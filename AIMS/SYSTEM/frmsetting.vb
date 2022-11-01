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
        cmbcopybill.SelectedIndex = 0
        cmbcopyschal.SelectedIndex = 0
        cmbcopysret.SelectedIndex = 0
        cmbcopypvouc.SelectedIndex = 0
        cmbcopyrvouc.SelectedIndex = 0
        cmbcopypo.SelectedIndex = 0
        cmbstartup.SelectedIndex = 0
        cmbcopypret.SelectedIndex = 0
        cmbcopymr.SelectedIndex = 0
        txtkpbckup.Text = ""
        txtbkuppath.Text = ""
        cmbexpalrt.SelectedIndex = 0
        txtexpalrt.Text = ""
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
        chkbillsms.Checked = False
        chkduesms.Checked = False
        chkpaysms.Checked = False
        chkrecsms.Checked = False
    End Sub

    Private Sub dataload()
        Dim ds As DataSet = get_dataset("SELECT * FROM gen_setting")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtprintbill.Text = ds.Tables(0).Rows(0).Item("print_bill")
            txtprintschal.Text = ds.Tables(0).Rows(0).Item("print_schal")
            txtprintsret.Text = ds.Tables(0).Rows(0).Item("print_sret")
            txtprintpo.Text = ds.Tables(0).Rows(0).Item("print_po")
            txtprintpret.Text = ds.Tables(0).Rows(0).Item("print_pret")
            txtprintpvouc.Text = ds.Tables(0).Rows(0).Item("print_pvouc")
            txtprintrvouc.Text = ds.Tables(0).Rows(0).Item("print_rvouc")
            txtprintmr.Text = ds.Tables(0).Rows(0).Item("print_mr")
            txtprintcntbl.Text = ds.Tables(0).Rows(0).Item("print_cntbl")
            txtprintsrvbl.Text = ds.Tables(0).Rows(0).Item("print_srvbl")
            cmbcopybill.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("copy_bill")) - 1
            cmbcopyschal.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("copy_schal")) - 1
            cmbcopysret.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("copy_sret")) - 1
            cmbcopypo.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("copy_po")) - 1
            cmbcopypret.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("copy_pret")) - 1
            cmbcopypvouc.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("copy_pvouc")) - 1
            cmbcopyrvouc.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("copy_rvouc")) - 1
            cmbcopymr.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("copy_mr")) - 1
            cmbcopycntrbl.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("copy_cntbl")) - 1
            cmbcopysrvbl.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("copy_srvbl")) - 1
            If ds.Tables(0).Rows(0).Item("exp_alrt") = "N" Then
                cmbexpalrt.SelectedIndex = 0
            Else
                cmbexpalrt.SelectedIndex = 1
            End If
            If ds.Tables(0).Rows(0).Item("start_backup") = "N" Then
                cmbstartup.SelectedIndex = 0
            Else
                cmbstartup.SelectedIndex = 1
            End If
            txtexpalrt.Text = ds.Tables(0).Rows(0).Item("exp_days")
            txtkpbckup.Text = ds.Tables(0).Rows(0).Item("backup_days")
            txtbkuppath.Text = ds.Tables(0).Rows(0).Item("backup_path")
            txtpff.Text = Format(ds.Tables(0).Rows(0).Item("pf_per"), "#######0.00")
            txtesicc.Text = Format(ds.Tables(0).Rows(0).Item("esic_per"), "#######0.00")
            txtdeductn.Text = Format(ds.Tables(0).Rows(0).Item("oth_deduct"), "#######0.00")
            chkremind.Checked = IIf(ds.Tables(0).Rows(0).Item("backup_rem"), 1, 0)
            chkstudbday.Checked = IIf(ds.Tables(0).Rows(0).Item("bday_rem"), 1, 0)
            chkaniversery.Checked = IIf(ds.Tables(0).Rows(0).Item("anvr_rem"), 1, 0)
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
            chkbillsms.Checked = IIf(ds.Tables(0).Rows(0).Item("bill_sms"), 1, 0)
            chkduesms.Checked = IIf(ds.Tables(0).Rows(0).Item("due_sms"), 1, 0)
            chkpaysms.Checked = IIf(ds.Tables(0).Rows(0).Item("pay_sms"), 1, 0)
            chkrecsms.Checked = IIf(ds.Tables(0).Rows(0).Item("rec_sms"), 1, 0)
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
        SQLInsert("UPDATE gen_setting SET print_bill=" & txtprintbill.Text & ",print_schal=" & txtprintschal.Text & ",print_sret=" & _
                  txtprintsret.Text & ",print_PO=" & txtprintpo.Text & ",print_pret=" & txtprintpret.Text & ",print_mr=" & _
                  txtprintmr.Text & ",print_pvouc=" & txtprintpvouc.Text & ",print_rvouc=" & txtprintrvouc.Text & ",print_cntbl=" & _
                  txtprintcntbl.Text & ",copy_bill=" & vb.Right(cmbcopybill.Text, 1) & ",copy_schal=" & vb.Right(cmbcopyschal.Text, 1) & ",copy_sret=" & _
                  vb.Right(cmbcopysret.Text, 1) & ",copy_po=" & vb.Right(cmbcopypo.Text, 1) & ",copy_pret=" & vb.Right(cmbcopypret.Text, 1) & ",copy_mr=" & _
                  vb.Right(cmbcopymr.Text, 1) & ",copy_pvouc=" & vb.Right(cmbcopypvouc.Text, 1) & ",copy_rvouc=" & _
                  vb.Right(cmbcopyrvouc.Text, 1) & ",copy_cntbl=" & vb.Right(cmbcopycntrbl.Text, 1) & ",exp_alrt='" & vb.Left(cmbexpalrt.Text, 1) & "',start_backup='" & vb.Left(cmbstartup.Text, 1) & _
                  "',exp_days=" & Val(txtexpalrt.Text) & ",backup_days=" & Val(txtkpbckup.Text) & _
                  ",backup_path='" & Trim(txtbkuppath.Text) & "', pf_per=" & Val(txtpff.Text) & _
                  ",esic_per=" & Val(txtesicc.Text) & ",oth_deduct=" & Val(txtdeductn.Text) & _
                  ",backup_rem=" & IIf(chkremind.Checked, 1, 0) & " ,bday_rem=" & IIf(chkstudbday.Checked, 1, 0) & _
                  ",anvr_rem=" & IIf(chkaniversery.Checked, 1, 0) & ", due_rem=" & IIf(chkduepment.Checked, 1, 0) & ",srvr_gsm=" & Val(srvr_gsm) & _
                  ",sms_srvr='" & Trim(txtsmsserver.Text) & "',sms_id='" & Trim(txtuserid.Text) & _
                  "',sms_pwd='" & Encrypt(txtpassword.Text.Trim()) & "',sender_id='" & Trim(txtsender.Text) & _
                  "',port_no='" & Trim(txtportno.Text) & "',smtp_srvr='" & Trim(txtsmpt.Text) & _
                  "',mail_id='" & Trim(txtuserid1.Text) & "',mail_pwd='" & Encrypt(txtpassword1.Text.Trim()) & _
                  "',bill_sms=" & IIf(chkbillsms.Checked, 1, 0) & ",due_sms=" & IIf(chkduesms.Checked, 1, 0) & _
                  ",pay_sms=" & IIf(chkpaysms.Checked, 1, 0) & ",rec_sms=" & IIf(chkrecsms.Checked, 1, 0) & ",print_srvbl = " & txtprintsrvbl.Text & ",copy_srvbl = " & vb.Right(cmbcopysrvbl.Text, 1) & " WHERE slno=1")
        MessageBox.Show("Setting Changes Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close1()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprintsret.Enter, txtprintschal.Enter, txtprintrvouc.Enter, txtprintpvouc.Enter, txtprintpret.Enter, txtprintpo.Enter, txtprintmr.Enter, txtprintcntbl.Enter, txtprintbill.Enter, txtpff.Enter, txtkpbckup.Enter, txtexpalrt.Enter, txtesicc.Enter, txtdeductn.Enter, cmbstartup.Enter, cmbexpalrt.Enter, cmbcopysret.Enter, cmbcopyschal.Enter, cmbcopyrvouc.Enter, cmbcopypvouc.Enter, cmbcopypret.Enter, cmbcopypo.Enter, cmbcopymr.Enter, cmbcopycntrbl.Enter, cmbcopybill.Enter, txtuserid1.Enter, txtuserid.Enter, txtsmsserver.Enter, txtsmpt.Enter, txtsender.Enter, txtportno.Enter, txtpassword1.Enter, txtpassword.Enter, txtprintsrvbl.Enter, cmbcopysrvbl.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprintsret.Leave, txtprintschal.Leave, txtprintrvouc.Leave, txtprintpvouc.Leave, txtprintpret.Leave, txtprintpo.Leave, txtprintmr.Leave, txtprintcntbl.Leave, txtprintbill.Leave, txtpff.Leave, txtkpbckup.Leave, txtexpalrt.Leave, txtesicc.Leave, txtdeductn.Leave, cmbstartup.Leave, cmbexpalrt.Leave, cmbcopysret.Leave, cmbcopyschal.Leave, cmbcopyrvouc.Leave, cmbcopypvouc.Leave, cmbcopypret.Leave, cmbcopypo.Leave, cmbcopymr.Leave, cmbcopycntrbl.Leave, cmbcopybill.Leave, txtuserid1.Leave, txtuserid.Leave, txtsmsserver.Leave, txtsmpt.Leave, txtsender.Leave, txtportno.Leave, txtpassword1.Leave, txtpassword.Leave, txtprintsrvbl.Leave, cmbcopysrvbl.Leave
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

    Private Sub sender_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrefresh.MouseEnter, btnbrowse.MouseEnter, btnaply.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrefresh.MouseLeave, btnbrowse.MouseLeave, btnaply.MouseLeave, btnexit.MouseLeave
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
    Private Sub cmbpaysch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcopybill.KeyPress
        key(cmbcopyschal, e)
        SPKey(e)
    End Sub

    Private Sub cmbcollrec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcopyschal.KeyPress
        key(cmbcopysret, e)
        SPKey(e)
    End Sub

    Private Sub cmbothcollrec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcopysret.KeyPress
        key(cmbcopypvouc, e)
        SPKey(e)
    End Sub

    Private Sub cmbpayvcr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcopypvouc.KeyPress
        key(cmbcopyrvouc, e)
        SPKey(e)
    End Sub

    Private Sub cmbrecvcr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcopyrvouc.KeyPress
        key(cmbcopypo, e)
        SPKey(e)
    End Sub

    Private Sub cmbcopypo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcopypo.KeyPress
        key(cmbcopypret, e)
        SPKey(e)
    End Sub

    Private Sub cmbcopypret_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcopypret.KeyPress
        key(cmbcopymr, e)
        SPKey(e)
    End Sub

    Private Sub cmbothcollrec1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcopymr.KeyPress
        key(cmbexpalrt, e)
        SPKey(e)
    End Sub

    Private Sub cmbduealrt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbexpalrt.KeyPress
        key(txtexpalrt, e)
        SPKey(e)
    End Sub

    Private Sub txtduealrt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtexpalrt.KeyPress
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
        key(txtpff, e)
        SPKey(e)
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
        key(txtsmsserver, e)
        TabControl1.SelectedIndex = 1
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

    Private Sub txtprintbill_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprintbill.TextChanged
        Call print_Details(txtprintbill, lblbill, 1)
    End Sub

    Private Sub txtprintschal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprintschal.TextChanged
        Call print_Details(txtprintschal, lblschal, 2)
    End Sub

    Private Sub txtprintsret_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprintsret.TextChanged
        Call print_Details(txtprintsret, lblsret, 3)
    End Sub

    Private Sub txtprintpo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprintpo.TextChanged
        Call print_Details(txtprintpo, lblpo, 4)
    End Sub

    Private Sub txtprintpret_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprintpret.TextChanged
        Call print_Details(txtprintpret, lblpret, 5)
    End Sub

    Private Sub txtprintmr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprintmr.TextChanged
        Call print_Details(txtprintmr, lblmr, 6)
    End Sub

    Private Sub txtprintpvouc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprintpvouc.TextChanged
        Call print_Details(txtprintpvouc, lblpvouc, 7)
    End Sub

    Private Sub txtprintrvouc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprintrvouc.TextChanged
        Call print_Details(txtprintrvouc, lblrvouc, 8)
    End Sub

    Private Sub txtprintcntbl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprintcntbl.TextChanged
        Call print_Details(txtprintcntbl, lblcntrbl, 9)
    End Sub

    Private Sub txtprintsrvbl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprintsrvbl.TextChanged
        Call print_Details(txtprintsrvbl, lblsrvbl, 10)
    End Sub
End Class