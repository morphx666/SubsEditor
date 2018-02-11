<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOptions
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
        Me.TabControlSections = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ComboBoxLocales = New System.Windows.Forms.ComboBox()
        Me.ComboBoxDictionaries = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonRefresh = New System.Windows.Forms.Button()
        Me.LabelLoading = New System.Windows.Forms.Label()
        Me.ProgressBarLoading = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListViewDictionaries = New SubsEditor.FlickerFreeListView()
        Me.ColumnHeaderName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabControlSections.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlSections
        '
        Me.TabControlSections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlSections.Controls.Add(Me.TabPage1)
        Me.TabControlSections.Location = New System.Drawing.Point(12, 12)
        Me.TabControlSections.Name = "TabControlSections"
        Me.TabControlSections.SelectedIndex = 0
        Me.TabControlSections.Size = New System.Drawing.Size(1037, 555)
        Me.TabControlSections.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ComboBoxLocales)
        Me.TabPage1.Controls.Add(Me.ComboBoxDictionaries)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.ButtonRefresh)
        Me.TabPage1.Controls.Add(Me.LabelLoading)
        Me.TabPage1.Controls.Add(Me.ProgressBarLoading)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.ListViewDictionaries)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1029, 529)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Spell Checker"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ComboBoxLocales
        '
        Me.ComboBoxLocales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLocales.FormattingEnabled = True
        Me.ComboBoxLocales.Location = New System.Drawing.Point(359, 501)
        Me.ComboBoxLocales.Name = "ComboBoxLocales"
        Me.ComboBoxLocales.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxLocales.TabIndex = 7
        '
        'ComboBoxDictionaries
        '
        Me.ComboBoxDictionaries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDictionaries.FormattingEnabled = True
        Me.ComboBoxDictionaries.Location = New System.Drawing.Point(112, 501)
        Me.ComboBoxDictionaries.Name = "ComboBoxDictionaries"
        Me.ComboBoxDictionaries.Size = New System.Drawing.Size(241, 21)
        Me.ComboBoxDictionaries.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 505)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Default Dictionary"
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRefresh.Location = New System.Drawing.Point(948, 500)
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Size = New System.Drawing.Size(75, 23)
        Me.ButtonRefresh.TabIndex = 4
        Me.ButtonRefresh.Text = "Refresh"
        Me.ButtonRefresh.UseVisualStyleBackColor = True
        '
        'LabelLoading
        '
        Me.LabelLoading.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelLoading.AutoSize = True
        Me.LabelLoading.Location = New System.Drawing.Point(432, 229)
        Me.LabelLoading.Name = "LabelLoading"
        Me.LabelLoading.Size = New System.Drawing.Size(49, 13)
        Me.LabelLoading.TabIndex = 3
        Me.LabelLoading.Text = "Loading"
        '
        'ProgressBarLoading
        '
        Me.ProgressBarLoading.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ProgressBarLoading.Location = New System.Drawing.Point(435, 245)
        Me.ProgressBarLoading.Name = "ProgressBarLoading"
        Me.ProgressBarLoading.Size = New System.Drawing.Size(159, 23)
        Me.ProgressBarLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBarLoading.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Dictionaries"
        '
        'ListViewDictionaries
        '
        Me.ListViewDictionaries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewDictionaries.CheckBoxes = True
        Me.ListViewDictionaries.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderName, Me.ColumnHeaderDescription, Me.ColumnHeaderStatus})
        Me.ListViewDictionaries.FullRowSelect = True
        Me.ListViewDictionaries.GridLines = True
        Me.ListViewDictionaries.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewDictionaries.HideSelection = False
        Me.ListViewDictionaries.Location = New System.Drawing.Point(6, 19)
        Me.ListViewDictionaries.MultiSelect = False
        Me.ListViewDictionaries.Name = "ListViewDictionaries"
        Me.ListViewDictionaries.Size = New System.Drawing.Size(1017, 475)
        Me.ListViewDictionaries.TabIndex = 0
        Me.ListViewDictionaries.UseCompatibleStateImageBehavior = False
        Me.ListViewDictionaries.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderName
        '
        Me.ColumnHeaderName.Text = "Language"
        Me.ColumnHeaderName.Width = 200
        '
        'ColumnHeaderDescription
        '
        Me.ColumnHeaderDescription.Text = "Description"
        Me.ColumnHeaderDescription.Width = 400
        '
        'ColumnHeaderStatus
        '
        Me.ColumnHeaderStatus.Text = "Status"
        Me.ColumnHeaderStatus.Width = 200
        '
        'FormOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1061, 579)
        Me.Controls.Add(Me.TabControlSections)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOptions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Options"
        Me.TabControlSections.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControlSections As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListViewDictionaries As FlickerFreeListView
    Friend WithEvents ColumnHeaderName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents LabelLoading As System.Windows.Forms.Label
    Friend WithEvents ProgressBarLoading As System.Windows.Forms.ProgressBar
    Friend WithEvents ButtonRefresh As System.Windows.Forms.Button
    Friend WithEvents ColumnHeaderStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDictionaries As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxLocales As System.Windows.Forms.ComboBox
End Class
