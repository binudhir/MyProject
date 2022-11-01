﻿Imports vb = Microsoft.VisualBasic
Public Class frmmr
    Dim comd As String

    Private Sub frmmr_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnumr.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmmr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmmr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnumr.Enabled = False
        Me.clr()
        Me.dv_disp()
        vdt.Value = sys_date
    End Sub

    Private Sub frmmr_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Money Receipt . . ."
        lbladdress.Text = ""
        lbladdress1.Text = ""
        lblamt.Text = 0
        lbldisc.Text = 0
        lblprtbal.Text = "0.00 Cr."
        lbldipobal.Text = "0.00 Cr."
        txtvno.Text = ""
        txtvno.Text = ""
        cmbpname.Text = ""
        cmbrcmode.SelectedIndex = 0
        lbladdress.Text = ""
        txtamt.Text = "0.00"
        txtdiscamt.Text = "0.00"
        cmbrecfrm.Text = ""
        cmbdesc1.Text = ""
        cmbdesc2.Text = ""
        cmbdesc3.Text = ""
        cmbcollby.Text = ""
        txtcollcd.Text = 0
        chckclrdata.Checked = False
        'cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(mr_no) as 'Max' FROM mr")
        txtvno.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtvno.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        cmbpname.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, cmdview.Click
        Me.clr()
        Me.Text = "Money Receipt Entry Screen . . ."
        Me.dv_disp()
    End Sub

#Region "Enter/Leave"

    Private Sub txtvnm_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvno.Enter, txtdiscamt.Enter, txtamt.Enter, cmbdesc3.Enter, cmbdesc2.Enter, cmbdesc1.Enter, cmbrcmode.Enter, cmbpname.Enter, cmbrecfrm.Enter, cmbcollby.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub txtvnm_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvno.Leave, txtdiscamt.Leave, txtamt.Leave, cmbdesc3.Leave, cmbdesc2.Leave, cmbdesc1.Leave, cmbrcmode.Leave, cmbpname.Leave, cmbrecfrm.Leave, cmbcollby.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
        sender.text = UCase(sender.text)
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseEnter, btnsave.MouseEnter, btns1.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseLeave, btnsave.MouseLeave, btns1.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtvno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvno.KeyPress
        key(vdt, e)
        NUM(e)
    End Sub

    Private Sub vdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles vdt.KeyPress
        key(cmbpname, e)
    End Sub

    Private Sub cmbpname_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpname.KeyPress
        key(cmbcollby, e)
        SPKey(e)
    End Sub

    Private Sub cmbcollby_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcollby.KeyPress
        key(cmbrcmode, e)
        SPKey(e)
    End Sub

    Private Sub cmbrcmode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbrcmode.KeyPress
        key(txtamt, e)
        NUM1(e)
    End Sub

    Private Sub txtammnt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtamt.KeyPress
        If cmbrcmode.SelectedIndex = 0 Then
            key(txtdiscamt, e)
        Else
            key(cmbrecfrm, e)
        End If

        NUM1(e)
    End Sub

    Private Sub cmbrecfrm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbrecfrm.KeyPress
        key(cmbdesc1, e)
        SPKey(e)
    End Sub

    Private Sub cmbdescr1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdesc1.KeyPress
        key(cmbdesc2, e)
        SPKey(e)
    End Sub

    Private Sub cmbdescr2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdesc2.KeyPress
        key(cmbdesc3, e)
        SPKey(e)
    End Sub

    Private Sub cmbdescr3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdesc3.KeyPress
        key(btnsave, e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        key(btnsave, e)
    End Sub

#End Region

#Region "GotFocus/LostFocus"
    Private Sub txtammnt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamt.GotFocus, txtdiscamt.GotFocus
        If Val(sender.Text) = 0 Then
            sender.Text = ""
        End If
    End Sub

    Private Sub txtammnt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamt.LostFocus, txtdiscamt.LostFocus
        sender.Text = Format(Val(sender.Text), "######0.00")
    End Sub

#End Region



    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        Me.Text = "Money Receipt Entry Screen . . ."
        comd = "E"
        btnsave.Text = "Save"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Val(txtvno.Text) = 0 Then
            MessageBox.Show("Sorry The Voucher No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtamt.Focus()
            Exit Sub
        End If
        If Trim(cmbpname.Text) = "" Or Val(txtprtcd.Text) = 0 Then
            MessageBox.Show("Please Provide A Party/Head Of A/c Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbpname.Focus()
            Exit Sub
        End If
        If Val(txtamt.Text) = 0 Then
            MessageBox.Show("Sorry The Amount Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtamt.Focus()
            Exit Sub
        End If
        If cmbrcmode.SelectedIndex = 1 Then
            If Trim(cmbrecfrm.Text) = "" Or Val(txtbycd.Text) = 0 Then
                MessageBox.Show("Please Provide A Recieved From A/c Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbrecfrm.Focus()
                Exit Sub
            End If
            If Val(txtprtcd.Text) = Val(txtbycd.Text) Then
                MessageBox.Show("Sorry Both Account Should Not Be Equal.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbrecfrm.Focus()
                Exit Sub
            End If
        End If
        If Trim(cmbdesc1.Text) = "" Then
            MessageBox.Show("Please Provide At Least One Voucher Details.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbdesc1.Focus()
            Exit Sub
        End If
        Me.pay_save()

    End Sub

    Private Sub pay_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(mr_no) as 'Max' FROM mr")
                txtvno.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtvno.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO mr (mr_no,mr_dt,prt_code,amt,disc_amt,desc1,desc2,desc3,pay_mode,by_code," & _
                          "usr_ent,ent_date,usr_mod,mod_date,rec_lock,staf_sl) VALUES (" & Val(txtvno.Text) & ",'" & _
                          Format(vdt.Value, "dd/MMM/yyyy") & "'," & Val(txtprtcd.Text) & "," & Val(txtamt.Text) & "," & _
                          Val(txtdiscamt.Text) & ",'" & Trim(cmbdesc1.Text) & "','" & Trim(cmbdesc2.Text) & "','" & Trim(cmbdesc3.Text) & "','" & _
                          vb.Left(cmbrcmode.Text, 1) & "'," & Val(txtbycd.Text) & "," & Val(usr_sl) & ",'" & _
                          Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N'," & Val(txtcollcd.Text) & ")")
                SQLInsert("UPDATE party SET cr_amt=cr_amt + " & Val(txtamt.Text) + Val(txtdiscamt.Text) & ",cl_amt=cl_amt + " & Val(txtamt.Text) + Val(txtdiscamt.Text) & " WHERE prt_code=" & Val(txtprtcd.Text) & "")
                If Val(txtbycd.Text) <> 0 Then
                    SQLInsert("UPDATE party SET dr_amt=dr_amt + " & Val(txtamt.Text) & ",cl_amt=cl_amt - " & Val(txtamt.Text) & " WHERE prt_code=" & Val(txtbycd.Text) & "")
                End If
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cnfr = MessageBox.Show("Are You Sure The Printer Is Ready To Print The Money Receipt.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If cnfr = vbYes Then
                    Call mr_print(Val(txtvno.Text))
                End If
                Me.clr()
                Close1()
            End If
        Else
            If usr_tp = "O" Then
                MessageBox.Show("You Are Not Authorised to Modify The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT mr_no FROM mr WHERE mr_no=" & Val(txtvno.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE mr SET mr_dt='" & Format(vdt.Value, "dd/MMM/yyyy") & "',prt_code=" & Val(txtprtcd.Text) & ",amt=" & _
                              Val(txtamt.Text) & ",disc_amt=" & Val(txtdiscamt.Text) & ",desc1='" & Trim(cmbdesc1.Text) & "',desc2='" & Trim(cmbdesc2.Text) & "',desc3='" & _
                              Trim(cmbdesc3.Text) & "',pay_mode='" & vb.Left(cmbrcmode.Text, 1) & "',by_code=" & Val(txtbycd.Text) & ",usr_mod=" & _
                              Val(usr_sl) & ",mod_date='" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "',staf_sl=" & Val(txtcollcd.Text) & " WHERE mr_no =" & Val(txtvno.Text) & "")
                    'Delete Previous balance 
                    SQLInsert("UPDATE party SET cr_amt=cr_amt - " & Val(lblamt.Text) + Val(lbldisc.Text) & ",cl_amt=cl_amt - " & Val(lblamt.Text) + Val(lbldisc.Text) & " WHERE prt_code=" & Val(txtprtcd.Text) & "")
                    If Val(txtbycd.Text) <> 0 Then
                        SQLInsert("UPDATE party SET dr_amt=dr_amt - " & Val(lblamt.Text) & ",cl_amt=cl_amt + " & Val(lblamt.Text) & " WHERE prt_code=" & Val(txtbycd.Text) & "")
                    End If
                    'Update Current balance
                    SQLInsert("UPDATE party SET cr_amt=cr_amt + " & Val(txtamt.Text) + Val(txtdiscamt.Text) & ",cl_amt=cl_amt + " & Val(txtamt.Text) + Val(txtdiscamt.Text) & " WHERE prt_code=" & Val(txtprtcd.Text) & "")
                    If Val(txtbycd.Text) <> 0 Then
                        SQLInsert("UPDATE party SET dr_amt=dr_amt + " & Val(txtamt.Text) & ",cl_amt=cl_amt - " & Val(txtamt.Text) & " WHERE prt_code=" & Val(txtbycd.Text) & "")
                    End If
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
        Dim dsedit As DataSet = get_dataset("SELECT mr.mr_no AS 'Mr. No', CONVERT(VARCHAR,mr.mr_dt,103) AS 'Date', party.pname AS 'Party Head Of A/c Name',(CASE WHEN mr.pay_mode='1' THEN 'Cash' WHEN mr.pay_mode='2' THEN 'DD/Cheque' END) AS 'Mode',  STR(mr.amt,10,2) AS 'Amount', mr.desc1 AS 'Remarks', mr.rec_lock FROM mr LEFT OUTER JOIN party ON mr.prt_code = party.prt_code ORDER BY mr.mr_no DESC")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(6).Visible = False
            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(6).Value
                If reclock = "Y" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    'dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT party.pname, party.add1,party.cl_amt,staf.short_nm, mr.* FROM  mr LEFT OUTER JOIN staf ON mr.staf_sl = staf.staf_sl LEFT OUTER JOIN party ON mr.prt_code = party.prt_code WHERE mr.mr_no=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtvno.Text = slno
            vdt.Value = dsedit.Tables(0).Rows(0).Item("mr_dt")
            cmbpname.Text = ""
            If Not IsDBNull(dsedit.Tables(0).Rows(0).Item("pname")) Then
                cmbpname.Text = dsedit.Tables(0).Rows(0).Item("pname")
                lbladdress.Text = Trim(dsedit.Tables(0).Rows(0).Item("add1"))
                txtprtcd.Text = dsedit.Tables(0).Rows(0).Item("prt_code")
            End If
            cmbcollby.Text = dsedit.Tables(0).Rows(0).Item("short_nm")
            txtcollcd.Text = dsedit.Tables(0).Rows(0).Item("staf_sl")
            
            txtbycd.Text = dsedit.Tables(0).Rows(0).Item("by_code")
            cmbrcmode.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("pay_mode")) - 1
            txtamt.Text = Format(dsedit.Tables(0).Rows(0).Item("amt"), "######0.00")
            lblamt.Text = Format(dsedit.Tables(0).Rows(0).Item("amt"), "######0.00")
            txtdiscamt.Text = Format(dsedit.Tables(0).Rows(0).Item("disc_amt"), "######0.00")
            lbldisc.Text = Format(dsedit.Tables(0).Rows(0).Item("disc_amt"), "######0.00")
            cmbdesc1.Text = dsedit.Tables(0).Rows(0).Item("desc1")
            cmbdesc2.Text = dsedit.Tables(0).Rows(0).Item("desc2")
            cmbdesc3.Text = dsedit.Tables(0).Rows(0).Item("desc3")
            clamt = Val(dsedit.Tables(0).Rows(0).Item("cl_amt"))
            If clamt < 0 Then
                lblprtbal.Text = Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
            Else
                lblprtbal.Text = Format(clamt, "#######0.00") & " " & "Cr."
            End If
            If Val(txtbycd.Text) <> 0 Then
                Dim ds As DataSet = get_dataset("SELECT pname,add1,cl_amt FROM party WHERE (prt_code = " & Val(txtbycd.Text) & ")")
                If ds.Tables(0).Rows.Count <> 0 Then
                    cmbrecfrm.Text = ds.Tables(0).Rows(0).Item("pname")
                    lbladdress1.Text = ds.Tables(0).Rows(0).Item("add1")
                    clamt = Val(ds.Tables(0).Rows(0).Item("cl_amt"))
                    If clamt < 0 Then
                        lbldipobal.Text = Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
                    Else
                        lbldipobal.Text = Format(clamt, "#######0.00") & " " & "Cr."
                    End If
                End If
            End If
            'If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
            '    cmblock.SelectedIndex = 1
            'Else
            '    cmblock.SelectedIndex = 0
            'End If
        End If
        Close1()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
        Me.Text = "Money Receipt Entry Screen . . ."
        dv.Visible = False
        txtvno.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Money Receipt Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtvno.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            If usr_tp = "A" Or usr_tp = "D" Then
                slno = dv.SelectedRows(0).Cells(0).Value
                cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Start1()
                If cnfr = vbYes Then
                    Dim ds As DataSet = get_dataset("SELECT mr_no,amt,prt_code,by_code,disc_amt FROM mr WHERE mr_no=" & Val(slno) & "")
                    If ds.Tables(0).Rows.Count <> 0 Then
                        amt = ds.Tables(0).Rows(0).Item(1)
                        prtcd = ds.Tables(0).Rows(0).Item(2)
                        bycd = ds.Tables(0).Rows(0).Item(3)
                        discamt = ds.Tables(0).Rows(0).Item(4)
                        SQLInsert("UPDATE party SET cr_amt=cr_amt - " & Val(amt) + Val(discamt) & ",cl_amt=cl_amt - " & Val(amt) + Val(discamt) & " WHERE prt_code=" & Val(prtcd) & "")
                        If Val(txtbycd.Text) <> 0 Then
                            SQLInsert("UPDATE party SET dr_amt=dr_amt - " & Val(amt) & ",cl_amt=cl_amt + " & Val(amt) & " WHERE prt_code=" & Val(bycd) & "")
                        End If
                        SQLInsert("DELETE FROM mr WHERE mr_no =" & Val(slno) & "")
                        MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.dv_disp()
                    End If
                    Close1()
                End If
            Else
                MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub cmbpname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname.GotFocus
        lbladdress.Text = ""
        populate(cmbpname, "SELECT pname FROM party WHERE rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbpname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname.LostFocus
        cmbpname.Height = 21
    End Sub

    Private Sub cmbpname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname.Validated
        Dim ds As DataSet = get_dataset("SELECT prt_code,add1,cl_amt FROM party WHERE pname='" & Trim(cmbpname.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtprtcd.Text = ds.Tables(0).Rows(0).Item("prt_code")
            lbladdress.Text = Trim(ds.Tables(0).Rows(0).Item("add1"))
            clamt = Val(ds.Tables(0).Rows(0).Item("cl_amt"))
            If clamt < 0 Then
                lblprtbal.Text = Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
            Else
                lblprtbal.Text = Format(clamt, "#######0.00") & " " & "Cr."
            End If
        End If
    End Sub

    Private Sub cmbpname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbpname.Validating
        vdating(cmbpname, "SELECT pname FROM party WHERE rec_lock='N' AND pname='" & Trim(cmbpname.Text) & "'", "Please Select A Valid Party Head Of A/c Name.")
    End Sub

    Private Sub cmbrecfrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbrecfrm.GotFocus
        lbladdress1.Text = ""
        populate(cmbrecfrm, "SELECT pname FROM party WHERE rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbrecfrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbrecfrm.LostFocus
        cmbrecfrm.Height = 21
    End Sub

    Private Sub cmbrecfrm_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbrecfrm.Validated
        Dim ds As DataSet = get_dataset("SELECT prt_code,add1,cl_amt FROM party WHERE pname='" & Trim(cmbrecfrm.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtbycd.Text = ds.Tables(0).Rows(0).Item("prt_code")
            lbladdress1.Text = ds.Tables(0).Rows(0).Item("add1")
            clamt = Val(ds.Tables(0).Rows(0).Item("cl_amt"))
            If clamt < 0 Then
                lbldipobal.Text = Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
            Else
                lbldipobal.Text = Format(clamt, "#######0.00") & " " & "Cr."
            End If
        End If
    End Sub

    Private Sub cmbrecfrm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbrecfrm.Validating
        vdating(cmbrecfrm, "SELECT pname FROM party WHERE  pname='" & Trim(cmbrecfrm.Text) & "' AND rec_lock='N'", "Please Select A Valid Party Head Of A/c Name.")
    End Sub

    Private Sub cmbrcmode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbrcmode.SelectedIndexChanged
        If cmbrcmode.SelectedIndex = 0 Then
            cmbrecfrm.Text = ""
            cmbrecfrm.Enabled = False
            txtbycd.Text = 0
        Else
            cmbrecfrm.Enabled = True
        End If
    End Sub

    Private Sub cmbdesc1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesc1.GotFocus
        populate(cmbdesc1, "SELECT descr_nm FROM descr WHERE rec_lock='N'  ORDER BY descr_nm")
    End Sub

    Private Sub cmbdesc1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesc1.LostFocus
        cmbdesc1.Height = 21
    End Sub

    Private Sub cmbdesc2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesc2.GotFocus
        populate(cmbdesc2, "SELECT descr_nm FROM descr WHERE rec_lock='N' ORDER BY descr_nm")
    End Sub

    Private Sub cmbdesc2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesc2.LostFocus
        cmbdesc2.Height = 21
    End Sub

    Private Sub cmbdesc3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesc3.GotFocus
        populate(cmbdesc3, "SELECT descr_nm FROM descr WHERE rec_lock='N' ORDER BY descr_nm")
    End Sub

    Private Sub cmbdesc3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesc3.LostFocus
        cmbdesc3.Height = 21
    End Sub

    Private Sub btns1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btns1.Click
        If Trim(cmbdesc1.Text) <> "" Then
            Dim ds1 As DataSet = get_dataset("SELECT descr_nm FROM descr WHERE descr_nm='" & Trim(cmbdesc1.Text) & "'")
            If ds1.Tables(0).Rows.Count = 0 Then
                Dim ds As DataSet = get_dataset("SELECT max(descr_cd) as 'Max' FROM descr")
                mxno = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                Start1()
                SQLInsert("INSERT INTO descr (descr_cd,descr_nm,rec_lock) VALUES (" & Val(mxno) & ",'" & _
                          Trim(cmbdesc1.Text) & "','N')")
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Close1()
            End If
        End If
    End Sub

    Private Sub btns2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btns2.Click
        If Trim(cmbdesc2.Text) <> "" Then
            Dim ds1 As DataSet = get_dataset("SELECT descr_nm FROM descr WHERE descr_nm='" & Trim(cmbdesc2.Text) & "'")
            If ds1.Tables(0).Rows.Count = 0 Then
                Dim ds As DataSet = get_dataset("SELECT max(descr_cd) as 'Max' FROM descr")
                mxno = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                Start1()
                SQLInsert("INSERT INTO descr (descr_cd,descr_nm,rec_lock) VALUES (" & Val(mxno) & ",'" & _
                          Trim(cmbdesc2.Text) & "','N')")
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Close1()
            End If
        End If
    End Sub

    Private Sub btns3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btns3.Click
        If Trim(cmbdesc3.Text) <> "" Then
            Dim ds1 As DataSet = get_dataset("SELECT descr_nm FROM descr WHERE descr_nm='" & Trim(cmbdesc3.Text) & "'")
            If ds1.Tables(0).Rows.Count = 0 Then
                Dim ds As DataSet = get_dataset("SELECT max(descr_cd) as 'Max' FROM descr")
                mxno = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                Start1()
                SQLInsert("INSERT INTO descr (descr_cd,descr_nm,rec_lock) VALUES (" & Val(mxno) & ",'" & _
                          Trim(cmbdesc3.Text) & "','N')")
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Close1()
            End If
        End If
    End Sub

    Private Sub txtdiscamt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdiscamt.KeyPress
        If cmbrecfrm.Enabled = True Then
            key(cmbrecfrm, e)
        Else
            key(cmbdesc1, e)
        End If
    End Sub

    Private Sub cmbcollby_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcollby.GotFocus
        populate(cmbcollby, "SELECT short_nm FROM staf WHERE(rec_lock = 'N')")
    End Sub

    Private Sub cmbcollby_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcollby.Validating
        vdating(cmbcollby, "SELECT short_nm FROM staf WHERE short_nm='" & Trim(cmbcollby.Text) & "'", "Please Enter A Valid Employee Name.")
    End Sub

    Private Sub cmbcollby_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcollby.Validated
        vdated(txtcollcd, "SELECT staf_sl FROM staf WHERE short_nm='" & Trim(cmbcollby.Text) & "'")
    End Sub

    Private Sub cmbcollby_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcollby.LostFocus
        cmbcollby.Height = 21
    End Sub

    Private Sub cmnuprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuprint.Click
        If dv.SelectedRows.Count <> 0 Then
            slno = dv.SelectedRows(0).Cells(0).Value
            Start1()
            Call mr_print(slno)
            Close1()
        Else
            frmno = 6
            frmprnt.MdiParent = MDI
            frmprnt.Show()
        End If
    End Sub

    Private Sub btnprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprint.Click
        frmno = 6
        frmprnt.MdiParent = MDI
        frmprnt.Show()
    End Sub

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub
End Class


