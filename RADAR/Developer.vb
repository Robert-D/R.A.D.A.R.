Imports System.Data.SQLite
Imports System.IO

Public Class Developer
    Public Shared Sub SetDBPassword(ByVal pass As String)
        Dim cnn As New SQLiteConnection(Globals.RadarCS)
        cnn.Open()
        cnn.ChangePassword(pass)
        cnn.Close()
    End Sub

    Public Shared Sub ClearTables()
        Dim spath As String = Application.StartupPath()

        Dim Results As DialogResult
        Results = MessageBox.Show("This will delete all your settings and data! Continue?", "Reset to Default", MessageBoxButtons.YesNo)
        If Results = DialogResult.Yes Then

            Try
                Dim sql As String = ""

                Dim db As SQLiteDatabase = New SQLiteDatabase()
                db.ExecuteNonQuery("DELETE FROM MasterPBSS;")

                'Reset the default settings
                sql = "UPDATE Settings SET ScanCount = 100, ScanInterval = 5, StoreDuration = 15, SmtpEnabled = 0, " & _
                    "SmtpServer = 'smtp.gmail.com', SmtpPort = '25', SmtpAuthUser = 'yourgmailaccount@gmail.com', SmtpAuthPass = 'pass', SmtpSendTo = 'youremail@whatever.com', SmtpReqSSL = 0, " & _
                    "CFPixelStart = 15, CFPixelEnd = 50000, ScanAuto = 0, PlaySound = 1, DeleteCheaters = 1, DeleteSuspicious = 1, RestoreWindow = 1, PostStats = 1, PostPBSS = 1, WebServerEnabled = 0, WebPortNum = 8088, " & _
                    "WebPass = 'iseepbss*', WebDisplayLimit = 200, WebBanner = 'http://www.pb-radar.net/images/replacebanner.png'"


                Dim db1 As SQLiteDatabase = New SQLiteDatabase()
                db1.ExecuteNonQuery(sql)

                'Delete all servers
                'Dim db2 As SQLiteDatabase = New SQLiteDatabase()
                'db2.ExecuteNonQuery("DELETE FROM Servers;")

                'Delete all servers
                Dim db3 As SQLiteDatabase = New SQLiteDatabase()
                db3.ExecuteNonQuery("DELETE FROM DismissPBSS;")

                Dim db6 As SQLiteDatabase = New SQLiteDatabase()
                db6.ExecuteNonQuery("DELETE FROM AltAccounts;")

                'Reseed tables
                Dim db4 As SQLiteDatabase = New SQLiteDatabase()
                db4.ExecuteNonQuery("DELETE FROM sqlite_sequence WHERE (Name = 'MasterPBSS') OR (Name = 'Servers') OR (Name = 'DismissPBSS') OR (Name = 'AltAccounts');")

                'Shrink the Database
                Dim db5 As SQLiteDatabase = New SQLiteDatabase()
                db5.ExecuteNonQuery("vacuum;")

                'Delete staging files
                Dim DirInfo As New DirectoryInfo(spath & "\StagingImages\")
                Dim Files As FileInfo() = DirInfo.GetFiles()

                For Each F In Files
                    If F.Extension = ".png" Or F.Extension = ".jpg" Or F.Extension = ".txt" Then
                        F.Delete()
                    End If
                Next

                'Delete Store Files
                Dim DirInfo1 As New DirectoryInfo(spath & "\Store\PBSS\")
                Dim Files1 As FileInfo() = DirInfo1.GetFiles()

                For Each F In Files1
                    If F.Extension = ".png" Or F.Extension = ".jpg" Or F.Extension = ".txt" Then
                        F.Delete()
                    End If
                Next
                MainForm.SetSettings()
                MsgBox("Application has been reset to default.")


            Catch ex As Exception
                Dim exMsg As String
                exMsg = Now().ToString & ": Error purging data: "
                While ex IsNot Nothing
                    exMsg &= ex.Message
                    ex = ex.InnerException
                End While
                Globals.WriteLog(exMsg)
            End Try
        End If
    End Sub
End Class
