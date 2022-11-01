
Imports vb = Microsoft.VisualBasic
Public Class frmpurchal
    Dim comd As String = "E"
    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point
#Region "Start Up"
    Private Sub frmpurchal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnupchal.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmpurchal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmpurchal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnupchal.Enabled = False
        Me.clr()
        cmbpr.SelectedIndex = 0
        cmbtr.SelectedIndex = 0
        Me.Set_view()
    End Sub

    Private Sub frmpurchal_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Purchase Challan Entry Screen . . ."
        txtslno.Text = "1"
        cmbprt.Text = ""
        txtref.Text = "X"
        txtrealmrp.Text = 0
        txtrealrt.Text = 0
        dvtrans.DataSource = Nothing
        dvsl1.Rows.Clear()
        txtsndstk.Text = 0
        txtdmgstk.Text = 0
        lbldescri.Text = ""
        lblgrp.Text = ""
        lblsnd.Text = "0.00"
        lbldmg.Text = "0.00"
        lbltotamt.Text = "0.00"
        cmbprt.Text = ""
        txtprtcd.Text = 0
        lbladdress.Text = ""
        lblprtbal.Text = "0.00 Cr."
        cmbstore.Text = ""
        txtgodcd.Text = 0
        txtnb.Text = ""
        'Others
        txtordno.Text = ""
        orddt.Value = sys_date
        txtvehno.Text = ""
        txtlrno.Text = ""
        txtwaypfx.Text = ""
        txtwbno.Text = ""
        lrdt.Value = sys_date
        dtchal.Value = sys_date
        dtref.Value = sys_date
        dv1.Rows.Clear()
        If comd = "E" Then
            Me.Text = "Purchase Challan Entry Screen . . ."
            Dim ds As DataSet = get_dataset("SELECT max(pch_no) as 'Max' FROM pchal1")
            txtscrl.Text = 1
            txtscrl.Focus()
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            btnsave.Text = "Save"
        ElseIf comd = "M" Then
            Me.Text = "Purchase Challan Modification Screen . . ."
            txtscrl.Text = ""
            btnsave.Text = "Modify"
        Else
            Me.Text = "Purchase Challan Deletion Screen . . ."
            txtscrl.Text = ""
            btnsave.Text = "Delete"
        End If
        Me.clr1()
        Me.clr2()
        Me.Set_chang()
    End Sub

    Private Sub clr1()
        txttaxstl.Text = "I"
        txttaxcat.Text = "1"
        cmbproduct.Text = ""
        cmbbatch.Text = ""
        txtbatcd.Text = 0
        cmbunit.Text = ""
        txtuntcd.Text = 0
        txtquantity.Text = "0.00"
        txtfree.Text = "0.00"
        txtmrp.Text = "0.00"
        txtrate.Text = "0.00"
        txtmulrt.Text = 1
        txtvatper.Text = 0
        txtbatcreat.Text = "N"
    End Sub

    Private Sub clr2()
        serial_panel.Visible = False
        dvsl.Rows.Clear()
        lblsqty.Text = "00"
        lblpqty.Text = "00"
        txtsl.Text = "1"
        txtserialno.Text = ""
        txtsl_slno.Text = 0
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.dv_disp()
    End Sub
#End Region
#Region "Enter/Leave"
    Private Sub txtscrl_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtslno.Enter, txtscrl.Enter, txtref.Enter, txtquantity.Enter, txtmrp.Enter, cmbunit.Enter, cmbprt.Enter, cmbproduct.Enter, cmbpr.Enter, txtnb.Enter, txtserialno.Enter, txtlrno.Enter, txtwaypfx.Enter, txtwbno.Enter, txtordno.Enter, txtvehno.Enter, cmbstore.Enter, cmbbatch.Enter, txtfree.Enter, cmbtr.Enter, txtrate.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub txtscrl_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtslno.Leave, txtscrl.Leave, txtref.Leave, txtquantity.Leave, txtmrp.Leave, cmbunit.Leave, cmbprt.Leave, cmbproduct.Leave, cmbpr.Leave, txtnb.Leave, txtserialno.Leave, txtlrno.Leave, txtwaypfx.Leave, txtwbno.Leave, txtordno.Leave, txtvehno.Leave, cmbstore.Leave, cmbbatch.Leave, txtfree.Leave, cmbtr.Leave, txtrate.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
        ' sender.text = UCase(sender.text)
    End Sub
#End Region

    Private Sub txtquantity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquantity.GotFocus, txtfree.GotFocus, txtmrp.GotFocus, txtrate.GotFocus
        If Val(sender.Text) = 0 Then
            sender.Text = ""
        End If
    End Sub

    Private Sub txtquantity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquantity.LostFocus, txtfree.LostFocus, txtmrp.LostFocus, txtrate.LostFocus
        sender.Text = Format(Val(sender.Text), "########0.00")
    End Sub

#Region "Mouse Enter/Leave"
    Private Sub sender_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnxt.MouseEnter, btnsave.MouseEnter, btnset.MouseEnter, btnswap.MouseEnter, btnref.MouseEnter, btnview.MouseEnter, btnothers.MouseEnter, btnexit.MouseEnter, btnabort.MouseEnter, btnfresh1.MouseEnter, btnok.MouseEnter, btnslabort.MouseEnter, btnslclr.MouseEnter, btnslcont.MouseEnter, btnslnxt.MouseEnter, btnsetabrt.MouseEnter, btnsetaply.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnxt.MouseLeave, btnsave.MouseLeave, btnset.MouseLeave, btnswap.MouseLeave, btnref.MouseLeave, btnview.MouseLeave, btnothers.MouseLeave, btnexit.MouseLeave, btnabort.MouseLeave, btnfresh1.MouseLeave, btnok.MouseLeave, btnslabort.MouseLeave, btnslclr.MouseLeave, btnslcont.MouseLeave, btnslnxt.MouseLeave, btnsetabrt.MouseLeave, btnsetaply.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub chksetmep_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetrate.MouseEnter, chksetmrp.MouseEnter, chksetdisc.MouseEnter, chksetcalcrt.MouseEnter
        sender.forecolor = Color.Blue
    End Sub

    Private Sub chksetmep_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetrate.MouseLeave, chksetmrp.MouseLeave, chksetdisc.MouseLeave, chksetcalcrt.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "KeyPress"

    Private Sub txtscrl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtscrl.KeyPress
        key(dtchal, e)
        SPKey(e)
    End Sub

    Private Sub dtchal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtchal.KeyPress
        key(cmbprt, e)
    End Sub

    Private Sub cmbprt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbprt.KeyPress
        key(txtref, e)
        SPKey(e)
    End Sub

    Private Sub txtref_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtref.KeyPress
        key(dtref, e)
        SPKey(e)
    End Sub

    Private Sub dtref_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtref.KeyPress
        key(cmbstore, e)
    End Sub

    Private Sub cmbstore_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstore.KeyPress
        key(cmbproduct, e)
    End Sub

    Private Sub cmbproduct_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbproduct.KeyPress
        If cmbproduct.Text = "" Then
            key(txtnb, e)
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

    Private Sub cmbunit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunit.KeyPress
        key(txtquantity, e)
        SPKey(e)
    End Sub

    Private Sub txtquantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtquantity.KeyPress
        key(txtfree, e)
        NUM(e)
    End Sub

    Private Sub txtfree_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfree.KeyPress
        If txtmrp.Enabled = True Then
            key(txtmrp, e)
        Else
            key(btnnxt, e)
        End If
        NUM(e)
    End Sub

    Private Sub txtmrp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmrp.KeyPress
        key(txtrate, e)
        NUM(e)
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        key(btnnxt, e)
        NUM(e)
    End Sub

    Private Sub txtnb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnb.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub

    'Others
    Private Sub txtordno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtordno.KeyPress
        key(orddt, e)
        SPKey(e)
    End Sub

    Private Sub orddt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles orddt.KeyPress
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

    Private Sub txtserialno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtserialno.KeyPress
        If Trim(txtserialno.Text) = "" Then
            key(btnslcont, e)
        Else
            key(btnslnxt, e)
        End If
        SPKey(e)
    End Sub
#End Region

#Region "Combo Box"

    Private Sub cmbprt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprt.GotFocus
        lbladdress.Text = ""
        cmbprt.Height = 100
        populate(cmbprt, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbprt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprt.LostFocus
        cmbprt.Height = 21
    End Sub

    Private Sub cmbprt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprt.Validated
        Dim ds As DataSet = get_dataset("SELECT prt_code,add1,cl_amt FROM party WHERE pname='" & Trim(cmbprt.Text) & "'")
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

    Private Sub cmbprt_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbprt.Validating
        vdating(cmbprt, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' AND pname='" & Trim(cmbprt.Text) & "'", "Please Select A Valid Party Head Of A/c Name.")
    End Sub


    Private Sub cmbproduct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.LostFocus
        cmbproduct.Height = 21
    End Sub

    Private Sub cmbproduct_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.GotFocus
        txtitcd.Text = 0
        lbldescri.Text = ""
        lblgrp.Text = ""
        populate(cmbproduct, "SELECT it_name FROM item WHERE (rec_lock = 'N') ORDER BY it_name")
        cmbproduct.Height = 100
    End Sub

    Private Sub cmbproduct_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbproduct.Validated
        Dim ds As DataSet = get_dataset("SELECT item.it_cd,item.bat_cnf, item.descri, item.ptx_cd, item.mrp, item.pur_rate, item.unt1,item.unt2,item.unt3,item.unt4, item.cl_stk,item.dcl_stk, itgrp.gp_nm, item.multi1, taxper.txname,taxper.taxcat, item.tax_stl, taxper.tax1 FROM item LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN taxper ON item.ptx_cd = taxper.taxcd WHERE item.it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtitcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            cmbunit.Text = ds.Tables(0).Rows(0).Item("unt1")
            'txtmulrt.Text = ds.Tables(0).Rows(0).Item("multi1")
            lbldescri.Text = Trim(ds.Tables(0).Rows(0).Item("descri"))
            lblgrp.Text = Trim(ds.Tables(0).Rows(0).Item("gp_nm"))
            txtrealmrp.Text = Val(ds.Tables(0).Rows(0).Item("mrp"))
            txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("pur_rate"))
            txtsndstk.Text = Val(ds.Tables(0).Rows(0).Item("cl_stk"))
            txtdmgstk.Text = Val(ds.Tables(0).Rows(0).Item("dcl_stk"))
            txtbatcnfr.Text = ds.Tables(0).Rows(0).Item("bat_cnf")
            txtvatper.Text = ds.Tables(0).Rows(0).Item("tax1")
            txttaxstl.Text = ds.Tables(0).Rows(0).Item("tax_stl")
            txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
            If txtbatcnfr.Text = "B" Then
                cmbbatch.Enabled = True
                cmbbatch.Text = ""
            Else
                cmbbatch.Enabled = False
                cmbbatch.Text = "X"
            End If
            Me.stk_calc()
            '  Me.dv_calc()
            If Val(txtprtcd.Text) <> 0 Or Val(txtitcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
    End Sub

    Private Sub cmbproduct_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbproduct.TextChanged
        Dim ds As DataSet = get_dataset("SELECT item.it_cd,item.bat_cnf, item.descri, item.ptx_cd, item.mrp, item.pur_rate, item.unt1,item.unt2,item.unt3,item.unt4, item.cl_stk,item.dcl_stk, itgrp.gp_nm, item.multi1, taxper.txname,taxper.taxcat, item.tax_stl, taxper.tax1 FROM item LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN taxper ON item.ptx_cd = taxper.taxcd WHERE item.it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtitcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            cmbunit.Text = ds.Tables(0).Rows(0).Item("unt1")
            'txtmulrt.Text = ds.Tables(0).Rows(0).Item("multi1")
            lbldescri.Text = Trim(ds.Tables(0).Rows(0).Item("descri"))
            lblgrp.Text = Trim(ds.Tables(0).Rows(0).Item("gp_nm"))
            txtrealmrp.Text = Val(ds.Tables(0).Rows(0).Item("mrp"))
            txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("pur_rate"))
            txtsndstk.Text = Val(ds.Tables(0).Rows(0).Item("cl_stk"))
            txtdmgstk.Text = Val(ds.Tables(0).Rows(0).Item("dcl_stk"))
            txtbatcnfr.Text = ds.Tables(0).Rows(0).Item("bat_cnf")
            txtvatper.Text = ds.Tables(0).Rows(0).Item("tax1")
            txttaxstl.Text = ds.Tables(0).Rows(0).Item("tax_stl")
            txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
            If txtbatcnfr.Text = "B" Then
                cmbbatch.Enabled = True
                cmbbatch.Text = ""
            Else
                cmbbatch.Enabled = False
                cmbbatch.Text = "X"
            End If
            Me.stk_calc()
            '  Me.dv_calc()
            If Val(txtprtcd.Text) <> 0 Or Val(txtitcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
    End Sub

    Private Sub cmbproduct_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbproduct.Validating
        vdating(cmbproduct, "SELECT it_name FROM item WHERE it_name = '" & Trim(cmbproduct.Text) & "'", "Please Select a Valid Product Name.")
    End Sub

    Private Sub cmbbatch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatch.GotFocus
        populate(cmbbatch, "SELECT bat_no FROM batno WHERE (rec_lock = 'N') AND (it_cd=" & Val(txtitcd.Text) & " ) ORDER BY bat_no")
    End Sub

    Private Sub cmbbatch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatch.LostFocus
        cmbbatch.Height = 21
    End Sub

    Private Sub cmbbatch_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbatch.Validated
        Dim ds As DataSet = get_dataset("SELECT batno.bat_cd, batno.ptx_cd, batno.mrp, batno.pur_rate, batno.cl_stk,batno.dcl_stk, taxper.txname,taxper.taxcat, batno.tax_stl, taxper.tax1 FROM batno LEFT OUTER JOIN taxper ON batno.ptx_cd = taxper.taxcd WHERE batno.bat_no='" & Trim(cmbbatch.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtbatcd.Text = ds.Tables(0).Rows(0).Item("bat_cd")
            txtmrp.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            txtrate.Text = Format(ds.Tables(0).Rows(0).Item("pur_rate"), "#######0.00")
            txtsndstk.Text = Val(ds.Tables(0).Rows(0).Item("cl_stk"))
            txtdmgstk.Text = Val(ds.Tables(0).Rows(0).Item("dcl_stk"))
            txtvatper.Text = ds.Tables(0).Rows(0).Item("tax1")
            txttaxstl.Text = ds.Tables(0).Rows(0).Item("tax_stl")
            txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
            Me.stk_calc()
        End If
    End Sub

    Private Sub cmbbatch_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbbatch.Validating
        If Trim(cmbbatch.Text) <> "" Then
            If cmbtr.SelectedIndex = 0 Then
                Dim ds As DataSet = get_dataset("SELECT bat_no FROM batno WHERE (rec_lock='N') AND (bat_no= '" & Trim(cmbbatch.Text) & "') AND (it_cd =" & Val(txtitcd.Text) & ") ")
                If ds.Tables(0).Rows.Count = 0 Then
                    cnfr = MessageBox.Show("You Have Given A New Batch Name." & vbCrLf & "Are You Sure to Create The New Batch No.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If cnfr = vbYes Then
                        txtbatcreat.Text = "Y"
                    Else
                        txtbatcreat.Text = "N"
                        cmbbatch.Text = ""
                    End If
                End If
            Else
                vdating(cmbbatch, "SELECT bat_no FROM batno WHERE (rec_lock='N') AND (bat_no= '" & Trim(cmbbatch.Text) & "') AND (it_cd =" & Val(txtitcd.Text) & ") ", "Please Select a Valid Batch.")
            End If
        End If
    End Sub

    Private Sub cmbbatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatch.TextChanged
        Dim ds As DataSet = get_dataset("SELECT batno.bat_cd, batno.ptx_cd, batno.mrp, batno.pur_rate, batno.cl_stk,batno.dcl_stk, taxper.txname,taxper.taxcat, batno.tax_stl, taxper.tax1 FROM batno LEFT OUTER JOIN taxper ON batno.ptx_cd = taxper.taxcd WHERE batno.bat_no='" & Trim(cmbbatch.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtbatcd.Text = ds.Tables(0).Rows(0).Item("bat_cd")
            txtrealmrp.Text = Val(ds.Tables(0).Rows(0).Item("mrp"))
            txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("pur_rate"))
            txtsndstk.Text = Val(ds.Tables(0).Rows(0).Item("cl_stk"))
            txtdmgstk.Text = Val(ds.Tables(0).Rows(0).Item("dcl_stk"))
            txtvatper.Text = ds.Tables(0).Rows(0).Item("tax1")
            txttaxstl.Text = ds.Tables(0).Rows(0).Item("tax_stl")
            txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
            Me.stk_calc()
        End If
    End Sub

    Private Sub cmbunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.GotFocus
        populate(cmbunit, "SELECT unt.unt_nm FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitcd.Text) & ") ORDER BY untlnk.unt_pos")
    End Sub

    Private Sub cmbunit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.LostFocus
        cmbunit.Height = 21
    End Sub

    Private Sub cmbunit_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.Validated
        Dim ds As DataSet = get_dataset("SELECT * FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitcd.Text) & ") AND unt.unt_nm='" & Trim(cmbunit.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtuntcd.Text = ds.Tables(0).Rows(0).Item("unt_cd")
            txtmulrt.Text = ds.Tables(0).Rows(0).Item("mul_rt")
        End If
        Me.stk_calc()
    End Sub

    Private Sub cmbunit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.TextChanged
        Dim ds As DataSet = get_dataset("SELECT * FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitcd.Text) & ") AND unt.unt_nm='" & Trim(cmbunit.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtuntcd.Text = ds.Tables(0).Rows(0).Item("unt_cd")
            txtmulrt.Text = ds.Tables(0).Rows(0).Item("mul_rt")
        End If
        Me.stk_calc()
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        vdating(cmbunit, "SELECT unt.unt_nm FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitcd.Text) & ") AND unt.unt_nm='" & Trim(cmbunit.Text) & "'", "Please Select An Valid Unit Name.")
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

#End Region

#Region "Button"

    Private Sub btnsetabrt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsetabrt.Click
        setting_panel.Visible = False
    End Sub

    Private Sub btnsetaply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsetaply.Click
        Start1()
        SQLInsert("UPDATE setting_pchal SET req_mrp=" & IIf(chksetmrp.Checked, 1, 0) & ",req_rate=" & _
                  IIf(chksetrate.Checked, 1, 0) & ",req_mrprt=" & IIf(chksetdisc.Checked, 1, 0) & ",rate_calc=" & _
                  IIf(chksetcalcrt.Checked, 1, 0) & " WHERE slno=1")
        Close1()
        setting_panel.Visible = False
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
    End Sub

    Private Sub btninter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnswap.Click
        If comd = "E" Then
            comd = "M"
        ElseIf comd = "M" Then
            comd = "D"
        Else
            comd = "E"
        End If
        Me.clr()
    End Sub

    Private Sub btnothers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnothers.Click
        other_panel.Size = New Size(410, 134)
        other_panel.Location = New Point(5, 145)
        other_panel.Visible = True
        txtordno.Focus()
    End Sub

    Private Sub btnabort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnabort.Click
        txtordno.Text = ""
        orddt.Value = sys_date
        txtvehno.Text = ""
        txtlrno.Text = ""
        txtwaypfx.Text = ""
        txtwbno.Text = ""
        lrdt.Value = sys_date
        other_panel.Visible = False
    End Sub

    Private Sub btnfresh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfresh1.Click
        txtordno.Text = ""
        orddt.Value = sys_date
        txtvehno.Text = ""
        txtlrno.Text = ""
        txtwaypfx.Text = ""
        txtwbno.Text = ""
        lrdt.Value = sys_date
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        other_panel.Visible = False
    End Sub

    Private Sub btnset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnset.Click
        setting_panel.Size = New Size(334, 134)
        setting_panel.Location = New Point(510, 145)
        setting_panel.Visible = True
    End Sub

    Private Sub btnslabort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnslabort.Click
        If dvsl.Rows.Count <> 0 Then
            If Val(lblpqty.Text) <> Val(lblsqty.Text) Then
                MessageBox.Show("Sorry The Serial Quantity And The Sales Quantity Must Be Equal.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtserialno.Focus()
                Exit Sub
            End If
        End If
        Me.clr2()
        cmbproduct.Focus()
    End Sub

    Private Sub btnslnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnslnxt.Click
        If txtserialno.Text = "" Then
            MessageBox.Show("Please Enter A Valid Product Serial Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtserialno.Focus()
            Exit Sub
        End If
        If Val(lblpqty.Text) <> 0 Then
            If Val(lblpqty.Text) = Val(lblsqty.Text) Then
                MessageBox.Show("The Serial Quantity And The Sales Quantity Are Equal.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnslcont.Focus()
                Exit Sub
            End If
        End If
        If dvsl.Rows.Count <> 0 Then
            For i As Integer = 0 To dvsl.RowCount - 1
                x = dvsl.Rows(i).Cells(1).Value
                If Trim(txtserialno.Text) = x Then
                    MessageBox.Show("Sorry The Serial No Not be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtserialno.Focus()
                    Exit Sub
                End If
            Next
        End If
        sl1 = Val(txtsl.Text)
        dvsl.Rows.Add()
        dvsl.Rows(sl1 - 1).Cells(0).Value = sl1
        dvsl.Rows(sl1 - 1).Cells(1).Value = txtserialno.Text
        dvsl.Rows(sl1 - 1).Cells(2).Value = txtslqty.Text
        sl1 += 1
        txtsl.Text = sl1
        lblsqty.Text = Val(lblsqty.Text) + 1
        txtserialno.Text = ""
        txtserialno.Focus()
    End Sub

    Private Sub btnslclr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnslclr.Click
        dvsl.Rows.Clear()
        txtsl.Text = "1"
    End Sub

    Private Sub btnslcont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnslcont.Click
        If Val(lblpqty.Text) <> Val(lblsqty.Text) Then
            MessageBox.Show("Sorry The Serial Quantity And The Purchase Quantity Must Be Equal.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtserialno.Focus()
            Exit Sub
        End If
        sl = dvsl1.Rows.Count
        For i As Integer = 0 To dvsl.Rows.Count - 1
            dvsl1.Rows.Add()
            dvsl1.Rows(sl).Cells(0).Value = sl + 1
            dvsl1.Rows(sl).Cells(1).Value = dvsl.Rows(i).Cells(1).Value
            dvsl1.Rows(sl).Cells(2).Value = dvsl.Rows(i).Cells(2).Value
            dvsl1.Rows(sl).Cells(3).Value = txtitcd.Text
            sl += 1
        Next
        Me.clr2()
        cmbproduct.Focus()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Val(txtscrl.Text) = 0 Then
            MessageBox.Show("Sorry The Scroll No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtscrl.Focus()
            Exit Sub
        End If
        If Trim(cmbprt.Text) = "" Or Val(txtprtcd.Text) = 0 Then
            MessageBox.Show("Sorry The Party Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbprt.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count = 0 Then
            MessageBox.Show("Please Enter At least one item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If
        Me.chal_save()
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
        If cmbtr.SelectedIndex = 1 Then
            If Val(lblsnd.Text) < (Val(txtquantity.Text * (-1)) + Val(txtfree.Text) * (-1)) Then
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
        dv1.Rows(sl1 - 1).Cells(5).Value = Trim(cmbunit.Text)
        dv1.Rows(sl1 - 1).Cells(6).Value = txtquantity.Text
        dv1.Rows(sl1 - 1).Cells(7).Value = txtfree.Text
        dv1.Rows(sl1 - 1).Cells(8).Value = txtmrp.Text
        dv1.Rows(sl1 - 1).Cells(9).Value = txtrate.Text
        dv1.Rows(sl1 - 1).Cells(10).Value = txtitcd.Text
        dv1.Rows(sl1 - 1).Cells(11).Value = txtbatcd.Text
        dv1.Rows(sl1 - 1).Cells(12).Value = txtmulrt.Text
        sl1 += 1
        txtslno.Text = sl1
        lblpqty.Text = Format(Val(txtquantity.Text) + Val(txtfree.Text), "####0")
        Start1()
        If chksetmrp.Checked = True Then
            mrp = Val(txtmrp.Text) / Val(txtmulrt.Text)
            SQLInsert("UPDATE item SET mrp=" & mrp & " WHERE it_cd=" & Val(txtitcd.Text) & "")
            SQLInsert("UPDATE batno SET mrp=" & mrp & " WHERE it_cd=" & Val(txtitcd.Text) & " AND bat_cd=" & Val(txtbatcd.Text) & "")
        End If
        If chksetrate.Checked = True Then
            pur_rt = Val(txtrealrt.Text) / Val(txtmulrt.Text)
            SQLInsert("UPDATE item SET pur_rate=" & pur_rt & " WHERE it_cd=" & Val(txtitcd.Text) & "")
            SQLInsert("UPDATE batno SET pur_rate=" & pur_rt & " WHERE it_cd=" & Val(txtitcd.Text) & " AND bat_cd=" & Val(txtbatcd.Text) & "")
        End If
        Close1()
        cmbproduct.Focus()
        Me.grandamt(dv1)
        If txtbatcnfr.Text = "S" Then
            serial_panel.Size = New Size(371, 292)
            serial_panel.Location = New Point(461, 154)
            serial_panel.Visible = True
            txtserialno.Focus()
        End If
        Me.clr1()
    End Sub
#End Region
#Region "Data save"
    Private Sub chal_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(pch_no) as 'Max' FROM pchal1")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO pchal1(pch_no,pch_dt,prt_code,ref_no,ref_dt,way_bno,way_chr,trk_no,lr_no,lr_dt,pch_amt,billed," & _
                          "usedby,rec_lock,nb,ord_no,ord_dt,god_sl,usr_ent,ent_date,usr_mod,mod_date) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Format(dtchal.Value, "dd/MMM/yyyy") & "'," & Val(txtprtcd.Text) & ",'" & Trim(txtref.Text) & "','" & _
                          Format(dtref.Value, "dd/MMM/yyyy") & "','" & Trim(txtwbno.Text) & "','" & Trim(txtwaypfx.Text) & "','" & _
                          Trim(txtvehno.Text) & "','" & Trim(txtlrno.Text) & "','" & Format(lrdt.Value, "dd/MMM/yyyy") & "'," & _
                          Val(lbltotamt.Text) & ",'N','N','N','" & Trim(txtnb.Text) & "','" & Trim(txtordno.Text) & "','" & _
                          Format(orddt.Value, "dd/MMM/yyyy") & "'," & Val(txtgodcd.Text) & "," & Val(usr_sl) & ",'" & _
                          Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "')")
                Me.dv_save()
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'cnfr = MessageBox.Show("Are You Sure The Printer is Ready To Print The Bill.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If cnfr = vbYes Then
                '    Call order_print(Val(txtordno.Text))
                'End If
                Me.clr()
            End If
        ElseIf comd = "M" Then
            If usr_tp = "O" Then
                MessageBox.Show("You Are Not Authorised to Modify The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Start1()
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT pch_no FROM pchal1 WHERE pch_no=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE pchal1 SET pch_dt='" & Format(dtchal.Value, "dd/MMM/yyyy") & "', prt_code=" & _
                              Val(txtprtcd.Text) & ", ref_no='" & Trim(txtref.Text) & "', ref_dt='" & _
                              Format(dtref.Value, "dd/MMM/yyyy") & "', way_bno='" & Trim(txtwbno.Text) & "', way_chr='" & _
                              Trim(txtwaypfx.Text) & "', trk_no='" & Trim(txtvehno.Text) & "', lr_no='" & Trim(txtlrno.Text) & "', lr_dt='" & _
                              Format(lrdt.Value, "dd/MMM/yyyy") & "', pch_amt=" & Val(lbltotamt.Text) & ", nb='" & _
                              Trim(txtnb.Text) & "', ord_no='" & Trim(txtordno.Text) & "', ord_dt='" & _
                              Format(orddt.Value, "dd/MMM/yyyy") & "', god_sl=" & Val(txtgodcd.Text) & ", usr_mod=" & _
                              Val(usr_sl) & ", mod_date='" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "' WHERE pch_no =" & Val(txtscrl.Text) & "")
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
                Call del1(txtscrl.Text)
                Call del2(txtscrl.Text)
                txtscrl.Focus()
            End If
        End If
        Close1()
    End Sub

    Private Sub dv_save()
        If dv1.RowCount <> 0 Then
            If comd = "M" Then
                Call del2(txtscrl.Text)
            End If
            For i As Integer = 0 To dv1.RowCount - 1
                prdtp = Trim(dv1.Rows(i).Cells(1).Value)
                trtp = Trim(dv1.Rows(i).Cells(4).Value)
                unt = dv1.Rows(i).Cells(5).Value
                qty = Val(dv1.Rows(i).Cells(6).Value)
                free = Val(dv1.Rows(i).Cells(7).Value)
                mrp = Val(dv1.Rows(i).Cells(8).Value)
                prate = Val(dv1.Rows(i).Cells(9).Value)
                amt = qty * prate
                itcd = Val(dv1.Rows(i).Cells(10).Value)
                batcd = Val(dv1.Rows(i).Cells(11).Value)
                mulrt = Val(dv1.Rows(i).Cells(12).Value)
                itamt = prate * qty
                Dim ds1 As DataSet = get_dataset("SELECT max(pch_sl) as 'Max' FROM pchal2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO pchal2(pch_sl,pch_no,pch_dt,pch_tp,prd_tp,prt_code,it_cd,bat_cd,pur_rt,pch_qty,free_qty,bpch_qty,bfree_qty," & _
                          "unt,billed,mrp,excl_mrp,it_amt,mul_rt,rep_qty,brep_qty) VALUES (" & Val(mxno) & "," & Val(txtscrl.Text) & ",'" & _
                          Format(dtchal.Value, "dd/MMM/yyyy") & "','" & vb.Left(trtp, 1) & "','" & _
                          vb.Left(prdtp, 1) & "'," & Val(txtprtcd.Text) & "," & Val(itcd) & "," & Val(batcd) & "," & _
                          prate & "," & qty & "," & free & ",0,0,'" & unt & "','N'," & mrp & ",0," & Val(itamt) & "," & mulrt & ",0,0)")
                'If txtbatcnfr.Text = "S" Then
                Me.srl_save(mxno, itcd)
                'End If
                itqt = (qty * mulrt) + (free * mulrt)
                stock_IN(itqt, itcd, batcd, vb.Left(prdtp, 1), vb.Left(trtp, 1))
            Next
        End If
    End Sub

    Private Sub srl_save(ByVal pchsl As Integer, ByVal it_cd As Integer)
        If dvsl1.RowCount <> 0 Then
            For m As Integer = 0 To dvsl1.RowCount - 1
                srlno = dvsl1.Rows(m).Cells(1).Value
                itcd = Val(dvsl1.Rows(m).Cells(3).Value)
                If Val(itcd) = Val(it_cd) Then
                    Dim ds1 As DataSet = get_dataset("SELECT max(sl_slno) as 'Max' FROM mast_slno")
                    mxno = 1
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                            mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                        End If
                    End If
                    SQLInsert("INSERT INTO mast_slno (sl_slno,it_cd,slno,io_pos,trans) VALUES (" & Val(mxno) & "," & itcd & ",'" & Trim(srlno) & "','I','Y')")
                    SQLInsert("INSERT INTO pchal_slno (sl_slno,it_cd,pch_no,pch_sl,billed,pur_no,pur_sl) VALUES (" & Val(mxno) & "," & itcd & "," & Val(txtscrl.Text) & "," & Val(pchsl) & ",'N',0,0)")
                End If
            Next
        End If
    End Sub

    Private Sub batch_save()
        Dim ds As DataSet = get_dataset("SELECT item.tax_stl,item.stx_cd,item.ptx_cd,item.sale_rate1,item.sale_rate2,item.sale_rate3,item.sale_rate4 FROM item WHERE item.it_cd=" & Val(txtitcd.Text) & "")
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
                      vb.Right(cmbbatch.Text, 8) & "'," & Val(txtitcd.Text) & ",'2099-12-01 00:00:00.000','" & txttaxstl.Text & "'," & _
                      Val(staxcd) & "," & Val(ptaxcd) & "," & Val(mrp) & "," & Val(prate) & "," & Val(prate) & "," & Val(cat1) & "," & _
                      Val(cat2) & "," & Val(cat3) & "," & Val(cat4) & ",0,1," & Val(prate) & ",0," & Val(prate) & ",0," & Val(itqt) & ",0,0,0," & _
                      Val(itqt) & ",0,0,0,'2099-12-01 00:00:00.000','N'," & Val(txtprtcd.Text) & ",'" & _
                      Format(dtchal.Value, "dd/MMM/yyyy") & "','','" & Format(dtchal.Value, "dd/MMM/yyyy") & "')")
            Close1()
        End If
    End Sub
#End Region

#Region "Calculation"
    Private Sub grandamt(ByVal dgv As DataGridView)
        tmrpamt = 0
        tittot = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            qty = Val(dgv.Rows(i).Cells(6).Value)
            itfr = Val(dgv.Rows(i).Cells(7).Value)
            mrp = Val(dgv.Rows(i).Cells(8).Value)
            itrt = Val(dgv.Rows(i).Cells(9).Value)
            mrpamt = (qty + itfr) * mrp
            ittot = qty * itrt
            'Totalling(Section)
            tmrpamt = tmrpamt + Val(mrpamt)
            tittot = tittot + Val(ittot)
        Next
        lblmrpvl.Text = Format(tmrpamt, "#######0.00")
        lbltotamt.Text = Format(tittot, "#######0.00")
    End Sub

    Private Sub stk_calc()
        lblsndunt.Text = cmbunit.Text
        lbldmgunt.Text = cmbunit.Text
        lblsnd.Text = Format(Val(txtsndstk.Text / txtmulrt.Text), "#####0")
        lbldmg.Text = Format(Val(txtdmgstk.Text / txtmulrt.Text), "#####0")
        If Val(txtmulrt.Text) <> 1 Then
            sndstk = Int(txtsndstk.Text / txtmulrt.Text)
            dmgstk = Int(txtdmgstk.Text / txtmulrt.Text)
            If txtsndstk.Text Mod txtmulrt.Text <> 0 Then
                lblsnd.Text = sndstk & "." & txtsndstk.Text Mod txtmulrt.Text
                lbldmg.Text = dmgstk & "." & txtdmgstk.Text Mod txtmulrt.Text
            End If
        End If
        txtmrp.Text = Format(Val(txtrealmrp.Text * txtmulrt.Text), "#######0.00")
        txtrate.Text = Format(Val(txtrealrt.Text * txtmulrt.Text), "#######0.00")
    End Sub
#End Region

#Region "Data Retrieve"
    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT pchal1.pch_no AS 'Chal.No', pchal1.pch_dt AS 'Challan Dt', party.pname AS 'Paty Name', pchal1.ref_no AS 'Ref No', pchal1.ref_dt AS 'Ref Dt', pchal1.billed AS 'Billed' FROM pchal1 LEFT OUTER JOIN party ON pchal1.prt_code = party.prt_code ")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            'dv.Columns(4).Visible = False
            'dv.Columns(5).Visible = False
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_view()
        Dim ds As DataSet = get_dataset("SELECT pchal2.*, item.it_name,batno.bat_no FROM pchal2 LEFT OUTER JOIN batno ON pchal2.bat_cd = batno.bat_cd LEFT OUTER JOIN item ON pchal2.it_cd = item.it_cd WHERE pchal2.pch_no=" & Val(txtscrl.Text) & "")
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
                If ds.Tables(0).Rows(i).Item("pch_tp") = "1" Then
                    dv1.Rows(rw).Cells(4).Value = "1.Purch."
                Else
                    dv1.Rows(rw).Cells(4).Value = "2.Return."
                End If
                dv1.Rows(rw).Cells(5).Value = ds.Tables(0).Rows(i).Item("unt")
                If chkbilled.Checked = False Then
                    dv1.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("pch_qty"), "####0.00")
                    dv1.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("free_qty"), "####0.00")
                Else
                    dv1.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("bpch_qty"), "####0.00")
                    dv1.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("bfree_qty"), "####0.00")
                End If
                dv1.Rows(rw).Cells(8).Value = Format(ds.Tables(0).Rows(i).Item("mrp"), "######0.00")
                dv1.Rows(rw).Cells(9).Value = Format(ds.Tables(0).Rows(i).Item("pur_rt"), "######0.00")
                dv1.Rows(rw).Cells(10).Value = ds.Tables(0).Rows(i).Item("it_cd")
                dv1.Rows(rw).Cells(11).Value = ds.Tables(0).Rows(i).Item("bat_cd")
                dv1.Rows(rw).Cells(12).Value = ds.Tables(0).Rows(i).Item("mul_rt")
                rw += 1
                'If txtbatcnfr.Text = "S" Then
                pchsl = ds.Tables(0).Rows(i).Item("pch_sl")
                Me.srl_view(pchsl)
                'End If
            Next
            Me.grandamt(dv1)
            txtslno.Text = rw + 1
        End If
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Dim dsedit As DataSet = get_dataset("SELECT pchal1.*, party.pname,party.cl_amt,party.add1,godown.godnm FROM pchal1  LEFT OUTER JOIN godown ON pchal1.god_sl = godown.godsl LEFT OUTER JOIN party ON pchal1.prt_code = party.prt_code WHERE pchal1.pch_no=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = dsedit.Tables(0).Rows(0).Item("pch_no")
            cmbprt.Text = dsedit.Tables(0).Rows(0).Item("pname")
            lbladdress.Text = dsedit.Tables(0).Rows(0).Item("add1")
            txtprtcd.Text = dsedit.Tables(0).Rows(0).Item("prt_code")
            cmbstore.Text = dsedit.Tables(0).Rows(0).Item("godnm")
            txtgodcd.Text = dsedit.Tables(0).Rows(0).Item("god_sl")
            dtchal.Value = dsedit.Tables(0).Rows(0).Item("pch_dt")
            txtref.Text = dsedit.Tables(0).Rows(0).Item("ref_no")
            dtref.Value = dsedit.Tables(0).Rows(0).Item("ref_dt")
            txtnb.Text = dsedit.Tables(0).Rows(0).Item("nb")
            'Others
            txtordno.Text = dsedit.Tables(0).Rows(0).Item("ord_no")
            orddt.Value = dsedit.Tables(0).Rows(0).Item("ord_dt")
            txtvehno.Text = dsedit.Tables(0).Rows(0).Item("trk_no")
            txtlrno.Text = dsedit.Tables(0).Rows(0).Item("lr_no")
            lrdt.Value = dsedit.Tables(0).Rows(0).Item("lr_dt")
            txtwaypfx.Text = dsedit.Tables(0).Rows(0).Item("way_chr")
            txtwbno.Text = dsedit.Tables(0).Rows(0).Item("way_bno")
            clamt = Val(dsedit.Tables(0).Rows(0).Item("cl_amt"))
            If clamt < 0 Then
                lblprtbal.Text = Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
            Else
                lblprtbal.Text = Format(clamt, "#######0.00") & " " & "Cr."
            End If
            Me.dv_view()
        End If
    End Sub

    Private Sub srl_view(ByVal pchsl As Integer)
        Dim ds2 As DataSet = get_dataset("SELECT mast_slno.slno, pchal_slno.* FROM pchal_slno LEFT OUTER JOIN mast_slno ON pchal_slno.sl_slno = mast_slno.sl_slno WHERE pchal_slno.pch_sl=" & pchsl & "")
        If ds2.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                sl = dvsl1.Rows.Count
                slno = ds2.Tables(0).Rows(i).Item("slno")
                itcd = ds2.Tables(0).Rows(i).Item("it_cd")
                dvsl1.Rows.Add()
                dvsl1.Rows(sl).Cells(0).Value = sl + 1
                dvsl1.Rows(sl).Cells(1).Value = slno
                dvsl1.Rows(sl).Cells(2).Value = 1
                dvsl1.Rows(sl).Cells(3).Value = itcd
            Next
        End If
    End Sub

    Private Sub trans_view()
        dvtrans.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        ds = get_dataset("SELECT TOP (3) convert(varchar,pch_dt,3) 'Date',STR(mrp,10,2) 'MRP', STR(pur_rt,10,2) 'Rate' FROM pchal2 WHERE (it_cd = " & Val(txtitcd.Text) & ") AND (prt_code = " & Val(txtprtcd.Text) & ") ORDER BY pch_dt DESC")
        If ds.Tables(0).Rows.Count <> 0 Then
            dvtrans.DataSource = ds.Tables(0)
        End If
        Close1()
    End Sub
#End Region

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
        Me.Text = "Purchase Challan Entry Screen . . ."
        dv.Visible = False
        txtscrl.Focus()
    End Sub


    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Purchase Challan Modify Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
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

    Private Sub txtscrl_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtscrl.Validated
        If comd <> "E" Then
            If txtscrl.Text <> "" Then
                Dim ds As DataSet = get_dataset("SELECT pch_no FROM pchal1 WHERE pch_no=" & Val(txtscrl.Text) & " ")
                If ds.Tables(0).Rows.Count <> 0 Then
                    Me.dv_edit(txtscrl.Text)
                Else
                    MessageBox.Show("Please Select a Valid Challan No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtscrl.Focus()
                End If
            End If
        End If
    End Sub

    'Delete data from Table1/Primary Table
    Private Sub del1(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT pch_no FROM pchal1 WHERE pch_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            SQLInsert("DELETE FROM pchal1 WHERE pch_no=" & Val(code) & "")
        End If
    End Sub

    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT pch_sl,pch_qty,it_cd,bat_cd,free_qty,mul_rt,prd_tp,pch_tp FROM pchal2 WHERE pch_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                pchsl = dsdel.Tables(0).Rows(i).Item(0)
                pqty = Val(dsdel.Tables(0).Rows(i).Item(1))
                itcd = dsdel.Tables(0).Rows(i).Item(2)
                batcd = dsdel.Tables(0).Rows(i).Item(3)
                frqt = Val(dsdel.Tables(0).Rows(i).Item(4))
                mulrt = Val(dsdel.Tables(0).Rows(i).Item(5))
                prdtp = Val(dsdel.Tables(0).Rows(i).Item(6))
                trtp = Val(dsdel.Tables(0).Rows(i).Item(7))
                itqt = (pqty * mulrt) + (frqt * mulrt)
                stock_INDEL(itqt, itcd, batcd, prdtp, trtp)
                Dim ds2 As DataSet = get_dataset("SELECT sl_slno FROM pchal_slno WHERE pch_sl=" & pchsl & "")
                If ds2.Tables(0).Rows.Count <> 0 Then
                    For m As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                        slno = ds2.Tables(0).Rows(m).Item(0)
                        SQLInsert("DELETE FROM mast_slno WHERE sl_slno =" & slno & "")
                        SQLInsert("DELETE FROM pchal_slno WHERE sl_slno =" & slno & "")
                    Next
                End If
                SQLInsert("DELETE FROM pchal2 WHERE pch_sl=" & Val(pchsl) & "")
            Next
        End If
    End Sub

    Private Sub cmnu1del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1del.Click
        If dv1.RowCount <> 0 Then
            itcd = Val(dv1.SelectedRows(0).Cells(10).Value)
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

    Private Sub cmnu2del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenu2del.Click
        For Each row As DataGridViewRow In dvsl.SelectedRows
            dvsl.Rows.Remove(row)
        Next
        sl = 1
        lblsqty.Text = 0
        For i As Integer = 0 To dvsl.Rows.Count - 1
            dvsl.Rows(i).Cells(0).Value = i + 1
            sl += 1
            lblsqty.Text = Val(lblsqty.Text) + 1
        Next
        txtsl.Text = sl
    End Sub

    Private Sub txtscrl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscrl.GotFocus
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
        ' Me.dv_calc()
    End Sub

    Private Sub txtquantity_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquantity.Validated, txtfree.Validated
        If cmbtr.SelectedIndex = 1 Then
            If Val(sender.Text) > 0 Then
                sender.Text = Format(Val(sender.Text) * (-1), "#######0.00")
            End If
        End If
        ' Me.dv_calc()
    End Sub


    Private Sub chksetdisc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetdisc.CheckedChanged
        Me.Set_chang()
    End Sub

    Private Sub chksetsel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetsel.CheckedChanged
        If chksetsel.Checked = True Then
            chksetrate.Checked = True
            chksetmrp.Checked = True
            chksetdisc.Checked = True
            chksetcalcrt.Checked = True
        Else
            chksetrate.Checked = False
            chksetmrp.Checked = False
            chksetdisc.Checked = False
            chksetcalcrt.Checked = False
        End If
    End Sub

    Private Sub Set_view()
        chksetrate.Checked = False
        chksetmrp.Checked = False
        chksetdisc.Checked = False
        chksetcalcrt.Checked = False
        Dim ds As DataSet = get_dataset("SELECT * FROM setting_pchal WHERE slno=1")
        If ds.Tables(0).Rows.Count <> 0 Then
            If ds.Tables(0).Rows(0).Item("req_mrp") = 1 Then
                chksetmrp.Checked = True
            End If
            If ds.Tables(0).Rows(0).Item("req_rate") = 1 Then
                chksetrate.Checked = True
            End If
            If ds.Tables(0).Rows(0).Item("req_mrprt") = 1 Then
                chksetdisc.Checked = True
            End If
            If ds.Tables(0).Rows(0).Item("rate_calc") = 1 Then
                chksetcalcrt.Checked = True
            End If
        End If
    End Sub

    Private Sub Set_chang()
        If chksetdisc.Checked = True Then
            txtmrp.Enabled = True
            txtrate.Enabled = True
        Else
            txtmrp.Enabled = False
            txtrate.Enabled = False
        End If
    End Sub

    Private Sub txtrate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrate.Validated
        txtrealrt.Text = txtrate.Text
        If chksetcalcrt.Checked = True Then
            purrt = Val(txtrate.Text)
            purrt = Val(purrt / (100 + Val(txtvatper.Text)) * 100)
            txtrate.Text = Format(Val(purrt), "########0.00")
        End If
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

    Private Sub serial_panel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles serial_panel.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll
    End Sub

    Private Sub serial_panel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles serial_panel.MouseMove
        If allowCoolMove = True Then
            serial_panel.Location = New Point(serial_panel.Location.X + e.X - myCoolPoint.X, serial_panel.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub serial_panel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles serial_panel.MouseUp
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

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub
End Class