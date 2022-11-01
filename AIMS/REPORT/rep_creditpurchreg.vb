Imports vb = Microsoft.VisualBasic
Public Class rep_creditpurchreg
    Dim comd As String

    Private Sub rep_creditpurchreg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_creditpurchreg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_creditpurchreg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        startdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        enddt.Value = startdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        Me.Text = "Credit Purchase Register . . ."
        hddr = Me.Text
        txtordcd.Text = 0
        txtpartycd.Text = 0
        txtprodcd.Text = 0
        txtregcd.Text = 0
        cmbreg.SelectedIndex = 0
        cmbprod.Text = ""
        cmbparty.Text = ""
        cmbreg.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False
        chkdetail.Checked = True
    End Sub

#Region "Enter/Leave"
    Private Sub cmbregist_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprod.Enter, cmbparty.Enter, cmbreg.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmbregist_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprod.Leave, cmbparty.Leave, cmbreg.Leave

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
        Dim ds As DataSet = get_dataset("SELECT prt_code,add1 FROM party WHERE pname='" & Trim(cmbparty.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtpartycd.Text = ds.Tables(0).Rows(0).Item("prt_code")
        End If
    End Sub

    Private Sub cmbparty_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbparty.Validating
        vdating(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' AND pname='" & Trim(cmbparty.Text) & "'", "Please Select A Valid Party Head Of A/c Name.")
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
        If chkparty.Checked = False Then
            conditn = " AND (party.prt_code=" & Val(txtpartycd.Text) & ")"
        End If
        If chkprod.Checked = False Then
            conditn = conditn & "AND (item.it_cd=" & Val(txtprodcd.Text) & ")"
        End If
        orderby = "purch1.pur_dt"
        If cmbreg.SelectedIndex = 1 Then
            orderby = " party.pname"
        End If
        If cmbreg.SelectedIndex = 2 Then
            orderby = "item.it_name"
        End If

        If (chkdetail.Checked = True) Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.',  STR(purch1.pur_no,10,0) AS 'Purchase No.', CONVERT(varchar,purch1.pur_dt,103) AS 'Purchase Date', purch1.inv_no AS 'Invoice No.', CONVERT(varchar,purch1.inv_dt,103) AS 'Invoice Date', purch1.pur_type AS 'Purchase Type', party.pname AS 'Party Name', item.it_name AS 'Product', STR(purch2.pur_qty,10,2) AS 'Quantity', STR(purch2.free_qty,10,2) AS 'Free', item.unt1 AS 'Unit', STR(purch2.mrp,10,2) AS 'M.R.P.', STR(purch2.pur_rt,10,2) AS 'Purchase Rate', STR(purch2.it_amt,10,2) AS 'Product Amount', STR(purch2.disc_amt1,10,2) AS 'Co. Dis. Amt.', STR(purch2.disc_amt2,10,2) AS 'Tr. Dis. Amt.',  STR(purch2.stax,10,2) AS 'TAX', STR(purch2.pur_amt,10,2) AS 'Total', STR(purch1.chr_amt,10,2) AS 'Charge Amount', STR(purch1.dis_amt,10,2) AS 'Discount Amount', STR(purch1.adj_amt,10,2) AS 'Adjust Amount', STR(purch1.to_amt,10,2) AS 'TOTAL AMOUNT' FROM  purch1 LEFT OUTER JOIN  purch2 LEFT OUTER JOIN party ON purch2.prt_code = party.prt_code LEFT OUTER JOIN  item ON purch2.it_cd = item.it_cd ON purch1.pur_no = purch2.pur_no  WHERE (purch1.pur_dt>='" & Format(startdt.Value, "dd/MMM/yyyy") & "') AND (purch1.pur_dt<='" & Format(enddt.Value, "dd/MMM/yyyy") & "')  " & conditn & " ORDER BY " & orderby & "")
        Else
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.',  STR(purch1.pur_no,10,0) AS 'Pur No.', CONVERT(varchar,purch1.pur_dt,103) AS 'Purchase Date',  purch1.pur_type AS 'Purchase Type', party.pname AS 'Party Name', item.it_name AS 'Product', STR(purch2.pur_qty,10,2) AS 'Quantity', STR(purch2.free_qty,10,2) AS 'Free', item.unt1 AS 'Unit',  STR(purch2.pur_rt,10,2) AS 'Purchase Rate', STR(purch2.it_amt,10,2) AS 'Product Amount', STR(purch2.stax,10,2) AS 'TAX', STR(purch2.pur_amt,10,2) AS 'Total', STR(purch1.chr_amt,10,2) AS 'Charge Amount', STR(purch1.dis_amt,10,2) AS 'Discount Amount', STR(purch1.adj_amt,10,2) AS 'Adjust Amount', STR(purch1.to_amt,10,2) AS 'TOTAL AMOUNT' FROM  purch1 LEFT OUTER JOIN  purch2 LEFT OUTER JOIN party ON purch2.prt_code = party.prt_code LEFT OUTER JOIN  item ON purch2.it_cd = item.it_cd ON purch1.pur_no = purch2.pur_no  WHERE (purch1.pur_dt>='" & Format(startdt.Value, "dd/MMM/yyyy") & "') AND (purch1.pur_dt<='" & Format(enddt.Value, "dd/MMM/yyyy") & "')  " & conditn & " ORDER BY " & orderby & "")
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            slno = 0
            For i As Integer = 0 To dv.Rows.Count - 1
                If ds.Tables(0).Rows(i).Item("Purchase type") = "1" Then
                    ds.Tables(0).Rows(i).Item("Purchase type") = "Purchase"
                End If
                If ds.Tables(0).Rows(i).Item("Purchase type") = "1" Then
                    ds.Tables(0).Rows(i).Item("Purchase type") = "Return"
                End If
                If slno = Val(dv.Rows(i).Cells(1).Value) Then
                    dv.Rows(i).Cells(1).Value = ""
                    dv.Rows(i).Cells(2).Value = ""
                    dv.Rows(i).Cells(3).Value = ""
                    dv.Rows(i).Cells(4).Value = ""
                    dv.Rows(i).Cells(6).Value = ""
                Else
                    slno = Val(dv.Rows(i).Cells(1).Value)
                End If

            Next
            GroupBox3.Text = "Purchase Register From " & startdt.Value & " To " & enddt.Value
            hddr = GroupBox3.Text
        Else
            lblmsg.Visible = True
        End If
        Close1()
    End Sub

#Region "checkBox"

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

    Private Sub chkdetail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdetail.CheckedChanged
        If (chkdetail.Checked = True) Then
            chkabstract.Checked = False
        Else
            chkabstract.Checked = True
        End If
    End Sub

    Private Sub chkabstract_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkabstract.CheckedChanged
        If (chkabstract.Checked = True) Then
            chkdetail.Checked = False
        Else
            chkdetail.Checked = True
        End If
    End Sub
#End Region

#Region "keypress"

    Private Sub startdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startdt.KeyPress
        key(enddt, e)
    End Sub

    Private Sub enddt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles enddt.KeyPress
        key(chkdetail, e)
    End Sub

    Private Sub chkdetail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkdetail.KeyPress
        key(chkabstract, e)
    End Sub

    Private Sub chkabstract_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkabstract.KeyPress
        key(cmbreg, e)
    End Sub

    Private Sub cmbreg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbreg.KeyPress
        key(cmbparty, e)
        SPKey(e)
    End Sub

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(chkparty, e)
        SPKey(e)
    End Sub

    Private Sub chkparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkparty.KeyPress
        key(cmbprod, e)
    End Sub

    Private Sub cmbprod_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbprod.KeyPress
        key(chkprod, e)
        SPKey(e)
    End Sub

    Private Sub chkprod_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkprod.KeyPress
        key(btnview, e)
    End Sub

#End Region
End Class
