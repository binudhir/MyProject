Imports vb = Microsoft.VisualBasic
Public Class frmpurchinv
    Dim comd As String = "E"
    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point
#Region "Start Up"
    Private Sub frmpurchinv_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
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
        Me.clr()
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
        dvchal1.DataSource = Nothing
        dvchal.Visible = False
        dvsl1.Rows.Clear()
        cmbproduct.Text = ""
        cmbbatch.Text = ""
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
        Else
            Me.Text = "Purchase Invoice Deletion Screen...."
            txtscroll.Text = ""
            btnsave.Text = "Delete"
        End If
        Me.clr1()
        Me.Set_chang()
    End Sub

    Private Sub clr1()
        txttaxstl.Text = "I"
        txttaxcat.Text = "1"
        'txtbatcnfr.Text = "N"
        cmbproduct.Text = ""
        cmbbatch.Text = ""
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

    Private Sub sender_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscroll.Enter, txtslno.Enter, txtquantity.Enter, txtfree.Enter, txtmrp.Enter, txtprtcd.Enter, txtrate.Enter, txtamount.Enter, txtcoper.Enter, txtcoamt.Enter, txttrper.Enter, txttramt.Enter, txtmrvalue.Enter, txttto.Enter, txtvat.Enter, txtadisc.Enter, txtacharg.Enter, txttotal.Enter, txtnb.Enter, txtchargamt.Enter, txtadisc.Enter, cmbparty.Enter, cmbstore.Enter, cmbproduct.Enter, cmbfrom.Enter, cmbpr.Enter, cmbtr.Enter, cmbvat.Enter, recdt.Enter, paydt.Enter, invdt.Enter, txtinvno.Enter, txtchno.Enter, txtvehno.Enter, txtlrno.Enter, txtwaypfx.Enter, txtwbno.Enter, cmbbatch.Enter, cmbunit.Enter, txtdiscamt.Enter, txttaxstl.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscroll.Leave, txtslno.Leave, txtquantity.Leave, txtfree.Leave, txtmrp.Leave, txtprtcd.Leave, txtrate.Leave, txtamount.Leave, txtcoper.Leave, txtcoamt.Leave, txttrper.Leave, txttramt.Leave, txtmrvalue.Leave, txttto.Leave, txtvat.Leave, txtadisc.Leave, txtacharg.Leave, txttotal.Leave, txtnb.Leave, txtchargamt.Leave, txtadisc.Leave, cmbparty.Leave, cmbstore.Leave, cmbproduct.Leave, cmbfrom.Leave, cmbpr.Leave, cmbtr.Leave, cmbvat.Leave, recdt.Leave, paydt.Leave, invdt.Leave, txtinvno.Leave, txtchno.Leave, txtvehno.Leave, txtlrno.Leave, txtwaypfx.Leave, txtwbno.Leave, cmbbatch.Leave, cmbunit.Leave, txtdiscamt.Leave, txttaxstl.Leave
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

#Region "Key Press"

    Private Sub txtscroll_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtscroll.KeyPress
        key(recdt, e)
        NUM(e)
    End Sub

    Private Sub recdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles recdt.KeyPress
        key(txtinvno, e)
    End Sub

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(invdt, e)
        SPKey(e)
    End Sub

    Private Sub txtinvno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinvno.KeyPress
        key(cmbparty, e)
        SPKey(e)
    End Sub

    Private Sub invdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles invdt.KeyPress
        key(paydt, e)
    End Sub

    Private Sub paydt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles paydt.KeyPress
        key(cmbstore, e)
    End Sub

    Private Sub cmbfrom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbfrom.KeyPress
        key(cmbstore, e)
        SPKey(e)
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
            dvchal.Visible = False
        Else
            If cmbbatch.Enabled = True Then
                key(cmbbatch, e)
            Else
                key(cmbunit, e)
            End If
        End If
        SPKey(e)
    End Sub

    Private Sub cmbbatch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbatch.KeyPress
        key(cmbunit, e)
        SPKey(e)
    End Sub

    Private Sub cmbtr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtr.KeyPress
        key(cmbunit, e)
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

#Region "Combo Box"
    Private Sub cmbparty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.GotFocus
        lbladdress.Text = ""
        populate(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.LostFocus
        cmbparty.Height = 21
    End Sub

    Private Sub cmbparty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.Validated
        Dim ds As DataSet = get_dataset("SELECT prt_code,add1,lim_day,cl_amt FROM party WHERE pname='" & Trim(cmbparty.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtprtcd.Text = ds.Tables(0).Rows(0).Item("prt_code")
            lbladdress.Text = Trim(ds.Tables(0).Rows(0).Item("add1"))
            clamt = Val(ds.Tables(0).Rows(0).Item("cl_amt"))
            If clamt < 0 Then
                lblprtbal.Text = Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
            Else
                lblprtbal.Text = Format(clamt, "#######0.00") & " " & "Cr."
            End If
            paydt.Value = invdt.Value.AddDays(Val(ds.Tables(0).Rows(0).Item("lim_day")))
            Dim dschal As DataSet = get_dataset("SELECT pchal2.pch_no,CONVERT(VARCHAR,pchal2.pch_dt,3) AS Date, item.it_name, (CASE WHEN pchal2.bat_cd=0 THEN 'X'  WHEN pchal2.bat_cd<>0 THEN batno.bat_no END) AS 'Batch', (CASE WHEN pchal2.pch_tp='1' THEN '1.Purch.' WHEN pchal2.pch_tp='2' THEN '2.Return.' END) AS 'Type',pchal2.unt,pchal2.pch_qty ,pchal2.bpch_qty,pchal2.free_qty, pchal2.bfree_qty,pchal2.mrp,pchal2.pur_rt, pchal2.mul_rt, pchal2.pch_sl, pchal2.prd_tp ,pchal2.it_cd, pchal2.bat_cd,pchal2.pch_dt FROM pchal2 LEFT OUTER JOIN batno ON pchal2.bat_cd = batno.bat_cd LEFT OUTER JOIN item ON pchal2.it_cd = item.it_cd WHERE (pchal2.prt_code = " & Val(txtprtcd.Text) & ") ORDER BY pchal2.pch_dt")
            dvchal1.Columns.Clear()
            If dschal.Tables(0).Rows.Count <> 0 Then
                dvchal1.DataSource = dschal.Tables(0)
            End If
        End If
    End Sub

    Private Sub cmbparty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbparty.Validating
        vdating(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' AND pname='" & Trim(cmbparty.Text) & "'", "Please Select A Valid Party Name.")
    End Sub

    Private Sub cmbproduct_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.GotFocus
        Me.clr1()
        'lbldescri.Text = ""
        'lblgrp.Text = ""
        'populate(cmbproduct, "SELECT it_name FROM item WHERE (rec_lock = 'N') ORDER BY it_name")
        Me.dv_chal()
    End Sub

    Private Sub cmbproduct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.LostFocus
        'dvchal.Visible = False
    End Sub

    'Private Sub cmbproduct_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbproduct.Validated
    '    Dim ds As DataSet = get_dataset("SELECT item.it_cd,item.bat_cnf, item.descri, item.ptx_cd, item.mrp, item.pur_rate, item.unt1,item.unt2,item.unt3,item.unt4, item.cl_stk,item.dcl_stk, itgrp.gp_nm, item.multi1, taxper.txname,taxper.taxcat, item.tax_stl, taxper.tax1 FROM item LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN taxper ON item.ptx_cd = taxper.taxcd WHERE item.it_name='" & Trim(cmbproduct.Text) & "'")
    '    If ds.Tables(0).Rows.Count <> 0 Then
    '        txtitemcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
    '        cmbunit.Text = ds.Tables(0).Rows(0).Item("unt1")
    '        lbldescri.Text = Trim(ds.Tables(0).Rows(0).Item("descri"))
    '        lblgrp.Text = Trim(ds.Tables(0).Rows(0).Item("gp_nm"))
    '        txttaxcd.Text = ds.Tables(0).Rows(0).Item("ptx_cd")
    '        txtvatper.Text = ds.Tables(0).Rows(0).Item("tax1")
    '        cmbvat.Text = ds.Tables(0).Rows(0).Item("txname")
    '        txtrealmrp.Text = Val(ds.Tables(0).Rows(0).Item("mrp"))
    '        txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("pur_rate"))
    '        txtsndstk.Text = Val(ds.Tables(0).Rows(0).Item("cl_stk"))
    '        txtdmgstk.Text = Val(ds.Tables(0).Rows(0).Item("dcl_stk"))
    '        txtbatcnfr.Text = ds.Tables(0).Rows(0).Item("bat_cnf")
    '        txttaxstl.Text = ds.Tables(0).Rows(0).Item("tax_stl")
    '        txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
    '        If txtbatcnfr.Text = "B" Then
    '            cmbbatch.Enabled = True
    '            cmbbatch.Text = ""
    '        Else
    '            cmbbatch.Enabled = False
    '            cmbbatch.Text = "X"
    '        End If
    '        Me.stk_calc()
    '        Me.dv_calc()
    '        If Val(txtprtcd.Text) <> 0 Or Val(txtitemcd.Text) <> 0 Then
    '            Me.trans_view()
    '        End If
    '    End If
    'End Sub

    'Private Sub cmbproduct_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbproduct.Validating
    '    vdating(cmbproduct, "SELECT it_name FROM item WHERE rec_lock='N' AND it_name= '" & Trim(cmbproduct.Text) & "'", "Please Select a Valid Product Name.")
    'End Sub

    Private Sub cmbproduct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.TextChanged
        Dim ds As DataSet = get_dataset("SELECT item.it_cd, item.descri, item.gp_cd, item.tax_stl, item.ptx_cd, item.mrp, item.pur_rate, item.unt1, item.multi1, item.cl_stk,item.dcl_stk,item.bat_cnf, itgrp.gp_nm, taxper.taxcat,taxper.tax1, taxper.txname FROM item LEFT OUTER JOIN taxper ON item.ptx_cd = taxper.taxcd LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd WHERE item.it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txttaxcd.Text = ds.Tables(0).Rows(0).Item("ptx_cd")
            txtvatper.Text = ds.Tables(0).Rows(0).Item("tax1")
            cmbvat.Text = ds.Tables(0).Rows(0).Item("txname")
            txtrealmrp.Text = Val(ds.Tables(0).Rows(0).Item("mrp"))
            txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("pur_rate"))
            txtsndstk.Text = Val(ds.Tables(0).Rows(0).Item("cl_stk"))
            txtdmgstk.Text = Val(ds.Tables(0).Rows(0).Item("dcl_stk"))
            txtbatcnfr.Text = ds.Tables(0).Rows(0).Item("bat_cnf")
            txttaxstl.Text = ds.Tables(0).Rows(0).Item("tax_stl")
            txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
            Me.stk_calc()
            Me.dv_calc()
            If Val(txtprtcd.Text) <> 0 Or Val(txtitemcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
    End Sub

    'Private Sub cmbbatch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatch.GotFocus
    '    populate(cmbbatch, "SELECT bat_no FROM batno WHERE (rec_lock = 'N') AND (it_cd=" & Val(txtitemcd.Text) & " )ORDER BY bat_no")
    'End Sub

    'Private Sub cmbbatch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatch.LostFocus
    '    cmbbatch.Height = 21
    'End Sub

    'Private Sub cmbbatch_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbatch.Validated
    '    Dim ds As DataSet = get_dataset("SELECT batno.bat_cd, batno.ptx_cd, batno.mrp, batno.pur_rate, batno.cl_stk,batno.dcl_stk, taxper.txname,taxper.taxcat, batno.tax_stl, taxper.tax1 FROM batno LEFT OUTER JOIN taxper ON batno.ptx_cd = taxper.taxcd WHERE batno.bat_no='" & Trim(cmbbatch.Text) & "'")
    '    If ds.Tables(0).Rows.Count <> 0 Then
    '        txtbatcd.Text = ds.Tables(0).Rows(0).Item("bat_cd")
    '        txttaxcd.Text = ds.Tables(0).Rows(0).Item("ptx_cd")
    '        txtvatper.Text = ds.Tables(0).Rows(0).Item("tax1")
    '        cmbvat.Text = ds.Tables(0).Rows(0).Item("txname")
    '        txtmrp.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
    '        txtrate.Text = Format(ds.Tables(0).Rows(0).Item("pur_rate"), "#######0.00")
    '        'lblsound.Text = Format(ds.Tables(0).Rows(0).Item("cl_stk"), "#####0.00")
    '        'lbldmg.Text = Format(ds.Tables(0).Rows(0).Item("dcl_stk"), "#####0.00")
    '        txtsndstk.Text = Val(ds.Tables(0).Rows(0).Item("cl_stk"))
    '        txtdmgstk.Text = Val(ds.Tables(0).Rows(0).Item("dcl_stk"))
    '        txttaxstl.Text = ds.Tables(0).Rows(0).Item("tax_stl")
    '        txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
    '        Me.stk_calc()
    '        Me.dv_calc()
    '    End If
    'End Sub

    'Private Sub cmbbatch_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbbatch.Validating
    '    If Trim(cmbbatch.Text) <> "" Then
    '        If cmbtr.SelectedIndex = 0 Then
    '            Dim ds As DataSet = get_dataset("SELECT bat_no FROM batno WHERE (rec_lock='N') AND (bat_no= '" & Trim(cmbbatch.Text) & "') AND (it_cd =" & Val(txtitemcd.Text) & ") ")
    '            If ds.Tables(0).Rows.Count = 0 Then
    '                cnfr = MessageBox.Show("You Have Given A New Batch Name." & vbCrLf & "Are You Sure to Create The New Batch No.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    '                If cnfr = vbYes Then
    '                    txtbatcreat.Text = "Y"
    '                Else
    '                    txtbatcreat.Text = "N"
    '                    cmbbatch.Text = ""
    '                End If
    '            End If
    '        Else
    '            vdating(cmbbatch, "SELECT bat_no FROM batno WHERE (rec_lock='N') AND (bat_no= '" & Trim(cmbbatch.Text) & "') AND (it_cd =" & Val(txtitemcd.Text) & ") ", "Please Select a Valid Batch.")
    '        End If
    '    End If
    'End Sub

    'Private Sub cmbbatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatch.TextChanged
    '    Dim ds As DataSet = get_dataset("SELECT batno.bat_cd, batno.ptx_cd, batno.mrp, batno.pur_rate, batno.cl_stk,batno.dcl_stk, taxper.txname,taxper.taxcat, batno.tax_stl, taxper.tax1 FROM batno LEFT OUTER JOIN taxper ON batno.ptx_cd = taxper.taxcd WHERE batno.bat_no='" & Trim(cmbbatch.Text) & "'")
    '    If ds.Tables(0).Rows.Count <> 0 Then
    '        txtbatcd.Text = ds.Tables(0).Rows(0).Item("bat_cd")
    '        txttaxcd.Text = ds.Tables(0).Rows(0).Item("ptx_cd")
    '        txtvatper.Text = ds.Tables(0).Rows(0).Item("tax1")
    '        cmbvat.Text = ds.Tables(0).Rows(0).Item("txname")
    '        txtrealmrp.Text = Val(ds.Tables(0).Rows(0).Item("mrp"))
    '        txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("pur_rate"))
    '        'lblsound.Text = Format(ds.Tables(0).Rows(0).Item("cl_stk"), "#####0.00")
    '        'lbldmg.Text = Format(ds.Tables(0).Rows(0).Item("dcl_stk"), "#####0.00")
    '        txtsndstk.Text = Val(ds.Tables(0).Rows(0).Item("cl_stk"))
    '        txtdmgstk.Text = Val(ds.Tables(0).Rows(0).Item("dcl_stk"))
    '        txttaxstl.Text = ds.Tables(0).Rows(0).Item("tax_stl")
    '        txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
    '        Me.stk_calc()
    '        Me.dv_calc()
    '    End If
    'End Sub

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

    'Private Sub cmbunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.GotFocus
    '    populate(cmbunit, "SELECT unt.unt_nm FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitemcd.Text) & ") ORDER BY untlnk.unt_pos")
    'End Sub

    'Private Sub cmbunit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.LostFocus
    '    cmbunit.Height = 21
    'End Sub

    'Private Sub cmbunit_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.Validated
    '    Dim ds As DataSet = get_dataset("SELECT * FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitemcd.Text) & ") AND unt.unt_nm='" & Trim(cmbunit.Text) & "'")
    '    If ds.Tables(0).Rows.Count <> 0 Then
    '        txtuntcd.Text = ds.Tables(0).Rows(0).Item("unt_cd")
    '        txtmulrt.Text = ds.Tables(0).Rows(0).Item("mul_rt")
    '    End If
    '    Me.dv_calc()
    '    Me.stk_calc()
    'End Sub

    'Private Sub cmbunit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.TextChanged
    '    Dim ds As DataSet = get_dataset("SELECT * FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitemcd.Text) & ") AND unt.unt_nm='" & Trim(cmbunit.Text) & "'")
    '    If ds.Tables(0).Rows.Count <> 0 Then
    '        txtuntcd.Text = ds.Tables(0).Rows(0).Item("unt_cd")
    '        txtmulrt.Text = ds.Tables(0).Rows(0).Item("mul_rt")
    '    End If
    '    Me.dv_calc()
    '    Me.stk_calc()
    'End Sub

    'Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
    '    vdating(cmbunit, "SELECT unt.unt_nm FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitemcd.Text) & ") AND unt.unt_nm='" & Trim(cmbunit.Text) & "'", "Please Select An Valid Unit Name.")
    'End Sub
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
            Me.batch_save()
        End If
        sl1 = Val(txtslno.Text)
        dv1.Rows.Add()
        dv1.Rows(sl1 - 1).Cells(0).Value = sl1
        dv1.Rows(sl1 - 1).Cells(1).Value = cmbpr.Text
        dv1.Rows(sl1 - 1).Cells(2).Value = cmbproduct.Text
        dv1.Rows(sl1 - 1).Cells(3).Value = cmbbatch.Text
        dv1.Rows(sl1 - 1).Cells(4).Value = cmbtr.Text
        dv1.Rows(sl1 - 1).Cells(5).Value = cmbunit.Text
        dv1.Rows(sl1 - 1).Cells(6).Value = txtquantity.Text
        dv1.Rows(sl1 - 1).Cells(7).Value = txtfree.Text
        dv1.Rows(sl1 - 1).Cells(8).Value = txtmrp.Text
        dv1.Rows(sl1 - 1).Cells(9).Value = txtrate.Text
        dv1.Rows(sl1 - 1).Cells(10).Value = txtamount.Text
        dv1.Rows(sl1 - 1).Cells(11).Value = txtcoper.Text
        dv1.Rows(sl1 - 1).Cells(12).Value = txtcoamt.Text
        dv1.Rows(sl1 - 1).Cells(13).Value = txttrper.Text
        dv1.Rows(sl1 - 1).Cells(14).Value = txttramt.Text
        dv1.Rows(sl1 - 1).Cells(15).Value = txtmrvalue.Text
        dv1.Rows(sl1 - 1).Cells(16).Value = txttto.Text
        dv1.Rows(sl1 - 1).Cells(17).Value = cmbvat.Text
        dv1.Rows(sl1 - 1).Cells(18).Value = txttaxstl.Text
        dv1.Rows(sl1 - 1).Cells(19).Value = txtvat.Text
        dv1.Rows(sl1 - 1).Cells(20).Value = txtadisc.Text
        dv1.Rows(sl1 - 1).Cells(21).Value = txtacharg.Text
        dv1.Rows(sl1 - 1).Cells(22).Value = txttotal.Text
        dv1.Rows(sl1 - 1).Cells(23).Value = txtitemcd.Text
        dv1.Rows(sl1 - 1).Cells(24).Value = txttaxcd.Text
        dv1.Rows(sl1 - 1).Cells(25).Value = Format(Val(txtexclmrp.Text), "######0.00")
        dv1.Rows(sl1 - 1).Cells(26).Value = txtbatcd.Text
        dv1.Rows(sl1 - 1).Cells(27).Value = txtmulrt.Text
        dv1.Rows(sl1 - 1).Cells(28).Value = txtpchsl.Text
        sl1 += 1
        txtslno.Text = sl1
        'lblpqty.Text = Format(Val(txtquantity.Text), "####0")
        Start1()
        If chksetmrp.Checked = True Then
            mrp = Val(txtmrp.Text) / Val(txtmulrt.Text)
            SQLInsert("UPDATE item SET mrp=" & mrp & " WHERE it_cd=" & Val(txtitemcd.Text) & "")
            SQLInsert("UPDATE batno SET mrp=" & mrp & " WHERE it_cd=" & Val(txtitemcd.Text) & " AND bat_cd=" & Val(txtbatcd.Text) & "")
        End If
        If chksetrate.Checked = True Then
            pur_rt = Val(txtrealrt.Text) / Val(txtmulrt.Text)
            SQLInsert("UPDATE item SET pur_rate=" & pur_rt & " WHERE it_cd=" & Val(txtitemcd.Text) & "")
            SQLInsert("UPDATE batno SET pur_rate=" & pur_rt & " WHERE it_cd=" & Val(txtitemcd.Text) & " AND bat_cd=" & Val(txtbatcd.Text) & "")
        End If
        Close1()
        'Secondary Chalan DV update by billed qty
        For i As Integer = 0 To dvchal1.Rows.Count - 1
            x = dvchal1.Rows(i).Cells(13).Value
            If Val(dvchal1.Rows(i).Cells(13).Value) = Val(txtpchsl.Text) Then
                dvchal1.Rows(i).Cells(7).Value = Val(txtquantity.Text)
                dvchal1.Rows(i).Cells(9).Value = Val(txtfree.Text)
            End If
        Next
        If txtbatcnfr.Text = "S" Then
            Dim ds1 As DataSet = get_dataset("SELECT sl_slno FROM pchal_slno WHERE pch_sl=" & Val(txtpchsl.Text) & " AND it_cd=" & Val(txtitemcd.Text) & " ORDER BY sl_slno")
            If ds1.Tables(0).Rows.Count <> 0 Then
                pqty = Val(txtquantity.Text) + Val(txtfree.Text)
                sl = dvsl1.Rows.Count
                For i As Integer = 0 To pqty - 1
                    dvsl1.Rows.Add()
                    dvsl1.Rows(sl).Cells(0).Value = sl + 1
                    dvsl1.Rows(sl).Cells(1).Value = ds1.Tables(0).Rows(i).Item(0)
                    dvsl1.Rows(sl).Cells(2).Value = txtitemcd.Text
                    dvsl1.Rows(sl).Cells(3).Value = txtitemcd.Text
                    dvsl1.Rows(sl).Cells(4).Value = txtitemcd.Text
                    sl += 1
                Next
            End If



            'serial_panel.Visible = True
            'serial_panel.Size = New Size(371, 292)
            'serial_panel.Location = New Point(561, 84)
            'txtserialno.Focus()
        End If
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
                SQLInsert("INSERT INTO purch1 (pur_no,pur_dt,prt_code,chal_no,chal_dt,inv_no,inv_dt,way_bno,trk_no,pur_type,pur_of," & _
                          "dis_amt,chr_amt,pur_amt,dv_tot,adj_amt,rec_lock,paydt,nb,lr_no,lr_dt,usr_ent,ent_date,usr_mod,mod_date," & _
                          "usedby,way_chr,godsl) VALUES (" & Val(txtscroll.Text) & ",'" & Format(recdt.Value, "dd/MMM/yyyy") & "'," & _
                          Val(txtprtcd.Text) & ",'" & Trim(txtchno.Text) & "','" & Format(chdt.Value, "dd/MMM/yyyy") & "','" & _
                          Trim(txtinvno.Text) & "','" & Format(invdt.Value, "dd/MMM/yyyy") & "'," & Val(txtwbno.Text) & ",'" & _
                          Trim(txtvehno.Text) & "','3','" & vb.Left(cmbfrom.Text, 1) & "'," & _
                          Val(txtdiscamt.Text) & "," & Val(txtchargamt.Text) & "," & Val(txtgrtotal.Text) & "," & Val(lbltotal.Text) & "," & _
                          Val(txtadj.Text) & ",'N','" & Format(paydt.Value, "dd/MMM/yyyy") & "','" & Trim(txtnb.Text) & "','" & _
                          Trim(txtlrno.Text) & "','" & Format(lrdt.Value, "dd/MMM/yyyy") & "'," & Val(usr_sl) & ",'" & _
                          Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N','" & _
                          Trim(txtwaypfx.Text) & "'," & Val(txtgodcd.Text) & ")")
                Me.dv_save()
                SQLInsert("UPDATE party SET cr_amt=cr_amt + " & Val(txtgrtotal.Text) & ",cl_amt=cl_amt + " & Val(txtgrtotal.Text) & " WHERE prt_code=" & Val(txtprtcd.Text) & "")
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                          Format(invdt.Value, "dd/MMM/yyyy") & "',way_bno=" & Val(txtwbno.Text) & ",trk_no='" & Trim(txtvehno.Text) & "',pur_of='" & vb.Left(cmbfrom.Text, 1) & "',dv_tot=" & Val(lbltotal.Text) & ",pur_amt=" & _
                          Val(txtgrtotal.Text) & ",way_chr='" & Trim(txtwaypfx.Text) & "',dis_amt=" & Val(txtdiscamt.Text) & ",chr_amt=" & _
                          Val(txtchargamt.Text) & ",nb='" & Trim(txtnb.Text) & "',paydt='" & Format(paydt.Value, "dd/MMM/yyyy") & "',lr_no='" & _
                          Trim(txtlrno.Text) & "',lr_dt='" & Format(lrdt.Value, "dd/MMM/yyyy") & "',usr_mod=" & Val(usr_sl) & ",mod_date='" & _
                          Format(Now, "dd/MMM/yyyy HH:mm:ss") & "',adj_amt=" & Val(txtadj.Text) & ",godsl=" & Val(txtgodcd.Text) & " WHERE pur_no =" & Val(txtscroll.Text) & "")
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
                trtp = dv1.Rows(i).Cells(4).Value
                unt = dv1.Rows(i).Cells(5).Value
                qty = Val(dv1.Rows(i).Cells(6).Value)
                free = Val(dv1.Rows(i).Cells(7).Value)
                mrp = Val(dv1.Rows(i).Cells(8).Value)
                it_rt = Val(dv1.Rows(i).Cells(9).Value)
                amt = Val(dv1.Rows(i).Cells(10).Value)
                codisper = Val(dv1.Rows(i).Cells(11).Value)
                codisamt = Val(dv1.Rows(i).Cells(12).Value)
                trdisper = Val(dv1.Rows(i).Cells(13).Value)
                trdisamt = Val(dv1.Rows(i).Cells(14).Value)
                mrval = Val(dv1.Rows(i).Cells(15).Value)
                tto = Val(dv1.Rows(i).Cells(16).Value)
                taxcat = dv1.Rows(i).Cells(18).Value
                vatamt = Val(dv1.Rows(i).Cells(19).Value)
                adisc = Val(dv1.Rows(i).Cells(20).Value)
                achrg = Val(dv1.Rows(i).Cells(21).Value)
                total = Val(dv1.Rows(i).Cells(22).Value)
                itcd = Val(dv1.Rows(i).Cells(23).Value)
                taxcd = Val(dv1.Rows(i).Cells(24).Value)
                exmrp = Val(dv1.Rows(i).Cells(25).Value)
                batcd = Val(dv1.Rows(i).Cells(26).Value)
                mulrt = Val(dv1.Rows(i).Cells(27).Value)
                pchsl = Val(dv1.Rows(i).Cells(28).Value)
                mrpamt = Val(exmrp) * (Val(qty) + Val(free))
                Dim ds1 As DataSet = get_dataset("SELECT max(pur_sl) as 'Max' FROM purch2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO purch2 (pur_sl,pur_no,pur_dt,prt_code,it_cd,godsl,bat_cd,pur_rt,pur_qty,it_amt,tto_amt,tax_cd,oth_amt,disc_amt,it_tot," & _
                          "stax,  mrp, ex_mrp, pch_sl, prd_tp, tr_tp, unt, free_qty, mul_rt, disc_rt1, disc_rt2, disc_amt1, disc_amt2," & _
                          "mrp_amt,bit_type,  bdisc_amt) VALUES (" & Val(mxno) & "," & Val(txtscroll.Text) & ",'" & Format(recdt.Value, "dd/MMM/yyyy") & "'," & _
                          Val(txtprtcd.Text) & "," & Val(itcd) & "," & Val(txtgodcd.Text) & "," & Val(batcd) & "," & it_rt & "," & qty & "," & amt & "," & tto & "," & taxcd & "," & _
                          achrg & "," & adisc & "," & total & "," & vatamt & "," & mrp & "," & exmrp & "," & Val(pchsl) & ",'" & vb.Left(prdtp, 1) & "','" & _
                          vb.Left(trtp, 1) & "','" & unt & "'," & free & "," & mulrt & "," & codisper & "," & trdisper & "," & codisamt & "," & trdisamt & "," & _
                          mrval & ",'" & taxcat & "'," & codisamt + trdisamt & ")")
                SQLInsert("UPDATE pchal2 SET bpch_qty = bpch_qty + " & qty & ",bfree_qty = bfree_qty + " & free & ",billed='Y' WHERE pch_sl=" & Val(pchsl) & "")
                'If txtbatcnfr.Text = "S" Then
                Me.srl_save(mxno, itcd, pchsl)
                'End If
                'itqt = (qty * mulrt) + (free * mulrt)
                'stock_IN(itqt, itcd, batcd, vb.Left(prdtp, 1), vb.Left(trtp, 1))
            Next
        End If
    End Sub

    Private Sub srl_save(ByVal pursl As Integer, ByVal it_cd As Integer, ByVal pch_sl As Integer)
        If dvsl1.RowCount <> 0 Then
            For m As Integer = 0 To dvsl1.RowCount - 1
                'srlno = dvsl1.Rows(m).Cells(1).Value
                itcd = Val(dvsl1.Rows(m).Cells(2).Value)
                srlcd = Val(dvsl1.Rows(m).Cells(1).Value)
                If Val(itcd) = Val(it_cd) Then
                    'Dim ds1 As DataSet = get_dataset("SELECT max(sl_slno) as 'Max' FROM mast_slno")
                    'mxno = 1
                    'If ds1.Tables(0).Rows.Count <> 0 Then
                    '    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                    '        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    '    End If
                    'End If
                    'SQLInsert("INSERT INTO mast_slno (sl_slno,it_cd,slno,io_pos,trans) VALUES (" & Val(mxno) & "," & itcd & ",'" & Trim(srlno) & "','I','Y')")
                    SQLInsert("INSERT INTO pur_slno (sl_slno,it_cd,pur_no,pur_sl) VALUES (" & srlcd & "," & itcd & "," & Val(txtscroll.Text) & "," & Val(pursl) & ")")
                    SQLInsert("UPDATE pchal_slno SET pur_no=" & Val(txtscroll.Text) & ",pur_sl=" & Val(pursl) & ",billed='Y' WHERE pch_sl=" & pch_sl & " AND it_cd=" & itcd & "")
                End If
            Next
        End If
    End Sub

    Private Sub batch_save()
        Dim ds As DataSet = get_dataset("SELECT item.tax_stl,item.stx_cd, item.ptx_cd,item.sale_rate1,item.sale_rate2,item.sale_rate3,item.sale_rate4 FROM item WHERE item.it_cd=" & Val(txtitemcd.Text) & "")
        If ds.Tables(0).Rows.Count <> 0 Then
            taxstl = ds.Tables(0).Rows(0).Item(0)
            staxcd = ds.Tables(0).Rows(0).Item(1)
            ptaxcd = ds.Tables(0).Rows(0).Item(2)
            cat1 = ds.Tables(0).Rows(0).Item(3)
            cat2 = ds.Tables(0).Rows(0).Item(4)
            cat3 = ds.Tables(0).Rows(0).Item(5)
            cat4 = ds.Tables(0).Rows(0).Item(6)
            Dim ds1 As DataSet = get_dataset("SELECT max(bat_cd) as 'Max' FROM batno")
            txtbatcd.Text = 1
            If ds1.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                    txtbatcd.Text = ds1.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            If cmbpr.SelectedIndex = 0 Then
                itqt = Val(txtquantity.Text) * Val(txtmulrt.Text) + Val(txtfree.Text) * Val(txtmulrt.Text)
            Else
                itqt = Val(txtquantity.Text) * Val(txtmulrt.Text) + Val(txtfree.Text) * Val(txtmulrt.Text)
            End If
            mrp = Val(txtmrp.Text) / Val(txtmulrt.Text)
            prate = Val(txtrate.Text) / Val(txtmulrt.Text)
            Start1()
            SQLInsert("INSERT INTO batno(bat_cd,bat_no,it_cd,exp_dt,tax_stl,stx_cd,ptx_cd,mrp,pur_rate,stk_rate,sale_rate1,sale_rate2," & _
                      "sale_rate3,sale_rate4,freeqty,freeon,oppur_rate,opsal_rate,opstk_rate,opstk_val,op_stk,rec_stk,iss_stk,cl_stk," & _
                      "dop_stk,drec_stk,diss_stk,dcl_stk,manf_dt,rec_lock,prt_code,pur_dt,inv_no,inv_dt) VALUES (" & Val(txtbatcd.Text) & ",'" & _
                      vb.Right(cmbbatch.Text, 8) & "'," & Val(txtitemcd.Text) & ",'2099-12-01 00:00:00.000','" & txttaxstl.Text & "'," & _
                      Val(staxcd) & "," & Val(ptaxcd) & "," & Val(mrp) & "," & Val(prate) & "," & Val(prate) & "," & Val(cat1) & "," & _
                      Val(cat2) & "," & Val(cat3) & "," & Val(cat4) & ",0,1," & Val(prate) & ",0," & Val(prate) & ",0," & _
                      Val(itqt) & ",0,0,0," & Val(itqt) & ",0,0,0,'2099-12-01 00:00:00.000','N'," & Val(txtprtcd.Text) & ",'" & _
                      Format(invdt.Value, "dd/MMM/yyyy") & "','','" & Format(invdt.Value, "dd/MMM/yyyy") & "')")
            Close1()
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

            'totmrp = Val(txtmrp.Text) * (Val(itqt) + Val(frqt))
            'vatfr = 0
            'If Val(frqt) <> 0 Then
            '    puramt = Format(Val(Val(frqt) * Val(txtrate.Text)), "########0.00")
            '    vatfr = Val((Val(txtvatper.Text) / 100) * Val(puramt))
            'End If
            'txtvat.Text = Format(Val(vatqt) + Val(vatfr), "########0.00")
            'totamt = Val(txttto.Text) + Val(txtvat.Text)
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
            amt = dgv.Rows(i).Cells(10).Value
            codis = dgv.Rows(i).Cells(12).Value
            trdis = dgv.Rows(i).Cells(14).Value
            mrval = dgv.Rows(i).Cells(15).Value
            tto = dgv.Rows(i).Cells(16).Value
            vatamt = dgv.Rows(i).Cells(19).Value
            disc = dgv.Rows(i).Cells(20).Value
            chrg = dgv.Rows(i).Cells(21).Value
            gtamt = dgv.Rows(i).Cells(22).Value
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
        lblsound.Text = Format(Val(txtsndstk.Text / txtmulrt.Text), "#####0")
        lbldmg.Text = Format(Val(txtdmgstk.Text / txtmulrt.Text), "#####0")
        If Val(txtmulrt.Text) <> 1 Then
            sndstk = Int(txtsndstk.Text / txtmulrt.Text)
            dmgstk = Int(txtdmgstk.Text / txtmulrt.Text)
            If txtsndstk.Text Mod txtmulrt.Text <> 0 Then
                lblsound.Text = sndstk & "." & txtsndstk.Text Mod txtmulrt.Text
                lbldmg.Text = dmgstk & "." & txtdmgstk.Text Mod txtmulrt.Text
            End If
        End If
        txtmrp.Text = Format(Val(txtrealmrp.Text * txtmulrt.Text), "#######0.00")
        txtrate.Text = Format(Val(txtrealrt.Text * txtmulrt.Text), "#######0.00")
    End Sub
#End Region

#Region "Data Retrieve"

    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT purch1.pur_no AS 'Scrl', CONVERT(VARCHAR,purch1.pur_dt,103) AS 'Date',purch1.inv_no AS 'Inv.No', purch1.inv_dt AS 'Inv.Date', (CASE WHEN purch1.pur_type='1' THEN 'Cash' WHEN purch1.pur_type='3' THEN 'Credit' END) AS 'Type', party.pname AS 'Name Of the Party', STR(purch1.pur_amt,10,2) AS 'Amount' FROM purch1 LEFT OUTER JOIN party ON purch1.prt_code = party.prt_code WHERE (purch1.pur_type = '3') ORDER BY purch1.pur_dt DESC, purch1.pur_no DESC")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_chal()
        dvchal.Columns.Clear()
        If dvchal1.RowCount <> 0 Then
            dvchal.ColumnCount = 16
            dvchal.Columns(0).Name = "ChNo"
            dvchal.Columns(1).Name = "Date"
            dvchal.Columns(2).Name = "Name Of The Product"
            dvchal.Columns(3).Name = "Batch"
            dvchal.Columns(4).Name = "Type"
            dvchal.Columns(5).Name = "Unit"
            dvchal.Columns(6).Name = "Qty"
            dvchal.Columns(7).Name = "Free"
            dvchal.Columns(8).Name = "MRP"
            dvchal.Columns(9).Name = "Rate"
            dvchal.Columns(10).Name = "mulrt"
            dvchal.Columns(11).Name = "Pchsl"
            dvchal.Columns(12).Name = "Prdtp"
            dvchal.Columns(13).Name = "itcd"
            dvchal.Columns(14).Name = "batcd"
            dvchal.Columns(15).Name = "pchdt"
            dvchal.Columns(0).Width = 38
            dvchal.Columns(1).Width = 76
            dvchal.Columns(2).Width = 197
            dvchal.Columns(3).Width = 124
            dvchal.Columns(4).Width = 77
            dvchal.Columns(5).Width = 53
            dvchal.Columns(6).Width = 67
            dvchal.Columns(7).Width = 58
            dvchal.Columns(8).Width = 80
            dvchal.Columns(9).Width = 78
            dvchal.Columns(10).Visible = False
            dvchal.Columns(11).Visible = False
            dvchal.Columns(12).Visible = False
            dvchal.Columns(13).Visible = False
            dvchal.Columns(14).Visible = False
            dvchal.Columns(15).Visible = False
            rw = 0
            For i As Integer = 0 To dvchal1.Rows.Count - 1
                pqty = Val(dvchal1.Rows(i).Cells(6).Value) - Val(dvchal1.Rows(i).Cells(7).Value)
                bpqty = Val(dvchal1.Rows(i).Cells(7).Value)
                frqty = Val(dvchal1.Rows(i).Cells(8).Value) - Val(dvchal1.Rows(i).Cells(9).Value)
                bfrqty = Val(dvchal1.Rows(i).Cells(9).Value)
                If (pqty + frqty) <> 0 Then
                    dvchal.Rows.Add()
                    dvchal.Rows(rw).Cells(0).Value = dvchal1.Rows(i).Cells(0).Value
                    dvchal.Rows(rw).Cells(1).Value = dvchal1.Rows(i).Cells(1).Value
                    dvchal.Rows(rw).Cells(2).Value = dvchal1.Rows(i).Cells(2).Value
                    dvchal.Rows(rw).Cells(3).Value = dvchal1.Rows(i).Cells(3).Value
                    dvchal.Rows(rw).Cells(4).Value = dvchal1.Rows(i).Cells(4).Value
                    dvchal.Rows(rw).Cells(5).Value = dvchal1.Rows(i).Cells(5).Value
                    dvchal.Rows(rw).Cells(6).Value = Format(pqty, "#######0.00")
                    dvchal.Rows(rw).Cells(7).Value = Format(frqty, "#######0.00")
                    dvchal.Rows(rw).Cells(8).Value = Format(Val(dvchal1.Rows(i).Cells(10).Value), "#######0.00")
                    dvchal.Rows(rw).Cells(9).Value = Format(Val(dvchal1.Rows(i).Cells(11).Value), "#######0.00")
                    dvchal.Rows(rw).Cells(10).Value = dvchal1.Rows(i).Cells(12).Value
                    dvchal.Rows(rw).Cells(11).Value = dvchal1.Rows(i).Cells(13).Value
                    dvchal.Rows(rw).Cells(12).Value = dvchal1.Rows(i).Cells(14).Value
                    dvchal.Rows(rw).Cells(13).Value = dvchal1.Rows(i).Cells(15).Value
                    dvchal.Rows(rw).Cells(14).Value = dvchal1.Rows(i).Cells(16).Value
                    dvchal.Rows(rw).Cells(15).Value = dvchal1.Rows(i).Cells(17).Value
                    rw += 1
                End If
            Next
            dvchal.Visible = True
            dvchal.Size = New Size(935, 230)
            dvchal.Location = Label59.Location
            dvchal.Focus()
        End If
    End Sub

    Private Sub dv_view()
        Dim ds As DataSet = get_dataset("SELECT item.it_name, purch2.*, taxper.txname,batno.bat_no FROM purch2 LEFT OUTER JOIN taxper ON purch2.tax_cd = taxper.taxcd LEFT OUTER JOIN item ON purch2.it_cd = item.it_cd LEFT OUTER JOIN batno ON purch2.bat_cd = batno.bat_cd WHERE purch2.pur_no=" & Val(txtscroll.Text) & "")
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
                If ds.Tables(0).Rows(i).Item("bat_cd") = 0 Then
                    dv1.Rows(rw).Cells(3).Value = "X"
                Else
                    dv1.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("bat_no")
                End If
                If ds.Tables(0).Rows(i).Item("tr_tp") = "1" Then
                    dv1.Rows(rw).Cells(4).Value = "1.Purch."
                Else
                    dv1.Rows(rw).Cells(4).Value = "2.Return."
                End If
                dv1.Rows(rw).Cells(5).Value = ds.Tables(0).Rows(i).Item("unt")
                dv1.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("pur_qty"), "####0.00")
                dv1.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("free_qty"), "####0.00")
                dv1.Rows(rw).Cells(8).Value = Format(ds.Tables(0).Rows(i).Item("mrp"), "######0.00")
                dv1.Rows(rw).Cells(9).Value = Format(ds.Tables(0).Rows(i).Item("pur_rt"), "######0.00")
                dv1.Rows(rw).Cells(10).Value = Format(ds.Tables(0).Rows(i).Item("it_amt"), "######0.00")
                dv1.Rows(rw).Cells(11).Value = Format(ds.Tables(0).Rows(i).Item("disc_rt1"), "######0.00")
                dv1.Rows(rw).Cells(12).Value = Format(ds.Tables(0).Rows(i).Item("disc_amt1"), "######0.00")
                dv1.Rows(rw).Cells(13).Value = Format(ds.Tables(0).Rows(i).Item("disc_rt2"), "######0.00")
                dv1.Rows(rw).Cells(14).Value = Format(ds.Tables(0).Rows(i).Item("disc_amt2"), "######0.00")
                'mrpval = Val(ds.Tables(0).Rows(i).Item("mrp")) * (Val(ds.Tables(0).Rows(i).Item("pur_qty")) + Val(ds.Tables(0).Rows(i).Item("free_qty")))
                dv1.Rows(rw).Cells(15).Value = Format(ds.Tables(0).Rows(i).Item("mrp_amt"), "######0.00")
                dv1.Rows(rw).Cells(16).Value = Format(ds.Tables(0).Rows(i).Item("tto_amt"), "######0.00")
                dv1.Rows(rw).Cells(17).Value = ds.Tables(0).Rows(i).Item("txname")
                dv1.Rows(rw).Cells(18).Value = ds.Tables(0).Rows(i).Item("bit_type")
                dv1.Rows(rw).Cells(19).Value = Format(ds.Tables(0).Rows(i).Item("stax"), "######0.00")
                dv1.Rows(rw).Cells(20).Value = Format(ds.Tables(0).Rows(i).Item("disc_amt"), "######0.00")
                dv1.Rows(rw).Cells(21).Value = Format(ds.Tables(0).Rows(i).Item("oth_amt"), "######0.00")
                dv1.Rows(rw).Cells(22).Value = Format(ds.Tables(0).Rows(i).Item("it_tot"), "######0.00")
                dv1.Rows(rw).Cells(23).Value = ds.Tables(0).Rows(i).Item("it_cd")
                dv1.Rows(rw).Cells(24).Value = ds.Tables(0).Rows(i).Item("tax_cd")
                dv1.Rows(rw).Cells(25).Value = Format(ds.Tables(0).Rows(i).Item("ex_mrp"), "######0.00")
                dv1.Rows(rw).Cells(26).Value = ds.Tables(0).Rows(i).Item("bat_cd")
                dv1.Rows(rw).Cells(27).Value = ds.Tables(0).Rows(i).Item("mul_rt")
                dv1.Rows(rw).Cells(28).Value = ds.Tables(0).Rows(i).Item("pch_sl")
                rw += 1
                'If txtbatcnfr.Text = "S" Then
                pursl = ds.Tables(0).Rows(i).Item("pur_sl")
                Me.srl_view(pursl)
                'End If
            Next
            Me.grandamt(dv1)
            txtslno.Text = rw + 1
        End If
    End Sub

    Private Sub srl_view(ByVal pursl As Integer)
        Dim ds2 As DataSet = get_dataset("SELECT sl_slno,it_cd FROM pur_slno WHERE pur_sl=" & pursl & "")
        If ds2.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                sl = dvsl1.Rows.Count
                slno = ds2.Tables(0).Rows(i).Item("sl_slno")
                itcd = ds2.Tables(0).Rows(i).Item("it_cd")
                dvsl1.Rows.Add()
                dvsl1.Rows(sl).Cells(0).Value = sl + 1
                dvsl1.Rows(sl).Cells(1).Value = slno
                dvsl1.Rows(sl).Cells(2).Value = itcd
                dvsl1.Rows(sl).Cells(3).Value = itcd
            Next
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
            Dim dschal As DataSet = get_dataset("SELECT pchal2.pch_no,CONVERT(VARCHAR,pchal2.pch_dt,3) AS Date, item.it_name, (CASE WHEN pchal2.bat_cd=0 THEN 'X'  WHEN pchal2.bat_cd<>0 THEN batno.bat_no END) AS 'Batch', (CASE WHEN pchal2.pch_tp='1' THEN '1.Purch.' WHEN pchal2.pch_tp='2' THEN '2.Return.' END) AS 'Type',pchal2.unt,pchal2.pch_qty ,pchal2.bpch_qty,pchal2.free_qty, pchal2.bfree_qty,pchal2.mrp,pchal2.pur_rt, pchal2.mul_rt, pchal2.pch_sl, pchal2.prd_tp ,pchal2.it_cd, pchal2.bat_cd,pchal2.pch_dt FROM pchal2 LEFT OUTER JOIN batno ON pchal2.bat_cd = batno.bat_cd LEFT OUTER JOIN item ON pchal2.it_cd = item.it_cd WHERE (pchal2.prt_code = " & Val(txtprtcd.Text) & ") ORDER BY pchal2.pch_dt")
            dvchal1.Columns.Clear()
            If dschal.Tables(0).Rows.Count <> 0 Then
                dvchal1.DataSource = dschal.Tables(0)
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

    Private Sub dvchal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dvchal.KeyDown
        If (e.KeyData = 13) Then
            If dvchal.Rows.Count <> 0 Then
                txtquantity.Focus()
                Me.chal_trans()
            Else
                txtnb.Focus()
            End If
        ElseIf (e.KeyData = 9) Then
            txtnb.Focus()
        End If
        dvchal.Visible = False
    End Sub

    Private Sub chal_trans()
        txtchno.Text = dvchal.SelectedRows(0).Cells(0).Value
        chdt.Value = CDate(dvchal.SelectedRows(0).Cells(15).Value)
        cmbbatch.Text = dvchal.SelectedRows(0).Cells(3).Value
        cmbtr.Text = dvchal.SelectedRows(0).Cells(4).Value
        cmbunit.Text = dvchal.SelectedRows(0).Cells(5).Value
        txtquantity.Text = Val(dvchal.SelectedRows(0).Cells(6).Value)
        txtfree.Text = Val(dvchal.SelectedRows(0).Cells(7).Value)
        txtmrp.Text = dvchal.SelectedRows(0).Cells(8).Value
        txtrate.Text = dvchal.SelectedRows(0).Cells(9).Value
        txtmulrt.Text = dvchal.SelectedRows(0).Cells(10).Value
        txtpchsl.Text = dvchal.SelectedRows(0).Cells(11).Value
        cmbpr.SelectedIndex = Val(dvchal.SelectedRows(0).Cells(12).Value) - 1
        txtitemcd.Text = dvchal.SelectedRows(0).Cells(13).Value
        txtbatcd.Text = dvchal.SelectedRows(0).Cells(14).Value
        cmbproduct.Text = dvchal.SelectedRows(0).Cells(2).Value
    End Sub

    Private Sub dvchal_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvchal.Validated
        'txtquantity.Focus()
        'Me.chal_trans()
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
            SQLInsert("UPDATE party SET cr_amt=cr_amt - " & Val(toamt) & ",cl_amt=cl_amt - " & Val(toamt) & " WHERE prt_code=" & Val(prtcd) & "")
            SQLInsert("DELETE FROM purch1 WHERE pur_no=" & Val(code) & "")
        End If
    End Sub

    'Delete data from Table2/Secondary Table
    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT pur_sl,pur_qty,it_cd,bat_cd,free_qty,pch_sl FROM purch2 WHERE pur_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                pursl = dsdel.Tables(0).Rows(i).Item(0)
                pqty = Val(dsdel.Tables(0).Rows(i).Item(1))
                itcd = dsdel.Tables(0).Rows(i).Item(2)
                batcd = dsdel.Tables(0).Rows(i).Item(3)
                frqt = Val(dsdel.Tables(0).Rows(i).Item(4))
                pch_sl = Val(dsdel.Tables(0).Rows(i).Item(5))
                'itqt = (pqty * mulrt) + (frqt * mulrt)
                'stock_INDEL(itqt, itcd, batcd, prdtp, trtp)
                Dim ds2 As DataSet = get_dataset("SELECT sl_slno FROM pur_slno WHERE pur_sl=" & pursl & "")
                If ds2.Tables(0).Rows.Count <> 0 Then
                    For m As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                        slno = ds2.Tables(0).Rows(m).Item(0)
                        SQLInsert("UPDATE pchal_slno SET pur_no=0,pur_sl=0,billed='N' WHERE sl_slno =" & slno & "")
                        SQLInsert("DELETE FROM pur_slno WHERE sl_slno =" & slno & "")
                    Next
                End If
                SQLInsert("UPDATE pchal2 SET bpch_qty = bpch_qty - (" & pqty & "),bfree_qty = bfree_qty - (" & frqt & "),billed='N' WHERE pch_sl=" & Val(pch_sl) & "")
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
            btnsave.Text = "Edit"
            Me.Text = "Purchase Invoice Modification Screen . . ."
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
        If dv1.RowCount <> 0 Then
            itcd = Val(dv1.SelectedRows(0).Cells(23).Value)
            'Dim rw As DataGridViewRow
            For i As Integer = 0 To dvsl1.Rows.Count - 1
                x = dvsl1.Rows(i).Cells(3).Value
                If Val(dvsl1.Rows(i).Cells(3).Value) = itcd Then
                    rw = dvsl1.Rows(i).Index
                    dvsl1.Rows(i).Cells(3).Value = ""
                End If
            Next
        End If

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
            cmbbatch.Text = ""
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

End Class
