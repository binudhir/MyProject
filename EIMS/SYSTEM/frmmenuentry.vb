Imports vb = Microsoft.VisualBasic
Public Class frmmenuentry

    Private Sub frmmenuentry_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmmenuentry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmmenuentry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        txtmnutext.Text = ""
        txtmenunm.Text = ""
        txtgenerate.Text = ""
    End Sub

    Private Sub txtmembr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmnutext.Enter, txtmnusl.Enter, txtmenunm.Enter, cmbtablvl.Enter, cmbmnutp.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.MistyRose
    End Sub

    Private Sub txtmembr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmnutext.Leave, txtmnusl.Leave, txtmenunm.Leave, cmbtablvl.Leave, cmbmnutp.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsend.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter, btnview.MouseEnter, btngen.MouseEnter
        sender.forecolor = Color.Red
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsend.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave, btnview.MouseLeave, btngen.MouseLeave
        sender.forecolor = Color.Black
    End Sub

    Private Sub btngen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngen.Click
        txtgenerate.Text = "INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock) VALUES " & _
        "(" & Trim(txtmnusl.Text) & ",'" & Trim(txtmnutext.Text) & "','" & Trim(txtmenunm.Text) & "'," & IIf(chkmnutp.Checked, 1, 0) & ",0," & Val(vb.Left(cmbtablvl.Text, 2)) & ",'" & vb.Left(cmbmnutp.Text, 1) & "',0,0,0,0,'N')"
        txtmnusl.Text = Val(txtmnusl.Text) + 1
    End Sub

    Private Sub txtmnusl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmnusl.KeyPress
        key(cmbmnutp, e)
        NUM(e)
    End Sub

    Private Sub cmbmnutp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbmnutp.KeyPress
        key(txtmenunm, e)
        SPKey(e)
    End Sub

    Private Sub txtmenunm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmenunm.KeyPress
        key(txtmnutext, e)
        SPKey(e)
    End Sub

    Private Sub txtmnutext_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmnutext.KeyPress
        key(cmbtablvl, e)
        SPKey(e)
    End Sub

    Private Sub cmbtablvl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtablvl.KeyPress
        key(btngen, e)
        SPKey(e)
    End Sub
End Class
