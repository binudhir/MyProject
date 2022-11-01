Imports System.Windows.Forms.Timer

Public Class MDI
    Dim seconds As Integer = 0, minutes As Integer = 0, hours As Integer = 0, lapCount As Integer = 0

    Private Sub MDI_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If mnuwin.DropDownItems.Count = 0 Then
            cnfr = MessageBox.Show("Are You Sure To Exit/Close The Job.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If cnfr = vbYes Then
                e.Cancel = True
                If logn = "Y" Then
                    cnfr = MessageBox.Show("Are You Want To Take A Backup Of Your Databse", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If cnfr = vbYes Then
                        Call data_backup()
                    End If
                End If
                'System.Diagnostics.Process.Start("http://www.shradhatechnologies.com")
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
        'mnulibrary.Visible = False
        mnuexamination.Visible = False
        'MenuStrip1.Items(2).Visible = False
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

    'Public Sub menu_visible()
    '    Dim ds As DataSet = get_dataset("SELECT menumst.menu_id FROM user_assign LEFT OUTER JOIN menumst ON user_assign.menu_sl = menumst.menu_sl WHERE (user_assign.user_sl = " & usr_sl & ") AND (user_assign.add_prm = 0) AND (user_assign.edit_prm = 0) AND (user_assign.delete_prm = 0) AND (user_assign.view_prm = 0)")
    '    If ds.Tables(0).Rows.Count <> 0 Then
    '        Dim mnunm As ToolStripMenuItem
    '        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '            mnunm = ds.Tables(0).Rows(i).Item(0)
    '            mnunm.Visible = False
    '        Next
    '    End If
    'End Sub

    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnstudreg.MouseEnter, btnstudenq.MouseEnter, btnPaySchedule.MouseEnter, btnFeeColl_SC.MouseEnter, btnFeeColl_NSC.MouseEnter, btnpaschdall.MouseEnter, btn_studreg.MouseEnter, btnpurinv.MouseEnter, btnporder.MouseEnter, btnPayVouc.MouseEnter, btnpayledg.MouseEnter, btnprtledger.MouseEnter, btncashbook.MouseEnter, btnNschdcolreg.MouseEnter, btnschdcolreg.MouseEnter, btndbrestore.MouseEnter, btndbbackup.MouseEnter, btnemplyee.MouseEnter, btnstudsearch.MouseEnter, btnstudledg.MouseEnter, btnpreview.MouseEnter, btncalc.MouseEnter, btnsms.MouseEnter, btnchngpswd.MouseEnter, btnupload.MouseEnter
        sender.ForeColor = Color.Maroon
        sender.BackgroundImage = My.Resources.btnbg1
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnporder.MouseLeave, btnpurinv.MouseLeave, btn_studreg.MouseLeave, btnpaschdall.MouseLeave, btnFeeColl_NSC.MouseLeave, btnFeeColl_SC.MouseLeave, btnPaySchedule.MouseLeave, btnupload.MouseLeave, btnchngpswd.MouseLeave, btnsms.MouseLeave, btncalc.MouseLeave, btnpreview.MouseLeave, btnstudledg.MouseLeave, btnstudenq.MouseLeave, btnstudsearch.MouseLeave, btnemplyee.MouseLeave, btndbbackup.MouseLeave, btndbrestore.MouseLeave, btnschdcolreg.MouseLeave, btnNschdcolreg.MouseLeave, btncashbook.MouseLeave, btnprtledger.MouseLeave, btnpayledg.MouseLeave, btnPayVouc.MouseLeave, btnstudreg.MouseLeave
        sender.ForeColor = Color.White
        sender.BackgroundImage = My.Resources.btnbg
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

    Private Sub mnu_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_login.Click
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

    End Sub

    Private Sub mnu_logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_logout.Click
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

    Private Sub mnuexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexit.Click
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

    Private Sub mnuuserpermission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuuserpermission.Click
        frmuserasign.MdiParent = Me
        frmuserasign.Show()
    End Sub

    Private Sub mnuchngpswd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuchngpswd.Click, btnchngpswd.Click
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

    Private Sub mnucalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnucalc.Click, btncalc.Click
        'System.Diagnostics.Process.Start("calc")
        System.Diagnostics.Process.Start("calc.exe")
    End Sub

    Private Sub mnunotepad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnunotepad.Click
        System.Diagnostics.Process.Start("notepad.exe")
    End Sub

    Private Sub mnudbbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudbbackup.Click, btndbbackup.Click
        Call data_backup()
    End Sub

    Private Sub mnudbrestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudbrestore.Click, btndbrestore.Click
        If mnuwin.DropDownItems.Count = 0 Then
            Call data_restore()
        Else
            MessageBox.Show("Please Close The All Active Forms.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub mnuunv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuunv.Click
        frmuniversity.MdiParent = Me
        frmuniversity.Show()
    End Sub

    Private Sub mnuSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSession.Click
        frmsession.MdiParent = Me
        frmsession.Show()
    End Sub

    Private Sub mnuSem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSem.Click
        frmsem.MdiParent = Me
        frmsem.Show()
    End Sub

    Private Sub mnuTrade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTrade.Click
        frmtrade.MdiParent = Me
        frmtrade.Show()
    End Sub

    Private Sub mnuCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCollection.Click
        frmcollhd.MdiParent = Me
        frmcollhd.Show()
    End Sub

    Private Sub mnuParty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuParty.Click
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

    Private Sub mnuProduct_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProduct.Click
        frmitem.MdiParent = Me
        frmitem.Show()
    End Sub

    Private Sub mnuSubject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSubject.Click
        frmsubmst.MdiParent = Me
        frmsubmst.Show()
    End Sub

    Private Sub mnuExamGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExamGroup.Click
        frmexmgrp.MdiParent = Me
        frmexmgrp.Show()
    End Sub

    Private Sub mnuExam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExam.Click

    End Sub

    Private Sub mnuPeriodGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPeriodGroup.Click
        frmpgroup.MdiParent = Me
        frmpgroup.Show()
    End Sub

    Private Sub mnuPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPeriod.Click
        frmperiod.MdiParent = Me
        frmperiod.Show()
    End Sub

    Private Sub mnuPlanner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnuDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDepartment.Click
        frmdept.MdiParent = Me
        frmdept.Show()
        'frmsams.MdiParent = Me
        'frmsams.Show()
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

    Private Sub mnuOccupation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOccupation.Click
        frmoccu.MdiParent = Me
        frmoccu.Show()
    End Sub

    Private Sub mnustudreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnustudreg.Click, btnstudreg.Click
        prmsn = sidebutton("mnustudreg")
        If prmsn = True Then
            frmstudreg.MdiParent = Me
            frmstudreg.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnustudenq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnustudenq.Click, btnstudenq.Click
        prmsn = sidebutton("mnustudenq")
        If prmsn = True Then
            frmenqiry.MdiParent = Me
            frmenqiry.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnuPayVouc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPayVouc.Click, btnPayVouc.Click
        prmsn = sidebutton("mnuPayVouc")
        If prmsn = True Then
            frmpayvouc.MdiParent = Me
            frmpayvouc.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    Private Sub mnuRec_Vouc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRec_Vouc.Click
        frmrecvouc.MdiParent = Me
        frmrecvouc.Show()
    End Sub

    Private Sub mnuPaySchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPaySchedule.Click, btnPaySchedule.Click
        prmsn = sidebutton("mnuPaySchedule")
        If prmsn = True Then
            frmschedule.MdiParent = Me
            frmschedule.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnuFeeColl_SC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFeeColl_SC.Click, btnFeeColl_SC.Click
        prmsn = sidebutton("mnuFeeColl_SC")
        If prmsn = True Then
            frmcollvouc.MdiParent = Me
            frmcollvouc.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub mnuFeeColl_NSC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFeeColl_NSC.Click, btnFeeColl_NSC.Click
        prmsn = sidebutton("mnuFeeColl_NSC")
        If prmsn = True Then
            frmocollvouc.MdiParent = Me
            frmocollvouc.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub mnupreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupreview.Click, btnpreview.Click
        Call disp_repo()
    End Sub

    Private Sub Mnutestreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mnutestreport.Click
        'frmmastergrid.MdiParent = Me
        'frmmastergrid.Show()
        frmexamresult.MdiParent = Me
        frmexamresult.Show()
    End Sub

    Private Sub mnusubassign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnusubassign.Click
        frmsubasgn.MdiParent = Me
        frmsubasgn.Show()
    End Sub

    Private Sub rep_studreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rep_studreg.Click, btn_studreg.Click
        prmsn = sidebutton("rep_studreg")
        If prmsn = True Then
            rep_stdlist.MdiParent = Me
            rep_stdlist.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        footer.Text = MarqueeLeft(footer.Text)
    End Sub

    Private Sub mnustudcolreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuschdcolreg.Click, btnschdcolreg.Click
        prmsn = sidebutton("mnuschdcolreg")
        If prmsn = True Then
            rep_colreg.MdiParent = Me
            rep_colreg.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub mnupayschd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupayschd.Click
        rep_schdreg.MdiParent = Me
        rep_schdreg.Show()
    End Sub

    Private Sub mnurecledg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnurecledg.Click
        rep_recledg.cmbreport.SelectedIndex = 0
        rep_recledg.MdiParent = Me
        rep_recledg.Show()
    End Sub

    Private Sub mnupayledg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupayledg.Click, btnpayledg.Click
        prmsn = sidebutton("mnupayledg")
        If prmsn = True Then
            rep_recledg.cmbreport.SelectedIndex = 1
            rep_recledg.MdiParent = Me
            rep_recledg.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnujrnledg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnujrnledg.Click
        rep_recledg.cmbreport.SelectedIndex = 2
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

    Private Sub mnuporder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuporder.Click, btnporder.Click
        prmsn = sidebutton("mnuporder")
        If prmsn = True Then
            frmporder.MdiParent = Me
            frmporder.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnupurinv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupurinv.Click, btnpurinv.Click
        prmsn = sidebutton("mnupurinv")
        If prmsn = True Then
            frmpurchinv.MdiParent = Me
            frmpurchinv.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnupret_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupret.Click
        frmpurchret.MdiParent = Me
        frmpurchret.Show()
    End Sub

    Private Sub mnuissue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuissue.Click
        frmiss.MdiParent = Me
        frmiss.Show()
    End Sub

    Private Sub mnurefund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnurefund.Click
        frmrefund.MdiParent = Me
        frmrefund.Show()
    End Sub

    Private Sub mnuintrgdn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuintrgdn.Click
        frmintrgodn.MdiParent = Me
        frmintrgodn.Show()
    End Sub

    Private Sub mnubookmst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnubookmst.Click
        frmbook.MdiParent = Me
        frmbook.Show()
    End Sub

    Private Sub mnuauthr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuauthr.Click
        frmauthor.MdiParent = Me
        frmauthor.Show()
    End Sub

    Private Sub mnupublictn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupublictn.Click
        frmpublication.MdiParent = Me
        frmpublication.Show()
    End Sub

    Private Sub mnushelf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnushelf.Click
        frmshelf.MdiParent = Me
        frmshelf.Show()
    End Sub

    Private Sub mnubkpur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnubkpur.Click
        frmbkpurch.MdiParent = Me
        frmbkpurch.Show()
    End Sub

    Private Sub mnubkscrl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnubkscrl.Click
        frmscroll.MdiParent = Me
        frmscroll.Show()
    End Sub

    Private Sub mnuorderreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuorderreg.Click
        rep_purchordreg.MdiParent = Me
        rep_purchordreg.Show()
    End Sub

    Private Sub mnupurchreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupurchreg.Click
        rep_purchreg.MdiParent = Me
        rep_purchreg.Show()
    End Sub

    Private Sub mnupurchretreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupurchretreg.Click
        rep_purchreturnreg.MdiParent = Me
        rep_purchreturnreg.Show()
    End Sub

    Private Sub mnuissureg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuissureg.Click
        rep_issuereg.cmbreport.SelectedIndex = 0
        rep_issuereg.MdiParent = Me
        rep_issuereg.Show()
    End Sub

    Private Sub mnurefreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnurefreg.Click
        rep_issuereg.cmbreport.SelectedIndex = 1
        rep_issuereg.MdiParent = Me
        rep_issuereg.Show()
    End Sub

    Private Sub mnubkiss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnubkiss.Click
        frmbkissue.MdiParent = Me
        frmbkissue.Show()
    End Sub

    Private Sub mnubkret_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnubkret.Click
        frmbkreturn.MdiParent = Me
        frmbkreturn.Show()
    End Sub

    Private Sub mnubkrej_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnubkrej.Click
        frmbkrejection.MdiParent = Me
        frmbkrejection.Show()
    End Sub

    Private Sub mnubksearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnubksearch.Click
        frmbksearch.MdiParent = Me
        frmbksearch.Show()
    End Sub

    Private Sub mnustudledg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnustudledg.Click, btnstudledg.Click
        prmsn = sidebutton("mnustudledg")
        If prmsn = True Then
            rep_studleg.MdiParent = Me
            rep_studleg.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub repcashbook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles repcashbook.Click, btncashbook.Click
        prmsn = sidebutton("repcashbook")
        If prmsn = True Then
            rep_cashbook.MdiParent = Me
            rep_cashbook.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnuprtledger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuprtledger.Click, btnprtledger.Click
        prmsn = sidebutton("mnuprtledger")
        If prmsn = True Then
            rep_partyledger.MdiParent = Me
            rep_partyledger.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub mnupaschdall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnupaschdall.Click, btnpaschdall.Click
        prmsn = sidebutton("mnupaschdall")
        If prmsn = True Then
            rep_schdregall.MdiParent = Me
            rep_schdregall.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnustudcolregindvdl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuschdcolregindvdl.Click
        rep_colregstud.MdiParent = Me
        rep_colregstud.Show()
    End Sub

    Private Sub mnuNschdcolreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNschdcolreg.Click, btnNschdcolreg.Click
        prmsn = sidebutton("mnuNschdcolreg")
        If prmsn = True Then
            rep_ocolreg.MdiParent = Me
            rep_ocolreg.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnuNschdcolregindvdl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNschdcolregindvdl.Click
        rep_ocolregstud.MdiParent = Me
        rep_ocolregstud.Show()
    End Sub

    Private Sub mnustudledger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnustudledger.Click
        'prmsn = sidebutton("mnustudledger")
        'If prmsn = True Then
        rep_studledg.MdiParent = Me
        rep_studledg.Show()
        'Else
        'MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub mnuTradeChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTradeChange.Click
        frmstrmchang.MdiParent = Me
        frmstrmchang.Show()
    End Sub

    Private Sub mnuemplyee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuemplyee.Click, btnemplyee.Click
        prmsn = sidebutton("mnuemplyee")
        If prmsn = True Then
            rep_stflist.MdiParent = Me
            rep_stflist.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub mnusms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnusms.Click, btnsms.Click
        prmsn = sidebutton("mnusms")
        If prmsn = True Then
            frmsmsservice.MdiParent = Me
            frmsmsservice.Show()
        Else
            MessageBox.Show("Sorry You Are Not Authenticate to Open This Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnustudlv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnustudlv.Click
        frmpromote.txttype.Text = "L"
        frmpromote.MdiParent = Me
        frmpromote.Show()
    End Sub

    Private Sub mnuStudPromot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStudPromot.Click
        frmpromote.txttype.Text = "P"
        frmpromote.MdiParent = Me
        frmpromote.Show()
    End Sub

    Private Sub mnustudout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnustudout.Click
        frmpromote.txttype.Text = "O"
        frmpromote.MdiParent = Me
        frmpromote.Show()
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

    Private Sub picnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picnxt.Click
        'If Panel3.Width < 190 Then

        '    For i As Integer = 1 To 190
        '        Panel3.Width = Panel3.Width + 1
        '    Next

        'End If
        Panel3.Visible = True
    End Sub

    Private Sub picleft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picleft.Click
        'If Panel3.Width >= 190 Then

        '    For i As Integer = 1 To 190
        '        Panel3.Width = Panel3.Width - 1
        '    Next

        'End If
        Panel3.Visible = False
    End Sub


    Private Sub picright_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picright.Click
        Panel4.Visible = False
        'If Panel4.Width >= 190 Then

        '    For i As Integer = 1 To 190
        '        Panel4.Width = Panel4.Width - 1
        '    Next

        'End If
    End Sub

    Private Sub picpre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picpre.Click
        Panel4.Visible = True
        'If Panel4.Width < 190 Then
        '    For i As Integer = 1 To 190
        '        Panel4.Width = Panel4.Width + 1
        '    Next
        'End If
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

    Private Sub pictwifi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictwifi.Click
        connected = CheckConnection() 'Checking Of Internet Connection Avalable Or Not
        If connected = True Then
            pictwifi.BackgroundImage = My.Resources.network2
        Else
            pictwifi.BackgroundImage = My.Resources.network1
        End If
    End Sub

    Private Sub MenuEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEntryToolStripMenuItem.Click
        frmmenuentry.MdiParent = Me
        frmmenuentry.Show()
    End Sub

    Private Sub mnuupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuupload.Click, btnupload.Click
        frmstuddoc.MdiParent = Me
        frmstuddoc.Show()
    End Sub

    Private Sub mnubkstkreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnubkstkreg.Click
        rep_bkstkreg.MdiParent = Me
        rep_bkstkreg.Show()
    End Sub

    Private Sub mnubkpurreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnubkpurreg.Click
        rep_bkpurchreg.MdiParent = Me
        rep_bkpurchreg.Show()
    End Sub

    Private Sub mnuPenalty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPenalty.Click

    End Sub

    Private Sub btnstudsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnstudsearch.Click, mnustudsearch.Click
        frmstudsearch.MdiParent = Me
        frmstudsearch.Show()
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

    Private Sub mnuprtbalupd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuprtbalupd.Click
        If mnuwin.DropDownItems.Count = 0 Then
            frmupdate.txttype.Text = "B"
            frmupdate.MdiParent = Me
            frmupdate.Show()
        Else
            MessageBox.Show("Please Close The All Active Forms.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mnubkissreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnubkissreg.Click
        rep_bkissuereg.cmbref.SelectedIndex = 0
        rep_bkissuereg.MdiParent = Me
        rep_bkissuereg.Show()
    End Sub

    Private Sub mnubkretreg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnubkretreg.Click
        rep_bkissuereg.cmbref.SelectedIndex = 0
        rep_bkissuereg.MdiParent = Me
        rep_bkissuereg.Show()
    End Sub

    Private Sub TestMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestMenuToolStripMenuItem.Click
        frmsams.MdiParent = Me
        frmsams.Show()
    End Sub
End Class