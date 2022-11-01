Imports vb = Microsoft.VisualBasic
Public Class rep_bkissuereg
    Dim comd As String

    Private Sub rep_bkissuereg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_bkissuereg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_bkissuereg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        fromdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        todt.Value = fromdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        If cmbref.SelectedIndex = 0 Then
            Me.Text = "Book Issue Register . . ."
        Else
            Me.Text = "Book Refund Register . . ."
        End If
        hddr = Me.Text
        txtstudcd.Text = 0
        txtbkcd.Text = 0
        cmbiss.SelectedIndex = 0
        cmborder.SelectedIndex = 0
        cmbbook.Text = ""
        cmbstud.Text = ""
        cmbiss.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False
        chkdetail.Checked = True
    End Sub

#Region "Enter/Leave"
    Private Sub cmbregist_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbook.Enter, cmbstud.Enter, cmbiss.Enter, cmborder.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmbregist_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbook.Leave, cmbstud.Leave, cmbiss.Leave, cmborder.Leave

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
    Private Sub cmbstud_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstud.GotFocus
        If cmbiss.SelectedIndex = 0 Then
            populate(cmbstud, "SELECT stud_nm FROM stud WHERE rec_lock='N' ORDER BY stud_nm")
        ElseIf cmbiss.SelectedIndex = 1 Then
            populate(cmbstud, "SELECT staf_nm FROM staf WHERE rec_lock='N' ORDER BY staf_nm")
        End If
    End Sub

    Private Sub cmbstud_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstud.LostFocus
        cmbstud.Height = 21
    End Sub

    Private Sub cmbstud_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstud.Validated
        If cmbiss.SelectedIndex = 0 Then
            vdated(txtstudcd, "SELECT stud_sl FROM stud WHERE stud_nm='" & Trim(cmbstud.Text) & "'")
        ElseIf cmbiss.SelectedIndex = 1 Then
            vdated(txtstudcd, "SELECT staf_sl FROM staf WHERE staf_nm='" & Trim(cmbstud.Text) & "'")
        End If
    End Sub

    Private Sub cmbstud_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstud.Validating
        If cmbiss.SelectedIndex = 0 Then
            vdating(cmbstud, "SELECT stud_nm FROM stud WHERE stud_nm='" & Trim(cmbstud.Text) & "' AND rec_lock='N'", "Please Select A Valid Student Name.")
        ElseIf cmbiss.SelectedIndex = 1 Then
            vdating(cmbstud, "SELECT staf_nm FROM staf WHERE staf_nm='" & Trim(cmbstud.Text) & "' AND rec_lock='N'", "Please Select A Valid Staff Name.")
        End If
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
        If cmbiss.SelectedIndex = 0 Then
            If chkstud.Checked = False Then
                conditn = " AND (stud.stud_sl=" & Val(txtstudcd.Text) & ") "
            End If
        ElseIf cmbiss.SelectedIndex = 1 Then
            If chkstud.Checked = False Then
                conditn = " AND (staf.staf_sl=" & Val(txtstudcd.Text) & ") "
            End If
        End If
        If chkbook.Checked = False Then
            If conditn <> "" Then
                conditn = conditn & " AND (book1.book_cd=" & Val(txtbkcd.Text) & ") "
            Else
                conditn = " AND (book1.book_cd=" & Val(txtbkcd.Text) & ") "
            End If
        End If
        orderby = "bk_iss2.iss_dt"
        If cmborder.SelectedIndex = 1 Then
            orderby = " book1.book_nm"
        End If
        If cmbref.SelectedIndex = 0 Then
            If cmbiss.SelectedIndex = 0 Then
                If (chkdetail.Checked = True) Then
                    ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & " ) AS 'Sl.', bk_iss2.iss_no AS 'Issue No.', CONVERT(varchar,bk_iss2.iss_dt,103) AS 'Issue Dt.', stud.stud_nm AS 'Student Name.', book1.book_nm AS 'Book Name.', STR(bk_iss2.qty,10,0) AS 'Qty.', STR(bk_iss2.mrp,10,2) AS 'M.R.P' FROM bk_iss2 LEFT OUTER JOIN book1 ON bk_iss2.book_cd = book1.book_cd LEFT OUTER JOIN stud ON bk_iss2.stud_sl = stud.stud_sl WHERE (bk_iss2.iss_tp='1') AND (bk_iss2.refund='" & vb.Left(cmbref.Text, 1) & "')" & conditn & " ORDER BY " & orderby & " ")
                Else
                    ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & " ) AS 'Sl.', bk_iss2.iss_no AS 'Issue No.', CONVERT(varchar,bk_iss2.iss_dt,103) AS 'Issue Dt.', stud.stud_nm AS 'Student Name.', book1.book_nm AS 'Book Name.', STR(bk_iss2.qty,10,0) AS 'Qty.', STR(bk_iss2.mrp,10,2) AS 'M.R.P' FROM bk_iss2 LEFT OUTER JOIN book1 ON bk_iss2.book_cd = book1.book_cd LEFT OUTER JOIN stud ON bk_iss2.stud_sl = stud.stud_sl WHERE (bk_iss2.iss_tp='1') AND (bk_iss2.refund='" & vb.Left(cmbref.Text, 1) & "')" & conditn & " ORDER BY " & orderby & " ")
                End If
            Else
                If (chkdetail.Checked = True) Then
                    ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & " ) AS 'Sl.', bk_iss2.iss_no AS 'Issue No.', CONVERT(varchar, bk_iss2.iss_dt, 103) AS 'Issue Dt.', staf.staf_nm AS 'Staff Name.', book1.book_nm AS 'Book Name.', STR(bk_iss2.qty, 10, 0) AS 'Qty.', STR(bk_iss2.mrp, 10, 2) AS 'M.R.P' FROM bk_iss2 LEFT OUTER JOIN staf ON bk_iss2.staf_sl = staf.staf_sl LEFT OUTER JOIN book1 ON bk_iss2.book_cd = book1.book_cd WHERE (bk_iss2.iss_tp = '2') AND (bk_iss2.refund='" & vb.Left(cmbref.Text, 1) & "')" & conditn & " ORDER BY " & orderby & " ")
                Else
                    ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & " ) AS 'Sl.', bk_iss2.iss_no AS 'Issue No.', CONVERT(varchar, bk_iss2.iss_dt, 103) AS 'Issue Dt.', staf.staf_nm AS 'Staff Name.', book1.book_nm AS 'Book Name.', STR(bk_iss2.qty, 10, 0) AS 'Qty.', STR(bk_iss2.mrp, 10, 2) AS 'M.R.P' FROM bk_iss2 LEFT OUTER JOIN staf ON bk_iss2.staf_sl = staf.staf_sl LEFT OUTER JOIN book1 ON bk_iss2.book_cd = book1.book_cd WHERE (bk_iss2.iss_tp = '2') AND (bk_iss2.refund='" & vb.Left(cmbref.Text, 1) & "')" & conditn & " ORDER BY " & orderby & " ")
                End If
            End If
        Else
            If cmbiss.SelectedIndex = 0 Then
                If (chkdetail.Checked = True) Then
                    ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & " ) AS 'Sl.', bk_iss2.iss_no AS 'Ref No.', CONVERT(varchar,bk_iss2.ret_dt,103) AS 'Issue Dt.', stud.stud_nm AS 'Student Name.', book1.book_nm AS 'Book Name.', STR(bk_iss2.qty,10,0) AS 'Qty.', STR(bk_iss2.mrp,10,2) AS 'M.R.P' FROM bk_iss2 LEFT OUTER JOIN book1 ON bk_iss2.book_cd = book1.book_cd LEFT OUTER JOIN stud ON bk_iss2.stud_sl = stud.stud_sl WHERE (bk_iss2.iss_tp='1') AND (bk_iss2.refund='" & vb.Left(cmbref.Text, 1) & "')" & conditn & " ORDER BY " & orderby & " ")
                Else
                    ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & " ) AS 'Sl.', bk_iss2.iss_no AS 'Ref No.', CONVERT(varchar,bk_iss2.ret_dt,103) AS 'Issue Dt.', stud.stud_nm AS 'Student Name.', book1.book_nm AS 'Book Name.', STR(bk_iss2.qty,10,0) AS 'Qty.', STR(bk_iss2.mrp,10,2) AS 'M.R.P' FROM bk_iss2 LEFT OUTER JOIN book1 ON bk_iss2.book_cd = book1.book_cd LEFT OUTER JOIN stud ON bk_iss2.stud_sl = stud.stud_sl WHERE (bk_iss2.iss_tp='1') AND (bk_iss2.refund='" & vb.Left(cmbref.Text, 1) & "')" & conditn & " ORDER BY " & orderby & " ")
                End If
            Else
                If (chkdetail.Checked = True) Then
                    ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & " ) AS 'Sl.', bk_iss2.iss_no AS 'Ref No.', CONVERT(varchar, bk_iss2.ret_dt, 103) AS 'Issue Dt.', staf.staf_nm AS 'Staff Name.', book1.book_nm AS 'Book Name.', STR(bk_iss2.qty, 10, 0) AS 'Qty.', STR(bk_iss2.mrp, 10, 2) AS 'M.R.P' FROM bk_iss2 LEFT OUTER JOIN staf ON bk_iss2.staf_sl = staf.staf_sl LEFT OUTER JOIN book1 ON bk_iss2.book_cd = book1.book_cd WHERE (bk_iss2.iss_tp = '2') AND (bk_iss2.refund='" & vb.Left(cmbref.Text, 1) & "')" & conditn & " ORDER BY " & orderby & " ")
                Else
                    ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & " ) AS 'Sl.', bk_iss2.iss_no AS 'Ref No.', CONVERT(varchar, bk_iss2.ret_dt, 103) AS 'Issue Dt.', staf.staf_nm AS 'Staff Name.', book1.book_nm AS 'Book Name.', STR(bk_iss2.qty, 10, 0) AS 'Qty.', STR(bk_iss2.mrp, 10, 2) AS 'M.R.P' FROM bk_iss2 LEFT OUTER JOIN staf ON bk_iss2.staf_sl = staf.staf_sl LEFT OUTER JOIN book1 ON bk_iss2.book_cd = book1.book_cd WHERE (bk_iss2.iss_tp = '2') AND (bk_iss2.refund='" & vb.Left(cmbref.Text, 1) & "')" & conditn & " ORDER BY " & orderby & " ")
                End If
            End If
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            If cmbref.SelectedIndex = 0 Then
                GroupBox3.Text = " Book Issue Register. . . "
            Else
                GroupBox3.Text = " Book Refund Register. . . "
            End If
            hddr = GroupBox3.Text
        Else
            lblmsg.Visible = True
        End If
        Close1()
    End Sub

#Region "checkBox"

    Private Sub chkstud_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkstud.CheckedChanged
        If chkstud.Checked = True Then
            If cmbiss.SelectedIndex = 0 Then
                cmbstud.Text = "<<< All Students >>>"
            Else
                cmbstud.Text = "<<< All Employee >>>"
            End If
            cmbstud.Enabled = False
            txtstudcd.Text = 0
        Else
            cmbstud.Text = ""
            cmbstud.Enabled = True
            cmbstud.Focus()
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
        key(cmbiss, e)
    End Sub

    Private Sub cmbiss_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbiss.KeyPress
        key(cmbstud, e)
        SPKey(e)
    End Sub

    Private Sub cmbstud_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstud.KeyPress
        key(cmbbook, e)
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


    Private Sub cmbiss_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbiss.SelectedIndexChanged
        If cmbiss.SelectedIndex = 0 Then
            lblstud.Text = "Student Name :"
        ElseIf cmbiss.SelectedIndex = 1 Then
            lblstud.Text = "Staff Name :"
        End If
    End Sub
End Class
