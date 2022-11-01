Imports vb = Microsoft.VisualBasic
Public Class frmpublication
    Dim comd As String

    Private Sub frmpublication_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnupublictn.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmpublication_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmpublication_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        comd = "E"
        MDI.mnupublictn.Enabled = False
        usrprmsn("mnupublictn", cmnuadd, cmnuedit, cmenudel, cmenuview)
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmpublication_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Publication Master Entry Screen . . ."
        txtpublication.Text = ""
        txtaddress.Text = ""
        txtcont.Text = ""
        txtcont1.Text = ""
        txtmail.Text = ""
        txtweb.Text = ""
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(pub_cd) as 'Max' FROM pubc")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtpublication.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, cmdview.Click
        Me.dv_disp()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpublication.Enter, txtaddress.Enter, txtcont.Enter, txtcont1.Enter, cmblock.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpublication.Leave, txtaddress.Leave, txtcont.Leave, txtcont1.Leave, cmblock.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

        sender.text = UCase(sender.text)
    End Sub

    Private Sub txtmail_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmail.Enter, txtweb.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub txtmail_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmail.Enter, txtweb.Enter
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub txtpublication_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpublication.KeyPress
        key(txtaddress, e)
        SPKey(e)
    End Sub

    Private Sub txtaddress_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaddress.KeyPress
        'key(txtcont, e)
        'SPKey(e)
    End Sub

    Private Sub txtcontact_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont.KeyPress
        key(txtcont1, e)
        NUM(e)
    End Sub

    Private Sub txtcontact1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont1.KeyPress
        key(txtmail, e)
        NUM(e)
    End Sub

    Private Sub txtmail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmail.KeyPress
        key(txtweb, e)
        SPKey(e)
    End Sub

    Private Sub txtweb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtweb.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub

    Private Sub txtmail_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmail.Validating
        If Trim(txtmail.Text) <> "" Then
            If txtmail.Text.IndexOf("@") = -1 OrElse txtmail.Text.IndexOf(".") = -1 Then
                e.Cancel = True
                MessageBox.Show("You Have Enter An Invalid Mail ID.Please Enter A Valid Email ID." & vbCrLf & "Ex. support@shradhatechnologies.com", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtmail.Focus()
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub txtweb_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtweb.Validating
        If Trim(txtweb.Text) <> "" Then
            website = LCase(Trim(txtweb.Text))
            If LCase(website.IndexOf("www")) = -1 OrElse txtweb.Text.IndexOf(".") = -1 Then
                e.Cancel = True
                MessageBox.Show("You Have Enter An Invalid Web Site.Please Enter A Valid Web Site." & vbCrLf & "Ex. www.shradhatechnologies.com", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtweb.Focus()
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
        If Trim(txtpublication.Text) = "" Then
            MessageBox.Show("Please Provide A Publication Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtpublication.Focus()
            Exit Sub
        End If
        Me.pub_save()
    End Sub

    Private Sub pub_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(pub_cd) as 'Max' FROM pubc")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO pubc(pub_cd,pub_nm,add1,add2,cont1,cont2,e_mail,web_site,rec_lock) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(txtpublication.Text) & "','" & Trim(txtaddress.Text) & "','','" & _
                          Trim(txtcont.Text) & "','" & Trim(txtcont1.Text) & "','" & Trim(txtmail.Text) & "','" & _
                          Trim(txtweb.Text) & "','" & vb.Left(cmblock.Text, 1) & "')")
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
                Dim ds As DataSet = get_dataset("SELECT pub_cd FROM pubc WHERE pub_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE pubc SET pub_nm='" & Trim(txtpublication.Text) & "',add1='" & Trim(txtaddress.Text) & "',cont1='" & _
                              Trim(txtcont.Text) & "',cont2='" & Trim(txtcont1.Text) & "',e_mail='" & Trim(txtmail.Text) & "',web_site='" & _
                              Trim(txtweb.Text) & "',rec_lock = '" & vb.Left(cmblock.Text, 1) & "' WHERE pub_cd =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY pub_nm) AS 'Sl.', pub_nm AS 'Publication Name', add1 AS 'Address', cont1 AS 'Contact No',pub_cd, rec_lock FROM pubc ORDER BY pub_nm")
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
            'Dim rw As Integer = 0
            'For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
            '    dv.Rows.Add()
            '    dv.Rows(i).Cells(0).Value = i + 1
            '    dv.Rows(i).Cells(1).Value = dsedit.Tables(0).Rows(rw).Item("pub_nm")
            '    dv.Rows(i).Cells(2).Value = dsedit.Tables(0).Rows(rw).Item("add1")
            '    dv.Rows(i).Cells(3).Value = dsedit.Tables(0).Rows(rw).Item("cont1")
            '    If dsedit.Tables(0).Rows(rw).Item("cont2") <> "" Then
            '        dv.Rows(i).Cells(3).Value = dsedit.Tables(0).Rows(rw).Item("cont1") & "," & dsedit.Tables(0).Rows(rw).Item("cont2")
            '    End If
            '    dv.Rows(i).Cells(4).Value = dsedit.Tables(0).Rows(rw).Item("pub_cd")
            '    If dsedit.Tables(0).Rows(rw).Item("rec_lock") = "Y" Then
            '        dv.Rows(i).DefaultCellStyle.BackColor = Color.White
            '        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
            '    Else
            '        dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
            '        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            '    End If
            '    rw = rw + 1
            'Next
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
        btnsave.Enabled = True
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT * FROM pubc WHERE pub_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtpublication.Text = dsedit.Tables(0).Rows(0).Item("pub_nm")
            txtaddress.Text = dsedit.Tables(0).Rows(0).Item("add1")
            txtcont.Text = dsedit.Tables(0).Rows(0).Item("cont1")
            txtcont1.Text = dsedit.Tables(0).Rows(0).Item("cont2")
            txtmail.Text = dsedit.Tables(0).Rows(0).Item("e_mail")
            txtweb.Text = dsedit.Tables(0).Rows(0).Item("web_site")
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
        Me.Text = "Publication Master Entry Screen . . ."
        dv.Visible = False
        txtpublication.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Edit"
            Me.Text = "Publication Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(4).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtpublication.Focus()
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
                Dim ds As DataSet = get_dataset("SELECT pub_cd FROM pubc WHERE pub_cd=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    'Dim ds1 As DataSet = get_dataset("SELECT pub_cd FROM prod_mst WHERE pub_cd=" & Val(slno) & "")
                    'If ds1.Tables(0).Rows.Count <> 0 Then
                    '    fnd = 1
                    'End If
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM pubc WHERE pub_cd =" & Val(slno) & "")
                        MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.dv_disp()
                    Else
                        MessageBox.Show("Sorry You Can't Delete The Publication It Has Been Already Used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Me.Text = "Publication Master View Screen . . ."
            slno = dv.SelectedRows(0).Cells(4).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtpublication.Focus()
        End If
    End Sub

    Private Sub cmenuserach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuserach.Click
        authnm = InputBox("Enter The Publication Name.", "Search Box...", Nothing)
        If (authnm Is Nothing OrElse authnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY pub_nm) AS 'Sl.', pub_nm AS 'Publication Name', add1 AS 'Address', cont1 AS 'Contact No',pub_cd, rec_lock FROM pubc WHERE (pubc.pub_nm LIKE'" & authnm & "%') ORDER BY pub_nm")
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
        End If
    End Sub
End Class
