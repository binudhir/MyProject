Imports vb = Microsoft.VisualBasic
Public Class frmporder
    Dim comd As String = "V"

    Private Sub frmporder_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuporder.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmporder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmporder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuporder.Enabled = False
        usrprmsn("mnuporder", cmnuadd, cmnuedit, cmenudel, cmenuview)
        comd = swapprmsn("mnuporder", comd)
        Me.clr()
    End Sub

    Private Sub frmporder_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        dvtrans.DataSource = Nothing
        txtsl.Text = "1"
        txtref.Text = "X"
        txtgrandtot.Text = "0.00"
        txtremark.Text = ""
        txtitcd.Text = 0
        txtprtcd.Text = 0
        cmbpriorty.SelectedIndex = 0
        cmbparty.Text = ""
        cmbproduct.Text = ""
        lbladdress.Text = ""
        lblbal.Text = ""
        lbldescri.Text = ""
        lblgrp.Text = ""
        orddt.Value = sys_date
        delvrdt.Value = sys_date
        dv1.Rows.Clear()
        If comd = "E" Then
            Me.Text = "Purchase Order Entry Screen...."
            Dim ds As DataSet = get_dataset("SELECT max(po_no) as 'Max' FROM porder1")
            txtordno.Text = 1
            txtordno.Focus()
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtordno.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            btnsave.Text = "Save"
        ElseIf comd = "M" Then
            Me.Text = "Purchase Order Modification Screen...."
            txtordno.Text = ""
            btnsave.Text = "Modify"
        ElseIf comd = "D" Then
            Me.Text = "Purchase Order Deletion Screen...."
            txtordno.Text = ""
            btnsave.Text = "Delete"
        Else
            Me.Text = "Purchase Order View Screen...."
            txtordno.Text = ""
            btnsave.Text = "View"
        End If
        Me.clr1()
    End Sub

    Private Sub clr1()
        txtquantity.Text = "0.000"
        txtfree.Text = "0.000"
        txtmrp.Text = "0.00"
        txtunit.Text = ""
        txtrate.Text = "0.00"
        txtamount.Text = "0.00"
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.dv_disp()
    End Sub

#Region "Enter/Leave"
    Private Sub txtamount_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtunit.Enter, txtremark.Enter, txtref.Enter, txtrate.Enter, txtquantity.Enter, txtordno.Enter, txtmrp.Enter, txtfree.Enter, cmbproduct.Enter, cmbpriorty.Enter, cmbparty.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub txtamount_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtunit.Leave, txtremark.Leave, txtref.Leave, txtrate.Leave, txtquantity.Leave, txtordno.Leave, txtmrp.Leave, txtfree.Leave, cmbproduct.Leave, cmbpriorty.Leave, cmbparty.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnset.MouseEnter, btnsave.MouseEnter, btnref.MouseEnter, btnprint.MouseEnter, btnnxt.MouseEnter, btninter.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnset.MouseLeave, btnsave.MouseLeave, btnref.MouseLeave, btnprint.MouseLeave, btnnxt.MouseLeave, btninter.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "Key Press"
    Private Sub txtorder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtordno.KeyPress
        key(cmbpriorty, e)
        NUM(e)
    End Sub

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(orddt, e)
        SPKey(e)
    End Sub

    Private Sub cmbpriorty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpriorty.KeyPress
        key(txtref, e)
        SPKey(e)
    End Sub

    Private Sub txtref_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtref.KeyPress
        key(cmbparty, e)
        NUM(e)
    End Sub

    Private Sub dtorder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles orddt.KeyPress
        key(delvrdt, e)
    End Sub

    Private Sub dtdeli_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles delvrdt.KeyPress
        key(cmbproduct, e)
    End Sub

    Private Sub cmbproduct_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbproduct.KeyPress
        If cmbproduct.Text <> "" Then
            key(txtquantity, e)
        Else
            key(txtremark, e)
        End If
        SPKey(e)
    End Sub

    Private Sub txtquantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtquantity.KeyPress
        key(txtfree, e)
        NUM1(e)
    End Sub

    Private Sub txtfree_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfree.KeyPress
        key(txtmrp, e)
        NUM1(e)
    End Sub

    Private Sub txtunit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtunit.KeyPress
        key(txtmrp, e)
        NUM(e)
    End Sub

    Private Sub txtmrp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmrp.KeyPress
        key(txtrate, e)
        NUM(e)
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        key(btnnxt, e)
        NUM1(e)
    End Sub

    Private Sub txtamount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtamount.KeyPress
        key(txtremark, e)
        NUM1(e)
    End Sub

    Private Sub txtremark_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtremark.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub
#End Region

#Region "Got/Lost Focus"
    'Private Sub txtorder_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtordno.GotFocus
    '    If txtordno.Text = "1" Then
    '        txtordno.Text = ""
    '    End If
    'End Sub

    'Private Sub txtorder_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtordno.LostFocus
    '    If txtordno.Text = "" Then
    '        txtordno.Text = "1"
    '    End If
    'End Sub

    Private Sub txtref_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtref.GotFocus
        If txtref.Text = "X" Then
            txtref.Text = ""
        End If
    End Sub

    Private Sub txtref_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtref.LostFocus
        If txtref.Text = "" Then
            txtref.Text = "X"
        End If
    End Sub

    Private Sub txtquantity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquantity.GotFocus, txtfree.GotFocus
        If Val(sender.Text) = 0 Then
            sender.Text = ""
        End If
    End Sub

    Private Sub txtquantity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquantity.LostFocus, txtfree.LostFocus
        sender.Text = Format(Val(sender.Text), "########0.000")
    End Sub

    Private Sub txtmrp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmrp.GotFocus, txtrate.GotFocus
        If Val(sender.Text) = 0 Then
            sender.Text = ""
        End If
    End Sub

    Private Sub txtmrp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmrp.LostFocus, txtrate.LostFocus
        sender.Text = Format(Val(sender.Text), "########0.00")
    End Sub
#End Region

#Region "Combo Box"
    Private Sub cmbparty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.GotFocus
        lbladdress.Text = ""
        lblbal.Text = ""
        populate(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.LostFocus
        cmbparty.Height = 21
    End Sub

    Private Sub cmbparty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.Validated
        Dim ds As DataSet = get_dataset("SELECT prt_code,add1,cl_bal FROM party WHERE pname='" & Trim(cmbparty.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtprtcd.Text = ds.Tables(0).Rows(0).Item("prt_code")
            lbladdress.Text = Trim(ds.Tables(0).Rows(0).Item("add1"))
            lblbal.Text = Format(ds.Tables(0).Rows(0).Item("cl_bal"), "#######0.00")
        End If
    End Sub

    Private Sub cmbparty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbparty.Validating
        vdating(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' AND pname='" & Trim(cmbparty.Text) & "'", "Please Select A Valid Party Head Of A/c Name.")
    End Sub

    Private Sub cmbproduct_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.GotFocus
        txtitcd.Text = 0
        lbldescri.Text = ""
        lblgrp.Text = ""
        populate(cmbproduct, "SELECT it_name FROM item WHERE (rec_lock = 'N') ORDER BY it_name")
    End Sub

    Private Sub cmbproduct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.LostFocus
        cmbproduct.Height = 21
    End Sub

    Private Sub cmbproduct_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbproduct.Validated
        Dim ds As DataSet = get_dataset("SELECT item.it_cd,item.mrp,item.pur_rate, item_group.grp_nm, item.it_desc,item.unt1 FROM item LEFT OUTER JOIN item_group ON item.grp_cd = item_group.grp_cd WHERE item.it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtitcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            lbldescri.Text = Trim(ds.Tables(0).Rows(0).Item("it_desc"))
            lblgrp.Text = Trim(ds.Tables(0).Rows(0).Item("grp_nm"))
            txtunit.Text = Trim(ds.Tables(0).Rows(0).Item("unt1"))
            txtmrp.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            txtrate.Text = Format(ds.Tables(0).Rows(0).Item("pur_rate"), "#######0.00")
            If Val(txtprtcd.Text) <> 0 Or Val(txtitcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
    End Sub

    Private Sub cmbproduct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.TextChanged
        Dim ds As DataSet = get_dataset("SELECT it_cd,cl_stk,unt1,mrp,pur_rate FROM item WHERE item.it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtitcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            lblsnd.Text = Format(ds.Tables(0).Rows(0).Item("cl_stk"), "#######0.000")
            lblsndunt.Text = Trim(ds.Tables(0).Rows(0).Item("unt1"))
            txtunit.Text = Trim(ds.Tables(0).Rows(0).Item("unt1"))
            txtmrp.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            txtrate.Text = Format(ds.Tables(0).Rows(0).Item("pur_rate"), "#######0.00")
            If Val(txtprtcd.Text) <> 0 Or Val(txtitcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
    End Sub

    Private Sub cmbproduct_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbproduct.Validating
        vdating(cmbproduct, "SELECT it_name FROM item WHERE (it_name = '" & Trim(cmbproduct.Text) & "')", "Please Select a Valid Product Name.")
    End Sub
#End Region

#Region "Botton"
    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
    End Sub

    Private Sub btnprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprint.Click
        frmno = 2
        frmprnt.MdiParent = MDI
        frmprnt.Show()
    End Sub

    Private Sub btninter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninter.Click
        comd = swapprmsn("mnuporder", comd)
        'If comd = "E" Then
        '    comd = "M"
        'ElseIf comd = "M" Then
        '    comd = "D"
        'Else
        '    comd = "E"
        'End If
        Me.clr()
    End Sub

    Private Sub btnset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnset.Click

    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Val(txtordno.Text) = 0 Then
            MessageBox.Show("Sorry The Order No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtordno.Focus()
            Exit Sub
        End If
        If Trim(cmbparty.Text) = "" Or Val(txtprtcd.Text) = 0 Then
            MessageBox.Show("Sorry The Party Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbparty.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count = 0 Then
            MessageBox.Show("Please Order At least one item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If
        Me.order_save()
    End Sub

    Private Sub btnnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.Click
        If Trim(cmbproduct.Text) = "" Or Val(txtitcd.Text) = 0 Then
            MessageBox.Show("Please Provide A Product Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If
        If Val(txtquantity.Text) = 0 Then
            MessageBox.Show("Sorry The Quantity Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtquantity.Focus()
            Exit Sub
        End If
        If Val(txtrate.Text) = 0 Then
            MessageBox.Show("Sorry The Prchase Rate Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtrate.Focus()
            Exit Sub
        End If
        sl1 = Val(txtsl.Text)
        dv1.Rows.Add()
        dv1.Rows(sl1 - 1).Cells(0).Value = sl1
        dv1.Rows(sl1 - 1).Cells(1).Value = cmbproduct.Text
        dv1.Rows(sl1 - 1).Cells(2).Value = txtquantity.Text
        dv1.Rows(sl1 - 1).Cells(3).Value = txtfree.Text
        dv1.Rows(sl1 - 1).Cells(4).Value = Trim(txtunit.Text)
        dv1.Rows(sl1 - 1).Cells(5).Value = txtmrp.Text
        dv1.Rows(sl1 - 1).Cells(6).Value = txtrate.Text
        dv1.Rows(sl1 - 1).Cells(7).Value = txtamount.Text
        dv1.Rows(sl1 - 1).Cells(8).Value = txtitcd.Text
        sl1 += 1
        txtsl.Text = sl1
        Me.grandamt(dv1, txtgrandtot)
        Me.clr1()
        cmbproduct.Focus()
    End Sub
#End Region
    Private Sub order_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(po_no) as 'Max' FROM porder1")
                txtordno.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtordno.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO porder1 (po_no,po_dt,priority,ref_no,prt_code,deliver_dt,gr_tot,nb1,nb2,usr_ent,ent_date,usr_mod," & _
                          "mod_date,rec_lock,used_by) VALUES (" & Val(txtordno.Text) & ",'" & Format(orddt.Value, "dd/MMM/yyyy") & "','" & _
                          vb.Left(cmbpriorty.Text, 1) & "','" & Trim(txtref.Text) & "'," & Val(txtprtcd.Text) & ",'" & _
                          Format(delvrdt.Value, "dd/MMM/yyyy") & "'," & Val(txtgrandtot.Text) & ",'" & Trim(txtremark.Text) & "',''," & _
                          Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(usr_sl) & ",'" & _
                          Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N','N')")
                Me.dv_save()
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cnfr = MessageBox.Show("Are You Sure The Printer is Ready To Print The Bill.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If cnfr = vbYes Then
                    Call order_print(Val(txtordno.Text))
                End If
                Me.clr()
            End If
        ElseIf comd = "M" Then
            'If usr_tp = "O" Then
            '    MessageBox.Show("You Are Not Authorised to Modify The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT po_no FROM porder1 WHERE po_no=" & Val(txtordno.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE porder1 SET po_dt='" & Format(orddt.Value, "dd/MMM/yyyy") & "',priority='" & _
                              vb.Left(cmbpriorty.Text, 1) & "',ref_no='" & Val(txtref.Text) & "',prt_code=" & _
                              Val(txtprtcd.Text) & ",deliver_dt='" & Format(delvrdt.Value, "dd/MMM/yyyy") & "',gr_tot=" & _
                              Val(txtgrandtot.Text) & ",nb1='" & Trim(txtremark.Text) & "',usr_mod=" & _
                              Val(usr_sl) & ",mod_date='" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "' WHERE po_no =" & Val(txtordno.Text) & "")
                    Me.dv_save()
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                End If
            End If
        ElseIf comd = "D" Then
            'If usr_tp <> "A" Or usr_tp <> "D" Then
            '    MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Call del1(txtordno.Text)
                Call del2(txtordno.Text)
                txtordno.Focus()
            End If
        End If
        Close1()
    End Sub

    Private Sub dv_save()
        If dv1.RowCount <> 0 Then
            If comd = "M" Then
                Call del2(txtordno.Text)
            End If
            For i As Integer = 0 To dv1.RowCount - 1
                qty = Val(dv1.Rows(i).Cells(2).Value)
                free = Val(dv1.Rows(i).Cells(3).Value)
                unt = Trim(dv1.Rows(i).Cells(4).Value)
                mrp = Val(dv1.Rows(i).Cells(5).Value)
                prate = Val(dv1.Rows(i).Cells(6).Value)
                amt = Val(dv1.Rows(i).Cells(7).Value)
                itcd = Val(dv1.Rows(i).Cells(8).Value)
                Dim ds1 As DataSet = get_dataset("SELECT max(po_sl) as 'Max' FROM porder2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO porder2(po_sl,po_no,po_dt,prt_code,it_cd,po_qty,bpo_qty,po_free,bpo_free,po_rate,po_mrp,po_amt," & _
                          "po_unit,mul_rt,billed) VALUES (" & Val(mxno) & "," & Val(txtordno.Text) & ",'" & Format(orddt.Value, "dd/MMM/yyyy") & "'," & _
                          Val(txtprtcd.Text) & "," & Val(itcd) & "," & qty & ",0," & free & ",0," & prate & "," & mrp & "," & amt & ",'" & unt & "',1,'N')")
            Next
        End If
    End Sub

    Private Sub txtrate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrate.Validated
        txtamount.Text = Format(Val(txtquantity.Text) * Val(txtrate.Text), "######0.00")
    End Sub

    Private Sub txtquantity_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquantity.Validated
        txtamount.Text = Format(Val(txtquantity.Text) * Val(txtrate.Text), "######0.00")
    End Sub

    Private Sub cmnu1del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1del.Click
        For Each row As DataGridViewRow In dv1.SelectedRows
            dv1.Rows.Remove(row)
        Next
        sl = 1
        For i As Integer = 0 To dv1.Rows.Count - 1
            dv1.Rows(i).Cells(0).Value = i + 1
            sl += 1
        Next
        txtsl.Text = sl
        Me.grandamt(dv1, txtgrandtot)
    End Sub

    Private Sub grandamt(ByVal dgv As DataGridView, ByVal txt As TextBox)
        gamt = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            amt = dgv.Rows(i).Cells(7).Value
            gamt = gamt + Val(amt)
        Next
        txt.Text = Format(gamt, "#######0.00")
    End Sub


    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT porder1.*, party.pname FROM porder1 LEFT OUTER JOIN party ON porder1.prt_code = party.prt_code ORDER BY porder1.po_dt")
        dv.Rows.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                dv.Rows.Add()
                dv.Rows(i).Cells(0).Value = dsedit.Tables(0).Rows(rw).Item("po_no")
                dv.Rows(i).Cells(1).Value = Format(dsedit.Tables(0).Rows(rw).Item("po_dt"), "dd/MM/yyyy")
                dv.Rows(i).Cells(2).Value = dsedit.Tables(0).Rows(rw).Item("pname")
                dv.Rows(i).Cells(3).Value = dsedit.Tables(0).Rows(rw).Item("ref_no")
                If dsedit.Tables(0).Rows(rw).Item("priority") = "1" Then
                    dv.Rows(i).Cells(4).Value = "Normal"
                ElseIf dsedit.Tables(0).Rows(rw).Item("priority") = "2" Then
                    dv.Rows(i).Cells(4).Value = "Urgent"
                Else
                    dv.Rows(i).Cells(4).Value = "SemiUrgent"
                End If
                dv.Rows(i).Cells(5).Value = Format(dsedit.Tables(0).Rows(rw).Item("deliver_dt"), "dd/MM/yyyy")
                'dv.Rows(i).Cells(6).Value = Format(dsedit.Tables(0).Rows(rw).Item("gr_tot"), "######0.00")
                If dsedit.Tables(0).Rows(rw).Item("rec_lock") = "Y" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
                rw = rw + 1
            Next
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_view()
        Dim ds As DataSet = get_dataset("SELECT porder2.*, item.it_name FROM porder2 LEFT OUTER JOIN item ON porder2.it_cd = item.it_cd WHERE porder2.po_no=" & Val(txtordno.Text) & "")
        rw = 0
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("it_name")
                dv1.Rows(rw).Cells(2).Value = Format(ds.Tables(0).Rows(i).Item("po_qty"), "####0.000")
                dv1.Rows(rw).Cells(3).Value = Format(ds.Tables(0).Rows(i).Item("po_free"), "####0.000")
                dv1.Rows(rw).Cells(4).Value = ds.Tables(0).Rows(i).Item("po_unit")
                dv1.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(i).Item("po_mrp"), "######0.00")
                dv1.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("po_rate"), "######0.00")
                dv1.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("po_amt"), "######0.00")
                dv1.Rows(rw).Cells(8).Value = ds.Tables(0).Rows(i).Item("it_cd")
                rw += 1
            Next
            Me.grandamt(dv1, txtgrandtot)
            txtsl.Text = rw + 1
        End If
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT porder1.*, party.pname FROM porder1 LEFT OUTER JOIN party ON porder1.prt_code = party.prt_code WHERE(porder1.po_no = " & slno & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtordno.Text = slno
            txtref.Text = dsedit.Tables(0).Rows(0).Item("ref_no")
            txtgrandtot.Text = Format(dsedit.Tables(0).Rows(0).Item("gr_tot"), "######0.00")
            txtremark.Text = dsedit.Tables(0).Rows(0).Item("nb1")
            txtprtcd.Text = dsedit.Tables(0).Rows(0).Item("prt_code")
            cmbpriorty.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("priority")) - 1
            cmbparty.Text = dsedit.Tables(0).Rows(0).Item("pname")
            orddt.Value = dsedit.Tables(0).Rows(0).Item("po_dt")
            delvrdt.Value = dsedit.Tables(0).Rows(0).Item("deliver_dt")
            Me.dv_view()
        End If
        Close1()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        comd = "E"
        Me.clr()
        dv.Visible = False
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Purchase Order Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
        End If
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            comd = "V"
            btnsave.Text = "View"
            Me.Text = "Purchase Order View Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            'If usr_tp = "A" Or usr_tp = "D" Then
            slno = dv.SelectedRows(0).Cells(0).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Call del1(slno)
                Call del2(slno)
            End If
            Close1()
            Me.dv_disp()
            'Else
            '    MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        End If
    End Sub

    Private Sub trans_view()
        dvtrans.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        ds = get_dataset("SELECT TOP (3) convert(varchar,po_dt,3) 'Date',STR(po_mrp,10,2) 'MRP', STR(po_rate,10,2) 'Rate' FROM porder2 WHERE (it_cd = " & Val(txtitcd.Text) & ") AND (prt_code = " & Val(txtprtcd.Text) & ") ORDER BY po_dt")
        If ds.Tables(0).Rows.Count <> 0 Then
            dvtrans.DataSource = ds.Tables(0)
        End If
        Close1()
    End Sub

    Private Sub txtordno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtordno.Validated
        If comd <> "E" Then
            If txtordno.Text <> "" Then
                Dim ds As DataSet = get_dataset("SELECT po_no FROM porder1 WHERE po_no=" & Val(txtordno.Text) & " ")
                If ds.Tables(0).Rows.Count <> 0 Then
                    Me.dv_edit(txtordno.Text)
                Else
                    MessageBox.Show("Please Select a Valid Order No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtordno.Focus()
                End If
            End If
        End If
    End Sub

    'Delete data from Table1/Primary Table
    Private Sub del1(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT po_no FROM porder1 WHERE po_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            SQLInsert("DELETE FROM porder1 WHERE po_no=" & Val(code) & "")
        End If
    End Sub

    'Delete data from Table2/Secondary Table
    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT po_sl FROM porder2 WHERE po_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                posl = dsdel.Tables(0).Rows(i).Item(0)
                SQLInsert("DELETE FROM porder2 WHERE po_sl=" & Val(posl) & "")
            Next
        End If
    End Sub

    Private Sub txtordno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtordno.GotFocus
        If comd <> "E" Then
            Me.clr()
        End If
    End Sub

    Private Sub mnuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexpert.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        prtnm = InputBox("Enter Name Of The Party.", "Search Box...", Nothing)
        If (prtnm Is Nothing OrElse prtnm = "") Then
            'User hit cancel
        Else
            Dim dssear As DataSet = get_dataset("SELECT porder1.*, party.pname FROM porder1 LEFT OUTER JOIN party ON porder1.prt_code = party.prt_code WHERE (party.pname LIKE'" & prtnm & "%') ORDER BY porder1.po_dt")
            dv.Rows.Clear()
            If dssear.Tables(0).Rows.Count <> 0 Then
                Dim rw As Integer = 0
                For i As Integer = 0 To dssear.Tables(0).Rows.Count - 1
                    dv.Rows.Add()
                    dv.Rows(i).Cells(0).Value = dssear.Tables(0).Rows(rw).Item("po_no")
                    dv.Rows(i).Cells(1).Value = Format(dssear.Tables(0).Rows(rw).Item("po_dt"), "dd/MM/yyyy")
                    dv.Rows(i).Cells(2).Value = dssear.Tables(0).Rows(rw).Item("pname")
                    dv.Rows(i).Cells(3).Value = dssear.Tables(0).Rows(rw).Item("ref_no")
                    If dssear.Tables(0).Rows(rw).Item("priority") = "1" Then
                        dv.Rows(i).Cells(4).Value = "Normal"
                    ElseIf dssear.Tables(0).Rows(rw).Item("priority") = "2" Then
                        dv.Rows(i).Cells(4).Value = "Urgent"
                    Else
                        dv.Rows(i).Cells(4).Value = "SemiUrgent"
                    End If
                    dv.Rows(i).Cells(5).Value = Format(dssear.Tables(0).Rows(rw).Item("deliver_dt"), "dd/MM/yyyy")
                    'dv.Rows(i).Cells(6).Value = Format(dssear.Tables(0).Rows(rw).Item("gr_tot"), "######0.00")
                    If dssear.Tables(0).Rows(rw).Item("rec_lock") = "Y" Then
                        dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    Else
                        dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    End If
                    rw = rw + 1
                Next
            End If
            Close1()
            dv.Visible = True
            dv.Dock = DockStyle.Fill
        End If
    End Sub
End Class
