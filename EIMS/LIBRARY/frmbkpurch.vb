Imports vb = Microsoft.VisualBasic
Public Class frmbkpurch
    Dim comd As String = "V"

    Private Sub frmbkpurch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnubkpur.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmbkpurch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmbkpurch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnubkpur.Enabled = False
        usrprmsn("mnubkpur", cmnuadd, cmnu1del, cmnuedit, cmenuview)
        comd = swapprmsn("mnubkpur", comd)
        Me.clr()
    End Sub

    Private Sub clr()
        dvtrans.DataSource = Nothing
        txtscrlno.Text = ""
        txtsl.Text = "1"
        txtinvno.Text = "X"
        txtgrandtot.Text = "0.00"
        txtremark.Text = ""
        txtbookcd.Text = 0
        txtprtcd.Text = 0
        cmbtype.SelectedIndex = 0
        cmbparty.Text = ""
        cmbbook.Text = ""
        lbladdress.Text = ""
        lblbal.Text = ""
        lblauthor.Text = ""
        lblpublication.Text = ""
        dtrec.Value = sys_date
        invdt.Value = sys_date
        txttot.Text = "0.00"
        txttotamt.Text = "0.00"
        txttototh.Text = "0.00"
        txtcharges.Text = "0.00"
        txtdis.Text = "0.00"
        txtadj.Text = "0.00"
        txtgrandtot.Text = "0.00"
        dv1.Rows.Clear()
        If comd = "E" Then
            Me.Text = "Book Purchase Entry Screen...."
            Dim ds As DataSet = get_dataset("SELECT max(pur_no) as 'Max' FROM bk_pur1")
            txtscrlno.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtscrlno.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            btnsave.Text = "Save"
        ElseIf comd = "M" Then
            Me.Text = "Book Purchase Modification Screen...."
            txtscrlno.Text = ""
            btnsave.Text = "Modify"
        ElseIf comd = "D" Then
            Me.Text = "Book Purchase Deletion Screen...."
            txtscrlno.Text = ""
            btnsave.Text = "Delete"
        Else
            Me.Text = "Book Purchase View Screen...."
            txtscrlno.Text = ""
            btnsave.Text = "View"
        End If
        Me.clr1()
    End Sub

    Private Sub clr1()
        txtgtot.Text = "0.00"
        txtpurrate.Text = "0.00"
        txtqty.Text = "0"
        txtoth.Text = "0.00"
        txtamount.Text = "0.00"
    End Sub

#Region "Enter/Leave"
    Private Sub sender_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscrlno.Enter, txtremark.Enter, dtrec.Enter, cmbtype.Enter, invdt.Enter, cmbparty.Enter, txtinvno.Enter, txtoth.Enter, txtpurrate.Enter, cmbbook.Enter, txtqty.Enter, txtcharges.Enter, txtdis.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscrlno.Leave, txtremark.Leave, dtrec.Leave, cmbtype.Leave, invdt.Leave, cmbparty.Leave, txtinvno.Leave, txtoth.Leave, txtpurrate.Leave, cmbbook.Leave, txtqty.Leave, txtcharges.Leave, txtdis.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnset.MouseEnter, btnsave.MouseEnter, btnref.MouseEnter, btnprint.MouseEnter, btnnxt.MouseEnter, btninter.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnset.MouseLeave, btnsave.MouseLeave, btnref.MouseLeave, btnprint.MouseLeave, btnnxt.MouseLeave, btninter.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "Combo Box"
    Private Sub cmbparty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.GotFocus
        lbladdress.Text = ""
        lblbal.Text = ""
        populate(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.LostFocus
        cmbparty.Height = 21
    End Sub

    Private Sub cmbparty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.Validated
        Dim ds As DataSet = get_dataset("SELECT prt_code,add1,cl_amt FROM party WHERE pname='" & Trim(cmbparty.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtprtcd.Text = ds.Tables(0).Rows(0).Item("prt_code")
            lbladdress.Text = Trim(ds.Tables(0).Rows(0).Item("add1"))
            lblbal.Text = Format(ds.Tables(0).Rows(0).Item("cl_amt"), "#######0.00")
        End If
    End Sub

    Private Sub cmbparty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbparty.Validating
        vdating(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' AND pname='" & Trim(cmbparty.Text) & "'", "Please Select A Valid Party Head Of A/c Name.")
    End Sub

    Private Sub cmbbook_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbook.GotFocus
        txtbookcd.Text = 0
        lblauthor.Text = ""
        lblpublication.Text = ""
        lblsnd.Text = ""
        populate(cmbbook, "SELECT book_nm FROM book1 WHERE rec_lock = 'N' ORDER BY book_nm")
    End Sub

    Private Sub cmbbook_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbook.LostFocus
        cmbbook.Height = 21
        cmbbook.BackColor = Color.White
    End Sub

    Private Sub cmbbook_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbook.Validated
        Dim ds As DataSet = get_dataset("SELECT book1.book_cd, book1.mrp, book1.cl_stk, author.auth_nm, pubc.pub_nm FROM book1 LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd WHERE (book1.book_nm = '" & Trim(cmbbook.Text) & "')")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtbookcd.Text = ds.Tables(0).Rows(0).Item("book_cd")
            lblauthor.Text = Trim(ds.Tables(0).Rows(0).Item("auth_nm"))
            lblpublication.Text = Trim(ds.Tables(0).Rows(0).Item("pub_nm"))
            txtpurrate.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            lblsnd.Text = Format(ds.Tables(0).Rows(0).Item("cl_stk"), "#######0")
            lblsndunt.Text = "PCS"
            If Val(txtprtcd.Text) <> 0 Or Val(txtbookcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
    End Sub

    Private Sub cmbbook_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbook.TextChanged
        Dim ds As DataSet = get_dataset("SELECT book1.book_cd, book1.mrp, book1.cl_stk, author.auth_nm, pubc.pub_nm FROM book1 LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd WHERE (book1.book_nm = '" & Trim(cmbbook.Text) & "')")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtbookcd.Text = ds.Tables(0).Rows(0).Item("book_cd")
            lblauthor.Text = Trim(ds.Tables(0).Rows(0).Item("auth_nm"))
            lblpublication.Text = Trim(ds.Tables(0).Rows(0).Item("pub_nm"))
            txtpurrate.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            lblsnd.Text = Format(ds.Tables(0).Rows(0).Item("cl_stk"), "#######0")
            lblsndunt.Text = "PCS"
            If Val(txtprtcd.Text) <> 0 Or Val(txtbookcd.Text) <> 0 Then
                Me.trans_view()
            End If
        End If
    End Sub

    Private Sub cmbbook_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        vdating(cmbbook, "SELECT book_nm FROM book1 WHERE (book_nm = '" & Trim(cmbbook.Text) & "')", "Please Select a Valid Book Name.")
    End Sub
#End Region

#Region "Key Press"
    Private Sub txtscrlno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtscrlno.KeyPress
        key(dtrec, e)
        NUM(e)
    End Sub

    Private Sub dtrec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtrec.KeyPress
        key(cmbtype, e)
    End Sub

    Private Sub cmbtype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtype.KeyPress
        key(txtinvno, e)
    End Sub

    Private Sub txtinvno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinvno.KeyPress
        'If txtinvno.Text = "" Then
        '    txtinvno.Text = "X"
        'End If
        key(cmbparty, e)
        SPKey(e)
    End Sub

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(invdt, e)
    End Sub

    Private Sub dtinv_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles invdt.KeyPress
        key(cmbbook, e)
    End Sub


    Private Sub cmbbook_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbook.KeyPress
        If Trim(cmbbook.Text) <> "" Then
            key(txtqty, e)
        Else
            key(txtremark, e)
        End If
        SPKey(e)
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        key(txtpurrate, e)
        NUM(e)
    End Sub

    Private Sub txtpurrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpurrate.KeyPress
        key(txtoth, e)
        NUM1(e)
    End Sub

    Private Sub txtoth_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtoth.KeyPress
        key(btnnxt, e)
        NUM1(e)
    End Sub

    Private Sub txtremark_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtremark.KeyPress
        key(txtcharges, e)
        SPKey(e)
    End Sub

    Private Sub txtcharges_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcharges.KeyPress
        key(txtdis, e)
        NUM1(e)
    End Sub

    Private Sub txtdis_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdis.KeyPress
        key(btnsave, e)
        NUM1(e)
    End Sub
#End Region

#Region "Botton"
    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        comd = "E"
        Me.dv_disp()

    End Sub

    Private Sub btnprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprint.Click

    End Sub

    Private Sub btninter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninter.Click
        comd = swapprmsn("mnubkpur", comd)
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

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Val(txtscrlno.Text) = 0 Then
            MessageBox.Show("Sorry The Scroll No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtscrlno.Focus()
            Exit Sub
        End If
        If Trim(cmbparty.Text) = "" Or Val(txtprtcd.Text) = 0 Then
            MessageBox.Show("Sorry The Party Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbparty.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count = 0 Then
            MessageBox.Show("Please Order At least one item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbbook.Focus()
            Exit Sub
        End If
        Me.purchase_save()
    End Sub

    Private Sub btnnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.Click
        If Trim(cmbbook.Text) = "" Or Val(txtbookcd.Text) = 0 Then
            MessageBox.Show("Please Provide A Book Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbbook.Focus()
            Exit Sub
        End If

        If Val(txtpurrate.Text) = 0 Then
            MessageBox.Show("Sorry The Purchase Rate Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtpurrate.Focus()
            Exit Sub
        End If
        sl1 = Val(txtsl.Text)
        dv1.Rows.Add()
        dv1.Rows(sl1 - 1).Cells(0).Value = sl1
        dv1.Rows(sl1 - 1).Cells(1).Value = cmbbook.Text
        dv1.Rows(sl1 - 1).Cells(2).Value = txtqty.Text
        dv1.Rows(sl1 - 1).Cells(3).Value = txtpurrate.Text
        dv1.Rows(sl1 - 1).Cells(4).Value = txtamount.Text
        dv1.Rows(sl1 - 1).Cells(5).Value = txtoth.Text
        dv1.Rows(sl1 - 1).Cells(6).Value = txtgtot.Text
        dv1.Rows(sl1 - 1).Cells(7).Value = txtbookcd.Text
        sl1 += 1
        txtsl.Text = sl1
        Me.grandamt(dv1)
        Me.clr1()
        cmbbook.Focus()
    End Sub
#End Region

    Private Sub cmnu1del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1del.Click

        If dv1.RowCount <> 0 Then
            bkcd = dv1.SelectedRows(0).Cells(7).Value
            Dim ds As DataSet = get_dataset("SELECT scroll_nm FROM book2 WHERE pur_sl=" & Val(txtscrlno.Text) & "")
            fnd = 0
            If ds.Tables(0).Rows.Count <> 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If ds.Tables(0).Rows(i).Item("scroll_nm") <> "" Then
                        fnd = 1
                    End If
                Next
            End If
            If fnd = 1 Then
                MessageBox.Show("Sorry You Can't Delete This Record.  This Book Is Already Scrolled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                For Each row As DataGridViewRow In dv1.SelectedRows
                    dv1.Rows.Remove(row)
                Next
                sl = 1
                For j As Integer = 0 To dv1.Rows.Count - 1
                    dv1.Rows(j).Cells(0).Value = j + 1
                    sl += 1
                Next
                txtsl.Text = sl
                Me.grandamt(dv1)
            End If
        End If
    End Sub

    Private Sub txtqty_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.Validated
        txtamount.Text = Format(Val(txtqty.Text) * Val(txtpurrate.Text), "######0.00")
        txtgtot.Text = Format(Val(txtamount.Text) + Val(txtoth.Text), "######0.00")
    End Sub

    Private Sub purchase_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(pur_no) as 'Max' FROM bk_pur1")
                txtscrlno.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrlno.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO bk_pur1 (pur_no,	pur_dt,	pur_tp,	inv_no,	inv_dt,	prt_code,tot_tax,tot_itamt,tot_oth,	tot_ittot," & _
                          "chr_amt,dis_amt,adj_amt,gr_tot,nb,usr_ent,ent_date,usr_mod,mod_date,usedby,rec_lock)" & _
                          "VALUES (" & Val(txtscrlno.Text) & ",'" & Format(dtrec.Value, "dd/MMM/yyyy") & "','" & _
                          vb.Left(cmbtype.Text, 1) & "','" & Trim(txtinvno.Text) & "','" & Format(invdt.Value, "dd/MMM/yyyy") & "'," & _
                          Val(txtprtcd.Text) & ",0," & Val(txttotamt.Text) & "," & Val(txttototh.Text) & "," & Val(txttot.Text) & "," & _
                          Val(txtcharges.Text) & "," & Val(txtdis.Text) & "," & Val(txtadj.Text) & "," & Val(txtgrandtot.Text) & ",'" & _
                          Trim(txtremark.Text) & "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(usr_sl) & ",'" & _
                          Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N','N')")
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
                Dim ds As DataSet = get_dataset("SELECT pur_no FROM bk_pur1 WHERE pur_no=" & Val(txtscrlno.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE bk_pur1 SET pur_dt='" & Format(dtrec.Value, "dd/MMM/yyyy") & "',pur_tp='" & _
                              vb.Left(cmbtype.Text, 1) & "',inv_no='" & Trim(txtinvno.Text) & "',inv_dt='" & _
                              Format(invdt.Value, "dd/MMM/yyyy") & "',prt_code=" & Val(txtprtcd.Text) & ",tot_tax=0,tot_itamt=" & _
                              Val(txttotamt.Text) & ",tot_oth=" & Val(txttototh.Text) & ",	tot_ittot=" & Val(txttot.Text) & ",chr_amt=" & _
                              Val(txtcharges.Text) & ",dis_amt=" & Val(txtdis.Text) & ",adj_amt=" & Val(txtadj.Text) & ",gr_tot=" & _
                              Val(txtgrandtot.Text) & ",nb='" & Trim(txtremark.Text) & "',usr_mod=" & Val(usr_sl) & ",mod_date='" & _
                              Format(Now, "dd/MMM/yyyy HH:mm:ss") & "' WHERE pur_no =" & Val(txtscrlno.Text) & "")
                    Me.dv_save()
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
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
                Call del1(txtscrlno.Text)
                Call del2(txtscrlno.Text)
                MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
            End If
        End If
    End Sub

    Private Sub dv_save()
        If dv1.RowCount <> 0 Then
            If comd = "M" Then
                del2(txtscrlno.Text)
            End If
            For i As Integer = 0 To dv1.RowCount - 1
                qty = Val(dv1.Rows(i).Cells(2).Value)
                prate = Val(dv1.Rows(i).Cells(3).Value)
                amt = Val(dv1.Rows(i).Cells(4).Value)
                othamt = Val(dv1.Rows(i).Cells(5).Value)
                totamt = Val(dv1.Rows(i).Cells(6).Value)
                bkcd = Val(dv1.Rows(i).Cells(7).Value)
                Dim ds1 As DataSet = get_dataset("SELECT max(pur_sl) as 'Max' FROM bk_pur2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO bk_pur2(pur_sl,pur_no,pur_dt,prt_code,pur_tp,book_cd,it_qty,it_rate,it_amt,tax_cd,tax_amt," & _
                          "oth_amt,it_tot) VALUES (" & Val(mxno) & "," & Val(txtscrlno.Text) & ",'" & Format(dtrec.Value, "dd/MMM/yyyy") & "'," & _
                          Val(txtprtcd.Text) & ",'" & vb.Left(cmbtype.Text, 1) & "'," & Val(bkcd) & "," & qty & "," & prate & "," & _
                          amt & ",0,0," & othamt & "," & totamt & ")")
                Dim ds2 As DataSet = get_dataset("SELECT max(scroll_cd ) as 'Max' FROM book2")
                mxno = 1
                If ds2.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds2.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds2.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                For n As Integer = 0 To qty - 1
                    SQLInsert("INSERT INTO book2(scroll_cd,book_cd,scroll_nm,prd_tp,book_pos,book_rej,book_qty,book_frm," & _
                             "in_date,out_date,mrp,edition,yr_pub,rej_by,pages,blocked,pur_sl) VALUES (" & Val(mxno) & "," & _
                             Val(bkcd) & ",'','1','I','N',1,'P','" & Format(Now, "dd/MMM/yyyy") & "','" & Format(Now, "dd/MMM/yyyy") & "'," & prate & ",'','','',0,'N'," & Val(txtscrlno.Text) & ")")
                    mxno = mxno + 1

                    Dim ds3 As DataSet = get_dataset("SELECT rec_stk,cl_stk  FROM book1 WHERE book_cd=" & bkcd & "")
                    'If ds2.Tables(0).Rows.Count <> 0 Then
                    '    If Not IsDBNull(ds2.Tables(0).Rows(0).Item(0)) Then
                    recstk = ds3.Tables(0).Rows(0).Item(0)
                    clstk = ds3.Tables(0).Rows(0).Item(1)
                    '    End If
                    'End If
                    totop = recstk + 1
                    totcl = clstk + 1
                    SQLInsert("UPDATE book1 SET rec_stk=" & totop & ",cl_stk=" & totcl & " WHERE book_cd=" & Val(bkcd) & "")

                    If cmbtype.SelectedIndex = 1 Then

                        Dim ds4 As DataSet = get_dataset("SELECT party.cr_amt, party.cl_amt,party.prt_code FROM party RIGHT OUTER JOIN bk_pur1 ON party.prt_code = bk_pur1.prt_code WHERE bk_pur1.pur_no=" & Val(txtscrlno.Text) & "")
                        cramt = ds4.Tables(0).Rows(0).Item(0)
                        clamt = ds4.Tables(0).Rows(0).Item(1)
                        prtcd = ds4.Tables(0).Rows(0).Item(2)
                        cramt = cramt + prate
                        clamt = clamt + prate
                        SQLInsert("UPDATE party SET cr_amt=" & cramt & ",cl_amt=" & clamt & " WHERE prt_code=" & prtcd & "")

                    End If
                Next

               
            Next
        End If
    End Sub

    Private Sub grandamt(ByVal dgv As DataGridView)
        gamt = 0
        goamt = 0
        gtamt = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            amt = dgv.Rows(i).Cells(4).Value
            oamt = dgv.Rows(i).Cells(5).Value
            tamt = dgv.Rows(i).Cells(6).Value
            gamt = gamt + Val(amt)
            goamt = goamt + Val(oamt)
            gtamt = gtamt + Val(tamt)
        Next
        txttotamt.Text = Format(gamt, "#######0.00")
        txttototh.Text = Format(goamt, "#######0.00")
        txttot.Text = Format(gtamt, "#######0.00")
        'Totalling Section
        grtot = (Val(txttot.Text) + Val(txtcharges.Text)) - Val(txtdis.Text)
        txtgrandtot.Text = Format(Math.Round(grtot), "########0.00")
        txtadj.Text = Format(Val(txtgrandtot.Text) - Val(grtot), "#######0.00")
        'txtgrandtot.Text = Format((Val(gtamt) + Val(txtcharges.Text)) - Val(txtdis.Text), "#######0.00")
    End Sub

    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT  bk_pur1.pur_no AS 'Bill No.', bk_pur1.pur_dt AS 'Bill Date',party.pname AS 'Party Name',(CASE WHEN bk_pur1.pur_tp=1 THEN 'Cash' WHEN bk_pur1.pur_tp=1 THEN 'Credit' END) AS 'Tr. Type', bk_pur1.inv_no AS 'Invoice No.', bk_pur1.inv_dt AS 'Invoice Date',  STR(bk_pur1.gr_tot,10,2) AS 'Total Amt.' FROM  bk_pur1 LEFT OUTER JOIN party ON bk_pur1.prt_code = party.prt_code ORDER BY bk_pur1.pur_no")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_view()
        Dim ds As DataSet = get_dataset("SELECT book1.book_nm, bk_pur2.pur_sl, bk_pur2.pur_no, bk_pur2.pur_dt, bk_pur2.prt_code, bk_pur2.pur_tp, bk_pur2.book_cd, bk_pur2.it_qty, bk_pur2.it_rate, bk_pur2.it_amt, bk_pur2.tax_cd, bk_pur2.tax_amt, bk_pur2.oth_amt, bk_pur2.it_tot FROM book1 RIGHT OUTER JOIN bk_pur2 ON book1.book_cd = bk_pur2.book_cd WHERE (bk_pur2.pur_no = " & Val(txtscrlno.Text) & ")")
        rw = 0
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("book_nm")
                dv1.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("it_qty")
                dv1.Rows(rw).Cells(3).Value = Format(ds.Tables(0).Rows(i).Item("it_rate"), "######0.00")
                dv1.Rows(rw).Cells(4).Value = Format(ds.Tables(0).Rows(i).Item("it_amt"), "######0.00")
                dv1.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(i).Item("oth_amt"), "######0.00")
                dv1.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("it_tot"), "######0.00")
                dv1.Rows(rw).Cells(7).Value = ds.Tables(0).Rows(i).Item("book_cd")
                rw += 1
            Next
            Me.grandamt(dv1)
            txtsl.Text = rw + 1
        End If
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)

        Dim dsedit As DataSet = get_dataset("SELECT bk_pur1.*, party.pname FROM bk_pur1 LEFT OUTER JOIN party ON bk_pur1.prt_code = party.prt_code WHERE(bk_pur1.pur_no = " & slno & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrlno.Text = slno
            dtrec.Value = dsedit.Tables(0).Rows(0).Item("pur_dt")
            cmbtype.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("pur_tp")) - 1
            txtinvno.Text = dsedit.Tables(0).Rows(0).Item("inv_no")
            invdt.Value = dsedit.Tables(0).Rows(0).Item("inv_dt")
            txtremark.Text = dsedit.Tables(0).Rows(0).Item("nb")
            txtprtcd.Text = dsedit.Tables(0).Rows(0).Item("prt_code")
            txtremark.Text = dsedit.Tables(0).Rows(0).Item("nb")
            txtdis.Text = Format(dsedit.Tables(0).Rows(0).Item("dis_amt"), "#######0.00")
            txtcharges.Text = Format(dsedit.Tables(0).Rows(0).Item("chr_amt"), "#######0.00")
            cmbparty.Text = dsedit.Tables(0).Rows(0).Item("pname")
            Me.dv_view()
        End If

    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Add"
        Me.Text = "Purchase Order Entry Screen . . ."
        dv.Visible = False
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Purchase Order Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
        End If
    End Sub


    Private Sub trans_view()
        dvtrans.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        ds = get_dataset("SELECT TOP (3) convert(varchar,pur_dt,3) 'Date',STR(it_rate,10,2) 'MRP', STR(it_rate,10,2) 'Rate' FROM bk_pur2 WHERE (book_cd = " & Val(txtbookcd.Text) & ") AND (prt_code = " & Val(txtprtcd.Text) & ") ORDER BY pur_dt")
        If ds.Tables(0).Rows.Count <> 0 Then
            dvtrans.DataSource = ds.Tables(0)
        End If
        Close1()
    End Sub

    Private Sub txtordno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtscrlno.Validated
        If comd <> "E" Then
            If txtscrlno.Text <> "" Then
                Dim ds As DataSet = get_dataset("SELECT pur_no FROM bk_pur1 WHERE pur_no=" & Val(txtscrlno.Text) & " ")
                If ds.Tables(0).Rows.Count <> 0 Then
                    Me.dv_edit(txtscrlno.Text)
                Else
                    MessageBox.Show("Please Select a Valid Scroll No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtscrlno.Focus()
                End If
            End If
        End If
    End Sub

    'Delete data from Table1/Primary Table
    Private Sub del1(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT pur_no FROM bk_pur1 WHERE pur_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            SQLInsert("DELETE FROM bk_pur1 WHERE pur_no=" & Val(code) & "")
        End If
    End Sub

    'Delete data from Table2/Secondary Table
    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT pur_sl,it_qty,book_cd,it_rate FROM bk_pur2 WHERE pur_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            SQLInsert("DELETE FROM book2 WHERE pur_sl=" & Val(code) & "")
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                posl = dsdel.Tables(0).Rows(i).Item(0)
                qty = dsdel.Tables(0).Rows(i).Item(1)
                bkcd = dsdel.Tables(0).Rows(i).Item(2)
                itrate = dsdel.Tables(0).Rows(i).Item(3)
                SQLInsert("DELETE FROM bk_pur2 WHERE pur_sl=" & Val(posl) & "")

                Dim ds2 As DataSet = get_dataset("SELECT rec_stk,cl_stk  FROM book1 WHERE book_cd=" & bkcd & "")
                'If ds2.Tables(0).Rows.Count <> 0 Then
                '    If Not IsDBNull(ds2.Tables(0).Rows(0).Item(0)) Then
                recstk = ds2.Tables(0).Rows(0).Item(0)
                clstk = ds2.Tables(0).Rows(0).Item(1)
                '    End If
                'End If
                totop = recstk - qty
                totcl = clstk - qty
                SQLInsert("UPDATE book1 SET rec_stk=" & totop & " ,cl_stk=" & totcl & " WHERE book_cd=" & bkcd & "")

                If cmbtype.SelectedIndex = 1 Then

                    Dim ds3 As DataSet = get_dataset("SELECT party.cr_amt, party.cl_amt,party.prt_code FROM party RIGHT OUTER JOIN bk_pur1 ON party.prt_code = bk_pur1.prt_code WHERE bk_pur1.pur_no=" & Val(code) & "")

                    cramt = ds3.Tables(0).Rows(0).Item(0)
                    clamt = ds3.Tables(0).Rows(0).Item(1)
                    prtcd = ds3.Tables(0).Rows(0).Item(2)

                    cramt = cramt - (itrate * qty)
                    clamt = clamt - (itrate * qty)

                    SQLInsert("UPDATE party SET cr_amt=" & cramt & ",cl_amt=" & clamt & " WHERE prt_code=" & prtcd & "")

                End If

            Next

        End If

    End Sub

    Private Sub txtcharges_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdis.Validated, txtcharges.Validated
        grtot = (Val(txttot.Text) + Val(txtcharges.Text)) - Val(txtdis.Text)
        txtgrandtot.Text = Format(Math.Round(grtot), "########0.00")
        txtadj.Text = Format(Val(txtgrandtot.Text) - Val(grtot), "#######0.00")
    End Sub



    Private Sub txtscrlno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscrlno.GotFocus
        If comd <> "E" Then
            Me.clr()
        End If
    End Sub

    Private Sub txtcharges_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcharges.GotFocus, txtdis.GotFocus, txtoth.GotFocus, txtpurrate.GotFocus
        If Val(sender.Text) = 0 Then
            sender.Text = ""
        End If
    End Sub

    Private Sub txtcharges_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcharges.LostFocus, txtdis.LostFocus, txtoth.LostFocus, txtpurrate.LostFocus
        sender.Text = Format(Val(sender.text), "#######0.00")
    End Sub

    Private Sub txtqty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqty.GotFocus
        If Val(txtqty.Text) = 0 Then
            txtqty.Text = ""
        End If
    End Sub

    Private Sub txtqty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqty.LostFocus
        txtqty.Text = Format(Val(txtqty.Text), "#######0")
    End Sub

    Private Sub txtpurrate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpurrate.Validated
        txtamount.Text = Format(Val(txtqty.Text) * Val(txtpurrate.Text), "######0.00")
        txtgtot.Text = Format(Val(txtamount.Text) + Val(txtoth.Text), "######0.00")
    End Sub

    Private Sub txtoth_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtoth.Validated
        txtgtot.Text = Format(Val(txtamount.Text) + Val(txtoth.Text), "######0.00")
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click
        Me.dv_disp()
    End Sub


    Private Sub mnuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexpert.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            comd = "V"
            btnsave.Text = "View"
            Me.Text = "Purchase Order View Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
        End If
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        authnm = InputBox("Enter The Party Name.", "Search Box...", Nothing)
        If (authnm Is Nothing OrElse authnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT  bk_pur1.pur_no AS 'Bill No.', bk_pur1.pur_dt AS 'Bill Date',party.pname AS 'Party Name',(CASE WHEN bk_pur1.pur_tp=1 THEN 'Cash' WHEN bk_pur1.pur_tp=1 THEN 'Credit' END) AS 'Tr. Type', bk_pur1.inv_no AS 'Invoice No.', bk_pur1.inv_dt AS 'Invoice Date',  STR(bk_pur1.gr_tot,10,2) AS 'Total Amt.' FROM  bk_pur1 LEFT OUTER JOIN party ON bk_pur1.prt_code = party.prt_code WHERE (party.pname LIKE'" & authnm & "%') ORDER BY bk_pur1.pur_no")
            dv.Columns.Clear()
            If dsedit.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dsedit.Tables(0)
            End If
            Close1()
            dv.Visible = True
            dv.Dock = DockStyle.Fill
        End If
    End Sub
End Class
