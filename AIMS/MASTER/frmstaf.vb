Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO
Public Class frmstaf
    Dim comd As String
    Dim con_img As New SqlConnection(connectionstrng)
    Dim cmd_img As SqlCommand

    Private Sub frmstaf_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuEmployee.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmstaf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmstaf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuEmployee.Enabled = False
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmstaf_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        txtempid.Visible = False
        txtpreid.Visible = True
        txtpoid.Visible = True
        txtphoto.Text = "N"
        txtstat2.Text = ""
        txtstat1.Text = ""
        txtsrtnm.Text = ""
        txtrelgon.Text = ""
        txtpin2.Text = ""
        txtpin1.Text = ""
        txtph2.Text = ""
        txtph1.Text = ""
        txtnmof.Text = ""
        txtnatlty.Text = ""
        txtmotnm.Text = ""
        txtgrdmob.Text = ""
        txtempnm.Text = ""
        txtpoid.Text = ""
        txtdevcd.Text = ""
        txtage.Text = ""
        txtadd2.Text = ""
        txtadd1.Text = ""
        cmbprinm.SelectedIndex = 0
        cmbnmof.SelectedIndex = 0
        cmbdist2.Text = ""
        cmbdist1.Text = ""
        txtyear.Text = "0"
        txtpfredg.Text = ""
        txtlastemp.Text = ""
        txtexp.Text = ""
        txtesino.Text = ""
        txtbasic.Text = ""
        cmbposttype.SelectedIndex = 0
        cmblogin.SelectedIndex = 0
        cmblock.SelectedIndex = 0
        cmbdesg.Text = ""
        cmbdept.Text = ""
        txtgrdmob.Text = ""
        txtmail.Text = ""
        txtage.Text = ""
        txtadd2.Text = ""
        txtadd1.Text = ""
        regdt.Value = sys_date
        dv.Columns.Clear()
        dvquali.Rows.Clear()
        txtscrl.Text = 0
        txtdesgcd.Text = 0
        txtdeptcd.Text = 0
        txtdistcd1.Text = 0
        txtdistcd2.Text = 0
        txtsl.Text = 1
        dob.Value = sys_date.AddYears(-15)
        pict1.BackgroundImage = My.Resources.photo
        Me.Text = "Employee Registration Screen . . ."
        Dim ds As DataSet = get_dataset("SELECT max(staf_sl) as 'Max' FROM staf")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If

        Dim ds1 As DataSet = get_dataset("SELECT id_pfx FROM staf ORDER BY staf_sl DESC")
        txtpreid.Text = "AIMS"
        If ds1.Tables(0).Rows.Count <> 0 Then
            txtpreid.Text = ds1.Tables(0).Rows(0).Item(0)
        End If

        Dim ds2 As DataSet = get_dataset("SELECT max(stafid_no) as 'IDMax' FROM staf WHERE id_pfx='" & Trim(txtpreid.Text) & "'")
        txtpoid.Text = 1
        If ds2.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds2.Tables(0).Rows(0).Item(0)) Then
                txtpoid.Text = ds2.Tables(0).Rows(0).Item(0) + 1
            End If
            txtempid.Text = txtpreid.Text & Format(Val(txtpoid.Text), "00000")
        End If

        txtempnm.Focus()
        Me.clr1()
    End Sub

    Private Sub clr1()
        txtschnm.Text = ""
        txtyear.Text = ""
        txtper.Text = "0.00"
        cmbexam.Text = ""
        txtexmcd.Text = 0
    End Sub

#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtstat2.Enter, txtstat1.Enter, txtsrtnm.Enter, txtrelgon.Enter, txtpin2.Enter, txtpin1.Enter, txtph2.Enter, txtph1.Enter, txtnmof.Enter, txtnatlty.Enter, txtmotnm.Enter, txtgrdmob.Enter, txtempnm.Enter, txtpoid.Enter, txtdevcd.Enter, txtage.Enter, txtadd2.Enter, txtadd1.Enter, cmbprinm.Enter, cmbnmof.Enter, cmbdist2.Enter, cmbdist1.Enter, txtyear.Enter, txtschnm.Enter, txtpfredg.Enter, txtper.Enter, txtlastemp.Enter, txtexp.Enter, txtesino.Enter, txtbasic.Enter, cmbposttype.Enter, cmblock.Enter, cmbexam.Enter, cmbdesg.Enter, cmbdept.Enter, cmblogin.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtstat2.Leave, txtstat1.Leave, txtsrtnm.Leave, txtrelgon.Leave, txtpin2.Leave, txtpin1.Leave, txtph2.Leave, txtph1.Leave, txtnmof.Leave, txtnatlty.Leave, txtmotnm.Leave, txtgrdmob.Leave, txtempnm.Leave, txtpoid.Leave, txtdevcd.Leave, txtage.Leave, txtadd2.Leave, txtadd1.Leave, cmbprinm.Leave, cmbnmof.Leave, cmbdist2.Leave, cmbdist1.Leave, txtyear.Leave, txtschnm.Leave, txtpfredg.Leave, txtper.Leave, txtlastemp.Leave, txtexp.Leave, txtesino.Leave, txtbasic.Leave, cmbposttype.Leave, cmblock.Leave, cmbexam.Leave, cmbdesg.Leave, cmbdept.Leave, cmblogin.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
        sender.text = UCase(sender.text)
    End Sub

    Private Sub txtmail_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmail.Enter
        txtmail.ForeColor = Color.Blue
        txtmail.BackColor = Color.LavenderBlush
    End Sub

    Private Sub txtmail_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmail.Leave
        txtmail.ForeColor = Color.Black
        txtmail.BackColor = Color.White
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

    
    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, cmdview.Click
        Me.clr()
        Me.dv_disp()
    End Sub


#Region "Key Press"

    Private Sub txtempid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtempid.KeyPress
        key(txtdevcd, e)
        SPKey(e)
    End Sub

    Private Sub txtpreid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpreid.KeyPress
        key(txtdevcd, e)
        SPKey(e)
    End Sub

    Private Sub txtpoid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpoid.KeyPress
        key(txtdevcd, e)
        SPKey(e)
    End Sub

    Private Sub txtdevcd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdevcd.KeyPress
        key(cmbprinm, e)
        NUM(e)
    End Sub

    Private Sub cmbprinm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbprinm.KeyPress
        key(txtempnm, e)
    End Sub

    Private Sub txtempnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtempnm.KeyPress
        key(txtsrtnm, e)
        SPKey(e)
    End Sub

    Private Sub txtsrtnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsrtnm.KeyPress
        key(regdt, e)
        SPKey(e)
    End Sub

    Private Sub regdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles regdt.KeyPress
        key(dob, e)
    End Sub

    Private Sub dob_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dob.KeyPress
        If dom.Visible = True Then
            key(dom, e)
        Else
            key(txtnatlty, e)
        End If
        SPKey(e)
    End Sub

    Private Sub dom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dom.KeyPress
        key(txtnatlty, e)
    End Sub

    Private Sub txtnatlty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnatlty.KeyPress
        key(txtrelgon, e)
        SPKey(e)
    End Sub

    Private Sub txtrelgon_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrelgon.KeyPress
        key(cmbnmof, e)
        SPKey(e)
    End Sub

    Private Sub cmbnmof_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbnmof.KeyPress
        key(txtnmof, e)
    End Sub

    Private Sub txtnmof_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnmof.KeyPress
        key(txtmotnm, e)
        SPKey(e)
    End Sub

    Private Sub txtmotnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmotnm.KeyPress
        key(txtadd1, e)
        SPKey(e)
    End Sub

    Private Sub txtadd1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd1.KeyPress
        key(cmbdist1, e)
        SPKey(e)
    End Sub

    Private Sub cmbdist1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdist1.KeyPress
        key(txtpin1, e)
        SPKey(e)
    End Sub

    Private Sub txtpin1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpin1.KeyPress
        key(txtph1, e)
        NUM(e)
    End Sub

    Private Sub txtadd2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd2.KeyPress
        key(cmbdist2, e)
        SPKey(e)
    End Sub

    Private Sub cmbdist2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdist2.KeyPress
        key(txtpin2, e)
        SPKey(e)
    End Sub

    Private Sub txtpin2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpin2.KeyPress
        key(txtph1, e)
        NUM(e)
    End Sub

    Private Sub txtph1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtph1.KeyPress
        key(txtph2, e)
        NUM(e)
    End Sub

    Private Sub txtph2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtph2.KeyPress
        key(txtgrdmob, e)
        NUM(e)
    End Sub

    Private Sub txtgrdmob_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgrdmob.KeyPress
        key(txtmail, e)
        NUM(e)
    End Sub

    Private Sub txtmail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmail.KeyPress
        key(lnknext, e)
        SPKey(e)
    End Sub

    Private Sub lnknext_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnknext.LinkClicked
        TabControl1.SelectedIndex = 1
        txtschnm.Focus()
    End Sub

    Private Sub txtschnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtschnm.KeyPress
        If txtschnm.Text = "" Then
            key(txtlastemp, e)
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
        key(txtper, e)
        NUM(e)
    End Sub

    Private Sub txtper_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtper.KeyPress
        key(btnnxt, e)
        NUM1(e)
    End Sub

    Private Sub txtlastemp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlastemp.KeyPress
        key(txtexp, e)
        SPKey(e)
    End Sub

    Private Sub txtexp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtexp.KeyPress
        key(cmbdept, e)
        NUM(e)
    End Sub



    Private Sub cmbposttype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbposttype.KeyPress
        key(cmbdesg, e)
        SPKey(e)
    End Sub

    Private Sub cmbdept_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdept.KeyPress
        key(cmbposttype, e)
        SPKey(e)
    End Sub

    Private Sub txtbasic_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbasic.KeyPress
        key(cmblogin, e)
        NUM1(e)
    End Sub

    Private Sub cmbdesg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbdesg.KeyPress
        key(txtbasic, e)
        SPKey(e)
    End Sub

    Private Sub txtpfredg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpfredg.KeyPress
        key(cmblogin, e)
        SPKey(e)
    End Sub

    Private Sub cmblogin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblogin.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub txtesino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtesino.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub
#End Region

    Private Sub txtempnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtempnm.LostFocus
        If Trim(txtsrtnm.Text) = "" Then
            txtsrtnm.Text = vb.Left(Trim(txtempnm.Text), 5)
        End If
    End Sub

#Region "Combo Box"
    Private Sub cmbdist1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist1.GotFocus
        populate(cmbdist1, "SELECT dist_nm FROM dist WHERE rec_lock='N' ORDER BY dist_nm")
    End Sub

    Private Sub cmbdist1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist1.LostFocus
        cmbdist1.Height = 21
    End Sub

    Private Sub cmbdist1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist1.Validated
        Dim ds As DataSet = get_dataset("SELECT dist.dist_cd, stat.stat_cd,stat.stat_nm FROM cntr RIGHT OUTER JOIN stat ON cntr.cntr_sl = stat.cntr_sl RIGHT OUTER JOIN dist ON stat.stat_cd = dist.stat_cd WHERE (dist.dist_nm = '" & Trim(cmbdist1.Text) & "')")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtdistcd1.Text = ds.Tables(0).Rows(0).Item("dist_cd")
            txtstat1.Text = ds.Tables(0).Rows(0).Item("stat_nm")
            If Val(txtdistcd2.Text) = 0 Then
                txtdistcd2.Text = Val(txtdistcd1.Text)
            End If
            If Trim(cmbdist2.Text) = "" Then
                cmbdist2.Text = Trim(cmbdist1.Text)
            End If
            If Trim(txtstat2.Text) = "" Then
                txtstat2.Text = Trim(txtstat1.Text)
            End If
        End If
    End Sub

    Private Sub cmbdist1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdist1.Validating
        vdating(cmbdist1, "SELECT dist_nm FROM dist WHERE dist_nm='" & Trim(cmbdist1.Text) & "' AND rec_lock='N'", "Please Select A Valid District Name.")
    End Sub

    Private Sub cmbdist2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist2.GotFocus
        populate(cmbdist2, "SELECT dist_nm FROM dist WHERE rec_lock='N' ORDER BY dist_nm")
    End Sub

    Private Sub cmbdist2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist2.LostFocus
        cmbdist2.Height = 21
    End Sub

    Private Sub cmbdist2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdist2.Validated
        Dim ds As DataSet = get_dataset("SELECT dist.dist_cd, stat.stat_cd,stat.stat_nm FROM cntr RIGHT OUTER JOIN stat ON cntr.cntr_sl = stat.cntr_sl RIGHT OUTER JOIN dist ON stat.stat_cd = dist.stat_cd WHERE (dist.dist_nm = '" & Trim(cmbdist2.Text) & "')")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtdistcd2.Text = ds.Tables(0).Rows(0).Item("dist_cd")
            txtstat2.Text = ds.Tables(0).Rows(0).Item("stat_nm")
        End If
    End Sub

    Private Sub cmbdist2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdist2.Validating
        vdating(cmbdist2, "SELECT dist_nm FROM dist WHERE dist_nm='" & Trim(cmbdist2.Text) & "' AND rec_lock='N'", "Please Select A Valid District Name.")
    End Sub

    Private Sub cmbdesg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesg.GotFocus
        populate(cmbdesg, "SELECT desg_nm FROM desg WHERE rec_lock='N' ORDER BY desg_nm")
    End Sub

    Private Sub cmbdesg_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesg.LostFocus
        cmbdesg.Height = 21
    End Sub

    Private Sub cmbdesg_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesg.Validated
        vdated(txtdesgcd, "SELECT desg_cd FROM desg WHERE desg_nm='" & Trim(cmbdesg.Text) & "'")
    End Sub

    Private Sub cmbdesg_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdesg.Validating
        vdating(cmbdesg, "SELECT desg_nm FROM desg WHERE desg_nm='" & Trim(cmbdesg.Text) & "' AND rec_lock='N'", "Please Select A Valid Designation Name.")
    End Sub

    Private Sub cmbdept_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdept.GotFocus
        populate(cmbdept, "SELECT dept_nm FROM dept WHERE rec_lock='N' ORDER BY dept_nm")
    End Sub

    Private Sub cmbdept_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdept.LostFocus
        cmbdept.Height = 21
    End Sub

    Private Sub cmbdept_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdept.Validated
        vdated(txtdeptcd, "SELECT dept_cd FROM dept WHERE dept_nm='" & Trim(cmbdept.Text) & "'")
    End Sub

    Private Sub cmbdept_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdept.Validating
        vdating(cmbdept, "SELECT dept_nm FROM dept WHERE dept_nm='" & Trim(cmbdept.Text) & "' AND rec_lock='N'", "Please Select A Valid Department Name.")
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

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        comd = "E"
        Me.Text = "Employee Registration Entry Screen . . ."
        btnsave.Text = "Save"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtpreid.Text) = "" Then
            MessageBox.Show("The Employee Prefix Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            txtpreid.Focus()
            Exit Sub
        End If
        If Trim(txtempnm.Text) = "" Then
            MessageBox.Show("The Employee Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtempnm.Focus()
            Exit Sub
        End If
        If Trim(cmbdist1.Text) = "" Or Trim(cmbdist2.Text) = "" Or Val(txtdistcd1.Text) = 0 Or Val(txtdistcd2.Text) = 0 Then
            MessageBox.Show("The District Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            cmbdist1.Focus()
            Exit Sub
        End If
        If Trim(cmbdept.Text) = "" Or Val(txtdeptcd.Text) = 0 Then
            MessageBox.Show("The Department Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 1
            cmbdept.Focus()
            Exit Sub
        End If
        If Trim(cmbdesg.Text) = "" Or Val(txtdesgcd.Text) = 0 Then
            MessageBox.Show("The Designation Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 1
            cmbdesg.Focus()
            Exit Sub
        End If
        Me.staf_save()
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
                x = dvquali.Rows(i).Cells(5).Value
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
        dvquali.Rows(sl - 1).Cells(4).Value = txtper.Text
        dvquali.Rows(sl - 1).Cells(5).Value = txtexmcd.Text
        sl += 1
        txtsl.Text = sl
        txtschnm.Focus()
        Me.clr1()
    End Sub

#End Region

#Region "Data Save"
    Private Sub staf_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(staf_sl) as 'Max' FROM staf")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO staf(staf_sl,nm_pri,staf_nm,short_nm,device_code,emp_tp,desg_cd,dept_cd,doj,dol,per_add1," & _
                          "per_zip,cont_no,pre_add1,pre_zip,dob,gndr,married,nation,religion,caste,f_g_h,fgh_nm,staf_image," & _
                          "rec_lock,moth_nm,pf_req,pf_reg,esi_req,esi_reg,dist_cd1,dist_cd2,mail_id,login_req,pswd_crtd," & _
                          "cont_no1,grd_mob,last_emp,tot_exp,basic_pay,leaved,dom,room_req,conync_req,cantn_req,sms_req," & _
                          "mail_req,id_pfx,stafid_no,staf_id) VALUES (" & Val(txtscrl.Text) & ",'" & Trim(cmbprinm.Text) & "','" & _
                          Trim(txtempnm.Text) & "','" & Trim(txtsrtnm.Text) & "'," & Val(txtdevcd.Text) & ",'" & vb.Left(cmbposttype.Text, 1) & _
                          "'," & Val(txtdesgcd.Text) & "," & Val(txtdeptcd.Text) & ",'" & Format(regdt.Value, "dd/MMM/yyyy") & "','" & _
                          Format(regdt.Value, "dd/MMM/yyyy") & "','" & Trim(txtadd1.Text) & "','" & Trim(txtpin1.Text) & "','" & _
                          Trim(txtph1.Text) & "','" & Trim(txtadd2.Text) & "','" & Trim(txtpin2.Text) & "','" & Format(dob.Value, "dd/MMM/yyyy") & "','" & _
                          IIf(rdmale.Checked, "M", "F") & "','" & IIf(chkmard.Checked, "2", "1") & "','" & Trim(txtnatlty.Text) & "','" & _
                          Trim(txtrelgon.Text) & "','','" & vb.Left(cmbnmof.Text, 1) & "','" & Trim(txtnmof.Text) & "','','" & _
                          vb.Left(cmblock.Text, 1) & "','" & Trim(txtmotnm.Text) & "','" & IIf(chkpf.Checked, "Y", "N") & "','" & _
                          Trim(txtpfredg.Text) & "','" & IIf(chkesi.Checked, "Y", "N") & "','" & Trim(txtesino.Text) & "'," & _
                          Val(txtdistcd1.Text) & "," & Val(txtdistcd2.Text) & ",'" & Trim(txtmail.Text) & "','" & _
                          vb.Left(cmblogin.Text, 1) & "','N','" & Trim(txtph2.Text) & "','" & Trim(txtgrdmob.Text) & "','" & _
                          Trim(txtlastemp.Text) & "'," & Val(txtexp.Text) & "," & Val(txtbasic.Text) & ",'N','" & Format(dom.Value, "dd/MMM/yyyy") & "','" _
                          & IIf(chkroom.Checked, "Y", "N") & "','" & IIf(chktrans.Checked, "Y", "N") & "','" & _
                          IIf(chkcnteen.Checked, "Y", "N") & "','" & IIf(chksms.Checked, "Y", "N") & "','" & IIf(chkmail.Checked, "Y", "N") & _
                          "','" & Trim(txtpreid.Text) & "'," & Val(txtpoid.Text) & ",'" & Trim(txtempid.Text) & "')")
                Me.quali_save()
                If txtphoto.Text = "Y" Then
                    Me.save_image()
                End If

                If cmblogin.SelectedIndex = 1 Then
                    Me.save_login()
                End If

                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Me.Text = "Employee Registration Entry Screen . . ."
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
                Dim ds As DataSet = get_dataset("SELECT staf_sl FROM staf WHERE staf_sl=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE staf SET nm_pri='" & Trim(cmbprinm.Text) & "',staf_nm='" & Trim(txtempnm.Text) & "',short_nm='" & _
                              Trim(txtsrtnm.Text) & "',device_code=" & Val(txtdevcd.Text) & ",emp_tp='" & vb.Left(cmbposttype.Text, 1) & "',desg_cd=" & _
                              Val(txtdesgcd.Text) & ",dept_cd=" & Val(txtdeptcd.Text) & ",doj='" & Format(regdt.Value, "dd/MMM/yyyy") & "',dol='" & _
                              Format(regdt.Value, "dd/MMM/yyyy") & "',per_add1='" & Trim(txtadd1.Text) & "',per_zip='" & Trim(txtpin1.Text) & "',cont_no='" & _
                              Trim(txtph1.Text) & "',pre_add1='" & Trim(txtadd2.Text) & "',pre_zip='" & Trim(txtpin2.Text) & "',dob='" & _
                              Format(dob.Value, "dd/MMM/yyyy") & "',gndr='" & IIf(rdmale.Checked, "M", "F") & "',married='" & IIf(chkmard.Checked, "2", "1") & "',nation='" & _
                              Trim(txtnatlty.Text) & "',religion='" & Trim(txtrelgon.Text) & "',f_g_h='" & vb.Left(cmbnmof.Text, 1) & "',fgh_nm='" & _
                              Trim(txtnmof.Text) & "',staf_image='',staf_id='" & Trim(txtpoid.Text) & "',rec_lock='" & vb.Left(cmblock.Text, 1) & "',moth_nm='" & _
                              Trim(txtmotnm.Text) & "',pf_req='" & IIf(chkpf.Checked, "Y", "N") & "',pf_reg='" & Trim(txtpfredg.Text) & "',esi_req='" & _
                              IIf(chkesi.Checked, "Y", "N") & "',esi_reg='" & Trim(txtesino.Text) & "',dist_cd1=" & Val(txtdistcd1.Text) & ",dist_cd2=" & _
                              Val(txtdistcd2.Text) & ",mail_id='" & Trim(txtmail.Text) & "',cont_no1='" & Trim(txtph2.Text) & "',grd_mob='" & _
                              Trim(txtgrdmob.Text) & "',last_emp='" & Trim(txtlastemp.Text) & "',tot_exp=" & Val(txtexp.Text) & ",basic_pay=" & _
                              Val(txtbasic.Text) & ",dom='" & Format(dom.Value, "dd/MMM/yyyy") & "',room_req='" & IIf(chkroom.Checked, "Y", "N") & _
                              "',conync_req='" & IIf(chktrans.Checked, "Y", "N") & "',cantn_req='" & IIf(chkcnteen.Checked, "Y", "N") & _
                              "',sms_req='" & IIf(chksms.Checked, "Y", "N") & "',mail_req='" & IIf(chkmail.Checked, "Y", "N") & _
                              "' WHERE staf_sl =" & Val(txtscrl.Text) & "")
                    Me.quali_save()
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

    Private Sub save_login()
        Dim ds As DataSet = get_dataset("SELECT max(usr_sl) as 'Max' FROM usr")
        txtlogin.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtlogin.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        SQLInsert("INSERT INTO usr(usr_sl,usr_id,usr_pwd,usr_tp,usr_nm,usr_add1,usr_add2,usr_ph1,usr_ph2," & _
                  "usr_mail,login_block,frst_login,login_atmpt,staf_sl,rec_lock) VALUES(" & Val(txtlogin.Text) & _
                  ",'" & Trim(txtempid.Text) & "','PASSWORD','O','" & Trim(txtempnm.Text) & "','" & Trim(txtadd1.Text) & _
                  "','" & Trim(txtadd2.Text) & "','" & Trim(txtph1.Text) & "','" & Trim(txtph2.Text) & "','" & Trim(txtmail.Text) & _
                  "','N','N',0," & Val(txtscrl.Text) & ",'N')")
    End Sub

    Private Sub quali_save()
        If dvquali.RowCount <> 0 Then
            SQLInsert("DELETE FROM staf_quali WHERE staf_sl=" & Val(txtscrl.Text) & "")
            For i As Integer = 0 To dvquali.RowCount - 1
                ins_nm = dvquali.Rows(i).Cells(1).Value
                yr = dvquali.Rows(i).Cells(3).Value
                permrk = dvquali.Rows(i).Cells(4).Value
                exm_cd = dvquali.Rows(i).Cells(5).Value
                Dim ds1 As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM staf_quali")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO staf_quali(slno, staf_sl, sch_nm, edu_cd, yr, mark_per) VALUES (" & Val(mxno) & "," & _
                          Val(txtscrl.Text) & ",'" & ins_nm & "'," & Val(exm_cd) & ",'" & yr & "'," & Val(permrk) & ")")
            Next
        End If
    End Sub

    Private Sub save_image()
        Try
            Dim cmd_img As New SqlCommand("UPDATE staf SET staf_image=@staf_image WHERE staf_sl=" & Val(txtscrl.Text) & "", con_img)
            Dim ms As New MemoryStream()
            pict1.BackgroundImage.Save(ms, pict1.BackgroundImage.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@staf_image", SqlDbType.Image)
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
#End Region

#Region "Data Display"
    Private Sub dv_disp()
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY staf_nm) AS 'Sl.',staf.staf_nm AS 'Staff Name', staf.cont_no AS 'Contact No.', dept.dept_nm AS 'Department Name', desg.desg_nm AS 'Designation Name',staf.staf_sl, staf.rec_lock FROM staf LEFT OUTER JOIN desg ON staf.desg_cd = desg.desg_cd LEFT OUTER JOIN dept ON staf.dept_cd = dept.dept_cd ORDER BY staf.staf_nm")
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
        dv.Focus()
    End Sub

    Private Sub quali_view()
        Dim ds As DataSet = get_dataset("SELECT staf_quali.*, education.edu_nm FROM staf_quali LEFT OUTER JOIN education ON staf_quali.edu_cd = education.edu_cd WHERE staf_quali.staf_sl=" & Val(txtscrl.Text) & "")
        rw = 0
        dvquali.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dvquali.Rows.Add()
                dvquali.Rows(rw).Cells(0).Value = i + 1
                dvquali.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("sch_nm")
                dvquali.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("edu_nm")
                dvquali.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("yr")
                dvquali.Rows(rw).Cells(4).Value = Format(ds.Tables(0).Rows(i).Item("mark_per"), "######0.00")
                dvquali.Rows(rw).Cells(5).Value = ds.Tables(0).Rows(i).Item("edu_cd")
                rw += 1
            Next
            txtsl.Text = rw + 1
        End If
    End Sub

    Private Sub show_image()
        Dim cmd_img As New SqlCommand("SELECT staf_image FROM staf WHERE staf_sl=" & Val(txtscrl.Text) & " ", con_img)
        cmd_img.Parameters.AddWithValue("staf_image", 3)
        Try
            con_img.Open()
            pict1.SizeMode = PictureBoxSizeMode.StretchImage
            pict1.BackgroundImage = Image.FromStream(New IO.MemoryStream(CType(cmd_img.ExecuteScalar, Byte())))
            ' or you can save in a file 
            IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\staf.jpg", CType(cmd_img.ExecuteScalar, Byte()))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con_img.Close()
        End Try
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT dist.dist_nm, stat.stat_nm, staf.*,  desg.desg_nm, dept.dept_nm, stat.stat_nm,DataLength(staf.staf_image) AS staf_img FROM staf LEFT OUTER JOIN dept ON staf.dept_cd = dept.dept_cd LEFT OUTER JOIN desg ON staf.desg_cd = desg.desg_cd  LEFT OUTER JOIN dist ON staf.dist_cd1 = dist.dist_cd LEFT OUTER JOIN stat ON dist.stat_cd = stat.stat_cd WHERE staf.staf_sl=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtempid.Text = dsedit.Tables(0).Rows(0).Item("staf_id")
            cmbprinm.Text = dsedit.Tables(0).Rows(0).Item("nm_pri")
            txtempnm.Text = dsedit.Tables(0).Rows(0).Item("staf_nm")
            txtsrtnm.Text = dsedit.Tables(0).Rows(0).Item("short_nm")
            txtdevcd.Text = dsedit.Tables(0).Rows(0).Item("device_code")
            cmbposttype.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("emp_tp")) - 1
            txtdesgcd.Text = dsedit.Tables(0).Rows(0).Item("desg_cd")
            txtdeptcd.Text = dsedit.Tables(0).Rows(0).Item("dept_cd")
            cmbdesg.Text = dsedit.Tables(0).Rows(0).Item("desg_nm")
            cmbdept.Text = dsedit.Tables(0).Rows(0).Item("dept_nm")
            regdt.Value = dsedit.Tables(0).Rows(0).Item("doj")
            txtadd1.Text = dsedit.Tables(0).Rows(0).Item("per_add1")
            txtpin1.Text = dsedit.Tables(0).Rows(0).Item("per_zip")
            txtph1.Text = dsedit.Tables(0).Rows(0).Item("cont_no")
            txtadd2.Text = dsedit.Tables(0).Rows(0).Item("pre_add1")
            txtadd1.Text = dsedit.Tables(0).Rows(0).Item("per_add1")
            txtpin2.Text = dsedit.Tables(0).Rows(0).Item("pre_zip")
            dob.Value = dsedit.Tables(0).Rows(0).Item("dob")
            txtrelgon.Text = dsedit.Tables(0).Rows(0).Item("religion")
            txtnatlty.Text = dsedit.Tables(0).Rows(0).Item("nation")
            txtnmof.Text = dsedit.Tables(0).Rows(0).Item("fgh_nm")
            txtmotnm.Text = dsedit.Tables(0).Rows(0).Item("moth_nm")
            txtpfredg.Text = dsedit.Tables(0).Rows(0).Item("pf_reg")
            txtesino.Text = dsedit.Tables(0).Rows(0).Item("esi_reg")
            txtdistcd1.Text = dsedit.Tables(0).Rows(0).Item("dist_cd1")
            cmbdist1.Text = dsedit.Tables(0).Rows(0).Item("dist_nm")
            txtstat1.Text = dsedit.Tables(0).Rows(0).Item("stat_nm")
            txtdistcd2.Text = dsedit.Tables(0).Rows(0).Item("dist_cd2")
            txtmail.Text = dsedit.Tables(0).Rows(0).Item("mail_id")
            txtph2.Text = dsedit.Tables(0).Rows(0).Item("cont_no1")
            txtgrdmob.Text = dsedit.Tables(0).Rows(0).Item("grd_mob")
            txtlastemp.Text = dsedit.Tables(0).Rows(0).Item("last_emp")
            txtexp.Text = dsedit.Tables(0).Rows(0).Item("tot_exp")
            txtbasic.Text = Format(dsedit.Tables(0).Rows(0).Item("basic_pay"), "#######0.00")
            dom.Value = dsedit.Tables(0).Rows(0).Item("dom")
            If Val(txtdistcd2.Text) <> 0 Then
                If Val(txtdistcd2.Text) = Val(txtdistcd1.Text) Then
                    cmbdist2.Text = dsedit.Tables(0).Rows(0).Item("dist_nm")
                    txtstat2.Text = dsedit.Tables(0).Rows(0).Item("stat_nm")
                Else
                    Dim ds As DataSet = get_dataset("SELECT dist.dist_nm, stat.stat_nm FROM stat RIGHT OUTER JOIN dist ON stat.stat_cd = dist.stat_cd WHERE (dist.dist_cd = " & Val(txtdistcd2.Text) & ")")
                    If ds.Tables(0).Rows.Count <> 0 Then
                        cmbdist2.Text = ds.Tables(0).Rows(0).Item("dist_nm")
                        txtstat2.Text = ds.Tables(0).Rows(0).Item("stat_nm")
                    End If
                End If
            End If

            If dsedit.Tables(0).Rows(0).Item("f_g_h") = "F" Then
                cmbnmof.SelectedIndex = 0
            ElseIf dsedit.Tables(0).Rows(0).Item("f_g_h") = "H" Then
                cmbnmof.SelectedIndex = 1
            Else
                cmbnmof.SelectedIndex = 2
            End If
            If dsedit.Tables(0).Rows(0).Item("pf_req") = "Y" Then
                chkpf.Checked = True
            Else
                chkpf.Checked = False
            End If
            If dsedit.Tables(0).Rows(0).Item("esi_req") = "Y" Then
                chkesi.Checked = True
            Else
                chkesi.Checked = False
            End If
            If dsedit.Tables(0).Rows(0).Item("married") = "2" Then
                chkmard.Checked = True
            Else
                chkmard.Checked = False
            End If
            If dsedit.Tables(0).Rows(0).Item("gndr") = "M" Then
                rdmale.Checked = True
            Else
                rdfemale.Checked = True
            End If
            If dsedit.Tables(0).Rows(0).Item("login_req") = "Y" Then
                cmblogin.SelectedIndex = 1
            Else
                cmblogin.SelectedIndex = 0
            End If
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
                cmblock.SelectedIndex = 1
            Else
                cmblock.SelectedIndex = 0
            End If
            If dsedit.Tables(0).Rows(0).Item("room_req") = "Y" Then
                chkroom.Checked = True
            Else
                chkroom.Checked = False
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
            img_length = dsedit.Tables(0).Rows(0).Item("staf_img")
            If Val(img_length) <> 0 Then
                txtphoto.Text = "Y"
                Me.show_image()
            End If
            Me.quali_view()
        End If
        Close1()
    End Sub
#End Region

    Private Sub btnclr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclr.Click
        dvquali.Rows.Clear()
        Me.clr1()
        txtsl.Text = "1"
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        txtempid.Visible = False
        txtpreid.Visible = True
        txtpoid.Visible = True
        lblid.visible = True
        cmblogin.Visible = True
        btnsave.Text = "Save"
        Me.Text = "Employee Registration Entry Screen . . ."
        dv.Visible = False
        txtempnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            txtempid.Visible = True
            txtpreid.Visible = False
            txtpoid.Visible = False
            lblid.Visible = False
            cmblogin.Visible = False
            txtempid.Left = txtpreid.Left
            txtempid.Top = txtpreid.Top
            btnsave.Text = "Modify"
            Me.Text = "Employee Registration Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(5).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtempnm.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        'fnd = 0
        'If dv.RowCount <> 0 Then
        '    If usr_tp = "A" Or usr_tp = "D" Then
        '        slno = dv.SelectedRows(0).Cells(7).Value
        '        cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        '        Start1()
        '        If cnfr = vbYes Then
        '            Dim ds As DataSet = get_dataset("SELECT staf_sl FROM staf WHERE staf_sl=" & Val(slno) & "")
        '            If ds.Tables(0).Rows.Count <> 0 Then
        '                Dim ds1 As DataSet = get_dataset("SELECT staf_sl FROM iss1 WHERE staf_sl=" & Val(slno) & "")
        '                If ds1.Tables(0).Rows.Count <> 0 Then
        '                    fnd = 1
        '                End If

        '                Dim ds2 As DataSet = get_dataset("SELECT staf_sl FROM bk_iss1 WHERE staf_sl=" & Val(slno) & "")
        '                If ds2.Tables(0).Rows.Count <> 0 Then
        '                    fnd = 1
        '                End If

        '                Dim ds3 As DataSet = get_dataset("SELECT staf_sl FROM usr WHERE staf_sl=" & Val(slno) & "")
        '                If ds3.Tables(0).Rows.Count <> 0 Then
        '                    fnd = 1
        '                End If

        '                If fnd = 0 Then
        '                    SQLInsert("DELETE FROM staf WHERE staf_sl =" & Val(slno) & "")
        '                    SQLInsert("DELETE FROM staf_quali WHERE staf_sl =" & Val(slno) & "")
        '                    SQLInsert("DELETE FROM usr WHERE staf_sl =" & Val(slno) & "")
        '                    MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                    Me.dv_disp()
        '                Else
        '                    MessageBox.Show("Sorry You Can't Delete The Employee It Has Been Already Used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                    Exit Sub
        '                End If
        '            End If
        '            Close1()
        '        End If
        '    Else
        '        MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'End If
    End Sub

    Private Sub dob_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dob.Validated
        txtage.Text = DateDiff(DateInterval.Year, dob.Value, sys_date)
    End Sub


    Private Sub txttotmrk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtper.GotFocus, txtbasic.GotFocus
        If Val(sender.text) = 0 Then
            sender.text = ""
        End If
    End Sub

    Private Sub txttotmrk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtper.LostFocus, txtbasic.LostFocus
        sender.text = Format(Val(sender.text), "######0.00")
    End Sub

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

    Private Sub txtrelgon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrelgon.LostFocus
        If Trim(txtrelgon.Text) = "" Then
            txtrelgon.Text = "HINDU"
        End If
    End Sub

    Private Sub txtnatlty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnatlty.LostFocus
        If Trim(txtnatlty.Text) = "" Then
            txtnatlty.Text = "INDIAN"
        End If
    End Sub

    Private Sub lnkclr_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkclr.LinkClicked
        pict1.BackgroundImage = My.Resources.photo
        txtphoto.Text = "N"
    End Sub

    Private Sub dob_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dob.ValueChanged
        txtage.Text = DateDiff(DateInterval.Year, dob.Value, sys_date)
    End Sub

    Private Sub chkmard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkmard.CheckedChanged
        If chkmard.Checked = True Then
            dom.Visible = True
        Else
            dom.Visible = False
        End If
    End Sub

    Private Sub chkpf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpf.CheckedChanged
        If chkpf.Checked = True Then
            txtpfredg.Visible = True
        Else
            txtpfredg.Visible = False
        End If
    End Sub

    Private Sub chkesi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkesi.CheckedChanged
        If chkesi.Checked = True Then
            txtesino.Visible = True
        Else
            txtesino.Visible = False
        End If
    End Sub

    Private Sub txtstudmob_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtph1.Validating, txtph2.Validating, txtgrdmob.Validating
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

    Private Sub txtemail_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmail.Validating
        If Trim(txtmail.Text) <> "" Then
            If txtmail.Text.IndexOf("@") = -1 OrElse txtmail.Text.IndexOf(".") = -1 Then
                e.Cancel = True
                MessageBox.Show("You Have Enter An Invalid Mail ID.Please Enter A Valid Email ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtmail.Focus()
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

    Private Sub txtpin1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpin1.LostFocus
        If Trim(txtpin2.Text) = "" Then
            txtpin2.Text = Trim(txtpin1.Text)
        End If
    End Sub

    Private Sub pict1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pict1.DoubleClick
        If txtphoto.Text = "Y" Then
            Dim stfpath As String
            If Trim(txtpoid.Text) = "" Then
                stfpath = My.Application.Info.DirectoryPath & "\staf.Jpeg"
            Else
                stfpath = My.Application.Info.DirectoryPath & "\" & Trim(txtpoid.Text) & ".Jpeg"
            End If
            pict1.Size = New Size(413, 531)
            Dim bmp As New Drawing.Bitmap(pict1.Width, pict1.Height)
            pict1.DrawToBitmap(bmp, pict1.ClientRectangle)
            bmp.Save(stfpath, System.Drawing.Imaging.ImageFormat.Jpeg)
            pict1.Size = New Size(134, 146)
        End If
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

    Private Sub txtpreid_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpreid.Validated
        If Trim(txtpreid.Text) <> "" Then
            Dim ds2 As DataSet = get_dataset("SELECT max(stafid_no) as 'IDMax' FROM staf WHERE id_pfx='" & Trim(txtpreid.Text) & "'")
            txtpoid.Text = 1
            If ds2.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds2.Tables(0).Rows(0).Item(0)) Then
                    txtpoid.Text = ds2.Tables(0).Rows(0).Item(0) + 1
                End If
                txtempid.Text = txtpreid.Text & Format(Val(txtpoid.Text), "00000")
            End If
        End If
    End Sub

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub
End Class
