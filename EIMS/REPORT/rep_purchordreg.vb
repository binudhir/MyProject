Imports vb = Microsoft.VisualBasic
Public Class rep_purchordreg
    Dim comd As String

    Private Sub rep_purchordreg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_purchordreg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_purchordreg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        fromdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        todt.Value = fromdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        Me.Text = "Purchage Order Register . . ."
        hddr = Me.Text
        txtordcd.Text = 0
        txtpartycd.Text = 0
        txtprodcd.Text = 0
        cmborder.SelectedIndex = 0
        cmbprod.Text = ""
        cmbparty.Text = ""
        cmborder.Focus()
        cmbstat.SelectedIndex = 0
        dv.DataSource = Nothing
        lblmsg.Visible = False
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprod.Enter, cmbparty.Enter, cmborder.Enter, cmbstat.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmborder.Leave, cmbprod.Leave, cmbparty.Leave, cmbstat.Leave

        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub
#Region "Enter/Leave"
    Private Sub cmbprod_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmbprod_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmborder.Leave

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

    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.LostFocus
        cmbparty.Height = 21
    End Sub

    Private Sub cmbparty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.GotFocus
        txtpartycd.Text = 0
        populate(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbparty_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbparty.Validated
        Dim ds As DataSet = get_dataset("SELECT prt_code,add1,cl_bal FROM party WHERE pname='" & Trim(cmbparty.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtpartycd.Text = ds.Tables(0).Rows(0).Item("prt_code")
        End If
    End Sub

    Private Sub cmbparty_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbparty.Validating
        vdating(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND pname='" & Trim(cmbparty.Text) & "'", "Please Select A Valid Party Head Of A/c Name.")
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
#Region "KeyPress"

    Private Sub fromdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fromdt.KeyPress
        key(todt, e)
    End Sub

    Private Sub todt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles todt.KeyPress
        key(cmbparty, e)
    End Sub

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(cmbprod, e)
        SPKey(e)
    End Sub

    Private Sub cmbprod_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbprod.KeyPress
        key(cmbstat, e)
        SPKey(e)
    End Sub

    Private Sub cmbstat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstat.KeyPress
        key(cmborder, e)
        SPKey(e)
    End Sub

    Private Sub cmborder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmborder.KeyPress
        key(btnview, e)
        SPKey(e)
    End Sub
#End Region

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        lblmsg.Visible = False
        dv.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        conditn = ""
        If chkparty.Checked = False Then
            conditn = " AND (party.prt_code=" & Val(txtpartycd.Text) & ")"
        End If
        If chkprod.Checked = False Then
            conditn = conditn & "AND (item.it_cd=" & Val(txtprodcd.Text) & ")"
        End If
        If cmbstat.SelectedIndex = 1 Then
            conditn = conditn & " AND (porder2.billed='Y')"
        ElseIf cmbstat.SelectedIndex = 2 Then
            conditn = conditn & " AND (porder2.billed='N')"
        End If
        orderby = "porder1.po_dt"
        If cmborder.SelectedIndex = 1 Then
            orderby = " party.pname"
        End If
        If cmborder.SelectedIndex = 2 Then
            orderby = "item.it_name"
        End If
        ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', STR(porder1.po_no,10,0) AS 'PO No.', CONVERT(varchar,porder1.po_dt,103) AS 'Date', party.pname AS 'Party', porder1.ref_no AS 'Ref No.', CONVERT(varchar,porder1.deliver_dt,103) AS 'Date(delivery)', item.it_name AS 'Product', porder2.po_unit AS 'Unit', STR(porder2.po_mrp,10,2) AS 'M.R.P.', STR(porder2.po_rate,10,2) AS 'Rate', STR(porder2.po_qty,10,2) AS 'Quantity', STR(porder2.bpo_qty,10,2) AS 'Billed Qty', STR(porder2.po_amt,10,2) AS 'Total' FROM party RIGHT OUTER JOIN item RIGHT OUTER JOIN porder1 LEFT OUTER JOIN porder2 ON porder1.po_no = porder2.po_no ON item.it_cd = porder2.it_cd ON party.prt_code = porder1.prt_code  WHERE (porder1.po_dt>='" & Format(fromdt.Value, "dd/MMM/yyyy") & "') AND (porder1.po_dt<='" & Format(todt.Value, "dd/MMM/yyyy") & "')  " & conditn & " ORDER BY " & orderby & "")
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            slno = 0
            For i As Integer = 0 To dv.Rows.Count - 1
                If slno = Val(dv.Rows(i).Cells(1).Value) Then
                    dv.Rows(i).Cells(1).Value = ""
                    dv.Rows(i).Cells(2).Value = ""
                    dv.Rows(i).Cells(3).Value = ""
                    dv.Rows(i).Cells(4).Value = ""
                    dv.Rows(i).Cells(5).Value = ""
                Else
                    slno = Val(dv.Rows(i).Cells(1).Value)
                End If

            Next

            GroupBox3.Text = "Purchase Order Register From " & fromdt.Value & " To " & todt.Value
            hddr = GroupBox3.Text
        Else
            lblmsg.Visible = True
        End If
        Close1()
    End Sub

    Private Sub chkparty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkparty.CheckedChanged
        If chkparty.Checked = True Then
            cmbparty.Text = "<<< All Party >>>"
            cmbparty.Enabled = False
            txtpartycd.Text = 0
        Else
            cmbparty.Text = ""
            cmbparty.Enabled = True
            cmbparty.Focus()
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

 
End Class
