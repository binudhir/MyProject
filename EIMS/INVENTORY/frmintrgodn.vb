Imports vb = Microsoft.VisualBasic
Public Class frmintrgodn
    Dim comd As String = "V"
    Dim used As String = "N"

    Private Sub frmintergodown_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuintrgdn.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmintergodown_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmintergodown_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuintrgdn.Enabled = False
        usrprmsn("mnuintrgdn", cmnuadd, cmnuedit, cmenudel, cmenuview)
        comd = swapprmsn("mnuintrgdn", comd)
        Me.clr()
    End Sub

    Private Sub frmintergodown_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black
        End If
    End Sub

    Private Sub clr()
        dv1.Rows.Clear()
        txtref.Text = "X"
        txtsl.Text = "1"
        txtitcd.Text = ""
        cmbgodfrom.Text = ""
        cmbgodto.Text = ""
        cmbname.Text = ""
        cmbgodfrom.Enabled = True
        If comd = "E" Then
            Me.Text = "Inter Godown Transfer Entry Screen...."
            Dim ds As DataSet = get_dataset("SELECT max(ig_sl) as 'Max' FROM ig1")
            txtscroll.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            btnsave.Text = "Save"
        ElseIf comd = "M" Then
            Me.Text = "Inter Godown Transfer Modification Screen...."
            txtscroll.Text = ""
            cmbgodfrom.Enabled = False
            btnsave.Text = "Modify"
        ElseIf comd = "D" Then
            Me.Text = "Inter Godown Transfer Deletion Screen...."
            txtscroll.Text = ""
            btnsave.Text = "Delete"
        Else
            Me.Text = "Inter Godown Transfer View Screen...."
            txtscroll.Text = ""
            btnsave.Text = "View"
        End If
        Me.clr1()
    End Sub

    Private Sub clr1()
        txtitcd.Text = ""
        cmbname.Text = ""
    End Sub

#Region "Enter Leave"
    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsl.Enter, txtscroll.Enter, txtref.Enter, dttrans.Enter, dtref.Enter, cmbname.Enter, cmbgodto.Enter, cmbgodfrom.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsl.Leave, txtscroll.Leave, txtref.Leave, dttrans.Leave, dtref.Leave, cmbname.Leave, cmbgodto.Leave, cmbgodfrom.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnnext_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnref.MouseEnter, btnnext.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnnext_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnref.MouseLeave, btnnext.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "KeyPress"

    Private Sub txtscroll_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtscroll.KeyPress
        key(dttrans, e)
        NUM(e)
    End Sub

    Private Sub dttrans_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dttrans.KeyPress
        key(txtref, e)
    End Sub

    Private Sub txtref_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtref.KeyPress
        key(dtref, e)
        SPKey(e)
    End Sub

    Private Sub dtref_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtref.KeyPress
        If cmbgodfrom.Enabled = True Then
            key(cmbgodfrom, e)
        Else
            key(cmbgodto, e)
        End If
    End Sub

    Private Sub cmbgodfrom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgodfrom.KeyPress
        key(cmbgodto, e)
        SPKey(e)
    End Sub

    Private Sub cmbgodto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgodto.KeyPress
        key(cmbname, e)
        SPKey(e)
    End Sub

    Private Sub cmbname_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbname.KeyPress
        If Trim(cmbname.Text) <> "" Then
            key(btnnext, e)
        Else
            key(btnsave, e)
        End If
        SPKey(e)
    End Sub

#End Region

#Region "Got/LostFocus"
    Private Sub txtref_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtref.GotFocus
        If txtref.Text = "X" Then
            txtref.Text = ""
        End If
    End Sub

    Private Sub txtref_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtref.LostFocus
        If txtref.Text = "" Then
            txtref.Text = "X"
        End If
    End Sub

    Private Sub cmbgodfrom_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodfrom.GotFocus
        cmbgodfrom.Height = 100
        populate(cmbgodfrom, "SELECT godnm FROM godown WHERE rec_lock='N' ORDER BY godnm")
    End Sub

    Private Sub cmbgodfrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodfrom.LostFocus
        cmbgodfrom.Height = 21
    End Sub

    Private Sub cmbgodto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodto.GotFocus
        cmbgodto.Height = 100
        populate(cmbgodto, "SELECT godnm FROM godown WHERE rec_lock='N' ORDER BY godnm")
    End Sub

    Private Sub cmbgodto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodto.LostFocus
        cmbgodto.Height = 21
    End Sub
    Private Sub cmbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.GotFocus
        txtitcd.Text = ""
        cmbname.Height = 100
        populate(cmbname, "SELECT it_name FROM item WHERE (rec_lock = 'N') AND (godsl =" & Val(txtgodfrom.Text) & " ) ORDER BY it_name")
    End Sub

    Private Sub cmbname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.LostFocus
        cmbname.Height = 21
    End Sub

#End Region

#Region "Validated / Validating"

    Private Sub cmbgodfrom_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbgodfrom.Validated
        vdated(txtgodfrom, "SELECT godsl FROM godown WHERE (godnm = '" & Trim(cmbgodfrom.Text) & "')")
    End Sub

    Private Sub cmbgodfrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgodfrom.Validating
        vdating(cmbgodfrom, "SELECT godnm FROM godown WHERE (godnm = '" & Trim(cmbgodfrom.Text) & "')", "Please Select a Valid Godown Name.")
    End Sub

    Private Sub cmbgodto_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbgodto.Validated
        vdated(txtgodto, "SELECT godsl FROM godown WHERE (godnm = '" & Trim(cmbgodto.Text) & "')")
    End Sub

    Private Sub cmbgodto_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgodto.Validating
        vdating(cmbgodto, "SELECT godnm FROM godown WHERE (godnm = '" & Trim(cmbgodto.Text) & "')", "Please Select a Valid Godown Name.")
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        vdated(txtitcd, "SELECT it_cd FROM item WHERE (it_name = '" & Trim(cmbname.Text) & "')")
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        vdating(cmbname, "SELECT it_name FROM item WHERE (it_name = '" & Trim(cmbname.Text) & "')", "Please Select a Valid Product Name.")
    End Sub

#End Region

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
    End Sub

    Private Sub btninter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninter.Click
        'If comd = "E" Then
        '    comd = "M"
        'ElseIf comd = "M" Then
        '    comd = "D"
        'Else
        '    comd = "E"
        'End If
        comd = swapprmsn("mnuintrgdn", comd)
        Me.clr()
    End Sub

    Private Sub btnnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnext.Click
        If cmbname.Text = "" Then
            MessageBox.Show("Please Enter A Valid Item Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbname.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                x = dv1.Rows(i).Cells(2).Value
                If Val(txtitcd.Text) = x Then
                    MessageBox.Show("Sorry The Data Should Not Be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbname.Focus()
                    Exit Sub
                End If
            Next
        End If
        sl1 = Val(txtsl.Text)
        dv1.Rows.Add()
        dv1.Rows(sl1 - 1).Cells(0).Value = sl1
        dv1.Rows(sl1 - 1).Cells(1).Value = cmbname.Text
        dv1.Rows(sl1 - 1).Cells(2).Value = txtitcd.Text
        sl1 += 1
        txtsl.Text = sl1
        cmbname.Focus()
        Me.clr1()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Val(txtscroll.Text) = 0 Then
            MessageBox.Show("Sorry The Scroll No Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtscroll.Focus()
            Exit Sub
        End If
        If Val(txtgodfrom.Text) = Val(txtgodto.Text) Then
            MessageBox.Show("Sorry Godown From & Godown To Should Not Be Same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbgodto.Focus()
            Exit Sub
        End If
        If cmbgodfrom.Text = "" Or Val(txtgodfrom.Text) = 0 Then
            MessageBox.Show("The Base Godown Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbgodfrom.Focus()
            Exit Sub
        End If
        If cmbgodto.Text = "" Or Val(txtgodto.Text) = 0 Then
            MessageBox.Show("The Destination Godown Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbgodto.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count = 0 Then
            MessageBox.Show("Please Transfer Atleast One Item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbname.Focus()
            Exit Sub
        End If
        Me.trans_save()
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Me.dv_disp()
    End Sub
#End Region
    Private Sub trans_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT MAX(ig_sl) AS 'MAX' FROM ig1")
                txtscroll.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO ig1 (ig_sl,ig_dt,ig_ref,ref_dt,gdsl_frm,gdsl_to,usr_ent,ent_date,usr_mod," & _
                          "mod_date,rec_lock,pfx,usedby) VALUES (" & Val(txtscroll.Text) & ",'" & _
                          Format(dttrans.Value, "dd/MMM/yyyy") & "','" & Trim(txtref.Text) & "','" & _
                          Format(dtref.Value, "dd/MMM/yyyy") & "'," & Val(txtgodfrom.Text) & "," & _
                          Val(txtgodto.Text) & "," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & _
                          Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N','N','N')")

                Me.dv_save()
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'cnfr = MessageBox.Show("Are You Sure The Printer is Ready To Print The Bill.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If cnfr = vbYes Then
                '    Call colrec_print(Val(txtordno.Text))
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
                Dim ds As DataSet = get_dataset("SELECT ig_sl FROM ig1 WHERE ig_sl=" & Val(txtscroll.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE ig1 SET ig_dt='" & Format(dttrans.Value, "dd/MMM/yyyy") & "',ig_ref='" & _
                          Trim(txtref.Text) & "',ref_dt='" & Format(dtref.Value, "dd/MMM/yyyy") & "',gdsl_frm=" & _
                          Val(txtgodfrom.Text) & ",gdsl_to= " & Val(txtgodto.Text) & ",usr_mod=" & _
                         Val(usr_sl) & ",mod_date='" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "' WHERE ig_sl =" & _
                         Val(txtscroll.Text) & "")
                    Me.dv_save()
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                End If
                Close1()
            End If
        ElseIf comd = "D" Then
            'If usr_tp <> "A" Or usr_tp <> "D" Then
            '    MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Call del1(txtscroll.Text)
                Call del2(txtscroll.Text)
                txtscroll.Focus()
            End If
        End If
    End Sub

    Private Sub dv_save()
        If dv1.RowCount <> 0 Then
            If comd = "M" Then
                Call del2(txtscroll.Text)
            End If
            For i As Integer = 0 To dv1.RowCount - 1
                itcd = Val(dv1.Rows(i).Cells(2).Value)
                Dim ds1 As DataSet = get_dataset("SELECT max(ig_rsl) as 'Max' FROM ig2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO ig2(ig_rsl,ig_sl,ig_dt,ref_dt,gdsl_frm,gdsl_to,it_cd,it_qty,unt,mul_rt,pfx) VALUES (" & _
                          Val(mxno) & "," & Val(txtscroll.Text) & ",'" & Format(dttrans.Value, "dd/MMM/yyyy") & "','" & _
                          Format(dtref.Value, "dd/MMM/yyyy") & "'," & Val(txtgodfrom.Text) & "," & Val(txtgodto.Text) & "," & itcd & _
                          ",0,'N',1,'AA')")
                SQLInsert("UPDATE item SET godsl = " & Val(txtgodto.Text) & " WHERE it_cd = " & itcd & " ")
            Next
        End If
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT ig1.*, godown.godnm,(SELECT godnm FROM godown WHERE godown.godsl=ig1.gdsl_to) AS godnm1 FROM ig1 LEFT OUTER JOIN godown ON ig1.gdsl_frm = godown.godsl WHERE ig1.ig_sl=1")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscroll.Text = slno
            txtref.Text = dsedit.Tables(0).Rows(0).Item("ig_ref")
            dttrans.Value = dsedit.Tables(0).Rows(0).Item("ig_dt")
            dtref.Value = dsedit.Tables(0).Rows(0).Item("ref_dt")
            txtgodfrom.Text = dsedit.Tables(0).Rows(0).Item("gdsl_frm")
            txtgodto.Text = dsedit.Tables(0).Rows(0).Item("gdsl_to")
            cmbgodfrom.Text = dsedit.Tables(0).Rows(0).Item("godnm")
            cmbgodto.Text = dsedit.Tables(0).Rows(0).Item("godnm1")
            Me.dv_view()
        End If
        Close1()
    End Sub

    Private Sub dv_view()
        Dim ds As DataSet = get_dataset("SELECT ig2.it_cd, item.it_name FROM ig2 LEFT OUTER JOIN item ON ig2.it_cd = item.it_cd WHERE (ig2.ig_sl = " & Val(txtscroll.Text) & ") ORDER BY ig2.ig_rsl")
        rw = 0
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("it_name")
                dv1.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("it_cd")
                rw += 1
            Next
            txtsl.Text = rw + 1
        End If
    End Sub

    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT ig1.ig_sl AS 'Sl.', ig1.ig_dt AS 'Trans Date', godown.godnm AS 'Godown From',(SELECT godnm FROM godown WHERE godown.godsl=ig1.gdsl_to) AS 'Godown To' FROM ig1 LEFT OUTER JOIN godown ON ig1.gdsl_frm = godown.godsl ORDER BY ig1.ig_sl")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            For i As Integer = 0 To dv1.Rows.Count - 1
                dv.Columns(2).Width = 300
            Next
        End If
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

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
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        comd = "E"
        Me.clr()
        dv.Visible = False
        txtscroll.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Inter Godown Transfer Modification Screen...."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
        End If
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            comd = "V"
            btnsave.Text = "View"
            Me.Text = "Inter Godown Transfer View Screen...."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
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

    Private Sub txtscroll_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtscroll.Validated
        If comd <> "E" Then
            If Val(txtscroll.Text) <> 0 Then
                Dim ds As DataSet = get_dataset("SELECT ig_sl FROM ig1 WHERE (ig_sl = '" & Trim(txtscroll.Text) & "')")
                If ds.Tables(0).Rows.Count <> 0 Then
                    Me.dv_edit(txtscroll.Text)
                Else
                    MessageBox.Show("Please Select a Valid Scroll No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtscroll.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtscroll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscroll.GotFocus
        If comd <> "E" Then
            Me.clr()
        End If
    End Sub

    'Delete data from Table1/Primary Table
    Private Sub del1(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT ig_sl FROM ig1 WHERE ig_sl=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            SQLInsert("DELETE FROM ig1 WHERE ig_sl=" & Val(code) & "")
        End If
    End Sub

    'Delete data from Table2/Secondary Table
    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT ig_rsl,gdsl_frm,it_cd FROM ig2 WHERE ig_sl=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                posl = dsdel.Tables(0).Rows(i).Item(0)
                gdfsl = dsdel.Tables(0).Rows(i).Item(1)
                itcd = dsdel.Tables(0).Rows(i).Item(2)
                SQLInsert("UPDATE ITEM SET godsl=" & Val(gdfsl) & " WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("DELETE FROM ig2 WHERE ig_rsl=" & Val(posl) & "")
            Next
        End If
    End Sub

    Private Sub mnuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexpert.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        prtnm = InputBox("Enter Name Of The Godown From.", "Search Box...", Nothing)
        If (prtnm Is Nothing OrElse prtnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT ig1.ig_sl AS 'Sl.', ig1.ig_dt AS 'Trans Date', godown.godnm AS 'Godown From',(SELECT godnm FROM godown WHERE godown.godsl=ig1.gdsl_to) AS 'Godown To' FROM ig1 LEFT OUTER JOIN godown ON ig1.gdsl_frm = godown.godsl WHERE (godown.godnm LIKE'" & prtnm & "%') ORDER BY ig1.ig_sl")
            dv.Columns.Clear()
            If dsedit.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dsedit.Tables(0)
                For i As Integer = 0 To dv1.Rows.Count - 1
                    dv.Columns(2).Width = 300
                Next
            End If
            dv.Visible = True
            dv.Dock = DockStyle.Fill
        End If
    End Sub
End Class
