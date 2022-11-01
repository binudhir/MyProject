Imports vb = Microsoft.VisualBasic
Public Class frmbkissue
    Dim comd As String = "E"

    Private Sub frmbkissue_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnubkiss.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmbkissue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmbkissue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnubkiss.Enabled = False
        Me.clr()
        cmbtrtype.SelectedIndex = 0
    End Sub

    Private Sub clr()
        txtcd.Text = "0"

        txtroll.Text = ""
        txtnm.Text = ""
        dttr.Text = sys_date
        txtsession.Text = ""
        txttrade.Text = ""
        txtsem.Text = ""
        txtscroll.Text = ""
        dtissue.Text = sys_date
        txtsl.Text = "1"
        txttotalissue.Text = "0"
        txttotqty.Text = "0"
        txttotval.Text = "0.00"
        dv1.Rows.Clear()
        dv.Rows.Clear()
        txtroll.Focus()
        Me.clr1()

        Dim ds As DataSet = get_dataset("SELECT max(iss_no) as 'Max' FROM bk_iss1")
        txtscroll.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
    End Sub

    Private Sub clr1()
        txtbookcd.Text = ""
        txtbooknm.Text = ""
        txtpub.Text = ""
        If cmbtrtype.SelectedIndex = 0 Then
            dtapprt.Text = dtissue.Value.AddDays(stud_bkday)
        Else
            dtapprt.Text = dtissue.Value.AddDays(stud_bkday)
        End If
        txtmrp.Text = ""
        txtqty.Text = "1"
        txtremark.Text = ""
        lblcurrstk.Text = "0"
        lbltotstk.Text = "0"
        txtdetailnm.Text = ""
        txtisbn.Text = ""
        txtedition.Text = ""
        txtauth.Text = ""
        txtothauth.Text = ""
    End Sub

#Region "Enter/Leave"
    Private Sub sender_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrtype.Enter, txtroll.Enter, dttr.Enter, dtissue.Enter, txtbookcd.Enter, dtapprt.Enter, txtremark.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
        sender.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Bold)
    End Sub

    Private Sub sender_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrtype.Leave, txtroll.Leave, dttr.Leave, dtissue.Leave, txtbookcd.Leave, dtapprt.Leave, txtremark.Leave
        sender.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Regular)
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnxt.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter, btnsave.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnxt.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave, btnsave.MouseLeave
        sender.forecolor = Color.Red
    End Sub


#End Region

#Region "Key Press"
    Private Sub txtroll_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtroll.KeyPress
        key(txtbookcd, e)
        SPKey(e)
    End Sub

    Private Sub txtbookcd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbookcd.KeyPress
        key(dtapprt, e)
        SPKey(e)
    End Sub

    Private Sub dtapprt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtapprt.KeyPress
        key(btnnxt, e)
    End Sub

    Private Sub txtremark_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtremark.KeyPress
        key(btnsave, e)
    End Sub
#End Region

#Region "Combo Box"
    Private Sub cmbtrtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrtype.SelectedIndexChanged
        If Val(cmbtrtype.SelectedIndex) = 0 Then
            lblroll.Text = "Regd No.:"
            lblsession.Text = "Session :"
            lbltrade.Text = "Trade :"
            lblsem.Visible = True
            txtsem.Visible = True
            txtroll.Text = ""
        Else
            lblroll.Text = "Emp No.:"
            lblsession.Text = "Desg.:"
            lbltrade.Text = "Dept.:"
            lblsem.Visible = False
            txtsem.Visible = False
            txtroll.Text = ""
        End If
    End Sub

#End Region

#Region "Validate / Validating"

    Private Sub txtbookcd_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbookcd.Validated
        If txtbookcd.Text = "" Then
            clr1()
            txtremark.Focus()
        Else
            Dim ds As DataSet = get_dataset("SELECT book2.mrp,book2.edition,book2.scroll_cd,book2.book_qty,book1.op_stk,book1.rec_stk,book1.iss_stk,book1.cl_stk,book1.book_cd,book1.book_nm,book1.book_dnm,book1.isbn_no,pubc.pub_nm, author.auth_nm, book1.oth_auth,book2.book_rej,book2.book_pos FROM author RIGHT OUTER JOIN book1 ON author.auth_cd = book1.auth_cd LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd RIGHT OUTER JOIN book2 ON book1.book_cd = book2.book_cd WHERE(book2.scroll_nm = '" & Trim(txtbookcd.Text) & "') AND (book1.rec_lock = 'N')")
            rej = ""
            pos = ""
            If ds.Tables(0).Rows.Count <> 0 Then
                rej = Trim(ds.Tables(0).Rows(0).Item("book_rej"))
                pos = Trim(ds.Tables(0).Rows(0).Item("book_pos"))
                If rej = "Y" Then
                    MessageBox.Show("The Book Code You Entered Is Already Rejected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    clr1()
                    txtbookcd.Focus()
                    Exit Sub
                End If
                If pos = "O" Then
                    MessageBox.Show("The Book Code You Entered Is Already Issued.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    clr1()
                    txtbookcd.Focus()
                    Exit Sub
                End If

                txtbooknm.Text = Trim(ds.Tables(0).Rows(0).Item("book_nm"))
                txtpub.Text = Trim(ds.Tables(0).Rows(0).Item("pub_nm"))
                txtmrp.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
                txttotqty.Text = Format(ds.Tables(0).Rows(0).Item("book_qty"))
                txtdetailnm.Text = Trim(ds.Tables(0).Rows(0).Item("book_dnm"))
                txtedition.Text = Trim(ds.Tables(0).Rows(0).Item("edition"))
                txtauth.Text = Trim(ds.Tables(0).Rows(0).Item("auth_nm"))
                txtothauth.Text = Trim(ds.Tables(0).Rows(0).Item("oth_auth"))
                txtisbn.Text = Trim(ds.Tables(0).Rows(0).Item("isbn_no"))
                lblcurrstk.Text = Format(ds.Tables(0).Rows(0).Item("cl_stk"))
                lbltotstk.Text = Val(ds.Tables(0).Rows(0).Item("op_stk")) + Val(ds.Tables(0).Rows(0).Item("rec_stk"))
                txtbook.Text = Format(ds.Tables(0).Rows(0).Item("book_cd"))
                txtscrlcd.Text = Format(ds.Tables(0).Rows(0).Item("scroll_cd"))
                Dim ds1 As DataSet = get_dataset("SELECT COUNT(book2.book_pos) AS totin_bk FROM book2 LEFT OUTER JOIN book1 ON book2.book_cd = book1.book_cd WHERE (book2.book_rej= 'N') AND (book2.book_pos = 'I') AND (book1.rec_lock='N') AND book2.book_cd='" & Trim(txtbook.Text) & "'")
                If ds1.Tables(0).Rows.Count <> 0 Then
                    lblcurrstk.Text = Format(ds1.Tables(0).Rows(0).Item("totin_bk"))
                End If
                Dim ds2 As DataSet = get_dataset("SELECT COUNT(book2.book_pos) AS tot_bk FROM book2 LEFT OUTER JOIN book1 ON book2.book_cd = book1.book_cd WHERE ( book2.book_rej= 'N') AND (book1.rec_lock='N')AND book2.book_cd='" & Trim(txtbook.Text) & "'")
                If ds2.Tables(0).Rows.Count <> 0 Then
                    lbltotstk.Text = Format(ds2.Tables(0).Rows(0).Item("tot_bk"))
                End If
            Else
                MessageBox.Show("The Book Code You Entered Is Locked.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clr1()
                txtbookcd.Focus()
            End If
        End If
    End Sub

    Private Sub txtbookcd_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbookcd.Validating
        vdating(txtbookcd, "SELECT book2.scroll_nm FROM book2 LEFT OUTER JOIN book1 ON book2.book_cd = book1.book_cd WHERE (book2.scroll_nm = '" & Trim(txtbookcd.Text) & "')", "Sorry This Book Is Not Available. Please Enter A Valid Book Code.")
    End Sub

    Private Sub txtroll_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtroll.Validating

        If cmbtrtype.SelectedIndex = 0 Then
            vdating(txtroll, "SELECT reg_no FROM stud WHERE (reg_no ='" & Trim(txtroll.Text) & "') AND rec_lock='N'", "Please Enter A Valid Regd. No.")

        Else
            vdating(txtroll, "SELECT staf_id FROM staf WHERE (staf_id = '" & Trim(txtroll.Text) & "')", "Please Enter A Valid Employee No.")
        End If

    End Sub

    Private Sub txtroll_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtroll.Validated
        If cmbtrtype.SelectedIndex = 0 Then
            Dim ds As DataSet = get_dataset("SELECT stud_hstry.stud_sl, sesion1.sesn_nm, semester.sem_nm, trad.trad_nm, stud.stud_nm FROM stud_hstry LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd WHERE (stud_hstry.reg_no= '" & Trim(txtroll.Text) & "' AND  stud_hstry.active='Y')")
            If ds.Tables(0).Rows.Count <> 0 Then
                txtnm.Text = ds.Tables(0).Rows(0).Item("stud_nm")
                txtsession.Text = Trim(ds.Tables(0).Rows(0).Item("sesn_nm"))
                txttrade.Text = Trim(ds.Tables(0).Rows(0).Item("trad_nm"))
                txtsem.Text = Format(ds.Tables(0).Rows(0).Item("sem_nm"))
                txtcd.Text = Format(ds.Tables(0).Rows(0).Item("stud_sl"))
                Me.dv_view(txtcd.Text)
            
            End If
        Else
            Dim ds As DataSet = get_dataset("SELECT staf.staf_nm , desg.desg_nm, dept.dept_nm, staf.staf_sl FROM staf LEFT OUTER JOIN dept ON staf.dept_cd = dept.dept_cd LEFT OUTER JOIN desg ON staf.desg_cd = desg.desg_cd WHERE (staf.staf_id = '" & Trim(txtroll.Text) & "')")
            If ds.Tables(0).Rows.Count <> 0 Then
                txtnm.Text = ds.Tables(0).Rows(0).Item("staf_nm")
                txtsession.Text = Trim(ds.Tables(0).Rows(0).Item("desg_nm"))
                txttrade.Text = Trim(ds.Tables(0).Rows(0).Item("dept_nm"))
                txtcd.Text = Format(ds.Tables(0).Rows(0).Item("staf_sl"))
                Me.dv_view(txtcd.Text)
           
            End If
        End If
        Me.clr1()
    End Sub

#End Region

#Region "Button"
    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        If Trim(txtroll.Text) = "" Then
            MessageBox.Show("Sorry The Roll No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtroll.Focus()
            Exit Sub
        End If

        If cmbtrtype.SelectedIndex = 0 Then
            If Val(txttotalissue.Text) + Val(txttotqty.Text) > Val(studbk) Then
                MessageBox.Show("Sorry, Can't Issue More Than " & Val(studbk) & " Books To This Student.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtbookcd.Focus()
                Exit Sub
            End If
        Else
            If Val(txttotalissue.Text) + Val(txttotqty.Text) > Val(stafbk) Then
                MessageBox.Show("Sorry, Can't Issue More Than " & Val(stafbk) & " Books To This Staff.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtbookcd.Focus()
                Exit Sub
            End If

        End If
        Me.order_save()
    End Sub

    Private Sub btnnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.Click
        If txtroll.Text = "" Then
            MessageBox.Show("Please Provide A Roll No. / Employee No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtroll.Focus()
            Exit Sub
        End If
        If Trim(txtbookcd.Text) = "" Then
            MessageBox.Show("Please Provide A Book Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clr1()
            Exit Sub
        End If
        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                x = dv1.Rows(i).Cells(1).Value
                If Val(txtbookcd.Text) = x Then
                    MessageBox.Show("Sorry This Book Is Not Available For Issue.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    clr1()
                    Exit Sub
                End If
            Next
        End If


        sl1 = Val(txtsl.Text)
        dv1.Rows.Add()
        dv1.Rows(sl1 - 1).Cells(0).Value = sl1
        dv1.Rows(sl1 - 1).Cells(1).Value = txtbookcd.Text
        dv1.Rows(sl1 - 1).Cells(2).Value = txtbooknm.Text
        dv1.Rows(sl1 - 1).Cells(3).Value = txtpub.Text
        dv1.Rows(sl1 - 1).Cells(4).Value = Format(dtapprt.Value, "dd/MMM/yyyy HH:mm:ss")
        dv1.Rows(sl1 - 1).Cells(5).Value = txtmrp.Text
        dv1.Rows(sl1 - 1).Cells(6).Value = txtqty.Text
        dv1.Rows(sl1 - 1).Cells(7).Value = txtscrlcd.Text
        dv1.Rows(sl1 - 1).Cells(8).Value = txtbook.Text
        sl1 += 1
        txtsl.Text = sl1

        Me.grandamt(dv1)
        Me.totqty(dv1)
        txtbookcd.Focus()
        Me.clr1()
    End Sub
#End Region

    Private Sub txtbookcd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbookcd.GotFocus
        clr1()
    End Sub

    Private Sub totqty(ByVal dgv As DataGridView)
        tqty = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            qty = dgv.Rows(i).Cells(6).Value
            tqty = tqty + Val(qty)
        Next
        txttotqty.Text = Format(tqty, "#######0")

    End Sub

    Private Sub grandamt(ByVal dgv As DataGridView)

        gtamt = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            amt = dgv.Rows(i).Cells(5).Value
            gtamt = gtamt + Val(amt)
        Next
        txttotval.Text = Format(gtamt, "#######0.00")

    End Sub

    Private Sub order_save()

        staf_sl = 0
        stud_sl = 0
        If cmbtrtype.SelectedIndex = 0 Then
            stud_sl = Val(txtcd.Text)
        Else
            staf_sl = Val(txtcd.Text)
        End If

        cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Start1()
        If cnfr = vbYes Then
            Dim ds As DataSet = get_dataset("SELECT max(iss_no) as 'Max' FROM bk_iss1")
            txtscroll.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            SQLInsert("INSERT INTO bk_iss1 (iss_no,iss_tp,iss_dt,stud_sl,staf_sl,ret_dt,tot_qty,tot_val,nb,usr_ent,ent_date,usr_mod,mod_date,usedby,rec_lock) VALUES (" & _
                      Val(txtscroll.Text) & " , '" & vb.Left(cmbtrtype.Text, 1) & "','" & Format(dtissue.Value, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(stud_sl) & "," & Val(staf_sl) & _
                      ",'" & Format(dttr.Value, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(txttotqty.Text) & "," & Val(txttotval.Text) & ",'" & Trim(txtremark.Text) & "'," & Val(usr_sl) & _
                      ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N','N')")

            Me.dv_save()
            MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'cnfr = MessageBox.Show("Are You Sure The Printer is Ready To Print The Bill.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            'If cnfr = vbYes Then
            '    Call colrec_print(Val(txtordno.Text))
            'End If
            Me.clr()
            Close1()
            txtroll.Focus()
        End If
    End Sub

    Private Sub dv_save()
        If dv1.RowCount <> 0 Then
            staf_sl = 0
            stud_sl = 0
            If cmbtrtype.SelectedIndex = 0 Then
                stud_sl = Val(txtcd.Text)
            Else
                staf_sl = Val(txtcd.Text)
            End If

            'SQLInsert("DELETE FROM iss2 WHERE iss_no=" & Val(txtscroll.Text) & "")
            For i As Integer = 0 To dv1.RowCount - 1

                appdt = dv1.Rows(i).Cells(4).Value
                mrp = Val(dv1.Rows(i).Cells(5).Value)
                qty = Val(dv1.Rows(i).Cells(6).Value)
                scrollcd = Val(dv1.Rows(i).Cells(7).Value)
                bookcd = Val(dv1.Rows(i).Cells(8).Value)

                Dim ds1 As DataSet = get_dataset("SELECT max(iss_sl) as 'Max' FROM bk_iss2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO bk_iss2(iss_sl,iss_no,iss_tp,iss_dt,stud_sl,staf_sl,ret_dt,apret_dt,book_cd,scroll_cd,mrp,qty,penalty,refund) VALUES (" & _
                          Val(mxno) & "," & Val(txtscroll.Text) & ",'" & vb.Left(cmbtrtype.Text, 1) & "','" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & _
                          "'," & stud_sl & "," & staf_sl & ",'" & Format(dtissue.Value, "dd/MMM/yyyy HH:mm:ss") & "','" & appdt & "'," & bookcd & _
                          "," & scrollcd & "," & mrp & "," & qty & ",0,'N')")
                SQLInsert("UPDATE book2 SET book_pos='O' WHERE scroll_cd=" & scrollcd & "")

                Dim ds2 As DataSet = get_dataset("SELECT iss_stk,cl_stk FROM book1 WHERE book_cd=" & bookcd & " ")
                issstk = ds2.Tables(0).Rows(0).Item(0)
                clstk = ds2.Tables(0).Rows(0).Item(1)

                totiss = issstk + 1
                totcl = clstk - 1
                SQLInsert("UPDATE book1 SET iss_stk=" & totiss & ",cl_stk=" & totcl & " WHERE book_cd=" & bookcd & "")

            Next
        End If
    End Sub

    Private Sub dv_view(ByVal slno As Integer)
        Dim ds As DataSet
        If cmbtrtype.SelectedIndex = 0 Then
            ds = get_dataset("SELECT bk_iss2.iss_dt, bk_iss2.apret_dt, bk_iss2.mrp, bk_iss2.penalty, book2.scroll_nm, book1.book_nm, pubc.pub_nm, bk_iss2.iss_no, bk_iss2.scroll_cd, bk_iss2.iss_sl FROM pubc RIGHT OUTER JOIN book1 ON pubc.pub_cd = book1.pub_cd RIGHT OUTER JOIN bk_iss2 ON book1.book_cd = bk_iss2.book_cd LEFT OUTER JOIN book2 ON bk_iss2.scroll_cd = book2.scroll_cd WHERE (bk_iss2.stud_sl=" & slno & " AND bk_iss2.refund='N')")
        Else
            ds = get_dataset("SELECT bk_iss2.iss_dt, bk_iss2.apret_dt, bk_iss2.mrp, bk_iss2.penalty, book2.scroll_nm, book1.book_nm, pubc.pub_nm, bk_iss2.iss_no, bk_iss2.scroll_cd, bk_iss2.iss_sl FROM pubc RIGHT OUTER JOIN book1 ON pubc.pub_cd = book1.pub_cd RIGHT OUTER JOIN bk_iss2 ON book1.book_cd = bk_iss2.book_cd LEFT OUTER JOIN book2 ON bk_iss2.scroll_cd = book2.scroll_cd WHERE (bk_iss2.staf_sl=" & slno & " AND bk_iss2.refund='N')")
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
                dv.Rows(rw).Cells(12).Value = "Refund"
                rw = rw + 1
            Next
            txttotalissue.Text = rw
        Else
            txttotalissue.Text = "0"
        End If
    End Sub

    Private Sub dv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dv.CellClick
        If e.ColumnIndex = 12 Then
            ' MsgBox(("Row : " + e.RowIndex.ToString & "  Col : ") + e.ColumnIndex.ToString)
            rw = e.RowIndex.ToString
            iss_sl = dv.Rows(rw).Cells(11).Value
            scrollcd = dv.Rows(rw).Cells(9).Value
            fine = dv.Rows(rw).Cells(8).Value
            cond = dv.Rows(rw).Cells(7).Value
            bknm = dv.Rows(rw).Cells(2).Value
            bk_cd = dv.Rows(rw).Cells(1).Value
            If cond = "" Then
                cond = "1"
            End If
            cnfr = MessageBox.Show("Are You Sure To Return The Book" & vbCrLf & " " & vbCrLf & " [" & bknm & "] " & vbCrLf & "" & vbCrLf & " Having The Book Code [" & bk_cd & "] ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                SQLInsert("UPDATE bk_iss2 SET refund='Y',ret_dt='" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "',penalty=" & Val(fine) & " WHERE iss_sl= " & Val(iss_sl) & " ")
                SQLInsert("UPDATE book2 SET book_pos='I',prd_tp='" & vb.Left(cond, 1) & "' WHERE scroll_cd=" & scrollcd & "")

                Dim ds As DataSet = get_dataset("SELECT iss_stk,cl_stk FROM book1 WHERE book_cd=" & bk_cd & " ")
                issstk = ds.Tables(0).Rows(0).Item(0)
                clstk = ds.Tables(0).Rows(0).Item(1)

                totiss = issstk - 1
                totcl = clstk + 1
                SQLInsert("UPDATE book1 SET iss_stk=" & totiss & ",cl_stk=" & totcl & " WHERE book_cd=" & bk_cd & "")

                MessageBox.Show("Book Returned Successfully.", "Informatiom", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Close1()
            If cmbtrtype.SelectedIndex = 0 Then
                Me.dv_view(txtcd.Text)
            Else
                Me.dv_view(txtcd.Text)
            End If

        End If
    End Sub

    Private Sub cmnudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnudel.Click
        If dv1.RowCount <> 0 Then

            For Each row As DataGridViewRow In dv1.SelectedRows
                dv1.Rows.Remove(row)
            Next
            sl = 1
            For i As Integer = 0 To dv1.Rows.Count - 1
                dv1.Rows(i).Cells(0).Value = i + 1
                sl += 1
            Next
            txtsl.Text = sl
            Me.grandamt(dv1)
            Me.totqty(dv1)
            txtbookcd.Focus()
        Else
            MessageBox.Show("Sorry There Is No Book To Delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
       

    End Sub

    Private Sub mnuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexpert.Click
        Call excel_view(dv)
    End Sub
End Class
