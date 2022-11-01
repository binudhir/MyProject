'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared

Public Class frmviewer1
    Private Sub frmviewer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        'Me.WindowState = FormWindowState.Maximized
        Me.Dock = DockStyle.Fill
        'Dim cryRpt As New ReportDocument
        'Dim crtableLogoninfos As New TableLogOnInfos
        'Dim crtableLogoninfo As New TableLogOnInfo
        'Dim crConnectionInfo As New ConnectionInfo
        'Dim CrTables As Tables
        'Dim CrTable As Table
        'cryRpt.Load(My.Application.Info.DirectoryPath & "\REPORTS\" & reportnm)
        'With crConnectionInfo
        '    .ServerName = srvnm
        '    .DatabaseName = dbnm
        '    .UserID = dbid
        '    .Password = dbpwd
        'End With
        'CrTables = cryRpt.Database.Tables
        'For Each CrTable In CrTables
        '    crtableLogoninfo = CrTable.LogOnInfo
        '    crtableLogoninfo.ConnectionInfo = crConnectionInfo
        '    CrTable.ApplyLogOnInfo(crtableLogoninfo)
        'Next
        'CrystalReportViewer1.ReportSource = cryRpt
        'CrystalReportViewer1.Refresh()
    End Sub
End Class
