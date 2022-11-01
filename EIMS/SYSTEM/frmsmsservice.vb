Imports vb = Microsoft.VisualBasic
Imports System.Net
Imports System.IO

Public Class frmsmsservice
    Dim comd As String

    Private Sub frmsmsservice_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmsmsservice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmsmsservice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
        txttext.Text = conm
    End Sub

    Private Sub frmsmsservice_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        'TabControl1.TabPages.Remove(TabPage1)
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Remove(TabPage3)
        TabControl1.TabPages.Remove(TabPage4)
        TabControl1.TabPages.Remove(TabPage5)
        chkall1.Checked = True
        chkall2.Checked = True
        chkall3.Checked = True
        chkall4.Checked = True
        chkall5.Checked = True
        txtconper.Text = ""
        txtcontno.Text = ""
        txttext.Text = ""
        txtpage.Text = "0"
        txtcount.Text = "0"
        lblsmsbal.Text = "0"
        cmbgroup.Text = ""
        txtgrpcd1.Text = 0
        cmbsndtp.SelectedIndex = 0
        cmbgrpnm.Text = ""
        txtgrpcd1.Text = 0
        dv1.Rows.Clear()
        cmbgroup.Focus()
        connected = CheckConnection() 'Checking Of Internet Connection Avalable Or Not
        If connected = True Then
            lblinternet.Text = "Connected"
            lblinternet.ForeColor = Color.Green
        Else
            lblinternet.Text = "Disconnected"
            lblinternet.ForeColor = Color.Red
        End If
        If vb.Left(lblinternet.Text, 1) = "C" Then
            lblsmsbal.Text = sms_balance()
        End If
    End Sub

#Region "Enter/Leave"
    Private Sub cmbgroup_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpage.Enter, txtcount.Enter, txtcontno.Enter, txtconper.Enter, cmbgrpnm.Enter, cmbsndtp.Enter, cmbgroup.Enter, txttext.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub cmbgroup_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpage.Leave, txtcount.Leave, txtcontno.Leave, txtconper.Leave, cmbgrpnm.Leave, cmbsndtp.Leave, cmbgroup.Leave, txttext.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnplus_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsend.MouseEnter, btnsav.MouseEnter, btnclr.MouseEnter, btnplus.MouseEnter, btnexit.MouseEnter, btnfresh.MouseEnter, btnview.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnplus_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsend.MouseLeave, btnsav.MouseLeave, btnclr.MouseLeave, btnplus.MouseLeave, btnexit.MouseLeave, btnfresh.MouseLeave, btnview.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "KeyPress"
    Private Sub cmbgroup_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgroup.KeyPress
        key(btnplus, e)
        SPKey(e)
    End Sub

    Private Sub btnplus_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnplus.KeyPress
        key(txtconper, e)
    End Sub

    Private Sub txtconper_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconper.KeyPress
        key(txtcontno, e)
        SPKey(e)
    End Sub

    Private Sub txtcontno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontno.KeyPress
        key(btnsav, e)
        NUM1(e)
    End Sub

    Private Sub btnsav_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnsav.KeyPress
        key(btnclr, e)
    End Sub

    Private Sub btnrefre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnclr.KeyPress
        key(cmbsndtp, e)
    End Sub

    Private Sub cmbsend_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbsndtp.KeyPress
        key(cmbgrpnm, e)
        SPKey(e)
    End Sub

    Private Sub cmbgrpnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgrpnm.KeyPress
        key(txttext, e)
        SPKey(e)
    End Sub

    Private Sub txttext_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttext.KeyPress
        key(txtcount, e)
        SPKey(e)
    End Sub

    Private Sub txtcount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcount.KeyPress
        key(txtpage, e)
        NUM1(e)
    End Sub

    Private Sub txtpage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpage.KeyPress
        key(btnsend, e)
        NUM1(e)
    End Sub
#End Region

#Region "Combobox"

    Private Sub cmbgroup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgroup.GotFocus
        populate(cmbgroup, "SELECT grp_nm FROM phgroup ORDER BY grp_nm")
    End Sub

    Private Sub cmbgroup_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgroup.LostFocus
        cmbgroup.Height = 21
    End Sub

    Private Sub cmbgroup_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbgroup.Validated
        vdated(txtgrpcd, "SELECT grp_sl FROM phgroup WHERE grp_nm='" & Trim(cmbgroup.Text) & "'")
    End Sub

    'Private Sub cmbgroup_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgroup.Validating
    '    vdating(cmbgroup, "SELECT grp_nm FROM phgroup WHERE grp_nm='" & Trim(cmbgroup.Text) & "'", "Please Select A Valid Group Name.")
    'End Sub

    Private Sub cmbgrpnm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgrpnm.GotFocus
        populate(cmbgrpnm, "SELECT grp_nm FROM phgroup ORDER BY grp_nm")
    End Sub

    Private Sub cmbgrpnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgrpnm.LostFocus
        cmbgrpnm.Height = 21
    End Sub

    Private Sub cmbgrpnm_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbgrpnm.Validated
        vdated(txtgrpcd1, "SELECT grp_sl FROM phgroup WHERE grp_nm='" & Trim(cmbgrpnm.Text) & "'")
    End Sub

    Private Sub cmbgrpnm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgrpnm.Validating
        vdating(cmbgrpnm, "SELECT grp_nm FROM phgroup WHERE grp_nm='" & Trim(cmbgrpnm.Text) & "'", "Please Select A Valid Group Name.")
    End Sub

#End Region

    Private Sub txttext_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttext.TextChanged
        txtcount.Text = Len(txttext.Text)
        If Len(txttext.Text) <= 160 Then
            txtpage.Text = 1
        ElseIf Len(txttext.Text) > 160 * 1 Then
            txtpage.Text = 2
        ElseIf Len(txttext.Text) > 160 * 2 Then
            txtpage.Text = 3
        End If
    End Sub

    Private Sub cmbsend_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsndtp.SelectedIndexChanged
        cmbgrpnm.Enabled = False
        cmbgrpnm.Text = ""
        If vb.Left(cmbsndtp.Text, 1) = "6" Then
            cmbgrpnm.Enabled = True
        End If
    End Sub

    Private Sub chkall1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall1.CheckedChanged
        If chkall1.Checked = True Then
            For i As Integer = 0 To dv1.Rows.Count - 1
                dv1.Rows(i).Cells(0).Value = 1
            Next
        Else
            For i As Integer = 0 To dv1.Rows.Count - 1
                dv1.Rows(i).Cells(0).Value = 0
            Next
        End If
    End Sub

    Private Sub chkall2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall2.CheckedChanged
        If chkall2.Checked = True Then
            For i As Integer = 0 To dv2.Rows.Count - 1
                dv2.Rows(i).Cells(0).Value = 1
            Next
        Else
            For i As Integer = 0 To dv2.Rows.Count - 1
                dv2.Rows(i).Cells(0).Value = 0
            Next
        End If
    End Sub

    Private Sub chkall3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall3.CheckedChanged
        If chkall3.Checked = True Then
            For i As Integer = 0 To dv3.Rows.Count - 1
                dv3.Rows(i).Cells(0).Value = 1
            Next
        Else
            For i As Integer = 0 To dv3.Rows.Count - 1
                dv3.Rows(i).Cells(0).Value = 0
            Next
        End If
    End Sub

    Private Sub chkall4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall4.CheckedChanged
        If chkall4.Checked = True Then
            For i As Integer = 0 To dv4.Rows.Count - 1
                dv4.Rows(i).Cells(0).Value = 1
            Next
        Else
            For i As Integer = 0 To dv4.Rows.Count - 1
                dv4.Rows(i).Cells(0).Value = 0
            Next
        End If
    End Sub

    Private Sub chkall5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall5.CheckedChanged
        If chkall5.Checked = True Then
            For i As Integer = 0 To dv5.Rows.Count - 1
                dv5.Rows(i).Cells(0).Value = 1
            Next
        Else
            For i As Integer = 0 To dv5.Rows.Count - 1
                dv5.Rows(i).Cells(0).Value = 0
            Next
        End If
    End Sub


#Region "Button"
    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnfresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfresh.Click
        Me.clr()
    End Sub

    Private Sub btnsend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsend.Click
        If Trim(txttext.Text) = "" Then
            MessageBox.Show("The Message Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txttext.Focus()
            Exit Sub
        End If
        cnfr = MessageBox.Show("Are You Sure to Save The SMS For Sending it Later.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If cnfr = vbYes Then
            Start1()
            For i As Integer = 0 To 4
                If i = 0 Then
                    Me.save_sms(dv1, chkconfr1)
                ElseIf i = 1 Then
                    Me.save_sms(dv2, chkconfr2)
                ElseIf i = 2 Then
                    Me.save_sms(dv3, chkconfr3)
                ElseIf i = 3 Then
                    Me.save_sms(dv4, chkconfr4)
                ElseIf i = 4 Then
                    Me.save_sms(dv5, chkconfr5)
                End If
            Next
            Me.clr()
        End If
        Close1()
    End Sub

    Private Sub save_sms(ByVal dv As DataGridView, ByVal chkconfr As CheckBox)
        Dim ds As DataSet = get_dataset("SELECT max(sms_sl) as 'Max' FROM sending_sms")
        mxno = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                mxno = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        pbst()
        pb.Maximum = dv.Rows.Count + 1
        For i As Integer = 0 To dv.Rows.Count - 1
            If dv.Rows(i).Cells(0).Value = 1 Then
                cont_nm = dv.Rows(i).Cells(2).Value
                mobno = dv.Rows(i).Cells(3).Value
                If Len(mobno) = 10 Then
                    If chkconfr.Checked = True Then
                        cnfr = MessageBox.Show("Are You Sure To Send SMS To " & cont_nm & ".", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If cnfr = vbYes Then
                            saving_sms(mxno, "Gateway SMS", mobno, Trim(txttext.Text))
                            mxno += 1
                        End If
                    Else
                        saving_sms(mxno, "Gateway SMS", mobno, Trim(txttext.Text))
                        mxno += 1
                    End If
                End If
            End If
            pbin()
        Next
        pbcl()
    End Sub

    Private Sub btnsav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsav.Click
        If Trim(cmbgroup.Text) = "" Or Val(txtgrpcd.Text) = 0 Then
            MessageBox.Show("Please Provide A Group Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbgroup.Focus()
            Exit Sub
        End If
        If Trim(cmbgroup.Text) <> "" Then
            Start1()
            Dim ds As DataSet = get_dataset("SELECT grp_nm FROM phgroup WHERE grp_nm='" & Trim(cmbgroup.Text) & "'")
            If ds.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("Please Select A Valid Group Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbgroup.Focus()
            End If
            Close1()
        End If
        If Trim(txtconper.Text) = "" Then
            MessageBox.Show("Please Provide A Contact Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtconper.Focus()
            Exit Sub
        End If
        If Trim(txtcontno.Text) = "" Then
            MessageBox.Show("Please Provide A Contact Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtconper.Focus()
            Exit Sub
        End If

        Start1()
        Dim ds1 As DataSet = get_dataset("SELECT cont_nm FROM contacts WHERE grp_sl=" & Val(txtgrpcd.Text) & " AND cont_nm='" & Trim(txtconper.Text) & "'")
        If ds1.Tables(0).Rows.Count = 0 Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(cont_sl) as 'Max' FROM contacts")
                mxno = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO contacts (cont_sl,cont_nm,cont_no,grp_sl) VALUES (" & Val(mxno) & ",'" & _
                          Trim(txtconper.Text) & "','" & Trim(txtcontno.Text) & "'," & Val(txtgrpcd.Text) & ")")
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbgroup.Text = ""
                txtgrpcd.Text = 0
                txtconper.Text = ""
                txtcontno.Text = ""
                cmbgroup.Focus()
            End If
        Else
            MessageBox.Show("Sorry The Contact Name Already Present in Your Database For This Group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbgroup.Focus()
        End If
        Close1()


    End Sub

    Private Sub btnclr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclr.Click
        cmbgroup.Text = ""
        txtgrpcd.Text = 0
        txtconper.Text = ""
        txtcontno.Text = ""
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Dim ds As DataSet
        If vb.Left(cmbsndtp.Text, 1) = "1" Then
            ds = get_dataset("SELECT stud_nm,pre_ph1 FROM stud WHERE leaved='N' AND sms_req='Y' ORDER BY stud_nm")
        ElseIf vb.Left(cmbsndtp.Text, 1) = "2" Then
            ds = get_dataset("SELECT fathr_nm,per_ph1,stud_nm FROM stud WHERE leaved='N' AND sms_req='Y' ORDER BY fathr_nm")
        ElseIf vb.Left(cmbsndtp.Text, 1) = "3" Then
            ds = get_dataset("SELECT mthr_nm,per_ph2,stud_nm FROM stud WHERE leaved='N' AND sms_req='Y' ORDER BY mthr_nm")
        ElseIf vb.Left(cmbsndtp.Text, 1) = "4" Then
            ds = get_dataset("SELECT lg_nm,lg_phno1,stud_nm FROM stud WHERE leaved='N' AND sms_req='Y' ORDER BY lg_nm")
        ElseIf vb.Left(cmbsndtp.Text, 1) = "5" Then
            ds = get_dataset("SELECT staf_nm,cont_no FROM staf WHERE leaved='N' AND sms_req='Y' ORDER BY staf_nm")
        Else
            ds = get_dataset("SELECT contacts.cont_nm, contacts.cont_no, phgroup.grp_nm FROM contacts LEFT OUTER JOIN phgroup ON contacts.grp_sl = phgroup.grp_sl WHERE contacts.grp_sl=" & Val(txtgrpcd1.Text) & " ORDER BY contacts.cont_nm")
        End If
        dv1.Rows.Clear()
        dv2.Rows.Clear()
        dv3.Rows.Clear()
        dv4.Rows.Clear()
        dv5.Rows.Clear()
        pbst()
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim rw1 As Integer = 0
            Dim rw2 As Integer = 0
            Dim rw3 As Integer = 0
            Dim rw4 As Integer = 0
            Dim rw5 As Integer = 0
            pb.Maximum = ds.Tables(0).Rows.Count + 1
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage4)
            TabControl1.TabPages.Remove(TabPage5)
            If ds.Tables(0).Rows.Count > 400 * 5 Then
                TabControl1.TabPages.Add(TabPage2)
                TabControl1.TabPages.Add(TabPage3)
                TabControl1.TabPages.Add(TabPage4)
                TabControl1.TabPages.Add(TabPage5)
            ElseIf ds.Tables(0).Rows.Count > 400 * 4 Then
                TabControl1.TabPages.Add(TabPage2)
                TabControl1.TabPages.Add(TabPage3)
                TabControl1.TabPages.Add(TabPage4)
            ElseIf ds.Tables(0).Rows.Count > 400 * 3 Then
                TabControl1.TabPages.Add(TabPage2)
                TabControl1.TabPages.Add(TabPage3)
            ElseIf ds.Tables(0).Rows.Count > 400 * 2 Then
                TabControl1.TabPages.Add(TabPage2)
            End If
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Columns(4).HeaderText = "Group"
                If vb.Left(cmbsndtp.Text, 1) = "6" Then
                    grpnm = cmbgrpnm.Text
                ElseIf vb.Left(cmbsndtp.Text, 1) = "1" Then
                    grpnm = "Student"
                ElseIf vb.Left(cmbsndtp.Text, 1) = "5" Then
                    grpnm = "Employee"
                Else
                    grpnm = ds.Tables(0).Rows(i).Item(2)
                    dv1.Columns(4).HeaderText = "Student Name"
                    dv2.Columns(4).HeaderText = "Student Name"
                    dv3.Columns(4).HeaderText = "Student Name"
                    dv4.Columns(4).HeaderText = "Student Name"
                    dv5.Columns(4).HeaderText = "Student Name"
                End If
                If Val(i + 1) > 400 And i < 400 * 2 Then
                    dv2.Rows.Add()
                    dv2.Columns(0).Visible = True
                    dv2.Rows(rw2).Cells(0).Value = 1
                    dv2.Rows(rw2).Cells(1).Value = i + 1
                    dv2.Rows(rw2).Cells(2).Value = ds.Tables(0).Rows(i).Item(0)
                    dv2.Rows(rw2).Cells(3).Value = ds.Tables(0).Rows(i).Item(1)
                    dv2.Rows(rw2).Cells(4).Value = grpnm
                    rw2 += 1
                ElseIf Val(i + 1) > 400 * 2 And i < 400 * 3 Then
                    dv3.Rows.Add()
                    dv3.Columns(0).Visible = True
                    dv3.Rows(rw3).Cells(0).Value = 1
                    dv3.Rows(rw3).Cells(1).Value = i + 1
                    dv3.Rows(rw3).Cells(2).Value = ds.Tables(0).Rows(i).Item(0)
                    dv3.Rows(rw3).Cells(3).Value = ds.Tables(0).Rows(i).Item(1)
                    dv3.Rows(rw3).Cells(4).Value = grpnm
                    rw3 += 1
                ElseIf Val(i + 1) > 400 * 3 And i < 400 * 4 Then
                    dv4.Rows.Add()
                    dv4.Columns(0).Visible = True
                    dv4.Rows(rw4).Cells(0).Value = 1
                    dv4.Rows(rw4).Cells(1).Value = i + 1
                    dv4.Rows(rw4).Cells(2).Value = ds.Tables(0).Rows(i).Item(0)
                    dv4.Rows(rw4).Cells(3).Value = ds.Tables(0).Rows(i).Item(1)
                    dv4.Rows(rw4).Cells(4).Value = grpnm
                    rw4 += 1
                ElseIf Val(i + 1) > 400 * 4 And i < 400 * 5 Then
                    dv5.Rows.Add()
                    dv5.Columns(0).Visible = True
                    dv5.Rows(rw5).Cells(0).Value = 1
                    dv5.Rows(rw5).Cells(1).Value = i + 1
                    dv5.Rows(rw5).Cells(2).Value = ds.Tables(0).Rows(i).Item(0)
                    dv5.Rows(rw5).Cells(3).Value = ds.Tables(0).Rows(i).Item(1)
                    dv5.Rows(rw5).Cells(4).Value = grpnm
                    rw5 += 1
                ElseIf i < 400 Then
                    dv1.Rows.Add()
                    dv1.Columns(0).Visible = True
                    dv1.Rows(rw1).Cells(0).Value = 1
                    dv1.Rows(rw1).Cells(1).Value = i + 1
                    dv1.Rows(rw1).Cells(2).Value = ds.Tables(0).Rows(i).Item(0)
                    dv1.Rows(rw1).Cells(3).Value = ds.Tables(0).Rows(i).Item(1)
                    dv1.Rows(rw1).Cells(4).Value = grpnm
                    rw1 += 1
                End If
                pbin()
            Next
        End If
        pbcl()
    End Sub
#End Region

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        Me.search()
    End Sub

    Private Sub search()
        Dim ds As DataSet
        If chkexact.Checked = False Then
            If vb.Left(cmbsndtp.Text, 1) = "1" Then
                ds = get_dataset("SELECT stud_nm,pre_ph1 FROM stud WHERE leaved='N'AND sms_req='Y' AND stud_nm LIKE '%" & Trim(txtsearch.Text) & "%' ORDER BY stud_nm")
            ElseIf vb.Left(cmbsndtp.Text, 1) = "2" Then
                ds = get_dataset("SELECT fathr_nm,per_ph1,stud_nm FROM stud WHERE leaved='N' AND sms_req='Y' AND fathr_nm LIKE '%" & Trim(txtsearch.Text) & "%' ORDER BY fathr_nm")
            ElseIf vb.Left(cmbsndtp.Text, 1) = "3" Then
                ds = get_dataset("SELECT mthr_nm,per_ph2,stud_nm FROM stud WHERE leaved='N' AND sms_req='Y' AND mthr_nm LIKE '%" & Trim(txtsearch.Text) & "%' ORDER BY mthr_nm")
            ElseIf vb.Left(cmbsndtp.Text, 1) = "4" Then
                ds = get_dataset("SELECT lg_nm,lg_phno1,stud_nm FROM stud WHERE leaved='N' AND sms_req='Y' AND lg_nm LIKE '%" & Trim(txtsearch.Text) & "%' ORDER BY lg_nm")
            ElseIf vb.Left(cmbsndtp.Text, 1) = "5" Then
                ds = get_dataset("SELECT staf_nm,cont_no FROM staf WHERE leaved='N' AND sms_req='Y' AND staf_nm LIKE '%" & Trim(txtsearch.Text) & "%' ORDER BY staf_nm")
            Else
                ds = get_dataset("SELECT contacts.cont_nm, contacts.cont_no, phgroup.grp_nm FROM contacts LEFT OUTER JOIN phgroup ON contacts.grp_sl = phgroup.grp_sl WHERE contacts.grp_sl=" & Val(txtgrpcd1.Text) & " AND contacts.cont_nm LIKE '%" & Trim(txtsearch.Text) & "%' ORDER BY contacts.cont_nm")
            End If
        Else
            If vb.Left(cmbsndtp.Text, 1) = "1" Then
                ds = get_dataset("SELECT stud_nm,pre_ph1 FROM stud WHERE leaved='N' AND sms_req='Y' AND stud_nm LIKE '" & Trim(txtsearch.Text) & "%' ORDER BY stud_nm")
            ElseIf vb.Left(cmbsndtp.Text, 1) = "2" Then
                ds = get_dataset("SELECT fathr_nm,per_ph1,stud_nm FROM stud WHERE leaved='N' AND sms_req='Y' AND fathr_nm LIKE '" & Trim(txtsearch.Text) & "%' ORDER BY fathr_nm")
            ElseIf vb.Left(cmbsndtp.Text, 1) = "3" Then
                ds = get_dataset("SELECT mthr_nm,per_ph2,stud_nm FROM stud WHERE leaved='N' AND sms_req='Y' AND mthr_nm LIKE '" & Trim(txtsearch.Text) & "%' ORDER BY mthr_nm")
            ElseIf vb.Left(cmbsndtp.Text, 1) = "4" Then
                ds = get_dataset("SELECT lg_nm,lg_phno1,stud_nm FROM stud WHERE leaved='N' AND sms_req='Y' AND lg_nm LIKE '" & Trim(txtsearch.Text) & "%' ORDER BY lg_nm")
            ElseIf vb.Left(cmbsndtp.Text, 1) = "5" Then
                ds = get_dataset("SELECT staf_nm,cont_no FROM staf WHERE leaved='N' AND sms_req='Y' AND staf_nm LIKE '" & Trim(txtsearch.Text) & "%' ORDER BY staf_nm")
            Else
                ds = get_dataset("SELECT contacts.cont_nm, contacts.cont_no, phgroup.grp_nm FROM contacts LEFT OUTER JOIN phgroup ON contacts.grp_sl = phgroup.grp_sl WHERE contacts.grp_sl=" & Val(txtgrpcd1.Text) & " AND contacts.cont_nm LIKE '" & Trim(txtsearch.Text) & "%' ORDER BY contacts.cont_nm")
            End If
        End If
        dv1.Rows.Clear()
        dv2.Rows.Clear()
        dv3.Rows.Clear()
        dv4.Rows.Clear()
        dv5.Rows.Clear()
        pbst()
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim rw1 As Integer = 0
            Dim rw2 As Integer = 0
            Dim rw3 As Integer = 0
            Dim rw4 As Integer = 0
            Dim rw5 As Integer = 0
            pb.Maximum = ds.Tables(0).Rows.Count + 1
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage4)
            TabControl1.TabPages.Remove(TabPage5)
            If ds.Tables(0).Rows.Count > 400 * 5 Then
                TabControl1.TabPages.Add(TabPage2)
                TabControl1.TabPages.Add(TabPage3)
                TabControl1.TabPages.Add(TabPage4)
                TabControl1.TabPages.Add(TabPage5)
            ElseIf ds.Tables(0).Rows.Count > 400 * 4 Then
                TabControl1.TabPages.Add(TabPage2)
                TabControl1.TabPages.Add(TabPage3)
                TabControl1.TabPages.Add(TabPage4)
            ElseIf ds.Tables(0).Rows.Count > 400 * 3 Then
                TabControl1.TabPages.Add(TabPage2)
                TabControl1.TabPages.Add(TabPage3)
            ElseIf ds.Tables(0).Rows.Count > 400 * 2 Then
                TabControl1.TabPages.Add(TabPage2)
            End If
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Columns(4).HeaderText = "Group"
                If vb.Left(cmbsndtp.Text, 1) = "6" Then
                    grpnm = cmbgrpnm.Text
                ElseIf vb.Left(cmbsndtp.Text, 1) = "1" Then
                    grpnm = "Student"
                ElseIf vb.Left(cmbsndtp.Text, 1) = "5" Then
                    grpnm = "Employee"
                Else
                    grpnm = ds.Tables(0).Rows(i).Item(2)
                    dv1.Columns(4).HeaderText = "Student Name"
                    dv2.Columns(4).HeaderText = "Student Name"
                    dv3.Columns(4).HeaderText = "Student Name"
                    dv4.Columns(4).HeaderText = "Student Name"
                    dv5.Columns(4).HeaderText = "Student Name"
                End If
                If Val(i + 1) > 400 And i < 400 * 2 Then
                    dv2.Rows.Add()
                    dv2.Columns(0).Visible = True
                    dv2.Rows(rw2).Cells(0).Value = 1
                    dv2.Rows(rw2).Cells(1).Value = i + 1
                    dv2.Rows(rw2).Cells(2).Value = ds.Tables(0).Rows(i).Item(0)
                    dv2.Rows(rw2).Cells(3).Value = ds.Tables(0).Rows(i).Item(1)
                    dv2.Rows(rw2).Cells(4).Value = grpnm
                    rw2 += 1
                ElseIf Val(i + 1) > 400 * 2 And i < 400 * 3 Then
                    dv3.Rows.Add()
                    dv3.Columns(0).Visible = True
                    dv3.Rows(rw3).Cells(0).Value = 1
                    dv3.Rows(rw3).Cells(1).Value = i + 1
                    dv3.Rows(rw3).Cells(2).Value = ds.Tables(0).Rows(i).Item(0)
                    dv3.Rows(rw3).Cells(3).Value = ds.Tables(0).Rows(i).Item(1)
                    dv3.Rows(rw3).Cells(4).Value = grpnm
                    rw3 += 1
                ElseIf Val(i + 1) > 400 * 3 And i < 400 * 4 Then
                    dv4.Rows.Add()
                    dv4.Columns(0).Visible = True
                    dv4.Rows(rw4).Cells(0).Value = 1
                    dv4.Rows(rw4).Cells(1).Value = i + 1
                    dv4.Rows(rw4).Cells(2).Value = ds.Tables(0).Rows(i).Item(0)
                    dv4.Rows(rw4).Cells(3).Value = ds.Tables(0).Rows(i).Item(1)
                    dv4.Rows(rw4).Cells(4).Value = grpnm
                    rw4 += 1
                ElseIf Val(i + 1) > 400 * 4 And i < 400 * 5 Then
                    dv5.Rows.Add()
                    dv5.Columns(0).Visible = True
                    dv5.Rows(rw5).Cells(0).Value = 1
                    dv5.Rows(rw5).Cells(1).Value = i + 1
                    dv5.Rows(rw5).Cells(2).Value = ds.Tables(0).Rows(i).Item(0)
                    dv5.Rows(rw5).Cells(3).Value = ds.Tables(0).Rows(i).Item(1)
                    dv5.Rows(rw5).Cells(4).Value = grpnm
                    rw5 += 1
                ElseIf i < 400 Then
                    dv1.Rows.Add()
                    dv1.Columns(0).Visible = True
                    dv1.Rows(rw1).Cells(0).Value = 1
                    dv1.Rows(rw1).Cells(1).Value = i + 1
                    dv1.Rows(rw1).Cells(2).Value = ds.Tables(0).Rows(i).Item(0)
                    dv1.Rows(rw1).Cells(3).Value = ds.Tables(0).Rows(i).Item(1)
                    dv1.Rows(rw1).Cells(4).Value = grpnm
                    rw1 += 1
                End If
                pbin()
            Next
        End If
        pbcl()
    End Sub

    Private Sub chkexact_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkexact.CheckedChanged
        Me.search()
    End Sub

    Public Sub pbst()
        pb.Visible = True
        pb.Value = 0
        pb.Width = Width - 105
    End Sub

    Public Sub pbin()
        If pb.Value < pb.Maximum Then
            pb.Value += 1
        End If
    End Sub

    Public Sub pbcl()
        pb.Visible = False
        pb.Width = 100
    End Sub

    Private Sub send_sms(ByVal dv As DataGridView, ByVal chkconfr As CheckBox)
        If Trim(txttext.Text) = "" Then
            MessageBox.Show("The Message Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txttext.Focus()
            Exit Sub
        End If
        chk = 0
        For i As Integer = 0 To dv.Rows.Count - 1
            If dv.Rows(i).Cells(0).Value = 1 Then
                chk += 1
            End If
        Next
        If chk = 0 Then
            MessageBox.Show("Please Select At Least One Contact For Sending SMS.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Start1()
        Dim ds As DataSet = get_dataset("SELECT max(sms_sl) as 'Max' FROM sending_sms")
        mxno = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                mxno = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        pbst()
        If vb.Left(lblinternet.Text, 1) = "C" Then
            If Val(lblsmsbal.Text) > Val(chk) Then
                pb.Maximum = dv.Rows.Count + 1
                mob_no = ""
                For i As Integer = 0 To dv.Rows.Count - 1
                    If dv.Rows(i).Cells(0).Value = 1 Then
                        cont_nm = dv.Rows(i).Cells(2).Value
                        mobno = dv.Rows(i).Cells(3).Value
                        If Len(mobno) = 10 Then
                            If chkconfr.Checked = True Then
                                cnfr = MessageBox.Show("Are You Sure To Send SMS To " & cont_nm & ".", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                If cnfr = vbYes Then
                                    If mob_no <> "" Then
                                        mob_no = mob_no & ","
                                    End If
                                    mob_no = mob_no & "91" & mobno
                                End If
                            Else
                                If mob_no <> "" Then
                                    mob_no = mob_no & ","
                                End If
                                mob_no = mob_no & "91" & mobno
                            End If
                        End If
                    End If
                    pbin()
                Next
                If mob_no <> "" Then
                    'Sending_sms(mob_no, Trim(txttext.Text))
                End If
            Else
                cnfr = MessageBox.Show("There is Not Sufficient SMS Balance.Are You want to Save SMS For Sending Later.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If cnfr = vbYes Then
                    pb.Maximum = dv.Rows.Count + 1
                    For i As Integer = 0 To dv.Rows.Count - 1
                        If dv.Rows(i).Cells(0).Value = 1 Then
                            cont_nm = dv.Rows(i).Cells(2).Value
                            mobno = dv.Rows(i).Cells(3).Value
                            If Len(mobno) = 10 Then
                                If chkconfr.Checked = True Then
                                    cnfr = MessageBox.Show("Are You Sure To Send SMS To " & cont_nm & ".", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    If cnfr = vbYes Then
                                        saving_sms(mxno, "Gateway SMS", mobno, Trim(txttext.Text))
                                        mxno += 1
                                    End If
                                Else
                                    saving_sms(mxno, "Gateway SMS", mobno, Trim(txttext.Text))
                                    mxno += 1
                                End If
                            End If
                        End If
                        pbin()
                    Next
                End If
            End If
        Else
            cnfr = MessageBox.Show("There is No Internet Connection.Are You want to Save SMS For Sending Later.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If cnfr = vbYes Then
                pb.Maximum = dv.Rows.Count + 1
                For i As Integer = 0 To dv.Rows.Count - 1
                    If dv.Rows(i).Cells(0).Value = 1 Then
                        cont_nm = dv.Rows(i).Cells(2).Value
                        mobno = dv.Rows(i).Cells(3).Value
                        If Len(mobno) = 10 Then
                            If chkconfr.Checked = True Then
                                cnfr = MessageBox.Show("Are You Sure To Send SMS To " & cont_nm & ".", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                If cnfr = vbYes Then
                                    saving_sms(mxno, "Gateway SMS", mobno, Trim(txttext.Text))
                                    mxno += 1
                                End If
                            Else
                                saving_sms(mxno, "Gateway SMS", mobno, Trim(txttext.Text))
                                mxno += 1
                            End If
                        End If
                    End If
                    pbin()
                Next
            End If
        End If
        Close1()
        pbcl()
        dv.Rows.Clear()
    End Sub

    Private Sub btnplus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnplus.Click
        If Trim(cmbgroup.Text) = "" Then
            MessageBox.Show("Please Provide A Group Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbgroup.Focus()
            Exit Sub
        End If
        Start1()
        Dim ds1 As DataSet = get_dataset("SELECT grp_nm FROM phgroup WHERE grp_nm='" & Trim(cmbgroup.Text) & "'")
        If ds1.Tables(0).Rows.Count = 0 Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(grp_sl) as 'Max' FROM phgroup")
                txtgrpcd.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtgrpcd.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO phgroup (grp_sl,grp_nm) VALUES (" & Val(txtgrpcd.Text) & ",'" & _
                          Trim(cmbgroup.Text) & "')")
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbgroup.Focus()
            End If
        Else
            MessageBox.Show("Sorry The Group Name Already Present in Your Database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbgroup.Focus()
        End If
        Close1()
    End Sub

    Private Sub lnksend1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnksend1.LinkClicked
        Me.send_sms(dv1, chkconfr1)
    End Sub

    Private Sub lnksend2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnksend2.LinkClicked
        Me.send_sms(dv2, chkconfr2)
    End Sub

    Private Sub lnksend3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnksend3.LinkClicked
        Me.send_sms(dv3, chkconfr3)
    End Sub

    Private Sub lnksend4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnksend4.LinkClicked
        Me.send_sms(dv4, chkconfr4)
    End Sub

    Private Sub lnksend5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnksend5.LinkClicked
        Me.send_sms(dv5, chkconfr5)
    End Sub
End Class
