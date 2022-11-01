Imports vb = Microsoft.VisualBasic
Public Class rep_partylist
    Dim comd As String

    Private Sub rep_partylist_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_partylist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_partylist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
    End Sub

    Private Sub clr()
        Me.Text = "Party Detail List . . ."
        hddr = Me.Text
        txtmarkcd.Text = 0
        txtpartycd.Text = 0
        txtprttp.Text = 0
        cmbprttp.Text = ""
        cmbmarket.Text = ""
        cmbparty.Text = ""
        cmborder.SelectedIndex = 0
        cmbparty.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False

    End Sub

#Region "Enter/Leave"
    Private Sub cmbregist_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprttp.Enter, cmbmarket.Enter, cmbparty.Enter, cmborder.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmbregist_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprttp.Leave, cmbmarket.Leave, cmbparty.Leave, cmborder.Leave

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

#Region "combobox"

    Private Sub cmbparty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.GotFocus
        txtpartycd.Text = 0
        populate(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.LostFocus
        cmbparty.Height = 21
    End Sub

    Private Sub cmbparty_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbparty.Validated
        Dim ds As DataSet = get_dataset("SELECT prt_code,add1 FROM party WHERE pname='" & Trim(cmbparty.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtpartycd.Text = ds.Tables(0).Rows(0).Item("prt_code")
        End If
    End Sub

    Private Sub cmbparty_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbparty.Validating
        vdating(cmbparty, "SELECT pname FROM party WHERE prt_type='A' AND rec_lock='N' AND pname='" & Trim(cmbparty.Text) & "'", "Please Select A Valid Party Head Of A/c Name.")
    End Sub


    Private Sub cmbprttp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprttp.GotFocus
        populate(cmbprttp, "SELECT pt_name FROM prttype ORDER BY prt_type")
    End Sub

    Private Sub cmbprttp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprttp.LostFocus
        cmbprttp.Height = 21
    End Sub

    Private Sub cmbprttp_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprttp.Validated
        vdated(txtprttp, "SELECT prt_type FROM prttype WHERE pt_name='" & Trim(cmbprttp.Text) & "'")
    End Sub

    Private Sub cmbprttp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbprttp.Validating
        vdating(cmbprttp, "SELECT pt_name FROM prttype WHERE pt_name='" & Trim(cmbprttp.Text) & "'", "Please Select A Valid Party Account Type.")
    End Sub

    Private Sub cmbmarket_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmarket.GotFocus
        cmbmarket.Height = 100
        populate(cmbmarket, "SELECT ma_nm FROM market ORDER BY ma_nm")
    End Sub

    Private Sub cmbmarket_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmarket.LostFocus
        cmbmarket.Height = 21
    End Sub
    Private Sub cmbmarket_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmarket.Validated
        vdated(txtmarkcd, "SELECT ma_cd FROM market WHERE ma_nm='" & Trim(cmbmarket.Text) & "'")
    End Sub

    Private Sub cmbmarket_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmarket.Validating
        vdating(cmbmarket, "SELECT ma_nm FROM market WHERE ma_nm='" & Trim(cmbmarket.Text) & "'", "Please Select A Market Name.")
    End Sub
#End Region

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

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        lblmsg.Visible = False
        dv.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        conditn = "WHERE"
        If chktype.Checked = False Then
            conditn = conditn & " (prttype.prt_type='" & Trim(txtprttp.Text) & "') AND"
        End If
        If chkmark.Checked = False Then
            conditn = conditn & " (market.ma_cd=" & Val(txtmarkcd.Text) & ") AND"
        End If
        If chkparty.Checked = False Then
            conditn = conditn & " (party.prt_code=" & Val(txtpartycd.Text) & ")"
        End If
        If conditn = "WHERE" Then
            conditn = ""
        End If
        If vb.Right(conditn, 3) = "AND" Then
            conditn = vb.Left(conditn, Len(conditn) - 3)
        End If
        orderby = "party.pname"
        ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', party.pname AS 'Party Name', party.add1 AS 'Address', market.ma_nm AS 'Market Name', prttype.pt_name AS 'Category', STR(party.op_bal,10,2) AS 'Opening Balance', STR(party.cl_amt,10,2) AS 'Closing Balance' FROM party LEFT OUTER JOIN prttype ON party.prt_type = prttype.prt_type LEFT OUTER JOIN market ON party.ma_cd = market.ma_cd  " & conditn & " ORDER BY " & orderby & "")

        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            GroupBox3.Text = "Party Head Of A/C Detail List . . . "
            hddr = GroupBox3.Text
        Else
            lblmsg.Visible = True
        End If
        Close1()
    End Sub

#Region "checkBox"

    Private Sub chkmark_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkmark.CheckedChanged
        If chkmark.Checked = True Then
            cmbmarket.Text = "<<< All Market >>>"
            cmbmarket.Enabled = False
            txtmarkcd.Text = 0
        Else
            cmbmarket.Text = ""
            cmbmarket.Enabled = True
            cmbmarket.Focus()
        End If
    End Sub

    Private Sub chkparty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkparty.CheckedChanged
        If chkparty.Checked = True Then
            cmbparty.Text = "<<< All Party >>>"
            cmbparty.Enabled = False
            txtpartycd.Text = 0
        Else
            cmbparty.Text = ""
            cmbparty.Enabled = True
            cmbparty.Focus()
        End If
    End Sub

    Private Sub chktype_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktype.CheckedChanged
        If chktype.Checked = True Then
            cmbprttp.Text = "<<< All Party Type   >>>"
            cmbprttp.Enabled = False
            txtprttp.Text = ""
        Else
            cmbprttp.Text = ""
            cmbprttp.Enabled = True
            cmbprttp.Focus()
        End If
    End Sub

#End Region

#Region "keypress"

    Private Sub cmbprttp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbprttp.KeyPress
        key(cmbmarket, e)
        SPKey(e)
    End Sub

    Private Sub cmbmarket_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbmarket.KeyPress
        key(cmbparty, e)
        SPKey(e)
    End Sub

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(cmborder, e)
        SPKey(e)
    End Sub

    Private Sub cmborder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmborder.KeyPress
        key(btnview, e)
        SPKey(e)
    End Sub

#End Region


End Class
