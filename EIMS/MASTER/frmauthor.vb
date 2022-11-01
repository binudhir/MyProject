Imports vb = Microsoft.VisualBasic
Public Class frmauthor
    Dim comd As String

    Private Sub frmauther_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuauthr.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmauther_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmauther_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        comd = "E"
        MDI.mnuauthr.Enabled = False
        usrprmsn("mnuauthr", cmnuadd, cmnuedit, cmenudel, cmenuview)
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmauthor_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Author Master Entry Screen . . ."
        txtscrl.Text = ""
        txtauthornm.Text = ""
        txtaddress.Text = ""
        txtcontact.Text = ""
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(auth_cd) as 'Max' FROM author")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtauthornm.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, cmdview.Click
        Me.dv_disp()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtauthornm.Enter, txtaddress.Enter, txtcontact.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtauthornm.Leave, txtaddress.Leave, txtcontact.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

        sender.text = UCase(sender.text)
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.MouseEnter, btnsave.MouseEnter, cmdview.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.MouseLeave, btnsave.MouseLeave, cmdview.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub txtauthornm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtauthornm.KeyPress
        key(txtaddress, e)
        SPKey(e)
    End Sub

    Private Sub txtaddress_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaddress.KeyPress
        'key(txtcontact, e)
        'SPKey(e)
    End Sub

    Private Sub txtcontact_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontact.KeyPress
        key(cmblock, e)
        NUM(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Add"
    End Sub

    Private Sub btnexit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtauthornm.Text) = "" Then
            MessageBox.Show("Please Provide An Author Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtauthornm.Focus()
            Exit Sub
        End If
        Me.auth_save()
    End Sub

    Private Sub auth_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(auth_cd) as 'Max' FROM author")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO author(auth_cd,auth_nm,add1,cont,rec_lock) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(txtauthornm.Text) & "','" & Trim(txtaddress.Text) & "','" & Trim(txtcontact.Text) & "','" & _
                          vb.Left(cmblock.Text, 1) & "')")
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
                Dim ds As DataSet = get_dataset("SELECT auth_cd FROM author WHERE auth_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE author SET auth_nm='" & Trim(txtauthornm.Text) & "',add1='" & Trim(txtaddress.Text) & "',cont='" & _
                              Trim(txtcontact.Text) & "',rec_lock='" & vb.Left(cmblock.Text, 1) & "' WHERE auth_cd =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY auth_nm) AS 'Sl.',auth_nm AS 'Author',add1 AS 'Address',cont AS 'Contact',auth_cd,rec_lock FROM author ORDER BY auth_nm")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(4).Visible = False
            dv.Columns(5).Visible = False
           
            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(5).Value

                If reclock = "Y" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    'dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
        btnsave.Enabled = True
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT * FROM author WHERE auth_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtauthornm.Text = dsedit.Tables(0).Rows(0).Item("auth_nm")
            txtaddress.Text = dsedit.Tables(0).Rows(0).Item("add1")
            txtcontact.Text = dsedit.Tables(0).Rows(0).Item("cont")
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
                cmblock.SelectedIndex = 1
            Else
                cmblock.SelectedIndex = 0
            End If
        End If
        Close1()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Add"
        Me.Text = "Author Entry Screen . . ."
        dv.Visible = False
        txtauthornm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Edit"
            Me.Text = "Author Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(4).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtauthornm.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            'If usr_tp = "A" Or usr_tp = "D" Then
            slno = dv.SelectedRows(0).Cells(4).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT auth_cd FROM author WHERE auth_cd=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    'Dim ds1 As DataSet = get_dataset("SELECT auth_cd FROM prod_mst WHERE auth_cd=" & Val(slno) & "")
                    'If ds1.Tables(0).Rows.Count <> 0 Then
                    '    fnd = 1
                    'End If
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM author WHERE auth_cd =" & Val(slno) & "")
                        MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.dv_disp()
                    Else
                        MessageBox.Show("Sorry You Can't Delete The Group It Has Been Already Used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            btnsave.Enabled = False
            Me.Text = "Author Master View Screen . . ."
            slno = dv.SelectedRows(0).Cells(4).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtauthornm.Focus()
        End If
    End Sub

    Private Sub mnuexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexport.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        authnm = InputBox("Enter The Auther Name.", "Search Box...", Nothing)
        If (authnm Is Nothing OrElse authnm = "") Then
            'User hit cancel
        Else
            Dim dssear As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY auth_nm) AS 'Sl.',auth_nm AS 'Author',add1 AS 'Address',cont AS 'Contact',auth_cd,rec_lock FROM author WHERE (author.auth_nm LIKE'" & authnm & "%') ORDER BY auth_nm")
            dv.Columns.Clear()
            If dssear.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dssear.Tables(0)
                dv.Columns(4).Visible = False
                dv.Columns(5).Visible = False

                For i As Integer = 0 To dv.Rows.Count - 1
                    reclock = dv.Rows(i).Cells(5).Value

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
