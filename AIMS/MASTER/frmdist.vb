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
        Me.Text = "District Master . . ."
        txtscrl.Text = ""
        txtshort.Text = ""
        txtdistnm.Text = ""
        cmbstat.Text = ""
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

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.dv_disp()
    End Sub

#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdistnm.Enter, cmblock.Enter, cmbstat.Enter, txtshort.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
        'sender.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Bold)
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdistnm.Leave, cmblock.Leave, cmbstat.Leave, txtshort.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
        'sender.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Regular)
        sender.text = UCase(sender.text)
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub
    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtdistnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdistnm.KeyPress
        key(cmbstat, e)
        SPKey(e)
    End Sub

    Private Sub cmbstat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstat.KeyPress
        key(txtshort, e)
        SPKey(e)
    End Sub

    Private Sub txtshort_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshort.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub

#End Region

#Region "Combo"

    Private Sub cmbcntr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstat.GotFocus
        cmbstat.Height = 100
        populate(cmbstat, "SELECT stat_nm FROM stat WHERE rec_lock='N' ORDER BY stat_nm")
    End Sub

    Private Sub cmbcntr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstat.LostFocus
        cmbstat.Height = 21
    End Sub

    Private Sub cmbcntr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstat.Validated
        vdated(txtstatcd, "SELECT stat_cd FROM stat WHERE stat_nm='" & Trim(cmbstat.Text) & "'")
    End Sub

    Private Sub cmbcntr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstat.Validating
        vdating(cmbstat, "SELECT stat_nm FROM stat WHERE stat_nm='" & Trim(cmbstat.Text) & "'", "Please Select A Valid State Name.")
    End Sub

#End Region

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        comd = "E"
        Me.Text = "District Master Entry Screen . . ."
        btnsave.Text = "Save"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtdistnm.Text) = "" Then
            MessageBox.Show("Please Provide A District Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtdistnm.Focus()
            Exit Sub
        End If
        If Trim(cmbstat.Text) = "" Or Val(txtstatcd.Text) = 0 Then
            MessageBox.Show("The Country Name Should not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtdistnm.Focus()
            Exit Sub
        End If
        Me.trad_save()

    End Sub

#End Region
   

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
                Me.Text = "District Master Entry Screen . . ."
                Close1()
            End If
        Else
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
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY dist_nm) AS 'Sl.',dist.dist_nm AS 'District Name', dist.dist_snm AS 'Short Name', stat.stat_nm AS 'State Name', dist.dist_cd,dist.stat_cd, dist.rec_lock FROM dist INNER JOIN stat ON dist.stat_cd = stat.stat_cd")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(4).Visible = False
            dv.Columns(5).Visible = False
            dv.Columns(6).Visible = False

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
        Close1()
        Me.clr()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT dist.*, stat.stat_nm FROM dist LEFT OUTER JOIN stat ON dist.stat_cd = stat.stat_cd WHERE dist.dist_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtdistnm.Text = dsedit.Tables(0).Rows(0).Item("dist_nm")
            txtstatcd.Text = dsedit.Tables(0).Rows(0).Item("stat_cd")
            cmbstat.Text = dsedit.Tables(0).Rows(0).Item("stat_nm")
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
        btnsave.Text = "Save"
        Me.Text = "District Master Entry Screen . . ."
        dv.Visible = False
        txtdistnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "District Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(4).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtdistnm.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        'fnd = 0
        'If dv.RowCount <> 0 Then
        '    slno = dv.SelectedRows(0).Cells(4).Value
        '    cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        '    Start1()
        '    If cnfr = vbYes Then
        '        Dim ds As DataSet = get_dataset("SELECT dist_cd FROM dist WHERE dist_cd=" & Val(slno) & "")
        '        If ds.Tables(0).Rows.Count <> 0 Then
        '            'Dim ds1 As DataSet = get_dataset("SELECT dist_cd FROM prod_mst WHERE dist_cd=" & Val(slno) & "")
        '            'If ds1.Tables(0).Rows.Count <> 0 Then
        '            '    fnd = 1
        '            'End If
        '            If fnd = 0 Then
        '                SQLInsert("DELETE FROM dist WHERE dist_cd =" & Val(slno) & "")
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

   

 
    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub
End Class
