Imports vb = Microsoft.VisualBasic
Public Class frmuniversity
    Dim comd As String

    Private Sub frmuniversity_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuunv.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmuniversity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmuniversity_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black
        End If
    End Sub

    Private Sub frmuniversity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuunv.Enabled = False
        usrprmsn("mnuunv", cmnuadd, cmnuedit, cmenudel, cmenuview)
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub clr()
        Me.Text = "University Master Entry Screen . . ."
        txtscrl.Text = ""
        txtunvnm.Text = ""
        txtprefix.Text = ""
        txtperson.Text = ""
        txtadd1.Text = ""
        txtcont1.Text = ""
        txtcont2.Text = ""
        txtstat.Text = ""
        cmbdist.Text = ""
        txtzip.Text = ""
        txtdistcd.Text = 0
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(uni_cd) as 'Max' FROM universe")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtunvnm.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, cmdview.Click
        Me.dv_disp()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtzip.Enter, txtunvnm.Enter, txtstat.Enter, txtprefix.Enter, txtperson.Enter, txtcont2.Enter, txtcont1.Enter, txtadd1.Enter, cmbdist.Enter, cmblock.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtzip.Leave, txtunvnm.Leave, txtstat.Leave, txtprefix.Leave, txtperson.Leave, txtcont2.Leave, txtcont1.Leave, txtadd1.Leave, cmbdist.Leave, cmblock.Leave
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

    Private Sub txtunvnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtunvnm.KeyPress
        key(txtprefix, e)
        SPKey(e)
    End Sub

    Private Sub txtprefix_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprefix.KeyPress
        key(txtperson, e)
        SPKey(e)
    End Sub

    Private Sub txtperson_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtperson.KeyPress
        key(txtadd1, e)
        SPKey(e)
    End Sub

    'Private Sub txtadd1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd1.KeyPress
    '    key(txtcont1, e)
    '    SPKey(e)
    'End Sub

    Private Sub txtcont1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont1.KeyPress
        key(txtcont2, e)
        NUM(e)
    End Sub

    Private Sub txtcont2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont2.KeyPress
        key(cmbdist, e)
        NUM(e)
    End Sub

    Private Sub cmbdist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdist.KeyPress
        key(txtzip, e)
        SPKey(e)
    End Sub

    Private Sub txtzip_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzip.KeyPress
        key(cmblock, e)
        NUM(e)
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
        If Trim(txtunvnm.Text) = "" Then
            MessageBox.Show("Please Provide A University Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtunvnm.Focus()
            Exit Sub
        End If
        If Trim(txtprefix.Text) = "" Then
            MessageBox.Show("Please Provide A Prefix.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtprefix.Focus()
            Exit Sub
        End If
        If Trim(cmbdist.Text) = "" Or Val(txtdistcd.Text) = 0 Then
            MessageBox.Show("Please Select A District.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbdist.Focus()
            Exit Sub
        End If
        Me.unv_save()
    End Sub

    Private Sub unv_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(uni_cd) as 'Max' FROM universe")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO universe (uni_cd,uni_nm,uni_pfx,cont_person,cont_no1,cont_no2,add1,add2,dist_cd," & _
                          "zip_code,rec_lock) VALUES (" & Val(txtscrl.Text) & ",'" & Trim(txtunvnm.Text) & "','" & _
                          Trim(txtprefix.Text) & "','" & Trim(txtperson.Text) & "','" & Trim(txtcont1.Text) & "','" & _
                          Trim(txtcont2.Text) & "','" & Trim(txtadd1.Text) & "','" & Trim(txtadd1.Text) & "'," & _
                          Val(txtdistcd.Text) & ",'" & Trim(txtzip.Text) & "','" & vb.Left(cmblock.Text, 1) & "')")
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
                Dim ds As DataSet = get_dataset("SELECT uni_cd FROM universe WHERE uni_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE universe SET uni_nm='" & Trim(txtunvnm.Text) & "',uni_pfx='" & _
                          Trim(txtprefix.Text) & "',cont_person='" & Trim(txtperson.Text) & "',cont_no1='" & _
                          Trim(txtcont1.Text) & "',cont_no2='" & Trim(txtcont2.Text) & "',add1='" & _
                          Trim(txtadd1.Text) & "',dist_cd=" & Val(txtdistcd.Text) & "," & "zip_code='" & _
                          Trim(txtzip.Text) & "' ,rec_lock='" & vb.Left(cmblock.Text, 1) & "' WHERE uni_cd =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT  ROW_NUMBER() OVER(ORDER BY uni_nm) AS 'Sl.', universe.uni_nm AS 'University', universe.cont_no1 AS 'Contact No', universe.add1 AS 'Address', dist.dist_nm AS 'District', universe.rec_lock, universe.uni_cd  FROM universe LEFT OUTER JOIN dist ON universe.dist_cd = dist.dist_cd ORDER BY universe.uni_nm")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(5).Visible = False
            dv.Columns(6).Visible = False

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
            '    dv.Rows(i).Cells(1).Value = dsedit.Tables(0).Rows(rw).Item("uni_nm")
            '    dv.Rows(i).Cells(2).Value = dsedit.Tables(0).Rows(rw).Item("add1")
            '    dv.Rows(i).Cells(3).Value = dsedit.Tables(0).Rows(rw).Item("cont_no1")
            '    dv.Rows(i).Cells(4).Value = dsedit.Tables(0).Rows(rw).Item("dist_nm")
            '    dv.Rows(i).Cells(5).Value = dsedit.Tables(0).Rows(rw).Item("uni_cd")
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
        Dim dsedit As DataSet = get_dataset("SELECT dist.dist_nm, universe.*, stat.stat_nm FROM stat RIGHT OUTER JOIN dist ON stat.stat_cd = dist.stat_cd RIGHT OUTER JOIN universe ON dist.dist_cd = universe.dist_cd WHERE universe.uni_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtunvnm.Text = dsedit.Tables(0).Rows(0).Item("uni_nm")
            txtprefix.Text = dsedit.Tables(0).Rows(0).Item("uni_pfx")
            txtperson.Text = dsedit.Tables(0).Rows(0).Item("cont_person")
            txtadd1.Text = dsedit.Tables(0).Rows(0).Item("add1")
            txtcont1.Text = dsedit.Tables(0).Rows(0).Item("cont_no1")
            txtcont2.Text = dsedit.Tables(0).Rows(0).Item("cont_no2")
            txtzip.Text = dsedit.Tables(0).Rows(0).Item("zip_code")
            cmbdist.Text = dsedit.Tables(0).Rows(0).Item("dist_nm")
            txtstat.Text = dsedit.Tables(0).Rows(0).Item("stat_nm")
            txtdistcd.Text = dsedit.Tables(0).Rows(0).Item("dist_cd")
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
        Me.Text = "University Master Entry Screen . . ."
        dv.Visible = False
        txtunvnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "University Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(6).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtunvnm.Focus()
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
                Dim ds As DataSet = get_dataset("SELECT uni_cd FROM universe WHERE uni_cd=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    'Dim ds1 As DataSet = get_dataset("SELECT uni_cd FROM prod_mst WHERE uni_cd=" & Val(slno) & "")
                    'If ds1.Tables(0).Rows.Count <> 0 Then
                    '    fnd = 1
                    'End If
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM universe WHERE uni_cd =" & Val(slno) & "")
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

    Private Sub cmbdist_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist.GotFocus
        populate(cmbdist, "SELECT dist_nm FROM dist ORDER BY dist_nm")
    End Sub

    Private Sub cmbdist_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist.LostFocus
        cmbdist.Height = 21
    End Sub

    Private Sub cmbdist_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist.Validated
        vdated(txtdistcd, "SELECT dist_cd FROM dist WHERE dist_nm='" & Trim(cmbdist.Text) & "'")
        vdated(txtstat, "SELECT stat.stat_nm FROM dist LEFT OUTER JOIN stat ON dist.stat_cd = stat.stat_cd WHERE dist.dist_nm='" & Trim(cmbdist.Text) & "'")
    End Sub

    Private Sub cmbdist_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdist.Validating
        vdating(cmbdist, "SELECT dist_nm FROM dist WHERE dist_nm='" & Trim(cmbdist.Text) & "'", "Please Select A Valid District Name")
    End Sub

    Private Sub mnuexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexport.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            btnsave.Enabled = False
            Me.Text = "University Master View Screen . . ."
            slno = dv.SelectedRows(0).Cells(6).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtunvnm.Focus()
        End If
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        authnm = InputBox("Enter The University Name.", "Search Box...", Nothing)
        If (authnm Is Nothing OrElse authnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT  ROW_NUMBER() OVER(ORDER BY uni_nm) AS 'Sl.', universe.uni_nm AS 'University', universe.cont_no1 AS 'Contact No', universe.add1 AS 'Address', dist.dist_nm AS 'District', universe.rec_lock, universe.uni_cd  FROM universe LEFT OUTER JOIN dist ON universe.dist_cd = dist.dist_cd WHERE (universe.uni_nm LIKE'" & authnm & "%') ORDER BY universe.uni_nm")
            dv.Columns.Clear()
            If dsedit.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dsedit.Tables(0)
                dv.Columns(5).Visible = False
                dv.Columns(6).Visible = False

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
