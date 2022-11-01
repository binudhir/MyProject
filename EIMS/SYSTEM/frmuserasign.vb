Imports vb = Microsoft.VisualBasic
Public Class frmuserasign
    Dim comd As String
#Region "Start Up"
    Private Sub frmuserasign_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmuserasign_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmuserasign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If inventory = "N" Then
            TabControl1.TabPages.Remove(TabPage4)
        End If
        If exam = "N" Then
            TabControl1.TabPages.Remove(TabPage5)
        End If
        If library = "N" Then
            TabControl1.TabPages.Remove(TabPage6)
        End If

        Me.clr()
    End Sub

    Private Sub frmuserasign_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black
        End If
    End Sub

    Private Sub clr()
        cmbempid.Text = ""
        txtusrnm.Text = ""
        txtusrlevel.Text = ""
        txtusrsl.Text = 0
        chkadd.Checked = False
        chkdel.Checked = False
        chkedit.Checked = False
        chkview.Checked = False
        dvmaster.Rows.Clear()
        cmbempid.Focus()
        Me.dv_disp(dvmaster, "LEFT(menu_tp,1)='M'")
        Me.dv_disp(dvstud, "menu_tp='S'")
        Me.dv_disp(dvacnt, "menu_tp='A'")
        Me.dv_disp(dvinv, "menu_tp='I'")
        Me.dv_disp(dvexam, "menu_tp='E'")
        Me.dv_disp(dvlib, "menu_tp='L'")
        Me.dv_disp(dvrepo, "LEFT(menu_tp,1)='R'")
        Me.dv_disp(dvutility, "menu_tp='U'")
        Me.dv_disp(dvconfig, "(menu_tp='C' OR menu_tp='X')")
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click, cmenufresh.Click
        Me.clr()
    End Sub

    Private Sub btnAsgnvw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsgnvw.Click
        Me.assign_disp(dvmaster, "LEFT(menu_tp,1)='M'")
        Me.assign_disp(dvstud, "menu_tp='S'")
        Me.assign_disp(dvacnt, "menu_tp='A'")
        Me.assign_disp(dvinv, "menu_tp='I'")
        Me.assign_disp(dvexam, "menu_tp='E'")
        Me.assign_disp(dvlib, "menu_tp='L'")
        Me.assign_disp(dvrepo, "LEFT(menu_tp,1)='R'")
        Me.assign_disp(dvutility, "menu_tp='U'")
        Me.assign_disp(dvconfig, "(menu_tp='C' OR menu_tp='X')")
    End Sub

    Private Sub btnmnuupdt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmnuupdt.Click
        cnfr = MessageBox.Show("Are You Sure To Refresh The Menu List.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            Call menu_update()
        End If
        cnfr = MessageBox.Show("Are You Sure To Update The User Assignment.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            Start1()
            SQLInsert("DELETE FROM user_assign")
            Close1()
            Dim ds1 As DataSet = get_dataset("SELECT usr_sl,usr_tp FROM usr")
            If ds1.Tables(0).Rows.Count <> 0 Then
                For m As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                    usrsl = ds1.Tables(0).Rows(m).Item(0)
                    usrtp = ds1.Tables(0).Rows(m).Item(1)
                    Dim ds As DataSet = get_dataset("SELECT * FROM menumst ORDER BY menu_sl")
                    If ds.Tables(0).Rows.Count <> 0 Then
                        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                            Dim ds2 As DataSet = get_dataset("SELECT max(asgn_no) as 'Max' FROM user_assign")
                            asgn_no = 1
                            If ds2.Tables(0).Rows.Count <> 0 Then
                                If Not IsDBNull(ds2.Tables(0).Rows(0).Item(0)) Then
                                    asgn_no = ds2.Tables(0).Rows(0).Item(0) + 1
                                End If
                            End If
                            menusl = ds.Tables(0).Rows(i).Item("menu_sl")
                            menu_tp = ds.Tables(0).Rows(i).Item("menu_tp")
                            menu_prmsn = ds.Tables(0).Rows(i).Item("menu_prmsn")
                            viewprmsn = 0
                            addprmsn = 0
                            editprmsn = 0
                            delprmsn = 0
                            If usrtp = "A" And menu_prmsn = "Y" Then
                                viewprmsn = 1
                                addprmsn = 1
                                editprmsn = 1
                                delprmsn = 1
                            End If
                            If vb.Left(ds.Tables(0).Rows(i).Item("menu_tp"), 1) = "R" Then
                                viewprmsn = 0
                            ElseIf ds.Tables(0).Rows(i).Item("menu_tp") = "X" Or ds.Tables(0).Rows(i).Item("menu_tp") = "U" Or ds.Tables(0).Rows(i).Item("menu_tp") = "C" Then
                                addprmsn = 0
                                delprmsn = 0
                            End If

                            Start1()
                            SQLInsert("INSERT INTO user_assign (asgn_no,user_sl,menu_sl,add_prm,edit_prm,delete_prm,view_prm) VALUES (" & Val(asgn_no) & "," & _
                                      Val(usrsl) & "," & Val(menusl) & "," & Val(addprmsn) & "," & Val(editprmsn) & "," & Val(delprmsn) & "," & Val(viewprmsn) & ")")
                            Close1()
                            asgn_no += 1
                        Next
                    End If
                Next
            End If
            Me.clr()
        End If
    End Sub

    Private Sub txtmembr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbempid.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub txtmembr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbempid.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.MouseEnter, btnupdate.MouseEnter, btnexit.MouseEnter, btnmnuupdt.MouseEnter, btnAsgnvw.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.MouseLeave, btnupdate.MouseLeave, btnexit.MouseLeave, btnmnuupdt.MouseLeave, btnAsgnvw.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub cbview_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkview.MouseEnter, chkedit.MouseEnter, chkdel.MouseEnter, chkadd.MouseEnter
        sender.forecolor = Color.Blue
    End Sub

    Private Sub cbview_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkview.MouseLeave, chkedit.MouseLeave, chkdel.MouseLeave, chkadd.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub cmbempid_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbempid.KeyPress
        key(btnupdate, e)
        SPKey(e)
    End Sub
#End Region

    Private Sub cmbempid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbempid.GotFocus
        populate(cmbempid, "SELECT usr_id FROM usr WHERE login_block='N' AND usr_tp<>'A' AND usr_tp<>'D' ORDER BY usr_id")
    End Sub

    Private Sub cmbempid_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbempid.LostFocus
        cmbempid.Height = 21
    End Sub

    Private Sub cmbempid_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbempid.Validated
        Dim ds As DataSet = get_dataset("SELECT usr_sl,usr_nm,usr_tp FROM usr WHERE usr_id='" & Trim(cmbempid.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtusrsl.Text = ds.Tables(0).Rows(0).Item("usr_sl")
            txtusrnm.Text = ds.Tables(0).Rows(0).Item("usr_nm")
            If ds.Tables(0).Rows(0).Item("usr_nm") = "A" Then
                txtusrlevel.Text = "Administrator"
            ElseIf ds.Tables(0).Rows(0).Item("usr_nm") = "D" Then
                txtusrlevel.Text = "Director"
            ElseIf ds.Tables(0).Rows(0).Item("usr_nm") = "M" Then
                txtusrlevel.Text = "Manager"
            Else
                txtusrlevel.Text = "Operator"
            End If
            '    Me.assign_disp(dvmaster, "menu_tp='M'")
            '    Me.assign_disp(dvstud, "menu_tp='S'")
            '    Me.assign_disp(dvacnt, "menu_tp='A'")
            '    Me.assign_disp(dvinv, "menu_tp='I'")
            '    Me.assign_disp(dvexam, "menu_tp='E'")
            '    Me.assign_disp(dvlib, "menu_tp='L'")
            '    Me.assign_disp(dvrepo, "menu_tp='R'")
            '    Me.assign_disp(dvutility, "menu_tp='U'")
            '    Me.assign_disp(dvconfig, "menu_tp='C' OR menu_tp='X'")
            'Else
            '    Me.dv_disp(dvmaster, "menu_tp='M'")
            '    Me.dv_disp(dvstud, "menu_tp='S'")
            '    Me.dv_disp(dvacnt, "menu_tp='A'")
            '    Me.dv_disp(dvinv, "menu_tp='I'")
            '    Me.dv_disp(dvexam, "menu_tp='E'")
            '    Me.dv_disp(dvlib, "menu_tp='L'")
            '    Me.dv_disp(dvrepo, "menu_tp='R'")
            '    Me.dv_disp(dvutility, "menu_tp='U'")
            '    Me.dv_disp(dvconfig, "menu_tp='C' OR menu_tp='X'")
        End If
    End Sub

    Private Sub cmbempid_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbempid.Validating
        vdating(cmbempid, "SELECT usr_id FROM usr WHERE usr_id='" & Trim(cmbempid.Text) & "' AND login_block='N' AND usr_tp<>'A' AND usr_tp<>'D'", "Please Select A Valid User ID.")
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        If Trim(cmbempid.Text) = "" Or Val(txtusrsl.Text) = 0 Then
            MessageBox.Show("Please Provide An User ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbempid.Focus()
            Exit Sub
        End If
        'Start1()
        'SQLInsert("DELETE FROM user_assign WHERE user_sl = " & Val(txtusrsl.Text) & "")
        'Close1()
        Me.dv_save(dvmaster)
        Me.dv_save(dvstud)
        Me.dv_save(dvacnt)
        Me.dv_save(dvinv)
        Me.dv_save(dvexam)
        Me.dv_save(dvlib)
        Me.dv_save(dvrepo)
        Me.dv_save(dvutility)
        Me.dv_save(dvconfig)
        MessageBox.Show("User Assignment Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.clr()
    End Sub

    Private Sub dv_save(ByVal dgv As DataGridView)
        If dgv.Rows.Count <> 0 Then
            Dim ds As DataSet = get_dataset("SELECT max(asgn_no) as 'Max' FROM user_assign")
            asgn_no = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    asgn_no = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            For i As Integer = 0 To dgv.Rows.Count - 1
                viewprmsn = dgv.Rows(i).Cells(2).Value
                addprmsn = dgv.Rows(i).Cells(3).Value
                editprmsn = dgv.Rows(i).Cells(4).Value
                delprmsn = dgv.Rows(i).Cells(5).Value
                menusl = dgv.Rows(i).Cells(6).Value
                Start1()
                'SQLInsert("INSERT INTO user_assign (asgn_no,user_sl,menu_sl,add_prm,edit_prm,delete_prm,view_prm) VALUES (" & Val(asgn_no) & "," & _
                '          Val(txtusrsl.Text) & "," & Val(menusl) & "," & Val(addprmsn) & "," & Val(editprmsn) & "," & Val(delprmsn) & "," & Val(viewprmsn) & ")")

                SQLInsert("UPDATE user_assign SET add_prm=" & Val(addprmsn) & ",edit_prm=" & Val(editprmsn) & ",delete_prm=" & _
                          Val(delprmsn) & ",view_prm=" & Val(viewprmsn) & " WHERE user_sl=" & _
                         Val(txtusrsl.Text) & " AND menu_sl=" & Val(menusl) & "")



                Close1()
                asgn_no += 1
            Next
        End If
    End Sub


    Private Sub dv_disp(ByVal dgv As DataGridView, ByVal cndtn As String)
        Start1()
        dgv.Rows.Clear()
        Dim dsedit As DataSet = get_dataset("SELECT menu_sl,menu_nm,view_prmsn,add_prmsn,edit_prmsn,delete_prmsn,menu_lvl FROM menumst WHERE " & cndtn & " AND menu_prmsn<>'N' ORDER BY menu_sl")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                dgv.Rows.Add()
                dgv.Rows(i).Cells(0).Value = i + 1
                dgv.Rows(i).Cells(1).Value = dsedit.Tables(0).Rows(rw).Item("menu_nm")
                dgv.Rows(i).Cells(2).Value = Val(dsedit.Tables(0).Rows(rw).Item("view_prmsn"))
                dgv.Rows(i).Cells(3).Value = Val(dsedit.Tables(0).Rows(rw).Item("add_prmsn"))
                dgv.Rows(i).Cells(4).Value = Val(dsedit.Tables(0).Rows(rw).Item("edit_prmsn"))
                dgv.Rows(i).Cells(5).Value = Val(dsedit.Tables(0).Rows(rw).Item("delete_prmsn"))
                dgv.Rows(i).Cells(6).Value = Val(dsedit.Tables(0).Rows(rw).Item("menu_sl"))
                If Val(dsedit.Tables(0).Rows(rw).Item("menu_lvl")) = 0 Then
                    dgv.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                    dgv.Rows(i).DefaultCellStyle.BackColor = Color.Pink
                End If
                rw = rw + 1
            Next
        End If

    End Sub

    Private Sub assign_disp(ByVal dgv As DataGridView, ByVal cndtn As String)
        Start1()
        dgv.Rows.Clear()
        Dim dsedit As DataSet = get_dataset("SELECT menumst.menu_nm,menumst.menu_lvl, user_assign.* FROM user_assign LEFT OUTER JOIN menumst ON user_assign.menu_sl = menumst.menu_sl WHERE (user_assign.user_sl = " & Val(txtusrsl.Text) & ") AND menumst.menu_prmsn<>'N' AND " & cndtn & " ORDER BY menumst.menu_sl")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                dgv.Rows.Add()
                dgv.Rows(i).Cells(0).Value = i + 1
                dgv.Rows(i).Cells(1).Value = dsedit.Tables(0).Rows(rw).Item("menu_nm")
                dgv.Rows(i).Cells(2).Value = Val(dsedit.Tables(0).Rows(rw).Item("view_prm"))
                dgv.Rows(i).Cells(3).Value = Val(dsedit.Tables(0).Rows(rw).Item("add_prm"))
                dgv.Rows(i).Cells(4).Value = Val(dsedit.Tables(0).Rows(rw).Item("edit_prm"))
                dgv.Rows(i).Cells(5).Value = Val(dsedit.Tables(0).Rows(rw).Item("delete_prm"))
                dgv.Rows(i).Cells(6).Value = Val(dsedit.Tables(0).Rows(rw).Item("menu_sl"))
                If Val(dsedit.Tables(0).Rows(rw).Item("menu_lvl")) = 0 Then
                    dgv.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                    dgv.Rows(i).DefaultCellStyle.BackColor = Color.Pink
                End If
                rw = rw + 1
            Next
        End If

    End Sub

    Private Sub chkview_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkview.CheckedChanged
        'If TabControl1.SelectedTab Is TabPage1 Then
        '    Me.viewcheck(dvmaster)
        'ElseIf TabControl1.SelectedTab Is TabPage2 Then
        '    Me.viewcheck(dvstud)
        'ElseIf TabControl1.SelectedTab Is TabPage3 Then
        '    Me.viewcheck(dvacnt)
        'ElseIf TabControl1.SelectedTab Is TabPage4 Then
        '    Me.viewcheck(dvinv)
        'ElseIf TabControl1.SelectedTab Is TabPage5 Then
        '    Me.viewcheck(dvexam)
        'ElseIf TabControl1.SelectedTab Is TabPage6 Then
        '    Me.viewcheck(dvlib)
        'ElseIf TabControl1.SelectedTab Is TabPage7 Then
        '    Me.viewcheck(dvrepo)
        'ElseIf TabControl1.SelectedTab Is TabPage8 Then
        '    Me.viewcheck(dvconfig)
        'ElseIf TabControl1.SelectedTab Is TabPage9 Then
        '    Me.viewcheck(dvutility)
        'End If
        Me.check_box()
    End Sub

    Private Sub chkadd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkadd.CheckedChanged
        'If TabControl1.SelectedTab Is TabPage1 Then
        '    Me.Addcheck(dvmaster)
        'ElseIf TabControl1.SelectedTab Is TabPage2 Then
        '    Me.Addcheck(dvstud)
        'ElseIf TabControl1.SelectedTab Is TabPage3 Then
        '    Me.Addcheck(dvacnt)
        'ElseIf TabControl1.SelectedTab Is TabPage4 Then
        '    Me.Addcheck(dvinv)
        'ElseIf TabControl1.SelectedTab Is TabPage5 Then
        '    Me.Addcheck(dvexam)
        'ElseIf TabControl1.SelectedTab Is TabPage6 Then
        '    Me.Addcheck(dvlib)
        'ElseIf TabControl1.SelectedTab Is TabPage7 Then
        '    'Me.Addcheck(dvrepo)
        'ElseIf TabControl1.SelectedTab Is TabPage8 Then
        '    'Me.Addcheck(dvconfig)
        'ElseIf TabControl1.SelectedTab Is TabPage9 Then
        '    'Me.Addcheck(dvutility)
        'End If
        Me.check_box()
    End Sub

    Private Sub chkedit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkedit.CheckedChanged
        'If TabControl1.SelectedTab Is TabPage1 Then
        '    Me.editcheck(dvmaster)
        'ElseIf TabControl1.SelectedTab Is TabPage2 Then
        '    Me.editcheck(dvstud)
        'ElseIf TabControl1.SelectedTab Is TabPage3 Then
        '    Me.editcheck(dvacnt)
        'ElseIf TabControl1.SelectedTab Is TabPage4 Then
        '    Me.editcheck(dvinv)
        'ElseIf TabControl1.SelectedTab Is TabPage5 Then
        '    Me.editcheck(dvexam)
        'ElseIf TabControl1.SelectedTab Is TabPage6 Then
        '    Me.editcheck(dvlib)
        'ElseIf TabControl1.SelectedTab Is TabPage7 Then
        '    'Me.editcheck(dvrepo)
        'ElseIf TabControl1.SelectedTab Is TabPage8 Then
        '    Me.editcheck(dvconfig)
        'ElseIf TabControl1.SelectedTab Is TabPage9 Then
        '    Me.editcheck(dvutility)
        'End If
        Me.check_box()
    End Sub

    Private Sub chkdel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdel.CheckedChanged
        'If TabControl1.SelectedTab Is TabPage1 Then
        '    Me.delcheck(dvmaster)
        'ElseIf TabControl1.SelectedTab Is TabPage2 Then
        '    Me.delcheck(dvstud)
        'ElseIf TabControl1.SelectedTab Is TabPage3 Then
        '    Me.delcheck(dvacnt)
        'ElseIf TabControl1.SelectedTab Is TabPage4 Then
        '    Me.delcheck(dvinv)
        'ElseIf TabControl1.SelectedTab Is TabPage5 Then
        '    Me.delcheck(dvexam)
        'ElseIf TabControl1.SelectedTab Is TabPage6 Then
        '    Me.delcheck(dvlib)
        'ElseIf TabControl1.SelectedTab Is TabPage7 Then
        '    'Me.delcheck(dvrepo)
        'ElseIf TabControl1.SelectedTab Is TabPage8 Then
        '    'Me.delcheck(dvconfig)
        'ElseIf TabControl1.SelectedTab Is TabPage9 Then
        '    'Me.delcheck(dvutility)
        'End If
        Me.check_box()
    End Sub

    Private Sub check_box()
        If TabControl1.SelectedTab Is TabPage1 Then
            Me.viewcheck(dvmaster)
            Me.Addcheck(dvmaster)
            Me.editcheck(dvmaster)
            Me.delcheck(dvmaster)
        ElseIf TabControl1.SelectedTab Is TabPage2 Then
            Me.viewcheck(dvstud)
            Me.Addcheck(dvstud)
            Me.editcheck(dvstud)
            Me.delcheck(dvstud)
        ElseIf TabControl1.SelectedTab Is TabPage3 Then
            Me.viewcheck(dvacnt)
            Me.Addcheck(dvacnt)
            Me.editcheck(dvacnt)
            Me.delcheck(dvacnt)
        ElseIf TabControl1.SelectedTab Is TabPage4 Then
            Me.viewcheck(dvinv)
            Me.Addcheck(dvinv)
            Me.editcheck(dvinv)
            Me.delcheck(dvinv)
        ElseIf TabControl1.SelectedTab Is TabPage5 Then
            Me.viewcheck(dvexam)
            Me.Addcheck(dvexam)
            Me.editcheck(dvexam)
            Me.delcheck(dvexam)
        ElseIf TabControl1.SelectedTab Is TabPage6 Then
            Me.viewcheck(dvlib)
            Me.Addcheck(dvlib)
            Me.editcheck(dvlib)
            Me.delcheck(dvlib)
        ElseIf TabControl1.SelectedTab Is TabPage7 Then
            Me.viewcheck(dvrepo)
        ElseIf TabControl1.SelectedTab Is TabPage8 Then
            Me.viewcheck(dvconfig)
            Me.editcheck(dvconfig)
        ElseIf TabControl1.SelectedTab Is TabPage9 Then
            Me.viewcheck(dvutility)
            Me.editcheck(dvutility)
        End If
    End Sub


    Private Sub viewcheck(ByVal dgv As DataGridView)
        If chkview.Checked = True Then
            For i As Integer = 0 To dgv.Rows.Count - 1
                dgv.Rows(i).Cells(2).Value = 1
            Next
        Else
            For i As Integer = 0 To dgv.Rows.Count - 1
                dgv.Rows(i).Cells(2).Value = 0
            Next
        End If
    End Sub

    Private Sub Addcheck(ByVal dgv As DataGridView)
        If chkadd.Checked = True Then
            For i As Integer = 0 To dgv.Rows.Count - 1
                dgv.Rows(i).Cells(3).Value = 1
            Next
        Else
            For i As Integer = 0 To dgv.Rows.Count - 1
                dgv.Rows(i).Cells(3).Value = 0
            Next
        End If
    End Sub

    Private Sub editcheck(ByVal dgv As DataGridView)
        If chkedit.Checked = True Then
            For i As Integer = 0 To dgv.Rows.Count - 1
                dgv.Rows(i).Cells(4).Value = 1
            Next
        Else
            For i As Integer = 0 To dgv.Rows.Count - 1
                dgv.Rows(i).Cells(4).Value = 0
            Next
        End If
    End Sub

    Private Sub delcheck(ByVal dgv As DataGridView)
        If chkdel.Checked = True Then
            For i As Integer = 0 To dgv.Rows.Count - 1
                dgv.Rows(i).Cells(5).Value = 1
            Next
        Else
            For i As Integer = 0 To dgv.Rows.Count - 1
                dgv.Rows(i).Cells(5).Value = 0
            Next
        End If
    End Sub

    'Private Sub dgv_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dvmaster.CellClick
    '    'If e.ColumnIndex = dvmaster.Rows(0).DefaultCellStyle.ForeColor = Color.Blue Then
    '    '    'Do your staff
    '    'End If


    '    'For Each row As  In MDI.MenuStrip1.Items

    '    'Next
    '    CurrentRow = e.RowIndex
    '    CurrentCol = e.ColumnIndex
    '    col = dvmaster.Columns(e.ColumnIndex).Index
    '    rw = dvmaster.Rows(e.RowIndex).Index
    '    x = dvmaster.Rows(0).Cells(col).Value

    '    If rw = 0 Then
    '        For Each oRow As DataGridViewRow In dvmaster.Rows
    '            If oRow.Cells(col).Value = True Then
    '                MessageBox.Show("true")

    '            Else
    '                MessageBox.Show("False")
    '                'do whatever you need to do.
    '            End If
    '        Next
    '    End If
    '    'If rw = 0 Then
    '    '    If dvmaster.Rows(0).Cells(col).Value = 1 Then
    '    '        For i As Integer = 1 To dvmaster.Rows.Count - 1
    '    '            dvmaster.Rows(i).Cells(col).Value = 1
    '    '        Next
    '    '    Else
    '    '        For i As Integer = 1 To dvmaster.Rows.Count - 1
    '    '            dvmaster.Rows(i).Cells(col).Value = 0
    '    '        Next
    '    '    End If
    '    'End If


    'End Sub

    'Private Sub dvmaster_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvmaster.CellContentClick
    '    'dvmaster.CommitEdit(DataGridViewDataErrorContexts.Commit)
    '    CurrentRow = e.RowIndex
    '    CurrentCol = e.ColumnIndex
    '    col = dvmaster.Columns(e.ColumnIndex).Index
    '    rw = dvmaster.Rows(e.RowIndex).Index
    '    x = dvmaster.Rows(0).Cells(col).Value




    '    'For Each gvr As DataGridViewRow In dvmaster.Rows
    '    '    if(((CheckBox)gvr.findcontrol("CheckBox1")).Checked == true)


    '    'Next




    'End Sub

    'Private Sub dvmaster_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvmaster.CellValueChanged
    '    'If dvmaster.Rows(0).Cells(2).Value = 1 Then
    '    '    For i As Integer = 1 To dvmaster.Rows.Count - 1
    '    '        dvmaster.Rows(i).Cells(5).Value = 1
    '    '    Next
    '    'Else
    '    '    For i As Integer = 0 To dvmaster.Rows.Count - 1
    '    '        dvmaster.Rows(i).Cells(5).Value = 0
    '    '    Next
    '    'End If
    '    CurrentCellName = dvmaster.Columns(e.ColumnIndex).Name
    'End Sub

    'Private Sub tabMain_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
    '    Dim g As Graphics
    '    Dim sText As String
    '    Dim iX As Integer
    '    Dim iY As Integer
    '    Dim sizeText As SizeF
    '    Dim ctlTab As TabControl


    '    Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)

    '    ctlTab = CType(sender, TabControl)

    '    g = e.Graphics
    '    sText = ctlTab.TabPages(e.Index).Text
    '    sizeText = g.MeasureString(sText, ctlTab.Font)
    '    iX = e.Bounds.Left + 6
    '    iY = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2

    '    If TabControl1.SelectedIndex = e.Index Then 'Selected
    '        g.FillRectangle(New SolidBrush(Color.Red), e.Bounds)
    '    Else
    '        g.FillRectangle(New SolidBrush(Color.LightBlue), e.Bounds)
    '    End If

    '    g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY)
    'End Sub

    
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'Me.check_box()
    End Sub
End Class
