Imports System.IO
Imports System.Data
Imports System.Data.SQLite
Imports System.Web

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("AuthPass") Is Nothing Or Session("DisplayLimit") Is Nothing Or Session("Banner") Is Nothing Then

            'get and store the settings
            Dim db As SQLiteDatabase = New SQLiteDatabase()
            Dim dt As DataTable = db.GetDataTable("SELECT WebPass, WebDisplayLimit, WebBanner FROM Settings")
            For Each row As DataRow In dt.Rows
                Session("AuthPass") = row("WebPass").ToString
                Session("DisplayLimit") = row("WebDisplayLimit").ToString
                Session("Banner") = row("WebBanner").ToString
            Next
        End If

        'Check to see if authenticated
        If Session("IsAuth") Is Nothing Or Session("IsAuth") = "N" Then
            Session("IsAuth") = "N"
            DisplayPAN.Visible = False
            LoginPAN.Visible = True
        ElseIf Session("IsAuth") = "Y" Then
            DisplayPAN.Visible = True
            LoginPAN.Visible = False
        End If


        'Set the banner
        If Session("Banner").ToString.Contains(".png") Or Session("Banner").ToString.Contains(".jpg") Or Session("Banner").ToString.Contains(".gif") Then
            'It's an image
            HeaderTextLAB.Text = "<img alt=""Banner"" src=""" & Session("Banner").ToString & """ />"
        Else
            'It's text
            HeaderTextLAB.Text = Session("Banner").ToString
        End If

        If Not Page.IsPostBack Then
            Dim dbs As SQLiteDatabase = New SQLiteDatabase()
            Dim dts As DataTable = dbs.GetDataTable("SELECT * FROM SERVERS")
            ServersDDL.DataSource = dts
            ServersDDL.DataTextField = "ServerName"
            ServersDDL.DataValueField = "ServerID"
            ServersDDL.DataBind()
            BuildResults()
        End If


    End Sub

    Protected Sub SearchBTN_Click(sender As Object, e As System.EventArgs) Handles SearchBTN.Click
        BuildResults()
    End Sub

    Sub BuildResults()
        Dim sql As String = "SELECT * "
        sql &= "FROM MasterPBSS AS PB INNER JOIN Servers AS S ON PB.ServerID = S.ServerID "
        sql &= "WHERE (PB.ServerID = CASE " & ServersDDL.SelectedValue & " WHEN 0 THEN PB.ServerID ELSE " & ServersDDL.SelectedValue & " END) "

        If HeroNameTXT.Text <> "" Then
            sql &= "AND (PB.HeroName LIKE '" & Globals.CleanSQL(HeroNameTXT.Text) & "%') "
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

        sql &= " AND (Deleted = 0) ORDER BY PB.PBSSID DESC LIMIT " & Session("DisplayLimit").ToString


        Dim db As SQLiteDatabase = New SQLiteDatabase()
        Dim dt As DataTable = db.GetDataTable(SQL)
        Dim col As Integer = 1
        Dim rHTML As String = ""
        rHTML &= "<table width=""100%"">"
        rHTML &= "<td colspan=""2"" align=""right"">Displaying " & dt.Rows.Count & " results.</td>"

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If col = 1 Then
                    rHTML &= "<tr>"
                    rHTML &= "<td width=""50%"" align=""center"">"
                    rHTML &= "<img class=""lazy"" src='http://www.pb-radar.net/images/loading.gif'  data-original='PBSS/" & row("ImageName") & "' />"
                    'rHTML &= "<img class=""lazy"" alt=""" & row("HeroName") & """ src=""holder.png"" data-original=""PBSS/" & row("ImageName") & """ />"
                    rHTML &= "<table width=""100%""><tr><td>Hero: " & row("HeroName") & "</td><td>Image: " & row("ImageNum") & "</td></tr><tr><td>Server: " & row("ServerName") & "</td><td>Time: " & row("ImageDate") & "</td></tr></table><br />"
                    rHTML &= "</td>"
                    col = 2
                Else
                    rHTML &= "<td width=""50%"" align=""center"">"
                    rHTML &= "<img class=""lazy"" src='http://www.pb-radar.net/images/loading.gif'  data-original='PBSS/" & row("ImageName") & "' />"
                    'rHTML &= "<img class=""lazy"" alt=""" & row("HeroName") & """ src=""holder.png"" data-original=""PBSS/" & row("ImageName") & """ />"
                    rHTML &= "<table width=""100%""><tr><td>Hero: " & row("HeroName") & "</td><td>Image: " & row("ImageNum") & "</td></tr><tr><td>Server: " & row("ServerName") & "</td><td>Time: " & row("ImageDate") & "</td></tr></table><br />"
                    rHTML &= "</td>"
                    rHTML &= "</tr>"
                    col = 1
                End If
            Next
            If col = 2 Then
                rHTML &= "<td width=""50%"">"
                rHTML &= "</td>"
                rHTML &= "</tr>"
            End If
        Else
            rHTML &= "<tr>"
            rHTML &= "<td>There were no screenshots found with your search criteria."
            rHTML &= "</td>"
            rHTML &= "</tr>"
        End If
        'Add the provided by logo
        rHTML &= "<td colspan=""2"" align=""right""><br /><a href=""http://www.pb-radar.net""><img alt=""Provided By R.A.D.A.R"" src=""http://www.pb-radar.net/images/ProvidedByLogo.png"" /></a></td>"
        rHTML &= "</table>"
        ResultsLIT.Text = rHTML
    End Sub

    Protected Sub ResetBTN_Click(sender As Object, e As System.EventArgs) Handles ResetBTN.Click
        HeroNameTXT.Text = ""
        ServersDDL.SelectedIndex = 0
        SuspiciousCB.Checked = False
        CroppedCB.Checked = False
        FailedCB.Checked = False
        PinkCB.Checked = False
        BlackCB.Checked = False
        NormalCB.Checked = False
        CheatersCB.Checked = False

        BuildResults()

    End Sub

    Protected Sub LoginBTN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginBTN.Click
        If Session("AttemptNum") Is Nothing Then
            Session("AttemptNum") = 1
        Else
            Session("AttemptNum") += 1
        End If


        If AuthPassTXT.Text = Session("AuthPass").ToString Then
            Session("IsAuth") = "Y"
            DisplayPAN.Visible = True
            LoginPAN.Visible = False
        Else
            Session("IsAuth") = "N"
            DisplayPAN.Visible = False
            LoginPAN.Visible = True
            StatusLAB.Text = "Invalid password."
        End If

        If Session("AttemptNum") >= 5 Then
            LoginBTN.Enabled = False
            AuthPassTXT.Enabled = False
            AuthPassTXT.Visible = False
            LoginBTN.Visible = False
            StatusLAB.Text = "Too many invalid attempts."
        End If
    End Sub

    Protected Sub LogoutBTN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LogoutBTN.Click
        Session.Abandon()
        LoginPAN.Visible = True
        DisplayPAN.Visible = False
    End Sub
End Class
