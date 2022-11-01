Imports vb = Microsoft.VisualBasic
Public Class frmbook
    Dim comd As String

    Private Sub frmbook_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnubookmst.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmbook_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmbook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnubookmst.Enabled = False
        usrprmsn("mnubookmst", cmnuadd, cmnuedit, cmenudel, cmenuview)
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmbook_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Book Master Entry Screen . . ."
        cmbbooknm.Text = ""
        txtnewnm.Text = ""
        txtdetailnm.Text = ""
        cmbauthnm.Text = ""
        txtothauth.Text = ""
        cmbpublication.Text = ""
        cmbsub.Text = ""
        cmbshelf.Text = ""
        txtisbn.Text = ""
        txtbarcd.Text = ""
        txtsl.Text = "1"
        txttotqty.Text = ""
        txttotval.Text = ""
        cmbbooknm.Enabled = True
        cmbcond.SelectedIndex = 0
        cmblock.SelectedIndex = 0
        dv1.Rows.Clear()
        Dim ds As DataSet = get_dataset("SELECT max(book_cd) as 'Max' FROM book1")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        cmbbooknm.Focus()
        Me.clr1()
      
    End Sub

    Private Sub clr1()
        txtaccessno.Text = ""
        'txtedition.Text = "0"
        'txtyear.Text = ""
        'txtpage.Text = "0"
        'txtcost.Text = "0.00"
    End Sub


#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtyear.Enter, txtpage.Enter, txtothauth.Enter, txtnewnm.Enter, txtisbn.Enter, txtedition.Enter, txtdetailnm.Enter, txtcost.Enter, txtbarcd.Enter, txtaccessno.Enter, cmbsub.Enter, cmbshelf.Enter, cmbpublication.Enter, cmbcond.Enter, cmbbooknm.Enter, cmbauthnm.Enter, cmblock.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtyear.Leave, txtpage.Leave, txtothauth.Leave, txtnewnm.Leave, txtisbn.Leave, txtedition.Leave, txtdetailnm.Leave, txtcost.Leave, txtbarcd.Leave, txtaccessno.Leave, cmbsub.Leave, cmbshelf.Leave, cmbpublication.Leave, cmblock.Leave, cmbcond.Leave, cmbbooknm.Leave, cmbauthnm.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

        sender.text = UCase(sender.text)
    End Sub

#End Region

#Region "Mouse Enter/Leave"

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter, btnnxt.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave, btnnxt.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtnewnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnewnm.KeyPress
        key(txtdetailnm, e)
        SPKey(e)
    End Sub

    Private Sub txtdetailnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdetailnm.KeyPress
        key(cmbauthnm, e)
        SPKey(e)
    End Sub

    Private Sub txtothauth_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtothauth.KeyPress
        key(cmbpublication, e)
        SPKey(e)
    End Sub

    Private Sub cmbsub_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbsub.KeyPress
        key(cmbshelf, e)
    End Sub

    Private Sub cmbshelf_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbshelf.KeyPress
        key(txtisbn, e)
    End Sub

    Private Sub txtisbn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtisbn.KeyPress
        key(txtbarcd, e)
        SPKey(e)
    End Sub

    Private Sub txtbarcd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbarcd.KeyPress
        key(txtaccessno, e)
        SPKey(e)
    End Sub

    Private Sub txtaccessno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaccessno.KeyPress
        If Trim(txtaccessno.Text) <> "" Then
            key(cmbcond, e)
        Else
            key(cmblock, e)
        End If
        SPKey(e)
    End Sub

    Private Sub cmbcond_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcond.KeyPress
        key(txtedition, e)
    End Sub

    Private Sub txtedition_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtedition.KeyPress
        key(txtyear, e)
        SPKey(e)
    End Sub

    Private Sub txtyear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtyear.KeyPress
        key(txtpage, e)
        SPKey(e)
    End Sub

    Private Sub txtpage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpage.KeyPress
        key(txtcost, e)
        SPKey(e)
    End Sub

    Private Sub txtcost_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcost.KeyPress
        key(btnnxt, e)
        SPKey(e)
    End Sub

    Private Sub cmbbooknm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbooknm.KeyPress
        key(txtdetailnm, e)
        SPKey(e)
    End Sub

    Private Sub cmbauthnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbauthnm.KeyPress
        key(txtothauth, e)
        SPKey(e)
    End Sub

    Private Sub cmbpublication_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpublication.KeyPress
        key(cmbsub, e)
        SPKey(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub

#End Region

#Region "GotFocus/LostFocus"

    Private Sub sender_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtedition.GotFocus, txtpage.GotFocus
        If Val(sender.text) = 0 Then
            sender.text = ""
        End If
    End Sub

    Private Sub sender_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtedition.LostFocus, txtpage.LostFocus
        sender.text = Format(Val(sender.text), "######0")
    End Sub

    Private Sub txtcost_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcost.GotFocus
        If Val(txtcost.Text) = 0 Then
            txtcost.Text = ""
        End If
    End Sub

    Private Sub txtcost_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcost.LostFocus
        txtcost.Text = Format(Val(sender.text), "#######0.00")
    End Sub

#End Region

#Region "Combo Box"

    Private Sub cmbbooknm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbooknm.GotFocus
        populate(cmbbooknm, "SELECT book_nm FROM book1 WHERE rec_lock='N' ORDER BY book_nm")
    End Sub

    Private Sub cmbbooknm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbooknm.LostFocus
        cmbbooknm.Height = 21
    End Sub

    Private Sub cmbbooknm_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbooknm.Validated
        vdated(txtscrl, "SELECT book_cd FROM book1 WHERE book_nm='" & Trim(cmbbooknm.Text) & "'")
        txtdetailnm.Text = Trim(cmbbooknm.Text)
        txtnewnm.Text = Trim(cmbbooknm.Text)
    End Sub

    Private Sub cmbbooknm_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbbooknm.Validating
        If comd = "E" Then
            Dim ds As DataSet = get_dataset("SELECT book_nm FROM book1 WHERE book_nm='" & Trim(cmbbooknm.Text) & "' AND rec_lock='N'")
            If ds.Tables(0).Rows.Count <> 0 Then
                MessageBox.Show("Sorry The Book Name Already Present in Your Database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbbooknm.Focus()
            End If
        Else
            vdating(cmbbooknm, "SELECT book_nm FROM book1 WHERE book_nm='" & Trim(cmbbooknm.Text) & "' AND rec_lock='N'", "Please Select A Valid Book Name.")
        End If
    End Sub

    Private Sub cmbauthnm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbauthnm.GotFocus
        populate(cmbauthnm, "SELECT auth_nm FROM author WHERE rec_lock='N' ORDER BY auth_nm")
    End Sub

    Private Sub cmbauthnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbauthnm.LostFocus
        cmbauthnm.Height = 21
    End Sub

    Private Sub cmbauthnm_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbauthnm.Validated
        vdated(txtauthcd, "SELECT auth_cd FROM author WHERE auth_nm='" & Trim(cmbauthnm.Text) & "'")
    End Sub

    Private Sub cmbauthnm_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbauthnm.Validating
        vdating(cmbauthnm, "SELECT auth_nm FROM author WHERE auth_nm='" & Trim(cmbauthnm.Text) & "' AND rec_lock='N'", "Please Select A Valid Author Name.")
    End Sub

    Private Sub cmbpublication_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpublication.GotFocus
        populate(cmbpublication, "SELECT pub_nm FROM pubc WHERE rec_lock='N' ORDER BY pub_nm")
    End Sub

    Private Sub cmbpublication_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpublication.LostFocus
        cmbpublication.Height = 21
    End Sub

    Private Sub cmbpublication_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbpublication.Validated
        vdated(txtpubcd, "SELECT pub_cd FROM pubc WHERE pub_nm='" & Trim(cmbpublication.Text) & "'")
    End Sub

    Private Sub cmbpublication_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbpublication.Validating
        vdating(cmbpublication, "SELECT pub_nm FROM pubc WHERE pub_nm='" & Trim(cmbpublication.Text) & "' AND rec_lock='N'", "Please Select A Valid Publication Name.")
    End Sub


    Private Sub cmbsub_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsub.GotFocus
        populate(cmbsub, "SELECT sub_nm FROM subject_mst WHERE rec_lock='N' ORDER BY sub_nm")
    End Sub

    Private Sub cmbsub_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsub.LostFocus
        cmbsub.Height = 21
    End Sub

    Private Sub cmbsub_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsub.Validated
        vdated(txtsubcd, "SELECT sub_cd FROM subject_mst WHERE sub_nm='" & Trim(cmbsub.Text) & "'")
    End Sub

    Private Sub cmbsub_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbsub.Validating
        vdating(cmbsub, "SELECT sub_nm FROM subject_mst WHERE sub_nm='" & Trim(cmbsub.Text) & "' AND rec_lock='N'", "Please Select A Valid Subject Name.")
    End Sub

    Private Sub cmbshelf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbshelf.GotFocus
        populate(cmbshelf, "SELECT self_nm FROM shelf WHERE rec_lock='N' ORDER BY self_nm")
    End Sub

    Private Sub cmbshelf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbshelf.LostFocus
        cmbshelf.Height = 21
    End Sub

    Private Sub cmbshelf_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbshelf.Validated
        vdated(txtshelfcd, "SELECT self_cd FROM shelf WHERE self_nm='" & Trim(cmbshelf.Text) & "'")
    End Sub

    Private Sub cmbshelf_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbshelf.Validating
        vdating(cmbshelf, "SELECT self_nm FROM shelf WHERE self_nm='" & Trim(cmbshelf.Text) & "' AND rec_lock='N'", "Please Select A Valid Shelf Name.")
    End Sub

#End Region

#Region "Validated/Validating"

    Private Sub txtaccessno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtaccessno.Validated
        If txtaccessno.Text <> "" Then
            Dim ds As DataSet = get_dataset("SELECT book1.book_nm FROM book1 LEFT OUTER JOIN book2 ON book1.book_cd = book2.book_cd WHERE (book2.scroll_nm = '" & Trim(txtaccessno.Text) & "')")
            If ds.Tables(0).Rows.Count <> 0 Then
                book_nm = ds.Tables(0).Rows(0).Item(0)
                MessageBox.Show("Sorry The Scroll No. You have Provided Here is Already Assigned to The Book : " & book_nm, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtaccessno.Focus()
            End If
        End If
    End Sub

#End Region

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Add"
        txtnewnm.ReadOnly = True
    End Sub

    Private Sub btnnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.Click
        If Trim(txtaccessno.Text) = "" Then
            MessageBox.Show("The Library Accession No Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtaccessno.Focus()
            Exit Sub
        End If

        If txtedition.Text = "" Or txtedition.Text = 0 Then
            MessageBox.Show("The Book Edition Should Not Be Blank / Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtedition.Focus()
            Exit Sub
        End If

        If Val(txtyear.Text) = 0 Then
            MessageBox.Show("The Book Publication Year Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtyear.Focus()
            Exit Sub
        End If

        If txtpage.Text = 0 Then
            MessageBox.Show("The Book Page Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtpage.Focus()
            Exit Sub
        End If

        If txtcost.Text = 0 Then
            MessageBox.Show("The Book Cost Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtcost.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                x = dv1.Rows(i).Cells(1).Value
                If Trim(txtaccessno.Text) = x Then
                    MessageBox.Show("Sorry The Data Should Not Be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtaccessno.Focus()
                    Exit Sub
                End If
            Next
        End If
        sl = Val(txtsl.Text)
        dv1.Rows.Add()
        dv1.Rows(sl - 1).Cells(0).Value = sl
        dv1.Rows(sl - 1).Cells(1).Value = txtaccessno.Text
        dv1.Rows(sl - 1).Cells(2).Value = cmbcond.Text
        dv1.Rows(sl - 1).Cells(3).Value = txtedition.Text
        dv1.Rows(sl - 1).Cells(4).Value = txtyear.Text
        dv1.Rows(sl - 1).Cells(5).Value = txtpage.Text
        dv1.Rows(sl - 1).Cells(6).Value = txtcost.Text
        dv1.Rows(sl - 1).Cells(7).Value = 1
        sl += 1
        txtsl.Text = sl
        Me.grandamt(dv1)
        Me.totqty(dv1)
        txtaccessno.Focus()
        Me.clr1()
    End Sub

    Private Sub totqty(ByVal dgv As DataGridView)
        tqty = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            qty = dgv.Rows(i).Cells(7).Value
            tqty = tqty + Val(qty)
        Next
        txttotqty.Text = Format(tqty, "#######0")

    End Sub

    Private Sub grandamt(ByVal dgv As DataGridView)

        gtamt = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            amt = dgv.Rows(i).Cells(6).Value
            gtamt = gtamt + Val(amt)
        Next
        txttotval.Text = Format(gtamt, "#######0.00")

    End Sub

    Private Sub btnclr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclr.Click
        If dv1.RowCount <> 0 Then
            If usr_tp = "A" Or usr_tp = "D" Then
                Dim ds As DataSet = get_dataset("SELECT * FROM book2 WHERE book_frm ='O' AND book_pos='O' OR book_rej='Y' AND book_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count = 0 Then

                    dv1.Rows.Clear()
                    txtsl.Text = "1"
                    Me.grandamt(dv1)
                    Me.totqty(dv1)
                    Me.clr1()
                   
                Else
                    MessageBox.Show("You Can Not Delete The Book. One Of The Scroll Already Issued/Rejected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If
            Else
                MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
     
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(cmbbooknm.Text) = "" Then
            MessageBox.Show("Please Provide A Book Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbbooknm.Focus()
            Exit Sub
        End If
        If Trim(cmbauthnm.Text) = "" Or Val(txtauthcd.Text) = 0 Then
            MessageBox.Show("Please Select A Auther Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbauthnm.Focus()
            Exit Sub
        End If
        If Trim(cmbpublication.Text) = "" Or Val(txtpubcd.Text) = 0 Then
            MessageBox.Show("Please Select A Publication Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbpublication.Focus()
            Exit Sub
        End If
        If Trim(cmbsub.Text) = "" Or Val(txtsubcd.Text) = 0 Then
            MessageBox.Show("Please Select A Subject Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbsub.Focus()
            Exit Sub
        End If
        If Trim(cmbshelf.Text) = "" Or Val(txtshelfcd.Text) = 0 Then
            MessageBox.Show("Please Select A Shelf Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbshelf.Focus()
            Exit Sub
        End If
        'If dv1.Rows.Count = 0 Then
        '    MessageBox.Show("Please Order At least one item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    cmbbook.Focus()
        '    Exit Sub
        'End If
        Me.book_save()
    End Sub

#End Region

#Region "cmenu"

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
        Me.Text = "Book Master Entry Screen . . ."
        txtnewnm.ReadOnly = True
        dv.Visible = False
        cmbbooknm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Book Master Modification Screen . . ."
            cmbbooknm.Enabled = False
            txtnewnm.ReadOnly = False
            slno = dv.SelectedRows(0).Cells(4).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtnewnm.Focus()
        End If
    End Sub

    Private Sub cmnu1del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1del.Click
        If dv1.RowCount <> 0 Then
            If usr_tp = "A" Or usr_tp = "D" Then
                Dim ds As DataSet = get_dataset("SELECT * FROM book2 WHERE book_frm ='O' AND book_pos='O' OR book_rej='Y' AND book_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count = 0 Then

                    scrlnm = dv1.SelectedRows(0).Cells(1).Value

                    'Dim ds1 As DataSet = get_dataset("SELECT scroll_cd,book_pos,book_rej FROM book2 WHERE book_frm ='O' AND scroll_nm=" & Val(scrlnm) & "")
                    'bkpos = ds1.Tables(0).Rows(0).Item("book_pos")
                    'bkrej = ds1.Tables(0).Rows(0).Item("book_rej")
                    'If bkpos = "O" Or bkrej = "Y" Then
                    '    MessageBox.Show("Sorry You Can Not Delete This Book", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    Exit Sub
                    'End If

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
                Else
                    MessageBox.Show("You Can Not Delete The Book. One Of The Scroll Already Issued/Rejected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If
            Else
                MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        If dv.RowCount <> 0 Then
            'If usr_tp = "A" Or usr_tp = "D" Then
            bkcd = dv.SelectedRows(0).Cells(4).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT book_cd FROM bk_iss2 WHERE book_cd=" & Val(bkcd) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    MessageBox.Show("Sorry You Can Not Delete This Book", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim ds1 As DataSet = get_dataset("SELECT book_cd FROM bk_pur2 WHERE book_cd=" & Val(bkcd) & "")
                If ds1.Tables(0).Rows.Count <> 0 Then
                    MessageBox.Show("Sorry You Can Not Delete This Book", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim ds2 As DataSet = get_dataset("SELECT book_cd FROM bk_rej2 WHERE book_cd=" & Val(bkcd) & "")
                If ds2.Tables(0).Rows.Count <> 0 Then
                    MessageBox.Show("Sorry You Can Not Delete This Book", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                SQLInsert("DELETE FROM book1 WHERE book_cd=" & Val(bkcd) & "")
                SQLInsert("DELETE FROM book2 WHERE book_cd=" & Val(bkcd) & "")
                MessageBox.Show("Record Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        'Else
        '    MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        Close1()
        Me.dv_disp()
    End Sub

#End Region

#Region "DATA SAVE"

    Private Sub book_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(book_cd) as 'Max' FROM book1")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
               
                SQLInsert("INSERT INTO book1 (book_cd,book_nm,book_dnm,isbn_no,pub_cd,sub_cd,auth_cd,oth_auth,sem_cd,self_cd,mrp," & _
                          "op_stk,rec_lock,rec_stk,iss_stk,cl_stk,barcode) VALUES (" & Val(txtscrl.Text) & ",'" & Trim(cmbbooknm.Text) & "','" & _
                          Trim(txtdetailnm.Text) & "','" & Trim(txtisbn.Text) & "'," & Val(txtpubcd.Text) & "," & Val(txtsubcd.Text) & "," & _
                          Val(txtauthcd.Text) & ",'" & Trim(txtothauth.Text) & "',0," & Val(txtshelfcd.Text) & ",0,0,'" & _
                          vb.Left(cmblock.Text, 1) & "',0,0,0,'" & Trim(txtbarcd.Text) & "')")
                Me.dv_save()
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Close1()
            End If
        Else
            'If usr_tp = "O" Then
            '    MessageBox.Show("You Are Not Authorised to Modify The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT book_cd,op_stk,cl_stk FROM book1 WHERE book_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    
                    SQLInsert("UPDATE book1 SET book_nm='" & Trim(txtnewnm.Text) & "',book_dnm='" & Trim(txtdetailnm.Text) & "',isbn_no='" & _
                              Trim(txtisbn.Text) & "',pub_cd=" & Val(txtpubcd.Text) & ",sub_cd=" & Val(txtpubcd.Text) & ",auth_cd=" & _
                              Val(txtauthcd.Text) & ",oth_auth='" & Trim(txtothauth.Text) & "',self_cd=" & Val(txtshelfcd.Text) & _
                              ", rec_lock='" & vb.Left(cmblock.Text, 1) & "',barcode='" & Trim(txtbarcd.Text) & _
                              "' WHERE book_cd=" & Val(txtscrl.Text) & "")
                    Me.dv_save()
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                    Me.dv_disp()
                End If
                Close1()
            End If
        End If
    End Sub

    Private Sub dv_disp()
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY auth_nm) AS 'Sl.', book1.book_nm AS 'Book Name', pubc.pub_nm AS 'Publication Name', author.auth_nm AS 'Author Name',book1.book_cd,book1.rec_lock FROM book1 LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd ORDER BY book1.book_nm")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(4).Visible = False
            dv.Columns(5).Visible = False

            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(5).Value

                If reclock = "Y" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    'dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
            
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
        btnsave.Enabled = True
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT pubc.pub_nm, author.auth_nm, book1.*, subject_mst.sub_nm, shelf.self_nm FROM book1 LEFT OUTER JOIN shelf ON book1.self_cd = shelf.self_cd LEFT OUTER JOIN subject_mst ON book1.sub_cd = subject_mst.sub_cd LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd WHERE(book1.book_cd = " & slno & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            cmbbooknm.Text = dsedit.Tables(0).Rows(0).Item("book_nm")
            txtnewnm.Text = dsedit.Tables(0).Rows(0).Item("book_nm")
            txtdetailnm.Text = dsedit.Tables(0).Rows(0).Item("book_dnm")
            cmbauthnm.Text = dsedit.Tables(0).Rows(0).Item("auth_nm")
            txtothauth.Text = dsedit.Tables(0).Rows(0).Item("oth_auth")
            cmbpublication.Text = dsedit.Tables(0).Rows(0).Item("pub_nm")
            cmbsub.Text = dsedit.Tables(0).Rows(0).Item("sub_nm")
            If Not IsDBNull(dsedit.Tables(0).Rows(0).Item("self_nm")) Then
                cmbshelf.Text = dsedit.Tables(0).Rows(0).Item("self_nm")
            End If
            txtisbn.Text = dsedit.Tables(0).Rows(0).Item("isbn_no")
            txtbarcd.Text = dsedit.Tables(0).Rows(0).Item("barcode")
            txtauthcd.Text = dsedit.Tables(0).Rows(0).Item("auth_cd")
            txtpubcd.Text = dsedit.Tables(0).Rows(0).Item("pub_cd")
            txtsubcd.Text = dsedit.Tables(0).Rows(0).Item("sub_cd")
            txtshelfcd.Text = dsedit.Tables(0).Rows(0).Item("self_cd")
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
                cmblock.SelectedIndex = 1
            Else
                cmblock.SelectedIndex = 0
            End If
            Me.dv_view()
        End If
        Close1()
    End Sub


    Private Sub dv_save()

        If comd = "M" Then
            Call del2(txtscrl.Text)
        End If
        If dv1.RowCount <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                accno = dv1.Rows(i).Cells(1).Value
                condtn = vb.Left(dv1.Rows(i).Cells(2).Value, 1)
                edtn = dv1.Rows(i).Cells(3).Value
                yr = dv1.Rows(i).Cells(4).Value
                page = dv1.Rows(i).Cells(5).Value
                cost = dv1.Rows(i).Cells(6).Value
                Dim ds1 As DataSet = get_dataset("SELECT max(scroll_cd ) as 'Max' FROM book2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO book2(scroll_cd,book_cd,scroll_nm,prd_tp,book_pos,book_rej,book_qty,book_frm," & _
                          "in_date,out_date,mrp,edition,yr_pub,rej_by,pages,blocked,pur_sl) VALUES (" & Val(mxno) & "," & _
                          Val(txtscrl.Text) & ",'" & accno & "','" & condtn & "','I','N',1,'O','" & _
                         Format(Now, "dd/MMM/yyyy") & "','" & Format(Now, "dd/MMM/yyyy") & "'," & cost & ",'" & edtn & "','" & yr & "',''," & page & ",'N',0)")
            Next

            Dim ds2 As DataSet = get_dataset("SELECT op_stk,cl_stk  FROM book1 WHERE book_cd=" & Val(txtscrl.Text) & "")
           
            If ds2.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds2.Tables(0).Rows(0).Item(0)) Then
                    opstk = ds2.Tables(0).Rows(0).Item(0)
                    clstk = ds2.Tables(0).Rows(0).Item(1)
              
                    totop = opstk + txttotqty.Text
                    totcl = clstk + txttotqty.Text
                    SQLInsert("UPDATE book1 SET op_stk=" & totop & ", cl_stk=" & totcl & " WHERE book_cd=" & Val(txtscrl.Text) & "")
                End If
            End If
        End If
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            btnsave.Enabled = False
            Me.Text = "Book Master View Screen . . ."
            slno = dv.SelectedRows(0).Cells(4).Value
            Me.dv_edit(slno)
            dv.Visible = False
            cmbbooknm.Focus()
        End If
    End Sub
   

    'Delete data from Table2/Secondary Table
    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT scroll_cd FROM book2 WHERE book_cd=" & Val(code) & " AND book_frm='O' AND book_pos='I'")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                scrl = dsdel.Tables(0).Rows(i).Item(0)
                SQLInsert("DELETE FROM book2 WHERE scroll_cd=" & Val(scrl) & " ")

                Dim ds2 As DataSet = get_dataset("SELECT op_stk ,cl_stk FROM book1 WHERE book_cd=" & Val(code) & "")
                'If ds2.Tables(0).Rows.Count <> 0 Then
                '    If Not IsDBNull(ds2.Tables(0).Rows(0).Item(0)) Then
                opstk = ds2.Tables(0).Rows(0).Item(0)
                clstk = ds2.Tables(0).Rows(0).Item(1)
                '    End If
                'End If
                totop = opstk - 1
                totcl = clstk - 1
                SQLInsert("UPDATE book1 SET op_stk=" & totop & ",cl_stk=" & totcl & " WHERE book_cd=" & Val(txtscrl.Text) & "")

            Next
        End If

    End Sub

    Private Sub dv_view()
        Dim ds As DataSet = get_dataset("SELECT * from book2 WHERE book_cd=" & Val(txtscrl.Text) & " AND book_frm='O'")
        rw = 0
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("scroll_nm")
                dv1.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("prd_tp")
                dv1.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("edition")
                dv1.Rows(rw).Cells(4).Value = ds.Tables(0).Rows(i).Item("yr_pub")
                dv1.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(i).Item("pages"), "######0")
                dv1.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("mrp"), "######0.00")
                dv1.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("book_qty"), "######0")

                rw += 1
            Next
            txtsl.Text = rw + 1
            Me.grandamt(dv1)
            Me.totqty(dv1)
        End If
    End Sub

#End Region


    Private Sub mnuexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexport.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        authnm = InputBox("Enter The Book Name.", "Search Box...", Nothing)
        If (authnm Is Nothing OrElse authnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY auth_nm) AS 'Sl.', book1.book_nm AS 'Book Name', pubc.pub_nm AS 'Publication Name', author.auth_nm AS 'Author Name',book1.book_cd,book1.rec_lock FROM book1 LEFT OUTER JOIN author ON book1.auth_cd = author.auth_cd LEFT OUTER JOIN pubc ON book1.pub_cd = pubc.pub_cd WHERE (book1.book_nm LIKE'" & authnm & "%') ORDER BY book1.book_nm")
            dv.Columns.Clear()
            If dsedit.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dsedit.Tables(0)
                dv.Columns(4).Visible = False
                dv.Columns(5).Visible = False

                For i As Integer = 0 To dv.Rows.Count - 1
                    reclock = dv.Rows(i).Cells(5).Value

                    If reclock = "Y" Then
                        dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    Else
                        'dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    End If
                Next

            End If
        End If
    End Sub
End Class
