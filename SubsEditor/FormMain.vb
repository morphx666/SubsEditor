﻿Imports Vlc.DotNet.Core
Imports System.Threading
Imports System.Net

Public Class FormMain
    Private validFileTypes() As String = {".avi", ".mpg", ".mp4", ".mkv", ".mov"}

    Private mMediaIsValid As Boolean = False
    Private vlcMedia As Medias.PathMedia
    Private videoFPS As Single
    Private isUpdatingUI As Boolean
    Private ignoreListViewSelectionEvent As Boolean

    Private Enum SubsFormats
        SRT
        [SUB]
        Unknown
    End Enum
    Private subsFormat As SubsFormats = SubsFormats.Unknown

    Public Enum SearchOptions
        None
        MatchCase
        WholeWord
    End Enum
    Private mSearchMode As SearchOptions = SearchOptions.None

    Private canCancelClose As Boolean = True
    Private checkForNewVersionThread As Thread
    Private extractAudioThread As Thread
    Private cancelExtractAudio As Boolean

    Private spellingEngine As NHunspell.Hunspell
    Private subtitles As SubtitlesList = New SubtitlesList()
    Private dictionaries As DictionariesList = New DictionariesList()

    Private tmpMediaDuration As Double

    Private dlgFindReplace As FormFindReplace
    Private mLastFindResult As Subtitle

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Controls Events"
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetUIState(False)

        Me.Text = "SubsEditor " + My.Application.Info.Version.ToString()

        AddEventHandlers()

        checkForNewVersionThread = New Thread(AddressOf CheckForNewVersion)
        checkForNewVersionThread.Start()

        SubtitlesEditorCtrl.Subtitles = subtitles
        SubtitlesEditorCtrl.Dictionaries = dictionaries
        SubtitlesBrowserCtrl.Subtitles = subtitles

        Initialize()
        LoadDictionaries()
        LoadSettings()
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSettings()

        If checkForNewVersionThread IsNot Nothing AndAlso checkForNewVersionThread.ThreadState = ThreadState.Running Then checkForNewVersionThread.Abort()
        If Not SaveChanges(True) Then e.Cancel = True
    End Sub

    Private Sub ToolStripMenuItemMainMenuEditUndo_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMainMenuEditUndo.Click
        MsgBox("Not Implemented", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
    End Sub

    Private Sub ToolStripMenuItemMainMenuEditRedo_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMainMenuEditRedo.Click
        MsgBox("Not Implemented", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
    End Sub

    Private Sub ToolStripMenuItemMainMenuExit_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMainMenuExit.Click
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItemMainMenuOpenSubtitle_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMainMenuOpenSubtitle.Click
        OpenSubtitle()
    End Sub

    Private Sub ToolStripMenuItemMainMenuNewSubtitle_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMainMenuNewSubtitle.Click
        If IO.File.Exists(TextBoxVideoFile.Text) Then
            Dim videoFile As IO.FileInfo = New IO.FileInfo(TextBoxVideoFile.Text)
            Dim subsFile As String = videoFile.FullName.Replace(videoFile.Extension, ".srt")
            IO.File.WriteAllText(subsFile, "")
            TextBoxSubtitlesFile.Text = subsFile
            LoadSubtitles(subsFile)
        Else
            MsgBox("Please open a video file first", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub HandleSearchSubtitle(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged, ButtonSearch.Click
        Dim offset As Integer = 0
        If TypeOf sender Is Button Then offset = 1

        SearchSubtitle(offset)
    End Sub

    Private Sub ButtonBrowseSubtitlesFile_Click(sender As Object, e As EventArgs) Handles ButtonBrowseSubtitlesFile.Click
        OpenSubtitle()
    End Sub

    Private Sub ToolStripMenuItemMainMenuSaveAs_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMainMenuSaveAs.Click
        Using dlg = New SaveFileDialog
            dlg.Filter = "Subtitles SRT File (*.srt)|*.srt|Subtitles SUB File (*.sub)|*.sub"
            dlg.Title = "Save Subtitles File"
            dlg.FileName = TextBoxSubtitlesFile.Text
            If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                TextBoxSubtitlesFile.Text = dlg.FileName
                If dlg.FileName.ToLower().EndsWith(".srt") Then
                    subsFormat = SubsFormats.SRT
                Else
                    subsFormat = SubsFormats.SUB
                End If
                SaveOffsettedSubtitles(True, False)
            End If
        End Using
    End Sub

    Private Sub ButtonBrowseVideoFile_Click(sender As Object, e As EventArgs) Handles ButtonBrowseVideoFile.Click
        OpenVideo()
    End Sub

    Private Sub ToolStripMenuItemMainMenuOpenVideo_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMainMenuOpenVideo.Click
        OpenVideo()
    End Sub

    Private Sub ToolStripMenuItemMainMenuSave_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMainMenuSave.Click
        SaveSubtitles()
    End Sub

    Private Sub ListViewSubtitles_DoubleClick(sender As Object, e As EventArgs) Handles ListViewSubtitles.DoubleClick
        EditSubtitle()
    End Sub

    Private Sub ListViewSubtitles_KeyUp(sender As Object, e As KeyEventArgs) Handles ListViewSubtitles.KeyUp
        Select Case e.KeyCode
            Case Keys.Delete : DeleteSelectedSubtitles()
            Case Keys.Insert : AddSubtitle()
        End Select
    End Sub

    Private Sub ListViewSubtitles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewSubtitles.SelectedIndexChanged
        If ignoreListViewSelectionEvent Then Exit Sub

        Dim c As Subtitle = GetSelectedSubtitle()

        If c IsNot Nothing Then
            If mMediaIsValid Then
                VideoPosition = c.FromTimeOffsetted
                UpdatePositionUI()
                If VlcCtrl.IsPlaying Then SubtitlesBrowserCtrl.CenterPosition(False)
            Else
                SubtitlesBrowserCtrl.Position = c.FromTimeOffsetted
                SubtitlesBrowserCtrl.CenterPosition(False)
            End If
        End If

        EditSubtitle()
    End Sub

    Private Sub VlcCtrl_PositionChanged(sender As Vlc.DotNet.Forms.VlcControl, e As VlcEventArgs(Of TimeSpan)) Handles VlcCtrl.TimeChanged
        UpdatePositionUI()

        Dim subtitleAtPosition = SubtitlesBrowserCtrl.GetSubtitleAtPosition()
        If subtitleAtPosition IsNot Nothing Then
            ignoreListViewSelectionEvent = True
            SelectSubtitle(subtitleAtPosition)
            ignoreListViewSelectionEvent = False
        End If
    End Sub

    Private Sub TrackBarPosition_ValueChanged(sender As Object, e As EventArgs) Handles TrackBarPosition.ValueChanged
        If isUpdatingUI Then Exit Sub
        VideoPosition = TimeSpan.FromMilliseconds(TrackBarPosition.Value / 1000000 * VlcCtrl.Duration.TotalMilliseconds)
        UpdatePositionUI()
    End Sub

    Private Sub ButtonPlay_Click(sender As Object, e As EventArgs) Handles ButtonPlay.Click
        TogglePlayPause()
    End Sub

    Private Sub ButtonPlay_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonPlay.EnabledChanged
        If ButtonPlay.Enabled Then
            ButtonPlay.Image = My.Resources.playpause_on
        Else
            ButtonPlay.Image = My.Resources.playpause_off
        End If
    End Sub

    Private Sub ButtonPlay_MouseDown(sender As Object, e As MouseEventArgs) Handles ButtonPlay.MouseDown
        If ButtonPlay.Enabled Then ButtonPlay.Image = My.Resources.playpause_on_down
    End Sub

    Private Sub ButtonPlay_MouseEnter(sender As Object, e As EventArgs) Handles ButtonPlay.MouseEnter
        If ButtonPlay.Enabled Then ButtonPlay.Image = My.Resources.playpause_on_over
    End Sub

    Private Sub ButtonPlay_MouseLeave(sender As Object, e As EventArgs) Handles ButtonPlay.MouseLeave
        If ButtonPlay.Enabled Then ButtonPlay.Image = My.Resources.playpause_on
    End Sub

    Private Sub ButtonPlay_MouseUp(sender As Object, e As MouseEventArgs) Handles ButtonPlay.MouseUp
        If ButtonPlay.Enabled Then ButtonPlay.Image = My.Resources.playpause_on
    End Sub

    Private Sub ComboBoxLanguages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxLanguages.SelectedIndexChanged
        VlcCtrl.AudioProperties.Track = CInt(ComboBoxLanguages.SelectedIndex + 1)
    End Sub

    Private Sub ButtonDeleteSubtitle_Click(sender As Object, e As EventArgs) Handles ButtonDeleteSubtitle.Click
        DeleteSelectedSubtitles()
    End Sub

    Private Sub SubtitlesBrowserCtrl_SubtitleChanged(sender As Object, e As SubtitlesBrowser.SubtitlesChangedEventArgs) Handles SubtitlesBrowserCtrl.SubtitlesChanged
        UpdateSubtitles(e.Subtitles)
    End Sub

    Private Sub SubtitlesBrowserCtrl_SubtitleSelected(sender As Object, e As SubtitlesBrowser.SubtitleSelectedEventArgs) Handles SubtitlesBrowserCtrl.SubtitleSelected
        SelectSubtitle(e.Subtitle)
        If e.Changed Then SaveOffsettedSubtitles(False, False)
    End Sub

    Private Sub SubtitlesBrowserCtrl_PositionChanged(sender As Object, e As SubtitlesBrowser.PositionChangedEventArgs) Handles SubtitlesBrowserCtrl.PositionChanged
        If e.Position.TotalMilliseconds >= 0 AndAlso (e.Position.TotalMilliseconds <= SubtitlesBrowserCtrl.MediaDuration.TotalMilliseconds) Then
            VideoPosition = e.Position
        End If
    End Sub

    Private Sub ButtonAddSubtitle_Click(sender As Object, e As EventArgs) Handles ButtonAddSubtitle.Click
        AddSubtitle()
    End Sub

    Private Sub ButtonZoomIn_Click(sender As Object, e As EventArgs) Handles ButtonZoomIn.Click
        SubtitlesBrowserCtrl.ZoomFactor += 1
    End Sub

    Private Sub ButtonZoomOut_Click(sender As Object, e As EventArgs) Handles ButtonZoomOut.Click
        SubtitlesBrowserCtrl.ZoomFactor -= 1
    End Sub

    Private Sub CheckBoxRippleEdits_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRippleEdits.CheckedChanged
        Select Case CheckBoxRippleEdits.Checked
            Case True
                CheckBoxRippleEdits.Image = My.Resources.lock
            Case False
                CheckBoxRippleEdits.Image = My.Resources.lock_open
        End Select
        SubtitlesBrowserCtrl.RippleEdits = CheckBoxRippleEdits.Checked
    End Sub

    Private Sub LinkLabelNewVersionDownload_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelNewVersionDownload.LinkClicked
        DownloadUpdate()
    End Sub

    Private Sub ToolStripMenuItemMainMenuEditOptions_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMainMenuEditOptions.Click
        Using f = New FormOptions()
            f.Dictionaries = dictionaries
            f.ShowDialog()
        End Using
    End Sub

    Private Sub ToolStripMenuItemMainMenuEditFind_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMainMenuEditFind.Click
        dlgFindReplace = New FormFindReplace()

        AddHandler dlgFindReplace.FormClosed, Sub() dlgFindReplace = Nothing
        AddHandler dlgFindReplace.SubtitleChanged, Sub(sende1 As Object, e1 As SubtitlesEditor.SubtitleChangedEventArgs)
                                                       UpdateListViewSubtitle(ListViewSubtitles, e1.Subtitle, , True)
                                                       SaveOffsettedSubtitles(False, False)
                                                   End Sub

        dlgFindReplace.Show(Me)
    End Sub
#End Region

    Public ReadOnly Property LastFindResult As Subtitle
        Get
            Return mLastFindResult
        End Get
    End Property

    Public Property SearchMode As SearchOptions
        Get
            Return mSearchMode
        End Get
        Set(value As SearchOptions)
            mSearchMode = value
            SearchSubtitle(0)
        End Set
    End Property

    Private Sub TryAutoLoadVideoFile(subtitlesFileName As String)
        Dim subsFile = New IO.FileInfo(subtitlesFileName)
        Dim subsFileName = subsFile.Name.Replace(subsFile.Extension, "")

        For Each file In subsFile.Directory.GetFiles()
            If validFileTypes.Contains(file.Extension) Then
                Dim videoFileName = file.Name.Replace(file.Extension, "")

                If videoFileName.Length <= subsFileName.Length AndAlso
                    subsFileName.Substring(0, videoFileName.Length) = videoFileName Then
                    TextBoxVideoFile.Text = file.FullName
                    LoadVideo(file.FullName)
                    Exit For
                End If
            End If
        Next
    End Sub

    ' http://en.wikipedia.org/wiki/WHATWG
    Private Sub LoadSubtitles(fileName As String, Optional autoLoadVideo As Boolean = True)
        subtitles.Clear()
        ListViewSubtitles.Items.Clear()
        SubtitlesBrowserCtrl.UpdateUI(True)
        SubtitlesBrowserCtrl.PeaksFileName = ""
        SetUIState(False)

        If autoLoadVideo Then TryAutoLoadVideoFile(fileName)
        If IO.File.Exists(fileName) Then
            Try
                If fileName.ToLower().EndsWith(".srt") Then
                    LoadSRTSubTitles(IO.File.ReadAllLines(fileName, System.Text.Encoding.UTF7))
                    subsFormat = SubsFormats.SRT
                ElseIf fileName.ToLower().EndsWith(".sub") Then
                    If mMediaIsValid Then
                        LoadSUBSubTitles(IO.File.ReadAllLines(fileName, System.Text.Encoding.UTF7))
                        subsFormat = SubsFormats.SUB
                    Else
                        Throw New Exception("Please load a valid video file before loading subtitles of the .sub format")
                    End If
                Else
                    Throw New Exception("Unsupported subtitles file format")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly)
                subsFormat = SubsFormats.Unknown
                Exit Sub
            End Try
        ElseIf fileName <> "" Then
            MsgBox("Subtitles File Not Found", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly)
        End If

        If ListViewSubtitles.Items.Count > 0 Then
            ListViewSubtitles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        Else
            ListViewSubtitles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        End If

        SetUIState(True)

        VlcCtrl.VideoProperties.SetSubtitleFile(TextBoxSubtitlesFile.Text)
        EditSubtitle()

        SubtitlesBrowserCtrl.UpdateUI(True)
        SubtitlesBrowserCtrl.Focus()
    End Sub

    Private Sub LoadSUBSubTitles(lines() As String)
        Dim index As Integer = 0

        For i As Integer = 0 To lines.Count - 1
            If Not lines(i).Contains("{") Then Continue For
            index += 1

            Dim startTime As TimeSpan = TimeSpan.FromMilliseconds(1000 * Integer.Parse(lines(i).Split("{"c)(1).TrimEnd("}")) / videoFPS)
            Dim endTime As TimeSpan = TimeSpan.FromMilliseconds(1000 * Integer.Parse(lines(i).Split("{"c)(2).Split("}")(0)) / videoFPS)
            Dim text As String = lines(i).Split("}")(2).Replace("|", vbCrLf)

            Dim c As Subtitle = New Subtitle(index,
                                        startTime,
                                        endTime,
                                        text)

            subtitles.Add(c)

            UpdateListViewSubtitle(ListViewSubtitles, c)
        Next
    End Sub

    Private Sub LoadSRTSubTitles(lines() As String)
        Dim index As Integer = 0

        For i As Integer = 0 To lines.Count - 1
            Do While i < lines.Count AndAlso lines(i) = ""
                i += 1
            Loop
            If i = lines.Count Then Exit For
            If lines(i + 1) = "" Then Continue For

            index += 1
            Dim startTime As String = lines(i + 1).Split(" "c)(0).Trim()
            Dim endTime As String = lines(i + 1).Split(" "c)(2).Trim()

            Dim text As String = ""
            i += 2
            Do While i < lines.Count AndAlso lines(i) <> ""
                text += lines(i) + vbCrLf
                i += 1
            Loop
            If text <> "" Then text = text.Substring(0, text.Length - 2)

            Dim c As Subtitle = New Subtitle(index,
                                        Subtitle.StringToTimeSpan(startTime),
                                        Subtitle.StringToTimeSpan(endTime),
                                        text)

            subtitles.Add(c)

            UpdateListViewSubtitle(ListViewSubtitles, c)
        Next
    End Sub

    Private Sub LoadVideo(fileName As String, Optional extractWaveForm As Boolean = True)
        SubtitlesBrowserCtrl.Position = TimeSpan.Zero
        ButtonPlay.Enabled = False
        TrackBarPosition.Enabled = False
        SubtitlesBrowserCtrl.MediaDuration = TimeSpan.Zero
        mMediaIsValid = False
        videoFPS = 23.976215

        If fileName <> "" AndAlso IO.File.Exists(fileName) Then
            If VlcCtrl.IsPlaying Then VlcCtrl.Stop()

            VlcCtrl.Media?.Dispose()

            vlcMedia = New Medias.PathMedia(fileName)
            VlcCtrl.Media = vlcMedia
            VlcCtrl.Play()

            Do
                Application.DoEvents()
                If vlcMedia.State = Interops.Signatures.LibVlc.Media.States.Error Then Exit Sub
            Loop Until vlcMedia.State = Interops.Signatures.LibVlc.Media.States.Playing

            If vlcMedia.State = Interops.Signatures.LibVlc.Media.States.Error Then Exit Sub

            VideoPosition = TimeSpan.Zero
            VlcCtrl.Pause()

            ComboBoxLanguages.Items.Clear()
            For i = 1 To VlcCtrl.AudioProperties.TrackCount - 1
                ComboBoxLanguages.Items.Add("Track " + i.ToString())
            Next
            If ComboBoxLanguages.Items.Count > 0 Then
                ComboBoxLanguages.Enabled = True
                ComboBoxLanguages.SelectedIndex = 0
            Else
                ComboBoxLanguages.Enabled = False
            End If

            ButtonPlay.Enabled = True
            TrackBarPosition.Enabled = True

            SubtitlesBrowserCtrl.MediaDuration = VlcCtrl.Duration
            mMediaIsValid = True

            videoFPS = VlcCtrl.FPS

            If extractWaveForm Then
                StopExtractingAudio()

                tmpMediaDuration = VlcCtrl.Duration.TotalSeconds

                VlcCtrl.Stop()
                VlcCtrl.Media.Dispose()
                vlcMedia.Dispose()

                extractAudioThread = New Thread(AddressOf ExtractAudio)
                extractAudioThread.Start()

                Application.DoEvents()

                LoadVideo(fileName, False)
            End If
        End If
    End Sub

    Private Sub StopExtractingAudio()
        If extractAudioThread IsNot Nothing AndAlso extractAudioThread.ThreadState = ThreadState.Running Then
            cancelExtractAudio = True

            Do
                Application.DoEvents()
            Loop While extractAudioThread.ThreadState = ThreadState.Running

            extractAudioThread = Nothing
        End If
        LabelExtractingAWF.Visible = False
        cancelExtractAudio = False
    End Sub

    Private Sub ExtractAudio()
        Dim UpdateProgressLabel = Sub(audioFileSize As Long, mediaDuration As Long)
                                      Me.Invoke(New MethodInvoker(Sub()
                                                                      LabelExtractingAWF.Visible = (audioFileSize <> 0)
                                                                      Select Case audioFileSize
                                                                          Case -1
                                                                              LabelExtractingAWF.Visible = True
                                                                              LabelExtractingAWF.Text = "Extracting Waveform..."
                                                                          Case -2
                                                                              LabelExtractingAWF.Visible = True
                                                                              LabelExtractingAWF.Text = "Generating Waveform..."
                                                                          Case -3
                                                                              LabelExtractingAWF.Visible = True
                                                                              LabelExtractingAWF.Text = "Loading Waveform..."
                                                                          Case Is > 0
                                                                              LabelExtractingAWF.Visible = True
                                                                              LabelExtractingAWF.Text = String.Format("Extracting Audio Waveform: {0:F2}%", audioFileSize / mediaDuration * 100)
                                                                      End Select
                                                                  End Sub))
                                  End Sub

        UpdateProgressLabel(-1, 0)

        Dim videoFile = New IO.FileInfo(TextBoxVideoFile.Text)
        Dim vlcFileName As String = IO.Path.Combine(VlcContext.LibVlcDllsPath, "vlc.exe")
        Dim audioFile = New IO.FileInfo(IO.Path.Combine(videoFile.DirectoryName, "audiowf.wav"))
        Dim peaksFile = New IO.FileInfo(IO.Path.Combine(videoFile.DirectoryName, "peaks.sep"))
        Dim wr As WavReader = Nothing

        If Not peaksFile.Exists Then
            If Not audioFile.Exists Then
                Dim factor As Integer = -1
                'Dim parameters = "-I dummy -vvv """ +
                '                txtVideoFile.Text +
                '                """ --sout=#transcode{vcodec=none,acodec=s16l,channels=1,ab=128,samplerate=8000}:standard{access=file,mux=wav,dst=""" +
                '                audioFile.FullName +
                '                """}  vlc://quit"

                Dim parameters = "-I dummy -vvv """ +
                                videoFile.FullName +
                                """ --sout=#transcode{vcodec=none,ab=128,acodec=s16l}:standard{access=file,mux=wav,dst=""" +
                                audioFile.FullName +
                                """}  vlc://quit"

                Dim stream = New IO.FileStream(audioFile.FullName, IO.FileMode.Create, IO.FileAccess.ReadWrite, IO.FileShare.ReadWrite)

                Dim vlcProcess = New Process With {
                    .StartInfo = New ProcessStartInfo(vlcFileName, parameters)
                }
                vlcProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                vlcProcess.Start()

                Do Until vlcProcess.HasExited
                    Application.DoEvents()
                    Thread.Sleep(1000)

                    If cancelExtractAudio Then
                        vlcProcess.Kill()
                        audioFile.Delete()
                        Exit Do
                    End If
                    Try
                        If stream.Length > 128 AndAlso factor = -1 Then
                            wr = New WavReader(stream)
                            factor = wr.Header.Channels * wr.Header.SampleRate * If(wr.Header.BitDepth = 8, 1, 2)
                        ElseIf factor <> -1 Then
                            UpdateProgressLabel(stream.Length / factor, tmpMediaDuration)
                        End If
                    Catch ex As Exception
                        Debug.WriteLine(ex.Message)
                    End Try
                Loop
            End If

            UpdateProgressLabel(-2, 0)
            If wr Is Nothing Then wr = New WavReader(audioFile.FullName)
            wr.SavePeaks(peaksFile.FullName)
            wr.Dispose()
            Try
                audioFile.Delete()
            Catch
            End Try
        End If

        If Not cancelExtractAudio Then
            UpdateProgressLabel(-3, 0)
            SubtitlesBrowserCtrl.PeaksFileName = peaksFile.FullName
        End If
        UpdateProgressLabel(0, 0)
    End Sub

    Private Sub SelectSubtitle(subtitle As Subtitle)
        If subtitle IsNot Nothing Then
            UpdateListViewSubtitle(ListViewSubtitles, subtitle, True)
            EditSubtitle()
        End If
    End Sub

    Public Sub UpdateListViewSubtitle(lv As ListView, c As Subtitle, Optional selectIt As Boolean = False, Optional autoResizeColumns As Boolean = False)
        Dim isOffsetted As Boolean = (lv.Name = ListViewSubtitles.Name)

        If lv.Items.Count >= c.Index Then
            With lv.Items(c.Index - 1)
                If isOffsetted Then
                    .SubItems(0).Text = FormatTimeStamp(c.FromTimeOffsetted)
                    .SubItems(1).Text = FormatTimeStamp(c.ToTimeOffsetted)
                    .SubItems(2).Text = c.TextOffsetted
                Else
                    .SubItems(0).Text = FormatTimeStamp(c.FromTimeOriginal)
                    .SubItems(1).Text = FormatTimeStamp(c.ToTimeOriginal)
                    .SubItems(2).Text = c.TextOriginal
                End If
                If selectIt Then
                    Do While lv.SelectedIndices.Count > 0
                        lv.SelectedItems(0).Selected = False
                    Loop
                    .Selected = True
                    .EnsureVisible()
                End If
            End With
        Else
            Dim newItem As ListViewItem
            If isOffsetted Then
                newItem = lv.Items.Add(FormatTimeStamp(c.FromTimeOffsetted))
                With newItem.SubItems
                    .Add(FormatTimeStamp(c.ToTimeOffsetted))
                    .Add(c.TextOffsetted)
                End With
            Else
                newItem = lv.Items.Add(FormatTimeStamp(c.FromTimeOriginal))
                With newItem.SubItems
                    .Add(FormatTimeStamp(c.ToTimeOriginal))
                    .Add(c.TextOriginal)
                End With
            End If

            If selectIt Then
                newItem.Selected = True
                newItem.EnsureVisible()
            End If
        End If

        'If autoResizeColumns Then lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub UpdateSubtitles(subtitles As List(Of Subtitle))
        For Each c In subtitles
            UpdateListViewSubtitle(ListViewSubtitles, c)
        Next

        SaveOffsettedSubtitles(False, False)
    End Sub

    Public Sub SaveOffsettedSubtitles(applyChanges As Boolean, isClosing As Boolean)
        Dim tmpFile As String = GetTempFile()
        Dim oldPosition As Integer = TrackBarPosition.Value
        Dim subtitleIndex As Integer = 0
        If GetSelectedSubtitle() IsNot Nothing Then subtitleIndex = GetSelectedSubtitle().Index

        Dim currentFPS As Single = videoFPS

        If applyChanges Then
            If IO.File.Exists(tmpFile) Then
                UnloadVLCMedia()
                IO.File.Delete(tmpFile)
            End If
            tmpFile = TextBoxSubtitlesFile.Text
        End If

        Dim w As IO.StreamWriter = New IO.StreamWriter(tmpFile, False, System.Text.Encoding.UTF8)
        If Not applyChanges OrElse subsFormat = SubsFormats.SRT Then
            For Each c In subtitles
                w.WriteLine(c.Index)
                w.WriteLine(c.GetOffsettedSRTTime())
                w.WriteLine(c.TextOffsetted)
                w.WriteLine()
            Next
        ElseIf subsFormat = SubsFormats.SUB Then
            For Each c In subtitles
                w.WriteLine(String.Format("{0}{1}", c.GetOffsettedSUBTime(currentFPS), c.TextOffsetted.Replace(vbCrLf, "|")))
            Next
        End If
        w.Close()

        If Not isClosing Then
            Dim mediaDuration = SubtitlesBrowserCtrl.MediaDuration
            If applyChanges Then LoadSubtitles(TextBoxSubtitlesFile.Text)
            SubtitlesBrowserCtrl.UpdateUI(False)

            If mMediaIsValid Then
                ' Workaround to solve the problem when VLC does not support any additional subtitle files.
                ' The only way (so far) to empty the list of added subtitle files is to re-load the video.
                If applyChanges OrElse VlcCtrl.VideoProperties.SpuCount > 70 Then
                    LoadVideo(TextBoxVideoFile.Text)

                    TrackBarPosition.Value = oldPosition
                    If subtitleIndex > 0 Then
                        With ListViewSubtitles.Items(subtitleIndex - 1)
                            .Selected = True
                            .EnsureVisible()
                        End With
                        SelectSubtitle(GetSelectedSubtitle())
                    End If
                End If

                VlcCtrl.VideoProperties.SetSubtitleFile(tmpFile)
                SubtitlesBrowserCtrl.MediaDuration = mediaDuration
            End If

            EditSubtitle()
        End If
    End Sub

    Private Sub UnloadVLCMedia()
        If mMediaIsValid Then VlcCtrl.Stop()
        'Dim media = New Medias.EmptyMedia("")
        'vlcCtrl.Media = media
        VlcCtrl.Medias.Clear()
    End Sub

    Private Function GetTempFile() As String
        Dim result As String = ""
        Try
            If TextBoxSubtitlesFile.Text <> "" Then
                Dim file As IO.FileInfo = New IO.FileInfo(TextBoxSubtitlesFile.Text)
                Dim path As String = file.DirectoryName
                Dim newName As String = file.Name.Replace(file.Extension, "") + ".Offsetted" + file.Extension
                result = IO.Path.Combine(path, newName)
            End If
        Catch
        End Try

        Return result
    End Function

    Private Sub UpdatePositionUI()
        isUpdatingUI = True

        Dim time = VideoPosition

        If SubtitlesBrowserCtrl.MediaDuration.TotalMilliseconds > 0 Then
            Try
                TrackBarPosition.Value = time.TotalMilliseconds / SubtitlesBrowserCtrl.MediaDuration.TotalMilliseconds * TrackBarPosition.Maximum
            Catch ex As Exception
                TrackBarPosition.Value = 0
            End Try
        End If
        LabelTime.Text = String.Format("{0:00}:{1:00}:{2:00},{3:000}",
                                    time.Hours,
                                    time.Minutes,
                                    time.Seconds,
                                    time.Milliseconds)

        SubtitlesBrowserCtrl.Position = time
        SubtitlesBrowserCtrl.CenterPosition(mMediaIsValid AndAlso VlcCtrl.IsPlaying)

        isUpdatingUI = False
    End Sub

    Private Property VideoPosition As TimeSpan
        Get
            If mMediaIsValid Then
                If VlcCtrl.IsPlaying Then
                    Return VlcCtrl.Time
                Else
                    Return TimeSpan.FromMilliseconds(VlcCtrl.Position * VlcCtrl.Duration.TotalMilliseconds)
                End If
            Else
                Return SubtitlesBrowserCtrl.Position
            End If
        End Get
        Set(value As TimeSpan)
            If mMediaIsValid Then
                If VlcCtrl.IsPlaying AndAlso VlcCtrl.Time <> value Then
                    VlcCtrl.Time = value
                Else
                    VlcCtrl.Position = value.TotalMilliseconds / VlcCtrl.Duration.TotalMilliseconds
                End If
            Else
                SubtitlesBrowserCtrl.Position = value
            End If

            UpdatePositionUI()
        End Set
    End Property

    Public Sub EditSubtitle()
        Dim c As Subtitle = GetSelectedSubtitle()

        If c Is Nothing Then
            SubtitlesEditorCtrl.SubtitleIndex = -1
        Else
            SubtitlesEditorCtrl.SubtitleIndex = c.Index - 1
        End If
        SubtitlesBrowserCtrl.SelectedSubtitle = c
    End Sub

    Private Function GetSelectedSubtitle() As Subtitle
        If ListViewSubtitles.SelectedItems.Count = 1 Then
            Return subtitles(ListViewSubtitles.SelectedIndices(0))
        Else
            Return Nothing
        End If
    End Function

    Public Function AddSubtitle() As Subtitle
        Dim newSubtitle As Subtitle = Nothing
        Dim selectedSubtitle As Subtitle = GetSelectedSubtitle()

        Dim previousSubtitle As Subtitle = Nothing
        Dim previousSubtitles = From c In subtitles Select c Where c.ToTimeOffsetted < SubtitlesBrowserCtrl.Position
        If previousSubtitles.Count > 0 Then previousSubtitle = previousSubtitles.Last()
        Dim index = If(previousSubtitle Is Nothing, 1, previousSubtitle.Index + 1)
        newSubtitle = New Subtitle(index,
                                    SubtitlesBrowserCtrl.Position,
                                    SubtitlesBrowserCtrl.Position + TimeSpan.FromSeconds(3),
                                    My.Resources.NewSubtitleText)

        For i As Integer = newSubtitle.Index - 1 To subtitles.Count - 1
            subtitles(i).Index += 1
        Next
        subtitles.Insert(newSubtitle.Index - 1, newSubtitle)
        With ListViewSubtitles.Items.Insert(newSubtitle.Index - 1, "").SubItems
            .Add("")
            .Add("")
        End With
        UpdateListViewSubtitle(ListViewSubtitles, newSubtitle, True, True)
        EditSubtitle()

        Return newSubtitle
    End Function

    Private Sub SetUIState(state As Boolean)
        ButtonAddSubtitle.Enabled = state
        ButtonDeleteSubtitle.Enabled = state
        CheckBoxRippleEdits.Enabled = state
        SubtitlesBrowserCtrl.Enabled = state
        TextBoxSearch.Enabled = state
        ButtonSearch.Enabled = state
    End Sub

    Private Sub CheckForNewVersion()
        Dim version As String
        Try
            Dim wc = New WebClient()
            Try
                version = wc.DownloadString("http://software.xfx.net/rsc/get-product-version.php?id=23")
            Catch
                Exit Sub
            End Try
            wc.Dispose()
            version = ExtractBody(version)

            If version.Contains(".") Then
                Dim latestVersion = New Version(version)
                If latestVersion > My.Application.Info.Version Then
                    'If MsgBox("A new version of SubsEditor is available" + vbCrLf +
                    '          "Current Version: " + My.Application.Info.Version.ToString() + vbCrLf +
                    '          "New Version: " + latestVersion.ToString() + vbCrLf + vbCrLf +
                    '          "Would you like to download it now?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = vbYes Then


                    'End If

                    Me.Invoke(New MethodInvoker(Sub()
                                                    LinkLabelNewVersionDownload.Text = "Download SubsEditor " + latestVersion.ToString()
                                                    LinkLabelNewVersionDownload.Visible = True
                                                    LabelNewVersionInfo.Visible = True
                                                End Sub))
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub DownloadUpdate()
        LinkLabelNewVersionDownload.Visible = False
        LabelNewVersionInfo.Visible = False

        LabelDownloading.Visible = True
        ProgressBarDownload.Visible = True

        Dim wc = New WebClient()
        Dim setupFile As String = ""

        Try
            setupFile = wc.DownloadString("http://software.xfx.net/rsc/get-product-setupfile.php?id=23")
            wc.Dispose()
            setupFile = ExtractBody(setupFile)
        Catch ex As Exception
            MsgBox("Update failed: Unable to get the installer's download link" + vbCrLf + ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly)
        End Try

        wc = New WebClient()
        AddHandler wc.DownloadProgressChanged, Sub(sender As Object, e As DownloadProgressChangedEventArgs)
                                                   Me.Invoke(New MethodInvoker(Sub() ProgressBarDownload.Value = e.ProgressPercentage))
                                               End Sub

        AddHandler wc.DownloadDataCompleted, Sub(sender As Object, e As DownloadDataCompletedEventArgs)
                                                 If Not e.Cancelled Then
                                                     Try
                                                         Dim tmpFile = My.Computer.FileSystem.GetTempFileName() + ".msi"
                                                         IO.File.WriteAllBytes(tmpFile, e.Result)
                                                         Process.Start(tmpFile)

                                                         canCancelClose = False
                                                         Me.Close()
                                                     Catch ex As Exception
                                                         MsgBox("Update failed: Unable to run the installer" + vbCrLf + ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly)
                                                     End Try
                                                 End If
                                             End Sub

        Try
            wc.DownloadDataAsync(New Uri(setupFile))
        Catch ex As Exception
            MsgBox("Update failed: Unable to start the installer download" + vbCrLf + ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Function ExtractBody(value As String) As String
        Try
            Dim p1 = value.IndexOf("<body>") + 6
            Dim p2 = value.IndexOf("<", p1)
            Return value.Substring(p1, p2 - p1).Trim()
        Catch
            Return ""
        End Try
    End Function

    Private Function SaveChanges(isClosing As Boolean) As Boolean
        StopExtractingAudio()
        If VlcCtrl.IsPlaying Then VlcCtrl.Stop()

        Dim tmpFile As String = GetTempFile()
        If IO.File.Exists(tmpFile) Then
            Select Case MsgBox("You have unsaved changes." + vbCrLf + "Would you like to apply them now?",
                               MsgBoxStyle.Question Or If(canCancelClose, MsgBoxStyle.YesNoCancel, MsgBoxStyle.YesNo))
                Case MsgBoxResult.No
                    UnloadVLCMedia()
                    IO.File.Delete(tmpFile)
                    Return True
                Case MsgBoxResult.Yes
                    SaveOffsettedSubtitles(True, isClosing)
                    Return True
                Case MsgBoxResult.Cancel
                    Return False
            End Select
        End If

        Return True
    End Function

    ' http://www.colourlovers.com
    Private Sub SetSubtitlesBrowserColors()
        '' Plumb Theme
        With SubtitlesBrowserCtrl
            .Font = New Font(Me.Font.FontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel)

            .ForeColor = Color.FromArgb(223, 210, 181)
            .BackColor = Color.FromArgb(58, 41, 51)

            .SubtitleBackColor = Color.FromArgb(128, 88, 74, 83)
            .SubtitleSelectedBackColor = Color.FromArgb(200, 100, 60, 75)

            .WaveFormColor = Color.FromArgb(240, 13, 99, 126)
            .WaveFormSelectedColor = Color.FromArgb(33, 119, 146)

            .GridTimeColor = Color.FromArgb(184, 166, 161)
            .GridTimeFont = New Font(.Font.FontFamily, 9, FontStyle.Regular, GraphicsUnit.Pixel)

            .PositionMarkerColor = Color.FromArgb(200, Color.LightBlue)
        End With

        '' Bluish
        'With sbCtrl
        '    .Font = New Font(Me.Font.FontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel)

        '    .ForeColor = Color.FromArgb(198, 204, 165)
        '    .BackColor = Color.FromArgb(97, 81, 69)

        '    .SubtitleBackColor = Color.FromArgb(128, 84, 120, 125)
        '    .SubtitleSelectedBackColor = Color.FromArgb(200, 107, 153, 151)

        '    .WaveFormColor = Color.FromArgb(240, 13, 99, 126)
        '    .WaveFormSelectedColor = Color.FromArgb(33, 119, 146)

        '    .GridTimeColor = Color.FromArgb(138, 184, 168)
        '    .GridTimeFont = New Font(.Font.FontFamily, 9, FontStyle.Regular, GraphicsUnit.Pixel)

        '    .PositionMarkerColor = Color.FromArgb(200, Color.LightBlue)
        'End With

        '' Brownish
        'With sbCtrl
        '    .Font = New Font(Me.Font.FontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel)

        '    .ForeColor = Color.FromArgb(226, 203, 146)
        '    .BackColor = Color.FromArgb(49, 44, 32)

        '    .SubtitleBackColor = Color.FromArgb(128, 73, 77, 75)
        '    .SubtitleSelectedBackColor = Color.FromArgb(200, 179, 161, 118)

        '    .WaveFormColor = Color.FromArgb(240, 13, 99, 126)
        '    .WaveFormSelectedColor = Color.FromArgb(33, 119, 146)

        '    .GridTimeColor = Color.FromArgb(124, 112, 82)
        '    .GridTimeFont = New Font(.Font.FontFamily, 9, FontStyle.Regular, GraphicsUnit.Pixel)

        '    .PositionMarkerColor = Color.FromArgb(200, Color.LightBlue)
        'End With

        ' Grayish
        'With sbCtrl
        '    .Font = New Font(Me.Font.FontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel)

        '    .ForeColor = Color.FromArgb(220, 220, 220)
        '    .BackColor = Color.FromArgb(78, 89, 90)

        '    .SubtitleBackColor = Color.FromArgb(128, 58, 69, 70)
        '    .SubtitleSelectedBackColor = Color.FromArgb(128, 114, 131, 122)

        '    .WaveFormColor = Color.FromArgb(220, 194, 252, 18)
        '    .WaveFormSelectedColor = Color.FromArgb(255, 255, 128, 0)

        '    .GridColor = .SubtitleBackColor
        '    .GridTimeColor = Color.FromArgb(154, 237, 119)
        '    .GridTimeFont = New Font(.Font.FontFamily, 9, FontStyle.Regular, GraphicsUnit.Pixel)

        '    .PositionMarkerColor = Color.FromArgb(200, Color.LightBlue)
        'End With

        Static isFirstTime = True
        If isFirstTime Then
            isFirstTime = False
            AddHandler SubtitlesBrowserCtrl.MouseClick, Sub(sender As Object, e As MouseEventArgs)
                                              If e.Button = Windows.Forms.MouseButtons.Right Then
                                                  SetSubtitlesBrowserColors()
                                              End If
                                          End Sub
        End If
    End Sub

    Private Sub TogglePlayPause()
        If mMediaIsValid Then
            If VlcCtrl.IsPlaying Then
                VlcCtrl.Pause()
            Else
                VlcCtrl.Play()
            End If
            ' FIXME: Freaking VLC seems to change the Duration at will... so we update it every time we start playing
            SubtitlesBrowserCtrl.MediaDuration = VlcCtrl.Duration
        End If
    End Sub

    Private Sub Initialize()
        AddHandler SubtitlesBrowserCtrl.ZoomFactorChanged, Sub() TrackBarZoom.Value = SubtitlesBrowserCtrl.ZoomFactor
        AddHandler SubtitlesBrowserCtrl.CreateNewSubtitle, Sub(sender As Object, e As SubtitlesBrowser.CreateNewSubtitleEventArgs)
                                                 Dim newSubtitle = AddSubtitle()
                                                 newSubtitle.FromTimeOffsetted = e.StartTime
                                                 newSubtitle.ToTimeOffsetted = e.EndTime
                                             End Sub
        AddHandler SubtitlesBrowserCtrl.EditSubtitle, Sub(sender As Object, e As SubtitlesBrowser.SubtitleSelectedEventArgs) EditSubtitle()
        AddHandler TrackBarZoom.Scroll, Sub() SubtitlesBrowserCtrl.ZoomFactor = Math.Min(TrackBarZoom.Value, TrackBarZoom.Maximum)
        AddHandler SubtitlesEditorCtrl.SubtitleIndexChanged, Sub()
                                                    With ListViewSubtitles.Items(SubtitlesEditorCtrl.SubtitleIndex)
                                                        .Selected = True
                                                        .EnsureVisible()
                                                    End With
                                                End Sub
        AddHandler SubtitlesEditorCtrl.SubtitleChanged, Sub(sender As Object, e As SubtitlesEditor.SubtitleChangedEventArgs)
                                               UpdateListViewSubtitle(ListViewSubtitles, e.Subtitle, , True)
                                               SaveOffsettedSubtitles(False, False)
                                           End Sub

        AddHandler dictionaries.DefaultDictionaryChanged, Sub()
                                                              SubtitlesEditorCtrl.SpellCheckerEngine = dictionaries.GetSpellingEngine()
                                                          End Sub

        SubtitlesBrowserCtrl.ZoomFactor = 100
        SetSubtitlesBrowserColors()

        If Not IO.Directory.Exists(Dictionary.DictionariesFolder) Then IO.Directory.CreateDirectory(Dictionary.DictionariesFolder)
    End Sub

    Private Sub SaveSettings()
        Dim xmlSettings = New XDocument()
        Dim data As XElement
        Dim defDict = dictionaries.GetDefaultDictionary()
        Dim defDictID = If(defDict Is Nothing, "", defDict.ID)
        Dim defDictLocale = If(defDict Is Nothing, "", defDict.Locale)

        data = <settings>
                   <mainWindow>
                       <main state=<%= Me.WindowState %> location=<%= Me.Location %> size=<%= Me.Size %>/>
                       <splitMain distance=<%= SplitContainerMain.SplitterDistance %>/>
                       <splitSubtitlesAndEditor distance=<%= SplitContainerSubtitlesAndEditor.SplitterDistance %>/>
                       <splitVideoAndBrowser distance=<%= SplitContainerVideoAndBrowser.SplitterDistance %>/>
                   </mainWindow>
                   <project>
                       <subtitles fileName=<%= TextBoxSubtitlesFile.Text %>/>
                       <video fileName=<%= TextBoxVideoFile.Text %>/>
                       <browser position=<%= VideoPosition.TotalMilliseconds %> zoom=<%= SubtitlesBrowserCtrl.ZoomFactor %> rippeEdits=<%= SubtitlesBrowserCtrl.RippleEdits %>/>
                       <editor index=<%= SubtitlesEditorCtrl.SubtitleIndex %>/>
                   </project>
                   <defaultDictionary id=<%= defDictID %> locale=<%= defDictLocale %>/>
               </settings>
        xmlSettings.Add(data)
        xmlSettings.Save(IO.Path.Combine(My.Application.Info.DirectoryPath, "settings.dat"))
    End Sub

    Private Sub LoadSettings()
        Dim fileName As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "settings.dat")

        If IO.File.Exists(fileName) Then
            Dim xmlSettings = XDocument.Load("settings.dat")

            Try
                Me.WindowState = StringToWindowState(xmlSettings.<settings>.<mainWindow>.<main>.@state)
                If Me.WindowState = FormWindowState.Normal Then
                    Me.Location = StringToPoint(xmlSettings.<settings>.<mainWindow>.<main>.@location)
                    Me.Size = StringToSize(xmlSettings.<settings>.<mainWindow>.<main>.@size)
                End If
            Catch
            End Try

            SplitContainerMain.SplitterDistance = Integer.Parse(xmlSettings.<settings>.<mainWindow>.<splitMain>.@distance)
            SplitContainerSubtitlesAndEditor.SplitterDistance = Integer.Parse(xmlSettings.<settings>.<mainWindow>.<splitSubtitlesAndEditor>.@distance)
            SplitContainerVideoAndBrowser.SplitterDistance = Integer.Parse(xmlSettings.<settings>.<mainWindow>.<splitVideoAndBrowser>.@distance)

            TextBoxVideoFile.Text = xmlSettings.<settings>.<project>.<video>.@fileName
            TextBoxSubtitlesFile.Text = xmlSettings.<settings>.<project>.<subtitles>.@fileName

            LoadVideo(TextBoxVideoFile.Text)
            LoadSubtitles(TextBoxSubtitlesFile.Text, False)

            Application.DoEvents()

            SubtitlesEditorCtrl.SubtitleIndex = xmlSettings.<settings>.<project>.<editor>.@index
            If SubtitlesEditorCtrl.SubtitleIndex <> -1 Then SelectSubtitle(subtitles(SubtitlesEditorCtrl.SubtitleIndex))
            SubtitlesBrowserCtrl.ZoomFactor = xmlSettings.<settings>.<project>.<browser>.@zoom
            SubtitlesBrowserCtrl.RippleEdits = StringToBoolean(xmlSettings.<settings>.<project>.<browser>.@zoom)
            VideoPosition = TimeSpan.FromMilliseconds(xmlSettings.<settings>.<project>.<browser>.@position)

            dictionaries.SetDefault(xmlSettings.<settings>.<defaultDictionary>.@id, xmlSettings.<settings>.<defaultDictionary>.@locale)
        End If

        SubtitlesBrowserCtrl.Focus()
    End Sub

    Private Sub OpenSubtitle()
        If SaveChanges(False) Then
            Using dlg = New OpenFileDialog()
                dlg.Filter = "Subtitles File (*.srt;*.sub)|*.srt;*.sub"
                dlg.Title = "Select Subtitles File"
                If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    TextBoxSubtitlesFile.Text = dlg.FileName
                    LoadSubtitles(TextBoxSubtitlesFile.Text)
                End If
            End Using
        End If
    End Sub

    Private Sub OpenVideo()
        Using dlg = New OpenFileDialog()
            dlg.Filter = "Video Files|" + String.Join(";", validFileTypes).Replace(".", "*.") + "|All Files|*.*"
            dlg.Title = "Select Video File"
            If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                TextBoxVideoFile.Text = dlg.FileName
                LoadVideo(dlg.FileName)
            End If
        End Using
    End Sub

    Private Sub SaveSubtitles()
        Me.Enabled = False
        SaveOffsettedSubtitles(True, False)
        Me.Enabled = True
    End Sub

    Private Sub LoadDictionaries()
        dictionaries.Clear()
        For Each directory In New IO.DirectoryInfo(Dictionary.DictionariesFolder).GetDirectories()
            dictionaries.Add(New Dictionary(directory.FullName))
        Next
    End Sub

    Private Sub AddEventHandlers()
        AddHandler SubtitlesBrowserCtrl.KeyDown, Sub(sender As Object, e As KeyEventArgs) If e.KeyCode = Keys.Space Then TogglePlayPause()
        AddHandler VlcCtrl.KeyDown, Sub(sender As Object, e As KeyEventArgs) If e.KeyCode = Keys.Space Then TogglePlayPause()
        AddHandler ButtonPlay.KeyDown, Sub(sender As Object, e As KeyEventArgs) If e.KeyCode = Keys.Space Then TogglePlayPause()
        AddHandler ListViewSubtitles.KeyDown, Sub(sender As Object, e As KeyEventArgs) If e.KeyCode = Keys.Space Then TogglePlayPause()
    End Sub

    Public Sub SearchSubtitle(offset As Integer)
        TextBoxSearch.BackColor = Color.FromKnownColor(KnownColor.Window)
        TextBoxSearch.ForeColor = Color.FromKnownColor(KnownColor.WindowText)

        If TextBoxSearch.Text = "" Then
            mLastFindResult = Nothing
            Exit Sub
        End If

        Dim startIndex As Integer = 0
        If ListViewSubtitles.SelectedItems.Count > 0 Then
            startIndex = GetLastSelectedIndex() + offset
            If startIndex = ListViewSubtitles.Items.Count Then startIndex = 0
        End If

        Dim filter As String = If(mSearchMode And SearchOptions.MatchCase = SearchOptions.MatchCase, TextBoxSearch.Text, TextBoxSearch.Text.ToLower())
        Dim match As ListViewItem = Nothing
        If ListViewSubtitles.Items.Count > 0 Then
            Do
                For i As Integer = startIndex To subtitles.Count - 1
                    Dim subtitleText = subtitles(i).TextOffsetted
                    Dim isMatch As Boolean
                    If mSearchMode = SearchOptions.None Then
                        isMatch = subtitleText.ToLower().Contains(filter)
                    Else
                        Dim isWholeWord = True
                        Dim isCase = True

                        If (mSearchMode And SearchOptions.WholeWord) = SearchOptions.WholeWord Then
                            isWholeWord = False
                            For Each word In TextBoxWithSpellingSupport.GetWords(subtitleText)
                                If word.Word.ToLower() = filter.ToLower() Then
                                    isWholeWord = True
                                    Exit For
                                End If
                            Next
                        End If

                        If (mSearchMode And SearchOptions.MatchCase) = SearchOptions.MatchCase Then
                            isCase = subtitleText.Contains(filter)
                        End If

                        isMatch = isWholeWord And isCase
                    End If

                    If isMatch Then
                        match = ListViewSubtitles.Items(i)
                        Exit For
                    End If
                Next
                If match IsNot Nothing OrElse startIndex = 0 Then Exit Do
                startIndex = 0
            Loop
        End If

        If match Is Nothing Then
            TextBoxSearch.BackColor = Color.DarkRed
            TextBoxSearch.ForeColor = Color.White
            mLastFindResult = Nothing
        Else
            match.Selected = True
            match.EnsureVisible()
            mLastFindResult = subtitles(match.Index)

            SelectAllButLast()
        End If
    End Sub

    Public Sub SearchMisspelling(offset As Integer)
        Dim startIndex As Integer = 0
        If ListViewSubtitles.SelectedItems.Count > 0 Then
            startIndex = GetLastSelectedIndex() + offset
            If startIndex = ListViewSubtitles.Items.Count Then startIndex = 0
        End If

        Dim se = dictionaries.GetSpellingEngine()
        Dim match As ListViewItem = Nothing
        If ListViewSubtitles.Items.Count > 0 Then
            Do
                For i As Integer = startIndex To subtitles.Count - 1
                    For Each word In TextBoxWithSpellingSupport.GetWords(subtitles(i).TextOffsetted)
                        If Not se.Spell(word.Word) Then
                            match = ListViewSubtitles.Items(i)
                            Exit For
                        End If
                    Next
                    If match IsNot Nothing Then Exit For
                Next
                If match IsNot Nothing OrElse startIndex = 0 Then Exit Do
                startIndex = 0
            Loop
        End If
        se.Dispose()

        If match Is Nothing Then
            TextBoxSearch.BackColor = Color.DarkRed
            TextBoxSearch.ForeColor = Color.White
            mLastFindResult = Nothing
        Else
            match.Selected = True
            match.EnsureVisible()
            mLastFindResult = subtitles(match.Index)

            SelectAllButLast()
        End If
    End Sub

    Public Sub SelectFirstSubtitle()
        If ListViewSubtitles.Items.Count > 0 Then
            ListViewSubtitles.Items(0).Selected = True
            ListViewSubtitles.Items(0).EnsureVisible()
        End If
    End Sub

    Private Sub DeleteSelectedSubtitles()
        If ListViewSubtitles.SelectedItems.Count = 0 Then Exit Sub

        Dim indexes(ListViewSubtitles.SelectedIndices.Count - 1) As Integer
        ListViewSubtitles.SelectedIndices.CopyTo(indexes, 0)

        For Each index As Integer In indexes
            Dim c = subtitles(ListViewSubtitles.SelectedIndices(0))
            subtitles.Remove(c)

            For i As Integer = c.Index - 1 To subtitles.Count - 1
                subtitles(i).Index -= 1
            Next

            ListViewSubtitles.Items.Remove(ListViewSubtitles.SelectedItems(0))
        Next

        SaveOffsettedSubtitles(False, False)
    End Sub

    Private Function GetLastSelectedIndex() As Integer
        If ListViewSubtitles.SelectedIndices.Count > 0 Then
            SelectAllButLast()
            Return ListViewSubtitles.SelectedIndices(0)
        Else
            Return -1
        End If
    End Function

    Private Sub SelectAllButLast()
        Do While ListViewSubtitles.SelectedIndices.Count > 1
            ListViewSubtitles.Items(ListViewSubtitles.SelectedIndices(0)).Selected = False
        Loop
    End Sub
End Class
