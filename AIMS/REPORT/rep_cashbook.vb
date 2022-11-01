Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class rep_cashbook
    Dim comd As String
    Dim sdt As Date
    Dim edt As Date

    Private Sub rep_cashbook_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_cashbook_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_cashbook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        startdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        enddt.Value = startdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        Me.Text = "Cash Book . . ."
        hddr = Me.Text
        cmborder.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT scrl_dt FROM print_cashbook ORDER BY scrl_dt DESC")
        If ds.Tables(0).Rows.Count <> 0 Then
            lblcsbk.Text = "The Cash Book Is Updated Upto : " & Format(ds.Tables(0).Rows(0).Item(0), "dd/MMM/yyyy")
        Else
            lblcsbk.Text = "The Cash Book Is Not Updated.Please Click Update Cashbook To Update The Cashbook."
        End If
    End Sub

    Private Sub cmborder_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmborder.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmborder_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmborder.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btncalc_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnrfresh.MouseEnter, btnexport.MouseEnter, btnexit.MouseEnter, btncalc.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btncalc_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnrfresh.MouseLeave, btnexport.MouseLeave, btnexit.MouseLeave, btncalc.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub startdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startdt.KeyPress
        key(enddt, e)
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btncalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncalc.Click
        System.Diagnostics.Process.Start("calc.exe")
    End Sub

    Private Sub btnrfresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrfresh.Click
        Me.clr()
    End Sub

    Private Sub btnexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexport.Click
        Call excel_view(dv)
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        dv.Columns.Clear()
        lblmsg.Visible = False
        dv.DataSource = Nothing
        sdt = startdt.Value
        edt = enddt.Value
        csh = 0
        Start1()
        Dim ds, ds1 As DataSet
        orderby = " scrl_dt"
        If cmborder.SelectedIndex = 1 Then
            orderby = " scrl_dt"
        End If
        If (rddetails.Checked = True) Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY  MAX(scrl_tp)) AS 'Sl.', ' '  AS 'Scroll No.', '" & Format(sdt, "dd/MM/yyyy") & "' AS 'Date.','Cash In Hand.' AS 'Transaction Details',STR(SUM(dr_amt),10,2) AS 'Debit Amt', STR(SUM(cr_amt),10,2) AS 'Credit Amt',STR(MAX(blnc_amt),10,2) AS 'Balance Amt.','Cash In Hand Upto " & Format(sdt, "dd/MMM/yyyy") & "' AS 'Remarks If Any' FROM print_cashbook WHERE scrl_dt < '" & Format(sdt, "dd/MMM/yyyy") & "'")
            ds1 = get_dataset("SELECT  ROW_NUMBER() OVER(ORDER BY slno) AS 'Sl.', scrl_tp + STR(scrl_no,10,0) AS 'Scroll No.', CONVERT(varchar,scrl_dt,103) AS 'Date.',tr_details AS 'Transaction Details', STR(dr_amt,10,2) AS 'Debit Amt', STR(cr_amt,10,2) AS 'Credit Amt',STR(blnc_amt,10,2) AS 'Balance Amt.', desc1 +' '+  desc2 +' '+ desc3 AS 'Remarks If Any' FROM print_cashbook WHERE (scrl_dt>='" & Format(sdt, "dd/MMM/yyyy") & "') AND (scrl_dt<='" & Format(edt, "dd/MMM/yyyy") & "') ORDER BY slno")
        ElseIf (rdabsdt.Checked = True) Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY  MAX(scrl_dt)) AS 'Sl.', '" & Format(sdt, "dd/MM/yyyy") & "' AS 'Date.','Cash In Hand Upto " & Format(sdt, "dd/MM/yyyy") & "' AS 'Transaction Details',STR(SUM(dr_amt),10,2) AS 'Debit Amt.', STR(SUM(cr_amt),10,2) AS 'Credit Amt.',STR(MAX(blnc_amt),10,2) AS 'Balance Amt.' FROM print_cashbook WHERE scrl_dt < '" & Format(sdt, "dd/MMM/yyyy") & "'")
            ds1 = get_dataset("SELECT ROW_NUMBER() OVER (ORDER BY scrl_dt) AS 'Sl.', CONVERT(varchar,scrl_dt,103) AS 'Date.', MAX(CASE WHEN scrl_tp='Mr' THEN 'Total MR Collection' WHEN scrl_tp='Pur' THEN 'Total Cash Purchase' WHEN scrl_tp='Pret' THEN 'Total Cash Purchase Return ' WHEN scrl_tp='Sale' THEN 'Total Cash Sales' WHEN scrl_tp='Sret' THEN 'Total Cash Sales Return' WHEN scrl_tp='Pay' THEN 'Total Payment' WHEN scrl_tp='Rec' THEN 'Total Recieve' END) AS 'Transaction Details', STR(SUM(dr_amt),10,2) AS 'Debit Amt.', STR(SUM(cr_amt),10,2) AS 'Credit Amt.', STR(MAX(blnc_amt),10,2) AS 'Balance Amt.' FROM print_cashbook WHERE (scrl_dt>='" & Format(sdt, "dd/MMM/yyyy") & "') AND (scrl_dt<='" & Format(edt, "dd/MMM/yyyy") & "') GROUP BY scrl_tp,scrl_dt")
        Else
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY  MAX(scrl_dt)) AS 'Sl.', 'Cash In Hand Upto " & Format(sdt, "dd/MM/yyyy") & "' AS 'Transaction Details',STR(SUM(dr_amt),10,2) AS 'Debit Amt.', STR(SUM(cr_amt),10,2) AS 'Credit Amt.',STR(MAX(blnc_amt),10,2) AS 'Balance Amt.' FROM print_cashbook WHERE scrl_dt < '" & Format(sdt, "dd/MMM/yyyy") & "'")
            ds1 = get_dataset("SELECT ROW_NUMBER() OVER (ORDER BY scrl_tp) AS 'Sl.',MAX(CASE WHEN scrl_tp='Mr' THEN 'Total MR Collection' WHEN scrl_tp='Pur' THEN 'Total Cash Purchase' WHEN scrl_tp='Pret' THEN 'Total Cash Purchase Return ' WHEN scrl_tp='Sale' THEN 'Total Cash Sales' WHEN scrl_tp='Sret' THEN 'Total Cash Sales Return' WHEN scrl_tp='Pay' THEN 'Total Payment' WHEN scrl_tp='Rec' THEN 'Total Recieve' END) AS 'Transaction Details', STR(SUM(dr_amt),10,2) AS 'Debit Amt.', STR(SUM(cr_amt),10,2) AS 'Credit Amt.', STR(MAX(blnc_amt),10,2) AS 'Balance Amt.' FROM print_cashbook WHERE (scrl_dt>='" & Format(sdt, "dd/MMM/yyyy") & "') AND (scrl_dt<='" & Format(edt, "dd/MMM/yyyy") & "') GROUP BY scrl_tp")
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            ds.Merge(ds1)
            dv.DataSource = ds.Tables(0)
            dramt = 0
            cramt = 0
            blamt = 0
            rw = 2
            GroupBox3.Text = "Cash Book Register In Abstract From " & Format(sdt, "dd/MM/yyyy") & " To " & Format(edt, "dd/MM/yyyy")
            If (rddetails.Checked = True) Then
                rw = rw + 2
                GroupBox3.Text = "Cash Book Register In Details From " & Format(sdt, "dd/MM/yyyy") & " To " & Format(edt, "dd/MM/yyyy")
            ElseIf (rdabsdt.Checked = True) Then
                rw = rw + 1
            End If
            pbstart()
            MDI.pb.Maximum = dv.Rows.Count + 1
            dramt = 0
            cramt = 0
            For i As Integer = 0 To dv.Rows.Count - 1
                dv.Rows(i).Cells(0).Value = i + 1
                If Not IsDBNull(dv.Rows(i).Cells(rw).Value) Then
                    dramt = dv.Rows(i).Cells(rw).Value
                End If
                If Not IsDBNull(dv.Rows(i).Cells(rw + 1).Value) Then
                    cramt = dv.Rows(i).Cells(rw + 1).Value
                End If
                blamt = blamt + (cramt - dramt)
                If Val(blamt) < 0 Then
                    dv.Rows(i).Cells(rw + 2).Value = Format(blamt * (-1), "########0.00") & "Dr"
                Else
                    dv.Rows(i).Cells(rw + 2).Value = Format(blamt, "#########0.00") & "Cr"
                End If
                pbincr()
            Next
            dv.Columns(rw).DefaultCellStyle.Format = "#######0.00"
            dv.Columns(rw).DefaultCellStyle.Alignment = 64
            dv.Columns(rw + 1).DefaultCellStyle.Format = "#######0.00"
            dv.Columns(rw + 1).DefaultCellStyle.Alignment = 64
            dv.Columns(rw + 2).DefaultCellStyle.Alignment = 64
            hddr = GroupBox3.Text
        Else
            lblmsg.Visible = True
        End If
        Close1()
        pbclose()
    End Sub

    Public Shared Function DateRange(ByVal Start As DateTime, ByVal Thru As DateTime) As IEnumerable(Of Date)
        Return Enumerable.Range(0, (Thru.Date - Start.Date).Days + 1).Select(Function(i) Start.AddDays(i))
    End Function

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Me.DATASTORE()
        Me.clr()
    End Sub

    Private Sub DATASTORE()
        Dim rw As Integer = 0
        Start1()
        SQLInsert("DELETE FROM print_cashbook WHERE usr_sl=" & usr_sl & "")
        Dim ds As DataSet
        'Dim ds1 As DataSet
        fnd = 0
        conditn = ""
        cr_amt = 0
        dr_amt = 0
        bal_amt = 0

        pbstart()
        x = DateDiff(DateInterval.Day, startdt.Value, enddt.Value)
        MDI.pb.Maximum = x + 1
        For Each Day As DateTime In DateRange(startdt.Value, enddt.Value)

            Dim dssl As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM print_cashbook")
            slno = 1
            If dssl.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(dssl.Tables(0).Rows(0).Item(0)) Then
                    slno = dssl.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            sdt = Day
            'Purchase Section
            ds = get_dataset("SELECT purch1.pur_no, purch1.pur_dt, purch1.pur_amt,purch1.nb, party.pname FROM purch1 LEFT OUTER JOIN party ON purch1.prt_code = party.prt_code WHERE purch1.pur_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (purch1.pur_type = '1') ORDER BY purch1.pur_dt")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("pur_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    amt = ds.Tables(0).Rows(i).Item("pur_amt")
                    nb = ds.Tables(0).Rows(i).Item("nb")
                    SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Pur'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "'," & Val(amt) & ",0,'" & nb & "','','',''," & usr_sl & ")")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()
            'Purchase Return Section
            ds = get_dataset("SELECT pret1.pret_no, pret1.pret_dt, pret1.pret_amt,pret1.nb, party.pname FROM pret1 LEFT OUTER JOIN party ON pret1.prt_code = party.prt_code WHERE pret1.pret_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (pret1.pret_type = '1') ORDER BY pret1.pret_dt")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("pret_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    amt = ds.Tables(0).Rows(i).Item("pret_amt")
                    nb = ds.Tables(0).Rows(i).Item("nb")
                    SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Pret'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'" & nb & "','','',''," & usr_sl & ")")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()
            'Sales Section
            ds = get_dataset("SELECT csale1.bill_no, csale1.bill_dt, csale1.sale_amt,csale1.nb, csale1.bl_name, party.pname FROM csale1 LEFT OUTER JOIN party ON csale1.prt_code = party.prt_code WHERE csale1.bill_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (csale1.bill_tp = '1') ORDER BY csale1.bill_dt")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("bill_no")
                    pname = ds.Tables(0).Rows(i).Item("bl_name")
                    amt = ds.Tables(0).Rows(i).Item("sale_amt")
                    nb = ds.Tables(0).Rows(i).Item("nb")
                    SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Sale'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'" & nb & "','','',''," & usr_sl & ")")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()
            'Sales Return Section
            ds = get_dataset("SELECT sret1.sret_no, sret1.sret_dt, sret1.sret_amt,sret1.nb, party.pname FROM sret1 LEFT OUTER JOIN party ON sret1.prt_code = party.prt_code WHERE sret1.sret_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (sret1.sret_type = '1') ORDER BY sret1.sret_dt")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("sret_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    amt = ds.Tables(0).Rows(i).Item("sret_amt")
                    nb = ds.Tables(0).Rows(i).Item("nb")
                    SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Sret'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "'," & Val(amt) & ",0,'" & nb & "','','',''," & usr_sl & ")")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()

            'Money Recipet Collection Section
            ds = get_dataset("SELECT mr.mr_no, mr.mr_dt, party.pname, mr.amt,mr.desc1,mr.desc2,mr.desc3 FROM mr LEFT OUTER JOIN party ON mr.prt_code = party.prt_code WHERE mr.mr_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (mr.pay_mode = '1') ORDER BY mr.mr_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("mr_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    amt = ds.Tables(0).Rows(i).Item("amt")
                    desc1 = ds.Tables(0).Rows(i).Item("desc1")
                    desc2 = ds.Tables(0).Rows(i).Item("desc2")
                    desc3 = ds.Tables(0).Rows(i).Item("desc3")
                    SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Mr'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'" & desc1 & "','" & desc2 & "','" & desc3 & "',''," & usr_sl & ")")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()
            'Recipet Collection Section
            ds = get_dataset("SELECT vouc.v_no, vouc.v_dt, party.pname, vouc.amt,vouc.desc1,vouc.desc2,vouc.desc3 FROM vouc LEFT OUTER JOIN party ON vouc.prt_code = party.prt_code WHERE vouc.v_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (vouc.pay_mode = '1') ORDER BY vouc.v_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("v_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    amt = ds.Tables(0).Rows(i).Item("amt")
                    desc1 = ds.Tables(0).Rows(i).Item("desc1")
                    desc2 = ds.Tables(0).Rows(i).Item("desc2")
                    desc3 = ds.Tables(0).Rows(i).Item("desc3")
                    SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Rec'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'" & desc1 & "','" & desc2 & "','" & desc3 & "',''," & usr_sl & ")")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()
            'Payment Collection Section
            ds = get_dataset("SELECT voucp.v_no, voucp.v_dt, voucp.amt, party.pname,voucp.desc1,voucp.desc2,voucp.desc3 FROM voucp LEFT OUTER JOIN party ON voucp.prt_code = party.prt_code WHERE voucp.v_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (voucp.pay_mode = '1') ORDER BY voucp.v_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("v_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    amt = ds.Tables(0).Rows(i).Item("amt")
                    desc1 = ds.Tables(0).Rows(i).Item("desc1")
                    desc2 = ds.Tables(0).Rows(i).Item("desc2")
                    desc3 = ds.Tables(0).Rows(i).Item("desc3")
                    SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Pay'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "'," & Val(amt) & ",0,'" & desc1 & "','" & desc2 & "','" & desc3 & "',''," & usr_sl & ")")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()
            pbincr()
        Next
        Close1()
        pbclose()
    End Sub

End Class
