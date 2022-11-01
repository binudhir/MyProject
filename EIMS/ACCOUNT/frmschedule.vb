Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO
Public Class frmschedule
    Dim comd As String = "E"
    Dim used As String = "N"
    Dim con_img As New SqlConnection(connectionstrng)
    Dim cmd_img As SqlCommand

    Private Sub frmschedule_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuPaySchedule.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmschedule_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmschedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuPaySchedule.Enabled = False
        usrprmsn("mnuPaySchedule", cmnuadd, cmnuedit, cmenudel, cmenuview)
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmschedule_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()

        'txtregdno.Text = ""
        txtstudnm.Text = ""
        txtseson.Text = ""
        txttrde.Text = ""
        txtnb.Text = ""
        txtsl.Text = "1"
        startdt.Value = sys_date
        enddt.Value = sys_date
        duedt.Value = sys_date
        txtfinlamt.Text = "0.00"
        txtgrndtotal.Text = "0.00"
        pict1.BackgroundImage = My.Resources.photo

        If comd = "E" Then
            Me.Text = "Payment Schedule Entry Screen . . ."
            Dim ds As DataSet = get_dataset("SELECT max(schd_no) as 'Max' FROM schd1")
            txtscrl.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            txtregdno.Focus()
            btnsave.Text = "Save"
        ElseIf comd = "M" Then
            Me.Text = "Scheduled Collection Modification Screen . . ."
            btnsave.Text = "Modify"
        Else
            Me.Text = "Scheduled Collection Deletion Screen . . ."
            btnsave.Text = "Delete"
        End If
        dv1.Rows.Clear()
        Me.clr1()
    End Sub

    Private Sub clr1()
        txtacdncd.Text = 0
        txtcollcd.Text = 0
        cmbacdmyr.Text = ""
        cmbcollction.Text = ""
        txtgrace.Text = 0
        txtdueamt.Text = "0.00"
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, cmdview.Click
        Me.dv_disp()
    End Sub

    Private Sub txtvnm_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnb.Enter, txtgrace.Enter, txtfinlamt.Enter, txtdueamt.Enter, cmbacdmyr.Enter, cmbcollction.Enter, txtregdno.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub txtvnm_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregdno.Leave, txtnb.Leave, txtgrace.Leave, txtfinlamt.Leave, txtdueamt.Leave, cmbacdmyr.Leave, cmbcollction.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

        sender.text = UCase(sender.text)
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseEnter, btnsave.MouseEnter, btnnext.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseLeave, btnsave.MouseLeave, btnnext.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub txtredg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtregdno.KeyPress
        key(txtfinlamt, e)
        SPKey(e)
    End Sub

    Private Sub txtfinlamt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfinlamt.KeyPress
        key(cmbacdmyr, e)
        NUM1(e)
    End Sub

    Private Sub cmbsemnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbacdmyr.KeyPress
        If Trim(cmbacdmyr.Text) = "" Then
            key(txtnb, e)
        Else
            key(cmbcollction, e)
        End If
        SPKey(e)
    End Sub

    Private Sub cmbcollction_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcollction.KeyPress
        key(txtdueamt, e)
        SPKey(e)
    End Sub

    Private Sub txtdueamt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdueamt.KeyPress
        key(duedt, e)
        NUM1(e)
    End Sub

    Private Sub duedt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles duedt.KeyPress
        key(txtgrace, e)
    End Sub

    Private Sub txtgrace_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgrace.KeyPress
        key(btnnext, e)
        NUM(e)
    End Sub

    Private Sub txtnb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnb.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub

    Private Sub txtredg_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtregdno.Validated
        If Trim(txtregdno.Text) <> "" Then
            Start1()
            If comd = "E" Then
                Dim ds1 As DataSet = get_dataset("SELECT schd1.* FROM schd1 LEFT OUTER JOIN stud_hstry ON schd1.stud_sl = stud_hstry.stud_sl WHERE (stud_hstry.reg_no = '" & Trim(txtregdno.Text) & "') AND (stud_hstry.active = 'Y')")
                If ds1.Tables(0).Rows.Count = 0 Then
                    Dim ds As DataSet = get_dataset("SELECT stud_hstry.stud_sl,stud_hstry.sesn_cd,stud.stud_nm,DataLength(stud.stud_image) AS stud_img, trad.trad_nm, sesion1.sesn_nm, sesion1.sesn_dt1, sesion1.sesn_dt2 FROM stud_hstry LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.reg_no = '" & Trim(txtregdno.Text) & "')")
                    If ds.Tables(0).Rows.Count <> 0 Then
                        txtstudnm.Text = ds.Tables(0).Rows(0).Item("stud_nm")
                        txtseson.Text = ds.Tables(0).Rows(0).Item("sesn_nm")
                        txttrde.Text = ds.Tables(0).Rows(0).Item("trad_nm")
                        startdt.Value = ds.Tables(0).Rows(0).Item("sesn_dt1")
                        enddt.Value = ds.Tables(0).Rows(0).Item("sesn_dt2")
                        txtstudsl.Text = ds.Tables(0).Rows(0).Item("stud_sl")
                        txtsesncd.Text = ds.Tables(0).Rows(0).Item("sesn_cd")
                        img_length = ds.Tables(0).Rows(0).Item("stud_img")
                        If Val(img_length) <> 0 Then
                            Me.show_image()
                        End If
                    Else
                        MessageBox.Show("Please Enter A Valid Regd. No", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtregdno.Focus()
                    End If
                Else
                    MessageBox.Show("Sorry The The Payment Schedule For This Student Have Already Been Created." & vbCrLf & "If You Want To Rescheduled Then Go Through The Edit Mode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtregdno.Focus()
                End If
            Else
                Dim ds1 As DataSet = get_dataset("SELECT schd_no FROM schd1 LEFT OUTER JOIN stud_hstry ON schd1.stud_sl = stud_hstry.stud_sl WHERE (stud_hstry.reg_no = '" & Trim(txtregdno.Text) & "') AND (stud_hstry.active = 'Y')")
                If ds1.Tables(0).Rows.Count <> 0 Then
                    slno = ds1.Tables(0).Rows(0).Item(0)
                    dv_edit(slno)
                End If
            End If
            Close1()
        End If
    End Sub

    Private Sub show_image()
        Dim cmd_img As New SqlCommand("SELECT stud_image FROM stud WHERE stud_sl=" & Val(txtstudsl.Text) & " ", con_img)
        cmd_img.Parameters.AddWithValue("stud_image", 3)
        Try
            con_img.Open()
            pict1.SizeMode = PictureBoxSizeMode.StretchImage
            pict1.BackgroundImage = Image.FromStream(New IO.MemoryStream(CType(cmd_img.ExecuteScalar, Byte())))
            ' or you can save in a file 
            IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\stud.jpg", CType(cmd_img.ExecuteScalar, Byte()))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con_img.Close()
        End Try
    End Sub

    Private Sub pict1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pict1.MouseEnter
        pict1.Size = New Size(140, 150)
    End Sub

    Private Sub pict1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pict1.MouseLeave
        pict1.Size = New Size(40, 40)
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.Text = "Payment Schedule Entry Screen . . ."
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtregdno.Text) = "" Then
            MessageBox.Show("Sorry The Regd. No. Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtregdno.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count = 0 Then
            MessageBox.Show("Please Schedule At Least One.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbacdmyr.Focus()
            Exit Sub
        End If
        If Val(txtfinlamt.Text) <> Val(txtgrndtotal.Text) Then
            MessageBox.Show("Sorry The Grand Total Amount Should Be Equal To The Final Amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtfinlamt.Focus()
            Exit Sub
        End If
        Me.pay_save()
    End Sub

    Private Sub txtredg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtregdno.GotFocus
        If Trim(txtregdno.Text) <> "" Then
            Me.clr()
        End If
    End Sub

    Private Sub pay_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(schd_no) as 'Max' FROM schd1")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO schd1 (schd_no,stud_sl,final_amt,nb,usr_ent,ent_date,usr_mod,mod_date," & _
                          "usedby,rec_lock) VALUES (" & Val(txtscrl.Text) & "," & Val(txtstudsl.Text) & "," & _
                          Val(txtfinlamt.Text) & ",'" & Trim(txtnb.Text) & "'," & Val(usr_sl) & ",'" & _
                          Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N','N')")
                Me.dv_save()
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                Dim ds As DataSet = get_dataset("SELECT schd_no FROM schd1 WHERE schd_no=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE schd1 SET stud_sl=" & Val(txtstudsl.Text) & ",final_amt=" & Val(txtfinlamt.Text) & ",nb='" & _
                              Trim(txtnb.Text) & "',usr_mod=" & Val(usr_sl) & ",mod_date='" & _
                              Format(Now, "dd/MMM/yyyy HH:mm:ss") & "' WHERE schd_no =" & Val(txtscrl.Text) & "")
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
        If dv1.RowCount <> 0 Then
            SQLInsert("DELETE FROM schd2 WHERE stud_sl=" & Val(txtstudsl.Text) & "")
            For i As Integer = 0 To dv1.RowCount - 1
                semcd = Val(dv1.Rows(i).Cells(7).Value)
                colcd = Val(dv1.Rows(i).Cells(8).Value)
                due_dt = Format(dv1.Rows(i).Cells(6).Value, "dd/MMM/yyyy")
                due_amt = Val(dv1.Rows(i).Cells(3).Value)
                grc = Val(dv1.Rows(i).Cells(5).Value)
                Dim ds1 As DataSet = get_dataset("SELECT max(schd_sl) as 'Max' FROM schd2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO schd2(schd_sl,schd_no,stud_sl,sem_cd,coll_cd,due_amt,due_dt,grace) VALUES (" & Val(mxno) & "," & _
                          Val(txtscrl.Text) & "," & Val(txtstudsl.Text) & "," & semcd & "," & colcd & "," & due_amt & ",'" & due_dt & "'," & grc & ")")
            Next
        End If
    End Sub

    Private Sub dv_view()
        Dim ds As DataSet = get_dataset("SELECT schd2.*, coll.coll_nm, semester.sem_nm FROM schd2 LEFT OUTER JOIN semester ON schd2.sem_cd = semester.sem_cd LEFT OUTER JOIN coll ON schd2.coll_cd = coll.coll_cd WHERE(schd2.schd_no = " & Val(txtscrl.Text) & ") ORDER BY schd2.schd_sl")
        rw = 0
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("sem_nm")
                dv1.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("coll_nm")
                dv1.Rows(rw).Cells(3).Value = Format(ds.Tables(0).Rows(i).Item("due_amt"), "######0.00")
                dv1.Rows(rw).Cells(4).Value = Format(ds.Tables(0).Rows(i).Item("due_dt"), "dd/MM/yyyy")
                dv1.Rows(rw).Cells(5).Value = Val(ds.Tables(0).Rows(i).Item("grace"))
                dv1.Rows(rw).Cells(6).Value = ds.Tables(0).Rows(i).Item("due_dt")
                dv1.Rows(rw).Cells(7).Value = Val(ds.Tables(0).Rows(i).Item("sem_cd"))
                dv1.Rows(rw).Cells(8).Value = ds.Tables(0).Rows(i).Item("coll_cd")
                Me.grandamt()
                rw += 1
            Next
            txtsl.Text = rw + 1
        End If
    End Sub

    Private Sub dv_disp()
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT schd1.schd_no AS 'Schd.No.', stud_hstry.reg_no AS 'Regd.No.',stud.stud_nm AS 'Student Name', sesion1.sesn_nm AS 'Session' , trad.trad_nm AS 'Branch',STR( schd1.final_amt,10,2) AS 'Amount'FROM stud RIGHT OUTER JOIN stud_hstry ON stud.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd RIGHT OUTER JOIN schd1 ON stud_hstry.stud_sl = schd1.stud_sl WHERE (stud_hstry.active = 'Y') ORDER BY stud_hstry.reg_no")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(5).CellTemplate.Style.Alignment = DataGridViewContentAlignment.BottomRight
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
        'dv.Rows.Clear()
        'If dsedit.Tables(0).Rows.Count <> 0 Then
        '    Dim rw As Integer = 0
        '    For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
        '        dv.Rows.Add()
        '        dv.Rows(rw).Cells(0).Value = i + 1
        '        dv.Rows(rw).Cells(1).Value = dsedit.Tables(0).Rows(i).Item("reg_no")
        '        dv.Rows(rw).Cells(2).Value = dsedit.Tables(0).Rows(i).Item("stud_nm")
        '        dv.Rows(rw).Cells(3).Value = dsedit.Tables(0).Rows(i).Item("sesn_nm")
        '        dv.Rows(rw).Cells(4).Value = dsedit.Tables(0).Rows(i).Item("trad_nm")
        '        dv.Rows(rw).Cells(5).Value = Format(dsedit.Tables(0).Rows(i).Item("final_amt"), "######0.00")
        '        'If dsedit.Tables(0).Rows(i).Item("rec_lock") = "Y" Then
        '        '    dv.Rows(rw).DefaultCellStyle.BackColor = Color.AliceBlue
        '        '    dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Blue
        '        'Else
        '        '    dv.Rows(rw).DefaultCellStyle.BackColor = Color.White
        '        '    dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Black
        '        'End If
        '        rw = rw + 1
        '    Next
        'End If
        'Close1()
        'dv.Visible = True
        'dv.Dock = DockStyle.Fill
        'dv.Focus()
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Dim dsedit As DataSet = get_dataset("SELECT  schd1.stud_sl,schd1.final_amt, schd1.nb,stud_hstry.reg_no, stud_hstry.sesn_cd, stud.stud_nm, trad.trad_nm, sesion1.sesn_nm, sesion1.sesn_dt1, sesion1.sesn_dt2,DataLength(stud.stud_image) AS stud_img FROM stud_hstry RIGHT OUTER JOIN schd1 ON stud_hstry.stud_sl = schd1.stud_sl LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (schd1.schd_no = " & Val(slno) & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtregdno.Text = dsedit.Tables(0).Rows(0).Item("reg_no")
            txtstudnm.Text = dsedit.Tables(0).Rows(0).Item("stud_nm")
            txtstudsl.Text = dsedit.Tables(0).Rows(0).Item("stud_sl")
            txtseson.Text = dsedit.Tables(0).Rows(0).Item("sesn_nm")
            txtsesncd.Text = dsedit.Tables(0).Rows(0).Item("sesn_cd")
            txttrde.Text = dsedit.Tables(0).Rows(0).Item("trad_nm")
            txtnb.Text = dsedit.Tables(0).Rows(0).Item("nb")
            startdt.Value = dsedit.Tables(0).Rows(0).Item("sesn_dt1")
            enddt.Value = dsedit.Tables(0).Rows(0).Item("sesn_dt2")
            txtfinlamt.Text = Format(dsedit.Tables(0).Rows(0).Item("final_amt"), "######0.00")
            Me.dv_view()
            img_length = dsedit.Tables(0).Rows(0).Item("stud_img")
            If Val(img_length) <> 0 Then
                Me.show_image()
            End If
        End If
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
        Me.Text = "Payment Schedule Entry Screen . . ."
        dv.Visible = False
        txtregdno.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Payment Schedule Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
            'txtfinlamt.Focus()
        End If
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            comd = "V"
            btnsave.Text = "View"
            Me.Text = "Payment Schedule View Screen . . ."
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
                SQLInsert("DELETE FROM schd1 WHERE schd_no =" & Val(slno) & "")
                SQLInsert("DELETE FROM schd2 WHERE schd_no =" & Val(slno) & "")
                MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dv_disp()
            End If
            Close1()
            'Else
            '    MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        End If
    End Sub

    Private Sub sender_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfinlamt.GotFocus, txtdueamt.GotFocus
        If Val(sender.Text) = 0 Then
            sender.Text = ""
        End If
    End Sub

    Private Sub sender_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfinlamt.LostFocus, txtdueamt.LostFocus
        sender.Text = Format(Val(sender.Text), "######0.00")
    End Sub

    Private Sub cmbacdmyr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacdmyr.GotFocus
        populate(cmbacdmyr, "SELECT semester.sem_nm FROM semester RIGHT OUTER JOIN sesion2 ON semester.sem_cd = sesion2.sem_cd WHERE(sesion2.sesn_cd = " & Val(txtsesncd.Text) & ") ORDER BY sesion2.sem_dt1")
    End Sub

    Private Sub cmbacdmyr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacdmyr.LostFocus
        cmbacdmyr.Height = 21
    End Sub

    Private Sub cmbacdmyr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacdmyr.Validated
        Dim ds As DataSet = get_dataset("SELECT semester.sem_cd,sesion2.sem_dt1 FROM semester RIGHT OUTER JOIN sesion2 ON semester.sem_cd = sesion2.sem_cd WHERE (sesion2.sesn_cd = " & Val(txtsesncd.Text) & ") AND semester.sem_nm='" & Trim(cmbacdmyr.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtacdncd.Text = ds.Tables(0).Rows(0).Item("sem_cd")
            duedt.Value = ds.Tables(0).Rows(0).Item("sem_dt1")
        End If
    End Sub

    Private Sub cmbacdmyr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbacdmyr.Validating
        vdating(cmbacdmyr, "SELECT sem_nm FROM semester WHERE sem_nm='" & Trim(cmbacdmyr.Text) & "' AND rec_lock='N'", "Please Select A Valid Sem/Ac.Year Name.")
    End Sub

    Private Sub cmbcollction_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcollction.GotFocus
        populate(cmbcollction, "SELECT coll_nm FROM coll WHERE rec_lock='N' AND (schd = 'Y') ORDER BY coll_nm")
    End Sub

    Private Sub cmbcollction_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcollction.LostFocus
        cmbcollction.Height = 21
    End Sub

    Private Sub cmbcollction_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcollction.Validated
        'vdated(txtcollcd, "SELECT coll_cd FROM coll WHERE coll_nm='" & Trim(cmbcollction.Text) & "'")
        Dim ds As DataSet = get_dataset("SELECT coll_cd,colamt FROM coll WHERE coll_nm='" & Trim(cmbcollction.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtdueamt.Text = Format(ds.Tables(0).Rows(0).Item("colamt"), "########0.00")
            txtcollcd.Text = ds.Tables(0).Rows(0).Item("coll_cd")
        End If
    End Sub

    Private Sub cmbcollction_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcollction.Validating
        vdating(cmbcollction, "SELECT coll_nm FROM coll WHERE coll_nm='" & Trim(cmbcollction.Text) & "' AND rec_lock='N' AND (schd = 'Y')", "Please Select A Valid Collection Head Name.")
    End Sub

    Private Sub btnnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnext.Click
        If Trim(cmbacdmyr.Text) = "" Or Val(txtacdncd.Text) = 0 Then
            MessageBox.Show("Please Provide A Academic Year Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbacdmyr.Focus()
            Exit Sub
        End If
        If Trim(cmbcollction.Text) = "" Or Val(txtcollcd.Text) = 0 Then
            MessageBox.Show("Please Provide A Collection Head Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbcollction.Focus()
            Exit Sub
        End If
        If Val(txtdueamt.Text) = 0 Then
            MessageBox.Show("The Due Amount Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtdueamt.Focus()
            Exit Sub
        End If
        If Val(txtdueamt.Text) = 0 Then
            MessageBox.Show("The Due Amount Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtdueamt.Focus()
            Exit Sub
        End If

        sl = Val(txtsl.Text)
        'If used <> "Y" Then
        dv1.Rows.Add()
        'End If
        dv1.Rows(sl - 1).Cells(0).Value = sl
        dv1.Rows(sl - 1).Cells(1).Value = cmbacdmyr.Text
        dv1.Rows(sl - 1).Cells(2).Value = cmbcollction.Text
        dv1.Rows(sl - 1).Cells(3).Value = txtdueamt.Text
        dv1.Rows(sl - 1).Cells(4).Value = Format(duedt.Value, "dd/MM/yyyy")
        dv1.Rows(sl - 1).Cells(5).Value = txtgrace.Text
        dv1.Rows(sl - 1).Cells(6).Value = duedt.Value
        dv1.Rows(sl - 1).Cells(7).Value = txtacdncd.Text
        dv1.Rows(sl - 1).Cells(8).Value = txtcollcd.Text
        sl += 1
        txtsl.Text = sl
        cmbacdmyr.Focus()
        Me.grandamt()
        Me.clr1()
    End Sub

    Private Sub cmnu1add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1add.Click
        used = "N"
        cmbacdmyr.Focus()
    End Sub

    Private Sub cmnu1del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1del.Click
        used = "N"
        For Each row As DataGridViewRow In dv1.SelectedRows
            dv1.Rows.Remove(row)
        Next
        sl = 1
        For i As Integer = 0 To dv1.Rows.Count - 1
            dv1.Rows(i).Cells(0).Value = i + 1
            sl += 1
        Next
        txtsl.Text = sl
        Me.grandamt()
    End Sub


    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        regdno = InputBox("Enter Teh Regd. No.", "Search Box...", Nothing)
        If (regdno Is Nothing OrElse regdno = "") Then
            'User hit cancel
        Else
            Dim dssear As DataSet = get_dataset("SELECT schd1.schd_no AS 'Schd.No.', stud_hstry.reg_no AS 'Regd.No.',stud.stud_nm AS 'Student Name', sesion1.sesn_nm AS 'Session' , trad.trad_nm AS 'Branch',STR( schd1.final_amt,10,2) AS 'Amount'FROM stud RIGHT OUTER JOIN stud_hstry ON stud.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd RIGHT OUTER JOIN schd1 ON stud_hstry.stud_sl = schd1.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.reg_no LIKE'" & regdno & "%') ORDER BY stud_hstry.reg_no")
            dv.Columns.Clear()
            If dssear.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dssear.Tables(0)
                dv.Columns(5).CellTemplate.Style.Alignment = DataGridViewContentAlignment.BottomRight
            End If
            dv.Visible = True
            dv.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub grandamt()
        gamt = 0
        For i As Integer = 0 To dv1.Rows.Count - 1
            amt = dv1.Rows(i).Cells(3).Value
            gamt = gamt + Val(amt)
        Next
        txtgrndtotal.Text = Format(gamt, "#######0.00")
        txtdueamt.Text = Format(Val(txtfinlamt.Text) - Val(txtgrndtotal.Text), "#######0.00")
    End Sub

    Private Sub cmnu1edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1edit.Click
        used = "Y"
        For i As Integer = 0 To dv1.SelectedRows.Count - 1
            txtsl.Text = dv1.SelectedRows(i).Cells(0).Value
            cmbacdmyr.Text = dv1.SelectedRows(i).Cells(1).Value
            cmbcollction.Text = dv1.SelectedRows(i).Cells(2).Value
            txtdueamt.Text = dv1.SelectedRows(i).Cells(3).Value
            duedt.Value = dv1.SelectedRows(i).Cells(6).Value
            txtgrace.Text = dv1.SelectedRows(i).Cells(5).Value
            txtacdncd.Text = dv1.SelectedRows(i).Cells(7).Value
            txtcollcd.Text = dv1.SelectedRows(i).Cells(8).Value
            'For Each row As DataGridViewRow In dv1.SelectedRows
            '    dv1.Rows.Remove(row)
            'Next
        Next
    End Sub

    Private Sub mnuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexpert.Click
        Call excel_view(dv)
    End Sub
#Region "Mass Payment"
    Private Sub cmbsessn_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsessn.Validated
        vdated(txtsesncd, "SELECT sesn_cd FROM sesion1 WHERE sesn_nm='" & Trim(cmbsessn.Text) & "'")
    End Sub

    Private Sub cmbsessn_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbsessn.Validating
        vdating(cmbsessn, "SELECT sesn_nm FROM sesion1 WHERE sesn_nm='" & Trim(cmbsessn.Text) & "' AND rec_lock='N'", "Please Select A Valid Session Name.")
    End Sub

    Private Sub cmbsessn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsessn.GotFocus
        populate(cmbsessn, "SELECT sesn_nm FROM sesion1 WHERE rec_lock='N' ORDER BY sesn_dt1 DESC")
    End Sub

    Private Sub cmbsessn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsessn.LostFocus
        cmbsessn.Height = 21
    End Sub

    Private Sub cmbstrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstrm.GotFocus
        populate(cmbstrm, "SELECT trad_nm FROM trad WHERE rec_lock='N' ORDER BY trad_nm")
    End Sub

    Private Sub cmbstrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstrm.LostFocus
        cmbstrm.Height = 21
    End Sub

    Private Sub cmbstrm_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstrm.Validated
        vdated(txtstrmcd, "SELECT trad_cd FROM trad WHERE trad_nm='" & Trim(cmbstrm.Text) & "'")
    End Sub

    Private Sub cmbstrm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstrm.Validating
        vdating(cmbstrm, "SELECT trad_nm FROM trad WHERE trad_nm='" & Trim(cmbstrm.Text) & "' AND rec_lock='N'", "Please Select A Valid Branch Name.")
    End Sub

    Private Sub chkstrm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkstrm.CheckedChanged
        If chkstrm.Checked = True Then
            cmbstrm.Text = "<<< All Branch >>>"
            cmbstrm.Enabled = False
            txtstrmcd.Text = 0
        Else
            cmbstrm.Text = ""
            cmbstrm.Enabled = True
            cmbstrm.Focus()
        End If
    End Sub

#End Region

End Class
