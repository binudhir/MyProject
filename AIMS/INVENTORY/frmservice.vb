Imports vb = Microsoft.VisualBasic
Public Class frmservice
    Dim comd As String = "E"
    Dim item_type As String = "1"
    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point
#Region "Start Up"
    Private Sub frmservice_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuservice.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmservice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmservice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Width = Screen.PrimaryScreen.Bounds.Width
        'Me.Height = Screen.PrimaryScreen.Bounds.Height
        'Me.Dock = DockStyle.Fill
        MDI.mnuservice.Enabled = False
        Me.clr()
        cmbbilltp.SelectedIndex = 1
        Dim ds1 As DataSet = get_dataset("SELECT srv_pfx  FROM serv1 ORDER BY srv_no DESC")
        If ds1.Tables(0).Rows.Count <> 0 Then
            txtpfx.Text = ds1.Tables(0).Rows(0).Item(0)
        End If
        Me.Set_view()
    End Sub

    Private Sub frmservice_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black
        End If
    End Sub

    Private Sub clr()
        lblamount.Text = "0.00"
        lblcgsttot.Text = "0.00"
        lblsgsttot.Text = "0.00"
        lbladisc.Text = "0.00"
        lblachrg.Text = "0.00"
        lbltotal.Text = "0.00"
        lbldescri.Text = ""
        lblgrp.Text = ""
        cmbstaf.Text = ""
        txtstafcd.Text = 0
        txtpfx.Text = "SRV"
        txtrefno.Text = "X"
        txtrealmrp.Text = 0
        txtrealrt.Text = 0
        txttaxcat.Text = "1"
        dvtrans.DataSource = Nothing
        cmbproduct.Text = ""
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
        paydt.Value = sys_date
        invdt.Value = sys_date
        dv1.Rows.Clear()
        'Others
        txtordno.Text = ""
        orddt.Value = sys_date
        cmbdrvr.Text = ""
        txtdrvcd.Text = 0
        txtvehno.Text = ""
        txtlrno.Text = ""
        txtwaypfx.Text = ""
        txtwbno.Text = ""
        lrdt.Value = sys_date
        If comd = "E" Then
            Dim ds As DataSet = get_dataset("SELECT max(srv_no) as 'Max' FROM serv1")
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
            Me.Text = "Cash / Credit Service Modification Screen...."
            txtscroll.Text = ""
            txtinvno.Text = ""
            btnsave.Text = "Modify"
        Else
            Me.Text = "Cash / Credit Service Deletion Screen...."
            txtscroll.Text = ""
            txtinvno.Text = ""
            btnsave.Text = "Delete"
        End If
        Me.prtclr()
        Me.clr1()
        Me.Set_chang()
    End Sub

    Private Sub prtclr()
        txtprtcd.Text = 0
        txtinout.Text = "I"
        lbltrlmt.Text = "0.00 Cr."
        lblmarket.Text = ""
        lblregdno.Text = ""
        lblinvtp.Text = "Service Invoice"
        txtmob.Text = ""
        txtadd.Text = ""
        txtbillnm.Text = ""
        lbladdress.Text = ""
        lblprtbal.Text = "0.00 Cr."
        prtbal = lblprtbal.Text
    End Sub

    Private Sub clr1()
        item_type = "1"
        cmbproduct.Text = ""
        txtquantity.Text = "0.00"
        txtrate.Text = "0.00"
        txtamount.Text = "0.00"
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

    Private Sub rintin_bill()
        Dim ds As DataSet
        ds = get_dataset("SELECT max(inv_bno) as 'Max' FROM serv1 WHERE srv_pfx='" & Trim(txtpfx.Text) & "'")
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

    Private Sub sender_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscroll.Enter, txtslno.Enter, txtquantity.Enter, txtprtcd.Enter, txtrate.Enter, txtamount.Enter, txtcgst.Enter, txtsgst.Enter, txtadisc.Enter, txtacharg.Enter, txttotal.Enter, txtnb.Enter, txtchargamt.Enter, txtadisc.Enter, cmbparty.Enter, cmbproduct.Enter, cmbbilltp.Enter, cmbcgst.Enter, cmbsgst.Enter, paydt.Enter, invdt.Enter, txtinvno.Enter, txtvehno.Enter, txtlrno.Enter, txtwaypfx.Enter, txtwbno.Enter, cmbunit.Enter, txtdiscamt.Enter, txtmob.Enter, txtadd.Enter, txtbillnm.Enter, cmbstaf.Enter, txtpfx.Enter, txtrefno.Enter, txtordno.Enter, cmbdrvr.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscroll.Leave, txtslno.Leave, txtquantity.Leave, txtprtcd.Leave, txtrate.Leave, txtamount.Leave, txtcgst.Leave, txtsgst.Leave, txtadisc.Leave, txtacharg.Leave, txttotal.Leave, txtnb.Leave, txtchargamt.Leave, txtadisc.Leave, cmbparty.Leave, cmbproduct.Leave, cmbbilltp.Leave, cmbcgst.Leave, cmbsgst.Leave, paydt.Leave, invdt.Leave, txtinvno.Leave, txtvehno.Leave, txtlrno.Leave, txtwaypfx.Leave, txtwbno.Leave, cmbunit.Leave, txtdiscamt.Leave, txtmob.Leave, txtadd.Leave, txtbillnm.Leave, cmbstaf.Leave, txtpfx.Leave, txtrefno.Leave, txtordno.Leave, cmbdrvr.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub
#End Region

#Region "Mouse Enter/Leave"

    Private Sub sender_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnxt.MouseEnter, btnsave.MouseEnter, btnset.MouseEnter, btninter.MouseEnter, btnref.MouseEnter, btnprint.MouseEnter, btnview.MouseEnter, btnothers.MouseEnter, btnexit.MouseEnter, btnabort.MouseEnter, btnfresh1.MouseEnter, btnok.MouseEnter, btnsetabrt.MouseEnter, btnsetaply.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnxt.MouseLeave, btnsave.MouseLeave, btnset.MouseLeave, btninter.MouseLeave, btnref.MouseLeave, btnprint.MouseLeave, btnview.MouseLeave, btnothers.MouseLeave, btnexit.MouseLeave, btnabort.MouseLeave, btnfresh1.MouseLeave, btnok.MouseLeave, btnsetabrt.MouseLeave, btnsetaply.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub chksetmep_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetvat.MouseEnter, chksetrate.MouseEnter, chksetdisc.MouseEnter, chksetblrnd.MouseEnter
        sender.forecolor = Color.Blue
    End Sub

    Private Sub chksetmep_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksetvat.MouseLeave, chksetrate.MouseLeave, chksetdisc.MouseLeave, chksetblrnd.MouseLeave
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
        key(txtrefno, e)
        SPKey(e)
    End Sub

    Private Sub txtrefno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrefno.KeyPress
        key(paydt, e)
        SPKey(e)
    End Sub

    Private Sub paydt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles paydt.KeyPress
        key(cmbstaf, e)
    End Sub

    Private Sub cmbstaf_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstaf.KeyPress
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

    Private Sub cmbproduct_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbproduct.KeyPress
        If cmbproduct.Text = "" Then
            key(txtnb, e)
        Else
          key(cmbunit, e)
        End If
        SPKey(e)
    End Sub

    Private Sub cmbunit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunit.KeyPress
        key(txtquantity, e)
        SPKey(e)
    End Sub

    Private Sub txtquantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtquantity.KeyPress
        key(txtrate, e)
        NUM1(e)
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        If cmbcgst.Enabled = True Then
            key(cmbcgst, e)
        ElseIf txtadisc.Enabled = True Then
            key(txtadisc, e)
        Else
            key(btnnxt, e)
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

#End Region

    Private Sub txtquantity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquantity.GotFocus
        If Val(sender.Text) = 0 Then
            sender.Text = ""
        End If
    End Sub

    Private Sub txtquantity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquantity.LostFocus
        sender.Text = Format(Val(sender.Text), "########0.00")
    End Sub

    Private Sub txtmrp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.GotFocus, txtamount.GotFocus, txtadisc.GotFocus, txtacharg.GotFocus, txttotal.GotFocus, txtchargamt.GotFocus, txtdiscamt.GotFocus, txtadj.GotFocus, txtgrtotal.GotFocus
        If Val(sender.Text) = 0 Then
            sender.Text = ""
        End If
    End Sub

    Private Sub txtmrp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.LostFocus, txtamount.LostFocus, txtadisc.LostFocus, txtacharg.LostFocus, txttotal.LostFocus, txtchargamt.LostFocus, txtdiscamt.LostFocus, txtadj.LostFocus, txtgrtotal.LostFocus
        sender.Text = Format(Val(sender.Text), "########0.00")
    End Sub

    Private Sub txtbillnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbillnm.LostFocus
        If Trim(txtbillnm.Text) = "" Then
            txtbillnm.Text = "Cash Service"
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
            lblinvtp.Text = "Service Invoice"
            txtbillnm.Text = "Cash Service."
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
        populate(cmbproduct, "SELECT it_name FROM item WHERE (rec_lock = 'N') AND (prd_tp='3') ORDER BY it_name")
    End Sub

    Private Sub cmbproduct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.LostFocus
        cmbproduct.Height = 21
    End Sub

    Private Sub cmbproduct_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbproduct.Validated
        Dim ds As DataSet = get_dataset("SELECT item.it_cd FROM item WHERE it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtitemcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            Me.item_view()
            Me.dv_calc()
            If Val(txtprtcd.Text) <> 0 Or Val(txtitemcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
    End Sub

    Private Sub cmbproduct_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbproduct.Validating
        vdating(cmbproduct, "SELECT it_name FROM item WHERE rec_lock='N' AND it_name= '" & Trim(cmbproduct.Text) & "' AND (prd_tp='3')", "Please Select a Valid Service Name.")
    End Sub

    Private Sub cmbproduct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.TextChanged
        Dim ds As DataSet = get_dataset("SELECT item.it_cd FROM item WHERE it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtitemcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            Me.item_view()
            Me.dv_calc()
            If Val(txtprtcd.Text) <> 0 Or Val(txtitemcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
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
    End Sub

    Private Sub cmbunit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.TextChanged
        Dim ds As DataSet = get_dataset("SELECT * FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitemcd.Text) & ") AND unt.unt_nm='" & Trim(cmbunit.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtuntcd.Text = ds.Tables(0).Rows(0).Item("unt_cd")
            txtmulrt.Text = ds.Tables(0).Rows(0).Item("mul_rt")
        End If
        Me.dv_calc()
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
        SQLInsert("UPDATE setting_service SET req_rate=" & IIf(chksetrate.Checked, 1, 0) & ",req_disc=" & _
                  IIf(chksetdisc.Checked, 1, 0) & ",req_vat=" & IIf(chksetvat.Checked, 1, 0) & ",bill_rnd=" & _
                  IIf(chksetblrnd.Checked, 1, 0) & ",req_prnt=" & IIf(chksetprnt.Checked, 1, 0) & " WHERE slno=1")
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
        txtvehno.Text = ""
        txtlrno.Text = ""
        txtwaypfx.Text = ""
        txtwbno.Text = ""
        lrdt.Value = sys_date
        other_panel.Visible = False
    End Sub

    Private Sub btnfresh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfresh1.Click
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
        setting_panel.Size = New Size(334, 201)
        setting_panel.Location = New Point(142, 145)
        setting_panel.Visible = True
    End Sub

    Private Sub btnprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprint.Click
        frmno = 9
        frmprnt.MdiParent = MDI
        frmprnt.Show()
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
        If Trim(cmbstaf.Text) = "" Or Val(txtstafcd.Text) = 0 Then
            MessageBox.Show("Sorry The Service By Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbstaf.Focus()
            Exit Sub
        End If

        If dv1.Rows.Count = 0 Then
            MessageBox.Show("Please Enter At least one item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If


        Me.service_save()
    End Sub

    Private Sub btnnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.Click
        If Trim(cmbproduct.Text) = "" Or Val(txtitemcd.Text) = 0 Then
            MessageBox.Show("Please Provide A Service Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If
        If Val(txtquantity.Text) = 0 Then
            MessageBox.Show("Sorry The Quantity Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtquantity.Focus()
            Exit Sub
        End If
        If Val(txtrate.Text) = 0 Then
            MessageBox.Show("Sorry The Service Price Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtrate.Focus()
            Exit Sub
        End If

        sl1 = Val(txtslno.Text)
        dv1.Rows.Add()
        dv1.Rows(sl1 - 1).Cells(0).Value = sl1
        dv1.Rows(sl1 - 1).Cells(1).Value = cmbproduct.Text
        dv1.Rows(sl1 - 1).Cells(2).Value = cmbunit.Text
        dv1.Rows(sl1 - 1).Cells(3).Value = txtquantity.Text
        dv1.Rows(sl1 - 1).Cells(4).Value = txtrate.Text
        dv1.Rows(sl1 - 1).Cells(5).Value = txtamount.Text
        dv1.Rows(sl1 - 1).Cells(6).Value = cmbcgst.Text
        dv1.Rows(sl1 - 1).Cells(7).Value = txtcgst.Text
        dv1.Rows(sl1 - 1).Cells(8).Value = cmbsgst.Text
        dv1.Rows(sl1 - 1).Cells(9).Value = txtsgst.Text
        dv1.Rows(sl1 - 1).Cells(10).Value = txtadisc.Text
        dv1.Rows(sl1 - 1).Cells(11).Value = txtacharg.Text
        dv1.Rows(sl1 - 1).Cells(12).Value = txttotal.Text
        dv1.Rows(sl1 - 1).Cells(13).Value = txtitemcd.Text
        dv1.Rows(sl1 - 1).Cells(14).Value = txttaxcd.Text
        dv1.Rows(sl1 - 1).Cells(15).Value = txtmulrt.Text
        dv1.Rows(sl1 - 1).Cells(16).Value = 0
        sl1 += 1
        txtslno.Text = sl1
        Start1()
        If chksetrate.Checked = True Then
            pur_rt = Val(txtrealrt.Text) / Val(txtmulrt.Text)
            SQLInsert("UPDATE item SET sale_rate1=" & pur_rt & " WHERE it_cd=" & Val(txtitemcd.Text) & "")
        End If
        Close1()
        cmbproduct.Focus()
        Me.grandamt(dv1)
        Me.clr1()
    End Sub
#End Region

#Region "Data save"
    Private Sub service_save()
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
                Dim ds As DataSet = get_dataset("SELECT MAX(srv_no) AS MAX FROM serv1")
                txtscroll.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO serv1 (srv_no,srv_dt,pay_dt,bill_tp,srv_pfx,inv_bno,inv_tp,prt_code,staf_sl," & _
                          "order_no,order_dt,trk_no,way_bno,way_pfx,lr_no,lr_dt,srv_amt,dis_amt,chr_amt,dv_tot,adj_amt,bl_name,ref_no,nb," & _
                          "usr_ent,ent_date,usr_mod,mod_date,used_by,rec_lock,tot_vat,splnb,mobno,add1,drv_cd,cgsttot,sgsttot,igsttot,tot_tto) VALUES (" & _
                          Val(txtscroll.Text) & ",'" & Format(invdt.Value, "dd/MMM/yyyy") & "','" & Format(paydt.Value, "dd/MMM/yyyy") & "','" & vb.Left(cmbbilltp.Text, 1) & "','" & _
                          Trim(txtpfx.Text) & "'," & Val(txtinvno.Text) & ",'" & vb.Left(lblinvtp.Text, 1) & "'," & _
                          Val(txtprtcd.Text) & ",'" & Trim(txtstafcd.Text) & "','" & Trim(txtordno.Text) & "','" & _
                          Format(orddt.Value, "dd/MMM/yyyy") & "','" & Trim(txtvehno.Text) & "'," & _
                          Val(txtwbno.Text) & ",'" & Trim(txtwaypfx.Text) & "','" & Trim(txtlrno.Text) & "','" & _
                          Format(lrdt.Value, "dd/MMM/yyyy") & "'," & Val(txtgrtotal.Text) & "," & Val(txtdiscamt.Text) & "," & _
                          Val(txtchargamt.Text) & "," & Val(lbltotal.Text) & "," & Val(txtadj.Text) & ",'" & Trim(txtbillnm.Text) & "','" & _
                          Trim(txtrefno.Text) & "','" & Trim(txtnb.Text) & "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & _
                          Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N','N'," & _
                          Val(lblcgsttot.Text) & ",'" & Trim(txtnb.Text) & "','" & Trim(txtmob.Text) & "','" & _
                          Trim(txtadd.Text) & "'," & Val(txtdrvcd.Text) & "," & cgst & "," & Val(lblsgsttot.Text) & "," & igst & ",0)")
                Me.dv_save()
                If cmbbilltp.SelectedIndex = 1 Then
                    SQLInsert("UPDATE party SET dr_amt=dr_amt + " & Val(txtgrtotal.Text) & ",cl_amt=cl_amt - " & Val(txtgrtotal.Text) & " WHERE prt_code=" & Val(txtprtcd.Text) & "")
                End If
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If chksetprnt.Checked = True Then
                    cnfr = MessageBox.Show("Are You Sure The Printer is Ready To Print The Bill.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If cnfr = vbYes Then
                        Call service_print(Val(txtscroll.Text))
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
                Dim ds As DataSet = get_dataset("SELECT srv_no FROM serv1 WHERE srv_no=" & Val(txtscroll.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE serv1 SET srv_dt='" & Format(invdt.Value, "dd/MMM/yyyy") & "',bill_tp='" & _
                              vb.Left(cmbbilltp.Text, 1) & "', srv_pfx='" & Trim(txtpfx.Text) & "', inv_tp='" & _
                              vb.Left(lblinvtp.Text, 1) & "',pay_dt='" & Format(paydt.Value, "dd/MMM/yyyy") & "', prt_code=" & Val(txtprtcd.Text) & ", staf_sl='" & _
                              Trim(txtstafcd.Text) & "', order_no='" & Trim(txtordno.Text) & "', order_dt='" & Format(orddt.Value, "dd/MMM/yyyy") & "', trk_no='" & _
                              Trim(txtvehno.Text) & "', way_bno=" & Val(txtwbno.Text) & ", way_pfx='" & Trim(txtwaypfx.Text) & "', lr_no='" & _
                              Trim(txtlrno.Text) & "', lr_dt='" & Format(lrdt.Value, "dd/MMM/yyyy") & "', srv_amt=" & _
                              Val(txtgrtotal.Text) & ", dis_amt=" & Val(txtdiscamt.Text) & ", chr_amt=" & Val(txtchargamt.Text) & ", dv_tot=" & _
                              Val(lbltotal.Text) & ", adj_amt=" & Val(txtadj.Text) & ", bl_name='" & Trim(txtbillnm.Text) & "', ref_no='" & _
                              Trim(txtrefno.Text) & "', nb='" & Trim(txtnb.Text) & "', usr_mod=" & Val(usr_sl) & ", mod_date='" & _
                              Format(Now, "dd/MMM/yyyy HH:mm:ss") & "', tot_vat=" & _
                              Val(lblcgsttot.Text) & ",cgsttot=" & cgst & ",sgsttot=" & Val(lblsgsttot.Text) & ",igsttot=" & igst & ", splnb='" & Trim(txtnb.Text) & "', mobno='" & _
                              Trim(txtmob.Text) & "', add1='" & Trim(txtadd.Text) & "',drv_cd=" & Val(txtdrvcd.Text) & " WHERE srv_no =" & Val(txtscroll.Text) & "")
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
                unt = dv1.Rows(i).Cells(2).Value
                qty = Val(dv1.Rows(i).Cells(3).Value)
                it_rt = Val(dv1.Rows(i).Cells(4).Value)
                amt = Val(dv1.Rows(i).Cells(5).Value)
                cgst = Val(dv1.Rows(i).Cells(6).Value)
                cgstamt = Val(dv1.Rows(i).Cells(7).Value)
                sgst = Val(dv1.Rows(i).Cells(8).Value)
                sgstamt = Val(dv1.Rows(i).Cells(9).Value)
                If txtinout.Text = "O" Then
                    cgst = 0
                    cgstamt = 0
                    igst = Val(dv1.Rows(i).Cells(6).Value)
                    igstamt = Val(dv1.Rows(i).Cells(7).Value)
                End If
                adisc = Val(dv1.Rows(i).Cells(10).Value)
                achrg = Val(dv1.Rows(i).Cells(11).Value)
                total = Val(dv1.Rows(i).Cells(12).Value)
                itcd = Val(dv1.Rows(i).Cells(13).Value)
                taxcd = Val(dv1.Rows(i).Cells(14).Value)
                mulrt = Val(dv1.Rows(i).Cells(15).Value)
                Dim ds1 As DataSet = get_dataset("SELECT max(srv_sl) as 'Max' FROM serv2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                mxsl = 0
                SQLInsert("INSERT INTO serv2(srv_sl,srv_no,srv_dt,bill_tp,inv_bno,prt_code,it_cd,srv_qty," & _
                          "srv_rt,disc_amt,it_tot,srv_pfx,unt,it_amt,mul_rt," & _
                          "tax_cd,stax,chrg_amt,cgstper,cgstamt,sgstper,sgstamt,igstper,igstamt) VALUES (" & Val(mxno) & "," & Val(txtscroll.Text) & ",'" & _
                          Format(invdt.Value, "dd/MMM/yyyy") & "','" & vb.Left(cmbbilltp.Text, 1) & "'," & Val(txtinvno.Text) & "," & _
                          Val(txtprtcd.Text) & ", " & Val(itcd) & "," & qty & "," & _
                          it_rt & "," & adisc & "," & total & ",'" & _
                          Trim(txtpfx.Text) & "','" & unt & "'," & amt & "," & mulrt & "," & taxcd & "," & cgstamt & "," & achrg & "," & _
                          cgst & "," & cgstamt & "," & sgst & "," & sgstamt & "," & igst & "," & igstamt & ")")
            Next
        End If
    End Sub

#End Region

#Region "Calculation"
    Private Sub dv_calc()
        gstper = Val(cmbcgst.Text) + Val(cmbsgst.Text)
        itqt = Val(txtquantity.Text) '* Val(txtmulrt.Text)
        If Val(txtquantity.Text) <> 0 Then
            txtamount.Text = Format(Val(Val(itqt) * Val(txtrate.Text)), "########0.00")
            'If Trim(txttaxstl.Text) = "I" Then
            '    txtexclmrp.Text = Val(Val(txtmrp.Text) * 100) / Val(Val(gstper) + 100)
            '    txtmrvalue.Text = Format(Val(Val(Val(itqt) + Val(frqt)) * Val(txtmrp.Text) * 100) / Val(Val(gstper) + 100), "########0.00")
            'Else
            '    txtmrvalue.Text = Format(Val(Val(Val(itqt) + Val(frqt)) * Val(txtmrp.Text)), "########0.00")
            'End If
            'If txttaxcat.Text = "1" Then
            cgst = Val((Val(cmbcgst.Text) / 100) * Val(txtamount.Text))
            sgst = Val((Val(cmbsgst.Text) / 100) * Val(txtamount.Text))
            'End If
            txtcgst.Text = Format(Val(cgst), "########0.00")
            If txtinout.Text = "I" Then
                txtsgst.Text = Format(Val(sgst), "########0.00")
            End If
            txttotal.Text = Format(Val(Val(txtamount.Text) + (Val(txtcgst.Text) + Val(txtsgst.Text) + Val(txtacharg.Text)) - Val(txtadisc.Text)), "########0.00")
        End If
    End Sub

    Private Sub grandamt(ByVal dgv As DataGridView)
        tamt = 0
        tcgst = 0
        tsgst = 0
        tdisc = 0
        tchrg = 0
        tgtamt = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            amt = dgv.Rows(i).Cells(5).Value
            cgst = dgv.Rows(i).Cells(7).Value
            sgst = dgv.Rows(i).Cells(9).Value
            disc = dgv.Rows(i).Cells(10).Value
            chrg = dgv.Rows(i).Cells(11).Value
            gtamt = dgv.Rows(i).Cells(12).Value
            'Totalling(Section)
            tamt = tamt + Val(amt)
            tcgst = tcgst + Val(cgst)
            tsgst = tsgst + Val(sgst)
            tdisc = tdisc + Val(disc)
            tchrg = tchrg + Val(chrg)
            tgtamt = tgtamt + Val(gtamt)
        Next
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

#End Region

#Region "Data Retrieve"

    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT serv1.srv_no AS 'Bill No', CONVERT(VARCHAR,serv1.srv_dt,103) AS 'Date', (CASE WHEN serv1.bill_tp='1' THEN 'Cash' WHEN serv1.bill_tp='2' THEN 'Credit' END) AS 'Type', serv1.srv_pfx + STR(serv1.inv_bno,8) AS 'Inv.No', serv1.bl_name AS 'Name',STR(serv1.srv_amt,10,2) AS 'Amount',staf.short_nm AS 'Sold By' FROM serv1 LEFT OUTER JOIN staf ON serv1.staf_sl = staf.staf_sl ORDER BY serv1.srv_dt DESC, serv1.srv_no DESC")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_view()
        Dim ds As DataSet = get_dataset("SELECT item.it_name, taxper.txname, serv2.* FROM serv2 LEFT OUTER JOIN taxper ON serv2.tax_cd = taxper.taxcd LEFT OUTER JOIN item ON serv2.it_cd = item.it_cd WHERE serv2.srv_no=" & Val(txtscroll.Text) & "")
        rw = 0
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("it_name")
                dv1.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("unt")
                dv1.Rows(rw).Cells(3).Value = Format(ds.Tables(0).Rows(i).Item("srv_qty"), "####0.00")
                dv1.Rows(rw).Cells(4).Value = Format(ds.Tables(0).Rows(i).Item("srv_rt"), "######0.00")
                dv1.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(i).Item("it_amt"), "######0.00")
                If Trim(txtinout.Text) = "O" Then
                    dv1.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("igstper"), "######0.00")
                    dv1.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("igstamt"), "######0.00")
                Else
                    dv1.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("cgstper"), "######0.00")
                    dv1.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("cgstamt"), "######0.00")
                End If
                dv1.Rows(rw).Cells(8).Value = Format(ds.Tables(0).Rows(i).Item("sgstper"), "######0.00")
                dv1.Rows(rw).Cells(9).Value = Format(ds.Tables(0).Rows(i).Item("sgstamt"), "######0.00")
                dv1.Rows(rw).Cells(10).Value = Format(ds.Tables(0).Rows(i).Item("disc_amt"), "######0.00")
                dv1.Rows(rw).Cells(11).Value = Format(ds.Tables(0).Rows(i).Item("chrg_amt"), "######0.00")
                dv1.Rows(rw).Cells(12).Value = Format(ds.Tables(0).Rows(i).Item("it_tot"), "######0.00")
                dv1.Rows(rw).Cells(13).Value = ds.Tables(0).Rows(i).Item("it_cd")
                dv1.Rows(rw).Cells(14).Value = ds.Tables(0).Rows(i).Item("tax_cd")
                dv1.Rows(rw).Cells(15).Value = ds.Tables(0).Rows(i).Item("mul_rt")
                dv1.Rows(rw).Cells(16).Value = ds.Tables(0).Rows(i).Item("srv_sl")
                rw += 1
            Next
            Me.grandamt(dv1)
            txtslno.Text = rw + 1
        End If
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT party.pname, drvmst.drv_snm, staf.short_nm, serv1.* FROM serv1 LEFT OUTER JOIN drvmst ON serv1.drv_cd = drvmst.drv_cd LEFT OUTER JOIN staf ON serv1.staf_sl = staf.staf_sl LEFT OUTER JOIN party ON serv1.prt_code = party.prt_code WHERE(serv1.srv_no = " & slno & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscroll.Text = slno
            cmbbilltp.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("bill_tp")) - 1
            txtpfx.Text = dsedit.Tables(0).Rows(0).Item("srv_pfx")
            txtinvno.Text = dsedit.Tables(0).Rows(0).Item("inv_bno")
            txtrefno.Text = dsedit.Tables(0).Rows(0).Item("ref_no")
            invdt.Value = dsedit.Tables(0).Rows(0).Item("srv_dt")
            paydt.Value = dsedit.Tables(0).Rows(0).Item("pay_dt")
            cmbstaf.Text = dsedit.Tables(0).Rows(0).Item("short_nm")
            txtstafcd.Text = dsedit.Tables(0).Rows(0).Item("staf_sl")
            txtprtcd.Text = dsedit.Tables(0).Rows(0).Item("prt_code")
            If Val(txtprtcd.Text) <> 0 Then
                cmbparty.Text = dsedit.Tables(0).Rows(0).Item("pname")
            End If
            txtbillnm.Text = dsedit.Tables(0).Rows(0).Item("bl_name")
            txtadd.Text = dsedit.Tables(0).Rows(0).Item("add1")
            txtmob.Text = dsedit.Tables(0).Rows(0).Item("mobno")
            txtdiscamt.Text = Format(dsedit.Tables(0).Rows(0).Item("dis_amt"), "######0.00")
            txtchargamt.Text = Format(dsedit.Tables(0).Rows(0).Item("chr_amt"), "######0.00")
            txtadj.Text = Format(dsedit.Tables(0).Rows(0).Item("adj_amt"), "######0.00")
            txtgrtotal.Text = Format(dsedit.Tables(0).Rows(0).Item("srv_amt"), "######0.00")
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
        salrt = "srv_rate" & txtprtcat.Text
        ds = get_dataset("SELECT TOP (3) convert(varchar,srv_dt,3) 'Date', STR(srv_rt,10,2) 'Rate',unt AS 'Unit' FROM serv2 WHERE (it_cd = " & Val(txtitemcd.Text) & ") AND (prt_code = " & Val(txtprtcd.Text) & ") ORDER BY srv_dt DESC")
        If ds.Tables(0).Rows.Count <> 0 Then
            dvtrans.DataSource = ds.Tables(0)
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
        Dim ds As DataSet = get_dataset("SELECT item.descri, item.gp_cd, item.tax_stl, item.ptx_cd, item.pur_rate,item.sale_rate1,item.sale_rate2,item.sale_rate3,item.sale_rate4, item.unt1, item.multi1, item.cl_stk,item.dcl_stk,item.bat_cnf, itgrp.gp_nm, taxper.taxcat,taxper.tax1, taxper.txname FROM item LEFT OUTER JOIN taxper ON item.ptx_cd = taxper.taxcd LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd WHERE item.it_cd=" & Val(txtitemcd.Text) & "")
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
            lbldescri.Text = Trim(ds.Tables(0).Rows(0).Item("descri"))
            lblgrp.Text = Trim(ds.Tables(0).Rows(0).Item("gp_nm"))
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
            txttaxcat.Text = ds.Tables(0).Rows(0).Item("taxcat")
        End If
    End Sub

#End Region
    Private Sub txtrate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrate.Validated
        Me.dv_calc()
    End Sub

    Private Sub txtvat_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcgst.Validated, txtacharg.Validated, txtadisc.Validated
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
        Dim dsdel As DataSet = get_dataset("SELECT srv_no,prt_code,srv_amt,bill_tp FROM serv1 WHERE srv_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            prtcd = dsdel.Tables(0).Rows(0).Item(1)
            toamt = dsdel.Tables(0).Rows(0).Item(2)
            bltp = dsdel.Tables(0).Rows(0).Item(3)
            If bltp = "2" Then
                SQLInsert("UPDATE party SET dr_amt=dr_amt - " & Val(toamt) & ",cl_amt=cl_amt + " & Val(toamt) & " WHERE prt_code=" & Val(prtcd) & "")
            End If
            SQLInsert("DELETE FROM serv1 WHERE srv_no=" & Val(code) & "")
        End If
    End Sub

    'Delete data from Table2/Secondary Table
    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT srv_sl FROM serv2 WHERE srv_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                srv_sl = dsdel.Tables(0).Rows(i).Item(0)
                SQLInsert("DELETE FROM serv2 WHERE srv_sl=" & Val(srv_sl) & "")
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
            Me.Text = "Cash / Credit Service Modification Screen . . ."
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
            Call service_print(slno)
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
                Dim ds As DataSet = get_dataset("SELECT srv_no FROM serv1 WHERE srv_no=" & Val(txtscroll.Text) & " ")
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
            itcd = Val(dv1.SelectedRows(0).Cells(13).Value)
            'Dim rw As DataGridViewRow
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

    Private Sub txtquantity_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquantity.Validated
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
            chksetdisc.Checked = True
            chksetblrnd.Checked = True
        Else
            chksetvat.Checked = False
            chksetrate.Checked = False
            chksetdisc.Checked = False
            chksetblrnd.Checked = False
        End If
    End Sub

    Private Sub Set_view()
        chksetvat.Checked = False
        chksetrate.Checked = False
        chksetdisc.Checked = False
        chksetblrnd.Checked = False
        chksetprnt.Checked = False
        Dim ds As DataSet = get_dataset("SELECT * FROM setting_service WHERE slno=1")
        If ds.Tables(0).Rows.Count <> 0 Then
            If ds.Tables(0).Rows(0).Item("req_rate") = 1 Then
                chksetrate.Checked = True
            End If
            If ds.Tables(0).Rows(0).Item("req_disc") = 1 Then
                chksetdisc.Checked = True
            End If
            If ds.Tables(0).Rows(0).Item("req_vat") = 1 Then
                chksetvat.Checked = True
            End If
            If ds.Tables(0).Rows(0).Item("bill_rnd") = 1 Then
                chksetblrnd.Checked = True
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
