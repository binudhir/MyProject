Imports vb = Microsoft.VisualBasic
Public Class frmsplash
    Private Sub frmsplash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.clr()
        pbs.Minimum = 0
        pbs.Maximum = 2000
        For i As Integer = 0 To 2000
            pbs.Value = i
        Next
    End Sub

    Private Sub frmsplash_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black
        End If
    End Sub
End Class
