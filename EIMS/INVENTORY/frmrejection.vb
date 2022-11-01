Imports vb = Microsoft.VisualBasic
Public Class frmrejection
    Dim comd As String

    Private Sub frmrejection_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmrejection_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub
    Private Sub frmrejection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
    End Sub

    Private Sub frmrejection_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        txtscroll.Text = ""
        txtref.Text = ""
        txtslno.Text = ""
        txtquantity.Text = ""
        txtrate.Text = ""
        txtamount.Text = ""
        txtunit.Text = ""
        txtnb.Text = ""
        txtitcd.Text = ""
        lblstk.Text = ""
        lbltotal.Text = ""
        cmbreject.SelectedIndex = ""
        cmbgodown.SelectedIndex = ""
        cmbproduct.Text = ""
        If comd = "E" Then
            Me.Text = "Material Rejection Entry Screen...."
            Dim ds As DataSet = get_dataset("SELECT max(po_no) as 'Max' FROM porder1")
            txtscroll.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
        ElseIf comd = "M" Then
            Me.Text = "Material Rejection Modification Screen...."
            txtscroll.Text = ""
        Else
            Me.Text = "Material Rejection Deletion Screen...."
            txtscroll.Text = ""
        End If
    End Sub
#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtscroll.Enter, txtref.Enter, dtissue.Enter, cmbreject.Enter, cmbgodown.Enter, cmbproduct.Enter, txtrate.Enter, txtquantity.Enter, txtnb.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtscroll.Leave, txtref.Leave, dtissue.Leave, cmbreject.Leave, cmbgodown.Leave, cmbproduct.Leave, txtrate.Leave, txtquantity.Leave, txtnb.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub
    Private Sub btnnext_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnref.MouseEnter, btnnext.MouseEnter, btnswap.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnnext_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnref.MouseLeave, btnnext.MouseLeave, btnswap.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "Got/LostFocus"

    Private Sub txtrate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.GotFocus
        If Val(txtrate.Text) = 0 Then
            txtrate.Text = ""
        End If
    End Sub

    Private Sub txtrate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.LostFocus
        txtrate.Text = Format(Val(txtrate.Text), "########0.00")

    End Sub

    Private Sub cmbproduct_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.GotFocus
        cmbproduct.Height = 100
        populate(cmbproduct, "SELECT it_name FROM item WHERE (rec_lock = 'N') ORDER BY it_name")
    End Sub

    Private Sub cmbproduct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.LostFocus
        cmbproduct.Height = 21
    End Sub

    Private Sub cmbgodown_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodown.GotFocus
        cmbgodown.Height = 100
        populate(cmbgodown, "SELECT godnm FROM godown WHERE rec_lock='N' ORDER BY godnm")
    End Sub

    Private Sub cmbgodown_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodown.LostFocus
        cmbgodown.Height = 21
    End Sub
    Private Sub cmbreject_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbreject.GotFocus
        cmbreject.Height = 100
        populate(cmbreject, "SELECT staf_nm FROM staf WHERE rec_lock='N' ORDER BY staf_nm")
    End Sub

    Private Sub cmbreject_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbreject.LostFocus
        cmbreject.Height = 21
    End Sub
#End Region

#Region "Combo Validate"

    Private Sub cmbproduct_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.Validated
        Dim ds As DataSet = get_dataset("SELECT item.it_cd,item.pur_rate,item.unt1,item.cl_stk FROM item  WHERE item.it_name='" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtitcd.Text = Format(ds.Tables(0).Rows(0).Item("it_cd"))
            txtunit.Text = Trim(ds.Tables(0).Rows(0).Item("unt1"))
            txtrate.Text = Format(ds.Tables(0).Rows(0).Item("pur_rate"), "#######0.00")
            lblstk.Text = Format(ds.Tables(0).Rows(0).Item("cl_stk"))
        End If
    End Sub

    Private Sub cmbproduct_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbproduct.Validating
        vdating(cmbproduct, "SELECT it_name FROM item WHERE it_name='" & Trim(cmbproduct.Text) & "' AND rec_lock = 'N'", "Please Select a Valid Product Name.")
    End Sub

    Private Sub cmbgodown_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodown.Validated
        vdated(txtgodcd, "SELECT godsl FROM godown WHERE godnm  ='" & Trim(cmbgodown.Text) & "'")
    End Sub

    Private Sub cmbgodown_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgodown.Validating
        vdating(cmbgodown, "SELECT godnm FROM godown WHERE godnm  ='" & Trim(cmbgodown.Text) & "' AND rec_lock='N'", "Please Select A Valid Godown Name.")
    End Sub

    Private Sub cmbreject_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbreject.Validated
        vdated(txtrejcd, "SELECT staf_sl FROM staf WHERE staf_nm ='" & Trim(cmbreject.Text) & "'")
    End Sub

    Private Sub cmbreject_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbreject.Validating
        vdating(cmbreject, "SELECT staf_nm FROM staf WHERE staf_nm ='" & Trim(cmbreject.Text) & "' AND rec_lock='N'", "Please Select A Valid Staff Name.")
    End Sub
   
#End Region

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "&Save"
    End Sub

#Region "KeyPress"

    Private Sub txtscroll_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtscroll.KeyPress
        key(dtissue, e)
        NUM(e)
    End Sub

    Private Sub dtissue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtissue.KeyPress
        key(txtref, e)
        SPKey(e)
    End Sub

    Private Sub txtref_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtref.KeyPress
        key(cmbreject, e)
        SPKey(e)
    End Sub

    Private Sub cmbreject_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbreject.KeyPress
        key(cmbgodown, e)
        NUM(e)
    End Sub

    Private Sub cmbgodown_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgodown.KeyPress
        key(cmbproduct, e)
        SPKey(e)
    End Sub

    Private Sub cmbproduct_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbproduct.KeyPress
        key(txtquantity, e)
        NUM1(e)
    End Sub

    Private Sub txtquantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtquantity.KeyPress
        key(txtrate, e)
        NUM1(e)
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        key(btnnext, e)
        NUM1(e)
    End Sub

    Private Sub txtnb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnb.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub
#End Region

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Me.dv_disp()
    End Sub

    Private Sub btnswap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnswap.Click
        If comd = "E" Then
            comd = "M"
        ElseIf comd = "M" Then
            comd = "D"
        Else
            comd = "E"
        End If
        Me.clr()
    End Sub

    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT rej2.scrl_sl, rej2.scrl_no, rej2.scrl_dt, item.it_name, godown.godnm, rej2.rej_qty, rej2.unt FROM rej2 LEFT OUTER JOIN godown ON rej2.godsl = godown.godsl LEFT OUTER JOIN item ON rej2.it_cd = item.it_cd")
        dv1.Rows.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                dv.Rows.Add()
                dv.Rows(i).Cells(0).Value = dsedit.Tables(0).Rows(rw).Item("scrl_sl")
                dv.Rows(i).Cells(1).Value = dsedit.Tables(0).Rows(rw).Item("scrl_no")
                dv.Rows(i).Cells(2).Value = Format(dsedit.Tables(0).Rows(rw).Item("scrl_dt"), "dd/MM/yyyy")
                dv.Rows(i).Cells(3).Value = dsedit.Tables(0).Rows(rw).Item("it_name")
                dv.Rows(i).Cells(4).Value = dsedit.Tables(0).Rows(rw).Item("godnm")
                dv.Rows(i).Cells(5).Value = Format(dsedit.Tables(0).Rows(rw).Item("rej_qty"), "######0")
                dv.Rows(i).Cells(6).Value = dsedit.Tables(0).Rows(rw).Item("unt")

                dv.Rows(i).Cells(5).Value = Format(dsedit.Tables(0).Rows(rw).Item("deliver_dt"), "dd/MM/yyyy")
                'dv.Rows(i).Cells(6).Value = Format(dsedit.Tables(0).Rows(rw).Item("gr_tot"), "######0.00")
                If dsedit.Tables(0).Rows(rw).Item("rec_lock") = "Y" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
                rw = rw + 1
            Next
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub


    Private Sub mnuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexpert.Click
        Call excel_view(dv)
    End Sub
End Class
