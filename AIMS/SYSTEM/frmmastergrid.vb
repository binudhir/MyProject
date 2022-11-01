Imports Microsoft.Office.Interop
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Reporting.WinForms

Public Class frmmastergrid
    Private Sub frmmastergrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmmastergrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT stud.stud_nm, stud.stud_sl, stud.reg_no, stud.pre_add1, stud.per_ph1, stud.dob, stud.gndr,stud.leaved,sesion1.sesn_nm, semester.sem_nm, trad.trad_nm FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd RIGHT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') ORDER BY stud.stud_nm,stud.reg_no")
        dv.Rows.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                dv.Rows.Add()
                dv.Rows(rw).Cells(0).Value = i + 1
                dv.Rows(rw).Cells(1).Value = dsedit.Tables(0).Rows(i).Item("stud_nm")
                dv.Rows(rw).Cells(2).Value = dsedit.Tables(0).Rows(i).Item("reg_no")
                dv.Rows(rw).Cells(3).Value = dsedit.Tables(0).Rows(i).Item("pre_add1")
                dv.Rows(rw).Cells(4).Value = dsedit.Tables(0).Rows(i).Item("per_ph1")
                dv.Rows(rw).Cells(5).Value = Format(dsedit.Tables(0).Rows(i).Item("dob"), "dd/MM/yyyy")
                dv.Rows(rw).Cells(7).Value = dsedit.Tables(0).Rows(i).Item("sesn_nm")
                dv.Rows(rw).Cells(8).Value = dsedit.Tables(0).Rows(i).Item("sesn_nm")
                dv.Rows(rw).Cells(9).Value = dsedit.Tables(0).Rows(i).Item("trad_nm")
                dv.Rows(rw).Cells(10).Value = dsedit.Tables(0).Rows(i).Item("stud_sl")
                If dsedit.Tables(0).Rows(rw).Item("leaved") = "Y" Then
                    dv.Rows(rw).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Red
                Else
                    If dsedit.Tables(0).Rows(rw).Item("gndr") = "1" Then
                        dv.Rows(rw).Cells(6).Value = "M"
                        dv.Rows(rw).DefaultCellStyle.BackColor = Color.AliceBlue
                        dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Blue
                    Else
                        dv.Rows(rw).Cells(6).Value = "F"
                        dv.Rows(rw).DefaultCellStyle.BackColor = Color.White
                        dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Black
                    End If
                End If
                rw = rw + 1
            Next
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim xlApp As Excel.Application
        'Dim xlWorkBook As Excel.Workbook
        'Dim xlWorkSheet As Excel.Worksheet
        'Dim misValue As Object = System.Reflection.Missing.Value
        'xlApp = New Excel.ApplicationClass
        'xlWorkBook = xlApp.Workbooks.Add(misValue)
        'xlWorkSheet = xlWorkBook.Sheets("sheet1")
        'With xlWorkSheet
        '    For Each col As DataGridViewColumn In dv.Columns
        '        'noms des colonnes
        '        .Cells(1, col.Index + 1) = col.HeaderText
        '        .Cells(1, col.Index + 1).Interior.Color = RGB(190, 250, 120) 'System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
        '        .Cells(1, col.Index + 1).Font.Color = RGB(250, 0, 0)
        '        .Cells(1, col.Index + 1).Font.Bold = True
        '        For Each rowa As DataGridViewRow In dv.Rows
        '            .Cells(rowa.Index + 2, col.Index + 1) = rowa.Cells(col.Index).Value
        '        Next
        '    Next
        '    .Columns.AutoFit()
        'End With
        'xlApp.Visible = True
        Call excel_view(dv)
    End Sub

    'Private Sub releaseObject(ByVal obj As Object)
    '    Try
    '        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
    '        obj = Nothing
    '    Catch ex As Exception
    '        obj = Nothing
    '    Finally
    '        GC.Collect()
    '    End Try
    'End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ds As New dsrep
        Dim dt As DataTable = ds.Tables(0)
        'With dt
        '    For Each col As DataGridViewColumn In dv.Columns
        '        .Columns.Add(col.HeaderText)
        '        '.Columns.Add("name")
        '        '.Columns.Add("gender")
        '        '.Columns.Add("address")
        '    Next
        'End With
        'For Each rowa As DataGridViewRow In dv.Rows
        '    dt.Rows.Add(rowa.Cells(rowa.Index).Value)
        'Next
        'Dim ds1 As DataSet = get_dataset("SELECT collrec1.coll_no,collrec1.coll_no, collrec1.tot_amt, trad.trad_nm, sesion1.sesn_nm, stud.stud_nm, stud_hstry.reg_no, collrec1.coll_dt, collrec1.pay_mod FROM stud RIGHT OUTER JOIN stud_hstry ON stud.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd RIGHT OUTER JOIN collrec1 ON stud_hstry.stud_sl = collrec1.stud_sl WHERE (stud_hstry.active = 'Y') AND (collrec1.coll_no=1)")
        'If ds1.Tables(0).Rows.Count <> 0 Then
        '    Dim r As DataRow = dt.NewRow()
        '    r("ID") = ds1.Tables(0).Rows(0).Item("coll_no")
        '    r("Name") = ds1.Tables(0).Rows(0).Item("stud_nm")
        '    r("Regno") = ds1.Tables(0).Rows(0).Item("reg_no")
        '    r("Class") = ds1.Tables(0).Rows(0).Item("trad_nm")
        '    'r("recdt") = ds1.Tables(0).Rows(0).Item("coll_no")
        '    'r("stream") = ds1.Tables(0).Rows(0).Item("trad_nm")
        '    'r("semnm") = ds1.Tables(0).Rows(0).Item("coll_no")
        '    'r("class") = ds1.Tables(0).Rows(0).Item("coll_no")
        '    'r("mode") = ds1.Tables(0).Rows(0).Item("coll_no")
        '    'r("regno") = ds1.Tables(0).Rows(0).Item("reg_no")
        '    'r("studno") = ds1.Tables(0).Rows(0).Item("stud_nm")
        '    'r("chqno") = ds1.Tables(0).Rows(0).Item("coll_no")
        '    'r("banknm") = ds1.Tables(0).Rows(0).Item("coll_no")
        '    dt.Rows.Add(r)
        'End If
        'For x As Integer = 1 To 20
        '    Dim r As DataRow = dt.NewRow()
        '    r("slno") = x
        '    r("recno") = "Item" & x.ToString
        '    dt.Rows.Add(r)
        'Next
        'For Each dr As DataGridViewRow In Me.dv.Rows
        '    dt.Rows.Add(dr.Cells("code").Value, dr.Cells("name").Value, _
        '                dr.Cells("gender").Value, dr.Cells("address").Value)
        'Next
        '
        Dim rptDoc As New ReportDocument
        'rptDoc = New CrystalReport1
        rptDoc.Load(My.Application.Info.DirectoryPath & "\REPORTS\CrystalReport1.rpt")
        rptDoc.SetDataSource(dt)
        frmviewer1.CrystalReportViewer1.ReportSource = rptDoc
        frmviewer1.ShowDialog()
        frmviewer1.Dispose()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ds As New dsrep
        Dim dt As DataTable = ds.Tables(0)

        'For x As Integer = 1 To 20
        '    Dim r As DataRow = dt.NewRow()
        '    r("ID") = x
        '    r("Name") = "Item" & x.ToString
        '    dt.Rows.Add(r)
        'Next


        Dim ds1 As DataSet = get_dataset("SELECT collrec1.coll_no,collrec1.coll_no, collrec1.tot_amt, trad.trad_nm, sesion1.sesn_nm, stud.stud_nm, stud_hstry.reg_no, collrec1.coll_dt, collrec1.pay_mod FROM stud RIGHT OUTER JOIN stud_hstry ON stud.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd RIGHT OUTER JOIN collrec1 ON stud_hstry.stud_sl = collrec1.stud_sl WHERE (stud_hstry.active = 'Y') AND (collrec1.coll_no=1)")
        If ds1.Tables(0).Rows.Count <> 0 Then
            Dim r As DataRow = dt.NewRow()
            r("ID") = ds1.Tables(0).Rows(0).Item("coll_no")
            r("Name") = ds1.Tables(0).Rows(0).Item("stud_nm")
            r("Regno") = ds1.Tables(0).Rows(0).Item("reg_no")
            'r("Class") = ds1.Tables(0).Rows(0).Item("trad_nm")
            'r("semnm") = ds1.Tables(0).Rows(0).Item("coll_no")
            'r("class") = ds1.Tables(0).Rows(0).Item("coll_no")
            'r("mode") = ds1.Tables(0).Rows(0).Item("coll_no")
            'r("regno") = ds1.Tables(0).Rows(0).Item("reg_no")
            'r("studno") = ds1.Tables(0).Rows(0).Item("stud_nm")
            'r("chqno") = ds1.Tables(0).Rows(0).Item("coll_no")
            'r("banknm") = ds1.Tables(0).Rows(0).Item("coll_no")
            dt.Rows.Add(r)
        End If
        frmviewer.MdiParent = MDI
        frmviewer.Show()

        frmviewer.ReportViewer1.LocalReport.ReportPath = My.Application.Info.DirectoryPath & "\REPORTS\Report1.rdlc"
        frmviewer.ReportViewer1.LocalReport.DataSources.Clear()
        frmviewer.ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1_DataTable1", ds.Tables(0)))
        frmviewer.ReportViewer1.RefreshReport()
    End Sub
End Class
