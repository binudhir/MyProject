Imports vb = Microsoft.VisualBasic
Public Class frmmarket
    Dim comd As String

    Private Sub frmmarket_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnumrkt.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmmarket_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmmarket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnumrkt.Enabled = False
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmmarket_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Market Master. . . ."
        txtscrl.Text = ""
        txtmarket.Text = ""
        cmbroute.Text = ""
        txtroutecd.Text = ""
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(ma_cd) as 'Max' FROM market")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtmarket.Focus()
    End Sub

#Region "Enter/Leave"

    Private Sub txtmarket_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmarket.Enter, cmbroute.Enter, cmblock.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub txtmarket_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmarket.Leave, cmbroute.Leave, cmblock.Leave
        sender.text = UCase(sender.text)
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtmarket_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmarket.KeyPress
        key(cmbroute, e)
        SPKey(e)
    End Sub

    Private Sub cmbroute_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbroute.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub

#End Region

#Region "Combo Box"

    Private Sub cmbroute_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbroute.Validating
        vdating(cmbroute, " SELECT rt_nm FROM rout WHERE rt_nm='" & Trim(cmbroute.Text) & "'", "Please Select A Valid Route Name.")
    End Sub

    Private Sub cmbroute_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbroute.GotFocus
        cmbroute.Height = 100
        populate(cmbroute, "SELECT rt_nm FROM rout WHERE rec_lock='N' ORDER BY rt_nm")
    End Sub

    Private Sub cmbroute_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbroute.LostFocus
        cmbroute.Height = 21
    End Sub

    Private Sub cmbroute_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbroute.Validated
        vdated(txtroutecd, " SELECT rt_cd FROM rout WHERE rt_nm='" & Trim(cmbroute.Text) & "'")
    End Sub

#End Region

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        comd = "E"
        Me.Text = "Market Master Entry Screen . . ."
        btnsave.Text = "Add"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtmarket.Text) = "" Then
            MessageBox.Show("Please Provide A Market Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtmarket.Focus()
            Exit Sub
        End If
        If Trim(cmbroute.Text) = "" Or Val(txtroutecd.Text) = 0 Then
            MessageBox.Show("The Route Name Should not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtmarket.Focus()
            Exit Sub
        End If
        Me.market_save()
    End Sub

#End Region

    Private Sub market_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(ma_cd) as 'Max' FROM market")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO market(ma_cd,ma_nm,rt_cd,rec_lock) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(txtmarket.Text) & "','" & Val(txtroutecd.Text) & "','" & _
                          vb.Left(cmblock.Text, 1) & "')")
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Me.Text = "Market Master Entry Screen . . ."
                Close1()
            End If
        Else
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT ma_cd FROM market WHERE ma_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE market SET ma_nm='" & Trim(txtmarket.Text) & "',rt_cd='" & Val(txtroutecd.Text) & "',rec_lock='" & _
                              vb.Left(cmblock.Text, 1) & "' WHERE ma_cd =" & Val(txtscrl.Text) & "")
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                    Me.dv_disp()
                End If
                Close1()
            End If
        End If
    End Sub

    Private Sub dv_disp()
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY ma_nm) AS 'Sl.',market.ma_nm AS 'Market Name', rout.rt_nm AS 'Area Name',market.ma_cd,  market.rt_cd, market.rec_lock FROM market INNER JOIN rout ON market.rt_cd = rout.rt_cd ORDER BY ma_nm")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(3).Visible = False
            dv.Columns(4).Visible = False
            dv.Columns(5).Visible = False

            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(5).Value

                If reclock = "Y" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    'dv.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
        End If
        Close1()
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT market.ma_cd, market.ma_nm, rout.rt_nm, market.rt_cd, market.rec_lock FROM market INNER JOIN rout ON market.rt_cd = rout.rt_cd WHERE ma_cd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtmarket.Text = dsedit.Tables(0).Rows(0).Item("ma_nm")
            cmbroute.Text = dsedit.Tables(0).Rows(0).Item("rt_nm")
            txtroutecd.Text = dsedit.Tables(0).Rows(0).Item("rt_cd")
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
                cmblock.SelectedIndex = 1
            Else
                cmblock.SelectedIndex = 0
            End If
        End If
        Close1()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
        Me.Text = "Market Master Entry Screen . . ."
        dv.Visible = False
        txtmarket.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Maeket Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(3).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtmarket.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            slno = dv.SelectedRows(0).Cells(3).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT ma_cd FROM market WHERE ma_cd=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    Dim ds1 As DataSet = get_dataset("SELECT ma_cd FROM party WHERE ma_cd=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM market WHERE ma_cd =" & Val(slno) & "")
                        MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.dv_disp()
                    Else
                        MessageBox.Show("Sorry You Can't Delete The Market It Has Been Already Used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                Close1()
            End If
        End If
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub
End Class
