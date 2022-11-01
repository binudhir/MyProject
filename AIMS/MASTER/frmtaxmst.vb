Imports vb = Microsoft.VisualBasic
Public Class frmtaxmst
    Dim comd As String

    Private Sub frmtaxmst_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuTax.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmtaxmst_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmtaxmst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuTax.Enabled = False
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmtaxmst_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Tax Master . . ."
        txtscrl.Text = ""
        txttaxnm.Text = ""
        txtsrtnm.Text = ""
        txttaxamt.Text = "0.00"
        cmbcalc.SelectedIndex = 0
        cmblock.SelectedIndex = 0
        rdbvat.Checked = True
        Dim ds As DataSet = get_dataset("SELECT max(taxcd) as 'Max' FROM taxper")
        txtscrl.Text = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        txttaxnm.Focus()
    End Sub


#Region "Enter/Leave"

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttaxnm.Enter, txttaxamt.Enter, txtsrtnm.Enter, cmblock.Enter, cmbcalc.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttaxnm.Leave, txttaxamt.Leave, txtsrtnm.Leave, cmblock.Leave, cmbcalc.Leave
        sender.text = UCase(sender.text)
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

#Region "KeyPress"


    Private Sub txttaxnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttaxnm.KeyPress
        key(txtsrtnm, e)
        SPKey(e)
    End Sub

    Private Sub txtsrtnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsrtnm.KeyPress
        key(cmbcalc, e)
        SPKey(e)
    End Sub

    Private Sub cmbcalc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcalc.KeyPress
        key(txttaxamt, e)
    End Sub

    Private Sub txttaxamt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttaxamt.KeyPress
        key(rdbvat, e)
        NUM1(e)
    End Sub

    Private Sub rdbvat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rdbvat.KeyPress
        key(cmblock, e)
    End Sub

    Private Sub rdbcst_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rdbcst.KeyPress
        key(cmblock, e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(btnsave, e)
    End Sub

#End Region

#Region "GotFocus/LostFocus"

    Private Sub txttaxnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttaxnm.LostFocus
        If Trim(txtsrtnm.Text) = "" Then
            txtsrtnm.Text = vb.Left(Trim(txttaxnm.Text), 5)
        End If
    End Sub

    Private Sub txttaxamt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttaxamt.LostFocus
        txttaxamt.Text = Format(Val(txttaxamt.Text), "######0.00")
    End Sub

    Private Sub txttaxamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttaxamt.GotFocus
        If Val(txttaxamt.Text) = 0 Then
            txttaxamt.Text = ""
        End If
    End Sub

#End Region

#Region "Button"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
        Me.Text = "Tax Master Entry Screen . . ."
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txttaxnm.Text) = "" Then
            MessageBox.Show("Please Provide A Tax Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txttaxnm.Focus()
            Exit Sub
        End If
        If Trim(txtsrtnm.Text) = "" Then
            MessageBox.Show("Please Provide A Short Tax Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtsrtnm.Focus()
            Exit Sub
        End If
        'If Val(txttaxamt.Text) = 0 Then
        '    MessageBox.Show("Sorry The Tax(%) Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txttaxamt.Focus()
        '    Exit Sub
        'End If
        Me.tax_save()
    End Sub

#End Region

#Region "cmnu"

    Private Sub cmnuref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuref.Click, btnview.Click
        Me.clr()
        Me.Text = "Tax Master . . ."
        Me.dv_disp()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Save"
        Me.Text = "Tax Master Entry Screen . . ."
        dv.Visible = False
        txttaxnm.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Tax Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(4).Value
            Me.dv_edit(slno)
            dv.Visible = False
            txttaxnm.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        'fnd = 0
        'If dv.RowCount <> 0 Then
        '    slno = dv.SelectedRows(0).Cells(4).Value
        '    cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        '    Start1()
        '    If cnfr = vbYes Then
        '        Dim ds As DataSet = get_dataset("SELECT taxcd FROM taxper WHERE taxcd=" & Val(slno) & "")
        '        If ds.Tables(0).Rows.Count <> 0 Then
        '            Dim ds1 As DataSet = get_dataset("SELECT taxcd FROM prod_mst WHERE taxcd=" & Val(slno) & "")
        '            If ds1.Tables(0).Rows.Count <> 0 Then
        '                fnd = 1
        '            End If
        '            If fnd = 0 Then
        '                SQLInsert("DELETE FROM taxper WHERE taxcd =" & Val(slno) & "")
        '                MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                Me.dv_disp()
        '            Else
        '                MessageBox.Show("Sorry You Can't Delete The Tax It Has Been Already Used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                Exit Sub
        '            End If
        '        End If
        '        Close1()
        '    End If
        'End If
    End Sub


#End Region

    Private Sub tax_save()
        If rdbvat.Checked = True Then
            rdbval = "V"
        Else
            rdbval = "C"
        End If

        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(taxcd) as 'Max' FROM taxper")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO taxper (taxcd,taxnm,txname,tax1,tax2,tax3,taxcat,taxsl,tax_tp,pay_tp,rec_lock,cr_alow,used) VALUES (" & Val(txtscrl.Text) & ",'" & _
                          Trim(txttaxnm.Text) & "','" & Trim(txtsrtnm.Text) & "'," & Val(txttaxamt.Text) & ",0,0," & _
                          vb.Left(cmbcalc.Text, 1) & ",0,'" & Trim(rdbval) & "','Y','" & vb.Left(cmblock.Text, 1) & "','N','Y')")
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Me.Text = "Tax Master Entry Screen ..."
                Close1()
            End If
        Else
            
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT taxcd FROM taxper WHERE taxcd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE taxper SET taxnm='" & Trim(txttaxnm.Text) & "',txname='" & Trim(txtsrtnm.Text) & "',taxcat='" & _
                          vb.Left(cmbcalc.Text, 1) & "',tax1=" & Val(txttaxamt.Text) & ",rec_lock='" & _
                              vb.Left(cmblock.Text, 1) & "',tax_tp='" & Trim(rdbval) & "' WHERE taxcd =" & Val(txtscrl.Text) & "")
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
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY taxnm) AS 'Sl.',taxnm AS 'Tax Name',STR(tax1,10,2) AS 'Tax Amount',(CASE WHEN taxcat='1' THEN 'VAT' WHEN taxcat='2' THEN 'MRP' END) AS 'Type Category',taxcd,rec_lock FROM taxper ORDER BY taxnm")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
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
        Dim dsedit As DataSet = get_dataset("SELECT * FROM taxper WHERE taxcd=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txttaxnm.Text = dsedit.Tables(0).Rows(0).Item("taxnm")
            txtsrtnm.Text = dsedit.Tables(0).Rows(0).Item("txname")
            txttaxamt.Text = Format(dsedit.Tables(0).Rows(0).Item("tax1"), "######0.00")
            cmbcalc.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("taxcat")) - 1
            If dsedit.Tables(0).Rows(0).Item("tax_tp") = "V" Then
                rdbvat.Checked = True
            Else
                rdbcst.Checked = True
            End If
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "Y" Then
                cmblock.SelectedIndex = 1
            Else
                cmblock.SelectedIndex = 0
            End If
        End If
        Close1()
    End Sub

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub
End Class
