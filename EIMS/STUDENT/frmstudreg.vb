Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO

Public Class frmstudreg
    Dim comd As String = "E"
    Dim con_img As New SqlConnection(connectionstrng)
    Dim cmd_img As SqlCommand

#Region "START UP"
    Private Sub frmstudreg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnustudreg.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmstudreg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmstudreg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        MDI.mnustudreg.Enabled = False
        usrprmsn("mnustudreg", cmnuadd, cmnuedit, cmenudel, cmenuview)
        If cmnuadd.Enabled = True Then
            btnadd.Enabled = True
        Else
            btnadd.Enabled = False
        End If
        If cmnuedit.Enabled = True Then
            btnedit.Enabled = True
        Else
            btnedit.Enabled = False
        End If
        If cmenudel.Enabled = True Then
            btndelete.Enabled = True
        Else
            btndelete.Enabled = False
        End If
        cmbenq.SelectedIndex = 0
        cmbstrm.Text = ""
        cmbsessn.Text = ""
        cmbacdmyr.Text = ""
        txtacdncd.Text = 0
        txtstrmcd.Text = 0
        txtsesncd.Text = 0
        regdt.Value = sys_date
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub clr()
        TabControl1.SelectedIndex = 0
        cmbincome.SelectedIndex = 0
        txtphoto.Text = "N"
        txtzip1.Text = ""
        txtsurnm.Text = ""
        txtstudmob.Text = ""
        txtserregd.Text = ""
        txtsername.Text = ""
        txtreltn.Text = ""
        txtrelgn.Text = ""
        'txtregdno.Text = ""
        txtnatnl.Text = ""
        txtmthernm.Text = ""
        txtmothmob.Text = ""
        txtmdlnm.Text = ""
        txtgrdmob.Text = ""
        txtgrdnnm.Text = ""
        txtfthernm.Text = ""
        txtfrstnm.Text = ""
        txtfathmob.Text = ""
        txtenqno.Text = ""
        txtemail.Text = ""
        txtage.Text = ""
        txtadd2.Text = ""
        txtadd1.Text = ""
        cmbreference.Text = ""
        cmboccu.Text = ""
        cmbenqmob.Text = ""
        cmbdist2.Text = ""
        cmbdist1.Text = ""
        txtstate1.Text = ""
        txtstate2.Text = ""
        txtcntr1.Text = ""
        txtcntr2.Text = ""
        cmbbldgrp.SelectedIndex = 8
        txtdoccu.Text = ""
        txtdevicecd.Text = ""
        txtcouncil.Text = ""
        txtformno.Text = ""
        cmbunversity.Text = ""
        txtps1.Text = ""
        txtps2.Text = ""
        txtzip2.Text = ""
        cmbjointp.SelectedIndex = 0
        cmbdocutp.SelectedIndex = 0
        'dv.Rows.Clear()
        dv.Columns.Clear()
        dvquali.Rows.Clear()
        dvdocu.Rows.Clear()
        txtscrl.Text = 0
        txtocucd.Text = 0
        txtunvcd.Text = 0
        txtdist1cd.Text = 0
        txtdist2cd.Text = 0
        txtstat1cd.Text = 0
        txtstat2cd.Text = 0
        txtrefcd.Text = 0
        txtsl.Text = 1
        txtsl1.Text = 1
        dob.Value = sys_date.AddYears(-5)
        pict1.BackgroundImage = My.Resources.photo
        If comd = "E" Then
            Me.Text = "Student Registration Entry Screen . . ."
            Dim ds As DataSet = get_dataset("SELECT max(stud_sl) as 'Max' FROM stud")
            txtscrl.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
        End If
        txtsurnm.Focus()
        Me.clr1()
        Me.last_regd()
    End Sub

    Private Sub clr1()
        txtschnm.Text = ""
        txtyear.Text = ""
        txttotmrk.Text = "0.00"
        txtsecmrk.Text = "0.00"
        txtcgpa.Text = ""
        txtper.Text = "0.00"
        cmbgrd.SelectedIndex = 0
        cmbexam.Text = ""
        txtexmcd.Text = 0
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.dv_disp()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtzip2.Enter, txtzip1.Enter, txtsurnm.Enter, txtstudmob.Enter, txtserregd.Enter, txtsername.Enter, txtreltn.Enter, txtrelgn.Enter, txtregdno.Enter, txtnatnl.Enter, txtmthernm.Enter, txtmothmob.Enter, txtmdlnm.Enter, txtgrdmob.Enter, txtgrdnnm.Enter, txtfthernm.Enter, txtfrstnm.Enter, txtfathmob.Enter, txtenqno.Enter, txtage.Enter, txtadd2.Enter, txtadd1.Enter, cmbstrm.Enter, cmbsessn.Enter, cmbreference.Enter, cmboccu.Enter, cmbenqmob.Enter, cmbenq.Enter, cmbdist2.Enter, cmbdist1.Enter, cmbbldgrp.Enter, cmbacdmyr.Enter, txtyear.Enter, txttotmrk.Enter, txtsecmrk.Enter, txtschnm.Enter, txtper.Enter, txtdoccu.Enter, txtdevicecd.Enter, txtcouncil.Enter, txtcgpa.Enter, txtformno.Enter, cmbunversity.Enter, cmbjointp.Enter, cmbgrd.Enter, cmbexam.Enter, cmbdocutp.Enter, txtps1.Enter, txtps2.Enter, cmbincome.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtzip2.Leave, txtzip1.Leave, txtsurnm.Leave, txtstudmob.Leave, txtserregd.Leave, txtsername.Leave, txtreltn.Leave, txtrelgn.Leave, txtregdno.Leave, txtnatnl.Leave, txtmthernm.Leave, txtmothmob.Leave, txtmdlnm.Leave, txtgrdmob.Leave, txtgrdnnm.Leave, txtfthernm.Leave, txtfrstnm.Leave, txtfathmob.Leave, txtenqno.Leave, txtage.Leave, txtadd2.Leave, txtadd1.Leave, cmbstrm.Leave, cmbsessn.Leave, cmbreference.Leave, cmboccu.Leave, cmbenqmob.Leave, cmbenq.Leave, cmbdist2.Leave, cmbdist1.Leave, cmbbldgrp.Leave, cmbacdmyr.Leave, txtyear.Leave, txttotmrk.Leave, txtsecmrk.Leave, txtschnm.Leave, txtper.Leave, txtdoccu.Leave, txtdevicecd.Leave, txtcouncil.Leave, txtcgpa.Leave, txtformno.Leave, cmbunversity.Leave, cmbjointp.Leave, cmbgrd.Leave, cmbexam.Leave, cmbdocutp.Leave, txtps1.Leave, txtps2.Leave, cmbincome.Enter

        sender.text = UCase(sender.text)
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub txtmail_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtemail.Enter
        txtemail.ForeColor = Color.Blue
        txtemail.BackColor = Color.LavenderBlush
        txtemail.Text = LCase(Trim(txtemail.Text))
        txtemail.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Bold)
    End Sub

    Private Sub txtmail_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtemail.Leave
        txtemail.ForeColor = Color.Black
        txtemail.BackColor = Color.White
        txtemail.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Regular)
    End Sub
#End Region

#Region "BUTTONS"
    Private Sub btndelete_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnnxt1.MouseEnter, btnnxt.MouseEnter, btnexit.MouseEnter, btnedit.MouseEnter, btndelete.MouseEnter, btnclr1.MouseEnter, btnclr.MouseEnter, btnadd.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btndelete_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnnxt1.MouseLeave, btnnxt.MouseLeave, btnexit.MouseLeave, btnedit.MouseLeave, btndelete.MouseLeave, btnclr1.MouseLeave, btnclr.MouseLeave, btnadd.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click, cmnuadd.Click
        comd = "E"
        btnsave.Text = "Save."
        Me.Text = "Student Registration Entry Screen . . ."
        Me.clr()
        For i As Integer = 0 To dv.Height = 10
            dv.Height = dv.Height - 1
        Next
        dv.Visible = False
        grpsearch.Visible = False
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click, cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Student Registration Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(11).Value
            Me.dv_edit(slno)
            For i As Integer = 0 To dv.Width = 10
                dv.Width = dv.Width - 1
            Next
            dv.Visible = False
            grpsearch.Visible = False
            txtsurnm.Focus()
        End If
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        comd = "V"
        btnsave.Enabled = False
        Me.Text = "Student Registration View Screen . . ."
        slno = dv.SelectedRows(0).Cells(11).Value
        Me.dv_edit(slno)
        For i As Integer = 0 To dv.Width = 10
            dv.Width = dv.Width - 1
        Next
        dv.Visible = False
        grpsearch.Visible = False
        txtsurnm.Focus()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        comd = "E"
        Me.clr()
        If dv.Visible = True Then
            Me.dv_disp()
        End If
    End Sub

    'Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
    '    Me.Text = "Student Registration Deletion Screen . . ."
    '    comd = "D"
    'End Sub

    Private Sub btnnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.Click
        If Trim(txtschnm.Text) = "" Then
            MessageBox.Show("The Institute Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtschnm.Focus()
            Exit Sub
        End If
        If Trim(cmbexam.Text) = "" Or Val(txtexmcd.Text) = 0 Then
            MessageBox.Show("The Examination Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtschnm.Focus()
            Exit Sub
        End If
        If dvquali.Rows.Count <> 0 Then
            For i As Integer = 0 To dvquali.RowCount - 1
                x = dvquali.Rows(i).Cells(9).Value
                If Val(txtexmcd.Text) = x Then
                    MessageBox.Show("Sorry The Data Should Not Be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbexam.Focus()
                    Exit Sub
                End If
            Next
        End If

        sl = Val(txtsl.Text)
        dvquali.Rows.Add()
        dvquali.Rows(sl - 1).Cells(0).Value = sl
        dvquali.Rows(sl - 1).Cells(1).Value = txtschnm.Text
        dvquali.Rows(sl - 1).Cells(2).Value = cmbexam.Text
        dvquali.Rows(sl - 1).Cells(3).Value = txtyear.Text
        dvquali.Rows(sl - 1).Cells(4).Value = txttotmrk.Text
        dvquali.Rows(sl - 1).Cells(5).Value = txtsecmrk.Text
        dvquali.Rows(sl - 1).Cells(6).Value = txtper.Text
        dvquali.Rows(sl - 1).Cells(7).Value = txtcgpa.Text
        dvquali.Rows(sl - 1).Cells(8).Value = cmbgrd.Text
        dvquali.Rows(sl - 1).Cells(9).Value = txtexmcd.Text
        sl += 1
        txtsl.Text = sl
        txtschnm.Focus()
        Me.clr1()
    End Sub

    Private Sub btnnxt1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt1.Click
        If Trim(txtdoccu.Text) = "" Then
            MessageBox.Show("The Doccument Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtdoccu.Focus()
            Exit Sub
        End If
        If dvdocu.Rows.Count <> 0 Then
            For i As Integer = 0 To dvdocu.RowCount - 1
                x = dvdocu.Rows(i).Cells(1).Value
                If Trim(txtdoccu.Text) = x Then
                    MessageBox.Show("Sorry The Data Should Not Be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtdoccu.Focus()
                    Exit Sub
                End If
            Next
        End If
        sl1 = Val(txtsl1.Text)
        dvdocu.Rows.Add()
        dvdocu.Rows(sl1 - 1).Cells(0).Value = sl1
        dvdocu.Rows(sl1 - 1).Cells(1).Value = txtdoccu.Text
        dvdocu.Rows(sl1 - 1).Cells(2).Value = cmbdocutp.Text
        sl1 += 1
        txtsl1.Text = sl1
        txtdoccu.Text = ""
        txtdoccu.Focus()
    End Sub

    Private Sub btnclr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclr.Click
        dvquali.Rows.Clear()
        txtsl.Text = "1"
        Me.clr1()
    End Sub

    Private Sub btnclr1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclr1.Click
        dvdocu.Rows.Clear()
        txtsl1.Text = "1"
        txtdoccu.Text = ""
    End Sub
#End Region

#Region "Keypress"
    Private Sub txtsurnm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsurnm.TextChanged
        txtstudnm.Text = Trim(txtfrstnm.Text) & " " & Trim(txtmdlnm.Text) & " " & Trim(txtsurnm.Text)
    End Sub

    Private Sub txtfrstnm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfrstnm.TextChanged
        txtstudnm.Text = Trim(txtfrstnm.Text) & " " & Trim(txtmdlnm.Text) & " " & Trim(txtsurnm.Text)
    End Sub

    Private Sub txtmdlnm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmdlnm.TextChanged
        txtstudnm.Text = Trim(txtfrstnm.Text) & " " & Trim(txtmdlnm.Text) & " " & Trim(txtsurnm.Text)
    End Sub

    Private Sub cmbsessn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbsessn.KeyPress
        key(cmbacdmyr, e)
        SPKey(e)
    End Sub

    Private Sub cmbacdmyr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbacdmyr.KeyPress
        key(cmbstrm, e)
        SPKey(e)
    End Sub

    Private Sub cmbstrm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstrm.KeyPress
        key(txtregdno, e)
        SPKey(e)
    End Sub

    Private Sub txtregdno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtregdno.KeyPress
        key(cmbenq, e)
        SPKey(e)
    End Sub

    Private Sub cmbenq_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbenq.KeyPress
        If txtenqno.Visible = True Then
            key(txtenqno, e)
        Else
            key(txtsurnm, e)
        End If
        NUM(e)
    End Sub

    Private Sub txtenqno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtenqno.KeyPress
        key(cmbenqmob, e)
        SPKey(e)
    End Sub

    Private Sub cmbenqmob_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbenqmob.KeyPress
        key(txtsurnm, e)
        NUM(e)
    End Sub

    Private Sub txtsurnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsurnm.KeyPress
        key(txtfrstnm, e)
        SPKey(e)
    End Sub

    Private Sub txtfrstnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfrstnm.KeyPress
        key(txtmdlnm, e)
        SPKey(e)
    End Sub

    Private Sub txtmdlnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmdlnm.KeyPress
        key(txtfthernm, e)
        SPKey(e)
    End Sub

    Private Sub txtfthernm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfthernm.KeyPress
        key(txtmthernm, e)
        SPKey(e)
    End Sub

    Private Sub txtmthernm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmthernm.KeyPress
        key(txtgrdnnm, e)
        SPKey(e)
    End Sub

    Private Sub txtgrdnnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgrdnnm.KeyPress
        key(txtreltn, e)
        SPKey(e)
    End Sub

    Private Sub txtreltn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtreltn.KeyPress
        key(cmbbldgrp, e)
        SPKey(e)
    End Sub

    Private Sub cmbbldgrp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbldgrp.KeyPress
        key(dob, e)
        SPKey(e)
    End Sub

    Private Sub dob_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dob.KeyPress
        key(cmboccu, e)
        SPKey(e)
    End Sub

    Private Sub cmboccu_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmboccu.KeyPress
        key(cmbincome, e)
        SPKey(e)
    End Sub

    Private Sub cmbincome_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbincome.KeyPress
        key(txtrelgn, e)
        SPKey(e)
    End Sub

    Private Sub txtrelgn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrelgn.KeyPress
        key(txtnatnl, e)
        SPKey(e)
    End Sub

    Private Sub txtnatnl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnatnl.KeyPress
        key(txtadd1, e)
        SPKey(e)
    End Sub

    Private Sub txtadd1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd1.KeyPress
        key(cmbdist1, e)
        SPKey(e)
    End Sub

    Private Sub cmbcity1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdist1.KeyPress
        key(txtzip1, e)
        SPKey(e)
    End Sub

    Private Sub txtzip1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzip1.KeyPress
        key(txtps1, e)
        NUM(e)
    End Sub

    Private Sub txtps1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtps1.KeyPress
        key(txtstudmob, e)
        SPKey(e)
    End Sub

    Private Sub txtstudmob_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstudmob.KeyPress
        key(txtstudmob1, e)
        NUM(e)
    End Sub

    Private Sub txtstudmob1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstudmob1.KeyPress
        key(txtfathmob, e)
        NUM(e)
    End Sub

    Private Sub txtfathmob_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfathmob.KeyPress
        key(txtmothmob, e)
        NUM(e)
    End Sub

    Private Sub txtmothmob_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmothmob.KeyPress
        key(cmbreference, e)
        NUM(e)
    End Sub

    Private Sub txtadd2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd2.KeyPress
        key(cmbdist2, e)
        SPKey(e)
    End Sub

    Private Sub cmbcity2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdist2.KeyPress
        key(txtzip2, e)
        SPKey(e)
    End Sub

    Private Sub txtzip2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzip2.KeyPress
        key(txtps2, e)
        NUM(e)
    End Sub

    Private Sub txtps2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtps2.KeyPress
        key(cmbreference, e)
        SPKey(e)
    End Sub

    Private Sub cmbreference_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbreference.KeyPress
        key(txtgrdmob, e)
        SPKey(e)
    End Sub

    Private Sub txtlandno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgrdmob.KeyPress
        key(txtemail, e)
        SPKey(e)
    End Sub

    Private Sub txtemail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtemail.KeyPress
        key(lnknext, e)
        SPKey(e)
    End Sub

    Private Sub cmbunversity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunversity.KeyPress
        key(txtformno, e)
        SPKey(e)
    End Sub

    Private Sub txcolregd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtformno.KeyPress
        key(txtcouncil, e)
        SPKey(e)
    End Sub

    Private Sub txtcouncil_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcouncil.KeyPress
        key(txtdevicecd, e)
        SPKey(e)
    End Sub

    Private Sub txtdevicecd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdevicecd.KeyPress
        key(regdt, e)
        SPKey(e)
    End Sub

    Private Sub regdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles regdt.KeyPress
        key(cmbjointp, e)
    End Sub

    Private Sub cmbjointp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbjointp.KeyPress
        key(txtschnm, e)
        SPKey(e)
    End Sub

    Private Sub txtschnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtschnm.KeyPress
        If txtschnm.Text = "" Then
            key(txtdoccu, e)
        Else
            key(cmbexam, e)
        End If
        SPKey(e)
    End Sub

    Private Sub cmbexam_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbexam.KeyPress
        key(txtyear, e)
        SPKey(e)
    End Sub

    Private Sub txtyear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtyear.KeyPress
        key(txttotmrk, e)
        NUM(e)
    End Sub

    Private Sub txttotmrk_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttotmrk.KeyPress
        key(txtsecmrk, e)
        NUM1(e)
    End Sub

    Private Sub txtsecmrk_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsecmrk.KeyPress
        key(txtper, e)
        NUM1(e)
    End Sub

    Private Sub txtper_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtper.KeyPress
        key(txtcgpa, e)
        NUM1(e)
    End Sub

    Private Sub txtcgpa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcgpa.KeyPress
        key(cmbgrd, e)
        NUM1(e)
    End Sub

    Private Sub cmbgrd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgrd.KeyPress
        key(btnnxt, e)
        SPKey(e)
    End Sub

    Private Sub txtdoccu_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdoccu.KeyPress
        If txtdoccu.Text = "" Then
            key(btnsave, e)
        Else
            key(cmbdocutp, e)
        End If
        SPKey(e)
    End Sub

    Private Sub cmbdocutp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdocutp.KeyPress
        key(btnnxt1, e)
        SPKey(e)
    End Sub
#End Region

#Region "Combo Box"

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

    Private Sub cmbacdmyr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacdmyr.GotFocus
        populate(cmbacdmyr, "SELECT sem_nm FROM semester WHERE rec_lock='N' ORDER BY sem_pos")
    End Sub

    Private Sub cmbacdmyr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacdmyr.LostFocus
        cmbacdmyr.Height = 21
    End Sub

    Private Sub cmbacdmyr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacdmyr.Validated
        vdated(txtacdncd, "SELECT sem_cd FROM semester WHERE sem_nm='" & Trim(cmbacdmyr.Text) & "'")
    End Sub

    Private Sub cmbacdmyr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbacdmyr.Validating
        vdating(cmbacdmyr, "SELECT sem_nm FROM semester WHERE sem_nm='" & Trim(cmbacdmyr.Text) & "' AND rec_lock='N'", "Please Select A Valid Sem/Ac.Year Name.")
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
        vdating(cmbstrm, "SELECT trad_nm FROM trad WHERE trad_nm='" & Trim(cmbstrm.Text) & "' AND rec_lock='N'", "Please Select A Valid Stream/Trade Name.")
    End Sub

    Private Sub cmbunversity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunversity.GotFocus
        populate(cmbunversity, "SELECT uni_pfx FROM universe WHERE rec_lock='N' ORDER BY uni_nm")
    End Sub

    Private Sub cmbunversity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunversity.LostFocus
        cmbunversity.Height = 21
    End Sub

    Private Sub cmbunversity_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunversity.Validated
        vdated(txtunvcd, "SELECT uni_cd FROM universe WHERE uni_pfx='" & Trim(cmbunversity.Text) & "'")
    End Sub

    Private Sub cmbunversity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunversity.Validating
        vdating(cmbunversity, "SELECT uni_pfx FROM universe WHERE uni_pfx='" & Trim(cmbunversity.Text) & "' AND rec_lock='N'", "Please Select A Valid University Name.")
    End Sub

    Private Sub cmbreference_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbreference.GotFocus
        populate(cmbreference, "SELECT pname FROM party WHERE rec_lock='N' AND prt_type='K' ORDER BY pname")
    End Sub

    Private Sub cmbreference_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbreference.LostFocus
        cmbreference.Height = 21
    End Sub

    Private Sub cmbreference_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbreference.Validated
        vdated(txtrefcd, "SELECT prt_code FROM party WHERE pname='" & Trim(cmbreference.Text) & "'")
    End Sub

    Private Sub cmbreference_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbreference.Validating
        vdating(cmbreference, "SELECT pname FROM party WHERE pname='" & Trim(cmbreference.Text) & "' AND rec_lock='N' AND prt_type='K'", "Please Select A Valid Reference Name.")
    End Sub

    Private Sub cmboccu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmboccu.GotFocus
        populate(cmboccu, "SELECT ocu_nm FROM ocupation WHERE rec_lock='N' ORDER BY ocu_nm")
    End Sub

    Private Sub cmboccu_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmboccu.LostFocus
        cmboccu.Height = 21
    End Sub

    Private Sub cmboccu_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmboccu.Validated
        vdated(txtocucd, "SELECT ocu_cd FROM ocupation WHERE ocu_nm='" & Trim(cmboccu.Text) & "'")
    End Sub

    Private Sub cmboccu_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmboccu.Validating
        vdating(cmboccu, "SELECT ocu_nm FROM ocupation WHERE ocu_nm='" & Trim(cmboccu.Text) & "' AND rec_lock='N'", "Please Select A Valid Occupation Name.")
    End Sub

    Private Sub cmbexam_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbexam.GotFocus
        populate(cmbexam, "SELECT edu_nm FROM education WHERE rec_lock='N' ORDER BY edu_nm")
    End Sub

    Private Sub cmbexam_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbexam.LostFocus
        cmbexam.Height = 21
    End Sub

    Private Sub cmbexam_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbexam.Validated
        vdated(txtexmcd, "SELECT edu_cd FROM education WHERE edu_nm='" & Trim(cmbexam.Text) & "'")
    End Sub

    Private Sub cmbexam_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbexam.Validating
        vdating(cmbexam, "SELECT edu_nm FROM education WHERE edu_nm='" & Trim(cmbexam.Text) & "' AND rec_lock='N'", "Please Select A Valid Exam. Name.")
    End Sub

    Private Sub cmbenqmob_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbenqmob.GotFocus
        populate(cmbenqmob, "SELECT cont1 FROM stud_enq WHERE admit='N' ORDER BY cont1")
    End Sub

    Private Sub cmbenqmob_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbenqmob.LostFocus
        cmbenqmob.Height = 21
    End Sub

    Private Sub cmbenqmob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbenqmob.Validated
        vdated(txtenqno, "SELECT enq_no FROM stud_enq WHERE cont1='" & Trim(cmbenqmob.Text) & "'")
        Me.enq_show(Val(txtenqno.Text))
    End Sub

    Private Sub cmbenqmob_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbenqmob.Validating
        vdating(cmbenqmob, "SELECT cont1 FROM stud_enq WHERE cont1='" & Trim(cmbenqmob.Text) & "' AND admit='N'", "Please Select A Valid Contact Number.")
    End Sub

    Private Sub cmbcity1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist1.GotFocus
        populate(cmbdist1, "SELECT dist_nm FROM dist WHERE rec_lock='N' ORDER BY dist_nm")
    End Sub

    Private Sub cmbcity1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist1.LostFocus
        cmbdist1.Height = 21
    End Sub

    Private Sub cmbcity1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist1.Validated
        Dim ds As DataSet = get_dataset("SELECT dist.dist_cd, stat.stat_cd,stat.stat_nm, cntr.cntr_nm FROM cntr RIGHT OUTER JOIN stat ON cntr.cntr_sl = stat.cntr_sl RIGHT OUTER JOIN dist ON stat.stat_cd = dist.stat_cd WHERE (dist.dist_nm = '" & Trim(cmbdist1.Text) & "')")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtdist1cd.Text = ds.Tables(0).Rows(0).Item("dist_cd")
            txtstat1cd.Text = ds.Tables(0).Rows(0).Item("stat_cd")
            txtstate1.Text = ds.Tables(0).Rows(0).Item("stat_nm")
            txtcntr1.Text = ds.Tables(0).Rows(0).Item("cntr_nm")
            If Val(txtdist2cd.Text) = 0 Then
                txtdist2cd.Text = Val(txtdist1cd.Text)
            End If
            If Trim(cmbdist2.Text) = "" Then
                cmbdist2.Text = Trim(cmbdist1.Text)
            End If
            If Val(txtstat2cd.Text) = 0 Then
                txtstat2cd.Text = Val(txtstat1cd.Text)
            End If
            If Trim(txtstate2.Text) = "" Then
                txtstate2.Text = Trim(txtstate1.Text)
            End If
            If Trim(txtcntr2.Text) = "" Then
                txtcntr2.Text = Trim(txtcntr1.Text)
            End If
        End If
    End Sub

    Private Sub cmbcity1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdist1.Validating
        vdating(cmbdist1, "SELECT dist_nm FROM dist WHERE dist_nm='" & Trim(cmbdist1.Text) & "' AND rec_lock='N'", "Please Select A Valid City Name.")
    End Sub

    Private Sub cmbcity2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist2.GotFocus
        populate(cmbdist2, "SELECT dist_nm FROM dist WHERE rec_lock='N' ORDER BY dist_nm")
    End Sub

    Private Sub cmbcity2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist2.LostFocus
        cmbdist2.Height = 21
    End Sub

    Private Sub cmbcity2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist2.Validated
        Dim ds As DataSet = get_dataset("SELECT dist.dist_cd, stat.stat_cd,stat.stat_nm, cntr.cntr_nm FROM cntr RIGHT OUTER JOIN stat ON cntr.cntr_sl = stat.cntr_sl RIGHT OUTER JOIN dist ON stat.stat_cd = dist.stat_cd WHERE (dist.dist_nm = '" & Trim(cmbdist2.Text) & "')")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtdist2cd.Text = ds.Tables(0).Rows(0).Item("dist_cd")
            txtstat2cd.Text = ds.Tables(0).Rows(0).Item("stat_cd")
            txtstate2.Text = ds.Tables(0).Rows(0).Item("stat_nm")
            txtcntr2.Text = ds.Tables(0).Rows(0).Item("cntr_nm")
        End If
    End Sub

    Private Sub cmbcity2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdist2.Validating
        vdating(cmbdist2, "SELECT dist_nm FROM dist WHERE dist_nm='" & Trim(cmbdist1.Text) & "' AND rec_lock='N'", "Please Select A Valid City Name.")
    End Sub

#End Region

#Region "Display"
    Private Sub old_dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT stud.stud_nm, stud.stud_sl, stud.reg_no, stud.pre_add1, stud.per_ph1, stud.dob, stud.gndr,stud.leaved,sesion1.sesn_nm, semester.sem_nm, trad.trad_nm FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd RIGHT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') ORDER BY stud.stud_nm,stud.reg_no")
        dv.Rows.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                dv.Rows.Add()
                dv.Rows(rw).Cells(0).Value = i + 1
                dv.Rows(rw).Cells(1).Value = dsedit.Tables(0).Rows(i).Item("stud_nm")
                dv.Rows(rw).Cells(2).Value = dsedit.Tables(0).Rows(i).Item("reg_no")
                dv.Rows(rw).Cells(3).Value = dsedit.Tables(0).Rows(i).Item("pre_add1")
                dv.Rows(rw).Cells(4).Value = dsedit.Tables(0).Rows(i).Item("per_ph1")
                dv.Rows(rw).Cells(5).Value = Format(dsedit.Tables(0).Rows(i).Item("dob"), "dd/MM/yyyy")
                dv.Rows(rw).Cells(7).Value = dsedit.Tables(0).Rows(i).Item("sesn_nm")
                dv.Rows(rw).Cells(8).Value = dsedit.Tables(0).Rows(i).Item("sem_nm")
                dv.Rows(rw).Cells(9).Value = dsedit.Tables(0).Rows(i).Item("trad_nm")
                dv.Rows(rw).Cells(10).Value = dsedit.Tables(0).Rows(i).Item("stud_sl")
                If dsedit.Tables(0).Rows(rw).Item("leaved") = "Y" Then
                    dv.Rows(rw).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Red
                Else
                    If dsedit.Tables(0).Rows(rw).Item("gndr") = "M" Then
                        dv.Rows(rw).Cells(6).Value = "M"
                        dv.Rows(rw).DefaultCellStyle.BackColor = Color.AliceBlue
                        dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Blue
                    Else
                        dv.Rows(rw).Cells(6).Value = "F"
                        dv.Rows(rw).DefaultCellStyle.BackColor = Color.White
                        dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Black
                    End If
                End If
                rw = rw + 1
            Next
        End If
        dv.Visible = True
        dv.Dock = DockStyle.Fill
        grpsearch.Visible = True
    End Sub

    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud_nm) AS 'Sl.',stud.stud_nm AS 'Student Name', stud.reg_no AS 'Regd. No', stud.pre_add1 AS 'Address', stud.per_ph1 AS 'Mobile No', stud.dob AS 'DOB', stud.gndr AS 'M/F', sesion1.sesn_nm AS 'Session', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch',stud.leaved,stud.stud_sl FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd RIGHT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') ORDER BY stud.stud_nm,stud.reg_no")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(10).Visible = False
            dv.Columns(11).Visible = False
        End If
        For i As Integer = 0 To dv.Rows.Count - 1
            leaved = dv.Rows(i).Cells(10).Value
            gndr = dv.Rows(i).Cells(6).Value
            If leaved = "Y" Then
                dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
            Else
                If gndr = "F" Then
                    'dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                Else
                    'dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            End If
        Next
        dv.Visible = True
        dv.Dock = DockStyle.Fill
        grpsearch.Visible = True
        btnsave.Enabled = True
    End Sub

    Private Sub txtsersearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtserregd.TextChanged
        Me.search()
    End Sub

    Private Sub search()
        Dim dssearch As DataSet
        If txtsername.Text <> "" And txtserregd.Text <> "" Then
            If chkexact.Checked = False And chkexact1.Checked = False Then
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud_nm) AS 'Sl.',stud.stud_nm AS 'Student Name', stud.reg_no AS 'Regd. No', stud.pre_add1 AS 'Address', stud.per_ph1 AS 'Mobile No', stud.dob AS 'DOB', stud.gndr AS 'M/F', sesion1.sesn_nm AS 'Session', semester.sem_nm AS 'Class', trad.trad_nm AS 'Stream',stud.leaved,stud.stud_sl FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd RIGHT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND stud.reg_no LIKE '%" & Trim(txtserregd.Text) & "%' AND stud.stud_nm LIKE '%" & Trim(txtsername.Text) & "%' ORDER BY stud.stud_nm,stud.reg_no")
            Else
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud_nm) AS 'Sl.',stud.stud_nm AS 'Student Name', stud.reg_no AS 'Regd. No', stud.pre_add1 AS 'Address', stud.per_ph1 AS 'Mobile No', stud.dob AS 'DOB', stud.gndr AS 'M/F', sesion1.sesn_nm AS 'Session', semester.sem_nm AS 'Class', trad.trad_nm AS 'Stream',stud.leaved,stud.stud_sl FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd RIGHT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND stud.reg_no LIKE '" & Trim(txtserregd.Text) & "%' AND stud.stud_nm LIKE '" & Trim(txtsername.Text) & "%' ORDER BY stud.stud_nm,stud.reg_no")
            End If
        ElseIf txtserregd.Text <> "" Then
            If chkexact.Checked = False Then
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud_nm) AS 'Sl.',stud.stud_nm AS 'Student Name', stud.reg_no AS 'Regd. No', stud.pre_add1 AS 'Address', stud.per_ph1 AS 'Mobile No', stud.dob AS 'DOB', stud.gndr AS 'M/F', sesion1.sesn_nm AS 'Session', semester.sem_nm AS 'Class', trad.trad_nm AS 'Stream',stud.leaved,stud.stud_sl FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd RIGHT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND stud.reg_no LIKE '%" & Trim(txtserregd.Text) & "%' ORDER BY stud.stud_nm,stud.reg_no")
            Else
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud_nm) AS 'Sl.',stud.stud_nm AS 'Student Name', stud.reg_no AS 'Regd. No', stud.pre_add1 AS 'Address', stud.per_ph1 AS 'Mobile No', stud.dob AS 'DOB', stud.gndr AS 'M/F', sesion1.sesn_nm AS 'Session', semester.sem_nm AS 'Class', trad.trad_nm AS 'Stream',stud.leaved,stud.stud_sl FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd RIGHT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND stud.reg_no LIKE '" & Trim(txtserregd.Text) & "%' ORDER BY stud.stud_nm,stud.reg_no")
            End If
        ElseIf txtsername.Text <> "" Then
            If chkexact1.Checked = False Then
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud_nm) AS 'Sl.',stud.stud_nm AS 'Student Name', stud.reg_no AS 'Regd. No', stud.pre_add1 AS 'Address', stud.per_ph1 AS 'Mobile No', stud.dob AS 'DOB', stud.gndr AS 'M/F', sesion1.sesn_nm AS 'Session', semester.sem_nm AS 'Class', trad.trad_nm AS 'Stream',stud.leaved,stud.stud_sl FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd RIGHT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND  stud.stud_nm LIKE '%" & Trim(txtsername.Text) & "%' ORDER BY stud.stud_nm,stud.reg_no")
            Else
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud_nm) AS 'Sl.',stud.stud_nm AS 'Student Name', stud.reg_no AS 'Regd. No', stud.pre_add1 AS 'Address', stud.per_ph1 AS 'Mobile No', stud.dob AS 'DOB', stud.gndr AS 'M/F', sesion1.sesn_nm AS 'Session', semester.sem_nm AS 'Class', trad.trad_nm AS 'Stream',stud.leaved,stud.stud_sl FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd RIGHT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND  stud.stud_nm LIKE '" & Trim(txtsername.Text) & "%' ORDER BY stud.stud_nm,stud.reg_no")
            End If
        Else
            dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud_nm) AS 'Sl.',stud.stud_nm AS 'Student Name', stud.reg_no AS 'Regd. No', stud.pre_add1 AS 'Address', stud.per_ph1 AS 'Mobile No', stud.dob AS 'DOB', stud.gndr AS 'M/F', sesion1.sesn_nm AS 'Session', semester.sem_nm AS 'Class', trad.trad_nm AS 'Stream',stud.leaved,stud.stud_sl FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd RIGHT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') ORDER BY stud.stud_nm,stud.reg_no")
        End If
        dv.Columns.Clear()
        If dssearch.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dssearch.Tables(0)
            dv.Columns(10).Visible = False
            dv.Columns(11).Visible = False
        End If
        For i As Integer = 0 To dv.Rows.Count - 1
            leaved = dv.Rows(i).Cells(10).Value
            gndr = dv.Rows(i).Cells(6).Value
            If leaved = "Y" Then
                dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
            Else
                If gndr = "F" Then
                    'dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                Else
                    'dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            End If
        Next
    End Sub

    Private Sub txtsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsername.TextChanged
        Me.search()
    End Sub
#End Region

#Region "DATA SAVE"
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(cmbsessn.Text) = "" Or Val(txtsesncd.Text) = 0 Then
            MessageBox.Show("The Session Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            cmbsessn.Focus()
            Exit Sub
        End If
        If Trim(cmbacdmyr.Text) = "" Or Val(txtacdncd.Text) = 0 Then
            MessageBox.Show("The Class Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            cmbacdmyr.Focus()
            Exit Sub
        End If
        If Trim(cmbstrm.Text) = "" Or Val(txtstrmcd.Text) = 0 Then
            MessageBox.Show("The Branch Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            cmbstrm.Focus()
            Exit Sub
        End If
        If Trim(txtregdno.Text) = "" Then
            MessageBox.Show("The Regd. No. Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            txtregdno.Focus()
            Exit Sub
        End If
        If Trim(txtsurnm.Text) = "" Then
            MessageBox.Show("The Sur Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            txtsurnm.Focus()
            Exit Sub
        End If
        If Trim(txtfrstnm.Text) = "" Then
            MessageBox.Show("The First Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            txtfrstnm.Focus()
            Exit Sub
        End If
        If Trim(txtgrdnnm.Text) = "" Then
            MessageBox.Show("The Local Guardian Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            txtgrdnnm.Focus()
            Exit Sub
        End If
        If Trim(txtadd1.Text) = "" Or Trim(txtadd2.Text) = "" Then
            MessageBox.Show("The Address Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            txtadd1.Focus()
            Exit Sub
        End If
        If Trim(cmbdist1.Text) = "" Or Trim(cmbdist2.Text) = "" Or Val(txtdist1cd.Text) = 0 Or Val(txtdist2cd.Text) = 0 Then
            MessageBox.Show("The District Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            cmbdist1.Focus()
            Exit Sub
        End If
        If Trim(txtstudmob.Text) = "" And Trim(txtstudmob1.Text) = "" Then
            MessageBox.Show("The Student Mobile No Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            txtstudmob.Focus()
            Exit Sub
        End If
        If Trim(txtfathmob.Text) = "" Then
            MessageBox.Show("The Father Mobile No Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            txtfathmob.Focus()
            Exit Sub
        End If
        If Trim(cmbunversity.Text) = "" Or Val(txtunvcd.Text) = 0 Then
            MessageBox.Show("The Univercity Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 1
            cmbunversity.Focus()
            Exit Sub
        End If
        Me.stud_save()
    End Sub

    Private Sub stud_save()
        caste = 0
        quota = 0
        If rdgen.Checked = True Then
            caste = 1
        ElseIf rdst.Checked = True Then
            caste = 2
        ElseIf rdsc.Checked = True Then
            caste = 3
        ElseIf rdobc.Checked = True Then
            caste = 4
        End If
        If rdspgen.Checked = True Then
            quota = 1
        ElseIf rdex.Checked = True Then
            quota = 2
        ElseIf rdmart.Checked = True Then
            quota = 3
        ElseIf rdph.Checked = True Then
            quota = 4
        End If
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(stud_sl) as 'Max' FROM stud")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO stud (stud_sl,stud_nm,reg_no,device_code,doj,leaved,cause_leave,hostel_req,dol,pre_add1,pre_add2," & _
                          "pre_zip,pre_ph1,pre_ph2,per_add1,per_add2,per_zip,per_ph1,per_ph2,dob,gndr,married,nation,religion,height,weight," & _
                          "chest,vision,fathr_nm,occu,income,rec_lock,stud_image,council_reg,ocu_cd,pre_ps,per_ps,lg_nm,lg_phno1,uni_cd,stud_usl," & _
                          "mthr_nm,prt_code,join_tp,email,frm_no,pre_dist_cd,per_dist_cd,lg_phno2,stud_caste,stud_quota,fst_nm,mdl_nm,sur_nm," & _
                          "conync_req,cantn_req,sms_req,mail_req,bld_grp,frm_enq,enq_no,reltn) VALUES (" & Val(txtscrl.Text) & ",'" & Trim(txtstudnm.Text) & "','" & _
                          Trim(txtregdno.Text) & "'," & Val(txtdevicecd.Text) & ",'" & Format(regdt.Value, "dd/MMM/yyyy") & "','N','','" & _
                          IIf(chkhostel.Checked, "Y", "N") & "','" & Format(regdt.Value.AddYears(3), "dd/MMM/yyyy") & "','" & Trim(txtadd2.Text) & "','','" & _
                          Trim(txtzip2.Text) & "','" & Trim(txtstudmob.Text) & "','" & Trim(txtstudmob1.Text) & "','" & Trim(txtadd1.Text) & "','" & _
                          Trim(txtadd1.Text) & "','" & Trim(txtzip1.Text) & "','" & Trim(txtfathmob.Text) & "','" & Trim(txtmothmob.Text) & "','" & _
                          Format(dob.Value, "dd/MMM/yyyy") & "','" & IIf(rdmale.Checked, "M", "F") & "','" & IIf(chkmard.Checked, "Y", "N") & "','" & Trim(txtnatnl.Text) & "','" & _
                          Trim(txtrelgn.Text) & "','','','','','" & Trim(txtfthernm.Text) & "','" & Trim(cmboccu.Text) & "','" & _
                          vb.Left(cmbincome.Text, 1) & "','N','','" & Trim(txtcouncil.Text) & "'," & Val(txtocucd.Text) & ",'" & Trim(txtps2.Text) & "','" & _
                          Trim(txtps1.Text) & "','" & Trim(txtgrdnnm.Text) & "','" & Trim(txtgrdmob.Text) & "'," & Val(txtunvcd.Text) & "," & Val(txtscrl.Text) & ",'" & _
                          Trim(txtmthernm.Text) & "'," & Val(txtrefcd.Text) & ",'" & vb.Left(cmbjointp.Text, 1) & "','" & Trim(txtemail.Text) & "','" & _
                          Trim(txtformno.Text) & "'," & Val(txtdist2cd.Text) & "," & Val(txtdist1cd.Text) & ",'" & Trim(txtgrdmob.Text) & "'," & _
                          Val(caste) & "," & Val(quota) & ",'" & Trim(txtfrstnm.Text) & "','" & Trim(txtmdlnm.Text) & "','" & Trim(txtsurnm.Text) & "','" & _
                          IIf(chktrans.Checked, "Y", "N") & "','" & IIf(chkcnteen.Checked, "Y", "N") & "','" & IIf(chksms.Checked, "Y", "N") & "','" & _
                          IIf(chkmail.Checked, "Y", "N") & "','" & vb.Left(cmbbldgrp.Text, 1) & "','" & vb.Left(cmbenq.Text, 1) & "'," & Val(txtenqno.Text) & ",'" & Trim(txtreltn.Text) & "')")
                'stud histry Save
                Me.hstry_save()
                Me.quali_save()
                Me.docu_save()
                If Val(txtenqno.Text) <> 0 Then
                    SQLInsert("UPDATE stud_enq SET admit='Y',stud_sl=" & Val(txtscrl.Text) & " WHERE enq_no=" & Val(txtenqno.Text) & "")
                End If
                If txtphoto.Text = "Y" Then
                    Me.save_image()
                End If
                'sending sms
                Me.sms_send()
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
                Dim ds As DataSet = get_dataset("SELECT stud_sl FROM stud WHERE stud_sl=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE stud SET stud_nm='" & Trim(txtstudnm.Text) & "',reg_no='" & Trim(txtregdno.Text) & "',device_code=" & _
                              Val(txtdevicecd.Text) & ",doj='" & Format(regdt.Value, "dd/MMM/yyyy") & "',hostel_req='" & _
                              IIf(chkhostel.Checked, "Y", "N") & "',pre_add1='" & Trim(txtadd2.Text) & "',pre_zip='" & _
                              Trim(txtzip2.Text) & "',pre_ph1='" & Trim(txtstudmob.Text) & "',pre_ph2='" & _
                              Trim(txtstudmob1.Text) & "',per_add1='" & Trim(txtadd1.Text) & "',per_add2='" & _
                              Trim(txtadd1.Text) & "',per_zip='" & Trim(txtzip1.Text) & "',per_ph1='" & _
                              Trim(txtfathmob.Text) & "',per_ph2='" & Trim(txtmothmob.Text) & "',dob='" & _
                              Format(dob.Value, "dd/MMM/yyyy") & "',gndr='" & IIf(rdmale.Checked, "M", "F") & "',married='" & _
                              IIf(chkmard.Checked, "Y", "N") & "',nation='" & Trim(txtnatnl.Text) & "',religion='" & _
                              Trim(txtrelgn.Text) & "',fathr_nm='" & Trim(txtfthernm.Text) & "',occu='" & Trim(cmboccu.Text) & "',income='" & _
                              vb.Left(cmbincome.Text, 1) & "',stud_image='',council_reg='" & Trim(txtcouncil.Text) & "',ocu_cd=" & _
                              Val(txtocucd.Text) & ",pre_ps='" & Trim(txtps2.Text) & "',per_ps='" & Trim(txtps1.Text) & "',lg_nm='" & _
                              Trim(txtgrdnnm.Text) & "',lg_phno1='" & Trim(txtgrdmob.Text) & "',uni_cd=" & _
                              Val(txtunvcd.Text) & ", mthr_nm='" & Trim(txtmthernm.Text) & "',prt_code=" & _
                              Val(txtrefcd.Text) & ",join_tp='" & vb.Left(cmbjointp.Text, 1) & "',email='" & _
                              Trim(txtemail.Text) & "',frm_no='" & Trim(txtformno.Text) & "',pre_dist_cd=" & _
                              Trim(txtdist2cd.Text) & ",per_dist_cd=" & Trim(txtdist1cd.Text) & ",lg_phno2='" & _
                              Trim(txtgrdmob.Text) & "',stud_caste=" & Val(caste) & ",stud_quota=" & Val(quota) & ",fst_nm='" & _
                              Trim(txtfrstnm.Text) & "',mdl_nm='" & Trim(txtmdlnm.Text) & "',sur_nm='" & Trim(txtsurnm.Text) & "',conync_req='" & _
                              IIf(chktrans.Checked, "Y", "N") & "',cantn_req='" & IIf(chkcnteen.Checked, "Y", "N") & "',sms_req='" & _
                              IIf(chksms.Checked, "Y", "N") & "',mail_req='" & IIf(chkmail.Checked, "Y", "N") & "',bld_grp='" & _
                              vb.Left(cmbbldgrp.Text, 1) & "',frm_enq='" & vb.Left(cmbenq.Text, 1) & "',enq_no=" & _
                              Val(txtenqno.Text) & ",reltn='" & Trim(txtreltn.Text) & "' WHERE stud_sl=" & Val(txtscrl.Text) & "")
                    Me.hstry_save()
                    Me.quali_save()
                    Me.docu_save()
                    If txtphoto.Text = "Y" Then
                        Me.save_image()
                    End If
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                    Me.dv_disp()
                End If
                Close1()
            End If
        End If
    End Sub

    Private Sub sms_send()
        Dim ds As DataSet = get_dataset("SELECT pre_ph1,per_ph1,per_ph2,lg_phno1,reg_no FROM stud WHERE stud_sl = " & Val(txtscrl.Text) & " ")

        If regd_sms = 1 Then
            Dim dsnm As DataSet = get_dataset("SELECT fst_nm FROM stud WHERE stud_sl=" & Val(txtscrl.Text) & "")
            fstnm = dsnm.Tables(0).Rows(0).Item("fst_nm")
            regno = ds.Tables(0).Rows(0).Item("reg_no")
            msg = "Dear " & Trim(fstnm) & ", Welcome To  " & Trim(cosnm) & ". Your Registration No. is : " & Trim(regno) & ". From : " & Trim(cosnm) & "."
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
                    saving_sms(mxno, "Regd. SMS", studmob, msg)
                    mxno += 1
                End If
            End If
            If fath_sms = 1 Then
                fatmob = ds.Tables(0).Rows(0).Item("per_ph1")
                If Len(fatmob) = 10 Then
                    saving_sms(mxno, "Regd. SMS", fatmob, msg)
                    mxno += 1
                End If
            End If
            If moth_sms = 1 Then
                motmob = ds.Tables(0).Rows(0).Item("per_ph2")
                If Len(motmob) = 10 Then
                    saving_sms(mxno, "Regd. SMS", motmob, msg)
                    mxno += 1
                End If
            End If
            If grdn_sms = 1 Then
                grdnmob = ds.Tables(0).Rows(0).Item("lg_phno1")
                If Len(grdnmob) = 10 Then
                    saving_sms(mxno, "Regd. SMS", grdnmob, msg)
                End If
            End If
        End If
    End Sub

    Private Sub hstry_save()
        SQLInsert("DELETE FROM stud_hstry WHERE active='Y'AND stud_sl=" & Val(txtscrl.Text) & "")
        Dim ds1 As DataSet = get_dataset("SELECT max(stud_hstry_sl) as 'Max' FROM stud_hstry")
        mxno = 1
        If ds1.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                mxno = ds1.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        SQLInsert("INSERT INTO stud_hstry(stud_hstry_sl,stud_sl,sesn_cd,sem_cd,trad_cd,reg_no,trans_dt,active,trans_tp,usr_ent,subj_asgn) VALUES (" & Val(mxno) & "," & _
                  Val(txtscrl.Text) & "," & Val(txtsesncd.Text) & "," & Val(txtacdncd.Text) & "," & Val(txtstrmcd.Text) & ",'" & Trim(txtregdno.Text) & "','" & _
                  Format(regdt.Value, "dd/MMM/yyyy") & "','Y','A'," & Val(usr_sl) & ",'N')")
    End Sub

    Private Sub quali_save()
        If dvquali.RowCount <> 0 Then
            SQLInsert("DELETE FROM stud_quali WHERE stud_sl=" & Val(txtscrl.Text) & "")
            For i As Integer = 0 To dvquali.RowCount - 1
                ins_nm = dvquali.Rows(i).Cells(1).Value
                yr = dvquali.Rows(i).Cells(3).Value
                totmrk = dvquali.Rows(i).Cells(4).Value
                secmrk = dvquali.Rows(i).Cells(5).Value
                permrk = dvquali.Rows(i).Cells(6).Value
                cgpa = dvquali.Rows(i).Cells(7).Value
                grade = dvquali.Rows(i).Cells(8).Value
                exm_cd = dvquali.Rows(i).Cells(9).Value
                Dim ds1 As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM stud_quali")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO stud_quali(slno, stud_sl, ins_nm, edu_cd, yr, tot_mark, sec_mark, per_mark, cgpa, grade) VALUES (" & Val(mxno) & "," & _
                          Val(txtscrl.Text) & ",'" & ins_nm & "'," & Val(exm_cd) & ",'" & yr & "'," & Val(totmrk) & "," & Val(secmrk) & "," & Val(permrk) & "," & _
                          Val(cgpa) & ",'" & cmbgrd.Text & "')")
            Next
        End If
    End Sub

    Private Sub docu_save()
        If dvdocu.RowCount <> 0 Then
            SQLInsert("DELETE FROM stud_docu WHERE stud_sl=" & Val(txtscrl.Text) & "")
            For i As Integer = 0 To dvdocu.RowCount - 1
                docu_nm = dvdocu.Rows(i).Cells(1).Value
                docu_tp = vb.Left(dvdocu.Rows(i).Cells(2).Value, 1)
                Dim ds1 As DataSet = get_dataset("SELECT max(docu_cd) as 'Max' FROM stud_docu")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO stud_docu(docu_cd,stud_sl,docu_desc,docu_tp,docu_img) VALUES (" & Val(mxno) & "," & _
                          Val(txtscrl.Text) & ",'" & docu_nm & "','" & docu_tp & "','')")
            Next
        End If
    End Sub

    Private Sub save_image()
        Try
            Dim cmd_img As New SqlCommand("UPDATE stud SET stud_image=@stud_image WHERE stud_sl=" & Val(txtscrl.Text) & "", con_img)
            Dim ms As New MemoryStream()
            pict1.BackgroundImage.Save(ms, pict1.BackgroundImage.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@stud_image", SqlDbType.Image)
            p.Value = data
            cmd_img.Parameters.Add(p)
            con_img.Open()
            cmd_img.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con_img.Close()
        End Try
    End Sub

    Private Sub show_image()
        Dim cmd_img As New SqlCommand("SELECT stud_image FROM stud WHERE stud_sl=" & Val(txtscrl.Text) & " ", con_img)
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
#End Region

#Region "Retrieve"
    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT stud.*, universe.uni_pfx, party.pname, dist.dist_nm, stat.stat_nm, cntr.cntr_nm,DataLength(stud.stud_image) AS stud_img FROM stat LEFT OUTER JOIN cntr ON stat.cntr_sl = cntr.cntr_sl RIGHT OUTER JOIN dist ON stat.stat_cd = dist.stat_cd RIGHT OUTER JOIN stud ON dist.dist_cd = stud.pre_dist_cd LEFT OUTER JOIN party ON stud.prt_code = party.prt_code LEFT OUTER JOIN universe ON stud.uni_cd = universe.uni_cd WHERE (stud.stud_sl = " & Val(slno) & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtstudnm.Text = dsedit.Tables(0).Rows(0).Item("stud_nm")
            txtregdno.Text = dsedit.Tables(0).Rows(0).Item("reg_no")
            txtdevicecd.Text = dsedit.Tables(0).Rows(0).Item("device_code")
            regdt.Value = dsedit.Tables(0).Rows(0).Item("doj")
            txtadd2.Text = dsedit.Tables(0).Rows(0).Item("pre_add1")
            txtzip2.Text = dsedit.Tables(0).Rows(0).Item("pre_zip")
            txtstudmob.Text = dsedit.Tables(0).Rows(0).Item("pre_ph1")
            txtstudmob1.Text = dsedit.Tables(0).Rows(0).Item("pre_ph2")
            txtadd1.Text = dsedit.Tables(0).Rows(0).Item("per_add1")
            txtzip1.Text = dsedit.Tables(0).Rows(0).Item("per_zip")
            txtfathmob.Text = dsedit.Tables(0).Rows(0).Item("per_ph1")
            txtmothmob.Text = dsedit.Tables(0).Rows(0).Item("per_ph2")
            dob.Value = dsedit.Tables(0).Rows(0).Item("dob")
            txtnatnl.Text = dsedit.Tables(0).Rows(0).Item("nation")
            txtrelgn.Text = dsedit.Tables(0).Rows(0).Item("religion")
            txtfthernm.Text = dsedit.Tables(0).Rows(0).Item("fathr_nm")
            cmboccu.Text = dsedit.Tables(0).Rows(0).Item("occu")
            cmbincome.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("income")) - 1
            txtcouncil.Text = dsedit.Tables(0).Rows(0).Item("council_reg")
            txtocucd.Text = dsedit.Tables(0).Rows(0).Item("ocu_cd")
            txtps2.Text = dsedit.Tables(0).Rows(0).Item("pre_ps")
            txtps1.Text = dsedit.Tables(0).Rows(0).Item("per_ps")
            txtgrdnnm.Text = dsedit.Tables(0).Rows(0).Item("lg_nm")
            txtunvcd.Text = dsedit.Tables(0).Rows(0).Item("uni_cd")
            If Val(txtunvcd.Text) <> 0 Then
                cmbunversity.Text = dsedit.Tables(0).Rows(0).Item("uni_pfx")
            End If
            txtmthernm.Text = dsedit.Tables(0).Rows(0).Item("mthr_nm")
            txtrefcd.Text = dsedit.Tables(0).Rows(0).Item("prt_code")
            If Val(txtrefcd.Text) <> 0 Then
                cmbreference.Text = dsedit.Tables(0).Rows(0).Item("pname")
            End If
            cmbjointp.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("join_tp")) - 1
            txtemail.Text = dsedit.Tables(0).Rows(0).Item("email")
            txtformno.Text = dsedit.Tables(0).Rows(0).Item("frm_no")
            txtdist1cd.Text = dsedit.Tables(0).Rows(0).Item("per_dist_cd")
            If Val(txtdist1cd.Text) <> 0 Then
                cmbdist1.Text = dsedit.Tables(0).Rows(0).Item("dist_nm")
                txtstate1.Text = dsedit.Tables(0).Rows(0).Item("stat_nm")
                txtcntr1.Text = dsedit.Tables(0).Rows(0).Item("dist_nm")
            End If
            txtdist2cd.Text = dsedit.Tables(0).Rows(0).Item("pre_dist_cd")
            If Val(txtdist2cd.Text) <> 0 Then
                If Val(txtdist2cd.Text) = Val(txtdist1cd.Text) Then
                    cmbdist2.Text = dsedit.Tables(0).Rows(0).Item("dist_nm")
                    txtstate2.Text = dsedit.Tables(0).Rows(0).Item("stat_nm")
                    txtcntr2.Text = dsedit.Tables(0).Rows(0).Item("dist_nm")
                Else
                    Dim ds As DataSet = get_dataset("SELECT dist.dist_nm, stat.stat_nm, cntr.cntr_nm FROM stat LEFT OUTER JOIN cntr ON stat.cntr_sl = cntr.cntr_sl RIGHT OUTER JOIN dist ON stat.stat_cd = dist.stat_cd WHERE (dist.dist_cd = " & Val(txtdist2cd.Text) & ")")
                    If ds.Tables(0).Rows.Count <> 0 Then
                        cmbdist2.Text = ds.Tables(0).Rows(0).Item("dist_nm")
                        txtstate2.Text = ds.Tables(0).Rows(0).Item("stat_nm")
                        txtcntr2.Text = ds.Tables(0).Rows(0).Item("cntr_nm")
                    End If
                End If
            End If
            txtgrdmob.Text = dsedit.Tables(0).Rows(0).Item("lg_phno2")
            txtfrstnm.Text = dsedit.Tables(0).Rows(0).Item("fst_nm")
            txtmdlnm.Text = dsedit.Tables(0).Rows(0).Item("mdl_nm")
            txtsurnm.Text = dsedit.Tables(0).Rows(0).Item("sur_nm")
            txtreltn.Text = dsedit.Tables(0).Rows(0).Item("reltn")
            cmbbldgrp.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("bld_grp")) - 1
            txtenqno.Text = dsedit.Tables(0).Rows(0).Item("enq_no")
            If dsedit.Tables(0).Rows(0).Item("hostel_req") = "Y" Then
                chkhostel.Checked = True
            Else
                chkhostel.Checked = False
            End If
            If dsedit.Tables(0).Rows(0).Item("hostel_req") = "Y" Then
                chkhostel.Checked = True
            Else
                chkhostel.Checked = False
            End If
            If dsedit.Tables(0).Rows(0).Item("gndr") = "M" Then
                rdmale.Checked = True
            Else
                rdfemale.Checked = True
            End If
            If dsedit.Tables(0).Rows(0).Item("married") = "Y" Then
                chkmard.Checked = True
            Else
                chkmard.Checked = False
            End If
            If dsedit.Tables(0).Rows(0).Item("conync_req") = "Y" Then
                chktrans.Checked = True
            Else
                chktrans.Checked = False
            End If
            If dsedit.Tables(0).Rows(0).Item("cantn_req") = "Y" Then
                chkcnteen.Checked = True
            Else
                chkcnteen.Checked = False
            End If
            If dsedit.Tables(0).Rows(0).Item("sms_req") = "Y" Then
                chksms.Checked = True
            Else
                chksms.Checked = False
            End If
            If dsedit.Tables(0).Rows(0).Item("mail_req") = "Y" Then
                chkmail.Checked = True
            Else
                chkmail.Checked = False
            End If
            If dsedit.Tables(0).Rows(0).Item("frm_enq") = "Y" Then
                cmbenq.SelectedIndex = 1
            Else
                cmbenq.SelectedIndex = 0
            End If
            If dsedit.Tables(0).Rows(0).Item("stud_caste") = 1 Then
                rdgen.Checked = True
            ElseIf dsedit.Tables(0).Rows(0).Item("stud_caste") = 2 Then
                rdst.Checked = True
            ElseIf dsedit.Tables(0).Rows(0).Item("stud_caste") = 3 Then
                rdsc.Checked = True
            Else
                rdobc.Checked = True
            End If
            If dsedit.Tables(0).Rows(0).Item("stud_quota") = 1 Then
                rdspgen.Checked = True
            ElseIf dsedit.Tables(0).Rows(0).Item("stud_quota") = 2 Then
                rdex.Checked = True
            ElseIf dsedit.Tables(0).Rows(0).Item("stud_quota") = 3 Then
                rdmart.Checked = True
            Else
                rdph.Checked = True
            End If
            Dim ds1 As DataSet = get_dataset("SELECT stud_hstry.sesn_cd, stud_hstry.sem_cd, stud_hstry.trad_cd,sesion1.sesn_nm, semester.sem_nm, trad.trad_nm, stud_hstry.stud_sl FROM stud_hstry LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd WHERE (stud_hstry.active = 'Y') AND (stud_hstry.stud_sl = " & Val(txtscrl.Text) & ")")
            If ds1.Tables(0).Rows.Count <> 0 Then
                txtsesncd.Text = ds1.Tables(0).Rows(0).Item("sesn_cd")
                txtacdncd.Text = ds1.Tables(0).Rows(0).Item("sem_cd")
                txtstrmcd.Text = ds1.Tables(0).Rows(0).Item("trad_cd")
                If Val(txtsesncd.Text) <> 0 Then
                    cmbsessn.Text = ds1.Tables(0).Rows(0).Item("sesn_nm")
                End If
                If Val(txtstrmcd.Text) <> 0 Then
                    cmbstrm.Text = ds1.Tables(0).Rows(0).Item("trad_nm")
                End If
                If Val(txtacdncd.Text) <> 0 Then
                    cmbacdmyr.Text = ds1.Tables(0).Rows(0).Item("sem_nm")
                End If
            End If
            img_length = dsedit.Tables(0).Rows(0).Item("stud_img")
            If Val(img_length) <> 0 Then
                txtphoto.Text = "Y"
                Me.show_image()
            End If
            Me.quali_view()
            Me.docu_view()
        End If
        Close1()
    End Sub

    Private Sub quali_view()
        Dim ds As DataSet = get_dataset("SELECT stud_quali.*, education.edu_nm FROM stud_quali LEFT OUTER JOIN education ON stud_quali.edu_cd = education.edu_cd WHERE stud_quali.stud_sl=" & Val(txtscrl.Text) & "")
        rw = 0
        dvquali.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dvquali.Rows.Add()
                dvquali.Rows(rw).Cells(0).Value = i + 1
                dvquali.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("ins_nm")
                dvquali.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("edu_nm")
                dvquali.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("yr")
                dvquali.Rows(rw).Cells(4).Value = Format(ds.Tables(0).Rows(i).Item("tot_mark"), "######0.00")
                dvquali.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(i).Item("sec_mark"), "######0.00")
                dvquali.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("per_mark"), "######0.00")
                dvquali.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("cgpa"), "######0.00")
                dvquali.Rows(rw).Cells(8).Value = ds.Tables(0).Rows(i).Item("grade")
                dvquali.Rows(rw).Cells(9).Value = ds.Tables(0).Rows(i).Item("edu_cd")
                rw += 1
            Next
            txtsl.Text = rw + 1
        End If
    End Sub

    Private Sub docu_view()
        Dim ds As DataSet = get_dataset("SELECT * FROM stud_docu WHERE stud_sl=" & Val(txtscrl.Text) & "")
        rw = 0
        dvdocu.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dvdocu.Rows.Add()
                dvdocu.Rows(rw).Cells(0).Value = i + 1
                dvdocu.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("docu_desc")
                If ds.Tables(0).Rows(i).Item("docu_tp") = "1" Then
                    dvdocu.Rows(rw).Cells(2).Value = "1.Photocopy"
                Else
                    dvdocu.Rows(rw).Cells(2).Value = "2.Original"
                End If
                rw += 1
            Next
            txtsl1.Text = rw + 1
        End If
    End Sub

    Private Sub last_regd()
        lv.GridLines = True
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT TOP(10) reg_no  FROM stud where leaved='N' Order By doj DESC,reg_no DESC")
        lv.Items.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                'lv.Items.Add(dsedit.Tables(0).Rows(i).Item("reg_no"))

                'Me.lv.Columns.Add(dsedit.Tables(0).Rows(i).Item("reg_no"))
                With lv
                    .Items.Add(dsedit.Tables(0).Rows(i).Item("reg_no"))
                    With .Items(.Items.Count - 1).SubItems
                        .Add(dsedit.Tables(0).Rows(i).Item("reg_no"))
                    End With
                End With
            Next
        End If
        Close1()
    End Sub
#End Region



    Private Sub lnkadd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkadd.LinkClicked
        pict1.Image = Nothing
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Set filter options and filter index.
            OpenFileDialog1.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg"
            OpenFileDialog1.FilterIndex = 1
            pict1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
            txtphoto.Text = "Y"
        End If
    End Sub

    Private Sub cmbenq_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbenq.SelectedIndexChanged
        If cmbenq.SelectedIndex = 1 Then
            cmbenqmob.Visible = True
            txtenqno.Visible = True
            lblenqmob.Visible = True
            lblenqno.Visible = True
        Else
            cmbenqmob.Visible = False
            txtenqno.Visible = False
            lblenqmob.Visible = False
            lblenqno.Visible = False
            txtenqno.Text = ""
            cmbenqmob.Text = ""
        End If
    End Sub

    Private Sub dob_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dob.Validated
        txtage.Text = DateDiff(DateInterval.Year, dob.Value, sys_date)
    End Sub


    Private Sub txttotmrk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttotmrk.GotFocus, txtsecmrk.GotFocus, txtper.GotFocus
        If Val(sender.text) = 0 Then
            sender.text = ""
        End If
    End Sub

    Private Sub txttotmrk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttotmrk.LostFocus, txtsecmrk.LostFocus, txtper.LostFocus
        sender.text = Format(Val(sender.text), "######0.00")
    End Sub

    Private Sub txttotmrk_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttotmrk.Validated
        If Val(txttotmrk.Text) <> 0 Or Val(txtsecmrk.Text) <> 0 Then
            txtper.Text = Format((Val(txtsecmrk.Text) / Val(txttotmrk.Text)) * 100, "#####0.00")
        End If
    End Sub

    Private Sub txtsecmrk_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsecmrk.Validated
        If Val(txttotmrk.Text) <> 0 Or Val(txtsecmrk.Text) <> 0 Then
            txtper.Text = Format((Val(txtsecmrk.Text) / Val(txttotmrk.Text)) * 100, "#####0.00")
        End If
    End Sub

    Private Sub txtfthernm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfthernm.LostFocus
        If Trim(txtgrdnnm.Text) = "" Then
            txtgrdnnm.Text = UCase(Trim(txtfthernm.Text))
            txtreltn.Text = "Father"
        End If
    End Sub

    Private Sub lnknext_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnknext.LinkClicked
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub txtstudmob_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtstudmob1.Validating, txtstudmob.Validating, txtmothmob.Validating, txtgrdmob.Validating, txtfathmob.Validating
        If Trim(sender.text) <> "" Then
            If Len(sender.text) <> 10 Then
                e.Cancel = True
                MessageBox.Show("The Mobile No Should Be 10 Digit Only.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TabControl1.SelectedIndex = 0
                sender.focus()
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub txtemail_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtemail.Validating
        If Trim(txtemail.Text) <> "" Then
            If txtemail.Text.IndexOf("@") = -1 OrElse txtemail.Text.IndexOf(".") = -1 Then
                e.Cancel = True
                MessageBox.Show("You Have Enter An Invalid Mail ID.Please Enter A Valid Email ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TabControl1.SelectedIndex = 0
                txtemail.Focus()
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub txtadd1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadd1.LostFocus
        If Trim(txtadd2.Text) = "" Then
            txtadd2.Text = Trim(txtadd1.Text)
        End If
    End Sub

    Private Sub txtzip1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtzip1.LostFocus
        If Trim(txtzip2.Text) = "" Then
            txtzip2.Text = Trim(txtzip1.Text)
        End If
    End Sub

    Private Sub txtps1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtps1.LostFocus
        If Trim(txtps2.Text) = "" Then
            txtps2.Text = Trim(txtps1.Text)
        End If
    End Sub

    Private Sub txtfathmob_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfathmob.LostFocus
        If Trim(txtgrdmob.Text) = "" Then
            txtgrdmob.Text = Trim(txtfathmob.Text)
        End If
    End Sub


    Private Sub txtrelgn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrelgn.LostFocus
        If Trim(txtrelgn.Text) = "" Then
            txtrelgn.Text = "HINDU"
        End If
    End Sub

    Private Sub txtnatnl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnatnl.LostFocus
        If Trim(txtnatnl.Text) = "" Then
            txtnatnl.Text = "INDIAN"
        End If
    End Sub

    Private Sub lnkclr_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkclr.LinkClicked
        pict1.BackgroundImage = My.Resources.photo
        txtphoto.Text = "N"
    End Sub

    Private Sub dob_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dob.ValueChanged
        txtage.Text = DateDiff(DateInterval.Year, dob.Value, sys_date)
    End Sub

    Private Sub pict1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pict1.DoubleClick
        If txtphoto.Text = "Y" Then
            Dim stfpath As String
            If Trim(txtregdno.Text) = "" Then
                stfpath = My.Application.Info.DirectoryPath & "\stud.Jpeg"
            Else
                stfpath = My.Application.Info.DirectoryPath & "\" & Trim(txtregdno.Text) & ".Jpeg"
            End If
            Call image_download(stfpath, pict1, 300, 360)
            'pict1.Size = New Size(413, 531)
            'Dim bmp As New Drawing.Bitmap(pict1.Width, pict1.Height)
            'pict1.DrawToBitmap(bmp, pict1.ClientRectangle)
            'bmp.Save(stfpath, System.Drawing.Imaging.ImageFormat.Jpeg)
            'pict1.Size = New Size(150, 160)
        End If
    End Sub

    Private Sub txtregdno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtregdno.Validating
        If Trim(txtregdno.Text) <> "" Then
            Dim ds As DataSet = get_dataset("SELECT reg_no FROM stud WHERE reg_no='" & Trim(txtregdno.Text) & "'")
            If ds.Tables(0).Rows.Count <> 0 Then
                MessageBox.Show("Sorry The Registration No. Should Not be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtregdno.Focus()
                e.Cancel = True
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub txtenqno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtenqno.Validated
        If Val(txtenqno.Text) <> 0 Then
            Me.enq_show(Val(txtenqno.Text))
        End If
    End Sub

    Private Sub enq_show(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT trad.trad_nm, stud_enq.*, dist.dist_nm, stat.stat_nm, cntr.cntr_nm FROM stat LEFT OUTER JOIN cntr ON stat.cntr_sl = cntr.cntr_sl RIGHT OUTER JOIN dist ON stat.stat_cd = dist.stat_cd RIGHT OUTER JOIN stud_enq ON dist.dist_cd = stud_enq.per_dist_cd LEFT OUTER JOIN trad ON stud_enq.trad_cd = trad.trad_cd WHERE (stud_enq.enq_no = " & Val(slno) & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtstudnm.Text = dsedit.Tables(0).Rows(0).Item("stud_nm")
            txtadd2.Text = dsedit.Tables(0).Rows(0).Item("add2")
            txtzip2.Text = dsedit.Tables(0).Rows(0).Item("pre_zip")
            txtstudmob.Text = dsedit.Tables(0).Rows(0).Item("cont1")
            txtstudmob1.Text = dsedit.Tables(0).Rows(0).Item("cont2")
            txtadd1.Text = dsedit.Tables(0).Rows(0).Item("add1")
            txtzip1.Text = dsedit.Tables(0).Rows(0).Item("per_zip")
            txtfthernm.Text = dsedit.Tables(0).Rows(0).Item("fgh_nm")
            txtps2.Text = dsedit.Tables(0).Rows(0).Item("pre_ps")
            txtps1.Text = dsedit.Tables(0).Rows(0).Item("per_ps")
            txtmthernm.Text = dsedit.Tables(0).Rows(0).Item("mthr_nm")
            txtemail.Text = dsedit.Tables(0).Rows(0).Item("email")
            txtdist1cd.Text = dsedit.Tables(0).Rows(0).Item("per_dist_cd")
            If Val(txtdist1cd.Text) <> 0 Then
                cmbdist1.Text = dsedit.Tables(0).Rows(0).Item("dist_nm")
                txtstate1.Text = dsedit.Tables(0).Rows(0).Item("stat_nm")
                txtcntr1.Text = dsedit.Tables(0).Rows(0).Item("dist_nm")
            End If
            txtdist2cd.Text = dsedit.Tables(0).Rows(0).Item("pre_dist_cd")
            If Val(txtdist2cd.Text) <> 0 Then
                If Val(txtdist2cd.Text) = Val(txtdist1cd.Text) Then
                    cmbdist2.Text = dsedit.Tables(0).Rows(0).Item("dist_nm")
                    txtstate2.Text = dsedit.Tables(0).Rows(0).Item("stat_nm")
                    txtcntr2.Text = dsedit.Tables(0).Rows(0).Item("dist_nm")
                Else
                    Dim ds As DataSet = get_dataset("SELECT dist.dist_nm, stat.stat_nm, cntr.cntr_nm FROM stat LEFT OUTER JOIN cntr ON stat.cntr_sl = cntr.cntr_sl RIGHT OUTER JOIN dist ON stat.stat_cd = dist.stat_cd WHERE (dist.dist_cd = " & Val(txtdist2cd.Text) & ")")
                    If ds.Tables(0).Rows.Count <> 0 Then
                        cmbdist2.Text = ds.Tables(0).Rows(0).Item("dist_nm")
                        txtstate2.Text = ds.Tables(0).Rows(0).Item("stat_nm")
                        txtcntr2.Text = ds.Tables(0).Rows(0).Item("cntr_nm")
                    End If
                End If
            End If
            txtfrstnm.Text = dsedit.Tables(0).Rows(0).Item("fst_nm")
            txtmdlnm.Text = dsedit.Tables(0).Rows(0).Item("mdl_nm")
            txtsurnm.Text = dsedit.Tables(0).Rows(0).Item("sur_nm")
            If dsedit.Tables(0).Rows(0).Item("gndr") = "M" Then
                rdmale.Checked = True
            Else
                rdfemale.Checked = True
            End If
            Me.enqquali_view()
        End If
        Close1()
    End Sub

    Private Sub enqquali_view()
        Dim ds As DataSet = get_dataset("SELECT stud_enq_quali.*, education.edu_nm FROM stud_enq_quali LEFT OUTER JOIN education ON stud_enq_quali.edu_cd = education.edu_cd WHERE stud_enq_quali.enq_no=" & Val(txtenqno.Text) & "")
        rw = 0
        dvquali.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dvquali.Rows.Add()
                dvquali.Rows(rw).Cells(0).Value = i + 1
                dvquali.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("ins_nm")
                dvquali.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("edu_nm")
                dvquali.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("yr")
                dvquali.Rows(rw).Cells(4).Value = Format(ds.Tables(0).Rows(i).Item("tot_mark"), "######0.00")
                dvquali.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(i).Item("sec_mark"), "######0.00")
                dvquali.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("per_mark"), "######0.00")
                dvquali.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("cgpa"), "######0.00")
                dvquali.Rows(rw).Cells(8).Value = ds.Tables(0).Rows(i).Item("grade")
                dvquali.Rows(rw).Cells(9).Value = ds.Tables(0).Rows(i).Item("edu_cd")
                rw += 1
            Next
            txtsl.Text = rw + 1
        End If
    End Sub

    Private Sub txtenqno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtenqno.GotFocus
        'Me.clr()
    End Sub

    Private Sub chkexact_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkexact.CheckedChanged
        Me.search()
    End Sub

    Private Sub chkexact1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkexact1.CheckedChanged
        Me.search()
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click, btndelete.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            If usr_tp = "A" Or usr_tp = "D" Then
                slno = dv.SelectedRows(0).Cells(11).Value
                cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Start1()
                If cnfr = vbYes Then
                    Dim ds As DataSet = get_dataset("SELECT stud_sl FROM stud WHERE stud_sl=" & Val(slno) & "")
                    If ds.Tables(0).Rows.Count <> 0 Then
                        'Dim ds1 As DataSet = get_dataset("SELECT coll_cd FROM prod_mst WHERE coll_cd=" & Val(slno) & "")
                        'If ds1.Tables(0).Rows.Count <> 0 Then
                        '    fnd = 1
                        'End If
                        If fnd = 0 Then
                            SQLInsert("DELETE FROM stud WHERE stud_sl =" & Val(slno) & "")
                            SQLInsert("DELETE FROM stud_quali WHERE stud_sl =" & Val(slno) & "")
                            SQLInsert("DELETE FROM stud_hstry WHERE stud_sl =" & Val(slno) & "")
                            MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.dv_disp()
                        Else
                            MessageBox.Show("Sorry You Can't Delete The Student It Has Been Already Used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If
                    Close1()
                End If
            Else
                MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub cmenu2del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenu2del.Click
        For Each row As DataGridViewRow In dvdocu.SelectedRows
            dvdocu.Rows.Remove(row)
        Next
        sl = 1
        For i As Integer = 0 To dvdocu.Rows.Count - 1
            dvdocu.Rows(i).Cells(0).Value = i + 1
            sl += 1
        Next
        txtsl1.Text = sl
    End Sub

    Private Sub cmnu1del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1del.Click
        For Each row As DataGridViewRow In dvquali.SelectedRows
            dvquali.Rows.Remove(row)
        Next
        sl = 1
        For i As Integer = 0 To dvquali.Rows.Count - 1
            dvquali.Rows(i).Cells(0).Value = i + 1
            sl += 1
        Next
        txtsl.Text = sl
    End Sub

    Private Sub mnuexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexport.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        studnm = InputBox("Enter The Student Name.", "Search Box...", Nothing)
        If (studnm Is Nothing OrElse studnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud_nm) AS 'Sl.',stud.stud_nm AS 'Student Name', stud.reg_no AS 'Regd. No', stud.pre_add1 AS 'Address', stud.per_ph1 AS 'Mobile No', stud.dob AS 'DOB', stud.gndr AS 'M/F', sesion1.sesn_nm AS 'Session', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch',stud.leaved,stud.stud_sl FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd RIGHT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.stud_nm LIKE'" & studnm & "%') ORDER BY stud.stud_nm,stud.reg_no")
            dv.Columns.Clear()
            If dsedit.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dsedit.Tables(0)
                dv.Columns(10).Visible = False
                dv.Columns(11).Visible = False
            End If
            For i As Integer = 0 To dv.Rows.Count - 1
                leaved = dv.Rows(i).Cells(10).Value
                gndr = dv.Rows(i).Cells(6).Value
                If leaved = "Y" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    If gndr = "F" Then
                        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                    Else
                        dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    End If
                End If
            Next
        End If
    End Sub

   
End Class
