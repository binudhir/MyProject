﻿
Imports vb = Microsoft.VisualBasic
Public Class frmparty
    Dim comd As String = "E"

    Private Sub frmparty_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuParty.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmparty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmparty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuParty.Enabled = False
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmparty_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Party/Head Of A/c Master . . ."
        txtscrl.Text = ""
        txtparty.Text = ""
        txtperson.Text = ""
        txtadd1.Text = ""
        txtcont1.Text = ""
        txtcont2.Text = ""
        txtmailid.Text = ""
        txtbill.Text = ""
        txtlimit.Text = "0"
        txtmarkcd.Text = ""
        txttrans.Text = "0.00"
        cmbmarket.Text = ""
        txtopbl.Text = "0.00"
        cmbactp.Text = ""
        txtregno.Text = ""
        txtcstno.Text = ""
        txtactp.Text = ""
        cmbcustom.SelectedIndex = 0
        cmblock.SelectedIndex = 0
        cmbbltp.SelectedIndex = 0
        cmbtrans.SelectedIndex = 0
        cmbinout.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(prt_code) as 'Max' FROM party")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtparty.Focus()
        Me.last_regd()
    End Sub

#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtparty.Enter, txttrans.Enter, txtcstno.Enter, txtregno.Enter, txtperson.Enter, txtopbl.Enter, txtlimit.Enter, txtcont2.Enter, txtcont1.Enter, txtbill.Enter, txtadd1.Enter, cmbtrans.Enter, cmbmarket.Enter, cmblock.Enter, cmbcustom.Enter, cmbbltp.Enter, cmbactp.Enter, cmbinout.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtparty.Leave, txttrans.Leave, txtcstno.Leave, txtregno.Leave, txtperson.Leave, txtopbl.Leave, txtlimit.Leave, txtcont2.Leave, txtcont1.Leave, txtbill.Leave, txtadd1.Leave, cmbtrans.Leave, cmbmarket.Leave, cmblock.Leave, cmbcustom.Leave, cmbbltp.Leave, cmbactp.Leave, cmbinout.Leave
        sender.text = UCase(sender.text)
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub txtmailid_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmailid.Enter
        sender.ForeColor = Color.Blue
        sender.BackColor = Color.LavenderBlush
    End Sub

    Private Sub txtmailid_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmailid.Leave
        txtmailid.Text = LCase(sender.text)
        sender.ForeColor = Color.Black
        sender.BackColor = Color.White
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtparty.KeyPress
        key(txtbill, e)
        SPKey(e)
    End Sub

    Private Sub txtbill_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbill.KeyPress
        key(txtperson, e)
        SPKey(e)
    End Sub

    Private Sub txtperson_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtperson.KeyPress
        key(txtadd1, e)
        SPKey(e)
    End Sub

    Private Sub txtadd1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd1.KeyPress
        key(txtcont1, e)
        SPKey(e)
    End Sub

    Private Sub txtcont1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont1.KeyPress
        key(txtcont2, e)
        NUM1(e)
    End Sub

    Private Sub txtcont2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont2.KeyPress
        key(txtmailid, e)
        NUM1(e)
    End Sub

    Private Sub txtmailid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmailid.KeyPress
        key(cmbactp, e)
        SPKey(e)
    End Sub

    Private Sub cmbactp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbactp.KeyPress
        key(cmbinout, e)
        SPKey(e)
    End Sub

    Private Sub cmbinout_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbinout.KeyPress
        key(txtopbl, e)
        SPKey(e)
    End Sub

    Private Sub txtopbl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtopbl.KeyPress
        key(cmbbltp, e)
        NUM1(e)
    End Sub

    Private Sub cmbbltp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbltp.KeyPress
        key(txtregno, e)
        SPKey(e)
    End Sub

    Private Sub txtregno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtregno.KeyPress
        key(txtcstno, e)
        SPKey(e)
    End Sub

    Private Sub txtcstno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcstno.KeyPress
        key(txttrans, e)
        SPKey(e)
    End Sub

    Private Sub txttrans_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttrans.KeyPress
        key(cmbtrans, e)
        NUM1(e)
    End Sub

    Private Sub cmbtrans_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtrans.KeyPress
        key(txtlimit, e)
        NUM1(e)
    End Sub

    Private Sub txtlimit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlimit.KeyPress
        key(cmbcustom, e)
        NUM1(e)
    End Sub

    Private Sub cmbcustom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcustom.KeyPress
        key(cmbmarket, e)
        SPKey(e)
    End Sub

    Private Sub cmbmarket_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbmarket.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub

#End Region

#Region "GotFocus/LostFocus"

    Private Sub txtparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtparty.LostFocus
        If Trim(txtbill.Text) = "" Then
            txtbill.Text = Trim(txtparty.Text)
        End If
    End Sub

    Private Sub sender_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtopbl.GotFocus, txttrans.GotFocus, txtlimit.GotFocus
        If Val(sender.text) = 0 Then
            sender.text = ""
        End If
    End Sub

    Private Sub sender_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtopbl.LostFocus, txttrans.LostFocus
        sender.text = Format(Val(sender.text), "######0.00")
    End Sub

#End Region

#Region "Combo Box"

    Private Sub cmbactp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbactp.GotFocus
        cmbactp.Height = 100
        populate(cmbactp, "SELECT pt_name FROM prttype ORDER BY prt_type")
    End Sub

    Private Sub cmbactp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbactp.LostFocus
        cmbactp.Height = 21
    End Sub

    Private Sub cmbactp_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbactp.Validated
        vdated(txtactp, "SELECT prt_type FROM prttype WHERE pt_name='" & Trim(cmbactp.Text) & "'")
    End Sub

    Private Sub cmbactp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbactp.Validating
        vdating(cmbactp, "SELECT pt_name FROM prttype WHERE pt_name='" & Trim(cmbactp.Text) & "'", "Please Select A Valid Account Type.")
    End Sub

    Private Sub cmbmarket_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmarket.GotFocus
        cmbmarket.Height = 100
        populate(cmbmarket, "SELECT ma_nm FROM market ORDER BY ma_nm")
    End Sub

    Private Sub cmbmarket_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmarket.LostFocus
        cmbmarket.Height = 21
    End Sub


    Private Sub cmbmarket_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmarket.Validated
        vdated(txtmarkcd, "SELECT ma_cd FROM market WHERE ma_nm='" & Trim(cmbmarket.Text) & "'")
    End Sub

    Private Sub cmbmarket_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmarket.Validating
        vdating(cmbmarket, "SELECT ma_nm FROM market WHERE ma_nm='" & Trim(cmbmarket.Text) & "'", "Please Select A Market Name.")
    End Sub

    Private Sub txtparty_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtparty.Validating
        If comd = "E" Then
            If txtparty.Text <> "" Then
                Dim ds As DataSet = get_dataset("SELECT pname FROM party WHERE pname='" & Trim(txtparty.Text) & "' AND rec_lock='N'")
                If ds.Tables(0).Rows.Count <> 0 Then
                    txtparty.Text = ""
                    txtbill.Text = ""
                    MessageBox.Show("Sorry The Party Name Already Present in Your Database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtparty.Focus()
                End If
            End If
        End If
    End Sub
#End Region

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click, cmnuadd.Click
        comd = "E"
        btnsave.Text = "Save."
        Me.Text = "Party/Head Of A/c Master Entry Screen . . ."
        Me.clr()
        For i As Integer = 0 To dv.Height = 10
            dv.Height = dv.Height - 1
        Next
        dv.Visible = False
        grpsearch.Visible = False
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click, cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Party/Head Of A/c Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(9).Value
            Me.dv_edit(slno)
            For i As Integer = 0 To dv.Width = 10
                dv.Width = dv.Width - 1
            Next
            dv.Visible = False
            grpsearch.Visible = False
            txtparty.Focus()
        End If
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        comd = "E"
        Me.clr()
        If dv.Visible = True Then
            Me.dv_disp()
        End If
    End Sub


    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click, btndelete.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            If usr_tp = "A" Or usr_tp = "D" Then
                slno = dv.SelectedRows(0).Cells(9).Value
                cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Start1()
                If cnfr = vbYes Then
                    Dim ds As DataSet = get_dataset("SELECT prt_code FROM party WHERE prt_code=" & Val(slno) & "")
                    If ds.Tables(0).Rows.Count <> 0 Then
                        Dim ds1 As DataSet = get_dataset("SELECT prt_code FROM purch1 WHERE prt_code=" & Val(slno) & "")
                        If ds1.Tables(0).Rows.Count <> 0 Then
                            fnd = 1
                        End If
                        Dim ds2 As DataSet = get_dataset("SELECT prt_code FROM csale1 WHERE prt_code=" & Val(slno) & "")
                        If ds2.Tables(0).Rows.Count <> 0 Then
                            fnd = 1
                        End If
                        Dim ds3 As DataSet = get_dataset("SELECT prt_code FROM serv1 WHERE prt_code=" & Val(slno) & "")
                        If ds3.Tables(0).Rows.Count <> 0 Then
                            fnd = 1
                        End If
                        Dim ds4 As DataSet = get_dataset("SELECT prt_code FROM mr WHERE prt_code=" & Val(slno) & "")
                        If ds4.Tables(0).Rows.Count <> 0 Then
                            fnd = 1
                        End If
                        Dim ds5 As DataSet = get_dataset("SELECT by_code FROM mr WHERE by_code=" & Val(slno) & "")
                        If ds5.Tables(0).Rows.Count <> 0 Then
                            fnd = 1
                        End If
                        If fnd = 0 Then
                            SQLInsert("DELETE FROM party WHERE prt_code =" & Val(slno) & "")
                            MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.dv_disp()
                        Else
                            MessageBox.Show("Sorry You Can't Delete The Party It Has Been Already Used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If
                    Close1()
                End If
            Else
                MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If cmbmarket.Text = "" Then
            txtmarkcd.Text = ""
        End If
        If Trim(txtparty.Text) = "" Then
            MessageBox.Show("Please Provide A Party Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtparty.Focus()
            Exit Sub
        End If
        If Trim(cmbactp.Text) = "" Then
            MessageBox.Show("Please Select A Account Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbactp.Focus()
            Exit Sub
        End If
        Me.prt_save()
    End Sub

#End Region

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub prt_save()
        sms = 0
        email = 0
        If chkautosm.Checked = True Then
            sms = 1
        End If
        If chkautoem.Checked = True Then
            email = 1
        End If
        opbl = txtopbl.Text
        trlim = txttrans.Text
        If cmbbltp.Text = "Dr." Then
            opbl = Val(txtopbl.Text) * (-1)
        End If
        If cmbtrans.Text = "Dr." Then
            trlim = Val(txttrans.Text) * (-1)
        End If
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(prt_code) as 'Max' FROM party")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO party (prt_code,pname,bname,add1,cont1,cont2,in_out,ma_cd,prt_type," & _
                          "lst_no,op_bal,bal_cd,tr_lim,lim_cd,lim_day,per_cont,grp_cd,opr_bal,bal_cd1,cust_cat," & _
                          "req_sms,mail,req_mail,rec_lock,cr_amt,dr_amt,rpt_cr,rpt_dr,rpt_cl,rpt_op,cst_no,cl_amt) VALUES (" & _
                          Val(txtscrl.Text) & ",'" & Trim(txtparty.Text) & "','" & Trim(txtbill.Text) & "','" & _
                          Trim(txtadd1.Text) & "','" & Trim(txtcont1.Text) & "','" & Trim(txtcont2.Text) & "','" & _
                          vb.Left(cmbinout.Text, 1) & "'," & Val(txtmarkcd.Text) & ",'" & Trim(txtactp.Text) & "','" & _
                          Trim(txtregno.Text) & "'," & Val(txtopbl.Text) & ",'" & vb.Left(cmbbltp.Text, 1) & "'," & _
                          Val(trlim) & ",'" & vb.Left(cmbtrans.Text, 1) & "'," & Val(txtlimit.Text) & ",'" & _
                          Trim(txtperson.Text) & "',0,0,'C','" & vb.Left(cmbcustom.Text, 1) & "','" & sms & "','" & _
                          Trim(txtmailid.Text) & "','" & email & "', '" & vb.Left(cmblock.Text, 1) & "',0,0,0,0,0,0,'" & _
                          Trim(txtcstno.Text) & "', " & Val(opbl) & ")")

                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Me.Text = "Party/Head Of A/c Master Entry Screen . . ."
                Close1()
            End If
        Else
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT prt_code FROM party WHERE prt_code=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE party SET pname='" & Trim(txtparty.Text) & "',bname='" & _
                          Trim(txtbill.Text) & "',per_cont='" & Trim(txtperson.Text) & "',cont1='" & _
                          Trim(txtcont1.Text) & "',cont2='" & Trim(txtcont2.Text) & "',add1='" & _
                          Trim(txtadd1.Text) & "',mail='" & Trim(txtmailid.Text) & "',prt_type='" & _
                          Trim(txtactp.Text) & "',in_out='" & vb.Left(cmbinout.Text, 1) & "',op_bal=" & _
                          Val(opbl) & ",bal_cd='" & vb.Left(cmbbltp.Text, 1) & "'," & "lst_no='" & _
                          Trim(txtregno.Text) & "' ,tr_lim=" & Val(trlim) & ",lim_cd='" & _
                          vb.Left(cmbtrans.Text, 1) & "',lim_day=" & Val(txtlimit.Text) & ",cust_cat='" & _
                          vb.Left(cmbcustom.Text, 1) & "',ma_cd=" & Val(txtmarkcd.Text) & ",req_sms='" & _
                          sms & "',req_mail='" & email & "', rec_lock='" & vb.Left(cmblock.Text, 1) & _
                          "',cst_no='" & Trim(txtcstno.Text) & "' WHERE prt_code =" & Val(txtscrl.Text) & "")
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                    Me.dv_disp()
                End If
                Close1()
            End If
        End If
    End Sub

    Private Sub dv_disp()
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY pname) AS 'Sl.', party.pname AS 'Party Name', party.add1 AS 'Address', party.cont1 AS 'Contact No.', party.lst_no AS 'Regd. No.', prttype.pt_name AS 'Account Type', market.ma_nm AS 'Market',(CASE WHEN party.cl_amt < 0 THEN STR(party.cl_amt * (-1),10,2) WHEN party.cl_amt = 0 THEN '0.00' WHEN party.cl_amt > 0 THEN STR(party.cl_amt,10,2) END) AS 'Balance',(CASE WHEN party.cl_amt < 0 THEN 'Dr.' WHEN party.cl_amt >= 0 THEN 'Cr.' END) AS ' ', party.prt_code,party.rec_lock FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type LEFT OUTER JOIN market ON party.ma_cd = market.ma_cd ORDER BY pname")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(9).Visible = False
            dv.Columns(10).Visible = False
            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(10).Value
                If reclock = "Y" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
        End If
        Close1()
        dv.Visible = True
        grpsearch.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT prttype.pt_name, market.ma_nm, party.* FROM party LEFT OUTER JOIN market ON party.ma_cd = market.ma_cd LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type WHERE (party.prt_code = " & Val(slno) & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtparty.Text = dsedit.Tables(0).Rows(0).Item("pname")
            txtbill.Text = dsedit.Tables(0).Rows(0).Item("bname")
            txtperson.Text = dsedit.Tables(0).Rows(0).Item("per_cont")
            txtadd1.Text = dsedit.Tables(0).Rows(0).Item("add1")
            txtcont1.Text = dsedit.Tables(0).Rows(0).Item("cont1")
            txtcont2.Text = dsedit.Tables(0).Rows(0).Item("cont2")
            txtmailid.Text = dsedit.Tables(0).Rows(0).Item("mail")
            cmbactp.Text = dsedit.Tables(0).Rows(0).Item("pt_name")
            cmbinout.Text = dsedit.Tables(0).Rows(0).Item("in_out")
            txtopbl.Text = Format(dsedit.Tables(0).Rows(0).Item("op_bal"), "#####0.00")
            txtregno.Text = dsedit.Tables(0).Rows(0).Item("lst_no")
            txtcstno.Text = dsedit.Tables(0).Rows(0).Item("cst_no")
            txttrans.Text = Format(dsedit.Tables(0).Rows(0).Item("tr_lim"), "#####0.00")
            txtlimit.Text = dsedit.Tables(0).Rows(0).Item("lim_day")
            cmbcustom.Text = dsedit.Tables(0).Rows(0).Item("cust_cat")
            If Not IsDBNull(dsedit.Tables(0).Rows(0).Item("ma_nm")) Then
                cmbmarket.Text = dsedit.Tables(0).Rows(0).Item("ma_nm")
            End If
            txtmarkcd.Text = dsedit.Tables(0).Rows(0).Item("ma_cd")
            txtactp.Text = dsedit.Tables(0).Rows(0).Item("prt_type")
            If Val(txtopbl.Text) < 0 Then
                txtopbl.Text = Format(Val(txtopbl.Text) * (-1), "#####0.00")
            End If
            If dsedit.Tables(0).Rows(0).Item("bal_cd") = "D" Then
                cmbbltp.SelectedIndex = 1
            Else
                cmbbltp.SelectedIndex = 0
            End If
            If Val(txttrans.Text) < 0 Then
                txttrans.Text = Format(Val(txttrans.Text) * (-1), "#####0.00")
            End If
            If dsedit.Tables(0).Rows(0).Item("lim_cd") = "D" Then
                cmbtrans.SelectedIndex = 1
            Else
                cmbtrans.SelectedIndex = 0
            End If
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
                cmblock.SelectedIndex = 1
            Else
                cmblock.SelectedIndex = 0
            End If
        End If
        Close1()
    End Sub

    Private Sub txtsersearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtadd.TextChanged
        Me.search()
    End Sub

    Private Sub search()
        Dim dssearch As DataSet
        If txtsername.Text <> "" And txtadd.Text <> "" Then
            If chkexact.Checked = False And chkexact1.Checked = False Then
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY pname) AS 'Sl.', party.pname AS 'Party Name', party.add1 AS 'Address', party.cont1 AS 'Contact No.', party.lst_no AS 'Regd. No.', prttype.pt_name AS 'Account Type', market.ma_nm AS 'Market',(CASE WHEN party.cl_amt < 0 THEN party.cl_amt * (-1) WHEN party.cl_amt = 0 THEN '0.00' WHEN party.cl_amt > 0 THEN STR(party.cl_amt,10,2) END) AS 'Balance',(CASE WHEN party.cl_amt < 0 THEN 'Dr.' WHEN party.cl_amt >= 0 THEN 'Cr.' END) AS ' ',party.prt_code,party.rec_lock  FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type LEFT OUTER JOIN market ON party.ma_cd = market.ma_cd  WHERE party.add1 LIKE '%" & Trim(txtadd.Text) & "%' AND party.pname LIKE '%" & Trim(txtsername.Text) & "%' ORDER BY pname")
            Else
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY pname) AS 'Sl.', party.pname AS 'Party Name', party.add1 AS 'Address', party.cont1 AS 'Contact No.', party.lst_no AS 'Regd. No.', prttype.pt_name AS 'Account Type', market.ma_nm AS 'Market',(CASE WHEN party.cl_amt < 0 THEN party.cl_amt * (-1) WHEN party.cl_amt = 0 THEN '0.00' WHEN party.cl_amt > 0 THEN STR(party.cl_amt,10,2) END) AS 'Balance',(CASE WHEN party.cl_amt < 0 THEN 'Dr.' WHEN party.cl_amt >= 0 THEN 'Cr.' END) AS ' ',party.prt_code,party.rec_lock  FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type LEFT OUTER JOIN market ON party.ma_cd = market.ma_cd  WHERE party.add1 LIKE '" & Trim(txtadd.Text) & "%' AND party.pname LIKE '" & Trim(txtsername.Text) & "%' ORDER BY pname")
            End If
        ElseIf txtadd.Text <> "" Then
            If chkexact.Checked = False Then
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY pname) AS 'Sl.', party.pname AS 'Party Name', party.add1 AS 'Address', party.cont1 AS 'Contact No.', party.lst_no AS 'Regd. No.', prttype.pt_name AS 'Account Type', market.ma_nm AS 'Market',(CASE WHEN party.cl_amt < 0 THEN party.cl_amt * (-1) WHEN party.cl_amt = 0 THEN '0.00' WHEN party.cl_amt > 0 THEN STR(party.cl_amt,10,2) END) AS 'Balance',(CASE WHEN party.cl_amt < 0 THEN 'Dr.' WHEN party.cl_amt >= 0 THEN 'Cr.' END) AS ' ',party.prt_code,party.rec_lock  FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type LEFT OUTER JOIN market ON party.ma_cd = market.ma_cd  WHERE party.add1 LIKE '%" & Trim(txtadd.Text) & "%' ORDER BY pname")
            Else
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY pname) AS 'Sl.', party.pname AS 'Party Name', party.add1 AS 'Address', party.cont1 AS 'Contact No.', party.lst_no AS 'Regd. No.', prttype.pt_name AS 'Account Type', market.ma_nm AS 'Market',(CASE WHEN party.cl_amt < 0 THEN party.cl_amt * (-1) WHEN party.cl_amt = 0 THEN '0.00' WHEN party.cl_amt > 0 THEN STR(party.cl_amt,10,2) END) AS 'Balance',(CASE WHEN party.cl_amt < 0 THEN 'Dr.' WHEN party.cl_amt >= 0 THEN 'Cr.' END) AS ' ',party.prt_code,party.rec_lock  FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type LEFT OUTER JOIN market ON party.ma_cd = market.ma_cd WHERE party.add1 LIKE '" & Trim(txtadd.Text) & "%'  ORDER BY pname")
            End If
        ElseIf txtsername.Text <> "" Then
            If chkexact1.Checked = False Then
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY pname) AS 'Sl.', party.pname AS 'Party Name', party.add1 AS 'Address', party.cont1 AS 'Contact No.', party.lst_no AS 'Regd. No.', prttype.pt_name AS 'Account Type', market.ma_nm AS 'Market',(CASE WHEN party.cl_amt < 0 THEN party.cl_amt * (-1) WHEN party.cl_amt = 0 THEN '0.00' WHEN party.cl_amt > 0 THEN STR(party.cl_amt,10,2) END) AS 'Balance',(CASE WHEN party.cl_amt < 0 THEN 'Dr.' WHEN party.cl_amt >= 0 THEN 'Cr.' END) AS ' ',party.prt_code,party.rec_lock  FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type LEFT OUTER JOIN market ON party.ma_cd = market.ma_cd WHERE party.pname LIKE '%" & Trim(txtsername.Text) & "%' ORDER BY pname")
            Else
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY pname) AS 'Sl.', party.pname AS 'Party Name', party.add1 AS 'Address', party.cont1 AS 'Contact No.', party.lst_no AS 'Regd. No.', prttype.pt_name AS 'Account Type', market.ma_nm AS 'Market',(CASE WHEN party.cl_amt < 0 THEN party.cl_amt * (-1) WHEN party.cl_amt = 0 THEN '0.00' WHEN party.cl_amt > 0 THEN STR(party.cl_amt,10,2) END) AS 'Balance',(CASE WHEN party.cl_amt < 0 THEN 'Dr.' WHEN party.cl_amt >= 0 THEN 'Cr.' END) AS ' ',party.prt_code,party.rec_lock  FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type LEFT OUTER JOIN market ON party.ma_cd = market.ma_cd  WHERE party.pname LIKE '" & Trim(txtsername.Text) & "%'   ORDER BY pname")
            End If
        Else
            dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY pname) AS 'Sl.', party.pname AS 'Party Name', party.add1 AS 'Address', party.cont1 AS 'Contact No.', party.lst_no AS 'Regd. No.', prttype.pt_name AS 'Account Type', market.ma_nm AS 'Market',(CASE WHEN party.cl_amt < 0 THEN party.cl_amt * (-1) WHEN party.cl_amt = 0 THEN '0.00' WHEN party.cl_amt > 0 THEN STR(party.cl_amt,10,2) END) AS 'Balance',(CASE WHEN party.cl_amt < 0 THEN 'Dr.' WHEN party.cl_amt >= 0 THEN 'Cr.' END) AS ' ',party.prt_code,party.rec_lock  FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type LEFT OUTER JOIN market ON party.ma_cd = market.ma_cd ORDER BY pname")
        End If
        dv.Columns.Clear()
        If dssearch.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dssearch.Tables(0)
            dv.Columns(9).Visible = False
            dv.Columns(10).Visible = False
            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(10).Value
                If reclock = "Y" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
        End If
    End Sub

    Private Sub txtsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsername.TextChanged
        Me.search()
    End Sub

    Private Sub chkexact_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkexact.CheckedChanged
        Me.search()
    End Sub

    Private Sub chkexact1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkexact1.CheckedChanged
        Me.search()
    End Sub

    Private Sub last_regd()
        lv.GridLines = True
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT TOP(6) pname  FROM party where rec_lock='N' Order By prt_code DESC")
        lv.Items.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                With lv
                    .Items.Add(dsedit.Tables(0).Rows(i).Item("pname"))
                    With .Items(.Items.Count - 1).SubItems
                        .Add(dsedit.Tables(0).Rows(i).Item("pname"))
                    End With
                End With
            Next
        End If
        Close1()
    End Sub

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub
End Class
