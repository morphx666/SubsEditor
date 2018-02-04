Imports System.Threading
Imports System.ComponentModel

Public Class SubtitlesEditor
    Private Enum Modes
        SetEnd
        SetLength
    End Enum

    Private mSubtitles As SubtitlesList
    Private mSubtitleIndex As Integer = -1

    Private delayedDisableUI As Timer = New Timer(New TimerCallback(Sub() Me.Invoke(New MethodInvoker(Sub() Me.Enabled = False))),
                                                  Nothing, Timeout.Infinite, Timeout.Infinite)
    Private ignoreChangeEvents As Boolean
    Private mode As Modes = Modes.SetEnd
    Private focusedTextBox As TextBoxWithSpellingSupport

    Private mSpellCheckerEngine As NHunspell.Hunspell
    Private mDictionaries As DictionariesList

    Public Class SubtitleChangedEventArgs
        Inherits EventArgs

        Private mSubtitle As Subtitle
        Private mSubtitleIndex As Integer

        Public Sub New(subtitle As Subtitle, index As Integer)
            mSubtitle = subtitle
            mSubtitleIndex = index
        End Sub

        Public ReadOnly Property Subtitle As Subtitle
            Get
                Return mSubtitle
            End Get
        End Property

        Public ReadOnly Property SubtitleIndex As Integer
            Get
                Return mSubtitleIndex
            End Get
        End Property
    End Class

    Public Event SubtitleIndexChanged(sender As Object, e As EventArgs)
    Public Event SubtitleChanged(sender As Object, e As SubtitleChangedEventArgs)

    <Browsable(False)>
    Public Property Subtitles As SubtitlesList
        Get
            Return mSubtitles
        End Get
        Set(value As SubtitlesList)
            mSubtitles = value

            If mSubtitles IsNot Nothing Then
                AddHandler mSubtitles.CollectionChanged, Sub(sender1 As Object, e1 As Specialized.NotifyCollectionChangedEventArgs)
                                                             If e1.Action = Specialized.NotifyCollectionChangedAction.Reset Then mSubtitleIndex = -1
                                                             UpdateUI()
                                                         End Sub
            End If
        End Set
    End Property

    <Browsable(False)>
    Public Property SubtitleIndex As Integer
        Get
            Return mSubtitleIndex
        End Get
        Set(value As Integer)
            If value < 0 OrElse value >= mSubtitles.Count Then value = -1
            mSubtitleIndex = value

            If value = -1 Then
                delayedDisableUI.Change(500, Timeout.Infinite)
            Else
                delayedDisableUI.Change(Timeout.Infinite, Timeout.Infinite)
                Me.Enabled = True

                UpdateUI()
            End If
        End Set
    End Property

    <Browsable(False)>
    Public Property Dictionaries As DictionariesList
        Get
            Return mDictionaries
        End Get
        Set(value As DictionariesList)
            mDictionaries = value

            txtPreviousSubtitle.Dictionaries = mDictionaries
            txtCurrentSubtitle.Dictionaries = mDictionaries
            txtNextSubtitle.Dictionaries = mDictionaries
        End Set
    End Property

    Public Property SpellCheckerEngine As NHunspell.Hunspell
        Get
            Return mSpellCheckerEngine
        End Get
        Set(value As NHunspell.Hunspell)
            mSpellCheckerEngine = value

            txtPreviousSubtitle.SpellCheckerEngine = mSpellCheckerEngine
            txtCurrentSubtitle.SpellCheckerEngine = mSpellCheckerEngine
            txtNextSubtitle.SpellCheckerEngine = mSpellCheckerEngine
        End Set
    End Property

    Private Sub UpdateUI()
        If mSubtitleIndex = -1 OrElse mSubtitleIndex >= mSubtitles.Count Then Exit Sub

        ignoreChangeEvents = True

        With mSubtitles(mSubtitleIndex)
            nudHourStart.Text = .FromTimeOffsetted.Hours
            nudMinuteStart.Text = .FromTimeOffsetted.Minutes
            nudSecondStart.Text = .FromTimeOffsetted.Seconds
            nudMilliSecondStart.Text = .FromTimeOffsetted.Milliseconds

            Select Case mode
                Case Modes.SetEnd
                    nudHourEnd.Text = .ToTimeOffsetted.Hours
                    nudMinuteEnd.Text = .ToTimeOffsetted.Minutes
                    nudSecondEnd.Text = .ToTimeOffsetted.Seconds
                    nudMilliSecondEnd.Text = .ToTimeOffsetted.Milliseconds
                Case Modes.SetLength
                    Dim length = .ToTimeOffsetted - .FromTimeOffsetted
                    nudHourEnd.Text = length.Hours
                    nudMinuteEnd.Text = length.Minutes
                    nudSecondEnd.Text = length.Seconds
                    nudMilliSecondEnd.Text = length.Milliseconds
            End Select

            txtCurrentSubtitle.Text = .TextOffsetted
        End With

        If mSubtitleIndex = 0 Then
            txtPreviousSubtitle.Text = ""
            txtPreviousSubtitle.Enabled = False
        Else
            txtPreviousSubtitle.Text = Subtitles(mSubtitleIndex - 1).TextOffsetted
            txtPreviousSubtitle.Enabled = True
        End If

        If mSubtitleIndex > mSubtitles.Count - 2 Then
            txtNextSubtitle.Text = ""
            txtNextSubtitle.Enabled = False
        Else
            txtNextSubtitle.Text = Subtitles(mSubtitleIndex + 1).TextOffsetted
            txtNextSubtitle.Enabled = True
        End If

        vsBar.Minimum = 0
        vsBar.Maximum = mSubtitles.Count + 8 ' hmmm... what? why + 8?
        vsBar.Value = mSubtitleIndex

        ignoreChangeEvents = False
    End Sub

    Private Sub TimeValueChanged(sender As System.Object, e As System.EventArgs) Handles nudHourStart.ValueChanged, nudHourEnd.ValueChanged,
                                                                                          nudMinuteStart.ValueChanged, nudMinuteEnd.ValueChanged,
                                                                                          nudSecondStart.ValueChanged, nudSecondEnd.ValueChanged,
                                                                                          nudMilliSecondStart.ValueChanged, nudMilliSecondEnd.ValueChanged

        If ignoreChangeEvents Then Exit Sub

        If nudMilliSecondEnd.Value = 1000 Then
            ignoreChangeEvents = True
            nudMilliSecondEnd.Value = 0
            ignoreChangeEvents = False

            nudSecondEnd.Value += 1
            Exit Sub
        ElseIf nudMilliSecondEnd.Value = -1 Then
            ignoreChangeEvents = True
            nudMilliSecondEnd.Value = 999
            ignoreChangeEvents = False

            nudSecondEnd.Value -= 1
            Exit Sub
        End If

        If nudSecondEnd.Value = 60 Then
            ignoreChangeEvents = True
            nudSecondEnd.Value = 0
            ignoreChangeEvents = False

            nudMinuteEnd.Value += 1
            Exit Sub
        ElseIf nudSecondEnd.Value = -1 Then
            ignoreChangeEvents = True
            nudSecondEnd.Value = 59
            ignoreChangeEvents = False

            nudMinuteEnd.Value -= 1
            Exit Sub
        End If

        If nudMinuteEnd.Value = 60 Then
            ignoreChangeEvents = True
            nudMinuteEnd.Value = 0
            ignoreChangeEvents = False

            If nudHourEnd.Value < 99 Then nudHourEnd.Value += 1
            Exit Sub
        ElseIf nudMinuteEnd.Value = -1 Then
            ignoreChangeEvents = True
            nudMinuteEnd.Value = 59
            ignoreChangeEvents = False

            If nudHourEnd.Value > 0 Then nudHourEnd.Value -= 1
            Exit Sub
        End If

        ' -----------------------

        If nudMilliSecondStart.Value = 1000 Then
            ignoreChangeEvents = True
            nudMilliSecondStart.Value = 0
            ignoreChangeEvents = False

            nudSecondStart.Value += 1
            Exit Sub
        ElseIf nudMilliSecondStart.Value = -1 Then
            ignoreChangeEvents = True
            nudMilliSecondStart.Value = 999
            ignoreChangeEvents = False

            nudSecondStart.Value -= 1
            Exit Sub
        End If

        If nudSecondStart.Value = 60 Then
            ignoreChangeEvents = True
            nudSecondStart.Value = 0
            ignoreChangeEvents = False

            nudMinuteStart.Value += 1
            Exit Sub
        ElseIf nudSecondStart.Value = -1 Then
            ignoreChangeEvents = True
            nudSecondStart.Value = 59
            ignoreChangeEvents = False

            nudMinuteStart.Value -= 1
            Exit Sub
        End If

        If nudMinuteStart.Value = 60 Then
            ignoreChangeEvents = True
            nudMinuteStart.Value = 0
            ignoreChangeEvents = False

            If nudHourStart.Value < 99 Then nudHourStart.Value += 1
            Exit Sub
        ElseIf nudMinuteStart.Value = -1 Then
            ignoreChangeEvents = True
            nudMinuteStart.Value = 59
            ignoreChangeEvents = False

            If nudHourStart.Value > 0 Then nudHourStart.Value -= 1
            Exit Sub
        End If

        UpdateSubtitle()
    End Sub

    Private Sub TextBoxGotFocus(sender As Object, e As System.EventArgs)
        focusedTextBox = CType(sender, TextBoxWithSpellingSupport)
    End Sub

    Private Sub UpdateSubtitle()
        If ignoreChangeEvents Then Exit Sub

        If mSubtitleIndex <> -1 Then
            Subtitles(mSubtitleIndex).FromTimeOffsetted = StartToTimeSpan()

            Select Case mode
                Case Modes.SetEnd
                    Subtitles(mSubtitleIndex).ToTimeOffsetted = EndToTimeSpan()
                Case Modes.SetLength
                    Subtitles(mSubtitleIndex).ToTimeOffsetted = StartToTimeSpan() + EndToTimeSpan()
            End Select
            Subtitles(mSubtitleIndex).TextOffsetted = txtCurrentSubtitle.Text

            If txtPreviousSubtitle.Enabled Then Subtitles(mSubtitleIndex - 1).TextOffsetted = txtPreviousSubtitle.Text
            If txtNextSubtitle.Enabled Then Subtitles(mSubtitleIndex + 1).TextOffsetted = txtNextSubtitle.Text

            RaiseEvent SubtitleChanged(Me, New SubtitleChangedEventArgs(Subtitles(mSubtitleIndex), mSubtitleIndex))

            'txtPreviousSubtitle.Invalidate()
            'txtCurrentSubtitle.Invalidate()
            'txtNextSubtitle.Invalidate()
        End If
    End Sub

    Private Sub rbEnd_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbEnd.CheckedChanged
        mode = Modes.SetEnd
        UpdateUI()
    End Sub

    Private Sub rbLength_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbLength.CheckedChanged
        mode = Modes.SetLength
        UpdateUI()
    End Sub

    Private Function StartToTimeSpan() As TimeSpan
        Return New TimeSpan(0, nudHourStart.Value, nudMinuteStart.Value, nudSecondStart.Value, nudMilliSecondStart.Value)
    End Function

    Private Function EndToTimeSpan() As TimeSpan
        Return New TimeSpan(0, nudHourEnd.Value, nudMinuteEnd.Value, nudSecondEnd.Value, nudMilliSecondEnd.Value)
    End Function

    Private Sub btnBold_Click(sender As System.Object, e As System.EventArgs) Handles btnBold.Click
        ToggleTag("<b>", "</b>")
    End Sub

    Private Sub btnItalic_Click(sender As System.Object, e As System.EventArgs) Handles btnItalic.Click
        ToggleTag("<i>", "</i>")
    End Sub

    Private Sub TextBoxClick()
        Try
            Dim p = GetInnerText("<font color", "</font>")
            Dim innerText As String = focusedTextBox.Text.Substring(p(0), p(1) - p(0))

            If innerText.StartsWith("<font color") AndAlso innerText.EndsWith("</font>") Then
                Dim hexColor As String = innerText.Split("#")(1).Split("""")(0)

                Dim r As Integer = Integer.Parse(hexColor.Substring(0, 2), Globalization.NumberStyles.HexNumber)
                Dim g As Integer = Integer.Parse(hexColor.Substring(2, 2), Globalization.NumberStyles.HexNumber)
                Dim b As Integer = Integer.Parse(hexColor.Substring(4, 2), Globalization.NumberStyles.HexNumber)

                btnColor.BackColor = Color.FromArgb(r, g, b)
            Else
                btnColor.BackColor = Color.White
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub ToggleTag(openingTag As String, closingTag As String)
        Try
            Dim p = GetInnerText(openingTag, closingTag)
            Dim innerText As String = focusedTextBox.Text.Substring(p(0), p(1) - p(0))

            If innerText.StartsWith(openingTag) AndAlso innerText.EndsWith(closingTag) Then
                focusedTextBox.Text = focusedTextBox.Text.Substring(0, p(0)) +
                                innerText.Substring(openingTag.Length, innerText.Length - (openingTag.Length + closingTag.Length)) +
                                focusedTextBox.Text.Substring(p(1))
            Else
                focusedTextBox.Text = focusedTextBox.Text.Substring(0, p(0)) + openingTag + innerText + closingTag + focusedTextBox.Text.Substring(p(1))
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Function GetInnerText(openingTag As String, closingTag As String) As Integer()
        If focusedTextBox.SelectedText <> "" Then Return {focusedTextBox.SelectionStart, focusedTextBox.SelectionStart + focusedTextBox.SelectionLength}

        If openingTag.Contains(" ") Then openingTag = openingTag.Split(" ")(0)

        If focusedTextBox.SelectionStart = 0 OrElse focusedTextBox.SelectionStart = focusedTextBox.TextLength - 1 Then
            Return {0, focusedTextBox.TextLength}
        Else
            Dim startIndex As Integer
            Dim endIndex As Integer
            Dim testIndex As Integer

            For startIndex = focusedTextBox.SelectionStart To 0 Step -1
                If startIndex = focusedTextBox.TextLength Then Continue For

                If focusedTextBox.Text(startIndex) = ">" Then
                    Do
                        testIndex = FindChar("<", startIndex, -1)
                        If testIndex = startIndex Then
                            Exit Do
                        Else
                            startIndex = testIndex
                        End If
                        If focusedTextBox.Text.Substring(startIndex, openingTag.Length) = openingTag Then
                            startIndex -= 1
                            Exit For
                        End If
                    Loop
                End If
            Next
            startIndex += 1

            For endIndex = focusedTextBox.SelectionStart To focusedTextBox.TextLength - 1
                If focusedTextBox.Text(endIndex) = "<" Then
                    Do
                        testIndex = FindChar(">", endIndex, 1)
                        If testIndex = endIndex Then
                            Exit Do
                        Else
                            endIndex = testIndex
                        End If
                        If focusedTextBox.Text.Substring(endIndex - closingTag.Length + 1, closingTag.Length) = closingTag Then
                            endIndex += 1
                            Exit For
                        End If
                    Loop
                End If
            Next

            Return {startIndex, endIndex}
        End If
    End Function

    Private Function FindChar(c As Char, position As Integer, direction As Integer) As Integer
        Do Until focusedTextBox.Text(position) = c OrElse position = 0 OrElse position = focusedTextBox.TextLength - 1
            position += direction
        Loop

        Return position
    End Function

    Private Sub btnColor_Click(sender As System.Object, e As System.EventArgs) Handles btnColor.Click
        Using dlg = New ColorDialog()
            dlg.Color = btnColor.BackColor
            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                btnColor.BackColor = dlg.Color

                ToggleTag(String.Format("<font color=""#{0}{1}{2}"">",
                                        dlg.Color.R.ToString("X").PadLeft(2, "0"),
                                        dlg.Color.G.ToString("X").PadLeft(2, "0"),
                                        dlg.Color.B.ToString("X").PadLeft(2, "0")),
                                    "</font>")
            End If
        End Using
    End Sub

    Private Sub vsBar_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles vsBar.Scroll
        SubtitleIndex = vsBar.Value
        RaiseEvent SubtitleIndexChanged(Me, New EventArgs())
    End Sub

    Private Sub SubtitlesEditor_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        focusedTextBox = txtCurrentSubtitle

        AddHandler txtPreviousSubtitle.TextChanged, AddressOf UpdateSubtitle
        AddHandler txtPreviousSubtitle.Click, AddressOf TextBoxClick
        AddHandler txtPreviousSubtitle.GotFocus, AddressOf TextBoxGotFocus
        AddHandler txtPreviousSubtitle.DictionaryChanged, AddressOf SetDefaultDictionary

        AddHandler txtCurrentSubtitle.TextChanged, AddressOf UpdateSubtitle
        AddHandler txtCurrentSubtitle.Click, AddressOf TextBoxClick
        AddHandler txtCurrentSubtitle.GotFocus, AddressOf TextBoxGotFocus
        AddHandler txtCurrentSubtitle.DictionaryChanged, AddressOf SetDefaultDictionary

        AddHandler txtNextSubtitle.TextChanged, AddressOf UpdateSubtitle
        AddHandler txtNextSubtitle.Click, AddressOf TextBoxClick
        AddHandler txtNextSubtitle.GotFocus, AddressOf TextBoxGotFocus
        AddHandler txtNextSubtitle.DictionaryChanged, AddressOf SetDefaultDictionary
    End Sub

    Private Sub SetDefaultDictionary(sender As Object, e As TextBoxWithSpellingSupport.DictionaryChangedEventArgs)
        mDictionaries.SetDefault(e.Dictionary.ID, e.Locale)
    End Sub
End Class
