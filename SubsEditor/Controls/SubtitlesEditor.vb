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

            TextBoxPreviousSubtitle.Dictionaries = mDictionaries
            TextBoxCurrentSubtitle.Dictionaries = mDictionaries
            TextBoxNextSubtitle.Dictionaries = mDictionaries
        End Set
    End Property

    Public Property SpellCheckerEngine As NHunspell.Hunspell
        Get
            Return mSpellCheckerEngine
        End Get
        Set(value As NHunspell.Hunspell)
            mSpellCheckerEngine = value

            TextBoxPreviousSubtitle.SpellCheckerEngine = mSpellCheckerEngine
            TextBoxCurrentSubtitle.SpellCheckerEngine = mSpellCheckerEngine
            TextBoxNextSubtitle.SpellCheckerEngine = mSpellCheckerEngine
        End Set
    End Property

    Private Sub UpdateUI()
        If mSubtitleIndex = -1 OrElse mSubtitleIndex >= mSubtitles.Count Then Exit Sub

        ignoreChangeEvents = True

        With mSubtitles(mSubtitleIndex)
            NumericUpDownHourStart.Text = .FromTimeOffsetted.Hours
            NumericUpDownMinuteStart.Text = .FromTimeOffsetted.Minutes
            NumericUpDownSecondStart.Text = .FromTimeOffsetted.Seconds
            NumericUpDownMilliSecondStart.Text = .FromTimeOffsetted.Milliseconds

            Select Case mode
                Case Modes.SetEnd
                    NumericUpDownHourEnd.Text = .ToTimeOffsetted.Hours
                    NumericUpDownMinuteEnd.Text = .ToTimeOffsetted.Minutes
                    NumericUpDownSecondEnd.Text = .ToTimeOffsetted.Seconds
                    NumericUpDownMilliSecondEnd.Text = .ToTimeOffsetted.Milliseconds
                Case Modes.SetLength
                    Dim length = .ToTimeOffsetted - .FromTimeOffsetted
                    NumericUpDownHourEnd.Text = length.Hours
                    NumericUpDownMinuteEnd.Text = length.Minutes
                    NumericUpDownSecondEnd.Text = length.Seconds
                    NumericUpDownMilliSecondEnd.Text = length.Milliseconds
            End Select

            TextBoxCurrentSubtitle.Text = .TextOffsetted
        End With

        If mSubtitleIndex = 0 Then
            TextBoxPreviousSubtitle.Text = ""
            TextBoxPreviousSubtitle.Enabled = False
        Else
            TextBoxPreviousSubtitle.Text = Subtitles(mSubtitleIndex - 1).TextOffsetted
            TextBoxPreviousSubtitle.Enabled = True
        End If

        If mSubtitleIndex > mSubtitles.Count - 2 Then
            TextBoxNextSubtitle.Text = ""
            TextBoxNextSubtitle.Enabled = False
        Else
            TextBoxNextSubtitle.Text = Subtitles(mSubtitleIndex + 1).TextOffsetted
            TextBoxNextSubtitle.Enabled = True
        End If

        VScrollBarSubtitles.Minimum = 0
        VScrollBarSubtitles.Maximum = mSubtitles.Count + 8 ' hmmm... what? why + 8?
        VScrollBarSubtitles.Value = mSubtitleIndex

        ignoreChangeEvents = False
    End Sub

    Private Sub TimeValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownHourStart.ValueChanged, NumericUpDownHourEnd.ValueChanged,
                                                                                          NumericUpDownMinuteStart.ValueChanged, NumericUpDownMinuteEnd.ValueChanged,
                                                                                          NumericUpDownSecondStart.ValueChanged, NumericUpDownSecondEnd.ValueChanged,
                                                                                          NumericUpDownMilliSecondStart.ValueChanged, NumericUpDownMilliSecondEnd.ValueChanged

        If ignoreChangeEvents Then Exit Sub

        If NumericUpDownMilliSecondEnd.Value = 1000 Then
            ignoreChangeEvents = True
            NumericUpDownMilliSecondEnd.Value = 0
            ignoreChangeEvents = False

            NumericUpDownSecondEnd.Value += 1
            Exit Sub
        ElseIf NumericUpDownMilliSecondEnd.Value = -1 Then
            ignoreChangeEvents = True
            NumericUpDownMilliSecondEnd.Value = 999
            ignoreChangeEvents = False

            NumericUpDownSecondEnd.Value -= 1
            Exit Sub
        End If

        If NumericUpDownSecondEnd.Value = 60 Then
            ignoreChangeEvents = True
            NumericUpDownSecondEnd.Value = 0
            ignoreChangeEvents = False

            NumericUpDownMinuteEnd.Value += 1
            Exit Sub
        ElseIf NumericUpDownSecondEnd.Value = -1 Then
            ignoreChangeEvents = True
            NumericUpDownSecondEnd.Value = 59
            ignoreChangeEvents = False

            NumericUpDownMinuteEnd.Value -= 1
            Exit Sub
        End If

        If NumericUpDownMinuteEnd.Value = 60 Then
            ignoreChangeEvents = True
            NumericUpDownMinuteEnd.Value = 0
            ignoreChangeEvents = False

            If NumericUpDownHourEnd.Value < 99 Then NumericUpDownHourEnd.Value += 1
            Exit Sub
        ElseIf NumericUpDownMinuteEnd.Value = -1 Then
            ignoreChangeEvents = True
            NumericUpDownMinuteEnd.Value = 59
            ignoreChangeEvents = False

            If NumericUpDownHourEnd.Value > 0 Then NumericUpDownHourEnd.Value -= 1
            Exit Sub
        End If

        ' -----------------------

        If NumericUpDownMilliSecondStart.Value = 1000 Then
            ignoreChangeEvents = True
            NumericUpDownMilliSecondStart.Value = 0
            ignoreChangeEvents = False

            NumericUpDownSecondStart.Value += 1
            Exit Sub
        ElseIf NumericUpDownMilliSecondStart.Value = -1 Then
            ignoreChangeEvents = True
            NumericUpDownMilliSecondStart.Value = 999
            ignoreChangeEvents = False

            NumericUpDownSecondStart.Value -= 1
            Exit Sub
        End If

        If NumericUpDownSecondStart.Value = 60 Then
            ignoreChangeEvents = True
            NumericUpDownSecondStart.Value = 0
            ignoreChangeEvents = False

            NumericUpDownMinuteStart.Value += 1
            Exit Sub
        ElseIf NumericUpDownSecondStart.Value = -1 Then
            ignoreChangeEvents = True
            NumericUpDownSecondStart.Value = 59
            ignoreChangeEvents = False

            NumericUpDownMinuteStart.Value -= 1
            Exit Sub
        End If

        If NumericUpDownMinuteStart.Value = 60 Then
            ignoreChangeEvents = True
            NumericUpDownMinuteStart.Value = 0
            ignoreChangeEvents = False

            If NumericUpDownHourStart.Value < 99 Then NumericUpDownHourStart.Value += 1
            Exit Sub
        ElseIf NumericUpDownMinuteStart.Value = -1 Then
            ignoreChangeEvents = True
            NumericUpDownMinuteStart.Value = 59
            ignoreChangeEvents = False

            If NumericUpDownHourStart.Value > 0 Then NumericUpDownHourStart.Value -= 1
            Exit Sub
        End If

        UpdateSubtitle()
    End Sub

    Private Sub TextBoxGotFocus(sender As Object, e As EventArgs)
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
            Subtitles(mSubtitleIndex).TextOffsetted = TextBoxCurrentSubtitle.Text

            If TextBoxPreviousSubtitle.Enabled Then Subtitles(mSubtitleIndex - 1).TextOffsetted = TextBoxPreviousSubtitle.Text
            If TextBoxNextSubtitle.Enabled Then Subtitles(mSubtitleIndex + 1).TextOffsetted = TextBoxNextSubtitle.Text

            RaiseEvent SubtitleChanged(Me, New SubtitleChangedEventArgs(Subtitles(mSubtitleIndex), mSubtitleIndex))

            'txtPreviousSubtitle.Invalidate()
            'txtCurrentSubtitle.Invalidate()
            'txtNextSubtitle.Invalidate()
        End If
    End Sub

    Private Sub RadioButtonEnd_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonEnd.CheckedChanged
        mode = Modes.SetEnd
        UpdateUI()
    End Sub

    Private Sub RadioButtonLength_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonLength.CheckedChanged
        mode = Modes.SetLength
        UpdateUI()
    End Sub

    Private Function StartToTimeSpan() As TimeSpan
        Return New TimeSpan(0, NumericUpDownHourStart.Value, NumericUpDownMinuteStart.Value, NumericUpDownSecondStart.Value, NumericUpDownMilliSecondStart.Value)
    End Function

    Private Function EndToTimeSpan() As TimeSpan
        Return New TimeSpan(0, NumericUpDownHourEnd.Value, NumericUpDownMinuteEnd.Value, NumericUpDownSecondEnd.Value, NumericUpDownMilliSecondEnd.Value)
    End Function

    Private Sub ButtonBold_Click(sender As Object, e As EventArgs) Handles ButtonBold.Click
        ToggleTag("<b>", "</b>")
    End Sub

    Private Sub ButtonItalic_Click(sender As Object, e As EventArgs) Handles ButtonItalic.Click
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

                ButtonColor.BackColor = Color.FromArgb(r, g, b)
            Else
                ButtonColor.BackColor = Color.White
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

    Private Sub ButtonColor_Click(sender As Object, e As EventArgs) Handles ButtonColor.Click
        Using dlg = New ColorDialog()
            dlg.Color = ButtonColor.BackColor
            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                ButtonColor.BackColor = dlg.Color

                ToggleTag(String.Format("<font color=""#{0}{1}{2}"">",
                                        dlg.Color.R.ToString("X").PadLeft(2, "0"),
                                        dlg.Color.G.ToString("X").PadLeft(2, "0"),
                                        dlg.Color.B.ToString("X").PadLeft(2, "0")),
                                    "</font>")
            End If
        End Using
    End Sub

    Private Sub VScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBarSubtitles.Scroll
        SubtitleIndex = VScrollBarSubtitles.Value
        RaiseEvent SubtitleIndexChanged(Me, New EventArgs())
    End Sub

    Private Sub SubtitlesEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        focusedTextBox = TextBoxCurrentSubtitle

        AddHandler TextBoxPreviousSubtitle.TextChanged, AddressOf UpdateSubtitle
        AddHandler TextBoxPreviousSubtitle.Click, AddressOf TextBoxClick
        AddHandler TextBoxPreviousSubtitle.GotFocus, AddressOf TextBoxGotFocus
        AddHandler TextBoxPreviousSubtitle.DictionaryChanged, AddressOf SetDefaultDictionary

        AddHandler TextBoxCurrentSubtitle.TextChanged, AddressOf UpdateSubtitle
        AddHandler TextBoxCurrentSubtitle.Click, AddressOf TextBoxClick
        AddHandler TextBoxCurrentSubtitle.GotFocus, AddressOf TextBoxGotFocus
        AddHandler TextBoxCurrentSubtitle.DictionaryChanged, AddressOf SetDefaultDictionary

        AddHandler TextBoxNextSubtitle.TextChanged, AddressOf UpdateSubtitle
        AddHandler TextBoxNextSubtitle.Click, AddressOf TextBoxClick
        AddHandler TextBoxNextSubtitle.GotFocus, AddressOf TextBoxGotFocus
        AddHandler TextBoxNextSubtitle.DictionaryChanged, AddressOf SetDefaultDictionary
    End Sub

    Private Sub SetDefaultDictionary(sender As Object, e As TextBoxWithSpellingSupport.DictionaryChangedEventArgs)
        mDictionaries.SetDefault(e.Dictionary.ID, e.Locale)
    End Sub
End Class
