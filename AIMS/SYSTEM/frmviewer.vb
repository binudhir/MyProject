Imports CrystalDecisions.CrystalReports.Engine
Public Class frmviewer
    Private Sub frmviewer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmviewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
