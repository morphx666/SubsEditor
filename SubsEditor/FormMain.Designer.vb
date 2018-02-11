<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
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
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.TextBoxSubtitlesFile = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonBrowseSubtitlesFile = New System.Windows.Forms.Button()
        Me.ButtonBrowseVideoFile = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxVideoFile = New System.Windows.Forms.TextBox()
        Me.VlcCtrl = New Vlc.DotNet.Forms.VlcControl()
        Me.TrackBarPosition = New System.Windows.Forms.TrackBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxLanguages = New System.Windows.Forms.ComboBox()
        Me.LabelTime = New System.Windows.Forms.Label()
        Me.ButtonZoomOut = New System.Windows.Forms.Button()
        Me.ButtonZoomIn = New System.Windows.Forms.Button()
        Me.CheckBoxRippleEdits = New System.Windows.Forms.CheckBox()
        Me.ButtonPlay = New System.Windows.Forms.PictureBox()
        Me.ButtonSearch = New System.Windows.Forms.Button()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.ButtonAddSubtitle = New System.Windows.Forms.Button()
        Me.ButtonDeleteSubtitle = New System.Windows.Forms.Button()
        Me.ListViewSubtitles = New System.Windows.Forms.ListView()
        Me.ColumnHeaderTimeFromOffsetted = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderTimeToOffsetted = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderSubtitles = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LabelNewVersionInfo = New System.Windows.Forms.Label()
        Me.LinkLabelNewVersionDownload = New System.Windows.Forms.LinkLabel()
        Me.ProgressBarDownload = New System.Windows.Forms.ProgressBar()
        Me.LabelDownloading = New System.Windows.Forms.Label()
        Me.LabelExtractingAWF = New System.Windows.Forms.Label()
        Me.TrackBarZoom = New System.Windows.Forms.TrackBar()
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerSubtitlesAndEditor = New System.Windows.Forms.SplitContainer()
        Me.SubtitlesEditorCtrl = New SubsEditor.SubtitlesEditor()
        Me.SplitContainerVideoAndBrowser = New System.Windows.Forms.SplitContainer()
        Me.SubtitlesBrowserCtrl = New SubsEditor.SubtitlesBrowser()
        Me.MenuStripMainMenu = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItemMainMenuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemMainMenuNewSubtitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemMainMenuOpenSubtitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemMainMenuOpenVideo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemMainMenuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemMainMenuSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemMainMenuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemMainMenuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemMainMenuEditUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemMainMenuEditRedo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemMainMenuEditFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemMainMenuEditOptions = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.TrackBarPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.Panel2.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        CType(Me.SplitContainerSubtitlesAndEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerSubtitlesAndEditor.Panel1.SuspendLayout()
        Me.SplitContainerSubtitlesAndEditor.Panel2.SuspendLayout()
        Me.SplitContainerSubtitlesAndEditor.SuspendLayout()
        CType(Me.SplitContainerVideoAndBrowser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerVideoAndBrowser.Panel1.SuspendLayout()
        Me.SplitContainerVideoAndBrowser.Panel2.SuspendLayout()
        Me.SplitContainerVideoAndBrowser.SuspendLayout()
        Me.MenuStripMainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxSubtitlesFile
        '
        Me.TextBoxSubtitlesFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSubtitlesFile.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxSubtitlesFile.Location = New System.Drawing.Point(59, 27)
        Me.TextBoxSubtitlesFile.Name = "TextBoxSubtitlesFile"
        Me.TextBoxSubtitlesFile.ReadOnly = True
        Me.TextBoxSubtitlesFile.Size = New System.Drawing.Size(485, 22)
        Me.TextBoxSubtitlesFile.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Subtitles"
        '
        'ButtonBrowseSubtitlesFile
        '
        Me.ButtonBrowseSubtitlesFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonBrowseSubtitlesFile.Location = New System.Drawing.Point(550, 28)
        Me.ButtonBrowseSubtitlesFile.Name = "ButtonBrowseSubtitlesFile"
        Me.ButtonBrowseSubtitlesFile.Size = New System.Drawing.Size(26, 20)
        Me.ButtonBrowseSubtitlesFile.TabIndex = 3
        Me.ButtonBrowseSubtitlesFile.Text = "..."
        Me.ButtonBrowseSubtitlesFile.UseVisualStyleBackColor = True
        '
        'ButtonBrowseVideoFile
        '
        Me.ButtonBrowseVideoFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonBrowseVideoFile.Location = New System.Drawing.Point(550, 53)
        Me.ButtonBrowseVideoFile.Name = "ButtonBrowseVideoFile"
        Me.ButtonBrowseVideoFile.Size = New System.Drawing.Size(26, 20)
        Me.ButtonBrowseVideoFile.TabIndex = 14
        Me.ButtonBrowseVideoFile.Text = "..."
        Me.ButtonBrowseVideoFile.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Video"
        '
        'TextBoxVideoFile
        '
        Me.TextBoxVideoFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxVideoFile.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxVideoFile.Location = New System.Drawing.Point(59, 52)
        Me.TextBoxVideoFile.Name = "TextBoxVideoFile"
        Me.TextBoxVideoFile.ReadOnly = True
        Me.TextBoxVideoFile.Size = New System.Drawing.Size(485, 22)
        Me.TextBoxVideoFile.TabIndex = 12
        '
        'VlcCtrl
        '
        Me.VlcCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VlcCtrl.BackColor = System.Drawing.Color.Black
        Me.VlcCtrl.Location = New System.Drawing.Point(3, 4)
        Me.VlcCtrl.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.VlcCtrl.Name = "VlcCtrl"
        Me.VlcCtrl.Rate = 0!
        Me.VlcCtrl.Size = New System.Drawing.Size(734, 368)
        Me.VlcCtrl.TabIndex = 15
        '
        'TrackBarPosition
        '
        Me.TrackBarPosition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBarPosition.AutoSize = False
        Me.TrackBarPosition.Enabled = False
        Me.TrackBarPosition.LargeChange = 10000
        Me.TrackBarPosition.Location = New System.Drawing.Point(41, 377)
        Me.TrackBarPosition.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TrackBarPosition.Maximum = 1000000
        Me.TrackBarPosition.Name = "TrackBarPosition"
        Me.TrackBarPosition.Size = New System.Drawing.Size(554, 32)
        Me.TrackBarPosition.SmallChange = 100
        Me.TrackBarPosition.TabIndex = 17
        Me.TrackBarPosition.TickFrequency = 10000
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(959, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Audio Language"
        '
        'ComboBoxLanguages
        '
        Me.ComboBoxLanguages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLanguages.Enabled = False
        Me.ComboBoxLanguages.FormattingEnabled = True
        Me.ComboBoxLanguages.ItemHeight = 13
        Me.ComboBoxLanguages.Location = New System.Drawing.Point(1057, 52)
        Me.ComboBoxLanguages.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxLanguages.Name = "ComboBoxLanguages"
        Me.ComboBoxLanguages.Size = New System.Drawing.Size(104, 21)
        Me.ComboBoxLanguages.TabIndex = 19
        '
        'LabelTime
        '
        Me.LabelTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelTime.AutoSize = True
        Me.LabelTime.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTime.Location = New System.Drawing.Point(609, 384)
        Me.LabelTime.Name = "LabelTime"
        Me.LabelTime.Size = New System.Drawing.Size(128, 18)
        Me.LabelTime.TabIndex = 20
        Me.LabelTime.Text = "00:00:00,000"
        '
        'ButtonZoomOut
        '
        Me.ButtonZoomOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonZoomOut.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonZoomOut.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.ButtonZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonZoomOut.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonZoomOut.Image = Global.SubsEditor.My.Resources.Resources.magifier_zoom_out
        Me.ButtonZoomOut.Location = New System.Drawing.Point(710, 95)
        Me.ButtonZoomOut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonZoomOut.Name = "ButtonZoomOut"
        Me.ButtonZoomOut.Size = New System.Drawing.Size(27, 25)
        Me.ButtonZoomOut.TabIndex = 24
        Me.ButtonZoomOut.UseMnemonic = False
        Me.ButtonZoomOut.UseVisualStyleBackColor = False
        '
        'ButtonZoomIn
        '
        Me.ButtonZoomIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonZoomIn.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonZoomIn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.ButtonZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonZoomIn.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonZoomIn.Image = Global.SubsEditor.My.Resources.Resources.magnifier_zoom_in
        Me.ButtonZoomIn.Location = New System.Drawing.Point(710, 3)
        Me.ButtonZoomIn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonZoomIn.Name = "ButtonZoomIn"
        Me.ButtonZoomIn.Size = New System.Drawing.Size(27, 25)
        Me.ButtonZoomIn.TabIndex = 23
        Me.ButtonZoomIn.UseMnemonic = False
        Me.ButtonZoomIn.UseVisualStyleBackColor = False
        '
        'CheckBoxRippleEdits
        '
        Me.CheckBoxRippleEdits.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxRippleEdits.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxRippleEdits.Enabled = False
        Me.CheckBoxRippleEdits.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.CheckBoxRippleEdits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxRippleEdits.Image = Global.SubsEditor.My.Resources.Resources.lock_open
        Me.CheckBoxRippleEdits.Location = New System.Drawing.Point(710, 125)
        Me.CheckBoxRippleEdits.Name = "CheckBoxRippleEdits"
        Me.CheckBoxRippleEdits.Size = New System.Drawing.Size(27, 25)
        Me.CheckBoxRippleEdits.TabIndex = 13
        Me.CheckBoxRippleEdits.UseVisualStyleBackColor = True
        '
        'ButtonPlay
        '
        Me.ButtonPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonPlay.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonPlay.Enabled = False
        Me.ButtonPlay.Image = Global.SubsEditor.My.Resources.Resources.playpause_off
        Me.ButtonPlay.Location = New System.Drawing.Point(3, 377)
        Me.ButtonPlay.Name = "ButtonPlay"
        Me.ButtonPlay.Size = New System.Drawing.Size(32, 32)
        Me.ButtonPlay.TabIndex = 25
        Me.ButtonPlay.TabStop = False
        '
        'ButtonSearch
        '
        Me.ButtonSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSearch.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonSearch.Enabled = False
        Me.ButtonSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.ButtonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSearch.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSearch.Image = CType(resources.GetObject("ButtonSearch.Image"), System.Drawing.Image)
        Me.ButtonSearch.Location = New System.Drawing.Point(375, 4)
        Me.ButtonSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(27, 22)
        Me.ButtonSearch.TabIndex = 25
        Me.ButtonSearch.UseMnemonic = False
        Me.ButtonSearch.UseVisualStyleBackColor = False
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSearch.Enabled = False
        Me.TextBoxSearch.Location = New System.Drawing.Point(219, 4)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(150, 22)
        Me.TextBoxSearch.TabIndex = 13
        '
        'ButtonAddSubtitle
        '
        Me.ButtonAddSubtitle.Enabled = False
        Me.ButtonAddSubtitle.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.ButtonAddSubtitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAddSubtitle.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAddSubtitle.Image = Global.SubsEditor.My.Resources.Resources.pencil_add
        Me.ButtonAddSubtitle.Location = New System.Drawing.Point(3, 4)
        Me.ButtonAddSubtitle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonAddSubtitle.Name = "ButtonAddSubtitle"
        Me.ButtonAddSubtitle.Size = New System.Drawing.Size(27, 25)
        Me.ButtonAddSubtitle.TabIndex = 12
        Me.ButtonAddSubtitle.UseMnemonic = False
        Me.ButtonAddSubtitle.UseVisualStyleBackColor = True
        '
        'ButtonDeleteSubtitle
        '
        Me.ButtonDeleteSubtitle.Enabled = False
        Me.ButtonDeleteSubtitle.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.ButtonDeleteSubtitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDeleteSubtitle.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDeleteSubtitle.Image = Global.SubsEditor.My.Resources.Resources.pencil_delete
        Me.ButtonDeleteSubtitle.Location = New System.Drawing.Point(36, 4)
        Me.ButtonDeleteSubtitle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonDeleteSubtitle.Name = "ButtonDeleteSubtitle"
        Me.ButtonDeleteSubtitle.Size = New System.Drawing.Size(27, 25)
        Me.ButtonDeleteSubtitle.TabIndex = 12
        Me.ButtonDeleteSubtitle.UseMnemonic = False
        Me.ButtonDeleteSubtitle.UseVisualStyleBackColor = True
        '
        'ListViewSubtitles
        '
        Me.ListViewSubtitles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewSubtitles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderTimeFromOffsetted, Me.ColumnHeaderTimeToOffsetted, Me.ColumnHeaderSubtitles})
        Me.ListViewSubtitles.FullRowSelect = True
        Me.ListViewSubtitles.HideSelection = False
        Me.ListViewSubtitles.Location = New System.Drawing.Point(3, 34)
        Me.ListViewSubtitles.Name = "ListViewSubtitles"
        Me.ListViewSubtitles.Size = New System.Drawing.Size(399, 194)
        Me.ListViewSubtitles.TabIndex = 10
        Me.ListViewSubtitles.UseCompatibleStateImageBehavior = False
        Me.ListViewSubtitles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderTimeFromOffsetted
        '
        Me.ColumnHeaderTimeFromOffsetted.Text = "From"
        '
        'ColumnHeaderTimeToOffsetted
        '
        Me.ColumnHeaderTimeToOffsetted.Text = "To"
        '
        'ColumnHeaderSubtitles
        '
        Me.ColumnHeaderSubtitles.Text = "Subtitle"
        '
        'LabelNewVersionInfo
        '
        Me.LabelNewVersionInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelNewVersionInfo.AutoSize = True
        Me.LabelNewVersionInfo.ForeColor = System.Drawing.Color.Red
        Me.LabelNewVersionInfo.Location = New System.Drawing.Point(12, 655)
        Me.LabelNewVersionInfo.Name = "LabelNewVersionInfo"
        Me.LabelNewVersionInfo.Size = New System.Drawing.Size(211, 13)
        Me.LabelNewVersionInfo.TabIndex = 26
        Me.LabelNewVersionInfo.Text = "A new version of SubsEditor is available"
        Me.LabelNewVersionInfo.Visible = False
        '
        'LinkLabelNewVersionDownload
        '
        Me.LinkLabelNewVersionDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabelNewVersionDownload.AutoSize = True
        Me.LinkLabelNewVersionDownload.LinkArea = New System.Windows.Forms.LinkArea(0, 37)
        Me.LinkLabelNewVersionDownload.Location = New System.Drawing.Point(12, 670)
        Me.LinkLabelNewVersionDownload.Name = "LinkLabelNewVersionDownload"
        Me.LinkLabelNewVersionDownload.Size = New System.Drawing.Size(130, 20)
        Me.LinkLabelNewVersionDownload.TabIndex = 27
        Me.LinkLabelNewVersionDownload.TabStop = True
        Me.LinkLabelNewVersionDownload.Text = "Download SubsEditor 1.0"
        Me.LinkLabelNewVersionDownload.UseCompatibleTextRendering = True
        Me.LinkLabelNewVersionDownload.Visible = False
        '
        'ProgressBarDownload
        '
        Me.ProgressBarDownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBarDownload.Location = New System.Drawing.Point(553, 655)
        Me.ProgressBarDownload.Name = "ProgressBarDownload"
        Me.ProgressBarDownload.Size = New System.Drawing.Size(608, 23)
        Me.ProgressBarDownload.TabIndex = 28
        Me.ProgressBarDownload.Visible = False
        '
        'LabelDownloading
        '
        Me.LabelDownloading.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelDownloading.AutoSize = True
        Me.LabelDownloading.Location = New System.Drawing.Point(469, 660)
        Me.LabelDownloading.Name = "LabelDownloading"
        Me.LabelDownloading.Size = New System.Drawing.Size(78, 13)
        Me.LabelDownloading.TabIndex = 29
        Me.LabelDownloading.Text = "Downloading"
        Me.LabelDownloading.Visible = False
        '
        'LabelExtractingAWF
        '
        Me.LabelExtractingAWF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelExtractingAWF.AutoSize = True
        Me.LabelExtractingAWF.BackColor = System.Drawing.Color.Black
        Me.LabelExtractingAWF.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.LabelExtractingAWF.Location = New System.Drawing.Point(3, 344)
        Me.LabelExtractingAWF.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelExtractingAWF.Name = "LabelExtractingAWF"
        Me.LabelExtractingAWF.Padding = New System.Windows.Forms.Padding(6)
        Me.LabelExtractingAWF.Size = New System.Drawing.Size(168, 25)
        Me.LabelExtractingAWF.TabIndex = 30
        Me.LabelExtractingAWF.Text = "Extracting Audio Waveform..."
        Me.LabelExtractingAWF.Visible = False
        '
        'TrackBarZoom
        '
        Me.TrackBarZoom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBarZoom.AutoSize = False
        Me.TrackBarZoom.LargeChange = 10
        Me.TrackBarZoom.Location = New System.Drawing.Point(710, 33)
        Me.TrackBarZoom.Maximum = 500
        Me.TrackBarZoom.Minimum = 10
        Me.TrackBarZoom.Name = "TrackBarZoom"
        Me.TrackBarZoom.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarZoom.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TrackBarZoom.RightToLeftLayout = True
        Me.TrackBarZoom.Size = New System.Drawing.Size(27, 57)
        Me.TrackBarZoom.TabIndex = 31
        Me.TrackBarZoom.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarZoom.Value = 10
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainerMain.Location = New System.Drawing.Point(12, 80)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        '
        'SplitContainerMain.Panel1
        '
        Me.SplitContainerMain.Panel1.Controls.Add(Me.SplitContainerSubtitlesAndEditor)
        Me.SplitContainerMain.Panel1MinSize = 405
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.Controls.Add(Me.SplitContainerVideoAndBrowser)
        Me.SplitContainerMain.Size = New System.Drawing.Size(1149, 566)
        Me.SplitContainerMain.SplitterDistance = 405
        Me.SplitContainerMain.TabIndex = 10
        '
        'SplitContainerSubtitlesAndEditor
        '
        Me.SplitContainerSubtitlesAndEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerSubtitlesAndEditor.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerSubtitlesAndEditor.Name = "SplitContainerSubtitlesAndEditor"
        Me.SplitContainerSubtitlesAndEditor.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerSubtitlesAndEditor.Panel1
        '
        Me.SplitContainerSubtitlesAndEditor.Panel1.Controls.Add(Me.ListViewSubtitles)
        Me.SplitContainerSubtitlesAndEditor.Panel1.Controls.Add(Me.TextBoxSearch)
        Me.SplitContainerSubtitlesAndEditor.Panel1.Controls.Add(Me.ButtonSearch)
        Me.SplitContainerSubtitlesAndEditor.Panel1.Controls.Add(Me.ButtonAddSubtitle)
        Me.SplitContainerSubtitlesAndEditor.Panel1.Controls.Add(Me.ButtonDeleteSubtitle)
        '
        'SplitContainerSubtitlesAndEditor.Panel2
        '
        Me.SplitContainerSubtitlesAndEditor.Panel2.Controls.Add(Me.SubtitlesEditorCtrl)
        Me.SplitContainerSubtitlesAndEditor.Panel2MinSize = 200
        Me.SplitContainerSubtitlesAndEditor.Size = New System.Drawing.Size(405, 566)
        Me.SplitContainerSubtitlesAndEditor.SplitterDistance = 231
        Me.SplitContainerSubtitlesAndEditor.TabIndex = 26
        '
        'SubtitlesEditorCtrl
        '
        Me.SubtitlesEditorCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SubtitlesEditorCtrl.Dictionaries = Nothing
        Me.SubtitlesEditorCtrl.Location = New System.Drawing.Point(3, 3)
        Me.SubtitlesEditorCtrl.Name = "SubtitlesEditorCtrl"
        Me.SubtitlesEditorCtrl.Size = New System.Drawing.Size(399, 325)
        Me.SubtitlesEditorCtrl.SpellCheckerEngine = Nothing
        Me.SubtitlesEditorCtrl.SubtitleIndex = -1
        Me.SubtitlesEditorCtrl.Subtitles = Nothing
        Me.SubtitlesEditorCtrl.TabIndex = 27
        '
        'SplitContainerVideoAndBrowser
        '
        Me.SplitContainerVideoAndBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerVideoAndBrowser.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerVideoAndBrowser.Name = "SplitContainerVideoAndBrowser"
        Me.SplitContainerVideoAndBrowser.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerVideoAndBrowser.Panel1
        '
        Me.SplitContainerVideoAndBrowser.Panel1.Controls.Add(Me.LabelExtractingAWF)
        Me.SplitContainerVideoAndBrowser.Panel1.Controls.Add(Me.VlcCtrl)
        Me.SplitContainerVideoAndBrowser.Panel1.Controls.Add(Me.ButtonPlay)
        Me.SplitContainerVideoAndBrowser.Panel1.Controls.Add(Me.TrackBarPosition)
        Me.SplitContainerVideoAndBrowser.Panel1.Controls.Add(Me.LabelTime)
        '
        'SplitContainerVideoAndBrowser.Panel2
        '
        Me.SplitContainerVideoAndBrowser.Panel2.Controls.Add(Me.CheckBoxRippleEdits)
        Me.SplitContainerVideoAndBrowser.Panel2.Controls.Add(Me.ButtonZoomOut)
        Me.SplitContainerVideoAndBrowser.Panel2.Controls.Add(Me.TrackBarZoom)
        Me.SplitContainerVideoAndBrowser.Panel2.Controls.Add(Me.SubtitlesBrowserCtrl)
        Me.SplitContainerVideoAndBrowser.Panel2.Controls.Add(Me.ButtonZoomIn)
        Me.SplitContainerVideoAndBrowser.Panel2MinSize = 150
        Me.SplitContainerVideoAndBrowser.Size = New System.Drawing.Size(740, 566)
        Me.SplitContainerVideoAndBrowser.SplitterDistance = 409
        Me.SplitContainerVideoAndBrowser.TabIndex = 32
        '
        'SubtitlesBrowserCtrl
        '
        Me.SubtitlesBrowserCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SubtitlesBrowserCtrl.BackColor = System.Drawing.Color.Black
        Me.SubtitlesBrowserCtrl.Enabled = False
        Me.SubtitlesBrowserCtrl.GridColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.SubtitlesBrowserCtrl.GridTimeColor = System.Drawing.Color.Silver
        Me.SubtitlesBrowserCtrl.GridTimeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.SubtitlesBrowserCtrl.Location = New System.Drawing.Point(3, 3)
        Me.SubtitlesBrowserCtrl.MediaDuration = System.TimeSpan.Parse("00:00:00")
        Me.SubtitlesBrowserCtrl.Name = "SubtitlesBrowserCtrl"
        Me.SubtitlesBrowserCtrl.PeaksFileName = Nothing
        Me.SubtitlesBrowserCtrl.Position = System.TimeSpan.Parse("00:00:00")
        Me.SubtitlesBrowserCtrl.PositionMarkerColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.SubtitlesBrowserCtrl.RippleEdits = False
        Me.SubtitlesBrowserCtrl.SelectedSubtitle = Nothing
        Me.SubtitlesBrowserCtrl.Size = New System.Drawing.Size(701, 147)
        Me.SubtitlesBrowserCtrl.SubtitleBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.SubtitlesBrowserCtrl.Subtitles = Nothing
        Me.SubtitlesBrowserCtrl.SubtitleSelectedBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.SubtitlesBrowserCtrl.TabIndex = 21
        Me.SubtitlesBrowserCtrl.WaveFormColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.SubtitlesBrowserCtrl.WaveFormSelectedColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SubtitlesBrowserCtrl.ZoomFactor = 10.0!
        '
        'MenuStripMainMenu
        '
        Me.MenuStripMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemMainMenuFile, Me.ToolStripMenuItemMainMenuEdit})
        Me.MenuStripMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMainMenu.Name = "MenuStripMainMenu"
        Me.MenuStripMainMenu.Size = New System.Drawing.Size(1173, 24)
        Me.MenuStripMainMenu.TabIndex = 30
        '
        'ToolStripMenuItemMainMenuFile
        '
        Me.ToolStripMenuItemMainMenuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemMainMenuNewSubtitle, Me.ToolStripMenuItem5, Me.ToolStripMenuItemMainMenuOpenSubtitle, Me.ToolStripMenuItemMainMenuOpenVideo, Me.ToolStripMenuItem1, Me.ToolStripMenuItemMainMenuSave, Me.ToolStripMenuItemMainMenuSaveAs, Me.ToolStripMenuItem2, Me.ToolStripMenuItemMainMenuExit})
        Me.ToolStripMenuItemMainMenuFile.Name = "ToolStripMenuItemMainMenuFile"
        Me.ToolStripMenuItemMainMenuFile.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItemMainMenuFile.Text = "File"
        '
        'ToolStripMenuItemMainMenuNewSubtitle
        '
        Me.ToolStripMenuItemMainMenuNewSubtitle.Name = "ToolStripMenuItemMainMenuNewSubtitle"
        Me.ToolStripMenuItemMainMenuNewSubtitle.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemMainMenuNewSubtitle.Size = New System.Drawing.Size(220, 22)
        Me.ToolStripMenuItemMainMenuNewSubtitle.Text = "New Subtitle"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(217, 6)
        '
        'ToolStripMenuItemMainMenuOpenSubtitle
        '
        Me.ToolStripMenuItemMainMenuOpenSubtitle.Name = "ToolStripMenuItemMainMenuOpenSubtitle"
        Me.ToolStripMenuItemMainMenuOpenSubtitle.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemMainMenuOpenSubtitle.Size = New System.Drawing.Size(220, 22)
        Me.ToolStripMenuItemMainMenuOpenSubtitle.Text = "Open Subtitle..."
        '
        'ToolStripMenuItemMainMenuOpenVideo
        '
        Me.ToolStripMenuItemMainMenuOpenVideo.Name = "ToolStripMenuItemMainMenuOpenVideo"
        Me.ToolStripMenuItemMainMenuOpenVideo.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemMainMenuOpenVideo.Size = New System.Drawing.Size(220, 22)
        Me.ToolStripMenuItemMainMenuOpenVideo.Text = "Open Video..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(217, 6)
        '
        'ToolStripMenuItemMainMenuSave
        '
        Me.ToolStripMenuItemMainMenuSave.Name = "ToolStripMenuItemMainMenuSave"
        Me.ToolStripMenuItemMainMenuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemMainMenuSave.Size = New System.Drawing.Size(220, 22)
        Me.ToolStripMenuItemMainMenuSave.Text = "Save"
        '
        'ToolStripMenuItemMainMenuSaveAs
        '
        Me.ToolStripMenuItemMainMenuSaveAs.Name = "ToolStripMenuItemMainMenuSaveAs"
        Me.ToolStripMenuItemMainMenuSaveAs.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemMainMenuSaveAs.Size = New System.Drawing.Size(220, 22)
        Me.ToolStripMenuItemMainMenuSaveAs.Text = "Save As..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(217, 6)
        '
        'ToolStripMenuItemMainMenuExit
        '
        Me.ToolStripMenuItemMainMenuExit.Name = "ToolStripMenuItemMainMenuExit"
        Me.ToolStripMenuItemMainMenuExit.Size = New System.Drawing.Size(220, 22)
        Me.ToolStripMenuItemMainMenuExit.Text = "Exit"
        '
        'ToolStripMenuItemMainMenuEdit
        '
        Me.ToolStripMenuItemMainMenuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemMainMenuEditUndo, Me.ToolStripMenuItemMainMenuEditRedo, Me.ToolStripMenuItem3, Me.ToolStripMenuItemMainMenuEditFind, Me.ToolStripMenuItem4, Me.ToolStripMenuItemMainMenuEditOptions})
        Me.ToolStripMenuItemMainMenuEdit.Name = "ToolStripMenuItemMainMenuEdit"
        Me.ToolStripMenuItemMainMenuEdit.Size = New System.Drawing.Size(39, 20)
        Me.ToolStripMenuItemMainMenuEdit.Text = "Edit"
        '
        'ToolStripMenuItemMainMenuEditUndo
        '
        Me.ToolStripMenuItemMainMenuEditUndo.Name = "ToolStripMenuItemMainMenuEditUndo"
        Me.ToolStripMenuItemMainMenuEditUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemMainMenuEditUndo.Size = New System.Drawing.Size(192, 22)
        Me.ToolStripMenuItemMainMenuEditUndo.Text = "Undo"
        '
        'ToolStripMenuItemMainMenuEditRedo
        '
        Me.ToolStripMenuItemMainMenuEditRedo.Name = "ToolStripMenuItemMainMenuEditRedo"
        Me.ToolStripMenuItemMainMenuEditRedo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemMainMenuEditRedo.Size = New System.Drawing.Size(192, 22)
        Me.ToolStripMenuItemMainMenuEditRedo.Text = "Redo"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(189, 6)
        '
        'ToolStripMenuItemMainMenuEditFind
        '
        Me.ToolStripMenuItemMainMenuEditFind.Name = "ToolStripMenuItemMainMenuEditFind"
        Me.ToolStripMenuItemMainMenuEditFind.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemMainMenuEditFind.Size = New System.Drawing.Size(192, 22)
        Me.ToolStripMenuItemMainMenuEditFind.Text = "Find/Replace..."
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(189, 6)
        '
        'ToolStripMenuItemMainMenuEditOptions
        '
        Me.ToolStripMenuItemMainMenuEditOptions.Name = "ToolStripMenuItemMainMenuEditOptions"
        Me.ToolStripMenuItemMainMenuEditOptions.Size = New System.Drawing.Size(192, 22)
        Me.ToolStripMenuItemMainMenuEditOptions.Text = "Options..."
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 692)
        Me.Controls.Add(Me.LabelDownloading)
        Me.Controls.Add(Me.ProgressBarDownload)
        Me.Controls.Add(Me.LinkLabelNewVersionDownload)
        Me.Controls.Add(Me.LabelNewVersionInfo)
        Me.Controls.Add(Me.ComboBoxLanguages)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ButtonBrowseVideoFile)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxVideoFile)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Controls.Add(Me.ButtonBrowseSubtitlesFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxSubtitlesFile)
        Me.Controls.Add(Me.MenuStripMainMenu)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FormMain"
        Me.Text = "SubsEditor"
        CType(Me.TrackBarPosition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonPlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        Me.SplitContainerMain.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.SplitContainerSubtitlesAndEditor.Panel1.ResumeLayout(False)
        Me.SplitContainerSubtitlesAndEditor.Panel1.PerformLayout()
        Me.SplitContainerSubtitlesAndEditor.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerSubtitlesAndEditor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerSubtitlesAndEditor.ResumeLayout(False)
        Me.SplitContainerVideoAndBrowser.Panel1.ResumeLayout(False)
        Me.SplitContainerVideoAndBrowser.Panel1.PerformLayout()
        Me.SplitContainerVideoAndBrowser.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerVideoAndBrowser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerVideoAndBrowser.ResumeLayout(False)
        Me.MenuStripMainMenu.ResumeLayout(False)
        Me.MenuStripMainMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxSubtitlesFile As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonBrowseSubtitlesFile As System.Windows.Forms.Button
    Friend WithEvents ListViewSubtitles As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeaderTimeFromOffsetted As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderTimeToOffsetted As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderSubtitles As System.Windows.Forms.ColumnHeader
    Friend WithEvents ButtonBrowseVideoFile As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxVideoFile As System.Windows.Forms.TextBox
    Friend WithEvents VlcCtrl As Vlc.DotNet.Forms.VlcControl
    Friend WithEvents TrackBarPosition As System.Windows.Forms.TrackBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxLanguages As System.Windows.Forms.ComboBox
    Friend WithEvents LabelTime As System.Windows.Forms.Label
    Friend WithEvents ButtonAddSubtitle As System.Windows.Forms.Button
    Friend WithEvents ButtonDeleteSubtitle As System.Windows.Forms.Button
    Friend WithEvents SubtitlesBrowserCtrl As SubsEditor.SubtitlesBrowser
    Friend WithEvents ButtonZoomOut As System.Windows.Forms.Button
    Friend WithEvents ButtonZoomIn As System.Windows.Forms.Button
    Friend WithEvents CheckBoxRippleEdits As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonPlay As System.Windows.Forms.PictureBox
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSearch As System.Windows.Forms.Button
    Friend WithEvents LabelNewVersionInfo As System.Windows.Forms.Label
    Friend WithEvents LinkLabelNewVersionDownload As System.Windows.Forms.LinkLabel
    Friend WithEvents ProgressBarDownload As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelDownloading As System.Windows.Forms.Label
    Friend WithEvents LabelExtractingAWF As System.Windows.Forms.Label
    Friend WithEvents TrackBarZoom As System.Windows.Forms.TrackBar
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainerVideoAndBrowser As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainerSubtitlesAndEditor As System.Windows.Forms.SplitContainer
    Friend WithEvents SubtitlesEditorCtrl As SubsEditor.SubtitlesEditor
    Friend WithEvents MenuStripMainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItemMainMenuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemMainMenuOpenSubtitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemMainMenuOpenVideo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemMainMenuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemMainMenuSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemMainMenuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemMainMenuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemMainMenuEditUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemMainMenuEditRedo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemMainMenuEditOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemMainMenuEditFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemMainMenuNewSubtitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
End Class
