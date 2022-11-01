Imports vb = Microsoft.VisualBasic
Public Class frmstrmchang
    Dim comd As String

    Private Sub frmstrmchang_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmstrmchang_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmstrmchang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
    End Sub

    Private Sub frmstrmchang_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Student Trade / Stream Change . . ."
        txtstudregd.Text = ""
        txtstudname.Text = ""
        txttrade.Text = ""
        txtsession.Text = ""
        txtsemister.Text = ""
        txtnew.Text = ""
        cmbnew.Text = ""
        txtslno.Text = ""
        txtsemcd.Text = ""
        txtsescd.Text = ""
        txtstudcd.Text = ""
        txttradcd.Text = ""
        txtoldtrad.Text = ""
        txthstcd.Text = ""
        txtstudregd.Focus()
    End Sub

#Region "Enter / Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtstudregd.Enter, txtstudname.Enter, txttrade.Enter, txtsession.Enter, txtsemister.Enter, txtnew.Enter, cmbnew.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtstudregd.Leave, txtstudname.Leave, txttrade.Leave, txtsession.Leave, txtsemister.Leave, txtnew.Leave, cmbnew.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.MouseEnter, btnsave.MouseEnter, btnexit.MouseEnter, btnserch.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.MouseLeave, btnsave.MouseLeave, btnexit.MouseLeave, btnserch.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtstudregd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstudregd.KeyPress
        key(txtnew, e)
        SPKey(e)
    End Sub

    Private Sub txtnew_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnew.KeyPress
        key(cmbnew, e)
        SPKey(e)
    End Sub

    Private Sub cmbnew_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbnew.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub

#End Region
    
#Region "Button"

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
    End Sub

    Private Sub btnexit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtstudregd.Text = "" Then
            MessageBox.Show("Please Enter A Student's Registration No.")
            Exit Sub
        End If
        If txtstudregd.Text = "" Then
            MessageBox.Show("Please Enter A New Registration No. For This Student")
            Exit Sub
        End If
        If Val(txtoldtrad.Text) = Val(txttradcd.Text) Then
            MessageBox.Show("Sorry The Trade / Stream Name Should Not Be Same.")
            Exit Sub
        End If

        Me.strm_save()

    End Sub

    Private Sub btnserch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnserch.Click
        frmstudsearch.Show()
    End Sub
#End Region

    Private Sub cmbnew_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbnew.GotFocus
        cmbnew.Height = 100
        populate(cmbnew, "SELECT trad_nm FROM trad ORDER BY trad_nm")
    End Sub

    Private Sub cmbnew_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbnew.LostFocus
        cmbnew.Height = 21
    End Sub

    Private Sub txtstudregd_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtstudregd.Validating
        vdating(txtstudregd, "SELECT reg_no FROM stud_hstry WHERE (active = 'Y') AND reg_no='" & Trim(txtstudregd.Text) & "' ", "Please Enter A Valid Registration No.")
    End Sub

    Private Sub txtstudregd_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtstudregd.Validated
        Dim ds As DataSet = get_dataset("SELECT stud_hstry.stud_hstry_sl, stud_hstry.stud_sl, stud.stud_nm, sesion1.sesn_nm, semester.sem_nm, trad.trad_nm, stud_hstry.trad_cd, stud_hstry.sesn_cd, stud_hstry.sem_cd FROM stud_hstry LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE(stud_hstry.active = 'Y') AND (stud_hstry.reg_no =  '" & Trim(txtstudregd.Text) & "') ")

        If ds.Tables(0).Rows.Count <> 0 Then
            txtstudname.Text = Trim(ds.Tables(0).Rows(0).Item("stud_nm"))
            txtsession.Text = Trim(ds.Tables(0).Rows(0).Item("sesn_nm"))
            txttrade.Text = Trim(ds.Tables(0).Rows(0).Item("trad_nm"))
            txtsemister.Text = Trim(ds.Tables(0).Rows(0).Item("sem_nm"))
            txtstudcd.Text = ds.Tables(0).Rows(0).Item("stud_sl")
            txtoldtrad.Text = ds.Tables(0).Rows(0).Item("trad_cd")
            txtsemcd.Text = ds.Tables(0).Rows(0).Item("sem_cd")
            txtsescd.Text = ds.Tables(0).Rows(0).Item("sesn_cd")
        End If
    End Sub

    Private Sub cmbnew_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbnew.Validating
        vdating(cmbnew, "SELECT trad_nm FROM trad WHERE trad_nm='" & Trim(cmbnew.Text) & "'", "Please Select A Valid Trade / Stream Name.")
    End Sub

    Private Sub cmbnew_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbnew.Validated
        vdated(txttradcd, "SELECT trad_cd FROM trad WHERE trad_nm='" & Trim(cmbnew.Text) & "'")
    End Sub

    Private Sub txtnew_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnew.Validated
        If Trim(txtnew.Text) <> "" Then
            Dim ds As DataSet = get_dataset("SELECT reg_no FROM stud WHERE reg_no='" & Trim(txtnew.Text) & "' ")
            If ds.Tables(0).Rows.Count <> 0 Then
                MessageBox.Show("Please Enter A Different Registration No." & vbCrLf & " This No. Is Already Assigned To A Student.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtnew.Focus()
                Exit Sub
            End If

        End If
    End Sub

    Private Sub strm_save()
        cnfr = MessageBox.Show("Are You Sure To Save The Record", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM trad_chng")
                txtslno.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtslno.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                Dim ds1 As DataSet = get_dataset("SELECT max(stud_hstry_sl) as 'Max' FROM stud_hstry")
                txthstcd.Text = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        txthstcd.Text = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO trad_chng(slno,trans_dt,stud_sl,old_trad_cd,new_trad_cd,old_reg_no,new_reg_no) VALUES (" & Val(txtslno.Text) & ",'" & _
                           Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(txtstudcd.Text) & "," & Val(txtoldtrad.Text) & "," & Val(txttradcd.Text) & ",'" & _
                           Trim(txtstudregd.Text) & "','" & Trim(txtnew.Text) & "')")

                SQLInsert("UPDATE stud_hstry SET active='N' WHERE stud_sl=" & Val(txtstudcd.Text) & " AND active='Y'")

                SQLInsert("INSERT INTO stud_hstry(stud_hstry_sl,stud_sl,sesn_cd,sem_cd,trad_cd,reg_no,trans_dt,active,trans_tp,usr_ent,subj_asgn)VALUES (" & _
                           Val(txthstcd.Text) & "," & Val(txtstudcd.Text) & "," & Val(txtsescd.Text) & "," & Val(txtsemcd.Text) & "," & Val(txttradcd.Text) & _
                           ",'" & Trim(txtnew.Text) & "','" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','Y','T'," & Val(usr_sl) & ",'N')")

                SQLInsert("UPDATE stud SET reg_no='" & Trim(txtnew.Text) & "' WHERE stud_sl=" & Val(txtstudcd.Text) & " ")

                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Close1()
            End If
        End If
    End Sub

    
End Class
