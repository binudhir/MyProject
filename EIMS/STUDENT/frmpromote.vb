Imports vb = Microsoft.VisualBasic
Public Class frmpromote
    Dim comd As String

    Private Sub frmpromote_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuStudPromot.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmpromote_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmpromote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
        If txttype.Text = "P" Then
            Me.Text = "Student Promotion Screen . . ."
            btnsave.Text = "Promote"
            txtcause.Text = ""
            txtcause.Visible = False
            lblcause.Visible = False
            lblnew.Visible = True
            cmbnew.Visible = True
            Me.clr1()
        ElseIf txttype.Text = "O" Then
            Me.Text = "Student Passout Screen . . ."
            txtcause.Text = "Pass Out"
            txtcause.Enabled = False
            txtcause.Visible = True
            lblcause.Visible = True
            lblnew.Visible = False
            cmbnew.Visible = False
            txtcause.Left = cmbnew.Left
            txtcause.Top = cmbnew.Top
            btnsave.Text = "Pass"
            MDI.mnuStudPromot.Enabled = False
            Me.clr1()
        ElseIf txttype.Text = "L" Then
            Me.Text = "Student Leave Screen . . ."
            txtcause.Text = ""
            txtcause.Enabled = True
            txtcause.Visible = True
            lblcause.Visible = True
            lblnew.Visible = False
            cmbnew.Visible = False
            txtcause.Left = cmbnew.Left
            txtcause.Top = cmbnew.Top
            btnsave.Text = "Leave"
            Me.clr1()
        End If
    End Sub

    Private Sub frmpromote_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        cmbsession.Text = ""
        cmbcurr.Text = ""
        txtsemcd.Text = ""
        txtsempos.Text = ""
        txtsesncd.Text = ""
        cmbsession.Focus()
        dttr.Text = sys_date
        'cmbtype.SelectedIndex = 0
        chkpay.Checked = False
        Me.clr1()
    End Sub

    Private Sub clr1()
        cmbnew.Text = ""
        txtnewcd.Text = ""
        chkall.Checked = True
        chksel.Checked = True
        chkpay.Checked = False
        chklibrary.Checked = False
        chkpenalty.Checked = False
        chkcnfr.Checked = False
        dv.Rows.Clear()
    End Sub

    Private Sub rddall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To dv.Rows.Count - 1
            dv.Rows(i).Cells(0).Value = 0
        Next
    End Sub

    Private Sub rdall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To dv.Rows.Count - 1
            dv.Rows(i).Cells(0).Value = 1
        Next
    End Sub


#Region "KeyPress"

    Private Sub cmbsession_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbsession.KeyPress
        key(cmbcurr, e)
        SPKey(e)
    End Sub

    Private Sub cmbcurr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcurr.KeyPress
        key(btnshow, e)
        SPKey(e)
    End Sub

    Private Sub cmbnew_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbnew.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub

#End Region

#Region "GotFocus / LostFocus"

    Private Sub cmbsession_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsession.GotFocus
        populate(cmbsession, "SELECT sesn_nm FROM sesion1 WHERE (rec_lock = 'N')")
        cmbsession.Height = 100
    End Sub

    Private Sub cmbsession_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsession.LostFocus
        cmbsession.Height = 21
    End Sub

    Private Sub cmbcurr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcurr.GotFocus
        populate(cmbcurr, "SELECT semester.sem_nm FROM sesion2 LEFT OUTER JOIN semester ON sesion2.sem_cd = semester.sem_cd WHERE (sesion2.sesn_cd = " & Val(txtsesncd.Text) & ") AND (semester.rec_lock = 'N') ORDER BY semester.sem_pos")
        cmbcurr.Height = 100
    End Sub

    Private Sub cmbcurr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcurr.LostFocus
        cmbcurr.Height = 21
    End Sub

    Private Sub cmbnew_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbnew.GotFocus
        populate(cmbnew, "SELECT semester.sem_nm FROM sesion2 LEFT OUTER JOIN semester ON sesion2.sem_cd = semester.sem_cd WHERE (sesion2.sesn_cd = " & Val(txtsesncd.Text) & ") AND (semester.rec_lock = 'N') AND (semester.sem_pos >" & Val(txtsempos.Text) & ") ORDER BY semester.sem_pos")
        cmbnew.Height = 100

    End Sub

    Private Sub cmbnew_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbnew.LostFocus
        cmbnew.Height = 21
    End Sub

    Private Sub cmbtrad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrad.GotFocus
        populate(cmbtrad, "SELECT trad_nm FROM trad WHERE (rec_lock = 'N') ORDER BY trad_nm")
        cmbtrad.Height = 100
    End Sub

    Private Sub cmbtrad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrad.LostFocus
        cmbtrad.Height = 21
    End Sub

#End Region

#Region "Enter / Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsession.Enter, cmbcurr.Enter, cmbnew.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsession.Leave, cmbcurr.Leave, cmbnew.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

#End Region

#Region "Validating / Validated"

    Private Sub cmbsession_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbsession.Validating
        vdating(cmbsession, "SELECT sesn_nm FROM sesion1 WHERE sesn_nm='" & Trim(cmbsession.Text) & "'", "Please Select A Valid Session Name.")
    End Sub

    Private Sub cmbsession_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsession.Validated
        vdated(txtsesncd, "SELECT sesn_cd FROM sesion1 WHERE sesn_nm='" & Trim(cmbsession.Text) & "'")
    End Sub

    Private Sub cmbcurr_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcurr.Validating
        vdating(cmbcurr, "SELECT sem_nm FROM semester WHERE sem_nm='" & Trim(cmbcurr.Text) & "'", "Please Select A Valid Class Name.")
    End Sub

    Private Sub cmbcurr_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcurr.Validated
        Dim ds As DataSet = get_dataset("SELECT sem_cd,sem_pos FROM semester WHERE sem_nm='" & Trim(cmbcurr.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtsemcd.Text = ds.Tables(0).Rows(0).Item("sem_cd")
            txtsempos.Text = ds.Tables(0).Rows(0).Item("sem_pos")
        End If
    End Sub

    Private Sub cmbnew_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbnew.Validating
        vdating(cmbnew, "SELECT sem_nm FROM semester WHERE sem_nm='" & Trim(cmbnew.Text) & "'", "Please Select A Valid New Class Name.")
    End Sub

    Private Sub cmbnew_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbnew.Validated
        vdated(txtnewcd, "SELECT sem_cd FROM semester WHERE sem_nm='" & Trim(cmbnew.Text) & "'")
    End Sub


    Private Sub cmbtrad_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrad.Validated
        vdated(txttradcd, "SELECT trad_cd FROM trad WHERE trad_nm='" & Trim(cmbtrad.Text) & "'")
    End Sub

    Private Sub cmbtrad_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrad.Validating
        vdating(cmbtrad, "SELECT trad_nm FROM trad WHERE trad_nm='" & Trim(cmbtrad.Text) & "'", "Please Select A Valid New Class Name.")
    End Sub

#End Region

#Region "Checked"
    'Private Sub cmbtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.SelectedIndexChanged
    '    If cmbtype.SelectedIndex = 0 Then
    '        btnsave.Text = "Promote"
    '        txtcause.Text = ""
    '        txtcause.Visible = False
    '        lblcause.Visible = False
    '        lblnew.Visible = True
    '        cmbnew.Visible = True
    '        Me.clr1()
    '    ElseIf cmbtype.SelectedIndex = 1 Then
    '        txtcause.Text = "Pass Out"
    '        txtcause.Enabled = False
    '        txtcause.Visible = True
    '        lblcause.Visible = True
    '        lblnew.Visible = False
    '        cmbnew.Visible = False
    '        txtcause.Left = cmbnew.Left
    '        txtcause.Top = cmbnew.Top
    '        btnsave.Text = "Leave"
    '        Me.clr1()
    '    ElseIf cmbtype.SelectedIndex = 2 Then
    '        txtcause.Text = ""
    '        txtcause.Enabled = True
    '        txtcause.Visible = True
    '        lblcause.Visible = True
    '        lblnew.Visible = False
    '        cmbnew.Visible = False
    '        txtcause.Left = cmbnew.Left
    '        txtcause.Top = cmbnew.Top
    '        btnsave.Text = "Pass"
    '        Me.clr1()
    '    End If
    'End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        If chkall.Checked = True Then
            cmbtrad.Enabled = False
            cmbtrad.Text = "<<All Branch>>"
            txttradcd.Text = "0"
        Else
            cmbtrad.Enabled = True
            cmbtrad.Text = ""
            txttradcd.Text = ""
        End If
    End Sub

    Private Sub chksel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksel.CheckedChanged
        If chksel.Checked = True Then
            For i As Integer = 0 To dv.Rows.Count - 1
                dv.Rows(i).Cells(0).Value = 1
            Next
        Else
            For i As Integer = 0 To dv.Rows.Count - 1
                dv.Rows(i).Cells(0).Value = 0
            Next
        End If
    End Sub
#End Region

#Region "Button"
    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        clr1()
        Start1()
        Dim ds As DataSet
        If chkall.Checked = True Then
            ds = get_dataset("SELECT stud_hstry.reg_no, stud.stud_nm, stud_hstry.stud_sl FROM stud_hstry LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (sesn_cd=" & Val(txtsesncd.Text) & ") AND (sem_cd=" & Val(txtsemcd.Text) & ") ORDER BY stud_hstry.reg_no ")
        Else
            ds = get_dataset("SELECT stud_hstry.reg_no, stud.stud_nm, stud_hstry.stud_sl FROM stud_hstry LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (sesn_cd=" & Val(txtsesncd.Text) & ") AND (sem_cd=" & Val(txtsemcd.Text) & ")AND (trad_cd=" & Val(txttradcd.Text) & ") ORDER BY stud_hstry.reg_no ")

        End If
       
        dv.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv.Rows.Add()
                dv.Rows(rw).Cells(0).Value = 1
                dv.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("reg_no")
                dv.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("stud_nm")
                dv.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("stud_sl")
                rw = rw + 1
            Next
        Else
            MessageBox.Show("Sorry There Is No Student For This Session / Class.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.clr()
        End If
        Close1()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(cmbsession.Text) = "" Or Val(txtsesncd.Text) = 0 Then
            MessageBox.Show("Sorry The Session Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbsession.Focus()
            Exit Sub
        End If
        If Trim(cmbcurr.Text) = "" Or Val(txtsemcd.Text) = 0 Then
            MessageBox.Show("Sorry The Currnt Class Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbcurr.Focus()
            Exit Sub
        End If
        If txttype.Text = "P" Then

            If Trim(cmbnew.Text) = "" Or Val(txtnewcd.Text) = 0 Then
                MessageBox.Show("Sorry The New Class Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbnew.Focus()
                Exit Sub
            End If
        ElseIf txttype.Text = "L" Then
            If Trim(txtcause.Text) = "" Then
                MessageBox.Show("Please Enter A Valid Cause To Leave.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtcause.Focus()
                Exit Sub
            End If

        End If
        If chkpay.Checked <> True Then
            MessageBox.Show("Please Verify Payment Is Cleared.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            chkpay.Focus()
            Exit Sub
        End If
        If chklibrary.Checked <> True Then
            MessageBox.Show("Please Verify Library Books Are Returned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            chklibrary.Focus()
            Exit Sub
        End If
        If chkpenalty.Checked <> True Then
            MessageBox.Show("Please Verify Penalty Is Cleared.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            chkpenalty.Focus()
            Exit Sub
        End If
        chk = 0
        For i As Integer = 0 To dv.Rows.Count - 1
            If dv.Rows(i).Cells(0).Value = 1 Then
                chk = 1
            End If
        Next
        If chk = 0 Then
            MessageBox.Show("Please Select At Least One Student To Promote.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Me.tr_save()

    End Sub
#End Region

    Private Sub tr_save()
        Start1()
        If txttype.Text = "P" Then
            For i As Integer = 0 To dv.Rows.Count - 1
                If dv.Rows(i).Cells(0).Value = 1 Then
                    regdno = dv.Rows(i).Cells(1).Value
                    stdname = dv.Rows(i).Cells(2).Value
                    stdsl = dv.Rows(i).Cells(3).Value
                    If chkcnfr.Checked = True Then
                        cnfr = MessageBox.Show("Are You Sure To Promote The Student:" & stdname & "(" & regdno & ").", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If cnfr = vbYes Then
                            SQLInsert("UPDATE stud_hstry SET active='N',sem_cd=" & Val(txtnewcd.Text) & ",trans_dt='" & Format(dttr.Value, "dd/MMM/yyyy HH:mm:ss") & "',trans_tp='P' WHERE stud_sl=" & stdsl & " AND active='Y'")


                            Dim ds1 As DataSet = get_dataset("SELECT max(stud_hstry_sl) as 'Max' FROM stud_hstry")
                            mxno = 1
                            If ds1.Tables(0).Rows.Count <> 0 Then
                                If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                                    mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                                End If
                            End If
                            SQLInsert("INSERT INTO stud_hstry(stud_hstry_sl,stud_sl,sesn_cd,sem_cd,trad_cd,reg_no,trans_dt,active,trans_tp,usr_ent,subj_asgn)VALUES (" & _
                                       Val(mxno) & "," & Val(stdsl) & "," & Val(txtsesncd.Text) & "," & Val(txtsemcd.Text) & "," & Val(txttradcd.Text) & _
                                       ",'" & Trim(regdno) & "','" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','Y','P'," & Val(usr_sl) & ",'N')")
                        End If
                    Else
                        SQLInsert("UPDATE stud_hstry SET active='N',sem_cd=" & Val(txtnewcd.Text) & ",trans_dt='" & Format(dttr.Value, "dd/MMM/yyyy HH:mm:ss") & "',trans_tp='P' WHERE stud_sl=" & stdsl & " AND active='Y'")

                        Dim ds1 As DataSet = get_dataset("SELECT max(stud_hstry_sl) as 'Max' FROM stud_hstry")
                        mxno = 1
                        If ds1.Tables(0).Rows.Count <> 0 Then
                            If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                                mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                            End If
                        End If
                        SQLInsert("INSERT INTO stud_hstry(stud_hstry_sl,stud_sl,sesn_cd,sem_cd,trad_cd,reg_no,trans_dt,active,trans_tp,usr_ent,subj_asgn)VALUES (" & _
                                   Val(mxno) & "," & Val(stdsl) & "," & Val(txtsesncd.Text) & "," & Val(txtsemcd.Text) & "," & Val(txttradcd.Text) & _
                                   ",'" & Trim(regdno) & "','" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','Y','P'," & Val(usr_sl) & ",'N')")
                    End If
                End If
            Next
            MessageBox.Show("The Student Are Promoted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.clr()
        ElseIf txttype.Text = "O" Then
            For i As Integer = 0 To dv.Rows.Count - 1
                If dv.Rows(i).Cells(0).Value = 1 Then
                    regdno = dv.Rows(i).Cells(1).Value
                    stdname = dv.Rows(i).Cells(2).Value
                    stdsl = dv.Rows(i).Cells(3).Value
                    If chkcnfr.Checked = True Then
                        cnfr = MessageBox.Show("Are You Sure To PassOut The Student :" & stdname & "(" & regdno & ").", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If cnfr = vbYes Then
                            SQLInsert("UPDATE stud SET leaved='Y',cause_leave='" & Trim(txtcause.Text) & "' WHERE stud_sl=" & stdsl & "")
                            SQLInsert("UPDATE stud_hstry SET active='N',trans_dt='" & Format(dttr.Value, "dd/MMM/yyyy HH:mm:ss") & "',trans_tp='O' WHERE stud_sl=" & stdsl & "")
                        End If
                    Else
                        SQLInsert("UPDATE stud SET leaved='Y',cause_leave='" & Trim(txtcause.Text) & "'WHERE stud_sl=" & stdsl & "")
                        SQLInsert("UPDATE stud_hstry SET active='N', trans_dt='" & Format(dttr.Value, "dd/MMM/yyyy HH:mm:ss") & "',trans_tp='O' WHERE stud_sl=" & stdsl & "")
                    End If
                End If
            Next
            MessageBox.Show("The Students Are Passed Out Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.clr()

        Else
            For i As Integer = 0 To dv.Rows.Count - 1
                If dv.Rows(i).Cells(0).Value = 1 Then
                    regdno = dv.Rows(i).Cells(1).Value
                    stdname = dv.Rows(i).Cells(2).Value
                    stdsl = dv.Rows(i).Cells(3).Value
                    If chkcnfr.Checked = True Then
                        cnfr = MessageBox.Show("Are You Sure To Leave The Student :" & stdname & "(" & regdno & ").", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If cnfr = vbYes Then
                            SQLInsert("UPDATE stud SET leaved='Y',cause_leave='" & Trim(txtcause.Text) & "' WHERE stud_sl=" & stdsl & "")
                            SQLInsert("UPDATE stud_hstry SET active='N',trans_dt='" & Format(dttr.Value, "dd/MMM/yyyy HH:mm:ss") & "',trans_tp='L' WHERE stud_sl=" & stdsl & "")
                        End If
                    Else
                        SQLInsert("UPDATE stud SET leaved='Y',cause_leave='" & Trim(txtcause.Text) & "'WHERE stud_sl=" & stdsl & "")
                        SQLInsert("UPDATE stud_hstry SET active='N', trans_dt='" & Format(dttr.Value, "dd/MMM/yyyy HH:mm:ss") & "',trans_tp='L' WHERE stud_sl=" & stdsl & "")
                    End If
                End If
            Next
            MessageBox.Show("The Students Are Leaved Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.clr()
        End If
       
        Close1()
    End Sub
   

   
End Class
