Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO

Public Class frmenqiry
    Dim comd As String = "E"
    Dim con_img As New SqlConnection(connectionstrng)
    Dim cmd_img As SqlCommand
    Dim fdt1, fdt2, fdt3, fdt4, pdt1, pdt2, pdt3, pdt4 As Date


#Region "START UP"
    Private Sub frmenqiry_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnustudenq.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmenqiry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmenqiry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        MDI.mnustudenq.Enabled = False
        usrprmsn("mnu_studenq", cmnuadd, cmnuedit, cmenudel, cmenuview)
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
        'If cmnuadd.Enabled = True Then
        '    btnadd.Enabled = True
        'Else
        '    btnadd.Enabled = False
        'End If
        cmbmedia.SelectedIndex = 0
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub clr()
        TabControl1.SelectedIndex = 0
        dvrmrk.Rows.Clear()
        txtphoto.Text = "N"
        txtzip1.Text = ""
        txtsurnm.Text = ""
        txtstudmob.Text = ""
        txtstudmob1.Text = ""
        txtserregd.Text = ""
        txtsername.Text = ""
        'txtregdno.Text = ""
        txtmthernm.Text = ""
        txtmdlnm.Text = ""
        txtfthernm.Text = ""
        txtfrstnm.Text = ""
        txtenqno.Text = ""
        txtemail.Text = ""
        txtadd2.Text = ""
        txtadd1.Text = ""
        cmbstrm.Text = ""
        cmbdist2.Text = ""
        cmbdist1.Text = ""
        txtstate1.Text = ""
        txtstate2.Text = ""
        txtcntr1.Text = ""
        txtcntr2.Text = ""
        txtremark.Text = ""
        txtother.Text = ""
        txtcourse.Text = ""
        txtps1.Text = ""
        txtps2.Text = ""
        txtzip2.Text = ""
        prefdt.Value = sys_date
        dv.Columns.Clear()
        dvquali.Rows.Clear()
        txtenqno.Text = 0
        txtacdncd.Text = 0
        txtstrmcd.Text = 0
        txtsesncd.Text = 0
        txtocucd.Text = 0
        txtunvcd.Text = 0
        txtdist1cd.Text = 0
        txtdist2cd.Text = 0
        txtstat1cd.Text = 0
        txtstat2cd.Text = 0
        txtrefcd.Text = 0
        txtsl.Text = 1
        txtdays.Text = "30"
        Me.Text = "Student Enquiry Entry Screen . . ."
        Dim ds As DataSet = get_dataset("SELECT max(enq_no) as 'Max' FROM stud_enq")
        txtenqno.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtenqno.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        cmbstrm.Focus()
        Me.clr1()
        Me.follup_disp()
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

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtzip2.Enter, txtzip1.Enter, txtsurnm.Enter, txtstudmob.Enter, txtserregd.Enter, txtsername.Enter, txtmthernm.Enter, txtmdlnm.Enter, txtfthernm.Enter, txtfrstnm.Enter, txtenqno.Enter, txtadd2.Enter, txtadd1.Enter, cmbstrm.Enter, cmbdist2.Enter, cmbdist1.Enter, txtremark.Enter, txtother.Enter, txtcourse.Enter, txtps1.Enter, txtps2.Enter, cmbmedia.Enter, txtdays.Enter, txtschnm.Enter, txtyear.Enter, txttotmrk.Enter, txtsecmrk.Enter, txtcgpa.Enter, txtper.Enter, cmbgrd.Enter, cmbexam.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtzip2.Leave, txtzip1.Leave, txtsurnm.Leave, txtstudmob.Leave, txtserregd.Leave, txtsername.Leave, txtmthernm.Leave, txtmdlnm.Leave, txtfthernm.Leave, txtfrstnm.Leave, txtenqno.Leave, txtadd2.Leave, txtadd1.Leave, cmbstrm.Leave, cmbdist2.Leave, cmbdist1.Leave, txtremark.Leave, txtother.Leave, txtcourse.Leave, txtps1.Leave, txtps2.Leave, cmbmedia.Leave, txtdays.Leave, txtschnm.Leave, txtyear.Leave, txttotmrk.Leave, txtsecmrk.Leave, txtcgpa.Leave, txtper.Leave, cmbgrd.Leave, cmbexam.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

        sender.text = UCase(sender.text)
    End Sub

    Private Sub txtmail_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtemail.Enter
        txtemail.ForeColor = Color.Blue
        txtemail.BackColor = Color.LavenderBlush
        txtemail.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Bold)
    End Sub

    Private Sub txtmail_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtemail.Leave
        txtemail.ForeColor = Color.Black
        txtemail.BackColor = Color.White
        txtemail.Text = LCase(Trim(txtemail.Text))
        txtemail.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Regular)
    End Sub
#End Region

#Region "BUTTONS"
    Private Sub btndelete_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter, btnedit.MouseEnter, btndelete.MouseEnter, btnadd.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btndelete_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave, btnedit.MouseLeave, btndelete.MouseLeave, btnadd.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click, cmnuadd.Click
        comd = "E"
        btnsave.Text = "Save."
        Me.Text = "Student Enquiry Entry Screen . . ."
        Me.clr()
        For i As Integer = 0 To dv.Height = 10
            dv.Height = dv.Height - 1
        Next
        dv.Visible = False
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click, cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Student Enquiry Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(9).Value
            Me.dv_edit(slno)
            For i As Integer = 0 To dv.Width = 10
                dv.Width = dv.Width - 1
            Next
            dv.Visible = False
            txtsurnm.Focus()
        End If
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            btnsave.Enabled = False
            Me.Text = "Student Enquiry View Screen . . ."
            slno = dv.SelectedRows(0).Cells(9).Value
            Me.dv_edit(slno)
            For i As Integer = 0 To dv.Width = 10
                dv.Width = dv.Width - 1
            Next
            dv.Visible = False
            txtsurnm.Focus()
        End If
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        comd = "E"
        If dv.Visible = True Then
            Me.dv_disp()
        Else
            Me.clr()
        End If
    End Sub

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

    Private Sub btnclr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclr.Click
        dvquali.Rows.Clear()
        txtsl.Text = "1"
        Me.clr1()
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

    Private Sub txtenqno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtenqno.KeyPress
        key(enqdt, e)
        SPKey(e)
    End Sub

    Private Sub enqdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles enqdt.KeyPress
        key(cmbstrm, e)
    End Sub

    Private Sub cmbstrm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstrm.KeyPress
        key(txtsurnm, e)
        SPKey(e)
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
        key(txtemail, e)
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
        key(txtemail, e)
        SPKey(e)
    End Sub

    Private Sub txtemail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtemail.KeyPress
        key(txtschnm, e)
        SPKey(e)
    End Sub

    Private Sub txtschnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtschnm.KeyPress
        If txtschnm.Text = "" Then
            key(lnknext, e)
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

    Private Sub txtcourse_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcourse.KeyPress
        key(cmbmedia, e)
        SPKey(e)
    End Sub

    Private Sub cmbmedia_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbmedia.KeyPress
        If txtother.Visible = True Then
            key(txtother, e)
        Else
            key(prefdt, e)
        End If
        SPKey(e)
    End Sub

    Private Sub txtcouncil_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtother.KeyPress
        key(prefdt, e)
        SPKey(e)
    End Sub

    Private Sub regdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles prefdt.KeyPress
        key(txtremark, e)
    End Sub

    Private Sub txtdevicecd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtremark.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub
#End Region

#Region "Combo Box"

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

#End Region

#Region "Display"
    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud_nm) AS 'Sl.',CONVERT(VARCHAR,stud_enq.ernq_dt,103) AS 'Date',stud_enq.stud_nm AS 'Student Name',stud_enq.add1 AS 'Address',stud_enq.cont1 AS 'Mob',stud_enq.gndr AS 'M/F',trad.trad_nm AS 'Branch',stud_enq.admit AS 'Admit',stud_enq.nb1 AS 'Remark',stud_enq.enq_no FROM stud_enq LEFT OUTER JOIN trad ON stud_enq.trad_cd = trad.trad_cd ORDER BY stud_enq.ernq_dt")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(9).Visible = False
            'dv.Columns(11).Visible = False
        End If
        For i As Integer = 0 To dv.Rows.Count - 1
            admit = dv.Rows(i).Cells(7).Value
            gndr = dv.Rows(i).Cells(5).Value
            If admit = "Y" Then
                dv.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
            Else
                dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
        dv.Visible = True
        dv.Dock = DockStyle.Fill
        btnsave.Enabled = True
    End Sub

    Private Sub txtsersearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtserregd.TextChanged
        Me.search()
    End Sub

    Private Sub search()
        Start1()
        Dim dssearch As DataSet
        If txtsername.Text <> "" And txtserregd.Text <> "" Then
            If chkexact.Checked = False And chkexact1.Checked = False Then
                dssearch = get_dataset("SELECT stud_enq.*, trad.trad_nm FROM stud_enq LEFT OUTER JOIN trad ON stud_enq.trad_cd = trad.trad_cd WHERE stud_enq.reg_no LIKE '%" & Trim(txtserregd.Text) & "%' AND stud_enq.stud_nm LIKE '%" & Trim(txtsername.Text) & "%' ORDER BY stud_enq.ernq_dt")
            Else
                dssearch = get_dataset("SELECT stud_enq.*, trad.trad_nm FROM stud_enq LEFT OUTER JOIN trad ON stud_enq.trad_cd = trad.trad_cd WHERE stud_enq.reg_no LIKE '" & Trim(txtserregd.Text) & "%' AND stud_enq.stud_nm LIKE '" & Trim(txtsername.Text) & "%' ORDER BY stud_enq.ernq_dt")
            End If
        ElseIf txtserregd.Text <> "" Then
            If chkexact.Checked = False Then
                dssearch = get_dataset("SELECT stud_enq.*, trad.trad_nm FROM stud_enq LEFT OUTER JOIN trad ON stud_enq.trad_cd = trad.trad_cd WHERE stud_enq.reg_no LIKE '%" & Trim(txtserregd.Text) & "%' ORDER BY stud_enq.ernq_dt")
            Else
                dssearch = get_dataset("SELECT stud_enq.*, trad.trad_nm FROM stud_enq LEFT OUTER JOIN trad ON stud_enq.trad_cd = trad.trad_cd WHERE stud_enq.reg_no LIKE '" & Trim(txtserregd.Text) & "%' ORDER BY stud_enq.ernq_dt")
            End If
        ElseIf txtsername.Text <> "" Then
            If chkexact1.Checked = False Then
                dssearch = get_dataset("SELECT stud_enq.*, trad.trad_nm FROM stud_enq LEFT OUTER JOIN trad ON stud_enq.trad_cd = trad.trad_cd WHERE stud_enq.stud_nm LIKE '%" & Trim(txtsername.Text) & "%' ORDER BY stud_enq.ernq_dt")
            Else
                dssearch = get_dataset("SELECT stud_enq.*, trad.trad_nm FROM stud_enq LEFT OUTER JOIN trad ON stud_enq.trad_cd = trad.trad_cd WHERE stud_enq.stud_nm LIKE '" & Trim(txtsername.Text) & "%' ORDER BY stud_enq.ernq_dt")
            End If
        Else
            dssearch = get_dataset("SELECT stud_enq.*, trad.trad_nm FROM stud_enq LEFT OUTER JOIN trad ON stud_enq.trad_cd = trad.trad_cd ORDER BY stud_enq.ernq_dt")
        End If
            dv.Rows.Clear()
            If dssearch.Tables(0).Rows.Count <> 0 Then
                Dim rw As Integer = 0
                For i As Integer = 0 To dssearch.Tables(0).Rows.Count - 1
                dv.Rows.Add()
                dv.Rows(rw).Cells(0).Value = i + 1
                dv.Rows(rw).Cells(1).Value = Format(dssearch.Tables(0).Rows(i).Item("enq_dt"), "dd/MM/yyyy")
                dv.Rows(rw).Cells(2).Value = dssearch.Tables(0).Rows(i).Item("stud_nm")
                dv.Rows(rw).Cells(3).Value = dssearch.Tables(0).Rows(i).Item("pre_add1")
                dv.Rows(rw).Cells(4).Value = dssearch.Tables(0).Rows(i).Item("per_ph1")
                If dssearch.Tables(0).Rows(rw).Item("gndr") = "1" Then
                    dv.Rows(rw).Cells(5).Value = "M"
                Else
                    dv.Rows(rw).Cells(5).Value = "F"
                End If
                dv.Rows(rw).Cells(6).Value = dssearch.Tables(0).Rows(i).Item("trad_nm")
                dv.Rows(rw).Cells(7).Value = dssearch.Tables(0).Rows(i).Item("admit")
                dv.Rows(rw).Cells(8).Value = dssearch.Tables(0).Rows(i).Item("nb1")
                dv.Rows(rw).Cells(9).Value = dssearch.Tables(0).Rows(i).Item("enq_no")
                If dssearch.Tables(0).Rows(rw).Item("admit") = "Y" Then
                    dv.Rows(rw).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Blue
                ElseIf dssearch.Tables(0).Rows(rw).Item("admit") = "N" Then
                    dv.Rows(rw).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Red
                End If
                    rw = rw + 1
                Next
            End If
            Close1()
    End Sub

    Private Sub txtsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsername.TextChanged
        Me.search()
    End Sub
#End Region

#Region "DATA SAVE"
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(cmbstrm.Text) = "" Or Val(txtstrmcd.Text) = 0 Then
            MessageBox.Show("The Branch Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            cmbstrm.Focus()
            Exit Sub
        End If
        If Trim(txtsurnm.Text) = "" Then
            MessageBox.Show("The Sur Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            txtsurnm.Focus()
            Exit Sub
        End If
        If Trim(txtfrstnm.Text) = "" Then
            MessageBox.Show("The First Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            txtfrstnm.Focus()
            Exit Sub
        End If
        If Trim(txtadd1.Text) = "" Or Trim(txtadd2.Text) = "" Then
            MessageBox.Show("The Address Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            txtadd1.Focus()
            Exit Sub
        End If
        If Trim(cmbdist1.Text) = "" Or Trim(cmbdist2.Text) = "" Or Val(txtdist1cd.Text) = 0 Or Val(txtdist2cd.Text) = 0 Then
            MessageBox.Show("The District Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            cmbdist1.Focus()
            Exit Sub
        End If
        If Trim(txtstudmob.Text) = "" And Trim(txtstudmob1.Text) = "" Then
            MessageBox.Show("The Student Mobile No Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            txtstudmob.Focus()
            Exit Sub
        End If

        Me.stud_save()
    End Sub

    Private Sub stud_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(enq_no) as 'Max' FROM stud_enq")
                txtenqno.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtenqno.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO stud_enq (enq_no,ernq_dt,stud_nm,f_g_h,fgh_nm,add1,add2,cont1,cont2,trad_cd,media_tp,media_oth,prfr_dt,nb1,nb2," & _
                          "nb3,nb4,nb5,stud_sl,admit,frm_no,course_descri,fst_nm,mdl_nm,sur_nm,mthr_nm,per_dist_cd,pre_dist_cd,per_zip,pre_zip," & _
                          "per_ps,pre_ps,email,gndr,prfr_dt2,prfr_dt3,prfr_dt4,prfr_dt5,flup_dt1,flup_dt2,flup_dt3,flup_dt4,flup_dt5) VALUES (" & _
                          Val(txtenqno.Text) & ",'" & Format(enqdt.Value, "dd/MMM/yyyy") & "','" & Trim(txtstudnm.Text) & "','','" & _
                          Trim(txtfthernm.Text) & "','" & Trim(txtadd1.Text) & "','" & Trim(txtadd2.Text) & "','" & Trim(txtstudmob.Text) & "','" & _
                          Trim(txtstudmob1.Text) & "'," & Val(txtstrmcd.Text) & ",'" & vb.Left(cmbmedia.Text, 1) & "','" & Trim(txtother.Text) & "','" & _
                          Format(prefdt.Value, "dd/MMM/yyyy") & "','" & Trim(txtremark.Text) & "','','','','',0,'N','','" & Trim(txtcourse.Text) & "','" & _
                          Trim(txtfrstnm.Text) & "','" & Trim(txtmdlnm.Text) & "','" & Trim(txtsurnm.Text) & "','" & Trim(txtmthernm.Text) & "'," & _
                          Val(txtdist1cd.Text) & "," & Val(txtdist1cd.Text) & ",'" & Trim(txtzip1.Text) & "','" & Trim(txtzip2.Text) & "','" & _
                          Trim(txtps1.Text) & "','" & Trim(txtps2.Text) & "','" & Trim(txtemail.Text) & "','" & IIf(rdmale.Checked, "M", "F") & "','" & _
                          Format(enqdt.Value, "dd/MMM/yyyy") & "','" & Format(enqdt.Value, "dd/MMM/yyyy") & "','" & Format(enqdt.Value, "dd/MMM/yyyy") & "','" & _
                          Format(enqdt.Value, "dd/MMM/yyyy") & "','" & Format(enqdt.Value, "dd/MMM/yyyy") & "','" & Format(enqdt.Value, "dd/MMM/yyyy") & "','" & _
                          Format(enqdt.Value, "dd/MMM/yyyy") & "','" & Format(enqdt.Value, "dd/MMM/yyyy") & "','" & Format(enqdt.Value, "dd/MMM/yyyy") & "' )")
                Me.quali_save()
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
                Dim ds As DataSet = get_dataset("SELECT enq_no FROM stud_enq WHERE enq_no=" & Val(txtenqno.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE stud_enq SET ernq_dt='" & Format(enqdt.Value, "dd/MMM/yyyy") & "' ,stud_nm='" & Trim(txtstudnm.Text) & "',f_g_h='',fgh_nm='" & _
                              Trim(txtfthernm.Text) & "',add1='" & Trim(txtadd1.Text) & "',add2='" & Trim(txtadd2.Text) & "',cont1='" & _
                              Trim(txtstudmob.Text) & "',cont2='" & Trim(txtstudmob1.Text) & "',trad_cd=" & Val(txtstrmcd.Text) & ",media_tp='" & _
                              vb.Left(cmbmedia.Text, 1) & "',media_oth='" & Trim(txtother.Text) & "',prfr_dt='" & Format(prefdt.Value, "dd/MMM/yyyy") & "',nb1='" & _
                              Trim(txtremark.Text) & "',course_descri='" & Trim(txtcourse.Text) & "',fst_nm='" & Trim(txtfrstnm.Text) & "',mdl_nm='" & _
                              Trim(txtmdlnm.Text) & "',sur_nm='" & Trim(txtsurnm.Text) & "',mthr_nm='" & Trim(txtmthernm.Text) & "',per_dist_cd=" & _
                              Val(txtdist1cd.Text) & ",pre_dist_cd=" & Val(txtdist2cd.Text) & ",per_zip='" & Trim(txtzip1.Text) & "',pre_zip='" & _
                              Trim(txtzip2.Text) & "',per_ps='" & Trim(txtps1.Text) & "',pre_ps='" & Trim(txtps2.Text) & "',email='" & _
                              Trim(txtemail.Text) & "',gndr='" & IIf(rdmale.Checked, "M", "F") & "' WHERE enq_no=" & Val(txtenqno.Text) & "")
                    Me.quali_save()
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                    Me.dv_disp()
                End If
                Close1()
            End If
        End If
    End Sub

    Private Sub quali_save()
        If dvquali.RowCount <> 0 Then
            SQLInsert("DELETE FROM stud_enq_quali WHERE enq_no=" & Val(txtenqno.Text) & "")
            For i As Integer = 0 To dvquali.RowCount - 1
                ins_nm = dvquali.Rows(i).Cells(1).Value
                yr = dvquali.Rows(i).Cells(3).Value
                totmrk = dvquali.Rows(i).Cells(4).Value
                secmrk = dvquali.Rows(i).Cells(5).Value
                permrk = dvquali.Rows(i).Cells(6).Value
                cgpa = dvquali.Rows(i).Cells(7).Value
                grade = dvquali.Rows(i).Cells(8).Value
                exm_cd = dvquali.Rows(i).Cells(9).Value
                Dim ds1 As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM stud_enq_quali")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO stud_enq_quali(slno, enq_no, ins_nm, edu_cd, yr, tot_mark, sec_mark, per_mark, cgpa, grade) VALUES (" & Val(mxno) & "," & _
                          Val(txtenqno.Text) & ",'" & ins_nm & "'," & Val(exm_cd) & ",'" & yr & "'," & Val(totmrk) & "," & Val(secmrk) & "," & Val(permrk) & "," & _
                          Val(cgpa) & ",'" & cmbgrd.Text & "')")
            Next
        End If
    End Sub
#End Region

#Region "Retrieve"
    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT trad.trad_nm, stud_enq.*, dist.dist_nm, stat.stat_nm, cntr.cntr_nm FROM stat LEFT OUTER JOIN cntr ON stat.cntr_sl = cntr.cntr_sl RIGHT OUTER JOIN dist ON stat.stat_cd = dist.stat_cd RIGHT OUTER JOIN stud_enq ON dist.dist_cd = stud_enq.per_dist_cd LEFT OUTER JOIN trad ON stud_enq.trad_cd = trad.trad_cd WHERE (stud_enq.enq_no = " & Val(slno) & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtenqno.Text = slno
            txtstudnm.Text = dsedit.Tables(0).Rows(0).Item("stud_nm")
            txtremark.Text = dsedit.Tables(0).Rows(0).Item("nb1")
            prefdt.Value = dsedit.Tables(0).Rows(0).Item("prfr_dt")
            txtadd2.Text = dsedit.Tables(0).Rows(0).Item("add2")
            txtzip2.Text = dsedit.Tables(0).Rows(0).Item("pre_zip")
            txtstudmob.Text = dsedit.Tables(0).Rows(0).Item("cont1")
            txtstudmob1.Text = dsedit.Tables(0).Rows(0).Item("cont2")
            txtadd1.Text = dsedit.Tables(0).Rows(0).Item("add1")
            txtzip1.Text = dsedit.Tables(0).Rows(0).Item("per_zip")
            txtfthernm.Text = dsedit.Tables(0).Rows(0).Item("fgh_nm")
            txtother.Text = dsedit.Tables(0).Rows(0).Item("media_oth")
            txtps2.Text = dsedit.Tables(0).Rows(0).Item("pre_ps")
            txtps1.Text = dsedit.Tables(0).Rows(0).Item("per_ps")
            txtmthernm.Text = dsedit.Tables(0).Rows(0).Item("mthr_nm")
            txtemail.Text = dsedit.Tables(0).Rows(0).Item("email")
            txtcourse.Text = dsedit.Tables(0).Rows(0).Item("course_descri")
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
            Me.quali_view()
        End If
        Close1()
    End Sub

    Private Sub quali_view()
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

#End Region
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

    Private Sub lnknext_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnknext.LinkClicked
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub txtstudmob_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtstudmob1.Validating, txtstudmob.Validating
        If Trim(sender.text) <> "" Then
            If Len(sender.text) <> 10 Then
                e.Cancel = True
                MessageBox.Show("The Mobile No Should Be 10 Digit Only.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        Me.follup_disp()
    End Sub

    Private Sub txtdays_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdays.KeyPress
        key(btnshow, e)
        NUM(e)
    End Sub

    Private Sub follup_disp()
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT stud_enq.*, trad.trad_nm FROM stud_enq LEFT OUTER JOIN trad ON stud_enq.trad_cd = trad.trad_cd WHERE admit='N' ORDER BY stud_enq.prfr_dt")
        dvfup.Rows.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                dvfup.Rows.Add()
                dvfup.Rows(rw).Cells(0).Value = i + 1
                dvfup.Rows(rw).Cells(1).Value = dsedit.Tables(0).Rows(i).Item("stud_nm")
                dvfup.Rows(rw).Cells(2).Value = dsedit.Tables(0).Rows(i).Item("add1")
                dvfup.Rows(rw).Cells(3).Value = dsedit.Tables(0).Rows(i).Item("cont1")
                dvfup.Rows(rw).Cells(4).Value = dsedit.Tables(0).Rows(i).Item("email")
                dvfup.Rows(rw).Cells(5).Value = dsedit.Tables(0).Rows(i).Item("trad_nm")
                dvfup.Rows(rw).Cells(6).Value = Format(dsedit.Tables(0).Rows(i).Item("prfr_dt"), "dd/MM/yyyy")
                dvfup.Rows(rw).Cells(7).Value = dsedit.Tables(0).Rows(i).Item("nb1")
                dvfup.Rows(rw).Cells(8).Value = dsedit.Tables(0).Rows(i).Item("enq_no")
                If dsedit.Tables(0).Rows(rw).Item("gndr") = "1" Then
                    dvfup.Rows(rw).DefaultCellStyle.BackColor = Color.AliceBlue
                    dvfup.Rows(rw).DefaultCellStyle.ForeColor = Color.Blue
                Else
                    dvfup.Rows(rw).DefaultCellStyle.BackColor = Color.White
                    dvfup.Rows(rw).DefaultCellStyle.ForeColor = Color.Black
                End If
                rw = rw + 1
            Next
        End If
        Close1()
    End Sub

    Private Sub btnflup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnflup.Click
        If dvfup.SelectedRows.Count = 0 Then
            MessageBox.Show("Please Select At Least One Student For Follow Up.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 1
            dvfup.Focus()
            Exit Sub
        End If
        If prefdt.Value <= sys_date Then
            MessageBox.Show("Please Forward The Pref Date From Current Date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 1
            prefdt.Focus()
            Exit Sub
        End If
        If Trim(txtremark.Text) = "" Then
            MessageBox.Show("The Remark Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 1
            txtremark.Focus()
            Exit Sub
        End If

        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT * FROM stud_enq WHERE enq_no=" & Val(txtscrl.Text) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            nb1 = dsedit.Tables(0).Rows(0).Item("nb1")
            nb2 = dsedit.Tables(0).Rows(0).Item("nb2")
            nb3 = dsedit.Tables(0).Rows(0).Item("nb3")
            nb4 = dsedit.Tables(0).Rows(0).Item("nb4")
            nb5 = ""
            fdt1 = dsedit.Tables(0).Rows(0).Item("flup_dt1")
            fdt2 = dsedit.Tables(0).Rows(0).Item("flup_dt2")
            fdt3 = dsedit.Tables(0).Rows(0).Item("flup_dt3")
            fdt4 = dsedit.Tables(0).Rows(0).Item("flup_dt4")
            pdt1 = dsedit.Tables(0).Rows(0).Item("prfr_dt")
            pdt2 = dsedit.Tables(0).Rows(0).Item("prfr_dt2")
            pdt3 = dsedit.Tables(0).Rows(0).Item("prfr_dt3")
            pdt4 = dsedit.Tables(0).Rows(0).Item("prfr_dt4")
            If nb4 <> "" Then
                nb5 = nb4
                pdt5 = pdt4
                fdt5 = fdt4
            End If
            If nb3 <> "" Then
                nb4 = nb3
                pdt4 = pdt3
                fdt4 = fdt3
            End If
            If nb2 <> "" Then
                nb3 = nb2
                pdt3 = pdt2
                fdt3 = fdt2
            End If
            If nb1 <> "" Then
                nb2 = nb1
                pdt2 = pdt1
                fdt2 = fdt1
            End If
            SQLInsert("UPDATE stud_enq SET nb1='" & Trim(txtremark.Text) & "',nb2='" & nb2 & "',nb3='" & nb3 & "',nb4='" & nb4 & "',nb5='" & _
                      nb5 & "',prfr_dt='" & Format(prefdt.Value, "dd/MMM/yyyy") & "',prfr_dt2='" & pdt1 & "',prfr_dt3='" & pdt2 & "',prfr_dt4='" & _
                      pdt3 & "',prfr_dt5='" & pdt4 & "',flup_dt1='" & sys_date & "',flup_dt2='" & fdt1 & "',flup_dt3='" & fdt2 & "',flup_dt4='" & _
                      fdt3 & "',flup_dt5='" & fdt4 & "' WHERE enq_no=" & Val(txtscrl.Text) & "")
            MessageBox.Show("Student Follow-up Completed Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.clr()
        End If
        Close1()
    End Sub

    Private Sub cmbmedia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmedia.SelectedIndexChanged
        If cmbmedia.SelectedIndex = 3 Then
            txtother.Visible = True
        Else
            txtother.Visible = False
            txtother.Text = ""
        End If
    End Sub

    Private Sub cmenuflup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuflup.Click
        If dvfup.RowCount <> 0 Then
            txtscrl.Text = dvfup.SelectedRows(0).Cells(8).Value
            Me.remark_show(txtscrl.Text)
        End If
        txtremark.Focus()
    End Sub

    Private Sub dvfup_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvfup.CellClick
        If dvfup.RowCount <> 0 Then
            txtscrl.Text = dvfup.SelectedRows(0).Cells(8).Value
            Me.remark_show(txtscrl.Text)
        End If
    End Sub

    Private Sub remark_show(ByVal enqno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT * FROM stud_enq WHERE enq_no=" & Val(enqno) & "")
        dvrmrk.Rows.Clear()
        stud_nm = ""
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            stud_nm = dsedit.Tables(0).Rows(0).Item("stud_nm")
            If dsedit.Tables(0).Rows(0).Item("nb1") <> "" Then
                dvrmrk.Rows.Add()
                dvrmrk.Rows(rw).Cells(0).Value = rw + 1
                dvrmrk.Rows(rw).Cells(1).Value = Format(dsedit.Tables(0).Rows(0).Item("flup_dt1"), "dd/MM/yyyy")
                dvrmrk.Rows(rw).Cells(2).Value = stud_nm
                dvrmrk.Rows(rw).Cells(3).Value = Format(dsedit.Tables(0).Rows(0).Item("prfr_dt"), "dd/MM/yyyy")
                dvrmrk.Rows(rw).Cells(4).Value = dsedit.Tables(0).Rows(0).Item("nb1")
                rw = rw + 1
            End If
            If dsedit.Tables(0).Rows(0).Item("nb2") <> "" Then
                dvrmrk.Rows.Add()
                dvrmrk.Rows(rw).Cells(0).Value = rw + 1
                dvrmrk.Rows(rw).Cells(1).Value = Format(dsedit.Tables(0).Rows(0).Item("flup_dt2"), "dd/MM/yyyy")
                dvrmrk.Rows(rw).Cells(2).Value = stud_nm
                dvrmrk.Rows(rw).Cells(3).Value = Format(dsedit.Tables(0).Rows(0).Item("prfr_dt2"), "dd/MM/yyyy")
                dvrmrk.Rows(rw).Cells(4).Value = dsedit.Tables(0).Rows(0).Item("nb2")
                rw = rw + 1
            End If
            If dsedit.Tables(0).Rows(0).Item("nb3") <> "" Then
                dvrmrk.Rows.Add()
                dvrmrk.Rows(rw).Cells(0).Value = rw + 1
                dvrmrk.Rows(rw).Cells(1).Value = Format(dsedit.Tables(0).Rows(0).Item("flup_dt3"), "dd/MM/yyyy")
                dvrmrk.Rows(rw).Cells(2).Value = stud_nm
                dvrmrk.Rows(rw).Cells(3).Value = Format(dsedit.Tables(0).Rows(0).Item("prfr_dt3"), "dd/MM/yyyy")
                dvrmrk.Rows(rw).Cells(4).Value = dsedit.Tables(0).Rows(0).Item("nb3")
                rw = rw + 1
            End If
            If dsedit.Tables(0).Rows(0).Item("nb4") <> "" Then
                dvrmrk.Rows.Add()
                dvrmrk.Rows(rw).Cells(0).Value = rw + 1
                dvrmrk.Rows(rw).Cells(1).Value = Format(dsedit.Tables(0).Rows(0).Item("flup_dt4"), "dd/MM/yyyy")
                dvrmrk.Rows(rw).Cells(2).Value = stud_nm
                dvrmrk.Rows(rw).Cells(3).Value = Format(dsedit.Tables(0).Rows(0).Item("prfr_dt4"), "dd/MM/yyyy")
                dvrmrk.Rows(rw).Cells(4).Value = dsedit.Tables(0).Rows(0).Item("nb4")
                rw = rw + 1
            End If
            If dsedit.Tables(0).Rows(0).Item("nb5") <> "" Then
                dvrmrk.Rows.Add()
                dvrmrk.Rows(rw).Cells(0).Value = rw + 1
                dvrmrk.Rows(rw).Cells(1).Value = Format(dsedit.Tables(0).Rows(0).Item("flup_dt5"), "dd/MM/yyyy")
                dvrmrk.Rows(rw).Cells(2).Value = stud_nm
                dvrmrk.Rows(rw).Cells(3).Value = Format(dsedit.Tables(0).Rows(0).Item("prfr_dt5"), "dd/MM/yyyy")
                dvrmrk.Rows(rw).Cells(4).Value = dsedit.Tables(0).Rows(0).Item("nb5")
            End If
        End If
        Close1()
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click, btndelete.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            'If usr_tp = "A" Or usr_tp = "D" Then
            slno = dv.SelectedRows(0).Cells(9).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT enq_no FROM stud_enq WHERE enq_no=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    Dim ds1 As DataSet = get_dataset("SELECT enq_no FROM stud WHERE enq_no=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM stud_enq WHERE enq_no =" & Val(slno) & "")
                        SQLInsert("DELETE FROM stud_enq_quali WHERE enq_no =" & Val(slno) & "")
                        MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.dv_disp()
                    Else
                        MessageBox.Show("Sorry You Can't Delete The Enquiry It Has Been Already Used on Student Registration.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub cmnu1del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1del.Click
        'If dvrmrk.RowCount <> 0 Then
        '    nb = dvrmrk.SelectedRows(0).Cells(4).Value
        '    SQLInsert("UPDATE stud_enq SET admit='Y' WHERE stud_sl=" & Val(txtscrl.Text) & " AND enq_no=" & Val(txtenqno.Text) & "")
        'End If
        'For Each row As DataGridViewRow In dvrmrk.SelectedRows
        '    dvrmrk.Rows.Remove(row)
        'Next
        'sl = 1
        'For i As Integer = 0 To dvrmrk.Rows.Count - 1
        '    dvrmrk.Rows(i).Cells(0).Value = i + 1
        '    sl += 1
        'Next
        'txtsl.Text = sl
    End Sub

    Private Sub mnuexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexport.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        studnm = InputBox("Enter The Student Name.", "Search Box...", Nothing)
        If (studnm Is Nothing OrElse studnm = "") Then
            'User hit cancel
        Else
            Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud_nm) AS 'Sl.',CONVERT(VARCHAR,stud_enq.ernq_dt,103) AS 'Date',stud_enq.stud_nm AS 'Student Name',stud_enq.add1 AS 'Address',stud_enq.cont1 AS 'Mob',stud_enq.gndr AS 'M/F',trad.trad_nm AS 'Branch',stud_enq.admit AS 'Admit',stud_enq.nb1 AS 'Remark',stud_enq.enq_no FROM stud_enq LEFT OUTER JOIN trad ON stud_enq.trad_cd = trad.trad_cd WHERE (stud_enq.stud_nm LIKE'" & studnm & "%')ORDER BY stud_enq.ernq_dt")
            dv.Columns.Clear()
            If dsedit.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dsedit.Tables(0)
                dv.Columns(9).Visible = False
                'dv.Columns(11).Visible = False
            End If
            For i As Integer = 0 To dv.Rows.Count - 1
                admit = dv.Rows(i).Cells(7).Value
                If admit = "Y" Then
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                Else
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
        End If
    End Sub
End Class
