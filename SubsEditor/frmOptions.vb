Imports System.Threading
Imports System.Net
Imports HtmlAgilityPack

Public Class frmOptions
    Private Class IdentifiableWebClient
        Inherits WebClient

        Public Property ID As Guid

        Public Sub New()
            MyBase.New()
            ID = Guid.NewGuid()
        End Sub
    End Class

    Private Class OnlineDictionary
        Public Property Name As String
        Public Property LanguageName As String
        Public Property DownloadLink As String
        Public Property SystemName As String
        Public Property Description As String
        Public Property IsDownloading As Boolean
        Public Property WebClient As IdentifiableWebClient
        Public Property ListViewItem As ListViewItem
        Public Property DownloadThread As Thread
        Public Property TargetFile As String
        Public Property Directory As IO.DirectoryInfo
        Public Property [Error] As Exception

        Public Sub New(name As String, languageName As String, downloadLink As String, description As String)
            If languageName = "" Then languageName = name

            Me.Name = name
            Me.LanguageName = languageName
            Me.DownloadLink = downloadLink
            Me.Description = description

            Dim tokens() = downloadLink.Split("/"c)
            SystemName = tokens(tokens.Length - 1)

            TargetFile = IO.Path.Combine(Dictionary.DictionariesFolder, SystemName + ".zip")

            Dim file = New IO.FileInfo(TargetFile)
            Directory = New IO.DirectoryInfo(file.FullName.Replace(file.Extension, ""))
        End Sub
    End Class

    Private mDictionaries As DictionariesList

    Private onlineDictionaries As List(Of OnlineDictionary) = New List(Of OnlineDictionary)
    Private Const provider = "http://ftp.nluug.nl/office/openoffice/contrib/dictionaries/"
    Private loadDictionariesThread As Thread

    Private ignoreUIEvents As Boolean

    Public Property Dictionaries As DictionariesList
        Get
            Return mDictionaries
        End Get
        Set(value As DictionariesList)
            mDictionaries = value

            FetchDictionaries()
            SafeUpdateComboBox()
        End Set
    End Property

    Private Sub SafeUpdateComboBox()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateComboBox))
        Else
            UpdateComboBox()
        End If
    End Sub

    Private Sub UpdateComboBox()
        ignoreUIEvents = True

        cbDictionaries.Items.Clear()
        For Each d In mDictionaries
            Dim index = cbDictionaries.Items.Add(d)
            If d.IsDefault Then cbDictionaries.SelectedIndex = index
        Next
        PopulateLocales()

        ignoreUIEvents = False
    End Sub

    Private Sub PopulateLocales()
        cbLocales.Items.Clear()

        Dim d = CType(cbDictionaries.SelectedItem, Dictionary)
        If d Is Nothing Then
            cbLocales.Enabled = False
        Else
            For Each l In d.Locales
                Dim index = cbLocales.Items.Add(l)
                If d.Locale = l Then cbLocales.SelectedIndex = index
            Next

            If cbLocales.SelectedIndex = -1 Then cbLocales.SelectedIndex = 0
            cbLocales.Enabled = True
        End If
    End Sub

    Private Sub PopulateDictionariesList()
        ignoreUIEvents = True

        For Each d In onlineDictionaries
            d.ListViewItem = lvDictionaries.Items.Add(d.LanguageName)
            With d.ListViewItem
                .SubItems.Add(d.Description)

                .Tag = d

                .Checked = d.Directory.Exists
                If .Checked Then
                    .SubItems.Add("Downloaded")
                Else
                    .SubItems.Add("")
                End If
            End With
        Next

        lvDictionaries.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
        ignoreUIEvents = False

        PopulateLocales()
    End Sub

    Private Sub DoneDownloading(dictionary As OnlineDictionary, Optional errorMessage As String = "")
        Me.Invoke(New MethodInvoker(Sub()
                                        lblLoading.Visible = False
                                        pbLoading.Visible = False

                                        If dictionary Is Nothing Then
                                            If errorMessage <> "" Then MsgBox(errorMessage + vbCrLf + vbCrLf + "You may re-try the process by clicking the Refresh button", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
                                            ignoreUIEvents = False
                                        Else
                                            dictionary.IsDownloading = False

                                            For Each item As ListViewItem In lvDictionaries.Items
                                                If item.Tag.Equals(dictionary) Then
                                                    ignoreUIEvents = True
                                                    item.Checked = False
                                                    item.SubItems(chStatus.Index).Text = errorMessage
                                                    Application.DoEvents()
                                                    ignoreUIEvents = False
                                                    Exit For
                                                End If
                                            Next
                                        End If

                                        btnRefresh.Enabled = True
                                    End Sub))
    End Sub

    Private Sub DownloadDictionaries()
        Dim wc = New WebClient()
        Dim data As String

        wc.Encoding = System.Text.Encoding.UTF8
        Try
            data = wc.DownloadString(provider)
        Catch ex As Exception
            DoneDownloading(Nothing, "Unable to fetch dictionaries list" + vbCrLf + ex.Message)
            Exit Sub
        End Try

        Dim p As Integer = 0
        Dim htmlDoc As New HtmlDocument()
        htmlDoc.LoadHtml(data)

        For Each lnk In htmlDoc.DocumentNode.SelectNodes("//a[contains(@href, 'zip')]")
            onlineDictionaries.Add(ParseData(lnk))
        Next

        Me.Invoke(New MethodInvoker(AddressOf PopulateDictionariesList))
        DoneDownloading(Nothing)
    End Sub

    Private Function ParseData(lnk As HtmlNode) As OnlineDictionary
        Dim name As String = lnk.InnerText
        Dim languageName As String = lnk.InnerText
        Dim downloadLink As String = provider + lnk.InnerText
        Dim description As String = lnk.InnerText

        Return New OnlineDictionary(name, languageName, downloadLink, description)
    End Function

    Private Sub lvDictionaries_ItemCheck(sender As Object, e As System.Windows.Forms.ItemCheckEventArgs) Handles lvDictionaries.ItemCheck
        If ignoreUIEvents Then Exit Sub

        Dim item = lvDictionaries.Items(e.Index)
        Dim d = CType(lvDictionaries.Items(e.Index).Tag, OnlineDictionary)

        If e.CurrentValue = CheckState.Checked Then
            If d.IsDownloading Then
                If MsgBox("Are you sure you want to cancel downloading the '" + d.Name + "' dictionary?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    d.WebClient.CancelAsync()
                Else
                    e.NewValue = e.CurrentValue
                End If
            ElseIf d.Error Is Nothing Then
                If MsgBox("Are you sure you want to delete the '" + d.Name + "' dictionary?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim file = New IO.FileInfo(d.TargetFile)
                    Dim directory = New IO.DirectoryInfo(file.FullName.Replace(file.Extension, ""))
                    If directory.Exists Then directory.Delete(True)
                    item.SubItems(chStatus.Index).Text = ""

                    Dim dicts = (From dict In mDictionaries Where dict.Directory = directory.FullName Select dict)
                    If dicts.Any() Then mDictionaries.Remove(dicts.First())
                    SafeUpdateComboBox()
                Else
                    ignoreUIEvents = True
                    e.NewValue = CheckState.Checked
                    ignoreUIEvents = False
                End If
            End If
        Else
            Dim downloadThread = New Thread(New ParameterizedThreadStart(AddressOf DownloadDictionary))
            d.DownloadThread = downloadThread
            d.ListViewItem.SubItems(chStatus.Index).Text = "Initializing..."
            d.Error = Nothing
            downloadThread.Start(item)
        End If
    End Sub

    Private Sub DownloadDictionary(item As ListViewItem)
        Dim dictionary As OnlineDictionary = CType(item.Tag, OnlineDictionary)
        Dim tmpFile = New IO.FileInfo(IO.Path.GetTempFileName())

        Dim wc = New IdentifiableWebClient()

        AddHandler wc.DownloadFileCompleted, Sub(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs)
                                                 Dim d = GetDictionaryFromWebClient(CType(sender, IdentifiableWebClient))

                                                 d.IsDownloading = False
                                                 Me.Invoke(New MethodInvoker(Sub()
                                                                                 If e.Error IsNot Nothing Then
                                                                                     d.ListViewItem.SubItems(chStatus.Index).Text = e.Error.Message
                                                                                     d.ListViewItem.Checked = False
                                                                                     d.Error = e.Error
                                                                                 Else
                                                                                     If e.Cancelled Then
                                                                                         d.ListViewItem.SubItems(chStatus.Index).Text = "Cancelled"
                                                                                         d.ListViewItem.Checked = False
                                                                                     Else
                                                                                         d.ListViewItem.SubItems(chStatus.Index).Text = "Successfully Downloaded"
                                                                                     End If
                                                                                 End If
                                                                             End Sub))

                                                 If e.Cancelled OrElse e.Error IsNot Nothing Then Exit Sub

                                                 If IO.File.Exists(d.TargetFile) Then IO.File.Delete(d.TargetFile)
                                                 tmpFile.MoveTo(d.TargetFile)

                                                 Try
                                                     System.IO.Compression.ZipStorer.UnZip(tmpFile.FullName)
                                                 Catch ex As Exception
                                                     DoneDownloading(d, "'" + item.Text + "' appears to be an Invalid dictionary" + vbCrLf + ex.Message)
                                                     Exit Sub
                                                 End Try

                                                 Try
                                                     IO.File.Delete(d.TargetFile)
                                                 Catch ex As Exception
                                                     Exit Sub
                                                 End Try

                                                 mDictionaries.Add(New Dictionary(d.Directory.FullName))
                                                 SafeUpdateComboBox()
                                             End Sub

        AddHandler wc.DownloadProgressChanged, Sub(sender As Object, e As DownloadProgressChangedEventArgs)
                                                   Dim d = GetDictionaryFromWebClient(CType(sender, IdentifiableWebClient))
                                                   If d Is Nothing Then Exit Sub
                                                   Me.Invoke(New MethodInvoker(Sub()
                                                                                   d.ListViewItem.SubItems(chStatus.Index).Text = "Downloading: " + e.ProgressPercentage.ToString() + "%"
                                                                               End Sub))
                                               End Sub

        Try
            Me.Invoke(New MethodInvoker(Sub()
                                            dictionary.ListViewItem.SubItems(chStatus.Index).Text = "Downloading..."
                                        End Sub))

            dictionary.IsDownloading = True
            dictionary.WebClient = wc
            wc.DownloadFileAsync(New Uri(dictionary.DownloadLink), tmpFile.FullName)
            dictionary.IsDownloading = True
        Catch ex As Exception
            DoneDownloading(dictionary, "Unable to download dictionary for '" + item.Text + "'" + vbCrLf + ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Delegate Function GetDictionaryFromWebClientDelegate(wc As IdentifiableWebClient) As OnlineDictionary
    Private Function GetDictionaryFromWebClient(wc As IdentifiableWebClient) As OnlineDictionary
        Return Me.Invoke(New GetDictionaryFromWebClientDelegate(Function(iwc As IdentifiableWebClient)
                                                                    For Each item As ListViewItem In lvDictionaries.Items
                                                                        Dim d = CType(item.Tag, OnlineDictionary)
                                                                        If d.WebClient IsNot Nothing AndAlso d.WebClient.ID = iwc.ID Then Return d
                                                                    Next
                                                                    Return Nothing
                                                                End Function), wc)
    End Function

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        FetchDictionaries()
    End Sub

    Private Sub FetchDictionaries()
        lvDictionaries.Items.Clear()
        btnRefresh.Enabled = False

        lblLoading.Visible = True
        pbLoading.Visible = True
        ignoreUIEvents = True

        loadDictionariesThread = New Thread(AddressOf DownloadDictionaries)
        loadDictionariesThread.Start()
    End Sub

    Private Sub cbDefaultDictionary_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbDictionaries.SelectedIndexChanged
        If ignoreUIEvents Then Exit Sub

        If cbDictionaries.SelectedItem Is Nothing Then
            mDictionaries.SetDefault(Nothing, "")
        Else
            PopulateLocales()
        End If
    End Sub

    Private Sub cbLocales_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbLocales.SelectedIndexChanged
        mDictionaries.SetDefault(CType(cbDictionaries.SelectedItem, Dictionary).ID, cbLocales.Text)
    End Sub
End Class