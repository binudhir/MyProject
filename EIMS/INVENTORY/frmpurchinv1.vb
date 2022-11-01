Imports vb = Microsoft.VisualBasic
Public Class frmpurchinv1
    Dim comd As String = "V"
#Region "Start Up"
    Private Sub frmpurchinvoice_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmpurchinvoice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmpurchinvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
        cmbpurtype.SelectedIndex = 0
        cmbfrom.SelectedIndex = 0
        cmbpr.SelectedIndex = 0
        cmbtr.SelectedIndex = 0
    End Sub

    Private Sub clr()
        dvtrans.DataSource = Nothing
        cmbproduct.Text = ""
        txtorder.Text = ""
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
        lblsound.Text = "0.000"
        lbldmg.Text = "0.000"
        txtchargamt.Text = "0.00"
        txtdiscamt.Text = "0.00"
        txtadj.Text = "0.00"
        txtgrtotal.Text = "0.00"
        cmbparty.Text = ""
        cmbstore.Text = ""
        'cmbfrom.SelectedIndex = 0
        'cmbpr.SelectedIndex = 0
        'cmbtr.SelectedIndex = 0
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
            Me.Text = "New Cash / Credit Purchase Entry Screen...."
            Dim ds As DataSet = get_dataset("SELECT max(pur_no) as 'Max' FROM purch1")
            txtscroll.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            btnsave.Text = "Save"
        ElseIf comd = "M" Then
            Me.Text = "Old Cash / Credit Purchase Modification Screen...."
            txtscroll.Text = ""
            btnsave.Text = "Modify"
        Else
            Me.Text = "Old Cash / Credit Purchase Deletion Screen...."
            txtscroll.Text = ""
            btnsave.Text = "Delete"
        End If
        Me.clr1()
    End Sub

    Private Sub clr1()
        'cmbproduct.Text = ""
        txtquantity.Text = "0.000"
        txtfree.Text = "0.000"
        txtunit.Text = ""
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
        txtmulrt.Text = "1"
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.dv_disp()
    End Sub
#End Region

#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtorder.Enter, txtscroll.Enter, txtslno.Enter, txtquantity.Enter, txtfree.Enter, txtunit.Enter, txtmrp.Enter, txtprtcd.Enter, txtrate.Enter, txtamount.Enter, txtcoper.Enter, txtcoamt.Enter, txttrper.Enter, txttramt.Enter, txtmrvalue.Enter, txttto.Enter, txtvat.Enter, txtadisc.Enter, txtacharg.Enter, txttotal.Enter, txtnb.Enter, txtchargamt.Enter, txtadisc.Enter, cmbparty.Enter, cmbstore.Enter, cmbproduct.Enter, cmbfrom.Enter, cmbpr.Enter, cmbpurtype.Enter, cmbtr.Enter, cmbvat.Enter, recdt.Enter, paydt.Enter, invdt.Enter, txtinvno.Enter, txtchno.Enter, txtvehno.Enter, txtlrno.Enter, txtwaypfx.Enter, txtwbno.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtorder.Leave, txtscroll.Leave, txtslno.Leave, txtquantity.Leave, txtfree.Leave, txtunit.Leave, txtmrp.Leave, txtprtcd.Leave, txtrate.Leave, txtamount.Leave, txtcoper.Leave, txtcoamt.Leave, txttrper.Leave, txttramt.Leave, txtmrvalue.Leave, txttto.Leave, txtvat.Leave, txtadisc.Leave, txtacharg.Leave, txttotal.Leave, txtnb.Leave, txtchargamt.Leave, txtadisc.Leave, cmbparty.Leave, cmbstore.Leave, cmbproduct.Leave, cmbfrom.Leave, cmbpr.Leave, cmbpurtype.Leave, cmbtr.Leave, cmbvat.Leave, recdt.Leave, paydt.Leave, invdt.Leave, txtinvno.Leave, txtchno.Leave, txtvehno.Leave, txtlrno.Leave, txtwaypfx.Leave, txtwbno.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub
#End Region

#Region "Mouse Enter/Leave"

    Private Sub sender_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnxt.MouseEnter, btnsave.MouseEnter, btnset.MouseEnter, btninter.MouseEnter, btnref.MouseEnter, btnprint.MouseEnter, btnview.MouseEnter, btnothers.MouseEnter, btnexit.MouseEnter, btnabort.MouseEnter, btnfresh1.MouseEnter, btnok.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnxt.MouseLeave, btnsave.MouseLeave, btnset.MouseLeave, btninter.MouseLeave, btnref.MouseLeave, btnprint.MouseLeave, btnview.MouseLeave, btnothers.MouseLeave, btnexit.MouseLeave, btnabort.MouseLeave, btnfresh1.MouseLeave, btnok.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

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
            key(txtquantity, e)
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

    Private Sub txtmrp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmrp.KeyPress
        key(txtrate, e)
        NUM1(e)
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        key(txtcoper, e)
        NUM1(e)
    End Sub

    Private Sub txtcomp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcoper.KeyPress
        key(txtcoamt, e)
        NUM1(e)
    End Sub

    Private Sub txtdisc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcoamt.KeyPress
        key(txttrper, e)
        NUM1(e)
    End Sub

    Private Sub txttrade_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttrper.KeyPress
        key(txttramt, e)
        NUM1(e)
    End Sub

    Private Sub txtdis_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttramt.KeyPress
        If cmbvat.Enabled = True Then
            key(cmbvat, e)
        Else
            key(txtadisc, e)
        End If
        NUM1(e)
    End Sub

    Private Sub cmbvat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbvat.KeyPress
        key(txtadisc, e)
        SPKey(e)
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
    Private Sub txtquantity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquantity.GotFocus, txtfree.GotFocus
        If Val(sender.Text) = 0 Then
            sender.Text = ""
        End If
    End Sub

    Private Sub txtquantity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquantity.LostFocus, txtfree.LostFocus
        sender.Text = Format(Val(sender.Text), "########0.000")
    End Sub

    Private Sub txtmrp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmrp.GotFocus, txtrate.GotFocus, txtamount.GotFocus, txtcoper.GotFocus, txtcoamt.GotFocus, txttrper.GotFocus, txttramt.GotFocus, txtmrvalue.GotFocus, txttto.GotFocus, txtadisc.GotFocus, txtacharg.GotFocus, txttotal.GotFocus, txtchargamt.GotFocus, txtdiscamt.GotFocus, txtadj.GotFocus, txtgrtotal.GotFocus
        If Val(sender.Text) = 0 Then
            sender.Text = ""
        End If
    End Sub

    Private Sub txtmrp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmrp.LostFocus, txtrate.LostFocus, txtamount.LostFocus, txtcoper.LostFocus, txtcoamt.LostFocus, txttrper.LostFocus, txttramt.LostFocus, txtmrvalue.LostFocus, txttto.LostFocus, txtadisc.LostFocus, txtacharg.LostFocus, txttotal.LostFocus, txtchargamt.LostFocus, txtdiscamt.LostFocus, txtadj.LostFocus, txtgrtotal.LostFocus
        sender.Text = Format(Val(sender.Text), "########0.00")
    End Sub

#Region "Combo Box"
    Private Sub cmbparty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.GotFocus
        lbladdress.Text = ""
        populate(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.LostFocus
        cmbparty.Height = 21
    End Sub

    Private Sub cmbparty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.Validated
        Dim ds As DataSet = get_dataset("SELECT prt_code,add1 FROM party WHERE pname='" & Trim(cmbparty.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtprtcd.Text = ds.Tables(0).Rows(0).Item("prt_code")
            lbladdress.Text = Trim(ds.Tables(0).Rows(0).Item("add1"))
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
        Dim ds As DataSet = get_dataset("SELECT item.it_cd, item.unt1,item.multi1, item.mrp, item.pur_rate, item.cl_stk, item.taxcd, taxper.txname, taxper.taxamt, item_group.grp_nm, item.it_desc FROM item LEFT OUTER JOIN item_group ON item.grp_cd = item_group.grp_cd LEFT OUTER JOIN taxper ON item.taxcd = taxper.taxcd WHERE item.it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtproductcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            txtunit.Text = ds.Tables(0).Rows(0).Item("unt1")
            txtmulrt.Text = ds.Tables(0).Rows(0).Item("multi1")
            lbldescri.Text = Trim(ds.Tables(0).Rows(0).Item("it_desc"))
            lblgrp.Text = Trim(ds.Tables(0).Rows(0).Item("grp_nm"))
            txttaxcd.Text = ds.Tables(0).Rows(0).Item("taxcd")
            txtvatper.Text = ds.Tables(0).Rows(0).Item("taxamt")
            cmbvat.Text = ds.Tables(0).Rows(0).Item("txname")
            txtmrp.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            txtrate.Text = Format(ds.Tables(0).Rows(0).Item("pur_rate"), "#######0.00")
            lblsound.Text = Format(ds.Tables(0).Rows(0).Item("cl_stk"), "#####0.000")
            Me.dv_calc()
            If Val(txtprtcd.Text) <> 0 Or Val(txtproductcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
    End Sub

    Private Sub cmbproduct_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbproduct.Validating
        vdating(cmbproduct, "SELECT it_name FROM item WHERE rec_lock='N' AND it_name= '" & Trim(cmbproduct.Text) & "'", "Please Select a Valid Product Name.")
    End Sub

    Private Sub cmbproduct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.TextChanged
        Dim ds As DataSet = get_dataset("SELECT item.it_cd, item.unt1, item.mrp, item.pur_rate, item.cl_stk, item.taxcd, taxper.txname, taxper.taxamt FROM item LEFT OUTER JOIN taxper ON item.taxcd = taxper.taxcd WHERE item.it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtproductcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            txtunit.Text = ds.Tables(0).Rows(0).Item("unt1")
            txttaxcd.Text = ds.Tables(0).Rows(0).Item("taxcd")
            txtvatper.Text = ds.Tables(0).Rows(0).Item("taxamt")
            cmbvat.Text = ds.Tables(0).Rows(0).Item("txname")
            txtmrp.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            txtrate.Text = Format(ds.Tables(0).Rows(0).Item("pur_rate"), "#######0.00")
            lblsound.Text = Format(ds.Tables(0).Rows(0).Item("cl_stk"), "#####")
            If Val(txtprtcd.Text) <> 0 Or Val(txtproductcd.Text) <> 0 Then
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
        Dim ds As DataSet = get_dataset("SELECT taxcd,taxamt FROM taxper WHERE (txname ='" & Trim(cmbvat.Text) & "')")
        If ds.Tables(0).Rows.Count <> 0 Then
            txttaxcd.Text = ds.Tables(0).Rows(0).Item("taxcd")
            txtvatper.Text = ds.Tables(0).Rows(0).Item("taxamt")
            Me.dv_calc()
        End If
    End Sub
#End Region

#Region "Botton Click"

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "&Save"
    End Sub

    Private Sub btninter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninter.Click
        If comd = "E" Then
            comd = "M"
        ElseIf comd = "M" Then
            comd = "D"
        Else
            comd = "E"
        End If
        Me.clr()
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnothers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnothers.Click
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

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Val(txtscroll.Text) = 0 Then
            MessageBox.Show("Sorry The Scroll No. Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
#End Region

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
                SQLInsert("INSERT INTO purch1 (pur_no,pur_dt,prt_code,chal_no,chal_dt,inv_no,inv_dt,way_bno,trk_no,pur_type,pur_of,to_amt,way_chr,dis_amt," & _
                          "chr_amt,nb,paydt,lr_no,lr_dt,adj_amt,godsl,usr_ent,ent_date,usr_mod,mod_date,rec_lock,usedby,pfx,purch_for,po_no,shift_sl)" & _
                          "VALUES (" & Val(txtscroll.Text) & ",'" & Format(recdt.Value, "dd/MMM/yyyy") & "'," & Val(txtprtcd.Text) & ",'" & _
                          Trim(txtchno.Text) & "','" & Format(chdt.Value, "dd/MMM/yyyy") & "','" & Trim(txtinvno.Text) & "','" & _
                          Format(invdt.Value, "dd/MMM/yyyy") & "'," & Val(txtwbno.Text) & ",'" & Trim(txtvehno.Text) & "','" & _
                          vb.Left(cmbpurtype.Text, 1) & "','I'," & Val(txtgrtotal.Text) & ",'" & Trim(txtwaypfx.Text) & "'," & _
                          Val(txtdiscamt.Text) & "," & Val(txtchargamt.Text) & ",'" & Trim(txtnb.Text) & "','" & _
                          Format(paydt.Value, "dd/MMM/yyyy") & "','" & Trim(txtlrno.Text) & "','" & Format(lrdt.Value, "dd/MMM/yyyy") & "'," & _
                          Val(txtadj.Text) & "," & Val(txtgodcd.Text) & "," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & _
                          Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N','N','AA','1'," & Val(txtorder.Text) & ",0)")
                Me.dv_save()
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'cnfr = MessageBox.Show("Are You Sure The Printer is Ready To Print The Bill.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If cnfr = vbYes Then
                '    Call colrec_print(Val(txtscrlno.Text))
                'End If
                Me.clr()
                Close1()
            End If
        ElseIf comd = "M" Then
            If usr_tp = "O" Then
                MessageBox.Show("You Are Not Authorised to Modify The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT pur_no FROM purch1 WHERE pur_no=" & Val(txtscroll.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE purch1 SET pur_dt='" & Format(recdt.Value, "dd/MMM/yyyy") & "',prt_code=" & Val(txtprtcd.Text) & ",chal_no='" & _
                          Trim(txtchno.Text) & "',chal_dt='" & Format(chdt.Value, "dd/MMM/yyyy") & "',inv_no='" & Trim(txtinvno.Text) & "',inv_dt='" & _
                          Format(invdt.Value, "dd/MMM/yyyy") & "',way_bno=" & Val(txtwbno.Text) & ",trk_no='" & Trim(txtvehno.Text) & "',pur_type='" & _
                          vb.Left(cmbpurtype.Text, 1) & "',to_amt=" & Val(txtgrtotal.Text) & ",way_chr='" & Trim(txtwaypfx.Text) & "',dis_amt=" & _
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
            If usr_tp <> "A" And usr_tp <> "D" Then
                MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
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
                itcd = Val(dv1.Rows(i).Cells(21).Value)
                trtp = dv1.Rows(i).Cells(3).Value
                qty = Val(dv1.Rows(i).Cells(4).Value)
                free = Val(dv1.Rows(i).Cells(5).Value)
                unt = dv1.Rows(i).Cells(6).Value
                mrp = Val(dv1.Rows(i).Cells(7).Value)
                it_rt = Val(dv1.Rows(i).Cells(8).Value)
                amt = Val(dv1.Rows(i).Cells(9).Value)
                codisper = Val(dv1.Rows(i).Cells(10).Value)
                codisamt = Val(dv1.Rows(i).Cells(11).Value)
                trdisper = Val(dv1.Rows(i).Cells(12).Value)
                trdisamt = Val(dv1.Rows(i).Cells(13).Value)
                mrval = Val(dv1.Rows(i).Cells(14).Value)
                tto = Val(dv1.Rows(i).Cells(15).Value)
                taxcd = Val(dv1.Rows(i).Cells(22).Value)
                vatamt = Val(dv1.Rows(i).Cells(17).Value)
                adisc = Val(dv1.Rows(i).Cells(18).Value)
                achrg = Val(dv1.Rows(i).Cells(19).Value)
                total = Val(dv1.Rows(i).Cells(20).Value)
                exmrp = Val(dv1.Rows(i).Cells(23).Value)
                pchsl = Val(dv1.Rows(i).Cells(24).Value)
                mulrt = Val(dv1.Rows(i).Cells(25).Value)
                mrpamt = Val(exmrp) * (Val(qty) + Val(free))
                Dim ds1 As DataSet = get_dataset("SELECT max(pur_sl) as 'Max' FROM purch2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO purch2(pur_sl,pur_no,pur_dt,prt_code,it_cd,pur_rt,pur_qty,it_amt,tto_amt,tax_cd,oth_amt,disc_amt," & _
                          "pur_amt,stax,entax,mrp,ex_mrp,pch_sl,prd_tp,tr_tp,unt,free_qty,mul_rt,disc_rt1,disc_rt2,disc_amt1,disc_amt2,mrp_amt," & _
                          "bit_type,pfx,po_sl,purch_for) VALUES (" & Val(mxno) & "," & Val(txtscroll.Text) & ",'" & Format(recdt.Value, "dd/MMM/yyyy") & "'," & _
                          Val(txtprtcd.Text) & "," & Val(itcd) & "," & it_rt & "," & qty & "," & amt & "," & tto & "," & taxcd & "," & _
                          achrg & "," & adisc & "," & total & "," & vatamt & ",0," & mrp & "," & exmrp & "," & pchsl & ",'" & vb.Left(prdtp, 1) & "','" & _
                          vb.Left(trtp, 1) & "','" & unt & "'," & free & "," & mulrt & "," & codisper & "," & trdisper & "," & codisamt & "," & trdisamt & "," & _
                          mrpamt & ",'I','AA'," & pchsl & ",'1')")
            Next
        End If
    End Sub

    Private Sub btnnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.Click
        If Trim(cmbproduct.Text) = "" Or Val(txtproductcd.Text) = 0 Then
            MessageBox.Show("Please Provide A Product Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If
        If Val(txtquantity.Text) = 0 Then
            MessageBox.Show("Sorry The Quantity Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtquantity.Focus()
            Exit Sub
        End If
        If Val(txtmrp.Text) = 0 Then
            MessageBox.Show("Sorry The MRP Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtmrp.Focus()
            Exit Sub
        End If
        If Val(txtrate.Text) = 0 Then
            MessageBox.Show("Sorry The Purchase Rate Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtrate.Focus()
            Exit Sub
        End If
        If Val(txtvat.Text) = 0 Then
            MessageBox.Show("Sorry The Vat Amount Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtrate.Focus()
            Exit Sub
        End If

        sl1 = Val(txtslno.Text)
        dv1.Rows.Add()
        dv1.Rows(sl1 - 1).Cells(0).Value = sl1
        dv1.Rows(sl1 - 1).Cells(1).Value = cmbpr.Text
        dv1.Rows(sl1 - 1).Cells(2).Value = cmbproduct.Text
        dv1.Rows(sl1 - 1).Cells(3).Value = cmbtr.Text
        dv1.Rows(sl1 - 1).Cells(4).Value = txtquantity.Text
        dv1.Rows(sl1 - 1).Cells(5).Value = txtfree.Text
        dv1.Rows(sl1 - 1).Cells(6).Value = txtunit.Text
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
        dv1.Rows(sl1 - 1).Cells(17).Value = txtvat.Text
        dv1.Rows(sl1 - 1).Cells(18).Value = txtadisc.Text
        dv1.Rows(sl1 - 1).Cells(19).Value = txtacharg.Text
        dv1.Rows(sl1 - 1).Cells(20).Value = txttotal.Text
        dv1.Rows(sl1 - 1).Cells(21).Value = txtproductcd.Text
        dv1.Rows(sl1 - 1).Cells(22).Value = txttaxcd.Text
        dv1.Rows(sl1 - 1).Cells(23).Value = Format((Val(txtmrp.Text) / (100 + Val(txtvatper.Text))) * 100, "#########0.00")
        dv1.Rows(sl1 - 1).Cells(24).Value = 0
        dv1.Rows(sl1 - 1).Cells(25).Value = txtmulrt.Text
        sl1 += 1
        txtslno.Text = sl1
        Me.grandamt(dv1)
        Me.clr1()
        cmbproduct.Focus()
    End Sub

    Private Sub dv_calc()
        If Val(txtquantity.Text) <> 0 Or Val(txtfree.Text) <> 0 Then
            txtmrvalue.Text = Format(Val(Val(txtquantity.Text) + Val(txtfree.Text)) * Val(txtmrp.Text), "########0.00")
            txtamount.Text = Format(Val(Val(txtquantity.Text) * Val(txtrate.Text)), "########0.00")
            txttto.Text = Format(Val(txtamount.Text) - (Val(txtcoamt.Text) + Val(txttramt.Text)), "########0.00")
            txtvat.Text = Format((Val(txtvatper.Text) / 100) * Val(txttto.Text), "########0.00")
            'totamt = Val(txttto.Text) + Val(txtvat.Text)
            txttotal.Text = Format(Val(Val(txtamount.Text) + (Val(txtvat.Text) + Val(txtacharg.Text)) - Val(txtadisc.Text)), "########0.00")
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
            vatamt = dgv.Rows(i).Cells(17).Value
            disc = dgv.Rows(i).Cells(18).Value
            chrg = dgv.Rows(i).Cells(19).Value
            gtamt = dgv.Rows(i).Cells(20).Value
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
        'txtgrtotal.Text = Format((Val(gtamt) + Val(txtchargamt.Text)) - Val(txtdiscamt.Text), "#######0.00")
    End Sub

    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT purch1.pur_no, purch1.pur_dt, purch1.inv_no, purch1.pur_type, purch1.to_amt, purch1.inv_dt, purch1.rec_lock, party.pname FROM purch1 LEFT OUTER JOIN party ON purch1.prt_code = party.prt_code")
        dv.Rows.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                dv.Rows.Add()
                dv.Rows(i).Cells(0).Value = dsedit.Tables(0).Rows(rw).Item("pur_no")
                dv.Rows(i).Cells(1).Value = Format(dsedit.Tables(0).Rows(rw).Item("pur_dt"), "dd/MM/yyyy")

                If dsedit.Tables(0).Rows(rw).Item("pur_type") = "1" Then
                    dv.Rows(i).Cells(2).Value = "Cash"
                Else
                    dv.Rows(i).Cells(2).Value = "Credit"
                End If
                dv.Rows(i).Cells(3).Value = dsedit.Tables(0).Rows(rw).Item("pname")
                dv.Rows(i).Cells(4).Value = dsedit.Tables(0).Rows(rw).Item("inv_no")
                dv.Rows(i).Cells(5).Value = Format(dsedit.Tables(0).Rows(rw).Item("inv_dt"), "dd/MM/yyyy")
                dv.Rows(i).Cells(6).Value = Format(dsedit.Tables(0).Rows(rw).Item("to_amt"), "######0.00")
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
                dv1.Rows(rw).Cells(4).Value = Format(ds.Tables(0).Rows(i).Item("pur_qty"), "####0.000")
                dv1.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(i).Item("free_qty"), "####0.000")
                dv1.Rows(rw).Cells(6).Value = ds.Tables(0).Rows(i).Item("unt")
                dv1.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("mrp"), "######0.00")
                dv1.Rows(rw).Cells(8).Value = Format(ds.Tables(0).Rows(i).Item("pur_rt"), "######0.00")
                dv1.Rows(rw).Cells(9).Value = Format(ds.Tables(0).Rows(i).Item("it_amt"), "######0.00")
                dv1.Rows(rw).Cells(10).Value = Format(ds.Tables(0).Rows(i).Item("disc_rt1"), "######0.00")
                dv1.Rows(rw).Cells(11).Value = Format(ds.Tables(0).Rows(i).Item("disc_amt1"), "######0.00")
                dv1.Rows(rw).Cells(12).Value = Format(ds.Tables(0).Rows(i).Item("disc_rt2"), "######0.00")
                dv1.Rows(rw).Cells(13).Value = Format(ds.Tables(0).Rows(i).Item("disc_amt2"), "######0.00")
                mrpval = Val(ds.Tables(0).Rows(i).Item("mrp")) * (Val(ds.Tables(0).Rows(i).Item("pur_qty")) + Val(ds.Tables(0).Rows(i).Item("free_qty")))
                dv1.Rows(rw).Cells(14).Value = Format(mrpval, "######0.00")
                dv1.Rows(rw).Cells(15).Value = Format(ds.Tables(0).Rows(i).Item("tto_amt"), "######0.00")
                dv1.Rows(rw).Cells(16).Value = ds.Tables(0).Rows(i).Item("txname")
                dv1.Rows(rw).Cells(17).Value = Format(ds.Tables(0).Rows(i).Item("stax"), "######0.00")
                dv1.Rows(rw).Cells(18).Value = Format(ds.Tables(0).Rows(i).Item("disc_amt"), "######0.00")
                dv1.Rows(rw).Cells(19).Value = Format(ds.Tables(0).Rows(i).Item("oth_amt"), "######0.00")
                dv1.Rows(rw).Cells(20).Value = Format(ds.Tables(0).Rows(i).Item("pur_amt"), "######0.00")
                dv1.Rows(rw).Cells(21).Value = ds.Tables(0).Rows(i).Item("it_cd")
                dv1.Rows(rw).Cells(22).Value = ds.Tables(0).Rows(i).Item("tax_cd")
                dv1.Rows(rw).Cells(23).Value = Format(ds.Tables(0).Rows(i).Item("ex_mrp"), "######0.00")
                dv1.Rows(rw).Cells(24).Value = ds.Tables(0).Rows(i).Item("po_sl")
                dv1.Rows(rw).Cells(25).Value = ds.Tables(0).Rows(i).Item("mul_rt")
                rw += 1
            Next
            Me.grandamt(dv1)
            txtslno.Text = rw + 1
        End If
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT party.pname, purch1.*, godown.godnm FROM purch1 LEFT OUTER JOIN godown ON purch1.godsl = godown.godsl LEFT OUTER JOIN party ON purch1.prt_code = party.prt_code WHERE(purch1.pur_no = " & slno & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscroll.Text = slno
            recdt.Value = dsedit.Tables(0).Rows(0).Item("pur_dt")
            cmbpurtype.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("pur_type")) - 1
            'cmbfrom.SelectedIndex=0
            txtorder.Text = dsedit.Tables(0).Rows(0).Item("po_no")
            txtinvno.Text = dsedit.Tables(0).Rows(0).Item("inv_no")
            invdt.Value = dsedit.Tables(0).Rows(0).Item("inv_dt")
            paydt.Value = dsedit.Tables(0).Rows(0).Item("paydt")
            cmbstore.Text = dsedit.Tables(0).Rows(0).Item("godnm")
            txtgodcd.Text = dsedit.Tables(0).Rows(0).Item("godsl")
            txtprtcd.Text = dsedit.Tables(0).Rows(0).Item("prt_code")
            cmbparty.Text = dsedit.Tables(0).Rows(0).Item("pname")
            txtdiscamt.Text = Format(dsedit.Tables(0).Rows(0).Item("dis_amt"), "######0.00")
            txtchargamt.Text = Format(dsedit.Tables(0).Rows(0).Item("chr_amt"), "######0.00")
            txtadj.Text = Format(dsedit.Tables(0).Rows(0).Item("adj_amt"), "######0.00")
            txtgrtotal.Text = Format(dsedit.Tables(0).Rows(0).Item("to_amt"), "######0.00")
            txtnb.Text = dsedit.Tables(0).Rows(0).Item("nb")
            'Others
            txtchno.Text = dsedit.Tables(0).Rows(0).Item("chal_no")
            invdt.Value = dsedit.Tables(0).Rows(0).Item("chal_dt")
            txtvehno.Text = dsedit.Tables(0).Rows(0).Item("trk_no")
            txtlrno.Text = dsedit.Tables(0).Rows(0).Item("lr_no")
            lrdt.Value = dsedit.Tables(0).Rows(0).Item("lr_dt")
            txtwaypfx.Text = dsedit.Tables(0).Rows(0).Item("way_chr")
            txtwbno.Text = dsedit.Tables(0).Rows(0).Item("way_bno")
            Me.dv_view()
        End If
        Close1()
    End Sub

    Private Sub txtrate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrate.TextChanged
        txtamount.Text = Val(txtquantity.Text) * Val(txtrate.Text)
    End Sub

    Private Sub cmbfrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbfrom.SelectedIndexChanged
        If cmbfrom.SelectedIndex = 0 Then
            txtorder.Text = ""
            txtorder.Enabled = False
        Else
            txtorder.Enabled = True
            txtorder.Focus()
        End If
    End Sub

    Private Sub txtvat_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvat.Validated, txtrate.Validated, txtmrp.Validated, txtacharg.Validated, txtadisc.Validated
        Me.dv_calc()
    End Sub

    Private Sub txtcoper_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcoper.Validated, txtcoamt.Validated
        If Val(txtcoper.Text) <> 0 Then
            txtcoamt.Text = Format((Val(txtcoper.Text) / 100) * Val(txtamount.Text), "########0.00")
        End If
        If Val(txtcoamt.Text) <> 0 Then
            txtcoper.Text = Format((Val(txtcoamt.Text) * 100) / Val(txtamount.Text), "########0.00")
        End If
        Me.dv_calc()
    End Sub

    Private Sub txttrper_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrper.Validated, txttramt.Validated
        If Val(txttrper.Text) <> 0 Then
            txttramt.Text = Format((Val(txttrper.Text) / 100) * (Val(txtamount.Text) - Val(txtcoamt.Text)), "########0.00")
        End If
        If Val(txttramt.Text) <> 0 Then
            txttrper.Text = Format((Val(txttramt.Text) * 100) / (Val(txtamount.Text) - Val(txtcoamt.Text)), "########0.00")
        End If
        Me.dv_calc()
    End Sub

    Private Sub txtcharges_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdiscamt.Validated, txtchargamt.Validated
        grtot = (Val(lbltotal.Text) + Val(txtchargamt.Text)) - Val(txtdiscamt.Text)
        txtgrtotal.Text = Format(Math.Round(grtot), "########0.00")
        txtadj.Text = Format(Val(txtgrtotal.Text) - Val(grtot), "#######0.00")
        'txtgrtotal.Text = Format((Val(gtamt) + Val(txtchargamt.Text)) - Val(txtdiscamt.Text), "#######0.00")
    End Sub

    'Delete data from Table1/Primary Table
    Private Sub del1(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT pur_no FROM purch1 WHERE pur_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            SQLInsert("DELETE FROM purch1 WHERE pur_no=" & Val(code) & "")
        End If
    End Sub

    'Delete data from Table2/Secondary Table
    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT pur_sl FROM purch2 WHERE pur_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                posl = dsdel.Tables(0).Rows(i).Item(0)
                SQLInsert("DELETE FROM purch2 WHERE pur_sl=" & Val(posl) & "")
            Next
        End If
    End Sub

    Private Sub trans_view()
        dvtrans.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        ds = get_dataset("SELECT TOP (3) convert(varchar,pur_dt,3) 'Date',STR(mrp,10,2) 'MRP', STR(pur_rt,10,2) 'Rate' FROM purch2 WHERE (it_cd = " & Val(txtproductcd.Text) & ") AND (prt_code = " & Val(txtprtcd.Text) & ") ORDER BY pur_dt")
        If ds.Tables(0).Rows.Count <> 0 Then
            dvtrans.DataSource = ds.Tables(0)
        End If
        Close1()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Add"
        Me.Text = "Old Purchase Return Entry Screen . . ."
        dv.Visible = False
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Edit"
            Me.Text = "Old Purchase Return Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            dv.Visible = False
            Me.dv_edit(slno)
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
                    Call del1(slno)
                    Call del2(slno)
                End If
                Close1()
                Me.dv_disp()
            Else
                MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
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

    Private Sub cmnu1del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1del.Click
        For Each row As DataGridViewRow In dv1.SelectedRows
            dv1.Rows.Remove(row)
        Next
        sl = 1
        For i As Integer = 0 To dv1.Rows.Count - 1
            dv1.Rows(i).Cells(0).Value = i + 1
            sl += 1
        Next
        txtslno.Text = sl
        Me.grandamt(dv1)
    End Sub

    Private Sub txtscroll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscroll.GotFocus
        If comd <> "E" Then
            Me.clr()
        End If
    End Sub

    Private Sub cmbtr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtr.SelectedIndexChanged
        If cmbtr.SelectedIndex = 0 Then
            If Val(txtquantity.Text) < 0 Then
                txtquantity.Text = Val(txtquantity.Text) * (-1)
            End If
            If Val(txtfree.Text) < 0 Then
                txtfree.Text = Val(txtfree.Text) * (-1)
            End If
        Else
            txtquantity.Text = Val(txtquantity.Text) * (-1)
            txtfree.Text = Val(txtfree.Text) * (-1)
        End If
        Me.dv_calc()
    End Sub

    Private Sub txtquantity_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquantity.Validated
        If cmbtr.SelectedIndex = 1 Then
            txtquantity.Text = Val(txtquantity.Text) * (-1)
        End If
        Me.dv_calc()
    End Sub

    Private Sub txtfree_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfree.Validated
        If cmbtr.SelectedIndex = 1 Then
            txtfree.Text = Val(txtfree.Text) * (-1)
        End If
        Me.dv_calc()
    End Sub
End Class
