<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LookupForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LookupForm))
        Me.LookupHeroNameTXT = New System.Windows.Forms.TextBox()
        Me.ServersCB = New System.Windows.Forms.ComboBox()
        Me.SearchBTN = New System.Windows.Forms.Button()
        Me.PbssImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ResultsGV = New System.Windows.Forms.DataGridView()
        Me.ResultsCMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewHeroScreenshotsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspiciousCB = New System.Windows.Forms.CheckBox()
        Me.PinkCB = New System.Windows.Forms.CheckBox()
        Me.BlackCB = New System.Windows.Forms.CheckBox()
        Me.CroppedCB = New System.Windows.Forms.CheckBox()
        Me.FailedCB = New System.Windows.Forms.CheckBox()
        Me.HeroNameLAB = New System.Windows.Forms.Label()
        Me.DateLAB = New System.Windows.Forms.Label()
        Me.OrgImgLAB = New System.Windows.Forms.Label()
        Me.RenamedImgLAB = New System.Windows.Forms.Label()
        Me.ServerLab = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MaxRecNUM = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ReturnedCntLAB = New System.Windows.Forms.Label()
        Me.NormalCB = New System.Windows.Forms.CheckBox()
        Me.ResetBTN = New System.Windows.Forms.Button()
        Me.CheatersCB = New System.Windows.Forms.CheckBox()
        Me.ViewPB = New System.Windows.Forms.PictureBox()
        Me.BGPanel = New System.Windows.Forms.Panel()
        Me.ExitPB = New System.Windows.Forms.PictureBox()
        Me.MinimizePB = New System.Windows.Forms.PictureBox()
        CType(Me.ResultsGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ResultsCMS.SuspendLayout()
        CType(Me.MaxRecNUM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BGPanel.SuspendLayout()
        CType(Me.ExitPB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinimizePB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LookupHeroNameTXT
        '
        Me.LookupHeroNameTXT.Location = New System.Drawing.Point(97, 178)
        Me.LookupHeroNameTXT.Name = "LookupHeroNameTXT"
        Me.LookupHeroNameTXT.Size = New System.Drawing.Size(158, 20)
        Me.LookupHeroNameTXT.TabIndex = 0
        '
        'ServersCB
        '
        Me.ServersCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ServersCB.FormattingEnabled = True
        Me.ServersCB.Location = New System.Drawing.Point(97, 151)
        Me.ServersCB.Name = "ServersCB"
        Me.ServersCB.Size = New System.Drawing.Size(158, 21)
        Me.ServersCB.TabIndex = 1
        '
        'SearchBTN
        '
        Me.SearchBTN.BackColor = System.Drawing.Color.Transparent
        Me.SearchBTN.Location = New System.Drawing.Point(181, 262)
        Me.SearchBTN.Name = "SearchBTN"
        Me.SearchBTN.Size = New System.Drawing.Size(68, 23)
        Me.SearchBTN.TabIndex = 5
        Me.SearchBTN.Text = "Search"
        Me.SearchBTN.UseVisualStyleBackColor = False
        '
        'PbssImageList
        '
        Me.PbssImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.PbssImageList.ImageSize = New System.Drawing.Size(125, 80)
        Me.PbssImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'ResultsGV
        '
        Me.ResultsGV.AllowUserToAddRows = False
        Me.ResultsGV.AllowUserToDeleteRows = False
        Me.ResultsGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ResultsGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ResultsGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ResultsGV.ContextMenuStrip = Me.ResultsCMS
        Me.ResultsGV.Location = New System.Drawing.Point(8, 330)
        Me.ResultsGV.MultiSelect = False
        Me.ResultsGV.Name = "ResultsGV"
        Me.ResultsGV.ReadOnly = True
        Me.ResultsGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ResultsGV.Size = New System.Drawing.Size(836, 234)
        Me.ResultsGV.TabIndex = 7
        '
        'ResultsCMS
        '
        Me.ResultsCMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewHeroScreenshotsToolStripMenuItem})
        Me.ResultsCMS.Name = "ResultsCMS"
        Me.ResultsCMS.Size = New System.Drawing.Size(195, 26)
        '
        'ViewHeroScreenshotsToolStripMenuItem
        '
        Me.ViewHeroScreenshotsToolStripMenuItem.Name = "ViewHeroScreenshotsToolStripMenuItem"
        Me.ViewHeroScreenshotsToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ViewHeroScreenshotsToolStripMenuItem.Text = "View Hero Screenshots"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Server:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(11, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Hero Name:"
        '
        'SuspiciousCB
        '
        Me.SuspiciousCB.AutoSize = True
        Me.SuspiciousCB.BackColor = System.Drawing.Color.Transparent
        Me.SuspiciousCB.ForeColor = System.Drawing.Color.White
        Me.SuspiciousCB.Location = New System.Drawing.Point(14, 209)
        Me.SuspiciousCB.Name = "SuspiciousCB"
        Me.SuspiciousCB.Size = New System.Drawing.Size(77, 17)
        Me.SuspiciousCB.TabIndex = 11
        Me.SuspiciousCB.Text = "Suspicious"
        Me.SuspiciousCB.UseVisualStyleBackColor = False
        '
        'PinkCB
        '
        Me.PinkCB.AutoSize = True
        Me.PinkCB.BackColor = System.Drawing.Color.Transparent
        Me.PinkCB.ForeColor = System.Drawing.Color.White
        Me.PinkCB.Location = New System.Drawing.Point(14, 238)
        Me.PinkCB.Name = "PinkCB"
        Me.PinkCB.Size = New System.Drawing.Size(47, 17)
        Me.PinkCB.TabIndex = 12
        Me.PinkCB.Text = "Pink"
        Me.PinkCB.UseVisualStyleBackColor = False
        '
        'BlackCB
        '
        Me.BlackCB.AutoSize = True
        Me.BlackCB.BackColor = System.Drawing.Color.Transparent
        Me.BlackCB.ForeColor = System.Drawing.Color.White
        Me.BlackCB.Location = New System.Drawing.Point(91, 238)
        Me.BlackCB.Name = "BlackCB"
        Me.BlackCB.Size = New System.Drawing.Size(53, 17)
        Me.BlackCB.TabIndex = 13
        Me.BlackCB.Text = "Black"
        Me.BlackCB.UseVisualStyleBackColor = False
        '
        'CroppedCB
        '
        Me.CroppedCB.AutoSize = True
        Me.CroppedCB.BackColor = System.Drawing.Color.Transparent
        Me.CroppedCB.ForeColor = System.Drawing.Color.White
        Me.CroppedCB.Location = New System.Drawing.Point(91, 209)
        Me.CroppedCB.Name = "CroppedCB"
        Me.CroppedCB.Size = New System.Drawing.Size(66, 17)
        Me.CroppedCB.TabIndex = 14
        Me.CroppedCB.Text = "Cropped"
        Me.CroppedCB.UseVisualStyleBackColor = False
        '
        'FailedCB
        '
        Me.FailedCB.AutoSize = True
        Me.FailedCB.BackColor = System.Drawing.Color.Transparent
        Me.FailedCB.ForeColor = System.Drawing.Color.White
        Me.FailedCB.Location = New System.Drawing.Point(169, 209)
        Me.FailedCB.Name = "FailedCB"
        Me.FailedCB.Size = New System.Drawing.Size(54, 17)
        Me.FailedCB.TabIndex = 15
        Me.FailedCB.Text = "Failed"
        Me.FailedCB.UseVisualStyleBackColor = False
        '
        'HeroNameLAB
        '
        Me.HeroNameLAB.AutoSize = True
        Me.HeroNameLAB.BackColor = System.Drawing.Color.Transparent
        Me.HeroNameLAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeroNameLAB.ForeColor = System.Drawing.Color.White
        Me.HeroNameLAB.Location = New System.Drawing.Point(8, 7)
        Me.HeroNameLAB.Name = "HeroNameLAB"
        Me.HeroNameLAB.Size = New System.Drawing.Size(117, 25)
        Me.HeroNameLAB.TabIndex = 16
        Me.HeroNameLAB.Text = "Hero Name:"
        '
        'DateLAB
        '
        Me.DateLAB.AutoSize = True
        Me.DateLAB.BackColor = System.Drawing.Color.Transparent
        Me.DateLAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateLAB.ForeColor = System.Drawing.Color.White
        Me.DateLAB.Location = New System.Drawing.Point(10, 35)
        Me.DateLAB.Name = "DateLAB"
        Me.DateLAB.Size = New System.Drawing.Size(46, 17)
        Me.DateLAB.TabIndex = 17
        Me.DateLAB.Text = "Date: "
        '
        'OrgImgLAB
        '
        Me.OrgImgLAB.AutoSize = True
        Me.OrgImgLAB.BackColor = System.Drawing.Color.Transparent
        Me.OrgImgLAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OrgImgLAB.ForeColor = System.Drawing.Color.White
        Me.OrgImgLAB.Location = New System.Drawing.Point(10, 69)
        Me.OrgImgLAB.Name = "OrgImgLAB"
        Me.OrgImgLAB.Size = New System.Drawing.Size(103, 17)
        Me.OrgImgLAB.TabIndex = 18
        Me.OrgImgLAB.Text = "Original Image:"
        '
        'RenamedImgLAB
        '
        Me.RenamedImgLAB.AutoSize = True
        Me.RenamedImgLAB.BackColor = System.Drawing.Color.Transparent
        Me.RenamedImgLAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RenamedImgLAB.ForeColor = System.Drawing.Color.White
        Me.RenamedImgLAB.Location = New System.Drawing.Point(10, 86)
        Me.RenamedImgLAB.Name = "RenamedImgLAB"
        Me.RenamedImgLAB.Size = New System.Drawing.Size(115, 17)
        Me.RenamedImgLAB.TabIndex = 19
        Me.RenamedImgLAB.Text = "Renamed Image:"
        '
        'ServerLab
        '
        Me.ServerLab.AutoSize = True
        Me.ServerLab.BackColor = System.Drawing.Color.Transparent
        Me.ServerLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServerLab.ForeColor = System.Drawing.Color.White
        Me.ServerLab.Location = New System.Drawing.Point(10, 52)
        Me.ServerLab.Name = "ServerLab"
        Me.ServerLab.Size = New System.Drawing.Size(54, 17)
        Me.ServerLab.TabIndex = 20
        Me.ServerLab.Text = "Server:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 20)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Search Conditions"
        '
        'MaxRecNUM
        '
        Me.MaxRecNUM.Location = New System.Drawing.Point(123, 265)
        Me.MaxRecNUM.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.MaxRecNUM.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MaxRecNUM.Name = "MaxRecNUM"
        Me.MaxRecNUM.Size = New System.Drawing.Size(47, 20)
        Me.MaxRecNUM.TabIndex = 22
        Me.MaxRecNUM.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 267)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Max records to return:"
        '
        'ReturnedCntLAB
        '
        Me.ReturnedCntLAB.AutoSize = True
        Me.ReturnedCntLAB.BackColor = System.Drawing.Color.Transparent
        Me.ReturnedCntLAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReturnedCntLAB.ForeColor = System.Drawing.Color.White
        Me.ReturnedCntLAB.Location = New System.Drawing.Point(10, 304)
        Me.ReturnedCntLAB.Name = "ReturnedCntLAB"
        Me.ReturnedCntLAB.Size = New System.Drawing.Size(161, 20)
        Me.ReturnedCntLAB.TabIndex = 24
        Me.ReturnedCntLAB.Text = "Records Returned:"
        '
        'NormalCB
        '
        Me.NormalCB.AutoSize = True
        Me.NormalCB.BackColor = System.Drawing.Color.Transparent
        Me.NormalCB.ForeColor = System.Drawing.Color.White
        Me.NormalCB.Location = New System.Drawing.Point(169, 238)
        Me.NormalCB.Name = "NormalCB"
        Me.NormalCB.Size = New System.Drawing.Size(59, 17)
        Me.NormalCB.TabIndex = 25
        Me.NormalCB.Text = "Normal"
        Me.NormalCB.UseVisualStyleBackColor = False
        '
        'ResetBTN
        '
        Me.ResetBTN.BackColor = System.Drawing.Color.Transparent
        Me.ResetBTN.Location = New System.Drawing.Point(255, 262)
        Me.ResetBTN.Name = "ResetBTN"
        Me.ResetBTN.Size = New System.Drawing.Size(68, 23)
        Me.ResetBTN.TabIndex = 27
        Me.ResetBTN.Text = "Reset"
        Me.ResetBTN.UseVisualStyleBackColor = False
        '
        'CheatersCB
        '
        Me.CheatersCB.AutoSize = True
        Me.CheatersCB.BackColor = System.Drawing.Color.Transparent
        Me.CheatersCB.ForeColor = System.Drawing.Color.White
        Me.CheatersCB.Location = New System.Drawing.Point(238, 209)
        Me.CheatersCB.Name = "CheatersCB"
        Me.CheatersCB.Size = New System.Drawing.Size(68, 17)
        Me.CheatersCB.TabIndex = 28
        Me.CheatersCB.Text = "Cheaters"
        Me.CheatersCB.UseVisualStyleBackColor = False
        '
        'ViewPB
        '
        Me.ViewPB.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ViewPB.Location = New System.Drawing.Point(332, 10)
        Me.ViewPB.Name = "ViewPB"
        Me.ViewPB.Size = New System.Drawing.Size(512, 314)
        Me.ViewPB.TabIndex = 8
        Me.ViewPB.TabStop = False
        '
        'BGPanel
        '
        Me.BGPanel.BackColor = System.Drawing.Color.Black
        Me.BGPanel.Controls.Add(Me.ResultsGV)
        Me.BGPanel.Controls.Add(Me.CheatersCB)
        Me.BGPanel.Controls.Add(Me.LookupHeroNameTXT)
        Me.BGPanel.Controls.Add(Me.ResetBTN)
        Me.BGPanel.Controls.Add(Me.ServersCB)
        Me.BGPanel.Controls.Add(Me.NormalCB)
        Me.BGPanel.Controls.Add(Me.SearchBTN)
        Me.BGPanel.Controls.Add(Me.ReturnedCntLAB)
        Me.BGPanel.Controls.Add(Me.ViewPB)
        Me.BGPanel.Controls.Add(Me.Label4)
        Me.BGPanel.Controls.Add(Me.Label1)
        Me.BGPanel.Controls.Add(Me.MaxRecNUM)
        Me.BGPanel.Controls.Add(Me.Label2)
        Me.BGPanel.Controls.Add(Me.Label3)
        Me.BGPanel.Controls.Add(Me.SuspiciousCB)
        Me.BGPanel.Controls.Add(Me.ServerLab)
        Me.BGPanel.Controls.Add(Me.PinkCB)
        Me.BGPanel.Controls.Add(Me.RenamedImgLAB)
        Me.BGPanel.Controls.Add(Me.BlackCB)
        Me.BGPanel.Controls.Add(Me.OrgImgLAB)
        Me.BGPanel.Controls.Add(Me.CroppedCB)
        Me.BGPanel.Controls.Add(Me.DateLAB)
        Me.BGPanel.Controls.Add(Me.FailedCB)
        Me.BGPanel.Controls.Add(Me.HeroNameLAB)
        Me.BGPanel.Location = New System.Drawing.Point(15, 78)
        Me.BGPanel.Name = "BGPanel"
        Me.BGPanel.Size = New System.Drawing.Size(858, 578)
        Me.BGPanel.TabIndex = 29
        '
        'ExitPB
        '
        Me.ExitPB.Image = Global.RADAR.My.Resources.Resources.Very_Basic_Cancel_icon_24_d
        Me.ExitPB.Location = New System.Drawing.Point(880, 75)
        Me.ExitPB.Name = "ExitPB"
        Me.ExitPB.Size = New System.Drawing.Size(24, 24)
        Me.ExitPB.TabIndex = 30
        Me.ExitPB.TabStop = False
        '
        'MinimizePB
        '
        Me.MinimizePB.Image = Global.RADAR.My.Resources.Resources.Very_Basic_Download_icon_d
        Me.MinimizePB.Location = New System.Drawing.Point(880, 104)
        Me.MinimizePB.Name = "MinimizePB"
        Me.MinimizePB.Size = New System.Drawing.Size(24, 24)
        Me.MinimizePB.TabIndex = 31
        Me.MinimizePB.TabStop = False
        '
        'LookupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.RADAR.My.Resources.Resources.lookupbg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(918, 669)
        Me.Controls.Add(Me.MinimizePB)
        Me.Controls.Add(Me.ExitPB)
        Me.Controls.Add(Me.BGPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LookupForm"
        Me.Text = "Screenshot Lookup"
        CType(Me.ResultsGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResultsCMS.ResumeLayout(False)
        CType(Me.MaxRecNUM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BGPanel.ResumeLayout(False)
        Me.BGPanel.PerformLayout()
        CType(Me.ExitPB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinimizePB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LookupHeroNameTXT As System.Windows.Forms.TextBox
    Friend WithEvents ServersCB As System.Windows.Forms.ComboBox
    Friend WithEvents SearchBTN As System.Windows.Forms.Button
    Friend WithEvents PbssImageList As System.Windows.Forms.ImageList
    Friend WithEvents ResultsGV As System.Windows.Forms.DataGridView
    Friend WithEvents ViewPB As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SuspiciousCB As System.Windows.Forms.CheckBox
    Friend WithEvents PinkCB As System.Windows.Forms.CheckBox
    Friend WithEvents BlackCB As System.Windows.Forms.CheckBox
    Friend WithEvents CroppedCB As System.Windows.Forms.CheckBox
    Friend WithEvents FailedCB As System.Windows.Forms.CheckBox
    Friend WithEvents HeroNameLAB As System.Windows.Forms.Label
    Friend WithEvents DateLAB As System.Windows.Forms.Label
    Friend WithEvents OrgImgLAB As System.Windows.Forms.Label
    Friend WithEvents RenamedImgLAB As System.Windows.Forms.Label
    Friend WithEvents ServerLab As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MaxRecNUM As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ReturnedCntLAB As System.Windows.Forms.Label
    Friend WithEvents NormalCB As System.Windows.Forms.CheckBox
    Friend WithEvents ResetBTN As System.Windows.Forms.Button
    Friend WithEvents CheatersCB As System.Windows.Forms.CheckBox
    Friend WithEvents BGPanel As System.Windows.Forms.Panel
    Friend WithEvents ExitPB As System.Windows.Forms.PictureBox
    Friend WithEvents MinimizePB As System.Windows.Forms.PictureBox
    Friend WithEvents ResultsCMS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewHeroScreenshotsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
