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
        If comd = "R" Then
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
    End Sub

    Private Sub cmborder_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdiponm.Enter, cmbpname.Enter, cmborder.Enter, cmbprttp.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmborder_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdiponm.Leave, cmbpname.Leave, cmborder.Leave, cmbprttp.Leave

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
        If comd = "R" Then
            If chkprt.Checked = False Then
                conditn = "AND (voucr_coll.prt_code=" & Val(txtprtcd.Text) & ")"
            End If
            If chkdipo.Checked = False Then
                conditn = conditn & " AND (voucr_coll.by_code=" & Val(txtdipocd.Text) & ")"
            End If
            orderby = " voucr_coll.v_dt"
            GroupBox3.Text = "Reciept Ledger From " & startdt.Value & " To " & enddt.Value
        ElseIf comd = "P" Then
            If chkprt.Checked = False Then
                conditn = "AND (voucp_coll.prt_code=" & Val(txtprtcd.Text) & ")"
            End If
            If chkdipo.Checked = False Then
                conditn = conditn & " AND (voucp_coll.by_code=" & Val(txtdipocd.Text) & ")"
            End If
            orderby = " voucp_coll.v_dt"
            GroupBox3.Text = "Payment Ledger From " & startdt.Value & " To " & enddt.Value
        Else
            GroupBox3.Text = "Journal Ledger From " & startdt.Value & " To " & enddt.Value
        End If
        If cmborder.SelectedIndex = 1 Then
            orderby = " party.pname"
        End If
        If comd = "R" Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', CONVERT(VARCHAR,voucr_coll.v_dt,103) AS 'Date', voucr_coll.v_no AS 'V.No',party.pname AS 'Party Name', (CASE WHEN voucr_coll.pay_mode='1' THEN 'Cash' WHEN voucr_coll.pay_mode='2' THEN 'DD/Cheque' END) AS 'Mode', STR(voucr_coll.amt,10,2) AS 'Amount', (CASE WHEN voucr_coll.desc3<>'' THEN voucr_coll.desc1+','+voucr_coll.desc2+','+voucr_coll.desc3  WHEN voucr_coll.desc2<>'' THEN voucr_coll.desc1+','+voucr_coll.desc2 WHEN voucr_coll.desc1<>'' THEN voucr_coll.desc1 END) AS 'Voucher Details', (CASE WHEN voucr_coll.by_code=0 THEN '' WHEN voucr_coll.by_code<>0 THEN (SELECT pname FROM party WHERE party.prt_code=voucr_coll.by_code) END) AS 'Diposit A/c'FROM voucr_coll LEFT OUTER JOIN party ON voucr_coll.prt_code = party.prt_code WHERE (voucr_coll.v_dt>='" & Format(startdt.Value, "dd/MMM/yyyy") & "') AND (voucr_coll.v_dt<='" & Format(enddt.Value, "dd/MMM/yyyy") & "')" & conditn & " ORDER BY " & orderby & "")
        ElseIf comd = "P" Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', CONVERT(VARCHAR,voucp_coll.v_dt,103) AS 'Date', voucp_coll.v_no AS 'V.No',party.pname AS 'Party Name', (CASE WHEN voucp_coll.pay_mode='1' THEN 'Cash' WHEN voucp_coll.pay_mode='2' THEN 'DD/Cheque' END) AS 'Mode', STR(voucp_coll.amt,10,2) AS 'Amount', (CASE WHEN voucp_coll.desc3<>'' THEN voucp_coll.desc1+','+voucp_coll.desc2+','+voucp_coll.desc3  WHEN voucp_coll.desc2<>'' THEN voucp_coll.desc1+','+voucp_coll.desc2 WHEN voucp_coll.desc1<>'' THEN voucp_coll.desc1 END) AS 'Voucher Details', (CASE WHEN voucp_coll.by_code=0 THEN '' WHEN voucp_coll.by_code<>0 THEN (SELECT pname FROM party WHERE party.prt_code=voucp_coll.by_code) END) AS 'Diposit A/c'FROM voucp_coll LEFT OUTER JOIN party ON voucp_coll.prt_code = party.prt_code WHERE (voucp_coll.v_dt>='" & Format(startdt.Value, "dd/MMM/yyyy") & "') AND (voucp_coll.v_dt<='" & Format(enddt.Value, "dd/MMM/yyyy") & "')" & conditn & " ORDER BY " & orderby & "")
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
