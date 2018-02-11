Public Class FormFindReplace
    Private mainForm As FormMain

    Public Event SubtitleChanged(sender As Object, e As SubtitlesEditor.SubtitleChangedEventArgs)

    Private Sub FormFindReplace_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mainForm = CType(Me.Owner, FormMain)
        TextBoxSearch.Text = mainForm.TextBoxSearch.Text

        AddHandler TextBoxSearch.TextChanged, Sub()
                                                  mainForm.TextBoxSearch.Text = TextBoxSearch.Text
                                                  SetupUI()
                                              End Sub
        AddHandler mainForm.TextBoxSearch.TextChanged, Sub() TextBoxSearch.Text = mainForm.TextBoxSearch.Text
        AddHandler mainForm.TextBoxSearch.BackColorChanged, Sub() TextBoxSearch.BackColor = mainForm.TextBoxSearch.BackColor
        AddHandler mainForm.TextBoxSearch.ForeColorChanged, Sub() TextBoxSearch.ForeColor = mainForm.TextBoxSearch.ForeColor
        AddHandler RadioButtonText.CheckedChanged, AddressOf SetupUI
        AddHandler RadioButtonMisspelledSubtitles.CheckedChanged, AddressOf SetupUI
        AddHandler ButtonFind.Click, Sub() Find()
    End Sub

    Private Sub Find()
        If RadioButtonText.Checked Then
            mainForm.SearchSubtitle(1)
        Else
            mainForm.SearchMisspelling(1)
        End If
        SetupUI()
    End Sub

    Private Sub CheckBoxMatchCase_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMatchCase.CheckedChanged
        If CheckBoxMatchCase.Checked Then
            mainForm.SearchMode = mainForm.SearchMode Or FormMain.SearchOptions.MatchCase
        Else
            mainForm.SearchMode = mainForm.SearchMode And Not FormMain.SearchOptions.MatchCase
        End If
        Find()
    End Sub

    Private Sub CheckBoxMatchWholeWord_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMatchWholeWord.CheckedChanged
        If CheckBoxMatchWholeWord.Checked Then
            mainForm.SearchMode = mainForm.SearchMode Or FormMain.SearchOptions.WholeWord
        Else
            mainForm.SearchMode = mainForm.SearchMode And Not FormMain.SearchOptions.WholeWord
        End If
        Find()
    End Sub

    Private Sub SetupUI()
        Dim state As Boolean = If(RadioButtonText.Checked, True, False)
        Dim resultIsValid As Boolean

        If mainForm Is Nothing Then
            resultIsValid = state
        Else
            resultIsValid = mainForm.LastFindResult IsNot Nothing
        End If

        TextBoxSearch.Enabled = state
        TextBoxReplace.Enabled = state
        CheckBoxMatchCase.Enabled = state
        CheckBoxMatchWholeWord.Enabled = state
        ButtonReplace.Enabled = resultIsValid
        ButtonReplaceAll.Enabled = resultIsValid
    End Sub

    Private Sub ButtonReplace_Click(sender As Object, e As EventArgs) Handles ButtonReplace.Click
        ReplaceText()
    End Sub

    Private Sub ButtonReplaceAll_Click(sender As Object, e As EventArgs) Handles ButtonReplaceAll.Click
        mainForm.SelectFirstSubtitle()
        Do While mainForm.LastFindResult IsNot Nothing
            If Not ReplaceText() Then Exit Do
            Find()
        Loop
    End Sub

    Private Function ReplaceText() As Boolean
        Dim searchText = TextBoxSearch.Text.ToLower()
        Dim currentText = mainForm.LastFindResult.TextOffsetted.ToLower()
        Dim p1 = currentText.IndexOf(searchText)
        If p1 = -1 Then Return False
        mainForm.LastFindResult.TextOffsetted = mainForm.LastFindResult.TextOffsetted.Substring(0, p1) + TextBoxReplace.Text + mainForm.LastFindResult.TextOffsetted.Substring(p1 + searchText.Length)

        RaiseEvent SubtitleChanged(Me, New SubtitlesEditor.SubtitleChangedEventArgs(mainForm.LastFindResult, mainForm.LastFindResult.Index))
        
        Return True
    End Function
End Class