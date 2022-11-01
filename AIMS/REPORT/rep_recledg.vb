Imports vb = Microsoft.VisualBasic
Public Class rep_recledg
    Dim comd As String

    Private Sub rep_recledg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_recledg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_recledg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        startdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        enddt.Value = startdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        comd = vb.Left(cmbreport.Text, 1)
        Panel2.Visible = True
        If comd = "M" Then
            Me.Text = "Money Reciept Ledger . . ."
        ElseIf comd = "R" Then
            Me.Text = "Reciept Ledger . . ."
        ElseIf comd = "P" Then
            Me.Text = "Payment Ledger . . ."
        Else
            Me.Text = "Journal Ledger . . ."
            Panel2.Visible = False
        End If
        hddr = Me.Text
        txtprtcd.Text = 0
        txtdipocd.Text = 0
        txtprttp.Text = ""
        cmborder.SelectedIndex = 0
        cmbpname.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False
        If chkprt.Checked = False Then
            cmbpname.Text = ""
        End If
        If chktype.Checked = False Then
            cmbprttp.Text = ""
        End If
        If chkdipo.Checked = False Then
            cmbdiponm.Text = ""
        End If
        If chkstaf.Checked = False Then
            cmbstaf.Text = ""
        End If
    End Sub

    Private Sub cmborder_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdiponm.Enter, cmbpname.Enter, cmborder.Enter, cmbprttp.Enter, cmbstaf.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub cmborder_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdiponm.Leave, cmbpname.Leave, cmborder.Leave, cmbprttp.Leave, cmbstaf.Leave
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
        If comd <> "J" Then
            key(cmbprttp, e)
        Else
            key(btnview, e)
        End If
    End Sub

    Private Sub cmbprttp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbprttp.KeyPress
        key(cmbpname, e)
        SPKey(e)
    End Sub

    Private Sub cmbsession_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpname.KeyPress
        key(cmbdiponm, e)
        SPKey(e)
    End Sub

    Private Sub cmbstream_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdiponm.KeyPress
        key(cmborder, e)
        SPKey(e)
    End Sub

    Private Sub cmborder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmborder.KeyPress
        key(btnview, e)
        SPKey(e)
    End Sub

    Private Sub cmbprttp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprttp.GotFocus
        populate(cmbprttp, "SELECT pt_name FROM prttype ORDER BY prt_type")
    End Sub

    Private Sub cmbprttp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprttp.LostFocus
        cmbprttp.Height = 21
    End Sub

    Private Sub cmbprttp_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprttp.Validated
        vdated(txtprttp, "SELECT prt_type FROM prttype WHERE pt_name='" & Trim(cmbprttp.Text) & "'")
    End Sub

    Private Sub cmbprttp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbprttp.Validating
        vdating(cmbprttp, "SELECT pt_name FROM prttype WHERE pt_name='" & Trim(cmbprttp.Text) & "'", "Please Select A Valid Party Account Type.")
    End Sub

    Private Sub cmbpname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname.GotFocus
        If chktype.Checked = True Then
            populate(cmbpname, "SELECT pname FROM party WHERE rec_lock='N' ORDER BY pname")
        Else
            populate(cmbpname, "SELECT pname FROM party WHERE rec_lock='N' AND prt_type='" & Trim(txtprttp.Text) & "' ORDER BY pname")
        End If
    End Sub

    Private Sub cmbpname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname.LostFocus
        cmbpname.Height = 21
    End Sub

    Private Sub cmbpname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbpname.Validated
        vdated(txtprtcd, "SELECT prt_code FROM party WHERE pname='" & Trim(cmbpname.Text) & "'")
    End Sub

    Private Sub cmbpname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbpname.Validating
        If chktype.Checked = True Then
            vdating(cmbpname, "SELECT pname FROM party WHERE pname='" & Trim(cmbpname.Text) & "' AND rec_lock='N'", "Please Select A Valid Session Name.")
        Else
            vdating(cmbpname, "SELECT pname FROM party WHERE pname='" & Trim(cmbpname.Text) & "' AND rec_lock='N' AND prt_type='" & Trim(txtprttp.Text) & "'", "Please Select A Valid Party Name.")
        End If
    End Sub

    Private Sub cmbdiponm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdiponm.GotFocus
        populate(cmbdiponm, "SELECT pname FROM party WHERE rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbdiponm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdiponm.LostFocus
        cmbdiponm.Height = 21
    End Sub

    Private Sub cmbdiponm_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdiponm.Validated
        vdated(txtdipocd, "SELECT prt_code FROM party WHERE pname='" & Trim(cmbdiponm.Text) & "'")
    End Sub

    Private Sub cmbdiponm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdiponm.Validating
        vdating(cmbdiponm, "SELECT pname FROM party WHERE pname='" & Trim(cmbdiponm.Text) & "' AND rec_lock='N'", "Please Select A Valid Session Name.")
    End Sub

    Private Sub cmbstaf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstaf.GotFocus
        populate(cmbstaf, "SELECT short_nm FROM staf WHERE(rec_lock = 'N')")
    End Sub

    Private Sub cmbstaf_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstaf.Validating
        vdating(cmbstaf, "SELECT short_nm FROM staf WHERE short_nm='" & Trim(cmbstaf.Text) & "'", "Please Enter A Valid Employee Name.")
    End Sub

    Private Sub cmbstaf_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstaf.Validated
        vdated(txtstafcd, "SELECT staf_sl FROM staf WHERE short_nm='" & Trim(cmbstaf.Text) & "'")
    End Sub

    Private Sub cmbstaf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstaf.LostFocus
        cmbstaf.Height = 21
    End Sub

    Private Sub chkprt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkprt.CheckedChanged
        If chkprt.Checked = True Then
            cmbpname.Text = "<<<  All  >>>"
            cmbpname.Enabled = False
            txtprtcd.Text = 0
        Else
            cmbpname.Text = ""
            cmbpname.Enabled = True
            cmbpname.Focus()
        End If
    End Sub

    Private Sub chkdipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdipo.CheckedChanged
        If chkdipo.Checked = True Then
            cmbdiponm.Text = "<<<  All  >>>"
            cmbdiponm.Enabled = False
            txtdipocd.Text = 0
        Else
            cmbdiponm.Text = ""
            cmbdiponm.Enabled = True
            cmbdiponm.Focus()
        End If
    End Sub

    Private Sub chktype_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktype.CheckedChanged
        If chktype.Checked = True Then
            cmbprttp.Text = "<<<  All  >>>"
            cmbprttp.Enabled = False
            txtprttp.Text = ""
        Else
            cmbprttp.Text = ""
            cmbprttp.Enabled = True
            cmbprttp.Focus()
        End If
    End Sub

    Private Sub chkstaf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkstaf.CheckedChanged
        If chkstaf.Checked = True Then
            cmbstaf.Text = "<<<  All  >>>"
            cmbstaf.Enabled = False
            txtstafcd.Text = 0
        Else
            cmbstaf.Text = ""
            cmbstaf.Enabled = True
            cmbstaf.Focus()
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
        lblmsg.Visible = False
        dv.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        conditn = ""
        orderby = ""
        If comd = "M" Then
            If chkprt.Checked = False Then
                conditn = "AND (mr.prt_code=" & Val(txtprtcd.Text) & ")"
            End If
            If chkdipo.Checked = False Then
                conditn = conditn & " AND (mr.by_code=" & Val(txtdipocd.Text) & ")"
            End If
            If chkstaf.Checked = False Then
                conditn = conditn & " AND (mr.staf_sl=" & Val(txtstafcd.Text) & ")"
            End If
            orderby = " mr.mr_dt"
            GroupBox3.Text = "Money Reciept Ledger From " & startdt.Value & " To " & enddt.Value
        ElseIf comd = "R" Then
            If chkprt.Checked = False Then
                conditn = "AND (vouc.prt_code=" & Val(txtprtcd.Text) & ")"
            End If
            If chkdipo.Checked = False Then
                conditn = conditn & " AND (vouc.by_code=" & Val(txtdipocd.Text) & ")"
            End If
            If chkstaf.Checked = False Then
                conditn = conditn & " AND (vouc.staf_sl=" & Val(txtstafcd.Text) & ")"
            End If
            orderby = " vouc.v_dt"
            GroupBox3.Text = "Reciept Ledger From " & startdt.Value & " To " & enddt.Value
        ElseIf comd = "P" Then
            If chkprt.Checked = False Then
                conditn = "AND (voucp.prt_code=" & Val(txtprtcd.Text) & ")"
            End If
            If chkdipo.Checked = False Then
                conditn = conditn & " AND (voucp.by_code=" & Val(txtdipocd.Text) & ")"
            End If
            If chkstaf.Checked = False Then
                conditn = conditn & " AND (voucp.staf_sl=" & Val(txtstafcd.Text) & ")"
            End If
            orderby = " voucp.v_dt"
            GroupBox3.Text = "Payment Ledger From " & startdt.Value & " To " & enddt.Value
        Else
            GroupBox3.Text = "Journal Ledger From " & startdt.Value & " To " & enddt.Value
        End If
        If cmborder.SelectedIndex = 1 Then
            orderby = " party.pname"
        End If
        If comd = "M" Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', CONVERT(VARCHAR,mr.mr_dt,103) AS 'Date', mr.mr_no AS 'MR.No',party.pname AS 'Party Name',staf.short_nm AS 'Coll. By', (CASE WHEN mr.pay_mode='1' THEN 'Cash' WHEN mr.pay_mode='2' THEN 'DD/Cheque' END) AS 'Mode', STR(mr.amt,10,2) AS 'Amount', (CASE WHEN mr.desc3<>'' THEN mr.desc1+','+mr.desc2+','+mr.desc3  WHEN mr.desc2<>'' THEN mr.desc1+','+mr.desc2 WHEN mr.desc1<>'' THEN mr.desc1 END) AS 'Voucher Details', (CASE WHEN mr.by_code=0 THEN '' WHEN mr.by_code<>0 THEN (SELECT pname FROM party WHERE party.prt_code=mr.by_code) END) AS 'Diposit A/c' FROM mr LEFT OUTER JOIN staf ON mr.staf_sl = staf.staf_sl LEFT OUTER JOIN party ON mr.prt_code = party.prt_code WHERE (mr.mr_dt>='" & Format(startdt.Value, "dd/MMM/yyyy") & "') AND (mr.mr_dt<='" & Format(enddt.Value, "dd/MMM/yyyy") & "')" & conditn & " ORDER BY " & orderby & "")
        ElseIf comd = "R" Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', CONVERT(VARCHAR,vouc.v_dt,103) AS 'Date', vouc.v_no AS 'V.No',party.pname AS 'Party Name',staf.short_nm AS 'Rec. By', (CASE WHEN vouc.pay_mode='1' THEN 'Cash' WHEN vouc.pay_mode='2' THEN 'DD/Cheque' END) AS 'Mode', STR(vouc.amt,10,2) AS 'Amount', (CASE WHEN vouc.desc3<>'' THEN vouc.desc1+','+vouc.desc2+','+vouc.desc3  WHEN vouc.desc2<>'' THEN vouc.desc1+','+vouc.desc2 WHEN vouc.desc1<>'' THEN vouc.desc1 END) AS 'Voucher Details', (CASE WHEN vouc.by_code=0 THEN '' WHEN vouc.by_code<>0 THEN (SELECT pname FROM party WHERE party.prt_code=vouc.by_code) END) AS 'Diposit A/c' FROM vouc LEFT OUTER JOIN staf ON vouc.staf_sl = staf.staf_sl LEFT OUTER JOIN party ON vouc.prt_code = party.prt_code WHERE (vouc.v_dt>='" & Format(startdt.Value, "dd/MMM/yyyy") & "') AND (vouc.v_dt<='" & Format(enddt.Value, "dd/MMM/yyyy") & "')" & conditn & " ORDER BY " & orderby & "")
        ElseIf comd = "P" Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', CONVERT(VARCHAR,voucp.v_dt,103) AS 'Date', voucp.v_no AS 'V.No',party.pname AS 'Party Name',staf.short_nm AS 'Paid By', (CASE WHEN voucp.pay_mode='1' THEN 'Cash' WHEN voucp.pay_mode='2' THEN 'DD/Cheque' END) AS 'Mode', STR(voucp.amt,10,2) AS 'Amount', (CASE WHEN voucp.desc3<>'' THEN voucp.desc1+','+voucp.desc2+','+voucp.desc3  WHEN voucp.desc2<>'' THEN voucp.desc1+','+voucp.desc2 WHEN voucp.desc1<>'' THEN voucp.desc1 END) AS 'Voucher Details', (CASE WHEN voucp.by_code=0 THEN '' WHEN voucp.by_code<>0 THEN (SELECT pname FROM party WHERE party.prt_code=voucp.by_code) END) AS 'Diposit A/c' FROM voucp LEFT OUTER JOIN staf ON voucp.staf_sl = staf.staf_sl LEFT OUTER JOIN party ON voucp.prt_code = party.prt_code WHERE (voucp.v_dt>='" & Format(startdt.Value, "dd/MMM/yyyy") & "') AND (voucp.v_dt<='" & Format(enddt.Value, "dd/MMM/yyyy") & "')" & conditn & " ORDER BY " & orderby & "")
        Else
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY jrn1.jr_no) AS 'Sl.',jrn1.jr_no AS 'Jr. No' ,CONVERT(VARCHAR,jrn1.jr_dt,103) AS 'Date', party.pname AS 'Name Of The Party',(CASE WHEN jrn2.jr_type='D' THEN STR(jrn2.amt,10,2) WHEN jrn2.jr_type='C' THEN '' END) AS 'Debit Amount',(CASE WHEN jrn2.jr_type='C' THEN STR(jrn2.amt,10,2) WHEN jrn2.jr_type='D' THEN ' ' END) AS 'Credit Amount', (CASE WHEN jrn1.desc3<>'' THEN jrn1.desc1+','+jrn1.desc2+','+jrn1.desc3  WHEN jrn1.desc2<>'' THEN jrn1.desc1+','+jrn1.desc2 WHEN jrn1.desc1<>'' THEN jrn1.desc1 END) AS 'Voucher Details' FROM jrn2 RIGHT OUTER JOIN jrn1 ON jrn2.jr_no = jrn1.jr_no LEFT OUTER JOIN party ON jrn2.prt_code = party.prt_code WHERE (jrn1.jr_dt>='" & Format(startdt.Value, "dd/MMM/yyyy") & "') AND (jrn1.jr_dt<='" & Format(enddt.Value, "dd/MMM/yyyy") & "') ORDER BY jrn1.jr_no")
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            hddr = GroupBox3.Text
        Else
            lblmsg.Visible = True
        End If
        Close1()
    End Sub

End Class
