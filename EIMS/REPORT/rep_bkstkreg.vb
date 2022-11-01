Imports vb = Microsoft.VisualBasic
Public Class rep_bkstkreg
    Dim comd As String

    Private Sub rep_bkstkreg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_bkstkreg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_bkstkreg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        'startdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        'enddt.Value = startdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        Me.Text = "Book Stock Register . . . ."
        hddr = Me.Text
        txtpubcd.Text = 0
        txtbkcd.Text = 0
        txtauthcd.Text = 0
        txtunitcd.Text = 0
        cmbauth.Text = ""
        cmbpub.Text = ""
        cmbbook.Text = ""
        cmborder.SelectedIndex = 0
        cmborder.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False
        'rdbdetail.Checked = True
    End Sub

#Region "Enter/Leave"
    Private Sub cmbregist_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbauth.Enter, cmbpub.Enter, cmbbook.Enter, cmborder.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmbregist_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbauth.Leave, cmbpub.Leave, cmbbook.Leave, cmborder.Leave

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


    Private Sub chkpub_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpub.CheckedChanged
        If chkpub.Checked = True Then
            cmbpub.Text = "<<< All Publications >>>"
            cmbpub.Enabled = False
            txtpubcd.Text = 0
        Else
            cmbpub.Text = ""
            cmbpub.Enabled = True
            cmbpub.Focus()
        End If
    End Sub

    Private Sub chkauth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkauth.CheckedChanged
        If chkauth.Checked = True Then
            cmbauth.Text = "<<< All Authors >>>"
            cmbauth.Enabled = False
            txtauthcd.Text = 0
        Else
            cmbauth.Text = ""
            cmbauth.Enabled = True
            cmbauth.Focus()
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

    Private Sub cmbpub_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpub.KeyPress
        key(cmbauth, e)
        SPKey(e)
    End Sub

    Private Sub cmbauth_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbauth.KeyPress
        key(cmbbook, e)
        SPKey(e)
    End Sub

    Private Sub cmbbook_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbook.KeyPress
        key(cmborder, e)
        SPKey(e)
    End Sub

    Private Sub cmborder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmborder.KeyPress
        key(chkdetail, e)
        SPKey(e)
    End Sub

    Private Sub chkdetail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkdetail.KeyPress
        key(chkabstract, e)
        SPKey(e)
    End Sub

    Private Sub chkabstract_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkabstract.KeyPress
        key(btnview, e)
    End Sub

#End Region

#Region "combobox"
    Private Sub cmbauth_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbauth.GotFocus
        populate(cmbauth, "SELECT auth_nm FROM author WHERE rec_lock='N' ORDER BY auth_nm")
    End Sub

    Private Sub cmbauth_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbauth.LostFocus
        cmbauth.Height = 21
    End Sub

    Private Sub cmbauth_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbauth.Validated
        vdated(txtauthcd, "SELECT auth_cd FROM author WHERE auth_nm='" & Trim(cmbauth.Text) & "'")
    End Sub

    Private Sub cmbauth_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbauth.Validating
        vdating(cmbauth, "SELECT auth_nm FROM author WHERE auth_nm='" & Trim(cmbauth.Text) & "' AND rec_lock='N'", "Please Select A Valid Author Name.")
    End Sub

    Private Sub cmbpub_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpub.GotFocus
        populate(cmbpub, "SELECT pub_nm FROM pubc WHERE rec_lock='N' ORDER BY pub_nm")
    End Sub

    Private Sub cmbpub_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpub.LostFocus
        cmbpub.Height = 21
    End Sub

    Private Sub cmbpub_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpub.Validated
        vdated(txtpubcd, "SELECT pub_cd FROM pubc WHERE pub_nm='" & Trim(cmbpub.Text) & "'")
    End Sub

    Private Sub cmbpub_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbpub.Validating
        vdating(cmbpub, "SELECT pub_nm FROM pubc WHERE pub_nm='" & Trim(cmbpub.Text) & "' AND rec_lock='N'", "Please Select A Valid Publication Name.")
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

        conditn = "WHERE "
        If chkpub.Checked = False Then
            conditn = conditn & "(pubc.pub_cd=" & Val(txtpubcd.Text) & ") AND "
        End If
        If chkauth.Checked = False Then
            conditn = conditn & "(author.auth_cd=" & Val(txtauthcd.Text) & ") AND "
        End If
        If chkbook.Checked = False Then
            conditn = conditn & "(book1.book_cd=" & Val(txtbkcd.Text) & ") "
        End If

        If conditn = "WHERE " Then
            conditn = ""
        End If
        orderby = "book1.book_nm"
        If cmborder.SelectedIndex = 1 Then
            orderby = " author.auth_nm"
        End If
        If cmborder.SelectedIndex = 2 Then
            orderby = "pubc.pub_nm"
        End If

        If (chkdetail.Checked = True) Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', book1.book_nm AS 'Book Name', author.auth_nm AS 'Author Name', pubc.pub_nm AS 'Publication Name', subject_mst.sub_nm AS 'Subject name', book1.op_stk AS 'Opening Sstok', book1.iss_stk AS 'Issue Stock', book1.cl_stk AS 'Close Stock' FROM book1 LEFT OUTER JOIN subject_mst ON book1.sub_cd = subject_mst.sub_cd LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd " & conditn & " ORDER BY " & orderby & "")
        Else
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', book1.book_nm AS 'Book Name', author.auth_nm AS 'Author Name', pubc.pub_nm AS 'Publication Name', subject_mst.sub_nm AS 'Subject name', book1.op_stk AS 'Opening Sstok', book1.iss_stk AS 'Issue Stock', book1.cl_stk AS 'Close Stock' FROM book1 LEFT OUTER JOIN subject_mst ON book1.sub_cd = subject_mst.sub_cd LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd " & conditn & " ORDER BY " & orderby & "")
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            GroupBox3.Text = " Book Register Form "
            hddr = GroupBox3.Text
        Else
            lblmsg.Visible = True
        End If
        Close1()
    End Sub
End Class