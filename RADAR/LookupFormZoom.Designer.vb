<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LookupFormZoom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LookupFormZoom))
        Me.ViewZoomPB = New System.Windows.Forms.PictureBox()
        CType(Me.ViewZoomPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ViewZoomPB
        '
        Me.ViewZoomPB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewZoomPB.Location = New System.Drawing.Point(0, 0)
        Me.ViewZoomPB.Name = "ViewZoomPB"
        Me.ViewZoomPB.Size = New System.Drawing.Size(651, 328)
        Me.ViewZoomPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ViewZoomPB.TabIndex = 0
        Me.ViewZoomPB.TabStop = False
        '
        'LookupFormZoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(734, 426)
        Me.Controls.Add(Me.ViewZoomPB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LookupFormZoom"
        Me.Text = "Zoomed Preview"
        CType(Me.ViewZoomPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ViewZoomPB As System.Windows.Forms.PictureBox
End Class
