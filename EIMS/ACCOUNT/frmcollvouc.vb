Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO
Public Class frmcollvouc
    Dim comd As String = "E"
    Dim used As String = "N"
    Dim con_img As New SqlConnection(connectionstrng)
    Dim cmd_img As SqlCommand

    Private Sub frmcollvouc_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuFeeColl_SC.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmcollvouc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmcollvouc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuFeeColl_SC.Enabled = False
        usrprmsn("mnuFeeColl_SC", cmnuadd, cmnuedit, cmenudel, cmenuview)
        colldt.Value = sys_date
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmcollvouc_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black
        End If
    End Sub

    Private Sub clr()
        txtbalance.Visible = False
        Label19.Visible = False
        txtsesncd.Text = 0
        txtacdmcd.Text = 0
        txtprtcd.Text = 0
        txtstudsl.Text = 0
        chqdt.Value = sys_date
        txtbanknm.Text = ""
        txtchqno.Text = ""
        txtregdno.Text = ""
        txtstudnm.Text = ""
        txtseson.Text = ""
        txttrde.Text = ""
        txtnb.Text = ""
        startdt.Value = sys_date
        enddt.Value = sys_date
        txtfinlamt.Text = "0.00"
        txtpaidamt.Text = "0.00"
        txtdisc.Text = "0.00"
        txttotdisc.Text = "0.00"
        cmbmode.SelectedIndex = 0
        pict1.BackgroundImage = My.Resources.photo
        dv1.Rows.Clear()
        dvcoll.Rows.Clear()
        dvrec.Rows.Clear()
        If comd = "E" Then
            Me.Text = "Scheduled Collection Entry Screen . . ."
            Dim ds As DataSet = get_dataset("SELECT max(coll_no) as 'Max' FROM collrec1")
            txtcollno.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtcollno.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            btnsave.Text = "Save"
        ElseIf comd = "M" Then
            Me.Text = "Scheduled Collection Modification Screen . . ."
            txtcollno.Text = ""
            btnsave.Text = "Modify"
        Else
            Me.Text = "Scheduled Collection Deletion Screen . . ."
            txtcollno.Text = ""
            btnsave.Text = "Delete"
        End If
        txtcollno.Focus()
        Me.coll_view()
        txttotamt.Text = "0.00"
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, cmdview.Click
        comd = "E"
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        prtnm = InputBox("Enter The Regd. No.", "Search Box...", Nothing)
        If (prtnm Is Nothing OrElse prtnm = "") Then
            'User hit cancel
        Else
            Dim dssear As DataSet = get_dataset("SELECT collrec1.coll_no AS 'Coll. No.',  CONVERT(VARCHAR,collrec1.coll_dt,103) AS 'Date', stud_hstry.reg_no AS 'Regd. No.',stud.stud_nm AS 'Stud. Name', sesion1.sesn_nm AS 'Session',trad.trad_nm AS 'Branch', (CASE WHEN collrec1.pay_mod='1' THEN 'Cash' WHEN collrec1.pay_mod='2' THEN 'DD/Cheque' END) AS 'Pay Mode' ,STR(collrec1.tot_amt,10,2) AS 'Amount' FROM stud RIGHT OUTER JOIN stud_hstry ON stud.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd RIGHT OUTER JOIN collrec1 ON stud_hstry.stud_sl = collrec1.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.reg_no LIKE'" & prtnm & "%') ORDER BY stud_hstry.reg_no")
            dv.Columns.Clear()
            If dssear.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dssear.Tables(0)
                dv.Columns(7).CellTemplate.Style.Alignment = DataGridViewContentAlignment.BottomRight
            End If
            dv.Visible = True
            dv.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub txtvnm_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregdno.Enter, txtnb.Enter, txtfinlamt.Enter, txtcollno.Enter, cmbmode.Enter, txtbanknm.Enter, txtchqno.Enter, cmbacyr.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub txtvnm_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregdno.Leave, txtnb.Leave, txtfinlamt.Leave, txtcollno.Leave, cmbmode.Leave, txtbanknm.Leave, txtchqno.Leave, cmbacyr.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

        sender.text = UCase(sender.text)
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter, btnabort.MouseEnter, btnfresh1.MouseEnter, btnok.MouseEnter, btnprint.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave, btnabort.MouseLeave, btnfresh1.MouseLeave, btnok.MouseLeave, btnprint.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub txtredg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtregdno.KeyPress
        key(cmbacyr, e)
        SPKey(e)
    End Sub

    Private Sub txtdisc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdisc.KeyPress
        key(txttotamt, e)
        SPKey(e)
    End Sub

    Private Sub txtnb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnb.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub

    Private Sub txtbanknm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbanknm.KeyPress
        key(txtchqno, e)
        SPKey(e)
    End Sub

    Private Sub txtchqno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtchqno.KeyPress
        key(chqdt, e)
        SPKey(e)
    End Sub

    Private Sub chqdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chqdt.KeyPress
        key(btnok, e)
    End Sub

    Private Sub txtcollno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcollno.KeyPress
        key(cmbmode, e)
        NUM(e)
    End Sub

    Private Sub cmbmode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbmode.KeyPress
        key(colldt, e)
    End Sub

    Private Sub colldt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles colldt.KeyPress
        key(txtregdno, e)
    End Sub

    Private Sub txtregdno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtregdno.Validating
        vdating(txtregdno, "SELECT schd1.* FROM schd1 LEFT OUTER JOIN stud ON schd1.stud_sl = stud.stud_sl where stud.reg_no='" & Trim(txtregdno.Text) & "'", "Please Make Payment Schedule For This Student.")
    End Sub

    Private Sub txtredg_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtregdno.Validated
        If Trim(txtregdno.Text) <> "" Then
            Start1()
            Dim ds As DataSet = get_dataset("SELECT stud_hstry.stud_sl, stud_hstry.sesn_cd,stud_hstry.sem_cd, stud.stud_nm, DATALENGTH(stud.stud_image) AS stud_img, trad.trad_nm, sesion1.sesn_nm, sesion1.sesn_dt1, sesion1.sesn_dt2, semester.sem_nm FROM stud_hstry LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.reg_no = '" & Trim(txtregdno.Text) & "')")
            If ds.Tables(0).Rows.Count <> 0 Then
                txtstudnm.Text = ds.Tables(0).Rows(0).Item("stud_nm")
                txtseson.Text = ds.Tables(0).Rows(0).Item("sesn_nm")
                txttrde.Text = ds.Tables(0).Rows(0).Item("trad_nm")
                cmbacyr.Text = ds.Tables(0).Rows(0).Item("sem_nm")
                startdt.Value = ds.Tables(0).Rows(0).Item("sesn_dt1")
                enddt.Value = ds.Tables(0).Rows(0).Item("sesn_dt2")
                txtstudsl.Text = ds.Tables(0).Rows(0).Item("stud_sl")
                txtsesncd.Text = ds.Tables(0).Rows(0).Item("sesn_cd")
                txtacdmcd.Text = ds.Tables(0).Rows(0).Item("sem_cd")
                img_length = ds.Tables(0).Rows(0).Item("stud_img")
                Me.schd_view()
                Me.colrec_view()
                If Val(img_length) <> 0 Then
                    Me.show_image()
                End If
            Else
                MessageBox.Show("Please Enter A Valid Regd. No", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtregdno.Focus()
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
        comd = "E"
        Me.clr()

    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Val(txtcollno.Text) = 0 Then
            MessageBox.Show("Sorry The Collection No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtcollno.Focus()
            Exit Sub
        End If
        If Trim(txtregdno.Text) = "" Then
            MessageBox.Show("Sorry The Regd. No. Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtregdno.Focus()
            Exit Sub
        End If
        If cmbmode.SelectedIndex = 1 Then
            If Trim(txtbanknm.Text) = "" Then
                MessageBox.Show("Sorry The Bank Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bank_panel.Visible = True
                txtbanknm.Focus()
                Exit Sub
            End If
            If Trim(txtchqno.Text) = "" Then
                MessageBox.Show("Sorry The Cheque No. Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bank_panel.Visible = True
                txtchqno.Focus()
                Exit Sub
            End If
            If Trim(cmbpname.Text) = "" Or Val(txtprtcd.Text) = 0 Then
                MessageBox.Show("Sorry The Bankers Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbpname.Focus()
                Exit Sub
            End If
        End If
        If Val(txttotamt.Text) = 0 Then
            MessageBox.Show("Sorry The Collection Amount Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dvcoll.Focus()
            Exit Sub
        End If
        If Val(txtfinlamt.Text) < Val(txtpaidamt.Text) + Val(txttotamt.Text) + Val(txttotdisc.Text) + Val(txtdisc.Text) Then
            MessageBox.Show("Sorry You Can't Collect More Than Final Amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Me.pay_save()

    End Sub

    Private Sub sms_send()
        Dim ds As DataSet = get_dataset("SELECT sms_req,pre_ph1,per_ph1,per_ph2,lg_phno1 FROM stud WHERE stud_sl = " & Val(txtstudsl.Text) & " ")
        If ds.Tables(0).Rows(0).Item("sms_req") = "Y" Then
            If coll_sms = 1 Then
                Dim dsnm As DataSet = get_dataset("SELECT fst_nm FROM stud WHERE stud_sl=" & Val(txtstudsl.Text) & "")
                fstnm = dsnm.Tables(0).Rows(0).Item("fst_nm")
                msg = "Dear " & Trim(fstnm) & ", Thanx For Payment Of Rs: " & Val(txttotamt.Text) & " Against Coll No." & Val(txtcollno.Text) & ". Bal.Due Rs:" & Val(txtbalance.Text) & ". From : " & Trim(cosnm) & "."
                Dim ds1 As DataSet = get_dataset("SELECT max(sms_sl) as 'Max' FROM sending_sms")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                If stud_sms = 1 Then
                    studmob = ds.Tables(0).Rows(0).Item("pre_ph1")
                    If Len(studmob) = 10 Then
                        saving_sms(mxno, "Collection SMS", studmob, msg)
                        mxno += 1
                    End If
                End If
                If fath_sms = 1 Then
                    fatmob = ds.Tables(0).Rows(0).Item("per_ph1")
                    If Len(fatmob) = 10 Then
                        saving_sms(mxno, "Collection SMS", fatmob, msg)
                        mxno += 1
                    End If
                End If
                If moth_sms = 1 Then
                    motmob = ds.Tables(0).Rows(0).Item("per_ph2")
                    If Len(motmob) = 10 Then
                        saving_sms(mxno, "Collection SMS", motmob, msg)
                        mxno += 1
                    End If
                End If
                If grdn_sms = 1 Then
                    grdnmob = ds.Tables(0).Rows(0).Item("lg_phno1")
                    If Len(grdnmob) = 10 Then
                        saving_sms(mxno, "Collection SMS", grdnmob, msg)
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub txtredg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtregdno.GotFocus
        If Trim(txtregdno.Text) <> "" Then
            ' Me.clr()
        End If
    End Sub

    Private Sub pay_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(coll_no) as 'Max' FROM collrec1")
                txtcollno.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtcollno.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO collrec1 (coll_no,coll_dt,rec_tp,pay_mod,stud_sl,prt_code,tot_amt,bank_nm,chq_no,chq_dt,nb," & _
                          "usr_ent,ent_date,usr_mod,mod_date,rec_lock,disc_amt) VALUES (" & Val(txtcollno.Text) & ",'" & _
                          Format(colldt.Value, "dd/MMM/yyyy") & "','1','" & vb.Left(cmbmode.Text, 1) & "'," & Val(txtstudsl.Text) & "," & _
                          Val(txtprtcd.Text) & "," & Val(txttotamt.Text) & ",'" & Trim(txtbanknm.Text) & "','" & Trim(txtchqno.Text) & "','" & _
                          Format(chqdt.Value, "dd/MMM/yyyy") & "','" & Trim(txtnb.Text) & "'," & Val(usr_sl) & ",'" & _
                          Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N'," & Val(txtdisc.Text) & ")")
                Me.dv_save()
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cnfr = MessageBox.Show("Are You Sure The Printer is Ready To Print The Bill.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If cnfr = vbYes Then
                    Call colrec_print(Val(txtcollno.Text))
                End If
                Me.sms_send()
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
                Dim ds As DataSet = get_dataset("SELECT coll_no FROM collrec1 WHERE coll_no=" & Val(txtcollno.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE collrec1 SET coll_dt='" & Format(colldt.Value, "dd/MMM/yyyy") & "',pay_mod='" & _
                              vb.Left(cmbmode.Text, 1) & "',stud_sl=" & Val(txtstudsl.Text) & ",tot_amt=" & _
                              Val(txttotamt.Text) & ",prt_code=" & Val(txtprtcd.Text) & ",bank_nm='" & _
                              Trim(txtbanknm.Text) & "',chq_no='" & Trim(txtchqno.Text) & "',chq_dt='" & _
                              Format(chqdt.Value, "dd/MMM/yyyy") & "',nb='" & Trim(txtnb.Text) & "',usr_mod=" & _
                              Val(usr_sl) & ",mod_date='" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "',disc_amt=" & Val(txtdisc.Text) & " WHERE coll_no =" & Val(txtcollno.Text) & "")
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
        If dvcoll.RowCount <> 0 Then
            If comd = "M" Then
                Call del2(txtcollno.Text)
            End If
            For i As Integer = 0 To dvcoll.RowCount - 1
                colcd = Val(dvcoll.Rows(i).Cells(3).Value)
                col_amt = Val(dvcoll.Rows(i).Cells(2).Value)
                Dim ds1 As DataSet = get_dataset("SELECT max(coll_sl) as 'Max' FROM collrec2")
                If Val(col_amt) <> 0 Then
                    mxno = 1
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                            mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                        End If
                    End If
                    SQLInsert("INSERT INTO collrec2(coll_sl,coll_no,coll_dt,stud_sl,rec_tp,pay_mod,sem_cd,coll_cd,coll_amt) VALUES (" & Val(mxno) & "," & _
                              Val(txtcollno.Text) & ",'" & Format(colldt.Value, "dd/MMM/yyyy") & "'," & Val(txtstudsl.Text) & ",'1','" & _
                              vb.Left(cmbmode.Text, 1) & "'," & Val(txtacdmcd.Text) & "," & colcd & "," & col_amt & ")")
                End If
            Next
        End If
    End Sub

#Region "DISPLAY"
    Private Sub schd_view()
        Dim ds As DataSet = get_dataset("SELECT coll.coll_nm, semester.sem_nm, schd2.* FROM schd2 LEFT OUTER JOIN semester ON schd2.sem_cd = semester.sem_cd LEFT OUTER JOIN coll ON schd2.coll_cd = coll.coll_cd WHERE(schd2.stud_sl = " & Val(txtstudsl.Text) & ") ORDER BY schd2.schd_sl")
        rw = 0
        amt = 0
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
                amt = amt + Val(ds.Tables(0).Rows(i).Item("due_amt"))
                rw += 1
            Next
        End If
        txtfinlamt.Text = Format(amt, "#######0.00")
        If Val(txtfinlamt.Text) <> 0 Then
            txtbalance.Visible = True
            Label19.Visible = True
        End If
    End Sub

    Private Sub coll_view()
        Dim ds As DataSet = get_dataset("SELECT coll_nm,coll_cd FROM coll WHERE(coll_tp = '1') AND (schd = 'Y') ORDER BY coll_nm")
        rw = 0
        dvcoll.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dvcoll.Rows.Add()
                dvcoll.Rows(rw).Cells(0).Value = i + 1
                dvcoll.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("coll_nm")
                dvcoll.Rows(rw).Cells(2).Value = "0.00"
                dvcoll.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("coll_cd")
                rw += 1
            Next
        End If
    End Sub

    Private Sub colrec_view()
        If comd = "E" Then
            Dim ds As DataSet = get_dataset("SELECT coll.coll_nm, semester.sem_nm, collrec2.coll_amt FROM collrec2 LEFT OUTER JOIN semester ON collrec2.sem_cd = semester.sem_cd LEFT OUTER JOIN coll ON collrec2.coll_cd = coll.coll_cd WHERE(collrec2.stud_sl = " & Val(txtstudsl.Text) & ") ORDER BY collrec2.coll_sl")
            rw = 0
            amt = 0
            dvrec.Rows.Clear()
            If ds.Tables(0).Rows.Count <> 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dvrec.Rows.Add()
                    dvrec.Rows(rw).Cells(0).Value = i + 1
                    dvrec.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("sem_nm")
                    dvrec.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("coll_nm")
                    dvrec.Rows(rw).Cells(3).Value = Format(ds.Tables(0).Rows(i).Item("coll_amt"), "######0.00")
                    amt = amt + Val(ds.Tables(0).Rows(i).Item("coll_amt"))
                    rw += 1
                Next
            End If

            Dim ds1 As DataSet = get_dataset("SELECT SUM(disc_amt) AS 'Disc' FROM collrec1 WHERE stud_sl=" & Val(txtstudsl.Text) & " ")
            If Not IsDBNull(ds1.Tables(0).Rows(0).Item("Disc")) Then
                txttotdisc.Text = Format(ds1.Tables(0).Rows(0).Item("Disc"), "#######0.00")
            End If
            txtpaidamt.Text = Format(amt, "#######0.00")
            txtbalance.Text = Format(Val(txtfinlamt.Text) - (amt + Val(txttotdisc.Text)), "#######0.00")
        Else
            Me.coll_view()

            Dim ds As DataSet = get_dataset("SELECT coll.coll_nm, semester.sem_nm, collrec2.coll_amt FROM collrec2 LEFT OUTER JOIN semester ON collrec2.sem_cd = semester.sem_cd LEFT OUTER JOIN coll ON collrec2.coll_cd = coll.coll_cd WHERE(collrec2.coll_no = " & Val(txtcollno.Text) & ") ORDER BY collrec2.coll_sl")
            rw = 0
            amt = 0
            dvrec.Rows.Clear()
            If ds.Tables(0).Rows.Count <> 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dvrec.Rows.Add()
                    dvrec.Rows(rw).Cells(0).Value = i + 1
                    dvrec.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("sem_nm")
                    dvrec.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("coll_nm")
                    dvrec.Rows(rw).Cells(3).Value = Format(ds.Tables(0).Rows(i).Item("coll_amt"), "######0.00")
                    amt = amt + Val(ds.Tables(0).Rows(i).Item("coll_amt"))
                    For n As Integer = 0 To dvcoll.Rows.Count - 1
                        col_nm = dvrec.Rows(rw).Cells(2).Value
                        If Trim(dvcoll.Rows(n).Cells(1).Value) = Trim(col_nm) Then
                            dvcoll.Rows(n).Cells(2).Value = dvrec.Rows(rw).Cells(3).Value
                            dvcoll.Rows(n).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
                        End If
                    Next
                    rw += 1
                Next
            End If

            Dim ds1 As DataSet = get_dataset("SELECT SUM(disc_amt) AS 'Disc' FROM collrec1 WHERE stud_sl=" & Val(txtstudsl.Text) & " ")
            txttotdisc.Text = Format(ds1.Tables(0).Rows(0).Item("Disc"), "#######0.00")

            txtpaidamt.Text = Format(amt, "#######0.00")
            txttotamt.Text = Format(amt, "#######0.00")
            txtbalance.Text = Format(Val(txtfinlamt.Text) - (amt + Val(txttotdisc.Text)), "#######0.00")
        End If
    End Sub

    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT collrec1.coll_no AS 'Coll. No.', CONVERT(VARCHAR,collrec1.coll_dt,103) AS 'Date', stud_hstry.reg_no AS 'Regd. No.',stud.stud_nm AS 'Stud. Name', sesion1.sesn_nm AS 'Session',trad.trad_nm AS 'Branch', (CASE WHEN collrec1.pay_mod='1' THEN 'Cash' WHEN collrec1.pay_mod='2' THEN 'DD/Cheque' END) AS 'Pay Mode' ,STR(collrec1.tot_amt,10,2) AS 'Amount' FROM stud RIGHT OUTER JOIN stud_hstry ON stud.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd RIGHT OUTER JOIN collrec1 ON stud_hstry.stud_sl = collrec1.stud_sl WHERE (stud_hstry.active = 'Y') ORDER BY collrec1.coll_no DESC,collrec1.coll_dt DESC")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(7).CellTemplate.Style.Alignment = DataGridViewContentAlignment.BottomRight
        End If
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT stud_hstry.reg_no, stud_hstry.sesn_cd, stud_hstry.sem_cd, stud.stud_nm, trad.trad_nm, sesion1.sesn_nm, sesion1.sesn_dt1, sesion1.sesn_dt2, semester.sem_nm, collrec1.*, party.pname,DataLength(stud.stud_image) AS stud_img FROM party RIGHT OUTER JOIN collrec1 ON party.prt_code = collrec1.prt_code LEFT OUTER JOIN stud_hstry LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd ON collrec1.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (collrec1.coll_no = " & slno & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtcollno.Text = slno
            colldt.Value = dsedit.Tables(0).Rows(0).Item("coll_dt")
            cmbmode.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("pay_mod")) - 1
            txtregdno.Text = dsedit.Tables(0).Rows(0).Item("reg_no")
            txtstudnm.Text = dsedit.Tables(0).Rows(0).Item("stud_nm")
            txtstudsl.Text = dsedit.Tables(0).Rows(0).Item("stud_sl")
            txtseson.Text = dsedit.Tables(0).Rows(0).Item("sesn_nm")
            txtsesncd.Text = dsedit.Tables(0).Rows(0).Item("sesn_cd")
            txttrde.Text = dsedit.Tables(0).Rows(0).Item("trad_nm")
            cmbacyr.Text = dsedit.Tables(0).Rows(0).Item("sem_nm")
            txtacdmcd.Text = dsedit.Tables(0).Rows(0).Item("sem_cd")
            txtbanknm.Text = dsedit.Tables(0).Rows(0).Item("bank_nm")
            txtchqno.Text = dsedit.Tables(0).Rows(0).Item("chq_no")
            chqdt.Value = dsedit.Tables(0).Rows(0).Item("chq_dt")
            txtprtcd.Text = dsedit.Tables(0).Rows(0).Item("prt_code")
            If Val(txtprtcd.Text) <> 0 Then
                cmbpname.Text = dsedit.Tables(0).Rows(0).Item("pname")
            End If
            txtnb.Text = dsedit.Tables(0).Rows(0).Item("nb")
            startdt.Value = dsedit.Tables(0).Rows(0).Item("sesn_dt1")
            enddt.Value = dsedit.Tables(0).Rows(0).Item("sesn_dt2")
            txtdisc.Text = Format(dsedit.Tables(0).Rows(i).Item("disc_amt"), "######0.00")
            'txtfinlamt.Text = Format(dsedit.Tables(0).Rows(0).Item("tot_amt"), "######0.00")
            Me.schd_view()
            Me.colrec_view()
            img_length = dsedit.Tables(0).Rows(0).Item("stud_img")
            If Val(img_length) <> 0 Then
                Me.show_image()
            End If
        End If
        Close1()
    End Sub
#End Region

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
        Me.Text = "Scheduled Collection Entry Screen . . ."
        dv.Visible = False
        txtregdno.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Scheduled Collection Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
            'txtregdno.Focus()
        End If
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            comd = "V"
            btnsave.Text = "View"
            Me.Text = "Scheduled Collection View Screen . . ."
            slno = dv.SelectedRows(0).Cells(0).Value
            dv.Visible = False
            Me.dv_edit(slno)
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

    Private Sub dvcoll_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvcoll.CellValidated
        amt = 0
        For i As Integer = 0 To dvcoll.Rows.Count - 1
            dvcoll.Rows(i).Cells(2).Value = Format(Val(dvcoll.Rows(i).Cells(2).Value), "#######0.00")
            amt = amt + Val(dvcoll.Rows(i).Cells(2).Value)
            If Val(dvcoll.Rows(i).Cells(2).Value) <> 0 Then
                dvcoll.Rows(i).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
            End If
        Next
        txttotamt.Text = Format(amt, "########0.00")
        txtbalance.Text = Format(Val(txtfinlamt.Text) - (Val(txtpaidamt.Text) + amt + Val(txttotdisc.Text) + Val(txtdisc.Text)), "########0.00")
    End Sub

    Private Sub btnfresh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfresh1.Click
        chqdt.Value = sys_date
        txtbanknm.Text = ""
        txtchqno.Text = ""
    End Sub

    Private Sub cmbmode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmode.LostFocus
        If cmbmode.SelectedIndex = 1 Then
            bank_panel.Visible = True
            cmbpname.Enabled = True
            txtbanknm.Focus()
        Else
            cmbpname.Enabled = True
            cmbpname.Text = ""
            txtprtcd.Text = 0
            bank_panel.Visible = False
            chqdt.Value = sys_date
            txtbanknm.Text = ""
            txtchqno.Text = ""
        End If
    End Sub

    Private Sub btnabort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnabort.Click, btnok.Click
        bank_panel.Visible = False
    End Sub

    Private Sub cmbrecfrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname.GotFocus
        populate(cmbpname, "SELECT pname FROM party WHERE prt_type='D' AND rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbrecfrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname.LostFocus
        cmbpname.Height = 21
    End Sub

    Private Sub cmbrecfrm_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpname.Validated
        vdated(txtprtcd, "SELECT prt_code FROM party WHERE pname='" & Trim(cmbpname.Text) & "'")
    End Sub

    Private Sub cmbrecfrm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbpname.Validating
        vdating(cmbpname, "SELECT pname FROM party WHERE prt_type='D' AND rec_lock='N' AND pname='" & Trim(cmbpname.Text) & "'", "Please Select A Valid Bank Name.")
    End Sub

    Private Sub cmbacyr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacyr.GotFocus
        populate(cmbacyr, "SELECT sem_nm FROM semester WHERE rec_lock='N' ORDER BY sem_pos")
    End Sub

    Private Sub cmbacyr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacyr.LostFocus
        cmbacyr.Height = 21
    End Sub

    Private Sub cmbacyr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacyr.Validated
        vdated(txtacdmcd, "SELECT sem_cd FROM semester WHERE sem_nm='" & Trim(cmbacyr.Text) & "'")
    End Sub

    Private Sub cmbacyr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbacyr.Validating
        vdating(cmbacyr, "SELECT sem_nm FROM semester WHERE sem_nm='" & Trim(cmbacyr.Text) & "' AND rec_lock='N'", "Please Select A Valid Sem/Ac.Year Name.")
    End Sub

    Private Sub txtcollno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcollno.GotFocus
        If Val(txtcollno.Text) <> 0 Then
            Me.clr()
        End If
    End Sub

    Private Sub txtcollno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcollno.Validated
        If comd = "M" Then
            Dim ds1 As DataSet = get_dataset("SELECT coll_no FROM collrec1 WHERE (coll_no = '" & Trim(txtcollno.Text) & "')")
            If ds1.Tables(0).Rows.Count <> 0 Then
                slno = ds1.Tables(0).Rows(0).Item(0)
                dv_edit(slno)
            End If
        End If
    End Sub

    Private Sub btnprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprint.Click
        frmno = 1
        frmprnt.MdiParent = MDI
        frmprnt.Show()
    End Sub

    Private Sub cmnuprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuprint.Click
        If dv.SelectedRows.Count <> 0 Then
            slno = dv.SelectedRows(0).Cells(0).Value
            Start1()
            Call colrec_print(slno)
            Close1()
        Else
            frmno = 1
            frmprnt.MdiParent = MDI
            frmprnt.Show()
        End If
    End Sub

    Private Sub cmbacyr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbacyr.KeyPress
        key(dvcoll, e)
        SPKey(e)
    End Sub

    'Delete data from Table1/Primary Table
    Private Sub del1(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT coll_no FROM collrec1 WHERE coll_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            SQLInsert("DELETE FROM collrec1 WHERE coll_no=" & Val(code) & "")
        End If
    End Sub

    'Delete data from Table2/Secondary Table
    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT coll_sl FROM collrec2 WHERE coll_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                posl = dsdel.Tables(0).Rows(i).Item(0)
                SQLInsert("DELETE FROM collrec2 WHERE coll_sl=" & Val(posl) & "")
            Next
        End If
    End Sub

    Private Sub txtdisc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdisc.LostFocus
        Format(txtdisc.Text, "#######0.00")
    End Sub

    Private Sub txtdisc_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdisc.Validated
        txtbalance.Text = Format(Val(txtfinlamt.Text) - (Val(txtpaidamt.Text) + Val(txttotdisc.Text) + Val(txtdisc.Text) + Val(txttotamt.Text)), "######0.00")
    End Sub

    Private Sub mnuexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexport.Click
        Call excel_view(dv)
    End Sub
End Class
