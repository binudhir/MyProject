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
            ds1 = get_dataset("SELECT ROW_NUMBER() OVER (ORDER BY scrl_dt) AS 'Sl.', CONVERT(varchar,scrl_dt,103) AS 'Date.', MAX(CASE WHEN scrl_tp='Coll' THEN 'Total Student Collection' WHEN scrl_tp='Pur' THEN 'Total Cash Purchase' WHEN scrl_tp='Bpur' THEN 'Total Book Purchase' WHEN scrl_tp='Pret' THEN 'Total Cash Purchase Return ' WHEN scrl_tp='Pay' THEN 'Total Payment' WHEN scrl_tp='Rec' THEN 'Total Recieve' END) AS 'Transaction Details', STR(SUM(dr_amt),10,2) AS 'Debit Amt.', STR(SUM(cr_amt),10,2) AS 'Credit Amt.', STR(MAX(blnc_amt),10,2) AS 'Balance Amt.' FROM print_cashbook WHERE (scrl_dt>='" & Format(sdt, "dd/MMM/yyyy") & "') AND (scrl_dt<='" & Format(edt, "dd/MMM/yyyy") & "') GROUP BY scrl_tp,scrl_dt")
        Else
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY  MAX(scrl_dt)) AS 'Sl.', 'Cash In Hand Upto " & Format(sdt, "dd/MM/yyyy") & "' AS 'Transaction Details',STR(SUM(dr_amt),10,2) AS 'Debit Amt.', STR(SUM(cr_amt),10,2) AS 'Credit Amt.',STR(MAX(blnc_amt),10,2) AS 'Balance Amt.' FROM print_cashbook WHERE scrl_dt < '" & Format(sdt, "dd/MMM/yyyy") & "'")
            ds1 = get_dataset("SELECT ROW_NUMBER() OVER (ORDER BY scrl_tp) AS 'Sl.',MAX(CASE WHEN scrl_tp='Coll' THEN 'Total Student Collection' WHEN scrl_tp='Pur' THEN 'Total Cash Purchase' WHEN scrl_tp='Bpur' THEN 'Total Book Purchase' WHEN scrl_tp='Pret' THEN 'Total Cash Purchase Return ' WHEN scrl_tp='Pay' THEN 'Total Payment' WHEN scrl_tp='Rec' THEN 'Total Recieve' END) AS 'Transaction Details', STR(SUM(dr_amt),10,2) AS 'Debit Amt.', STR(SUM(cr_amt),10,2) AS 'Credit Amt.', STR(MAX(blnc_amt),10,2) AS 'Balance Amt.' FROM print_cashbook WHERE (scrl_dt>='" & Format(sdt, "dd/MMM/yyyy") & "') AND (scrl_dt<='" & Format(edt, "dd/MMM/yyyy") & "') GROUP BY scrl_tp")
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

    Private Sub DATASTORE1()
        'Create an unbound DataGridView by declaring a column count.

        '' Set the column header style. 
        'Dim columnHeaderStyle As New DataGridViewCellStyle()

        'columnHeaderStyle.BackColor = Color.Beige
        'columnHeaderStyle.Font = New Font("Verdana", 10, FontStyle.Bold)
        ' Set the column header names.
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


        'ds10 = get_dataset("SELECT op_bal FROM party WHERE prt_code=" & Val(txtprtcd.Text) & " ")
        'If ds10.Tables(0).Rows.Count <> 0 Then
        '    fnd = 1
        '    For i As Integer = 0 To ds10.Tables(0).Rows.Count - 1
        '        dv.Rows.Add()
        '        dv.Rows(rw).Cells(0).Value = rw + 1
        '        dv.Rows(rw).Cells(1).Value = ""
        '        dv.Rows(rw).Cells(2).Value = Format(startdt.Value, "dd/MM/yyyy")
        '        dv.Rows(rw).Cells(3).Value = "Opening Balance."
        '        If Val(ds10.Tables(0).Rows(i).Item("op_bal")) < 0 Then
        '            dv.Rows(rw).Cells(4).Value = Format(ds10.Tables(0).Rows(i).Item("op_bal") * (-1), "########0.00")
        '            dv.Rows(rw).Cells(5).Value = "0.00"
        '        Else
        '            dv.Rows(rw).Cells(4).Value = "0.00"
        '            dv.Rows(rw).Cells(5).Value = Format(ds10.Tables(0).Rows(i).Item("op_bal"), "########0.00")
        '        End If
        '        dv.Rows(rw).Cells(6).Value = Format(ds10.Tables(0).Rows(i).Item("op_bal"), "########0.00")
        '        rw = rw + 1
        '    Next
        'End If

        pbstart()
        x = DateDiff(DateInterval.Day, startdt.Value, enddt.Value)
        MDI.pb.Maximum = x + 1
        'For Each Day As DateTime In DateRange(startdt.Value, enddt.Value)

        Dim dssl As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM print_cashbook")
        slno = 1
        If dssl.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(dssl.Tables(0).Rows(0).Item(0)) Then
                slno = dssl.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        Dim sdt As Date = startdt.Value
        Dim edt As Date = enddt.Value
        'Purchase Section
        ds = get_dataset("SELECT pur_dt, SUM(pur_amt) AS amt FROM purch1 GROUP BY pur_dt WHERE (purch1.pur_dt>='" & Format(sdt, "dd/MMM/yyyy") & "') AND (purch1.pur_dt<='" & Format(edt, "dd/MMM/yyyy") & "' )> AND (purch1.pur_type = '1') ORDER BY purch1.pur_dt ")
        If ds.Tables(0).Rows.Count <> 0 Then
            fnd = 1
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                scrlno = 0
                pname = "Total Purchase"
                amt = ds.Tables(0).Rows(i).Item(1)
                SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                          "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Purchase'," & _
                    Val(scrlno) & ",'" & Trim(pname) & "'," & Val(amt) & ",0,'','','',''," & usr_sl & ")")
                slno = slno + 1
            Next
        End If
        ds.Tables.Clear()
        'Purchase Return Section
        ds = get_dataset("SELECT pret_dt, SUM(pret_amt) AS amt FROM pret1 GROUP BY pret_dt WHERE (pret1.pret_dt>='" & Format(sdt, "dd/MMM/yyyy") & "') AND (pret1.pret_dt<='" & Format(edt, "dd/MMM/yyyy") & "' )> AND (pret1.pret_type = '1') ORDER BY pret1.pret_dt")
        If ds.Tables(0).Rows.Count <> 0 Then
            fnd = 1
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                scrlno = 0
                pname = "Total Return"
                amt = ds.Tables(0).Rows(i).Item(1)
                SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                          "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Pret'," & _
                    Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'','','',''," & usr_sl & ")")
                slno = slno + 1
            Next
        End If
        ds.Tables.Clear()
        'Schedule Collection Section
        ds = get_dataset("SELECT coll_dt,SUM(tot_amt) AS amt  FROM collrec1 GROUP BY coll_dt WHERE (collrec1.coll_dt>='" & Format(sdt, "dd/MMM/yyyy") & "') AND (collrec1.coll_dt<='" & Format(edt, "dd/MMM/yyyy") & "' )> AND (collrec1.pay_mod = '1') ORDER BY collrec1.coll_dt ")
        If ds.Tables(0).Rows.Count <> 0 Then
            fnd = 1
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                scrlno = 0
                pname = "Total Collection"
                amt = ds.Tables(0).Rows(i).Item(1)
                SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                          "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Coll'," & _
                    Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'','','',''," & usr_sl & ")")
                slno = slno + 1
            Next
        End If
        ds.Tables.Clear()
        'Non Schedule Collection Section
        ds = get_dataset("SELECT coll_dt,SUM(tot_amt) AS amt  FROM collrec1 GROUP BY coll_dt WHERE (collrec1.coll_dt>='" & Format(sdt, "dd/MMM/yyyy") & "') AND (collrec1.coll_dt<='" & Format(edt, "dd/MMM/yyyy") & "' )> AND (collrec1.pay_mod = '1') ORDER BY collrec1.coll_dt ")
        If ds.Tables(0).Rows.Count <> 0 Then
            fnd = 1
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                scrlno = 0
                pname = "Total Collection"
                amt = ds.Tables(0).Rows(i).Item(1)
                SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                          "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Coll'," & _
                    Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'','','',''," & usr_sl & ")")
                slno = slno + 1
            Next
        End If
        ds.Tables.Clear()
        'Recipet Collection Section
        ds = get_dataset("SELECT v_dt, SUM(amt) AS amt FROM voucr_coll GROUP BY v_dt WHERE (voucr_coll.v_dt>='" & Format(sdt, "dd/MMM/yyyy") & "') AND (voucr_coll.v_dt<='" & Format(edt, "dd/MMM/yyyy") & "' )> AND (voucr_coll.pay_mode = '1') ORDER BY voucr_coll.v_dt ")
        If ds.Tables(0).Rows.Count <> 0 Then
            fnd = 1
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                scrlno = 0
                pname = "Recipet Collection"
                amt = ds.Tables(0).Rows(i).Item(1)
                SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                          "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Coll'," & _
                    Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'','','',''," & usr_sl & ")")
                slno = slno + 1
            Next
        End If
        ds.Tables.Clear()
        'Payment Collection Section
        ds = get_dataset("SELECT v_dt, SUM(amt) AS amt FROM voucp_coll GROUP BY v_dt WHERE (voucp_coll.v_dt>='" & Format(sdt, "dd/MMM/yyyy") & "') AND (voucp_coll.v_dt<='" & Format(edt, "dd/MMM/yyyy") & "' )> AND (voucp_coll.pay_mode = '1') ORDER BY voucp_coll.v_dt ")
        If ds.Tables(0).Rows.Count <> 0 Then
            fnd = 1
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                scrlno = 0
                pname = "Recipet Collection"
                amt = ds.Tables(0).Rows(i).Item(1)
                SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                          "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Coll'," & _
                    Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'','','',''," & usr_sl & ")")
                slno = slno + 1
            Next
        End If
        ds.Tables.Clear()
        pbincr()
        'Next
        Close1()
        pbclose()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Me.DATASTORE()
        Me.clr()
    End Sub

    Private Sub DATASTORE()
        'Create an unbound DataGridView by declaring a column count.

        '' Set the column header style. 
        'Dim columnHeaderStyle As New DataGridViewCellStyle()

        'columnHeaderStyle.BackColor = Color.Beige
        'columnHeaderStyle.Font = New Font("Verdana", 10, FontStyle.Bold)
        ' Set the column header names.
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


        'ds10 = get_dataset("SELECT op_bal FROM party WHERE prt_code=" & Val(txtprtcd.Text) & " ")
        'If ds10.Tables(0).Rows.Count <> 0 Then
        '    fnd = 1
        '    For i As Integer = 0 To ds10.Tables(0).Rows.Count - 1
        '        dv.Rows.Add()
        '        dv.Rows(rw).Cells(0).Value = rw + 1
        '        dv.Rows(rw).Cells(1).Value = ""
        '        dv.Rows(rw).Cells(2).Value = Format(startdt.Value, "dd/MM/yyyy")
        '        dv.Rows(rw).Cells(3).Value = "Opening Balance."
        '        If Val(ds10.Tables(0).Rows(i).Item("op_bal")) < 0 Then
        '            dv.Rows(rw).Cells(4).Value = Format(ds10.Tables(0).Rows(i).Item("op_bal") * (-1), "########0.00")
        '            dv.Rows(rw).Cells(5).Value = "0.00"
        '        Else
        '            dv.Rows(rw).Cells(4).Value = "0.00"
        '            dv.Rows(rw).Cells(5).Value = Format(ds10.Tables(0).Rows(i).Item("op_bal"), "########0.00")
        '        End If
        '        dv.Rows(rw).Cells(6).Value = Format(ds10.Tables(0).Rows(i).Item("op_bal"), "########0.00")
        '        rw = rw + 1
        '    Next
        'End If

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
            ds = get_dataset("SELECT purch1.pur_no, purch1.pur_dt, purch1.pur_amt,purch1.nb, party.pname FROM purch1 LEFT OUTER JOIN party ON purch1.prt_code = party.prt_code WHERE purch1.pur_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (purch1.pur_type = '1') ORDER BY purch1.pur_dt ")
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
            ds = get_dataset("SELECT pret1.pret_no, pret1.pret_dt, pret1.pret_amt,pret1.nb, party.pname FROM pret1 LEFT OUTER JOIN party ON pret1.prt_code = party.prt_code WHERE pret1.pret_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (pret1.pret_type = '1') ORDER BY pret1.pret_dt ")
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
            'Schedule Collection Section
            ds = get_dataset("SELECT stud.stud_nm, stud.reg_no, collrec1.tot_amt,collrec1.nb, collrec1.coll_dt, collrec1.coll_no, collrec1.nb FROM collrec1 LEFT OUTER JOIN stud ON collrec1.stud_sl = stud.stud_sl WHERE collrec1.coll_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (collrec1.pay_mod = '1') ORDER BY collrec1.coll_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("coll_no")
                    pname = ds.Tables(0).Rows(i).Item("stud_nm") & "(" & ds.Tables(0).Rows(i).Item("reg_no") & ")"
                    amt = ds.Tables(0).Rows(i).Item("tot_amt")
                    nb = ds.Tables(0).Rows(i).Item("nb")
                    SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Coll'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'" & nb & "','','',''," & usr_sl & ")")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()
            'Non Schedule Collection Section
            ds = get_dataset("SELECT stud.stud_nm, stud.reg_no, ocollrec1.tot_amt,ocollrec1.nb, ocollrec1.coll_dt, ocollrec1.coll_no, ocollrec1.nb FROM ocollrec1 LEFT OUTER JOIN stud ON ocollrec1.stud_sl = stud.stud_sl WHERE ocollrec1.coll_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (ocollrec1.pay_mod = '1') ORDER BY ocollrec1.coll_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("coll_no")
                    pname = ds.Tables(0).Rows(i).Item("stud_nm") & "(" & ds.Tables(0).Rows(i).Item("reg_no") & ")"
                    amt = ds.Tables(0).Rows(i).Item("tot_amt")
                    nb = ds.Tables(0).Rows(i).Item("nb")
                    SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Coll'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'" & nb & "','','',''," & usr_sl & ")")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()

            'Recipet Collection Section
            ds = get_dataset("SELECT voucr_coll.v_no, voucr_coll.v_dt, party.pname, voucr_coll.amt,voucr_coll.desc1,voucr_coll.desc2,voucr_coll.desc3 FROM voucr_coll LEFT OUTER JOIN party ON voucr_coll.prt_code = party.prt_code WHERE voucr_coll.v_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (voucr_coll.pay_mode = '1') ORDER BY voucr_coll.v_dt ")
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
            ds = get_dataset("SELECT voucp_coll.v_no, voucp_coll.v_dt, voucp_coll.amt, party.pname,voucp_coll.desc1,voucp_coll.desc2,voucp_coll.desc3 FROM voucp_coll LEFT OUTER JOIN party ON voucp_coll.prt_code = party.prt_code WHERE voucp_coll.v_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (voucp_coll.pay_mode = '1') ORDER BY voucp_coll.v_dt ")
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
            'Book Purchase Section
            ds = get_dataset("SELECT bk_pur1.pur_no, bk_pur1.pur_dt, bk_pur1.gr_tot, bk_pur1.nb, bk_pur1.prt_code, party.pname, prttype.pt_name FROM prttype RIGHT OUTER JOIN party ON prttype.prt_type = party.prt_type RIGHT OUTER JOIN bk_pur1 ON party.prt_code = bk_pur1.prt_code WHERE bk_pur1.pur_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (bk_pur1.pur_tp = '1') ORDER BY bk_pur1.pur_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("pur_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    amt = ds.Tables(0).Rows(i).Item("gr_tot")
                    nb = ds.Tables(0).Rows(i).Item("nb")
                    SQLInsert("INSERT INTO print_cashbook (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Coll'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'" & nb & "','','',''," & usr_sl & ")")
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
