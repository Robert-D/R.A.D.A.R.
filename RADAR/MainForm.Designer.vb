<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SaveSettingsBTN = New System.Windows.Forms.Button()
        Me.StatusLAB = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ToggleScanBTN = New System.Windows.Forms.Button()
        Me.ScanPBSSTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ScanPBSSBGW = New System.ComponentModel.BackgroundWorker()
        Me.ScanPBSSNotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NewsTab = New System.Windows.Forms.TabPage()
        Me.NewsBrowser = New System.Windows.Forms.WebBrowser()
        Me.LogTab = New System.Windows.Forms.TabPage()
        Me.LogRTB = New System.Windows.Forms.RichTextBox()
        Me.StatsTab = New System.Windows.Forms.TabPage()
        Me.HistoricalBreakdownPieChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RefreshStatsBTN = New System.Windows.Forms.Button()
        Me.StoredBreakdownPieChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ColorFilterTab = New System.Windows.Forms.TabPage()
        Me.RescanBTN = New System.Windows.Forms.Button()
        Me.ColorFilterAddColorBTN = New System.Windows.Forms.Button()
        Me.ColorFilterBlueNUD = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ColorFilterGreenNUD = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ColorFilterRedNUD = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ThresholdEndNum = New System.Windows.Forms.NumericUpDown()
        Me.ThresholdStartNum = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.DeleteColorFilterRowBTN = New System.Windows.Forms.Button()
        Me.ColorFilterGridView = New System.Windows.Forms.DataGridView()
        Me.Sample = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SettingsTab = New System.Windows.Forms.TabPage()
        Me.SettingsTabs = New System.Windows.Forms.TabControl()
        Me.ServersTab = New System.Windows.Forms.TabPage()
        Me.DeleteServerBTN = New System.Windows.Forms.Button()
        Me.AddServerBTN = New System.Windows.Forms.Button()
        Me.ServersGV = New System.Windows.Forms.DataGridView()
        Me.AddServersGB = New System.Windows.Forms.GroupBox()
        Me.ServerRconPortNUM = New System.Windows.Forms.NumericUpDown()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ServerRconPassTXT = New System.Windows.Forms.TextBox()
        Me.ServerIPTXT = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ServerNameTXT = New System.Windows.Forms.TextBox()
        Me.AuthGB = New System.Windows.Forms.GroupBox()
        Me.PbsvssAuthReqCB = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PbsvssAuthPassTXT = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PbsvssAuthUserTXT = New System.Windows.Forms.TextBox()
        Me.PbsvssURLTXT = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GeneralTab = New System.Windows.Forms.TabPage()
        Me.ShareGB = New System.Windows.Forms.GroupBox()
        Me.PostSSCB = New System.Windows.Forms.CheckBox()
        Me.PostStatsCB = New System.Windows.Forms.CheckBox()
        Me.PurgeBTN = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DeleteSuspiciousCB = New System.Windows.Forms.CheckBox()
        Me.DeleteCheatersCB = New System.Windows.Forms.CheckBox()
        Me.PbssStoreCount = New System.Windows.Forms.NumericUpDown()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ScanSettingsGB = New System.Windows.Forms.GroupBox()
        Me.RestoreWindowCB = New System.Windows.Forms.CheckBox()
        Me.PlaySoundCB = New System.Windows.Forms.CheckBox()
        Me.ScanAutoCB = New System.Windows.Forms.CheckBox()
        Me.PBSSScanCount = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PBSSTimeCount = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.EmailTab = New System.Windows.Forms.TabPage()
        Me.EmailGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.SMTPSSLReqCB = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SMTPSendToTXT = New System.Windows.Forms.TextBox()
        Me.SendTestEmailBTN = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SMTPServerTXT = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SMTPPassTXT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SMTPPortTXT = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SMTPUserTXT = New System.Windows.Forms.TextBox()
        Me.EnableEmailCHK = New System.Windows.Forms.CheckBox()
        Me.WebTab = New System.Windows.Forms.TabPage()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.EnableWebServerCHK = New System.Windows.Forms.CheckBox()
        Me.WebServerSettingsGB = New System.Windows.Forms.GroupBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.WebPublicLink = New System.Windows.Forms.LinkLabel()
        Me.WebPrivateLink = New System.Windows.Forms.LinkLabel()
        Me.WebBannerTXT = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.WebDisplayLimitNUM = New System.Windows.Forms.NumericUpDown()
        Me.WebPortNUM = New System.Windows.Forms.NumericUpDown()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.WebPassTXT = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.SuspiciousTab = New System.Windows.Forms.TabPage()
        Me.DismissDurationCB = New System.Windows.Forms.ComboBox()
        Me.SusImageInfoLAB = New System.Windows.Forms.Label()
        Me.SusImgLAB = New System.Windows.Forms.Label()
        Me.DismissPBSSBTN = New System.Windows.Forms.Button()
        Me.NextImgBTN = New System.Windows.Forms.Button()
        Me.PrevImgBTN = New System.Windows.Forms.Button()
        Me.ReviewPB = New System.Windows.Forms.PictureBox()
        Me.MainTabMenu = New System.Windows.Forms.TabControl()
        Me.AltAccountTAB = New System.Windows.Forms.TabPage()
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.AltShowDateCB = New System.Windows.Forms.CheckBox()
        Me.AltGV = New System.Windows.Forms.DataGridView()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.AltHeroNameTXT = New System.Windows.Forms.TextBox()
        Me.AltProcessLogBTN = New System.Windows.Forms.Button()
        Me.AltSearchBTN = New System.Windows.Forms.Button()
        Me.LookupFormPB = New System.Windows.Forms.PictureBox()
        Me.FormOpenBGW = New System.ComponentModel.BackgroundWorker()
        Me.BGPanel = New System.Windows.Forms.Panel()
        Me.ReportGGCPB = New System.Windows.Forms.PictureBox()
        Me.OpenAppFolderPB = New System.Windows.Forms.PictureBox()
        Me.ExitPB = New System.Windows.Forms.PictureBox()
        Me.MinimizePB = New System.Windows.Forms.PictureBox()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.WebUpdateBGW = New System.ComponentModel.BackgroundWorker()
        Me.WebUpdateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RadarLinkPB = New System.Windows.Forms.PictureBox()
        Me.AltAccountsBGW = New System.ComponentModel.BackgroundWorker()
        Me.NewsTab.SuspendLayout()
        Me.LogTab.SuspendLayout()
        Me.StatsTab.SuspendLayout()
        CType(Me.HistoricalBreakdownPieChart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StoredBreakdownPieChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ColorFilterTab.SuspendLayout()
        CType(Me.ColorFilterBlueNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorFilterGreenNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorFilterRedNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ThresholdEndNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ThresholdStartNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorFilterGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SettingsTab.SuspendLayout()
        Me.SettingsTabs.SuspendLayout()
        Me.ServersTab.SuspendLayout()
        CType(Me.ServersGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AddServersGB.SuspendLayout()
        CType(Me.ServerRconPortNUM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AuthGB.SuspendLayout()
        Me.GeneralTab.SuspendLayout()
        Me.ShareGB.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PbssStoreCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ScanSettingsGB.SuspendLayout()
        CType(Me.PBSSScanCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBSSTimeCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmailTab.SuspendLayout()
        Me.EmailGroupBox.SuspendLayout()
        Me.WebTab.SuspendLayout()
        Me.WebServerSettingsGB.SuspendLayout()
        CType(Me.WebDisplayLimitNUM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WebPortNUM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspiciousTab.SuspendLayout()
        CType(Me.ReviewPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainTabMenu.SuspendLayout()
        Me.AltAccountTAB.SuspendLayout()
        CType(Me.AltGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookupFormPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BGPanel.SuspendLayout()
        CType(Me.ReportGGCPB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OpenAppFolderPB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExitPB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinimizePB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadarLinkPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SaveSettingsBTN
        '
        Me.SaveSettingsBTN.Location = New System.Drawing.Point(457, 477)
        Me.SaveSettingsBTN.Name = "SaveSettingsBTN"
        Me.SaveSettingsBTN.Size = New System.Drawing.Size(103, 23)
        Me.SaveSettingsBTN.TabIndex = 25
        Me.SaveSettingsBTN.Text = "Save Settings"
        Me.SaveSettingsBTN.UseVisualStyleBackColor = True
        '
        'StatusLAB
        '
        Me.StatusLAB.AutoSize = True
        Me.StatusLAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLAB.ForeColor = System.Drawing.Color.White
        Me.StatusLAB.Location = New System.Drawing.Point(9, 425)
        Me.StatusLAB.Name = "StatusLAB"
        Me.StatusLAB.Size = New System.Drawing.Size(153, 20)
        Me.StatusLAB.TabIndex = 8
        Me.StatusLAB.Text = "Status: Not Running"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 448)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(547, 23)
        Me.ProgressBar1.TabIndex = 7
        '
        'ToggleScanBTN
        '
        Me.ToggleScanBTN.Location = New System.Drawing.Point(13, 477)
        Me.ToggleScanBTN.Name = "ToggleScanBTN"
        Me.ToggleScanBTN.Size = New System.Drawing.Size(122, 23)
        Me.ToggleScanBTN.TabIndex = 6
        Me.ToggleScanBTN.Text = "Enable Scanning"
        Me.ToggleScanBTN.UseVisualStyleBackColor = True
        '
        'ScanPBSSTimer
        '
        Me.ScanPBSSTimer.Interval = 300000
        '
        'ScanPBSSBGW
        '
        Me.ScanPBSSBGW.WorkerReportsProgress = True
        '
        'ScanPBSSNotifyIcon
        '
        Me.ScanPBSSNotifyIcon.Icon = CType(resources.GetObject("ScanPBSSNotifyIcon.Icon"), System.Drawing.Icon)
        Me.ScanPBSSNotifyIcon.Text = "R.A.D.A.R - PBSS Scanner" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "By Hoof~Arted"
        Me.ScanPBSSNotifyIcon.Visible = True
        '
        'NewsTab
        '
        Me.NewsTab.Controls.Add(Me.NewsBrowser)
        Me.NewsTab.Location = New System.Drawing.Point(4, 22)
        Me.NewsTab.Name = "NewsTab"
        Me.NewsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.NewsTab.Size = New System.Drawing.Size(543, 384)
        Me.NewsTab.TabIndex = 6
        Me.NewsTab.Text = "News"
        Me.NewsTab.UseVisualStyleBackColor = True
        '
        'NewsBrowser
        '
        Me.NewsBrowser.AllowWebBrowserDrop = False
        Me.NewsBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NewsBrowser.IsWebBrowserContextMenuEnabled = False
        Me.NewsBrowser.Location = New System.Drawing.Point(3, 3)
        Me.NewsBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.NewsBrowser.Name = "NewsBrowser"
        Me.NewsBrowser.Size = New System.Drawing.Size(537, 378)
        Me.NewsBrowser.TabIndex = 0
        '
        'LogTab
        '
        Me.LogTab.Controls.Add(Me.LogRTB)
        Me.LogTab.Location = New System.Drawing.Point(4, 22)
        Me.LogTab.Name = "LogTab"
        Me.LogTab.Padding = New System.Windows.Forms.Padding(3)
        Me.LogTab.Size = New System.Drawing.Size(543, 384)
        Me.LogTab.TabIndex = 2
        Me.LogTab.Text = "Log"
        '
        'LogRTB
        '
        Me.LogRTB.BackColor = System.Drawing.SystemColors.Control
        Me.LogRTB.Location = New System.Drawing.Point(6, 6)
        Me.LogRTB.Name = "LogRTB"
        Me.LogRTB.Size = New System.Drawing.Size(531, 372)
        Me.LogRTB.TabIndex = 1
        Me.LogRTB.Text = ""
        '
        'StatsTab
        '
        Me.StatsTab.AutoScroll = True
        Me.StatsTab.Controls.Add(Me.HistoricalBreakdownPieChart)
        Me.StatsTab.Controls.Add(Me.RefreshStatsBTN)
        Me.StatsTab.Controls.Add(Me.StoredBreakdownPieChart)
        Me.StatsTab.Location = New System.Drawing.Point(4, 22)
        Me.StatsTab.Name = "StatsTab"
        Me.StatsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.StatsTab.Size = New System.Drawing.Size(543, 384)
        Me.StatsTab.TabIndex = 3
        Me.StatsTab.Text = "Stats"
        Me.StatsTab.UseVisualStyleBackColor = True
        '
        'HistoricalBreakdownPieChart
        '
        ChartArea1.BackColor = System.Drawing.Color.Chartreuse
        ChartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center
        ChartArea1.Name = "ChartArea1"
        Me.HistoricalBreakdownPieChart.ChartAreas.Add(ChartArea1)
        Me.HistoricalBreakdownPieChart.Location = New System.Drawing.Point(3, 350)
        Me.HistoricalBreakdownPieChart.Name = "HistoricalBreakdownPieChart"
        Me.HistoricalBreakdownPieChart.Size = New System.Drawing.Size(514, 343)
        Me.HistoricalBreakdownPieChart.TabIndex = 15
        Me.HistoricalBreakdownPieChart.Text = "Historical Screenshot Breakdown"
        Title1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Title1.Name = "Title1"
        Title1.Text = "Historical Screenshot Breakdown"
        Me.HistoricalBreakdownPieChart.Titles.Add(Title1)
        '
        'RefreshStatsBTN
        '
        Me.RefreshStatsBTN.Location = New System.Drawing.Point(412, 13)
        Me.RefreshStatsBTN.Name = "RefreshStatsBTN"
        Me.RefreshStatsBTN.Size = New System.Drawing.Size(108, 23)
        Me.RefreshStatsBTN.TabIndex = 0
        Me.RefreshStatsBTN.Text = "Refresh Stats"
        Me.RefreshStatsBTN.UseVisualStyleBackColor = True
        '
        'StoredBreakdownPieChart
        '
        Me.StoredBreakdownPieChart.BackColor = System.Drawing.Color.Transparent
        Me.StoredBreakdownPieChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center
        Me.StoredBreakdownPieChart.BackImageTransparentColor = System.Drawing.Color.White
        Me.StoredBreakdownPieChart.BackSecondaryColor = System.Drawing.Color.White
        ChartArea2.BackColor = System.Drawing.Color.CornflowerBlue
        ChartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center
        ChartArea2.Name = "ChartArea1"
        Me.StoredBreakdownPieChart.ChartAreas.Add(ChartArea2)
        Me.StoredBreakdownPieChart.Location = New System.Drawing.Point(6, 1)
        Me.StoredBreakdownPieChart.Name = "StoredBreakdownPieChart"
        Me.StoredBreakdownPieChart.Size = New System.Drawing.Size(514, 343)
        Me.StoredBreakdownPieChart.TabIndex = 14
        Me.StoredBreakdownPieChart.Text = "Stored Screenshot Breakdown"
        Title2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Title2.Name = "Title1"
        Title2.Text = "Stored Screenshot Breakdown"
        Me.StoredBreakdownPieChart.Titles.Add(Title2)
        '
        'ColorFilterTab
        '
        Me.ColorFilterTab.Controls.Add(Me.RescanBTN)
        Me.ColorFilterTab.Controls.Add(Me.ColorFilterAddColorBTN)
        Me.ColorFilterTab.Controls.Add(Me.ColorFilterBlueNUD)
        Me.ColorFilterTab.Controls.Add(Me.Label17)
        Me.ColorFilterTab.Controls.Add(Me.Label16)
        Me.ColorFilterTab.Controls.Add(Me.ColorFilterGreenNUD)
        Me.ColorFilterTab.Controls.Add(Me.Label14)
        Me.ColorFilterTab.Controls.Add(Me.ColorFilterRedNUD)
        Me.ColorFilterTab.Controls.Add(Me.Label11)
        Me.ColorFilterTab.Controls.Add(Me.ThresholdEndNum)
        Me.ColorFilterTab.Controls.Add(Me.ThresholdStartNum)
        Me.ColorFilterTab.Controls.Add(Me.Label10)
        Me.ColorFilterTab.Controls.Add(Me.RichTextBox1)
        Me.ColorFilterTab.Controls.Add(Me.DeleteColorFilterRowBTN)
        Me.ColorFilterTab.Controls.Add(Me.ColorFilterGridView)
        Me.ColorFilterTab.Location = New System.Drawing.Point(4, 22)
        Me.ColorFilterTab.Name = "ColorFilterTab"
        Me.ColorFilterTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ColorFilterTab.Size = New System.Drawing.Size(543, 384)
        Me.ColorFilterTab.TabIndex = 4
        Me.ColorFilterTab.Text = "Color Filters"
        Me.ColorFilterTab.UseVisualStyleBackColor = True
        '
        'RescanBTN
        '
        Me.RescanBTN.Location = New System.Drawing.Point(453, 87)
        Me.RescanBTN.Name = "RescanBTN"
        Me.RescanBTN.Size = New System.Drawing.Size(81, 23)
        Me.RescanBTN.TabIndex = 15
        Me.RescanBTN.Text = "Rescan All"
        Me.RescanBTN.UseVisualStyleBackColor = True
        '
        'ColorFilterAddColorBTN
        '
        Me.ColorFilterAddColorBTN.Location = New System.Drawing.Point(292, 355)
        Me.ColorFilterAddColorBTN.Name = "ColorFilterAddColorBTN"
        Me.ColorFilterAddColorBTN.Size = New System.Drawing.Size(72, 23)
        Me.ColorFilterAddColorBTN.TabIndex = 14
        Me.ColorFilterAddColorBTN.Text = "Add Color"
        Me.ColorFilterAddColorBTN.UseVisualStyleBackColor = True
        '
        'ColorFilterBlueNUD
        '
        Me.ColorFilterBlueNUD.Location = New System.Drawing.Point(235, 358)
        Me.ColorFilterBlueNUD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.ColorFilterBlueNUD.Name = "ColorFilterBlueNUD"
        Me.ColorFilterBlueNUD.Size = New System.Drawing.Size(51, 20)
        Me.ColorFilterBlueNUD.TabIndex = 13
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(198, 360)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 13)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "Blue:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(96, 360)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Green:"
        '
        'ColorFilterGreenNUD
        '
        Me.ColorFilterGreenNUD.Location = New System.Drawing.Point(141, 358)
        Me.ColorFilterGreenNUD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.ColorFilterGreenNUD.Name = "ColorFilterGreenNUD"
        Me.ColorFilterGreenNUD.Size = New System.Drawing.Size(51, 20)
        Me.ColorFilterGreenNUD.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 360)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 13)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Red:"
        '
        'ColorFilterRedNUD
        '
        Me.ColorFilterRedNUD.Location = New System.Drawing.Point(39, 358)
        Me.ColorFilterRedNUD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.ColorFilterRedNUD.Name = "ColorFilterRedNUD"
        Me.ColorFilterRedNUD.Size = New System.Drawing.Size(51, 20)
        Me.ColorFilterRedNUD.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(187, 89)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "to"
        '
        'ThresholdEndNum
        '
        Me.ThresholdEndNum.Location = New System.Drawing.Point(207, 87)
        Me.ThresholdEndNum.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.ThresholdEndNum.Name = "ThresholdEndNum"
        Me.ThresholdEndNum.Size = New System.Drawing.Size(60, 20)
        Me.ThresholdEndNum.TabIndex = 6
        Me.ThresholdEndNum.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'ThresholdStartNum
        '
        Me.ThresholdStartNum.Location = New System.Drawing.Point(123, 87)
        Me.ThresholdStartNum.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.ThresholdStartNum.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ThresholdStartNum.Name = "ThresholdStartNum"
        Me.ThresholdStartNum.Size = New System.Drawing.Size(60, 20)
        Me.ThresholdStartNum.TabIndex = 5
        Me.ThresholdStartNum.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 89)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Alert pixel count range:"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox1.Location = New System.Drawing.Point(4, 7)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(533, 75)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'DeleteColorFilterRowBTN
        '
        Me.DeleteColorFilterRowBTN.Location = New System.Drawing.Point(412, 355)
        Me.DeleteColorFilterRowBTN.Name = "DeleteColorFilterRowBTN"
        Me.DeleteColorFilterRowBTN.Size = New System.Drawing.Size(125, 23)
        Me.DeleteColorFilterRowBTN.TabIndex = 2
        Me.DeleteColorFilterRowBTN.Text = "Delete Selected Row"
        Me.DeleteColorFilterRowBTN.UseVisualStyleBackColor = True
        '
        'ColorFilterGridView
        '
        Me.ColorFilterGridView.AllowUserToAddRows = False
        Me.ColorFilterGridView.AllowUserToResizeRows = False
        Me.ColorFilterGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ColorFilterGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.ColorFilterGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sample})
        Me.ColorFilterGridView.Location = New System.Drawing.Point(6, 120)
        Me.ColorFilterGridView.Name = "ColorFilterGridView"
        Me.ColorFilterGridView.Size = New System.Drawing.Size(531, 229)
        Me.ColorFilterGridView.TabIndex = 0
        '
        'Sample
        '
        Me.Sample.HeaderText = "Sample"
        Me.Sample.Name = "Sample"
        Me.Sample.ReadOnly = True
        '
        'SettingsTab
        '
        Me.SettingsTab.Controls.Add(Me.SettingsTabs)
        Me.SettingsTab.Location = New System.Drawing.Point(4, 22)
        Me.SettingsTab.Name = "SettingsTab"
        Me.SettingsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.SettingsTab.Size = New System.Drawing.Size(543, 384)
        Me.SettingsTab.TabIndex = 0
        Me.SettingsTab.Text = "Settings"
        Me.SettingsTab.UseVisualStyleBackColor = True
        '
        'SettingsTabs
        '
        Me.SettingsTabs.Controls.Add(Me.ServersTab)
        Me.SettingsTabs.Controls.Add(Me.GeneralTab)
        Me.SettingsTabs.Controls.Add(Me.EmailTab)
        Me.SettingsTabs.Controls.Add(Me.WebTab)
        Me.SettingsTabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SettingsTabs.Location = New System.Drawing.Point(3, 3)
        Me.SettingsTabs.Multiline = True
        Me.SettingsTabs.Name = "SettingsTabs"
        Me.SettingsTabs.SelectedIndex = 0
        Me.SettingsTabs.Size = New System.Drawing.Size(537, 378)
        Me.SettingsTabs.TabIndex = 32
        '
        'ServersTab
        '
        Me.ServersTab.Controls.Add(Me.DeleteServerBTN)
        Me.ServersTab.Controls.Add(Me.AddServerBTN)
        Me.ServersTab.Controls.Add(Me.ServersGV)
        Me.ServersTab.Controls.Add(Me.AddServersGB)
        Me.ServersTab.Location = New System.Drawing.Point(4, 22)
        Me.ServersTab.Name = "ServersTab"
        Me.ServersTab.Size = New System.Drawing.Size(529, 352)
        Me.ServersTab.TabIndex = 2
        Me.ServersTab.Text = "Servers"
        Me.ServersTab.UseVisualStyleBackColor = True
        '
        'DeleteServerBTN
        '
        Me.DeleteServerBTN.Location = New System.Drawing.Point(364, 196)
        Me.DeleteServerBTN.Name = "DeleteServerBTN"
        Me.DeleteServerBTN.Size = New System.Drawing.Size(152, 23)
        Me.DeleteServerBTN.TabIndex = 34
        Me.DeleteServerBTN.Text = "Delete Selected Server"
        Me.DeleteServerBTN.UseVisualStyleBackColor = True
        '
        'AddServerBTN
        '
        Me.AddServerBTN.Location = New System.Drawing.Point(6, 196)
        Me.AddServerBTN.Name = "AddServerBTN"
        Me.AddServerBTN.Size = New System.Drawing.Size(96, 23)
        Me.AddServerBTN.TabIndex = 36
        Me.AddServerBTN.Text = "Add Server"
        Me.AddServerBTN.UseVisualStyleBackColor = True
        '
        'ServersGV
        '
        Me.ServersGV.AllowUserToAddRows = False
        Me.ServersGV.AllowUserToDeleteRows = False
        Me.ServersGV.AllowUserToOrderColumns = True
        Me.ServersGV.AllowUserToResizeRows = False
        Me.ServersGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ServersGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ServersGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ServersGV.DefaultCellStyle = DataGridViewCellStyle2
        Me.ServersGV.Location = New System.Drawing.Point(7, 225)
        Me.ServersGV.MultiSelect = False
        Me.ServersGV.Name = "ServersGV"
        Me.ServersGV.ReadOnly = True
        Me.ServersGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ServersGV.Size = New System.Drawing.Size(509, 115)
        Me.ServersGV.TabIndex = 33
        '
        'AddServersGB
        '
        Me.AddServersGB.Controls.Add(Me.ServerRconPortNUM)
        Me.AddServersGB.Controls.Add(Me.Label24)
        Me.AddServersGB.Controls.Add(Me.Label23)
        Me.AddServersGB.Controls.Add(Me.Label22)
        Me.AddServersGB.Controls.Add(Me.ServerRconPassTXT)
        Me.AddServersGB.Controls.Add(Me.ServerIPTXT)
        Me.AddServersGB.Controls.Add(Me.Label21)
        Me.AddServersGB.Controls.Add(Me.ServerNameTXT)
        Me.AddServersGB.Controls.Add(Me.AuthGB)
        Me.AddServersGB.Controls.Add(Me.PbsvssURLTXT)
        Me.AddServersGB.Controls.Add(Me.Label12)
        Me.AddServersGB.Location = New System.Drawing.Point(7, 3)
        Me.AddServersGB.Name = "AddServersGB"
        Me.AddServersGB.Size = New System.Drawing.Size(509, 187)
        Me.AddServersGB.TabIndex = 32
        Me.AddServersGB.TabStop = False
        Me.AddServersGB.Text = "Add a Server"
        '
        'ServerRconPortNUM
        '
        Me.ServerRconPortNUM.Location = New System.Drawing.Point(370, 45)
        Me.ServerRconPortNUM.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.ServerRconPortNUM.Name = "ServerRconPortNUM"
        Me.ServerRconPortNUM.ReadOnly = True
        Me.ServerRconPortNUM.Size = New System.Drawing.Size(70, 20)
        Me.ServerRconPortNUM.TabIndex = 37
        Me.ServerRconPortNUM.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 78)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(89, 13)
        Me.Label24.TabIndex = 35
        Me.Label24.Text = "Pbsvss.htm URL:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(303, 48)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(58, 13)
        Me.Label23.TabIndex = 34
        Me.Label23.Text = "Rcon Port:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 48)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 13)
        Me.Label22.TabIndex = 33
        Me.Label22.Text = "Rcon Pass:"
        '
        'ServerRconPassTXT
        '
        Me.ServerRconPassTXT.Location = New System.Drawing.Point(101, 45)
        Me.ServerRconPassTXT.Name = "ServerRconPassTXT"
        Me.ServerRconPassTXT.ReadOnly = True
        Me.ServerRconPassTXT.Size = New System.Drawing.Size(88, 20)
        Me.ServerRconPassTXT.TabIndex = 31
        '
        'ServerIPTXT
        '
        Me.ServerIPTXT.Location = New System.Drawing.Point(370, 19)
        Me.ServerIPTXT.Name = "ServerIPTXT"
        Me.ServerIPTXT.ReadOnly = True
        Me.ServerIPTXT.Size = New System.Drawing.Size(125, 20)
        Me.ServerIPTXT.TabIndex = 30
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(72, 13)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = "Server Name:"
        '
        'ServerNameTXT
        '
        Me.ServerNameTXT.Location = New System.Drawing.Point(101, 19)
        Me.ServerNameTXT.Name = "ServerNameTXT"
        Me.ServerNameTXT.Size = New System.Drawing.Size(146, 20)
        Me.ServerNameTXT.TabIndex = 28
        '
        'AuthGB
        '
        Me.AuthGB.Controls.Add(Me.PbsvssAuthReqCB)
        Me.AuthGB.Controls.Add(Me.Label13)
        Me.AuthGB.Controls.Add(Me.PbsvssAuthPassTXT)
        Me.AuthGB.Controls.Add(Me.Label15)
        Me.AuthGB.Controls.Add(Me.PbsvssAuthUserTXT)
        Me.AuthGB.Location = New System.Drawing.Point(9, 97)
        Me.AuthGB.Name = "AuthGB"
        Me.AuthGB.Size = New System.Drawing.Size(486, 81)
        Me.AuthGB.TabIndex = 27
        Me.AuthGB.TabStop = False
        Me.AuthGB.Text = "Authentication (Multiplay/FTP)"
        '
        'PbsvssAuthReqCB
        '
        Me.PbsvssAuthReqCB.AutoSize = True
        Me.PbsvssAuthReqCB.Location = New System.Drawing.Point(6, 24)
        Me.PbsvssAuthReqCB.Name = "PbsvssAuthReqCB"
        Me.PbsvssAuthReqCB.Size = New System.Drawing.Size(183, 17)
        Me.PbsvssAuthReqCB.TabIndex = 32
        Me.PbsvssAuthReqCB.Text = "My server required authentication"
        Me.PbsvssAuthReqCB.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(256, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Password:"
        '
        'PbsvssAuthPassTXT
        '
        Me.PbsvssAuthPassTXT.Location = New System.Drawing.Point(333, 50)
        Me.PbsvssAuthPassTXT.Name = "PbsvssAuthPassTXT"
        Me.PbsvssAuthPassTXT.Size = New System.Drawing.Size(147, 20)
        Me.PbsvssAuthPassTXT.TabIndex = 30
        Me.PbsvssAuthPassTXT.UseSystemPasswordChar = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Username:"
        '
        'PbsvssAuthUserTXT
        '
        Me.PbsvssAuthUserTXT.Location = New System.Drawing.Point(67, 50)
        Me.PbsvssAuthUserTXT.Name = "PbsvssAuthUserTXT"
        Me.PbsvssAuthUserTXT.Size = New System.Drawing.Size(147, 20)
        Me.PbsvssAuthUserTXT.TabIndex = 27
        '
        'PbsvssURLTXT
        '
        Me.PbsvssURLTXT.Location = New System.Drawing.Point(101, 71)
        Me.PbsvssURLTXT.Name = "PbsvssURLTXT"
        Me.PbsvssURLTXT.Size = New System.Drawing.Size(394, 20)
        Me.PbsvssURLTXT.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(303, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "IP Address:"
        '
        'GeneralTab
        '
        Me.GeneralTab.AutoScroll = True
        Me.GeneralTab.Controls.Add(Me.ShareGB)
        Me.GeneralTab.Controls.Add(Me.PurgeBTN)
        Me.GeneralTab.Controls.Add(Me.GroupBox1)
        Me.GeneralTab.Controls.Add(Me.ScanSettingsGB)
        Me.GeneralTab.Location = New System.Drawing.Point(4, 22)
        Me.GeneralTab.Name = "GeneralTab"
        Me.GeneralTab.Padding = New System.Windows.Forms.Padding(3)
        Me.GeneralTab.Size = New System.Drawing.Size(529, 352)
        Me.GeneralTab.TabIndex = 1
        Me.GeneralTab.Text = "General"
        Me.GeneralTab.UseVisualStyleBackColor = True
        '
        'ShareGB
        '
        Me.ShareGB.Controls.Add(Me.PostSSCB)
        Me.ShareGB.Controls.Add(Me.PostStatsCB)
        Me.ShareGB.Location = New System.Drawing.Point(7, 241)
        Me.ShareGB.Name = "ShareGB"
        Me.ShareGB.Size = New System.Drawing.Size(496, 68)
        Me.ShareGB.TabIndex = 43
        Me.ShareGB.TabStop = False
        Me.ShareGB.Text = "Share Settings"
        '
        'PostSSCB
        '
        Me.PostSSCB.AutoSize = True
        Me.PostSSCB.Location = New System.Drawing.Point(7, 42)
        Me.PostSSCB.Name = "PostSSCB"
        Me.PostSSCB.Size = New System.Drawing.Size(321, 17)
        Me.PostSSCB.TabIndex = 42
        Me.PostSSCB.Text = "Post your ""Marked Cheater"" screenshots to www.pb-radar.net."
        Me.PostSSCB.UseVisualStyleBackColor = True
        '
        'PostStatsCB
        '
        Me.PostStatsCB.AutoSize = True
        Me.PostStatsCB.Location = New System.Drawing.Point(7, 19)
        Me.PostStatsCB.Name = "PostStatsCB"
        Me.PostStatsCB.Size = New System.Drawing.Size(261, 17)
        Me.PostStatsCB.TabIndex = 39
        Me.PostStatsCB.Text = "Post your scanning statistics to www.pb-radar.net."
        Me.PostStatsCB.UseVisualStyleBackColor = True
        '
        'PurgeBTN
        '
        Me.PurgeBTN.Location = New System.Drawing.Point(182, 315)
        Me.PurgeBTN.Name = "PurgeBTN"
        Me.PurgeBTN.Size = New System.Drawing.Size(153, 23)
        Me.PurgeBTN.TabIndex = 43
        Me.PurgeBTN.Text = "Reset To Default"
        Me.PurgeBTN.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DeleteSuspiciousCB)
        Me.GroupBox1.Controls.Add(Me.DeleteCheatersCB)
        Me.GroupBox1.Controls.Add(Me.PbssStoreCount)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 135)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 100)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Maintenance/Cleanup"
        '
        'DeleteSuspiciousCB
        '
        Me.DeleteSuspiciousCB.AutoSize = True
        Me.DeleteSuspiciousCB.Location = New System.Drawing.Point(7, 72)
        Me.DeleteSuspiciousCB.Name = "DeleteSuspiciousCB"
        Me.DeleteSuspiciousCB.Size = New System.Drawing.Size(204, 17)
        Me.DeleteSuspiciousCB.TabIndex = 42
        Me.DeleteSuspiciousCB.Text = "Don't delete 'Suspicious' screenshots."
        Me.DeleteSuspiciousCB.UseVisualStyleBackColor = True
        '
        'DeleteCheatersCB
        '
        Me.DeleteCheatersCB.AutoSize = True
        Me.DeleteCheatersCB.Location = New System.Drawing.Point(7, 49)
        Me.DeleteCheatersCB.Name = "DeleteCheatersCB"
        Me.DeleteCheatersCB.Size = New System.Drawing.Size(190, 17)
        Me.DeleteCheatersCB.TabIndex = 39
        Me.DeleteCheatersCB.Text = "Don't delete 'Cheater' screenshots."
        Me.DeleteCheatersCB.UseVisualStyleBackColor = True
        '
        'PbssStoreCount
        '
        Me.PbssStoreCount.Location = New System.Drawing.Point(207, 21)
        Me.PbssStoreCount.Name = "PbssStoreCount"
        Me.PbssStoreCount.Size = New System.Drawing.Size(42, 20)
        Me.PbssStoreCount.TabIndex = 36
        Me.PbssStoreCount.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(205, 13)
        Me.Label19.TabIndex = 37
        Me.Label19.Text = "Automatically delete old screenshots after "
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(249, 23)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(32, 13)
        Me.Label20.TabIndex = 38
        Me.Label20.Text = "days."
        '
        'ScanSettingsGB
        '
        Me.ScanSettingsGB.Controls.Add(Me.RestoreWindowCB)
        Me.ScanSettingsGB.Controls.Add(Me.PlaySoundCB)
        Me.ScanSettingsGB.Controls.Add(Me.ScanAutoCB)
        Me.ScanSettingsGB.Controls.Add(Me.PBSSScanCount)
        Me.ScanSettingsGB.Controls.Add(Me.Label7)
        Me.ScanSettingsGB.Controls.Add(Me.Label9)
        Me.ScanSettingsGB.Controls.Add(Me.PBSSTimeCount)
        Me.ScanSettingsGB.Controls.Add(Me.Label8)
        Me.ScanSettingsGB.Location = New System.Drawing.Point(7, 7)
        Me.ScanSettingsGB.Name = "ScanSettingsGB"
        Me.ScanSettingsGB.Size = New System.Drawing.Size(496, 122)
        Me.ScanSettingsGB.TabIndex = 39
        Me.ScanSettingsGB.TabStop = False
        Me.ScanSettingsGB.Text = "Scan Settings"
        '
        'RestoreWindowCB
        '
        Me.RestoreWindowCB.AutoSize = True
        Me.RestoreWindowCB.Location = New System.Drawing.Point(7, 91)
        Me.RestoreWindowCB.Name = "RestoreWindowCB"
        Me.RestoreWindowCB.Size = New System.Drawing.Size(285, 17)
        Me.RestoreWindowCB.TabIndex = 38
        Me.RestoreWindowCB.Text = "Restore this window when a suspicious image is found."
        Me.RestoreWindowCB.UseVisualStyleBackColor = True
        '
        'PlaySoundCB
        '
        Me.PlaySoundCB.AutoSize = True
        Me.PlaySoundCB.Location = New System.Drawing.Point(7, 68)
        Me.PlaySoundCB.Name = "PlaySoundCB"
        Me.PlaySoundCB.Size = New System.Drawing.Size(242, 17)
        Me.PlaySoundCB.TabIndex = 37
        Me.PlaySoundCB.Text = "Play sound when a suspicious image is found."
        Me.PlaySoundCB.UseVisualStyleBackColor = True
        '
        'ScanAutoCB
        '
        Me.ScanAutoCB.AutoSize = True
        Me.ScanAutoCB.Location = New System.Drawing.Point(7, 45)
        Me.ScanAutoCB.Name = "ScanAutoCB"
        Me.ScanAutoCB.Size = New System.Drawing.Size(259, 17)
        Me.ScanAutoCB.TabIndex = 36
        Me.ScanAutoCB.Text = "Start scanning automatically when program starts."
        Me.ScanAutoCB.UseVisualStyleBackColor = True
        '
        'PBSSScanCount
        '
        Me.PBSSScanCount.Location = New System.Drawing.Point(73, 19)
        Me.PBSSScanCount.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.PBSSScanCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.PBSSScanCount.Name = "PBSSScanCount"
        Me.PBSSScanCount.Size = New System.Drawing.Size(42, 20)
        Me.PBSSScanCount.TabIndex = 31
        Me.PBSSScanCount.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Scan the last"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(114, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "pbss every"
        '
        'PBSSTimeCount
        '
        Me.PBSSTimeCount.Location = New System.Drawing.Point(173, 19)
        Me.PBSSTimeCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.PBSSTimeCount.Name = "PBSSTimeCount"
        Me.PBSSTimeCount.Size = New System.Drawing.Size(42, 20)
        Me.PBSSTimeCount.TabIndex = 34
        Me.PBSSTimeCount.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(215, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "minutes."
        '
        'EmailTab
        '
        Me.EmailTab.Controls.Add(Me.EmailGroupBox)
        Me.EmailTab.Controls.Add(Me.EnableEmailCHK)
        Me.EmailTab.Location = New System.Drawing.Point(4, 22)
        Me.EmailTab.Name = "EmailTab"
        Me.EmailTab.Padding = New System.Windows.Forms.Padding(3)
        Me.EmailTab.Size = New System.Drawing.Size(529, 352)
        Me.EmailTab.TabIndex = 3
        Me.EmailTab.Text = "Email"
        Me.EmailTab.UseVisualStyleBackColor = True
        '
        'EmailGroupBox
        '
        Me.EmailGroupBox.Controls.Add(Me.Label18)
        Me.EmailGroupBox.Controls.Add(Me.SMTPSSLReqCB)
        Me.EmailGroupBox.Controls.Add(Me.Label3)
        Me.EmailGroupBox.Controls.Add(Me.SMTPSendToTXT)
        Me.EmailGroupBox.Controls.Add(Me.SendTestEmailBTN)
        Me.EmailGroupBox.Controls.Add(Me.Label5)
        Me.EmailGroupBox.Controls.Add(Me.SMTPServerTXT)
        Me.EmailGroupBox.Controls.Add(Me.Label1)
        Me.EmailGroupBox.Controls.Add(Me.SMTPPassTXT)
        Me.EmailGroupBox.Controls.Add(Me.Label2)
        Me.EmailGroupBox.Controls.Add(Me.Label6)
        Me.EmailGroupBox.Controls.Add(Me.SMTPPortTXT)
        Me.EmailGroupBox.Controls.Add(Me.Label4)
        Me.EmailGroupBox.Controls.Add(Me.SMTPUserTXT)
        Me.EmailGroupBox.Location = New System.Drawing.Point(6, 28)
        Me.EmailGroupBox.Name = "EmailGroupBox"
        Me.EmailGroupBox.Size = New System.Drawing.Size(517, 170)
        Me.EmailGroupBox.TabIndex = 7
        Me.EmailGroupBox.TabStop = False
        Me.EmailGroupBox.Text = "SMTP Server Settings"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(18, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 13)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Server Connection"
        '
        'SMTPSSLReqCB
        '
        Me.SMTPSSLReqCB.AutoSize = True
        Me.SMTPSSLReqCB.Location = New System.Drawing.Point(82, 93)
        Me.SMTPSSLReqCB.Name = "SMTPSSLReqCB"
        Me.SMTPSSLReqCB.Size = New System.Drawing.Size(91, 17)
        Me.SMTPSSLReqCB.TabIndex = 18
        Me.SMTPSSLReqCB.Text = "Requires SSL"
        Me.SMTPSSLReqCB.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Send To:"
        '
        'SMTPSendToTXT
        '
        Me.SMTPSendToTXT.Location = New System.Drawing.Point(82, 134)
        Me.SMTPSendToTXT.Name = "SMTPSendToTXT"
        Me.SMTPSendToTXT.Size = New System.Drawing.Size(164, 20)
        Me.SMTPSendToTXT.TabIndex = 9
        Me.SMTPSendToTXT.Text = "youremail@whatever.com"
        '
        'SendTestEmailBTN
        '
        Me.SendTestEmailBTN.Location = New System.Drawing.Point(386, 132)
        Me.SendTestEmailBTN.Name = "SendTestEmailBTN"
        Me.SendTestEmailBTN.Size = New System.Drawing.Size(108, 23)
        Me.SendTestEmailBTN.TabIndex = 17
        Me.SendTestEmailBTN.Text = "Send Test Email"
        Me.SendTestEmailBTN.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(283, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Password:"
        '
        'SMTPServerTXT
        '
        Me.SMTPServerTXT.Location = New System.Drawing.Point(82, 41)
        Me.SMTPServerTXT.Name = "SMTPServerTXT"
        Me.SMTPServerTXT.Size = New System.Drawing.Size(147, 20)
        Me.SMTPServerTXT.TabIndex = 5
        Me.SMTPServerTXT.Text = "smtp.gmail.com"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Server:"
        '
        'SMTPPassTXT
        '
        Me.SMTPPassTXT.Location = New System.Drawing.Point(347, 67)
        Me.SMTPPassTXT.Name = "SMTPPassTXT"
        Me.SMTPPassTXT.Size = New System.Drawing.Size(147, 20)
        Me.SMTPPassTXT.TabIndex = 15
        Me.SMTPPassTXT.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Port:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(283, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Authentcation"
        '
        'SMTPPortTXT
        '
        Me.SMTPPortTXT.Location = New System.Drawing.Point(82, 67)
        Me.SMTPPortTXT.Name = "SMTPPortTXT"
        Me.SMTPPortTXT.Size = New System.Drawing.Size(34, 20)
        Me.SMTPPortTXT.TabIndex = 8
        Me.SMTPPortTXT.Text = "25"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(283, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Username:"
        '
        'SMTPUserTXT
        '
        Me.SMTPUserTXT.Location = New System.Drawing.Point(347, 41)
        Me.SMTPUserTXT.Name = "SMTPUserTXT"
        Me.SMTPUserTXT.Size = New System.Drawing.Size(147, 20)
        Me.SMTPUserTXT.TabIndex = 11
        Me.SMTPUserTXT.Text = "youremail@gmail.com"
        '
        'EnableEmailCHK
        '
        Me.EnableEmailCHK.AutoSize = True
        Me.EnableEmailCHK.Location = New System.Drawing.Point(6, 6)
        Me.EnableEmailCHK.Name = "EnableEmailCHK"
        Me.EnableEmailCHK.Size = New System.Drawing.Size(148, 17)
        Me.EnableEmailCHK.TabIndex = 6
        Me.EnableEmailCHK.Text = "Enable Email Notifications"
        Me.EnableEmailCHK.UseVisualStyleBackColor = True
        '
        'WebTab
        '
        Me.WebTab.Controls.Add(Me.RichTextBox2)
        Me.WebTab.Controls.Add(Me.EnableWebServerCHK)
        Me.WebTab.Controls.Add(Me.WebServerSettingsGB)
        Me.WebTab.Location = New System.Drawing.Point(4, 22)
        Me.WebTab.Name = "WebTab"
        Me.WebTab.Padding = New System.Windows.Forms.Padding(3)
        Me.WebTab.Size = New System.Drawing.Size(529, 352)
        Me.WebTab.TabIndex = 4
        Me.WebTab.Text = "Web"
        Me.WebTab.UseVisualStyleBackColor = True
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(7, 185)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.ReadOnly = True
        Me.RichTextBox2.Size = New System.Drawing.Size(516, 161)
        Me.RichTextBox2.TabIndex = 5
        Me.RichTextBox2.Text = resources.GetString("RichTextBox2.Text")
        '
        'EnableWebServerCHK
        '
        Me.EnableWebServerCHK.AutoSize = True
        Me.EnableWebServerCHK.Location = New System.Drawing.Point(7, 7)
        Me.EnableWebServerCHK.Name = "EnableWebServerCHK"
        Me.EnableWebServerCHK.Size = New System.Drawing.Size(119, 17)
        Me.EnableWebServerCHK.TabIndex = 4
        Me.EnableWebServerCHK.Text = "Enable Web Server"
        Me.EnableWebServerCHK.UseVisualStyleBackColor = True
        '
        'WebServerSettingsGB
        '
        Me.WebServerSettingsGB.Controls.Add(Me.Label30)
        Me.WebServerSettingsGB.Controls.Add(Me.Label29)
        Me.WebServerSettingsGB.Controls.Add(Me.WebPublicLink)
        Me.WebServerSettingsGB.Controls.Add(Me.WebPrivateLink)
        Me.WebServerSettingsGB.Controls.Add(Me.WebBannerTXT)
        Me.WebServerSettingsGB.Controls.Add(Me.Label28)
        Me.WebServerSettingsGB.Controls.Add(Me.WebDisplayLimitNUM)
        Me.WebServerSettingsGB.Controls.Add(Me.WebPortNUM)
        Me.WebServerSettingsGB.Controls.Add(Me.Label27)
        Me.WebServerSettingsGB.Controls.Add(Me.Label26)
        Me.WebServerSettingsGB.Controls.Add(Me.WebPassTXT)
        Me.WebServerSettingsGB.Controls.Add(Me.Label25)
        Me.WebServerSettingsGB.Location = New System.Drawing.Point(7, 30)
        Me.WebServerSettingsGB.Name = "WebServerSettingsGB"
        Me.WebServerSettingsGB.Size = New System.Drawing.Size(516, 149)
        Me.WebServerSettingsGB.TabIndex = 3
        Me.WebServerSettingsGB.TabStop = False
        Me.WebServerSettingsGB.Text = "Web Server Settings"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(194, 83)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(71, 13)
        Me.Label30.TabIndex = 16
        Me.Label30.Text = "Intranet URL:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(194, 58)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(71, 13)
        Me.Label29.TabIndex = 15
        Me.Label29.Text = "Internet URL:"
        '
        'WebPublicLink
        '
        Me.WebPublicLink.AutoSize = True
        Me.WebPublicLink.Location = New System.Drawing.Point(302, 58)
        Me.WebPublicLink.Name = "WebPublicLink"
        Me.WebPublicLink.Size = New System.Drawing.Size(114, 13)
        Me.WebPublicLink.TabIndex = 14
        Me.WebPublicLink.TabStop = True
        Me.WebPublicLink.Text = "Web server is disabled"
        '
        'WebPrivateLink
        '
        Me.WebPrivateLink.AutoSize = True
        Me.WebPrivateLink.Location = New System.Drawing.Point(302, 83)
        Me.WebPrivateLink.Name = "WebPrivateLink"
        Me.WebPrivateLink.Size = New System.Drawing.Size(114, 13)
        Me.WebPrivateLink.TabIndex = 13
        Me.WebPrivateLink.TabStop = True
        Me.WebPrivateLink.Text = "Web server is disabled"
        '
        'WebBannerTXT
        '
        Me.WebBannerTXT.Location = New System.Drawing.Point(305, 28)
        Me.WebBannerTXT.Name = "WebBannerTXT"
        Me.WebBannerTXT.Size = New System.Drawing.Size(205, 20)
        Me.WebBannerTXT.TabIndex = 12
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(194, 31)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(105, 13)
        Me.Label28.TabIndex = 11
        Me.Label28.Text = "Banner URL or Text:"
        '
        'WebDisplayLimitNUM
        '
        Me.WebDisplayLimitNUM.Location = New System.Drawing.Point(82, 81)
        Me.WebDisplayLimitNUM.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.WebDisplayLimitNUM.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.WebDisplayLimitNUM.Name = "WebDisplayLimitNUM"
        Me.WebDisplayLimitNUM.Size = New System.Drawing.Size(57, 20)
        Me.WebDisplayLimitNUM.TabIndex = 10
        Me.WebDisplayLimitNUM.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'WebPortNUM
        '
        Me.WebPortNUM.Location = New System.Drawing.Point(82, 29)
        Me.WebPortNUM.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.WebPortNUM.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.WebPortNUM.Name = "WebPortNUM"
        Me.WebPortNUM.Size = New System.Drawing.Size(57, 20)
        Me.WebPortNUM.TabIndex = 9
        Me.WebPortNUM.Value = New Decimal(New Integer() {8088, 0, 0, 0})
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 83)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(68, 13)
        Me.Label27.TabIndex = 7
        Me.Label27.Text = "Display Limit:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(7, 55)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 13)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "Password:"
        '
        'WebPassTXT
        '
        Me.WebPassTXT.Location = New System.Drawing.Point(82, 55)
        Me.WebPassTXT.Name = "WebPassTXT"
        Me.WebPassTXT.Size = New System.Drawing.Size(85, 20)
        Me.WebPassTXT.TabIndex = 4
        Me.WebPassTXT.Text = "iseepbss"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(7, 31)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(29, 13)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "Port:"
        '
        'SuspiciousTab
        '
        Me.SuspiciousTab.Controls.Add(Me.DismissDurationCB)
        Me.SuspiciousTab.Controls.Add(Me.SusImageInfoLAB)
        Me.SuspiciousTab.Controls.Add(Me.SusImgLAB)
        Me.SuspiciousTab.Controls.Add(Me.DismissPBSSBTN)
        Me.SuspiciousTab.Controls.Add(Me.NextImgBTN)
        Me.SuspiciousTab.Controls.Add(Me.PrevImgBTN)
        Me.SuspiciousTab.Controls.Add(Me.ReviewPB)
        Me.SuspiciousTab.Location = New System.Drawing.Point(4, 22)
        Me.SuspiciousTab.Name = "SuspiciousTab"
        Me.SuspiciousTab.Padding = New System.Windows.Forms.Padding(3)
        Me.SuspiciousTab.Size = New System.Drawing.Size(543, 384)
        Me.SuspiciousTab.TabIndex = 5
        Me.SuspiciousTab.Text = "Suspicious"
        Me.SuspiciousTab.UseVisualStyleBackColor = True
        '
        'DismissDurationCB
        '
        Me.DismissDurationCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DismissDurationCB.FormattingEnabled = True
        Me.DismissDurationCB.Items.AddRange(New Object() {"Dismiss Image", "Dismiss Player Images For 1 Hour", "Dismiss Player Images For 1 Day", "Dismiss Player Images For 15 Days", "Dismiss Player Images For 30 Days", "** Mark Player As Cheater **"})
        Me.DismissDurationCB.Location = New System.Drawing.Point(149, 356)
        Me.DismissDurationCB.Name = "DismissDurationCB"
        Me.DismissDurationCB.Size = New System.Drawing.Size(182, 21)
        Me.DismissDurationCB.TabIndex = 7
        '
        'SusImageInfoLAB
        '
        Me.SusImageInfoLAB.AutoSize = True
        Me.SusImageInfoLAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SusImageInfoLAB.Location = New System.Drawing.Point(6, 329)
        Me.SusImageInfoLAB.Name = "SusImageInfoLAB"
        Me.SusImageInfoLAB.Size = New System.Drawing.Size(0, 17)
        Me.SusImageInfoLAB.TabIndex = 6
        Me.SusImageInfoLAB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SusImgLAB
        '
        Me.SusImgLAB.AutoSize = True
        Me.SusImgLAB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SusImgLAB.Location = New System.Drawing.Point(425, 329)
        Me.SusImgLAB.Name = "SusImgLAB"
        Me.SusImgLAB.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SusImgLAB.Size = New System.Drawing.Size(0, 17)
        Me.SusImgLAB.TabIndex = 5
        '
        'DismissPBSSBTN
        '
        Me.DismissPBSSBTN.Location = New System.Drawing.Point(337, 355)
        Me.DismissPBSSBTN.Name = "DismissPBSSBTN"
        Me.DismissPBSSBTN.Size = New System.Drawing.Size(57, 23)
        Me.DismissPBSSBTN.TabIndex = 3
        Me.DismissPBSSBTN.Text = "Dismiss"
        Me.DismissPBSSBTN.UseVisualStyleBackColor = True
        '
        'NextImgBTN
        '
        Me.NextImgBTN.Location = New System.Drawing.Point(462, 355)
        Me.NextImgBTN.Name = "NextImgBTN"
        Me.NextImgBTN.Size = New System.Drawing.Size(75, 23)
        Me.NextImgBTN.TabIndex = 2
        Me.NextImgBTN.Text = "Next Image"
        Me.NextImgBTN.UseVisualStyleBackColor = True
        '
        'PrevImgBTN
        '
        Me.PrevImgBTN.Location = New System.Drawing.Point(6, 355)
        Me.PrevImgBTN.Name = "PrevImgBTN"
        Me.PrevImgBTN.Size = New System.Drawing.Size(75, 23)
        Me.PrevImgBTN.TabIndex = 1
        Me.PrevImgBTN.Text = "Prev Image"
        Me.PrevImgBTN.UseVisualStyleBackColor = True
        '
        'ReviewPB
        '
        Me.ReviewPB.Image = Global.RADAR.My.Resources.Resources.RADAR_Clear
        Me.ReviewPB.Location = New System.Drawing.Point(4, 7)
        Me.ReviewPB.Name = "ReviewPB"
        Me.ReviewPB.Size = New System.Drawing.Size(533, 319)
        Me.ReviewPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.ReviewPB.TabIndex = 0
        Me.ReviewPB.TabStop = False
        '
        'MainTabMenu
        '
        Me.MainTabMenu.Controls.Add(Me.SuspiciousTab)
        Me.MainTabMenu.Controls.Add(Me.SettingsTab)
        Me.MainTabMenu.Controls.Add(Me.ColorFilterTab)
        Me.MainTabMenu.Controls.Add(Me.StatsTab)
        Me.MainTabMenu.Controls.Add(Me.LogTab)
        Me.MainTabMenu.Controls.Add(Me.NewsTab)
        Me.MainTabMenu.Controls.Add(Me.AltAccountTAB)
        Me.MainTabMenu.Location = New System.Drawing.Point(13, 12)
        Me.MainTabMenu.Name = "MainTabMenu"
        Me.MainTabMenu.SelectedIndex = 0
        Me.MainTabMenu.Size = New System.Drawing.Size(551, 410)
        Me.MainTabMenu.TabIndex = 5
        '
        'AltAccountTAB
        '
        Me.AltAccountTAB.Controls.Add(Me.RichTextBox3)
        Me.AltAccountTAB.Controls.Add(Me.AltShowDateCB)
        Me.AltAccountTAB.Controls.Add(Me.AltGV)
        Me.AltAccountTAB.Controls.Add(Me.Label31)
        Me.AltAccountTAB.Controls.Add(Me.AltHeroNameTXT)
        Me.AltAccountTAB.Controls.Add(Me.AltProcessLogBTN)
        Me.AltAccountTAB.Controls.Add(Me.AltSearchBTN)
        Me.AltAccountTAB.Location = New System.Drawing.Point(4, 22)
        Me.AltAccountTAB.Name = "AltAccountTAB"
        Me.AltAccountTAB.Padding = New System.Windows.Forms.Padding(3)
        Me.AltAccountTAB.Size = New System.Drawing.Size(543, 384)
        Me.AltAccountTAB.TabIndex = 7
        Me.AltAccountTAB.Text = "Alt Accounts"
        Me.AltAccountTAB.UseVisualStyleBackColor = True
        '
        'RichTextBox3
        '
        Me.RichTextBox3.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox3.Location = New System.Drawing.Point(6, 6)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.ReadOnly = True
        Me.RichTextBox3.Size = New System.Drawing.Size(531, 76)
        Me.RichTextBox3.TabIndex = 11
        Me.RichTextBox3.Text = resources.GetString("RichTextBox3.Text")
        '
        'AltShowDateCB
        '
        Me.AltShowDateCB.AutoSize = True
        Me.AltShowDateCB.Location = New System.Drawing.Point(224, 92)
        Me.AltShowDateCB.Name = "AltShowDateCB"
        Me.AltShowDateCB.Size = New System.Drawing.Size(79, 17)
        Me.AltShowDateCB.TabIndex = 10
        Me.AltShowDateCB.Text = "Show Date"
        Me.AltShowDateCB.UseVisualStyleBackColor = True
        '
        'AltGV
        '
        Me.AltGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.AltGV.Location = New System.Drawing.Point(3, 117)
        Me.AltGV.Name = "AltGV"
        Me.AltGV.ReadOnly = True
        Me.AltGV.Size = New System.Drawing.Size(534, 261)
        Me.AltGV.TabIndex = 9
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(3, 93)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(120, 13)
        Me.Label31.TabIndex = 8
        Me.Label31.Text = "Hero Name/IP Address:"
        '
        'AltHeroNameTXT
        '
        Me.AltHeroNameTXT.Location = New System.Drawing.Point(129, 90)
        Me.AltHeroNameTXT.Name = "AltHeroNameTXT"
        Me.AltHeroNameTXT.Size = New System.Drawing.Size(87, 20)
        Me.AltHeroNameTXT.TabIndex = 0
        '
        'AltProcessLogBTN
        '
        Me.AltProcessLogBTN.Location = New System.Drawing.Point(390, 88)
        Me.AltProcessLogBTN.Name = "AltProcessLogBTN"
        Me.AltProcessLogBTN.Size = New System.Drawing.Size(147, 23)
        Me.AltProcessLogBTN.TabIndex = 2
        Me.AltProcessLogBTN.Text = "Process Log Files"
        Me.AltProcessLogBTN.UseVisualStyleBackColor = True
        '
        'AltSearchBTN
        '
        Me.AltSearchBTN.Location = New System.Drawing.Point(309, 88)
        Me.AltSearchBTN.Name = "AltSearchBTN"
        Me.AltSearchBTN.Size = New System.Drawing.Size(75, 23)
        Me.AltSearchBTN.TabIndex = 1
        Me.AltSearchBTN.Text = "Search"
        Me.AltSearchBTN.UseVisualStyleBackColor = True
        '
        'LookupFormPB
        '
        Me.LookupFormPB.Image = Global.RADAR.My.Resources.Resources.Very_Basic_Search_icon_24_d
        Me.LookupFormPB.Location = New System.Drawing.Point(536, 0)
        Me.LookupFormPB.Name = "LookupFormPB"
        Me.LookupFormPB.Size = New System.Drawing.Size(24, 24)
        Me.LookupFormPB.TabIndex = 27
        Me.LookupFormPB.TabStop = False
        Me.ToolTips.SetToolTip(Me.LookupFormPB, "Search Screenshots")
        '
        'FormOpenBGW
        '
        '
        'BGPanel
        '
        Me.BGPanel.Controls.Add(Me.ReportGGCPB)
        Me.BGPanel.Controls.Add(Me.OpenAppFolderPB)
        Me.BGPanel.Controls.Add(Me.LookupFormPB)
        Me.BGPanel.Controls.Add(Me.MainTabMenu)
        Me.BGPanel.Controls.Add(Me.ToggleScanBTN)
        Me.BGPanel.Controls.Add(Me.ProgressBar1)
        Me.BGPanel.Controls.Add(Me.StatusLAB)
        Me.BGPanel.Controls.Add(Me.SaveSettingsBTN)
        Me.BGPanel.Location = New System.Drawing.Point(22, 77)
        Me.BGPanel.Name = "BGPanel"
        Me.BGPanel.Size = New System.Drawing.Size(568, 507)
        Me.BGPanel.TabIndex = 29
        '
        'ReportGGCPB
        '
        Me.ReportGGCPB.Image = Global.RADAR.My.Resources.Resources.Users_Police_icon_24_d
        Me.ReportGGCPB.Location = New System.Drawing.Point(476, 0)
        Me.ReportGGCPB.Name = "ReportGGCPB"
        Me.ReportGGCPB.Size = New System.Drawing.Size(24, 24)
        Me.ReportGGCPB.TabIndex = 29
        Me.ReportGGCPB.TabStop = False
        Me.ToolTips.SetToolTip(Me.ReportGGCPB, "Report Screenshot to GGC-Stream.net")
        '
        'OpenAppFolderPB
        '
        Me.OpenAppFolderPB.Image = Global.RADAR.My.Resources.Resources.Very_Basic_Folder_icon_24_d
        Me.OpenAppFolderPB.Location = New System.Drawing.Point(506, 0)
        Me.OpenAppFolderPB.Name = "OpenAppFolderPB"
        Me.OpenAppFolderPB.Size = New System.Drawing.Size(24, 24)
        Me.OpenAppFolderPB.TabIndex = 28
        Me.OpenAppFolderPB.TabStop = False
        Me.ToolTips.SetToolTip(Me.OpenAppFolderPB, "Open App Folder")
        '
        'ExitPB
        '
        Me.ExitPB.Image = Global.RADAR.My.Resources.Resources.Very_Basic_Cancel_icon_24_d
        Me.ExitPB.Location = New System.Drawing.Point(610, 76)
        Me.ExitPB.Name = "ExitPB"
        Me.ExitPB.Size = New System.Drawing.Size(24, 24)
        Me.ExitPB.TabIndex = 30
        Me.ExitPB.TabStop = False
        Me.ToolTips.SetToolTip(Me.ExitPB, "Exit Application")
        '
        'MinimizePB
        '
        Me.MinimizePB.Image = Global.RADAR.My.Resources.Resources.Very_Basic_Download_icon_d
        Me.MinimizePB.Location = New System.Drawing.Point(610, 103)
        Me.MinimizePB.Name = "MinimizePB"
        Me.MinimizePB.Size = New System.Drawing.Size(24, 24)
        Me.MinimizePB.TabIndex = 31
        Me.MinimizePB.TabStop = False
        Me.ToolTips.SetToolTip(Me.MinimizePB, "Minimize to Toolbar")
        '
        'WebUpdateBGW
        '
        '
        'WebUpdateTimer
        '
        Me.WebUpdateTimer.Enabled = True
        Me.WebUpdateTimer.Interval = 600000
        '
        'RadarLinkPB
        '
        Me.RadarLinkPB.Image = Global.RADAR.My.Resources.Resources.wwwpb_radarnet
        Me.RadarLinkPB.Location = New System.Drawing.Point(26, 592)
        Me.RadarLinkPB.Name = "RadarLinkPB"
        Me.RadarLinkPB.Size = New System.Drawing.Size(111, 12)
        Me.RadarLinkPB.TabIndex = 32
        Me.RadarLinkPB.TabStop = False
        '
        'AltAccountsBGW
        '
        Me.AltAccountsBGW.WorkerReportsProgress = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.RADAR.My.Resources.Resources.bg
        Me.ClientSize = New System.Drawing.Size(649, 616)
        Me.Controls.Add(Me.RadarLinkPB)
        Me.Controls.Add(Me.MinimizePB)
        Me.Controls.Add(Me.ExitPB)
        Me.Controls.Add(Me.BGPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.Text = "R.A.D.A.R v2.0 - By Hoof~Arted"
        Me.NewsTab.ResumeLayout(False)
        Me.LogTab.ResumeLayout(False)
        Me.StatsTab.ResumeLayout(False)
        CType(Me.HistoricalBreakdownPieChart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StoredBreakdownPieChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ColorFilterTab.ResumeLayout(False)
        Me.ColorFilterTab.PerformLayout()
        CType(Me.ColorFilterBlueNUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorFilterGreenNUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorFilterRedNUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ThresholdEndNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ThresholdStartNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorFilterGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SettingsTab.ResumeLayout(False)
        Me.SettingsTabs.ResumeLayout(False)
        Me.ServersTab.ResumeLayout(False)
        CType(Me.ServersGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AddServersGB.ResumeLayout(False)
        Me.AddServersGB.PerformLayout()
        CType(Me.ServerRconPortNUM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AuthGB.ResumeLayout(False)
        Me.AuthGB.PerformLayout()
        Me.GeneralTab.ResumeLayout(False)
        Me.ShareGB.ResumeLayout(False)
        Me.ShareGB.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PbssStoreCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ScanSettingsGB.ResumeLayout(False)
        Me.ScanSettingsGB.PerformLayout()
        CType(Me.PBSSScanCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBSSTimeCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmailTab.ResumeLayout(False)
        Me.EmailTab.PerformLayout()
        Me.EmailGroupBox.ResumeLayout(False)
        Me.EmailGroupBox.PerformLayout()
        Me.WebTab.ResumeLayout(False)
        Me.WebTab.PerformLayout()
        Me.WebServerSettingsGB.ResumeLayout(False)
        Me.WebServerSettingsGB.PerformLayout()
        CType(Me.WebDisplayLimitNUM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WebPortNUM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuspiciousTab.ResumeLayout(False)
        Me.SuspiciousTab.PerformLayout()
        CType(Me.ReviewPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainTabMenu.ResumeLayout(False)
        Me.AltAccountTAB.ResumeLayout(False)
        Me.AltAccountTAB.PerformLayout()
        CType(Me.AltGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookupFormPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BGPanel.ResumeLayout(False)
        Me.BGPanel.PerformLayout()
        CType(Me.ReportGGCPB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OpenAppFolderPB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExitPB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinimizePB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadarLinkPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StatusLAB As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ToggleScanBTN As System.Windows.Forms.Button
    Friend WithEvents ScanPBSSTimer As System.Windows.Forms.Timer
    Friend WithEvents ScanPBSSBGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents ScanPBSSNotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents SaveSettingsBTN As System.Windows.Forms.Button
    Friend WithEvents NewsTab As System.Windows.Forms.TabPage
    Friend WithEvents NewsBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents LogTab As System.Windows.Forms.TabPage
    Friend WithEvents LogRTB As System.Windows.Forms.RichTextBox
    Friend WithEvents StatsTab As System.Windows.Forms.TabPage
    Friend WithEvents ColorFilterTab As System.Windows.Forms.TabPage
    Friend WithEvents ColorFilterAddColorBTN As System.Windows.Forms.Button
    Friend WithEvents ColorFilterBlueNUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ColorFilterGreenNUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ColorFilterRedNUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ThresholdEndNum As System.Windows.Forms.NumericUpDown
    Friend WithEvents ThresholdStartNum As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents DeleteColorFilterRowBTN As System.Windows.Forms.Button
    Friend WithEvents ColorFilterGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Sample As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SettingsTab As System.Windows.Forms.TabPage
    Friend WithEvents SettingsTabs As System.Windows.Forms.TabControl
    Friend WithEvents ServersTab As System.Windows.Forms.TabPage
    Friend WithEvents DeleteServerBTN As System.Windows.Forms.Button
    Friend WithEvents ServersGV As System.Windows.Forms.DataGridView
    Friend WithEvents AddServersGB As System.Windows.Forms.GroupBox
    Friend WithEvents ServerRconPortNUM As System.Windows.Forms.NumericUpDown
    Friend WithEvents AddServerBTN As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ServerRconPassTXT As System.Windows.Forms.TextBox
    Friend WithEvents ServerIPTXT As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ServerNameTXT As System.Windows.Forms.TextBox
    Friend WithEvents AuthGB As System.Windows.Forms.GroupBox
    Friend WithEvents PbsvssAuthReqCB As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PbsvssAuthPassTXT As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PbsvssAuthUserTXT As System.Windows.Forms.TextBox
    Friend WithEvents PbsvssURLTXT As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GeneralTab As System.Windows.Forms.TabPage
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents PbssStoreCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PBSSTimeCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PBSSScanCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents EmailTab As System.Windows.Forms.TabPage
    Friend WithEvents EmailGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents SMTPSSLReqCB As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SMTPSendToTXT As System.Windows.Forms.TextBox
    Friend WithEvents SendTestEmailBTN As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SMTPServerTXT As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SMTPPassTXT As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SMTPPortTXT As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SMTPUserTXT As System.Windows.Forms.TextBox
    Friend WithEvents EnableEmailCHK As System.Windows.Forms.CheckBox
    Friend WithEvents SuspiciousTab As System.Windows.Forms.TabPage
    Friend WithEvents NextImgBTN As System.Windows.Forms.Button
    Friend WithEvents PrevImgBTN As System.Windows.Forms.Button
    Friend WithEvents ReviewPB As System.Windows.Forms.PictureBox
    Friend WithEvents MainTabMenu As System.Windows.Forms.TabControl
    Friend WithEvents ScanSettingsGB As System.Windows.Forms.GroupBox
    Friend WithEvents RefreshStatsBTN As System.Windows.Forms.Button
    Friend WithEvents LookupFormPB As System.Windows.Forms.PictureBox
    Friend WithEvents StoredBreakdownPieChart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents HistoricalBreakdownPieChart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents FormOpenBGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DeleteCheatersCB As System.Windows.Forms.CheckBox
    Friend WithEvents ScanAutoCB As System.Windows.Forms.CheckBox
    Friend WithEvents DeleteSuspiciousCB As System.Windows.Forms.CheckBox
    Friend WithEvents PlaySoundCB As System.Windows.Forms.CheckBox
    Friend WithEvents SusImgLAB As System.Windows.Forms.Label
    Friend WithEvents SusImageInfoLAB As System.Windows.Forms.Label
    Friend WithEvents RestoreWindowCB As System.Windows.Forms.CheckBox
    Friend WithEvents DismissPBSSBTN As System.Windows.Forms.Button
    Friend WithEvents DismissDurationCB As System.Windows.Forms.ComboBox
    Friend WithEvents ShareGB As System.Windows.Forms.GroupBox
    Friend WithEvents PostSSCB As System.Windows.Forms.CheckBox
    Friend WithEvents PostStatsCB As System.Windows.Forms.CheckBox
    Friend WithEvents BGPanel As System.Windows.Forms.Panel
    Friend WithEvents ExitPB As System.Windows.Forms.PictureBox
    Friend WithEvents MinimizePB As System.Windows.Forms.PictureBox
    Friend WithEvents OpenAppFolderPB As System.Windows.Forms.PictureBox
    Friend WithEvents ReportGGCPB As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
    Friend WithEvents WebUpdateBGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents WebUpdateTimer As System.Windows.Forms.Timer
    Friend WithEvents PurgeBTN As System.Windows.Forms.Button
    Friend WithEvents RadarLinkPB As System.Windows.Forms.PictureBox
    Friend WithEvents RescanBTN As System.Windows.Forms.Button
    Friend WithEvents WebTab As System.Windows.Forms.TabPage
    Friend WithEvents EnableWebServerCHK As System.Windows.Forms.CheckBox
    Friend WithEvents WebServerSettingsGB As System.Windows.Forms.GroupBox
    Friend WithEvents WebDisplayLimitNUM As System.Windows.Forms.NumericUpDown
    Friend WithEvents WebPortNUM As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents WebPassTXT As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents WebBannerTXT As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents WebPrivateLink As System.Windows.Forms.LinkLabel
    Friend WithEvents WebPublicLink As System.Windows.Forms.LinkLabel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents AltAccountsBGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents AltAccountTAB As System.Windows.Forms.TabPage
    Friend WithEvents AltGV As System.Windows.Forms.DataGridView
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents AltHeroNameTXT As System.Windows.Forms.TextBox
    Friend WithEvents AltProcessLogBTN As System.Windows.Forms.Button
    Friend WithEvents AltSearchBTN As System.Windows.Forms.Button
    Friend WithEvents AltShowDateCB As System.Windows.Forms.CheckBox
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox

End Class
