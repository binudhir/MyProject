Imports System.Windows.Forms.Timer

Public Class MDI
    Dim seconds As Integer = 0, minutes As Integer = 0, hours As Integer = 0, lapCount As Integer = 0

    Private Sub MDI_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If mnuwin.DropDownItems.Count = 0 Then
            cnfr = MessageBox.Show("Are You Sure To Exit/Close The Job.", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If cnfr = vbYes Then
                e.Cancel = True
                If logn = "Y" Then
                    cnfr = MessageBox.Show("Are You Want To Take A Backup Of Your Databse", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If cnfr = vbYes Then
                        Call data_backup()
                    End If
                End If
                System.Diagnostics.Process.Start("http://www.shradhatechnologies.com")
                End
            Else
                e.Cancel = True
            End If
        Else
            MessageBox.Show("Please Close The All Active Forms Before Closing The Software.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        End If
    End Sub

    Private Sub MDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'mnuinventory.Visible = False
        'mnureports.Visible = False
        Panel6.Left = Me.Width - 160
        Call main()
        Call menu_disable()
        footer.Text = "Designed And Developed By : Shradha Technologies,Odisha,Ph-9437279078,7205055589, Visit Us At : www.shradhatechnologies.com, E-mail : support@shradhatechnologies.com "
        Dim reader As New System.IO.StreamReader(lnk_path)
        check_db = reader.ReadLine()
        lblduration.Text = "00:00:00"
        If check_db <> "" Then
            frmdbpath.MdiParent = Me
            frmdbpath.Show()
        Else
            frmdbset.MdiParent = Me
            frmdbset.Show()
        End If
    End Sub

    Public Function MarqueeLeft(ByVal Text As String)
        Dim Str1 As String = Text.Remove(0, 1)
        Dim Str2 As String = Text(0)
        Return Str1 & Str2
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        time1.Text = TimeOfDay.ToString("hh:mm:ss")
        lblclock.Text = TimeOfDay.ToString("hh:mm:ss ttt")
        'footer.Text = MarqueeLeft(footer.Text)
        Me.duration()
        lblwarning.Visible = Not lblwarning.Visible

        'lblconm.Visible = Not lblconm.Visible

        'Static bDummy As Boolean
        'bDummy = Not bDummy
        'If bDummy Then
        '    lblconm.ForeColor = Color.Maroon
        '    footer.BackColor = Color.LightGreen
        'Else
        '    lblconm.ForeColor = Color.ForestGreen
        '    footer.BackColor = Color.SkyBlue

        'End If
        'If logn = "Y" Then
        '    Call menu_enable()
        'Else
        '    mnu_login.Enabled = True
        '    Call menu_disable()
        'End If
    End Sub
    'Duration Coda
    Private Sub duration()
        seconds += 1
        If (seconds = 60) Then
            seconds = 0
            minutes += 1
            If (minutes = 60) Then
                minutes = 0
                hours += 1
            End If
        End If
        h = Format(hours, "00")
        m = Format(minutes, "00")
        s = Format(seconds, "00")
        lblduration.Text = h & ":" & m & ":" & s
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_login.Click
        Dim reader As New System.IO.StreamReader(lnk_path)
        check_db = reader.ReadLine()
        If check_db <> "" Then
            frmdbpath.MdiParent = Me
            frmdbpath.Show()
        Else
            frmdbset.MdiParent = Me
            frmdbset.Show()
        End If

    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        If btnlogin.Text = "Login" Then
            Dim reader As New System.IO.StreamReader(lnk_path)
            check_db = reader.ReadLine()
            If check_db <> "" Then
                'btnlogin.Text = "Logout"
                frmdbpath.MdiParent = Me
                frmdbpath.Show()
            Else
                frmdbset.MdiParent = Me
                frmdbset.Show()
            End If
        Else
            If mnuwin.DropDownItems.Count = 0 Then
                btnlogin.Text = "Login"
                logn = "N"
                Call menu_disable()
                seconds = 0
                minutes = 0
                hours = 0
                lapCount = 0
            Else
                MessageBox.Show("Please Close The All Active Forms.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub lblconm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblconm.Click
        If mnuwin.DropDownItems.Count = 0 Then
            frmcompany.MdiParent = Me
            frmcompany.Show()
        Else
            MessageBox.Show("Please Close The All Active Forms.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Panel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.Click
        System.Diagnostics.Process.Start("http://www.shradhatechnologies.com")
    End Sub

    Private Sub LogoutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_logout.Click
        If mnuwin.DropDownItems.Count = 0 Then
            btnlogin.Text = "Login"
            logn = "N"
            Call menu_disable()
            seconds = 0
            minutes = 0
            hours = 0
            lapCount = 0
        Else
            MessageBox.Show("Please Close The All Active Forms.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexit.Click
        Me.Close()
    End Sub

    Private Sub mnuwebsite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuwebsite.Click
        System.Diagnostics.Process.Start("http://www.shradhatechnologies.com")
    End Sub

    Private Sub mnumailus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnumailus.Click
        frmmailus.MdiParent = Me
        frmmailus.Show()
    End Sub

    Private Sub mnunewuser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnunewuser.Click
        frmuser.MdiParent = Me
        frmuser.Show()
    End Sub

    Private Sub mnuchngpswd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuchngpswd.Click
        frmusermod.MdiParent = Me
        frmusermod.Show()
    End Sub

    Private Sub mnucompinfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnucompinfo.Click
        If mnuwin.DropDownItems.Count = 0 Then
            frmcompany.MdiParent = Me
            frmcompany.Show()
        Else
            MessageBox.Show("Please Close The All Active Forms.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub mnudbsetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudbsetting.Click
        If mnuwin.DropDownItems.Count = 0 Then
            frmdbset.MdiParent = Me
            frmdbset.Show()
        Else
            MessageBox.Show("Please Close The All Active Forms.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnucalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnucalc.Click
        'System.Diagnostics.Process.Start("calc")
        System.Diagnostics.Process.Start("calc.exe")
    End Sub

    Private Sub mnunotepad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnunotepad.Click
        System.Diagnostics.Process.Start("notepad.exe")
    End Sub

    Private Sub mnudbbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudbbackup.Click
        If mnuwin.DropDownItems.Count = 0 Then
            Call data_backup()
        Else
            MessageBox.Show("Please Close The All Active Forms.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnudbrestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudbrestore.Click
        If mnuwin.DropDownItems.Count = 0 Then
            Call data_restore()
        Else
            MessageBox.Show("Please Close The All Active Forms.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnuParty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuParty.Click
        'frmparty.MdiParent = Me
        'frmparty.Show()
        frmparty.MdiParent = Me
        frmparty.Show()
    End Sub

    Private Sub mnuUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUnit.Click
        frmunit.MdiParent = Me
        frmunit.Show()
    End Sub

    Private Sub mnuTax_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTax.Click
        frmtaxmst.MdiParent = Me
        frmtaxmst.Show()
    End Sub

    Private Sub mnuStorage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStorage.Click
        frmgodn.MdiParent = Me
        frmgodn.Show()
    End Sub

    Private Sub mnuProductgrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProductgrp.Click
        frmitgrp.MdiParent = Me
        frmitgrp.Show()
    End Sub

    Private Sub mnuProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProduct.Click
        frmitem.MdiParent = Me
        frmitem.Show()
    End Sub

    Private Sub mnuDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepartment.Click
        frmdept.MdiParent = Me
        frmdept.Show()
    End Sub

    Private Sub mnuDesignation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDesignation.Click
        frmdesg.MdiParent = Me
        frmdesg.Show()
    End Sub

    Private Sub mnuEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEmployee.Click
        frmstaf.MdiParent = Me
        frmstaf.Show()
    End Sub

    Private Sub mnuCountry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCountry.Click
        frmcntr.MdiParent = Me
        frmcntr.Show()
    End Sub

    Private Sub mnuState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuState.Click
        frmstat.MdiParent = Me
        frmstat.Show()
    End Sub

    Private Sub mnuDistrict_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDistrict.Click
        frmdist.MdiParent = Me
        frmdist.Show()
    End Sub

    Private Sub mnuQualification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQualification.Click
        frmquali.MdiParent = Me
        frmquali.Show()
    End Sub

    Private Sub mnuPayVouc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPayVouc.Click
        frmpayvouc.MdiParent = Me
        frmpayvouc.Show()
    End Sub

    Private Sub mnuRec_Vouc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRec_Vouc.Click
        frmrecvouc.MdiParent = Me
        frmrecvouc.Show()
    End Sub

    Private Sub mnupreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupreview.Click
        Call disp_repo()
    End Sub

    Private Sub TestReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestReportToolStripMenuItem.Click
        frmmastergrid.MdiParent = Me
        frmmastergrid.Show()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        footer.Text = MarqueeLeft(footer.Text)
    End Sub

    Private Sub mnumrledg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnumrledg.Click
        rep_recledg.cmbreport.SelectedIndex = 0
        rep_recledg.MdiParent = Me
        rep_recledg.Show()
    End Sub

    Private Sub mnurecledg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnurecledg.Click
        rep_recledg.cmbreport.SelectedIndex = 1
        rep_recledg.MdiParent = Me
        rep_recledg.Show()
    End Sub

    Private Sub mnupayledg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupayledg.Click
        rep_recledg.cmbreport.SelectedIndex = 2
        rep_recledg.MdiParent = Me
        rep_recledg.Show()
    End Sub

    Private Sub mnujrnledg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnujrnledg.Click
        rep_recledg.cmbreport.SelectedIndex = 3
        rep_recledg.MdiParent = Me
        rep_recledg.Show()
    End Sub

    Private Sub mnuJrn_Vouc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuJrn_Vouc.Click
        frmjrn.MdiParent = Me
        frmjrn.Show()
    End Sub

    Private Sub mnucompset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnucompset.Click
        If mnuwin.DropDownItems.Count = 0 Then
            frmsetting.MdiParent = Me
            frmsetting.Show()
        Else
            MessageBox.Show("Please Close The All Active Forms.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnuporder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuporder.Click
        frmporder.MdiParent = Me
        frmporder.Show()
    End Sub

    Private Sub mnupurinv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupurinv.Click
        frmpurchinv.MdiParent = Me
        frmpurchinv.Show()
    End Sub

    Private Sub mnupret_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupret.Click
        frmpurret.MdiParent = Me
        frmpurret.Show()
    End Sub

    Private Sub mnuissue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuissueveh.Click
        frmiss.MdiParent = Me
        frmiss.Show()
    End Sub

    Private Sub mnurefund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnurefveh.Click
        frmrefund.MdiParent = Me
        frmrefund.Show()
    End Sub

    Private Sub mnuintrgdn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuintrgdn.Click
        frmintrgodn.MdiParent = Me
        frmintrgodn.Show()
    End Sub

    Private Sub mnumr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnumr.Click
        frmmr.MdiParent = Me
        frmmr.Show()
    End Sub

    Private Sub mnumanf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnumanf.Click
        frmmanf.MdiParent = Me
        frmmanf.Show()
    End Sub

    Private Sub mnumrkt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnumrkt.Click
        frmmarket.MdiParent = Me
        frmmarket.Show()
    End Sub

    Private Sub mnudiscpartymanf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudiscpartymanf.Click

    End Sub

    Private Sub mnudiscpartyitem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudiscpartyitem.Click

    End Sub

    Private Sub mnuacsubgrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnudriver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudriver.Click
        frmdriver.MdiParent = Me
        frmdriver.Show()
    End Sub

    Private Sub mnuvhcl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuvhcl.Click
        frmvehicle.MdiParent = Me
        frmvehicle.Show()
    End Sub

    Private Sub mnuarea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuarea.Click
        frmrout.MdiParent = Me
        frmrout.Show()
    End Sub

    Private Sub mnucashcrpurch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnucashcrpurch.Click
        frmpurch.MdiParent = Me
        frmpurch.Show()
    End Sub

    Private Sub mnupchal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupchal.Click
        frmpurchal.MdiParent = Me
        frmpurchal.Show()
    End Sub

    Private Sub mnustkupdt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnustkupdt.Click
        If mnuwin.DropDownItems.Count = 0 Then
            frmupdate.txttype.Text = "S"
            frmupdate.MdiParent = Me
            frmupdate.Show()
        Else
            MessageBox.Show("Please Close The All Active Forms.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnuqrymngr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuqrymngr.Click

    End Sub

    Private Sub mnuemplyee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuemplyee.Click
        rep_stflist.MdiParent = Me
        rep_stflist.Show()
    End Sub

    Private Sub mnupurchreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupurchreg.Click
        rep_combinpurchreg.MdiParent = Me
        rep_combinpurchreg.Show()
    End Sub

    Private Sub mnupurchregVAT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupurchregVAT.Click
        rep_purchregvat.MdiParent = Me
        rep_purchregvat.Show()
    End Sub

    Private Sub mnupurchchalreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupurchchalreg.Click
        rep_purchchalreg.MdiParent = Me
        rep_purchchalreg.Show()
    End Sub

    Private Sub mnupurchretreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupurchretreg.Click
        rep_purchretreg.MdiParent = Me
        rep_purchretreg.Show()
    End Sub

    Private Sub mnusalesreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnusalesreg.Click
        rep_salesreg.MdiParent = Me
        rep_salesreg.Show()
    End Sub

    Private Sub mnuorderreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuorderreg.Click
        rep_purchordreg.MdiParent = Me
        rep_purchordreg.Show()
    End Sub

    Private Sub mnuprtledger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuprtledger.Click
        rep_partyledger.MdiParent = Me
        rep_partyledger.Show()
    End Sub

    Private Sub mnucashbook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnucashbook.Click
        rep_cashbook.MdiParent = Me
        rep_cashbook.Show()
    End Sub

    Private Sub mnustkreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnustkreg.Click
        rep_stockreg.MdiParent = Me
        rep_stockreg.Show()
    End Sub

    Private Sub mnustkstmnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnustkstmnt.Click
        rep_stkstatement.MdiParent = Me
        rep_stkstatement.Show()
    End Sub

    Private Sub mnusales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnusales.Click
        frmsales.MdiParent = Me
        frmsales.Show()
    End Sub

    Private Sub mnuschal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuschal.Click
        frmsalchal.MdiParent = Me
        frmsalchal.Show()
    End Sub

    Private Sub mnusret_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnusret.Click
        frmsalret.MdiParent = Me
        frmsalret.Show()
    End Sub

    Private Sub mnuservice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuservice.Click
        frmservice.MdiParent = Me
        frmservice.Show()
    End Sub

    Private Sub mnusalinv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnusalinv.Click

    End Sub

    Private Sub mnucntrsale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnucntrsale.Click

    End Sub

    Private Sub mnuprtbalupd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuprtbalupd.Click
        If mnuwin.DropDownItems.Count = 0 Then
            frmupdate.txttype.Text = "B"
            frmupdate.MdiParent = Me
            frmupdate.Show()
        Else
            MessageBox.Show("Please Close The All Active Forms.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnusalregvat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnusalregvat.Click
        rep_salesregvat.MdiParent = Me
        rep_salesregvat.Show()
    End Sub

    Private Sub mnusalretreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnusalretreg.Click
        rep_salesretreg.MdiParent = Me
        rep_salesretreg.Show()
    End Sub

    Private Sub mnusalchalreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnusalchalreg.Click
        rep_saleschalreg.MdiParent = Me
        rep_saleschalreg.Show()
    End Sub

    Private Sub mnufy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnufy.Click
        Call finance_year()
    End Sub

    Private Sub mnusrlstkreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnusrlstkreg.Click
        rep_stocksrlreg.MdiParent = Me
        rep_stocksrlreg.Show()
    End Sub
End Class