Imports vb = Microsoft.VisualBasic
Public Class frmuser
    Dim comd As String

    Private Sub frmuser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmuser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmuser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmuser_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        txtscrl.Text = ""
        cmbempid.Text = ""
        txtcont1.Text = ""
        txtcont2.Text = ""
        txtusrnm.Text = ""
        txtadd2.Text = ""
        txtadd1.Text = ""
        txtmailid.Text = ""
        cmblock.SelectedIndex = 0
        cmbusrlvl.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(usr_sl) as 'Max' FROM usr")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        cmbempid.Focus()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Me.dv_disp()
    End Sub

    Private Sub cmdview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.Click
        Me.dv_disp()
    End Sub

    Private Sub txtmembr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtusrnm.Enter, txtcont2.Enter, txtcont1.Enter, txtadd2.Enter, txtadd1.Enter, cmblock.Enter, cmbusrlvl.Enter, txtmailid.Enter, cmbempid.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub txtmembr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtusrnm.Leave, txtcont2.Leave, txtcont1.Leave, txtadd2.Leave, txtadd1.Leave, cmblock.Leave, cmbusrlvl.Leave, txtmailid.Leave, cmbempid.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
        sender.Text = UCase(Trim(sender.Text))
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub txtcont1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont1.KeyPress
        key(txtcont2, e)
        NUM(e)
    End Sub

    Private Sub txtsrtnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtusrnm.KeyPress
        key(txtadd1, e)
        SPKey(e)
    End Sub

    Private Sub txtadd1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd1.KeyPress
        key(txtadd2, e)
        SPKey(e)
    End Sub

    Private Sub txtadd2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd2.KeyPress
        key(txtcont1, e)
        SPKey(e)
    End Sub

    Private Sub txtcont2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont2.KeyPress
        key(txtmailid, e)
        NUM(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub

    Private Sub cmbusrlvl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbusrlvl.KeyPress
        key(txtusrnm, e)
    End Sub

    Private Sub txtmailid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmailid.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub txtmailid_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmailid.Validating
        If Trim(txtmailid.Text) <> "" Then
            If txtmailid.Text.IndexOf("@") = -1 OrElse txtmailid.Text.IndexOf(".") = -1 Then
                e.Cancel = True
                MessageBox.Show("You Have Enter An Invalid Mail ID.Please Enter A Valid Email ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtmailid.Focus()
            Else
                e.Cancel = False
            End If
        End If
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
        If Trim(cmbempid.Text) = "" Then
            MessageBox.Show("Please Provide A User Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbempid.Focus()
            Exit Sub
        End If
        'If Trim(txtadd1.Text) = "" Then
        '    MessageBox.Show("Please Provide A User Address.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtadd1.Focus()
        '    Exit Sub
        'End If
        'If Trim(txtcont1.Text) = "" Then
        '    MessageBox.Show("Please Provide A User Contact Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtcont1.Focus()
        '    Exit Sub
        'End If
        Me.user_save()
    End Sub

    Private Sub user_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(usr_sl) as 'Max' FROM usr")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO usr (usr_sl,usr_id,usr_pwd,usr_tp,usr_nm,usr_add1,usr_add2,usr_ph1,usr_ph2,usr_mail,login_block," & _
                          "frst_login,login_atmpt,staf_sl,rec_lock) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(cmbempid.Text) & "','password','" & vb.Left(cmbusrlvl.Text, 1) & "', '" & Trim(txtusrnm.Text) & "',  '" & _
                          Trim(txtadd1.Text) & "','" & Trim(txtadd2.Text) & "','" & Trim(txtcont1.Text) & "','" & _
                          Trim(txtcont2.Text) & "','" & Trim(txtmailid.Text) & "','" & vb.Left(cmblock.Text, 1) & "','N',0,0,'" & vb.Left(cmblock.Text, 1) & "')")
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MessageBox.Show("The User ID = " & Trim(cmbempid.Text) & " AND Default Password = password " & vbCrLf & "It Is Requested That Please Change Your Default Password In Your First Login.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.usr_assign()
                Me.clr()
                Close1()
            End If
        Else
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT usr_sl FROM usr WHERE usr_sl=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE usr SET usr_tp='" & vb.Left(cmbusrlvl.Text, 1) & "',usr_nm='" & _
                              Trim(txtusrnm.Text) & "',usr_add1='" & Trim(txtadd1.Text) & "',usr_add2='" & Trim(txtadd2.Text) & "',usr_ph1='" & _
                              Trim(txtcont1.Text) & "',usr_ph2='" & Trim(txtcont2.Text) & "',usr_mail='" & Trim(txtmailid.Text) & "',login_block='" & _
                              vb.Left(cmblock.Text, 1) & "',rec_lock='" & vb.Left(cmblock.Text, 1) & "' WHERE usr_sl =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY usr_sl) AS 'Sl.',usr_sl,  usr_id AS 'User ID', (CASE WHEN usr_tp='A' THEN 'Admin' WHEN usr_tp='M' THEN 'Maneger' WHEN usr_tp='O' THEN 'Operator' END) AS 'User Level', usr_nm AS 'Name', usr_ph1 AS 'Contact' FROM usr WHERE usr_tp<>'D' ORDER BY usr_sl")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(1).Visible = False
            'dv.Columns(5).Visible = False
            'dv.Columns(4).Visible = False
            'For i As Integer = 0 To dv.Rows.Count - 1
            '    reclock = dv.Rows(i).Cells(5).Value
            '    If reclock = "Y" Then
            '        dv.Rows(i).DefaultCellStyle.BackColor = Color.White
            '        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
            '    Else
            '        'dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
            '        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            '    End If
            'Next
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT * FROM usr WHERE usr_sl=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            cmbempid.Text = dsedit.Tables(0).Rows(0).Item("usr_id")
            txtusrnm.Text = dsedit.Tables(0).Rows(0).Item("usr_nm")
            txtadd1.Text = dsedit.Tables(0).Rows(0).Item("usr_add1")
            txtadd2.Text = dsedit.Tables(0).Rows(0).Item("usr_add2")
            txtcont1.Text = dsedit.Tables(0).Rows(0).Item("usr_ph1")
            txtcont2.Text = dsedit.Tables(0).Rows(0).Item("usr_ph2")
            txtmailid.Text = dsedit.Tables(0).Rows(0).Item("usr_mail")
            If dsedit.Tables(0).Rows(0).Item("usr_tp") = "A" Then
                cmbusrlvl.SelectedIndex = 0
            ElseIf dsedit.Tables(0).Rows(0).Item("usr_tp") = "D" Then
                cmbusrlvl.SelectedIndex = 0
            ElseIf dsedit.Tables(0).Rows(0).Item("usr_tp") = "M" Then
                cmbusrlvl.SelectedIndex = 1
            Else
                cmbusrlvl.SelectedIndex = 2
            End If
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
                cmblock.SelectedIndex = 1
            Else
                cmblock.SelectedIndex = 0
            End If
        End If
        Close1()
    End Sub

    Private Sub usr_assign()
        Dim ds As DataSet = get_dataset("SELECT * FROM menumst ORDER BY menu_sl")
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim ds2 As DataSet = get_dataset("SELECT max(asgn_no) as 'Max' FROM user_assign")
                asgn_no = 1
                If ds2.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds2.Tables(0).Rows(0).Item(0)) Then
                        asgn_no = ds2.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                menusl = ds.Tables(0).Rows(i).Item("menu_sl")
                menu_tp = ds.Tables(0).Rows(i).Item("menu_tp")
                menu_prmsn = ds.Tables(0).Rows(i).Item("menu_prmsn")
                viewprmsn = 0
                addprmsn = 0
                editprmsn = 0
                delprmsn = 0
                If vb.Left(cmbusrlvl.Text, 1) = "D" And menu_prmsn = "Y" Then
                    viewprmsn = 1
                    addprmsn = 1
                    editprmsn = 1
                    delprmsn = 1
                End If
                If vb.Left(ds.Tables(0).Rows(i).Item("menu_tp"), 1) = "R" Then
                    viewprmsn = 0
                ElseIf ds.Tables(0).Rows(i).Item("menu_tp") = "X" Or ds.Tables(0).Rows(i).Item("menu_tp") = "U" Or ds.Tables(0).Rows(i).Item("menu_tp") = "C" Then
                    addprmsn = 0
                    delprmsn = 0
                End If
                Start1()
                SQLInsert("INSERT INTO user_assign (asgn_no,user_sl,menu_sl,add_prm,edit_prm,delete_prm,view_prm) VALUES (" & Val(asgn_no) & "," & _
                          Val(txtscrl.Text) & "," & Val(menusl) & "," & Val(addprmsn) & "," & Val(editprmsn) & "," & Val(delprmsn) & "," & Val(viewprmsn) & ")")
                Close1()
                asgn_no += 1
            Next
        End If
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        comd = "E"
        btnsave.Text = "Add"
        Me.Text = "User Master Entry Screen . . ."
        cmbempid.Enabled = True
        dv.Visible = False
        cmbempid.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Edit"
            Me.Text = "User Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(1).Value
            Me.dv_edit(slno)
            cmbempid.Enabled = False
            dv.Visible = False
            cmbempid.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        If dv.RowCount <> 0 Then
            slno = dv.SelectedRows(0).Cells(1).Value
            cnfr = MessageBox.Show("Are You Sure To Block The User.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT usr_sl FROM usr WHERE usr_sl=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE usr SET rec_lock ='Y' WHERE usr_sl =" & Val(slno) & "")
                    MessageBox.Show("Record Blocked Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dv_disp()
                End If
                Close1()
            End If
        End If
    End Sub

    Private Sub cmbempid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbempid.GotFocus
        populate(cmbempid, "SELECT usr_id FROM usr WHERE usr_tp<>'A' AND usr_tp<>'D' ORDER BY usr_id")
    End Sub

    Private Sub cmbempid_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbempid.LostFocus
        cmbempid.Height = 21
    End Sub

    Private Sub cmbempid_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbempid.Validated
        vdated(txtscrl, "SELECT usr_sl FROM usr WHERE usr_id='" & Trim(cmbempid.Text) & "'")
    End Sub

    Private Sub cmbempid_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbempid.Validating
        If comd = "E" Then
            Dim ds As DataSet = get_dataset("SELECT usr_id FROM usr WHERE usr_id='" & Trim(cmbempid.Text) & "' AND rec_lock='N'")
            If ds.Tables(0).Rows.Count <> 0 Then
                MessageBox.Show("Sorry The User ID Already Present in Your Database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbempid.Focus()
            End If
        Else
            vdating(cmbempid, "SELECT usr_id FROM usr WHERE usr_id='" & Trim(cmbempid.Text) & "' AND rec_lock='N'", "Please Select A Valid User ID.")
        End If
    End Sub

    Private Sub cmbempid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbempid.KeyPress
        key(cmbusrlvl, e)
        SPKey(e)
    End Sub
End Class
