Imports vb = Microsoft.VisualBasic
Public Class rep_stflist
    Dim comd As String

    Private Sub rep_stflist_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_stflist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_stflist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
    End Sub

    Private Sub clr()
        Me.Text = "Staff List. . ."
        hddr = Me.Text
        txtdeptcd.Text = 0
        txtdesgcd.Text = 0
        txtsubcd.Text = 0
        'chkdept.Checked = False
        cmbgndr.SelectedIndex = 0
        cmbpost.SelectedIndex = 0
        cmbmar.SelectedIndex = 0
        cmborder.SelectedIndex = 0
        cmbdept.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False
        If chkdept.Checked = False Then
            cmbdept.Text = ""
        End If
        'If chksub.Checked = False Then
        '    cmbsub.Text = ""
        'End If
        If chkdesg.Checked = False Then
            cmbdesg.Text = ""
        End If
    End Sub

#Region "Enter/Leave"

    Private Sub cmborder_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdesg.Enter, cmbdept.Enter, cmborder.Enter, cmbpost.Enter, cmbgndr.Enter, cmbmar.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmborder_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdesg.Leave, cmbdept.Leave, cmborder.Leave, cmbpost.Leave, cmbgndr.Leave, cmbmar.Leave

        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btncalc_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnrfresh.MouseEnter, btnexport.MouseEnter, btnexit.MouseEnter, btncalc.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btncalc_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnrfresh.MouseLeave, btnexport.MouseLeave, btnexit.MouseLeave, btncalc.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

#Region "ComboBoX"

    Private Sub cmbdept_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdept.Validated
        vdated(txtdeptcd, "SELECT dept_cd FROM dept WHERE dept_nm='" & Trim(cmbdept.Text) & "'")
    End Sub

    Private Sub cmbdept_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdept.Validating
        vdating(cmbdept, "SELECT dept_nm FROM dept WHERE dept_nm='" & Trim(cmbdept.Text) & "' AND rec_lock='N'", "Please Select A Valid Session Name.")
    End Sub

    Private Sub cmbdept_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdept.GotFocus
        populate(cmbdept, "SELECT dept_nm FROM dept WHERE rec_lock='N' ORDER BY dept_nm DESC")
    End Sub

    Private Sub cmbdept_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdept.LostFocus
        cmbdept.Height = 21
    End Sub

    'Private Sub cmbsub_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    populate(cmbsub, "SELECT sub_nm FROM subject_mst WHERE rec_lock='N' ORDER BY sub_nm")
    'End Sub

    'Private Sub cmbsub_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    cmbsub.Height = 21
    'End Sub

    'Private Sub cmbsub_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '    vdated(txtsubcd, "SELECT sub_cd FROM subject_mst WHERE sub_nm='" & Trim(cmbsub.Text) & "'")
    'End Sub

    'Private Sub cmbsub_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    vdating(cmbsub, "SELECT sub_nm FROM subject_mst WHERE sub_nm='" & Trim(cmbsub.Text) & "' AND rec_lock='N'", "Please Select A Valid Sem/Ac.Year Name.")
    'End Sub

    Private Sub cmbdesg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesg.GotFocus
        populate(cmbdesg, "SELECT desg_nm FROM desg WHERE rec_lock='N' ORDER BY desg_nm")
    End Sub

    Private Sub cmbdesg_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesg.LostFocus
        cmbdesg.Height = 21
    End Sub

    Private Sub cmbdesg_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesg.Validated
        vdated(txtdesgcd, "SELECT desg_cd FROM desg WHERE desg_nm='" & Trim(cmbdesg.Text) & "'")
    End Sub

    Private Sub cmbdesg_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdesg.Validating
        vdating(cmbdesg, "SELECT desg_nm FROM desg WHERE desg_nm='" & Trim(cmbdesg.Text) & "' AND rec_lock='N'", "Please Select A Valid Stream/desge Name.")
    End Sub

#End Region

#Region "CheckBox"

    Private Sub chkdept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdept.CheckedChanged
        If chkdept.Checked = True Then
            cmbdept.Text = "<<< All >>>"
            cmbdept.Enabled = False
            txtdeptcd.Text = 0
        Else
            cmbdept.Text = ""
            cmbdept.Enabled = True
            cmbdept.Focus()
        End If
    End Sub
    Private Sub chkdesg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdesg.CheckedChanged
        If chkdesg.Checked = True Then
            cmbdesg.Text = "<<< All >>>"
            cmbdesg.Enabled = False
            txtdesgcd.Text = 0
        Else
            cmbdesg.Text = ""
            cmbdesg.Enabled = True
            cmbdesg.Focus()
        End If
    End Sub

#End Region

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btncalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncalc.Click
        System.Diagnostics.Process.Start("calc.exe")
    End Sub

    Private Sub btnrfresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrfresh.Click
        Me.clr()
    End Sub

    Private Sub btnexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexport.Click
        Call excel_view(dv)
    End Sub

#End Region

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        lblmsg.Visible = False
        dv.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        conditn = ""
        If chkdesg.Checked = False Then
            conditn = "AND (staf.desg_cd=" & Val(txtdesgcd.Text) & ")"
        End If
        'If chksub.Checked = False Then
        '    conditn = conditn & " AND (staf.sub_cd=" & Val(txtsubcd.Text) & ")"
        'End If
        If cmbgndr.SelectedIndex <> 0 Then
            conditn = conditn & " AND (staf.gndr='" & vb.Left(cmbgndr.Text, 1) & "')"
        End If
        If cmbpost.SelectedIndex <> 0 Then
            conditn = conditn & " AND (staf.emp_tp='" & vb.Left(cmbpost.Text, 1) & "')"
        End If
        If cmbmar.SelectedIndex <> 0 Then
            conditn = conditn & " AND (staf.married='" & vb.Left(cmbmar.Text, 1) & "')"
        End If
        orderby = " staf.staf_nm"
        If cmborder.SelectedIndex = 1 Then
            orderby = " staf.staf_id"
        End If
        If cmborder.SelectedIndex = 2 Then
            orderby = " staf.doj"
        End If
        If cmborder.SelectedIndex = 3 Then
            orderby = " staf.dob"
        End If
        If chkabst.Checked = False Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & " ) AS 'Sl.',staf.staf_id AS 'Emp.ID', staf.staf_nm AS 'Emp. Name',desg.desg_nm AS 'Designation', dept.dept_nm AS 'Department', CONVERT(varchar,staf.doj,103) AS 'DoJ', (CASE WHEN staf.emp_tp='1' THEN 'Permanent'  WHEN staf.emp_tp='2' THEN 'Temporary'  WHEN staf.emp_tp='3' THEN 'Contractual' END) AS 'Employee Type', staf.per_add1 AS 'Address', dist.dist_nm AS 'Dist.', staf.cont_no AS 'Ph.No.', CONVERT(varchar,staf.dob,103) AS 'Date Of Birth', (CASE WHEN staf.gndr='M' THEN 'Male' WHEN staf.gndr='F' THEN 'Female' END) AS 'Gender',staf.mail_id AS 'Mail Id' FROM staf LEFT OUTER JOIN dist ON staf.dist_cd1 = dist.dist_cd LEFT OUTER JOIN dept ON staf.dept_cd = dept.dept_cd LEFT OUTER JOIN desg ON staf.desg_cd = desg.desg_cd WHERE (staf.rec_lock = 'N') " & conditn & " ORDER BY " & orderby & "")
        Else
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & " ) AS 'Sl.', staf.staf_id AS 'Emp.ID', staf.staf_nm AS 'Emp. Name',desg.desg_nm AS 'Designation', dept.dept_nm AS 'Department', CONVERT(varchar,staf.doj,103) AS 'DoJ', (CASE WHEN staf.emp_tp='1' THEN 'Permanent'  WHEN staf.emp_tp='2' THEN 'Temporary'  WHEN staf.emp_tp='3' THEN 'Contractual' END) AS 'Employee Type', staf.cont_no AS 'Contact No',  staf.mail_id AS 'Mail Id' FROM staf LEFT OUTER JOIN dist ON staf.dist_cd1 = dist.dist_cd LEFT OUTER JOIN dept ON staf.dept_cd = dept.dept_cd LEFT OUTER JOIN desg ON staf.desg_cd = desg.desg_cd WHERE (staf.rec_lock = 'N') " & conditn & " ORDER BY " & orderby & "")
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            'For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            '    If ds.Tables(0).Rows(i).Item("emp_tp") = "1" Then
            '        ds.Tables(0).Rows(i).Item("emp_tp") = "Parmanent"
            '    End If
            '    If ds.Tables(0).Rows(i).Item("emp_tp") = "2" Then
            '        ds.Tables(0).Rows(i).Item("emp_tp") = "Temporary"
            '    End If
            '    If ds.Tables(0).Rows(i).Item("emp_tp") = "3" Then
            '        ds.Tables(0).Rows(i).Item("emp_tp") = "Contractual"
            '    End If
            'Next
            GroupBox3.Text = "Staff List. . ."
            hddr = GroupBox3.Text
        Else
            lblmsg.Visible = True
        End If
        Close1()
    End Sub

#Region "KeyPress"

    Private Sub cmbdept_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdept.KeyPress
        key(chkdept, e)
        SPKey(e)
    End Sub

    Private Sub chkdept_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkdept.KeyPress
        key(cmbdesg, e)
    End Sub

    Private Sub cmbdesg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdesg.KeyPress
        key(chkdesg, e)
        SPKey(e)
    End Sub

    Private Sub chkdesg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkdesg.KeyPress
        key(cmbgndr, e)
    End Sub

    Private Sub cmbgndr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgndr.KeyPress
        key(cmbpost, e)
        SPKey(e)
    End Sub

    Private Sub cmbpost_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpost.KeyPress
        key(cmbmar, e)
        SPKey(e)
    End Sub

    Private Sub cmbmar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbmar.KeyPress
        key(cmborder, e)
        SPKey(e)
    End Sub

    Private Sub cmborder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmborder.KeyPress
        key(chkabst, e)
        SPKey(e)
    End Sub

    Private Sub chkabst_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkabst.KeyPress
        key(btnview, e)
    End Sub

#End Region
End Class
