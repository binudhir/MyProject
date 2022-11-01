Imports vb = Microsoft.VisualBasic
Public Class frmpartymanfct
    Dim comd As String

    Private Sub frmpartymanfct_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmpartymanfct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmpartymanfct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
        Me.dv_disp()
    End Sub
    Private Sub clr()
        Me.Text = "Company Wise Discount Master. . . ."
        cmbparty.Text = ""
        txtbiling.Text = ""
        txtcontperson.Text = ""
        txtaddres.Text = ""
        txtsl.Text = ""
        txtpartycd.Text = ""
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(prt_code) as 'Max' FROM party")
        txtpartycd.Text = "1"
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtpartycd.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        cmbparty.Focus()
    End Sub

    Private Sub clr1()
        txtcompcd.Text = ""
        cmbcompany.Text = ""
        txtcomp.Text = "0.00"
        txttrade.Text = "0.00"
    End Sub

    Private Sub cmbparty_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrade.Enter, txtsl.Enter, txtcontperson.Enter, txtcomp.Enter, txtbiling.Enter, txtaddres.Enter, cmbcompany.Enter, cmbparty.Enter, cmblock.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub cmbparty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrade.Leave, txtsl.Leave, txtcontperson.Leave, txtcomp.Leave, txtbiling.Leave, txtaddres.Leave, cmbcompany.Leave, cmbparty.Leave, cmblock.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnnext_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseEnter, btnref.MouseEnter, btnnext.MouseEnter, btnexit.MouseEnter, btnedit.MouseEnter, btndelete.MouseEnter, btnadd.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnnext_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseLeave, btnref.MouseLeave, btnnext.MouseLeave, btnexit.MouseLeave, btnedit.MouseLeave, btndelete.MouseLeave, btnadd.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(cmbcompany, e)
        SPKey(e)
    End Sub

    Private Sub cmbcompany_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcompany.KeyPress
        key(txtcomp, e)
        SPKey(e)
    End Sub

    Private Sub txtcomp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcomp.KeyPress
        key(txttrade, e)
        NUM1(e)
    End Sub

    Private Sub txttrade_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttrade.KeyPress
        key(btnnext, e)
        NUM1(e)
    End Sub

    Private Sub btnnext_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnnext.KeyPress
        key(cmblock, e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Add"
    End Sub

    Private Sub cmbparty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.GotFocus
        cmbparty.Height = 100
        populate(cmbparty, "SELECT pname FROM party WHERE rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbparty_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbparty.Validated
        Dim ds As DataSet = get_dataset("select prt_code,bname,add1,per_cont from party where pname = '" & Trim(cmbparty.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtpartycd.Text = ds.Tables(0).Rows(0).Item("prt_code")
            txtbiling.Text = ds.Tables(0).Rows(0).Item("bname")
            txtaddres.Text = ds.Tables(0).Rows(0).Item("add1")
            txtcontperson.Text = ds.Tables(0).Rows(0).Item("per_cont")
        End If
    End Sub

    Private Sub cmbparty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbparty.Validating
        vdating(cmbparty, " SELECT pname FROM party WHERE pname='" & Trim(cmbparty.Text) & "'", "Please Select A Valid Party Name.")
    End Sub

    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.LostFocus
        cmbparty.Height = 21
    End Sub

    Private Sub cmbcompany_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcompany.GotFocus
        cmbcompany.Height = 100
        populate(cmbcompany, "SELECT manf_nm FROM manf WHERE rec_lock='N' ORDER BY manf_nm")
    End Sub

    Private Sub cmbcompany_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcompany.LostFocus
        cmbcompany.Height = 21
    End Sub

    Private Sub cmbcompany_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcompany.Validated
        vdated(txtcompcd, " SELECT manf_cd FROM manf WHERE manf_nm='" & Trim(cmbcompany.Text) & "'")
    End Sub

    Private Sub cmbcompany_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcompany.Validating
        vdating(cmbcompany, " SELECT manf_nm FROM manf WHERE manf_nm='" & Trim(cmbcompany.Text) & "'", "Please Select A Valid Company Name.")
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(cmbparty.Text) = "" Or Val(txtpartycd.Text) = 0 Then
            MessageBox.Show("The Party Name Should not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbparty.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count = 0 Then
            MessageBox.Show("Please Assign Discount To At Least One Company", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbparty.Focus()
            Exit Sub
        End If
        Me.party_save()
    End Sub

    Private Sub party_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                'Me.dv_save()
                Close1()
            End If
        Else
        End If
    End Sub
    Private Sub dv_disp()
    End Sub


    Private Sub btnnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnext.Click
        If Trim(cmbparty.Text) = "" Then
            MessageBox.Show("Sorry The Party Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbparty.Focus()
            Exit Sub
        End If
        If Trim(cmbcompany.Text) = "" Then
            MessageBox.Show("Sorry The Company Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbcompany.Focus()
            Exit Sub
        End If
        If Val(txtcomp.Text) = "0.00" Or Val(txtcomp.Text) = "0.00" Then
            MessageBox.Show("Please Enter Discount Ammount", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtcomp.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                x = dv1.Rows(i).Cells(1).Value
                If Trim(cmbcompany.Text) = x Then
                    MessageBox.Show("Sorry The Data Should Not Be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbcompany.Focus()
                    Exit Sub
                End If
            Next
        End If
        sl = Val(txtsl.Text)
        dv1.Rows.Add()
        dv1.Rows(sl - 1).Cells(0).Value = sl
        dv1.Rows(sl - 1).Cells(1).Value = cmbcompany.Text
        dv1.Rows(sl - 1).Cells(2).Value = txtcomp.Text
        dv1.Rows(sl - 1).Cells(3).Value = txttrade.Text
        dv1.Rows(sl - 1).Cells(4).Value = txtcompcd.Text
        sl += 1
        txtsl.Text = sl
        cmbcompany.Focus()
        Me.clr1()
    End Sub
End Class
