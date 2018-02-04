<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVideo
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
        Me.vlcCtrl = New Vlc.DotNet.Forms.VlcControl()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.tbPosition = New System.Windows.Forms.TrackBar()
        CType(Me.tbPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'vlcCtrl
        '
        Me.vlcCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vlcCtrl.Location = New System.Drawing.Point(12, 12)
        Me.vlcCtrl.Name = "vlcCtrl"
        Me.vlcCtrl.Position = 0.0!
        Me.vlcCtrl.Rate = 0.0!
        Me.vlcCtrl.Size = New System.Drawing.Size(260, 209)
        Me.vlcCtrl.TabIndex = 0
        '
        'btnPlay
        '
        Me.btnPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPlay.Location = New System.Drawing.Point(13, 227)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(75, 23)
        Me.btnPlay.TabIndex = 1
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'tbPosition
        '
        Me.tbPosition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPosition.AutoSize = False
        Me.tbPosition.LargeChange = 10
        Me.tbPosition.Location = New System.Drawing.Point(94, 227)
        Me.tbPosition.Maximum = 100
        Me.tbPosition.Name = "tbPosition"
        Me.tbPosition.Size = New System.Drawing.Size(178, 23)
        Me.tbPosition.TabIndex = 2
        '
        'frmVideo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbPosition)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.vlcCtrl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmVideo"
        Me.Text = "Video"
        CType(Me.tbPosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents vlcCtrl As Vlc.DotNet.Forms.VlcControl
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents tbPosition As System.Windows.Forms.TrackBar
End Class
