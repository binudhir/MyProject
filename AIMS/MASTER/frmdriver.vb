Imports vb = Microsoft.VisualBasic
Public Class frmdriver
    Dim comd As String

    Private Sub frmdriver_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnudriver.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmdriver_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmdriver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        comd = "E"
        MDI.mnudriver.Enabled = False
        Me.dv_disp()
        Me.clr()
    End Sub

    Private Sub frmdriver_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black
        End If
    End Sub

    Private Sub clr()
        Me.Text = "Driver Master. . . ."
        txtdrvcd.Text = 0
        txtdrvnm.Text = ""
        txtshrtnm.Text = ""
        txtaddress.Text = ""
        txtmobno.Text = ""
        cmbvehno.Text = ""
        txtvehcd.Text = 0
        doj.Value = sys_date
        dob.Value = sys_date.AddYears(-15)
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(drv_cd) as 'Max' FROM drvmst")
        txtdrvcd.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtdrvcd.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtdrvnm.Focus()
    End Sub

#Region "Enter/Leave"
    Private Sub txtdrvno_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtaddress.Enter, txtmobno.Enter, txtdrvnm.Enter, txtshrtnm.Enter, cmblock.Enter, cmbvehno.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub txtdrvno_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtaddress.Leave, txtmobno.Leave, txtdrvnm.Leave, txtshrtnm.Leave, cmblock.Leave, cmbvehno.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

#Region "Combo Box"
    Private Sub cmbvehno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbvehno.GotFocus
        populate(cmbvehno, "SELECT veh_no FROM veh WHERE rec_lock='N' ORDER BY veh_no")
    End Sub

    Private Sub cmbvehno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbvehno.LostFocus
        cmbvehno.Height = 21
    End Sub

    Private Sub cmbvehno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbvehno.Validated
        vdated(txtvehcd, "SELECT veh_cd FROM veh WHERE veh_no='" & Trim(cmbvehno.Text) & "'")
    End Sub

    Private Sub cmbvehno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbvehno.Validating
        vdating(cmbvehno, "SELECT veh_no FROM veh WHERE veh_no='" & Trim(cmbvehno.Text) & "' AND rec_lock='N'", "Please Select A Valid Vehicle No.")
    End Sub
#End Region

    Private Sub txtdrvnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdrvnm.LostFocus
        If Trim(txtshrtnm.Text) = "" Then
            txtshrtnm.Text = vb.Left(Trim(txtdrvnm.Text), 5)
        End If
    End Sub

    Private Sub dob_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dob.Validated
        txtage.Text = DateDiff(DateInterval.Year, dob.Value, sys_date)
    End Sub

    Private Sub dob_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dob.ValueChanged
        txtage.Text = DateDiff(DateInterval.Year, dob.Value, sys_date)
    End Sub

#Region "KeyPress"
    Private Sub txtdrvno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdrvnm.KeyPress
        key(txtshrtnm, e)
        SPKey(e)
    End Sub

    Private Sub txtshrtnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshrtnm.KeyPress
        key(dob, e)
        SPKey(e)
    End Sub

    Private Sub dob_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dob.KeyPress
        key(doj, e)
    End Sub

    Private Sub doj_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles doj.KeyPress
        key(txtaddress, e)
    End Sub

    Private Sub txtaddress_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaddress.KeyPress
        key(txtmobno, e)
        SPKey(e)
    End Sub

    Private Sub txtmobno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmobno.KeyPress
        key(cmbvehno, e)
        NUM(e)
    End Sub

    Private Sub cmbvehno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbvehno.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub

#End Region

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        Me.Text = "Driver Master Entry Screen . . ."
        comd = "E"
        btnsave.Text = "Save"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtdrvnm.Text) = "" Then
            MessageBox.Show("The Driver Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtdrvnm.Focus()
            Exit Sub
        End If
        If Trim(cmbvehno.Text) = "" Or Val(txtvehcd.Text) = 0 Then
            MessageBox.Show("The Vehicle No Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtaddress.Focus()
            Exit Sub
        End If
        If Trim(txtmobno.Text) = "" Then
            MessageBox.Show("Please Provide Driver's Contact No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtmobno.Focus()
            Exit Sub
        End If
        Me.driver_save()
    End Sub

#End Region

#Region "cmnu"

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
        Me.Text = "Driver Master Entry Screen . . ."
        dv.Visible = False
        txtdrvnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Driver Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(4).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtdrvnm.Focus()
        End If
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        'fnd = 0
        'If dv.RowCount <> 0 Then
        '    slno = dv.SelectedRows(0).Cells(2).Value
        '    cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        '    Start1()
        '    If cnfr = vbYes Then
        '        Dim ds As DataSet = get_dataset("SELECT drv_cd FROM drvmst WHERE drv_cd=" & Val(slno) & "")
        '        If ds.Tables(0).Rows.Count <> 0 Then
        '            'Dim ds1 As DataSet = get_dataset("SELECT grp_cd FROM prod_mst WHERE grp_cd=" & Val(slno) & "")
        '            'If ds1.Tables(0).Rows.Count <> 0 Then
        '            '    fnd = 1
        '            'End If
        '            If fnd = 0 Then
        '                SQLInsert("DELETE FROM drvmst WHERE drv_cd =" & Val(slno) & "")
        '                MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                Me.dv_disp()
        '            Else
        '                MessageBox.Show("Sorry You Can't Delete The Group It Has Been Already Used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                Exit Sub
        '            End If
        '        End If
        '        Close1()
        '    End If
        'End If
    End Sub

#End Region

    Private Sub driver_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(drv_cd) as 'Max' FROM drvmst")
                txtdrvcd.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtdrvcd.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO drvmst(drv_cd,drv_nm,drv_snm,doj,dob,veh_cd,add1,mob_no,rec_lock) VALUES (" & _
                          Val(txtdrvcd.Text) & ",'" & Trim(txtdrvnm.Text) & "','" & Trim(txtshrtnm.Text) & "','" & _
                          Format(doj.Value, "dd/MMM/yyyy") & "','" & Format(dob.Value, "dd/MMM/yyyy") & "'," & _
                          Val(txtvehcd.Text) & ",'" & Trim(txtaddress.Text) & "','" & Trim(txtmobno.Text) & "','" & _
                          vb.Left(cmblock.Text, 1) & "')")
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Me.Text = "Driver Master Entry Screen . . ."
                Close1()
            End If
        Else
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT drv_cd FROM drvmst WHERE drv_cd=" & Val(txtdrvcd.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE drvmst SET drv_nm = '" & Trim(txtdrvnm.Text) & "',drv_snm = '" & Trim(txtshrtnm.Text) & "',doj ='" & _
                          Format(doj.Value, "dd/MMM/yyyy") & "' ,dob ='" & Format(dob.Value, "dd/MMM/yyyy") & "' ,veh_cd = " & _
                          Val(txtvehcd.Text) & ",add1 = '" & Trim(txtaddress.Text) & "',mob_no = '" & Trim(txtmobno.Text) & "',rec_lock = '" & _
                          vb.Left(cmblock.Text, 1) & "' WHERE drv_cd =" & Val(txtdrvcd.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT  ROW_NUMBER() OVER(ORDER BY drvmst.drv_nm) AS 'Sl.', drvmst.drv_nm AS 'Driver Name', veh.veh_no AS 'Vehicle No.', drvmst.mob_no AS 'Mob No', drvmst.drv_cd, drvmst.rec_lock FROM drvmst LEFT OUTER JOIN veh ON drvmst.veh_cd = veh.veh_cd ORDER BY drvmst.drv_nm")
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
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT drvmst.*,veh.veh_no FROM drvmst LEFT OUTER JOIN veh ON drvmst.veh_cd = veh.veh_cd WHERE drvmst.drv_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtdrvcd.Text = slno
            txtdrvnm.Text = dsedit.Tables(0).Rows(0).Item("drv_nm")
            txtshrtnm.Text = dsedit.Tables(0).Rows(0).Item("drv_snm")
            txtaddress.Text = dsedit.Tables(0).Rows(0).Item("add1")
            txtmobno.Text = dsedit.Tables(0).Rows(0).Item("mob_no")
            dob.Value = dsedit.Tables(0).Rows(0).Item("dob")
            doj.Value = dsedit.Tables(0).Rows(0).Item("doj")
            cmbvehno.Text = dsedit.Tables(0).Rows(0).Item("veh_no")
            txtvehcd.Text = dsedit.Tables(0).Rows(0).Item("veh_cd")
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
                cmblock.SelectedIndex = 1
            Else
                cmblock.SelectedIndex = 0
            End If
        End If
        Close1()
    End Sub

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub
End Class
