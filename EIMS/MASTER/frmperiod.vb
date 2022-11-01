Imports vb = Microsoft.VisualBasic
Public Class frmperiod
    Dim comd As String

    Private Sub frmperiod_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuPeriod.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmperiod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmperiod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sttm.Value = Now
        endtm.Value = Now
        txtdur.Text = "0"
        MDI.mnuPeriod.Enabled = False
        usrprmsn("mnuCountry", cmnuadd, cmnuedit, cmenudel, cmenuview)
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmperiod_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Period Master Entry Screen . . ."
        txtscrl.Text = ""
        txtprdnm.Text = ""
        cmbpgrp.Text = ""
        txtpgrpcd.Text = 0
        cmblock.SelectedIndex = 0
        sttm.Value = endtm.Value
        Dim ds As DataSet = get_dataset("SELECT max(prd_cd) as 'Max' FROM period1")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtprdnm.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, cmdview.Click
        Me.dv_disp()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprdnm.Enter, cmblock.Enter, cmbpgrp.Enter, txtdur.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprdnm.Leave, cmblock.Leave, cmbpgrp.Leave, txtdur.Leave
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

    Private Sub txttradnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprdnm.KeyPress
        key(cmbpgrp, e)
        SPKey(e)
    End Sub

    Private Sub cmbcntr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpgrp.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(sttm, e)
    End Sub

    Private Sub cmbcntr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpgrp.GotFocus
        populate(cmbpgrp, "SELECT pgrp_nm FROM pgroup WHERE rec_lock='N' ORDER BY pgrp_nm")
    End Sub

    Private Sub cmbcntr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpgrp.LostFocus
        cmbpgrp.Height = 21
    End Sub

    Private Sub cmbcntr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpgrp.Validated
        vdated(txtpgrpcd, "SELECT pgrp_cd FROM pgroup WHERE pgrp_nm='" & Trim(cmbpgrp.Text) & "'")
    End Sub

    Private Sub cmbcntr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbpgrp.Validating
        vdating(cmbpgrp, "SELECT pgrp_nm FROM pgroup WHERE pgrp_nm='" & Trim(cmbpgrp.Text) & "'", "Please Select A Valid Country Name.")
    End Sub

    Private Sub sttm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles sttm.KeyPress
        key(txtdur, e)
    End Sub

    Private Sub txtdur_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdur.KeyPress
        key(endtm, e)
        NUM(e)
    End Sub

    Private Sub endtm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles endtm.KeyPress
        key(btnsave, e)
    End Sub

    Private Sub txtdur_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdur.Validated
        endtm.Value = sttm.Value.AddMinutes(txtdur.Text)
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
        If Trim(txtprdnm.Text) = "" Then
            MessageBox.Show("Please Provide A Period Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtprdnm.Focus()
            Exit Sub
        End If
        If Trim(cmbpgrp.Text) = "" Or Val(txtpgrpcd.Text) = 0 Then
            MessageBox.Show("The Group Name Should not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtprdnm.Focus()
            Exit Sub
        End If
        If Val(txtdur.Text) = 0 Then
            MessageBox.Show("The Period Duration Should not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtprdnm.Focus()
            Exit Sub
        End If
        Me.trad_save()
    End Sub

    Private Sub trad_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(prd_cd) as 'Max' FROM period1")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO period1 (prd_cd,prd_nm,pgrp_cd,rec_lock,frm_time,to_time,net_time,CreateId,CreateDt," & _
                          "ModifyId,ModifyDt) VALUES (" & Val(txtscrl.Text) & ",'" & Trim(txtprdnm.Text) & "'," & _
                          Val(txtpgrpcd.Text) & ",'" & vb.Left(cmblock.Text, 1) & "','" & Format(sttm.Value, "HH:mm") & "','" & _
                          Format(endtm.Value, "HH:mm") & "'," & Val(txtdur.Text) & "," & Val(usr_sl) & ",'" & _
                          Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "')")
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
                Dim ds As DataSet = get_dataset("SELECT prd_cd FROM period1 WHERE prd_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE period1 SET prd_nm='" & Trim(txtprdnm.Text) & "',pgrp_cd=" & Val(txtpgrpcd.Text) & ",rec_lock='" & _
                              vb.Left(cmblock.Text, 1) & "',frm_time='" & Format(sttm.Value, "HH:mm") & "',to_time='" & _
                              Format(endtm.Value, "HH:mm") & "',net_time=" & Val(txtdur.Text) & ",ModifyId=" & _
                              Val(usr_sl) & ",ModifyDt='" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "' WHERE prd_cd =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT period1.*, pgroup.pgrp_nm FROM period1 LEFT OUTER JOIN pgroup ON period1.pgrp_cd = pgroup.pgrp_cd ORDER BY period1.prd_nm")
        dv.Rows.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                dv.Rows.Add()
                dv.Rows(i).Cells(0).Value = i + 1
                dv.Rows(i).Cells(1).Value = dsedit.Tables(0).Rows(rw).Item("prd_nm")
                dv.Rows(i).Cells(2).Value = dsedit.Tables(0).Rows(rw).Item("pgrp_nm")
                dv.Rows(i).Cells(3).Value = Format(dsedit.Tables(0).Rows(rw).Item("frm_time"), "HH:mm")
                dv.Rows(i).Cells(4).Value = Format(dsedit.Tables(0).Rows(rw).Item("to_time"), "HH:mm")
                dv.Rows(i).Cells(5).Value = Format(dsedit.Tables(0).Rows(rw).Item("net_time"), "####0") & " Minute"
                dv.Rows(i).Cells(6).Value = dsedit.Tables(0).Rows(rw).Item("prd_cd")
                If dsedit.Tables(0).Rows(rw).Item("rec_lock") = "Y" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
                rw = rw + 1
            Next
        End If
        Close1()
        dv.Visible = True
        dv.Focus()
        dv.Dock = DockStyle.Fill
        btnsave.Enabled = True
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT period1.*, pgroup.pgrp_nm FROM period1 LEFT OUTER JOIN pgroup ON period1.pgrp_cd = pgroup.pgrp_cd WHERE period1.prd_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtprdnm.Text = dsedit.Tables(0).Rows(0).Item("prd_nm")
            txtpgrpcd.Text = dsedit.Tables(0).Rows(0).Item("pgrp_cd")
            cmbpgrp.Text = dsedit.Tables(0).Rows(0).Item("pgrp_nm")
            sttm.Value = dsedit.Tables(0).Rows(0).Item("frm_time")
            endtm.Value = dsedit.Tables(0).Rows(0).Item("to_time")
            txtdur.Text = dsedit.Tables(0).Rows(0).Item("net_time")
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
        Me.Text = "Period Master Entry Screen . . ."
        dv.Visible = False
        txtprdnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Edit"
            Me.Text = "Period Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(6).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtprdnm.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            'If usr_tp = "A" Or usr_tp = "D" Then
            slno = dv.SelectedRows(0).Cells(6).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT prd_cd FROM period1 WHERE prd_cd=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    'Dim ds1 As DataSet = get_dataset("SELECT prd_cd FROM prod_mst WHERE prd_cd=" & Val(slno) & "")
                    'If ds1.Tables(0).Rows.Count <> 0 Then
                    '    fnd = 1
                    'End If
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM period1 WHERE prd_cd =" & Val(slno) & "")
                        MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.dv_disp()
                    Else
                        MessageBox.Show("Sorry You Can't Delete The Period It Has Been Already Used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Me.Text = "Period Master View Screen . . ."
            slno = dv.SelectedRows(0).Cells(6).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtprdnm.Focus()
        End If
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        authnm = InputBox("Enter The Period Name.", "Search Box...", Nothing)
        If (authnm Is Nothing OrElse authnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT period1.*, pgroup.pgrp_nm FROM period1 LEFT OUTER JOIN pgroup ON period1.pgrp_cd = pgroup.pgrp_cd  WHERE (period1.prd_nm LIKE'" & authnm & "%') ORDER BY period1.prd_nm")
            dv.Rows.Clear()
            If dsedit.Tables(0).Rows.Count <> 0 Then
                Dim rw As Integer = 0
                For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                    dv.Rows.Add()
                    dv.Rows(i).Cells(0).Value = i + 1
                    dv.Rows(i).Cells(1).Value = dsedit.Tables(0).Rows(rw).Item("prd_nm")
                    dv.Rows(i).Cells(2).Value = dsedit.Tables(0).Rows(rw).Item("pgrp_nm")
                    dv.Rows(i).Cells(3).Value = Format(dsedit.Tables(0).Rows(rw).Item("frm_time"), "HH:mm")
                    dv.Rows(i).Cells(4).Value = Format(dsedit.Tables(0).Rows(rw).Item("to_time"), "HH:mm")
                    dv.Rows(i).Cells(5).Value = Format(dsedit.Tables(0).Rows(rw).Item("net_time"), "####0") & " Minute"
                    dv.Rows(i).Cells(6).Value = dsedit.Tables(0).Rows(rw).Item("prd_cd")
                    If dsedit.Tables(0).Rows(rw).Item("rec_lock") = "Y" Then
                        dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    Else
                        dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    End If
                    rw = rw + 1
                Next
            End If
        End If
    End Sub
End Class
