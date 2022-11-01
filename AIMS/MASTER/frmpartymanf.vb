Imports vb = Microsoft.VisualBasic
Public Class frmpartymanf
    Dim comd As String

    Private Sub frmpartymanf_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmpartymanf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmpartymanf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
        Me.dv_disp()
    End Sub
    Private Sub clr()
        Me.Text = "Company Wise Discount Master. . . ."
        cmbparty.Text = ""
        txtbiling.Text = ""
        txtcontperson.Text = ""
        txtaddres.Text = ""
        txtsl.Text = "1"
        txtpartycd.Text = ""
        cmbparty.Enabled = True
        dv1.Rows.Clear()
        cmbparty.Focus()
    End Sub

    Private Sub clr1()
        txtcompcd.Text = ""
        cmbcompany.Text = ""
        txtcomp.Text = "0.00"
        txttrade.Text = "0.00"
    End Sub

#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrade.Enter, txtsl.Enter, txtcontperson.Enter, txtcomp.Enter, txtbiling.Enter, txtaddres.Enter, cmbcompany.Enter, cmbparty.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrade.Leave, txtsl.Leave, txtcontperson.Leave, txtcomp.Leave, txtbiling.Leave, txtaddres.Leave, cmbcompany.Leave, cmbparty.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseEnter, btnref.MouseEnter, btnnext.MouseEnter, btnexit.MouseEnter, btnview.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseLeave, btnref.MouseLeave, btnnext.MouseLeave, btnexit.MouseLeave, btnview.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region
 
#Region "KeyPress"

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(cmbcompany, e)
        SPKey(e)
    End Sub

    Private Sub cmbcompany_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcompany.KeyPress
        If cmbcompany.Text <> "" Then
            key(txtcomp, e)
        Else
            key(btnsave, e)
        End If
        SPKey(e)
    End Sub

    Private Sub txtcomp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcomp.KeyPress
        key(txttrade, e)
        NUM1(e)
    End Sub

    Private Sub txttrade_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttrade.KeyPress
        key(btnnext, e)
        NUM1(e)
    End Sub

    Private Sub btnclear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnclear.KeyPress
        key(cmbcompany, e)
    End Sub

#End Region

#Region "Combo"

    Private Sub cmbparty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.GotFocus
        cmbparty.Height = 100
        populate(cmbparty, "SELECT pname FROM party WHERE rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.LostFocus
        cmbparty.Height = 21
    End Sub

    Private Sub cmbparty_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbparty.Validated
        Dim ds As DataSet = get_dataset("select prt_code,bname,add1,per_cont from party where pname = '" & Trim(cmbparty.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtpartycd.Text = ds.Tables(0).Rows(0).Item("prt_code")
            txtbiling.Text = ds.Tables(0).Rows(0).Item("bname")
            txtaddres.Text = ds.Tables(0).Rows(0).Item("add1")
            txtcontperson.Text = ds.Tables(0).Rows(0).Item("per_cont")
        End If
    End Sub

    Private Sub cmbparty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbparty.Validating
        vdating(cmbparty, " SELECT pname FROM party WHERE pname='" & Trim(cmbparty.Text) & "'", "Please Select A Valid Party Name.")
    End Sub

    Private Sub cmbcompany_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcompany.GotFocus
        cmbcompany.Height = 100
        populate(cmbcompany, "SELECT manf_nm FROM manf WHERE rec_lock='N' ORDER BY manf_nm")
    End Sub

    Private Sub cmbcompany_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcompany.LostFocus
        cmbcompany.Height = 21
    End Sub

    Private Sub cmbcompany_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcompany.Validated
        vdated(txtcompcd, " SELECT manf_cd FROM manf WHERE manf_nm='" & Trim(cmbcompany.Text) & "'")
    End Sub

    Private Sub cmbcompany_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcompany.Validating
        vdating(cmbcompany, " SELECT manf_nm FROM manf WHERE manf_nm='" & Trim(cmbcompany.Text) & "'", "Please Select A Valid Company Name.")
    End Sub

#End Region

    Private Sub sender_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttrade.LostFocus, txtcomp.LostFocus
        sender.Text = Format(Val(sender.text), "#######0.00")
    End Sub

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
        comd = "E"
        Me.Text = "Company Wise Discount Master Entry Screen . . ."
        btnsave.Text = "Save"
    End Sub

    Private Sub btnnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnext.Click
        If Trim(cmbparty.Text) = "" Then
            MessageBox.Show("Sorry The Party Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbparty.Focus()
            Exit Sub
        End If
        If Trim(cmbcompany.Text) = "" Then
            MessageBox.Show("Sorry The Company Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbcompany.Focus()
            Exit Sub
        End If
        If Val(txtcomp.Text) = "0.00" And Val(txttrade.Text) = "0.00" Then
            MessageBox.Show("Please Enter Discount Ammount", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtcomp.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                x = dv1.Rows(i).Cells(1).Value
                If Trim(cmbcompany.Text) = x Then
                    MessageBox.Show("Sorry The Data Should Not Be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbcompany.Focus()
                    Exit Sub
                End If
            Next
        End If
        sl = Val(txtsl.Text)
        dv1.Rows.Add()
        dv1.Rows(sl - 1).Cells(0).Value = sl
        dv1.Rows(sl - 1).Cells(1).Value = cmbcompany.Text
        dv1.Rows(sl - 1).Cells(2).Value = txtcomp.Text
        dv1.Rows(sl - 1).Cells(3).Value = txttrade.Text
        dv1.Rows(sl - 1).Cells(4).Value = txtcompcd.Text
        sl += 1
        txtsl.Text = sl
        cmbcompany.Focus()
        Me.clr1()
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        dv1.Rows.Clear()
        txtsl.Text = "1"
        Me.clr1()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(cmbparty.Text) = "" Or Val(txtpartycd.Text) = 0 Then
            MessageBox.Show("The Party Name Should not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbparty.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count = 0 Then
            MessageBox.Show("Please Assign Discount To At Least One Company", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbcompany.Focus()
            Exit Sub
        End If
        Me.party_save()
    End Sub

#End Region

    Private Sub party_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Me.compdis_save()
                Me.clr()
                Me.Text = "Company Wise Discount Master Entry Screen . . ."
                Close1()
            End If
        Else
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Me.compdis_save()
                Me.clr()
                Me.dv_disp()
            End If
            Close1()
        End If
    End Sub

    Private Sub compdis_save()
        If comd = "M" Then
            SQLInsert("DELETE FROM cmpdisc WHERE prt_code=" & Val(txtpartycd.Text) & " ")
            'Call del2(txtpartycd.Text)
        End If
        If dv1.RowCount <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                comp = dv1.Rows(i).Cells(2).Value
                trad = dv1.Rows(i).Cells(3).Value
                cmpcd = dv1.Rows(i).Cells(4).Value
                Dim ds1 As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM cmpdisc")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO cmpdisc(slno,prt_code,manf_cd,co_disc,tr_disc) VALUES (" & Val(mxno) & "," & _
                          Val(txtpartycd.Text) & "," & cmpcd & ",'" & comp & "','" & trad & "')")
            Next
        End If
    End Sub

    'Private Sub del2(ByVal code As Integer)
    '    Dim dsdel As DataSet = get_dataset("SELECT prt_code FROM cmpdisc WHERE prt_code=" & Val(code) & "")
    '    If dsdel.Tables(0).Rows.Count <> 0 Then
    '        For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
    '            scrl = dsdel.Tables(0).Rows(i).Item(0)
    '            SQLInsert("DELETE FROM cmpdisc WHERE prt_code=" & Val(code) & " ")
    '        Next
    '    End If
    'End Sub

    Private Sub dv_disp()
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT  ROW_NUMBER() OVER(ORDER BY pname) AS 'Sl.', party.pname AS 'Party Name', cmpdisc.slno, cmpdisc.prt_code FROM cmpdisc LEFT OUTER JOIN party ON cmpdisc.prt_code = party.prt_code")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(2).Visible = False
            dv.Columns(3).Visible = False
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT prt_code,pname, bname, add1, per_cont FROM  party  WHERE(prt_code = " & slno & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtpartycd.Text = dsedit.Tables(0).Rows(0).Item("prt_code")
            cmbparty.Text = dsedit.Tables(0).Rows(0).Item("pname")
            txtbiling.Text = dsedit.Tables(0).Rows(0).Item("bname")
            txtaddres.Text = dsedit.Tables(0).Rows(0).Item("add1")
            txtcontperson.Text = dsedit.Tables(0).Rows(0).Item("per_cont")
         
            Me.dv_view()
        End If
        Close1()
    End Sub

    Private Sub dv_view()
        Dim ds As DataSet = get_dataset("SELECT cmpdisc.co_disc, cmpdisc.tr_disc, cmpdisc.manf_cd, manf.manf_nm FROM cmpdisc INNER JOIN manf ON cmpdisc.manf_cd = manf.manf_cd WHERE prt_code=" & Val(txtpartycd.Text) & " ")
        rw = 0
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("manf_nm")
                dv1.Rows(rw).Cells(2).Value = Format(ds.Tables(0).Rows(i).Item("co_disc"), "#######0.00")
                dv1.Rows(rw).Cells(3).Value = Format(ds.Tables(0).Rows(i).Item("tr_disc"), "#######0.00")
                dv1.Rows(rw).Cells(4).Value = ds.Tables(0).Rows(i).Item("manf_cd")
                rw += 1
            Next
            txtsl.Text = rw + 1
        End If
    End Sub

#Region "cmenu"

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
        Me.Text = "Company Wise Discount Master Entry Screen . . ."
        cmbparty.Enabled = True
        dv.Visible = False
        cmbparty.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Company Wise Discount Master Modification Screen . . ."
            cmbparty.Enabled = False
            slno = dv.SelectedRows(0).Cells(3).Value
            Me.dv_edit(slno)
            dv.Visible = False
            cmbcompany.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        'If dv.RowCount <> 0 Then
        '    If usr_tp = "A" Or usr_tp = "D" Then
        '        bkcd = dv.SelectedRows(0).Cells(4).Value
        '        cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        '        Start1()
        '        If cnfr = vbYes Then
        '            Dim ds As DataSet = get_dataset("SELECT book_cd FROM bk_iss2 WHERE book_cd=" & Val(bkcd) & "")
        '            If ds.Tables(0).Rows.Count <> 0 Then
        '                MessageBox.Show("Sorry You Can Not Delete This Book", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                Exit Sub
        '            End If
        '            Dim ds1 As DataSet = get_dataset("SELECT book_cd FROM bk_pur2 WHERE book_cd=" & Val(bkcd) & "")
        '            If ds1.Tables(0).Rows.Count <> 0 Then
        '                MessageBox.Show("Sorry You Can Not Delete This Book", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                Exit Sub
        '            End If
        '            Dim ds2 As DataSet = get_dataset("SELECT book_cd FROM bk_rej2 WHERE book_cd=" & Val(bkcd) & "")
        '            If ds2.Tables(0).Rows.Count <> 0 Then
        '                MessageBox.Show("Sorry You Can Not Delete This Book", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                Exit Sub
        '            End If
        '            SQLInsert("DELETE FROM book1 WHERE book_cd=" & Val(bkcd) & "")
        '            SQLInsert("DELETE FROM book2 WHERE book_cd=" & Val(bkcd) & "")
        '            MessageBox.Show("Record Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        End If
        '    End If
        'Else
        '    MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        'Close1()
        'Me.dv_disp()
    End Sub

#End Region

   
End Class
