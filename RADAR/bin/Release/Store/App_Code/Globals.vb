Imports Microsoft.VisualBasic

Public Class Globals
    Public Shared RadarCS As String = "Data Source=" & HttpContext.Current.Server.MapPath("~\").Replace("Store", "Settings") & "RadarDB.s3db"
    Public Shared Function CleanSQL(ByVal SQL As String) As String
        Dim cleanedSQL As String = SQL
        cleanedSQL.Replace("'", "")
        Return cleanedSQL
    End Function
End Class
