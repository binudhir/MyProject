Imports vb = Microsoft.VisualBasic
Public Class frmcntr
    Dim comd As String

    Private Sub frmcntr_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuCountry.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmcntr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmcntr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuCountry.Enabled = False
        Me.clr()
        Me.dv_disp()


        'With Me
        '    .Text = "Anchor Test"
        '    .Size = New Size(300, 300)
        'End With
        'With DataGridView1
        '    .Location = New Point(13, 13)
        '    .Size = New Size(259, 208)
        '    .Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top Or AnchorStyles.Bottom
        'End With
        'With btnsave
        '    .Location = New Point(12, 227)
        '    .Size = New Size(75, 23)
        '    .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        'End With
        'With txtcntrnm
        '    .Location = New Point(93, 229)
        '    .Size = New Size(179, 20)
        '    .Anchor = AnchorStyles.Bottom Or AnchorStyles.Right Or AnchorStyles.Left
        'End With
        'x = Me.Left
        'y = Me.Top
        'z = Me.Right
        'm = Me.Bottom
        'MessageBox.Show("Left=" & x & ",Top=" & y & ",Right=" & z & ",Bottom=" & m & "")
        'Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmcntr_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        'Dim top As Integer = 0
        'For Each con As Control In Me.Controls
        '    con.Left = (Me.ClientRectangle.Width / 2) - (con.Width / 2)
        '    con.Top = (Me.ClientRectangle.Height / 2) - (con.Height / 2) + top
        '    top += 100
        'Next
        'Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        'Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        'Dim x As Integer = boundWidth - Me.Width
        'Dim y As Integer = boundHeight - Me.Height
        'Me.Location = New Point(x / 2, y / 2)
        'With btnsave
        '    .Location = New Point(12, 227)
        '    .Size = New Size(75, 23)
        '    .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        'End With
        'With txtcntrnm
        '    .Location = New Point(93, 229)
        '    .Size = New Size(179, 20)
        '    .Anchor = AnchorStyles.Bottom Or AnchorStyles.Right Or AnchorStyles.Left
        'End With

        'x = Me.Left
        'y = Me.Top
        'z = Me.Right
        'm = Me.Bottom
        'h = Me.Height
        'w = Me.Width
        'MessageBox.Show("Left=" & x & ",Top=" & y & ",Right=" & z & ",Bottom=" & m & ",Height=" & h & ",Width=" & w & "")
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Country Master . . ."
        txtscrl.Text = ""
        txtcntrnm.Text = ""
        txtntnl.Text = ""
        cmblock.SelectedIndex = 0
        Dim ds As DataSet = get_dataset("SELECT max(cntr_sl) as 'Max' FROM cntr")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txtcntrnm.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.dv_disp()
        Me.Text = "Country Master . . ."
    End Sub

#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcntrnm.Enter, cmblock.Enter, txtntnl.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
        sender.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Bold)
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcntrnm.Leave, cmblock.Leave, txtntnl.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
        sender.Font = New System.Drawing.Font("Verdana", 8, FontStyle.Regular)
        sender.text = UCase(sender.text)
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub


#End Region

#Region "KeyPress"

    Private Sub txtcntrnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcntrnm.KeyPress
        key(txtntnl, e)
        SPKey(e)
    End Sub

    Private Sub txtntnl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtntnl.KeyPress
        key(cmblock, e)
        SPKey(e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub
   
#End Region
   
    Private Sub txtdeptnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcntrnm.LostFocus
        If Trim(txtntnl.Text) = "" Then
            txtntnl.Text = Trim(txtcntrnm.Text)
        End If
    End Sub

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        Me.Text = "Country Master Entry Screen . . ."
        comd = "E"
        btnsave.Text = "Save"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtcntrnm.Text) = "" Then
            MessageBox.Show("Please Provide A Country Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtcntrnm.Focus()
            Exit Sub
        End If
        If Trim(txtntnl.Text) = "" Then
            MessageBox.Show("Please Provide The Nationality.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtcntrnm.Focus()
            Exit Sub
        End If
        Me.trad_save()
    End Sub

#End Region


    Private Sub trad_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(cntr_sl) as 'Max' FROM cntr")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO cntr (cntr_sl,cntr_nm,natn,rec_lock) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(txtcntrnm.Text) & "','" & Trim(txtntnl.Text) & "','" & vb.Left(cmblock.Text, 1) & "')")

                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Me.Text = "Country Master Entry Screen . . ."
                Close1()
            End If
        Else
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT cntr_sl FROM cntr WHERE cntr_sl=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE cntr SET cntr_nm='" & Trim(txtcntrnm.Text) & "',natn='" & Trim(txtntnl.Text) & "',rec_lock='" & _
                              vb.Left(cmblock.Text, 1) & "' WHERE cntr_sl =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT   ROW_NUMBER() OVER(ORDER BY cntr_nm) AS 'Sl.', cntr_nm AS 'Country Name', natn AS 'Nationality', cntr_sl,rec_lock FROM cntr ORDER BY cntr_nm")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(3).Visible = False
            dv.Columns(4).Visible = False

            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(4).Value

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
        Dim dsedit As DataSet = get_dataset("SELECT * FROM cntr WHERE cntr_sl=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtcntrnm.Text = dsedit.Tables(0).Rows(0).Item("cntr_nm")
            txtntnl.Text = dsedit.Tables(0).Rows(0).Item("natn")
           
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
        Me.Text = "Country Master Entry Screen . . ."
        dv.Visible = False
        txtcntrnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Country Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(3).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txtcntrnm.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            slno = dv.SelectedRows(0).Cells(3).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT cntr_sl FROM cntr WHERE cntr_sl=" & Val(slno) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    Dim ds1 As DataSet = get_dataset("SELECT cntr_sl FROM stat WHERE cntr_sl=" & Val(slno) & "")
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        fnd = 1
                    End If
                    If fnd = 0 Then
                        SQLInsert("DELETE FROM cntr WHERE cntr_sl =" & Val(slno) & "")
                        MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.dv_disp()
                    Else
                        MessageBox.Show("Sorry You Can't Delete The Country It Has Been Already Used in States.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                Close1()
            End If
        End If
    End Sub

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub
End Class
