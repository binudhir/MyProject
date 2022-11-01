Imports vb = Microsoft.VisualBasic
Public Class frmstat
    Dim comd As String

    Private Sub frmstat_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuState.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmstat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmstat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuState.Enabled = False
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmstat_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "State Master . . ."
        txtscrl.Text = ""
        txtstatnm.Text = ""
        cmbcntr.Text = ""
        txtcntrcd.Text = 0
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(stat_cd) as 'Max' FROM stat")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtstatnm.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, cmdview.Click
        Me.dv_disp()
        Me.Text = "State Master . . ."
    End Sub

#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtstatnm.Enter, cmblock.Enter, cmbcntr.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
        'sender.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Bold)
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtstatnm.Leave, cmblock.Leave, cmbcntr.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
        'sender.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Regular)
        sender.text = UCase(sender.text)
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtstatnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstatnm.KeyPress
        key(cmbcntr, e)
        SPKey(e)
    End Sub

    Private Sub cmbcntr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcntr.KeyPress
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
        comd = "E"
        Me.Text = "State Master Entry Screen . . ."
        btnsave.Text = "Save"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtstatnm.Text) = "" Then
            MessageBox.Show("Please Provide A State Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtstatnm.Focus()
            Exit Sub
        End If
        If Trim(cmbcntr.Text) = "" Or Val(txtcntrcd.Text) = 0 Then
            MessageBox.Show("The Country Name Should not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtstatnm.Focus()
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
                Dim ds As DataSet = get_dataset("SELECT max(stat_cd) as 'Max' FROM stat")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO stat (stat_cd,stat_nm,cntr_sl,rec_lock) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(txtstatnm.Text) & "'," & Val(txtcntrcd.Text) & ",'" & _
                          vb.Left(cmblock.Text, 1) & "')")
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Me.Text = "State Master Entry Screen . . ."
                Close1()
            End If
        Else
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT stat_cd FROM stat WHERE stat_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE stat SET stat_nm='" & Trim(txtstatnm.Text) & "',cntr_sl=" & Val(txtcntrcd.Text) & ",rec_lock='" & _
                              vb.Left(cmblock.Text, 1) & "' WHERE stat_cd =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stat_nm) AS 'Sl.',stat.stat_nm AS 'State Name', cntr.cntr_nm AS 'Country Name',stat.stat_cd, stat.cntr_sl, stat.rec_lock FROM stat INNER JOIN cntr ON stat.cntr_sl = cntr.cntr_sl")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(3).Visible = False
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
        dv.Focus()
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT stat.*, cntr.cntr_nm FROM stat LEFT OUTER JOIN cntr ON stat.cntr_sl = cntr.cntr_sl WHERE stat.stat_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtstatnm.Text = dsedit.Tables(0).Rows(0).Item("stat_nm")
            txtcntrcd.Text = dsedit.Tables(0).Rows(0).Item("stat_cd")
            cmbcntr.Text = dsedit.Tables(0).Rows(0).Item("cntr_nm")
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
        Me.Text = "State Master Entry Screen . . ."
        dv.Visible = False
        txtstatnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "State Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(3).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtstatnm.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            slno = dv.SelectedRows(0).Cells(3).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT stat_cd FROM stat WHERE stat_cd=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    Dim ds1 As DataSet = get_dataset("SELECT stat_cd FROM dist WHERE stat_cd=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM stat WHERE stat_cd =" & Val(slno) & "")
                        MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.dv_disp()
                    Else
                        MessageBox.Show("Sorry You Can't Delete The State It Has Been Already Used in District.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                Close1()
            End If
        End If
    End Sub

    Private Sub cmbcntr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcntr.GotFocus
        cmbcntr.Height = 100
        populate(cmbcntr, "SELECT cntr_nm FROM cntr WHERE rec_lock='N' ORDER BY cntr_nm")
    End Sub

    Private Sub cmbcntr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcntr.LostFocus
        cmbcntr.Height = 21
    End Sub

    Private Sub cmbcntr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcntr.Validated
        vdated(txtcntrcd, "SELECT cntr_sl FROM cntr WHERE cntr_nm='" & Trim(cmbcntr.Text) & "'")
    End Sub

    Private Sub cmbcntr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcntr.Validating
        vdating(cmbcntr, "SELECT cntr_nm FROM cntr WHERE cntr_nm='" & Trim(cmbcntr.Text) & "'", "Please Select A Valid Country Name.")
    End Sub

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub
End Class
