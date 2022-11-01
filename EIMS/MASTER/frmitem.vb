Imports vb = Microsoft.VisualBasic
Public Class frmitem
    Dim comd As String

    Private Sub frmitem_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuProduct.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmitem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmitem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuProduct.Enabled = False
        usrprmsn("mnuProduct", cmnuadd, cmnuedit, cmenudel, cmenuview)
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmitem_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Product Master Entry Screen . . ."
        txtscrl.Text = ""
        txtitemnm.Text = ""
        txtdescri.Text = ""
        cmbvat.Text = ""
        cmbgrp.Text = ""
        cmbgodwn.Text = ""
        cmbunt1.Text = ""
        cmbunt2.Text = ""
        txtmulti.Text = "1"
        txtmrp.Text = "0.00"
        txtpurrt.Text = "0.00"
        txtopstk.Text = "0.00"
        txtclstk.Text = "0.00"
        txtgrpcd.Text = 0
        txtvatcd.Text = 0
        txtuntcd1.Text = 0
        txtuntcd2.Text = 0
        txtgdncd.Text = 0
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(it_cd) as 'Max' FROM item")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtitemnm.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.dv_disp()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpurrt.Enter, txtopstk.Enter, txtmulti.Enter, txtmrp.Enter, txtitemnm.Enter, txtdescri.Enter, cmbvat.Enter, cmbunt2.Enter, cmbunt1.Enter, cmblock.Enter, cmbgrp.Enter, cmbgodwn.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpurrt.Leave, txtopstk.Leave, txtmulti.Leave, txtmrp.Leave, txtitemnm.Leave, txtdescri.Leave, cmbvat.Leave, cmbunt2.Leave, cmbunt1.Leave, cmblock.Leave, cmbgrp.Leave, cmbgodwn.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub txttradnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtitemnm.KeyPress
        key(txtdescri, e)
        SPKey(e)
    End Sub

    Private Sub txtdescri_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescri.KeyPress
        key(cmbgrp, e)
        SPKey(e)
    End Sub

    Private Sub cmbgrp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgrp.KeyPress
        key(cmbvat, e)
        SPKey(e)
    End Sub

    Private Sub cmbvat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbvat.KeyPress
        key(cmbunt1, e)
        SPKey(e)
    End Sub

    Private Sub cmbunt1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunt1.KeyPress
        key(txtmulti, e)
        SPKey(e)
    End Sub

    Private Sub txtmulti_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmulti.KeyPress
        key(cmbunt2, e)
        SPKey(e)
    End Sub

    Private Sub cmbunt2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunt2.KeyPress
        key(txtmrp, e)
        SPKey(e)
    End Sub

    Private Sub txtmrp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmrp.KeyPress
        key(txtpurrt, e)
        NUM1(e)
    End Sub

    Private Sub txtpurrt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpurrt.KeyPress
        key(cmbgodwn, e)
        NUM1(e)
    End Sub

    Private Sub cmbgodwn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgodwn.KeyPress
        key(txtopstk, e)
        SPKey(e)
    End Sub

    Private Sub txtopstk_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtopstk.KeyPress
        key(cmblock, e)
        NUM1(e)
    End Sub

    Private Sub txtdeptnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtitemnm.LostFocus
        txtdescri.Text = Trim(txtitemnm.Text)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Add"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtitemnm.Text) = "" Then
            MessageBox.Show("Please Provide A Product Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtitemnm.Focus()
            Exit Sub
        End If
        If Trim(cmbgrp.Text) = "" Or Val(txtgrpcd.Text) = 0 Then
            MessageBox.Show("Please Select A Product Group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbgrp.Focus()
            Exit Sub
        End If
        If Trim(cmbvat.Text) = "" Or Val(txtvatcd.Text) = 0 Then
            MessageBox.Show("Please Select A VAT Category.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbvat.Focus()
            Exit Sub
        End If
        If Trim(cmbgodwn.Text) = "" Or Val(txtgdncd.Text) = 0 Then
            MessageBox.Show("Please Select A Storge Point.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbgodwn.Focus()
            Exit Sub
        End If
        Me.item_save()
    End Sub

    Private Sub item_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(it_cd) as 'Max' FROM item")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO item (it_cd,it_name,it_desc,grp_cd,taxcd,unt1,multi1,unt2,mrp,pur_rate,min_cri,max_cri,rec_lock,rec_stk," & _
                          "iss_stk,cl_stk,godsl,op_stk,rop_stk,rrec_stk,riss_stk,rcl_stk) VALUES (" & Val(txtscrl.Text) & ",'" & Trim(txtitemnm.Text) & "','" & Trim(txtdescri.Text) & "'," & _
                          Val(txtgrpcd.Text) & "," & Val(txtvatcd.Text) & ",'" & Trim(cmbunt1.Text) & "'," & Val(txtmulti.Text) & ",'" & _
                          Trim(cmbunt2.Text) & "'," & Val(txtmrp.Text) & "," & Val(txtpurrt.Text) & ",0,0,'" & vb.Left(cmblock.Text, 1) & "',0,0," & _
                          Val(txtopstk.Text) & "," & Val(txtgdncd.Text) & "," & Val(txtopstk.Text) & ",0,0,0,0)")
                Me.unit_save()
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Close1()
            End If
        Else
            'If usr_tp = "O" Then
            '    MessageBox.Show("You Are Not Authorised to Modify The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT it_cd FROM item WHERE it_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE item SET it_name='" & Trim(txtitemnm.Text) & "',it_desc='" & Trim(txtdescri.Text) & "',grp_cd=" & _
                          Val(txtgrpcd.Text) & ",taxcd=" & Val(txtvatcd.Text) & ",unt1='" & Trim(cmbunt1.Text) & "',multi1=" & _
                          Val(txtmulti.Text) & ",unt2='" & Trim(cmbunt2.Text) & "',mrp=" & Val(txtmrp.Text) & ",pur_rate=" & _
                          Val(txtpurrt.Text) & ",rec_lock='" & vb.Left(cmblock.Text, 1) & "',godsl=" & Val(txtgdncd.Text) & ",op_stk=" & _
                          Val(txtopstk.Text) & " WHERE it_cd =" & Val(txtscrl.Text) & "")
                    Me.unit_save()
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                    Me.dv_disp()
                End If
                Close1()
            End If
        End If
    End Sub

    Private Sub unit_save()
        SQLInsert("DELETE FROM untlnk WHERE it_cd=" & Val(txtscrl.Text) & "")
        Dim ds1 As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM untlnk")
        mxno = 1
        If ds1.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                mxno = ds1.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        If Trim(cmbunt1.Text) <> "" Then
            SQLInsert("INSERT INTO untlnk(slno, it_cd,unt_pos, unt_nm,mul_rt,unt_cd) VALUES (" & Val(mxno) & "," & _
               Val(txtscrl.Text) & ",1,'" & Trim(cmbunt1.Text) & "',1," & Val(txtuntcd1.Text) & ")")
            mxno += 1
        End If
        If Trim(cmbunt2.Text) <> "" Then
            SQLInsert("INSERT INTO untlnk(slno, it_cd,unt_pos, unt_nm,mul_rt,unt_cd) VALUES (" & Val(mxno) & "," & _
               Val(txtscrl.Text) & ",2,'" & Trim(cmbunt2.Text) & "'," & Val(txtmulti.Text) & "," & Val(txtuntcd2.Text) & ")")
            mxno += 1
        End If
    End Sub

    Private Sub dv_disp()
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY item.it_name) AS 'Sl.',item.it_name AS 'Product Name',item_group.grp_nm AS 'Group Name', taxper.txname AS 'Tax Name', STR(item.mrp,10,2) AS 'M.R.P',  STR(item.cl_stk,8,3) AS 'Stock',item.rec_lock, item.it_cd FROM item LEFT OUTER JOIN taxper ON item.taxcd = taxper.taxcd LEFT OUTER JOIN item_group ON item.grp_cd = item_group.grp_cd ORDER BY item.it_name")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(6).Visible = False
            dv.Columns(7).Visible = False
            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(6).Value
                If reclock = "Y" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    'dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
                'Dim rw As Integer = 0
                'For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                '    dv.Rows.Add()
                '    dv.Rows(i).Cells(0).Value = i + 1
                '    dv.Rows(i).Cells(1).Value = dsedit.Tables(0).Rows(rw).Item("it_name")
                '    dv.Rows(i).Cells(2).Value = dsedit.Tables(0).Rows(rw).Item("grp_nm")
                '    dv.Rows(i).Cells(3).Value = dsedit.Tables(0).Rows(rw).Item("txname")
                '    dv.Rows(i).Cells(4).Value = Format(dsedit.Tables(0).Rows(rw).Item("mrp"), "######0.00")
                '    dv.Rows(i).Cells(5).Value = Format(dsedit.Tables(0).Rows(rw).Item("cl_stk"), "######0.00")
                '    dv.Rows(i).Cells(6).Value = dsedit.Tables(0).Rows(rw).Item("it_cd")
                '    If dsedit.Tables(0).Rows(rw).Item("rec_lock") = "Y" Then
                '        dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                '        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                '    Else
                '        dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                '        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                '    End If
                '    rw = rw + 1
            Next
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
        btnsave.Enabled = True
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT item_group.grp_nm , taxper.taxnm , item.*, godown.godnm FROM item LEFT OUTER JOIN godown ON item.godsl = godown.godsl LEFT OUTER JOIN taxper ON item.taxcd = taxper.taxcd LEFT OUTER JOIN item_group ON item.grp_cd = item_group.grp_cd WHERE item.it_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtitemnm.Text = dsedit.Tables(0).Rows(0).Item("it_name")
            txtdescri.Text = dsedit.Tables(0).Rows(0).Item("it_desc")
            cmbgrp.Text = dsedit.Tables(0).Rows(0).Item("grp_nm")
            txtgrpcd.Text = dsedit.Tables(0).Rows(0).Item("grp_cd")
            cmbvat.Text = dsedit.Tables(0).Rows(0).Item("taxnm")
            txtvatcd.Text = dsedit.Tables(0).Rows(0).Item("taxcd")
            cmbgodwn.Text = dsedit.Tables(0).Rows(0).Item("godnm")
            txtgdncd.Text = dsedit.Tables(0).Rows(0).Item("godsl")
            cmbunt1.Text = dsedit.Tables(0).Rows(0).Item("unt1")
            cmbunt2.Text = dsedit.Tables(0).Rows(0).Item("unt2")
            txtmulti.Text = dsedit.Tables(0).Rows(0).Item("multi1")
            txtmrp.Text = Format(dsedit.Tables(0).Rows(0).Item("mrp"), "######0.00")
            txtpurrt.Text = Format(dsedit.Tables(0).Rows(0).Item("pur_rate"), "######0.00")
            txtopstk.Text = Format(dsedit.Tables(0).Rows(0).Item("op_stk"), "######0.00")
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
                cmblock.SelectedIndex = 1
            Else
                cmblock.SelectedIndex = 0
            End If
            Me.unit_view()
        End If
        Close1()
    End Sub

    Private Sub unit_view()

        Dim ds1 As DataSet = get_dataset("SELECT * FROM untlnk WHERE it_cd=" & Val(txtscrl.Text) & " ORDER BY unt_pos")
        If ds1.Tables(0).Rows.Count <> 0 Then
            txtmulti.Text = 1
            For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                If ds1.Tables(0).Rows(i).Item("unt_pos") = 2 Then
                    cmbunt2.Text = ds1.Tables(0).Rows(i).Item("unt_nm")
                    txtuntcd2.Text = ds1.Tables(0).Rows(i).Item("unt_cd")
                    txtmulti.Text = Val(ds1.Tables(0).Rows(i).Item("mul_rt"))
                Else
                    cmbunt1.Text = ds1.Tables(0).Rows(i).Item("unt_nm")
                    txtuntcd1.Text = ds1.Tables(0).Rows(i).Item("unt_cd")
                End If
            Next
        End If
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Add"
        Me.Text = "Product Master Entry Screen . . ."
        dv.Visible = False
        txtitemnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Product Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(7).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtitemnm.Focus()
        End If
    End Sub

    Private Sub cmbgrp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgrp.GotFocus
        populate(cmbgrp, "SELECT grp_nm FROM item_group WHERE (rec_lock = 'N') ORDER BY grp_nm")
    End Sub

    Private Sub cmbgrp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgrp.LostFocus
        cmbgrp.Height = 21
    End Sub

    Private Sub cmbgrp_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbgrp.Validated
        vdated(txtgrpcd, "SELECT grp_cd FROM item_group WHERE (grp_nm = '" & Trim(cmbgrp.Text) & "')")
    End Sub

    Private Sub cmbgrp_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgrp.Validating
        vdating(cmbgrp, "SELECT grp_nm FROM item_group WHERE (grp_nm = '" & Trim(cmbgrp.Text) & "')", "Please Select a Valid Group Name.")
    End Sub

    Private Sub cmbvat_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbvat.GotFocus
        populate(cmbvat, "SELECT taxnm FROM taxper WHERE (rec_lock = 'N') ORDER BY taxnm")
    End Sub

    Private Sub cmbvat_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbvat.LostFocus
        cmbvat.Height = 21
    End Sub

    Private Sub cmbvat_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbvat.Validated
        vdated(txtvatcd, "SELECT taxcd FROM taxper WHERE (taxnm = '" & Trim(cmbvat.Text) & "')")
    End Sub

    Private Sub cmbvat_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbvat.Validating
        vdating(cmbvat, "SELECT taxnm FROM taxper WHERE (taxnm = '" & Trim(cmbvat.Text) & "')", "Please Select a Valid Tax Name.")
    End Sub

    Private Sub cmbunt1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunt1.GotFocus
        populate(cmbunt1, "SELECT unt_nm FROM unt WHERE (rec_lock = 'N') ORDER BY unt_nm")
    End Sub

    Private Sub cmbunt1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunt1.LostFocus
        cmbunt1.Height = 21
    End Sub

    Private Sub cmbunt1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbunt1.Validated
        vdated(txtuntcd1, "SELECT unt_cd FROM unt WHERE (unt_nm = '" & Trim(cmbunt1.Text) & "')")
    End Sub

    Private Sub cmbunt1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunt1.Validating
        vdating(cmbunt1, "SELECT unt_nm FROM unt WHERE (unt_nm = '" & Trim(cmbunt1.Text) & "')", "Please Select a Valid Unit Name.")
    End Sub

    Private Sub cmbunt2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunt2.GotFocus
        If Val(txtmulti.Text) > 1 Then
            populate(cmbunt2, "SELECT unt_nm FROM unt WHERE (rec_lock = 'N') AND unt_cd<>" & Val(txtuntcd1.Text) & " ORDER BY unt_nm")
        Else
            populate(cmbunt2, "SELECT unt_nm FROM unt WHERE (rec_lock = 'N') ORDER BY unt_nm")
        End If
    End Sub

    Private Sub cmbunt2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunt2.LostFocus
        cmbunt2.Height = 21
    End Sub

    Private Sub cmbunt2_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbunt2.Validated
        vdated(txtuntcd2, "SELECT unt_cd FROM unt WHERE (unt_nm = '" & Trim(cmbunt2.Text) & "')")
    End Sub

    Private Sub cmbunt2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunt2.Validating
        vdating(cmbunt2, "SELECT unt_nm FROM unt WHERE (unt_nm = '" & Trim(cmbunt2.Text) & "')", "Please Select a Valid Unit Name.")
    End Sub

    Private Sub cmbgodwn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodwn.GotFocus
        populate(cmbgodwn, "SELECT godnm FROM godown WHERE (rec_lock = 'N') ORDER BY godnm")
    End Sub

    Private Sub cmbgodwn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodwn.LostFocus
        cmbgodwn.Height = 21
    End Sub

    Private Sub cmbgodwn_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbgodwn.Validated
        vdated(txtgdncd, "SELECT godsl FROM godown WHERE (godnm = '" & Trim(cmbgodwn.Text) & "')")
    End Sub

    Private Sub cmbgodwn_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgodwn.Validating
        vdating(cmbgodwn, "SELECT godnm FROM godown WHERE (godnm = '" & Trim(cmbgodwn.Text) & "')", "Please Select a Valid Godown Name.")
    End Sub

    Private Sub txtmrp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmrp.GotFocus, txtpurrt.GotFocus, txtopstk.GotFocus
        If Val(sender.text) = 0 Then
            sender.text = ""
        End If
    End Sub

    Private Sub txtmrp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmrp.LostFocus, txtpurrt.LostFocus, txtopstk.LostFocus
        sender.text = Format(Val(sender.text), "######0.00")
    End Sub

    Private Sub txtopstk_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtopstk.Validated
        If Val(txtclstk.Text) = 0 Then
            txtclstk.Text = txtopstk.Text
        End If
    End Sub

    Private Sub txtmulti_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmulti.LostFocus
        If Val(txtmulti.Text) = 0 Then
            txtmulti.Text = "1"
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            'If usr_tp = "A" Or usr_tp = "D" Then
            slno = dv.SelectedRows(0).Cells(7).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT it_cd FROM item WHERE it_cd=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    Dim ds1 As DataSet = get_dataset("SELECT it_cd FROM purch2 WHERE it_cd=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM item WHERE it_cd =" & Val(slno) & "")
                        SQLInsert("DELETE FROM untlnk WHERE it_cd =" & Val(slno) & "")
                        MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.dv_disp()
                    Else
                        MessageBox.Show("Sorry You Can't Delete The Product It Has Been Already Used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                Close1()
            End If
            'Else
            '    MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        End If
    End Sub

    Private Sub mnuexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexport.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            btnsave.Enabled = False
            Me.Text = "Item Master View Screen . . ."
            slno = dv.SelectedRows(0).Cells(7).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtitemnm.Focus()
        End If
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        itemnm = InputBox("Enter The Item Name.", "Search Box...", Nothing)
        If (itemnm Is Nothing OrElse itemnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY item.it_name) AS 'Sl.',item.it_name AS 'Product Name',item_group.grp_nm AS 'Group Name', taxper.txname AS 'Tax Name', STR(item.mrp,10,2) AS 'M.R.P',  STR(item.cl_stk,8,3) AS 'Stock',item.rec_lock, item.it_cd FROM item LEFT OUTER JOIN taxper ON item.taxcd = taxper.taxcd LEFT OUTER JOIN item_group ON item.grp_cd = item_group.grp_cd WHERE (item.it_name LIKE'" & itemnm & "%') ORDER BY item.it_name")
            dv.Columns.Clear()
            If dsedit.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dsedit.Tables(0)
                dv.Columns(6).Visible = False
                dv.Columns(7).Visible = False
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
        End If
    End Sub
End Class
