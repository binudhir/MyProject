Imports vb = Microsoft.VisualBasic
Public Class rep_stocksrlreg
    Dim comd As String

    Private Sub rep_stocksrlreg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_stocksrlreg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_stocksrlreg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
    End Sub

    Private Sub clr()
        Me.Text = "Serial Stock Register . . . ."
        hddr = Me.Text
        txtcompcd.Text = 0
        txtgodncd.Text = 0
        txtprodcd.Text = 0
        txtunitcd.Text = 0
        dv.DataSource = Nothing
        lblmsg.Visible = False
        'rdbdetail.Checked = True
        If chkprod.Checked = False Then
            cmbprod.Text = ""
        End If
        If chkcomp.Checked = False Then
            cmbcompany.Text = ""
        End If
        If chkgodn.Checked = False Then
            cmbgodwn.Text = ""
        End If
    End Sub

#Region "Enter/Leave"
    Private Sub cmbregist_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprod.Enter, cmbcompany.Enter, cmbgodwn.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmbregist_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprod.Leave, cmbcompany.Leave, cmbgodwn.Leave

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

    Private Sub chkparty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcomp.CheckedChanged
        If chkcomp.Checked = True Then
            cmbcompany.Text = "<<< All Company >>>"
            cmbcompany.Enabled = False
            txtgodncd.Text = 0
        Else
            cmbcompany.Text = ""
            cmbcompany.Enabled = True
            cmbcompany.Focus()
        End If
    End Sub

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

    'Private Sub chkgodn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkgodn.CheckedChanged
    '    If chkgodn.Checked = True Then
    '        cmbgodwn.Text = "<<< All Godown >>>"
    '        cmbgodwn.Enabled = False
    '        txtgodncd.Text = 0
    '    Else
    '        cmbgodwn.Text = ""
    '        cmbgodwn.Enabled = True
    '        cmbgodwn.Focus()
    '    End If
    'End Sub


#End Region

#Region "keypress"
    Private Sub startdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        key(enddt, e)
    End Sub

    Private Sub enddt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If cmbcompany.Enabled = True Then
            key(cmbcompany, e)
        ElseIf cmbprod.Enabled = True Then
            key(cmbprod, e)
        Else
            key(btnview, e)
        End If
    End Sub

    Private Sub cmbcompany_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcompany.KeyPress
        If cmbprod.Enabled = True Then
            key(cmbprod, e)
        Else
            key(btnview, e)
        End If
        SPKey(e)
    End Sub

    Private Sub cmbprod_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbprod.KeyPress
        key(btnview, e)
        SPKey(e)
    End Sub

    'Private Sub cmbgodwn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgodwn.KeyPress
    '    key(chkgodn, e)
    '    SPKey(e)
    'End Sub

    'Private Sub chkgodn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkgodn.KeyPress
    '    key(cmbunit, e)
    'End Sub
#End Region

#Region "combobox"
    Private Sub cmbprod_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprod.GotFocus
        txtprodcd.Text = 0
        cmbprod.Text = ""
        populate(cmbprod, "SELECT it_name FROM item WHERE (rec_lock = 'N') AND (bat_cnf ='S') ORDER BY it_name")
        If txtcompcd.Text <> 0 Then
            populate(cmbprod, "SELECT it_name FROM item WHERE (rec_lock = 'N') AND (bat_cnf ='S') AND manf_cd = " & Val(txtcompcd.Text) & "ORDER BY it_name")
        End If
    End Sub

    Private Sub cmbprod_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprod.LostFocus
        cmbprod.Height = 21
    End Sub

    Private Sub cmbprod_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbprod.Validating
        vdating(cmbprod, "SELECT it_name FROM item WHERE (it_name = '" & Trim(cmbprod.Text) & "') AND (bat_cnf ='S')", "Please Select a Valid Product Name.")
    End Sub

    Private Sub cmbprod_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprod.Validated
        vdated(txtprodcd, "SELECT it_cd FROM item WHERE (it_name = '" & Trim(cmbprod.Text) & "')")
    End Sub

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
        dv.DataSource = Nothing






        lblmsg.Visible = False
        'dv.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        conditn = ""

        If chkzero.Checked = False Then
            conditn = " WHERE (item.op_stk + item.rec_stk + item.iss_stk + item.cl_stk <> 0)" ')"
        Else
            conditn = " WHERE (item.op_stk + item.rec_stk + item.iss_stk + item.cl_stk = 0)"
        End If
        If chkcomp.Checked = False Then
            conditn = conditn & " AND (item.manf_cd=" & Val(txtcompcd.Text) & ")"
        End If
        If chkprod.Checked = False Then
            conditn = conditn & " AND (item.it_cd=" & Val(txtprodcd.Text) & ")"
        End If
        'If chkgodn.Checked = False Then
        '    conditn = conditn & " AND (godown.godsl=" & Val(txtgodncd.Text) & ")"
        'End If
        If (rdbdetail.Checked = True) Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name ) AS 'Sl.',item.it_name AS 'Product Name', item.hsn_code AS 'HSN Code', manf.manf_nm AS 'Company Name', itgrp.gp_nm AS 'Group', taxper.taxnm AS 'GST', mast_slno.slno AS 'Serial No', (CASE WHEN mast_slno.io_pos='I' THEN 'In' WHEN mast_slno.io_pos='O' THEN 'Out' END) AS 'Position', STR(item.op_stk, 5) AS 'Opening Stk', STR(item.rec_stk, 5) AS 'Recive Stk', STR(item.iss_stk, 5) AS 'Issue Stk', STR(item.cl_stk, 5) AS 'Close Stk' FROM item RIGHT OUTER JOIN mast_slno ON item.it_cd = mast_slno.it_cd LEFT OUTER JOIN taxper ON item.stx_cd = taxper.taxcd LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN manf ON item.manf_cd = manf.manf_cd " & conditn & " ORDER BY item.it_name,mast_slno.slno")
        Else
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name ) AS 'Sl',item.it_name AS 'Product Name', manf.manf_nm AS 'Company Name', mast_slno.slno AS 'Serial No', (CASE WHEN mast_slno.io_pos = 'I' THEN 'In' WHEN mast_slno.io_pos = 'O' THEN 'Out' END) AS 'Position', STR(item.op_stk, 5) AS 'Opening Stk', STR(item.rec_stk, 5) AS 'Recive Stk', STR(item.iss_stk, 5) AS 'Issue Stk', STR(item.cl_stk, 5) AS 'Close Stk' FROM item RIGHT OUTER JOIN mast_slno ON item.it_cd = mast_slno.it_cd LEFT OUTER JOIN manf ON item.manf_cd = manf.manf_cd " & conditn & " ORDER BY item.it_name,mast_slno.slno")
        End If
        dv.Columns.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
        Else
            lblmsg.Visible = True
        End If
        GroupBox3.Text = "Serial Stock Register ..."
        hddr = GroupBox3.Text

        Close1()
        Call pbclose()
    End Sub



End Class