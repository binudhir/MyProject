Imports vb = Microsoft.VisualBasic
Public Class frmitgrp
    Dim comd As String

    Private Sub frmitgrp_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuProductgrp.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmitgrp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmitgrp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        comd = "E"
        MDI.mnuProductgrp.Enabled = False
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmitgrp_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Product Group Master . . ."
        txtscrl.Text = ""
        txtgrpshort.Text = ""
        txtgrplong.Text = ""
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(gp_cd) as 'Max' FROM itgrp")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtgrpshort.Focus()

    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub txtgrplong_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgrplong.LostFocus
        If txtgrplong.Text = "" Then
            txtgrplong.Text = Trim(txtgrpshort.Text)
        End If
    End Sub

#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgrpshort.Enter, txtgrplong.Enter, cmblock.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgrpshort.Leave, txtgrplong.Leave, cmblock.Leave
        sender.text = UCase(sender.text)
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region
  
#Region "KeyPress"

    Private Sub txtgrpshort_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgrpshort.KeyPress
        key(txtgrplong, e)
        SPKey(e)
    End Sub

    Private Sub txtgrplong_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgrplong.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub

#End Region

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        comd = "E"
        Me.Text = "Product Group Master Entry Screen . . ."
        btnsave.Text = "Save"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtgrpshort.Text) = "" Then
            MessageBox.Show("Please Provide A Group Short Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtgrpshort.Focus()
            Exit Sub
        End If
        If Trim(txtgrplong.Text) = "" Then
            MessageBox.Show("Please Provide A Group Long Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtgrplong.Focus()
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
                Dim ds As DataSet = get_dataset("SELECT max(gp_cd) as 'Max' FROM itgrp")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO itgrp (gp_cd, gp_nm, gp_lnm, manf_cd, tax_sal, tax_pur, tax_cat, rec_lock) VALUES (" & _
                          Val(txtscrl.Text) & ",'" & Trim(txtgrpshort.Text) & "','" & Trim(txtgrplong.Text) & "',0,0,0,0,'" & _
                          vb.Left(cmblock.Text, 1) & "')")
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Me.Text = "Product Group Master Entry Screen . . ."
                Close1()
            End If
        Else
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT gp_cd FROM itgrp WHERE gp_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE itgrp SET gp_nm='" & Trim(txtgrpshort.Text) & "',gp_lnm='" & Trim(txtgrplong.Text) & "',rec_lock='" & _
                              vb.Left(cmblock.Text, 1) & "' WHERE gp_cd =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY gp_nm) AS 'Sl.', gp_nm AS [Group Name],gp_lnm  AS [Group Long Name], gp_cd,rec_lock FROM itgrp ORDER BY gp_nm")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(3).Visible = False
            dv.Columns(4).Visible = False

            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(4).Value

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
        Dim dsedit As DataSet = get_dataset("SELECT * FROM itgrp WHERE gp_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtgrpshort.Text = dsedit.Tables(0).Rows(0).Item("gp_nm")
            txtgrplong.Text = dsedit.Tables(0).Rows(0).Item("gp_lnm")
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
        Me.Text = "Product Group Master Entry Screen . . ."
        dv.Visible = False
        txtgrpshort.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Product Group Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(3).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtgrpshort.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        'fnd = 0
        'If dv.RowCount <> 0 Then
        '    slno = dv.SelectedRows(0).Cells(2).Value
        '    cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        '    Start1()
        '    If cnfr = vbYes Then
        '        Dim ds As DataSet = get_dataset("SELECT gp_cd FROM it_grp WHERE gp_cd=" & Val(slno) & "")
        '        If ds.Tables(0).Rows.Count <> 0 Then
        '            'Dim ds1 As DataSet = get_dataset("SELECT grp_cd FROM prod_mst WHERE grp_cd=" & Val(slno) & "")
        '            'If ds1.Tables(0).Rows.Count <> 0 Then
        '            '    fnd = 1
        '            'End If
        '            If fnd = 0 Then
        '                SQLInsert("DELETE FROM sgroup WHERE gp_cd =" & Val(slno) & "")
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

    
    Private Sub txtgrpshort_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgrpshort.LostFocus
        txtgrplong.Text = txtgrpshort.Text
    End Sub

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub
End Class
