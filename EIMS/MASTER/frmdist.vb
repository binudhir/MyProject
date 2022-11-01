Imports vb = Microsoft.VisualBasic
Public Class frmdist
    Dim comd As String

    Private Sub frmdist_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuDistrict.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmdist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmdist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuDistrict.Enabled = False
        usrprmsn("mnuDistrict", cmnuadd, cmnuedit, cmenudel, cmenuview)
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmdist_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "District Master Entry Screen . . ."
        txtscrl.Text = ""
        txtshort.Text = ""
        txtdistnm.Text = ""
        cmbcntr.Text = ""
        txtstatcd.Text = 0
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(dist_cd) as 'Max' FROM dist")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtdistnm.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, cmdview.Click
        Me.dv_disp()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdistnm.Enter, cmblock.Enter, cmbcntr.Enter, txtshort.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdistnm.Leave, cmblock.Leave, cmbcntr.Leave, txtshort.Leave
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

    Private Sub txttradnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdistnm.KeyPress
        key(cmbcntr, e)
        SPKey(e)
    End Sub

    Private Sub cmbcntr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcntr.KeyPress
        key(txtshort, e)
        SPKey(e)
    End Sub

    Private Sub txtdeptnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdistnm.LostFocus
        'cmbcntr.Text = Trim(txtdistnm.Text)
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
        If Trim(txtdistnm.Text) = "" Then
            MessageBox.Show("Please Provide A District Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtdistnm.Focus()
            Exit Sub
        End If
        If Trim(cmbcntr.Text) = "" Or Val(txtstatcd.Text) = 0 Then
            MessageBox.Show("The Country Name Should not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtdistnm.Focus()
            Exit Sub
        End If
        Me.trad_save()
    End Sub

    Private Sub trad_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(dist_cd) as 'Max' FROM dist")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO dist(dist_cd,dist_nm,dist_snm,stat_cd,rec_lock) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(txtdistnm.Text) & "','" & Trim(txtshort.Text) & "'," & Val(txtstatcd.Text) & ",'" & _
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
                Dim ds As DataSet = get_dataset("SELECT dist_cd FROM dist WHERE dist_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE dist SET dist_nm='" & Trim(txtdistnm.Text) & "',dist_snm='" & Trim(txtshort.Text) & "',stat_cd=" & Val(txtstatcd.Text) & ",rec_lock='" & _
                              vb.Left(cmblock.Text, 1) & "' WHERE dist_cd =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY dist_nm) AS 'Sl.',dist.dist_cd, dist.dist_nm AS 'District Name', dist.dist_snm AS 'Short Name', dist.stat_cd, dist.rec_lock, stat.stat_nm AS 'State Name' FROM dist LEFT OUTER JOIN stat ON dist.stat_cd = stat.stat_cd ORDER BY dist.dist_nm")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(1).Visible = False
            dv.Columns(5).Visible = False
            dv.Columns(4).Visible = False
            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(5).Value
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
                '    dv.Rows(i).Cells(1).Value = dsedit.Tables(0).Rows(rw).Item("dist_nm")
                '    dv.Rows(i).Cells(2).Value = dsedit.Tables(0).Rows(rw).Item("dist_snm")
                '    dv.Rows(i).Cells(3).Value = dsedit.Tables(0).Rows(rw).Item("stat_nm")
                '    dv.Rows(i).Cells(4).Value = dsedit.Tables(0).Rows(rw).Item("dist_cd")
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
        Dim dsedit As DataSet = get_dataset("SELECT dist.*, stat.stat_nm FROM dist LEFT OUTER JOIN stat ON dist.stat_cd = stat.stat_cd WHERE dist.dist_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtdistnm.Text = dsedit.Tables(0).Rows(0).Item("dist_nm")
            txtstatcd.Text = dsedit.Tables(0).Rows(0).Item("dist_cd")
            cmbcntr.Text = dsedit.Tables(0).Rows(0).Item("stat_nm")
            txtshort.Text = dsedit.Tables(0).Rows(0).Item("dist_snm")
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
        Me.Text = "District Master Entry Screen . . ."
        dv.Visible = False
        txtdistnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "District Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(1).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtdistnm.Focus()
        End If
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            btnsave.Enabled = False
            Me.Text = "District Master View Screen . . ."
            slno = dv.SelectedRows(0).Cells(1).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtdistnm.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            'If dv.RowCount <> 0 Then
            slno = dv.SelectedRows(0).Cells(1).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT dist_cd FROM dist WHERE dist_cd=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    'Dim ds1 As DataSet = get_dataset("SELECT dist_cd FROM prod_mst WHERE dist_cd=" & Val(slno) & "")
                    'If ds1.Tables(0).Rows.Count <> 0 Then
                    '    fnd = 1
                    'End If
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM dist WHERE dist_cd =" & Val(slno) & "")
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

    Private Sub cmbcntr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcntr.GotFocus
        cmbcntr.Height = 100
        populate(cmbcntr, "SELECT stat_nm FROM stat WHERE rec_lock='N' ORDER BY stat_nm")
    End Sub

    Private Sub cmbcntr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcntr.LostFocus
        cmbcntr.Height = 21
    End Sub

    Private Sub cmbcntr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcntr.Validated
        vdated(txtstatcd, "SELECT stat_cd FROM stat WHERE stat_nm='" & Trim(cmbcntr.Text) & "'")
    End Sub

    Private Sub cmbcntr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcntr.Validating
        vdating(cmbcntr, "SELECT stat_nm FROM stat WHERE stat_nm='" & Trim(cmbcntr.Text) & "'", "Please Select A Valid State Name.")
    End Sub

    Private Sub txtshort_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshort.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub mnuexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexport.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        distnm = InputBox("Enter The District Name.", "Search Box...", Nothing)
        If (distnm Is Nothing OrElse distnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY dist_nm) AS 'Sl.',dist.dist_cd, dist.dist_nm AS 'District Name', dist.dist_snm AS 'Short Name', dist.stat_cd, dist.rec_lock, stat.stat_nm AS 'State Name' FROM dist LEFT OUTER JOIN stat ON dist.stat_cd = stat.stat_cd WHERE (dist.dist_nm LIKE'" & distnm & "%') ORDER BY dist.dist_nm")
            dv.Columns.Clear()
            If dsedit.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dsedit.Tables(0)
                dv.Columns(1).Visible = False
                dv.Columns(5).Visible = False
                dv.Columns(4).Visible = False
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
