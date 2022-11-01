Imports vb = Microsoft.VisualBasic
Public Class frmbkreturn
    Dim comd As String = "E"

    Private Sub frmbkreturn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnubkret.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmbkreturn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmbkreturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnubkret.Enabled = False
        Me.clr()
        cmbtrtype.SelectedIndex = 0
    End Sub

    Private Sub clr()
        txtstucd.Text = "0"
        txtstafcd.Text = "0"

        txtroll.Text = ""
        txtnm.Text = ""
        dttr.Text = sys_date
        txtsession.Text = ""
        txttrade.Text = ""
        txtsem.Text = ""
        dv.Rows.Clear()
        txtroll.Focus()
    End Sub


#Region "Enter/Leave"
    Private Sub sender_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrtype.Enter, txtroll.Enter, dttr.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
        sender.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Bold)
    End Sub

    Private Sub sender_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrtype.Leave, txtroll.Leave, dttr.Leave
        sender.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Regular)
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub


#End Region

#Region "Key Press"
    Private Sub cmbtrtype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtrtype.KeyPress
        key(txtroll, e)
        SPKey(e)
    End Sub

    Private Sub txtroll_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtroll.KeyPress
        key(dttr, e)
        SPKey(e)
    End Sub

    Private Sub dttr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dttr.KeyPress
        key(btnrefresh, e)
    End Sub

#End Region

#Region "Combo Box"
    Private Sub cmbtrtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrtype.SelectedIndexChanged
        If cmbtrtype.SelectedIndex = 0 Then
            lblroll.Text = "Regd No.:"
            lblsession.Text = "Session :"
            lbltrade.Text = "Trade :"
            lblsem.Visible = True
            txtsem.Visible = True
        End If
        If cmbtrtype.SelectedIndex = 1 Then
            lblroll.Text = "Emp No.:"
            lblsession.Text = "Desg.:"
            lbltrade.Text = "Dept.:"
            lblsem.Visible = False
            txtsem.Visible = False
        End If
    End Sub

    Private Sub cmbtrtype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        cmbtrtype.Height = 100
    End Sub

    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        cmbtrtype.Height = 21
    End Sub

#End Region

#Region "Botton"
    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
    End Sub

#End Region

    Private Sub txtroll_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtroll.Validated
        If cmbtrtype.SelectedIndex = 0 Then
            Dim ds As DataSet = get_dataset("SELECT stud.stud_sl,stud.stud_nm,sesion1.sesn_nm,semester.sem_nm,trad.trad_nm FROM stud_hstry INNER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd INNER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd INNER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE(stud_hstry.reg_no = '" & Trim(txtroll.Text) & "') AND (stud_hstry.active = 'Y')")
            If ds.Tables(0).Rows.Count <> 0 Then
                txtnm.Text = ds.Tables(0).Rows(0).Item("stud_nm")
                txtsession.Text = Trim(ds.Tables(0).Rows(0).Item("sesn_nm"))
                txttrade.Text = Trim(ds.Tables(0).Rows(0).Item("trad_nm"))
                txtsem.Text = Format(ds.Tables(0).Rows(0).Item("sem_nm"))
                txtstucd.Text = Format(ds.Tables(0).Rows(0).Item("stud_sl"))
                Me.dv_view(txtstucd.Text)
          
            End If
        Else
            Dim ds As DataSet = get_dataset("SELECT staf.staf_nm , desg.desg_nm, dept.dept_nm, staf.staf_sl FROM staf LEFT OUTER JOIN dept ON staf.dept_cd = dept.dept_cd LEFT OUTER JOIN desg ON staf.desg_cd = desg.desg_cd WHERE (staf.staf_id = '" & Trim(txtroll.Text) & "')")
            If ds.Tables(0).Rows.Count <> 0 Then
                txtnm.Text = ds.Tables(0).Rows(0).Item("staf_nm")
                txtsession.Text = Trim(ds.Tables(0).Rows(0).Item("desg_nm"))
                txttrade.Text = Trim(ds.Tables(0).Rows(0).Item("dept_nm"))
                txtstucd.Text = Format(ds.Tables(0).Rows(0).Item("staf_sl"))
                Me.dv_view(txtstafcd.Text)
           
            End If
        End If

    End Sub


    Private Sub dv_view(ByVal slno As Integer)
        Dim ds As DataSet
        If cmbtrtype.SelectedIndex = 0 Then
            ds = get_dataset("SELECT bk_iss2.iss_dt, bk_iss2.apret_dt, bk_iss2.mrp, bk_iss2.penalty, book2.scroll_nm,book2.book_cd, book1.book_nm, pubc.pub_nm, bk_iss2.iss_no, bk_iss2.scroll_cd, bk_iss2.iss_sl FROM pubc RIGHT OUTER JOIN book1 ON pubc.pub_cd = book1.pub_cd RIGHT OUTER JOIN bk_iss2 ON book1.book_cd = bk_iss2.book_cd LEFT OUTER JOIN book2 ON bk_iss2.scroll_cd = book2.scroll_cd WHERE (bk_iss2.stud_sl=" & slno & " AND bk_iss2.refund='N')")
        Else
            ds = get_dataset("SELECT bk_iss2.iss_dt, bk_iss2.apret_dt, bk_iss2.mrp, bk_iss2.penalty, book2.scroll_nm,book2.book_cd, book1.book_nm, pubc.pub_nm, bk_iss2.iss_no, bk_iss2.scroll_cd, bk_iss2.iss_sl FROM pubc RIGHT OUTER JOIN book1 ON pubc.pub_cd = book1.pub_cd RIGHT OUTER JOIN bk_iss2 ON book1.book_cd = bk_iss2.book_cd LEFT OUTER JOIN book2 ON bk_iss2.scroll_cd = book2.scroll_cd WHERE (bk_iss2.staf_sl=" & slno & " AND bk_iss2.refund='N')")
        End If
        dv.Rows.Clear()
        If (ds.Tables(0).Rows.Count <> 0) Then
            Dim rw As Integer = 0
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv.Rows.Add()
                dv.Rows(rw).Cells(0).Value = i + 1
                dv.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(rw).Item("scroll_nm")
                dv.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(rw).Item("book_nm")
                dv.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(rw).Item("pub_nm")
                dv.Rows(rw).Cells(4).Value = Format(ds.Tables(0).Rows(rw).Item("mrp"), "######0.00")
                dv.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(rw).Item("iss_dt"), "dd/MM/yy")
                dv.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(rw).Item("apret_dt"), "dd/MM/yy")
                ' dv.Rows(rw).Cells(7).Value = 1 Then
                dv.Rows(rw).Cells(8).Value = Format("0.00")
                dv.Rows(rw).Cells(9).Value = ds.Tables(0).Rows(rw).Item("scroll_cd")
                dv.Rows(rw).Cells(10).Value = ds.Tables(0).Rows(rw).Item("iss_no")
                dv.Rows(rw).Cells(11).Value = ds.Tables(0).Rows(rw).Item("iss_sl")
                dv.Rows(rw).Cells(12).Value = ds.Tables(0).Rows(rw).Item("book_cd")
                dv.Rows(rw).Cells(13).Value = "Refund"
                rw = rw + 1
            Next
        Else
            MessageBox.Show("There Is No Book To Return.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clr()
        End If
    End Sub

    Private Sub dv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dv.CellClick
        If e.ColumnIndex = 13 Then
            ' MsgBox(("Row : " + e.RowIndex.ToString & "  Col : ") + e.ColumnIndex.ToString)
            rw = e.RowIndex.ToString
            iss_sl = dv.Rows(rw).Cells(11).Value
            scrollcd = dv.Rows(rw).Cells(9).Value
            fine = dv.Rows(rw).Cells(8).Value
            cond = dv.Rows(rw).Cells(7).Value
            bknm = dv.Rows(rw).Cells(2).Value
            bk_cd = dv.Rows(rw).Cells(1).Value
            book_cd = dv.Rows(rw).Cells(12).Value
            If cond = "" Then
                cond = "1"
            End If
            cnfr = MessageBox.Show("Are You Sure To Return The Book" & vbCrLf & " " & vbCrLf & " [" & bknm & "] " & vbCrLf & "" & vbCrLf & " Having The Book Code [" & bk_cd & "] ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then

                SQLInsert("UPDATE bk_iss2 SET refund='Y',ret_dt='" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "',penalty=" & Val(fine) & " WHERE iss_sl= " & Val(iss_sl) & " ")
                SQLInsert("UPDATE book2 SET book_pos='I',prd_tp='" & vb.Left(cond, 1) & "' WHERE scroll_cd=" & scrollcd & "")

                Dim ds As DataSet = get_dataset("SELECT iss_stk,cl_stk FROM book1 WHERE book_cd=" & Val(book_cd) & " ")
                issstk = ds.Tables(0).Rows(0).Item(0)
                clstk = ds.Tables(0).Rows(0).Item(1)

                totiss = issstk - 1
                totcl = clstk + 1
                SQLInsert("UPDATE book1 SET iss_stk=" & totiss & ",cl_stk=" & totcl & " WHERE book_cd=" & Val(book_cd) & "")

                MessageBox.Show("Book Returned Successfully.", "Informatiom", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Close1()
            If cmbtrtype.SelectedIndex = 0 Then
                Me.dv_view(txtstucd.Text)
            Else
                Me.dv_view(txtstafcd.Text)
            End If

        End If
    End Sub

    Private Sub txtroll_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtroll.Validating

        If cmbtrtype.SelectedIndex = 0 Then
            vdating(txtroll, "SELECT reg_no FROM stud WHERE (reg_no ='" & Trim(txtroll.Text) & "') AND rec_lock='N'", "Please Enter A Valid Regd. No.")

        Else
            vdating(txtroll, "SELECT staf_id FROM staf WHERE (staf_id = '" & Trim(txtroll.Text) & "')", "Please Enter A Valid Employee No.")
        End If

    End Sub

End Class
