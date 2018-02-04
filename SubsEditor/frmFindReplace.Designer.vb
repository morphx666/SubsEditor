<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFindReplace
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFindReplace))
        Me.rbText = New System.Windows.Forms.RadioButton()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.rbMisspelledSubtitles = New System.Windows.Forms.RadioButton()
        Me.cbMatchCase = New System.Windows.Forms.CheckBox()
        Me.cbMatchWholeWord = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReplace = New System.Windows.Forms.TextBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnReplace = New System.Windows.Forms.Button()
        Me.btnReplaceAll = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rbText
        '
        Me.rbText.AutoSize = True
        Me.rbText.Checked = True
        Me.rbText.Location = New System.Drawing.Point(12, 12)
        Me.rbText.Name = "rbText"
        Me.rbText.Size = New System.Drawing.Size(45, 17)
        Me.rbText.TabIndex = 0
        Me.rbText.TabStop = True
        Me.rbText.Text = "Text"
        Me.rbText.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(81, 11)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(226, 22)
        Me.txtSearch.TabIndex = 2
        '
        'rbMisspelledSubtitles
        '
        Me.rbMisspelledSubtitles.AutoSize = True
        Me.rbMisspelledSubtitles.Location = New System.Drawing.Point(12, 113)
        Me.rbMisspelledSubtitles.Name = "rbMisspelledSubtitles"
        Me.rbMisspelledSubtitles.Size = New System.Drawing.Size(128, 17)
        Me.rbMisspelledSubtitles.TabIndex = 0
        Me.rbMisspelledSubtitles.Text = "Misspelled Subtitles"
        Me.rbMisspelledSubtitles.UseVisualStyleBackColor = True
        '
        'cbMatchCase
        '
        Me.cbMatchCase.AutoSize = True
        Me.cbMatchCase.Location = New System.Drawing.Point(81, 39)
        Me.cbMatchCase.Name = "cbMatchCase"
        Me.cbMatchCase.Size = New System.Drawing.Size(85, 17)
        Me.cbMatchCase.TabIndex = 3
        Me.cbMatchCase.Text = "Match Case"
        Me.cbMatchCase.UseVisualStyleBackColor = True
        '
        'cbMatchWholeWord
        '
        Me.cbMatchWholeWord.AutoSize = True
        Me.cbMatchWholeWord.Location = New System.Drawing.Point(81, 62)
        Me.cbMatchWholeWord.Name = "cbMatchWholeWord"
        Me.cbMatchWholeWord.Size = New System.Drawing.Size(127, 17)
        Me.cbMatchWholeWord.TabIndex = 3
        Me.cbMatchWholeWord.Text = "Match Whole Word"
        Me.cbMatchWholeWord.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Replace"
        '
        'txtReplace
        '
        Me.txtReplace.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReplace.Location = New System.Drawing.Point(81, 85)
        Me.txtReplace.Name = "txtReplace"
        Me.txtReplace.Size = New System.Drawing.Size(226, 22)
        Me.txtReplace.TabIndex = 2
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFind.Location = New System.Drawing.Point(70, 160)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 23)
        Me.btnFind.TabIndex = 5
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'btnReplace
        '
        Me.btnReplace.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReplace.Location = New System.Drawing.Point(151, 160)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.Size = New System.Drawing.Size(75, 23)
        Me.btnReplace.TabIndex = 6
        Me.btnReplace.Text = "Replace"
        Me.btnReplace.UseVisualStyleBackColor = True
        '
        'btnReplaceAll
        '
        Me.btnReplaceAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReplaceAll.Location = New System.Drawing.Point(232, 160)
        Me.btnReplaceAll.Name = "btnReplaceAll"
        Me.btnReplaceAll.Size = New System.Drawing.Size(75, 23)
        Me.btnReplaceAll.TabIndex = 6
        Me.btnReplaceAll.Text = "Replace All"
        Me.btnReplaceAll.UseVisualStyleBackColor = True
        '
        'frmFindReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 196)
        Me.Controls.Add(Me.btnReplaceAll)
        Me.Controls.Add(Me.btnReplace)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbMatchWholeWord)
        Me.Controls.Add(Me.cbMatchCase)
        Me.Controls.Add(Me.rbText)
        Me.Controls.Add(Me.rbMisspelledSubtitles)
        Me.Controls.Add(Me.txtReplace)
        Me.Controls.Add(Me.txtSearch)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(335, 230)
        Me.Name = "frmFindReplace"
        Me.Text = "Find / Replace"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbText As System.Windows.Forms.RadioButton
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents rbMisspelledSubtitles As System.Windows.Forms.RadioButton
    Friend WithEvents cbMatchCase As System.Windows.Forms.CheckBox
    Friend WithEvents cbMatchWholeWord As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReplace As System.Windows.Forms.TextBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnReplace As System.Windows.Forms.Button
    Friend WithEvents btnReplaceAll As System.Windows.Forms.Button
End Class
