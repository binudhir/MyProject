Imports vb = Microsoft.VisualBasic
Public Class rep_stockreg
    Dim comd As String

    Private Sub rep_stockreg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_stockreg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_stockreg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        startdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        enddt.Value = startdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        Me.Text = "Stock Register . . . ."
        hddr = Me.Text
        txtcompcd.Text = 0
        txtgodncd.Text = 0
        txtprodcd.Text = 0
        txtunitcd.Text = 0
        cmbunit.SelectedIndex = 0
        cmbprod.Text = ""
        cmbunit.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False
        'rdbdetail.Checked = True
    End Sub

#Region "Enter/Leave"
    Private Sub cmbregist_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprod.Enter, cmbunit.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmbregist_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprod.Leave, cmbunit.Leave

        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnview_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnrfresh.MouseEnter, btnexport.MouseEnter, btnexit.MouseEnter, btncalc.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnview_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnrfresh.MouseLeave, btnexport.MouseLeave, btnexit.MouseLeave, btncalc.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "checkBox"


    Private Sub chkprod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkprod.CheckedChanged
        If chkprod.Checked = True Then
            cmbprod.Text = "<<< All Products >>>"
            cmbprod.Enabled = False
            txtprodcd.Text = 0
        Else
            cmbprod.Text = ""
            cmbprod.Enabled = True
            cmbprod.Focus()
        End If
    End Sub

   
#End Region

#Region "keypress"
    Private Sub startdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startdt.KeyPress
        key(enddt, e)
    End Sub

    Private Sub enddt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles enddt.KeyPress
        key(cmbprod, e)
    End Sub

    Private Sub cmbprod_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbprod.KeyPress
        key(cmbunit, e)
        SPKey(e)
    End Sub

    'Private Sub cmbgodwn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgodwn.KeyPress
    '    key(chkgodn, e)
    '    SPKey(e)
    'End Sub

    'Private Sub chkgodn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkgodn.KeyPress
    '    key(cmbunit, e)
    'End Sub

    Private Sub cmbunit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunit.KeyPress
        key(btnview, e)
        SPKey(e)
    End Sub
#End Region

#Region "combobox"
    Private Sub cmbprod_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprod.GotFocus
        txtprodcd.Text = 0
        populate(cmbprod, "SELECT it_name FROM item WHERE (rec_lock = 'N') ORDER BY it_name")
    End Sub

    Private Sub cmbprod_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprod.LostFocus
        cmbprod.Height = 21
    End Sub

    Private Sub cmbprod_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbprod.Validating
        vdating(cmbprod, "SELECT it_name FROM item WHERE (it_name = '" & Trim(cmbprod.Text) & "')", "Please Select a Valid Product Name.")
    End Sub

    Private Sub cmbprod_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprod.Validated
        vdated(txtprodcd, "SELECT it_cd FROM item WHERE (it_name = '" & Trim(cmbprod.Text) & "')")
    End Sub

    'Private Sub cmbgodwn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodwn.GotFocus
    '    populate(cmbgodwn, "SELECT godnm FROM godown WHERE rec_lock='N' ORDER BY godnm")
    'End Sub

    'Private Sub cmbgodwn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodwn.LostFocus
    '    cmbgodwn.Height = 21
    'End Sub

    'Private Sub cmbgodwn_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodwn.Validated
    '    vdated(txtgodncd, "SELECT godsl FROM godown WHERE godnm='" & Trim(cmbgodwn.Text) & "'")
    'End Sub

    'Private Sub cmbgodwn_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgodwn.Validating
    '    vdating(cmbgodwn, "SELECT godnm FROM godown WHERE godnm='" & Trim(cmbgodwn.Text) & "' AND rec_lock='N'", "Please Select A Valid Godown Name.")
    'End Sub

   
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
        If chkzero.Checked = False Then
            conditn = " WHERE (item.op_stk + item.rec_stk + item.iss_stk + item.cl_stk <> 0) AND (untlnk.unt_pos='" & vb.Right(cmbunit.Text, 1) & "')"
        Else
            conditn = " WHERE (untlnk.unt_pos='" & vb.Right(cmbunit.Text, 1) & "')"
        End If
        If chkprod.Checked = False Then
            conditn = conditn & " AND (item.it_cd=" & Val(txtprodcd.Text) & ")"
        End If
        If (rdbdetail.Checked = True) Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name ) AS 'Sl.', item.it_name AS 'Product Name', STR(item.op_stk/untlnk.mul_rt, 10, 2) AS 'Open Stk', STR(item.rec_stk/untlnk.mul_rt, 10, 2) AS 'Recive Stk', STR(item.iss_stk/untlnk.mul_rt, 10, 2) AS 'Issue Stk', STR(item.cl_stk/untlnk.mul_rt, 10, 2) AS 'Close Stk', untlnk.unt_nm AS 'Unit' FROM item LEFT OUTER JOIN untlnk ON item.it_cd = untlnk.it_cd " & conditn & " ORDER BY item.it_name")
        Else
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name ) AS 'Sl.', item.it_name AS 'Product Name', STR(item.op_stk/untlnk.mul_rt, 10, 2) AS 'Open Stk', STR(item.rec_stk/untlnk.mul_rt, 10, 2) AS 'Recive Stk', STR(item.iss_stk/untlnk.mul_rt, 10, 2) AS 'Issue Stk', STR(item.cl_stk/untlnk.mul_rt, 10, 2) AS 'Close Stk', untlnk.unt_nm AS 'Unit' FROM item LEFT OUTER JOIN untlnk ON item.it_cd = untlnk.it_cd " & conditn & " ORDER BY item.it_name")
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            GroupBox3.Text = "Stock Register " & Format(startdt.Value, "dd/MM/yyyy") & " To " & Format(enddt.Value, "dd/MM/yyyy")
            hddr = GroupBox3.Text
        Else
            lblmsg.Visible = True
        End If
        Close1()
    End Sub
End Class