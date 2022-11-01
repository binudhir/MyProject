Imports vb = Microsoft.VisualBasic
Public Class frmcollhd
    Dim comd As String

    Private Sub frmcollhd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuCollection.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmcollhd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmcollhd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuCollection.Enabled = False
        usrprmsn("mnuCollection", cmnuadd, cmnuedit, cmenudel, cmenuview)
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmcollhd_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Collection Head A/c Master Entry Screen . . ."
        txtscrl.Text = ""
        txtcollnm.Text = ""
        txtamt.Text = "0.00"
        cmblock.SelectedIndex = 0
        cmbtype.SelectedIndex = 0
        cmbschedule.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(coll_cd) as 'Max' FROM coll")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtcollnm.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, cmdview.Click
        Me.dv_disp()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcollnm.Enter, cmblock.Enter, cmbschedule.Enter, cmbtype.Enter, txtamt.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcollnm.Leave, cmblock.Leave, cmbschedule.Leave, cmbtype.Leave, txtamt.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

        sender.text = UCase(sender.text)
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub txtcollnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcollnm.KeyPress
        key(cmbtype, e)
        SPKey(e)
    End Sub

    Private Sub cmbtype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtype.KeyPress
        key(cmbschedule, e)
    End Sub

    Private Sub cmbschedule_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbschedule.KeyPress
        key(txtamt, e)
    End Sub

    Private Sub txtamt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtamt.KeyPress
        key(cmblock, e)
        NUM1(e)
    End Sub

    Private Sub txtamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamt.GotFocus
        If Val(txtamt.Text) = 0 Then
            txtamt.Text = ""
        End If
    End Sub

    Private Sub txtamt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamt.LostFocus
        txtamt.Text = Format(Val(txtamt.Text), "########0.00")
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
        If Trim(txtcollnm.Text) = "" Then
            MessageBox.Show("Please Provide A Collection Head Of A/c Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtcollnm.Focus()
            Exit Sub
        End If
        Me.coll_save()
    End Sub

    Private Sub coll_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(coll_cd) as 'Max' FROM coll")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO coll (coll_cd,coll_nm,coll_tp,schd,rec_lock,is_adm,colamt) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(txtcollnm.Text) & "','" & vb.Left(cmbtype.Text, 1) & "','" & vb.Left(cmbschedule.Text, 1) & "','" & _
                          vb.Left(cmblock.Text, 1) & "','N'," & Val(txtamt.Text) & ")")
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
                Dim ds As DataSet = get_dataset("SELECT coll_cd FROM coll WHERE coll_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE coll SET coll_nm='" & Trim(txtcollnm.Text) & "',coll_tp='" & vb.Left(cmbtype.Text, 1) & "',schd='" & _
                              vb.Left(cmbschedule.Text, 1) & "',rec_lock='" & _
                              vb.Left(cmblock.Text, 1) & "',colamt=" & Val(txtamt.Text) & " WHERE coll_cd =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY coll_nm) AS 'Sl.', coll_nm AS 'Collection Head Name', (CASE WHEN coll_tp='1' THEN 'Normal' WHEN coll_tp='2' THEN 'Library Fine' WHEN coll_tp='3' THEN 'Lab Fine' WHEN coll_tp='4' THEN 'Misc. Fine' END) AS 'Collection Type', (CASE WHEN schd='N' THEN 'NO' WHEN SCHD='Y' THEN 'YES' END) AS 'Scheduled', coll_cd , rec_lock FROM coll ORDER BY coll_nm")
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
            '    dv.Rows(i).Cells(1).Value = dsedit.Tables(0).Rows(rw).Item("coll_nm")
            '    If dsedit.Tables(0).Rows(rw).Item("coll_tp") = "1" Then
            '        dv.Rows(i).Cells(2).Value = "Normal"
            '    ElseIf dsedit.Tables(0).Rows(rw).Item("coll_tp") = "2" Then
            '        dv.Rows(i).Cells(2).Value = "Library Fine"
            '    ElseIf dsedit.Tables(0).Rows(rw).Item("coll_tp") = "3" Then
            '        dv.Rows(i).Cells(2).Value = "Lab. Fine"
            '    Else
            '        dv.Rows(i).Cells(2).Value = "Misc. Fine"
            '    End If

            '    If dsedit.Tables(0).Rows(rw).Item("schd") = "Y" Then
            '        dv.Rows(i).Cells(3).Value = "Yes"
            '    Else
            '        dv.Rows(i).Cells(3).Value = "No"
            '    End If
            '    dv.Rows(i).Cells(4).Value = dsedit.Tables(0).Rows(rw).Item("coll_cd")
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
        Dim dsedit As DataSet = get_dataset("SELECT * FROM coll WHERE coll_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtcollnm.Text = dsedit.Tables(0).Rows(0).Item("coll_nm")
            cmbtype.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("coll_tp")) - 1
            txtamt.Text = Format(dsedit.Tables(0).Rows(0).Item("colamt"), "#######0.00")
            If dsedit.Tables(0).Rows(0).Item("schd") = "Y" Then
                cmbschedule.SelectedIndex = 1
            Else
                cmbschedule.SelectedIndex = 0
            End If
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
        Me.Text = "Collection Head A/c Master Entry Screen . . ."
        dv.Visible = False
        txtcollnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Edit"
            Me.Text = "Collection Head A/c Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(4).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtcollnm.Focus()
        End If
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            btnsave.Enabled = False
            Me.Text = "Collection Head A/c Master View Screen . . ."
            slno = dv.SelectedRows(0).Cells(4).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtcollnm.Focus()
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
                Dim ds As DataSet = get_dataset("SELECT coll_cd FROM coll WHERE coll_cd=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    'Dim ds1 As DataSet = get_dataset("SELECT coll_cd FROM prod_mst WHERE coll_cd=" & Val(slno) & "")
                    'If ds1.Tables(0).Rows.Count <> 0 Then
                    '    fnd = 1
                    'End If
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM coll WHERE coll_cd =" & Val(slno) & "")
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

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        collnm = InputBox("Enter The Collection Head Account Name.", "Search Box...", Nothing)
        If (collnm Is Nothing OrElse collnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY coll_nm) AS 'Sl.', coll_nm AS 'Collection Head Name', (CASE WHEN coll_tp='1' THEN 'Normal' WHEN coll_tp='2' THEN 'Library Fine' WHEN coll_tp='3' THEN 'Lab Fine' WHEN coll_tp='4' THEN 'Misc. Fine' END) AS 'Collection Type', (CASE WHEN schd='N' THEN 'NO' WHEN SCHD='Y' THEN 'YES' END) AS 'Scheduled', coll_cd , rec_lock FROM coll WHERE (coll.coll_nm LIKE'" & collnm & "%') ORDER BY coll_nm")
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
