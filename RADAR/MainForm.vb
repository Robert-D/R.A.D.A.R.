Imports System.Windows
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Net.Mail
Imports System.Xml
Imports System.Data.SQLite

Public Class MainForm

#Region "Global Variables"
    Dim spath As String = Application.StartupPath()
    Dim msg As String
    Dim webMsg As String
    Dim foMsg As String 'Form open background worker error msg var
    Dim progbar As Integer
    Dim progbarmax As Integer
    Dim stat As String
    Dim revwaitingcnt As Integer
    Dim showBalloon As Boolean = True
    Private currentFileIndex As Integer
    Dim foundsuspicious As Integer
    Dim susdt As DataTable
    Private mouseIsDown As Boolean = False
    Private firstPoint As Point

    '============ Cassini Web Server Variables ===============
    Private server As CassiniVB.Server
    Public Property Port() As Integer
    Public Property VirtRoot() As String = "/"
    Public Property WebPath() As String
    '=========================================================
#End Region

#Region "Main Form"

    Function ExistsInDB(ByVal ImgNum As String, ByVal Guid As String, ByVal timestamp As String) As Boolean
        Dim RecExists As Boolean = True
        Try
            Dim cnn As New SQLiteConnection(Globals.RadarCS)
            cnn.Open()
            Dim mycommand As New SQLiteCommand(cnn)
            mycommand.CommandText = "SELECT PBSSID FROM MasterPBSS WHERE (ImageNum = '" & ImgNum & "') AND (GUID = '" & Guid & "') AND (ImageDate = '" & timestamp & "')"
            Dim reader As SQLiteDataReader = mycommand.ExecuteReader()
            If reader.HasRows = False Then
                RecExists = False
            End If

            reader.Close()
            cnn.Close()

        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": SQLite Error - Could not verify if record exists: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            msg &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try

        Return RecExists
    End Function

    Function ExistsOnWeb(ByVal URL As String, ByVal AuthReq As Boolean, ByVal AuthUser As String, ByVal AuthPass As String) As Boolean


        Dim fileExists As Boolean = False

        Try
            'Check if the image file exists
            Dim objResponse As WebResponse
            Dim objRequest As WebRequest = System.Net.HttpWebRequest.Create(URL)
            If AuthReq = True Then
                objRequest.Credentials = New NetworkCredential(AuthUser, AuthPass)
            End If
            Dim sr As StreamReader
            objResponse = objRequest.GetResponse()
            sr = New StreamReader(objResponse.GetResponseStream())

            If sr.ReadLine().Contains("img src") Then
                fileExists = True
            End If

            sr.Close()
            objResponse.Close()
        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Could not verify if web file exists: " & URL & ": "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            msg &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try
        Return fileExists

    End Function

    Sub DownloadPBSS(ByVal PbsvssURL As String, ByVal AuthReq As Boolean, ByVal AuthUser As String, ByVal AuthPass As String, ByVal ScanCount As Integer, ByVal ServerName As String, ByVal ServerID As String)
        'Setup progress bar
        progbar = 0
        progbarmax = ScanCount + 1
        stat = "Status: Downloading new PBSS from: " & ServerName
        ScanPBSSBGW.ReportProgress(1)
        Try

            Dim imgnum, hero, guid, timestamp As String
            Dim objResponse As WebResponse
            Dim objRequest As WebRequest = System.Net.HttpWebRequest.Create(PbsvssURL)
            If AuthReq = True Then
                objRequest.Credentials = New NetworkCredential(AuthUser, AuthPass)
            End If

            Dim sr As StreamReader
            objResponse = objRequest.GetResponse()
            sr = New StreamReader(objResponse.GetResponseStream())
            'result = sr.ReadToEnd()

            Dim si, ei As Integer

            Dim FileData As String = sr.ReadToEnd

            Dim Lines() As String = FileData.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

            Dim start As Integer = Lines.Length - PBSSScanCount.Value
            If Lines.Length > 20000 Then
                msg &= Now().ToString & ": The Pbsvss.htm file on " & ServerName & " is getting too big and could be slowing the download process. Delete it from your server's web interface to speed things up a bit =)" & vbCrLf
            End If
            For i As Integer = 1 To Lines.Length

                'Only process the last X records
                If i > start Then

                    Dim curline As String = Lines(i - 1)

                    'Parse the file and read the fields into variables
                    Try
                        'Set Hero
                        si = curline.IndexOf("""") + 1
                        ei = curline.LastIndexOf("""")
                        hero = curline.Substring(si, ei - si)

                        'Set GUID
                        si = curline.Length - 57 'curline.IndexOf("GUID=") + 5
                        'ei = curline.IndexOf("(-) [")
                        guid = curline.Substring(si, 32)

                        'Set Timestamp
                        si = curline.Length - 20 'curline.IndexOf("[") + 1
                        'ei = curline.LastIndexOf("]")
                        timestamp = curline.Substring(si, 19)

                        'Set ImgNum
                        si = curline.IndexOf("_blank>") + 7
                        ei = curline.IndexOf("</a> ")
                        imgnum = curline.Substring(si, ei - si)

                    Catch ex As Exception
                        Dim exMsg As String
                        exMsg = Now().ToString & ": Error parsing pbsvss.htm fields: " & vbCrLf & curline
                        While ex IsNot Nothing
                            exMsg &= ex.Message
                            ex = ex.InnerException
                        End While
                        msg &= exMsg & vbCrLf
                        Globals.WriteLog(exMsg)
                    End Try

                    'Make sure the file has not already been downloaded and scanned
                    If ExistsInDB(imgnum, guid, timestamp.Replace(".", "-")) = False Then
                        If ExistsOnWeb(Replace(PbsvssURL, "pbsvss.htm", "pb") & imgnum & ".htm", AuthReq, AuthUser, AuthPass) = True Then

                            'Download the file
                            Dim Client As New WebClient
                            Try
                                If AuthReq = True Then
                                    Client.Credentials = New NetworkCredential(AuthUser, AuthPass)
                                End If
                                Client.DownloadFile(Replace(PbsvssURL, "pbsvss.htm", "pb") & imgnum & ".png", spath & "\StagingImages\pb" & imgnum & ".png")
                                Client.Dispose()

                                Dim StoreFileName As String = DateTime.Now.ToString("yyyyMMdd") & "_" & DateTime.Now.ToString("HHmmss") & "_pb" & imgnum & ".png"

                                'Insert the record into the database
                                Dim db As SQLiteDatabase = New SQLiteDatabase()
                                Dim data As New Dictionary(Of [String], [String])()
                                data.Add("ServerID", ServerID)
                                data.Add("ImageNum", imgnum)
                                data.Add("HeroName", hero)
                                data.Add("GUID", guid)
                                data.Add("ImageDate", timestamp.Replace(".", "-"))
                                data.Add("IsBlack", "0")
                                data.Add("IsCropped", "0")
                                data.Add("IsPink", "0")
                                data.Add("IsNormal", "0")
                                data.Add("ScreenCapFailed", "0")
                                data.Add("ReviewFlag", "0")
                                data.Add("Deleted", "0")
                                data.Add("IsCheater", "0")
                                data.Add("ColorFilterCount", "0")
                                data.Add("ImageName", StoreFileName)
                                data.Add("ProcessedDate", Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                data.Add("ScanCompleted", "N")
                                data.Add("MD5Sig", Globals.MD5CalcFile(spath & "\StagingImages\pb" & imgnum & ".png"))
                                Try
                                    db.Insert("MasterPBSS", data)
                                Catch ex As Exception
                                    Dim exMsg As String
                                    exMsg = Now().ToString & ": Cound not insert image record into database " & imgnum & ".png: "
                                    While ex IsNot Nothing
                                        exMsg &= ex.Message
                                        ex = ex.InnerException
                                    End While
                                    msg &= exMsg & vbCrLf
                                    Globals.WriteLog(exMsg)
                                End Try

                                'Copy the file to the store folder
                                Try
                                    If File.Exists(spath & "\StagingImages\pb" & imgnum & ".png") Then
                                        File.Copy(spath & "\StagingImages\pb" & imgnum & ".png", spath & "\Store\PBSS\" & StoreFileName)
                                    End If
                                Catch ex As Exception
                                    Dim exMsg As String
                                    exMsg = Now().ToString & ": Could not copy file " & imgnum & ".png to Store: "
                                    While ex IsNot Nothing
                                        exMsg &= ex.Message
                                        ex = ex.InnerException
                                    End While
                                    msg &= exMsg & vbCrLf
                                    Globals.WriteLog(exMsg)
                                End Try

                            Catch ex As Exception
                                Dim exMsg As String
                                exMsg = Now().ToString & ": Could not download " & imgnum & ".png: "
                                While ex IsNot Nothing
                                    exMsg &= ex.Message
                                    ex = ex.InnerException
                                End While
                                msg &= exMsg & vbCrLf
                                Globals.WriteLog(exMsg)
                                Client.Dispose()
                            End Try
                        End If
                    End If
                    progbar += 1
                    ScanPBSSBGW.ReportProgress(1)

                End If
            Next
            objResponse.Close()
            sr.Close()
        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error opening/reading pbsvss.htm file: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            msg &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try
    End Sub

    Sub DeleteStagingPBSS()
        Try

            Dim DirInfo As New DirectoryInfo(spath & "\StagingImages\")
            Dim Files As FileInfo() = DirInfo.GetFiles()

            'Setup the progress bar
            progbar = 0
            progbarmax = 0 + 1
            stat = "Status: Cleaning up old files"

            For Each F In Files
                If F.Extension = ".png" Then
                    progbarmax += 1
                End If
            Next
            ScanPBSSBGW.ReportProgress(1)

            For Each F In Files
                If F.Extension = ".png" Or F.Extension = ".jpg" Or F.Extension = ".txt" Then
                    F.Delete()
                    progbar += 1
                    ScanPBSSBGW.ReportProgress(1)
                End If
            Next

        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error deleting staging pbss files: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            msg &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)


        End Try
    End Sub

    Sub ScanPBSS()

        'Get dismissed heroes
        Dim disdb As SQLiteDatabase = New SQLiteDatabase()
        Dim disdt As DataTable = disdb.GetDataTable("SELECT HeroName FROM DismissPBSS WHERE (DismissExpire > datetime('now', 'localtime'))")

        Try
            Dim db As SQLiteDatabase = New SQLiteDatabase()
            Dim dt As DataTable = db.GetDataTable("SELECT PBSSID, ImageName, ImageNum, HeroName FROM MasterPBSS WHERE (ScanCompleted = 'N')")

                'Setup the progress bar
            progbar = 0
            progbarmax = dt.Rows.Count + 1
            stat = "Status: Scanning PBSS files."
            ScanPBSSBGW.ReportProgress(1)

                'Get the colors from filter tab
            Dim countList As New ArrayList
            Dim colList As New ArrayList
            For Each row As DataGridViewRow In ColorFilterGridView.Rows

                Dim r As Integer = ColorFilterGridView.Rows(row.Index).Cells(1).Value
                Dim g As Integer = ColorFilterGridView.Rows(row.Index).Cells(2).Value
                Dim b As Integer = ColorFilterGridView.Rows(row.Index).Cells(3).Value
                Dim a As Integer = ColorFilterGridView.Rows(row.Index).Cells(4).Value
                Dim c As Color = Color.FromArgb(a, r, g, b)
                colList.Add(c.ToArgb)
                countList.Add("0")
            Next


            For Each row As DataRow In dt.Rows
                Dim f As String = row("ImageName")
                Dim imgnum As String = row("ImageNum")
                Dim pbssid As Integer = row("PBSSID")
                Dim HeroName As String = row("HeroName")

                    'Dim DistinctColor As New Dictionary(Of Integer, Integer)

                    'If F.Extension = ".png" Then
                Dim picpath As String = spath & "\Store\PBSS\" & f
                Dim thresholdcnt As Integer = 0


                Dim curPic As New Bitmap(picpath)

                    'Don't scan the botton section of the images for threats.
                If curPic.Height > 87 Then
                    For xpix As Integer = 0 To curPic.Width - 1
                        For ypix As Integer = 0 To curPic.Height - 86
                            Dim curPix As Color = curPic.GetPixel(xpix, ypix)

                            For i = 0 To colList.Count - 1
                                If curPix.ToArgb = CType(colList.Item(i), Integer) Then
                                    thresholdcnt += 1
                                    End If
                            Next

                                'If SmartScanCB.Checked = True Then
                                '    If Not DistinctColor.ContainsKey(curPix.ToArgb) Then
                                '        DistinctColor.Add(curPix.ToArgb, 1)
                                '    Else
                                '        DistinctColor(curPix.ToArgb) += 1
                                '    End If
                                'End If

                        Next
                    Next
                    End If


                    'Run tests
                Dim IsCropped As Integer = 0
                Dim IsBlack As Integer = 0
                Dim IsPink As Integer = 0
                Dim ReviewFlag As Integer = 0
                Dim ScreenCapFailed As Integer = 0
                Dim IsNormal As Integer = 0

                    ''Determine if the image should be flagged from SmartScan
                    'If SmartScanCB.Checked = True Then
                    '    Dim pair As KeyValuePair(Of Integer, Integer)
                    '    For Each pair In DistinctColor
                    '        If pair.Value > 15 And pair.Value < 300 Then
                    '            ReviewFlag = 1
                    '            msg &= "Color:" & pair.Key.ToString & "  Count:" & pair.Value.ToString & vbCrLf
                    '        End If
                    '    Next
                    '    DistinctColor.Clear()
                    'End If

                    'Check to see if its cropped
                If curPic.Height <= 150 Then
                    IsCropped = 1
                    End If

                    'Check to see if it failed
                If IsCropped = 0 Then
                    Dim curPix As Color = curPic.GetPixel(15, curPic.Height - 14)
                    If curPix.R = 0 And curPix.G = 0 And curPix.B = 0 And curPix.A = 255 Then
                        ScreenCapFailed = 1
                        End If
                    End If

                    'Check to see if its black
                If IsCropped = 0 And ScreenCapFailed = 0 Then
                    Dim PixCount As Integer = 0
                    For xpix As Integer = 0 To curPic.Width - 1
                        Dim curPix As Color = curPic.GetPixel(xpix, 150)
                        If curPix.R = 0 And curPix.G = 0 And curPix.B = 0 And curPix.A = 255 Then
                            PixCount += 1
                            End If
                    Next
                    If PixCount >= 350 Then
                        IsBlack = 1
                        End If
                    End If

                    'Check to see if its pink
                If IsCropped = 0 Then
                    Dim PixCount As Integer = 0
                    For xpix As Integer = 0 To curPic.Width - 1
                        Dim curPix As Color = curPic.GetPixel(xpix, 150)
                        If curPix.R = 255 And curPix.G = 0 And curPix.B = 255 And curPix.A = 255 Then
                            PixCount += 1
                            End If
                    Next
                    If PixCount >= 100 Then
                        IsPink = 1
                        End If
                    End If


                If IsCropped = 0 And IsBlack = 0 And IsPink = 0 And ScreenCapFailed = 0 And ReviewFlag = 0 Then
                    IsNormal = 1
                    End If
                curPic.Dispose()

                If thresholdcnt >= ThresholdStartNum.Value And thresholdcnt <= ThresholdEndNum.Value Then
                        'Now make sure the player is not in the dismissed datatable
                    Dim dismissimg As Boolean = False

                    For Each r As DataRow In disdt.Rows
                        If r("HeroName").ToString = HeroName Then
                            dismissimg = True
                        End If
                    Next

                    If dismissimg = False Then
                        foundsuspicious += 1
                        ReviewFlag = 1

                        msg &= Now().ToString & "- Suspicious PBSS Found: pb" & imgnum & ".png" & vbCrLf
                    End If
                    'End If
                End If
                    'End If

                    'Update the record
                Try

                    Dim cnn As New SQLiteConnection(Globals.RadarCS)
                    cnn.Open()
                    Dim mycommand As New SQLiteCommand(cnn)
                    mycommand.CommandText = "UPDATE MasterPBSS SET IsBlack = @IsBlack, IsCropped = @IsCropped, IsPink = @IsPink, IsNormal = @IsNormal, " & _
                        "ScreenCapFailed = @ScreenCapFailed, ReviewFlag = @ReviewFlag, ColorFilterCount = @ColorFilterCount WHERE (PBSSID = @PBSSID)"
                    mycommand.Parameters.Add("IsBlack", DbType.Int32).Value = IsBlack
                    mycommand.Parameters.Add("IsCropped", DbType.Int32).Value = IsCropped
                    mycommand.Parameters.Add("IsPink", DbType.Int32).Value = IsPink
                    mycommand.Parameters.Add("ScreenCapFailed", DbType.Int32).Value = ScreenCapFailed
                    mycommand.Parameters.Add("ReviewFlag", DbType.Int32).Value = ReviewFlag
                    mycommand.Parameters.Add("IsNormal", DbType.Int32).Value = IsNormal
                    mycommand.Parameters.Add("ImageNum", DbType.String).Value = imgnum
                    mycommand.Parameters.Add("ImageName", DbType.String).Value = f
                    mycommand.Parameters.Add("PBSSID", DbType.Int32).Value = pbssid
                    mycommand.Parameters.Add("ColorFilterCount", DbType.Int32).Value = thresholdcnt

                    Dim rowsUpdated As Integer = mycommand.ExecuteNonQuery()
                    cnn.Close()
                Catch ex As Exception
                    Dim exMsg As String
                    exMsg = Now().ToString & ": Error updating database while scanning: "
                    While ex IsNot Nothing
                        exMsg &= ex.Message
                        ex = ex.InnerException
                        End While
                    msg &= exMsg & vbCrLf
                    Globals.WriteLog(exMsg)
                    End Try
                progbar += 1
                ScanPBSSBGW.ReportProgress(1)
            Next
        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error scanning pbss file: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
                End While
            msg &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
            End Try

            'Mark any dismissed hero images as review completed.
        Dim db3 As SQLiteDatabase = New SQLiteDatabase()
        db3.ExecuteNonQuery("UPDATE MasterPBSS SET ReviewCompleted = 'Y', IsCheater = 0, ScanCompleted = 'Y' WHERE (HeroName IN(SELECT HeroName FROM DismissPBSS WHERE (DismissExpire > datetime('now', 'localtime')))) AND (ScanCompleted = 'N')")

            'Send emails
        If EnableEmailCHK.Checked Then

            Dim db4 As SQLiteDatabase = New SQLiteDatabase()
            Dim dt4 As DataTable = db4.GetDataTable("SELECT PBSSID, ImageName, ImageNum FROM MasterPBSS WHERE (ScanCompleted = 'N') AND (ReviewCompleted = 'N') AND (ReviewFlag = 1)")

            progbar = 0
            progbarmax = dt4.Rows.Count + 1
            stat = "Status: Emailing Suspicious Emails"
            ScanPBSSBGW.ReportProgress(1)


                'Check to see if an email should be sent
            For Each row As DataRow In dt4.Rows
                Dim f As String = row("ImageName")
                Dim picpath As String = spath & "\Store\PBSS\" & f

                Try
                    SendMail("NoReply@pb-radar.net", SMTPSendToTXT.Text, "", "", "Suspicious PBSS Found", "A suspicious PBSS has been found and needs review.", "N", picpath, SMTPSSLReqCB.Checked)
                Catch ex As Exception
                    Dim exMsg As String
                    exMsg = Now().ToString & "-Error Sending Email: "
                    While ex IsNot Nothing
                        exMsg &= ex.Message
                        ex = ex.InnerException
                        End While
                    msg &= exMsg & vbCrLf
                    Globals.WriteLog(exMsg)
                    End Try
                progbar += 1
                ScanPBSSBGW.ReportProgress(1)
            Next


            End If

            'Update scan status to completed 
        Dim db5 As SQLiteDatabase = New SQLiteDatabase()
        db5.ExecuteNonQuery("UPDATE MasterPBSS SET ScanCompleted = 'Y' WHERE (ScanCompleted = 'N')")


    End Sub

    Private Sub ToggleScanBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToggleScanBTN.Click
        ToggleScan()
    End Sub

    Sub ToggleScan()
        Try

            If ScanPBSSTimer.Enabled = True Then
                ScanPBSSTimer.Enabled = False
                StatusLAB.Text = "Status: Not Running"
                ToggleScanBTN.Text = "Enable Scanning"
            Else
                ScanPBSSTimer.Enabled = True
                StatusLAB.Text = "Status: Scanning will begin shortly..."
                ToggleScanBTN.Text = "Disable Scanning"
                ScanPBSSTimer.Start()
                ScanPBSSBGW.RunWorkerAsync()
            End If
        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error starting/stopping back ground worker scan: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            LogRTB.Text &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try
    End Sub

    Private Sub ScanPBSSBGW_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ScanPBSSBGW.DoWork
        Try
            foundsuspicious = 0
            Dim db As SQLiteDatabase = New SQLiteDatabase()
            Dim dt As DataTable = db.GetDataTable("SELECT * FROM Servers")
            For Each row As DataRow In dt.Rows
                Dim ServerName As String = row("ServerName")
                Dim ServerID As String = row("ServerID")
                Dim PbsvssURL As String = row("PbsvssURL")
                Dim AuthEnabled As Boolean = row("PbsvssAuthEnabled")
                Dim AuthUser As String = row("PbsvssAuthUser")
                Dim AuthPass As String = row("PbsvssAuthPass")

                DeleteStagingPBSS()
                DownloadPBSS(PbsvssURL, AuthEnabled, AuthUser, AuthPass, PBSSScanCount.Value, ServerName, ServerID)
                ScanPBSS()

            Next

        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error looping through servers: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            msg &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try



    End Sub

    Private Sub ScanPBSSBGW_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles ScanPBSSBGW.ProgressChanged
        Try
            ProgressBar1.Value = progbar
            ProgressBar1.Maximum = progbarmax
            StatusLAB.Text = stat
        Catch ex As Exception
            'Dim exMsg As String
            'exMsg = Now().ToString & ": Error setting progress bar values: "
            'While ex IsNot Nothing
            '    exMsg &= ex.Message
            '    ex = ex.InnerException
            'End While
            'LogRTB.Text &= exMsg & vbCrLf
            'Globals.WriteLog(exMsg)
        End Try
    End Sub

    Private Sub ScanPBSSBGW_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ScanPBSSBGW.RunWorkerCompleted
        If foundsuspicious > 0 Then
            If PlaySoundCB.Checked Then
                My.Computer.Audio.Play(spath & "\Settings\notify.wav")
            End If
            If RestoreWindowCB.Checked Then
                Me.TopMost = True
                Me.Show()


                Me.BringToFront()
            End If
        End If
        StatusLAB.Text = "Status: Scan finished " & DateTime.Now & ". Scanning again soon."
        LogRTB.Text &= msg
        msg = ""
        ProgressBar1.Value = 0
        RefreshSuspicious()

        'Free up memory by collecting garbage
        If FormOpenBGW.IsBusy = False And WebUpdateBGW.IsBusy = False And AltAccountsBGW.IsBusy = False Then
            GC.Collect()
        End If

    End Sub

    Private Sub ScanPBSSTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanPBSSTimer.Tick
        ScanPBSSTimer.Interval = PBSSTimeCount.Value * 60 * 1000
        If ScanPBSSBGW.IsBusy = False Then
            ScanPBSSBGW.RunWorkerAsync()
        End If
    End Sub

    Sub SendMail(ByVal from As String, ByVal recipient As String, ByVal bcc As String, ByVal cc As String, _
        ByVal subject As String, ByVal body As String, ByVal ishtml As String, ByVal attachment As String, ByVal ssl As Boolean)

        ' Instantiate a new instance of MailMessage
        Dim mMailMessage As New MailMessage()

        ' Set the sender address of the mail message
        mMailMessage.From = New MailAddress(from)
        ' Set the recepient address of the mail message
        mMailMessage.To.Add(New MailAddress(recipient))

        ' Check if the bcc value is null or an empty string
        If Not bcc Is Nothing And bcc <> String.Empty Then
            ' Set the Bcc address of the mail message
            mMailMessage.Bcc.Add(New MailAddress(bcc))
        End If

        ' Check if the cc value is null or an empty value
        If Not cc Is Nothing And cc <> String.Empty Then
            ' Set the CC address of the mail message
            mMailMessage.CC.Add(New MailAddress(cc))
        End If

        ' Set the subject of the mail message
        mMailMessage.Subject = subject
        ' Set the body of the mail message
        mMailMessage.Body = body

        ' Secify the format of the body as HTML
        If ishtml = "Y" Then
            mMailMessage.IsBodyHtml = True
        Else
            mMailMessage.IsBodyHtml = False
        End If

        ' Check to see if there are any attachments
        If attachment <> "" Then
            mMailMessage.Attachments.Add(New Attachment(attachment))
        End If

        ' Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal
        ' Instantiate a new instance of SmtpClient
        Dim mSmtpClient As New SmtpClient()
        Dim basicAuthenticationInfo As New System.Net.NetworkCredential(SMTPUserTXT.Text, SMTPPassTXT.Text)
        mSmtpClient.Host = SMTPServerTXT.Text
        mSmtpClient.UseDefaultCredentials = False
        mSmtpClient.Port = SMTPPortTXT.Text
        mSmtpClient.Credentials = basicAuthenticationInfo
        'Check to see if the smtp server uses SSL
        If ssl = True Then
            mSmtpClient.EnableSsl = True
        End If

        ' Send the mail message
        mSmtpClient.Send(mMailMessage)

        mMailMessage.Attachments.Dispose()
        mMailMessage.Dispose()
        mSmtpClient.Dispose()

    End Sub

    Private Sub SendTestEmailBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendTestEmailBTN.Click
        Try
            SendMail("test@hoofshideaway.net", SMTPSendToTXT.Text, "", "", "Test Message", "You have successfully configured the email settings.", "N", spath & "\Settings\emailtestPBSS.png", SMTPSSLReqCB.Checked)
            MsgBox("Email was sent! Please check your inbox to verify")
        Catch ex As Exception
            Dim msgexp As String = ""
            While ex IsNot Nothing
                msgexp &= ex.Message
                ex = ex.InnerException
            End While
            MsgBox("Could not send email:" & msgexp)
        End Try
    End Sub

    Private Sub PBSSTimeCount_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ScanPBSSTimer.Interval = PBSSTimeCount.Value * 60 * 1000
    End Sub

    Sub SetTheme()
        Dim Img As New System.Drawing.Bitmap(My.Resources.bg)

        Dim g As Graphics = Me.CreateGraphics
        If g.DpiX.ToString() = "96" And g.DpiY.ToString() = "96" Then
            'Normal DPI is being used
            'Setup custom form theme
            'Setup the inner form size to the size of the background image
            Dim cs As New Size(649, 616)
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


            Me.FormBorderStyle = Forms.FormBorderStyle.None
        Else
            'Custom DPI is being used
            Me.Text &= " - Compatibility View"
            Dim color2 As Color = Img.GetPixel(350, 200)
            Me.BackgroundImage = My.Resources.CompatibilityBG
            Me.BackgroundImageLayout = ImageLayout.None
            Me.BackColor = color2
            ReviewPB.SizeMode = PictureBoxSizeMode.StretchImage
            MinimizePB.BackColor = color2
            ExitPB.BackColor = color2
        End If
        g.Dispose()


    End Sub

    Sub LoadColorFilter()

        Try
            Dim filePath As String = (spath & "\Settings\Settings.xml")
            Dim ColorFilterDS As New DataSet()
            ColorFilterDS.ReadXml(filePath)
            With ColorFilterGridView ' the datagridview
                .DataSource = ColorFilterDS
                .DataMember = "ColorFilter"
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                '.AutoSize = True
                .EditMode = DataGridViewEditMode.EditOnEnter
            End With
        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error loading color filter xml: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            LogRTB.Text &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try

    End Sub

    Private Sub ColorFilterGridView_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorFilterGridView.SelectionChanged
        SetSampleFilterColors()
    End Sub

    Sub SetSampleFilterColors()
        For Each row As DataGridViewRow In ColorFilterGridView.Rows

            Try
                Dim r As Integer = ColorFilterGridView.Rows(row.Index).Cells(1).Value
                Dim g As Integer = ColorFilterGridView.Rows(row.Index).Cells(2).Value
                Dim b As Integer = ColorFilterGridView.Rows(row.Index).Cells(3).Value
                Dim a As Integer = ColorFilterGridView.Rows(row.Index).Cells(4).Value

                Dim c As Color
                c = Color.FromArgb(a, r, g, b)
                ColorFilterGridView.Rows(row.Index).Cells(0).Style.BackColor = c
            Catch ex As Exception
                Dim exMsg As String
                exMsg = Now().ToString & ": Error setting sample filter color: "
                While ex IsNot Nothing
                    exMsg &= ex.Message
                    ex = ex.InnerException
                End While
                LogRTB.Text &= exMsg = vbCrLf
                Globals.WriteLog(exMsg)
            End Try
        Next
    End Sub

    Private Sub ColorFilterGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles ColorFilterGridView.DataBindingComplete
        If ColorFilterGridView.Rows.Count > 1 Then
            SetSampleFilterColors()
        End If

        'ColorFilterGridView.Rows(ColorFilterGridView.Rows.Count - 3).Selected = True
    End Sub

    Private Sub DeleteColorFilterRowBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteColorFilterRowBTN.Click
        Try
            For Each item As DataGridViewRow In ColorFilterGridView.SelectedRows
                If item.Index <= ColorFilterGridView.Rows.Count - 1 Then
                    ColorFilterGridView.Rows.RemoveAt(item.Index)
                    Dim branchDS As New DataSet
                    branchDS = ColorFilterGridView.DataSource '  BindingSource1.DataSource
                    branchDS.WriteXml(spath & "\Settings\Settings.xml")
                End If
            Next
        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error deleting color filter row: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            LogRTB.Text &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try

    End Sub

    Private Sub ColorFilterGridView_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles ColorFilterGridView.CellValidating
        Try
            ColorFilterGridView.Rows(e.RowIndex).ErrorText = ""
            Dim newInteger As Integer

            ' Don't try to validate the 'new row' until finished 
            ' editing since there
            ' is not any point in validating its initial value.
            If e.FormattedValue <> "" Then


                If ColorFilterGridView.Rows(e.RowIndex).IsNewRow Then
                    Return
                End If
                If Not Integer.TryParse(e.FormattedValue.ToString(), newInteger) OrElse newInteger > 255 OrElse newInteger < 0 Then
                    e.Cancel = True
                    ColorFilterGridView.Rows(e.RowIndex).ErrorText = "The value must be between 0 and 255."
                End If
            End If
        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error validating cell color value: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            LogRTB.Text &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try


    End Sub

    Private Sub SaveSettingsBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveSettingsBTN.Click
        Try
            Dim colorsDS As New DataSet
            colorsDS = ColorFilterGridView.DataSource '  BindingSource1.DataSource
            colorsDS.WriteXml(spath & "\Settings\Settings.xml")


            Dim cnn As New SQLiteConnection(Globals.RadarCS)
            cnn.Open()
            Dim mycommand As New SQLiteCommand(cnn)
            mycommand.CommandText = "UPDATE Settings SET ScanCount = @ScanCount, ScanInterval = @ScanInt, StoreDuration = @StoreDur, SmtpEnabled = @sEnabled, " & _
                "SmtpServer = @sServer, SmtpPort = @sPort, SmtpAuthUser = @sUser, SmtpAuthPass = @sPass, SmtpSendTo = @sSendTo, SmtpReqSSL = @sSSL, " & _
                "CFPixelStart = @ps, CFPixelEnd = @pe, ScanAuto = @ScanAuto, PlaySound = @PlaySound, DeleteCheaters = @dc, DeleteSuspicious = @ds, " & _
                "RestoreWindow = @rw, PostStats = @PostStats, PostPBSS = @PostPBSS, WebServerEnabled = @WebServerEnabled, WebPortNum = @WebPortNum, " & _
                "WebPass = @WebPass, WebDisplayLimit = @WebDisplayLimit, WebBanner = @WebBanner"


            mycommand.Parameters.Add("ScanCount", DbType.Int32).Value = PBSSScanCount.Value
            mycommand.Parameters.Add("ScanInt", DbType.Int32).Value = PBSSTimeCount.Value
            mycommand.Parameters.Add("StoreDur", DbType.Int32).Value = PbssStoreCount.Value
            mycommand.Parameters.Add("sEnabled", DbType.Boolean).Value = EnableEmailCHK.Checked
            mycommand.Parameters.Add("sServer", DbType.String).Value = SMTPServerTXT.Text
            mycommand.Parameters.Add("sPort", DbType.Int32).Value = SMTPPortTXT.Text
            mycommand.Parameters.Add("sUser", DbType.String).Value = SMTPUserTXT.Text
            mycommand.Parameters.Add("sPass", DbType.String).Value = SMTPPassTXT.Text
            mycommand.Parameters.Add("sSendTo", DbType.String).Value = SMTPSendToTXT.Text
            mycommand.Parameters.Add("sSSL", DbType.Boolean).Value = SMTPSSLReqCB.Checked
            mycommand.Parameters.Add("ps", DbType.Int32).Value = ThresholdStartNum.Value
            mycommand.Parameters.Add("pe", DbType.Int32).Value = ThresholdEndNum.Value
            mycommand.Parameters.Add("ScanAuto", DbType.Boolean).Value = ScanAutoCB.Checked
            mycommand.Parameters.Add("PlaySound", DbType.Boolean).Value = PlaySoundCB.Checked
            mycommand.Parameters.Add("dc", DbType.Boolean).Value = DeleteCheatersCB.Checked
            mycommand.Parameters.Add("ds", DbType.Boolean).Value = DeleteSuspiciousCB.Checked
            mycommand.Parameters.Add("rw", DbType.Boolean).Value = RestoreWindowCB.Checked
            mycommand.Parameters.Add("PostStats", DbType.Boolean).Value = PostStatsCB.Checked
            mycommand.Parameters.Add("PostPBSS", DbType.Boolean).Value = PostSSCB.Checked
            mycommand.Parameters.Add("WebServerEnabled", DbType.Boolean).Value = EnableWebServerCHK.Checked
            mycommand.Parameters.Add("WebPortNum", DbType.Int32).Value = WebPortNUM.Value
            mycommand.Parameters.Add("WebPass", DbType.String).Value = WebPassTXT.Text
            mycommand.Parameters.Add("WebDisplayLimit", DbType.Int32).Value = WebDisplayLimitNUM.Value
            mycommand.Parameters.Add("WebBanner", DbType.String).Value = WebBannerTXT.Text
            Dim rowsUpdated As Integer = mycommand.ExecuteNonQuery()

            cnn.Close()

        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error saving application settings: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            LogRTB.Text &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try

    End Sub

    Private Sub PrevImgBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrevImgBTN.Click
        Advance(-1)
        DismissDurationCB.SelectedIndex = 0
        ShowCurrentFile()
    End Sub

    Private Sub NextImgBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextImgBTN.Click
        Advance(1)
        DismissDurationCB.SelectedIndex = 0
        ShowCurrentFile()
    End Sub

    Private Sub Advance(ByVal delta As Integer)
        If susdt.Rows.Count > 0 Then
            currentFileIndex = ((currentFileIndex + susdt.Rows.Count) + delta) Mod susdt.Rows.Count
        Else
            currentFileIndex = -1
        End If
    End Sub

    Private Sub RefreshSuspicious()

        'Dim di As DirectoryInfo = New DirectoryInfo(path)

        'files = (From c In di.GetFiles()
        '        Where IsFileSupported(c)
        '        Select c).ToList()
        Dim db As SQLiteDatabase = New SQLiteDatabase()
        susdt = db.GetDataTable("SELECT PBSSID, ImageName, ImageNum, HeroName FROM MasterPBSS WHERE (ReviewFlag = 1) AND (ReviewCompleted = 'N')")

        If susdt.Rows.Count > 0 Then
            currentFileIndex = 0
            MainTabMenu.SelectedIndex = 0
            ShowCurrentFile()
        Else
            ReviewPB.Image = My.Resources.RADAR_Clear
            SusImgLAB.Text = ""
            SusImageInfoLAB.Text = ""
        End If
        SuspiciousTab.Text = "Suspicious (" & susdt.Rows.Count.ToString & ")"
        DismissDurationCB.SelectedIndex = 0
    End Sub

    Private Sub ShowCurrentFile()
        If currentFileIndex <> -1 Then
            If LookupFormZoom.Visible = True Then
                LookupFormZoom.ViewZoomPB.ImageLocation = spath & "\Store\PBSS\" & susdt.Rows(currentFileIndex).Item("ImageName").ToString
            End If
            ReviewPB.ImageLocation = spath & "\Store\PBSS\" & susdt.Rows(currentFileIndex).Item("ImageName").ToString
            ReviewPB.Tag = susdt.Rows(currentFileIndex).Item("PBSSID").ToString
            SusImgLAB.Text = "pb" & susdt.Rows(currentFileIndex).Item("ImageNum").ToString & ".png"
            SusImageInfoLAB.Text = susdt.Rows(currentFileIndex).Item("HeroName").ToString
        End If
    End Sub

    Private Function IsFileSupported(ByRef file As FileInfo) As Boolean
        Return file.Extension = ".jpg" Or file.Extension = ".png" ' etc
    End Function

    Private Sub ColorFilterGridView_RowValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles ColorFilterGridView.RowValidating
        Try
            ColorFilterGridView.Rows(e.RowIndex).ErrorText = ""
            For i As Integer = 1 To 4
                If ColorFilterGridView.Rows(e.RowIndex).Cells(i).FormattedValue = "" Then
                    e.Cancel = True
                    ColorFilterGridView.Rows(e.RowIndex).ErrorText = "The value must be between 0 and 255."
                End If
            Next
        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error validating row: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            LogRTB.Text &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try

    End Sub

    Private Sub ColorFilterAddColorBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorFilterAddColorBTN.Click
        Try


            Dim myxml As New XmlDocument()
            myxml.Load(spath & "\Settings\Settings.xml")

            Dim myxmlrecord As XmlElement = myxml.CreateElement("ColorFilter")
            Dim myxmlfield As XmlElement

            myxmlfield = myxml.CreateElement("Red")
            myxmlfield.InnerText = ColorFilterRedNUD.Value
            myxmlrecord.AppendChild(myxmlfield)

            myxmlfield = myxml.CreateElement("Green")
            myxmlfield.InnerText = ColorFilterGreenNUD.Value
            myxmlrecord.AppendChild(myxmlfield)

            myxmlfield = myxml.CreateElement("Blue")
            myxmlfield.InnerText = ColorFilterBlueNUD.Value
            myxmlrecord.AppendChild(myxmlfield)

            myxmlfield = myxml.CreateElement("Alpha")
            myxmlfield.InnerText = "255"
            myxmlrecord.AppendChild(myxmlfield)

            myxml.ChildNodes(1).AppendChild(myxmlrecord)

            myxml.Save(spath & "\Settings\Settings.xml")
        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error adding color: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            LogRTB.Text &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try

        LoadColorFilter()

    End Sub

    Private Sub AddServerBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddServerBTN.Click
        Try
            If ServerNameTXT.Text.Trim = "" Or ServerNameTXT.Text.Length < 3 Then
                MessageBox.Show("You must specify a server name at least 3 characters or longer.", "Server Name Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If PbsvssURLTXT.Text.ToLower.Contains("pbsvss.htm") = False Or (PbsvssURLTXT.Text.ToLower.Contains("http://") = False And PbsvssURLTXT.Text.ToLower.Contains("ftp://") = False) Then
                MessageBox.Show("Please enter a valid URL to your server's pbsvss.htm file.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            'Generate a new GUID for the server
            Dim sGUID As String
            sGUID = System.Guid.NewGuid.ToString()

            Dim cnn As New SQLiteConnection(Globals.RadarCS)
            cnn.Open()
            Dim mycommand As New SQLiteCommand(cnn)
            mycommand.CommandText = "INSERT INTO Servers (ServerGUID, ServerName, PbsvssURL, PbsvssAuthEnabled, PbsvssAuthUser, PbsvssAuthPass, ServerIP, RconPort, RconPass) " & _
                "VALUES (@ServerGUID, @ServerName, @URL, @PbsvssAuthEnabled, @PbsvssAuthUser, @PbsvssAuthPass, @ServerIP, @RconPort, @RconPass)"

            mycommand.Parameters.Add("ServerGUID", DbType.String).Value = sGUID
            mycommand.Parameters.Add("ServerName", DbType.String).Value = ServerNameTXT.Text
            mycommand.Parameters.Add("URL", DbType.String).Value = PbsvssURLTXT.Text
            mycommand.Parameters.Add("PbsvssAuthEnabled", DbType.Boolean).Value = PbsvssAuthReqCB.Checked
            mycommand.Parameters.Add("PbsvssAuthUser", DbType.String).Value = PbsvssAuthUserTXT.Text
            mycommand.Parameters.Add("PbsvssAuthPass", DbType.String).Value = PbsvssAuthPassTXT.Text
            mycommand.Parameters.Add("ServerIP", DbType.String).Value = ServerIPTXT.Text
            mycommand.Parameters.Add("RconPort", DbType.Int32).Value = ServerRconPortNUM.Value
            mycommand.Parameters.Add("RconPass", DbType.String).Value = ServerRconPassTXT.Text

            Dim rowsUpdated As Integer = mycommand.ExecuteNonQuery()
            cnn.Close()

            'Clear everything after insert
            PbsvssURLTXT.Text = ""
            PbsvssAuthPassTXT.Text = ""
            PbsvssAuthUserTXT.Text = ""
            PbsvssAuthReqCB.Checked = False
            ServerNameTXT.Text = ""
            ServerIPTXT.Text = ""
            ServerRconPassTXT.Text = ""
            ServerRconPortNUM.Value = 0

        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Could not add server to the database: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            msg &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try

        BindServersGV()

    End Sub

    Private Sub DeleteServerBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteServerBTN.Click
        If ServersGV.SelectedRows.Count > 0 Then
            Try
                Dim ServerID As Integer = ServersGV.SelectedRows(0).Cells(0).Value
                Dim db As SQLiteDatabase = New SQLiteDatabase()
                db.ExecuteNonQuery("DELETE FROM Servers WHERE (ServerID = " & ServerID & ")")

                BindServersGV()
            Catch ex As Exception
                Dim exMsg As String
                exMsg = Now().ToString & ": Could not delete server from the database: "
                While ex IsNot Nothing
                    exMsg &= ex.Message
                    ex = ex.InnerException
                End While
                msg &= exMsg & vbCrLf
                Globals.WriteLog(exMsg)
            End Try
        End If
    End Sub

    Sub BindServersGV()
        Dim db As SQLiteDatabase = New SQLiteDatabase()
        ServersGV.DataSource = db.GetDataTable("SELECT * FROM Servers")
        ServersGV.Columns("ServerGUID").Visible = False
        ServersGV.Columns("ServerID").Visible = False

    End Sub

    Sub SetSettings()
        Try
            Process.GetCurrentProcess.PriorityClass = ProcessPriorityClass.BelowNormal
            Dim db As SQLiteDatabase = New SQLiteDatabase()
            Dim dt As DataTable = db.GetDataTable("SELECT * FROM Settings")
            For Each row As DataRow In dt.Rows
                SMTPServerTXT.Text = row("SmtpServer").ToString()
                SMTPPortTXT.Text = row("SmtpPort").ToString
                SMTPUserTXT.Text = row("SmtpAuthUser").ToString
                SMTPPassTXT.Text = row("SmtpAuthPass").ToString
                SMTPSendToTXT.Text = row("SmtpSendTo").ToString
                SMTPSSLReqCB.Checked = row("SmtpReqSSL").ToString
                EnableEmailCHK.Checked = row("SmtpEnabled").ToString
                ThresholdEndNum.Value = row("CFPixelEnd").ToString
                ThresholdStartNum.Value = row("CFPixelStart").ToString
                PBSSScanCount.Value = row("ScanCount").ToString
                PBSSTimeCount.Value = row("ScanInterval").ToString
                PbssStoreCount.Value = row("StoreDuration").ToString
                ScanAutoCB.Checked = row("ScanAuto").ToString
                PlaySoundCB.Checked = row("PlaySound").ToString
                DeleteCheatersCB.Checked = row("DeleteCheaters").ToString
                DeleteSuspiciousCB.Checked = row("DeleteSuspicious").ToString
                RestoreWindowCB.Checked = row("RestoreWindow").ToString
                PostStatsCB.Checked = row("PostStats").ToString
                PostSSCB.Checked = row("PostPBSS").ToString
                EnableWebServerCHK.Checked = row("WebServerEnabled")
                WebPortNUM.Value = row("WebPortNum").ToString
                WebPassTXT.Text = row("WebPass").ToString
                WebDisplayLimitNUM.Value = row("WebDisplayLimit").ToString
                WebBannerTXT.Text = row("WebBanner").ToString
            Next

            BindServersGV()
        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error restoring your settings: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            LogRTB.Text &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try
    End Sub

    Public Sub CheckForExistingInstance()
        'Get number of processes of you program
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then

            MessageBox.Show("There is already another instance of R.A.D.A.R running.", "Multiple Instances Forbidden", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Application.Exit()

        End If
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetTheme()
        CheckForExistingInstance()
        NewsBrowser.Navigate("http://www.pb-radar.net/radar-app-news.aspx?ver=" & Me.Text.Substring(11, 3).Replace(".", "-"))
        SetSettings()
        RefreshStats()
        RefreshSuspicious()
        LoadColorFilter()

        'Set the form load time - This will be used to determine which screenshots to upload
        'Process time consuming tasks in the background
        FormOpenBGW.RunWorkerAsync()
        If ScanAutoCB.Checked = True Then
            ToggleScan()
        End If
        If EnableWebServerCHK.Checked = True Then
            StartServer()
        End If

    End Sub

    Sub RefreshStats()

        Dim db As SQLiteDatabase = New SQLiteDatabase()
        Dim dt As DataTable = db.GetDataTable("SELECT SUM(IsBlack) AS Black, SUM(IsCropped) AS Cropped, SUM(IsPink) AS Pink, SUM(ScreenCapFailed) AS Failed, SUM(IsNormal) AS Normal, SUM(ReviewFlag) AS Suspicious, SUM(IsCheater) AS Cheaters FROM MasterPBSS WHERE (Deleted = 0)")
        StoredBreakdownPieChart.Series.Clear()
        StoredBreakdownPieChart.Series.Add("Value")

        For Each row As DataRow In dt.Rows
            StoredBreakdownPieChart.Series("Value").Points.AddXY("Black (" & row("Black") & ")", row("Black"))
            StoredBreakdownPieChart.Series("Value").Points.AddXY("Pink (" & row("Pink") & ")", row("Pink"))
            StoredBreakdownPieChart.Series("Value").Points.AddXY("Cropped (" & row("Cropped") & ")", row("Cropped"))
            StoredBreakdownPieChart.Series("Value").Points.AddXY("Suspicious (" & row("Suspicious") & ")", row("Suspicious"))
            StoredBreakdownPieChart.Series("Value").Points.AddXY("Cheats Marked(" & row("Cheaters") & ")", row("Cheaters"))
            StoredBreakdownPieChart.Series("Value").Points.AddXY("Failed (" & row("Failed") & ")", row("Failed"))
            StoredBreakdownPieChart.Series("Value").Points.AddXY("Normal (" & row("Normal") & ")", row("Normal"))
        Next

        StoredBreakdownPieChart.Series("Value").Points(0).Color = Color.Black
        StoredBreakdownPieChart.Series("Value").Points(1).Color = Color.Magenta
        StoredBreakdownPieChart.Series("Value").Points(2).Color = Color.Yellow
        StoredBreakdownPieChart.Series("Value").Points(3).Color = Color.Chartreuse
        StoredBreakdownPieChart.Series("Value").Points(4).Color = Color.Red
        StoredBreakdownPieChart.Series("Value").Points(5).Color = Color.Orange
        StoredBreakdownPieChart.Series("Value").Points(6).Color = Color.CornflowerBlue

        StoredBreakdownPieChart.Series("Value").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        StoredBreakdownPieChart.Series("Value")("PieLabelStyle") = "Outside"
        StoredBreakdownPieChart.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True


        Dim db1 As SQLiteDatabase = New SQLiteDatabase()
        Dim dt1 As DataTable = db1.GetDataTable("SELECT SUM(IsBlack) AS Black, SUM(IsCropped) AS Cropped, SUM(IsPink) AS Pink, SUM(ScreenCapFailed) AS Failed, SUM(IsNormal) AS Normal, SUM(ReviewFlag) AS Suspicious, SUM(IsCheater) AS Cheaters FROM MasterPBSS")
        HistoricalBreakdownPieChart.Series.Clear()
        HistoricalBreakdownPieChart.Series.Add("Value")

        For Each row As DataRow In dt1.Rows
            HistoricalBreakdownPieChart.Series("Value").Points.AddXY("Black (" & row("Black") & ")", row("Black"))
            HistoricalBreakdownPieChart.Series("Value").Points.AddXY("Pink (" & row("Pink") & ")", row("Pink"))
            HistoricalBreakdownPieChart.Series("Value").Points.AddXY("Cropped (" & row("Cropped") & ")", row("Cropped"))
            HistoricalBreakdownPieChart.Series("Value").Points.AddXY("Suspicious (" & row("Suspicious") & ")", row("Suspicious"))
            HistoricalBreakdownPieChart.Series("Value").Points.AddXY("Cheats Marked(" & row("Cheaters") & ")", row("Cheaters"))
            HistoricalBreakdownPieChart.Series("Value").Points.AddXY("Failed (" & row("Failed") & ")", row("Failed"))
            HistoricalBreakdownPieChart.Series("Value").Points.AddXY("Normal (" & row("Normal") & ")", row("Normal"))
        Next

        HistoricalBreakdownPieChart.Series("Value").Points(0).Color = Color.Black
        HistoricalBreakdownPieChart.Series("Value").Points(1).Color = Color.Magenta
        HistoricalBreakdownPieChart.Series("Value").Points(2).Color = Color.Yellow
        HistoricalBreakdownPieChart.Series("Value").Points(3).Color = Color.Chartreuse
        HistoricalBreakdownPieChart.Series("Value").Points(4).Color = Color.Red
        HistoricalBreakdownPieChart.Series("Value").Points(5).Color = Color.Orange
        HistoricalBreakdownPieChart.Series("Value").Points(6).Color = Color.CornflowerBlue

        HistoricalBreakdownPieChart.Series("Value").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        HistoricalBreakdownPieChart.Series("Value")("PieLabelStyle") = "Outside"
        HistoricalBreakdownPieChart.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim Results As DialogResult
        Results = MessageBox.Show("Scanning will not continue! Are you sure you want to exit?", "Exit Application?", MessageBoxButtons.YesNo)
        If Results = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
#End Region

    Private Sub FormOpenBGW_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles FormOpenBGW.DoWork
        'Make sure the other worker is not doing something
        Dim ran As Boolean = False
        Do While ran = False
            If ScanPBSSBGW.IsBusy = False Then
                DeleteExpiredPBSS(PbssStoreCount.Value)
                Threading.Thread.Sleep(3000)
                ran = True
            End If
        Loop
    End Sub

    Private Sub FormOpenBGW_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles FormOpenBGW.RunWorkerCompleted
        LogRTB.Text &= foMsg
        foMsg = ""
    End Sub

    Sub DeleteExpiredPBSS(ByVal DeleteAfter As Integer)
        Try
            Dim db As SQLiteDatabase = New SQLiteDatabase()
            Dim sql As String = "SELECT PBSSID, ImageName FROM MasterPBSS WHERE (ProcessedDate < datetime('now', 'localtime', '-" & DeleteAfter & " day')) AND (Deleted = 0)"

            'Don't delete cheaters
            If DeleteCheatersCB.Checked = True Then
                sql &= " AND (IsCheater = 0)"
            End If

            'Don't delete suspicious
            If DeleteSuspiciousCB.Checked = True Then
                sql &= " AND (ReviewFlag = 0)"
            End If

            Dim dt As DataTable = db.GetDataTable(sql)


            For Each row As DataRow In dt.Rows

                If File.Exists(spath & "\Store\PBSS\" & row("ImageName")) Then
                    File.Delete(spath & "\Store\PBSS\" & row("ImageName"))
                End If
                Dim db1 As SQLiteDatabase = New SQLiteDatabase()
                db1.ExecuteNonQuery("UPDATE MasterPBSS SET Deleted = 1 WHERE (PBSSID = " & row("PBSSID") & ")")
            Next
            Dim db2 As SQLiteDatabase = New SQLiteDatabase()
            db2.ExecuteNonQuery("DELETE FROM DismissPBSS  WHERE (DismissExpire < datetime('now', 'localtime'))")
            Dim db3 As SQLiteDatabase = New SQLiteDatabase()
            db3.ExecuteNonQuery("VACUUM;")
            foMsg = Now().ToString & ": Successfully deleted " & dt.Rows.Count & " old pbss screenshots." & vbCrLf
        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error deleting old pbss files: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            foMsg &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try
    End Sub

    Private Sub DismissPBSSBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DismissPBSSBTN.Click
        Try
            If DismissDurationCB.SelectedIndex = 0 Then
                'Update the review completed flag
                Dim db As SQLiteDatabase = New SQLiteDatabase()
                db.ExecuteNonQuery("UPDATE MasterPBSS SET ReviewCompleted = 'Y', IsCheater = 0 WHERE (PBSSID = " & ReviewPB.Tag.ToString & ")")

            ElseIf DismissDurationCB.SelectedIndex = 1 Then
                'Dismiss this hero for 1 hour
                If SusImageInfoLAB.Text <> "" Then
                    Dim db As SQLiteDatabase = New SQLiteDatabase()
                    db.ExecuteNonQuery("UPDATE MasterPBSS SET ReviewCompleted = 'Y', IsCheater = 0 WHERE (PBSSID = " & ReviewPB.Tag.ToString & ")")
                    Dim db1 As SQLiteDatabase = New SQLiteDatabase()
                    db1.ExecuteNonQuery("INSERT INTO DismissPBSS (HeroName, DismissExpire) VALUES ('" & SusImageInfoLAB.Text & "',datetime('now', 'localtime', '+1 hour'))")
                End If
            ElseIf DismissDurationCB.SelectedIndex = 2 Then
                'Dismiss this hero for 1 day
                If SusImageInfoLAB.Text <> "" Then
                    Dim db As SQLiteDatabase = New SQLiteDatabase()
                    db.ExecuteNonQuery("UPDATE MasterPBSS SET ReviewCompleted = 'Y', IsCheater = 0 WHERE (PBSSID = " & ReviewPB.Tag.ToString & ")")
                    Dim db1 As SQLiteDatabase = New SQLiteDatabase()
                    db1.ExecuteNonQuery("INSERT INTO DismissPBSS (HeroName, DismissExpire) VALUES ('" & SusImageInfoLAB.Text & "',datetime('now', 'localtime', '+1 day'))")
                End If
            ElseIf DismissDurationCB.SelectedIndex = 3 Then
                'Dismiss this hero for 15 days
                If SusImageInfoLAB.Text <> "" Then
                    Dim db As SQLiteDatabase = New SQLiteDatabase()
                    db.ExecuteNonQuery("UPDATE MasterPBSS SET ReviewCompleted = 'Y', IsCheater = 0 WHERE (PBSSID = " & ReviewPB.Tag.ToString & ")")
                    Dim db1 As SQLiteDatabase = New SQLiteDatabase()
                    db1.ExecuteNonQuery("INSERT INTO DismissPBSS (HeroName, DismissExpire) VALUES ('" & SusImageInfoLAB.Text & "',datetime('now', 'localtime', '+15 day'))")
                End If
            ElseIf DismissDurationCB.SelectedIndex = 4 Then
                'Dismiss this hero for 30 days
                If SusImageInfoLAB.Text <> "" Then
                    Dim db As SQLiteDatabase = New SQLiteDatabase()
                    db.ExecuteNonQuery("UPDATE MasterPBSS SET ReviewCompleted = 'Y', IsCheater = 0 WHERE (PBSSID = " & ReviewPB.Tag.ToString & ")")
                    Dim db1 As SQLiteDatabase = New SQLiteDatabase()
                    db1.ExecuteNonQuery("INSERT INTO DismissPBSS (HeroName, DismissExpire) VALUES ('" & SusImageInfoLAB.Text & "',datetime('now', 'localtime', '+30 day'))")
                End If
            ElseIf DismissDurationCB.SelectedIndex = 5 Then
                'Mark as cheater
                If File.Exists(ReviewPB.ImageLocation) = True Then
                    Try
                        If File.Exists(spath & "\Cheaters\" & SusImgLAB.Text) Then
                            File.Delete(spath & "\Cheaters\" & SusImgLAB.Text)
                        End If
                        'Copy the file to the cheaters directory. Rename it back to it's orginal name
                        File.Copy(ReviewPB.ImageLocation, spath & "\Cheaters\" & SusImgLAB.Text)

                        'Update the review completed flag
                        Dim db As SQLiteDatabase = New SQLiteDatabase()
                        db.ExecuteNonQuery("UPDATE MasterPBSS SET ReviewCompleted = 'Y', IsCheater = 1 WHERE (PBSSID = " & ReviewPB.Tag.ToString & ")")
                    Catch ex As Exception
                        Dim exMsg As String
                        exMsg = Now().ToString & ": Error marking cheater PBSS: "
                        While ex IsNot Nothing
                            exMsg &= ex.Message
                            ex = ex.InnerException
                        End While
                        LogRTB.Text &= exMsg & vbCrLf
                        Globals.WriteLog(exMsg)
                    End Try
                End If
            End If
        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error dismissing pbss: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            LogRTB.Text &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try
        RefreshSuspicious()

    End Sub

    Public Function EncryptString(ByVal InSeed As Integer, ByVal InString As String) As String
        Dim c1 As Integer
        Dim NewEncryptString As String
        Dim EncryptSeed As Integer
        Dim EncryptChar As String

        NewEncryptString = ""
        EncryptSeed = InSeed
        For c1 = 1 To Len(InString)
            EncryptChar = Mid(InString, c1, 1)
            EncryptChar = Chr(Asc(EncryptChar) Xor EncryptSeed)
            EncryptSeed = EncryptSeed Xor c1
            NewEncryptString = NewEncryptString & EncryptChar
        Next

        EncryptString = NewEncryptString
    End Function

    Dim objRandom As New System.Random(CType(System.DateTime.Now.Ticks Mod System.Int32.MaxValue, Integer))

    Public Function GetRandomNumber(Optional ByVal Low As Integer = 1, Optional ByVal High As Integer = 100) As Integer
        ' Returns a random number,
        ' between the optional Low and High parameters
        Return objRandom.Next(Low, High + 1)
    End Function

    Private Sub RefreshStatsBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshStatsBTN.Click
        RefreshStats()
    End Sub

    Private Sub MainForm_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        firstPoint = e.Location
        mouseIsDown = True
    End Sub

    Private Sub MainForm_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        mouseIsDown = False
    End Sub

    Private Sub MainForm_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
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

    Private Sub ScanPBSSNotifyIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ScanPBSSNotifyIcon.MouseDoubleClick
        Try
            Me.Show()
            'Me.WindowState = FormWindowState.Normal
            ScanPBSSNotifyIcon.Visible = False
            'SetTheme()

        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error restoring form window: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            LogRTB.Text &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try
    End Sub

    Private Sub LookupFormPB_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LookupFormPB.MouseEnter
        Me.Cursor = Cursors.Hand
        LookupFormPB.Image = My.Resources.Very_Basic_Search_icon_24_l
    End Sub

    Private Sub LookupFormPB_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LookupFormPB.MouseLeave
        Me.Cursor = Cursors.Default
        LookupFormPB.Image = My.Resources.Very_Basic_Search_icon_24_d
    End Sub

    Private Sub LookupFormPB_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LookupFormPB.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub LookupFormPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LookupFormPB.Click
        LookupForm.Show()
    End Sub

    Private Sub OpenAppFolderPB_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles OpenAppFolderPB.MouseClick
        Process.Start("explorer.exe", spath)
    End Sub

    Private Sub OpenAppFolderPB_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenAppFolderPB.MouseEnter
        Me.Cursor = Cursors.Hand
        OpenAppFolderPB.Image = My.Resources.Very_Basic_Folder_icon_24_l
    End Sub

    Private Sub OpenAppFolderPB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenAppFolderPB.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub OpenAppFolderPB_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenAppFolderPB.MouseLeave
        Me.Cursor = Cursors.Default
        OpenAppFolderPB.Image = My.Resources.Very_Basic_Folder_icon_24_d
    End Sub

    Private Sub ReportGGCPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportGGCPB.Click
        System.Diagnostics.Process.Start("http://www.ggc-stream.net/tisy/ticket/write-pbss")
    End Sub

    Private Sub ReportGGCPB_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportGGCPB.MouseEnter
        Me.Cursor = Cursors.Hand
        ReportGGCPB.Image = My.Resources.Users_Police_icon_24_l
    End Sub

    Private Sub ReportGGCPB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportGGCPB.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub ReportGGCPB_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportGGCPB.MouseLeave
        Me.Cursor = Cursors.Default
        ReportGGCPB.Image = My.Resources.Users_Police_icon_24_d
    End Sub

    Private Sub ExitPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitPB.Click
        Application.Exit()
    End Sub

    Private Sub ExitPB_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitPB.MouseEnter
        Me.Cursor = Cursors.Hand
        ExitPB.Image = My.Resources.Very_Basic_Cancel_icon_24_r
    End Sub

    Private Sub ExitPB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExitPB.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub ExitPB_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExitPB.MouseLeave
        Me.Cursor = Cursors.Default
        ExitPB.Image = My.Resources.Very_Basic_Cancel_icon_24_d
    End Sub

    Private Sub MinimizePB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimizePB.Click

        'Me.WindowState = FormWindowState.Minimized
        Me.TopMost = False
        'Me.WindowState = FormWindowState.Normal
        ScanPBSSNotifyIcon.Visible = True
        Me.Hide()
        If showBalloon = True Then
            showBalloon = False
            ScanPBSSNotifyIcon.BalloonTipTitle = "R.A.D.A.R - Still Running"
            ScanPBSSNotifyIcon.BalloonTipText = "Scanning will continue to run in the background."
            ScanPBSSNotifyIcon.BalloonTipIcon = ToolTipIcon.None
            ScanPBSSNotifyIcon.ShowBalloonTip(3000)
        End If

        ScanPBSSNotifyIcon.Visible = True
    End Sub

    Private Sub MinimizePB_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinimizePB.MouseEnter
        Me.Cursor = Cursors.Hand
        MinimizePB.Image = My.Resources.Very_Basic_Download_icon_g
    End Sub

    Private Sub MinimizePB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinimizePB.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub MinimizePB_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MinimizePB.MouseLeave
        Me.Cursor = Cursors.Default
        MinimizePB.Image = My.Resources.Very_Basic_Download_icon_d
    End Sub

    Private Sub WebUpdateTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebUpdateTimer.Tick
        If PostStatsCB.Checked = True Or PostStatsCB.Checked = True Then
            'Upload some stuff
            If WebUpdateBGW.IsBusy = False Then
                WebUpdateBGW.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub WebUpdateBGW_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles WebUpdateBGW.DoWork
        'Make sure the other worker is not doing something
        Dim ran As Boolean = False
        Do While ran = False
            If ScanPBSSBGW.IsBusy = False Then

                If PostStatsCB.Checked = True Then
                    SendStats()
                End If
                If PostSSCB.Checked = True Then
                    SendPbss()
                End If

                Threading.Thread.Sleep(3000)
                ran = True
            End If
        Loop


    End Sub

    Sub SendStats()
        Try

            Dim ranKey As String = GetRandomNumber(100, 999)
            Dim AuthKey As String = AES_Encrypt("r@PldA|mb0td3tEct1oN", ranKey)
            Dim db As SQLiteDatabase = New SQLiteDatabase()
            Dim dt As DataTable = db.GetDataTable("SELECT ServerGUID, ServerName, Count(*) AS TotalScanned, SUM(IsBlack) AS IsBlack , " & _
                                                  "SUM(IsCropped) AS IsCropped, SUM(IsPink) AS IsPink, SUM(IsNormal) AS IsNormal, SUM(IsCheater) AS IsCheater, " & _
                                                  "SUM(ScreenCapFailed) AS ScreenCapFailed, SUM(ReviewFlag) AS ReviewFlag FROM MasterPBSS INNER JOIN Servers ON " & _
                                                  "MasterPBSS.ServerID = Servers.ServerID GROUP BY ServerName, ServerGUID")

            Dim rws As New RadarWebService.RadarStatsSoapClient
            rws.SendStats(AuthKey, dt, ranKey)
            'rws.Close()

        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error sending statistics to www.pb-radar.net: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            webMsg &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)

        End Try
    End Sub

    Sub SendPbss()
        Try
            Dim ranKey As String = GetRandomNumber(100, 999)
            Dim AuthKey As String = AES_Encrypt("r@PldA|mb0td3tEct1oN", ranKey)
            Dim db As SQLiteDatabase = New SQLiteDatabase()
            Dim dt As DataTable = db.GetDataTable("SELECT P.MD5Sig, P.PBSSID, S.ServerGUID, S.ServerName, P.ImageName, P.HeroName, P.ImageNum, P.ImageDate FROM MasterPBSS AS P INNER JOIN Servers AS S ON P.ServerID = S.ServerID WHERE (P.Uploaded = 'N') AND (P.IsCheater = 1)")
            For Each row As DataRow In dt.Rows
                If File.Exists(spath & "\Store\PBSS\" & row("ImageName").ToString) Then
                    'Make sure the md5 sig matches the orginal to verify that the image was not altered.
                    If row("MD5Sig").ToString = Globals.MD5CalcFile(spath & "\Store\PBSS\" & row("ImageName").ToString) Then

                        'Convert the image to a string
                        Dim img As Image
                        Dim imgStr As String
                        img = Image.FromFile(spath & "\Store\PBSS\" & row("ImageName").ToString)
                        imgStr = Globals.ImageToBase64(img, Imaging.ImageFormat.Png) & vbCrLf

                        'Upload the image
                        Dim rws As New RadarWebService.RadarStatsSoapClient
                        rws.SendPBSS(AuthKey, imgStr, row("ServerGUID").ToString, row("ServerName").ToString, row("HeroName").ToString, _
                            row("ImageNum").ToString, row("ImageDate").ToString, ranKey)

                        'Cleanup
                        rws.Close()
                        img.Dispose()

                        'Update the row so the image is not uploaded again.

                        Dim db1 As SQLiteDatabase = New SQLiteDatabase()
                        db1.ExecuteNonQuery("UPDATE MasterPBSS SET Uploaded = 'Y' WHERE (PBSSID = " & row("PBSSID").ToString & ")")
                    End If
                End If
            Next

        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & ": Error sending cheater PBSS to www.pb-radar.net: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            webMsg &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try
    End Sub

    Private Sub WebUpdateBGW_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WebUpdateBGW.RunWorkerCompleted
        LogRTB.Text &= webMsg
    End Sub

    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Dim hash(31) As Byte
        Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
        Array.Copy(temp, 0, hash, 0, 16)
        Array.Copy(temp, 0, hash, 15, 16)
        AES.Key = hash
        AES.Mode = System.Security.Cryptography.CipherMode.ECB
        Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
        Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
        encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        Return encrypted
    End Function

    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Dim hash(31) As Byte
        Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
        Array.Copy(temp, 0, hash, 0, 16)
        Array.Copy(temp, 0, hash, 15, 16)
        AES.Key = hash
        AES.Mode = System.Security.Cryptography.CipherMode.ECB
        Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
        Dim Buffer As Byte() = Convert.FromBase64String(input)
        decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        Return decrypted
    End Function

    Private Sub RadarLinkPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadarLinkPB.Click
        System.Diagnostics.Process.Start("http://www.pb-radar.net")
    End Sub

    Private Sub RadarLinkPB_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadarLinkPB.MouseEnter
        Me.Cursor = Cursors.Hand
        RadarLinkPB.Image = My.Resources.wwwpb_radarnet_g
    End Sub

    Private Sub RadarLinkPB_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadarLinkPB.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub RadarLinkPB_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadarLinkPB.MouseLeave
        Me.Cursor = Cursors.Default
        RadarLinkPB.Image = My.Resources.wwwpb_radarnet
    End Sub

    Private Sub ReviewPB_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReviewPB.DoubleClick
        Globals.PbZoomSender = "ReviewPB"
        LookupFormZoom.Show()
    End Sub

    Private Sub RescanBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RescanBTN.Click
        Dim Results As DialogResult
        Results = MessageBox.Show("Are you sure you want to rescan all stored screenshots? This could take a long time and is CPU intensive!", "Rescan All Screenshots?", MessageBoxButtons.YesNo)
        If Results = DialogResult.Yes Then
            Dim db1 As SQLiteDatabase = New SQLiteDatabase()
            db1.ExecuteNonQuery("UPDATE MasterPBSS SET ReviewCompleted = 'N', ScanCompleted = 'N' WHERE (IsCheater = 0) AND (Deleted = 0) AND (IsBlack = 0) AND (IsPink = 0) AND (IsNormal = 1) AND (ReviewFlag = 0)")
            If ScanPBSSBGW.IsBusy = False Then
                ScanPBSSBGW.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub StopServer()
        If server IsNot Nothing Then
            server.Stop()
            server = Nothing
        End If
    End Sub
    Private Sub StartServer()
        If My.Computer.FileSystem.DirectoryExists(spath & "\Store\") Then
            WebPath = spath & "\Store\"
            Try
                Port = WebPortNUM.Value
                'just point app path to your ASP.Net website or webservice  
                StopServer()
                server = New CassiniVB.Server(Port, VirtRoot, WebPath)
                server.Start(True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "~error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("path not found")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim GameA As New DataTable

        GameA.Columns.Add("PlayerID", GetType(Integer))
        GameA.Columns.Add("HeroID", GetType(Integer))
        GameA.PrimaryKey = New DataColumn() {GameA.Columns("PlayerID"), GameA.Columns("HeroID")}
        GameA.Rows.Add(1, 2)
        GameA.Rows.Add(2, 1)

        Dim GameB As New DataTable

        GameB.Columns.Add("PlayerID", GetType(Integer))
        GameB.Columns.Add("HeroID", GetType(Integer))
        GameB.PrimaryKey = New DataColumn() {GameB.Columns("PlayerID"), GameB.Columns("HeroID")}

        GameB.Rows.Add(1, 2)
        GameB.Rows.Add(2, 1)
        GameB.Rows.Add(3, 1)
        GameA.Merge(GameB)


        'ChangesDGV.DataSource = GameA.GetChanges(Data.DataRowState.)

    End Sub

    Private Sub EnableWebServerCHK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableWebServerCHK.CheckedChanged
        If EnableWebServerCHK.Checked = True Then
            StartServer()
            WebPrivateLink.Text = "http://" & GetIPAddress() & ":" & WebPortNUM.Value
            WebPublicLink.Text = "http://" & GetPublicIpAddress() & ":" & WebPortNUM.Value
        Else
            StopServer()
        End If
    End Sub

    Private Function GetIPAddress() As String
        GetIPAddress = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPAddress = ipheal.ToString()
            End If
        Next

    End Function

    Private Sub WebPrivateLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebPrivateLink.Click
        Process.Start("iexplore.exe", WebPrivateLink.Text)
    End Sub

    Function GetPublicIpAddress() As String
        Dim ip As New WebClient
        Return ip.DownloadString("https://secure.internode.on.net/webtools/showmyip?textonly=1").Replace(vbCrLf, "").Trim

    End Function

    Private Sub WebPublicLink_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles WebPublicLink.LinkClicked
        Process.Start("iexplore.exe", WebPublicLink.Text)
    End Sub

    Private Sub AltAccountsBGW_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles AltAccountsBGW.DoWork
        Try
            Dim pblogdir As New DirectoryInfo(spath & "\PBLogs\")
            Dim pblogarr As FileInfo() = pblogdir.GetFiles()

            Dim logfile As FileInfo
            For Each logfile In pblogarr
                Dim reader As New StreamReader(logfile.FullName)
                Do While reader.Peek() <> -1
                    Dim line As String = reader.ReadLine()
                    If line.Contains("New Connection") Then


                        Dim words As String() = line.Split(New Char() {" "c})

                        Dim PlayerDate As String = words(0).ToString.Replace("[", "").Replace(".", "-").Replace(" ", "")
                        Dim PlayerIP As String = words(6).ToString
                        PlayerIP = PlayerIP.Substring(0, PlayerIP.IndexOf(":"))
                        Dim PlayerName As String = words(8).ToString.Replace("""", "")

                        'LogRTB.Text &= PlayerName & "," & PlayerIP & "," & PlayerDate & vbCrLf
                        Dim db As SQLiteDatabase = New SQLiteDatabase()
                        db.ExecuteNonQuery("INSERT OR IGNORE INTO AltAccounts (HeroName, IpAddress, JoinDate) VALUES ('" & PlayerName & "', '" & PlayerIP & "', '" & PlayerDate & "')")
                    End If
                Loop
            Next
        Catch ex As Exception
            Dim exMsg As String
            exMsg = Now().ToString & "-Error Processing Alt Account: "
            While ex IsNot Nothing
                exMsg &= ex.Message
                ex = ex.InnerException
            End While
            msg &= exMsg & vbCrLf
            Globals.WriteLog(exMsg)
        End Try

    End Sub
    Private Sub AltAccountsBGW_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles AltAccountsBGW.RunWorkerCompleted
        LogRTB.Text &= Now.ToString & ": Finished Processing Alt Account Logs" & vbCrLf
        AltAccEnable()
    End Sub

    Private Sub AltProcessLogBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltProcessLogBTN.Click
        AltAccDisable()
        AltAccountsBGW.RunWorkerAsync()
    End Sub

    Private Sub AltSearchBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltSearchBTN.Click
        Dim db As SQLiteDatabase = New SQLiteDatabase()
        Dim query As String = "SELECT DISTINCT HeroName, IpAddress"
        If AltShowDateCB.Checked Then
            query &= ", JoinDate"
        End If
        query &= " FROM AltAccounts WHERE (IpAddress IN (SELECT IpAddress FROM AltAccounts WHERE (IpAddress = '" & AltHeroNameTXT.Text & "') OR (HeroName LIKE '" & AltHeroNameTXT.Text & "'))) ORDER BY IpAddress, HeroName"

        Dim dt As DataTable = db.GetDataTable(query)
        AltGV.DataSource = dt
        AltGV.Update()

    End Sub
    Sub AltAccDisable()
        AltProcessLogBTN.Text = "Processing... Please Wait"
        AltProcessLogBTN.Enabled = False
        AltSearchBTN.Enabled = False
        AltHeroNameTXT.Enabled = False
        AltShowDateCB.Enabled = False
        AltGV.Enabled = False
    End Sub
    Sub AltAccEnable()
        AltProcessLogBTN.Text = "Process Log Files"
        AltProcessLogBTN.Enabled = True
        AltSearchBTN.Enabled = True
        AltHeroNameTXT.Enabled = True
        AltShowDateCB.Enabled = True
        AltGV.Enabled = True
    End Sub

    Private Sub PurgeBTN_Click(sender As Object, e As EventArgs) Handles PurgeBTN.Click
        Developer.ClearTables()
    End Sub

End Class




