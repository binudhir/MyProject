Imports vb = Microsoft.VisualBasic
Public Class frmoccu
    Dim comd As String

    Private Sub frmoccu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuOccupation.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmoccu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmoccu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuOccupation.Enabled = True
        usrprmsn("mnuOccupation", cmnuadd, cmnuedit, cmenudel, cmenuview)
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmoccu_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Occupation Master Entry Screen . . ."
        txtscrl.Text = ""
        txtocunm.Text = ""
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(ocu_cd) as 'Max' FROM ocupation")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtocunm.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.dv_disp()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtocunm.Enter, cmblock.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtocunm.Leave, cmblock.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

        sender.text = UCase(sender.text)
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub txttradnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtocunm.KeyPress
        key(cmblock, e)
        SPKey(e)
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
        If Trim(txtocunm.Text) = "" Then
            MessageBox.Show("Please Provide A Occupation Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtocunm.Focus()
            Exit Sub
        End If
        Me.trad_save()
    End Sub

    Private Sub trad_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(ocu_cd) as 'Max' FROM ocupation")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO ocupation (ocu_cd,ocu_nm,rec_lock) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(txtocunm.Text) & "','" & _
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
                Dim ds As DataSet = get_dataset("SELECT ocu_cd FROM ocupation WHERE ocu_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE ocupation SET ocu_nm='" & Trim(txtocunm.Text) & "',rec_lock='" & _
                              vb.Left(cmblock.Text, 1) & "' WHERE ocu_cd =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY ocu_cd) AS 'Sl.', ocu_cd, ocu_nm AS 'Ocupation', rec_lock FROM ocupation ORDER BY ocu_cd")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(1).Visible = False
            dv.Columns(3).Visible = False
            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(3).Value
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
            '    dv.Rows(i).Cells(1).Value = dsedit.Tables(0).Rows(rw).Item("ocu_nm")
            '    dv.Rows(i).Cells(2).Value = dsedit.Tables(0).Rows(rw).Item("ocu_cd")
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
        Dim dsedit As DataSet = get_dataset("SELECT * FROM ocupation WHERE ocu_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtocunm.Text = dsedit.Tables(0).Rows(0).Item("ocu_nm")
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
        Me.Text = "Occupation Master Entry Screen . . ."
        dv.Visible = False
        txtocunm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Occupation Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtocunm.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            'If usr_tp = "A" Or usr_tp = "D" Then
            slno = dv.SelectedRows(0).Cells(2).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT ocu_cd FROM ocupation WHERE ocu_cd=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    'Dim ds1 As DataSet = get_dataset("SELECT ocu_cd FROM prod_mst WHERE ocu_cd=" & Val(slno) & "")
                    'If ds1.Tables(0).Rows.Count <> 0 Then
                    '    fnd = 1
                    'End If
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM ocupation WHERE ocu_cd =" & Val(slno) & "")
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

    Private Sub mnuexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexport.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            btnsave.Enabled = False
            Me.Text = "Occupation Master View Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtocunm.Focus()
        End If
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        authnm = InputBox("Enter The Occupation Name.", "Search Box...", Nothing)
        If (authnm Is Nothing OrElse authnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY ocu_cd) AS 'Sl.', ocu_cd, ocu_nm AS 'Ocupation', rec_lock FROM ocupation WHERE (ocupation.ocu_nm LIKE'" & authnm & "%') ORDER BY ocu_cd")
            dv.Columns.Clear()
            If dsedit.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dsedit.Tables(0)
                dv.Columns(1).Visible = False
                dv.Columns(3).Visible = False
                For i As Integer = 0 To dv.Rows.Count - 1
                    reclock = dv.Rows(i).Cells(3).Value
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
