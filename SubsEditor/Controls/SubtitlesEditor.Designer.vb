<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubtitlesEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.tlpSubtitles = New System.Windows.Forms.TableLayoutPanel()
        Me.vsBar = New System.Windows.Forms.VScrollBar()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.btnBold = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnItalic = New System.Windows.Forms.Button()
        Me.rbLength = New System.Windows.Forms.RadioButton()
        Me.rbEnd = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudMilliSecondEnd = New System.Windows.Forms.NumericUpDown()
        Me.nudSecondEnd = New System.Windows.Forms.NumericUpDown()
        Me.nudMinuteEnd = New System.Windows.Forms.NumericUpDown()
        Me.nudHourEnd = New System.Windows.Forms.NumericUpDown()
        Me.nudMilliSecondStart = New System.Windows.Forms.NumericUpDown()
        Me.nudSecondStart = New System.Windows.Forms.NumericUpDown()
        Me.nudMinuteStart = New System.Windows.Forms.NumericUpDown()
        Me.nudHourStart = New System.Windows.Forms.NumericUpDown()
        Me.txtNextSubtitle = New SubsEditor.TextBoxWithSpellingSupport()
        Me.txtCurrentSubtitle = New SubsEditor.TextBoxWithSpellingSupport()
        Me.txtPreviousSubtitle = New SubsEditor.TextBoxWithSpellingSupport()
        Me.tlpSubtitles.SuspendLayout()
        CType(Me.nudMilliSecondEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSecondEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinuteEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHourEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMilliSecondStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSecondStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinuteStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHourStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpSubtitles
        '
        Me.tlpSubtitles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpSubtitles.ColumnCount = 1
        Me.tlpSubtitles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSubtitles.Controls.Add(Me.txtNextSubtitle, 0, 2)
        Me.tlpSubtitles.Controls.Add(Me.txtCurrentSubtitle, 0, 1)
        Me.tlpSubtitles.Controls.Add(Me.txtPreviousSubtitle, 0, 0)
        Me.tlpSubtitles.Location = New System.Drawing.Point(0, 73)
        Me.tlpSubtitles.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpSubtitles.Name = "tlpSubtitles"
        Me.tlpSubtitles.RowCount = 3
        Me.tlpSubtitles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpSubtitles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpSubtitles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpSubtitles.Size = New System.Drawing.Size(420, 377)
        Me.tlpSubtitles.TabIndex = 44
        '
        'vsBar
        '
        Me.vsBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vsBar.Location = New System.Drawing.Point(420, 73)
        Me.vsBar.Name = "vsBar"
        Me.vsBar.Size = New System.Drawing.Size(17, 377)
        Me.vsBar.TabIndex = 43
        '
        'btnColor
        '
        Me.btnColor.BackColor = System.Drawing.Color.White
        Me.btnColor.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColor.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnColor.Image = Global.SubsEditor.My.Resources.Resources.select_by_color
        Me.btnColor.Location = New System.Drawing.Point(66, 43)
        Me.btnColor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(27, 25)
        Me.btnColor.TabIndex = 40
        Me.btnColor.UseMnemonic = False
        Me.btnColor.UseVisualStyleBackColor = False
        '
        'btnBold
        '
        Me.btnBold.BackColor = System.Drawing.SystemColors.Control
        Me.btnBold.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBold.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBold.Image = Global.SubsEditor.My.Resources.Resources.text_bold
        Me.btnBold.Location = New System.Drawing.Point(0, 43)
        Me.btnBold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBold.Name = "btnBold"
        Me.btnBold.Size = New System.Drawing.Size(27, 25)
        Me.btnBold.TabIndex = 41
        Me.btnBold.UseMnemonic = False
        Me.btnBold.UseVisualStyleBackColor = False
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
        'btnItalic
        '
        Me.btnItalic.BackColor = System.Drawing.SystemColors.Control
        Me.btnItalic.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnItalic.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItalic.Image = Global.SubsEditor.My.Resources.Resources.text_italic
        Me.btnItalic.Location = New System.Drawing.Point(33, 43)
        Me.btnItalic.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnItalic.Name = "btnItalic"
        Me.btnItalic.Size = New System.Drawing.Size(27, 25)
        Me.btnItalic.TabIndex = 42
        Me.btnItalic.UseMnemonic = False
        Me.btnItalic.UseVisualStyleBackColor = False
        '
        'rbLength
        '
        Me.rbLength.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbLength.AutoSize = True
        Me.rbLength.Checked = True
        Me.rbLength.Location = New System.Drawing.Point(314, -2)
        Me.rbLength.Name = "rbLength"
        Me.rbLength.Size = New System.Drawing.Size(58, 17)
        Me.rbLength.TabIndex = 38
        Me.rbLength.TabStop = True
        Me.rbLength.Text = "Length"
        Me.rbLength.UseVisualStyleBackColor = True
        '
        'rbEnd
        '
        Me.rbEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbEnd.AutoSize = True
        Me.rbEnd.Location = New System.Drawing.Point(251, -2)
        Me.rbEnd.Name = "rbEnd"
        Me.rbEnd.Size = New System.Drawing.Size(44, 17)
        Me.rbEnd.TabIndex = 37
        Me.rbEnd.Text = "End"
        Me.rbEnd.UseVisualStyleBackColor = True
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
        'nudMilliSecondEnd
        '
        Me.nudMilliSecondEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudMilliSecondEnd.Location = New System.Drawing.Point(395, 16)
        Me.nudMilliSecondEnd.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudMilliSecondEnd.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.nudMilliSecondEnd.Name = "nudMilliSecondEnd"
        Me.nudMilliSecondEnd.Size = New System.Drawing.Size(42, 20)
        Me.nudMilliSecondEnd.TabIndex = 35
        Me.nudMilliSecondEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudMilliSecondEnd.Value = New Decimal(New Integer() {999, 0, 0, 0})
        '
        'nudSecondEnd
        '
        Me.nudSecondEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudSecondEnd.Location = New System.Drawing.Point(347, 16)
        Me.nudSecondEnd.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudSecondEnd.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.nudSecondEnd.Name = "nudSecondEnd"
        Me.nudSecondEnd.Size = New System.Drawing.Size(42, 20)
        Me.nudSecondEnd.TabIndex = 34
        Me.nudSecondEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudSecondEnd.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'nudMinuteEnd
        '
        Me.nudMinuteEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudMinuteEnd.Location = New System.Drawing.Point(299, 16)
        Me.nudMinuteEnd.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudMinuteEnd.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.nudMinuteEnd.Name = "nudMinuteEnd"
        Me.nudMinuteEnd.Size = New System.Drawing.Size(42, 20)
        Me.nudMinuteEnd.TabIndex = 33
        Me.nudMinuteEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudMinuteEnd.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'nudHourEnd
        '
        Me.nudHourEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudHourEnd.Location = New System.Drawing.Point(251, 16)
        Me.nudHourEnd.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudHourEnd.Name = "nudHourEnd"
        Me.nudHourEnd.Size = New System.Drawing.Size(42, 20)
        Me.nudHourEnd.TabIndex = 32
        Me.nudHourEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudHourEnd.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'nudMilliSecondStart
        '
        Me.nudMilliSecondStart.Location = New System.Drawing.Point(144, 16)
        Me.nudMilliSecondStart.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudMilliSecondStart.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.nudMilliSecondStart.Name = "nudMilliSecondStart"
        Me.nudMilliSecondStart.Size = New System.Drawing.Size(42, 20)
        Me.nudMilliSecondStart.TabIndex = 31
        Me.nudMilliSecondStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudMilliSecondStart.Value = New Decimal(New Integer() {999, 0, 0, 0})
        '
        'nudSecondStart
        '
        Me.nudSecondStart.Location = New System.Drawing.Point(96, 16)
        Me.nudSecondStart.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudSecondStart.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.nudSecondStart.Name = "nudSecondStart"
        Me.nudSecondStart.Size = New System.Drawing.Size(42, 20)
        Me.nudSecondStart.TabIndex = 30
        Me.nudSecondStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudSecondStart.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'nudMinuteStart
        '
        Me.nudMinuteStart.Location = New System.Drawing.Point(48, 16)
        Me.nudMinuteStart.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudMinuteStart.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.nudMinuteStart.Name = "nudMinuteStart"
        Me.nudMinuteStart.Size = New System.Drawing.Size(42, 20)
        Me.nudMinuteStart.TabIndex = 29
        Me.nudMinuteStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudMinuteStart.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'nudHourStart
        '
        Me.nudHourStart.Location = New System.Drawing.Point(0, 16)
        Me.nudHourStart.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudHourStart.Name = "nudHourStart"
        Me.nudHourStart.Size = New System.Drawing.Size(42, 20)
        Me.nudHourStart.TabIndex = 28
        Me.nudHourStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudHourStart.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'txtNextSubtitle
        '
        Me.txtNextSubtitle.BackColor = System.Drawing.Color.DimGray
        Me.txtNextSubtitle.Dictionaries = Nothing
        Me.txtNextSubtitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNextSubtitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNextSubtitle.ForeColor = System.Drawing.Color.White
        Me.txtNextSubtitle.HideSelection = False
        Me.txtNextSubtitle.Location = New System.Drawing.Point(3, 253)
        Me.txtNextSubtitle.Multiline = True
        Me.txtNextSubtitle.Name = "txtNextSubtitle"
        Me.txtNextSubtitle.Size = New System.Drawing.Size(414, 121)
        Me.txtNextSubtitle.SpellCheckerEngine = Nothing
        Me.txtNextSubtitle.TabIndex = 2
        Me.txtNextSubtitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCurrentSubtitle
        '
        Me.txtCurrentSubtitle.BackColor = System.Drawing.Color.Black
        Me.txtCurrentSubtitle.Dictionaries = Nothing
        Me.txtCurrentSubtitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCurrentSubtitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentSubtitle.ForeColor = System.Drawing.Color.White
        Me.txtCurrentSubtitle.HideSelection = False
        Me.txtCurrentSubtitle.Location = New System.Drawing.Point(3, 128)
        Me.txtCurrentSubtitle.Multiline = True
        Me.txtCurrentSubtitle.Name = "txtCurrentSubtitle"
        Me.txtCurrentSubtitle.Size = New System.Drawing.Size(414, 119)
        Me.txtCurrentSubtitle.SpellCheckerEngine = Nothing
        Me.txtCurrentSubtitle.TabIndex = 1
        Me.txtCurrentSubtitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPreviousSubtitle
        '
        Me.txtPreviousSubtitle.BackColor = System.Drawing.Color.DimGray
        Me.txtPreviousSubtitle.Dictionaries = Nothing
        Me.txtPreviousSubtitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPreviousSubtitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreviousSubtitle.ForeColor = System.Drawing.Color.White
        Me.txtPreviousSubtitle.HideSelection = False
        Me.txtPreviousSubtitle.Location = New System.Drawing.Point(3, 3)
        Me.txtPreviousSubtitle.Multiline = True
        Me.txtPreviousSubtitle.Name = "txtPreviousSubtitle"
        Me.txtPreviousSubtitle.Size = New System.Drawing.Size(414, 119)
        Me.txtPreviousSubtitle.SpellCheckerEngine = Nothing
        Me.txtPreviousSubtitle.TabIndex = 0
        Me.txtPreviousSubtitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SubtitlesEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpSubtitles)
        Me.Controls.Add(Me.vsBar)
        Me.Controls.Add(Me.btnColor)
        Me.Controls.Add(Me.btnBold)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnItalic)
        Me.Controls.Add(Me.rbLength)
        Me.Controls.Add(Me.rbEnd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudMilliSecondEnd)
        Me.Controls.Add(Me.nudSecondEnd)
        Me.Controls.Add(Me.nudMinuteEnd)
        Me.Controls.Add(Me.nudHourEnd)
        Me.Controls.Add(Me.nudMilliSecondStart)
        Me.Controls.Add(Me.nudSecondStart)
        Me.Controls.Add(Me.nudMinuteStart)
        Me.Controls.Add(Me.nudHourStart)
        Me.Name = "SubtitlesEditor"
        Me.Size = New System.Drawing.Size(437, 450)
        Me.tlpSubtitles.ResumeLayout(False)
        Me.tlpSubtitles.PerformLayout()
        CType(Me.nudMilliSecondEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSecondEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinuteEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHourEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMilliSecondStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSecondStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinuteStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHourStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlpSubtitles As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents vsBar As System.Windows.Forms.VScrollBar
    Friend WithEvents btnColor As System.Windows.Forms.Button
    Friend WithEvents btnBold As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnItalic As System.Windows.Forms.Button
    Friend WithEvents rbLength As System.Windows.Forms.RadioButton
    Friend WithEvents rbEnd As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudMilliSecondEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudSecondEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMinuteEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudHourEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMilliSecondStart As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudSecondStart As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMinuteStart As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudHourStart As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtNextSubtitle As TextBoxWithSpellingSupport
    Friend WithEvents txtCurrentSubtitle As TextBoxWithSpellingSupport
    Friend WithEvents txtPreviousSubtitle As TextBoxWithSpellingSupport
End Class
