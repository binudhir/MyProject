Imports vb = Microsoft.VisualBasic
Public Class frmsales
    Dim comd As String = "E"
    Dim item_type As String = "1"
    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point
#Region "Start Up"
    Private Sub frmsales_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnusales.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmsales_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmsales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Width = Screen.PrimaryScreen.Bounds.Width
        'Me.Height = Screen.PrimaryScreen.Bounds.Height
        'Me.Dock = DockStyle.Fill
        MDI.mnusales.Enabled = False
        Me.clr()
        cmbbilltp.SelectedIndex = 1
        cmbpr.SelectedIndex = 0
        cmbtr.SelectedIndex = 0
        Me.Set_view()
    End Sub

    Private Sub frmsales_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        lblamount.Text = "0.00"
        lblcodisc.Text = "0.00"
        lbltrdisc.Text = "0.00"
        lblmrpval.Text = "0.00"
        lbltto.Text = "0.00"
        lblcgsttot.Text = "0.00"
        lblsgsttot.Text = "0.00"
        lbladisc.Text = "0.00"
        lblachrg.Text = "0.00"
        lbltotal.Text = "0.00"
        lbldescri.Text = ""
        lblgrp.Text = ""
        lblsound.Text = "0.00"
        lbldmg.Text = "0.00"
        lblpurrt.Text = "0.00"
        cmbstaf.Text = ""
        txtstafcd.Text = 0
        txtchno.Text = "0"
        txtpfx.Text = "AA"
        txtrefno.Text = "X"
        txtrealmrp.Text = 0
        txtrealrt.Text = 0
        txttaxstl.Text = "I"
        txttaxcat.Text = "1"
        dvtrans.DataSource = Nothing
        dvpur.DataSource = Nothing
        dvsl1.Rows.Clear()
        cmbproduct.Text = ""
        cmbbatch.Text = ""
        cmbunit.Text = ""
        txtinvno.Text = ""
        txtslno.Text = "1"
        txtnb.Text = ""
        txtsndstk.Text = 0
        txtdmgstk.Text = 0
        txtchargamt.Text = "0.00"
        txtdiscamt.Text = "0.00"
        txtadj.Text = "0.00"
        txtgrtotal.Text = "0.00"
        cmbparty.Text = ""
        cmbstore.Text = ""
        chdt.Value = sys_date
        paydt.Value = sys_date
        invdt.Value = sys_date
        dv1.Rows.Clear()
        'Others
        txtordno.Text = ""
        orddt.Value = sys_date
        cmbdrvr.Text = ""
        txtdrvcd.Text = 0
        txtchno.Text = ""
        txtvehno.Text = ""
        txtlrno.Text = ""
        txtwaypfx.Text = ""
        txtwbno.Text = ""
        chdt.Value = sys_date
        lrdt.Value = sys_date
        If comd = "E" Then
            Me.Text = "Cash / Credit Sales Entry Screen...."
            Dim ds As DataSet = get_dataset("SELECT max(bill_no) as 'Max' FROM csale1")
            txtscroll.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            Me.rintin_bill()
            btnsave.Text = "Save"
            cmbparty.Focus()
        ElseIf comd = "M" Then
            Me.Text = "Cash / Credit Sales Modification Screen...."
            txtscroll.Text = ""
            txtinvno.Text = ""
            btnsave.Text = "Modify"
        Else
            Me.Text = "Cash / Credit Sales Deletion Screen...."
            txtscroll.Text = ""
            txtinvno.Text = ""
            btnsave.Text = "Delete"
        End If
        Me.prtclr()
        Me.clr1()
        Me.clr2()
        Me.Set_chang()
    End Sub

    Private Sub prtclr()
        txtprtcd.Text = 0
        txtinout.Text = "I"
        lbltrlmt.Text = "0.00 Cr."
        lblmarket.Text = ""
        lblregdno.Text = ""
        lblinvtp.Text = "Retail Invoice"
        txtmob.Text = ""
        txtadd.Text = ""
        txtbillnm.Text = ""
        lbladdress.Text = ""
        lblprtbal.Text = "0.00 Cr."
        prtbal = lblprtbal.Text
    End Sub

    Private Sub clr1()
        item_type = "1"
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
        txtcgst.Text = "0.00"
        txtsgst.Text = "0.00"
        txtadisc.Text = "0.00"
        txtacharg.Text = "0.00"
        txttotal.Text = "0.00"
        txttaxcd.Text = 0
        cmbcgst.Text = ""
        cmbsgst.Text = ""
        txttaxper1.Text = 0
        txtmulrt.Text = 1
    End Sub

    Private Sub clr2()
        serial_panel.Visible = False
        dvsl.Rows.Clear()
        lblsqty.Text = "00"
        lblpqty.Text = "00"
        txtsl.Text = "1"
        cmbserialno.Text = ""
        txtsl_slno.Text = 0
    End Sub

    Private Sub rintin_bill()
        Dim ds As DataSet
        If vb.Left(lblinvtp.Text, 1) = "R" Then
            ds = get_dataset("SELECT max(rin_bno) as 'Max' FROM rinbill WHERE bill_pfx='" & Trim(txtpfx.Text) & "'")
        Else
            ds = get_dataset("SELECT max(tin_bno) as 'Max' FROM tinbill WHERE bill_pfx='" & Trim(txtpfx.Text) & "'")
        End If
        txtinvno.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtinvno.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
    End Sub


    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.dv_disp()
    End Sub
#End Region
#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscroll.Enter, txtslno.Enter, txtquantity.Enter, txtfree.Enter, txtmrp.Enter, txtprtcd.Enter, txtrate.Enter, txtamount.Enter, txtcoper.Enter, txtcoamt.Enter, txttrper.Enter, txttramt.Enter, txtmrvalue.Enter, txttto.Enter, txtcgst.Enter, txtsgst.Enter, txtadisc.Enter, txtacharg.Enter, txttotal.Enter, txtnb.Enter, txtchargamt.Enter, txtadisc.Enter, cmbparty.Enter, cmbstore.Enter, cmbproduct.Enter, cmbpr.Enter, cmbbilltp.Enter, cmbtr.Enter, cmbcgst.Enter, cmbsgst.Enter, paydt.Enter, invdt.Enter, txtinvno.Enter, txtvehno.Enter, txtlrno.Enter, txtwaypfx.Enter, txtwbno.Enter, cmbbatch.Enter, cmbunit.Enter, txtdiscamt.Enter, txttaxstl.Enter, txtmob.Enter, txtadd.Enter, txtbillnm.Enter, cmbstaf.Enter, txtchno.Enter, txtpfx.Enter, txtrefno.Enter, cmbserialno.Enter, txtordno.Enter, cmbdrvr.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscroll.Leave, txtslno.Leave, txtquantity.Leave, txtfree.Leave, txtmrp.Leave, txtprtcd.Leave, txtrate.Leave, txtamount.Leave, txtcoper.Leave, txtcoamt.Leave, txttrper.Leave, txttramt.Leave, txtmrvalue.Leave, txttto.Leave, txtcgst.Leave, txtsgst.Leave, txtadisc.Leave, txtacharg.Leave, txttotal.Leave, txtnb.Leave, txtchargamt.Leave, txtadisc.Leave, cmbparty.Leave, cmbstore.Leave, cmbproduct.Leave, cmbpr.Leave, cmbbilltp.Leave, cmbtr.Leave, cmbcgst.Leave, cmbsgst.Leave, paydt.Leave, invdt.Leave, txtinvno.Leave, txtvehno.Leave, txtlrno.Leave, txtwaypfx.Leave, txtwbno.Leave, cmbbatch.Leave, cmbunit.Leave, txtdiscamt.Leave, txttaxstl.Leave, txtmob.Leave, txtadd.Leave, txtbillnm.Leave, cmbstaf.Leave, txtchno.Leave, txtpfx.Leave, txtrefno.Leave, cmbserialno.Leave, txtordno.Leave, cmbdrvr.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub
#End Region

#Region "Mouse Enter/Leave"

    Private Sub sender_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnxt.MouseEnter, btnsave.MouseEnter, btnset.MouseEnter, btninter.MouseEnter, btnref.MouseEnter, btnprint.MouseEnter, btnview.MouseEnter, btnothers.MouseEnter, btnexit.MouseEnter, btnabort.MouseEnter, btnfresh1.MouseEnter, btnok.MouseEnter, btnslabort.MouseEnter, btnslclr.MouseEnter, btnslcont.MouseEnter, btnslnxt.MouseEnter, btnsetabrt.MouseEnter, btnsetaply.MouseEnter, btnestimate.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnxt.MouseLeave, btnsave.MouseLeave, btnset.MouseLeave, btninter.MouseLeave, btnref.MouseLeave, btnprint.MouseLeave, btnview.MouseLeave, btnothers.MouseLeave, btnexit.MouseLeave, btnabort.MouseLeave, btnfresh1.MouseLeave, btnok.MouseLeave, btnslabort.MouseLeave, btnslclr.MouseLeave, btnslcont.MouseLeave, btnslnxt.MouseLeave, btnsetabrt.MouseLeave, btnsetaply.MouseLeave, btnestimate.MouseLeave
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
        key(cmbbilltp, e)
        NUM(e)
    End Sub

    Private Sub cmbpurtype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbilltp.KeyPress
        key(txtinvno, e)
    End Sub

    Private Sub txtpfx_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpfx.KeyPress
        key(txtinvno, e)
        SPKey(e)
    End Sub

    Private Sub txtinvno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinvno.KeyPress
        key(invdt, e)
        SPKey(e)
    End Sub

    Private Sub invdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles invdt.KeyPress
        key(cmbparty, e)
    End Sub

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        If txtchno.Enabled = True Then
            key(txtchno, e)
        Else
            key(txtrefno, e)
        End If
        SPKey(e)
    End Sub

    Private Sub txtchalno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtchno.KeyPress
        key(chdt, e)
        NUM(e)
    End Sub

    Private Sub chaldt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chdt.KeyPress
        key(txtrefno, e)
    End Sub

    Private Sub txtrefno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrefno.KeyPress
        key(paydt, e)
        SPKey(e)
    End Sub

    Private Sub paydt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles paydt.KeyPress
        key(cmbstaf, e)
    End Sub

    Private Sub cmbstaf_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstaf.KeyPress
        key(cmbstore, e)
        SPKey(e)
    End Sub

    Private Sub cmbstore_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstore.KeyPress
        If Trim(cmbparty.Text) = "" Then
            key(txtbillnm, e)
        Else
            key(cmbproduct, e)
        End If
        SPKey(e)
    End Sub

    Private Sub txtbillnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbillnm.KeyPress
        key(txtmob, e)
        SPKey(e)
    End Sub

    Private Sub txtmob_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmob.KeyPress
        key(txtadd, e)
        NUM(e)
    End Sub

    Private Sub txtadd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd.KeyPress
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
        ElseIf cmbcgst.Enabled = True Then
            key(cmbcgst, e)
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
            If cmbcgst.Enabled = True Then
                key(cmbcgst, e)
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
        If cmbcgst.Enabled = True Then
            If cmbcgst.Enabled = True Then
                key(cmbcgst, e)
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

    Private Sub cmbcgst_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcgst.KeyPress
        key(cmbsgst, e)
        SPKey(e)
    End Sub

    Private Sub txtcgst_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcgst.KeyPress
        key(cmbsgst, e)
        NUM1(e)
    End Sub

    Private Sub cmbsgst_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbsgst.KeyPress
        If txtadisc.Enabled = True Then
            key(txtadisc, e)
        Else
            key(btnnxt, e)
        End If
        SPKey(e)
    End Sub

    Private Sub txtsgst_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsgst.KeyPress
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
    Private Sub txtordno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtordno.KeyPress
        key(orddt, e)
        SPKey(e)
    End Sub

    Private Sub orddt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles orddt.KeyPress
        key(cmbdrvr, e)
    End Sub

    Private Sub cmbdrvr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdrvr.KeyPress
        key(txtvehno, e)
        SPKey(e)
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

    Private Sub cmbserialno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbserialno.KeyPress
        If Trim(cmbserialno.Text) = "" Then
            key(btnslcont, e)
        Else
            key(btnslnxt, e)
        End If
        SPKey(e)
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

    Private Sub txtbillnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbillnm.LostFocus
        If Trim(txtbillnm.Text) = "" Then
            txtbillnm.Text = "Cash Sales"
        End If
    End Sub

    Private Sub txtrefno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrefno.LostFocus
        If Trim(txtrefno.Text) = "" Then
            txtrefno.Text = "X"
        End If
    End Sub


    Private Sub txtpfx_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpfx.Validated
        Me.rintin_bill()
    End Sub

#Region "Combo Box"
    Private Sub cmbparty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.GotFocus
        Me.prtclr()
        populate(cmbparty, "SELECT pname FROM party WHERE prt_type='B' AND rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.LostFocus
        cmbparty.Height = 21
    End Sub

    Private Sub cmbparty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.Validated
        If Trim(cmbparty.Text) <> "" Then
            vdated(txtprtcd, "SELECT prt_code FROM party WHERE pname='" & Trim(cmbparty.Text) & "'")
            Me.party_view()
            txtinout.Enabled = False
        Else
            lblinvtp.Text = "Retail Invoice"
            txtbillnm.Text = "Cash Sales."
            txtmob.Text = ""
            txtadd.Text = ""
            txtinout.Text = "I"
            txtinout.Enabled = True
        End If
        Me.rintin_bill()
    End Sub

    Private Sub cmbparty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbparty.Validating
        vdating(cmbparty, "SELECT pname FROM party WHERE prt_type='B' AND rec_lock='N' AND pname='" & Trim(cmbparty.Text) & "'", "Please Select A Valid Party Name.")
    End Sub

    Private Sub cmbproduct_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.GotFocus
        Me.clr1()
        lbldescri.Text = ""
        lblgrp.Text = ""
        populate(cmbproduct, "SELECT it_name FROM item WHERE (rec_lock = 'N') AND (prd_tp='1') ORDER BY it_name")
    End Sub

    Private Sub cmbproduct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.LostFocus
        cmbproduct.Height = 21
    End Sub

    Private Sub cmbproduct_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbproduct.Validated
        Dim ds As DataSet = get_dataset("SELECT item.it_cd FROM item WHERE it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtitemcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            Me.item_view()
            Me.stk_calc()
            Me.dv_calc()
            If Val(txtprtcd.Text) <> 0 Or Val(txtitemcd.Text) <> 0 Then
                Me.trans_view()
                Me.purch_view()
            End If
        End If
    End Sub

    Private Sub cmbproduct_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbproduct.Validating
        vdating(cmbproduct, "SELECT it_name FROM item WHERE rec_lock='N' AND it_name= '" & Trim(cmbproduct.Text) & "' AND (prd_tp='1')", "Please Select a Valid Product Name.")
    End Sub

    Private Sub cmbproduct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.TextChanged
        Dim ds As DataSet = get_dataset("SELECT item.it_cd FROM item WHERE it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtitemcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            Me.item_view()
            Me.stk_calc()
            Me.dv_calc()
            If Val(txtprtcd.Text) <> 0 Or Val(txtitemcd.Text) <> 0 Then
                Me.trans_view()
                Me.purch_view()
            End If
        End If
    End Sub

    Private Sub cmbbatch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatch.GotFocus
        populate(cmbbatch, "SELECT bat_no FROM batno WHERE (rec_lock = 'N') AND (it_cd=" & Val(txtitemcd.Text) & " )ORDER BY bat_no")
    End Sub

    Private Sub cmbbatch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatch.LostFocus
        cmbbatch.Height = 21
    End Sub

    Private Sub cmbbatch_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbatch.Validated
        Dim ds As DataSet = get_dataset("SELECT batno.bat_cd, batno.ptx_cd, batno.mrp, batno.pur_rate,batno.sale_rate1,batno.sale_rate2,batno.sale_rate3,batno.sale_rate4, batno.cl_stk,batno.dcl_stk, taxper.txname,taxper.taxcat, batno.tax_stl, taxper.tax1 FROM batno LEFT OUTER JOIN taxper ON batno.ptx_cd = taxper.taxcd WHERE batno.bat_no='" & Trim(cmbbatch.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtbatcd.Text = ds.Tables(0).Rows(0).Item("bat_cd")
            txttaxcd.Text = ds.Tables(0).Rows(0).Item("ptx_cd")
            txttaxper1.Text = ds.Tables(0).Rows(0).Item("tax1")
            cmbcgst.Text = ds.Tables(0).Rows(0).Item("txname")
            cmbsgst.Text = "0"
            If txtinout.Text = "I" Then
                cmbcgst.Text = Val(ds.Tables(0).Rows(0).Item("tax1")) / 2
                cmbsgst.Text = Val(ds.Tables(0).Rows(0).Item("tax1")) / 2
            End If
            txtmrp.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            txtrealmrp.Text = Val(ds.Tables(0).Rows(0).Item("mrp"))
            lblpurrt.Text = Format(ds.Tables(0).Rows(0).Item("pur_rate"), "######0.00")
            If Val(txtprtcat.Text) = 1 Then
                txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("sale_rate1"))
            ElseIf Val(txtprtcat.Text) = 2 Then
                txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("sale_rate2"))
            ElseIf Val(txtprtcat.Text) = 3 Then
                txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("sale_rate3"))
            ElseIf Val(txtprtcat.Text) = 4 Then
                txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("sale_rate4"))
            End If
            txtsndstk.Text = Val(ds.Tables(0).Rows(0).Item("cl_stk"))
            txtdmgstk.Text = Val(ds.Tables(0).Rows(0).Item("dcl_stk"))
            txttaxstl.Text = ds.Tables(0).Rows(0).Item("tax_stl")
            txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
            Me.stk_calc()
            Me.dv_calc()
        End If
    End Sub

    Private Sub cmbbatch_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbbatch.Validating
        vdating(cmbbatch, "SELECT bat_no FROM batno WHERE (rec_lock='N') AND (bat_no= '" & Trim(cmbbatch.Text) & "') AND (it_cd =" & Val(txtitemcd.Text) & ") ", "Please Select a Valid Batch.")
    End Sub

    Private Sub cmbbatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatch.TextChanged
        Dim ds As DataSet = get_dataset("SELECT batno.bat_cd, batno.ptx_cd, batno.mrp, batno.pur_rate,batno.sale_rate1,batno.sale_rate2,batno.sale_rate3,batno.sale_rate4, batno.cl_stk,batno.dcl_stk, taxper.txname,taxper.taxcat, batno.tax_stl, taxper.tax1 FROM batno LEFT OUTER JOIN taxper ON batno.ptx_cd = taxper.taxcd WHERE batno.bat_no='" & Trim(cmbbatch.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtbatcd.Text = ds.Tables(0).Rows(0).Item("bat_cd")
            txttaxcd.Text = ds.Tables(0).Rows(0).Item("ptx_cd")
            txttaxper1.Text = ds.Tables(0).Rows(0).Item("tax1")
            cmbcgst.Text = ds.Tables(0).Rows(0).Item("txname")
            cmbsgst.Text = "0"
            If txtinout.Text = "I" Then
                cmbcgst.Text = Val(ds.Tables(0).Rows(0).Item("tax1")) / 2
                cmbsgst.Text = Val(ds.Tables(0).Rows(0).Item("tax1")) / 2
            End If
            txtrealmrp.Text = Val(ds.Tables(0).Rows(0).Item("mrp"))
            txtrealmrp.Text = Val(ds.Tables(0).Rows(0).Item("mrp"))
            lblpurrt.Text = Format(ds.Tables(0).Rows(0).Item("pur_rate"), "######0.00")
            If Val(txtprtcat.Text) = 1 Then
                txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("sale_rate1"))
            ElseIf Val(txtprtcat.Text) = 2 Then
                txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("sale_rate2"))
            ElseIf Val(txtprtcat.Text) = 3 Then
                txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("sale_rate3"))
            ElseIf Val(txtprtcat.Text) = 4 Then
                txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("sale_rate4"))
            End If
            'lblsound.Text = Format(ds.Tables(0).Rows(0).Item("cl_stk"), "#####0.00")
            'lbldmg.Text = Format(ds.Tables(0).Rows(0).Item("dcl_stk"), "#####0.00")
            txtsndstk.Text = Val(ds.Tables(0).Rows(0).Item("cl_stk"))
            txtdmgstk.Text = Val(ds.Tables(0).Rows(0).Item("dcl_stk"))
            txttaxstl.Text = ds.Tables(0).Rows(0).Item("tax_stl")
            txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
            Me.stk_calc()
            Me.dv_calc()
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

    Private Sub cmbcgst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcgst.GotFocus, cmbsgst.GotFocus
        txtcgst.Text = "0.00"
        txtsgst.Text = "0.00"
        txttaxper1.Text = 0
        populate(sender, "SELECT txname FROM taxper WHERE (rec_lock = 'N') ORDER BY txname")
    End Sub

    Private Sub cmbcgste_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcgst.LostFocus, cmbsgst.LostFocus
        sender.Height = 21
    End Sub

    Private Sub cmbcgst_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcgst.Validating
        'vdating(cmbcgst, "SELECT txname FROM taxper WHERE (txname ='" & Trim(cmbcgst.Text) & "')", "Please Select a Valid Tax Name.")
    End Sub

    Private Sub cmbcgst_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcgst.Validated, cmbsgst.Validated
        Dim ds As DataSet = get_dataset("SELECT taxcd,tax1,taxcat FROM taxper WHERE (txname ='" & Trim(sender.Text) & "')")
        If ds.Tables(0).Rows.Count <> 0 Then
            txttaxcd.Text = ds.Tables(0).Rows(0).Item("taxcd")
            txttaxper1.Text = ds.Tables(0).Rows(0).Item("tax1")
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
        vdating(cmbunit, "SELECT unt.unt_nm FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitemcd.Text) & ") AND unt.unt_nm='" & Trim(cmbunit.Text) & "'", "Please Select A Valid Unit Name.")
    End Sub

    Private Sub cmbstaf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstaf.GotFocus
        populate(cmbstaf, "SELECT short_nm FROM staf WHERE(rec_lock = 'N') ORDER BY short_nm")
    End Sub

    Private Sub cmbstaff_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstaf.LostFocus
        cmbstaf.Height = 21
    End Sub

    Private Sub cmbstaff_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstaf.Validated
        vdated(txtstafcd, "SELECT staf_sl FROM staf WHERE short_nm='" & Trim(cmbstaf.Text) & "'")
    End Sub

    Private Sub cmbstaf_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstaf.Validating
        vdating(cmbstaf, "SELECT short_nm FROM staf WHERE short_nm='" & Trim(cmbstaf.Text) & "'", "Please Select A Valid Employee Name.")
    End Sub

    Private Sub cmbserialno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbserialno.GotFocus
        populate(cmbserialno, "SELECT slno FROM mast_slno WHERE (it_cd=" & Val(txtitemcd.Text) & ") AND (io_pos='I') ORDER BY slno")
    End Sub

    Private Sub cmbserialnof_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbserialno.LostFocus
        cmbserialno.Height = 21
    End Sub

    Private Sub cmbserialnof_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbserialno.Validated
        vdated(txtsl_slno, "SELECT sl_slno FROM mast_slno WHERE (slno='" & Trim(cmbserialno.Text) & "') AND (it_cd=" & Val(txtitemcd.Text) & ") AND (io_pos='I')")
    End Sub

    Private Sub cmbserialno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbserialno.Validating
        vdating(cmbserialno, "SELECT slno FROM mast_slno WHERE slno='" & Trim(cmbserialno.Text) & "' AND (it_cd=" & Val(txtitemcd.Text) & ") AND (io_pos='I')", "Please Select A Valid Serial No.")
    End Sub

    Private Sub cmbdrvr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdrvr.GotFocus
        populate(cmbdrvr, "SELECT drv_snm FROM drvmst WHERE (rec_lock = 'N') ORDER BY drv_snm")
    End Sub

    Private Sub cmbdrvrf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdrvr.LostFocus
        cmbdrvr.Height = 21
    End Sub

    Private Sub cmbdrvrf_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdrvr.Validated
        vdated(txtdrvcd, "SELECT drv_cd FROM drvmst WHERE drv_snm='" & Trim(cmbdrvr.Text) & "'")
        vdated(txtvehno, "SELECT veh.veh_no FROM drvmst LEFT OUTER JOIN veh ON drvmst.veh_cd = veh.veh_cd WHERE drvmst.drv_snm='" & Trim(cmbdrvr.Text) & "'")
    End Sub

    Private Sub cmbdrvr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdrvr.Validating
        vdating(cmbdrvr, "SELECT drv_snm FROM drvmst WHERE drv_snm='" & Trim(cmbdrvr.Text) & "'", "Please Select A Valid Driver Name.")
    End Sub
#End Region

#Region "Button"


    Private Sub btnsetabrt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsetabrt.Click
        setting_panel.Visible = False
    End Sub

    Private Sub btnsetaply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsetaply.Click
        Start1()
        SQLInsert("UPDATE setting_sales SET req_mrp=" & IIf(chksetmrp.Checked, 1, 0) & ",req_rate=" & _
                  IIf(chksetrate.Checked, 1, 0) & ",req_disc=" & IIf(chksetdisc.Checked, 1, 0) & ",req_codis=" & _
                  IIf(chksetcodisc.Checked, 1, 0) & ",req_vat=" & IIf(chksetvat.Checked, 1, 0) & ",bill_rnd=" & _
                  IIf(chksetblrnd.Checked, 1, 0) & ",rate_calc=" & IIf(chksetcalcrt.Checked, 1, 0) & ",req_prnt=" & _
                  IIf(chksetprnt.Checked, 1, 0) & ",req_chal=" & IIf(chksetchal.Checked, 1, 0) & " WHERE slno=1")
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
        other_panel.Location = New Point(3, 168)
        other_panel.Visible = True
        txtordno.Focus()
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
        setting_panel.Size = New Size(334, 201)
        setting_panel.Location = New Point(142, 145)
        setting_panel.Visible = True
    End Sub

    Private Sub btnslabort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnslabort.Click
        If dvsl.Rows.Count <> 0 Then
            If Val(lblpqty.Text) <> Val(lblsqty.Text) Then
                MessageBox.Show("Sorry The Serial Quantity And The Sales Quantity Must Be Equal.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbserialno.Focus()
                Exit Sub
            End If
        End If
        Me.clr2()
        cmbproduct.Focus()
    End Sub

    Private Sub btnslnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnslnxt.Click
        If cmbserialno.Text = "" Then
            MessageBox.Show("Please Enter A Valid Product Serial Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbserialno.Focus()
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
                If Trim(cmbserialno.Text) = x Then
                    MessageBox.Show("Sorry The Serial No Not be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbserialno.Focus()
                    Exit Sub
                End If
            Next
        End If
        sl1 = Val(txtsl.Text)
        dvsl.Rows.Add()
        dvsl.Rows(sl1 - 1).Cells(0).Value = sl1
        dvsl.Rows(sl1 - 1).Cells(1).Value = cmbserialno.Text
        dvsl.Rows(sl1 - 1).Cells(2).Value = txtslqty.Text
        dvsl.Rows(sl1 - 1).Cells(3).Value = txtsl_slno.Text
        sl1 += 1
        txtsl.Text = sl1
        lblsqty.Text = Val(lblsqty.Text) + 1
        cmbserialno.Text = ""
        cmbserialno.Focus()
    End Sub

    Private Sub btnslclr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnslclr.Click
        dvsl.Rows.Clear()
        txtsl.Text = "1"
    End Sub

    Private Sub btnprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprint.Click
        frmno = 1
        frmprnt.MdiParent = MDI
        frmprnt.Show()
    End Sub

    Private Sub btnslcont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnslcont.Click
        If Val(lblpqty.Text) <> Val(lblsqty.Text) Then
            MessageBox.Show("Sorry The Serial Quantity And The Sales Quantity Must Be Equal.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbserialno.Focus()
            Exit Sub
        End If
        sl = dvsl1.Rows.Count
        For i As Integer = 0 To dvsl.Rows.Count - 1
            dvsl1.Rows.Add()
            dvsl1.Rows(sl).Cells(0).Value = sl + 1
            dvsl1.Rows(sl).Cells(1).Value = dvsl.Rows(i).Cells(1).Value
            dvsl1.Rows(sl).Cells(2).Value = dvsl.Rows(i).Cells(2).Value
            dvsl1.Rows(sl).Cells(3).Value = txtitemcd.Text
            dvsl1.Rows(sl).Cells(4).Value = dvsl.Rows(i).Cells(3).Value
            sl += 1
        Next
        Me.clr2()
        cmbproduct.Focus()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Val(txtscroll.Text) = 0 Then
            MessageBox.Show("Sorry The Scroll No. Should Not Be Blank/Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtscroll.Focus()
            Exit Sub
        End If
        If vb.Left(cmbbilltp.Text, 1) = "1" Then
            If Trim(txtbillnm.Text) = "" Then
                MessageBox.Show("Sorry The Billing Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtbillnm.Focus()
                Exit Sub
            End If
        Else
            If Trim(cmbparty.Text) = "" Or Val(txtprtcd.Text) = 0 Then
                MessageBox.Show("Sorry The Party Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbparty.Focus()
                Exit Sub
            End If
        End If
        If Val(txtinvno.Text) = 0 Then
            MessageBox.Show("Sorry The Invoice No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtinvno.Focus()
            Exit Sub
        End If
        If Val(txtchno.Text) = 0 And chksetchal.Checked = True Then
            MessageBox.Show("Sorry The Challan No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtchno.Focus()
            Exit Sub
        End If
        If Trim(cmbstaf.Text) = "" Or Val(txtstafcd.Text) = 0 Then
            MessageBox.Show("Sorry The Sold By Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbstaf.Focus()
            Exit Sub
        End If
        If Trim(cmbstore.Text) = "" Or Val(txtgodcd.Text) = 0 Then
            MessageBox.Show("Sorry The Store Point Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbstore.Focus()
            Exit Sub
        End If
        'If Val(txtgrtotal.Text) + Val(lblprtbal.Text) < Val(lbltrlmt.Text) = 0 Then
        '    MessageBox.Show("Sorry The Store Point Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    cmbstore.Focus()
        '    Exit Sub
        'End If


        If dv1.Rows.Count = 0 Then
            MessageBox.Show("Please Enter At least one item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If


        Me.sales_save()
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
            MessageBox.Show("Sorry The Sale Rate Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtrate.Focus()
            Exit Sub
        End If
        'If Val(txtrate.Text) > Val(txtmrp.Text) Then
        '    MessageBox.Show("Sorry The MRP Should Not Be Less Then The Sale Rate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtmrp.Focus()
        '    Exit Sub
        'End If
        'If Val(txtvat.Text) = 0 Then
        '    MessageBox.Show("Sorry The Vat Amount Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtrate.Focus()
        '    Exit Sub
        'End If
        If cmbtr.SelectedIndex = 0 And item_type = "1" Then
            If Val(lblsound.Text) < (Val(txtquantity.Text) + Val(txtfree.Text)) Then
                MessageBox.Show("Sorry Not Sufficient Stock to Bill.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtquantity.Focus()
                Exit Sub
            End If
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
        dv1.Rows(sl1 - 1).Cells(17).Value = txttaxstl.Text
        dv1.Rows(sl1 - 1).Cells(18).Value = cmbcgst.Text
        dv1.Rows(sl1 - 1).Cells(19).Value = txtcgst.Text
        dv1.Rows(sl1 - 1).Cells(20).Value = cmbsgst.Text
        dv1.Rows(sl1 - 1).Cells(21).Value = txtsgst.Text
        dv1.Rows(sl1 - 1).Cells(22).Value = txtadisc.Text
        dv1.Rows(sl1 - 1).Cells(23).Value = txtacharg.Text
        dv1.Rows(sl1 - 1).Cells(24).Value = txttotal.Text
        dv1.Rows(sl1 - 1).Cells(25).Value = txtitemcd.Text
        dv1.Rows(sl1 - 1).Cells(26).Value = txttaxcd.Text
        dv1.Rows(sl1 - 1).Cells(27).Value = Format(Val(txtexclmrp.Text), "######0.00")
        dv1.Rows(sl1 - 1).Cells(28).Value = txtbatcd.Text
        dv1.Rows(sl1 - 1).Cells(29).Value = txtmulrt.Text
        dv1.Rows(sl1 - 1).Cells(30).Value = 0
        dv1.Rows(sl1 - 1).Cells(31).Value = item_type
        sl1 += 1
        txtslno.Text = sl1
        lblpqty.Text = Format(Val(txtquantity.Text), "####0")
        Start1()
        If chksetmrp.Checked = True Then
            mrp = Val(txtmrp.Text) / Val(txtmulrt.Text)
            SQLInsert("UPDATE item SET mrp=" & mrp & " WHERE it_cd=" & Val(txtitemcd.Text) & "")
            SQLInsert("UPDATE batno SET mrp=" & mrp & " WHERE it_cd=" & Val(txtitemcd.Text) & " AND bat_cd=" & Val(txtbatcd.Text) & "")
        End If
        If chksetrate.Checked = True Then
            pur_rt = Val(txtrealrt.Text) / Val(txtmulrt.Text)
            SQLInsert("UPDATE item SET sale_rate1=" & pur_rt & " WHERE it_cd=" & Val(txtitemcd.Text) & "")
            SQLInsert("UPDATE batno SET sale_rate1=" & pur_rt & " WHERE it_cd=" & Val(txtitemcd.Text) & " AND bat_cd=" & Val(txtbatcd.Text) & "")
        End If
        Close1()
        cmbproduct.Focus()
        If txtbatcnfr.Text = "S" Then
            serial_panel.Size = New Size(371, 292)
            serial_panel.Location = New Point(561, 84)
            serial_panel.Visible = True
            cmbserialno.Focus()
        End If
        Me.grandamt(dv1)
        Me.clr1()
    End Sub
#End Region

#Region "Data save"
    Private Sub sales_save()
        cgst = Val(lblcgsttot.Text)
        igst = 0
        If txtinout.Text = "O" Then
            cgst = 0
            igst = Val(lblcgsttot.Text)
        End If
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT MAX(bill_no) AS MAX FROM csale1")
                txtscroll.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                rinno = txtinvno.Text
                tinno = 0
                If vb.Left(lblinvtp.Text, 1) = "T" Then
                    tinno = txtinvno.Text
                    rinno = 0
                End If
                SQLInsert("INSERT INTO csale1 (bill_no,bill_dt,pay_dt,bill_tp,bill_pfx,tin_bno,rin_bno,inv_tp,prt_code,staf_sl,ch_no,ch_dt," & _
                          "order_no,order_dt,trk_no,way_bno,way_pfx,lr_no,lr_dt,sale_amt,dis_amt,chr_amt,dv_tot,adj_amt,bl_name,ref_no,nb," & _
                          "usr_ent,ent_date,usr_mod,mod_date,used_by,rec_lock,tot_tto,tot_vat,splnb,godsl,mobno,add1,drv_cd,cgsttot,sgsttot,igsttot) VALUES (" & _
                          Val(txtscroll.Text) & ",'" & Format(invdt.Value, "dd/MMM/yyyy") & "','" & Format(paydt.Value, "dd/MMM/yyyy") & "','" & vb.Left(cmbbilltp.Text, 1) & "','" & _
                          Trim(txtpfx.Text) & "'," & Val(tinno) & "," & Val(rinno) & ",'" & vb.Left(lblinvtp.Text, 1) & "'," & _
                          Val(txtprtcd.Text) & ",'" & Trim(txtstafcd.Text) & "','" & Trim(txtchno.Text) & "','" & _
                          Format(chdt.Value, "dd/MMM/yyyy") & "','" & Trim(txtordno.Text) & "','" & Format(orddt.Value, "dd/MMM/yyyy") & "','" & Trim(txtvehno.Text) & "'," & _
                          Val(txtwbno.Text) & ",'" & Trim(txtwaypfx.Text) & "','" & Trim(txtlrno.Text) & "','" & _
                          Format(lrdt.Value, "dd/MMM/yyyy") & "'," & Val(txtgrtotal.Text) & "," & Val(txtdiscamt.Text) & "," & _
                          Val(txtchargamt.Text) & "," & Val(lbltotal.Text) & "," & Val(txtadj.Text) & ",'" & Trim(txtbillnm.Text) & "','" & _
                          Trim(txtrefno.Text) & "','" & Trim(txtnb.Text) & "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & _
                          Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N','N'," & Val(lbltto.Text) & "," & _
                          Val(lblcgsttot.Text) & ",'" & Trim(txtnb.Text) & "'," & Val(txtgodcd.Text) & ",'" & Trim(txtmob.Text) & "','" & _
                          Trim(txtadd.Text) & "'," & Val(txtdrvcd.Text) & "," & cgst & "," & Val(lblsgsttot.Text) & "," & igst & ")")
                If vb.Left(lblinvtp.Text, 1) = "T" Then
                    SQLInsert("INSERT INTO tinbill(tin_bno,tin_bdt,bill_tp,bill_pfx,bill_no) VALUES (" & Val(txtinvno.Text) & ",'" & Format(invdt.Value, "dd/MMM/yyyy") & "','" & vb.Left(cmbbilltp.Text, 1) & "','" & Trim(txtpfx.Text) & "'," & Val(txtscroll.Text) & ")")
                Else
                    SQLInsert("INSERT INTO rinbill(rin_bno,rin_bdt,bill_tp,bill_pfx,bill_no) VALUES (" & Val(txtinvno.Text) & ",'" & Format(invdt.Value, "dd/MMM/yyyy") & "','" & vb.Left(cmbbilltp.Text, 1) & "','" & Trim(txtpfx.Text) & "'," & Val(txtscroll.Text) & ")")
                End If
                If Val(txtchno.Text) <> 0 Then
                    Me.chal_save()
                End If
                Me.dv_save()
                If cmbbilltp.SelectedIndex = 1 Then
                    SQLInsert("UPDATE party SET dr_amt=dr_amt + " & Val(txtgrtotal.Text) & ",cl_amt=cl_amt - " & Val(txtgrtotal.Text) & " WHERE prt_code=" & Val(txtprtcd.Text) & "")
                End If
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If chksetprnt.Checked = True Then
                    cnfr = MessageBox.Show("Are You Sure The Printer is Ready To Print The Bill.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If cnfr = vbYes Then
                        Call sale_print(Val(txtscroll.Text))
                    End If
                End If
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
                Dim ds As DataSet = get_dataset("SELECT bill_no FROM csale1 WHERE bill_no=" & Val(txtscroll.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE csale1 SET bill_dt='" & Format(invdt.Value, "dd/MMM/yyyy") & "',bill_tp='" & _
                              vb.Left(cmbbilltp.Text, 1) & "', bill_pfx='" & Trim(txtpfx.Text) & "', inv_tp='" & _
                              vb.Left(lblinvtp.Text, 1) & "',pay_dt='" & Format(paydt.Value, "dd/MMM/yyyy") & "', prt_code=" & Val(txtprtcd.Text) & ", staf_sl='" & _
                              Trim(txtstafcd.Text) & "', ch_no='" & Trim(txtchno.Text) & "', ch_dt='" & _
                              Format(chdt.Value, "dd/MMM/yyyy") & "',order_no='" & Trim(txtordno.Text) & "', order_dt='" & Format(orddt.Value, "dd/MMM/yyyy") & "', trk_no='" & _
                              Trim(txtvehno.Text) & "', way_bno=" & Val(txtwbno.Text) & ", way_pfx='" & Trim(txtwaypfx.Text) & "', lr_no='" & _
                              Trim(txtlrno.Text) & "', lr_dt='" & Format(lrdt.Value, "dd/MMM/yyyy") & "', sale_amt=" & _
                              Val(txtgrtotal.Text) & ", dis_amt=" & Val(txtdiscamt.Text) & ", chr_amt=" & Val(txtchargamt.Text) & ", dv_tot=" & _
                              Val(lbltotal.Text) & ", adj_amt=" & Val(txtadj.Text) & ", bl_name='" & Trim(txtbillnm.Text) & "', ref_no='" & _
                              Trim(txtrefno.Text) & "', nb='" & Trim(txtnb.Text) & "', usr_mod=" & Val(usr_sl) & ", mod_date='" & _
                              Format(Now, "dd/MMM/yyyy HH:mm:ss") & "', tot_tto=" & Val(lbltto.Text) & ", tot_vat=" & _
                              Val(lblcgsttot.Text) & ",cgsttot=" & cgst & ",sgsttot=" & Val(lblsgsttot.Text) & ",igsttot=" & igst & ", splnb='" & Trim(txtnb.Text) & "', godsl=" & Val(txtgodcd.Text) & ", mobno='" & _
                              Trim(txtmob.Text) & "', add1='" & Trim(txtadd.Text) & "',drv_cd=" & Val(txtdrvcd.Text) & " WHERE bill_no =" & Val(txtscroll.Text) & "")
                    If Val(txtchno.Text) <> 0 Then
                        Me.chal_save()
                    End If
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
                Call del2(txtscroll.Text)
                Call del1(txtscroll.Text)
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
                igst = 0
                igstamt = 0
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
                taxcat = dv1.Rows(i).Cells(17).Value
                cgst = Val(dv1.Rows(i).Cells(18).Value)
                cgstamt = Val(dv1.Rows(i).Cells(19).Value)
                sgst = Val(dv1.Rows(i).Cells(20).Value)
                sgstamt = Val(dv1.Rows(i).Cells(21).Value)
                If txtinout.Text = "O" Then
                    cgst = 0
                    cgstamt = 0
                    igst = Val(dv1.Rows(i).Cells(18).Value)
                    igstamt = Val(dv1.Rows(i).Cells(19).Value)
                End If
                adisc = Val(dv1.Rows(i).Cells(22).Value)
                achrg = Val(dv1.Rows(i).Cells(23).Value)
                total = Val(dv1.Rows(i).Cells(24).Value)
                itcd = Val(dv1.Rows(i).Cells(25).Value)
                taxcd = Val(dv1.Rows(i).Cells(26).Value)
                exmrp = Val(dv1.Rows(i).Cells(27).Value)
                batcd = Val(dv1.Rows(i).Cells(28).Value)
                mulrt = Val(dv1.Rows(i).Cells(29).Value)
                item_type = dv1.Rows(i).Cells(31).Value
                mrpamt = Val(exmrp) * (Val(qty) + Val(free))
                Dim ds1 As DataSet = get_dataset("SELECT max(bill_sl) as 'Max' FROM csale2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                mxsl = 0
                If Val(txtchno.Text) <> 0 Then
                    Dim ds3 As DataSet = get_dataset("SELECT max(sch_sl) as 'Max' FROM schal2")
                    mxsl = 1
                    If ds3.Tables(0).Rows.Count <> 0 Then
                        If Not IsDBNull(ds3.Tables(0).Rows(0).Item(0)) Then
                            mxsl = ds3.Tables(0).Rows(0).Item(0) + 1
                        End If
                    End If
                End If

                rinno = txtinvno.Text
                tinno = 0
                If vb.Left(lblinvtp.Text, 1) = "T" Then
                    tinno = txtinvno.Text
                    rinno = 0
                End If
                SQLInsert("INSERT INTO csale2(bill_sl,bill_no,bill_dt,bill_tp,tin_bno,rin_bno,prt_code,ch_no,ch_sl,it_cd,bat_cd,godsl,sale_qty," & _
                          "free_qty,sale_rt,disc_rt1,disc_rt2,disc_amt1,disc_amt2,disc_amt,it_tot,mrp,ex_mrp,bill_pfx,unt,it_amt,mul_rt,tto_amt," & _
                          "tax_cd,stax,mrp_amt,bit_type,oth_amt,prd_tp,tr_tp,cgstper,cgstamt,sgstper,sgstamt,igstper,igstamt,item_tp) VALUES (" & Val(mxno) & "," & Val(txtscroll.Text) & ",'" & _
                          Format(invdt.Value, "dd/MMM/yyyy") & "','" & vb.Left(cmbbilltp.Text, 1) & "'," & Val(tinno) & "," & Val(rinno) & "," & _
                          Val(txtprtcd.Text) & ", " & Val(txtchno.Text) & "," & Val(mxsl) & "," & Val(itcd) & "," & Val(batcd) & "," & Val(txtgodcd.Text) & "," & qty & "," & free & "," & _
                          it_rt & "," & codisper & "," & trdisper & "," & codisamt & "," & trdisamt & "," & adisc & "," & total & "," & mrp & "," & exmrp & ",'" & _
                          Trim(txtpfx.Text) & "','" & unt & "'," & amt & "," & mulrt & "," & tto & "," & taxcd & "," & cgstamt & "," & mrpamt & ",'" & _
                          taxcat & "'," & achrg & ",'" & vb.Left(prdtp, 1) & "','" & vb.Left(trtp, 1) & "'," & cgst & "," & cgstamt & "," & sgst & "," & sgstamt & "," & igst & "," & igstamt & ",'" & item_type & "')")
                If Val(txtchno.Text) <> 0 Then
                    'Dim ds3 As DataSet = get_dataset("SELECT max(sch_sl) as 'Max' FROM schal2")
                    'mxsl = 1
                    'If ds3.Tables(0).Rows.Count <> 0 Then
                    '    If Not IsDBNull(ds3.Tables(0).Rows(0).Item(0)) Then
                    '        mxsl = ds3.Tables(0).Rows(0).Item(0) + 1
                    '    End If
                    'End If
                    SQLInsert("INSERT INTO schal2(sch_sl,sch_no,sch_dt,sch_tp,prd_tp,prt_code,it_cd,bat_cd,sale_rt,sch_qty,free_qty," & _
                              "bsch_qty,bfree_qty,unt,billed,mrp,excl_mrp,it_amt,mul_rt,rep_qty,brep_qty) VALUES (" & Val(mxsl) & "," & _
                              Val(txtchno.Text) & ",'" & Format(chdt.Value, "dd/MMM/yyyy") & "','3','" & vb.Left(prdtp, 1) & "'," & _
                              Val(txtprtcd.Text) & "," & Val(itcd) & "," & Val(batcd) & "," & it_rt & "," & qty & "," & free & "," & _
                              qty & "," & free & ",'" & unt & "','Y'," & mrp & "," & exmrp & "," & amt & "," & mulrt & ",0,0)")
                End If
                'If txtbatcnfr.Text = "S" Then
                Me.srl_save(mxno, itcd)
                'End If
                If item_type = "1" Then 'If 1=Saleble item then update the Stock
                    itqt = (qty * mulrt) + (free * mulrt)
                    stock_OUT(itqt, itcd, batcd, vb.Left(prdtp, 1), vb.Left(trtp, 1))
                End If
            Next
        End If
    End Sub

    Private Sub srl_save(ByVal pursl As Integer, ByVal it_cd As Integer)
        If dvsl1.RowCount <> 0 Then
            SQLInsert("DELETE FROM sale_slno WHERE bill_sl=" & Val(pursl) & "")
            For m As Integer = 0 To dvsl1.RowCount - 1
                srlcd = Val(dvsl1.Rows(m).Cells(4).Value)
                itcd = Val(dvsl1.Rows(m).Cells(3).Value)
                If Val(itcd) = Val(it_cd) Then
                    SQLInsert("UPDATE mast_slno SET io_pos='O' WHERE it_cd=" & it_cd & " AND sl_slno=" & srlcd & "")
                    SQLInsert("INSERT INTO sale_slno (sl_slno,it_cd,bill_no,bill_sl) VALUES (" & srlcd & "," & itcd & "," & Val(txtscroll.Text) & "," & Val(pursl) & ")")
                End If
            Next
        End If
    End Sub

    Private Sub chal_save()
        If comd = "E" Then
            SQLInsert("INSERT INTO schal1(sch_no,sch_dt,prt_code,ref_no,ref_dt,way_bno,way_chr,trk_no,lr_no,lr_dt,sch_amt,billed,usedby," & _
                      "pfx,rec_lock,nb,ord_no,ord_dt,god_sl,usr_ent,ent_date,usr_mod,mod_date) VALUES (" & Val(txtchno.Text) & ",'" & _
                      Format(chdt.Value, "dd/MMM/yyyy") & "'," & Val(txtprtcd.Text) & ",'" & Trim(txtrefno.Text) & "','" & _
                      Format(paydt.Value, "dd/MMM/yyyy") & "'," & Val(txtwbno.Text) & ",'" & Trim(txtwaypfx.Text) & "','" & _
                      Trim(txtvehno.Text) & "','" & Trim(txtlrno.Text) & "','" & Format(lrdt.Value, "dd/MMM/yyyy") & "'," & _
                      Val(lblamount.Text) & ",'Y','N','" & Trim(txtpfx.Text) & "','N','" & Trim(txtnb.Text) & "'," & Val(txtordno.Text) & ",'" & _
                      Format(orddt.Value, "dd/MMM/yyyy") & "'," & Val(txtgodcd.Text) & "," & Val(usr_sl) & ",'" & _
                      Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "')")
        ElseIf comd = "M" Then
            SQLInsert("UPDATE schal1 SET sch_dt='" & Format(chdt.Value, "dd/MMM/yyyy") & "', prt_code=" & Val(txtprtcd.Text) & ", ref_no='" & _
                      Trim(txtrefno.Text) & "', ref_dt='" & Format(paydt.Value, "dd/MMM/yyyy") & "', way_bno=" & Val(txtwbno.Text) & ", way_chr='" & _
                      Trim(txtwaypfx.Text) & "', trk_no='" & Trim(txtvehno.Text) & "', lr_no='" & Trim(txtlrno.Text) & "', lr_dt='" & _
                      Format(lrdt.Value, "dd/MMM/yyyy") & "', sch_amt=" & Val(lblamount.Text) & ",pfx='" & Trim(txtpfx.Text) & "', nb='" & _
                      Trim(txtnb.Text) & "',ord_no=" & Val(txtordno.Text) & ", ord_dt='" & Format(orddt.Value, "dd/MMM/yyyy") & "', god_sl=" & Val(txtgodcd.Text) & ", usr_mod=" & _
                      Val(usr_sl) & ", mod_date='" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "' WHERE sch_no=" & Val(txtchno.Text) & "")
        End If
    End Sub

#End Region

#Region "Calculation"
    Private Sub dv_calc()
        gstper = Val(cmbcgst.Text) + Val(cmbsgst.Text)
        itqt = Val(txtquantity.Text) '* Val(txtmulrt.Text)
        frqt = Val(txtfree.Text) '* Val(txtmulrt.Text)
        If Val(txtquantity.Text) <> 0 Or Val(frqt) <> 0 Then
            txtamount.Text = Format(Val(Val(itqt) * Val(txtrate.Text)), "########0.00")
            txttto.Text = Format(Val(txtamount.Text) - (Val(txtcoamt.Text) + Val(txttramt.Text)), "########0.00")
            If Trim(txttaxstl.Text) = "I" Then
                txtexclmrp.Text = Val(Val(txtmrp.Text) * 100) / Val(Val(gstper) + 100)
                txtmrvalue.Text = Format(Val(Val(Val(itqt) + Val(frqt)) * Val(txtmrp.Text) * 100) / Val(Val(gstper) + 100), "########0.00")
            Else
                txtmrvalue.Text = Format(Val(Val(Val(itqt) + Val(frqt)) * Val(txtmrp.Text)), "########0.00")
            End If
            If txttaxcat.Text = "1" Then
                cgst = Val((Val(cmbcgst.Text) / 100) * Val(txttto.Text))
                sgst = Val((Val(cmbsgst.Text) / 100) * Val(txttto.Text))
            Else
                cgst = Val((Val(cmbcgst.Text) / 100) * Val(txtmrvalue.Text))
                sgst = Val((Val(cmbsgst.Text) / 100) * Val(txtmrvalue.Text))
            End If
            txtcgst.Text = Format(Val(cgst), "########0.00")
            If txtinout.Text = "I" Then
                txtsgst.Text = Format(Val(sgst), "########0.00")
            End If
            'totmrp = Val(txtmrp.Text) * (Val(itqt) + Val(frqt))
            'vatfr = 0
            'If Val(frqt) <> 0 Then
            '    puramt = Format(Val(Val(frqt) * Val(txtrate.Text)), "########0.00")
            '    vatfr = Val((Val(txtvatper.Text) / 100) * Val(puramt))
            'End If
            'txtvat.Text = Format(Val(vatqt) + Val(vatfr), "########0.00")
            'totamt = Val(txttto.Text) + Val(txtvat.Text)
            txttotal.Text = Format(Val(Val(txttto.Text) + (Val(txtcgst.Text) + Val(txtsgst.Text) + Val(txtacharg.Text)) - Val(txtadisc.Text)), "########0.00")
        End If
    End Sub

    Private Sub grandamt(ByVal dgv As DataGridView)
        tamt = 0
        tcodis = 0
        ttrdis = 0
        tmrval = 0
        ttto = 0
        tcgst = 0
        tsgst = 0
        tdisc = 0
        tchrg = 0
        tgtamt = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            amt = dgv.Rows(i).Cells(10).Value
            codis = dgv.Rows(i).Cells(12).Value
            trdis = dgv.Rows(i).Cells(14).Value
            mrval = dgv.Rows(i).Cells(15).Value
            tto = dgv.Rows(i).Cells(16).Value
            cgst = dgv.Rows(i).Cells(19).Value
            sgst = dgv.Rows(i).Cells(21).Value
            disc = dgv.Rows(i).Cells(22).Value
            chrg = dgv.Rows(i).Cells(23).Value
            gtamt = dgv.Rows(i).Cells(24).Value
            'Totalling(Section)
            tamt = tamt + Val(amt)
            tcodis = tcodis + Val(codis)
            ttrdis = ttrdis + Val(trdis)
            tmrval = tmrval + Val(mrval)
            ttto = ttto + Val(tto)
            tcgst = tcgst + Val(cgst)
            tsgst = tsgst + Val(sgst)
            tdisc = tdisc + Val(disc)
            tchrg = tchrg + Val(chrg)
            tgtamt = tgtamt + Val(gtamt)
        Next
        lblamount.Text = Format(tamt, "#######0.00")
        lblcodisc.Text = Format(tcodis, "#######0.00")
        lbltrdisc.Text = Format(ttrdis, "#######0.00")
        lblmrpval.Text = Format(tmrval, "#######0.00")
        lbltto.Text = Format(ttto, "#######0.00")
        lblcgsttot.Text = Format(tcgst, "#######0.00")
        lblsgsttot.Text = Format(tsgst, "#######0.00")
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
        Dim dsedit As DataSet = get_dataset("SELECT csale1.bill_no AS 'Bill No', CONVERT(VARCHAR,csale1.bill_dt,103) AS 'Date', (CASE WHEN csale1.bill_tp='1' THEN 'Cash' WHEN csale1.bill_tp='2' THEN 'Credit' END) AS 'Type', (CASE WHEN csale1.inv_tp='T' THEN 'Tax Invoice' WHEN csale1.inv_tp='R' THEN 'Retail Invoice' END) AS 'Inv.Type', csale1.bill_pfx AS ' ',(CASE WHEN csale1.tin_bno=0 THEN csale1.rin_bno WHEN csale1.tin_bno<>0 THEN csale1.tin_bno END) AS 'Inv.No', csale1.ch_no AS 'Chal. No', csale1.bl_name AS 'Name',STR(csale1.sale_amt,10,2) AS 'Amount',staf.short_nm AS 'Sold By' FROM csale1 LEFT OUTER JOIN staf ON csale1.staf_sl = staf.staf_sl ORDER BY csale1.bill_dt DESC, csale1.bill_no DESC")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_view()
        Dim ds As DataSet = get_dataset("SELECT item.it_name, csale2.*, taxper.txname,batno.bat_no FROM csale2 LEFT OUTER JOIN taxper ON csale2.tax_cd = taxper.taxcd LEFT OUTER JOIN item ON csale2.it_cd = item.it_cd LEFT OUTER JOIN batno ON csale2.bat_cd = batno.bat_cd WHERE csale2.bill_no=" & Val(txtscroll.Text) & "")
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
                    dv1.Rows(rw).Cells(4).Value = "1.Sales."
                Else
                    dv1.Rows(rw).Cells(4).Value = "2.Return."
                End If
                dv1.Rows(rw).Cells(5).Value = ds.Tables(0).Rows(i).Item("unt")
                dv1.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("sale_qty"), "####0.00")
                dv1.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("free_qty"), "####0.00")
                dv1.Rows(rw).Cells(8).Value = Format(ds.Tables(0).Rows(i).Item("mrp"), "######0.00")
                dv1.Rows(rw).Cells(9).Value = Format(ds.Tables(0).Rows(i).Item("sale_rt"), "######0.00")
                dv1.Rows(rw).Cells(10).Value = Format(ds.Tables(0).Rows(i).Item("it_amt"), "######0.00")
                dv1.Rows(rw).Cells(11).Value = Format(ds.Tables(0).Rows(i).Item("disc_rt1"), "######0.00")
                dv1.Rows(rw).Cells(12).Value = Format(ds.Tables(0).Rows(i).Item("disc_amt1"), "######0.00")
                dv1.Rows(rw).Cells(13).Value = Format(ds.Tables(0).Rows(i).Item("disc_rt2"), "######0.00")
                dv1.Rows(rw).Cells(14).Value = Format(ds.Tables(0).Rows(i).Item("disc_amt2"), "######0.00")
                'mrpval = Val(ds.Tables(0).Rows(i).Item("mrp")) * (Val(ds.Tables(0).Rows(i).Item("sale_qty")) + Val(ds.Tables(0).Rows(i).Item("free_qty")))
                dv1.Rows(rw).Cells(15).Value = Format(ds.Tables(0).Rows(i).Item("mrp_amt"), "######0.00")
                dv1.Rows(rw).Cells(16).Value = Format(ds.Tables(0).Rows(i).Item("tto_amt"), "######0.00")
                dv1.Rows(rw).Cells(17).Value = ds.Tables(0).Rows(i).Item("bit_type")
                If Trim(txtinout.Text) = "O" Then
                    dv1.Rows(rw).Cells(18).Value = Format(ds.Tables(0).Rows(i).Item("igstper"), "######0.00")
                    dv1.Rows(rw).Cells(19).Value = Format(ds.Tables(0).Rows(i).Item("igstamt"), "######0.00")
                Else
                    dv1.Rows(rw).Cells(18).Value = Format(ds.Tables(0).Rows(i).Item("cgstper"), "######0.00")
                    dv1.Rows(rw).Cells(19).Value = Format(ds.Tables(0).Rows(i).Item("cgstamt"), "######0.00")
                End If
                dv1.Rows(rw).Cells(20).Value = Format(ds.Tables(0).Rows(i).Item("sgstper"), "######0.00")
                dv1.Rows(rw).Cells(21).Value = Format(ds.Tables(0).Rows(i).Item("sgstamt"), "######0.00")
                dv1.Rows(rw).Cells(22).Value = Format(ds.Tables(0).Rows(i).Item("disc_amt"), "######0.00")
                dv1.Rows(rw).Cells(23).Value = Format(ds.Tables(0).Rows(i).Item("oth_amt"), "######0.00")
                dv1.Rows(rw).Cells(24).Value = Format(ds.Tables(0).Rows(i).Item("it_tot"), "######0.00")
                dv1.Rows(rw).Cells(25).Value = ds.Tables(0).Rows(i).Item("it_cd")
                dv1.Rows(rw).Cells(26).Value = ds.Tables(0).Rows(i).Item("tax_cd")
                dv1.Rows(rw).Cells(27).Value = Format(ds.Tables(0).Rows(i).Item("ex_mrp"), "######0.00")
                dv1.Rows(rw).Cells(28).Value = ds.Tables(0).Rows(i).Item("bat_cd")
                dv1.Rows(rw).Cells(29).Value = ds.Tables(0).Rows(i).Item("mul_rt")
                dv1.Rows(rw).Cells(30).Value = ds.Tables(0).Rows(i).Item("bill_sl")
                dv1.Rows(rw).Cells(31).Value = ds.Tables(0).Rows(i).Item("item_tp")
                rw += 1
                'If txtbatcnfr.Text = "S" Then
                pursl = ds.Tables(0).Rows(i).Item("bill_sl")
                Me.srl_view(pursl)
                'End If
            Next
            Me.grandamt(dv1)
            txtslno.Text = rw + 1
        End If
    End Sub

    Private Sub srl_view(ByVal pursl As Integer)
        Dim ds2 As DataSet = get_dataset("SELECT mast_slno.slno, sale_slno.* FROM sale_slno LEFT OUTER JOIN mast_slno ON sale_slno.sl_slno = mast_slno.sl_slno WHERE sale_slno.bill_sl=" & pursl & "")
        If ds2.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                sl = dvsl1.Rows.Count
                slno = ds2.Tables(0).Rows(i).Item("slno")
                itcd = ds2.Tables(0).Rows(i).Item("it_cd")
                srlcd = ds2.Tables(0).Rows(i).Item("sl_slno")
                dvsl1.Rows.Add()
                dvsl1.Rows(sl).Cells(0).Value = sl + 1
                dvsl1.Rows(sl).Cells(1).Value = slno
                dvsl1.Rows(sl).Cells(2).Value = 1
                dvsl1.Rows(sl).Cells(3).Value = itcd
                dvsl1.Rows(sl).Cells(4).Value = srlcd
            Next
        End If
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT party.pname,drvmst.drv_snm, csale1.*, godown.godnm,staf.short_nm FROM csale1 LEFT OUTER JOIN drvmst ON csale1.drv_cd = drvmst.drv_cd LEFT OUTER JOIN godown ON csale1.godsl = godown.godsl LEFT OUTER JOIN staf ON csale1.staf_sl = staf.staf_sl LEFT OUTER JOIN party ON csale1.prt_code = party.prt_code WHERE(csale1.bill_no = " & slno & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscroll.Text = slno
            cmbbilltp.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("bill_tp")) - 1
            txtpfx.Text = dsedit.Tables(0).Rows(0).Item("bill_pfx")
            If dsedit.Tables(0).Rows(0).Item("tin_bno") <> 0 Then
                txtinvno.Text = dsedit.Tables(0).Rows(0).Item("tin_bno")
            Else
                txtinvno.Text = dsedit.Tables(0).Rows(0).Item("rin_bno")
            End If
            txtchno.Text = dsedit.Tables(0).Rows(0).Item("ch_no")
            chdt.Value = dsedit.Tables(0).Rows(0).Item("ch_dt")
            txtrefno.Text = dsedit.Tables(0).Rows(0).Item("ref_no")
            invdt.Value = dsedit.Tables(0).Rows(0).Item("bill_dt")
            paydt.Value = dsedit.Tables(0).Rows(0).Item("pay_dt")
            cmbstore.Text = dsedit.Tables(0).Rows(0).Item("godnm")
            txtgodcd.Text = dsedit.Tables(0).Rows(0).Item("godsl")
            cmbstaf.Text = dsedit.Tables(0).Rows(0).Item("short_nm")
            txtstafcd.Text = dsedit.Tables(0).Rows(0).Item("staf_sl")
            txtprtcd.Text = dsedit.Tables(0).Rows(0).Item("prt_code")
            cmbparty.Text = ""
            If Val(txtprtcd.Text) <> 0 And Not IsDBNull(dsedit.Tables(0).Rows(0).Item("pname")) Then
                cmbparty.Text = dsedit.Tables(0).Rows(0).Item("pname")
            End If
            txtbillnm.Text = dsedit.Tables(0).Rows(0).Item("bl_name")
            txtadd.Text = dsedit.Tables(0).Rows(0).Item("add1")
            txtmob.Text = dsedit.Tables(0).Rows(0).Item("mobno")

            txtdiscamt.Text = Format(dsedit.Tables(0).Rows(0).Item("dis_amt"), "######0.00")
            txtchargamt.Text = Format(dsedit.Tables(0).Rows(0).Item("chr_amt"), "######0.00")
            txtadj.Text = Format(dsedit.Tables(0).Rows(0).Item("adj_amt"), "######0.00")
            txtgrtotal.Text = Format(dsedit.Tables(0).Rows(0).Item("sale_amt"), "######0.00")
            txtnb.Text = dsedit.Tables(0).Rows(0).Item("nb")
            'Others
            txtdrvcd.Text = dsedit.Tables(0).Rows(0).Item("drv_cd")
            txtordno.Text = dsedit.Tables(0).Rows(0).Item("order_no")
            orddt.Value = dsedit.Tables(0).Rows(0).Item("order_dt")
            txtvehno.Text = dsedit.Tables(0).Rows(0).Item("trk_no")
            txtlrno.Text = dsedit.Tables(0).Rows(0).Item("lr_no")
            lrdt.Value = dsedit.Tables(0).Rows(0).Item("lr_dt")
            txtwaypfx.Text = dsedit.Tables(0).Rows(0).Item("way_pfx")
            txtwbno.Text = dsedit.Tables(0).Rows(0).Item("way_bno")
            If Val(txtdrvcd.Text) <> 0 Then
                cmbdrvr.Text = dsedit.Tables(0).Rows(0).Item("drv_snm")
            End If
            Me.party_view()
            Me.dv_view()
        End If
        Close1()
    End Sub

    Private Sub trans_view()
        dvtrans.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        salrt = "sale_rate" & txtprtcat.Text
        ds = get_dataset("SELECT TOP (3) convert(varchar,bill_dt,3) 'Date',STR(mrp,10,2) 'MRP', STR(sale_rt,10,2) 'Rate',unt AS 'Unit' FROM csale2 WHERE (it_cd = " & Val(txtitemcd.Text) & ") AND (prt_code = " & Val(txtprtcd.Text) & ") ORDER BY bill_dt DESC")
        If ds.Tables(0).Rows.Count <> 0 Then
            dvtrans.DataSource = ds.Tables(0)
        End If
        Close1()
    End Sub

    Private Sub purch_view()
        dvpur.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        ds = get_dataset("SELECT TOP (3) convert(varchar,pur_dt,3) 'Date',STR(mrp,10,2) 'MRP', STR(pur_rt,10,2) 'Pur.Rt',unt AS 'Unit' FROM purch2 WHERE (it_cd = " & Val(txtitemcd.Text) & ") ORDER BY pur_dt DESC")
        If ds.Tables(0).Rows.Count <> 0 Then
            dvpur.DataSource = ds.Tables(0)
        End If
        Close1()
    End Sub

    Private Sub party_view()
        Dim ds As DataSet = get_dataset("SELECT party.prt_code, party.bname,party.add1,party.cont1, party.lim_day, party.cl_amt,party.cust_cat, rout.rt_nm, market.ma_nm, party.ma_cd, party.cst_no, party.lst_no,party.in_out, party.tr_lim FROM rout RIGHT OUTER JOIN market ON rout.rt_cd = market.rt_cd RIGHT OUTER JOIN party ON market.ma_cd = party.ma_cd WHERE party.prt_code=" & Val(txtprtcd.Text) & "")
        If ds.Tables(0).Rows.Count <> 0 Then
            lbladdress.Text = Trim(ds.Tables(0).Rows(0).Item("add1"))
            txtmrktcd.Text = Val(ds.Tables(0).Rows(0).Item("ma_cd"))
            txtprtcat.Text = Val(ds.Tables(0).Rows(0).Item("cust_cat"))
            cstno = ""
            If Trim(ds.Tables(0).Rows(0).Item("cst_no")) <> "" Then
                cstno = " CST No : " & Trim(ds.Tables(0).Rows(0).Item("cst_no"))
            End If
            lblregdno.Text = Trim(ds.Tables(0).Rows(0).Item("lst_no")) & cstno
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("ma_nm")) Then
                lblmarket.Text = Trim(ds.Tables(0).Rows(0).Item("ma_nm")) & "(" & Trim(ds.Tables(0).Rows(0).Item("rt_nm")) & ")"
            End If
            paydt.Value = invdt.Value.AddDays(Val(ds.Tables(0).Rows(0).Item("lim_day")))
            clamt = Val(ds.Tables(0).Rows(0).Item("cl_amt"))
            If clamt < 0 Then
                lblprtbal.Text = Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
            Else
                lblprtbal.Text = Format(clamt, "#######0.00") & " " & "Cr."
            End If
            trlmt = Val(ds.Tables(0).Rows(0).Item("tr_lim"))
            If trlmt < 0 Then
                lbltrlmt.Text = Format(Val(trlmt) * (-1), "#######0.00") & " " & "Dr."
            Else
                lbltrlmt.Text = Format(trlmt, "#######0.00") & " " & "Cr."
            End If
            If Len(Trim(ds.Tables(0).Rows(0).Item("lst_no"))) >= 11 Then
                lblinvtp.Text = "Tax Invoice"
            Else
                lblinvtp.Text = "Retail Invoice"
            End If
            If Trim(ds.Tables(0).Rows(0).Item("in_out")) = "2" Then
                txtinout.Text = "O"
            End If
            txtbillnm.Text = Trim(ds.Tables(0).Rows(0).Item("bname"))
            txtadd.Text = lbladdress.Text
            txtmob.Text = Trim(ds.Tables(0).Rows(0).Item("cont1"))
        End If
    End Sub

    Private Sub item_view()
        Dim ds As DataSet = get_dataset("SELECT item.descri, item.gp_cd, item.tax_stl,item.prd_tp, item.ptx_cd, item.mrp, item.pur_rate,item.sale_rate1,item.sale_rate2,item.sale_rate3,item.sale_rate4, item.unt1, item.multi1, item.cl_stk,item.dcl_stk,item.bat_cnf, itgrp.gp_nm, taxper.taxcat,taxper.tax1, taxper.txname FROM item LEFT OUTER JOIN taxper ON item.ptx_cd = taxper.taxcd LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd WHERE item.it_cd=" & Val(txtitemcd.Text) & "")
        If ds.Tables(0).Rows.Count <> 0 Then
            cmbunit.Text = ds.Tables(0).Rows(0).Item("unt1")
            txttaxcd.Text = ds.Tables(0).Rows(0).Item("ptx_cd")
            'txttaxper1.Text = ds.Tables(0).Rows(0).Item("tax1")
            'taxper = Val(ds.Tables(0).Rows(0).Item("txname"))
            cmbcgst.Text = ds.Tables(0).Rows(0).Item("txname")
            cmbsgst.Text = "0"
            If txtinout.Text = "I" Then
                cmbcgst.Text = Val(ds.Tables(0).Rows(0).Item("tax1")) / 2
                cmbsgst.Text = Val(ds.Tables(0).Rows(0).Item("tax1")) / 2
            End If
            txtrealmrp.Text = Val(ds.Tables(0).Rows(0).Item("mrp"))
            lbldescri.Text = Trim(ds.Tables(0).Rows(0).Item("descri"))
            lblgrp.Text = Trim(ds.Tables(0).Rows(0).Item("gp_nm"))
            lblpurrt.Text = Format(ds.Tables(0).Rows(0).Item("pur_rate"), "######0.00")
            If Val(txtprtcat.Text) = 1 Then
                txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("sale_rate1"))
            ElseIf Val(txtprtcat.Text) = 2 Then
                txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("sale_rate2"))
            ElseIf Val(txtprtcat.Text) = 3 Then
                txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("sale_rate3"))
            ElseIf Val(txtprtcat.Text) = 4 Then
                txtrealrt.Text = Val(ds.Tables(0).Rows(0).Item("sale_rate4"))
            End If
            txtsndstk.Text = Val(ds.Tables(0).Rows(0).Item("cl_stk"))
            txtdmgstk.Text = Val(ds.Tables(0).Rows(0).Item("dcl_stk"))
            txtbatcnfr.Text = ds.Tables(0).Rows(0).Item("bat_cnf")
            txttaxstl.Text = ds.Tables(0).Rows(0).Item("tax_stl")
            txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
            item_type = ds.Tables(0).Rows(0).Item("prd_tp") 'Item Saleble or Not 
            If txtbatcnfr.Text = "B" Then
                cmbbatch.Enabled = True
                cmbbatch.Text = ""
            Else
                cmbbatch.Enabled = False
                cmbbatch.Text = "X"
            End If
        End If
    End Sub

#End Region
    Private Sub txtrate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrate.Validated
        txtrealrt.Text = txtrate.Text
        If chksetcalcrt.Checked = True Then
            purrt = Val(txtrate.Text)
            purrt = Val(purrt / (100 + Val(txttaxper1.Text)) * 100)
            txtrate.Text = Format(Val(purrt), "########0.00")
        End If
        Me.dv_calc()
    End Sub

    Private Sub txtvat_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcgst.Validated, txtmrp.Validated, txtacharg.Validated, txtadisc.Validated
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
        Dim dsdel As DataSet = get_dataset("SELECT bill_no,prt_code,sale_amt,inv_tp,bill_tp,ch_no FROM csale1 WHERE bill_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            prtcd = dsdel.Tables(0).Rows(0).Item(1)
            toamt = dsdel.Tables(0).Rows(0).Item(2)
            invtp = dsdel.Tables(0).Rows(0).Item(3)
            bltp = dsdel.Tables(0).Rows(0).Item(4)
            chno = dsdel.Tables(0).Rows(0).Item(5)
            If bltp = "2" Then
                SQLInsert("UPDATE party SET dr_amt=dr_amt - " & Val(toamt) & ",cl_amt=cl_amt + " & Val(toamt) & " WHERE prt_code=" & Val(prtcd) & "")
            End If
            If invtp = "R" Then
                SQLInsert("DELETE FROM rinbill WHERE bill_no=" & Val(code) & "")
            Else
                SQLInsert("DELETE FROM tinbill WHERE bill_no=" & Val(code) & "")
            End If
            SQLInsert("DELETE FROM schal1 WHERE sch_no=" & Val(chno) & "")
            SQLInsert("DELETE FROM csale1 WHERE bill_no=" & Val(code) & "")
        End If
    End Sub

    'Delete data from Table2/Secondary Table
    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT bill_sl,sale_qty,it_cd ,bat_cd,ch_sl,free_qty,mul_rt,prd_tp,tr_tp,item_tp FROM csale2 WHERE bill_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                pursl = dsdel.Tables(0).Rows(i).Item(0)
                pqty = Val(dsdel.Tables(0).Rows(i).Item(1))
                itcd = dsdel.Tables(0).Rows(i).Item(2)
                batcd = dsdel.Tables(0).Rows(i).Item(3)
                schsl = dsdel.Tables(0).Rows(i).Item(4)
                frqt = Val(dsdel.Tables(0).Rows(i).Item(5))
                mulrt = Val(dsdel.Tables(0).Rows(i).Item(6))
                prdtp = Val(dsdel.Tables(0).Rows(i).Item(7))
                trtp = Val(dsdel.Tables(0).Rows(i).Item(8))
                item_type = dsdel.Tables(0).Rows(i).Item(9)
                If item_type = "1" Then 'If 1=Saleble item then update the Stock
                    itqt = (pqty * mulrt) + (frqt * mulrt)
                    stock_OUTDEL(itqt, itcd, batcd, prdtp, trtp)
                End If
                Dim ds2 As DataSet = get_dataset("SELECT sl_slno FROM sale_slno WHERE bill_sl=" & pursl & "")
                If ds2.Tables(0).Rows.Count <> 0 Then
                    For m As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                        slno = ds2.Tables(0).Rows(m).Item(0)
                        SQLInsert("UPDATE mast_slno SET io_pos='I' WHERE sl_slno =" & slno & "")
                        SQLInsert("DELETE FROM sale_slno WHERE sl_slno =" & slno & "")
                    Next
                End If
                SQLInsert("DELETE FROM schal2 WHERE sch_sl=" & Val(schsl) & "")
                SQLInsert("DELETE FROM csale2 WHERE bill_sl=" & Val(pursl) & "")
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
            Me.Text = "Cash / Credit Sales Modification Screen . . ."
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
                    Call del2(slno)
                    Call del1(slno)
                End If
                Close1()
                Me.dv_disp()
            Else
                MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub smnuprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuprint.Click
        If dv.SelectedRows.Count <> 0 Then
            slno = dv.SelectedRows(0).Cells(0).Value
            Start1()
            Call sale_print(slno)
            Close1()
        Else
            frmno = 1
            frmprnt.MdiParent = MDI
            frmprnt.Show()
        End If
    End Sub

    Private Sub txtscroll_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtscroll.Validated
        If comd <> "E" Then
            If txtscroll.Text <> "" Then
                Dim ds As DataSet = get_dataset("SELECT bill_no FROM csale1 WHERE bill_no=" & Val(txtscroll.Text) & " ")
                If ds.Tables(0).Rows.Count <> 0 Then
                    Me.dv_edit(txtscroll.Text)
                Else
                    MessageBox.Show("Please Select A Valid Scroll No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    'Private Sub txtfree_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfree.Validated
    '    If cmbtr.SelectedIndex = 1 And Val(txtfree.Text) < 0 Then
    '        txtfree.Text = Val(txtfree.Text) * (-1)
    '    End If
    '    Me.dv_calc()
    'End Sub

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
        chksetprnt.Checked = False
        chksetchal.Checked = False
        Dim ds As DataSet = get_dataset("SELECT * FROM setting_sales WHERE slno=1")
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
            If ds.Tables(0).Rows(0).Item("req_chal") = 1 Then
                chksetchal.Checked = True
            End If
            If ds.Tables(0).Rows(0).Item("req_prnt") = 1 Then
                chksetprnt.Checked = True
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
            txtcgst.Enabled = True
            txtsgst.Enabled = True
            cmbcgst.Enabled = True
            cmbsgst.Enabled = True
        Else
            txtcgst.Enabled = False
            txtsgst.Enabled = False
            cmbcgst.Enabled = False
            cmbsgst.Enabled = False
        End If
        If chksetchal.Checked = True Then
            txtchno.Enabled = True
            chdt.Enabled = True
            Dim ds As DataSet = get_dataset("SELECT max(sch_no) as 'Max' FROM schal1")
            txtchno.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtchno.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
        Else
            txtchno.Text = "0"
            chdt.Value = invdt.Value
            txtchno.Enabled = False
            chdt.Enabled = False
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

    Private Sub chksetchal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetchal.CheckedChanged
        Me.Set_chang()
    End Sub

    Private Sub cmbbilltp_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbilltp.Validated
        Me.Set_chang()
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


    Private Sub btnestimate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnestimate.Click
        Start1()
        SQLInsert("DELETE FROM print_salebill WHERE usr_sl=" & usr_sl & "")
        'ds1 = get_dataset("SELECT staf.short_nm,drvmst.drv_snm,drvmst.mob_no, party.lst_no,party.cl_amt, csale1.* FROM csale1 LEFT OUTER JOIN drvmst ON csale1.drv_cd = drvmst.drv_cd LEFT OUTER JOIN party ON csale1.prt_code = party.prt_code LEFT OUTER JOIN staf ON csale1.staf_sl = staf.staf_sl WHERE (csale1.bill_no = " & Val(blno) & ")")
        If dv1.Rows.Count <> 0 Then
            bill_tp = "Cash"
            invtp = "Estimation Slip"
            inv_no = txtinvno.Text
            If vb.Left(cmbbilltp.Text, 1) = "2" Then
                bill_tp = "Credit"
            End If
            If Val(txtprtcd.Text) <> 0 Then
                prtbal = lblprtbal.Text
            End If
            'If ds1.Tables(0).Rows(0).Item("prt_code") <> 0 Then
            '    clamt = Val(ds1.Tables(0).Rows(0).Item("cl_amt"))
            '    If clamt < 0 Then
            '        prtbal = "Cur.Bal. : " & Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
            '    Else
            '        prtbal = "Cur.Bal. : " & Format(clamt, "#######0.00") & " " & "Cr."
            '    End If
            'End If
            inv_tp = invtp & "( " & bill_tp & " )"
            bill_no = txtscroll.Text
            bill_dt = invdt.Value
            ch_no = txtchno.Text
            ch_dt = chdt.Value
            order_no = txtordno.Text
            order_dt = orddt.Value
            ref_no = txtrefno.Text
            bl_name = txtbillnm.Text
            add1 = txtadd.Text
            mobno = txtmob.Text
            regd_no = lblregdno.Text
            sold_by = cmbstaf.Text
            tot_tto = lbltto.Text
            tot_vat = lblcgsttot.Text
            sale_amt = txtgrtotal.Text
            dis_amt = txtdiscamt.Text
            chr_amt = txtchargamt.Text
            dv_tot = lbltotal.Text
            adj_amt = txtadj.Text
            nb = prtbal & " " & txtnb.Text & "."
            If conb <> "" Then
                nb = nb & conb
            End If
            splnb = txtnb.Text
            way_bno = txtwaypfx.Text & txtwbno.Text
            drv_nm = cmbdrvr.Text
            drv_mob = ""
            inwords = RupeesToWord(sale_amt)
            'ds2 = get_dataset("SELECT batno.bat_no, item.it_name, taxper.txname, manf.manf_snm, csale2.* FROM manf RIGHT OUTER JOIN item ON manf.manf_cd = item.manf_cd RIGHT OUTER JOIN csale2 LEFT OUTER JOIN taxper ON csale2.tax_cd = taxper.taxcd LEFT OUTER JOIN batno ON csale2.bat_cd = batno.bat_cd ON item.it_cd = csale2.it_cd WHERE (csale2.bill_no = " & Val(blno) & ")")
            'If ds2.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.Rows.Count - 1
                it_cd = dv1.Rows(i).Cells(23).Value
                it_nm = dv1.Rows(i).Cells(2).Value
                manf_nm = ""
                bat_no = ""
                If Val(txtbatcd.Text) <> 0 Then
                    bat_no = "(B.No:- " & dv1.Rows(i).Cells(3).Value & ")"
                End If
                srl_no = "" 'ds2.Tables(0).Rows(i).Item("srl_no")
                sale_qty = dv1.Rows(i).Cells(6).Value
                free_qty = dv1.Rows(i).Cells(7).Value
                mrp = dv1.Rows(i).Cells(8).Value
                sale_rt = dv1.Rows(i).Cells(9).Value
                it_tot = dv1.Rows(i).Cells(24).Value
                disc_rt1 = dv1.Rows(i).Cells(11).Value
                disc_rt2 = dv1.Rows(i).Cells(13).Value
                disc_amt1 = dv1.Rows(i).Cells(12).Value
                disc_amt2 = dv1.Rows(i).Cells(14).Value
                oth_amt = dv1.Rows(i).Cells(23).Value
                disc_amt = dv1.Rows(i).Cells(22).Value
                unt = dv1.Rows(i).Cells(5).Value
                mul_rt = dv1.Rows(i).Cells(29).Value
                it_amt = dv1.Rows(i).Cells(10).Value
                tto_amt = dv1.Rows(i).Cells(16).Value
                tax_nm = dv1.Rows(i).Cells(17).Value
                stax = dv1.Rows(i).Cells(19).Value
                exmrp = Val(dv1.Rows(i).Cells(25).Value)
                mrp_amt = Val(exmrp) * (Val(sale_qty) + Val(free_qty))
                'Dim dssl As DataSet = get_dataset("SELECT mast_slno.slno FROM sale_slno LEFT OUTER JOIN mast_slno ON sale_slno.sl_slno = mast_slno.sl_slno WHERE (sale_slno.bill_no = " & Val(blno) & ") AND (sale_slno.it_cd = " & Val(it_cd) & ")")
                If dvsl1.Rows.Count <> 0 Then
                    For sl As Integer = 0 To dvsl1.Rows.Count - 1
                        If srl_no = "" Then
                            srl_no = dvsl1.Rows(sl).Cells(1).Value
                        Else
                            srl_no = srl_no & "," & dvsl1.Rows(sl).Cells(1).Value
                        End If
                    Next
                    srl_no = "(Sl.:- " & srl_no & ")"
                End If

                Dim ds As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM print_salebill")
                mxno = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO print_salebill(slno,bill_no,bill_dt,inv_no,inv_tp,ch_no,ch_dt,order_no,order_dt,ref_no,bl_name,add1," & _
                          "mobno,regd_no,sold_by,it_nm,bat_no,srl_no,sale_qty,free_qty,mrp,sale_rt,it_tot,disc_rt1,disc_rt2,disc_amt1,disc_amt2," & _
                          "oth_amt,disc_amt,unt,mul_rt,it_amt,tto_amt,tax_nm,stax,mrp_amt,tot_tto,tot_vat,sale_amt,dis_amt,chr_amt,dv_tot,adj_amt," & _
                          "nb,splnb,way_bno,inwords,usr_sl,usr_id,manf_nm,drv_nm,drv_mob) VALUES (" & mxno & " , " & Val(bill_no) & " , '" & bill_dt & "'   , '" & _
                            inv_no & "'  , '" & (inv_tp) & "'  , " & Val(ch_no) & "  , '" & ch_dt & "'  , " & Val(order_no) & "  , '" & _
                            order_dt & "'  , '" & ref_no & "'  , '" & bl_name & "'  , '" & add1 & "'  , '" & mobno & "'  , '" & regd_no & "'  , '" & _
                            sold_by & "'  , '" & it_nm & "'  , '" & bat_no & "'  , '" & srl_no & "'  , " & Val(sale_qty) & "  , " & _
                            Val(free_qty) & "  , " & Val(mrp) & "  , " & Val(sale_rt) & "  , " & Val(it_tot) & "  , " & Val(disc_rt1) & "  , " & _
                            Val(disc_rt2) & "  , " & Val(disc_amt1) & "  , " & Val(disc_amt2) & "  , " & Val(oth_amt) & "  , " & Val(disc_amt) & "  , '" & _
                            unt & "'  , " & Val(mul_rt) & "  , " & Val(it_amt) & "  , " & Val(tto_amt) & "  , '" & tax_nm & "'  , " & Val(stax) & "  , " & _
                            Val(mrp_amt) & "  , " & Val(tot_tto) & "  , " & Val(tot_vat) & "  , " & Val(sale_amt) & "  , " & Val(dis_amt) & "  , " & _
                            Val(chr_amt) & "  , " & Val(dv_tot) & "  , " & Val(adj_amt) & "  , '" & nb & "'  , '" & splnb & "'  , '" & way_bno & "'  , '" & _
                            inwords & "'  , " & Val(usr_sl) & "  , '" & usr_nm & "', '" & manf_nm & "','" & drv_nm & "','" & drv_mob & "')")


            Next
            'End If
        Else
            MessageBox.Show("Nothing To Estimate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Printin Of Estimation
        If printbill = 1 Then ' Windows Print Sale Bill Default Half Page
            reportnm = "salebillHF.rpt"
        ElseIf printbill = 2 Then ' Windows Print  Sale Bill Default Full Page
            reportnm = "salebillFL.rpt"
        ElseIf printbill = 3 Then ' Windows Print  Sale Bill Default Half Page & Full Page When Item No More Then 10
            Dim ds As DataSet = get_dataset("SELECT COUNT(slno) as 'Cntno' FROM print_salebill")
            If Val(ds.Tables(0).Rows(0).Item(0)) < 10 Then
                reportnm = "salebillHF.rpt"
            Else
                reportnm = "salebillFL.rpt"
            End If
        Else
            reportnm = "salebillHF.rpt"
        End If
        Call disp_repo()
        'For i As Integer = 0 To copybill
        '    'Call print_repo()
        'Next
        Close1()
    End Sub

    Private Sub txtinout_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtinout.TextChanged
        If txtinout.Text = "O" Then
            lblgst.Text = "%   IGST Amt."
            txtsgst.Text = "0.00"
            cmbsgst.Text = ""
            txtsgst.Enabled = False
            cmbsgst.Enabled = False
            Label40.Text = "IGST"
        Else
            lblgst.Text = "%   CGST Amt."
            Label40.Text = "CGST"
        End If
    End Sub
End Class
