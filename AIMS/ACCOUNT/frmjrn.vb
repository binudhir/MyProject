Imports vb = Microsoft.VisualBasic
Public Class frmjrn
    Dim comd As String

    Private Sub frmjrn_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuJrn_Vouc.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmjrn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmjrn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuJrn_Vouc.Enabled = False
        Me.clr()
        Me.dv_disp()
        jrdt.Value = sys_date
    End Sub

    Private Sub frmjrn_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Journal Voucher Entry Screen . . ."
        lbladdress.Text = ""
        lblcont.Text = ""
        lbltype.Text = ""
        lblbalnc.Text = ""
        lblregno.Text = ""
        txtsl.Text = 1
        txtsl1.Text = 1
        txtjrno.Text = ""
        txtprtcd.Text = 0
        txtprtcd1.Text = 0
        cmbpname.Text = ""
        cmbpname1.Text = ""
        txtdramt.Text = "0.00"
        txtcramt.Text = "0.00"
        txtdrtot.Text = "0.00"
        txtcrtot.Text = "0.00"
        cmbdesc1.Text = ""
        cmbdesc2.Text = ""
        cmbdesc3.Text = ""
        chckclrdata.Checked = False
        cmblock.SelectedIndex = 0
        dvdr.Rows.Clear()
        dvcr.Rows.Clear()

        Dim ds As DataSet = get_dataset("SELECT max(jr_no) as 'Max' FROM jrn1")
        txtjrno.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtjrno.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtjrno.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, cmdview.Click
        Me.dv_disp()
    End Sub

    Private Sub txtvnm_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtjrno.Enter, txtdramt.Enter, cmbdesc3.Enter, cmbdesc2.Enter, cmbdesc1.Enter, cmbpname.Enter, cmbpname1.Enter, txtcramt.Enter, cmblock.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub txtvnm_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtjrno.Leave, txtdramt.Leave, cmbdesc3.Leave, cmbdesc2.Leave, cmbdesc1.Leave, cmbpname.Leave, cmbpname1.Leave, txtcramt.Leave, cmblock.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

        sender.text = UCase(sender.text)
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseEnter, btnsave.MouseEnter, btns1.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter, btnnxt.MouseEnter, btnnxt1.MouseEnter, btnclr.MouseEnter, btnclr1.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseLeave, btnsave.MouseLeave, btns1.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave, btnnxt.MouseLeave, btnnxt1.MouseLeave, btnclr.MouseLeave, btnclr1.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub txtjrno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtjrno.KeyPress
        key(jrdt, e)
        NUM(e)
    End Sub

    Private Sub jrdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles jrdt.KeyPress
        key(cmbpname, e)
    End Sub

    Private Sub cmbpname_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpname.KeyPress
        If cmbpname.Text <> "" Then
            key(txtdramt, e)
        Else
            key(cmbpname1, e)
        End If
    End Sub

    Private Sub txtdramt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdramt.KeyPress
        key(btnnxt, e)
        NUM1(e)
    End Sub

    Private Sub cmbpname1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpname1.KeyPress
        If cmbpname1.Text <> "" Then
            key(txtcramt, e)
        Else
            key(cmbdesc1, e)
        End If
    End Sub

    Private Sub txtcramt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcramt.KeyPress
        key(btnnxt1, e)
        NUM1(e)
    End Sub

    Private Sub txtammnt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdramt.GotFocus, txtcramt.GotFocus
        If Val(sender.Text) = 0 Then
            sender.Text = ""
        End If
    End Sub

    Private Sub txtammnt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdramt.LostFocus, txtcramt.LostFocus
        sender.Text = Format(Val(sender.Text), "######0.00")
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Val(txtjrno.Text) = 0 Then
            MessageBox.Show("Sorry The Voucher No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtdramt.Focus()
            Exit Sub
        End If
        If Val(txtcrtot.Text) <> 0 Or Val(txtdrtot.Text) <> 0 Then
            If Val(txtcrtot.Text) < Val(txtdrtot.Text) Then
                MessageBox.Show("The Credit Amount Must Be Equal With Debit Amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtcramt.Focus()
                Exit Sub
            ElseIf Val(txtcrtot.Text) > Val(txtdrtot.Text) Then
                MessageBox.Show("The Debit Amount Must Be Equal With Credit Amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtdramt.Focus()
                Exit Sub
            End If
        End If
        If Trim(cmbdesc1.Text) = "" And Trim(cmbdesc2.Text) = "" And Trim(cmbdesc3.Text) = "" Then
            MessageBox.Show("Please Provide At Least One Voucher Details.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbdesc1.Focus()
            Exit Sub
        End If
        Me.jrn_save()
    End Sub

    Private Sub jrn_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(jr_no) as 'Max' FROM jrn1")
                txtjrno.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtjrno.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO jrn1 (jr_no,jr_dt,to_amt,desc1,desc2,desc3,usr_ent,ent_date,usr_mod,mod_date,rec_lock) VALUES (" & _
                          Val(txtjrno.Text) & ",'" & Format(jrdt.Value, "dd/MMM/yyyy") & "'," & Val(txtcrtot.Text) & ",'" & _
                          Trim(cmbdesc1.Text) & "','" & Trim(cmbdesc2.Text) & "','" & Trim(cmbdesc3.Text) & "'," & Val(usr_sl) & ",'" & _
                          Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','" & _
                          vb.Left(cmblock.Text, 1) & "')")
                Me.dv_save()
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Close1()
            End If
        Else
            If usr_tp = "O" Then
                MessageBox.Show("You Are Not Authorised to Modify The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT jr_no FROM jrn1 WHERE jr_no=" & Val(txtjrno.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE jrn1 SET jr_dt='" & Format(jrdt.Value, "dd/MMM/yyyy") & "',to_amt=" & Val(txtcrtot.Text) & ",desc1='" & _
                              Trim(cmbdesc1.Text) & "',desc2='" & Trim(cmbdesc2.Text) & "',desc3='" & Trim(cmbdesc3.Text) & "',usr_mod=" & _
                              Val(usr_sl) & ",mod_date='" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "',rec_lock='" & vb.Left(cmblock.Text, 1) & "' WHERE jr_no =" & Val(txtjrno.Text) & "")
                    Me.dv_save()
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                    Me.dv_disp()
                End If
                Close1()
            End If
        End If
    End Sub

    Private Sub dv_save()
        If comd = "M" Then
            Me.del2(txtjrno.Text)
        End If
        If dvdr.RowCount <> 0 Then
            For i As Integer = 0 To dvdr.RowCount - 1
                dramt = dvdr.Rows(i).Cells(2).Value
                prtcd = dvdr.Rows(i).Cells(3).Value
                Dim ds1 As DataSet = get_dataset("SELECT max(jr_sl) as 'Max' FROM jrn2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO jrn2(jr_sl,jr_no,jr_dt,jr_type,prt_code,amt) VALUES (" & Val(mxno) & "," & _
                          Val(txtjrno.Text) & ",'" & Format(jrdt.Value, "dd/MMM/yyyy") & "','D'," & Val(prtcd) & "," & Val(dramt) & ")")
                SQLInsert("UPDATE party SET dr_amt=dr_amt + " & Val(dramt) & ",cl_amt=cl_amt - " & Val(dramt) & " WHERE prt_code=" & Val(prtcd) & "")
            Next
        End If
        If dvcr.RowCount <> 0 Then
            For i As Integer = 0 To dvcr.RowCount - 1
                cramt = dvcr.Rows(i).Cells(2).Value
                prtcd = dvcr.Rows(i).Cells(3).Value
                Dim ds1 As DataSet = get_dataset("SELECT max(jr_sl) as 'Max' FROM jrn2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO jrn2(jr_sl,jr_no,jr_dt,jr_type,prt_code,amt) VALUES (" & Val(mxno) & "," & _
                          Val(txtjrno.Text) & ",'" & Format(jrdt.Value, "dd/MMM/yyyy") & "','C'," & Val(prtcd) & "," & Val(cramt) & ")")
                SQLInsert("UPDATE party SET cr_amt=cr_amt + " & Val(cramt) & ",cl_amt=cl_amt + " & Val(cramt) & " WHERE prt_code=" & Val(prtcd) & "")
            Next
        End If
    End Sub

    Private Sub dv_disp()
        Start1()
        'Dim dsedit As DataSet = get_dataset("SELECT party.pname, jrn1.desc1,jrn1.rec_lock, jrn2.* FROM jrn2 RIGHT OUTER JOIN jrn1 ON jrn2.jr_no = jrn1.jr_no LEFT OUTER JOIN party ON jrn2.prt_code = party.prt_code ORDER BY jrn1.jr_no")
        Dim dsedit As DataSet = get_dataset("SELECT jrn2.jr_no AS 'Jr. No', CONVERT(VARCHAR,jrn2.jr_dt,103) AS 'Date', party.pname AS 'Party Head Of A/c Name',STR((CASE WHEN jr_type='C' THEN jrn2.amt END),10,2) AS 'Cr. Amt',STR((CASE WHEN jr_type='D' THEN jrn2.amt END),10,2) AS 'Dr. Amt', jrn1.desc1 AS 'Remarks', jrn1.rec_lock FROM jrn2 RIGHT OUTER JOIN jrn1 ON jrn2.jr_no = jrn1.jr_no LEFT OUTER JOIN party ON jrn2.prt_code = party.prt_code ORDER BY jrn1.jr_no")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(6).Visible = False
            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(6).Value
                If reclock = "Y" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
        End If
        'If dsedit.Tables(0).Rows.Count <> 0 Then
        '    Dim rw As Integer = 0
        '    For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
        '        dv.Rows.Add()
        '        dv.Rows(rw).Cells(0).Value = dsedit.Tables(0).Rows(i).Item("jr_no")
        '        dv.Rows(rw).Cells(1).Value = Format(dsedit.Tables(0).Rows(i).Item("jr_dt"), "dd/MM/yy")
        '        dv.Rows(rw).Cells(2).Value = dsedit.Tables(0).Rows(i).Item("pname")
        '        If dsedit.Tables(0).Rows(i).Item("jr_type") = "D" Then
        '            dv.Rows(rw).Cells(3).Value = Format(dsedit.Tables(0).Rows(i).Item("amt"), "######0.00")
        '            dv.Rows(rw).DefaultCellStyle.BackColor = Color.AliceBlue
        '            dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Blue
        '        Else
        '            dv.Rows(rw).Cells(4).Value = Format(dsedit.Tables(0).Rows(i).Item("amt"), "######0.00")
        '            dv.Rows(rw).DefaultCellStyle.BackColor = Color.White
        '            dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Black
        '        End If
        '        dv.Rows(rw).Cells(5).Value = dsedit.Tables(0).Rows(i).Item("desc1")
        '        If dsedit.Tables(0).Rows(i).Item("rec_lock") = "Y" Then
        '            dv.Rows(rw).DefaultCellStyle.BackColor = Color.Red
        '            dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Yellow
        '        End If
        '        rw = rw + 1
        '    Next
        'End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub drcr_view()
        Dim ds As DataSet = get_dataset("SELECT jrn2.*, party.pname FROM jrn2 LEFT OUTER JOIN party ON jrn2.prt_code = party.prt_code WHERE (jrn2.jr_no = " & Val(txtjrno.Text) & ") AND jrn2.jr_type='D'")
        rw = 0
        dvdr.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dvdr.Rows.Add()
                dvdr.Rows(rw).Cells(0).Value = i + 1
                dvdr.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("pname")
                dvdr.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("amt")
                dvdr.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("prt_code")
                rw += 1
            Next
            txtsl.Text = rw + 1
            Me.grandamt(dvdr, txtdrtot)
        End If

        Dim ds1 As DataSet = get_dataset("SELECT jrn2.*, party.pname FROM jrn2 LEFT OUTER JOIN party ON jrn2.prt_code = party.prt_code WHERE (jrn2.jr_no = " & Val(txtjrno.Text) & ") AND jrn2.jr_type='C'")
        rw = 0
        dvcr.Rows.Clear()
        If ds1.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                dvcr.Rows.Add()
                dvcr.Rows(rw).Cells(0).Value = i + 1
                dvcr.Rows(rw).Cells(1).Value = ds1.Tables(0).Rows(i).Item("pname")
                dvcr.Rows(rw).Cells(2).Value = ds1.Tables(0).Rows(i).Item("amt")
                dvcr.Rows(rw).Cells(3).Value = ds1.Tables(0).Rows(i).Item("prt_code")
                rw += 1
            Next
            txtsl1.Text = rw + 1
            Me.grandamt(dvcr, txtcrtot)
        End If
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT * FROM jrn1 WHERE jr_no=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtjrno.Text = slno
            jrdt.Value = dsedit.Tables(0).Rows(0).Item("jr_dt")
            cmbdesc1.Text = dsedit.Tables(0).Rows(0).Item("desc1")
            cmbdesc2.Text = dsedit.Tables(0).Rows(0).Item("desc2")
            cmbdesc3.Text = dsedit.Tables(0).Rows(0).Item("desc3")
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
                cmblock.SelectedIndex = 1
            Else
                cmblock.SelectedIndex = 0
            End If
            Me.drcr_view()
        End If
        Close1()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
        Me.Text = "Journal Voucher Entry Screen . . ."
        dv.Visible = False
        txtjrno.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Journal Voucher Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtjrno.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        If dv.RowCount <> 0 Then
            If usr_tp = "A" Or usr_tp = "D" Then
                slno = dv.SelectedRows(0).Cells(0).Value
                cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Start1()
                If cnfr = vbYes Then
                    Dim ds As DataSet = get_dataset("SELECT jr_no FROM jrn1 WHERE jr_no=" & Val(slno) & "")
                    If ds.Tables(0).Rows.Count <> 0 Then
                        Me.del2(slno)
                        SQLInsert("DELETE FROM jrn1 WHERE jr_no =" & Val(slno) & "")
                        MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.dv_disp()
                    End If
                End If
                Close1()
            Else
                MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT jr_sl,jr_type,amt,prt_code FROM jrn2 WHERE jr_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                jrsl = dsdel.Tables(0).Rows(i).Item(0)
                jrtp = dsdel.Tables(0).Rows(i).Item(1)
                amt = Val(dsdel.Tables(0).Rows(i).Item(2))
                prtcd = dsdel.Tables(0).Rows(i).Item(3)
                If jrtp = "D" Then
                    SQLInsert("UPDATE party SET dr_amt=dr_amt - " & Val(amt) & ",cl_amt=cl_amt + " & Val(amt) & " WHERE prt_code=" & Val(prtcd) & "")
                Else
                    SQLInsert("UPDATE party SET cr_amt=cr_amt - " & Val(amt) & ",cl_amt=cl_amt - " & Val(amt) & " WHERE prt_code=" & Val(prtcd) & "")
                End If
                SQLInsert("DELETE FROM jrn2 WHERE jr_sl=" & Val(jrsl) & "")
            Next
        End If
    End Sub


    Private Sub cmbpname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname.GotFocus
        txtprtcd.Text = 0
        lbladdress.Text = ""
        lblcont.Text = ""
        lbltype.Text = ""
        lblbalnc.Text = ""
        lblregno.Text = ""
        populate(cmbpname, "SELECT pname FROM party WHERE rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbpname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname.LostFocus
        cmbpname.Height = 21
    End Sub

    Private Sub cmbpname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname.Validated
        Dim ds As DataSet = get_dataset("SELECT party.prt_code,party.add1, party.cont1, party.cont2, prttype.pt_name, party.cl_amt, party.lst_no FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type WHERE party.pname='" & Trim(cmbpname.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtprtcd.Text = ds.Tables(0).Rows(0).Item("prt_code")
            lbladdress.Text = Trim(ds.Tables(0).Rows(0).Item("add1"))
            lblcont.Text = Trim(ds.Tables(0).Rows(0).Item("cont1"))
            lbltype.Text = Trim(ds.Tables(0).Rows(0).Item("pt_name"))
            clamt = Val(ds.Tables(0).Rows(0).Item("cl_amt"))
            If clamt < 0 Then
                lblbalnc.Text = Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
            Else
                lblbalnc.Text = Format(clamt, "#######0.00") & " " & "Cr."
            End If
            lblregno.Text = Trim(ds.Tables(0).Rows(0).Item("lst_no"))
        End If
    End Sub

    Private Sub cmbpname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbpname.Validating
        vdating(cmbpname, "SELECT pname FROM party WHERE rec_lock='N' AND pname='" & Trim(cmbpname.Text) & "'", "Please Select A Valid Party Head Of A/c Name.")
    End Sub

    Private Sub cmbpname1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname1.GotFocus
        txtprtcd.Text = 0
        lbladdress.Text = ""
        lblcont.Text = ""
        lbltype.Text = ""
        lblbalnc.Text = ""
        lblregno.Text = ""
        populate(cmbpname1, "SELECT pname FROM party WHERE rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbpname1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname1.LostFocus
        cmbpname1.Height = 21
    End Sub

    Private Sub cmbpname1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname1.Validated
        Dim ds As DataSet = get_dataset("SELECT party.prt_code,party.add1, party.cont1, party.cont2, prttype.pt_name, party.cl_amt, party.lst_no FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type WHERE party.pname='" & Trim(cmbpname1.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtprtcd1.Text = ds.Tables(0).Rows(0).Item("prt_code")
            lbladdress.Text = Trim(ds.Tables(0).Rows(0).Item("add1"))
            lblcont.Text = Trim(ds.Tables(0).Rows(0).Item("cont1"))
            lbltype.Text = Trim(ds.Tables(0).Rows(0).Item("pt_name"))
            clamt = Val(ds.Tables(0).Rows(0).Item("cl_amt"))
            If clamt < 0 Then
                lblbalnc.Text = Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
            Else
                lblbalnc.Text = Format(clamt, "#######0.00") & " " & "Cr."
            End If
            lblregno.Text = Trim(ds.Tables(0).Rows(0).Item("lst_no"))
            If Val(txtdrtot.Text) <> 0 Then
                txtcramt.Text = Format(Val(txtdrtot.Text) - Val(txtcrtot.Text), "#######0.00")
            End If
        End If
    End Sub

    Private Sub cmbpname1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbpname1.Validating
        vdating(cmbpname1, "SELECT pname FROM party WHERE rec_lock='N' AND pname='" & Trim(cmbpname1.Text) & "'", "Please Select A Valid Party Head Of A/c Name.")
    End Sub

    Private Sub cmbdesc1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesc1.GotFocus
        populate(cmbdesc1, "SELECT descr_nm FROM descr WHERE rec_lock='N' ORDER BY descr_nm")
    End Sub

    Private Sub cmbdesc1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesc1.LostFocus
        cmbdesc1.Height = 21
    End Sub

    Private Sub cmbdesc2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesc2.GotFocus
        populate(cmbdesc2, "SELECT descr_nm FROM descr WHERE rec_lock='N' ORDER BY descr_nm")
    End Sub

    Private Sub cmbdesc2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesc2.LostFocus
        cmbdesc2.Height = 21
    End Sub

    Private Sub cmbdesc3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesc3.GotFocus
        populate(cmbdesc3, "SELECT descr_nm FROM descr WHERE rec_lock='N' ORDER BY descr_nm")
    End Sub

    Private Sub cmbdesc3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesc3.LostFocus
        cmbdesc3.Height = 21
    End Sub

    Private Sub btns1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btns1.Click
        Dim ds1 As DataSet = get_dataset("SELECT descr_nm FROM descr WHERE descr_nm='" & Trim(cmbdesc1.Text) & "'")
        If ds1.Tables(0).Rows.Count = 0 Then
            Dim ds As DataSet = get_dataset("SELECT max(descr_cd) as 'Max' FROM descr")
            mxno = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    mxno = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            Start1()
            SQLInsert("INSERT INTO descr (descr_cd,descr_nm,rec_lock) VALUES (" & Val(mxno) & ",'" & _
                      Trim(cmbdesc1.Text) & "','N')")
            MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close1()
        End If
    End Sub

    Private Sub btns2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btns2.Click
        Dim ds1 As DataSet = get_dataset("SELECT descr_nm FROM descr WHERE descr_nm='" & Trim(cmbdesc2.Text) & "'")
        If ds1.Tables(0).Rows.Count = 0 Then
            Dim ds As DataSet = get_dataset("SELECT max(descr_cd) as 'Max' FROM descr")
            mxno = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    mxno = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            Start1()
            SQLInsert("INSERT INTO descr (descr_cd,descr_nm,rec_lock) VALUES (" & Val(mxno) & ",'" & _
                      Trim(cmbdesc2.Text) & "','N')")
            MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close1()
        End If
    End Sub

    Private Sub btns3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btns3.Click
        Dim ds1 As DataSet = get_dataset("SELECT descr_nm FROM descr WHERE descr_nm='" & Trim(cmbdesc3.Text) & "'")
        If ds1.Tables(0).Rows.Count = 0 Then
            Dim ds As DataSet = get_dataset("SELECT max(descr_cd) as 'Max' FROM descr")
            mxno = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    mxno = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            Start1()
            SQLInsert("INSERT INTO descr (descr_cd,descr_nm,rec_lock) VALUES (" & Val(mxno) & ",'" & _
                      Trim(cmbdesc3.Text) & "','N')")
            MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close1()
        End If
    End Sub

    Private Sub btnnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.Click
        If Trim(cmbpname.Text) = "" Or Val(txtprtcd.Text) = 0 Then
            MessageBox.Show("Please Provide A Party/Head Of A/c Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbpname.Focus()
            Exit Sub
        End If
        If Val(txtdramt.Text) = 0 Then
            MessageBox.Show("Sorry The Debit Amount Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtdramt.Focus()
            Exit Sub
        End If
        'If Val(txtcrtot.Text) <> 0 And Val(txtdrtot.Text) <> 0 Then
        '    If Val(txtcrtot.Text) <> Val(txtdrtot.Text) Then
        '        MessageBox.Show("Sorry The Debit Amount Should Be Equal To The Credit Amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        cmbpname.Focus()
        '        Exit Sub
        '    End If
        'End If
        If dvdr.Rows.Count <> 0 Then
            For i As Integer = 0 To dvdr.RowCount - 1
                x = dvdr.Rows(i).Cells(3).Value
                If Val(txtprtcd.Text) = x Then
                    MessageBox.Show("Sorry You Can't Select This Party Again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbpname.Focus()
                    Exit Sub
                End If
            Next
        End If
        If dvcr.Rows.Count <> 0 Then
            For i As Integer = 0 To dvcr.RowCount - 1
                x = dvcr.Rows(i).Cells(3).Value
                If Val(txtprtcd.Text) = x Then
                    MessageBox.Show("Sorry You Can't Select This Party Which is in Credit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbpname.Focus()
                    Exit Sub
                End If
            Next
        End If
        sl1 = Val(txtsl.Text)
        dvdr.Rows.Add()
        dvdr.Rows(sl1 - 1).Cells(0).Value = sl1
        dvdr.Rows(sl1 - 1).Cells(1).Value = cmbpname.Text
        dvdr.Rows(sl1 - 1).Cells(2).Value = txtdramt.Text
        dvdr.Rows(sl1 - 1).Cells(3).Value = txtprtcd.Text
        sl1 += 1
        Me.grandamt(dvdr, txtdrtot)
        txtsl.Text = sl1
        cmbpname.Focus()
        cmbpname.Text = ""
        txtdramt.Text = "0.00"

    End Sub

    Private Sub btnnxt1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt1.Click
        If Trim(cmbpname1.Text) = "" Or Val(txtprtcd1.Text) = 0 Then
            MessageBox.Show("Please Provide A Party/Head Of A/c Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbpname1.Focus()
            Exit Sub
        End If
        If Val(txtcramt.Text) = 0 Then
            MessageBox.Show("Sorry The Credit Amount Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtcramt.Focus()
            Exit Sub
        End If
        'If Val(txtcrtot.Text) <> 0 And Val(txtdrtot.Text) <> 0 Then
        '    If Val(txtcrtot.Text) <> Val(txtdrtot.Text) Then
        '        MessageBox.Show("Sorry The Credit Amount Should Be Equal To The Debit Amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        cmbpname1.Focus()
        '        Exit Sub
        '    End If
        'End If
        If dvcr.Rows.Count <> 0 Then
            For i As Integer = 0 To dvcr.RowCount - 1
                x = dvcr.Rows(i).Cells(3).Value
                If Val(txtprtcd1.Text) = x Then
                    MessageBox.Show("Sorry You Can't Select This Party Again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbpname1.Focus()
                    Exit Sub
                End If
            Next
        End If
        If dvdr.Rows.Count <> 0 Then
            For i As Integer = 0 To dvdr.RowCount - 1
                x = dvdr.Rows(i).Cells(3).Value
                If Val(txtprtcd1.Text) = x Then
                    MessageBox.Show("Sorry You Can't Select This Party Which is in Debit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbpname1.Focus()
                    Exit Sub
                End If
            Next
        End If
        sl1 = Val(txtsl1.Text)
        dvcr.Rows.Add()
        dvcr.Rows(sl1 - 1).Cells(0).Value = sl1
        dvcr.Rows(sl1 - 1).Cells(1).Value = cmbpname1.Text
        dvcr.Rows(sl1 - 1).Cells(2).Value = txtcramt.Text
        dvcr.Rows(sl1 - 1).Cells(3).Value = txtprtcd1.Text
        sl1 += 1
        Me.grandamt(dvcr, txtcrtot)
        txtsl1.Text = sl1
        cmbpname1.Focus()
        cmbpname1.Text = ""
        txtcramt.Text = "0.00"
    End Sub

    Private Sub cmnu1del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1del.Click
        For Each row As DataGridViewRow In dvdr.SelectedRows
            dvdr.Rows.Remove(row)
        Next
        sl = 1
        For i As Integer = 0 To dvdr.Rows.Count - 1
            dvdr.Rows(i).Cells(0).Value = i + 1
            sl += 1
        Next
        txtsl.Text = sl
        Me.grandamt(dvdr, txtdrtot)
    End Sub

    Private Sub cmnu2del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu2del.Click
        For Each row As DataGridViewRow In dvcr.SelectedRows
            dvcr.Rows.Remove(row)
        Next
        sl = 1
        For i As Integer = 0 To dvcr.Rows.Count - 1
            dvcr.Rows(i).Cells(0).Value = i + 1
            sl += 1
        Next
        txtsl1.Text = sl
        Me.grandamt(dvcr, txtcrtot)
    End Sub

    Private Sub grandamt(ByVal dgv As DataGridView, ByVal txt As TextBox)
        gamt = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            amt = dgv.Rows(i).Cells(2).Value
            gamt = gamt + Val(amt)
        Next
        txt.Text = Format(gamt, "#######0.00")
    End Sub

    Private Sub cmbdesc1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdesc1.KeyPress
        key(cmbdesc2, e)
        SPKey(e)
    End Sub

    Private Sub cmbdesc2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdesc2.KeyPress
        key(cmbdesc3, e)
        SPKey(e)
    End Sub

    Private Sub cmbdesc3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdesc3.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub
End Class


