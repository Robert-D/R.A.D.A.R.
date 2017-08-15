Public Class LookupForm
#Region "Global Variables"
    Dim spath As String = Application.StartupPath()
    Private mouseIsDown As Boolean = False
    Private firstPoint As Point
#End Region
    Private Sub LookupForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        SetTheme()
        'Load the servers from the database
        Dim db As SQLiteDatabase = New SQLiteDatabase()
        Dim dt As DataTable = db.GetDataTable("SELECT 0 AS ServerID, 'All Servers' AS ServerName UNION SELECT ServerID, ServerName FROM Servers")
        ServersCB.DisplayMember = "ServerName"
        ServersCB.ValueMember = "ServerID"
        ServersCB.DataSource = dt
        ServersCB.SelectedIndex = 0
        GetResults()
        Me.AcceptButton = SearchBTN
    End Sub
    Sub SetTheme()
        Dim Img As New System.Drawing.Bitmap(My.Resources.lookupbg)

        Dim g As Graphics = Me.CreateGraphics
        If g.DpiX.ToString() = "96" And g.DpiY.ToString() = "96" Then
            'Normal DPI is being used
            'Setup custom form theme
            'Setup the inner form size to the size of the background image
            Dim cs As New Size(919, 671)
            Me.ClientSize = cs

            Me.BackgroundImage = Img

            'Your image path
            Dim color As Color = Img.GetPixel(0, 0)
            Dim color2 As Color = Img.GetPixel(350, 200)
            'Get the color for transparency in your image, and I choose the left upper pixel.
            Img.MakeTransparent(color)
            BGPanel.BackColor = color2
            MinimizePB.BackColor = color2
            ExitPB.BackColor = color2
            Me.BackgroundImage = Img

            Me.TransparencyKey = color

            Me.BackColor = color

            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Else
            'Custom DPI is being used
            Me.Text &= " - Compatibility View"
            Dim color2 As Color = Img.GetPixel(350, 200)
            Me.BackgroundImage = My.Resources.CompatibilityBG
            Me.BackgroundImageLayout = ImageLayout.None
            Me.BackColor = color2
            ViewPB.SizeMode = PictureBoxSizeMode.StretchImage
            BGPanel.BackColor = color2
            MinimizePB.BackColor = color2
            ExitPB.BackColor = color2
        End If
        g.Dispose()

    End Sub
    Private Sub SearchBTN_Click(sender As System.Object, e As System.EventArgs) Handles SearchBTN.Click
        GetResults()
    End Sub

    Private Sub ResultsGV_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles ResultsGV.SelectionChanged
        Try


            Dim selectedImage As String = ResultsGV.SelectedRows(0).Cells("Renamed").FormattedValue

            ViewPB.Image = Image.FromFile(spath & "\Store\PBSS\" & selectedImage)
            LookupFormZoom.ViewZoomPB.Image = Image.FromFile(spath & "\Store\PBSS\" & selectedImage)
            HeroNameLAB.Text = "Hero: " & ResultsGV.SelectedRows(0).Cells("Hero").FormattedValue
            DateLAB.Text = "Date: " & ResultsGV.SelectedRows(0).Cells("Date").FormattedValue
            OrgImgLAB.Text = "Orginal Image: " & ResultsGV.SelectedRows(0).Cells("Org Image").FormattedValue
            RenamedImgLAB.Text = "Stored Image: " & ResultsGV.SelectedRows(0).Cells("Renamed").FormattedValue
            ServerLab.Text = "Server: " & ResultsGV.SelectedRows(0).Cells("Server Name").FormattedValue
        Catch ex As Exception

        End Try
    End Sub

    Sub GetResults()
        Try
            Dim sql As String = "SELECT PB.HeroName AS Hero, DATETIME(PB.ImageDate) AS Date, S.ServerName AS 'Server Name', "
            sql &= "PB.IsBlack AS Black, PB.IsPink AS Pink, PB.ScreenCapFailed AS Failed, PB.IsCropped AS Cropped, PB.ReviewFlag AS Suspicious, PB.IsCheater AS Cheater, PB.IsNormal AS Normal, "
            sql &= "'pb' ||  PB.ImageNum || '.png' AS 'Org Image', PB.ImageName AS 'Renamed', PB.PBSSID, "
            sql &= "ColorFilterCount AS 'Matched Pixels' "
            sql &= "FROM MasterPBSS AS PB INNER JOIN Servers AS S ON PB.ServerID = S.ServerID "
            sql &= "WHERE (PB.ServerID = CASE " & ServersCB.SelectedValue & " WHEN 0 THEN PB.ServerID ELSE " & ServersCB.SelectedValue & " END) AND (PB.Deleted = 0) "

            If LookupHeroNameTXT.Text <> "" Then
                sql &= "AND (PB.HeroName LIKE '" & LookupHeroNameTXT.Text.Replace("'", "") & "%') "
            End If

            If SuspiciousCB.Checked = True Then
                sql &= "AND (PB.ReviewFlag = 1) "
            End If

            If CroppedCB.Checked = True Then
                sql &= "AND (PB.IsCropped = 1) "
            End If

            If FailedCB.Checked = True Then
                sql &= "AND (PB.ScreenCapFailed = 1) "
            End If

            If PinkCB.Checked = True Then
                sql &= "AND (PB.IsPink = 1) "
            End If

            If BlackCB.Checked = True Then
                sql &= "AND (PB.IsBlack = 1) "
            End If

            If NormalCB.Checked = True Then
                sql &= "AND (PB.IsNormal = 1) "
            End If

            If CheatersCB.Checked = True Then
                sql &= "AND (PB.IsCheater = 1) "
            End If

            sql &= "ORDER BY PB.PBSSID DESC LIMIT " & MaxRecNUM.Value


            Dim db As SQLiteDatabase = New SQLiteDatabase()
            Dim dt As DataTable = db.GetDataTable(sql)
            ResultsGV.DataSource = dt
            ResultsGV.Columns("Renamed").Visible = False
            ResultsGV.Columns("PBSSID").Visible = False
            ReturnedCntLAB.Text = "Records Returned: " & dt.Rows.Count
            ResultsGV.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RenamedImgLAB_Click(sender As System.Object, e As System.EventArgs) Handles RenamedImgLAB.Click
        Process.Start(spath & "\Store\PBSS\" & ResultsGV.SelectedRows(0).Cells("Renamed").FormattedValue)

    End Sub

    Private Sub RenamedImgLAB_MouseEnter(sender As System.Object, e As System.EventArgs) Handles RenamedImgLAB.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub RenamedImgLAB_MouseHover(sender As System.Object, e As System.EventArgs) Handles RenamedImgLAB.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub RenamedImgLAB_MouseLeave(sender As System.Object, e As System.EventArgs) Handles RenamedImgLAB.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub ResetBTN_Click(sender As System.Object, e As System.EventArgs) Handles ResetBTN.Click
        ResetSearchCriteria()
        GetResults()
    End Sub
    Sub ResetSearchCriteria()
        ServersCB.SelectedIndex = 0
        LookupHeroNameTXT.Text = ""
        Dim cb As Control
        For Each cb In BGPanel.Controls
            If (TypeOf cb Is CheckBox) Then
                CType(cb, CheckBox).Checked = False
            End If
        Next cb
    End Sub

    Private Sub LookupForm_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        firstPoint = e.Location
        mouseIsDown = True
    End Sub

    Private Sub LookupForm_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        mouseIsDown = False
    End Sub

    Private Sub LookupForm_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If mouseIsDown Then
            ' Get the difference between the two points
            Dim xDiff As Integer = firstPoint.X - e.Location.X
            Dim yDiff As Integer = firstPoint.Y - e.Location.Y

            ' Set the new point
            Dim x As Integer = Me.Location.X - xDiff
            Dim y As Integer = Me.Location.Y - yDiff
            Me.Location = New Point(x, y)
        End If
    End Sub

    Private Sub ExitPB_Click(sender As System.Object, e As System.EventArgs) Handles ExitPB.Click
        Me.Close()
    End Sub

    Private Sub ExitPB_MouseEnter(sender As Object, e As System.EventArgs) Handles ExitPB.MouseEnter
        Me.Cursor = Cursors.Hand
        ExitPB.Image = My.Resources.Very_Basic_Cancel_icon_24_r
    End Sub

    Private Sub ExitPB_MouseHover(sender As Object, e As System.EventArgs) Handles ExitPB.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub ExitPB_MouseLeave(sender As Object, e As System.EventArgs) Handles ExitPB.MouseLeave
        Me.Cursor = Cursors.Default
        ExitPB.Image = My.Resources.Very_Basic_Cancel_icon_24_d
    End Sub

    Private Sub MinimizePB_Click(sender As System.Object, e As System.EventArgs) Handles MinimizePB.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub MinimizePB_MouseEnter(sender As Object, e As System.EventArgs) Handles MinimizePB.MouseEnter
        Me.Cursor = Cursors.Hand
        MinimizePB.Image = My.Resources.Very_Basic_Download_icon_g
    End Sub

    Private Sub MinimizePB_MouseHover(sender As Object, e As System.EventArgs) Handles MinimizePB.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub MinimizePB_MouseLeave(sender As Object, e As System.EventArgs) Handles MinimizePB.MouseLeave
        Me.Cursor = Cursors.Default
        MinimizePB.Image = My.Resources.Very_Basic_Download_icon_d
    End Sub

    Private Sub ResultsGV_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles ResultsGV.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then                         'Run on mouse right button click 
                Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)          'HitTest to find out Row Index
                If hti.Type = DataGridViewHitTestType.Cell Then
                    If Not ResultsGV.Rows(hti.RowIndex).Selected Then
                        ResultsGV.ClearSelection()                                     'Clear previous selection
                        ResultsGV.CurrentCell = ResultsGV.Rows(hti.RowIndex).Cells(0) 'Set the current cell 
                        ResultsGV.Rows(hti.RowIndex).Selected = True                   'Do the selection
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ViewHeroScreenshotsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewHeroScreenshotsToolStripMenuItem.Click
        Try
            ResetSearchCriteria()
            LookupHeroNameTXT.Text = ResultsGV.SelectedRows(0).Cells(0).FormattedValue
            GetResults()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ViewPB_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ViewPB.DoubleClick
        Globals.PbZoomSender = "PBLookup"
        LookupFormZoom.Show()
    End Sub

End Class