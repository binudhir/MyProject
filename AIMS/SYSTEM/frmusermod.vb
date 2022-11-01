Imports vb = Microsoft.VisualBasic
Public Class frmusermod
    Dim comd As String

    Private Sub frmusermod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmusermod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
    End Sub

    Private Sub frmusermod_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "User Modification Screen . . ."
        dv_edit(usr_sl)
    End Sub

    Private Sub txtmembr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtusrnm.Enter, txtusrid.Enter, txtcont2.Enter, txtcont1.Enter, txtadd2.Enter, txtadd1.Enter, txtmailid.Enter, txtoldpswd.Enter, txtnewpswd.Enter, txtcnfrpwd.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub txtmembr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtusrnm.Leave, txtusrid.Leave, txtcont2.Leave, txtcont1.Leave, txtadd2.Leave, txtadd1.Leave, txtmailid.Leave, txtoldpswd.Leave, txtnewpswd.Leave, txtcnfrpwd.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub txtcont1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont1.KeyPress
        key(txtcont2, e)
        NUM(e)
    End Sub

    Private Sub txtsrtnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtusrnm.KeyPress
        key(txtadd1, e)
        SPKey(e)
    End Sub

    Private Sub txtadd1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd1.KeyPress
        key(txtadd2, e)
        SPKey(e)
    End Sub

    Private Sub txtadd2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd2.KeyPress
        key(txtcont1, e)
        SPKey(e)
    End Sub

    Private Sub txtcont2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont2.KeyPress
        key(txtmailid, e)
        NUM(e)
    End Sub

    Private Sub txtmailid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmailid.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub

    Private Sub txtmailid_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmailid.Validating
        If Trim(txtmailid.Text) <> "" Then
            If txtmailid.Text.IndexOf("@") = -1 OrElse txtmailid.Text.IndexOf(".") = -1 Then
                e.Cancel = True
                MessageBox.Show("You Have Enter An Invalid Mail ID.Please Enter A Valid Email ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtmailid.Focus()
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Modify"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtnewpswd.Text) = "" Then
            MessageBox.Show("Sorry The New Password Field Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtnewpswd.Focus()
            Exit Sub
        End If
        If Trim(txtoldpswd.Text) = Trim(txtcnfrpwd.Text) Then
            MessageBox.Show("Sorry The Old Password Should Not Be Equal To The New Password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtcnfrpwd.Focus()
            Exit Sub
        End If
        If Trim(txtcnfrpwd.Text) = "" Then
            MessageBox.Show("Sorry The Password Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtnewpswd.Focus()
            Exit Sub
        End If
        Me.user_save()
    End Sub

    Private Sub user_save()
        cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Start1()
        If cnfr = vbYes Then
            Dim ds As DataSet = get_dataset("SELECT usr_sl FROM usr WHERE usr_sl=" & Val(txtscrl.Text) & "")
            If ds.Tables(0).Rows.Count <> 0 Then
                SQLInsert("UPDATE usr SET usr_pwd='" & Trim(txtnewpswd.Text) & "',usr_nm='" & _
                          Trim(txtusrnm.Text) & "',usr_add1='" & Trim(txtadd1.Text) & "',usr_add2='" & Trim(txtadd2.Text) & "',usr_ph1='" & _
                          Trim(txtcont1.Text) & "',usr_ph2='" & Trim(txtcont2.Text) & "',usr_mail='" & Trim(txtmailid.Text) & "',frst_login='Y' WHERE usr_sl =" & Val(txtscrl.Text) & "")
                MessageBox.Show("User Modified Successfully.The Change Will Be Effect On Your Next Login.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
            End If
            Close1()
            End
        End If
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Dim dsedit As DataSet = get_dataset("SELECT * FROM usr WHERE usr_sl=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtusrid.Text = dsedit.Tables(0).Rows(0).Item("usr_id")
            txtusrnm.Text = dsedit.Tables(0).Rows(0).Item("usr_nm")
            'txtoldpswd.Text = dsedit.Tables(0).Rows(0).Item("usr_pwd")
            txtadd1.Text = dsedit.Tables(0).Rows(0).Item("usr_add1")
            txtadd2.Text = dsedit.Tables(0).Rows(0).Item("usr_add2")
            txtcont1.Text = dsedit.Tables(0).Rows(0).Item("usr_ph1")
            txtcont2.Text = dsedit.Tables(0).Rows(0).Item("usr_ph2")
            txtmailid.Text = dsedit.Tables(0).Rows(0).Item("usr_mail")
        End If
    End Sub

    Private Sub txtoldpswd_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtoldpswd.Validating
        If Trim(txtoldpswd.Text) <> "" Then
            Dim dsedit As DataSet = get_dataset("SELECT usr_pwd FROM usr WHERE usr_sl=" & Val(txtscrl.Text) & "")
            If dsedit.Tables(0).Rows.Count <> 0 Then
                If Trim(txtoldpswd.Text) <> Trim(dsedit.Tables(0).Rows(0).Item("usr_pwd")) Then
                    MessageBox.Show("Please Provide A Valid Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtoldpswd.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtoldpswd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtoldpswd.KeyPress
        key(txtnewpswd, e)
        SPKey(e)
    End Sub

    Private Sub txtnewpswd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnewpswd.KeyPress
        key(txtcnfrpwd, e)
        SPKey(e)
    End Sub

    Private Sub txtcnfrpwd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcnfrpwd.KeyPress
        key(txtusrnm, e)
        SPKey(e)
    End Sub

    Private Sub txtcnfrpwd_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcnfrpwd.Validating
        If Trim(txtcnfrpwd.Text) <> "" Then
            If Trim(txtcnfrpwd.Text) <> Trim(txtnewpswd.Text) Then
                MessageBox.Show("Sorry The Password Are Not Match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtcnfrpwd.Focus()
            End If
        End If
    End Sub
End Class
