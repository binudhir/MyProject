Imports vb = Microsoft.VisualBasic
Public Class frmrefund


    Private Sub frmrefund_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmrefund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmrefund_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
    End Sub

    Private Sub frmrefund_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        'txtregd.Text = ""
        cmbname.Text = ""
        dtissue.Value = sys_date
        cmbissue.SelectedIndex = 0
        rdbdis.Checked = 1
        dv1.Rows.Clear()
    End Sub

    'Private Sub cmbissue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbissue.SelectedIndexChanged
    '    If cmbissue.SelectedIndex = 0 Then
    '        lblreg.Text = "Regd No.:"
    '        lbltrade.Text = "Trade :"
    '    End If
    '    If cmbissue.SelectedIndex = 1 Then
    '        lblreg.Text = "Emp No.:"
    '        lbltrade.Text = "Dept.:"
    '    End If
    'End Sub

#Region "Enter/Leave"
    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbissue.Enter, cmbname.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbissue.Leave, cmbname.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

    End Sub
    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.MouseEnter, btnref.MouseEnter, btnref.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.MouseLeave, btnref.MouseLeave, btnref.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "Key Press"

    Private Sub txtscroll_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        key(cmbissue, e)
        NUM(e)
    End Sub

    Private Sub cmbissue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbissue.KeyPress
        key(dtissue, e)
        SPKey(e)
    End Sub

    Private Sub dtissue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtissue.KeyPress
        key(cmbname, e)
    End Sub

    Private Sub cmbname_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbname.KeyPress
        key(btnref, e)
        SPKey(e)
    End Sub
#End Region

#Region "Validating/Validated"


    Private Sub cmbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.GotFocus
        txtcd.Text = 0
        If cmbissue.SelectedIndex = 0 Then
            populate(cmbname, "SELECT staf_nm FROM staf WHERE rec_lock='N' ORDER BY staf_nm")
        Else
            populate(cmbname, "SELECT veh_nm FROM veh WHERE rec_lock='N' ORDER BY veh_nm")
        End If

    End Sub

    Private Sub cmbname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.LostFocus
        cmbname.Height = 21
    End Sub

    Private Sub cmbname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        If cmbissue.SelectedIndex = 0 Then
            vdated(txtcd, "SELECT staf_sl FROM staf WHERE (staf_nm = '" & Trim(cmbname.Text) & "')")
        Else
            vdated(txtcd, "SELECT veh_cd FROM veh WHERE (veh_nm = '" & Trim(cmbname.Text) & "')")
        End If
        If txtcd.Text <> 0 Then
            Me.dv_view(txtcd.Text)
        End If
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        If cmbissue.SelectedIndex = 0 Then
            vdating(cmbname, "SELECT staf_nm FROM staf WHERE rec_lock='N' AND staf_nm='" & Trim(cmbname.Text) & "'", "Please Select A Valid Staf Name.")
        Else
            vdating(cmbname, "SELECT veh_nm FROM veh WHERE rec_lock='N' AND veh_nm='" & Trim(cmbname.Text) & "'", "Please Select A Valid Vehcile Name.")
        End If

    End Sub


    'Private Sub txtregd_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    If cmbissue.SelectedIndex = 0 Then
    '        vdating(txtregd, "SELECT reg_no FROM stud WHERE (reg_no ='" & Trim(txtregd.Text) & "') AND rec_lock='N'", "Please Enter A Valid Regd. No.")
    '    Else
    '        vdating(txtregd, "SELECT staf_id FROM staf WHERE (staf_id = '" & Trim(txtregd.Text) & "')", "Please Enter A Valid Employee No.")
    '    End If
    'End Sub

    'Private Sub txtregd_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cmbissue.SelectedIndex = 0 Then
    '        Dim ds As DataSet = get_dataset("SELECT stud_hstry.stud_sl, stud.stud_nm, trad.trad_nm FROM stud_hstry INNER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE stud.reg_no='" & Trim(txtregd.Text) & "' AND (stud_hstry.active = 'Y')")
    '        If ds.Tables(0).Rows.Count <> 0 Then
    '            txtname.Text = Trim(ds.Tables(0).Rows(0).Item("stud_nm"))
    '            txttrade.Text = Trim(ds.Tables(0).Rows(0).Item("trad_nm"))
    '            txtcd.Text = Format(ds.Tables(0).Rows(0).Item("stud_sl"))
    '            Me.dv_view(txtcd.Text)
    '        End If
    '    Else
    '        Dim ds As DataSet = get_dataset("SELECT staf.staf_sl, staf.staf_nm,dept.dept_nm FROM staf LEFT OUTER JOIN dept ON staf.dept_cd = dept.dept_cd WHERE (staf.staf_id = '" & Trim(txtregd.Text) & "' AND staf.rec_lock='N')")
    '        If ds.Tables(0).Rows.Count <> 0 Then
    '            txtname.Text = Trim(ds.Tables(0).Rows(0).Item("staf_nm"))
    '            txttrade.Text = Trim(ds.Tables(0).Rows(0).Item("dept_nm"))
    '            txtcd.Text = Val(ds.Tables(0).Rows(0).Item("staf_sl"))
    '            Me.dv_view(txtcd.Text)
    '        End If
    '    End If
    'End Sub
#End Region

#Region "Botton"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
    End Sub

    Private Sub btnrefund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefund.Click
        If cmbname.Text = "" Then
            If cmbissue.SelectedIndex = 0 Then
                MessageBox.Show("Please Enter A Emp. No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbname.Focus()
                Exit Sub
            Else
                MessageBox.Show("Please Enter A Vehicle. No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbname.Focus()
                Exit Sub
            End If
        End If
        chk = 0
        For i As Integer = 0 To dv1.Rows.Count - 1
            If dv1.Rows(i).Cells(0).Value = 1 Then
                chk = 1
            End If
        Next
        If chk = 0 Then
            MessageBox.Show("Please Select At Least One Product To Refund.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Me.dv_save()
    End Sub

#End Region


    Private Sub dv_save()
        ''If dv1.RowCount <> 0 Then
        staf_sl = 0
        veh_cd = 0
        If cmbissue.SelectedIndex = 0 Then
            staf_sl = Val(txtcd.Text)
        Else
            veh_cd = Val(txtcd.Text)
        End If
        cnfr = MessageBox.Show("Are You Sure To Refund The Product.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Start1()
        If cnfr = vbYes Then
            For i As Integer = 0 To dv1.RowCount - 1
                If dv1.Rows(i).Cells(0).Value = 1 Then
                    isssl = Val(dv1.Rows(i).Cells(8).Value)
                    qty = Val(dv1.Rows(i).Cells(4).Value)
                    itcd = Val(dv1.Rows(i).Cells(9).Value)
                    mulrt = Val(dv1.Rows(i).Cells(10).Value)
                    itqt = (qty * mulrt)
                    stock_OUTDEL(itqt, itcd, 0, 1, 1)
                    SQLInsert("UPDATE iss2 SET ret_dt='" & Format(dtissue.Value, "dd/MMM/yyyy") & "', refund = 'Y' WHERE iss_sl = " & isssl & "")

                End If
            Next
        End If
        Close1()
        'End If
        If cmbissue.SelectedIndex = 0 Then
            Me.dv_view(txtcd.Text)
        Else
            Me.dv_view(txtcd.Text)
        End If
    End Sub

    Private Sub dv_view(ByVal x As Integer)
        Dim ds As DataSet
        If cmbissue.SelectedIndex = 0 Then
            ds = get_dataset("SELECT iss2.*,manf.manf_nm, item.it_name FROM iss2 LEFT OUTER JOIN manf ON iss2.manf_cd = manf.manf_cd LEFT OUTER JOIN item ON iss2.it_cd = item.it_cd WHERE (iss2.staf_sl = '" & Val(x) & "' AND refund = 'N')")
        Else
            ds = get_dataset("SELECT iss2.*,manf.manf_nm, item.it_name FROM iss2 LEFT OUTER JOIN manf ON iss2.manf_cd = manf.manf_cd LEFT OUTER JOIN item ON iss2.it_cd = item.it_cd WHERE (iss2.veh_cd = '" & Val(x) & "'  AND refund = 'N')")
        End If
        rw = 0
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(1).Value = i + 1
                dv1.Rows(rw).Cells(2).Value = ds.Tables(0).Rows(i).Item("manf_nm")
                dv1.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("it_name")
                dv1.Rows(rw).Cells(4).Value = Format(ds.Tables(0).Rows(i).Item("qty"), "######0")
                dv1.Rows(rw).Cells(5).Value = Trim(ds.Tables(0).Rows(i).Item("unt"))
                dv1.Rows(rw).Cells(6).Value = Format(ds.Tables(0).Rows(i).Item("rate"), "#######0.00")
                dv1.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("amt"), "######0.00")
                dv1.Rows(rw).Cells(8).Value = ds.Tables(0).Rows(i).Item("iss_sl")
                dv1.Rows(rw).Cells(9).Value = ds.Tables(0).Rows(i).Item("it_cd")
                dv1.Rows(rw).Cells(10).Value = ds.Tables(0).Rows(i).Item("mul_rt")
                rw += 1
            Next
        Else
            MessageBox.Show("There Is No Product To Return From This Staff", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbname.Focus()
            Me.clr()
        End If
    End Sub

    Private Sub rdbdis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbdis.CheckedChanged
        If rdbdis.Checked = True Then
            For i As Integer = 0 To dv1.Rows.Count - 1
                dv1.Rows(i).Cells(0).Value = 0
            Next
        End If
    End Sub

    Private Sub rdbsel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbsel.CheckedChanged
        If rdbsel.Checked = True Then
            For i As Integer = 0 To dv1.Rows.Count - 1
                dv1.Rows(i).Cells(0).Value = 1
            Next
        End If
    End Sub
End Class
