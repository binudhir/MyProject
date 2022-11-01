Imports vb = Microsoft.VisualBasic
Public Class frmbkrejection
    Dim comd As String = "V"

    Private Sub frmbkrejection_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnubkrej.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmbkrejection_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmbkrejection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnubkrej.Enabled = False
        usrprmsn("mnubkrej", cmnuadd, cmnu1del, cmnuedit, cmenuview)
        comd = swapprmsn("mnubkrej", comd)
        Me.clr()
    End Sub

    Private Sub clr()
        txtsl.Text = "1"
        txtrejscrl.Text = ""
        txtstafsl.Text = ""
        txtremark.Text = ""
        txttotqty.Text = "0"
        txttotmrp.Text = "0.00"
        txttotpur.Text = "0.00"
        cmbreject.Text = ""
        txtbknmcd.Text = ""
        txtscrlcd.Text = ""
        dtrej.Value = sys_date
        dv1.Rows.Clear()
        If comd = "E" Then
            Me.Text = "Book Rejection Entry Screen...."
            Dim ds As DataSet = get_dataset("SELECT max(rej_no) as 'Max' FROM bk_rej1")
            txtrejscrl.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtrejscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            btnsave.Text = "Save"
        ElseIf comd = "M" Then
            Me.Text = "Book Rejection Modification Screen...."
            txtrejscrl.Text = ""
            btnsave.Text = "Modify"
        ElseIf comd = "D" Then
            Me.Text = "Book Rejection Deletion Screen...."
            txtrejscrl.Text = ""
            btnsave.Text = "Delete"
        Else
            Me.Text = "Book Rejection View Screen...."
            txtrejscrl.Text = ""
            btnsave.Text = "View"
        End If
        Me.clr1()
    End Sub

    Private Sub clr1()
        txtbookcd.Text = ""
        txtbooknm.Text = ""
        txtpub.Text = ""
        txtdetailnm.Text = ""
        txtauth.Text = ""
        txtothauth.Text = ""
        txtedition.Text = ""
        txtisbn.Text = ""
        txtqty.Text = "1"
        txtpurrt.Text = ""
        txtmrp.Text = ""
    End Sub
#Region "Enter/Leave"
    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrejscrl.Enter, txtstafsl.Enter, txtremark.Enter, txttotqty.Enter, txttotmrp.Enter, txttotpur.Enter, cmbreject.Enter, txtbknmcd.Enter, txtscrlcd.Enter, dtrej.Enter, txtsl.Enter, txtbookcd.Enter, txtbooknm.Enter, txtpub.Enter, txtdetailnm.Enter, txtauth.Enter, txtothauth.Enter, txtedition.Enter, txtisbn.Enter, txtqty.Enter, txtpurrt.Enter, txtmrp.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub txtrejscrl_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrejscrl.Leave, txtstafsl.Leave, txtremark.Leave, txttotqty.Leave, txttotmrp.Leave, txttotpur.Leave, cmbreject.Leave, txtbknmcd.Leave, txtscrlcd.Leave, dtrej.Leave, txtsl.Leave, txtbookcd.Leave, txtbooknm.Leave, txtpub.Leave, txtdetailnm.Leave, txtauth.Leave, txtothauth.Leave, txtedition.Leave, txtisbn.Leave, txtqty.Leave, txtpurrt.Leave, txtmrp.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnnxt_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnset.MouseEnter, btnsave.MouseEnter, btnref.MouseEnter, btnprint.MouseEnter, btninter.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnnxt_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnset.MouseLeave, btnsave.MouseLeave, btnref.MouseLeave, btnprint.MouseLeave, btninter.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "KeyPress"
    Private Sub txtrejscrl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrejscrl.KeyPress
        key(cmbreject, e)
        NUM1(e)
    End Sub

    Private Sub cmbreject_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbreject.KeyPress
        key(dtrej, e)
        SPKey(e)
    End Sub

    Private Sub datedt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtrej.KeyPress
        key(txtbookcd, e)
    End Sub

    Private Sub txtbookcd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbookcd.KeyPress
        key(btnnxt, e)
        NUM1(e)
    End Sub

    Private Sub txtremark_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtremark.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub
#End Region

#Region "GotFocus/LostFocus"

    Private Sub cmbreject_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbreject.GotFocus
        populate(cmbreject, "SELECT staf_nm FROM staf WHERE rec_lock = 'N' ORDER BY staf_nm")
        cmbreject.Height = 100
    End Sub

    Private Sub cmbreject_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbreject.LostFocus
        cmbreject.Height = 21
    End Sub

#End Region

#Region "Validated/Validating"

    Private Sub txtrejscrl_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrejscrl.Validated
        If comd <> "E" Then
            If txtrejscrl.Text <> "" Then
                Dim ds As DataSet = get_dataset("SELECT rej_no FROM bk_rej1 WHERE rej_no=" & Val(txtrejscrl.Text) & " ")
                If ds.Tables(0).Rows.Count <> 0 Then
                    Me.dv_edit(txtrejscrl.Text)
                Else
                    MessageBox.Show("Please Select a Valid Rejection Scroll No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtrejscrl.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmbreject_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbreject.Validated
        vdated(txtstafsl, "SELECT staf_sl FROM staf WHERE (staf_nm = '" & Trim(cmbreject.Text) & "')")
    End Sub

    Private Sub cmbreject_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbreject.Validating
        vdating(cmbreject, "SELECT staf_nm FROM staf WHERE (staf_nm = '" & Trim(cmbreject.Text) & "')", "Please Select A Valid Staf Name.")
    End Sub

    Private Sub txtbookcd_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbookcd.Validating
        vdating(txtbookcd, "SELECT book2.scroll_nm FROM book2 LEFT OUTER JOIN book1 ON book2.book_cd = book1.book_cd WHERE (book2.scroll_nm = '" & Trim(txtbookcd.Text) & "')", "Sorry This Book Is Not Available. Please Enter A Valid Book Code.")
    End Sub

    Private Sub txtbookcd_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbookcd.Validated
        If txtbookcd.Text = "" Then
            txtremark.Focus()
            Exit Sub
        End If
        Dim ds As DataSet = get_dataset("SELECT book2.scroll_cd, book2.book_cd,book2.book_pos,book2.book_rej, book1.book_nm, book2.mrp, pubc.pub_nm, author.auth_nm, book1.oth_auth, book1.book_dnm, book2.edition, book1.isbn_no FROM author RIGHT OUTER JOIN book1 ON author.auth_cd = book1.auth_cd LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd RIGHT OUTER JOIN book2 ON book1.book_cd = book2.book_cd WHERE (book2.scroll_nm ='" & Trim(txtbookcd.Text) & "')")
        pos = ""
        rej = ""
        If ds.Tables(0).Rows.Count <> 0 Then
            pos = Trim(ds.Tables(0).Rows(0).Item("book_pos"))
            rej = Trim(ds.Tables(0).Rows(0).Item("book_rej"))
            If pos = "O" Then
                MessageBox.Show("Sorry You Can Not Reject This Book." & vbCrLf & " This Book Is Issued To A Staff/Student.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clr1()
                txtbookcd.Focus()
                Exit Sub
            End If
            If rej = "Y" Then
                MessageBox.Show("This Book Is Already Rejected." & vbCrLf & " Please Enter A different Book Code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clr1()
                txtbookcd.Focus()
                Exit Sub
            End If
            txtscrlcd.Text = ds.Tables(0).Rows(0).Item("scroll_cd")
            txtbooknm.Text = Trim(ds.Tables(0).Rows(0).Item("book_nm"))
            txtbknmcd.Text = ds.Tables(0).Rows(0).Item("book_cd")
            txtpub.Text = Trim(ds.Tables(0).Rows(0).Item("pub_nm"))
            txtpurrt.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            txtmrp.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            txtdetailnm.Text = Trim(ds.Tables(0).Rows(0).Item("book_dnm"))
            txtedition.Text = Trim(ds.Tables(0).Rows(0).Item("edition"))
            txtauth.Text = Trim(ds.Tables(0).Rows(0).Item("auth_nm"))
            txtothauth.Text = Trim(ds.Tables(0).Rows(0).Item("oth_auth"))
            txtisbn.Text = Trim(ds.Tables(0).Rows(0).Item("isbn_no"))
        End If
    End Sub
#End Region

#Region "Total"
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
        txttotmrp.Text = Format(gtamt, "#######0.00")
        txttotpur.Text = Format(gtamt, "#######0.00")
    End Sub
#End Region

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Me.dv_disp()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
        txtrejscrl.Focus()
    End Sub

    Private Sub btninter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninter.Click
        comd = swapprmsn("mnubkrej", comd)
        'If comd = "E" Then
        '    comd = "M"
        'ElseIf comd = "M" Then
        '    comd = "D"
        'Else
        '    comd = "E"
        'End If
        Me.clr()
    End Sub

    Private Sub btnset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnset.Click

    End Sub

    Private Sub btnnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.Click
       
        If Trim(cmbreject.Text) = "" Then
            MessageBox.Show("Please Select A Staff Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbreject.Focus()
            Exit Sub
        End If
        If Trim(txtbookcd.Text) = "" Then
            MessageBox.Show("Please Enter A Book Vode To Reject.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtbookcd.Focus()
            Exit Sub
        End If

        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                x = dv1.Rows(i).Cells(1).Value
                If Val(txtbookcd.Text) = x Then
                    MessageBox.Show("Sorry The Data Should Not Be Duplicate." & vbCrLf & " Please Select A Different Book Code To Reject.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    clr1()
                    txtbookcd.Focus()
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
        dv1.Rows(sl1 - 1).Cells(4).Value = txtpurrt.Text
        dv1.Rows(sl1 - 1).Cells(5).Value = txtmrp.Text
        dv1.Rows(sl1 - 1).Cells(6).Value = txtqty.Text
        dv1.Rows(sl1 - 1).Cells(7).Value = txtscrlcd.Text
        dv1.Rows(sl1 - 1).Cells(8).Value = txtbknmcd.Text
        sl1 += 1
        txtsl.Text = sl1

        Me.grandamt(dv1)
        Me.totqty(dv1)
        txtbookcd.Focus()
        Me.clr1()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Val(txtrejscrl.Text) = 0 Then
            MessageBox.Show("Sorry The Scroll No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtrejscrl.Focus()
            Exit Sub
        End If
        If Trim(cmbreject.Text) = "" Or Val(txtstafsl.Text) = 0 Then
            MessageBox.Show("Sorry The Staff Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbreject.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count = 0 Then
            MessageBox.Show("Please Reject At Least One Item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtbookcd.Focus()
            Exit Sub
        End If
        
        Me.rej_save()
       
    End Sub
#End Region

    Private Sub rej_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(rej_no) as 'Max' FROM bk_rej1")
                txtrejscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtrejscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
              
                SQLInsert("INSERT INTO bk_rej1 (rej_no,rej_dt,staf_sl,tot_qty,tot_mrp,tot_cost,nb,usr_ent,ent_date,usr_mod,mod_date,usedby,rec_lock)" & _
                          "VALUES (" & Val(txtrejscrl.Text) & ",'" & Format(dtrej.Value, "dd/MMM/yyyy") & "'," & _
                          Val(txtstafsl.Text) & "," & Val(txttotqty.Text) & "," & Val(txttotmrp.Text) & "," & Val(txttotpur.Text) & _
                          ",'" & Trim(txtremark.Text) & "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & _
                          "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N','N')")
                Me.dv_save()
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'cnfr = MessageBox.Show("Are You Sure The Printer is Ready To Print The Bill.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If cnfr = vbYes Then
                '    Call colrec_print(Val(txtscrlno.Text))
                'End If
                Me.clr()
                Close1()
            End If

        ElseIf comd = "M" Then
            'If usr_tp = "O" Then
            '    MessageBox.Show("You Are Not Authorised to Modify The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT rej_no FROM bk_rej1 WHERE rej_no=" & Val(txtrejscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE bk_rej1 SET rej_dt='" & Format(dtrej.Value, "dd/MMM/yyyy") & "',staf_sl=" & _
                               Val(txtstafsl.Text) & ",tot_qty=" & Val(txttotqty.Text) & ",tot_mrp=" & Val(txttotmrp.Text) & _
                               ",tot_cost=" & Val(txttotpur.Text) & ",nb='" & Trim(txtremark.Text) & "',usr_mod=" & Val(usr_sl) & ",mod_date='" & _
                              Format(Now, "dd/MMM/yyyy HH:mm:ss") & "',usr_ent=" & Val(usr_sl) & ",ent_date= '" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & _
                              "' WHERE rej_no =" & Val(txtrejscrl.Text) & "")
                    Me.dv_save()
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                    txtrejscrl.Focus()
                End If
                Close1()
            End If
        ElseIf comd = "D" Then
            'If usr_tp <> "A" And usr_tp <> "D" Then
            '    MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Call del1(txtrejscrl.Text)
                Call del2(txtrejscrl.Text)
                MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtrejscrl.Focus()
                clr()
            End If
            Close1()
        End If
    End Sub

    'Delete data from Table1/Primary Table
    Private Sub del1(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT rej_no FROM bk_rej1 WHERE rej_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            SQLInsert("DELETE FROM bk_rej1 WHERE rej_no=" & Val(code) & "")
        End If
    End Sub

    'Delete data from Table2/Secondary Table
    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT rej_sl,scroll_cd,book_cd FROM bk_rej2 WHERE rej_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                rejsl = dsdel.Tables(0).Rows(i).Item(0)
                scrlsl = dsdel.Tables(0).Rows(i).Item(1)
                bookcd = dsdel.Tables(0).Rows(i).Item(2)
                SQLInsert("UPDATE book2 SET book_rej='N' WHERE scroll_cd=" & Val(scrlsl) & "")
                SQLInsert("DELETE FROM bk_rej2 WHERE rej_sl=" & Val(rejsl) & "")

                Dim ds As DataSet = get_dataset("SELECT op_stk,rec_stk,iss_stk,cl_stk FROM book1 WHERE book_cd=" & bookcd & " ")
                opstk = ds.Tables(0).Rows(0).Item(0)
                recstk = ds.Tables(0).Rows(0).Item(1)
                issstk = ds.Tables(0).Rows(0).Item(2)
                clstk = ds.Tables(0).Rows(0).Item(3)

                Dim ds2 As DataSet = get_dataset("SELECT book_frm FROM book2 WHERE scroll_cd=" & Val(scrlsl) & " ")
                If ds2.Tables(0).Rows(0).Item(0) = "P" Then
                    totrec = recstk + 1
                    totcl = clstk + 1
                    SQLInsert("UPDATE book1 SET rec_stk=" & Val(totrec) & ", cl_stk=" & Val(totcl) & " WHERE book_cd=" & bookcd & "")
                ElseIf ds2.Tables(0).Rows(0).Item(0) = "O" Then
                    totop = opstk + 1
                    totcl = clstk + 1
                    SQLInsert("UPDATE book1 SET op_stk=" & Val(totop) & ", cl_stk=" & Val(totcl) & " WHERE book_cd=" & bookcd & "")
                End If
            Next
        End If
    End Sub

#Region "Dv"

    Private Sub dv_save()
        If dv1.RowCount <> 0 Then
            If comd = "M" Then
                Call del2(txtrejscrl.Text)
            End If

            For i As Integer = 0 To dv1.RowCount - 1
                bookcd = Val(dv1.Rows(i).Cells(8).Value)
                scrl = Val(dv1.Rows(i).Cells(7).Value)
                cost = Val(dv1.Rows(i).Cells(4).Value)
                mrp = Val(dv1.Rows(i).Cells(5).Value)

                Dim ds1 As DataSet = get_dataset("SELECT max(rej_sl) as 'Max' FROM bk_rej2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO bk_rej2(rej_sl,rej_no,rej_dt,staf_sl,book_cd,scroll_cd,bk_qty,bk_unt,bk_cost,bk_mrp) VALUES (" & _
                          Val(mxno) & "," & Val(txtrejscrl.Text) & ",'" & Format(dtrej.Value, "dd/MMM/yyyy") & "'," & _
                           Val(txtstafsl.Text) & "," & bookcd & "," & scrl & ",1,'pcs'," & cost & "," & mrp & ")")
                SQLInsert("UPDATE book2 SET book_rej='Y',rej_by=" & Val(txtstafsl.Text) & " WHERE scroll_cd=" & Val(scrl) & "")

                Dim ds As DataSet = get_dataset("SELECT op_stk,rec_stk,iss_stk,cl_stk FROM book1 WHERE book_cd=" & bookcd & " ")
                opstk = ds.Tables(0).Rows(0).Item(0)
                recstk = ds.Tables(0).Rows(0).Item(1)
                issstk = ds.Tables(0).Rows(0).Item(2)
                clstk = ds.Tables(0).Rows(0).Item(3)

                Dim ds2 As DataSet = get_dataset("SELECT book_frm FROM book2 WHERE scroll_cd=" & Val(scrl) & " ")
                If ds2.Tables(0).Rows(0).Item(0) = "P" Then
                    totrec = recstk - 1
                    totcl = clstk - 1
                    SQLInsert("UPDATE book1 SET rec_stk=" & Val(totrec) & ", cl_stk=" & Val(totcl) & " WHERE book_cd=" & bookcd & "")
                ElseIf ds2.Tables(0).Rows(0).Item(0) = "O" Then
                    totop = opstk - 1
                    totcl = clstk - 1
                    SQLInsert("UPDATE book1 SET op_stk=" & Val(totop) & ", cl_stk=" & Val(totcl) & " WHERE book_cd=" & bookcd & "")
                End If

            Next
        End If
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT bk_rej1.rej_no,bk_rej1.rej_dt, bk_rej1.tot_qty, bk_rej1.tot_mrp, bk_rej1.tot_cost, bk_rej1.nb, staf.staf_nm,bk_rej1.staf_sl FROM bk_rej1 LEFT OUTER JOIN staf ON bk_rej1.staf_sl = staf.staf_sl WHERE (bk_rej1.rej_no = " & Val(slno) & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtrejscrl.Text = dsedit.Tables(0).Rows(0).Item("rej_no")
            dtrej.Value = dsedit.Tables(0).Rows(0).Item("rej_dt")
            cmbreject.Text = Trim(dsedit.Tables(0).Rows(0).Item("staf_nm"))
            txttotqty.Text = Format(dsedit.Tables(0).Rows(0).Item("tot_qty"), "#####0")
            txttotmrp.Text = Format(dsedit.Tables(0).Rows(0).Item("tot_mrp"), "#####0.00")
            txttotpur.Text = Format(dsedit.Tables(0).Rows(0).Item("tot_cost"), "#####0.00")
            txtremark.Text = dsedit.Tables(0).Rows(0).Item("nb")
            txtstafsl.Text = dsedit.Tables(0).Rows(0).Item("staf_sl")
            Me.dv_view(slno)
        End If
        Close1()
    End Sub

    Private Sub dv_view(ByVal slno As Integer)
        Dim ds As DataSet = get_dataset("SELECT   bk_rej2.scroll_cd,  bk_rej2.book_cd,bk_rej2.rej_sl, bk_rej2.rej_dt, bk_rej2.bk_qty, bk_rej2.bk_cost, bk_rej2.bk_mrp, book1.book_nm, book2.scroll_nm, pubc.pub_nm FROM pubc RIGHT OUTER JOIN book1 ON pubc.pub_cd = book1.pub_cd RIGHT OUTER JOIN bk_rej2 LEFT OUTER JOIN book2 ON bk_rej2.scroll_cd = book2.scroll_cd ON book1.book_cd = bk_rej2.book_cd WHERE (bk_rej2.rej_no =" & Val(slno) & ") ")
        dv1.Rows.Clear()
        If (ds.Tables(0).Rows.Count <> 0) Then
            Dim rw As Integer = 0
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(rw).Item("scroll_nm")
                dv1.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(rw).Item("book_nm")
                dv1.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(rw).Item("pub_nm")
                dv1.Rows(rw).Cells(4).Value = Format(ds.Tables(0).Rows(rw).Item("bk_cost"), "######0.00")
                dv1.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(rw).Item("bk_mrp"), "######0.00")
                dv1.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(rw).Item("bk_qty"), "####0")
                dv1.Rows(rw).Cells(7).Value = ds.Tables(0).Rows(rw).Item("scroll_cd")
                dv1.Rows(rw).Cells(8).Value = ds.Tables(0).Rows(rw).Item("book_cd")

                rw = rw + 1
            Next
        End If
    End Sub

    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT bk_rej1.rej_no AS 'Rejection No',bk_rej1.rej_dt AS 'Rejection Date', staf.staf_nm AS 'Staff Name',bk_rej1.tot_qty AS 'Quantity', bk_rej1.tot_cost AS 'Pur. Rate', bk_rej1.tot_mrp AS 'M.R.P' FROM bk_rej1 LEFT OUTER JOIN staf ON bk_rej1.staf_sl = staf.staf_sl")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

#End Region

#Region "Menu"

    Private Sub cmnu1del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1del.Click
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
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        comd = "E"
        Me.clr()
        dv.Visible = False
        txtrejscrl.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click
        Me.dv_disp()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Book Rejection Modification Screen ...."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtrejscrl.Focus()
        End If
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            comd = "V"
            btnsave.Text = "View"
            Me.Text = "Book Rejection View Screen ...."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtrejscrl.Focus()
        End If
    End Sub

    Private Sub cmnudelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            'If usr_tp = "A" Or usr_tp = "D" Then
            slno = dv.SelectedRows(0).Cells(0).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Call del1(slno)
                Call del2(slno)
                MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dv_disp()
            End If
            Close1()
            'Else
            '    MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        End If
    End Sub

#End Region

    Private Sub mnuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexpert.Click
        Call excel_view(dv)
    End Sub

    
End Class
