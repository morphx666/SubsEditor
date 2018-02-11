<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFindReplace
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFindReplace))
        Me.RadioButtonText = New System.Windows.Forms.RadioButton()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.RadioButtonMisspelledSubtitles = New System.Windows.Forms.RadioButton()
        Me.CheckBoxMatchCase = New System.Windows.Forms.CheckBox()
        Me.CheckBoxMatchWholeWord = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxReplace = New System.Windows.Forms.TextBox()
        Me.ButtonFind = New System.Windows.Forms.Button()
        Me.ButtonReplace = New System.Windows.Forms.Button()
        Me.ButtonReplaceAll = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RadioButtonText
        '
        Me.RadioButtonText.AutoSize = True
        Me.RadioButtonText.Checked = True
        Me.RadioButtonText.Location = New System.Drawing.Point(12, 12)
        Me.RadioButtonText.Name = "RadioButtonText"
        Me.RadioButtonText.Size = New System.Drawing.Size(44, 17)
        Me.RadioButtonText.TabIndex = 0
        Me.RadioButtonText.TabStop = True
        Me.RadioButtonText.Text = "Text"
        Me.RadioButtonText.UseVisualStyleBackColor = True
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSearch.Location = New System.Drawing.Point(81, 11)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(226, 22)
        Me.TextBoxSearch.TabIndex = 2
        '
        'RadioButtonMisspelledSubtitles
        '
        Me.RadioButtonMisspelledSubtitles.AutoSize = True
        Me.RadioButtonMisspelledSubtitles.Location = New System.Drawing.Point(12, 113)
        Me.RadioButtonMisspelledSubtitles.Name = "RadioButtonMisspelledSubtitles"
        Me.RadioButtonMisspelledSubtitles.Size = New System.Drawing.Size(128, 17)
        Me.RadioButtonMisspelledSubtitles.TabIndex = 0
        Me.RadioButtonMisspelledSubtitles.Text = "Misspelled Subtitles"
        Me.RadioButtonMisspelledSubtitles.UseVisualStyleBackColor = True
        '
        'CheckBoxMatchCase
        '
        Me.CheckBoxMatchCase.AutoSize = True
        Me.CheckBoxMatchCase.Location = New System.Drawing.Point(81, 39)
        Me.CheckBoxMatchCase.Name = "CheckBoxMatchCase"
        Me.CheckBoxMatchCase.Size = New System.Drawing.Size(85, 17)
        Me.CheckBoxMatchCase.TabIndex = 3
        Me.CheckBoxMatchCase.Text = "Match Case"
        Me.CheckBoxMatchCase.UseVisualStyleBackColor = True
        '
        'CheckBoxMatchWholeWord
        '
        Me.CheckBoxMatchWholeWord.AutoSize = True
        Me.CheckBoxMatchWholeWord.Location = New System.Drawing.Point(81, 62)
        Me.CheckBoxMatchWholeWord.Name = "CheckBoxMatchWholeWord"
        Me.CheckBoxMatchWholeWord.Size = New System.Drawing.Size(127, 17)
        Me.CheckBoxMatchWholeWord.TabIndex = 3
        Me.CheckBoxMatchWholeWord.Text = "Match Whole Word"
        Me.CheckBoxMatchWholeWord.UseVisualStyleBackColor = True
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
        'TextBoxReplace
        '
        Me.TextBoxReplace.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxReplace.Location = New System.Drawing.Point(81, 85)
        Me.TextBoxReplace.Name = "TextBoxReplace"
        Me.TextBoxReplace.Size = New System.Drawing.Size(226, 22)
        Me.TextBoxReplace.TabIndex = 2
        '
        'ButtonFind
        '
        Me.ButtonFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFind.Location = New System.Drawing.Point(70, 160)
        Me.ButtonFind.Name = "ButtonFind"
        Me.ButtonFind.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFind.TabIndex = 5
        Me.ButtonFind.Text = "Find"
        Me.ButtonFind.UseVisualStyleBackColor = True
        '
        'ButtonReplace
        '
        Me.ButtonReplace.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonReplace.Location = New System.Drawing.Point(151, 160)
        Me.ButtonReplace.Name = "ButtonReplace"
        Me.ButtonReplace.Size = New System.Drawing.Size(75, 23)
        Me.ButtonReplace.TabIndex = 6
        Me.ButtonReplace.Text = "Replace"
        Me.ButtonReplace.UseVisualStyleBackColor = True
        '
        'ButtonReplaceAll
        '
        Me.ButtonReplaceAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonReplaceAll.Location = New System.Drawing.Point(232, 160)
        Me.ButtonReplaceAll.Name = "ButtonReplaceAll"
        Me.ButtonReplaceAll.Size = New System.Drawing.Size(75, 23)
        Me.ButtonReplaceAll.TabIndex = 6
        Me.ButtonReplaceAll.Text = "Replace All"
        Me.ButtonReplaceAll.UseVisualStyleBackColor = True
        '
        'FormFindReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 196)
        Me.Controls.Add(Me.ButtonReplaceAll)
        Me.Controls.Add(Me.ButtonReplace)
        Me.Controls.Add(Me.ButtonFind)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBoxMatchWholeWord)
        Me.Controls.Add(Me.CheckBoxMatchCase)
        Me.Controls.Add(Me.RadioButtonText)
        Me.Controls.Add(Me.RadioButtonMisspelledSubtitles)
        Me.Controls.Add(Me.TextBoxReplace)
        Me.Controls.Add(Me.TextBoxSearch)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(335, 230)
        Me.Name = "FormFindReplace"
        Me.Text = "Find / Replace"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioButtonText As System.Windows.Forms.RadioButton
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents RadioButtonMisspelledSubtitles As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBoxMatchCase As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxMatchWholeWord As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxReplace As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFind As System.Windows.Forms.Button
    Friend WithEvents ButtonReplace As System.Windows.Forms.Button
    Friend WithEvents ButtonReplaceAll As System.Windows.Forms.Button
End Class
