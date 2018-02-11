<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubtitlesEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.TableLayoutPanelSubtitles = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBoxNextSubtitle = New SubsEditor.TextBoxWithSpellingSupport()
        Me.TextBoxCurrentSubtitle = New SubsEditor.TextBoxWithSpellingSupport()
        Me.TextBoxPreviousSubtitle = New SubsEditor.TextBoxWithSpellingSupport()
        Me.VScrollBarSubtitles = New System.Windows.Forms.VScrollBar()
        Me.ButtonColor = New System.Windows.Forms.Button()
        Me.ButtonBold = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonItalic = New System.Windows.Forms.Button()
        Me.RadioButtonLength = New System.Windows.Forms.RadioButton()
        Me.RadioButtonEnd = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDownMilliSecondEnd = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownSecondEnd = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownMinuteEnd = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownHourEnd = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownMilliSecondStart = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownSecondStart = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownMinuteStart = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownHourStart = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanelSubtitles.SuspendLayout()
        CType(Me.NumericUpDownMilliSecondEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownSecondEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownMinuteEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownHourEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownMilliSecondStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownSecondStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownMinuteStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownHourStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanelSubtitles
        '
        Me.TableLayoutPanelSubtitles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanelSubtitles.ColumnCount = 1
        Me.TableLayoutPanelSubtitles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelSubtitles.Controls.Add(Me.TextBoxNextSubtitle, 0, 2)
        Me.TableLayoutPanelSubtitles.Controls.Add(Me.TextBoxCurrentSubtitle, 0, 1)
        Me.TableLayoutPanelSubtitles.Controls.Add(Me.TextBoxPreviousSubtitle, 0, 0)
        Me.TableLayoutPanelSubtitles.Location = New System.Drawing.Point(0, 73)
        Me.TableLayoutPanelSubtitles.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanelSubtitles.Name = "TableLayoutPanelSubtitles"
        Me.TableLayoutPanelSubtitles.RowCount = 3
        Me.TableLayoutPanelSubtitles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanelSubtitles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanelSubtitles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanelSubtitles.Size = New System.Drawing.Size(420, 377)
        Me.TableLayoutPanelSubtitles.TabIndex = 44
        '
        'TextBoxNextSubtitle
        '
        Me.TextBoxNextSubtitle.BackColor = System.Drawing.Color.DimGray
        Me.TextBoxNextSubtitle.Dictionaries = Nothing
        Me.TextBoxNextSubtitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxNextSubtitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNextSubtitle.ForeColor = System.Drawing.Color.White
        Me.TextBoxNextSubtitle.HideSelection = False
        Me.TextBoxNextSubtitle.Location = New System.Drawing.Point(3, 253)
        Me.TextBoxNextSubtitle.Multiline = True
        Me.TextBoxNextSubtitle.Name = "TextBoxNextSubtitle"
        Me.TextBoxNextSubtitle.Size = New System.Drawing.Size(414, 121)
        Me.TextBoxNextSubtitle.SpellCheckerEngine = Nothing
        Me.TextBoxNextSubtitle.TabIndex = 2
        Me.TextBoxNextSubtitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxCurrentSubtitle
        '
        Me.TextBoxCurrentSubtitle.BackColor = System.Drawing.Color.Black
        Me.TextBoxCurrentSubtitle.Dictionaries = Nothing
        Me.TextBoxCurrentSubtitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCurrentSubtitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCurrentSubtitle.ForeColor = System.Drawing.Color.White
        Me.TextBoxCurrentSubtitle.HideSelection = False
        Me.TextBoxCurrentSubtitle.Location = New System.Drawing.Point(3, 128)
        Me.TextBoxCurrentSubtitle.Multiline = True
        Me.TextBoxCurrentSubtitle.Name = "TextBoxCurrentSubtitle"
        Me.TextBoxCurrentSubtitle.Size = New System.Drawing.Size(414, 119)
        Me.TextBoxCurrentSubtitle.SpellCheckerEngine = Nothing
        Me.TextBoxCurrentSubtitle.TabIndex = 1
        Me.TextBoxCurrentSubtitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxPreviousSubtitle
        '
        Me.TextBoxPreviousSubtitle.BackColor = System.Drawing.Color.DimGray
        Me.TextBoxPreviousSubtitle.Dictionaries = Nothing
        Me.TextBoxPreviousSubtitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxPreviousSubtitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPreviousSubtitle.ForeColor = System.Drawing.Color.White
        Me.TextBoxPreviousSubtitle.HideSelection = False
        Me.TextBoxPreviousSubtitle.Location = New System.Drawing.Point(3, 3)
        Me.TextBoxPreviousSubtitle.Multiline = True
        Me.TextBoxPreviousSubtitle.Name = "TextBoxPreviousSubtitle"
        Me.TextBoxPreviousSubtitle.Size = New System.Drawing.Size(414, 119)
        Me.TextBoxPreviousSubtitle.SpellCheckerEngine = Nothing
        Me.TextBoxPreviousSubtitle.TabIndex = 0
        Me.TextBoxPreviousSubtitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'VScrollBarSubtitles
        '
        Me.VScrollBarSubtitles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrollBarSubtitles.Location = New System.Drawing.Point(420, 73)
        Me.VScrollBarSubtitles.Name = "VScrollBarSubtitles"
        Me.VScrollBarSubtitles.Size = New System.Drawing.Size(17, 377)
        Me.VScrollBarSubtitles.TabIndex = 43
        '
        'ButtonColor
        '
        Me.ButtonColor.BackColor = System.Drawing.Color.White
        Me.ButtonColor.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.ButtonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonColor.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonColor.Image = Global.SubsEditor.My.Resources.Resources.select_by_color
        Me.ButtonColor.Location = New System.Drawing.Point(66, 43)
        Me.ButtonColor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonColor.Name = "ButtonColor"
        Me.ButtonColor.Size = New System.Drawing.Size(27, 25)
        Me.ButtonColor.TabIndex = 40
        Me.ButtonColor.UseMnemonic = False
        Me.ButtonColor.UseVisualStyleBackColor = False
        '
        'ButtonBold
        '
        Me.ButtonBold.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonBold.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.ButtonBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonBold.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonBold.Image = Global.SubsEditor.My.Resources.Resources.text_bold
        Me.ButtonBold.Location = New System.Drawing.Point(0, 43)
        Me.ButtonBold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonBold.Name = "ButtonBold"
        Me.ButtonBold.Size = New System.Drawing.Size(27, 25)
        Me.ButtonBold.TabIndex = 41
        Me.ButtonBold.UseMnemonic = False
        Me.ButtonBold.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(296, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "/"
        '
        'ButtonItalic
        '
        Me.ButtonItalic.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonItalic.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.ButtonItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonItalic.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonItalic.Image = Global.SubsEditor.My.Resources.Resources.text_italic
        Me.ButtonItalic.Location = New System.Drawing.Point(33, 43)
        Me.ButtonItalic.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonItalic.Name = "ButtonItalic"
        Me.ButtonItalic.Size = New System.Drawing.Size(27, 25)
        Me.ButtonItalic.TabIndex = 42
        Me.ButtonItalic.UseMnemonic = False
        Me.ButtonItalic.UseVisualStyleBackColor = False
        '
        'RadioButtonLength
        '
        Me.RadioButtonLength.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButtonLength.AutoSize = True
        Me.RadioButtonLength.Checked = True
        Me.RadioButtonLength.Location = New System.Drawing.Point(314, -2)
        Me.RadioButtonLength.Name = "RadioButtonLength"
        Me.RadioButtonLength.Size = New System.Drawing.Size(58, 17)
        Me.RadioButtonLength.TabIndex = 38
        Me.RadioButtonLength.TabStop = True
        Me.RadioButtonLength.Text = "Length"
        Me.RadioButtonLength.UseVisualStyleBackColor = True
        '
        'RadioButtonEnd
        '
        Me.RadioButtonEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButtonEnd.AutoSize = True
        Me.RadioButtonEnd.Location = New System.Drawing.Point(251, -2)
        Me.RadioButtonEnd.Name = "RadioButtonEnd"
        Me.RadioButtonEnd.Size = New System.Drawing.Size(44, 17)
        Me.RadioButtonEnd.TabIndex = 37
        Me.RadioButtonEnd.Text = "End"
        Me.RadioButtonEnd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Start"
        '
        'NumericUpDownMilliSecondEnd
        '
        Me.NumericUpDownMilliSecondEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDownMilliSecondEnd.Location = New System.Drawing.Point(395, 16)
        Me.NumericUpDownMilliSecondEnd.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDownMilliSecondEnd.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.NumericUpDownMilliSecondEnd.Name = "NumericUpDownMilliSecondEnd"
        Me.NumericUpDownMilliSecondEnd.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDownMilliSecondEnd.TabIndex = 35
        Me.NumericUpDownMilliSecondEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDownMilliSecondEnd.Value = New Decimal(New Integer() {999, 0, 0, 0})
        '
        'NumericUpDownSecondEnd
        '
        Me.NumericUpDownSecondEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDownSecondEnd.Location = New System.Drawing.Point(347, 16)
        Me.NumericUpDownSecondEnd.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NumericUpDownSecondEnd.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.NumericUpDownSecondEnd.Name = "NumericUpDownSecondEnd"
        Me.NumericUpDownSecondEnd.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDownSecondEnd.TabIndex = 34
        Me.NumericUpDownSecondEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDownSecondEnd.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'NumericUpDownMinuteEnd
        '
        Me.NumericUpDownMinuteEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDownMinuteEnd.Location = New System.Drawing.Point(299, 16)
        Me.NumericUpDownMinuteEnd.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NumericUpDownMinuteEnd.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.NumericUpDownMinuteEnd.Name = "NumericUpDownMinuteEnd"
        Me.NumericUpDownMinuteEnd.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDownMinuteEnd.TabIndex = 33
        Me.NumericUpDownMinuteEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDownMinuteEnd.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'NumericUpDownHourEnd
        '
        Me.NumericUpDownHourEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDownHourEnd.Location = New System.Drawing.Point(251, 16)
        Me.NumericUpDownHourEnd.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.NumericUpDownHourEnd.Name = "NumericUpDownHourEnd"
        Me.NumericUpDownHourEnd.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDownHourEnd.TabIndex = 32
        Me.NumericUpDownHourEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDownHourEnd.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'NumericUpDownMilliSecondStart
        '
        Me.NumericUpDownMilliSecondStart.Location = New System.Drawing.Point(144, 16)
        Me.NumericUpDownMilliSecondStart.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDownMilliSecondStart.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.NumericUpDownMilliSecondStart.Name = "NumericUpDownMilliSecondStart"
        Me.NumericUpDownMilliSecondStart.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDownMilliSecondStart.TabIndex = 31
        Me.NumericUpDownMilliSecondStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDownMilliSecondStart.Value = New Decimal(New Integer() {999, 0, 0, 0})
        '
        'NumericUpDownSecondStart
        '
        Me.NumericUpDownSecondStart.Location = New System.Drawing.Point(96, 16)
        Me.NumericUpDownSecondStart.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NumericUpDownSecondStart.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.NumericUpDownSecondStart.Name = "NumericUpDownSecondStart"
        Me.NumericUpDownSecondStart.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDownSecondStart.TabIndex = 30
        Me.NumericUpDownSecondStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDownSecondStart.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'NumericUpDownMinuteStart
        '
        Me.NumericUpDownMinuteStart.Location = New System.Drawing.Point(48, 16)
        Me.NumericUpDownMinuteStart.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NumericUpDownMinuteStart.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.NumericUpDownMinuteStart.Name = "NumericUpDownMinuteStart"
        Me.NumericUpDownMinuteStart.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDownMinuteStart.TabIndex = 29
        Me.NumericUpDownMinuteStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDownMinuteStart.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'NumericUpDownHourStart
        '
        Me.NumericUpDownHourStart.Location = New System.Drawing.Point(0, 16)
        Me.NumericUpDownHourStart.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.NumericUpDownHourStart.Name = "NumericUpDownHourStart"
        Me.NumericUpDownHourStart.Size = New System.Drawing.Size(42, 20)
        Me.NumericUpDownHourStart.TabIndex = 28
        Me.NumericUpDownHourStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDownHourStart.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'SubtitlesEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanelSubtitles)
        Me.Controls.Add(Me.VScrollBarSubtitles)
        Me.Controls.Add(Me.ButtonColor)
        Me.Controls.Add(Me.ButtonBold)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonItalic)
        Me.Controls.Add(Me.RadioButtonLength)
        Me.Controls.Add(Me.RadioButtonEnd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericUpDownMilliSecondEnd)
        Me.Controls.Add(Me.NumericUpDownSecondEnd)
        Me.Controls.Add(Me.NumericUpDownMinuteEnd)
        Me.Controls.Add(Me.NumericUpDownHourEnd)
        Me.Controls.Add(Me.NumericUpDownMilliSecondStart)
        Me.Controls.Add(Me.NumericUpDownSecondStart)
        Me.Controls.Add(Me.NumericUpDownMinuteStart)
        Me.Controls.Add(Me.NumericUpDownHourStart)
        Me.Name = "SubtitlesEditor"
        Me.Size = New System.Drawing.Size(437, 450)
        Me.TableLayoutPanelSubtitles.ResumeLayout(False)
        Me.TableLayoutPanelSubtitles.PerformLayout()
        CType(Me.NumericUpDownMilliSecondEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownSecondEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownMinuteEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownHourEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownMilliSecondStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownSecondStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownMinuteStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownHourStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanelSubtitles As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents VScrollBarSubtitles As System.Windows.Forms.VScrollBar
    Friend WithEvents ButtonColor As System.Windows.Forms.Button
    Friend WithEvents ButtonBold As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonItalic As System.Windows.Forms.Button
    Friend WithEvents RadioButtonLength As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonEnd As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownMilliSecondEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownSecondEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownMinuteEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownHourEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownMilliSecondStart As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownSecondStart As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownMinuteStart As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownHourStart As System.Windows.Forms.NumericUpDown
    Friend WithEvents TextBoxNextSubtitle As TextBoxWithSpellingSupport
    Friend WithEvents TextBoxCurrentSubtitle As TextBoxWithSpellingSupport
    Friend WithEvents TextBoxPreviousSubtitle As TextBoxWithSpellingSupport
End Class
