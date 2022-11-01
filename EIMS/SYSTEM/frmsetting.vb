Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO

Public Class frmsetting
    Dim comd As String = "E"
    Dim con_img As New SqlConnection(connectionstrng)
    Dim cmd_img As SqlCommand
    Dim fdt1, fdt2, fdt3, fdt4, pdt1, pdt2, pdt3, pdt4 As Date


#Region "START UP"
    Private Sub frmsetting_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("The Changes Will effect After Closing The Screen.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmsetting_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmsetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dataload()
    End Sub

    Private Sub frmsetting_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        cmbpaysch.SelectedIndex = 0
        cmbcollrec.SelectedIndex = 0
        cmbothcollrec.SelectedIndex = 0
        cmbpayvcr.SelectedIndex = 0
        cmbrecvcr.SelectedIndex = 0
        cmbporder.SelectedIndex = 0
        cmbstudicard.SelectedIndex = 0
        cmbstafficard.SelectedIndex = 0
        cmbstartup.SelectedIndex = 0
        cmbcollrec1.SelectedIndex = 0
        cmbothcollrec1.SelectedIndex = 0
        txtkpbckup.Text = ""
        txtbkuppath.Text = ""
        cmbduealrt.SelectedIndex = 0
        txtduealrt.Text = ""
        txtstudbkissue.Text = ""
        txtstafbkissue.Text = ""
        txtforday.Text = ""
        txtforday1.Text = ""
        txtpff.Text = "0.00"
        txtesicc.Text = "0.00"
        txtdeductn.Text = "0.00"
        chkremind.Checked = False
        chkstudbday.Checked = False
        chkaniversery.Checked = False
        chkduepment.Checked = False
        chkduepment.Checked = False
        txtbkuppath.Text = My.Application.Info.DirectoryPath & "\Backup"
        Me.clr1()
    End Sub

    Private Sub clr1()
        txtsmsserver.Text = ""
        txtuserid.Text = ""
        txtpassword.Text = ""
        txtsender.Text = ""
        txtportno.Text = ""
        txtsmpt.Text = ""
        txtuserid1.Text = ""
        txtpassword1.Text = ""
        chkstudsms.Checked = False
        chkfathersms.Checked = False
        chkmothersms.Checked = False
        chkgurdiansms.Checked = False
        chkregdsms.Checked = False
        chkduesms.Checked = False
        chkcollsms.Checked = False
        chkresultsms.Checked = False
    End Sub

    Private Sub dataload()
        Dim ds As DataSet = get_dataset("SELECT * FROM gen_setting")
        If ds.Tables(0).Rows.Count <> 0 Then
            cmbpaysch.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("print_schd")) - 1
            cmbcollrec.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("print_coll")) - 1
            cmbothcollrec.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("print_ocoll")) - 1
            cmbpayvcr.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("print_payv")) - 1
            cmbrecvcr.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("print_recv")) - 1
            cmbporder.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("print_po")) - 1
            cmbstudicard.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("stud_icard")) - 1
            cmbstafficard.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("staff_icard")) - 1
            cmbcollrec1.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("trst_coll")) - 1
            cmbothcollrec1.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("trst_ocoll")) - 1
            If ds.Tables(0).Rows(0).Item("due_alrt") = "N" Then
                cmbduealrt.SelectedIndex = 0
            Else
                cmbduealrt.SelectedIndex = 1
            End If
            If ds.Tables(0).Rows(0).Item("strt_backup") = "N" Then
                cmbstartup.SelectedIndex = 0
            Else
                cmbstartup.SelectedIndex = 1
            End If

            txtduealrt.Text = ds.Tables(0).Rows(0).Item("due_days")
            txtkpbckup.Text = ds.Tables(0).Rows(0).Item("backup_days")
            txtbkuppath.Text = ds.Tables(0).Rows(0).Item("backup_pth")
            txtstudbkissue.Text = ds.Tables(0).Rows(0).Item("stud_bk")
            txtstafbkissue.Text = ds.Tables(0).Rows(0).Item("staf_bk")
            txtforday.Text = ds.Tables(0).Rows(0).Item("stud_bkday")
            txtforday1.Text = ds.Tables(0).Rows(0).Item("staf_bkday")
            txtpff.Text = Format(ds.Tables(0).Rows(0).Item("pf_per"), "#######0.00")
            txtesicc.Text = Format(ds.Tables(0).Rows(0).Item("esic_per"), "#######0.00")
            txtdeductn.Text = Format(ds.Tables(0).Rows(0).Item("oth_deduct"), "#######0.00")
            txtpaysch.Text = ds.Tables(0).Rows(0).Item("copy_schd")
            txtcollrec.Text = ds.Tables(0).Rows(0).Item("copy_coll")
            txtothcollrec.Text = ds.Tables(0).Rows(0).Item("copy_ocoll")
            txtpayvcr.Text = ds.Tables(0).Rows(0).Item("copy_payv")
            txtrecvcr.Text = ds.Tables(0).Rows(0).Item("copy_recv")
            txtporder.Text = ds.Tables(0).Rows(0).Item("copy_po")
            txtcollrec1.Text = ds.Tables(0).Rows(0).Item("copy_tcoll")
            txtothcollrec1.Text = ds.Tables(0).Rows(0).Item("copy_tocoll")

            chkremind.Checked = IIf(ds.Tables(0).Rows(0).Item("backup_rem"), 1, 0)
            chkstudbday.Checked = IIf(ds.Tables(0).Rows(0).Item("bday_rem"), 1, 0)
            chkaniversery.Checked = IIf(ds.Tables(0).Rows(0).Item("anvr_rem"), 1, 0)
            chkfolloup.Checked = IIf(ds.Tables(0).Rows(0).Item("enq_rem"), 1, 0)
            chkduepment.Checked = IIf(ds.Tables(0).Rows(0).Item("due_rem"), 1, 0)

            If ds.Tables(0).Rows(0).Item("srvr_gsm") = 0 Then
                radioservestrng.Checked = True
            Else
                radiogsm.Checked = True
            End If
            txtsmsserver.Text = ds.Tables(0).Rows(0).Item("sms_srvr")
            txtuserid.Text = ds.Tables(0).Rows(0).Item("sms_id")
            txtpassword.Text = Decrypt(Trim(ds.Tables(0).Rows(0).Item("sms_pwd")))
            txtsender.Text = ds.Tables(0).Rows(0).Item("sender_id")
            chkstudsms.Checked = IIf(ds.Tables(0).Rows(0).Item("stud_sms"), 1, 0)
            chkfathersms.Checked = IIf(ds.Tables(0).Rows(0).Item("fath_sms"), 1, 0)
            chkmothersms.Checked = IIf(ds.Tables(0).Rows(0).Item("moth_sms"), 1, 0)
            chkgurdiansms.Checked = IIf(ds.Tables(0).Rows(0).Item("grdn_sms"), 1, 0)
            chkregdsms.Checked = IIf(ds.Tables(0).Rows(0).Item("regd_sms"), 1, 0)
            chkduesms.Checked = IIf(ds.Tables(0).Rows(0).Item("due_sms"), 1, 0)
            chkcollsms.Checked = IIf(ds.Tables(0).Rows(0).Item("coll_sms"), 1, 0)
            chkresultsms.Checked = IIf(ds.Tables(0).Rows(0).Item("reslt_sms"), 1, 0)

            txtportno.Text = ds.Tables(0).Rows(0).Item("port_no")
            txtsmpt.Text = ds.Tables(0).Rows(0).Item("smtp_srvr")
            txtuserid1.Text = ds.Tables(0).Rows(0).Item("mail_id")
            txtpassword1.Text = Decrypt(Trim(ds.Tables(0).Rows(0).Item("mail_pwd")))
        End If
    End Sub

    Private Sub datasave()
        Start1()
        If radioservestrng.Checked = True Then
            srvr_gsm = 0
        Else
            srvr_gsm = 1
        End If
        SQLInsert("UPDATE gen_setting SET print_schd =" & vb.Right(cmbpaysch.Text, 1) & ",print_coll=" & vb.Right(cmbcollrec.Text, 1) & _
                  ",print_ocoll=" & vb.Right(cmbothcollrec.Text, 1) & ",print_payv=" & vb.Right(cmbpayvcr.Text, 1) & _
                  ",print_recv=" & vb.Right(cmbrecvcr.Text, 1) & ",print_po=" & vb.Right(cmbporder.Text, 1) & _
                  ", stud_icard=" & vb.Right(cmbstudicard.Text, 1) & ",staff_icard=" & vb.Right(cmbstafficard.Text, 1) & _
                  ",trst_coll=" & vb.Right(cmbcollrec1.Text, 1) & ",trst_ocoll=" & vb.Right(cmbothcollrec1.Text, 1) & _
                  ",due_alrt='" & vb.Left(cmbduealrt.Text, 1) & "',strt_backup='" & vb.Left(cmbstartup.Text, 1) & _
                  "',due_days=" & Val(txtduealrt.Text) & ",backup_days=" & Val(txtkpbckup.Text) & _
                  ",backup_pth='" & Trim(txtbkuppath.Text) & "',stud_bk=" & Val(txtstudbkissue.Text) & _
                  ",staf_bk=" & Val(txtstafbkissue.Text) & ",stud_bkday=" & Val(txtforday.Text) & _
                  ",staf_bkday=" & Val(txtforday1.Text) & ", pf_per=" & Val(txtpff.Text) & _
                  ",esic_per=" & Val(txtesicc.Text) & ",oth_deduct=" & Val(txtdeductn.Text) & _
                  ",backup_rem=" & IIf(chkremind.Checked, 1, 0) & " ,bday_rem=" & IIf(chkstudbday.Checked, 1, 0) & _
                  ",anvr_rem=" & IIf(chkaniversery.Checked, 1, 0) & ", enq_rem=" & IIf(chkfolloup.Checked, 1, 0) & _
                  ",due_rem=" & IIf(chkduepment.Checked, 1, 0) & ",srvr_gsm=" & Val(srvr_gsm) & _
                  ",sms_srvr='" & Trim(txtsmsserver.Text) & "',sms_id='" & Trim(txtuserid.Text) & _
                  "',sms_pwd='" & Encrypt(txtpassword.Text.Trim()) & "',sender_id='" & Trim(txtsender.Text) & _
                  "',port_no='" & Trim(txtportno.Text) & "',smtp_srvr='" & Trim(txtsmpt.Text) & _
                  "',mail_id='" & Trim(txtuserid1.Text) & "',mail_pwd='" & Encrypt(txtpassword1.Text.Trim()) & _
                  "',stud_sms=" & IIf(chkstudsms.Checked, 1, 0) & ",fath_sms=" & IIf(chkfathersms.Checked, 1, 0) & _
                  ",moth_sms=" & IIf(chkmothersms.Checked, 1, 0) & ",grdn_sms=" & IIf(chkgurdiansms.Checked, 1, 0) & _
                  ",regd_sms=" & IIf(chkregdsms.Checked, 1, 0) & ",due_sms=" & IIf(chkduesms.Checked, 1, 0) & _
                  ",coll_sms=" & IIf(chkcollsms.Checked, 1, 0) & ",reslt_sms=" & IIf(chkresultsms.Checked, 1, 0) & _
                  ",copy_schd=" & Val(txtpaysch.Text) & ",copy_coll=" & Val(txtcollrec.Text) & ",copy_ocoll=" & Val(txtothcollrec.Text) & _
                  ",copy_payv=" & Val(txtpayvcr.Text) & ",copy_recv=" & Val(txtrecvcr.Text) & ",copy_po=" & Val(txtporder.Text) & _
                  ",copy_tcoll=" & Val(txtcollrec1.Text) & ",copy_tocoll=" & Val(txtothcollrec1.Text) & " WHERE slno=1")
        MessageBox.Show("Setting Changes Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close1()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbpaysch.Enter, cmbcollrec.Enter, cmbothcollrec.Enter, cmbpayvcr.Enter, cmbrecvcr.Enter, cmbporder.Enter, cmbstudicard.Enter, cmbstafficard.Enter, cmbcollrec1.Enter, cmbothcollrec1.Enter, cmbduealrt.Enter, txtduealrt.Enter, cmbstartup.Enter, txtkpbckup.Enter, txtbkuppath.Enter, txtstudbkissue.Enter, txtforday.Enter, txtstafbkissue.Enter, txtforday1.Enter, txtpff.Enter, txtesicc.Enter, txtdeductn.Enter, txtsmsserver.Enter, txtuserid.Enter, txtpassword.Enter, txtsender.Enter, txtportno.Enter, txtsmpt.Enter, txtuserid1.Enter, txtpassword1.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbpaysch.Leave, cmbcollrec.Leave, cmbothcollrec.Leave, cmbpayvcr.Leave, cmbrecvcr.Leave, cmbporder.Leave, cmbstudicard.Leave, cmbstafficard.Leave, cmbcollrec1.Leave, cmbothcollrec1.Leave, cmbduealrt.Leave, txtduealrt.Leave, cmbstartup.Leave, txtkpbckup.Leave, txtbkuppath.Leave, txtstudbkissue.Leave, txtforday.Leave, txtstafbkissue.Leave, txtforday1.Leave, txtpff.Leave, txtesicc.Leave, txtdeductn.Leave, txtsmsserver.Leave, txtuserid.Leave, txtpassword.Leave, txtsender.Leave, txtportno.Leave, txtsmpt.Leave, txtuserid1.Leave, txtpassword1.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub
#End Region

#Region "BOTTON"
    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrefresh.MouseEnter, btnpreview.MouseEnter, btnpreview1.MouseEnter, btnbrowse.MouseEnter, btnaply.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrefresh.MouseLeave, btnpreview.MouseLeave, btnpreview1.MouseLeave, btnbrowse.MouseLeave, btnaply.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub


    Private Sub btnbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowse.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtbkuppath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    'Private Sub chkusessl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkusessl.Checked = True Then
    '        txtportno.Text = "465"
    '    Else
    '        txtportno.Text = "587"
    '    End If
    'End Sub

    Private Sub btnaply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaply.Click
        Me.datasave()
        Me.Close()
        Call global_settings()
    End Sub
#End Region

    Private Sub txtpff_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpff.GotFocus
        If Val(txtpff.Text) = 0 Then
            txtpff.Text = ""
        End If
    End Sub

    Private Sub txtpff_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpff.LostFocus
        txtpff.Text = Format(Val(txtpff.Text), "########0.00")
    End Sub

    Private Sub txtesicc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtesicc.GotFocus
        If Val(txtesicc.Text) = 0 Then
            txtesicc.Text = ""
        End If
    End Sub

    Private Sub txtesicc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtesicc.LostFocus
        txtesicc.Text = Format(Val(txtesicc.Text), "########0.00")
    End Sub

#Region "Key Press"
    Private Sub cmbpaysch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpaysch.KeyPress
        key(cmbcollrec, e)
        SPKey(e)
    End Sub

    Private Sub cmbcollrec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcollrec.KeyPress
        key(cmbothcollrec, e)
        SPKey(e)
    End Sub

    Private Sub cmbothcollrec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbothcollrec.KeyPress
        key(cmbpayvcr, e)
        SPKey(e)
    End Sub

    Private Sub cmbpayvcr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpayvcr.KeyPress
        key(cmbrecvcr, e)
        SPKey(e)
    End Sub

    Private Sub cmbrecvcr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbrecvcr.KeyPress
        key(cmbporder, e)
        SPKey(e)
    End Sub

    Private Sub cmbpurchase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbporder.KeyPress
        key(cmbstudicard, e)
        SPKey(e)
    End Sub

    Private Sub cmbstudicard_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstudicard.KeyPress
        key(cmbstafficard, e)
        SPKey(e)
    End Sub

    Private Sub cmbstafficard_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstafficard.KeyPress
        key(cmbcollrec1, e)
        SPKey(e)
    End Sub

    Private Sub cmbcollrec1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcollrec1.KeyPress
        key(cmbothcollrec1, e)
        SPKey(e)
    End Sub

    Private Sub cmbothcollrec1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbothcollrec1.KeyPress
        key(cmbduealrt, e)
        SPKey(e)
    End Sub

    Private Sub cmbduealrt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbduealrt.KeyPress
        key(txtduealrt, e)
        SPKey(e)
    End Sub

    Private Sub txtduealrt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtduealrt.KeyPress
        key(cmbstartup, e)
        NUM(e)
    End Sub

    Private Sub cmbstartup_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstartup.KeyPress
        key(txtkpbckup, e)
        SPKey(e)
    End Sub

    Private Sub txtkpbckup_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtkpbckup.KeyPress
        key(txtbkuppath, e)
        NUM(e)
    End Sub

    Private Sub txtbkuppath_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbkuppath.KeyPress
        key(txtstudbkissue, e)
        SPKey(e)
    End Sub

    Private Sub txtstudbkissue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstudbkissue.KeyPress
        key(txtforday, e)
        NUM(e)
    End Sub

    Private Sub txtforday_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtforday.KeyPress
        key(txtstafbkissue, e)
        NUM(e)
    End Sub

    Private Sub txtstafbkissue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstafbkissue.KeyPress
        key(txtforday1, e)
        NUM(e)
    End Sub

    Private Sub txtforday1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtforday1.KeyPress
        key(txtpff, e)
        NUM(e)
    End Sub

    Private Sub txtpff_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpff.KeyPress
        key(txtesicc, e)
        NUM1(e)
    End Sub

    Private Sub txtesicc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtesicc.KeyPress
        key(txtdeductn, e)
        NUM1(e)
    End Sub

    Private Sub txtdeductn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdeductn.KeyPress
        TabControl1.SelectedIndex = 1
        key(txtsmsserver, e)
        NUM1(e)
    End Sub

    Private Sub txtsms_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsmsserver.KeyPress
        key(txtuserid, e)
        SPKey(e)
    End Sub

    Private Sub txtuserid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuserid.KeyPress
        key(txtpassword, e)
        SPKey(e)
    End Sub

    Private Sub txtpassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpassword.KeyPress
        key(txtsender, e)
        SPKey(e)
    End Sub

    Private Sub txtsender_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsender.KeyPress
        key(txtportno, e)
        SPKey(e)
    End Sub

    Private Sub txtportno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtportno.KeyPress
        key(txtsmpt, e)
        NUM(e)
    End Sub

    Private Sub txtsmpt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsmpt.KeyPress
        key(txtuserid1, e)
        SPKey(e)
    End Sub

    Private Sub txtuserid1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuserid1.KeyPress
        key(txtpassword1, e)
        SPKey(e)
    End Sub

    Private Sub txtpassword1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpassword1.KeyPress
        key(btnaply, e)
        SPKey(e)
    End Sub
#End Region

    Private Sub txtuserid1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuserid1.Validating
        If Trim(txtuserid1.Text) <> "" Then
            If txtuserid1.Text.IndexOf("@") = -1 OrElse txtuserid1.Text.IndexOf(".") = -1 Then
                e.Cancel = True
                MessageBox.Show("You Have Enter An Invalid Mail ID.Please Enter A Valid Email ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtuserid1.Focus()
            Else
                e.Cancel = False
            End If
        End If
    End Sub
End Class