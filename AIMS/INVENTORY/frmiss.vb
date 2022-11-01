Imports vb = Microsoft.VisualBasic
Public Class frmiss
    Dim comd As String = "E"

    Private Sub frmiss_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmiss_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmiss_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        comd = "E"
        Me.clr()
    End Sub

    Private Sub frmiss_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black
        End If
    End Sub

    Private Sub clr()
        cmbname.Text = ""
        txtref.Text = ""
        txtsl.Text = "1"
        txtitcd.Text = ""
        txtgodsal.Text = ""
        txtisscd.Text = ""
        txtmanfcd.Text = ""
        cmbmanfnm.Text = ""
        txtnb.Text = ""
        lblsnd.Text = "0.00"
        lbldmg.Text = "0.00"
        txtsndstk.Text = 0
        txtdmgstk.Text = 0
        txtrealmrp.Text = 0
        txtrealrt.Text = 0
        lblgrtot.Text = "0.00"
        dtissue.Value = sys_date
        cmbissue.SelectedIndex = 0
        cmbstorege.Text = ""
        dv1.Rows.Clear()
        If comd = "E" Then
            cmbissue.Enabled = True
            btnsave.Text = "Save"
            Me.Text = "Product Issue Entry Screen...."
            Dim ds As DataSet = get_dataset("SELECT MAX(iss_no) AS 'MAX' FROM iss1")
            txtscroll.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
        ElseIf comd = "M" Then

            cmbissue.Enabled = False
            btnsave.Text = "Modify"
            Me.Text = "Product Issue Modification Screen . . ."
            txtscroll.Text = ""
        Else
            btnsave.Text = "Delete"
            cmbissue.Enabled = False
            Me.Text = "Product Issue Deletion Screen . . ."
            txtscroll.Text = ""
        End If
        Me.clr1()
    End Sub

    Private Sub clr1()
        cmbproduct.Text = ""
        txtitcd.Text = 0
        txtquantity.Text = "0"
        cmbunit.Text = ""
        txtmrp.Text = "0.00"
        txtamount.Text = "0.00"
        txtmulrt.Text = 1
    End Sub

#Region "Enter/Leave"
    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtscroll.Enter, cmbissue.Enter, txtsl.Enter, txtref.Enter, txtmrp.Enter, txtquantity.Enter, txtamount.Enter, cmbstorege.Enter, cmbproduct.Enter, cmbname.Enter, cmbmanfnm.Enter, cmbunit.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsl.Leave, txtscroll.Leave, txtref.Leave, txtmrp.Leave, txtquantity.Leave, txtamount.Leave, cmbstorege.Leave, cmbproduct.Leave, cmbissue.Leave, cmbname.Leave, cmbmanfnm.Leave, cmbunit.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.MouseEnter, btnexit.MouseEnter, btnview.MouseEnter, btnref.MouseEnter, btninter.MouseEnter, btnsave.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.MouseLeave, btnexit.MouseLeave, btnview.MouseLeave, btnref.MouseLeave, btninter.MouseLeave, btnsave.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "Key Press"

    Private Sub txtscroll_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtscroll.KeyPress
        key(dtissue, e)
        NUM(e)
    End Sub

    Private Sub dtissue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtissue.KeyPress
        key(cmbissue, e)
    End Sub

    Private Sub cmbissue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbissue.KeyPress
        key(txtref, e)
        SPKey(e)
    End Sub

    'Private Sub txtregd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    key(txtref, e)
    '    SPKey(e)
    'End Sub

    Private Sub txtref_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtref.KeyPress
        key(cmbname, e)
        SPKey(e)
    End Sub

    Private Sub cmbname_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbname.KeyPress
        key(cmbstorege, e)
        SPKey(e)
    End Sub

    Private Sub cmbstorege_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstorege.KeyPress
        key(cmbmanfnm, e)
        SPKey(e)
    End Sub

    Private Sub cmbmanfnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbmanfnm.KeyPress
        key(cmbproduct, e)
        SPKey(e)
    End Sub

    Private Sub cmbproduct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbproduct.KeyPress
        If Trim(cmbproduct.Text) <> "" Then
            key(cmbunit, e)
        Else
            key(txtnb, e)
        End If
        SPKey(e)
    End Sub

    Private Sub cmbunit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunit.KeyPress
        key(txtquantity, e)
    End Sub

    Private Sub txtquantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtquantity.KeyPress
        key(btnnxt, e)
        NUM1(e)
    End Sub

    Private Sub txtnb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnb.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub
#End Region

#Region "ComboBox"

    Private Sub txtquantity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquantity.GotFocus
        If Val(txtquantity.Text) = 0 Then
            txtquantity.Text = ""
        End If
    End Sub

    Private Sub txtrate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmrp.LostFocus
        txtmrp.Text = Format(Val(txtmrp.Text), "#########0.00")
    End Sub

    Private Sub txtamount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamount.LostFocus
        txtamount.Text = Format(Val(txtamount.Text), "########0.00")
    End Sub

    Private Sub cmbstorege_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstorege.GotFocus
        cmbstorege.Height = 100
        txtgodsal.Text = 0
        populate(cmbstorege, "SELECT godnm FROM godown WHERE rec_lock='N' ORDER BY godnm")
    End Sub

    Private Sub cmbstorege_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstorege.LostFocus
        cmbstorege.Height = 21
    End Sub

    Private Sub cmbproduct_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.GotFocus
        txtitcd.Text = 0
        lbldescri.Text = ""
        lblgrp.Text = ""
        populate(cmbproduct, "SELECT it_name FROM item WHERE (rec_lock = 'N')  AND (manf_cd = " & Val(txtmanfcd.Text) & ") ORDER BY it_name")
    End Sub

    Private Sub cmbproduct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.LostFocus
        cmbproduct.Height = 21
    End Sub

    Private Sub cmbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.GotFocus
        If cmbissue.SelectedIndex = 0 Then
            populate(cmbname, "SELECT staf_nm FROM staf WHERE rec_lock='N' ORDER BY staf_nm")
        Else
            populate(cmbname, "SELECT veh_nm FROM veh WHERE rec_lock='N' ORDER BY veh_nm")
        End If

    End Sub

    Private Sub cmbname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.LostFocus
        cmbname.Height = 21
    End Sub

    Private Sub cmbname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        If cmbissue.SelectedIndex = 0 Then
            vdated(txtcd, "SELECT staf_sl FROM staf WHERE (staf_nm = '" & Trim(cmbname.Text) & "')")
        Else
            vdated(txtcd, "SELECT veh_cd FROM veh WHERE (veh_nm = '" & Trim(cmbname.Text) & "')")
        End If

    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        If cmbissue.SelectedIndex = 0 Then
            vdating(cmbname, "SELECT staf_nm FROM staf WHERE rec_lock='N' AND staf_nm='" & Trim(cmbname.Text) & "'", "Please Select A Valid Staf Name.")
        Else
            vdating(cmbname, "SELECT veh_nm FROM veh WHERE rec_lock='N' AND veh_nm='" & Trim(cmbname.Text) & "'", "Please Select A Valid Vehcile Name.")
        End If

    End Sub

    Private Sub cmbstorege_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstorege.Validating
        vdating(cmbstorege, "SELECT godnm FROM godown WHERE (godnm = '" & Trim(cmbstorege.Text) & "')", "Please Enter A Valid Storage Name.")
    End Sub

    Private Sub cmbstorege_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstorege.Validated
        vdated(txtgodsal, "SELECT godsl FROM godown WHERE (godnm = '" & Trim(cmbstorege.Text) & "')")
    End Sub

    Private Sub cmbproduct_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.Validated
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
            Me.stk_calc()
            '  Me.dv_calc()
            If Val(txtcd.Text) <> 0 Or Val(txtitcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
    End Sub

    Private Sub cmbproduct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.TextChanged
        Dim ds As DataSet = get_dataset("SELECT item.it_cd,item.bat_cnf, item.descri, item.ptx_cd, item.mrp, item.pur_rate, item.unt1,item.unt2,item.unt3,item.unt4, item.cl_stk,item.dcl_stk, itgrp.gp_nm, item.multi1, taxper.txname,taxper.taxcat, item.tax_stl, taxper.tax1 FROM item LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN taxper ON item.ptx_cd = taxper.taxcd WHERE item.it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtitcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            cmbunit.Text = ds.Tables(0).Rows(0).Item("unt1")
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
            Me.stk_calc()
            '  Me.dv_calc()
            If Val(txtcd.Text) <> 0 Or Val(txtitcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
    End Sub

    Private Sub txtref_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtref.Validated
        If txtref.Text = "" Then
            txtref.Text = "X"
        End If
    End Sub

    Private Sub cmbproduct_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbproduct.Validating
        vdating(cmbproduct, "SELECT it_name FROM item WHERE rec_lock='N' AND it_name= '" & Trim(cmbproduct.Text) & "'", "Please Select a Valid Product Name.")
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
        'Me.dv_calc()
        Me.stk_calc()
    End Sub

    Private Sub cmbunit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.TextChanged
        Dim ds As DataSet = get_dataset("SELECT * FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitcd.Text) & ") AND unt.unt_nm='" & Trim(cmbunit.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtuntcd.Text = ds.Tables(0).Rows(0).Item("unt_cd")
            txtmulrt.Text = ds.Tables(0).Rows(0).Item("mul_rt")
        End If
        'Me.dv_calc()
        Me.stk_calc()
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        vdating(cmbunit, "SELECT unt.unt_nm FROM untlnk LEFT OUTER JOIN unt ON untlnk.unt_cd = unt.unt_cd WHERE(untlnk.it_cd = " & Val(txtitcd.Text) & ") AND unt.unt_nm='" & Trim(cmbunit.Text) & "'", "Please Select An Valid Unit Name.")
    End Sub

    Private Sub cmbmanfnm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmanfnm.GotFocus
        populate(cmbmanfnm, "SELECT manf_nm FROM manf WHERE (rec_lock = 'N') ORDER BY manf_nm")
    End Sub

    Private Sub cmbmanfnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmanfnm.LostFocus
        cmbmanfnm.Height = 21
    End Sub

    Private Sub cmbmanfnm_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmanfnm.Validating
        vdating(cmbmanfnm, "SELECT manf_nm FROM manf WHERE (manf_nm ='" & Trim(cmbmanfnm.Text) & "')", "Please Select a Valid Manufacturer Name.")
    End Sub

    Private Sub cmbmanfnm_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmanfnm.Validated
        vdated(txtmanfcd, "SELECT manf_cd FROM manf WHERE (manf_nm ='" & Trim(cmbmanfnm.Text) & "')")
    End Sub


#End Region

#Region "Botton"

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click, cmnurefresh.Click
        Me.dv_disp()
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Val(txtscroll.Text) = 0 Then
            MessageBox.Show("Sorry The Order No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtscroll.Focus()
            Exit Sub
        End If
        If Trim(cmbname.Text) = "" Or Val(txtcd.Text) = 0 Then
            If cmbissue.SelectedIndex = 0 Then
                MessageBox.Show("Please Enter A Valid Employee Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please Enter A Valid Vehicle Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            cmbname.Focus()
            Exit Sub
        End If
        If Trim(cmbstorege.Text) = "" Or Val(txtgodsal.Text) = 0 Then
            MessageBox.Show("Please Enter A Valid Storage Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbstorege.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count = 0 Then
            MessageBox.Show("Please Issue Atleast One Item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If
        Me.iss_save()
    End Sub

    Private Sub btnnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.Click
        If Trim(cmbproduct.Text) = "" Or Val(txtitcd.Text) = 0 Then
            MessageBox.Show("Please Enter A Valid Product Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If
        If Trim(cmbmanfnm.Text) = "" Or Val(txtmanfcd.Text) = 0 Then
            MessageBox.Show("Please Provide A Manufacturer Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbmanfnm.Focus()
            Exit Sub
        End If
        If Val(txtquantity.Text) = 0 Then
            MessageBox.Show("Please Enter A Quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtquantity.Focus()
            Exit Sub
        End If
        sl1 = Val(txtsl.Text)
        dv1.Rows.Add()
        dv1.Rows(sl1 - 1).Cells(0).Value = sl1
        dv1.Rows(sl1 - 1).Cells(1).Value = cmbmanfnm.Text
        dv1.Rows(sl1 - 1).Cells(2).Value = cmbproduct.Text
        dv1.Rows(sl1 - 1).Cells(3).Value = txtquantity.Text
        dv1.Rows(sl1 - 1).Cells(4).Value = cmbunit.Text
        dv1.Rows(sl1 - 1).Cells(5).Value = txtmrp.Text
        dv1.Rows(sl1 - 1).Cells(6).Value = txtamount.Text
        dv1.Rows(sl1 - 1).Cells(7).Value = txtitcd.Text
        dv1.Rows(sl1 - 1).Cells(8).Value = txtmanfcd.Text
        dv1.Rows(sl1 - 1).Cells(9).Value = txtmulrt.Text
        dv1.Rows(sl1 - 1).Cells(10).Value = "N"
        sl1 += 1
        txtsl.Text = sl1
        cmbproduct.Focus()
        Me.grandamt(dv1)
        Me.clr1()
    End Sub
#End Region

    Private Sub txtquantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquantity.TextChanged
        txtamount.Text = Format((Val(txtquantity.Text) * Val(txtmrp.Text)), "#######0.00")
    End Sub

    Private Sub grandamt(ByVal dgv As DataGridView)
        gtamt = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            amt = dgv.Rows(i).Cells(6).Value
            gtamt = gtamt + Val(amt)
        Next
        lblgrtot.Text = Format(gtamt, "#######0.00")
    End Sub

    Private Sub iss_save()
        staf_sl = 0
        veh_cd = 0
        If cmbissue.SelectedIndex = 0 Then
            staf_sl = Val(txtcd.Text)
        Else
            veh_cd = Val(txtcd.Text)
        End If
        Start1()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT MAX(iss_no) AS 'MAX' FROM iss1")
                txtscroll.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO iss1 (iss_no,iss_dt,iss_to,ref_no,veh_cd,staf_sl,godsl,tot_val,nb,usr_ent,ent_date,usr_mod,mod_date,rec_lock,used_by) VALUES (" & Val(txtscroll.Text) & _
                      ",'" & Format(dtissue.Value, "dd/MMM/yyyy") & "','" & _
                      vb.Left(cmbissue.Text, 1) & "','" & Trim(txtref.Text) & "'," & Val(veh_cd) & "," & Val(staf_sl) & "," & _
                      Val(txtgodsal.Text) & "," & Val(lblgrtot.Text) & ",'" & Trim(txtnb.Text) & "'," & _
                      Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(usr_sl) & ",'" & _
                      Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N','N')")

                Me.dv_save()
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'cnfr = MessageBox.Show("Are You Sure The Printer is Ready To Print The Bill.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If cnfr = vbYes Then
                '    Call colrec_print(Val(txtordno.Text))
                'End If
                Me.clr()
            End If
        ElseIf comd = "M" Then
            If usr_tp = "O" Then
                MessageBox.Show("You Are Not Authorised to Modify The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT iss_no FROM iss1 WHERE iss_no=" & Val(txtscroll.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE iss1 SET iss_dt='" & Format(dtissue.Value, "dd/MMM/yyyy") & "',iss_to='" & _
                         vb.Left(cmbissue.Text, 1) & "',ref_no='" & Trim(txtref.Text) & "',veh_cd=" & _
                         Val(veh_cd) & ",staf_sl=" & Val(staf_sl) & ",godsl=" & Val(txtgodsal.Text) & ",tot_val=" & Val(lblgrtot.Text) & _
                         ", nb='" & Trim(txtnb.Text) & "',usr_mod=" & _
                         Val(usr_sl) & ",mod_date='" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "' WHERE iss_no =" & Val(txtscroll.Text) & "")
                    Me.dv_save()
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                End If
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
                txtscroll.Focus()
            End If
        End If
        Close1()
    End Sub

    Private Sub dv_save()
        If dv1.RowCount <> 0 Then
            If comd = "M" Then
                Call del2(txtscroll.Text)
            End If
            staf_sl = 0
            veh_cd = 0
            If cmbissue.SelectedIndex = 0 Then
                staf_sl = Val(txtcd.Text)
            Else
                veh_cd = Val(txtcd.Text)
            End If
            For i As Integer = 0 To dv1.RowCount - 1
                qty = Val(dv1.Rows(i).Cells(3).Value)
                unt = dv1.Rows(i).Cells(4).Value
                mrp = Val(dv1.Rows(i).Cells(5).Value)
                amt = Val(dv1.Rows(i).Cells(6).Value)
                itcd = Val(dv1.Rows(i).Cells(7).Value)
                manfcd = Val(dv1.Rows(i).Cells(8).Value)
                mulrt = Val(dv1.Rows(i).Cells(9).Value)
                refnd = dv1.Rows(i).Cells(10).Value
                Dim ds1 As DataSet = get_dataset("SELECT max(iss_sl) as 'Max' FROM iss2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO iss2(iss_sl,iss_no,iss_dt,iss_to,veh_cd,staf_sl,manf_cd,it_cd,qty,unt,rate,amt,refund,ret_dt,mul_rt) VALUES (" & _
                          Val(mxno) & "," & Val(txtscroll.Text) & ",'" & Format(dtissue.Value, "dd/MMM/yyyy") & "','" & _
                          vb.Left(cmbissue.Text, 1) & "'," & Val(veh_cd) & "," & staf_sl & "," & Val(manfcd) & ", " & itcd & "," & qty & ",'" & unt & "'," & mrp & _
                          "," & amt & ",'" & refnd & "','" & Format(dtissue.Value, "dd/MMM/yyyy") & "'," & Val(mulrt) & ")")
                If refnd = "N" Then
                    itqt = (qty * mulrt)
                    stock_OUT(itqt, itcd, 0, 1, 1)
                End If
            Next
        End If
    End Sub

    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY iss1.iss_no) AS 'Sl.',  iss1.iss_no AS 'Issue No.', CONVERT(varchar,iss1.iss_dt,103) AS 'Issue Dt.' , (CASE WHEN iss1.iss_to='1' THEN 'Staff' WHEN iss1.iss_to='2' THEN 'Vehicle' END) AS 'Issue To' ,(CASE WHEN iss1.staf_sl<>0 THEN staf.staf_nm WHEN iss1.veh_cd<>0 THEN veh.veh_nm END) AS 'Particulars' , godown.godnm AS 'Godown', STR(iss1.tot_val,10,2) AS 'Total Value' FROM iss1 LEFT OUTER JOIN veh ON iss1.veh_cd = veh.veh_cd LEFT OUTER JOIN godown ON iss1.godsl = godown.godsl LEFT OUTER JOIN staf ON iss1.staf_sl = staf.staf_sl ORDER BY iss1.iss_no")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT   iss1.*,   staf.staf_id, staf.staf_nm, veh.veh_no, veh.veh_nm, veh.drv_nm, dept.dept_nm, godown.godnm FROM veh RIGHT OUTER JOIN iss1 LEFT OUTER JOIN godown ON iss1.godsl = godown.godsl ON veh.veh_cd = iss1.veh_cd LEFT OUTER JOIN dept RIGHT OUTER JOIN staf ON dept.dept_cd = staf.dept_cd ON iss1.staf_sl = staf.staf_sl WHERE (iss1.iss_no = " & Val(slno) & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscroll.Text = slno
            dtissue.Value = dsedit.Tables(0).Rows(0).Item("iss_dt")
            txtref.Text = dsedit.Tables(0).Rows(0).Item("ref_no")
            cmbissue.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("iss_to")) - 1
            txtgodsal.Text = dsedit.Tables(0).Rows(0).Item("godsl")
            cmbstorege.Text = dsedit.Tables(0).Rows(0).Item("godnm")
            txtnb.Text = dsedit.Tables(0).Rows(0).Item("nb")
            If cmbissue.SelectedIndex = 1 Then
                cmbname.Text = dsedit.Tables(0).Rows(0).Item("veh_nm")
                txtcd.Text = dsedit.Tables(0).Rows(0).Item("veh_cd")
            Else
                cmbname.Text = dsedit.Tables(0).Rows(0).Item("staf_nm")
                txtcd.Text = dsedit.Tables(0).Rows(0).Item("staf_sl")
            End If
            Me.dv_view()
        End If
        Close1()
    End Sub

    Private Sub dv_view()
        Dim ds As DataSet = get_dataset("SELECT manf.manf_nm, item.it_name, iss2.* FROM iss2 LEFT OUTER JOIN manf ON iss2.manf_cd = manf.manf_cd LEFT OUTER JOIN item ON iss2.it_cd = item.it_cd WHERE iss2.iss_no = " & Val(txtscroll.Text) & "")
        rw = 0
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("manf_nm")
                dv1.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("it_name")
                dv1.Rows(rw).Cells(3).Value = Format(ds.Tables(0).Rows(i).Item("qty"), "######0")
                dv1.Rows(rw).Cells(4).Value = ds.Tables(0).Rows(i).Item("unt")
                dv1.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(i).Item("rate"), "#######0.00")
                dv1.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("amt"), "######0.00")
                dv1.Rows(rw).Cells(7).Value = ds.Tables(0).Rows(i).Item("it_cd")
                dv1.Rows(rw).Cells(8).Value = ds.Tables(0).Rows(i).Item("manf_cd")
                dv1.Rows(rw).Cells(9).Value = ds.Tables(0).Rows(i).Item("mul_rt")
                dv1.Rows(rw).Cells(10).Value = ds.Tables(0).Rows(i).Item("refund")
                If ds.Tables(0).Rows(i).Item("refund") = "Y" Then
                    dv1.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv1.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    'dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    dv1.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
                rw += 1
            Next
            Me.grandamt(dv1)
            txtsl.Text = rw + 1
        Else
            MessageBox.Show("Products Issued To This Person Are Already Returned", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtscroll.Focus()
            Me.clr()
        End If

    End Sub

    Private Sub trans_view()
        dvtrans.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        If cmbissue.SelectedIndex = 0 Then
            ds = get_dataset("SELECT TOP (3) convert(varchar,iss_dt,3) 'Date',STR(rate,10,2) 'Rate' FROM iss2 WHERE (it_cd = " & Val(txtitcd.Text) & ") AND (staf_sl = " & Val(txtcd.Text) & ") ORDER BY iss_dt DESC")
        Else
            ds = get_dataset("SELECT TOP (3) convert(varchar,iss_dt,3) 'Date',STR(rate,10,2) 'Rate' FROM iss2 WHERE (it_cd = " & Val(txtitcd.Text) & ") AND (veh_cd = " & Val(txtcd.Text) & ") ORDER BY iss_dt DESC")
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            dvtrans.DataSource = ds.Tables(0)
        End If
        Close1()
    End Sub

    Private Sub stk_calc()
        lblsndunt.Text = cmbunit.Text
        lbldmgunt.Text = cmbunit.Text
        lblsnd.Text = Format(Val(txtsndstk.Text / txtmulrt.Text), "#####0.00")
        lbldmg.Text = Format(Val(txtdmgstk.Text / txtmulrt.Text), "#####0.00")
        txtmrp.Text = Format(Val(txtrealmrp.Text * txtmulrt.Text), "#######0.00")
        txtmrp.Text = Format(Val(txtrealrt.Text * txtmulrt.Text), "#######0.00")
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

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        comd = "E"
        Me.clr()
        dv.Visible = False
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Edit"
            Me.Text = "Product Issue Modification Screen. . . "
            slno = dv.SelectedRows(0).Cells(1).Value
            Me.dv_edit(slno)
            dv.Visible = False
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            If usr_tp = "A" Or usr_tp = "D" Then
                slno = dv.SelectedRows(0).Cells(1).Value
                cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Start1()
                If cnfr = vbYes Then
                    Call del1(slno)
                    Call del2(slno)
                    MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dv_disp()
                End If
                Close1()
            Else
                MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        txtsl.Text = sl
    End Sub

    Private Sub txtscroll_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtscroll.Validated
        If comd <> "E" Then
            If Val(txtscroll.Text) <> 0 Then
                Dim ds As DataSet = get_dataset("SELECT iss_no FROM iss1 WHERE (iss_no = '" & Trim(txtscroll.Text) & "')")
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

    'Delete data from Table1/Primary Table
    Private Sub del1(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT iss_no FROM iss1 WHERE iss_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            SQLInsert("DELETE FROM iss1 WHERE iss_no=" & Val(code) & "")
        End If
    End Sub

    'Delete data from Table2/Secondary Table
    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT iss_sl,qty,it_cd,mul_rt,refund FROM iss2 WHERE iss_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                posl = dsdel.Tables(0).Rows(i).Item(0)
                pqty = Val(dsdel.Tables(0).Rows(i).Item(1))
                itcd = dsdel.Tables(0).Rows(i).Item(2)
                mulrt = Val(dsdel.Tables(0).Rows(i).Item(3))
                If dsdel.Tables(0).Rows(i).Item(4) = "N" Then
                    itqt = (pqty * mulrt)
                    stock_OUTDEL(itqt, itcd, 0, 1, 1)
                End If
                SQLInsert("DELETE FROM iss2 WHERE iss_sl=" & Val(posl) & "")
            Next
        End If
    End Sub

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub
End Class
