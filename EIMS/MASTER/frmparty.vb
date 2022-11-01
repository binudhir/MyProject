Imports vb = Microsoft.VisualBasic
Public Class frmparty
    Dim comd As String

    Private Sub frmparty_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuParty.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmparty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmparty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuParty.Enabled = False
        usrprmsn("mnuCountry", cmnuadd, cmnuedit, cmenudel, cmenuview)
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmparty_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Party/Head Of A/c Master Entry Screen . . ."
        txtscrl.Text = ""
        txtprtnm.Text = ""
        txtperson.Text = ""
        txtadd1.Text = ""
        txtcont1.Text = ""
        txtcont2.Text = ""
        txtmailid.Text = ""
        txtopbl.Text = "0.00"
        cmbactp.Text = ""
        txtregno.Text = ""
        txtactp.Text = ""
        cmblock.SelectedIndex = 0
        cmbbltp.SelectedIndex = 0
        cmbsms.SelectedIndex = 0
        cmbmail.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(prt_code) as 'Max' FROM party")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtprtnm.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, cmdview.Click
        Me.dv_disp()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregno.Enter, txtprtnm.Enter, txtperson.Enter, txtopbl.Enter, txtcont2.Enter, txtcont1.Enter, txtadd1.Enter, cmbsms.Enter, cmbmail.Enter, cmblock.Enter, cmbbltp.Enter, cmbactp.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregno.Leave, txtprtnm.Leave, txtperson.Leave, txtopbl.Leave, txtcont2.Leave, txtcont1.Leave, txtadd1.Leave, cmbsms.Leave, cmbmail.Leave, cmblock.Leave, cmbbltp.Leave, cmbactp.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

        sender.text = UCase(sender.text)
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub txtunvnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprtnm.KeyPress
        key(txtperson, e)
        SPKey(e)
    End Sub

    Private Sub txtperson_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtperson.KeyPress
        key(txtadd1, e)
        SPKey(e)
    End Sub

    'Private Sub txtadd1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd1.KeyPress
    '    key(txtcont1, e)
    '    SPKey(e)
    'End Sub

    Private Sub txtcont1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont1.KeyPress
        key(txtcont2, e)
        NUM(e)
    End Sub

    Private Sub txtcont2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont2.KeyPress
        key(txtmailid, e)
        NUM(e)
    End Sub

    Private Sub cmbdist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbactp.KeyPress
        key(txtopbl, e)
        SPKey(e)
    End Sub

    Private Sub txtzip_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtregno.KeyPress
        key(cmblock, e)
        NUM(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub

    Private Sub txtmailid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmailid.KeyPress
        key(cmbactp, e)
        SPKey(e)
    End Sub

    Private Sub cmbmail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbmail.KeyPress
        key(cmbsms, e)
    End Sub

    Private Sub cmbsms_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbsms.KeyPress
        key(cmbactp, e)
    End Sub

    Private Sub txtopbl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtopbl.KeyPress
        key(cmbbltp, e)
    End Sub

    Private Sub cmbbltp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbltp.KeyPress
        key(txtregno, e)
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Add"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtprtnm.Text) = "" Then
            MessageBox.Show("Please Provide A Party Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtprtnm.Focus()
            Exit Sub
        End If
        If Trim(txtperson.Text) = "" Then
            MessageBox.Show("The Contact Person Field Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtperson.Focus()
            Exit Sub
        End If
        If Trim(cmbactp.Text) = "" Then
            MessageBox.Show("Please Select A Account Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbactp.Focus()
            Exit Sub
        End If
        Me.unv_save()
    End Sub

    Private Sub unv_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(prt_code) as 'Max' FROM party")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                opbl = txtopbl.Text
                If cmbbltp.Text = "Dr." Then
                    opbl = Val(txtopbl.Text) * (-1)
                End If
                SQLInsert("INSERT INTO party (prt_code,pname,per_nm,add1,add2,cont1,cont2,prt_type,op_bal,lst_no,rec_lock," & _
                          "cr_amt,dr_amt,cl_bal,auto_sms,auto_mail,email_id,cl_amt) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(txtprtnm.Text) & "','" & Trim(txtperson.Text) & "','" & Trim(txtadd1.Text) & "','" & _
                          Trim(txtadd1.Text) & "','" & Trim(txtcont1.Text) & "','" & Trim(txtcont2.Text) & "','" & _
                          Trim(txtactp.Text) & "'," & Val(opbl) & ",'" & Trim(txtregno.Text) & "','" & _
                          vb.Left(cmblock.Text, 1) & "',0,0," & Val(opbl) & ",'" & vb.Left(cmbsms.Text, 1) & "','" & _
                          vb.Left(cmbsms.Text, 1) & "','" & Trim(txtmailid.Text) & "'," & Val(opbl) & ")")
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
                opbl = txtopbl.Text
                If cmbbltp.Text = "Dr." Then
                    opbl = Val(txtopbl.Text) * (-1)
                End If
                Dim ds As DataSet = get_dataset("SELECT prt_code FROM party WHERE prt_code=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE party SET pname='" & Trim(txtprtnm.Text) & "',email_id='" & _
                          Trim(txtmailid.Text) & "',per_nm='" & Trim(txtperson.Text) & "',cont1='" & _
                          Trim(txtcont1.Text) & "',cont2='" & Trim(txtcont2.Text) & "',add1='" & _
                          Trim(txtadd1.Text) & "',prt_type='" & Trim(txtactp.Text) & "'," & "lst_no='" & _
                          Trim(txtregno.Text) & "' ,rec_lock='" & vb.Left(cmblock.Text, 1) & "',auto_sms='" & _
                          vb.Left(cmbsms.Text, 1) & "',auto_mail='" & vb.Left(cmbmail.Text, 1) & "',op_bal=" & _
                          Val(opbl) & " WHERE prt_code =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY  pname) AS 'Sl.', party.pname AS 'Party Name', party.add1 AS 'Address', party.cont1 AS 'Contact', prttype.pt_name AS 'Party Type', party.prt_code, party.rec_lock FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type ORDER BY party.pname ")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(5).Visible = False
            dv.Columns(6).Visible = False
            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(6).Value
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
        Dim dsedit As DataSet = get_dataset("SELECT prttype.pt_name, party.* FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type WHERE party.prt_code=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtprtnm.Text = dsedit.Tables(0).Rows(0).Item("pname")
            txtmailid.Text = dsedit.Tables(0).Rows(0).Item("email_id")
            txtperson.Text = dsedit.Tables(0).Rows(0).Item("per_nm")
            txtadd1.Text = dsedit.Tables(0).Rows(0).Item("add1")
            txtcont1.Text = dsedit.Tables(0).Rows(0).Item("cont1")
            txtcont2.Text = dsedit.Tables(0).Rows(0).Item("cont2")
            txtregno.Text = dsedit.Tables(0).Rows(0).Item("lst_no")
            cmbactp.Text = dsedit.Tables(0).Rows(0).Item("pt_name")
            txtactp.Text = dsedit.Tables(0).Rows(0).Item("prt_type")
            txtopbl.Text = Format(dsedit.Tables(0).Rows(0).Item("op_bal"), "#####0.00")
            If Val(txtopbl.Text) < 0 Then
                txtopbl.Text = Format(dsedit.Tables(0).Rows(0).Item("op_bal") * (-1), "#####0.00")
                cmbbltp.SelectedIndex = 1
            Else
                txtopbl.Text = Format(dsedit.Tables(0).Rows(0).Item("op_bal"), "#####0.00")
                cmbbltp.SelectedIndex = 0
            End If
            If dsedit.Tables(0).Rows(0).Item("auto_mail") = "Y" Then
                cmbmail.SelectedIndex = 1
            Else
                cmbmail.SelectedIndex = 0
            End If
            If dsedit.Tables(0).Rows(0).Item("auto_sms") = "Y" Then
                cmbsms.SelectedIndex = 1
            Else
                cmbsms.SelectedIndex = 0
            End If
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
                cmblock.SelectedIndex = 1
            Else
                cmblock.SelectedIndex = 0
            End If
        End If
        Close1()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Add"
        Me.Text = "Party/Head Of A/c Master Entry Screen . . ."
        dv.Visible = False
        txtprtnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Party/Head Of A/c Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(5).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtprtnm.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            'If usr_tp = "A" Or usr_tp = "D" Then
            slno = dv.SelectedRows(0).Cells(5).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT prt_code FROM party WHERE prt_code=" & Val(slno) & "")
                Dim ds1 As DataSet
                If ds.Tables(0).Rows.Count <> 0 Then
                    ds1 = get_dataset("SELECT prt_code FROM purch1 WHERE prt_code=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    ds1.Tables.Clear()
                    ds1 = get_dataset("SELECT prt_code FROM pret1 WHERE prt_code=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    ds1.Tables.Clear()
                    ds1 = get_dataset("SELECT prt_code FROM porder1 WHERE prt_code=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    ds1.Tables.Clear()
                    ds1 = get_dataset("SELECT prt_code FROM voucp_coll WHERE prt_code=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    ds1.Tables.Clear()
                    ds1 = get_dataset("SELECT prt_code FROM voucr_coll WHERE prt_code=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    ds1.Tables.Clear()
                    ds1 = get_dataset("SELECT by_code FROM voucp_coll WHERE by_code=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    ds1.Tables.Clear()
                    ds1 = get_dataset("SELECT by_code FROM voucr_coll WHERE by_code=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    ds1.Tables.Clear()
                    ds1 = get_dataset("SELECT prt_code FROM jrn2 WHERE prt_code=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    ds1.Tables.Clear()
                    ds1 = get_dataset("SELECT prt_code FROM jrn2 WHERE prt_code=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    ds1.Tables.Clear()
                    ds1 = get_dataset("SELECT prt_code FROM bk_pur1 WHERE prt_code=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    ds1.Tables.Clear()
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM party WHERE prt_code =" & Val(slno) & "")
                        MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.dv_disp()
                    Else
                        MessageBox.Show("Sorry You Can't Delete The Group It Has Been Already Used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                Close1()
            End If
            'Else
            '    MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        End If
    End Sub

    Private Sub cmbdist_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbactp.GotFocus
        populate(cmbactp, "SELECT pt_name FROM prttype ORDER BY pt_name")
    End Sub

    Private Sub cmbdist_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbactp.LostFocus
        cmbactp.Height = 21
    End Sub

    Private Sub cmbdist_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbactp.Validated
        vdated(txtactp, "SELECT prt_type FROM prttype WHERE pt_name='" & Trim(cmbactp.Text) & "'")
    End Sub

    Private Sub cmbdist_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbactp.Validating
        vdating(cmbactp, "SELECT pt_name FROM prttype WHERE pt_name='" & Trim(cmbactp.Text) & "'", "Please Select A Valid Account Type.")
    End Sub

  
    Private Sub txtopbl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtopbl.GotFocus
        If Val(txtopbl.Text) = 0 Then
            txtopbl.Text = ""
        End If
    End Sub

    Private Sub txtopbl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtopbl.LostFocus
        txtopbl.Text = Format(Val(txtopbl.Text), "######0.00")
    End Sub

    Private Sub txtmailid_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmailid.Enter
        txtmailid.ForeColor = Color.Blue
        txtmailid.BackColor = Color.LavenderBlush
        txtmailid.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Bold)
    End Sub

    Private Sub txtmailid_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmailid.Leave
        txtmailid.ForeColor = Color.Black
        txtmailid.BackColor = Color.White
        txtmailid.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Regular)
    End Sub

    Private Sub txtmailid_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmailid.Validating
        If Trim(txtmailid.Text) <> "" Then
            If txtmailid.Text.IndexOf("@") = -1 OrElse txtmailid.Text.IndexOf(".") = -1 Then
                e.Cancel = True
                MessageBox.Show("You Have Enter An Invalid Mail ID.Please Enter A Valid Email ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtmailid.Focus()
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub mnuexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexport.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            btnsave.Enabled = False
            Me.Text = "Party Master View Screen . . ."
            slno = dv.SelectedRows(0).Cells(5).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtprtnm.Focus()
        End If
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        prtnm = InputBox("Enter The Party Name.", "Search Box...", Nothing)
        If (prtnm Is Nothing OrElse prtnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY  pname) AS 'Sl.', party.pname AS 'Party Name', party.add1 AS 'Address', party.cont1 AS 'Contact', prttype.pt_name AS 'Party Type', party.prt_code, party.rec_lock FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type WHERE (party.pname LIKE'" & prtnm & "%') ORDER BY party.pname ")
            dv.Columns.Clear()
            If dsedit.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dsedit.Tables(0)
                dv.Columns(5).Visible = False
                dv.Columns(6).Visible = False
                For i As Integer = 0 To dv.Rows.Count - 1
                    reclock = dv.Rows(i).Cells(6).Value
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
