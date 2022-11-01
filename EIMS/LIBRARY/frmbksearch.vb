Imports vb = Microsoft.VisualBasic
Public Class frmbksearch
    Dim comd As String

    Private Sub frmbksearch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmbksearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmbksearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
    End Sub

    Private Sub clr()
        txtsearch.Text = ""
        cmbstudserch.SelectedIndex = 0
        Me.Text = "Find a Book at a Glance . . . "
    End Sub
#Region "Enter/Leave"
    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstudserch.Enter, txtsearch.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstudserch.Leave, txtsearch.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrfresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrfresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrfresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrfresh.Click
        Me.clr()
    End Sub

    Private Sub cmbstudserch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstudserch.KeyPress
        key(txtsearch, e)
        SPKey(e)
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        Me.search()
    End Sub

    Private Sub search()
        Dim dssearch As DataSet
        dv.Columns.Clear()
        If txtsearch.Text <> "" Then
            If chkexact.Checked = True Then
                If cmbstudserch.SelectedIndex = 0 Then
                    dssearch = get_dataset(" SELECT ROW_NUMBER() OVER(ORDER BY book1.book_nm) AS 'Sl.',book1.book_nm AS 'Book Name', author.auth_nm AS 'Author', pubc.pub_nm AS 'Publication', book1.oth_auth AS 'Other Author', book1.cl_stk AS 'Quantity',book1.book_dnm AS 'Details Of The Book.' FROM book1 LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd WHERE  book1.book_nm LIKE '" & Trim(txtsearch.Text) & "%' AND book1.rec_lock='N' ORDER BY book1.book_nm ")
                ElseIf cmbstudserch.SelectedIndex = 1 Then
                    dssearch = get_dataset(" SELECT ROW_NUMBER() OVER(ORDER BY  author.auth_nm) AS 'Sl.',book1.book_nm AS 'Book Name', author.auth_nm AS 'Author', pubc.pub_nm AS 'Publication', book1.oth_auth AS 'Other Author', book1.cl_stk AS 'Quantity',book1.book_dnm AS 'Details Of The Book.' FROM book1 LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd WHERE  author.auth_nm LIKE '" & Trim(txtsearch.Text) & "%' AND book1.rec_lock='N' ORDER BY author.auth_nm")
                Else
                    dssearch = get_dataset(" SELECT ROW_NUMBER() OVER(ORDER BY pubc.pub_nm) AS 'Sl.',book1.book_nm AS 'Book Name', author.auth_nm AS 'Author', pubc.pub_nm AS 'Publication', book1.oth_auth AS 'Other Author', book1.cl_stk AS 'Quantity',book1.book_dnm AS 'Details Of The Book.' FROM book1 LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd WHERE  pubc.pub_nm  LIKE '" & Trim(txtsearch.Text) & "%' AND book1.rec_lock='N' ORDER BY pubc.pub_nm")
                End If
            Else
                If cmbstudserch.SelectedIndex = 0 Then
                    dssearch = get_dataset(" SELECT ROW_NUMBER() OVER(ORDER BY book1.book_nm) AS 'Sl.',book1.book_nm AS 'Book Name', author.auth_nm AS 'Author', pubc.pub_nm AS 'Publication', book1.oth_auth AS 'Other Author', book1.cl_stk AS 'Quantity',book1.book_dnm AS 'Details Of The Book.' FROM book1 LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd WHERE  book1.book_nm LIKE '%" & Trim(txtsearch.Text) & "%' AND book1.rec_lock='N' ORDER BY book1.book_nm ")
                ElseIf cmbstudserch.SelectedIndex = 1 Then
                    dssearch = get_dataset(" SELECT ROW_NUMBER() OVER(ORDER BY  author.auth_nm) AS 'Sl.',book1.book_nm AS 'Book Name', author.auth_nm AS 'Author', pubc.pub_nm AS 'Publication', book1.oth_auth AS 'Other Author', book1.cl_stk AS 'Quantity',book1.book_dnm AS 'Details Of The Book.' FROM book1 LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd WHERE  author.auth_nm LIKE '%" & Trim(txtsearch.Text) & "%' AND book1.rec_lock='N' ORDER BY  author.auth_nm")
                Else
                    dssearch = get_dataset(" SELECT ROW_NUMBER() OVER(ORDER BY pubc.pub_nm) AS 'Sl.'book1.book_nm AS 'Book Name', author.auth_nm AS 'Author', pubc.pub_nm AS 'Publication', book1.oth_auth AS 'Other Author', book1.cl_stk AS 'Quantity',book1.book_dnm AS 'Details Of The Book.' FROM book1 LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd WHERE  pubc.pub_nm  LIKE '%" & Trim(txtsearch.Text) & "%' AND book1.rec_lock='N' ORDER BY  pubc.pub_nm ")
                End If
            End If
                If dssearch.Tables(0).Rows.Count <> 0 Then
                    dv.DataSource = dssearch.Tables(0)
            Else
                MessageBox.Show("Sorry No Data Found. Please Search In Different Catagories. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
    End Sub

    Private Sub chkexact_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkexact.CheckedChanged
        Me.search()
    End Sub
End Class