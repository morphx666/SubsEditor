Public Class frmFindReplace
    Private mainForm As frmMain

    Public Event SubtitleChanged(sender As Object, e As SubtitlesEditor.SubtitleChangedEventArgs)

    Private Sub frmFindReplace_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mainForm = CType(Me.Owner, frmMain)
        txtSearch.Text = mainForm.txtSearch.Text

        AddHandler txtSearch.TextChanged, Sub()
                                              mainForm.txtSearch.Text = txtSearch.Text
                                              SetupUI()
                                          End Sub
        AddHandler mainForm.txtSearch.TextChanged, Sub() txtSearch.Text = mainForm.txtSearch.Text
        AddHandler mainForm.txtSearch.BackColorChanged, Sub() txtSearch.BackColor = mainForm.txtSearch.BackColor
        AddHandler mainForm.txtSearch.ForeColorChanged, Sub() txtSearch.ForeColor = mainForm.txtSearch.ForeColor
        AddHandler rbText.CheckedChanged, AddressOf SetupUI
        AddHandler rbMisspelledSubtitles.CheckedChanged, AddressOf SetupUI
        AddHandler btnFind.Click, Sub() Find()
    End Sub

    Private Sub Find()
        If rbText.Checked Then
            mainForm.SearchSubtitle(1)
        Else
            mainForm.SearchMisspelling(1)
        End If
        SetupUI()
    End Sub

    Private Sub cbMatchCase_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbMatchCase.CheckedChanged
        If cbMatchCase.Checked Then
            mainForm.SearchMode = mainForm.SearchMode Or frmMain.SearchOptions.MatchCase
        Else
            mainForm.SearchMode = mainForm.SearchMode And Not frmMain.SearchOptions.MatchCase
        End If
        Find()
    End Sub

    Private Sub cbMatchWholeWord_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbMatchWholeWord.CheckedChanged
        If cbMatchWholeWord.Checked Then
            mainForm.SearchMode = mainForm.SearchMode Or frmMain.SearchOptions.WholeWord
        Else
            mainForm.SearchMode = mainForm.SearchMode And Not frmMain.SearchOptions.WholeWord
        End If
        Find()
    End Sub

    Private Sub SetupUI()
        Dim state As Boolean = If(rbText.Checked, True, False)
        Dim resultIsValid As Boolean

        If mainForm Is Nothing Then
            resultIsValid = state
        Else
            resultIsValid = mainForm.LastFindResult IsNot Nothing
        End If

        txtSearch.Enabled = state
        txtReplace.Enabled = state
        cbMatchCase.Enabled = state
        cbMatchWholeWord.Enabled = state
        btnReplace.Enabled = resultIsValid
        btnReplaceAll.Enabled = resultIsValid
    End Sub

    Private Sub btnReplace_Click(sender As System.Object, e As System.EventArgs) Handles btnReplace.Click
        ReplaceText()
    End Sub

    Private Sub btnReplaceAll_Click(sender As System.Object, e As System.EventArgs) Handles btnReplaceAll.Click
        mainForm.SelectFirstSubtitle()
        Do While mainForm.LastFindResult IsNot Nothing
            If Not ReplaceText() Then Exit Do
            Find()
        Loop
    End Sub

    Private Function ReplaceText() As Boolean
        Dim searchText = txtSearch.Text.ToLower()
        Dim currentText = mainForm.LastFindResult.TextOffsetted.ToLower()
        Dim p1 = currentText.IndexOf(searchText)
        If p1 = -1 Then Return False
        mainForm.LastFindResult.TextOffsetted = mainForm.LastFindResult.TextOffsetted.Substring(0, p1) + txtReplace.Text + mainForm.LastFindResult.TextOffsetted.Substring(p1 + searchText.Length)

        RaiseEvent SubtitleChanged(Me, New SubtitlesEditor.SubtitleChangedEventArgs(mainForm.LastFindResult, mainForm.LastFindResult.Index))
        
        Return True
    End Function
End Class