Imports vb = Microsoft.VisualBasic
Public Class frmsession
    Dim comd As String

    Private Sub frmsession_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuSession.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmsession_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmsession_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuSession.Enabled = False
        usrprmsn("mnuSession", cmnuadd, cmnuedit, cmenudel, cmenuview)
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmsession_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Session Master Entry Screen . . ."
        txtscrl.Text = ""
        txtacdmcd.Text = ""
        txtsession.Text = ""
        txtduration.Text = ""
        startdt.Value = sys_date
        enddt.Value = sys_date
        txtsl.Text = 1
        cmbacyr.Text = ""
        astdt.Value = startdt.Value
        aendt.Value = astdt.Value
        cmblock.SelectedIndex = 0
        dv1.Rows.Clear()
        Dim ds As DataSet = get_dataset("SELECT MAX(sesn_cd) as 'Max' FROM sesion1")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtsession.Focus()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsession.Enter, txtduration.Enter, cmbacyr.Enter, cmblock.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsession.Leave, txtduration.Leave, cmbacyr.Leave, cmblock.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

        sender.text = UCase(sender.text)
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnext.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnview.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnext.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnview.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub txtsession_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsession.KeyPress
        key(txtduration, e)
        SPKey(e)
    End Sub

    Private Sub txtduration_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtduration.KeyPress
        key(startdt, e)
        NUM(e)
    End Sub

    Private Sub startdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startdt.KeyPress
        key(cmbacyr, e)
    End Sub

    Private Sub enddt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles enddt.KeyPress
        key(cmbacyr, e)
    End Sub

    Private Sub cmbayear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbacyr.KeyPress
        If Trim(cmbacyr.Text) = "" Then
            key(cmblock, e)
        Else
            key(astdt, e)
        End If
        SPKey(e)
    End Sub

    Private Sub asdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles astdt.KeyPress
        key(aendt, e)
    End Sub

    Private Sub aedt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles aendt.KeyPress
        key(btnnext, e)
    End Sub

    Private Sub btnnext_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnnext.KeyPress
        key(btnsave, e)
    End Sub

    Private Sub cmbacyr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacyr.GotFocus
        populate(cmbacyr, "SELECT sem_nm FROM semester ORDER BY sem_pos, sem_dur")
    End Sub

    Private Sub cmbacyr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacyr.LostFocus
        cmbacyr.Height = 21
    End Sub

    Private Sub cmbacyr_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbacyr.Validated
        Dim ds As DataSet = get_dataset("SELECT sem_cd,sem_dur FROM semester WHERE sem_nm='" & Trim(cmbacyr.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtacdmcd.Text = ds.Tables(0).Rows(0).Item(0)
            txtacdur.Text = ds.Tables(0).Rows(0).Item(1)
            aendt.Value = astdt.Value.AddMonths(Val(txtacdur.Text))
        End If
    End Sub

    Private Sub cmbacyr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbacyr.Validating

    End Sub

    Private Sub txtduration_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtduration.Validated
        enddt.Value = startdt.Value.AddMonths(Val(txtduration.Text))
    End Sub

    Private Sub startdt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles startdt.Validated
        enddt.Value = startdt.Value.AddMonths(Val(txtduration.Text))
        astdt.Value = startdt.Value
    End Sub

    Private Sub startdt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startdt.ValueChanged
        enddt.Value = startdt.Value.AddMonths(Val(txtduration.Text))
        astdt.Value = startdt.Value
    End Sub

    Private Sub astdt_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles astdt.Validating
        aendt.Value = astdt.Value.AddMonths(Val(txtacdur.Text))
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Me.dv_disp()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtsession.Text) = "" Then
            MessageBox.Show("Please Provide A Session Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtsession.Focus()
            Exit Sub
        End If
        If Val(txtduration.Text) = 0 Then
            MessageBox.Show("Please Provide A Month Duration.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtduration.Focus()
            Exit Sub
        End If
        Me.session_save()
    End Sub

    Private Sub session_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(sesn_cd) as 'Max' FROM sesion1")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO sesion1(sesn_cd,sesn_nm,sesn_dur,sesn_dt1,sesn_dt2,rec_lock) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(txtsession.Text) & "'," & Val(txtduration.Text) & ",'" & Format(startdt.Value, "dd/MMM/yyyy") & "','" & _
                          Format(enddt.Value, "dd/MMM/yyyy") & "','" & vb.Left(cmblock.Text, 1) & "')")
                Me.sem_save()
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
                Dim ds As DataSet = get_dataset("SELECT sesn_cd FROM sesion1 WHERE sesn_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE sesion1 SET sesn_nm='" & Trim(txtsession.Text) & "',sesn_dur=" & Val(txtduration.Text) & ",sesn_dt1='" & _
                              Format(startdt.Value, "dd/MMM/yyyy") & "',sesn_dt2='" & Format(enddt.Value, "dd/MMM/yyyy") & "',rec_lock='" & _
                              vb.Left(cmblock.Text, 1) & "' WHERE sesn_cd =" & Val(txtscrl.Text) & "")
                    Me.sem_save()
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                    Me.dv_disp()
                End If
                Close1()
            End If
        End If
    End Sub


    Private Sub btnnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnext.Click
        If Trim(txtsession.Text) = "" Then
            MessageBox.Show("Please Provide A Session Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtsession.Focus()
            Exit Sub
        End If
        If Trim(txtduration.Text) = "" Then
            MessageBox.Show("Please Provide A Duration.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtduration.Focus()
            Exit Sub
        End If
        If Trim(cmbacyr.Text) = "" Or Val(txtacdmcd.Text) = 0 Then
            MessageBox.Show("The Academic Year Should not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbacyr.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                x = dv1.Rows(i).Cells(4).Value
                If Val(txtacdmcd.Text) = x Then
                    MessageBox.Show("Sorry The Data Should Not Be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbacyr.Focus()
                    Exit Sub
                End If
            Next
        End If
        sl = Val(txtsl.Text)
        dv1.Rows.Add()
        dv1.Rows(sl - 1).Cells(0).Value = sl
        dv1.Rows(sl - 1).Cells(1).Value = cmbacyr.Text
        dv1.Rows(sl - 1).Cells(2).Value = Format(astdt.Value, "dd/MM/yyyy")
        dv1.Rows(sl - 1).Cells(3).Value = Format(aendt.Value, "dd/MM/yyyy")
        dv1.Rows(sl - 1).Cells(4).Value = Val(txtacdmcd.Text)
        dv1.Rows(sl - 1).Cells(5).Value = astdt.Value
        dv1.Rows(sl - 1).Cells(6).Value = aendt.Value
        sl += 1
        txtsl.Text = sl
        cmbacyr.Focus()
        astdt.Value = aendt.Value.AddDays(1)
        aendt.Value = astdt.Value
    End Sub

    Private Sub sem_save()
        If dv1.RowCount <> 0 Then
            SQLInsert("DELETE FROM sesion2 WHERE sesn_cd=" & Val(txtscrl.Text) & "")
            For i As Integer = 0 To dv1.RowCount - 1
                semdt1 = Format(dv1.Rows(i).Cells(5).Value, "dd/MMM/yyyy")
                semdt2 = Format(dv1.Rows(i).Cells(6).Value, "dd/MMM/yyyy")
                semcd = Val(dv1.Rows(i).Cells(4).Value)
                Dim ds1 As DataSet = get_dataset("SELECT max(sesn_sl) as 'Max' FROM sesion2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO sesion2(sesn_sl,sesn_cd,sem_cd,sem_dt1,sem_dt2) VALUES (" & Val(mxno) & "," & _
                          Val(txtscrl.Text) & "," & semcd & ",'" & semdt1 & "','" & semdt1 & "')")
            Next
        End If
    End Sub

    Private Sub sem_view()
        Dim ds As DataSet = get_dataset("SELECT sesion2.*, semester.sem_nm FROM sesion2 LEFT OUTER JOIN semester ON sesion2.sem_cd = semester.sem_cd WHERE sesion2.sesn_cd=" & Val(txtscrl.Text) & "")
        rw = 0
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("sem_nm")
                dv1.Rows(rw).Cells(2).Value = Format(ds.Tables(0).Rows(i).Item("sem_dt1"), "dd/MM/yyyy")
                dv1.Rows(rw).Cells(3).Value = Format(ds.Tables(0).Rows(i).Item("sem_dt2"), "dd/MM/yyyy")
                dv1.Rows(rw).Cells(4).Value = ds.Tables(0).Rows(i).Item("sem_cd")
                dv1.Rows(rw).Cells(5).Value = ds.Tables(0).Rows(i).Item("sem_dt1")
                dv1.Rows(rw).Cells(6).Value = ds.Tables(0).Rows(i).Item("sem_dt2")
                rw += 1
            Next
            txtsl.Text = rw + 1
        End If
    End Sub

    Private Sub dv_disp()
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY sesn_cd) AS 'Sl.',  sesn_nm AS 'Session Name', sesn_dur AS 'Duration', sesn_dt1 AS 'Start Date', sesn_dt2 AS 'End Date',sesn_cd, rec_lock FROM sesion1 ORDER BY sesn_cd")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(6).Visible = False
            dv.Columns(5).Visible = False
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
                '    dv.Rows(i).Cells(1).Value = dsedit.Tables(0).Rows(rw).Item("sesn_nm")
                '    dv.Rows(i).Cells(2).Value = dsedit.Tables(0).Rows(rw).Item("sesn_dur") & " Months"
                '    dv.Rows(i).Cells(3).Value = Format(dsedit.Tables(0).Rows(rw).Item("sesn_dt1"), "dd/MM/yyyy")
                '    dv.Rows(i).Cells(4).Value = Format(dsedit.Tables(0).Rows(rw).Item("sesn_dt2"), "dd/MM/yyyy")
                '    dv.Rows(i).Cells(5).Value = dsedit.Tables(0).Rows(rw).Item("sesn_cd")
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
        Dim dsedit As DataSet = get_dataset("SELECT * FROM sesion1 WHERE sesn_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtsession.Text = dsedit.Tables(0).Rows(0).Item("sesn_nm")
            txtduration.Text = dsedit.Tables(0).Rows(0).Item("sesn_dur")
            startdt.Value = dsedit.Tables(0).Rows(0).Item("sesn_dt1")
            enddt.Value = dsedit.Tables(0).Rows(0).Item("sesn_dt2")
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
                cmblock.SelectedIndex = 1
            Else
                cmblock.SelectedIndex = 0
            End If
            Me.sem_view()
        End If
        Close1()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Add"
        Me.Text = "Session Master Entry Screen . . ."
        dv.Visible = False
        txtsession.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Session Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtsession.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            'If usr_tp = "A" Or usr_tp = "D" Then
            slno = dv.SelectedRows(0).Cells(5).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT sesn_cd FROM sesion1 WHERE sesn_cd=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    'Dim ds1 As DataSet = get_dataset("SELECT sesn_cd FROM prod_mst WHERE sesn_cd=" & Val(slno) & "")
                    'If ds1.Tables(0).Rows.Count <> 0 Then
                    '    fnd = 1
                    'End If
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM sesion1 WHERE sesn_cd =" & Val(slno) & "")
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

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
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

    Private Sub mnuexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexport.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            btnsave.Enabled = False
            Me.Text = "Session Master View Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtsession.Focus()
        End If
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        authnm = InputBox("Enter The Session Name.", "Search Box...", Nothing)
        If (authnm Is Nothing OrElse authnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY sesn_cd) AS 'Sl.',  sesn_nm AS 'Session Name', sesn_dur AS 'Duration', sesn_dt1 AS 'Start Date', sesn_dt2 AS 'End Date',sesn_cd, rec_lock FROM sesion1 WHERE (sesion1.sesn_nm LIKE'" & authnm & "%') ORDER BY sesn_cd")
            dv.Columns.Clear()
            If dsedit.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dsedit.Tables(0)
                dv.Columns(6).Visible = False
                dv.Columns(5).Visible = False
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
