Imports vb = Microsoft.VisualBasic
Public Class frmpurchinv
    Dim comd As String = "V"
    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point
#Region "Start Up"
    Private Sub frmpurchinv_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnupurinv.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmpurchinv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmpurchinv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnupurinv.Enabled = False
        usrprmsn("mnupurinv", cmnuadd, cmnuedit, cmenudel, cmenuview)
        comd = swapprmsn("mnupurinv", comd)
        Me.clr()
        cmbpurtype.SelectedIndex = 0
        cmbfrom.SelectedIndex = 0
        cmbpr.SelectedIndex = 0
        cmbtr.SelectedIndex = 0
        Me.Set_view()
    End Sub

    Private Sub frmpurchinv_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        txtrealmrp.Text = 0
        txtrealrt.Text = 0
        dvtrans.DataSource = Nothing
        cmbproduct.Text = ""
        cmbunit.Text = ""
        txtinvno.Text = ""
        txtslno.Text = "1"
        txtprtcd.Text = 0
        txtnb.Text = ""
        lblamount.Text = "0.00"
        lblcodisc.Text = "0.00"
        lbltrdisc.Text = "0.00"
        lblmrpval.Text = "0.00"
        lbltto.Text = "0.00"
        lblvat.Text = "0.00"
        lbladisc.Text = "0.00"
        lblachrg.Text = "0.00"
        lbltotal.Text = "0.00"
        lbldescri.Text = ""
        lblgrp.Text = ""
        lblsound.Text = "0.00"
        lbldmg.Text = "0.00"
        txtsndstk.Text = 0
        txtdmgstk.Text = 0
        txtchargamt.Text = "0.00"
        txtdiscamt.Text = "0.00"
        txtadj.Text = "0.00"
        txtgrtotal.Text = "0.00"
        cmbparty.Text = ""
        lbladdress.Text = ""
        lblprtbal.Text = "0.00 Cr."
        cmbstore.Text = ""
        recdt.Value = sys_date
        paydt.Value = sys_date
        invdt.Value = sys_date
        dv1.Rows.Clear()
        'Others
        txtchno.Text = ""
        txtvehno.Text = ""
        txtlrno.Text = ""
        txtwaypfx.Text = ""
        txtwbno.Text = ""
        chdt.Value = sys_date
        lrdt.Value = sys_date
        If comd = "E" Then
            Me.Text = "Purchase Invoice Entry Screen...."
            Dim ds As DataSet = get_dataset("SELECT max(pur_no) as 'Max' FROM purch1")
            txtscroll.Text = 1
            cmbparty.Focus()
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            btnsave.Text = "Save"
        ElseIf comd = "M" Then
            Me.Text = "Purchase Invoice Modification Screen...."
            txtscroll.Text = ""
            btnsave.Text = "Modify"
        ElseIf comd = "D" Then
            Me.Text = "Purchase Invoice Deletion Screen...."
            txtscroll.Text = ""
            btnsave.Text = "Delete"
        Else
            Me.Text = "Purchase Invoice View Screen...."
            txtscroll.Text = ""
            btnsave.Text = "View"
        End If
        Me.clr1()
        Me.Set_chang()
    End Sub

    Private Sub clr1()
        txttaxstl.Text = "I"
        txttaxcat.Text = "1"
        'txtbatcnfr.Text = "N"
        cmbproduct.Text = ""
        'txtitemcd.Text = 0
        txtbatcd.Text = 0
        txtquantity.Text = "0.00"
        txtfree.Text = "0.00"
        txtmrp.Text = "0.00"
        txtrate.Text = "0.00"
        txtamount.Text = "0.00"
        txtcoper.Text = "0.00"
        txtcoamt.Text = "0.00"
        txttrper.Text = "0.00"
        txttramt.Text = "0.00"
        txtmrvalue.Text = "0.00"
        txttto.Text = "0.00"
        txtvat.Text = "0.00"
        txtadisc.Text = "0.00"
        txtacharg.Text = "0.00"
        txttotal.Text = "0.00"
        txttaxcd.Text = 0
        cmbvat.Text = ""
        txtvatper.Text = 0
        txtmulrt.Text = 1
        txtbatcreat.Text = "N"
    End Sub


    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.dv_disp()
    End Sub
#End Region

#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscroll.Enter, txtslno.Enter, txtquantity.Enter, txtfree.Enter, txtmrp.Enter, txtprtcd.Enter, txtrate.Enter, txtamount.Enter, txtcoper.Enter, txtcoamt.Enter, txttrper.Enter, txttramt.Enter, txtmrvalue.Enter, txttto.Enter, txtvat.Enter, txtadisc.Enter, txtacharg.Enter, txttotal.Enter, txtnb.Enter, txtchargamt.Enter, txtadisc.Enter, cmbparty.Enter, cmbstore.Enter, cmbproduct.Enter, cmbfrom.Enter, cmbpr.Enter, cmbtr.Enter, cmbvat.Enter, paydt.Enter, invdt.Enter, txtinvno.Enter, txtchno.Enter, txtvehno.Enter, txtlrno.Enter, txtwaypfx.Enter, txtwbno.Enter, cmbunit.Enter, txtdiscamt.Enter, txttaxstl.Enter, recdt.Enter, cmbpurtype.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscroll.Leave, txtslno.Leave, txtquantity.Leave, txtfree.Leave, txtmrp.Leave, txtprtcd.Leave, txtrate.Leave, txtamount.Leave, txtcoper.Leave, txtcoamt.Leave, txttrper.Leave, txttramt.Leave, txtmrvalue.Leave, txttto.Leave, txtvat.Leave, txtadisc.Leave, txtacharg.Leave, txttotal.Leave, txtnb.Leave, txtchargamt.Leave, txtadisc.Leave, cmbparty.Leave, cmbstore.Leave, cmbproduct.Leave, cmbfrom.Leave, cmbpr.Leave, cmbtr.Leave, cmbvat.Leave, paydt.Leave, invdt.Leave, txtinvno.Leave, txtchno.Leave, txtvehno.Leave, txtlrno.Leave, txtwaypfx.Leave, txtwbno.Leave, cmbunit.Leave, txtdiscamt.Leave, txttaxstl.Leave, recdt.Leave, cmbpurtype.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub
#End Region

#Region "Mouse Enter/Leave"

    Private Sub sender_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnxt.MouseEnter, btnsave.MouseEnter, btnset.MouseEnter, btninter.MouseEnter, btnref.MouseEnter, btnview.MouseEnter, btnothers.MouseEnter, btnexit.MouseEnter, btnabort.MouseEnter, btnfresh1.MouseEnter, btnok.MouseEnter, btnsetabrt.MouseEnter, btnsetaply.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnxt.MouseLeave, btnsave.MouseLeave, btnset.MouseLeave, btninter.MouseLeave, btnref.MouseLeave, btnview.MouseLeave, btnothers.MouseLeave, btnexit.MouseLeave, btnabort.MouseLeave, btnfresh1.MouseLeave, btnok.MouseLeave, btnsetabrt.MouseLeave, btnsetaply.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub chksetmep_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetvat.MouseEnter, chksetrate.MouseEnter, chksetmrp.MouseEnter, chksetdisc.MouseEnter, chksetcalcrt.MouseEnter, chksetblrnd.MouseEnter
        sender.forecolor = Color.Blue
    End Sub

    Private Sub chksetmep_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetvat.MouseLeave, chksetrate.MouseLeave, chksetmrp.MouseLeave, chksetdisc.MouseLeave, chksetcalcrt.MouseLeave, chksetblrnd.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

    Private Sub txtquantity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquantity.GotFocus, txtfree.GotFocus
        If Val(sender.Text) = 0 Then
            sender.Text = ""
        End If
    End Sub

    Private Sub txtquantity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquantity.LostFocus, txtfree.LostFocus
        sender.Text = Format(Val(sender.Text), "########0.00")
    End Sub

    Private Sub txtmrp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmrp.GotFocus, txtrate.GotFocus, txtamount.GotFocus, txtcoper.GotFocus, txtcoamt.GotFocus, txttrper.GotFocus, txttramt.GotFocus, txtmrvalue.GotFocus, txttto.GotFocus, txtadisc.GotFocus, txtacharg.GotFocus, txttotal.GotFocus, txtchargamt.GotFocus, txtdiscamt.GotFocus, txtadj.GotFocus, txtgrtotal.GotFocus
        If Val(sender.Text) = 0 Then
            sender.Text = ""
        End If
    End Sub

    Private Sub txtmrp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmrp.LostFocus, txtrate.LostFocus, txtamount.LostFocus, txtcoper.LostFocus, txtcoamt.LostFocus, txttrper.LostFocus, txttramt.LostFocus, txtmrvalue.LostFocus, txttto.LostFocus, txtadisc.LostFocus, txtacharg.LostFocus, txttotal.LostFocus, txtchargamt.LostFocus, txtdiscamt.LostFocus, txtadj.LostFocus, txtgrtotal.LostFocus
        sender.Text = Format(Val(sender.Text), "########0.00")
    End Sub

#Region "Key Press"

    Private Sub txtscroll_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtscroll.KeyPress
        key(cmbpurtype, e)
        NUM(e)
    End Sub

    Private Sub cmbpurchase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpurtype.KeyPress
        key(cmbfrom, e)
        SPKey(e)
    End Sub

    Private Sub cmbfrom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbfrom.KeyPress
        If cmbfrom.SelectedIndex = 0 Then
            key(recdt, e)
        Else
            key(txtorder, e)
        End If
        SPKey(e)
    End Sub

    Private Sub txtorder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtorder.KeyPress
        key(recdt, e)
        NUM(e)
    End Sub

    Private Sub dtrecive_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles recdt.KeyPress
        key(cmbparty, e)
    End Sub

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(txtinvno, e)
        SPKey(e)
    End Sub

    Private Sub txtinvno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinvno.KeyPress
        key(invdt, e)
        SPKey(e)
    End Sub

    Private Sub dtinv_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles invdt.KeyPress
        key(paydt, e)
    End Sub

    Private Sub dtpay_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles paydt.KeyPress
        key(cmbstore, e)
    End Sub

    Private Sub cmbstore_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstore.KeyPress
        key(cmbproduct, e)
        SPKey(e)
    End Sub

    Private Sub cmbpr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpr.KeyPress
        key(cmbproduct, e)
        SPKey(e)
    End Sub

    Private Sub cmbproduct_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbproduct.KeyPress
        If cmbproduct.Text = "" Then
            key(txtnb, e)
        Else
            key(cmbunit, e)
        End If
        SPKey(e)
    End Sub

    Private Sub cmbtr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtr.KeyPress
        key(txtquantity, e)
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

    Private Sub cmbunit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunit.KeyPress
        key(txtquantity, e)
        SPKey(e)
    End Sub

    Private Sub txtmrp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmrp.KeyPress
        key(txtrate, e)
        NUM1(e)
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        If txtcoper.Enabled = True Then
            key(txtcoper, e)
        ElseIf cmbvat.Enabled = True Then
            key(cmbvat, e)
        ElseIf txtadisc.Enabled = True Then
            key(txtadisc, e)
        Else
            key(btnnxt, e)
        End If
        NUM1(e)
    End Sub

    Private Sub txtcomp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcoper.KeyPress
        If Val(txtcoper.Text) <> 0 Then
            key(txttrper, e)
        Else
            key(txtcoamt, e)
        End If
        NUM1(e)
    End Sub

    Private Sub txtdisc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcoamt.KeyPress
        key(txttrper, e)
        NUM1(e)
    End Sub

    Private Sub txttrade_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttrper.KeyPress
        If Val(txttrper.Text) <> 0 Then
            If cmbvat.Enabled = True Then
                key(cmbvat, e)
            ElseIf txtadisc.Enabled = True Then
                key(txtadisc, e)
            Else
                key(btnnxt, e)
            End If
        Else
            key(txttramt, e)
        End If
        NUM1(e)
    End Sub

    Private Sub txtdis_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttramt.KeyPress
        If cmbvat.Enabled = True Then
            If cmbvat.Enabled = True Then
                key(cmbvat, e)
            ElseIf txtadisc.Enabled = True Then
                key(txtadisc, e)
            Else
                key(btnnxt, e)
            End If
        Else
            key(txtadisc, e)
        End If
        NUM1(e)
    End Sub

    Private Sub cmbvat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbvat.KeyPress
        If txtadisc.Enabled = True Then
            key(txtadisc, e)
        Else
            key(btnnxt, e)
        End If
        SPKey(e)
    End Sub

    Private Sub txtvat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvat.KeyPress
        key(txtadisc, e)
        NUM1(e)
    End Sub

    Private Sub txtdiscount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadisc.KeyPress
        key(txtacharg, e)
        NUM1(e)
    End Sub

    Private Sub txtcharge_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtacharg.KeyPress
        key(btnnxt, e)
        NUM1(e)
    End Sub

    Private Sub txtnb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnb.KeyPress
        key(txtchargamt, e)
        If txtchargamt.Enabled = True Then
            key(txtchargamt, e)
        Else
            key(btnsave, e)
        End If
        SPKey(e)
    End Sub

    Private Sub txtcharges_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtchargamt.KeyPress
        key(txtdiscamt, e)
        NUM1(e)
    End Sub

    Private Sub txtdscount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdiscamt.KeyPress
        key(btnsave, e)
        NUM1(e)
    End Sub
    'Others
    Private Sub txtchno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtchno.KeyPress
        key(chdt, e)
        SPKey(e)
    End Sub

    Private Sub chdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chdt.KeyPress
        key(txtvehno, e)
    End Sub

    Private Sub txtvehno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvehno.KeyPress
        key(txtlrno, e)
        SPKey(e)
    End Sub

    Private Sub txtlrno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlrno.KeyPress
        key(lrdt, e)
        SPKey(e)
    End Sub

    Private Sub lrdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lrdt.KeyPress
        key(txtwaypfx, e)
    End Sub

    Private Sub txtwaypfx_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtwaypfx.KeyPress
        key(txtwbno, e)
        SPKey(e)
    End Sub

    Private Sub txtwbno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtwbno.KeyPress
        key(btnok, e)
        NUM(e)
    End Sub
#End Region

#Region "Combo Box"
    Private Sub cmbparty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.GotFocus
        lbladdress.Text = ""
        populate(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.LostFocus
        cmbparty.Height = 21
    End Sub

    Private Sub cmbparty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.Validated
        Dim ds As DataSet = get_dataset("SELECT prt_code,add1,cl_amt FROM party WHERE pname='" & Trim(cmbparty.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtprtcd.Text = ds.Tables(0).Rows(0).Item("prt_code")
            lbladdress.Text = Trim(ds.Tables(0).Rows(0).Item("add1"))
            clamt = Val(ds.Tables(0).Rows(0).Item("cl_amt"))
            If clamt < 0 Then
                lblprtbal.Text = Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
            Else
                lblprtbal.Text = Format(clamt, "#######0.00") & " " & "Cr."
            End If
            paydt.Value = invdt.Value '.AddDays(Val(ds.Tables(0).Rows(0).Item("lim_day")))
        End If
    End Sub

    Private Sub cmbparty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbparty.Validating
        vdating(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' AND pname='" & Trim(cmbparty.Text) & "'", "Please Select A Valid Party Name.")
    End Sub

    Private Sub cmbproduct_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.GotFocus
        Me.clr1()
        lbldescri.Text = ""
        lblgrp.Text = ""
        populate(cmbproduct, "SELECT it_name FROM item WHERE (rec_lock = 'N') ORDER BY it_name")
    End Sub

    Private Sub cmbproduct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.LostFocus
        cmbproduct.Height = 21
    End Sub

    Private Sub cmbproduct_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbproduct.Validated
        Dim ds As DataSet = get_dataset("SELECT item.it_cd,item.it_desc, item.taxcd, item.mrp, item.pur_rate, item.unt1,item.cl_stk,item.rcl_stk, item_group.grp_nm, item.multi1, taxper.txname,taxper.taxcat, taxper.taxamt FROM item LEFT OUTER JOIN item_group ON item.grp_cd = item_group.grp_cd LEFT OUTER JOIN taxper ON item.taxcd = taxper.taxcd WHERE item.it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtitemcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            cmbunit.Text = ds.Tables(0).Rows(0).Item("unt1")
            lbldescri.Text = Trim(ds.Tables(0).Rows(0).Item("it_desc"))
            lblgrp.Text = Trim(ds.Tables(0).Rows(0).Item("grp_nm"))
            txttaxcd.Text = ds.Tables(0).Rows(0).Item("taxcd")
            txtvatper.Text = ds.Tables(0).Rows(0).Item("taxamt")
            cmbvat.Text = ds.Tables(0).Rows(0).Item("txname")
            'txtmrp.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            'txtrate.Text = Format(ds.Tables(0).Rows(0).Item("pur_rate"), "#######0.00")
            txtrealmrp.Text = Val(ds.Tables(0).Rows(0).Item("mrp"))
            txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("pur_rate"))
            txtsndstk.Text = Format(ds.Tables(0).Rows(0).Item("cl_stk"), "#####0.00")
            txtdmgstk.Text = Format(ds.Tables(0).Rows(0).Item("rcl_stk"), "#####0.00")
            'txttaxstl.Text = ds.Tables(0).Rows(0).Item("tax_stl")
            txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
            Me.dv_calc()
            Me.stk_calc()
            If Val(txtprtcd.Text) <> 0 Or Val(txtitemcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
    End Sub

    Private Sub cmbproduct_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbproduct.Validating
        vdating(cmbproduct, "SELECT it_name FROM item WHERE rec_lock='N' AND it_name= '" & Trim(cmbproduct.Text) & "'", "Please Select a Valid Product Name.")
    End Sub

    Private Sub cmbproduct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.TextChanged
        Dim ds As DataSet = get_dataset("SELECT item.it_cd,item.it_desc, item.taxcd, item.mrp, item.pur_rate, item.unt1,item.cl_stk,item.rcl_stk, item_group.grp_nm, item.multi1, taxper.txname,taxper.taxcat, taxper.taxamt FROM item LEFT OUTER JOIN item_group ON item.grp_cd = item_group.grp_cd LEFT OUTER JOIN taxper ON item.taxcd = taxper.taxcd WHERE item.it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtitemcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            cmbunit.Text = ds.Tables(0).Rows(0).Item("unt1")
            lbldescri.Text = Trim(ds.Tables(0).Rows(0).Item("it_desc"))
            lblgrp.Text = Trim(ds.Tables(0).Rows(0).Item("grp_nm"))
            txttaxcd.Text = ds.Tables(0).Rows(0).Item("taxcd")
            txtvatper.Text = ds.Tables(0).Rows(0).Item("taxamt")
            cmbvat.Text = ds.Tables(0).Rows(0).Item("txname")
            'txtmrp.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            'txtrate.Text = Format(ds.Tables(0).Rows(0).Item("pur_rate"), "#######0.00")
            txtrealmrp.Text = Val(ds.Tables(0).Rows(0).Item("mrp"))
            txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("pur_rate"))
            txtsndstk.Text = Format(ds.Tables(0).Rows(0).Item("cl_stk"), "#####0.00")
            txtdmgstk.Text = Format(ds.Tables(0).Rows(0).Item("rcl_stk"), "#####0.00")
            'txttaxstl.Text = ds.Tables(0).Rows(0).Item("tax_stl")
            txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
            Me.dv_calc()
            Me.stk_calc()
            If Val(txtprtcd.Text) <> 0 Or Val(txtitemcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
    End Sub

    Private Sub cmbstore_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstore.GotFocus
        populate(cmbstore, "SELECT godnm FROM godown WHERE (rec_lock = 'N') ORDER BY godnm")
    End Sub

    Private Sub cmbstore_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstore.LostFocus
        cmbstore.Height = 21
    End Sub

    Private Sub cmbstore_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstore.Validating
        vdating(cmbstore, "SELECT godnm FROM godown WHERE (godnm ='" & Trim(cmbstore.Text) & "')", "Please Select a Valid Store Name.")
    End Sub

    Private Sub cmbstore_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstore.Validated
        vdated(txtgodcd, "SELECT godsl FROM godown WHERE (godnm ='" & Trim(cmbstore.Text) & "')")
    End Sub

    Private Sub cmbvat_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbvat.GotFocus
        txtvat.Text = "0.00"
        txtvatper.Text = 0
        populate(cmbvat, "SELECT txname FROM taxper WHERE (rec_lock = 'N') ORDER BY txname")
    End Sub

    Private Sub cmbvate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbvat.LostFocus
        cmbvat.Height = 21
    End Sub

    Private Sub cmbvat_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbvat.Validating
        vdating(cmbvat, "SELECT txname FROM taxper WHERE (txname ='" & Trim(cmbvat.Text) & "')", "Please Select a Valid Tax Name.")
    End Sub

    Private Sub cmbvat_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbvat.Validated
        Dim ds As DataSet = get_dataset("SELECT taxcd,tax1,taxcat FROM taxper WHERE (txname ='" & Trim(cmbvat.Text) & "')")
        If ds.Tables(0).Rows.Count <> 0 Then
            txttaxcd.Text = ds.Tables(0).Rows(0).Item("taxcd")
            txtvatper.Text = ds.Tables(0).Rows(0).Item("tax1")
            txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
            Me.dv_calc()
        End If
    End Sub

    Private Sub cmbunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.GotFocus
        populate(cmbunit, "SELECT unt.unt_nm FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitemcd.Text) & ") ORDER BY untlnk.unt_pos")
    End Sub


    Private Sub cmbunit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.LostFocus
        cmbunit.Height = 21
    End Sub

    Private Sub cmbunit_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.Validated
        Dim ds As DataSet = get_dataset("SELECT * FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitemcd.Text) & ") AND unt.unt_nm='" & Trim(cmbunit.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtuntcd.Text = ds.Tables(0).Rows(0).Item("unt_cd")
            txtmulrt.Text = ds.Tables(0).Rows(0).Item("mul_rt")
        End If
        Me.dv_calc()
        Me.stk_calc()
    End Sub

    Private Sub cmbunit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.TextChanged
        Dim ds As DataSet = get_dataset("SELECT * FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitemcd.Text) & ") AND unt.unt_nm='" & Trim(cmbunit.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtuntcd.Text = ds.Tables(0).Rows(0).Item("unt_cd")
            txtmulrt.Text = ds.Tables(0).Rows(0).Item("mul_rt")
        End If
        Me.dv_calc()
        Me.stk_calc()
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        vdating(cmbunit, "SELECT unt.unt_nm FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitemcd.Text) & ") AND unt.unt_nm='" & Trim(cmbunit.Text) & "'", "Please Select An Valid Unit Name.")
    End Sub
#End Region

#Region "Button"


    Private Sub btnsetabrt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsetabrt.Click
        setting_panel.Visible = False
    End Sub

    Private Sub btnsetaply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsetaply.Click
        Start1()
        SQLInsert("UPDATE setting_purch SET req_mrp=" & IIf(chksetmrp.Checked, 1, 0) & ",req_rate=" & _
                  IIf(chksetrate.Checked, 1, 0) & ",req_disc=" & IIf(chksetdisc.Checked, 1, 0) & ",req_codis=" & _
                  IIf(chksetdisc.Checked, 1, 0) & ",req_vat=" & IIf(chksetvat.Checked, 1, 0) & ",bill_rnd=" & _
                  IIf(chksetblrnd.Checked, 1, 0) & ",rate_calc=" & IIf(chksetcalcrt.Checked, 1, 0) & "")
        Close1()
        setting_panel.Visible = False
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
    End Sub

    Private Sub btninter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninter.Click

        comd = swapprmsn("mnupurinv", comd)
        'If comd = "E" Then
        '    comd = "M"
        'ElseIf comd = "M" Then
        '    comd = "D"
        'Else
        '    comd = "E"
        'End If
        Me.clr()
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnothers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnothers.Click
        other_panel.Size = New Size(410, 136)
        other_panel.Location = New Point(5, 130)
        other_panel.Visible = True
        txtchno.Focus()
    End Sub

    Private Sub btnabort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnabort.Click
        txtchno.Text = ""
        txtvehno.Text = ""
        txtlrno.Text = ""
        txtwaypfx.Text = ""
        txtwbno.Text = ""
        chdt.Value = sys_date
        lrdt.Value = sys_date
        other_panel.Visible = False
    End Sub

    Private Sub btnfresh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfresh1.Click
        txtchno.Text = ""
        txtvehno.Text = ""
        txtlrno.Text = ""
        txtwaypfx.Text = ""
        txtwbno.Text = ""
        chdt.Value = sys_date
        lrdt.Value = sys_date
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        other_panel.Visible = False
    End Sub

    Private Sub btnset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnset.Click
        setting_panel.Size = New Size(334, 191)
        setting_panel.Location = New Point(142, 145)
        setting_panel.Visible = True
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Val(txtscroll.Text) = 0 Then
            MessageBox.Show("Sorry The Scroll No. Should Not Be Blank/Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtscroll.Focus()
            Exit Sub
        End If
        If Trim(cmbparty.Text) = "" Or Val(txtprtcd.Text) = 0 Then
            MessageBox.Show("Sorry The Party Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbparty.Focus()
            Exit Sub
        End If
        If Trim(txtinvno.Text) = "" Then
            MessageBox.Show("Sorry The Invoice No. Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtinvno.Focus()
            Exit Sub
        End If
        If Trim(cmbstore.Text) = "" Or Val(txtgodcd.Text) = 0 Then
            MessageBox.Show("Sorry The Store Point Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbstore.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count = 0 Then
            MessageBox.Show("Please Enter At least one item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If
        Me.purchase_save()
    End Sub

    Private Sub btnnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.Click
        If Trim(cmbproduct.Text) = "" Or Val(txtitemcd.Text) = 0 Then
            MessageBox.Show("Please Provide A Product Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If
        If Val(Val(txtquantity.Text) + Val(txtfree.Text)) = 0 Then
            MessageBox.Show("Sorry The Quantity Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtquantity.Focus()
            Exit Sub
        End If
        'If Val(txtmrp.Text) = 0 Then
        '    MessageBox.Show("Sorry The MRP Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtmrp.Focus()
        '    Exit Sub
        'End If
        If Val(txtrate.Text) = 0 Then
            MessageBox.Show("Sorry The Purchase Rate Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtrate.Focus()
            Exit Sub
        End If
        'If Val(txtrate.Text) > Val(txtmrp.Text) Then
        '    MessageBox.Show("Sorry The MRP Should Not Be Less Then The Purchase Rate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtmrp.Focus()
        '    Exit Sub
        'End If
        'If Val(txtvat.Text) = 0 Then
        '    MessageBox.Show("Sorry The Vat Amount Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtrate.Focus()
        '    Exit Sub
        'End If
        If cmbtr.SelectedIndex = 1 Then
            If Val(lblsound.Text) < (Val(txtquantity.Text * (-1)) + Val(txtfree.Text) * (-1)) Then
                MessageBox.Show("Sorry Not Sufficient Stock to Return.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtquantity.Focus()
                Exit Sub
            End If
        End If
        If txtbatcreat.Text = "Y" And cmbtr.SelectedIndex = 0 Then
            'Me.batch_save()
        End If
        sl1 = Val(txtslno.Text)
        dv1.Rows.Add()
        dv1.Rows(sl1 - 1).Cells(0).Value = sl1
        dv1.Rows(sl1 - 1).Cells(1).Value = cmbpr.Text
        dv1.Rows(sl1 - 1).Cells(2).Value = cmbproduct.Text
        dv1.Rows(sl1 - 1).Cells(3).Value = cmbtr.Text
        dv1.Rows(sl1 - 1).Cells(4).Value = cmbunit.Text
        dv1.Rows(sl1 - 1).Cells(5).Value = txtquantity.Text
        dv1.Rows(sl1 - 1).Cells(6).Value = txtfree.Text
        dv1.Rows(sl1 - 1).Cells(7).Value = txtmrp.Text
        dv1.Rows(sl1 - 1).Cells(8).Value = txtrate.Text
        dv1.Rows(sl1 - 1).Cells(9).Value = txtamount.Text
        dv1.Rows(sl1 - 1).Cells(10).Value = txtcoper.Text
        dv1.Rows(sl1 - 1).Cells(11).Value = txtcoamt.Text
        dv1.Rows(sl1 - 1).Cells(12).Value = txttrper.Text
        dv1.Rows(sl1 - 1).Cells(13).Value = txttramt.Text
        dv1.Rows(sl1 - 1).Cells(14).Value = txtmrvalue.Text
        dv1.Rows(sl1 - 1).Cells(15).Value = txttto.Text
        dv1.Rows(sl1 - 1).Cells(16).Value = cmbvat.Text
        dv1.Rows(sl1 - 1).Cells(17).Value = txttaxstl.Text
        dv1.Rows(sl1 - 1).Cells(18).Value = txtvat.Text
        dv1.Rows(sl1 - 1).Cells(19).Value = txtadisc.Text
        dv1.Rows(sl1 - 1).Cells(20).Value = txtacharg.Text
        dv1.Rows(sl1 - 1).Cells(21).Value = txttotal.Text
        dv1.Rows(sl1 - 1).Cells(22).Value = txtitemcd.Text
        dv1.Rows(sl1 - 1).Cells(23).Value = txttaxcd.Text
        dv1.Rows(sl1 - 1).Cells(24).Value = Format(Val(txtexclmrp.Text), "######0.00")
        dv1.Rows(sl1 - 1).Cells(25).Value = txtbatcd.Text
        dv1.Rows(sl1 - 1).Cells(26).Value = txtmulrt.Text
        dv1.Rows(sl1 - 1).Cells(27).Value = txtpchsl.Text
        sl1 += 1
        txtslno.Text = sl1
        'lblpqty.Text = Format(Val(txtquantity.Text), "####0")
        Start1()
        If chksetmrp.Checked = True Then
            mrp = Val(txtmrp.Text) / Val(txtmulrt.Text)
            SQLInsert("UPDATE item SET mrp=" & mrp & " WHERE it_cd=" & Val(txtitemcd.Text) & "")
        End If
        If chksetrate.Checked = True Then
            pur_rt = Val(txtrealrt.Text) / Val(txtmulrt.Text)
            SQLInsert("UPDATE item SET pur_rate=" & pur_rt & " WHERE it_cd=" & Val(txtitemcd.Text) & "")
        End If
        Close1()
        cmbproduct.Focus()
        Me.grandamt(dv1)
        Me.clr1()
    End Sub
#End Region

#Region "Data save"
    Private Sub purchase_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT MAX(pur_no) AS MAX FROM purch1")
                txtscroll.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO purch1 (pur_no,pur_dt,prt_code,chal_no,chal_dt,inv_no,inv_dt,way_bno,trk_no,pur_type,pur_of,pur_amt,dv_tot,way_chr,dis_amt," & _
                         "chr_amt,nb,paydt,lr_no,lr_dt,adj_amt,godsl,usr_ent,ent_date,usr_mod,mod_date,rec_lock,usedby,pfx,purch_for,po_no,shift_sl)" & _
                         "VALUES (" & Val(txtscroll.Text) & ",'" & Format(recdt.Value, "dd/MMM/yyyy") & "'," & Val(txtprtcd.Text) & ",'" & _
                         Trim(txtchno.Text) & "','" & Format(chdt.Value, "dd/MMM/yyyy") & "','" & Trim(txtinvno.Text) & "','" & _
                         Format(invdt.Value, "dd/MMM/yyyy") & "'," & Val(txtwbno.Text) & ",'" & Trim(txtvehno.Text) & "','" & _
                         vb.Left(cmbpurtype.Text, 1) & "','I'," & Val(txtgrtotal.Text) & "," & Val(lbltotal.Text) & ",'" & Trim(txtwaypfx.Text) & "'," & _
                         Val(txtdiscamt.Text) & "," & Val(txtchargamt.Text) & ",'" & Trim(txtnb.Text) & "','" & _
                         Format(paydt.Value, "dd/MMM/yyyy") & "','" & Trim(txtlrno.Text) & "','" & Format(lrdt.Value, "dd/MMM/yyyy") & "'," & _
                         Val(txtadj.Text) & "," & Val(txtgodcd.Text) & "," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & _
                         Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N','N','AA','1'," & Val(txtorder.Text) & ",0)")
                Me.dv_save()
                If cmbpurtype.SelectedIndex = 1 Then
                    SQLInsert("UPDATE party SET cr_amt=cr_amt + " & Val(txtgrtotal.Text) & ",cl_amt=cl_amt + " & Val(txtgrtotal.Text) & " WHERE prt_code=" & Val(txtprtcd.Text) & "")
                End If
               MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Close1()
            End If
        ElseIf comd = "M" Then
            'If usr_tp = "O" Then
            '    MessageBox.Show("You Are Not Authorised to Modify The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT pur_no FROM purch1 WHERE pur_no=" & Val(txtscroll.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE purch1 SET pur_dt='" & Format(recdt.Value, "dd/MMM/yyyy") & "',prt_code=" & Val(txtprtcd.Text) & ",chal_no='" & _
                         Trim(txtchno.Text) & "',chal_dt='" & Format(chdt.Value, "dd/MMM/yyyy") & "',inv_no='" & Trim(txtinvno.Text) & "',inv_dt='" & _
                         Format(invdt.Value, "dd/MMM/yyyy") & "',way_bno=" & Val(txtwbno.Text) & ",trk_no='" & Trim(txtvehno.Text) & "',pur_type='" & _
                         vb.Left(cmbpurtype.Text, 1) & "',pur_amt=" & Val(txtgrtotal.Text) & ",dv_tot=" & Val(lbltotal.Text) & ",way_chr='" & Trim(txtwaypfx.Text) & "',dis_amt=" & _
                         Val(txtdiscamt.Text) & ",chr_amt=" & Val(txtchargamt.Text) & ",nb='" & Trim(txtnb.Text) & "',paydt='" & _
                         Format(paydt.Value, "dd/MMM/yyyy") & "',lr_no='" & Trim(txtlrno.Text) & "',lr_dt='" & _
                         Format(lrdt.Value, "dd/MMM/yyyy") & "',usr_mod=" & Val(usr_sl) & ",mod_date='" & _
                         Format(Now, "dd/MMM/yyyy HH:mm:ss") & "',po_no=" & Val(txtorder.Text) & ",adj_amt=" & _
                         Val(txtadj.Text) & ",godsl=" & Val(txtgodcd.Text) & " WHERE pur_no =" & Val(txtscroll.Text) & "")
                    Me.dv_save()
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                End If
                Close1()
            End If
        ElseIf comd = "D" Then
            'If usr_tp <> "A" And usr_tp <> "D" Then
            '    MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Call del1(txtscroll.Text)
                Call del2(txtscroll.Text)
                Me.clr()
            End If
        End If
    End Sub

    Private Sub dv_save()
        If dv1.RowCount <> 0 Then
            If comd = "M" Then
                del2(txtscroll.Text)
            End If
            For i As Integer = 0 To dv1.RowCount - 1
                prdtp = dv1.Rows(i).Cells(1).Value
                trtp = dv1.Rows(i).Cells(3).Value
                unt = dv1.Rows(i).Cells(4).Value
                qty = Val(dv1.Rows(i).Cells(5).Value)
                free = Val(dv1.Rows(i).Cells(6).Value)
                mrp = Val(dv1.Rows(i).Cells(7).Value)
                it_rt = Val(dv1.Rows(i).Cells(8).Value)
                amt = Val(dv1.Rows(i).Cells(9).Value)
                codisper = Val(dv1.Rows(i).Cells(10).Value)
                codisamt = Val(dv1.Rows(i).Cells(11).Value)
                trdisper = Val(dv1.Rows(i).Cells(12).Value)
                trdisamt = Val(dv1.Rows(i).Cells(13).Value)
                mrval = Val(dv1.Rows(i).Cells(14).Value)
                tto = Val(dv1.Rows(i).Cells(15).Value)
                taxcat = dv1.Rows(i).Cells(16).Value
                vatamt = Val(dv1.Rows(i).Cells(18).Value)
                adisc = Val(dv1.Rows(i).Cells(19).Value)
                achrg = Val(dv1.Rows(i).Cells(20).Value)
                total = Val(dv1.Rows(i).Cells(21).Value)
                itcd = Val(dv1.Rows(i).Cells(22).Value)
                taxcd = Val(dv1.Rows(i).Cells(23).Value)
                exmrp = Val(dv1.Rows(i).Cells(24).Value)
                batcd = Val(dv1.Rows(i).Cells(25).Value)
                mulrt = Val(dv1.Rows(i).Cells(26).Value)
                pchsl = Val(dv1.Rows(i).Cells(27).Value)
                mrpamt = Val(exmrp) * (Val(qty) + Val(free))
                Dim ds1 As DataSet = get_dataset("SELECT max(pur_sl) as 'Max' FROM purch2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO purch2(pur_sl,pur_no,pur_dt,prt_code,it_cd,pur_rt,pur_qty,it_amt,tto_amt,tax_cd,oth_amt,disc_amt," & _
                          "it_tot,stax,entax,mrp,ex_mrp,pch_sl,prd_tp,tr_tp,unt,free_qty,mul_rt,disc_rt1,disc_rt2,disc_amt1,disc_amt2,mrp_amt," & _
                          "bit_type,pfx,po_sl,purch_for) VALUES (" & Val(mxno) & "," & Val(txtscroll.Text) & ",'" & Format(recdt.Value, "dd/MMM/yyyy") & "'," & _
                          Val(txtprtcd.Text) & "," & Val(itcd) & "," & it_rt & "," & qty & "," & amt & "," & tto & "," & taxcd & "," & _
                          achrg & "," & adisc & "," & total & "," & vatamt & ",0," & mrp & "," & exmrp & "," & pchsl & ",'" & vb.Left(prdtp, 1) & "','" & _
                          vb.Left(trtp, 1) & "','" & unt & "'," & free & "," & mulrt & "," & codisper & "," & trdisper & "," & codisamt & "," & trdisamt & "," & _
                          mrpamt & ",'I','AA'," & pchsl & ",'1')")
                ' SQLInsert("UPDATE pchal2 SET bpch_qty = bpch_qty + " & qty & ",bfree_qty = bfree_qty + " & free & ",billed='Y' WHERE pch_sl=" & Val(pchsl) & "")
                itqt = (qty * mulrt) + (free * mulrt)
                stock_IN(itqt, itcd, vb.Left(prdtp, 1), vb.Left(trtp, 1))
            Next
        End If
    End Sub

#End Region

#Region "Calculation"
    Private Sub dv_calc()
        itqt = Val(txtquantity.Text) '* Val(txtmulrt.Text)
        frqt = Val(txtfree.Text) '* Val(txtmulrt.Text)
        If Val(txtquantity.Text) <> 0 Or Val(frqt) <> 0 Then
            txtamount.Text = Format(Val(Val(itqt) * Val(txtrate.Text)), "########0.00")
            txttto.Text = Format(Val(txtamount.Text) - (Val(txtcoamt.Text) + Val(txttramt.Text)), "########0.00")
            If Trim(txttaxstl.Text) = "I" Then
                txtexclmrp.Text = Val(Val(txtmrp.Text) * 100) / Val(Val(txtvatper.Text) + 100)
                txtmrvalue.Text = Format(Val(Val(Val(itqt) + Val(frqt)) * Val(txtmrp.Text) * 100) / Val(Val(txtvatper.Text) + 100), "########0.00")
            Else
                txtmrvalue.Text = Format(Val(Val(Val(itqt) + Val(frqt)) * Val(txtmrp.Text)), "########0.00")
            End If
            If txttaxcat.Text = "1" Then
                vatqt = Val((Val(txtvatper.Text) / 100) * Val(txttto.Text))
            Else
                vatqt = Val((Val(txtvatper.Text) / 100) * Val(txtmrvalue.Text))
            End If
            txtvat.Text = Format(Val(vatqt), "########0.00")
            txttotal.Text = Format(Val(Val(txttto.Text) + (Val(txtvat.Text) + Val(txtacharg.Text)) - Val(txtadisc.Text)), "########0.00")
        End If
    End Sub

    Private Sub grandamt(ByVal dgv As DataGridView)
        tamt = 0
        tcodis = 0
        ttrdis = 0
        tmrval = 0
        ttto = 0
        tvatamt = 0
        tdisc = 0
        tchrg = 0
        tgtamt = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            amt = dgv.Rows(i).Cells(9).Value
            codis = dgv.Rows(i).Cells(11).Value
            trdis = dgv.Rows(i).Cells(13).Value
            mrval = dgv.Rows(i).Cells(14).Value
            tto = dgv.Rows(i).Cells(15).Value
            vatamt = dgv.Rows(i).Cells(18).Value
            disc = dgv.Rows(i).Cells(19).Value
            chrg = dgv.Rows(i).Cells(20).Value
            gtamt = dgv.Rows(i).Cells(21).Value
            'Totalling(Section)
            tamt = tamt + Val(amt)
            tcodis = tcodis + Val(codis)
            ttrdis = ttrdis + Val(trdis)
            tmrval = tmrval + Val(mrval)
            ttto = ttto + Val(tto)
            tvatamt = tvatamt + Val(vatamt)
            tdisc = tdisc + Val(disc)
            tchrg = tchrg + Val(chrg)
            tgtamt = tgtamt + Val(gtamt)
        Next
        lblamount.Text = Format(tamt, "#######0.00")
        lblcodisc.Text = Format(tcodis, "#######0.00")
        lbltrdisc.Text = Format(ttrdis, "#######0.00")
        lblmrpval.Text = Format(tmrval, "#######0.00")
        lbltto.Text = Format(ttto, "#######0.00")
        lblvat.Text = Format(tvatamt, "#######0.00")
        lbladisc.Text = Format(tdisc, "#######0.00")
        lblachrg.Text = Format(tchrg, "#######0.00")
        lbltotal.Text = Format(tgtamt, "#######0.00")
        'Totalling(Section)
        grtot = (Val(lbltotal.Text) + Val(txtchargamt.Text)) - Val(txtdiscamt.Text)
        txtgrtotal.Text = Format(Math.Round(grtot), "########0.00")
        txtadj.Text = Format(Val(txtgrtotal.Text) - Val(grtot), "#######0.00")
        If chksetblrnd.Checked = True Then
            txtadj.Text = "0.00"
            txtgrtotal.Text = Format((Val(lbltotal.Text) + Val(txtchargamt.Text)) - Val(txtdiscamt.Text), "#######0.00")
        End If

    End Sub

    Private Sub stk_calc()
        lblsndunt.Text = cmbunit.Text
        lbldmgunt.Text = cmbunit.Text
        lblsound.Text = Format(Val(txtsndstk.Text / txtmulrt.Text), "#####0.00")
        lbldmg.Text = Format(Val(txtdmgstk.Text / txtmulrt.Text), "#####0.00")
        txtmrp.Text = Format(Val(txtrealmrp.Text * txtmulrt.Text), "#######0.00")
        txtrate.Text = Format(Val(txtrealrt.Text * txtmulrt.Text), "#######0.00")
    End Sub
#End Region

#Region "Data Retrieve"

    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT purch1.pur_no AS 'Scrl', CONVERT(VARCHAR,purch1.pur_dt,103) AS 'Date',purch1.inv_no AS 'Inv.No', purch1.inv_dt AS 'Inv.Date', (CASE WHEN purch1.pur_type='1' THEN 'Cash' WHEN purch1.pur_type='2' THEN 'Credit' END) AS 'Type', party.pname AS 'Name Of the Party', STR(purch1.pur_amt,10,2) AS 'Amount' FROM purch1 LEFT OUTER JOIN party ON purch1.prt_code = party.prt_code ORDER BY purch1.pur_dt DESC, purch1.pur_no DESC")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_view()
        Dim ds As DataSet = get_dataset("SELECT item.it_name, purch2.*, taxper.txname FROM purch2 LEFT OUTER JOIN taxper ON purch2.tax_cd = taxper.taxcd LEFT OUTER JOIN item ON purch2.it_cd = item.it_cd WHERE purch2.pur_no=" & Val(txtscroll.Text) & "")
        rw = 0
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                If ds.Tables(0).Rows(i).Item("prd_tp") = "1" Then
                    dv1.Rows(rw).Cells(1).Value = "1.Sound"
                Else
                    dv1.Rows(rw).Cells(1).Value = "2.Damage"
                End If
                dv1.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("it_name")
                If ds.Tables(0).Rows(i).Item("tr_tp") = "1" Then
                    dv1.Rows(rw).Cells(3).Value = "1.Purch."
                Else
                    dv1.Rows(rw).Cells(3).Value = "2.Return."
                End If
                dv1.Rows(rw).Cells(4).Value = ds.Tables(0).Rows(i).Item("unt")
                dv1.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(i).Item("pur_qty"), "####0.00")
                dv1.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("free_qty"), "####0.00")
                dv1.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("mrp"), "######0.00")
                dv1.Rows(rw).Cells(8).Value = Format(ds.Tables(0).Rows(i).Item("pur_rt"), "######0.00")
                dv1.Rows(rw).Cells(9).Value = Format(ds.Tables(0).Rows(i).Item("it_amt"), "######0.00")
                dv1.Rows(rw).Cells(10).Value = Format(ds.Tables(0).Rows(i).Item("disc_rt1"), "######0.00")
                dv1.Rows(rw).Cells(11).Value = Format(ds.Tables(0).Rows(i).Item("disc_amt1"), "######0.00")
                dv1.Rows(rw).Cells(12).Value = Format(ds.Tables(0).Rows(i).Item("disc_rt2"), "######0.00")
                dv1.Rows(rw).Cells(13).Value = Format(ds.Tables(0).Rows(i).Item("disc_amt2"), "######0.00")
                'mrpval = Val(ds.Tables(0).Rows(i).Item("mrp")) * (Val(ds.Tables(0).Rows(i).Item("pur_qty")) + Val(ds.Tables(0).Rows(i).Item("free_qty")))
                dv1.Rows(rw).Cells(14).Value = Format(ds.Tables(0).Rows(i).Item("mrp_amt"), "######0.00")
                dv1.Rows(rw).Cells(15).Value = Format(ds.Tables(0).Rows(i).Item("tto_amt"), "######0.00")
                dv1.Rows(rw).Cells(16).Value = ds.Tables(0).Rows(i).Item("txname")
                dv1.Rows(rw).Cells(17).Value = ds.Tables(0).Rows(i).Item("bit_type")
                dv1.Rows(rw).Cells(18).Value = Format(ds.Tables(0).Rows(i).Item("stax"), "######0.00")
                dv1.Rows(rw).Cells(19).Value = Format(ds.Tables(0).Rows(i).Item("disc_amt"), "######0.00")
                dv1.Rows(rw).Cells(20).Value = Format(ds.Tables(0).Rows(i).Item("oth_amt"), "######0.00")
                dv1.Rows(rw).Cells(21).Value = Format(ds.Tables(0).Rows(i).Item("it_tot"), "######0.00")
                dv1.Rows(rw).Cells(22).Value = ds.Tables(0).Rows(i).Item("it_cd")
                dv1.Rows(rw).Cells(23).Value = ds.Tables(0).Rows(i).Item("tax_cd")
                dv1.Rows(rw).Cells(24).Value = Format(ds.Tables(0).Rows(i).Item("ex_mrp"), "######0.00")
                dv1.Rows(rw).Cells(25).Value = 0
                dv1.Rows(rw).Cells(26).Value = ds.Tables(0).Rows(i).Item("mul_rt")
                dv1.Rows(rw).Cells(27).Value = ds.Tables(0).Rows(i).Item("pch_sl")
                rw += 1
            Next
            Me.grandamt(dv1)
            txtslno.Text = rw + 1
        End If
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT party.pname,party.add1,party.cl_amt, purch1.*, godown.godnm FROM purch1 LEFT OUTER JOIN godown ON purch1.godsl = godown.godsl LEFT OUTER JOIN party ON purch1.prt_code = party.prt_code WHERE(purch1.pur_no = " & slno & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscroll.Text = slno
            recdt.Value = dsedit.Tables(0).Rows(0).Item("pur_dt")
            ' txtorder.Text = dsedit.Tables(0).Rows(0).Item("po_no")
            txtinvno.Text = dsedit.Tables(0).Rows(0).Item("inv_no")
            invdt.Value = dsedit.Tables(0).Rows(0).Item("inv_dt")
            paydt.Value = dsedit.Tables(0).Rows(0).Item("paydt")
            cmbstore.Text = dsedit.Tables(0).Rows(0).Item("godnm")
            txtgodcd.Text = dsedit.Tables(0).Rows(0).Item("godsl")
            txtprtcd.Text = dsedit.Tables(0).Rows(0).Item("prt_code")
            cmbparty.Text = dsedit.Tables(0).Rows(0).Item("pname")
            lbladdress.Text = dsedit.Tables(0).Rows(0).Item("add1")
            txtdiscamt.Text = Format(dsedit.Tables(0).Rows(0).Item("dis_amt"), "######0.00")
            txtchargamt.Text = Format(dsedit.Tables(0).Rows(0).Item("chr_amt"), "######0.00")
            txtadj.Text = Format(dsedit.Tables(0).Rows(0).Item("adj_amt"), "######0.00")
            txtgrtotal.Text = Format(dsedit.Tables(0).Rows(0).Item("pur_amt"), "######0.00")
            txtnb.Text = dsedit.Tables(0).Rows(0).Item("nb")
            'Others
            txtchno.Text = dsedit.Tables(0).Rows(0).Item("chal_no")
            invdt.Value = dsedit.Tables(0).Rows(0).Item("chal_dt")
            txtvehno.Text = dsedit.Tables(0).Rows(0).Item("trk_no")
            txtlrno.Text = dsedit.Tables(0).Rows(0).Item("lr_no")
            lrdt.Value = dsedit.Tables(0).Rows(0).Item("lr_dt")
            txtwaypfx.Text = dsedit.Tables(0).Rows(0).Item("way_chr")
            txtwbno.Text = dsedit.Tables(0).Rows(0).Item("way_bno")
            clamt = Val(dsedit.Tables(0).Rows(0).Item("cl_amt"))
            If dsedit.Tables(0).Rows(0).Item("pur_of") = "I" Then
                cmbfrom.SelectedIndex = 0
            Else
                cmbfrom.SelectedIndex = 1
            End If
            If clamt < 0 Then
                lblprtbal.Text = Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
            Else
                lblprtbal.Text = Format(clamt, "#######0.00") & " " & "Cr."
            End If
            Me.dv_view()
        End If
        Close1()
    End Sub

    Private Sub trans_view()
        dvtrans.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        ds = get_dataset("SELECT TOP (3) convert(varchar,pur_dt,3) 'Date',STR(mrp,10,2) 'MRP', STR(pur_rt,10,2) 'Rate',unt AS 'Unit' FROM purch2 WHERE (it_cd = " & Val(txtitemcd.Text) & ") AND (prt_code = " & Val(txtprtcd.Text) & ") ORDER BY pur_dt DESC")
        If ds.Tables(0).Rows.Count <> 0 Then
            dvtrans.DataSource = ds.Tables(0)
        End If
        Close1()
    End Sub
#End Region
    Private Sub txtrate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrate.Validated
        txtrealrt.Text = txtrate.Text
        If chksetcalcrt.Checked = True Then
            purrt = Val(txtrate.Text)
            purrt = Val(purrt / (100 + Val(txtvatper.Text)) * 100)
            txtrate.Text = Format(Val(purrt), "########0.00")
        End If
        Me.dv_calc()
    End Sub

    Private Sub cmbfrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbfrom.SelectedIndexChanged
        'If cmbfrom.SelectedIndex = 0 Then
        '    txtorder.Text = ""
        '    txtorder.Enabled = False
        'Else
        '    txtorder.Enabled = True
        '    txtorder.Focus()
        'End If
    End Sub

    Private Sub txtvat_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvat.Validated, txtmrp.Validated, txtacharg.Validated, txtadisc.Validated
        Me.dv_calc()
    End Sub

    Private Sub txtcoper_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcoper.Validated, txtcoamt.Validated
        If Val(txtcoper.Text) <> 0 Then
            txtcoamt.Text = Format((Val(txtcoper.Text) / 100) * Val(txtamount.Text), "########0.00")
        End If
        'If Val(txtcoamt.Text) <> 0 Then
        '    txtcoper.Text = Format((Val(txtcoamt.Text) * 100) / Val(txtamount.Text), "########0.00")
        'End If
        Me.dv_calc()
    End Sub

    Private Sub txttrper_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrper.Validated, txttramt.Validated
        If Val(txttrper.Text) <> 0 Then
            txttramt.Text = Format((Val(txttrper.Text) / 100) * (Val(txtamount.Text) - Val(txtcoamt.Text)), "########0.00")
        End If
        'If Val(txttramt.Text) <> 0 Then
        '    txttrper.Text = Format((Val(txttramt.Text) * 100) / (Val(txtamount.Text) - Val(txtcoamt.Text)), "########0.00")
        'End If
        Me.dv_calc()
    End Sub

    Private Sub txtcharges_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdiscamt.Validated, txtchargamt.Validated
        grtot = (Val(lbltotal.Text) + Val(txtchargamt.Text)) - Val(txtdiscamt.Text)
        txtgrtotal.Text = Format(Math.Round(grtot), "########0.00")
        txtadj.Text = Format(Val(txtgrtotal.Text) - Val(grtot), "#######0.00")
        If chksetblrnd.Checked = True Then
            txtadj.Text = "0.00"
            txtgrtotal.Text = Format((Val(lbltotal.Text) + Val(txtchargamt.Text)) - Val(txtdiscamt.Text), "#######0.00")
        End If
    End Sub

    'Delete data from Table1/Primary Table
    Private Sub del1(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT pur_no,prt_code,pur_amt FROM purch1 WHERE pur_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            prtcd = dsdel.Tables(0).Rows(0).Item(1)
            toamt = dsdel.Tables(0).Rows(0).Item(2)
            If cmbpurtype.SelectedIndex = 1 Then
                SQLInsert("UPDATE party SET cr_amt=cr_amt - " & Val(toamt) & ",cl_amt=cl_amt - " & Val(toamt) & " WHERE prt_code=" & Val(prtcd) & "")
            End If
            SQLInsert("DELETE FROM purch1 WHERE pur_no=" & Val(code) & "")
        End If
    End Sub

    'Delete data from Table2/Secondary Table
    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT pur_sl,pur_qty,it_cd,free_qty,mul_rt,prd_tp,tr_tp  FROM purch2 WHERE pur_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                pursl = dsdel.Tables(0).Rows(i).Item(0)
                pqty = Val(dsdel.Tables(0).Rows(i).Item(1))
                itcd = dsdel.Tables(0).Rows(i).Item(2)
                frqt = Val(dsdel.Tables(0).Rows(i).Item(3))
                mulrt = Val(dsdel.Tables(0).Rows(i).Item(4))
                prdtp = Val(dsdel.Tables(0).Rows(i).Item(5))
                trtp = Val(dsdel.Tables(0).Rows(i).Item(6))
                itqt = (pqty * mulrt) + (frqt * mulrt)
                stock_INDEL(itqt, itcd, prdtp, trtp)
                SQLInsert("DELETE FROM purch2 WHERE pur_sl=" & Val(pursl) & "")
            Next
        End If
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
            Me.Text = "Purchase Invoice Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            dv.Visible = False
            Me.dv_edit(slno)
        End If
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            comd = "V"
            btnsave.Text = "View"
            Me.Text = "Purchase Invoice View Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            dv.Visible = False
            Me.dv_edit(slno)
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

    Private Sub txtscroll_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtscroll.Validated
        If comd <> "E" Then
            If txtscroll.Text <> "" Then
                Dim ds As DataSet = get_dataset("SELECT pur_no FROM purch1 WHERE pur_no=" & Val(txtscroll.Text) & " ")
                If ds.Tables(0).Rows.Count <> 0 Then
                    Me.dv_edit(txtscroll.Text)
                Else
                    MessageBox.Show("Please Select a Valid Scroll No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtscroll.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtscroll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscroll.GotFocus
        If comd <> "E" Then
            Me.clr()
        End If
    End Sub

    Private Sub cmbtr_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtr.Validated
        If cmbtr.SelectedIndex = 0 Then
            If Val(txtquantity.Text) < 0 Then
                txtquantity.Text = Val(txtquantity.Text) * (-1)
            End If
            If Val(txtfree.Text) < 0 Then
                txtfree.Text = Val(txtfree.Text) * (-1)
            End If
        Else
            If Val(txtquantity.Text) > 0 Then
                txtquantity.Text = Val(txtquantity.Text) * (-1)
            End If
            If Val(txtfree.Text) > 0 Then
                txtfree.Text = Val(txtfree.Text) * (-1)
            End If
            txtbatcreat.Text = "N"
            'cmbbatch.Text = ""
        End If
        Me.dv_calc()
    End Sub

    Private Sub txtquantity_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquantity.Validated, txtfree.Validated
        If cmbtr.SelectedIndex = 1 Then
            If Val(sender.Text) > 0 Then
                sender.Text = Format(Val(sender.Text) * (-1), "#######0.00")
            End If
        End If
        Me.dv_calc()
    End Sub

    Private Sub chksetsel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetsel.CheckedChanged
        If chksetsel.Checked = True Then
            chksetvat.Checked = True
            chksetrate.Checked = True
            chksetmrp.Checked = True
            chksetdisc.Checked = True
            chksetcalcrt.Checked = True
            chksetblrnd.Checked = True
            chksetcodisc.Checked = True
        Else
            chksetvat.Checked = False
            chksetrate.Checked = False
            chksetmrp.Checked = False
            chksetdisc.Checked = False
            chksetcalcrt.Checked = False
            chksetblrnd.Checked = False
            chksetcodisc.Checked = False
        End If
    End Sub

    Private Sub Set_view()
        chksetvat.Checked = False
        chksetrate.Checked = False
        chksetmrp.Checked = False
        chksetdisc.Checked = False
        chksetcalcrt.Checked = False
        chksetblrnd.Checked = False
        chksetcodisc.Checked = False
        Dim ds As DataSet = get_dataset("SELECT * FROM setting_purch")
        If ds.Tables(0).Rows.Count <> 0 Then
            If ds.Tables(0).Rows(0).Item("req_mrp") = 1 Then
                chksetmrp.Checked = True
            End If
            If ds.Tables(0).Rows(0).Item("req_rate") = 1 Then
                chksetrate.Checked = True
            End If
            If ds.Tables(0).Rows(0).Item("req_disc") = 1 Then
                chksetdisc.Checked = True
            End If
            If ds.Tables(0).Rows(0).Item("req_codis") = 1 Then
                chksetcodisc.Checked = True
            End If
            If ds.Tables(0).Rows(0).Item("req_vat") = 1 Then
                chksetvat.Checked = True
            End If
            If ds.Tables(0).Rows(0).Item("bill_rnd") = 1 Then
                chksetblrnd.Checked = True
            End If
            If ds.Tables(0).Rows(0).Item("rate_calc") = 1 Then
                chksetcalcrt.Checked = True
            End If
        End If
    End Sub

    Private Sub Set_chang()
        If chksetdisc.Checked = True Then
            txtadisc.Enabled = True
            txtacharg.Enabled = True
            txtchargamt.Enabled = True
            txtdiscamt.Enabled = True
        Else
            txtadisc.Enabled = False
            txtacharg.Enabled = False
            txtchargamt.Enabled = False
            txtdiscamt.Enabled = False
        End If
        If chksetcodisc.Checked = True Then
            txtcoper.Enabled = True
            txtcoamt.Enabled = True
            txttramt.Enabled = True
            txttrper.Enabled = True
        Else
            txtcoper.Enabled = False
            txtcoamt.Enabled = False
            txttramt.Enabled = False
            txttrper.Enabled = False
        End If
        If chksetvat.Checked = True Then
            txtvat.Enabled = True
            cmbvat.Enabled = True
        Else
            txtvat.Enabled = False
            cmbvat.Enabled = False
        End If
    End Sub

    Private Sub chksetblrnd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetblrnd.CheckedChanged
        Me.grandamt(dv1)
    End Sub

    Private Sub chksetvat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetvat.CheckedChanged
        Me.Set_chang()
    End Sub

    Private Sub chksetdisc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetdisc.CheckedChanged
        Me.Set_chang()
    End Sub

    Private Sub chksetcodisc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetcodisc.CheckedChanged
        Me.Set_chang()
    End Sub

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub

#Region "Panel Move"

    Private Sub other_panel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles other_panel.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll
    End Sub

    Private Sub other_panel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles other_panel.MouseMove
        If allowCoolMove = True Then
            other_panel.Location = New Point(other_panel.Location.X + e.X - myCoolPoint.X, other_panel.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub other_panel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles other_panel.MouseUp
        allowCoolMove = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub setting_panel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles setting_panel.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll
    End Sub

    Private Sub setting_panel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles setting_panel.MouseMove
        If allowCoolMove = True Then
            setting_panel.Location = New Point(setting_panel.Location.X + e.X - myCoolPoint.X, setting_panel.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub setting_panel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles setting_panel.MouseUp
        allowCoolMove = False
        Me.Cursor = Cursors.Default
    End Sub
#End Region

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        prtnm = InputBox("Enter Name Of The Party.", "Search Box...", Nothing)
        If (prtnm Is Nothing OrElse prtnm = "") Then
            'User hit cancel
        Else
             Dim dssear As DataSet = get_dataset("SELECT purch1.pur_no AS 'Scrl', CONVERT(VARCHAR,purch1.pur_dt,103) AS 'Date',purch1.inv_no AS 'Inv.No', purch1.inv_dt AS 'Inv.Date', (CASE WHEN purch1.pur_type='1' THEN 'Cash' WHEN purch1.pur_type='2' THEN 'Credit' END) AS 'Type', party.pname AS 'Name Of the Party', STR(purch1.pur_amt,10,2) AS 'Amount' FROM purch1 LEFT OUTER JOIN party ON purch1.prt_code = party.prt_code WHERE (party.pname LIKE'" & prtnm & "%') ORDER BY party.pname")
            dv.Columns.Clear()
            If dssear.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dssear.Tables(0)
            End If
            Close1()
            dv.Visible = True
            dv.Dock = DockStyle.Fill
        End If
    End Sub
  
    Private Sub cmnu1del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1del.Click
        'For Each row As DataGridViewRow In dv1.SelectedRows
        '    dv1.Rows.Remove(row)
        'Next
        'sl = 1
        'For i As Integer = 0 To dv1.Rows.Count - 1
        '    dv1.Rows(i).Cells(0).Value = i + 1
        '    sl += 1
        'Next
        'txtslno.Text = sl
    End Sub

  
End Class
