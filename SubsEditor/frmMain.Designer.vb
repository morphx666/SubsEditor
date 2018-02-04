<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.txtSubtitlesFile = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBrowseSubtitlesFile = New System.Windows.Forms.Button()
        Me.btnBrowseVideoFile = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVideoFile = New System.Windows.Forms.TextBox()
        Me.vlcCtrl = New Vlc.DotNet.Forms.VlcControl()
        Me.tbPosition = New System.Windows.Forms.TrackBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbLanguages = New System.Windows.Forms.ComboBox()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.btnZoomOut = New System.Windows.Forms.Button()
        Me.btnZoomIn = New System.Windows.Forms.Button()
        Me.chkRippleEdits = New System.Windows.Forms.CheckBox()
        Me.btnPlay = New System.Windows.Forms.PictureBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnAddSubtitle = New System.Windows.Forms.Button()
        Me.btnDeleteSubtitle = New System.Windows.Forms.Button()
        Me.lvSubtitles = New System.Windows.Forms.ListView()
        Me.chTimeFromOffsetted = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTimeToOffsetted = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chSubtitles = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblNewVersionInfo = New System.Windows.Forms.Label()
        Me.lnkNewVersionDownload = New System.Windows.Forms.LinkLabel()
        Me.pbDownload = New System.Windows.Forms.ProgressBar()
        Me.lblDownloading = New System.Windows.Forms.Label()
        Me.lblExtractingAWF = New System.Windows.Forms.Label()
        Me.tbZoom = New System.Windows.Forms.TrackBar()
        Me.scMain = New System.Windows.Forms.SplitContainer()
        Me.scSubtitlesAndEditor = New System.Windows.Forms.SplitContainer()
        Me.seCtrl = New SubsEditor.SubtitlesEditor()
        Me.scVideoAndBrowser = New System.Windows.Forms.SplitContainer()
        Me.sbCtrl = New SubsEditor.SubtitlesBrowser()
        Me.msMainMenu = New System.Windows.Forms.MenuStrip()
        Me.msMainMenuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMainMenuNewSubtitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.msMainMenuOpenSubtitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMainMenuOpenVideo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.msMainMenuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMainMenuSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.msMainMenuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMainMenuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMainMenuEditUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMainMenuEditRedo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.msMainMenuEditFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.msMainMenuEditOptions = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.tbPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scMain.Panel1.SuspendLayout()
        Me.scMain.Panel2.SuspendLayout()
        Me.scMain.SuspendLayout()
        CType(Me.scSubtitlesAndEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scSubtitlesAndEditor.Panel1.SuspendLayout()
        Me.scSubtitlesAndEditor.Panel2.SuspendLayout()
        Me.scSubtitlesAndEditor.SuspendLayout()
        CType(Me.scVideoAndBrowser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scVideoAndBrowser.Panel1.SuspendLayout()
        Me.scVideoAndBrowser.Panel2.SuspendLayout()
        Me.scVideoAndBrowser.SuspendLayout()
        Me.msMainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSubtitlesFile
        '
        Me.txtSubtitlesFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubtitlesFile.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubtitlesFile.Location = New System.Drawing.Point(59, 27)
        Me.txtSubtitlesFile.Name = "txtSubtitlesFile"
        Me.txtSubtitlesFile.ReadOnly = True
        Me.txtSubtitlesFile.Size = New System.Drawing.Size(485, 22)
        Me.txtSubtitlesFile.TabIndex = 1
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
        'btnBrowseSubtitlesFile
        '
        Me.btnBrowseSubtitlesFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseSubtitlesFile.Location = New System.Drawing.Point(550, 28)
        Me.btnBrowseSubtitlesFile.Name = "btnBrowseSubtitlesFile"
        Me.btnBrowseSubtitlesFile.Size = New System.Drawing.Size(26, 20)
        Me.btnBrowseSubtitlesFile.TabIndex = 3
        Me.btnBrowseSubtitlesFile.Text = "..."
        Me.btnBrowseSubtitlesFile.UseVisualStyleBackColor = True
        '
        'btnBrowseVideoFile
        '
        Me.btnBrowseVideoFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseVideoFile.Location = New System.Drawing.Point(550, 53)
        Me.btnBrowseVideoFile.Name = "btnBrowseVideoFile"
        Me.btnBrowseVideoFile.Size = New System.Drawing.Size(26, 20)
        Me.btnBrowseVideoFile.TabIndex = 14
        Me.btnBrowseVideoFile.Text = "..."
        Me.btnBrowseVideoFile.UseVisualStyleBackColor = True
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
        'txtVideoFile
        '
        Me.txtVideoFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVideoFile.BackColor = System.Drawing.SystemColors.Window
        Me.txtVideoFile.Location = New System.Drawing.Point(59, 52)
        Me.txtVideoFile.Name = "txtVideoFile"
        Me.txtVideoFile.ReadOnly = True
        Me.txtVideoFile.Size = New System.Drawing.Size(485, 22)
        Me.txtVideoFile.TabIndex = 12
        '
        'vlcCtrl
        '
        Me.vlcCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vlcCtrl.BackColor = System.Drawing.Color.Black
        Me.vlcCtrl.Location = New System.Drawing.Point(3, 4)
        Me.vlcCtrl.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.vlcCtrl.Name = "vlcCtrl"
        Me.vlcCtrl.Rate = 0!
        Me.vlcCtrl.Size = New System.Drawing.Size(734, 368)
        Me.vlcCtrl.TabIndex = 15
        '
        'tbPosition
        '
        Me.tbPosition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPosition.AutoSize = False
        Me.tbPosition.Enabled = False
        Me.tbPosition.LargeChange = 10000
        Me.tbPosition.Location = New System.Drawing.Point(41, 377)
        Me.tbPosition.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbPosition.Maximum = 1000000
        Me.tbPosition.Name = "tbPosition"
        Me.tbPosition.Size = New System.Drawing.Size(554, 32)
        Me.tbPosition.SmallChange = 100
        Me.tbPosition.TabIndex = 17
        Me.tbPosition.TickFrequency = 10000
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
        'cmbLanguages
        '
        Me.cmbLanguages.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLanguages.Enabled = False
        Me.cmbLanguages.FormattingEnabled = True
        Me.cmbLanguages.ItemHeight = 13
        Me.cmbLanguages.Location = New System.Drawing.Point(1057, 52)
        Me.cmbLanguages.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbLanguages.Name = "cmbLanguages"
        Me.cmbLanguages.Size = New System.Drawing.Size(104, 21)
        Me.cmbLanguages.TabIndex = 19
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(609, 384)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(128, 18)
        Me.lblTime.TabIndex = 20
        Me.lblTime.Text = "00:00:00,000"
        '
        'btnZoomOut
        '
        Me.btnZoomOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZoomOut.BackColor = System.Drawing.SystemColors.Control
        Me.btnZoomOut.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZoomOut.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZoomOut.Image = Global.SubsEditor.My.Resources.Resources.magifier_zoom_out
        Me.btnZoomOut.Location = New System.Drawing.Point(710, 95)
        Me.btnZoomOut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(27, 25)
        Me.btnZoomOut.TabIndex = 24
        Me.btnZoomOut.UseMnemonic = False
        Me.btnZoomOut.UseVisualStyleBackColor = False
        '
        'btnZoomIn
        '
        Me.btnZoomIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZoomIn.BackColor = System.Drawing.SystemColors.Control
        Me.btnZoomIn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZoomIn.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZoomIn.Image = Global.SubsEditor.My.Resources.Resources.magnifier_zoom_in
        Me.btnZoomIn.Location = New System.Drawing.Point(710, 3)
        Me.btnZoomIn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.Size = New System.Drawing.Size(27, 25)
        Me.btnZoomIn.TabIndex = 23
        Me.btnZoomIn.UseMnemonic = False
        Me.btnZoomIn.UseVisualStyleBackColor = False
        '
        'chkRippleEdits
        '
        Me.chkRippleEdits.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkRippleEdits.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkRippleEdits.Enabled = False
        Me.chkRippleEdits.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.chkRippleEdits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkRippleEdits.Image = Global.SubsEditor.My.Resources.Resources.lock_open
        Me.chkRippleEdits.Location = New System.Drawing.Point(710, 125)
        Me.chkRippleEdits.Name = "chkRippleEdits"
        Me.chkRippleEdits.Size = New System.Drawing.Size(27, 25)
        Me.chkRippleEdits.TabIndex = 13
        Me.chkRippleEdits.UseVisualStyleBackColor = True
        '
        'btnPlay
        '
        Me.btnPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPlay.BackColor = System.Drawing.SystemColors.Control
        Me.btnPlay.Enabled = False
        Me.btnPlay.Image = Global.SubsEditor.My.Resources.Resources.playpause_off
        Me.btnPlay.Location = New System.Drawing.Point(3, 377)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(32, 32)
        Me.btnPlay.TabIndex = 25
        Me.btnPlay.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Enabled = False
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(375, 4)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(27, 22)
        Me.btnSearch.TabIndex = 25
        Me.btnSearch.UseMnemonic = False
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Enabled = False
        Me.txtSearch.Location = New System.Drawing.Point(219, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(150, 22)
        Me.txtSearch.TabIndex = 13
        '
        'btnAddSubtitle
        '
        Me.btnAddSubtitle.Enabled = False
        Me.btnAddSubtitle.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnAddSubtitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSubtitle.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSubtitle.Image = Global.SubsEditor.My.Resources.Resources.pencil_add
        Me.btnAddSubtitle.Location = New System.Drawing.Point(3, 4)
        Me.btnAddSubtitle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAddSubtitle.Name = "btnAddSubtitle"
        Me.btnAddSubtitle.Size = New System.Drawing.Size(27, 25)
        Me.btnAddSubtitle.TabIndex = 12
        Me.btnAddSubtitle.UseMnemonic = False
        Me.btnAddSubtitle.UseVisualStyleBackColor = True
        '
        'btnDeleteSubtitle
        '
        Me.btnDeleteSubtitle.Enabled = False
        Me.btnDeleteSubtitle.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnDeleteSubtitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteSubtitle.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteSubtitle.Image = Global.SubsEditor.My.Resources.Resources.pencil_delete
        Me.btnDeleteSubtitle.Location = New System.Drawing.Point(36, 4)
        Me.btnDeleteSubtitle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDeleteSubtitle.Name = "btnDeleteSubtitle"
        Me.btnDeleteSubtitle.Size = New System.Drawing.Size(27, 25)
        Me.btnDeleteSubtitle.TabIndex = 12
        Me.btnDeleteSubtitle.UseMnemonic = False
        Me.btnDeleteSubtitle.UseVisualStyleBackColor = True
        '
        'lvSubtitles
        '
        Me.lvSubtitles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvSubtitles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chTimeFromOffsetted, Me.chTimeToOffsetted, Me.chSubtitles})
        Me.lvSubtitles.FullRowSelect = True
        Me.lvSubtitles.HideSelection = False
        Me.lvSubtitles.Location = New System.Drawing.Point(3, 34)
        Me.lvSubtitles.Name = "lvSubtitles"
        Me.lvSubtitles.Size = New System.Drawing.Size(399, 194)
        Me.lvSubtitles.TabIndex = 10
        Me.lvSubtitles.UseCompatibleStateImageBehavior = False
        Me.lvSubtitles.View = System.Windows.Forms.View.Details
        '
        'chTimeFromOffsetted
        '
        Me.chTimeFromOffsetted.Text = "From"
        '
        'chTimeToOffsetted
        '
        Me.chTimeToOffsetted.Text = "To"
        '
        'chSubtitles
        '
        Me.chSubtitles.Text = "Subtitle"
        '
        'lblNewVersionInfo
        '
        Me.lblNewVersionInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNewVersionInfo.AutoSize = True
        Me.lblNewVersionInfo.ForeColor = System.Drawing.Color.Red
        Me.lblNewVersionInfo.Location = New System.Drawing.Point(12, 655)
        Me.lblNewVersionInfo.Name = "lblNewVersionInfo"
        Me.lblNewVersionInfo.Size = New System.Drawing.Size(211, 13)
        Me.lblNewVersionInfo.TabIndex = 26
        Me.lblNewVersionInfo.Text = "A new version of SubsEditor is available"
        Me.lblNewVersionInfo.Visible = False
        '
        'lnkNewVersionDownload
        '
        Me.lnkNewVersionDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkNewVersionDownload.AutoSize = True
        Me.lnkNewVersionDownload.LinkArea = New System.Windows.Forms.LinkArea(0, 37)
        Me.lnkNewVersionDownload.Location = New System.Drawing.Point(12, 670)
        Me.lnkNewVersionDownload.Name = "lnkNewVersionDownload"
        Me.lnkNewVersionDownload.Size = New System.Drawing.Size(130, 20)
        Me.lnkNewVersionDownload.TabIndex = 27
        Me.lnkNewVersionDownload.TabStop = True
        Me.lnkNewVersionDownload.Text = "Download SubsEditor 1.0"
        Me.lnkNewVersionDownload.UseCompatibleTextRendering = True
        Me.lnkNewVersionDownload.Visible = False
        '
        'pbDownload
        '
        Me.pbDownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbDownload.Location = New System.Drawing.Point(553, 655)
        Me.pbDownload.Name = "pbDownload"
        Me.pbDownload.Size = New System.Drawing.Size(608, 23)
        Me.pbDownload.TabIndex = 28
        Me.pbDownload.Visible = False
        '
        'lblDownloading
        '
        Me.lblDownloading.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDownloading.AutoSize = True
        Me.lblDownloading.Location = New System.Drawing.Point(469, 660)
        Me.lblDownloading.Name = "lblDownloading"
        Me.lblDownloading.Size = New System.Drawing.Size(78, 13)
        Me.lblDownloading.TabIndex = 29
        Me.lblDownloading.Text = "Downloading"
        Me.lblDownloading.Visible = False
        '
        'lblExtractingAWF
        '
        Me.lblExtractingAWF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExtractingAWF.AutoSize = True
        Me.lblExtractingAWF.BackColor = System.Drawing.Color.Black
        Me.lblExtractingAWF.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblExtractingAWF.Location = New System.Drawing.Point(3, 344)
        Me.lblExtractingAWF.Margin = New System.Windows.Forms.Padding(0)
        Me.lblExtractingAWF.Name = "lblExtractingAWF"
        Me.lblExtractingAWF.Padding = New System.Windows.Forms.Padding(6)
        Me.lblExtractingAWF.Size = New System.Drawing.Size(168, 25)
        Me.lblExtractingAWF.TabIndex = 30
        Me.lblExtractingAWF.Text = "Extracting Audio Waveform..."
        Me.lblExtractingAWF.Visible = False
        '
        'tbZoom
        '
        Me.tbZoom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbZoom.AutoSize = False
        Me.tbZoom.LargeChange = 10
        Me.tbZoom.Location = New System.Drawing.Point(710, 33)
        Me.tbZoom.Maximum = 500
        Me.tbZoom.Minimum = 10
        Me.tbZoom.Name = "tbZoom"
        Me.tbZoom.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbZoom.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbZoom.RightToLeftLayout = True
        Me.tbZoom.Size = New System.Drawing.Size(27, 57)
        Me.tbZoom.TabIndex = 31
        Me.tbZoom.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbZoom.Value = 10
        '
        'scMain
        '
        Me.scMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scMain.Location = New System.Drawing.Point(12, 80)
        Me.scMain.Name = "scMain"
        '
        'scMain.Panel1
        '
        Me.scMain.Panel1.Controls.Add(Me.scSubtitlesAndEditor)
        Me.scMain.Panel1MinSize = 405
        '
        'scMain.Panel2
        '
        Me.scMain.Panel2.Controls.Add(Me.scVideoAndBrowser)
        Me.scMain.Size = New System.Drawing.Size(1149, 566)
        Me.scMain.SplitterDistance = 405
        Me.scMain.TabIndex = 10
        '
        'scSubtitlesAndEditor
        '
        Me.scSubtitlesAndEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scSubtitlesAndEditor.Location = New System.Drawing.Point(0, 0)
        Me.scSubtitlesAndEditor.Name = "scSubtitlesAndEditor"
        Me.scSubtitlesAndEditor.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scSubtitlesAndEditor.Panel1
        '
        Me.scSubtitlesAndEditor.Panel1.Controls.Add(Me.lvSubtitles)
        Me.scSubtitlesAndEditor.Panel1.Controls.Add(Me.txtSearch)
        Me.scSubtitlesAndEditor.Panel1.Controls.Add(Me.btnSearch)
        Me.scSubtitlesAndEditor.Panel1.Controls.Add(Me.btnAddSubtitle)
        Me.scSubtitlesAndEditor.Panel1.Controls.Add(Me.btnDeleteSubtitle)
        '
        'scSubtitlesAndEditor.Panel2
        '
        Me.scSubtitlesAndEditor.Panel2.Controls.Add(Me.seCtrl)
        Me.scSubtitlesAndEditor.Panel2MinSize = 200
        Me.scSubtitlesAndEditor.Size = New System.Drawing.Size(405, 566)
        Me.scSubtitlesAndEditor.SplitterDistance = 231
        Me.scSubtitlesAndEditor.TabIndex = 26
        '
        'seCtrl
        '
        Me.seCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.seCtrl.Dictionaries = Nothing
        Me.seCtrl.Location = New System.Drawing.Point(3, 3)
        Me.seCtrl.Name = "seCtrl"
        Me.seCtrl.Size = New System.Drawing.Size(399, 325)
        Me.seCtrl.SpellCheckerEngine = Nothing
        Me.seCtrl.SubtitleIndex = -1
        Me.seCtrl.Subtitles = Nothing
        Me.seCtrl.TabIndex = 27
        '
        'scVideoAndBrowser
        '
        Me.scVideoAndBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scVideoAndBrowser.Location = New System.Drawing.Point(0, 0)
        Me.scVideoAndBrowser.Name = "scVideoAndBrowser"
        Me.scVideoAndBrowser.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scVideoAndBrowser.Panel1
        '
        Me.scVideoAndBrowser.Panel1.Controls.Add(Me.lblExtractingAWF)
        Me.scVideoAndBrowser.Panel1.Controls.Add(Me.vlcCtrl)
        Me.scVideoAndBrowser.Panel1.Controls.Add(Me.btnPlay)
        Me.scVideoAndBrowser.Panel1.Controls.Add(Me.tbPosition)
        Me.scVideoAndBrowser.Panel1.Controls.Add(Me.lblTime)
        '
        'scVideoAndBrowser.Panel2
        '
        Me.scVideoAndBrowser.Panel2.Controls.Add(Me.chkRippleEdits)
        Me.scVideoAndBrowser.Panel2.Controls.Add(Me.btnZoomOut)
        Me.scVideoAndBrowser.Panel2.Controls.Add(Me.tbZoom)
        Me.scVideoAndBrowser.Panel2.Controls.Add(Me.sbCtrl)
        Me.scVideoAndBrowser.Panel2.Controls.Add(Me.btnZoomIn)
        Me.scVideoAndBrowser.Panel2MinSize = 150
        Me.scVideoAndBrowser.Size = New System.Drawing.Size(740, 566)
        Me.scVideoAndBrowser.SplitterDistance = 409
        Me.scVideoAndBrowser.TabIndex = 32
        '
        'sbCtrl
        '
        Me.sbCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbCtrl.BackColor = System.Drawing.Color.Black
        Me.sbCtrl.Enabled = False
        Me.sbCtrl.GridColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.sbCtrl.GridTimeColor = System.Drawing.Color.Silver
        Me.sbCtrl.GridTimeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.sbCtrl.Location = New System.Drawing.Point(3, 3)
        Me.sbCtrl.MediaDuration = System.TimeSpan.Parse("00:00:00")
        Me.sbCtrl.Name = "sbCtrl"
        Me.sbCtrl.PeaksFileName = Nothing
        Me.sbCtrl.Position = System.TimeSpan.Parse("00:00:00")
        Me.sbCtrl.PositionMarkerColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.sbCtrl.RippleEdits = False
        Me.sbCtrl.SelectedSubtitle = Nothing
        Me.sbCtrl.Size = New System.Drawing.Size(701, 147)
        Me.sbCtrl.SubtitleBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.sbCtrl.Subtitles = Nothing
        Me.sbCtrl.SubtitleSelectedBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.sbCtrl.TabIndex = 21
        Me.sbCtrl.WaveFormColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.sbCtrl.WaveFormSelectedColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sbCtrl.ZoomFactor = 10.0!
        '
        'msMainMenu
        '
        Me.msMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msMainMenuFile, Me.msMainMenuEdit})
        Me.msMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMainMenu.Name = "msMainMenu"
        Me.msMainMenu.Size = New System.Drawing.Size(1173, 24)
        Me.msMainMenu.TabIndex = 30
        '
        'msMainMenuFile
        '
        Me.msMainMenuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msMainMenuNewSubtitle, Me.ToolStripMenuItem5, Me.msMainMenuOpenSubtitle, Me.msMainMenuOpenVideo, Me.ToolStripMenuItem1, Me.msMainMenuSave, Me.msMainMenuSaveAs, Me.ToolStripMenuItem2, Me.msMainMenuExit})
        Me.msMainMenuFile.Name = "msMainMenuFile"
        Me.msMainMenuFile.Size = New System.Drawing.Size(37, 20)
        Me.msMainMenuFile.Text = "File"
        '
        'msMainMenuNewSubtitle
        '
        Me.msMainMenuNewSubtitle.Name = "msMainMenuNewSubtitle"
        Me.msMainMenuNewSubtitle.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.msMainMenuNewSubtitle.Size = New System.Drawing.Size(220, 22)
        Me.msMainMenuNewSubtitle.Text = "New Subtitle"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(217, 6)
        '
        'msMainMenuOpenSubtitle
        '
        Me.msMainMenuOpenSubtitle.Name = "msMainMenuOpenSubtitle"
        Me.msMainMenuOpenSubtitle.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.msMainMenuOpenSubtitle.Size = New System.Drawing.Size(220, 22)
        Me.msMainMenuOpenSubtitle.Text = "Open Subtitle..."
        '
        'msMainMenuOpenVideo
        '
        Me.msMainMenuOpenVideo.Name = "msMainMenuOpenVideo"
        Me.msMainMenuOpenVideo.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.msMainMenuOpenVideo.Size = New System.Drawing.Size(220, 22)
        Me.msMainMenuOpenVideo.Text = "Open Video..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(217, 6)
        '
        'msMainMenuSave
        '
        Me.msMainMenuSave.Name = "msMainMenuSave"
        Me.msMainMenuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.msMainMenuSave.Size = New System.Drawing.Size(220, 22)
        Me.msMainMenuSave.Text = "Save"
        '
        'msMainMenuSaveAs
        '
        Me.msMainMenuSaveAs.Name = "msMainMenuSaveAs"
        Me.msMainMenuSaveAs.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.msMainMenuSaveAs.Size = New System.Drawing.Size(220, 22)
        Me.msMainMenuSaveAs.Text = "Save As..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(217, 6)
        '
        'msMainMenuExit
        '
        Me.msMainMenuExit.Name = "msMainMenuExit"
        Me.msMainMenuExit.Size = New System.Drawing.Size(220, 22)
        Me.msMainMenuExit.Text = "Exit"
        '
        'msMainMenuEdit
        '
        Me.msMainMenuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msMainMenuEditUndo, Me.msMainMenuEditRedo, Me.ToolStripMenuItem3, Me.msMainMenuEditFind, Me.ToolStripMenuItem4, Me.msMainMenuEditOptions})
        Me.msMainMenuEdit.Name = "msMainMenuEdit"
        Me.msMainMenuEdit.Size = New System.Drawing.Size(39, 20)
        Me.msMainMenuEdit.Text = "Edit"
        '
        'msMainMenuEditUndo
        '
        Me.msMainMenuEditUndo.Name = "msMainMenuEditUndo"
        Me.msMainMenuEditUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.msMainMenuEditUndo.Size = New System.Drawing.Size(192, 22)
        Me.msMainMenuEditUndo.Text = "Undo"
        '
        'msMainMenuEditRedo
        '
        Me.msMainMenuEditRedo.Name = "msMainMenuEditRedo"
        Me.msMainMenuEditRedo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.msMainMenuEditRedo.Size = New System.Drawing.Size(192, 22)
        Me.msMainMenuEditRedo.Text = "Redo"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(189, 6)
        '
        'msMainMenuEditFind
        '
        Me.msMainMenuEditFind.Name = "msMainMenuEditFind"
        Me.msMainMenuEditFind.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.msMainMenuEditFind.Size = New System.Drawing.Size(192, 22)
        Me.msMainMenuEditFind.Text = "Find/Replace..."
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(189, 6)
        '
        'msMainMenuEditOptions
        '
        Me.msMainMenuEditOptions.Name = "msMainMenuEditOptions"
        Me.msMainMenuEditOptions.Size = New System.Drawing.Size(192, 22)
        Me.msMainMenuEditOptions.Text = "Options..."
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 692)
        Me.Controls.Add(Me.lblDownloading)
        Me.Controls.Add(Me.pbDownload)
        Me.Controls.Add(Me.lnkNewVersionDownload)
        Me.Controls.Add(Me.lblNewVersionInfo)
        Me.Controls.Add(Me.cmbLanguages)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnBrowseVideoFile)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtVideoFile)
        Me.Controls.Add(Me.scMain)
        Me.Controls.Add(Me.btnBrowseSubtitlesFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSubtitlesFile)
        Me.Controls.Add(Me.msMainMenu)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmMain"
        Me.Text = "SubsEditor"
        CType(Me.tbPosition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel2.ResumeLayout(False)
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scMain.ResumeLayout(False)
        Me.scSubtitlesAndEditor.Panel1.ResumeLayout(False)
        Me.scSubtitlesAndEditor.Panel1.PerformLayout()
        Me.scSubtitlesAndEditor.Panel2.ResumeLayout(False)
        CType(Me.scSubtitlesAndEditor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scSubtitlesAndEditor.ResumeLayout(False)
        Me.scVideoAndBrowser.Panel1.ResumeLayout(False)
        Me.scVideoAndBrowser.Panel1.PerformLayout()
        Me.scVideoAndBrowser.Panel2.ResumeLayout(False)
        CType(Me.scVideoAndBrowser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scVideoAndBrowser.ResumeLayout(False)
        Me.msMainMenu.ResumeLayout(False)
        Me.msMainMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSubtitlesFile As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBrowseSubtitlesFile As System.Windows.Forms.Button
    Friend WithEvents lvSubtitles As System.Windows.Forms.ListView
    Friend WithEvents chTimeFromOffsetted As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTimeToOffsetted As System.Windows.Forms.ColumnHeader
    Friend WithEvents chSubtitles As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnBrowseVideoFile As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtVideoFile As System.Windows.Forms.TextBox
    Friend WithEvents vlcCtrl As Vlc.DotNet.Forms.VlcControl
    Friend WithEvents tbPosition As System.Windows.Forms.TrackBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbLanguages As System.Windows.Forms.ComboBox
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents btnAddSubtitle As System.Windows.Forms.Button
    Friend WithEvents btnDeleteSubtitle As System.Windows.Forms.Button
    Friend WithEvents sbCtrl As SubsEditor.SubtitlesBrowser
    Friend WithEvents btnZoomOut As System.Windows.Forms.Button
    Friend WithEvents btnZoomIn As System.Windows.Forms.Button
    Friend WithEvents chkRippleEdits As System.Windows.Forms.CheckBox
    Friend WithEvents btnPlay As System.Windows.Forms.PictureBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblNewVersionInfo As System.Windows.Forms.Label
    Friend WithEvents lnkNewVersionDownload As System.Windows.Forms.LinkLabel
    Friend WithEvents pbDownload As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDownloading As System.Windows.Forms.Label
    Friend WithEvents lblExtractingAWF As System.Windows.Forms.Label
    Friend WithEvents tbZoom As System.Windows.Forms.TrackBar
    Friend WithEvents scMain As System.Windows.Forms.SplitContainer
    Friend WithEvents scVideoAndBrowser As System.Windows.Forms.SplitContainer
    Friend WithEvents scSubtitlesAndEditor As System.Windows.Forms.SplitContainer
    Friend WithEvents seCtrl As SubsEditor.SubtitlesEditor
    Friend WithEvents msMainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents msMainMenuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msMainMenuOpenSubtitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msMainMenuOpenVideo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents msMainMenuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msMainMenuSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents msMainMenuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msMainMenuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msMainMenuEditUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msMainMenuEditRedo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msMainMenuEditOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents msMainMenuEditFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msMainMenuNewSubtitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
End Class
