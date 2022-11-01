Imports vb = Microsoft.VisualBasic
Public Class rep_godntransfer
    Dim comd As String

    Private Sub rep_godntransfer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_godntransfer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_godntransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        fromdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        todt.Value = fromdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        Me.Text = "Inter Godown Transfer Register . . ."
        hddr = Me.Text
        txtordcd.Text = 0
        txtgodncd.Text = 0
        txtprocd.Text = 0
        cmborder.SelectedIndex = 0
        cmbgodn.Text = ""
        cmbproduct.Text = ""
        cmborder.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False
    End Sub
#Region "Enter/Leave"
    Private Sub cmbreport_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbproduct.Enter, cmborder.Enter, cmbgodn.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmbreport_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbproduct.Leave, cmborder.Leave, cmbgodn.Leave

        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnview_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnrfresh.MouseEnter, btnexport.MouseEnter, btnexit.MouseEnter, btncalc.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnview_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnrfresh.MouseLeave, btnexport.MouseLeave, btnexit.MouseLeave, btncalc.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "keypress"

    Private Sub fromdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fromdt.KeyPress
        key(todt, e)
    End Sub

    Private Sub todt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles todt.KeyPress
        key(cmbgodn, e)
    End Sub

    Private Sub cmbgodn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgodn.KeyPress
        key(chkgodn, e)
        SPKey(e)
    End Sub

    Private Sub chkgodn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkgodn.KeyPress
        key(cmbproduct, e)
    End Sub

    Private Sub cmbproduct_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbproduct.KeyPress
        key(chkprod, e)
        SPKey(e)
    End Sub

    Private Sub chkprod_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkprod.KeyPress
        key(cmborder, e)
    End Sub

    Private Sub cmborder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmborder.KeyPress
        key(btnview, e)
        SPKey(e)
    End Sub
#End Region

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btncalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncalc.Click
        System.Diagnostics.Process.Start("calc.exe")
    End Sub

    Private Sub btnrfresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrfresh.Click
        Me.clr()
    End Sub

    Private Sub btnexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexport.Click
        Call excel_view(dv)
    End Sub
#End Region

#Region "ComboBox"

    Private Sub cmbproduct_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.GotFocus
        txtprocd.Text = 0
        populate(cmbproduct, "SELECT it_name FROM item WHERE (rec_lock = 'N') ORDER BY it_name")
    End Sub

    Private Sub cmbproduct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.LostFocus
        cmbproduct.Height = 21
    End Sub

    Private Sub cmbproduct_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbproduct.Validated
        vdated(txtprocd, "SELECT it_cd FROM item WHERE (it_name = '" & Trim(cmbproduct.Text) & "')")
    End Sub

    Private Sub cmbproduct_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbproduct.Validating
        vdating(cmbproduct, "SELECT it_name FROM item WHERE (it_name = '" & Trim(cmbproduct.Text) & "')", "Please Select a Valid Product Name.")
    End Sub

    Private Sub cmbgodn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodn.GotFocus
        txtgodncd.Text = 0
        populate(cmbgodn, "SELECT godnm FROM godown WHERE (rec_lock = 'N') ORDER BY godnm")
    End Sub

    Private Sub cmbgodn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodn.LostFocus
        cmbgodn.Height = 21
    End Sub

    Private Sub cmbgodn_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbgodn.Validated
        vdated(txtgodncd, "SELECT godsl FROM godown WHERE (godnm = '" & Trim(cmbgodn.Text) & "')")
    End Sub

    Private Sub cmbgodn_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgodn.Validating
        vdating(cmbgodn, "SELECT godnm FROM godown WHERE (godnm = '" & Trim(cmbgodn.Text) & "')", "Please Select a Godown Name.")
    End Sub
#End Region

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        lblmsg.Visible = False
        dv.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        conditn = ""
        If chkgodn.Checked = False Then
            conditn = " AND (godown.godsl=" & Val(txtgodncd.Text) & ")"
        End If
        If chkprod.Checked = False Then
            conditn = conditn & "AND (item.it_cd=" & Val(txtprocd.Text) & ")"
        End If
        orderby = "ig1.ig_dt"
        If cmborder.SelectedIndex = 1 Then
            orderby = " godown.godnm"
        End If
        If cmborder.SelectedIndex = 2 Then
            orderby = "item.it_name"
        End If
        ds = get_dataset("SELECT  ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', STR(ig2.ig_sl,10,0) AS 'IG No. ', CONVERT(varchar,ig1.ig_dt,103) AS 'Date', ig1.ig_ref AS 'Ref No.', CONVERT(varchar,ig2.ref_dt,103) AS 'Ref Date',godown.godnm AS 'From Godown', item.it_name AS 'Product Name', (SELECT godnm FROM godown AS godown_2 WHERE (godsl = ig1.gdsl_to)) AS 'To Godown' FROM  item RIGHT OUTER JOIN  ig2 RIGHT OUTER JOIN ig1 ON ig2.ig_sl = ig1.ig_sl LEFT OUTER JOIN godown ON ig1.gdsl_frm = godown.godsl ON item.it_cd = ig2.it_cd WHERE (ig1.ig_dt>='" & Format(fromdt.Value, "dd/MMM/yyyy") & "') AND (ig1.ig_dt<='" & Format(todt.Value, "dd/MMM/yyyy") & "')  " & conditn & " ORDER BY " & orderby & "")
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            slno = 0
            For i As Integer = 0 To dv.Rows.Count - 1
                If slno = Val(dv.Rows(i).Cells(1).Value) Then
                    dv.Rows(i).Cells(1).Value = ""
                    dv.Rows(i).Cells(2).Value = ""
                    dv.Rows(i).Cells(3).Value = ""
                    dv.Rows(i).Cells(4).Value = ""
                    dv.Rows(i).Cells(5).Value = ""
                    dv.Rows(i).Cells(7).Value = ""
                Else
                    slno = Val(dv.Rows(i).Cells(1).Value)
                End If
            Next
            GroupBox3.Text = "Inter Godown Transfer from " & fromdt.Value & " To " & todt.Value
            hddr = GroupBox3.Text
        Else
            lblmsg.Visible = True
        End If
        Close1()
    End Sub

    Private Sub chkgodn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkgodn.CheckedChanged
        If chkgodn.Checked = True Then
            cmbgodn.Text = "<<< GODOWN >>>"
            cmbgodn.Enabled = False
            txtgodncd.Text = 0
        Else
            cmbgodn.Text = ""
            cmbgodn.Enabled = True
            cmbgodn.Focus()
        End If
    End Sub

    Private Sub chkprod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkprod.CheckedChanged
        If chkprod.Checked = True Then
            cmbproduct.Text = "<<< All Products >>>"
            cmbproduct.Enabled = False
            txtprocd.Text = 0
        Else
            cmbproduct.Text = ""
            cmbproduct.Enabled = True
            cmbproduct.Focus()
        End If
    End Sub
End Class
