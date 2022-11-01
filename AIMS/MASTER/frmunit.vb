Imports vb = Microsoft.VisualBasic
Public Class frmunit
    Dim comd As String

    Private Sub frmunit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuUnit.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmunit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmunit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuUnit.Enabled = False
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmunit_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
       
        Me.Text = "Unit Master . . ."
        txtscrl.Text = ""
        txtuntnm.Text = ""
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(unt_cd) as 'Max' FROM unt")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtuntnm.Focus()
    End Sub

#Region "Enter/Leave"

    Private Sub txtuntnm_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtuntnm.Enter, cmblock.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub txtuntnm_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtuntnm.Leave, cmblock.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
        result = StrConv(txtuntnm.Text, VbStrConv.ProperCase)
        txtuntnm.Text = result
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnref.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnref.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub


#End Region

#Region "KeyPress"

    Private Sub txtuntnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuntnm.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub

#End Region

#Region "cmnu"

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click
        Me.dv_disp()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
        Me.Text = "Unit Master Entry Screen . . ."
        dv.Visible = False
        txtuntnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Unit Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(2).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtuntnm.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        'fnd = 0
        'If dv.RowCount <> 0 Then
        '    slno = dv.SelectedRows(0).Cells(2).Value
        '    cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        '    Start1()
        '    If cnfr = vbYes Then
        '        Dim ds As DataSet = get_dataset("SELECT unt_cd FROM unt WHERE unt_cd=" & Val(slno) & "")
        '        If ds.Tables(0).Rows.Count <> 0 Then
        '            'Dim ds1 As DataSet = get_dataset("SELECT unt_cd FROM prod_mst WHERE unt_cd=" & Val(slno) & "")
        '            'If ds1.Tables(0).Rows.Count <> 0 Then
        '            '    fnd = 1
        '            'End If
        '            If fnd = 0 Then
        '                SQLInsert("DELETE FROM unt WHERE unt_cd =" & Val(slno) & "")
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

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
        comd = "E"
        Me.Text = "Unit Master Entry Screen. . ."
        btnsave.Text = "Save"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtuntnm.Text) = "" Then
            MessageBox.Show("Please Provide A Unit Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtuntnm.Focus()
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
                Dim ds As DataSet = get_dataset("SELECT max(unt_cd) as 'Max' FROM unt")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO unt (unt_cd, unt_nm,rec_lock) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(txtuntnm.Text) & "','" & vb.Left(cmblock.Text, 1) & "')")
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Me.Text = "Unit Master Entry Screen. . ."
                Close1()
            End If
        Else
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT unt_cd FROM unt WHERE unt_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE unt SET unt_nm='" & Trim(txtuntnm.Text) & "',rec_lock='" & vb.Left(cmblock.Text, 1) & "' WHERE unt_cd =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY unt_nm) AS 'Sl.', unt_nm AS 'Unit Name',unt_cd, rec_lock FROM unt ORDER BY unt_nm")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(2).Visible = False
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
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT * FROM unt WHERE unt_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtuntnm.Text = dsedit.Tables(0).Rows(0).Item("unt_nm")
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
