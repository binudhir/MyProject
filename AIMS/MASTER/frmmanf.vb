Imports vb = Microsoft.VisualBasic
Public Class frmmanf
    Dim comd As String

    Private Sub frmmanf_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnumanf.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmmanf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmmanf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnumanf.Enabled = False
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmmanf_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Manufacturer Master . . . ."
        txtmanfnm.Text = ""
        txtsortnm.Text = ""
        txtdetailnm.Text = ""
        txtadd.Text = ""
        cmbparty.Text = ""
        txtpartycd.Text = ""
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(manf_cd) as 'Max' FROM manf")
        txtscrl.Text = "1"
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtmanfnm.Focus()
    End Sub

#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmanfnm.Enter, txtdetailnm.Enter, txtadd.Enter, cmbparty.Enter, cmblock.Enter, txtsortnm.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmanfnm.Leave, txtdetailnm.Leave, txtadd.Leave, cmbparty.Leave, cmblock.Leave, txtsortnm.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
        sender.text = UCase(sender.text)
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseEnter, btnref.MouseEnter, btnexit.MouseEnter, btnview.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseLeave, btnref.MouseLeave, btnexit.MouseLeave, btnview.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtmanfnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmanfnm.KeyPress
        key(txtdetailnm, e)
        SPKey(e)
    End Sub

    Private Sub txtdetail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdetailnm.KeyPress
        key(txtadd, e)
        SPKey(e)
    End Sub

    Private Sub txtaddres_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd.KeyPress
        key(cmbparty, e)
        SPKey(e)
    End Sub

    Private Sub cmbprime_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(txtsortnm, e)
        SPKey(e)
    End Sub

    Private Sub txtsortnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsortnm.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub


    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub

#End Region

#Region "Combo"

    Private Sub cmbparty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.GotFocus
        cmbparty.Height = 100
        populate(cmbparty, "SELECT pname FROM party WHERE(prt_type = 'A') AND (rec_lock = 'N') ORDER BY pname")
    End Sub

    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.LostFocus
        cmbparty.Height = 21
    End Sub

    Private Sub cmbparty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.Validated
        vdated(txtpartycd, "SELECT prt_code FROM party WHERE pname='" & Trim(cmbparty.Text) & "'")
    End Sub

    Private Sub cmbparty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbparty.Validating
        vdating(cmbparty, "SELECT pname FROM party WHERE(prt_type = 'A') AND (rec_lock = 'N') AND (pname='" & Trim(cmbparty.Text) & "')", "Please Select A Valid Party Name.")
    End Sub

#End Region

    Private Sub txtdetailnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdetailnm.LostFocus
        If txtdetailnm.Text = "" Then
            txtdetailnm.Text = Trim(txtmanfnm.Text)
        End If
    End Sub

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
        Me.Text = "Manufacturer Master Entry Screen . . ."
        comd = "E"
        btnsave.Text = "Save"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtmanfnm.Text) = "" Then
            MessageBox.Show("Please Provide A Manufacturer Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtmanfnm.Focus()
            Exit Sub
        End If

        If Trim(txtdetailnm.Text) = "" Then
            MessageBox.Show("Please Provide The Detail Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtdetailnm.Focus()
            Exit Sub
        End If

        If Trim(cmbparty.Text) = "" Or Val(txtpartycd.Text) = 0 Then
            MessageBox.Show("Please Select A Valid Prime Supplier Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbparty.Focus()
            Exit Sub
        End If
        Me.manf_save()
    End Sub
#End Region


    Private Sub manf_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(manf_cd) as 'Max' FROM manf")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO manf( manf_cd, manf_nm, manf_lnm, add1,prt_cd, rec_lock,manf_snm) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(txtmanfnm.Text) & "','" & Trim(txtdetailnm.Text) & "','" & Trim(txtadd.Text) & "'," & Val(txtpartycd.Text) & _
                          ",'" & vb.Left(cmblock.Text, 1) & "','" & Trim(txtsortnm.Text) & "')")

                MessageBox.Show("Record added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Me.Text = "Manufacturer Master Entry Screen . . ."
                Close1()
            End If
        Else
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT manf_cd FROM manf WHERE manf_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE manf SET manf_nm='" & Trim(txtmanfnm.Text) & "',manf_lnm='" & Trim(txtdetailnm.Text) & "',add1='" & _
                              Trim(txtadd.Text) & "',prt_cd='" & Val(txtpartycd.Text) & "',rec_lock='" & vb.Left(cmblock.Text, 1) & _
                              "',manf_snm='" & Trim(txtsortnm.Text) & "' WHERE manf_cd =" & Val(txtscrl.Text) & "")
                    MessageBox.Show("Record Modified Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                    Me.dv_disp()
                End If
                Close1()
            End If
        End If
    End Sub

    Private Sub dv_disp()
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY manf_nm) AS 'Sl.', manf.manf_nm AS 'Manufacturer Name', manf.add1 AS 'Address', party.pname AS 'Prime Supplier Name',manf.manf_cd, manf.prt_cd, manf.rec_lock FROM manf INNER JOIN party ON manf.prt_cd = party.prt_code")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
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
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT manf.*, party.pname FROM manf LEFT OUTER JOIN party ON manf.prt_cd = party.prt_code WHERE manf.manf_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtmanfnm.Text = dsedit.Tables(0).Rows(0).Item("manf_nm")
            txtsortnm.Text = dsedit.Tables(0).Rows(0).Item("manf_snm")
            txtdetailnm.Text = dsedit.Tables(0).Rows(0).Item("manf_lnm")
            txtadd.Text = dsedit.Tables(0).Rows(0).Item("add1")
            cmbparty.Text = dsedit.Tables(0).Rows(0).Item("pname")
            txtpartycd.Text = dsedit.Tables(0).Rows(0).Item("prt_cd")
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
                cmblock.SelectedIndex = 1
            Else
                cmblock.SelectedIndex = 0
            End If
        End If
        Close1()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
        Me.Text = "Manufacturer Master Entry Screen . . ."
        dv.Visible = False
        txtmanfnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Manufacturer Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(4).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtmanfnm.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        'fnd = 0
        'If dv.RowCount <> 0 Then
        '    slno = dv.SelectedRows(0).Cells(2).Value
        '    cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        '    Start1()
        '    If cnfr = vbYes Then
        '        Dim ds As DataSet = get_dataset("SELECT veh_cd FROM veh WHERE veh_cd=" & Val(slno) & "")
        '        If ds.Tables(0).Rows.Count <> 0 Then
        '            'Dim ds1 As DataSet = get_dataset("SELECT grp_cd FROM prod_mst WHERE grp_cd=" & Val(slno) & "")
        '            'If ds1.Tables(0).Rows.Count <> 0 Then
        '            '    fnd = 1
        '            'End If
        '            If fnd = 0 Then
        '                SQLInsert("DELETE FROM veh WHERE veh_cd =" & Val(slno) & "")
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
