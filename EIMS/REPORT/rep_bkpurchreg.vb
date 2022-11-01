Imports vb = Microsoft.VisualBasic
Public Class rep_bkpurchreg
    Dim comd As String

    Private Sub rep_bkpurchreg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_bkpurchreg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_bkpurchreg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        fromdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        todt.Value = fromdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        Me.Text = "Book Purchase Register . . ."
        hddr = Me.Text
        txtpartycd.Text = 0
        txtbkcd.Text = 0
        cmbtype.SelectedIndex = 0
        cmbbook.Text = ""
        cmbparty.Text = ""
        cmbtype.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False
        chkdetail.Checked = True
    End Sub

#Region "Enter/Leave"
    Private Sub cmbregist_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbook.Enter, cmbparty.Enter, cmbtype.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmbregist_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbook.Leave, cmbparty.Leave, cmbtype.Leave

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
        vdating(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' AND pname='" & Trim(cmbparty.Text) & "'", "Please Select A Valid Party Head Of A/c Name.")
    End Sub

    Private Sub cmbbook_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbook.GotFocus
        populate(cmbbook, "SELECT book_nm FROM book1 WHERE rec_lock='N' ORDER BY book_nm")
    End Sub

    Private Sub cmbbook_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbook.LostFocus
        cmbbook.Height = 21
    End Sub

    Private Sub cmbbook_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbook.Validated
        vdated(txtbkcd, "SELECT book_cd FROM book1 WHERE book_nm='" & Trim(cmbbook.Text) & "'")
    End Sub

    Private Sub cmbbook_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbbook.Validating
        vdating(cmbbook, "SELECT book_nm FROM book1 WHERE book_nm='" & Trim(cmbbook.Text) & "' AND rec_lock='N'", "Please Select A Valid Book Name.")
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
        If cmbtype.SelectedIndex = 0 Then
            If chkparty.Checked = False Then
                conditn = "WHERE (party.prt_code=" & Val(txtpartycd.Text) & ")  "
            End If
        ElseIf cmbtype.SelectedIndex = 1 Then
            If chkbook.Checked = False Then
                conditn = "WHERE (book1.book_cd=" & Val(txtbkcd.Text) & ") "
            End If
        End If
        If cmbtype.SelectedIndex = 0 Then
            If (chkdetail.Checked = True) Then
                ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY bk_pur1.pur_no ) AS 'Sl.', bk_pur1.pur_no AS 'Bkpurch No.', bk_pur1.pur_dt AS 'Bkpur Dt.', party.pname AS 'Party Name', (CASE WHEN  bk_pur1.pur_tp=1 THEN 'Cash' WHEN bk_pur1.pur_tp=2 THEN 'Credit' END) AS 'Tr.Type', bk_pur1.inv_no AS 'Inv No.', bk_pur1.inv_dt AS 'Inv Dt.', STR(bk_pur1.chr_amt,10,2) AS 'Charges Amt.', STR(bk_pur1.dis_amt,10,2) AS 'Discount Amt.', STR(bk_pur1.adj_amt,10,2) AS 'Adjust Amt.', STR(bk_pur1.gr_tot,10,2) AS 'Total' FROM bk_pur1 LEFT OUTER JOIN party ON bk_pur1.prt_code = party.prt_code " & conditn & "")
            Else
                ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY bk_pur1.pur_no ) AS 'Sl.', bk_pur1.pur_no AS 'Bkpurch No.', bk_pur1.pur_dt AS 'Bkpur Dt.', party.pname AS 'Party Name', (CASE WHEN  bk_pur1.pur_tp=1 THEN 'Cash' WHEN bk_pur1.pur_tp=2 THEN 'Credit' END) AS 'Tr.Type', STR(bk_pur1.chr_amt,10,2) AS 'Charges Amt.', STR(bk_pur1.dis_amt,10,2) AS 'Discount Amt.', STR(bk_pur1.adj_amt,10,2) AS 'Adjust Amt.', STR(bk_pur1.gr_tot,10,2) AS 'Total' FROM bk_pur1 LEFT OUTER JOIN party ON bk_pur1.prt_code = party.prt_code " & conditn & "")
            End If
        Else
            If (chkdetail.Checked = True) Then
                ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY book1.book_nm ) AS 'Sl.', bk_pur1.pur_no AS 'bkPurch No.', bk_pur1.pur_dt  AS 'bkPurch Dt.' , party.pname AS 'Party Name', book1.book_nm AS 'Book name', (CASE WHEN  bk_pur2.pur_tp=1 THEN 'Cash' WHEN bk_pur2.pur_tp=2 THEN 'Credit' END) AS 'Tr.Type', STR(bk_pur2.it_qty,10,2) AS 'book Qty.',STR(bk_pur2.it_rate,10,2) AS 'book Amt.', STR(bk_pur2.oth_amt,10,2) AS 'Other Amt.', STR(bk_pur1.gr_tot,10,2) AS 'Gr.Total' FROM book1 RIGHT OUTER JOIN bk_pur2 ON book1.book_cd = bk_pur2.book_cd RIGHT OUTER JOIN bk_pur1 ON bk_pur2.pur_no = bk_pur1.pur_no LEFT OUTER JOIN party ON bk_pur1.prt_code = party.prt_code " & conditn & "")
            Else
                ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY book1.book_nm ) AS 'Sl.', bk_pur1.pur_no AS 'bkPurch No.', bk_pur1.pur_dt  AS 'bkPurch Dt.' , book1.book_nm AS 'Book name',  STR(bk_pur2.it_qty,10,2) AS 'book Qty.',bk_pur2.it_rate AS 'book Amt.', STR(bk_pur2.oth_amt,10,2) AS 'Other Amt.', STR(bk_pur1.gr_tot,10,2) AS 'Gr.Total' FROM book1 RIGHT OUTER JOIN bk_pur2 ON book1.book_cd = bk_pur2.book_cd RIGHT OUTER JOIN bk_pur1 ON bk_pur2.pur_no = bk_pur1.pur_no LEFT OUTER JOIN party ON bk_pur1.prt_code = party.prt_code" & conditn & "")
            End If
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            GroupBox3.Text = " Book Purchase Register. . . "
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

    Private Sub chkbook_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbook.CheckedChanged
        If chkbook.Checked = True Then
            cmbbook.Text = "<<< All Books >>>"
            cmbbook.Enabled = False
            txtbkcd.Text = 0
        Else
            cmbbook.Text = ""
            cmbbook.Enabled = True
            cmbbook.Focus()
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

    Private Sub fromdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fromdt.KeyPress
        key(todt, e)
    End Sub

    Private Sub todt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles todt.KeyPress
        key(cmbtype, e)
    End Sub

    Private Sub cmbtype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtype.KeyPress
        If cmbtype.SelectedIndex = 0 Then
            key(cmbparty, e)
        Else
            key(cmbbook, e)
        End If

    End Sub

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(chkdetail, e)
        SPKey(e)
    End Sub

    Private Sub cmbbook_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbook.KeyPress
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


    Private Sub cmbtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.SelectedIndexChanged
        If cmbtype.SelectedIndex = 0 Then
            cmbparty.Visible = True
            chkparty.Visible = True
            cmbbook.Visible = False
            chkbook.Visible = False

        ElseIf cmbtype.SelectedIndex = 1 Then
            cmbbook.Visible = True
            chkbook.Visible = True
            cmbparty.Visible = False
            chkparty.Visible = False


        End If
    End Sub
End Class
