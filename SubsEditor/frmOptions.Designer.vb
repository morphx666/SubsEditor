<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Me.tcSections = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cbLocales = New System.Windows.Forms.ComboBox()
        Me.cbDictionaries = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.pbLoading = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvDictionaries = New SubsEditor.FlickerFreeListView()
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tcSections.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcSections
        '
        Me.tcSections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcSections.Controls.Add(Me.TabPage1)
        Me.tcSections.Location = New System.Drawing.Point(12, 12)
        Me.tcSections.Name = "tcSections"
        Me.tcSections.SelectedIndex = 0
        Me.tcSections.Size = New System.Drawing.Size(1037, 555)
        Me.tcSections.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cbLocales)
        Me.TabPage1.Controls.Add(Me.cbDictionaries)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.btnRefresh)
        Me.TabPage1.Controls.Add(Me.lblLoading)
        Me.TabPage1.Controls.Add(Me.pbLoading)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.lvDictionaries)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1029, 529)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Spell Checker"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cbLocales
        '
        Me.cbLocales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLocales.FormattingEnabled = True
        Me.cbLocales.Location = New System.Drawing.Point(359, 501)
        Me.cbLocales.Name = "cbLocales"
        Me.cbLocales.Size = New System.Drawing.Size(121, 21)
        Me.cbLocales.TabIndex = 7
        '
        'cbDictionaries
        '
        Me.cbDictionaries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDictionaries.FormattingEnabled = True
        Me.cbDictionaries.Location = New System.Drawing.Point(112, 501)
        Me.cbDictionaries.Name = "cbDictionaries"
        Me.cbDictionaries.Size = New System.Drawing.Size(241, 21)
        Me.cbDictionaries.TabIndex = 6
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
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(948, 500)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'lblLoading
        '
        Me.lblLoading.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblLoading.AutoSize = True
        Me.lblLoading.Location = New System.Drawing.Point(432, 229)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(49, 13)
        Me.lblLoading.TabIndex = 3
        Me.lblLoading.Text = "Loading"
        '
        'pbLoading
        '
        Me.pbLoading.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbLoading.Location = New System.Drawing.Point(435, 245)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(159, 23)
        Me.pbLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbLoading.TabIndex = 2
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
        'lvDictionaries
        '
        Me.lvDictionaries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDictionaries.CheckBoxes = True
        Me.lvDictionaries.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName, Me.chDescription, Me.chStatus})
        Me.lvDictionaries.FullRowSelect = True
        Me.lvDictionaries.GridLines = True
        Me.lvDictionaries.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvDictionaries.HideSelection = False
        Me.lvDictionaries.Location = New System.Drawing.Point(6, 19)
        Me.lvDictionaries.MultiSelect = False
        Me.lvDictionaries.Name = "lvDictionaries"
        Me.lvDictionaries.Size = New System.Drawing.Size(1017, 475)
        Me.lvDictionaries.TabIndex = 0
        Me.lvDictionaries.UseCompatibleStateImageBehavior = False
        Me.lvDictionaries.View = System.Windows.Forms.View.Details
        '
        'chName
        '
        Me.chName.Text = "Language"
        Me.chName.Width = 200
        '
        'chDescription
        '
        Me.chDescription.Text = "Description"
        Me.chDescription.Width = 400
        '
        'chStatus
        '
        Me.chStatus.Text = "Status"
        Me.chStatus.Width = 200
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1061, 579)
        Me.Controls.Add(Me.tcSections)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Options"
        Me.tcSections.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcSections As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvDictionaries As FlickerFreeListView
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents pbLoading As System.Windows.Forms.ProgressBar
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents chStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbDictionaries As System.Windows.Forms.ComboBox
    Friend WithEvents cbLocales As System.Windows.Forms.ComboBox
End Class
