Imports System.IO

Public Class frmlogin
    Dim seconds As Integer = 0, minutes As Integer = 0, hours As Integer = 0, lapCount As Integer = 0

    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        If Trim(txtunm.Text) <> "" Then
            If Trim(txtpswd.Text) <> "" Then
                'start1()
                Dim ds As DataSet = get_dataset("SELECT * FROM usr WHERE usr_id='" & Trim(txtunm.Text) & "'")
                If ds.Tables(0).Rows.Count <> 0 Then
                    If ds.Tables(0).Rows(0).Item("login_block") = "N" Then
                        If Trim(txtpswd.Text) = ds.Tables(0).Rows(0).Item("usr_pwd") Then
                            usr_nm = ds.Tables(0).Rows(0).Item("usr_id")
                            usr_sl = ds.Tables(0).Rows(0).Item("usr_sl")
                            usr_tp = ds.Tables(0).Rows(0).Item("usr_tp")
                            If ds.Tables(0).Rows(0).Item("frst_login") = "N" Then
                                MessageBox.Show("Please Change The Default Password Before Login", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                frmusermod.MdiParent = MDI
                                frmusermod.Show()
                            End If
                            logn = "Y"
                            MDI.lblusrnm.Text = usr_nm
                            MDI.Timer1.Enabled = True
                            MDI.Timer2.Enabled = True
                            'If Chkrem.Checked = True Then
                            '    Me.log_remember()
                            'End If
                            Me.Close()
                        Else
                            MessageBox.Show("Please Provide A Valid Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtpswd.Focus()
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Sorry The User Is Blocked", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtpswd.Focus()
                        Exit Sub
                    End If

                Else
                    MessageBox.Show("Please Provide A Valid User Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtunm.Focus()
                    Exit Sub
                End If
                'close1()
            Else
                MessageBox.Show("Please Provide A Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtpswd.Focus()
                Exit Sub
            End If
        Else
            MessageBox.Show("Please Provide A User Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtunm.Focus()
            Exit Sub
        End If
        If logn = "Y" Then
            Call verupdt()
            Call comp_check()
            'loginfo
            Call menu_enable()
            Call uprmenu_visible()
            Call global_settings()
            MDI.btnlogin.Text = "Logout"
            'MDI.mnu_student.DropDownItems(1).Visible = False
        End If
    End Sub

    Private Sub btncncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncncl.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.Transparent
        If System.IO.File.Exists("D:\password.txt") = True Then
            txtunm.Text = "ADMIN"
            txtpswd.Text = "ADMIN"
        End If
        txtunm.Focus()
        'If System.IO.File.Exists(My.Application.Info.DirectoryPath & "\login.dll") = True Then
        '    Chkrem.Checked = True
        '    Dim TextLine As String
        '    Dim objReader As New System.IO.StreamReader(My.Application.Info.DirectoryPath & "\login.dll")
        '    rw = 0
        '    Do While objReader.Peek() <> -1
        '        TextLine = objReader.ReadLine() & vbNewLine
        '        asd = TextLine.Split(",")
        '        txtunm.Text = Trim(asd(1))
        '        txtpswd.Text = Trim(asd(0))
        '    Loop
        '    btnlogin.Focus()
        'End If

    End Sub

    Private Sub txtunm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtunm.KeyPress
        key(txtpswd, e)
        SPKey(e)
    End Sub

    Private Sub txtpswd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpswd.KeyPress
        key(btnlogin, e)
        SPKey(e)
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpswd.Enter, txtunm.Enter
        'sender.forecolor = Color.Blue
        'sender.backcolor = Color.LightGoldenrodYellow
        sender.Font = New System.Drawing.Font("Verdana", 10, FontStyle.Bold)
    End Sub

    Private Sub sender_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpswd.Leave, txtunm.Leave
        'sender.BackColor = Color.White
        ' sender.ForeColor = Color.Black
        sender.Font = New System.Drawing.Font("Verdana", 10, FontStyle.Regular)
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.MouseEnter, btncncl.MouseEnter
        sender.ForeColor = Color.Blue
    End Sub

    Private Sub Cancel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlogin.MouseLeave, btncncl.MouseLeave
        sender.ForeColor = Color.Black
    End Sub

    Private Sub log_remember()
        If System.IO.File.Exists(My.Application.Info.DirectoryPath & "\login.dll") = False Then
            File.Create(My.Application.Info.DirectoryPath & "\login.dll").Dispose()
        End If
        Dim objWriter As New System.IO.StreamWriter(My.Application.Info.DirectoryPath & "\login.dll")
        objWriter.Write("")
        objWriter.WriteLine(txtpswd.Text & "," & txtunm.Text)
        objWriter.Close()
    End Sub

    Private Sub lblset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblset.Click
        frmdbset.MdiParent = MDI
        frmdbset.Show()
        Me.Close()
    End Sub

    Private Sub lblint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblint.Click
        frmmailus.MdiParent = MDI
        frmmailus.Show()
        Me.Close()
    End Sub
End Class
