Imports vb = Microsoft.VisualBasic
Public Class rep_stkstatement
    Dim comd As String

    Private Sub rep_stkstatement_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_stkstatement_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_stkstatement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        startdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        enddt.Value = startdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        Me.Text = "Stock Statement . . ."
        hddr = Me.Text
        txtcompcd.Text = 0
        dv.DataSource = Nothing
        lblmsg.Visible = False
        If chkcomp.Checked = False Then
            cmbcompany.Text = ""
        End If
    End Sub

#Region "Enter/Leave"
    Private Sub cmbcompany_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcompany.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmbcompany_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcompany.Leave

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

#Region "combobox"
    Private Sub cmbcompany_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcompany.GotFocus
        txtcompcd.Text = 0
        populate(cmbcompany, "SELECT manf_nm FROM manf WHERE (rec_lock = 'N') ORDER BY manf_nm")
    End Sub

    Private Sub cmbcompany_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcompany.LostFocus
        cmbcompany.Height = 21
    End Sub

    Private Sub cmbcompany_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcompany.Validating
        vdating(cmbcompany, "SELECT manf_nm FROM manf WHERE (manf_nm = '" & Trim(cmbcompany.Text) & "')", "Please Select a Valid Product Name.")
    End Sub

    Private Sub cmbcompany_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcompany.Validated
        vdated(txtcompcd, "SELECT manf_cd FROM manf WHERE (manf_nm = '" & Trim(cmbcompany.Text) & "')")
    End Sub
#End Region

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

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        lblmsg.Visible = False
        dv.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        conditn = ""
        stkval = ""
        If chkzero.Checked = False Then
            conditn = " WHERE (item.op_stk + item.rec_stk + item.iss_stk + item.cl_stk <> 0) "
        End If
        If chkcomp.Checked = False Then
            If conditn = "" Then
                conditn = "WHERE (item.manf_cd=" & Val(txtcompcd.Text) & ")"
            Else
                conditn = conditn & "AND (item.manf_cd=" & Val(txtcompcd.Text) & ")"
            End If
        End If
        If rdbpurch.Checked = True Then
            stkval = "STR(item.pur_rate,10,2) AS 'Pur.Rate',STR(item.cl_stk * item.pur_rate,10,2) AS 'Stock Value'"
            GroupBox3.Text = "Stock Statement Register On Purchase Rate From " & Format(startdt.Value, "dd/MM/yyyy") & " To " & Format(enddt.Value, "dd/MM/yyyy")
        ElseIf (rdbsale.Checked = True) Then
            stkval = "STR(item.sale_rate1,10,2) AS 'Sale Rate',STR(item.cl_stk * item.sale_rate1,10,2) AS 'Stock Value'"
            GroupBox3.Text = "Stock Statement Register On Sale Rate From " & Format(startdt.Value, "dd/MM/yyyy") & " To " & Format(enddt.Value, "dd/MM/yyyy")
        ElseIf (rdbmrp.Checked = True) Then
            stkval = "STR(item.mrp,10,2) AS 'M.R.P',STR(item.cl_stk * item.mrp,10,2) AS 'Stock Value'"
            GroupBox3.Text = "Stock Statement Register On M.R.P From " & Format(startdt.Value, "dd/MM/yyyy") & " To " & Format(enddt.Value, "dd/MM/yyyy")
        Else
            stkval = "STR(item.stk_rate,10,2) AS 'Stock Rate',STR(item.cl_stk * item.stk_rate,10,2) AS 'Stock Value'"
            GroupBox3.Text = "Stock Statement Register On Stock Rate From " & Format(startdt.Value, "dd/MM/yyyy") & " To " & Format(enddt.Value, "dd/MM/yyyy")
        End If
        ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY item.it_name) AS 'Sl.', item.it_name AS 'Product Name', STR(item.op_stk, 10, 0) AS 'Opening Stock', STR(item.rec_stk, 10, 0) AS 'In Qty.', STR(item.iss_stk, 10, 0) AS 'Out Qty', STR(item.cl_stk, 10, 0) AS 'Closeing Stock', item.unt1 AS 'Unit'," & stkval & " FROM item " & conditn & " ORDER BY item.it_name")
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            hddr = GroupBox3.Text
        Else
            lblmsg.Visible = True
        End If
        Close1()
    End Sub

#Region "keypress"

    Private Sub startdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startdt.KeyPress
        key(enddt, e)
    End Sub

    Private Sub enddt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles enddt.KeyPress
        key(cmbcompany, e)
    End Sub

    Private Sub cmbcompany_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcompany.KeyPress
        key(btnview, e)
        SPKey(e)
    End Sub
#End Region

    Private Sub chkcomp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcomp.CheckedChanged
        If chkcomp.Checked = True Then
            cmbcompany.Text = "<<< All Company >>>"
            cmbcompany.Enabled = False
            txtcompcd.Text = 0
        Else
            cmbcompany.Text = ""
            cmbcompany.Enabled = True
            cmbcompany.Focus()
        End If
    End Sub
End Class
