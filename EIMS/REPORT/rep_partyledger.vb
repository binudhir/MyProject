Imports vb = Microsoft.VisualBasic
Public Class rep_partyledger
    Dim comd As String

    Private Sub rep_partyledger_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_partyledger_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_partyledger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        chkdetail.Checked = True
        Me.clr()
        startdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        enddt.Value = startdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        Me.Text = "Party Head Of A/c Ledger . . ."
        hddr = Me.Text
        txtsesncd.Text = 0
        txtprttp.Text = 0
        txtprtcd.Text = 0
        txtprttp.Text = " "
        cmborder.SelectedIndex = 0
        cmbactp.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False
        'If chkparty.Checked = False Then
        cmbparty.Text = ""
        'End If
        If chkactp.Checked = False Then
            cmbactp.Text = ""
        End If
        Dim ds As DataSet = get_dataset("SELECT scrl_dt FROM print_prtledg ORDER BY scrl_dt DESC")
        If ds.Tables(0).Rows.Count <> 0 Then
            lblcsbk.Text = "The Party Ledger Is Updated Upto : " & Format(ds.Tables(0).Rows(0).Item(0), "dd/MMM/yyyy")
        Else
            lblcsbk.Text = "The Party Ledger Is Not Updated.Please Click Update Party Ledger To Update The Party Ledger."
        End If
    End Sub

    Private Sub cmborder_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbactp.Enter, cmborder.Enter, cmbparty.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub cmborder_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbactp.Leave, cmborder.Leave, cmbparty.Leave
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

    Private Sub enddt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles enddt.KeyPress
        If cmbactp.Enabled = True Then
            key(cmbactp, e)
        ElseIf cmbparty.Enabled = True Then
            key(cmbparty, e)
        Else
            key(cmborder, e)
        End If
    End Sub

    Private Sub cmbactp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbactp.KeyPress
        If cmbparty.Enabled = True Then
            key(cmbparty, e)
        Else
            key(cmborder, e)
        End If
        SPKey(e)
    End Sub

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(btnview, e)
        SPKey(e)
    End Sub

    Private Sub cmborder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmborder.KeyPress
        key(btnview, e)
        SPKey(e)
    End Sub

    Private Sub cmbactp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbactp.GotFocus
        populate(cmbactp, "SELECT pt_name FROM prttype ORDER BY prt_type")
    End Sub

    Private Sub cmbactp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbactp.LostFocus
        cmbactp.Height = 21
    End Sub

    Private Sub cmbactp_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbactp.Validated
        vdated(txtprttp, "SELECT prt_type FROM prttype WHERE pt_name='" & Trim(cmbactp.Text) & "'")
    End Sub

    Private Sub cmbactp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbactp.Validating
        vdating(cmbactp, "SELECT pt_name FROM prttype WHERE pt_name='" & Trim(cmbactp.Text) & "'", "Please Select A Valid Account Type.")
    End Sub

    Private Sub cmbparty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.GotFocus
        conditn = ""
        If chkactp.Checked = False Then
            conditn = "AND (prt_type='" & txtprttp.Text & "')"
        End If
        populate(cmbparty, "SELECT pname FROM party WHERE rec_lock='N' " & conditn & " ORDER BY pname")
    End Sub

    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.LostFocus
        cmbparty.Height = 21
    End Sub

    Private Sub cmbparty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.Validated
        vdated(txtprtcd, "SELECT prt_code FROM party WHERE pname='" & Trim(cmbparty.Text) & "'")
    End Sub

    Private Sub cmbparty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbparty.Validating
        conditn = ""
        If chkactp.Checked = False Then
            conditn = "AND (prt_type='" & txtprttp.Text & "')"
        End If
        vdating(cmbparty, "SELECT pname FROM party WHERE pname='" & Trim(cmbparty.Text) & "' AND rec_lock='N' " & conditn & "", "Please Select A Valid Party Name.")
    End Sub

    Private Sub chkactp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkactp.CheckedChanged
        If chkactp.Checked = True Then
            cmbactp.Text = "<<< All Accounts >>>"
            cmbactp.Enabled = False
            txtprttp.Text = 0
        Else
            cmbactp.Text = ""
            cmbactp.Enabled = True
            cmbactp.Focus()
        End If
    End Sub

    'Private Sub chkparty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkparty.Checked = True Then
    '        cmbparty.Text = "<<< All Party >>>"
    '        cmbparty.Enabled = False
    '        txtprtcd.Text = 0
    '    Else
    '        cmbparty.Text = ""
    '        cmbparty.Enabled = True
    '        cmbparty.Focus()
    '    End If
    'End Sub

    Private Sub chkdetail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdetail.CheckedChanged
        If (chkdetail.Checked = True) Then
            chkabstract.Checked = False
        Else
            chkabstract.Checked = True
        End If
    End Sub

    Private Sub chkabstract_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkabstract.CheckedChanged
        If (chkabstract.Checked = True) Then
            chkdetail.Checked = False
        Else
            chkdetail.Checked = True
        End If
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
        Start1()
        Dim ds As DataSet
        cramt = 0
        dramt = 0
        balamt = 0
        conditn = ""
        'If chkparty.Checked = False Then
        conditn = " AND (prt_code=" & Val(txtprtcd.Text) & ")"
        'End If

        'If chkactp.Checked = False Then
        '    conditn = " AND (prt_type='" & Trim(cmbactp.Text) & "')"
        'End If

        orderby = " scrl_dt"
        If cmborder.SelectedIndex = 1 Then
            orderby = " scrl_dt"
        End If

        If (chkdetail.Checked = True) Then
            ds = get_dataset("SELECT  ROW_NUMBER() OVER(ORDER BY slno) AS 'Sl.', scrl_tp + STR(scrl_no,10,0) AS 'Scroll No.', CONVERT(varchar,scrl_dt,103) AS 'Date.', desc1 +' '+  desc2 +' '+ desc3 AS 'Transction Detail',prt_type AS 'Party Type', STR(dr_amt,10,2) AS 'Debit Amt', STR(cr_amt,10,2) AS 'Credit Amt',STR(blnc_amt,10,2) AS 'Balance Amt.' FROM print_prtledg WHERE (scrl_dt >='" & Format(sdt, "dd/MMM/yyyy") & "') AND (scrl_dt <='" & Format(edt, "dd/MMM/yyyy") & "') " & conditn & " ORDER BY slno")
        Else
            ds = get_dataset("SELECT ROW_NUMBER() OVER (ORDER BY scrl_tp) AS 'Sl.',MAX(CASE WHEN scrl_tp='Op' THEN 'Opening Balance' WHEN scrl_tp='Pur' THEN 'Total Purchase' WHEN scrl_tp='Pret' THEN 'Total Purchase Return ' WHEN scrl_tp='Pay' THEN 'Total Payment' WHEN scrl_tp='Rec' THEN 'Total Recieve' WHEN scrl_tp='Jrn' THEN 'Total Jounral' WHEN scrl_tp='Bpur' THEN 'Total Book Purchase' END) AS 'Transaction Details', SUM(dr_amt) AS 'Debit Amt.', SUM(cr_amt) AS 'Credit Amt.', MAX(blnc_amt) AS 'Balance Amt.' FROM print_prtledg WHERE (scrl_dt >='" & Format(sdt, "dd/MMM/yyyy") & "') AND (scrl_dt <='" & Format(edt, "dd/MMM/yyyy") & "') " & conditn & " GROUP BY scrl_tp")
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            dramt = 0
            cramt = 0
            blamt = 0
            rw = 0
            GroupBox3.Text = "Party Ledger In Abstract Of Party " & cmbparty.Text & " From " & Format(sdt, "dd/MM/yyyy") & " To " & Format(edt, "dd/MM/yyyy")
            If (chkdetail.Checked = True) Then
                rw = 5
                GroupBox3.Text = "Party Ledger In Details Of Party " & cmbparty.Text & " From " & Format(sdt, "dd/MM/yyyy") & " To " & Format(edt, "dd/MM/yyyy")
            ElseIf (chkabstract.Checked = True) Then
                rw = 2
            End If
            pbstart()
            MDI.pb.Maximum = dv.Rows.Count + 1
            For i As Integer = 0 To dv.Rows.Count - 1
                dramt = dv.Rows(i).Cells(rw).Value
                cramt = dv.Rows(i).Cells(rw + 1).Value
                blamt = blamt + (cramt - dramt)
                If Val(blamt) < 0 Then
                    dv.Rows(i).Cells(rw + 2).Value = Format(blamt * (-1), "########0.00") & "Dr."
                Else
                    dv.Rows(i).Cells(rw + 2).Value = Format(blamt, "#########0.00") & "Cr."
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

    'Private Sub Party_ledg()
    '    ' Create an unbound DataGridView by declaring a column count.
    '    dv.ColumnCount = 7
    '    dv.ColumnHeadersVisible = True

    '    '' Set the column header style. 
    '    'Dim columnHeaderStyle As New DataGridViewCellStyle()

    '    'columnHeaderStyle.BackColor = Color.Beige
    '    'columnHeaderStyle.Font = New Font("Verdana", 10, FontStyle.Bold)
    '    'dv.ColumnHeadersDefaultCellStyle = columnHeaderStyle

    '    ' Set the column header names.
    '    dv.Columns(0).Name = "Sl."
    '    dv.Columns(1).Name = "Date"
    '    dv.Columns(2).Name = "Scrl No"
    '    dv.Columns(3).Name = "Transaction Details"
    '    dv.Columns(4).Name = "Debit Amount"
    '    dv.Columns(5).Name = "Credit Amount"
    '    dv.Columns(6).Name = "Balance Amount"
    '    dv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '    dv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '    dv.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '    Dim rw As Integer = 0
    '    Start1()
    '    Dim ds As DataSet
    '    Dim ds1 As DataSet
    '    fnd = 0
    '    conditn = ""
    '    cr_amt = 0
    '    dr_amt = 0
    '    bal_amt = 0


    '    ds10 = get_dataset("SELECT op_bal FROM party WHERE prt_code=" & Val(txtprtcd.Text) & " ")
    '    If ds10.Tables(0).Rows.Count <> 0 Then
    '        fnd = 1
    '        For i As Integer = 0 To ds10.Tables(0).Rows.Count - 1
    '            dv.Rows.Add()
    '            dv.Rows(rw).Cells(0).Value = rw + 1
    '            dv.Rows(rw).Cells(1).Value = ""
    '            dv.Rows(rw).Cells(2).Value = Format(startdt.Value, "dd/MM/yyyy")
    '            dv.Rows(rw).Cells(3).Value = "Opening Balance."
    '            If Val(ds10.Tables(0).Rows(i).Item("op_bal")) < 0 Then
    '                dv.Rows(rw).Cells(4).Value = Format(ds10.Tables(0).Rows(i).Item("op_bal") * (-1), "########0.00")
    '                dv.Rows(rw).Cells(5).Value = "0.00"
    '            Else
    '                dv.Rows(rw).Cells(4).Value = "0.00"
    '                dv.Rows(rw).Cells(5).Value = Format(ds10.Tables(0).Rows(i).Item("op_bal"), "########0.00")
    '            End If
    '            dv.Rows(rw).Cells(6).Value = Format(ds10.Tables(0).Rows(i).Item("op_bal"), "########0.00")
    '            rw = rw + 1
    '        Next
    '    End If

    '    For Each Day As DateTime In DateRange(startdt.Value, enddt.Value)
    '        Dim sdt As Date = Day
    '        'Dim dssem As DataSet = get_dataset("SELECT sem_cd FROM semester " & conditn & " ORDER by sem_pos")
    '        'If dssem.Tables(0).Rows.Count <> 0 Then
    '        '    For sem As Integer = 0 To dssem.Tables(0).Rows.Count - 1
    '        '        semcd = dssem.Tables(0).Rows(sem).Item(0)
    '        '        due_amt = 0
    '        '        coll_amt = 0
    '        ds = get_dataset("SELECT pur_no,pur_dt,pur_amt FROM purch1 WHERE pur_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND prt_code=" & Val(txtprtcd.Text) & " ")
    '        If ds.Tables(0).Rows.Count <> 0 Then
    '            fnd = 1
    '            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '                dv.Rows.Add()
    '                dv.Rows(rw).Cells(0).Value = rw + 1
    '                dv.Rows(rw).Cells(1).Value = "Pur - " & ds.Tables(0).Rows(i).Item("pur_no")
    '                dv.Rows(rw).Cells(2).Value = Format(ds.Tables(0).Rows(i).Item("pur_dt"), "dd/MM/yyyy")
    '                dv.Rows(rw).Cells(3).Value = "By Binod"
    '                dv.Rows(rw).Cells(4).Value = "0.00"
    '                dv.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(i).Item("pur_amt"), "########0.00")
    '                dv.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("pur_amt"), "########0.00")
    '                rw = rw + 1
    '            Next
    '        End If
    '        ds1 = get_dataset("SELECT bill_no,bill_dt,sale_amt FROM csale1 WHERE bill_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND prt_code=" & Val(txtprtcd.Text) & " ")
    '        If ds1.Tables(0).Rows.Count <> 0 Then
    '            fnd = 1
    '            For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
    '                dv.Rows.Add()
    '                dv.Rows(rw).Cells(0).Value = rw + 1
    '                dv.Rows(rw).Cells(1).Value = "Sal - " & ds1.Tables(0).Rows(i).Item("bill_no")
    '                dv.Rows(rw).Cells(2).Value = Format(ds1.Tables(0).Rows(i).Item("bill_dt"), "dd/MM/yyyy")
    '                dv.Rows(rw).Cells(3).Value = "By Binod"
    '                dv.Rows(rw).Cells(4).Value = Format(ds1.Tables(0).Rows(i).Item("sale_amt"), "########0.00")
    '                dv.Rows(rw).Cells(5).Value = "0.00"
    '                dv.Rows(rw).Cells(6).Value = Format(ds1.Tables(0).Rows(i).Item("sale_amt"), "########0.00")
    '                rw = rw + 1
    '            Next
    '        End If
    '        ds2 = get_dataset("SELECT v_no,v_dt,amt FROM voucp WHERE v_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND prt_code=" & Val(txtprtcd.Text) & " ")
    '        If ds2.Tables(0).Rows.Count <> 0 Then
    '            fnd = 1
    '            For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
    '                dv.Rows.Add()
    '                dv.Rows(rw).Cells(0).Value = rw + 1
    '                dv.Rows(rw).Cells(1).Value = "Pay - " & ds2.Tables(0).Rows(i).Item("v_no")
    '                dv.Rows(rw).Cells(2).Value = Format(ds2.Tables(0).Rows(i).Item("v_dt"), "dd/MM/yyyy")
    '                dv.Rows(rw).Cells(3).Value = "By Binod"
    '                dv.Rows(rw).Cells(4).Value = Format(ds2.Tables(0).Rows(i).Item("amt"), "########0.00")
    '                dv.Rows(rw).Cells(5).Value = "0.00"
    '                dv.Rows(rw).Cells(6).Value = Format(ds2.Tables(0).Rows(i).Item("amt"), "########0.00")
    '                rw = rw + 1
    '            Next
    '        End If
    '        ds3 = get_dataset("SELECT mr_no,mr_dt,amt FROM mr WHERE mr_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND prt_code=" & Val(txtprtcd.Text) & " ")
    '        If ds3.Tables(0).Rows.Count <> 0 Then
    '            fnd = 1
    '            For i As Integer = 0 To ds3.Tables(0).Rows.Count - 1
    '                dv.Rows.Add()
    '                dv.Rows(rw).Cells(0).Value = rw + 1
    '                dv.Rows(rw).Cells(1).Value = "MR - " & ds3.Tables(0).Rows(i).Item("mr_no")
    '                dv.Rows(rw).Cells(2).Value = Format(ds3.Tables(0).Rows(i).Item("mr_dt"), "dd/MM/yyyy")
    '                dv.Rows(rw).Cells(3).Value = "By Binod"
    '                dv.Rows(rw).Cells(4).Value = "0.00"
    '                dv.Rows(rw).Cells(5).Value = Format(ds3.Tables(0).Rows(i).Item("amt"), "########0.00")
    '                dv.Rows(rw).Cells(6).Value = Format(ds3.Tables(0).Rows(i).Item("amt"), "########0.00")
    '                rw = rw + 1
    '            Next
    '        End If
    '        '        ds1 = get_dataset("SELECT semester.sem_nm, collrec2.coll_no, collrec2.coll_dt, coll.coll_nm, collrec2.coll_amt FROM coll RIGHT OUTER JOIN collrec2 ON coll.coll_cd = collrec2.coll_cd LEFT OUTER JOIN semester ON collrec2.sem_cd = semester.sem_cd RIGHT OUTER JOIN stud ON collrec2.stud_sl = stud.stud_sl WHERE(stud.stud_sl = " & Val(txtstudsl.Text) & ") AND semester.sem_cd=" & Val(semcd) & " ORDER BY collrec2.coll_dt,collrec2.coll_no")
    '        '        If ds1.Tables(0).Rows.Count <> 0 Then
    '        '            fnd = 1
    '        '            For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
    '        '                dv.Rows.Add()
    '        '                dv.Rows(rw).Cells(0).Value = rw + 1
    '        '                dv.Rows(rw).Cells(1).Value = ds1.Tables(0).Rows(i).Item("sem_nm")
    '        '                dv.Rows(rw).Cells(2).Value = "Col-" & ds1.Tables(0).Rows(i).Item("coll_no")
    '        '                dv.Rows(rw).Cells(3).Value = Format(ds1.Tables(0).Rows(i).Item("coll_dt"), "dd/MM/yyyy")
    '        '                dv.Rows(rw).Cells(4).Value = ds1.Tables(0).Rows(i).Item("coll_nm")
    '        '                dv.Rows(rw).Cells(7).Value = Format(ds1.Tables(0).Rows(i).Item("coll_amt"), "########0.00")
    '        '                dv.Rows(rw).Cells(8).Value = Format(ds1.Tables(0).Rows(i).Item("coll_amt"), "########0.00")
    '        '                coll_amt = coll_amt + Val(ds1.Tables(0).Rows(i).Item("coll_amt"))
    '        '                coll_tot = coll_tot + Val(ds1.Tables(0).Rows(i).Item("coll_amt"))
    '        '                rw = rw + 1
    '        '            Next
    '        '        End If
    '        '        If Val(due_amt) <> 0 And Val(coll_amt) <> 0 Then
    '        '            dv.Rows.Add()
    '        '            dv.Rows(rw).Cells(0).Value = ""
    '        '            dv.Rows(rw).Cells(1).Value = ""
    '        '            dv.Rows(rw).Cells(2).Value = ""
    '        '            dv.Rows(rw).Cells(3).Value = ""
    '        '            dv.Rows(rw).Cells(4).Value = "TOTAL"
    '        '            dv.Rows(rw).Cells(5).Value = Format(due_amt, "########0.00")
    '        '            dv.Rows(rw).Cells(7).Value = Format(coll_amt, "########0.00")
    '        '            dv.Rows(rw).Cells(8).Value = Format(Val(due_amt) - Val(coll_amt), "########0.00")
    '        '            dv.Rows(rw).DefaultCellStyle.BackColor = Color.White
    '        '            dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Blue
    '        '            bal_tot = bal_tot + (Val(due_amt) - Val(coll_amt))
    '        '            rw = rw + 1
    '        '        End If
    '        ' Next
    '        '    If Val(due_tot) <> 0 And Val(coll_tot) <> 0 Then
    '        '        dv.Rows.Add()
    '        '        dv.Rows(rw).Cells(0).Value = ""
    '        '        dv.Rows(rw).Cells(1).Value = ""
    '        '        dv.Rows(rw).Cells(2).Value = ""
    '        '        dv.Rows(rw).Cells(3).Value = ""
    '        '        dv.Rows(rw).Cells(4).Value = "GRAND TOTAL"
    '        '        dv.Rows(rw).Cells(5).Value = Format(due_tot, "########0.00")
    '        '        dv.Rows(rw).Cells(7).Value = Format(coll_tot, "########0.00")
    '        '        dv.Rows(rw).Cells(8).Value = Format(Val(bal_tot), "########0.00")
    '        '        dv.Rows(rw).DefaultCellStyle.BackColor = Color.Pink
    '        '        dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Black
    '        '        rw = rw + 1
    '        '    End If
    '        'End If
    '    Next
    '    Close1()
    '    'If fnd = 0 Then
    '    '    dv.Columns.Clear()
    '    '    lblmsg.Visible = True
    '    'End If
    'End Sub

    Private Sub DATASTORE()
        'Create an unbound DataGridView by declaring a column count.

        '' Set the column header style. 
        'Dim columnHeaderStyle As New DataGridViewCellStyle()

        'columnHeaderStyle.BackColor = Color.Beige
        'columnHeaderStyle.Font = New Font("Verdana", 10, FontStyle.Bold)
        ' Set the column header names.
        Dim rw As Integer = 0
        slno = 1
        Start1()
        SQLInsert("DELETE FROM print_prtledg WHERE usr_sl=" & usr_sl & "")
        Dim ds, ds1 As DataSet
        ds1 = get_dataset("SELECT party.prt_code,party.op_bal, prttype.pt_name FROM prttype RIGHT OUTER JOIN party ON prttype.prt_type = party.prt_type  ORDER BY pname")
        If ds1.Tables(0).Rows.Count <> 0 Then
            For n As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                op_bal = Val(ds1.Tables(0).Rows(n).Item(1))
                prtcd = Val(ds1.Tables(0).Rows(n).Item(0))
                prttp = ds1.Tables(0).Rows(n).Item(2)
                fnd = 0
                'conditn = ""
                cr_amt = 0
                dr_amt = 0
                'bal_amt = 0
                If Val(op_bal) < 0 Then
                    dr_amt = op_bal * -(1)
                Else
                    cr_amt = op_bal
                End If
                SQLInsert("INSERT INTO print_prtledg (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                                     "desc3,blnc_amt,usr_sl,prt_code,prt_type) VALUES (" & Val(slno) & ",'" & _
                                     Format(startdt.Value, "dd/MMM/yyyy") & "','Op',0,'Openiing Balance'," & dr_amt & "," & Val(cr_amt) & ",'Opening Balance','','',''," & usr_sl & "," & _
                               Val(prtcd) & ",'" & prttp & "')")
                slno = slno + 1
            Next
        End If
        pbstart()
        x = DateDiff(DateInterval.Day, startdt.Value, enddt.Value)
        MDI.pb.Maximum = x + 1
        For Each Day As DateTime In DateRange(startdt.Value, enddt.Value)
            Dim dssl As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM print_prtledg")

            If dssl.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(dssl.Tables(0).Rows(0).Item(0)) Then
                    slno = dssl.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            sdt = Day
            'Purchase Section
            ds = get_dataset("SELECT purch1.pur_no, purch1.prt_code, purch1.pur_dt, purch1.pur_amt, purch1.nb, party.pname, prttype.pt_name,purch1.inv_no,purch1.inv_dt FROM prttype RIGHT OUTER JOIN party ON prttype.prt_type = party.prt_type RIGHT OUTER JOIN purch1 ON party.prt_code = purch1.prt_code WHERE purch1.pur_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (purch1.pur_type = '2') ORDER BY purch1.pur_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("pur_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    ptcd = ds.Tables(0).Rows(i).Item("prt_code")
                    prttp = ds.Tables(0).Rows(i).Item("pt_name")
                    amt = ds.Tables(0).Rows(i).Item("pur_amt")
                    nb = ds.Tables(0).Rows(i).Item("nb")
                    invno = ds.Tables(0).Rows(i).Item("inv_no")
                    invdt = Format(ds.Tables(0).Rows(i).Item("inv_dt"), "dd/MM/yyyy")
                    SQLInsert("INSERT INTO print_prtledg (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl,prt_code,prt_type) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Pur'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'" & nb & "','Inv No-" & invno & "','Inv Dt-" & invdt & "',''," & usr_sl & "," & _
                        Val(ptcd) & ",'" & prttp & "')")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()
            'Purchase Return Section
            ds = get_dataset("SELECT pret1.pret_no, pret1.prt_code, pret1.pret_dt, pret1.pret_amt, pret1.nb, party.pname, prttype.pt_name,pret1.ref_no,pret1.ref_dt FROM prttype RIGHT OUTER JOIN party ON prttype.prt_type = party.prt_type RIGHT OUTER JOIN pret1 ON party.prt_code = pret1.prt_code WHERE pret1.pret_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (pret1.pret_type = '2') ORDER BY pret1.pret_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("pret_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    ptcd = ds.Tables(0).Rows(i).Item("prt_code")
                    prttp = ds.Tables(0).Rows(i).Item("pt_name")
                    amt = ds.Tables(0).Rows(i).Item("pret_amt")
                    nb = ds.Tables(0).Rows(i).Item("nb")
                    refno = ds.Tables(0).Rows(i).Item("ref_no")
                    refdt = Format(ds.Tables(0).Rows(i).Item("ref_dt"), "dd/MM/yyyy")
                    SQLInsert("INSERT INTO print_prtledg (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl,prt_code,prt_type) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Pret'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'" & nb & "','Inv No-" & refno & "','Inv Dt-" & refdt & "',''," & usr_sl & "," & Val(ptcd) & ",'" & prttp & "')")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()
            'Recipet Collection Section for Party Code
            ds = get_dataset("SELECT voucr_coll.v_no, voucr_coll.v_dt,voucr_coll.prt_code, party.pname, voucr_coll.amt, voucr_coll.desc1, voucr_coll.desc2, voucr_coll.desc3, prttype.pt_name FROM prttype RIGHT OUTER JOIN party ON prttype.prt_type = party.prt_type RIGHT OUTER JOIN voucr_coll ON party.prt_code = voucr_coll.prt_code WHERE voucr_coll.v_dt='" & Format(sdt, "dd/MMM/yyyy") & "' ORDER BY voucr_coll.v_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("v_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    ptcd = ds.Tables(0).Rows(i).Item("prt_code")
                    prttp = ds.Tables(0).Rows(i).Item("pt_name")
                    amt = ds.Tables(0).Rows(i).Item("amt")
                    desc1 = ds.Tables(0).Rows(i).Item("desc1")
                    desc2 = ds.Tables(0).Rows(i).Item("desc2")
                    desc3 = ds.Tables(0).Rows(i).Item("desc3")
                    SQLInsert("INSERT INTO print_prtledg (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl,prt_code,prt_type) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Rec'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'" & desc1 & "','" & desc2 & "','" & desc3 & "',''," & usr_sl & "," & Val(ptcd) & ",'" & prttp & "')")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()

            'Recipet Collection Section For By Code
            ds = get_dataset("SELECT voucr_coll.v_no, voucr_coll.v_dt, party.pname, voucr_coll.amt,voucr_coll.by_code, voucr_coll.desc1, voucr_coll.desc2, voucr_coll.desc3, prttype.pt_name FROM prttype RIGHT OUTER JOIN party ON prttype.prt_type = party.prt_type RIGHT OUTER JOIN voucr_coll ON party.prt_code = voucr_coll.by_code WHERE voucr_coll.v_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (voucr_coll.by_code<>0) ORDER BY voucr_coll.v_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("v_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    ptcd = ds.Tables(0).Rows(i).Item("by_code")
                    'pname = ""
                    'If ptcd <> 0 Then
                    '    pname = ds.Tables(0).Rows(i).Item("pname")
                    'End If
                    prttp = ds.Tables(0).Rows(i).Item("pt_name")
                    amt = ds.Tables(0).Rows(i).Item("amt")
                    desc1 = ds.Tables(0).Rows(i).Item("desc1")
                    desc2 = ds.Tables(0).Rows(i).Item("desc2")
                    desc3 = ds.Tables(0).Rows(i).Item("desc3")
                    SQLInsert("INSERT INTO print_prtledg (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl,prt_code,prt_type) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Rec'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "'," & Val(amt) & ",0,'" & desc1 & "','" & desc2 & "','" & desc3 & "',''," & usr_sl & "," & Val(ptcd) & ",'" & prttp & "')")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()

            'Payment Voucher Section For Prt Code
            ds = get_dataset("SELECT voucp_coll.v_no, voucp_coll.v_dt,voucp_coll.prt_code, party.pname, voucp_coll.amt, voucp_coll.desc1, voucp_coll.desc2, voucp_coll.desc3, prttype.pt_name FROM prttype RIGHT OUTER JOIN party ON prttype.prt_type = party.prt_type RIGHT OUTER JOIN voucp_coll ON party.prt_code = voucp_coll.prt_code WHERE voucp_coll.v_dt='" & Format(sdt, "dd/MMM/yyyy") & "' ORDER BY voucp_coll.v_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("v_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    ptcd = ds.Tables(0).Rows(i).Item("prt_code")
                    prttp = ds.Tables(0).Rows(i).Item("pt_name")
                    amt = ds.Tables(0).Rows(i).Item("amt")
                    desc1 = ds.Tables(0).Rows(i).Item("desc1")
                    desc2 = ds.Tables(0).Rows(i).Item("desc2")
                    desc3 = ds.Tables(0).Rows(i).Item("desc3")
                    SQLInsert("INSERT INTO print_prtledg (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl,prt_code,prt_type) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Pay'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "'," & Val(amt) & ",0,'" & desc1 & "','" & desc2 & "','" & desc3 & "',''," & usr_sl & "," & Val(ptcd) & ",'" & prttp & "')")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()

            'Payment Voucher Section For By Code
            ds = get_dataset("SELECT voucp_coll.v_no, voucp_coll.v_dt,voucp_coll.by_code,voucp_coll.prt_code, party.pname, voucp_coll.amt, voucp_coll.desc1, voucp_coll.desc2, voucp_coll.desc3, prttype.pt_name FROM prttype RIGHT OUTER JOIN party ON prttype.prt_type = party.prt_type RIGHT OUTER JOIN voucp_coll ON party.prt_code = voucp_coll.by_code WHERE voucp_coll.v_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (voucp_coll.by_code<>0)  ORDER BY voucp_coll.v_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("v_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    ptcd = ds.Tables(0).Rows(i).Item("by_code")
                    'pname = ""
                    'If ptcd <> 0 Then
                    '    pname = ds.Tables(0).Rows(i).Item("pname")
                    'End If
                    prttp = ds.Tables(0).Rows(i).Item("pt_name")
                    amt = ds.Tables(0).Rows(i).Item("amt")
                    desc1 = ds.Tables(0).Rows(i).Item("desc1")
                    desc2 = ds.Tables(0).Rows(i).Item("desc2")
                    desc3 = ds.Tables(0).Rows(i).Item("desc3")
                    SQLInsert("INSERT INTO print_prtledg (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl,prt_code,prt_type) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Pay'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'" & desc1 & "','" & desc2 & "','" & desc3 & "',''," & usr_sl & "," & Val(ptcd) & ",'" & prttp & "')")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()

            'journal Voucher Section For credit side
            ds = get_dataset("SELECT jrn1.jr_dt, jrn1.desc1, jrn1.desc2, jrn1.desc3, jrn1.jr_no, jrn2.amt, jrn2.prt_code, party.pname, prttype.pt_name FROM party LEFT OUTER JOIN  prttype ON party.prt_type = prttype.prt_type RIGHT OUTER JOIN jrn2 ON party.prt_code = jrn2.prt_code RIGHT OUTER JOIN jrn1 ON jrn2.jr_no = jrn1.jr_no WHERE jrn1.jr_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (jrn2.jr_type = 'C') ORDER BY jrn1.jr_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("jr_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    ptcd = ds.Tables(0).Rows(i).Item("prt_code")
                    'pname = ""
                    'If ptcd <> 0 Then
                    '    pname = ds.Tables(0).Rows(i).Item("pname")
                    'End If
                    prttp = ds.Tables(0).Rows(i).Item("pt_name")
                    amt = ds.Tables(0).Rows(i).Item("amt")
                    desc1 = ds.Tables(0).Rows(i).Item("desc1")
                    desc2 = ds.Tables(0).Rows(i).Item("desc2")
                    desc3 = ds.Tables(0).Rows(i).Item("desc3")
                    SQLInsert("INSERT INTO print_prtledg (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl,prt_code,prt_type) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Jrn'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "',0," & Val(amt) & ",'" & desc1 & "','" & desc2 & "','" & desc3 & "',''," & usr_sl & "," & Val(ptcd) & ",'" & prttp & "')")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()

            'journal Voucher Section For debit side
            ds = get_dataset("SELECT jrn1.jr_dt, jrn1.desc1, jrn1.desc2, jrn1.desc3, jrn1.jr_no, jrn2.amt, jrn2.prt_code, party.pname, prttype.pt_name FROM party LEFT OUTER JOIN  prttype ON party.prt_type = prttype.prt_type RIGHT OUTER JOIN jrn2 ON party.prt_code = jrn2.prt_code RIGHT OUTER JOIN jrn1 ON jrn2.jr_no = jrn1.jr_no WHERE jrn1.jr_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (jrn2.jr_type = 'D') ORDER BY jrn1.jr_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("jr_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    ptcd = ds.Tables(0).Rows(i).Item("prt_code")
                    'pname = ""
                    'If ptcd <> 0 Then
                    '    pname = ds.Tables(0).Rows(i).Item("pname")
                    'End If
                    prttp = ds.Tables(0).Rows(i).Item("pt_name")
                    amt = ds.Tables(0).Rows(i).Item("amt")
                    desc1 = ds.Tables(0).Rows(i).Item("desc1")
                    desc2 = ds.Tables(0).Rows(i).Item("desc2")
                    desc3 = ds.Tables(0).Rows(i).Item("desc3")
                    SQLInsert("INSERT INTO print_prtledg (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl,prt_code,prt_type) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','Jrn'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "'," & Val(amt) & ",0,'" & desc1 & "','" & desc2 & "','" & desc3 & "',''," & usr_sl & "," & Val(ptcd) & ",'" & prttp & "')")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()

            'Book Purchase Section
            ds = get_dataset("SELECT bk_pur1.pur_no, bk_pur1.pur_dt, bk_pur1.gr_tot, bk_pur1.nb, bk_pur1.prt_code, party.pname, prttype.pt_name,bk_pur1.inv_no,bk_pur1.inv_dt FROM prttype RIGHT OUTER JOIN party ON prttype.prt_type = party.prt_type RIGHT OUTER JOIN bk_pur1 ON party.prt_code = bk_pur1.prt_code WHERE bk_pur1.pur_dt='" & Format(sdt, "dd/MMM/yyyy") & "' AND (bk_pur1.pur_tp = '2') ORDER BY bk_pur1.pur_dt ")
            If ds.Tables(0).Rows.Count <> 0 Then
                fnd = 1
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    scrlno = ds.Tables(0).Rows(i).Item("pur_no")
                    pname = ds.Tables(0).Rows(i).Item("pname")
                    ptcd = ds.Tables(0).Rows(i).Item("prt_code")
                    prttp = ds.Tables(0).Rows(i).Item("pt_name")
                    amt = ds.Tables(0).Rows(i).Item("gr_tot")
                    nb = ds.Tables(0).Rows(i).Item("nb")
                    invno = ds.Tables(0).Rows(i).Item("inv_no")
                    invdt = Format(ds.Tables(0).Rows(i).Item("inv_dt"), "dd/MM/yyyy")
                    SQLInsert("INSERT INTO print_prtledg (slno,scrl_dt,scrl_tp,scrl_no,tr_details,dr_amt,cr_amt,desc1,desc2," & _
                              "desc3,blnc_amt,usr_sl,prt_code,prt_type) VALUES (" & Val(slno) & ",'" & Format(sdt, "dd/MMM/yyyy") & "','BPur'," & _
                        Val(scrlno) & ",'" & Trim(pname) & "'," & Val(amt) & ",0,'" & nb & "','Inv No-" & invno & "','Inv Dt-" & invdt & "',''," & usr_sl & "," & _
                        Val(ptcd) & ",'" & prttp & "')")
                    slno = slno + 1
                Next
            End If
            ds.Tables.Clear()
            pbincr()
        Next
                Close1()
        pbclose()
    End Sub


    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Me.DATASTORE()
        Me.clr()
    End Sub


End Class
