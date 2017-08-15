Public Class LookupFormZoom

    Private Sub LookupFormZoom_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim bgColor As New Color
        bgColor = Color.FromArgb(255, 24, 26, 27)
        Me.BackColor = bgColor
        If Globals.PbZoomSender = "ReviewPB" Then
            ViewZoomPB.Image = MainForm.ReviewPB.Image
        Else
            ViewZoomPB.Image = LookupForm.ViewPB.Image
        End If
        ViewZoomPB.Width = Me.ClientSize.Width
        ViewZoomPB.Height = Me.ClientSize.Height
    End Sub

    Private Sub LookupFormZoom_ResizeEnd(sender As System.Object, e As System.EventArgs) Handles MyBase.ResizeEnd
        ViewZoomPB.Width = Me.ClientSize.Width
        ViewZoomPB.Height = Me.ClientSize.Height
    End Sub
End Class