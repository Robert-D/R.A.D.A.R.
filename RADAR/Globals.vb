Imports System
Imports System.IO
Imports System.Data


Public Class Globals
    Public Shared RadarCS As String = "Data Source=Settings\RadarDB.s3db;Password=r@pidD8"
    'Public Shared RadarCS As String = "Data Source=Settings\RadarDB.s3db"
    Public Shared PbZoomSender As String

    Public Shared Sub WriteLog(ByVal strComments As String)
        Dim fileStream As FileStream
        Dim streamWriter As StreamWriter

        Dim strPath As String
        strPath = Application.StartupPath() & "\Logs\Error-" & Now.ToString("MM'-'dd'-'yyyy") & ".log"
        If System.IO.File.Exists(strPath) Then
            fileStream = New FileStream(strPath, FileMode.Append, FileAccess.Write)
        Else
            fileStream = New FileStream(strPath, FileMode.Create, FileAccess.Write)
        End If

        streamWriter = New StreamWriter(fileStream)

        'write the line
        streamWriter.WriteLine(strComments)

        'Close the file & cleanup
        streamWriter.Close()
        fileStream.Close()
        streamWriter.Dispose()
        fileStream.Dispose()

    End Sub

    ' specify the path to a file and this routine will calculate your hash
    Public Shared Function MD5CalcFile(ByVal filepath As String) As String

        ' open file (as read-only)
        Using reader As New System.IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)
            Using md5 As New System.Security.Cryptography.MD5CryptoServiceProvider

                ' hash contents of this stream
                Dim hash() As Byte = md5.ComputeHash(reader)

                ' return formatted hash
                Return ByteArrayToString(hash)

            End Using
        End Using

    End Function

    ' utility function to convert a byte array into a hex string
    Private Shared Function ByteArrayToString(ByVal arrInput() As Byte) As String

        Dim sb As New System.Text.StringBuilder(arrInput.Length * 2)

        For i As Integer = 0 To arrInput.Length - 1
            sb.Append(arrInput(i).ToString("X2"))
        Next

        Return sb.ToString().ToLower

    End Function

    Public Shared Function ImageToBase64(image As Image, format As System.Drawing.Imaging.ImageFormat) As String
        Using ms As New MemoryStream()
            ' Convert Image to byte[]
            image.Save(ms, format)
            Dim imageBytes As Byte() = ms.ToArray()

            ' Convert byte[] to Base64 String
            Dim base64String As String = Convert.ToBase64String(imageBytes)
            Return base64String
        End Using
    End Function

End Class
