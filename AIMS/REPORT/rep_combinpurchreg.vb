Imports vb = Microsoft.VisualBasic
Public Class rep_combinpurchreg
    Dim comd As String

    Private Sub rep_combinpurchreg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_combinpurchreg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_combinpurchreg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        fromdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        todt.Value = fromdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        Me.Text = "Combine Purchase Register . . ."
        hddr = Me.Text
        txtordcd.Text = ""
        txtpartycd.Text = ""
        txtprodcd.Text = ""
        txtregcd.Text = ""
        txtcompcd.Text = ""
        cmbtype.SelectedIndex = 0
        cmborder.SelectedIndex = 0
        cmbprod.Text = ""
        cmbparty.Text = ""
        cmbcompany.Text = ""
        fromdt.Value = sys_date
        todt.Value = sys_date
        cmborder.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False
        chkdetail.Checked = True
    End Sub

#Region "Enter/Leave"
    Private Sub cmbregist_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprod.Enter, cmbparty.Enter, cmbcompany.Enter, cmborder.Enter, cmbtype.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmbregist_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprod.Leave, cmbparty.Leave, cmbcompany.Leave, cmborder.Leave, cmbtype.Leave

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
        If chkparty.Checked = False Then
            conditn = " AND (party.prt_code=" & Val(txtpartycd.Text) & ")"
        End If
        If chkprod.Checked = False Then
            conditn = conditn & "AND (item.it_cd=" & Val(txtprodcd.Text) & ")"
        End If
        If chkcomp.Checked = False Then
            conditn = " AND (manf.manf_cd=" & Val(txtcompcd.Text) & ")"
        End If
        If cmbtype.SelectedIndex <> 0 Then
            conditn = " AND (purch1.pur_type='" & vb.Left(cmbtype.Text, 1) & "')"
        End If
        orderby = "purch1.pur_dt"
        If cmborder.SelectedIndex = 1 Then
            orderby = " party.pname"
        End If
        If cmborder.SelectedIndex = 2 Then
            orderby = "item.it_name"
        End If

        If (chkdetail.Checked = True) Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name) AS 'Sl.', purch1.pur_no AS 'Purch No', CONVERT(varchar, purch1.pur_dt, 103) AS 'Purch Date', party.pname AS 'Party Name', purch1.inv_no AS 'Purch Inv', CONVERT(varchar,purch1.inv_dt, 103) AS 'Invoice Date', item.it_name AS 'Product Name', batno.bat_no AS 'Batch No',(CASE WHEN purch2.prd_tp='1' THEN 'S' WHEN purch2.prd_tp='2' THEN 'D' END) AS 'Prd Type', STR(purch2.pur_qty, 10, 2) AS 'Purch Quantitty',STR(purch2.free_qty, 10, 2) AS 'Free', purch2.unt AS 'Unit', STR(purch2.mrp, 10, 2) AS 'Mrp',STR(purch2.pur_rt,10,2) AS 'Purch Amt', STR(purch2.tto_amt, 10, 2) AS 'Ammount',STR(purch2.disc_amt1, 10, 2) AS 'Company Discount', STR(purch2.disc_amt2, 10, 2) AS 'Trade Discount', taxper.taxnm AS 'Tax Name', STR(purch2.stax,10, 2) AS 'Tax Amt', STR(purch2.oth_amt, 10, 2) AS 'Other Charges', STR(purch2.disc_amt, 10, 2) AS 'Other Discount', STR(purch1.adj_amt, 10, 2) AS 'Adjust Amt', STR(purch1.pur_amt, 10, 2) AS 'Total Amt' FROM manf RIGHT OUTER JOIN item ON manf.manf_cd = item.manf_cd RIGHT OUTER JOIN batno RIGHT OUTER JOIN taxper INNER JOIN purch2 ON taxper.taxcd = purch2.tax_cd ON batno.bat_cd = purch2.bat_cd RIGHT OUTER JOIN purch1 LEFT OUTER JOIN party ON purch1.prt_code = party.prt_code ON purch2.pur_no = purch1.pur_no ON item.it_cd = purch2.it_cd WHERE (purch1.pur_dt>='" & Format(fromdt.Value, "dd/MMM/yyyy") & "') AND (purch1.pur_dt<='" & Format(todt.Value, "dd/MMM/yyyy") & "')  " & conditn & " ORDER BY party.pname,item.it_name")
        Else
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name) AS 'Sl.', purch1.pur_no AS 'Purch No.', manf.manf_nm AS 'Manufacture', item.it_name AS 'Produt Name', purch2.unt AS 'Unit', STR(purch2.pur_qty, 10, 2) AS 'Quantitty', STR(purch2.free_qty, 10, 2) AS 'Free', STR(purch2.mrp, 10, 2) AS 'Mrp', STR(purch2.disc_amt1, 10, 2) AS 'Company Discount', STR(purch2.disc_amt2, 10, 2) AS 'Trade Discount', taxper.taxnm AS 'VAT', STR(purch2.oth_amt, 10, 2) AS 'Other', STR(purch2.tto_amt, 10, 2) AS 'Total Amt.' FROM purch1 LEFT OUTER JOIN party ON purch1.prt_code = party.prt_code LEFT OUTER JOIN taxper INNER JOIN purch2 ON taxper.taxcd = purch2.tax_cd ON purch1.pur_no = purch2.pur_no LEFT OUTER JOIN  manf RIGHT OUTER JOIN item ON manf.manf_cd = item.manf_cd ON purch2.it_cd = item.it_cd WHERE (purch1.pur_dt>='" & Format(fromdt.Value, "dd/MMM/yyyy") & "') AND (purch1.pur_dt<='" & Format(todt.Value, "dd/MMM/yyyy") & "')   " & conditn & " ORDER BY item.it_name")
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            'slno = 0
            'For i As Integer = 0 To dv.Rows.Count - 1
            '    If ds.Tables(0).Rows(i).Item("Purchase type") = "1" Then
            '        ds.Tables(0).Rows(i).Item("Purchase type") = "Purchase"
            '    End If
            '    If ds.Tables(0).Rows(i).Item("Purchase type") = "1" Then
            '        ds.Tables(0).Rows(i).Item("Purchase type") = "Return"
            '    End If
            '    If slno = Val(dv.Rows(i).Cells(1).Value) Then
            '        dv.Rows(i).Cells(1).Value = ""
            '        dv.Rows(i).Cells(2).Value = ""
            '        dv.Rows(i).Cells(3).Value = ""
            '        dv.Rows(i).Cells(4).Value = ""
            '        dv.Rows(i).Cells(6).Value = ""
            '    Else
            '        slno = Val(dv.Rows(i).Cells(1).Value)
            '    End If

            'Next
            GroupBox3.Text = " Combine Purchase Register Form " & fromdt.Value & " To " & todt.Value
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

    Private Sub startdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fromdt.KeyPress
        key(todt, e)
    End Sub

    Private Sub enddt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles todt.KeyPress
        key(cmbparty, e)
    End Sub

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(cmbprod, e)
        SPKey(e)
    End Sub

    Private Sub cmbprod_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbprod.KeyPress
        key(cmbcompany, e)
        SPKey(e)
    End Sub

    Private Sub cmbcompany_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcompany.KeyPress
        key(cmbtype, e)
        SPKey(e)
    End Sub

    Private Sub cmbstat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtype.KeyPress
        key(cmborder, e)
        SPKey(e)
    End Sub

    Private Sub cmborder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmborder.KeyPress
        key(chkdetail, e)
        SPKey(e)
    End Sub

    Private Sub chkdetail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkdetail.KeyPress
        key(chkabstract, e)
    End Sub

    Private Sub chkabstract_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkabstract.KeyPress
        key(btnview, e)
    End Sub

#End Region

End Class
