Imports vb = Microsoft.VisualBasic
Public Class frmmailus

    Private Sub frmmailus_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmmailus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmmailus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
    End Sub

    Private Sub frmmailus_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        txtsub.Text = ""
        txtbody.Text = ""
        txtattach.Text = ""
        txtsub.Focus()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.dv_disp()
    End Sub

    Private Sub cmdview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.dv_disp()
    End Sub

    Private Sub txtmembr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbody.Enter, txtsub.Enter, txtattach.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.MistyRose

    End Sub

    Private Sub txtmembr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbody.Leave, txtsub.Leave, txtattach.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

        sender.text = UCase(sender.text)
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsend.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter, btnview.MouseEnter
        sender.forecolor = Color.Red
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsend.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave, btnview.MouseLeave
        sender.forecolor = Color.Black
    End Sub

    Private Sub txtcustnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsub.KeyPress
        key(txtbody, e)
        SPKey(e)
    End Sub

    Private Sub txtbody_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbody.KeyPress
        'key(btnsend, e)
        'SPKey(e)
    End Sub

    Private Sub txtattach_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtattach.KeyPress
        key(btnsend, e)
        SPKey(e)
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsend.Click
        If Trim(txtbody.Text) = "" Then
            MessageBox.Show("Sorry...The Body Field Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtbody.Focus()
            Exit Sub
        End If
        subject = Trim(txtsub.Text) & " EIMS"
        body = Trim(txtbody.Text) & vbCrLf & "With Regards " & vbCrLf & conm
        attch = Trim(txtattach.Text)
        If attch <> "" Then
            Sending_email(subject, "binu.dhir@gmail.com", body, New String() {attch})
        Else
            Sending_email(subject, "binu.dhir@gmail.com", body)
        End If
    End Sub

    Private Sub dv_disp()
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT complain.*, usr.usr_id FROM complain LEFT OUTER JOIN usr ON complain.usr_sl = usr.usr_sl ORDER BY complain.slno")
        dv.Rows.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                dv.Rows.Add()
                dv.Rows(i).Cells(0).Value = dsedit.Tables(0).Rows(rw).Item("slno")
                dv.Rows(i).Cells(1).Value = dsedit.Tables(0).Rows(rw).Item("subj")
                dv.Rows(i).Cells(2).Value = dsedit.Tables(0).Rows(rw).Item("body")
                dv.Rows(i).Cells(3).Value = Format(dsedit.Tables(0).Rows(rw).Item("send_dt"), "dd/MM/yy hh:mm:ss ttt")
                If dsedit.Tables(0).Rows(rw).Item("attach") = "Y" Then
                    dv.Rows(i).Cells(4).Value = "Yes"
                Else
                    dv.Rows(i).Cells(4).Value = "No"
                End If
                If dsedit.Tables(0).Rows(rw).Item("send") = "Y" Then
                    dv.Rows(i).Cells(5).Value = "Yes"
                Else
                    dv.Rows(i).Cells(5).Value = "No"
                End If
                dv.Rows(i).Cells(6).Value = dsedit.Tables(0).Rows(rw).Item("usr_id")
                dv.Rows(i).Cells(7).Value = dsedit.Tables(0).Rows(rw).Item("slno")
                rw = rw + 1
            Next
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub lnkbrowse_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkbrowse.LinkClicked
        If DialogResult.OK = OpenFileDialog1.ShowDialog() Then
            result = OpenFileDialog1.FileName
            txtattach.Text = result
        End If
    End Sub

    Private Sub cmdview_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Me.dv_disp()
    End Sub

    Private Sub dv_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dv.DoubleClick
        dv.Visible = False
        txtsub.Focus()
    End Sub

    Private Sub lnkclr_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkclr.LinkClicked
        txtattach.Text = ""
    End Sub
End Class
