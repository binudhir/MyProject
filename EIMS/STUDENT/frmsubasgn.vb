Imports vb = Microsoft.VisualBasic
Public Class frmsubasgn
    Dim comd As String = "E"

    Private Sub frmsubasgn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnusubassign.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmsubasgn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmsubasgn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnusubassign.Enabled = False
        usrprmsn("mnusubassign", cmnuadd, cmnuedit, cmenudel, cmenuview)
        comd = swapprmsn("mnusubassign", comd)
        Me.clr()
        'Me.dv_disp()
    End Sub

    Private Sub clr()
        cmbsessn.Text = ""
        cmbacdmyr.Text = ""
        cmbstrm.Text = ""
        dv.Rows.Clear()
        txtstdsl.Text = 0
        If comd = "E" Then
            Me.Text = "Student Subject Assignment.(Entry Screen)"
            chkcnfr.Visible = True
            rdall.Visible = True
            rddall.Visible = True
            rdall.Checked = True
            btnnext.Enabled = True
            btnnext.Enabled = True
            btnsave.Text = "Assign"
            dv.Columns(0).Visible = True
        ElseIf comd = "M" Then
            Me.Text = "Student Subject Assignment.(Modification Screen)"
            chkcnfr.Visible = False
            rdall.Visible = False
            rddall.Visible = False
            rddall.Checked = True
            btnnext.Enabled = True
            btnnext.Enabled = True
            btnsave.Text = "Modify"
            dv.Columns(0).Visible = False
        Else
            Me.Text = "Student Subject Assignment.(Deletion Screen)"
            chkcnfr.Visible = True
            rdall.Visible = True
            rddall.Visible = True
            rddall.Checked = True
            btnnext.Enabled = False
            btnnext.Enabled = False
            btnsave.Text = "Delete"
            dv.Columns(0).Visible = True
        End If
        Me.clr1()
        cmbsessn.Focus()
    End Sub

    Private Sub clr1()
        txtslno.Text = "1"
        cmbsubnm.Text = ""
        cmbtype.SelectedIndex = 0
        dv1.Rows.Clear()
    End Sub


#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsessn.Enter, cmbacdmyr.Enter, cmbstrm.Enter, txtslno.Enter, cmbsubnm.Enter, cmbtype.Enter, cmbsubnm.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsessn.Leave, cmbacdmyr.Leave, cmbstrm.Leave, txtslno.Leave, cmbsubnm.Leave, cmbtype.Leave, cmbsubnm.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnswap.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnswap.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub


#End Region

#Region "Radio Button"

    Private Sub rdall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdall.CheckedChanged
        For i As Integer = 0 To dv.Rows.Count - 1
            dv.Rows(i).Cells(0).Value = 1
        Next
    End Sub

    Private Sub rddall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rddall.CheckedChanged
        For i As Integer = 0 To dv.Rows.Count - 1
            dv.Rows(i).Cells(0).Value = 0
        Next
    End Sub

#End Region

#Region "KeyPress"

    Private Sub cmbsassion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbsessn.KeyPress
        key(cmbacdmyr, e)
        SPKey(e)
    End Sub

    Private Sub cmbsem_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbacdmyr.KeyPress
        key(cmbstrm, e)
        SPKey(e)
    End Sub

    Private Sub cmbstream_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstrm.KeyPress
        key(btnshow, e)
        SPKey(e)
    End Sub

    Private Sub cmbtype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtype.KeyPress
        key(cmbsubnm, e)
    End Sub

    Private Sub cmbsubnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbsubnm.KeyPress
        key(btnnext, e)
        SPKey(e)
    End Sub

#End Region

#Region "Validated/Validating"

    Private Sub cmbsessn_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsessn.Validated
        vdated(txtsesncd, "SELECT sesn_cd FROM sesion1 WHERE sesn_nm='" & Trim(cmbsessn.Text) & "'")
    End Sub

    Private Sub cmbsessn_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbsessn.Validating
        vdating(cmbsessn, "SELECT sesn_nm FROM sesion1 WHERE sesn_nm='" & Trim(cmbsessn.Text) & "' AND rec_lock='N'", "Please Select A Valid Session Name.")
    End Sub

    Private Sub cmbacdmyr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacdmyr.Validated
        vdated(txtacdncd, "SELECT sem_cd FROM semester WHERE sem_nm='" & Trim(cmbacdmyr.Text) & "'")
    End Sub

    Private Sub cmbacdmyr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbacdmyr.Validating
        vdating(cmbacdmyr, "SELECT sem_nm FROM semester WHERE sem_nm='" & Trim(cmbacdmyr.Text) & "' AND rec_lock='N'", "Please Select A Valid Sem/Ac.Year Name.")
    End Sub

    Private Sub cmbstrm_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstrm.Validated
        vdated(txtstrmcd, "SELECT trad_cd FROM trad WHERE trad_nm='" & Trim(cmbstrm.Text) & "'")
    End Sub

    Private Sub cmbstrm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstrm.Validating
        vdating(cmbstrm, "SELECT trad_nm FROM trad WHERE trad_nm='" & Trim(cmbstrm.Text) & "' AND rec_lock='N'", "Please Select A Valid Stream/Trade Name.")
    End Sub

    Private Sub cmbsubnm_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsubnm.Validated
        vdated(txtsubcd, "SELECT sub_cd FROM subject_mst WHERE sub_nm='" & Trim(cmbsubnm.Text) & "'")
    End Sub

    Private Sub cmbsubnm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbsubnm.Validating
        vdating(cmbsubnm, "SELECT sub_nm FROM subject_mst WHERE sub_nm='" & Trim(cmbsubnm.Text) & "' AND rec_lock='N' AND sub_type='" & vb.Left(cmbtype.Text, 1) & "'", "Please Select A Valid Subject Name.")
    End Sub


#End Region

#Region "GotFocus/LostFocus"

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

    Private Sub cmbstrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstrm.GotFocus
        populate(cmbstrm, "SELECT trad_nm FROM trad WHERE rec_lock='N' ORDER BY trad_nm")
    End Sub

    Private Sub cmbstrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstrm.LostFocus
        cmbstrm.Height = 21
    End Sub

    Private Sub cmbsubnm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsubnm.GotFocus
        populate(cmbsubnm, "SELECT sub_nm FROM subject_mst WHERE rec_lock='N' AND sub_type='" & vb.Left(cmbtype.Text, 1) & "' ORDER BY sub_nm")
    End Sub

    Private Sub cmbsubnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsubnm.LostFocus
        cmbsubnm.Height = 21
    End Sub

#End Region

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()

    End Sub

    Private Sub btnnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnext.Click
        If Trim(cmbsubnm.Text) = "" Or Val(txtsubcd.Text) = 0 Then
            MessageBox.Show("Sorry The Subject Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbsubnm.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                x = dv1.Rows(i).Cells(3).Value
                If Val(txtsubcd.Text) = x Then
                    MessageBox.Show("Sorry The Data Should Be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbsubnm.Focus()
                    Exit Sub
                End If
            Next
        End If
        sl1 = Val(txtslno.Text)
        dv1.Rows.Add()
        dv1.Rows(sl1 - 1).Cells(0).Value = sl1
        dv1.Rows(sl1 - 1).Cells(1).Value = cmbtype.Text
        dv1.Rows(sl1 - 1).Cells(2).Value = cmbsubnm.Text
        dv1.Rows(sl1 - 1).Cells(3).Value = txtsubcd.Text
        sl1 += 1
        txtslno.Text = sl1
        cmbsubnm.Text = ""
        cmbsubnm.Focus()
    End Sub

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        clr1()
        Start1()
        Dim ds As DataSet
        If comd = "E" Then
            ds = get_dataset("SELECT stud.stud_nm, stud_hstry.reg_no, stud_hstry.stud_sl,stud_hstry.sem_cd, semester.sem_nm FROM semester RIGHT OUTER JOIN stud_hstry ON semester.sem_cd = stud_hstry.sem_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.trad_cd = " & Val(txtstrmcd.Text) & ") AND (stud_hstry.sesn_cd = " & Val(txtsesncd.Text) & ") AND (stud_hstry.sem_cd = " & Val(txtacdncd.Text) & ") AND (stud_hstry.subj_asgn='N') ORDER BY stud.stud_nm")

            dv.Rows.Clear()
            If ds.Tables(0).Rows.Count <> 0 Then
                Dim rw As Integer = 0
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dv.Rows.Add()
                    dv.Columns(0).Visible = True
                    dv.Rows(rw).Cells(0).Value = 1
                    dv.Rows(rw).Cells(1).Value = i + 1
                    dv.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("reg_no")
                    dv.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("stud_nm")
                    dv.Rows(rw).Cells(4).Value = ds.Tables(0).Rows(i).Item("sem_nm")
                    dv.Rows(rw).Cells(5).Value = ds.Tables(0).Rows(i).Item("stud_sl")
                    dv.Rows(rw).Cells(6).Value = ds.Tables(0).Rows(i).Item("sem_cd")
                    rw = rw + 1
                Next
            End If

        ElseIf comd = "M" Then

            ds = get_dataset("SELECT stud.stud_nm, stud_hstry.reg_no, stud_hstry.stud_sl,stud_hstry.sem_cd, semester.sem_nm FROM semester RIGHT OUTER JOIN stud_hstry ON semester.sem_cd = stud_hstry.sem_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.trad_cd = " & Val(txtstrmcd.Text) & ") AND (stud_hstry.sesn_cd = " & Val(txtsesncd.Text) & ") AND (stud_hstry.sem_cd = " & Val(txtacdncd.Text) & ") AND (stud_hstry.subj_asgn='Y') ORDER BY stud.stud_nm")

            dv.Rows.Clear()
            If ds.Tables(0).Rows.Count <> 0 Then

                Dim rw As Integer = 0
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dv.Rows.Add()
                    dv.Columns(0).Visible = False
                    dv.Rows(rw).Cells(0).Value = 0
                    dv.Rows(rw).Cells(1).Value = i + 1
                    dv.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("reg_no")
                    dv.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("stud_nm")
                    dv.Rows(rw).Cells(4).Value = ds.Tables(0).Rows(i).Item("sem_nm")
                    dv.Rows(rw).Cells(5).Value = ds.Tables(0).Rows(i).Item("stud_sl")
                    dv.Rows(rw).Cells(6).Value = ds.Tables(0).Rows(i).Item("sem_cd")
                    rw = rw + 1
                Next
            End If
        Else
            ds = get_dataset("SELECT stud.stud_nm, stud_hstry.reg_no, stud_hstry.stud_sl,stud_hstry.sem_cd, semester.sem_nm FROM semester RIGHT OUTER JOIN stud_hstry ON semester.sem_cd = stud_hstry.sem_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.trad_cd = " & Val(txtstrmcd.Text) & ") AND (stud_hstry.sesn_cd = " & Val(txtsesncd.Text) & ") AND (stud_hstry.sem_cd = " & Val(txtacdncd.Text) & ") AND (stud_hstry.subj_asgn='Y') ORDER BY stud.stud_nm")

            dv.Rows.Clear()
            If ds.Tables(0).Rows.Count <> 0 Then

                Dim rw As Integer = 0
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dv.Rows.Add()
                    dv.Columns(0).Visible = True
                    dv.Rows(rw).Cells(0).Value = 0
                    dv.Rows(rw).Cells(1).Value = i + 1
                    dv.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("reg_no")
                    dv.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("stud_nm")
                    dv.Rows(rw).Cells(4).Value = ds.Tables(0).Rows(i).Item("sem_nm")
                    dv.Rows(rw).Cells(5).Value = ds.Tables(0).Rows(i).Item("stud_sl")
                    dv.Rows(rw).Cells(6).Value = ds.Tables(0).Rows(i).Item("sem_cd")
                    rw = rw + 1
                Next
            End If
        End If
        Close1()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(cmbsessn.Text) = "" Or Val(txtsesncd.Text) = 0 Then
            MessageBox.Show("Sorry The Session Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbsessn.Focus()
            Exit Sub
        End If
        If Trim(cmbacdmyr.Text) = "" Or Val(txtacdncd.Text) = 0 Then
            MessageBox.Show("Sorry The Academic Year Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbacdmyr.Focus()
            Exit Sub
        End If
        If Trim(cmbstrm.Text) = "" Or Val(txtstrmcd.Text) = 0 Then
            MessageBox.Show("Sorry The Stream Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbstrm.Focus()
            Exit Sub
        End If
        If comd = "E" Then
            chk = 0
            For i As Integer = 0 To dv.Rows.Count - 1
                If dv.Rows(i).Cells(0).Value = 1 Then
                    chk = 1
                End If
            Next
            If chk = 0 Then
                MessageBox.Show("Please Select At Least One Student To Assign The Subjects.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If dv1.Rows.Count = 0 Then
                MessageBox.Show("Please Assign At Least One Subject To The Student.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbsubnm.Focus()
                Exit Sub
            End If
            Start1()
            For i As Integer = 0 To dv.Rows.Count - 1
                If dv.Rows(i).Cells(0).Value = 1 Then
                    regdno = dv.Rows(i).Cells(2).Value
                    stdname = dv.Rows(i).Cells(3).Value
                    txtstdsl.Text = dv.Rows(i).Cells(5).Value
                    txtacdncd.Text = dv.Rows(i).Cells(6).Value
                    If chkcnfr.Checked = True Then
                        cnfr = MessageBox.Show("Are You Sure To Assign Subject To " & stdname & "(" & regdno & ") For This Class.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If cnfr = vbYes Then
                            Me.asign_save()
                        End If
                    Else
                        Me.asign_save()
                    End If
                End If
            Next
            MessageBox.Show("Assign Of Subject Completed Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.clr()
            Close1()
          
        ElseIf comd = "M" Then
            If usr_tp = "O" Then
                MessageBox.Show("You Are Not Authorised to Modify The Record.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
         
            If dv1.Rows.Count = 0 Then
                MessageBox.Show("Please Select At Least One Student/Subject To Modify.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbsubnm.Focus()
                Exit Sub
            End If
            Start1()
            For i As Integer = 0 To dv.Rows.Count - 1
                If dv.Rows(i).Selected = True Then
                    regdno = dv.Rows(i).Cells(2).Value
                    stdname = dv.Rows(i).Cells(3).Value
                    txtstdsl.Text = dv.Rows(i).Cells(5).Value
                    txtacdncd.Text = dv.Rows(i).Cells(6).Value

                    If chkcnfr.Checked = True Then
                        cnfr = MessageBox.Show("Are You Sure To Modify The Assigned Subjects To " & stdname & "(" & regdno & ") For This Class.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If cnfr = vbYes Then
                            Me.asign_save()
                        Else
                            Exit Sub
                        End If
                    Else
                        Me.asign_save()
                    End If
                End If
            Next
            MessageBox.Show("Modification Of Subjects Completed Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.clr()
            Close1()

        Else
            If usr_tp = "O" Then
                MessageBox.Show("You Are Not Authorised to Delete The Record.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            chk = 0
            For i As Integer = 0 To dv.Rows.Count - 1
                If dv.Rows(i).Cells(0).Value = 1 Then
                    chk = 1
                End If
            Next
            If chk = 0 Then
                MessageBox.Show("Please Select At Least One Student To Delete His/Her Assigned Subjects.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            
            Start1()
            For i As Integer = 0 To dv.Rows.Count - 1
                If dv.Rows(i).Cells(0).Value = 1 Then
                    regdno = dv.Rows(i).Cells(2).Value
                    stdname = dv.Rows(i).Cells(3).Value
                    txtstdsl.Text = dv.Rows(i).Cells(5).Value
                    txtacdncd.Text = dv.Rows(i).Cells(6).Value

                    If chkcnfr.Checked = True Then
                        cnfr = MessageBox.Show("Are You Sure To Delete The Assigned Subjects To " & stdname & "[" & regdno & "] For This Class.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If cnfr = vbYes Then
                            Me.del_sub()
                        Else
                            Exit Sub
                        End If
                    Else
                        Me.del_sub()
                    End If
                End If
            Next
            MessageBox.Show("Deletion Of Subjects Completed Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.clr()
            Close1()
        End If
    End Sub

    Private Sub btnswap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnswap.Click
        comd = swapprmsn("mnusubassign", comd)
        'If comd = "E" Then
        '    comd = "M"
        'ElseIf comd = "M" Then
        '    comd = "D"
        'Else
        '    comd = "E"
        'End If
        Me.clr()

    End Sub

#End Region

#Region "Menu"

    Private Sub cmnudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnudel.Click
        For Each row As DataGridViewRow In dv1.SelectedRows
            dv1.Rows.Remove(row)
        Next
        sl = 1
        For i As Integer = 0 To dv1.Rows.Count - 1
            dv1.Rows(i).Cells(0).Value = i + 1
            sl += 1
        Next
        txtslno.Text = sl
    End Sub

    Private Sub cmnuclr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuclr.Click
        dv1.Rows.Clear()
        txtslno.Text = "1"
    End Sub

#End Region

    Private Sub asign_save()
        If dv1.RowCount <> 0 Then
            SQLInsert("DELETE FROM stud_sub_asgn WHERE stud_sl=" & Val(txtstdsl.Text) & "")
            For i As Integer = 0 To dv1.RowCount - 1
                sub_tp = vb.Left(dv1.Rows(i).Cells(1).Value, 1)
                subcd = dv1.Rows(i).Cells(3).Value
                Dim ds1 As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM stud_sub_asgn")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO  stud_sub_asgn (slno,stud_sl,sub_tp,sub_cd,sem_cd) VALUES (" & Val(mxno) & "," & _
                          Val(txtstdsl.Text) & ",'" & sub_tp & "'," & subcd & "," & Val(txtsesncd.Text) & ")")
                SQLInsert("UPDATE stud_hstry SET subj_asgn='Y' WHERE stud_sl=" & Val(txtstdsl.Text) & "")
            Next
        End If
    End Sub

    Private Sub del_sub()
        SQLInsert("DELETE FROM stud_sub_asgn WHERE stud_sl=" & Val(txtstdsl.Text) & "")
        SQLInsert("UPDATE stud_hstry SET subj_asgn='N' WHERE stud_sl=" & Val(txtstdsl.Text) & "")
    End Sub

    Private Sub dv_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dv.CellEnter
        If comd = "M" Then

            For Each row As DataGridViewRow In dv.SelectedRows
                stdsl = dv.Rows(row.Index).Cells(5).Value
                dvsub_show(stdsl)
            Next
        End If
    End Sub

    Private Sub dvsub_show(ByVal stdsl As Integer)

        txtstdsl.Text = stdsl
        ds = get_dataset("SELECT (CASE WHEN stud_sub_asgn.sub_tp = '1' THEN '1.Compulsory' WHEN stud_sub_asgn.sub_tp = '2' THEN '2.Optional' WHEN stud_sub_asgn.sub_tp = '3' THEN '3.Elective' WHEN stud_sub_asgn.sub_tp = '4' THEN '4.Others' END) AS 'Type', subject_mst.sub_nm AS 'Subject', stud_sub_asgn.sub_cd FROM stud_sub_asgn LEFT OUTER JOIN subject_mst ON stud_sub_asgn.sub_cd = subject_mst.sub_cd WHERE (stud_sub_asgn.stud_sl = " & Val(txtstdsl.Text) & ") ORDER BY stud_sub_asgn.sub_tp")
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("type")
                dv1.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("Subject")
                dv1.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("sub_cd")
                rw = rw + 1
            Next
        End If
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.SelectedIndexChanged
        cmbsubnm.Text = ""
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click

    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click

    End Sub
End Class
