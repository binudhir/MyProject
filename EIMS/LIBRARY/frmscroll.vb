Imports vb = Microsoft.VisualBasic
Public Class frmscroll
    Dim comd As String

    Private Sub frmscroll_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnubkscrl.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmscroll_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmscroll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnubkscrl.Enabled = False
        Me.clr()
    End Sub

    Private Sub clr()
        Me.Text = "Scrolling of Books . . ."
        txtdetailnm.Text = ""
        txtauth.Text = ""
        txtothauth.Text = ""
        txtpub.Text = ""
        txtsub.Text = ""
        txtisbn.Text = ""
        txtstock.Text = ""
        txtmrp.Text = ""
        dv1.Rows.Clear()
        cmbbooknm.Focus()
    End Sub

#Region "Enter/Leave"
    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbooknm.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbooknm.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub
#End Region

#Region "Mouse Enter/Leave"
    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "Key Press"
    Private Sub cmbbooknm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbooknm.KeyPress
        key(dv1, e)
        SPKey(e)
    End Sub
#End Region

#Region "Combo"
    Private Sub cmbbooknm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbooknm.GotFocus
        populate(cmbbooknm, "SELECT book1.book_nm FROM book2 LEFT OUTER JOIN book1 ON book2.book_cd = book1.book_cd WHERE(book2.scroll_nm = '') GROUP BY book1.book_nm")
    End Sub

    Private Sub cmbbooknm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbooknm.LostFocus
        cmbbooknm.Height = 21
    End Sub

    Private Sub cmbbooknm_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbooknm.Validated
        Dim ds As DataSet = get_dataset("SELECT book1.book_cd,book1.book_dnm, book1.isbn_no, book1.cl_stk, book1.mrp, pubc.pub_nm, subject_mst.sub_nm, author.auth_nm, book1.oth_auth FROM book1 LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd LEFT OUTER JOIN subject_mst ON book1.sub_cd = subject_mst.sub_cd LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd WHERE book1.book_nm='" & Trim(cmbbooknm.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtbookcd.Text = ds.Tables(0).Rows(0).Item("book_cd")
            txtdetailnm.Text = ds.Tables(0).Rows(0).Item("book_dnm")
            txtisbn.Text = ds.Tables(0).Rows(0).Item("isbn_no")
            txtpub.Text = ds.Tables(0).Rows(0).Item("pub_nm")
            txtauth.Text = ds.Tables(0).Rows(0).Item("auth_nm")
            txtothauth.Text = ds.Tables(0).Rows(0).Item("oth_auth")
            txtsub.Text = ds.Tables(0).Rows(0).Item("sub_nm")
            txtmrp.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            txtstock.Text = ds.Tables(0).Rows(0).Item("cl_stk")
            Me.dv_view(txtbookcd.Text)
        End If

    End Sub

    Private Sub cmbbooknm_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbbooknm.Validating
        vdating(cmbbooknm, "SELECT book1.book_nm FROM book2 LEFT OUTER JOIN book1 ON book2.book_cd = book1.book_cd WHERE(book2.scroll_nm = '' AND book2.book_frm='P' AND book1.book_nm='" & Trim(cmbbooknm.Text) & "') GROUP BY book1.book_nm", "Please Select A Valid Book Name.")
    End Sub
#End Region

    Private Sub dv_view(ByVal slno As Integer)
        Dim ds As DataSet = get_dataset("SELECT * FROM book2 WHERE (scroll_nm = '' AND book_cd=" & Val(txtbookcd.Text) & ")")
        dv1.Rows.Clear()
        If (ds.Tables(0).Rows.Count <> 0) Then
            Dim rw As Integer = 0
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(rw).Item("scroll_nm")
                dv1.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(rw).Item("edition")
                dv1.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(rw).Item("yr_pub")
                dv1.Rows(rw).Cells(4).Value = Format(ds.Tables(0).Rows(rw).Item("pages"), "#######0")
                dv1.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(rw).Item("mrp"), "#######0.00")
                dv1.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(rw).Item("in_date"), "dd/MM/yyyy")
                dv1.Rows(rw).Cells(8).Value = ds.Tables(0).Rows(rw).Item("scroll_cd")
                rw = rw + 1
            Next
        End If
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(cmbbooknm.Text) = "" Then
            MessageBox.Show("Please Provide A Book Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbbooknm.Focus()
            Exit Sub
        End If
        fnd = 1
        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                If Trim(dv1.Rows(i).Cells(1).Value) <> "" Then
                    fnd = 0
                End If
            Next
        End If
        If fnd = 1 Then
            MessageBox.Show("Sorry The Book Code Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dv1.Focus()
            Exit Sub
        End If

        fnd = 0
        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                If Trim(dv1.Rows(i).Cells(2).Value) = "" And Trim(dv1.Rows(i).Cells(1).Value) <> "" Then
                    fnd = 1
                End If
            Next
        End If
        If fnd = 1 Then
            MessageBox.Show("Please Provide The Book Edition.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dv1.Focus()
            Exit Sub
        End If

        fnd = 0
        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                If Val(dv1.Rows(i).Cells(3).Value) = 0 And Trim(dv1.Rows(i).Cells(1).Value) <> "" Then
                    fnd = 1
                End If
            Next
        End If
        If fnd = 1 Then
            MessageBox.Show("Please Provide The Year Of Publication.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dv1.Focus()
            Exit Sub
        End If


        fnd = 0
        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                If Val(dv1.Rows(i).Cells(4).Value) = 0 And Trim(dv1.Rows(i).Cells(1).Value) <> "" Then
                    fnd = 1
                End If
            Next
        End If
        If fnd = 1 Then
            MessageBox.Show("Sorry The Page No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dv1.Focus()
            Exit Sub
        End If

        fnd = 0
        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                If Val(dv1.Rows(i).Cells(5).Value) = 0 And Trim(dv1.Rows(i).Cells(1).Value) <> "" Then
                    fnd = 1
                End If
            Next
        End If
        If fnd = 1 Then
            MessageBox.Show("Please Provide The Book's MRP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dv1.Focus()
            Exit Sub
        End If

        Me.book_save()
    End Sub

    Private Sub book_save()
        cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Start1()
        If cnfr = vbYes Then
            If dv1.RowCount <> 0 Then
                For i As Integer = 0 To dv1.RowCount - 1
                    access_no = Trim(dv1.Rows(i).Cells(1).Value)
                    edtn = dv1.Rows(i).Cells(2).Value
                    yr = dv1.Rows(i).Cells(3).Value
                    pages = dv1.Rows(i).Cells(4).Value
                    mrp = dv1.Rows(i).Cells(5).Value
                    cond = dv1.Rows(i).Cells(6).Value
                    scrl_cd = dv1.Rows(i).Cells(8).Value
                    If cond = "" Then
                        cond = "1"
                    End If
                    If access_no <> "" Then
                        SQLInsert("UPDATE book2 SET yr_pub ='" & Trim(yr) & "',scroll_nm='" & Trim(access_no) & "',prd_tp ='" & vb.Left(cond, 1) & "',edition ='" & Trim(edtn) & "',pages =" & Val(pages) & ",mrp=" & Val(mrp) & " WHERE scroll_cd=" & Val(scrl_cd) & "")
                        dv1.Rows(i).Cells(1).Value = ""
                    End If
                Next
            End If
            Me.clr()
        End If
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub dv1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dv1.CellValidated
        For i As Integer = 0 To dv1.Rows.Count - 1
            If Trim(dv1.Rows(i).Cells(1).Value) <> "" Then
                scroll_nm = Trim(dv1.Rows(i).Cells(1).Value)
                Dim ds As DataSet = get_dataset("SELECT book1.book_nm FROM book1 LEFT OUTER JOIN book2 ON book1.book_cd = book2.book_cd WHERE (book2.scroll_nm = '" & scroll_nm & "')")
                If ds.Tables(0).Rows.Count <> 0 Then
                    book_nm = ds.Tables(0).Rows(0).Item(0)
                    MessageBox.Show("Sorry The Scroll No. :- " & scroll_nm & " is Already Assigned to The Book - " & book_nm, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dv1.Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                    dv1.Rows(i).Cells(1).Value = ""
                    dv1.Focus()
                Else
                    dv1.Rows(i).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
                End If
            End If
        Next
    End Sub
End Class
