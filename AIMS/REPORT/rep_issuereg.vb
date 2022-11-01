Imports vb = Microsoft.VisualBasic
Public Class rep_issuereg
    Dim comd As String

    Private Sub rep_issuereg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_issuereg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_issuereg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        fromdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        todt.Value = fromdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        comd = vb.Left(cmbreport.Text, 1)
        If comd = "I" Then
            Me.Text = "Issue Register . . ."
            GroupBox3.Text = "Issue Register . . ."
        ElseIf comd = "R" Then
            Me.Text = "Refund Register . . ."
            GroupBox3.Text = "Refund Register . . ."
        End If
        txtordcd.Text = 0
        txtstafcd.Text = 0
        txtstudcd.Text = 0
        txtprocd.Text = 0
        cmborder.Text = ""
        cmbprodct.Text = ""
        cmbstud.Text = ""
        cmborder.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False
        cmborder.SelectedIndex = 0
    End Sub
#Region "Enter/Leave"
    Private Sub cmbreport_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstud.Enter, cmbprodct.Enter, cmborder.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmbreport_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstud.Leave, cmbprodct.Leave, cmborder.Leave

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

    Private Sub fromdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fromdt.KeyPress
        key(todt, e)
    End Sub

    Private Sub todt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles todt.KeyPress
        key(rbstudent, e)
    End Sub

    Private Sub rbstudent_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbstudent.KeyPress
        key(rbstaff, e)
    End Sub

    Private Sub rbstaff_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbstaff.KeyPress
        key(cmbreport, e)
    End Sub

    Private Sub cmbreport_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        key(cmbstud, e)
        SPKey(e)
    End Sub

    Private Sub cmbstud_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstud.KeyPress
        key(cmbprodct, e)
        SPKey(e)
    End Sub

    Private Sub cmbprodct_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbprodct.KeyPress
        key(cmborder, e)
        SPKey(e)
    End Sub

    Private Sub cmborder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmborder.KeyPress
        key(btnview, e)
        SPKey(e)
    End Sub

    Private Sub rbstudent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbstudent.CheckedChanged
        If rbstudent.Checked = True Then
            Label2.Text = "Student Name :"
        Else
            Label2.Text = "Staff Name :"
        End If
    End Sub

    Private Sub cmbprodct_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprodct.GotFocus
        txtprocd.Text = 0
        populate(cmbprodct, "SELECT it_name FROM item WHERE (rec_lock = 'N') ORDER BY it_name")
    End Sub

    Private Sub cmbprodct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprodct.LostFocus
        cmbprodct.Height = 21
    End Sub

    Private Sub cmbprodct_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprodct.Validated
        vdated(txtprocd, "SELECT it_cd FROM item WHERE (it_name = '" & Trim(cmbprodct.Text) & "')")
    End Sub

    Private Sub cmbprodct_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbprodct.Validating
        vdating(cmbprodct, "SELECT it_name FROM item WHERE (it_name = '" & Trim(cmbprodct.Text) & "')", "Please Select a Valid Product Name.")
    End Sub

    Private Sub cmbstud_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstud.GotFocus
        txtstudcd.Text = 0
        txtstafcd.Text = 0
        If rbstudent.Checked = True Then
            populate(cmbstud, "SELECT stud_nm FROM stud WHERE (rec_lock = 'N') ORDER BY stud_nm")
        Else
            populate(cmbstud, "SELECT staf_nm FROM staf WHERE (rec_lock = 'N') ORDER BY staf_nm")
        End If

    End Sub

    Private Sub cmbstud_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstud.LostFocus
        cmbstud.Height = 21
    End Sub

    Private Sub cmbstud_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstud.Validated
        vdated(txtstudcd, "SELECT stud_nm FROM stud WHERE (stud_nm = '" & Trim(cmbstud.Text) & "')")
    End Sub

    Private Sub cmbstud_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstud.Validating
        vdating(cmbstud, "SELECT stud_nm FROM stud WHERE (stud_nm = '" & Trim(cmbstud.Text) & "')", "Please Select a Student Name.")
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        lblmsg.Visible = False
        dv.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        conditn = ""
        orderby = ""
        If comd = "I" Then
            If chkstud.Checked = False Then
                If rbstudent.Checked = True Then
                    conditn = " AND (stud.stud_sl=" & Val(txtstudcd.Text) & ")"
                Else
                    conditn = " AND (staf.staf_sl=" & Val(txtstafcd.Text) & ")"
                End If
            End If
            If chkprod.Checked = False Then
                conditn = conditn & "AND (item.it_cd=" & Val(txtprocd.Text) & ")"
            End If
            orderby = "iss1.iss_dt"
            If cmborder.SelectedIndex = 1 Then
                If rbstudent.Checked = True Then
                    orderby = " stud.stud_nm"
                Else
                    orderby = " staf.staf_nm"
                End If
            End If
            If cmborder.SelectedIndex = 2 Then
                orderby = "item.it_name"
            End If

        ElseIf comd = "R" Then
            If chkstud.Checked = False Then
                If rbstudent.Checked = True Then
                    conditn = " AND (stud.stud_sl=" & Val(txtstudcd.Text) & ")"
                Else
                    conditn = " AND (staf.staf_sl=" & Val(txtstafcd.Text) & ")"
                End If
            End If
            If chkprod.Checked = False Then
                conditn = conditn & "AND (item.it_cd=" & Val(txtprocd.Text) & ")"
            End If
            orderby = "iss2.ret_dt"
            If cmborder.SelectedIndex = 1 Then
                If rbstudent.Checked = True Then
                    orderby = " stud.stud_nm"
                Else
                    orderby = " staf.staf_nm"
                End If
            End If
            If cmborder.SelectedIndex = 2 Then
                orderby = "item.it_name"
            End If

        End If


        If comd = "I" Then
            If (rbstudent.Checked = True) Then
                ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', STR(iss1.iss_no,10,0) AS 'Issue No.', CONVERT(varchar, iss1.iss_dt, 103) AS 'Issue Date',  stud.reg_no AS 'Reg No.', stud.stud_nm AS 'Student Name', trad.trad_nm AS 'Trade', sesion1.sesn_nm AS 'Session', semester.sem_nm AS 'Class', item.it_name AS 'Product', STR(iss2.qty, 10, 2) AS 'Quantity', iss2.unt AS 'Unit', STR(iss2.rate, 10, 2) AS 'M.R.P.', STR(iss2.amt, 10, 2) AS 'TOTAL' FROM         stud_hstry LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd RIGHT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl RIGHT OUTER JOIN item RIGHT OUTER JOIN iss2 ON item.it_cd = iss2.it_cd ON stud.stud_sl = iss2.stud_sl RIGHT OUTER JOIN  iss1 ON iss2.iss_no = iss1.iss_no WHERE  iss1.stud_sl <> 0 AND iss2.Refund = 'N' AND (iss1.iss_dt>='" & Format(fromdt.Value, "dd/MMM/yyyy") & "') AND (iss1.iss_dt<='" & Format(todt.Value, "dd/MMM/yyyy") & "')  " & conditn & " ORDER BY " & orderby & ",iss1.iss_no")
            Else
                ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', STR(iss1.iss_no,10,0) AS 'Issue No.', CONVERT(varchar, iss1.iss_dt, 103) AS 'Issue Date', iss1.ref_no AS 'Ref No.', staf.staf_id AS 'Staff ID', staf.staf_nm AS 'Staff Name', dept.dept_nm AS 'Dept Name', desg.desg_nm AS 'Designation', item.it_name AS 'Product', STR(iss2.qty, 10, 2) AS 'Quantity', iss2.unt AS 'Unit', STR(iss2.rate, 10, 2) AS 'M.R.P.', STR(iss2.amt, 10, 2) AS 'TOTAL' FROM         staf LEFT OUTER JOIN  dept ON staf.dept_cd = dept.dept_cd LEFT OUTER JOIN  desg ON staf.desg_cd = desg.desg_cd LEFT OUTER JOIN iss1 ON staf.staf_sl = iss1.staf_sl LEFT OUTER JOIN  item RIGHT OUTER JOIN  iss2 ON item.it_cd = iss2.it_cd ON iss1.iss_no = iss2.iss_no  WHERE iss1.staf_sl <> 0 AND iss2.Refund = 'N' AND (iss1.iss_dt>='" & Format(fromdt.Value, "dd/MMM/yyyy") & "') AND (iss1.iss_dt<='" & Format(todt.Value, "dd/MMM/yyyy") & "')  " & conditn & " ORDER BY " & orderby & ",iss1.iss_no")
            End If
            If ds.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = ds.Tables(0)
                slno1 = 0
                For i As Integer = 0 To dv.Rows.Count - 1
                    slno = Val(dv.Rows(i).Cells(1).Value)
                    If slno = slno1 Then
                        'dv.Rows(i).Cells(0).Value = ""
                        dv.Rows(i).Cells(1).Value = ""
                        dv.Rows(i).Cells(2).Value = ""
                        dv.Rows(i).Cells(3).Value = ""
                        dv.Rows(i).Cells(4).Value = ""
                        dv.Rows(i).Cells(5).Value = ""
                        dv.Rows(i).Cells(6).Value = ""
                        dv.Rows(i).Cells(7).Value = ""
                        'dv.Rows(i).Cells(8).Value = ""
                    Else
                        slno1 = Val(dv.Rows(i).Cells(1).Value)
                    End If
                    
                Next

                hddr = GroupBox3.Text
            Else
                lblmsg.Visible = True
            End If
        Else

            If (rbstudent.Checked = True) Then
                ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', STR(iss1.iss_no,10,0) AS 'Issue No.', CONVERT(varchar, iss2.ret_dt, 103) AS 'Refund Date',  stud.reg_no AS 'Reg No.', stud.stud_nm AS 'Student Name', trad.trad_nm AS 'Trade', sesion1.sesn_nm AS 'Session', semester.sem_nm AS 'Class', item.it_name AS 'Product', STR(iss2.qty, 10, 2) AS 'Quantity', iss2.unt AS 'Unit', STR(iss2.rate, 10, 2) AS 'M.R.P.', STR(iss2.amt, 10, 2) AS 'TOTAL' FROM stud_hstry LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd RIGHT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl RIGHT OUTER JOIN item RIGHT OUTER JOIN iss2 ON item.it_cd = iss2.it_cd ON stud.stud_sl = iss2.stud_sl RIGHT OUTER JOIN  iss1 ON iss2.iss_no = iss1.iss_no WHERE  iss1.stud_sl <> 0 AND iss2.Refund = 'Y' AND (iss1.iss_dt>='" & Format(fromdt.Value, "dd/MMM/yyyy") & "') AND (iss1.iss_dt<='" & Format(todt.Value, "dd/MMM/yyyy") & "')  " & conditn & " ORDER BY " & orderby & ",iss1.iss_no")
            Else
                ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', STR(iss1.iss_no,10,0) AS 'Issue No.', CONVERT(varchar, iss2.ret_dt, 103) AS 'Refund Date', iss1.ref_no AS 'Ref No.', staf.staf_id AS 'Staff ID', staf.staf_nm AS 'Staff Name', dept.dept_nm AS 'Dept Name', desg.desg_nm AS 'Designation', item.it_name AS 'Product', STR(iss2.qty, 10, 2) AS 'Quantity', iss2.unt AS 'Unit', STR(iss2.rate, 10, 2) AS 'M.R.P.', STR(iss2.amt, 10, 2) AS 'TOTAL' FROM staf LEFT OUTER JOIN  dept ON staf.dept_cd = dept.dept_cd LEFT OUTER JOIN  desg ON staf.desg_cd = desg.desg_cd LEFT OUTER JOIN iss1 ON staf.staf_sl = iss1.staf_sl LEFT OUTER JOIN  item RIGHT OUTER JOIN  iss2 ON item.it_cd = iss2.it_cd ON iss1.iss_no = iss2.iss_no  WHERE iss1.staf_sl <> 0 AND iss2.Refund = 'Y' AND (iss1.iss_dt>='" & Format(fromdt.Value, "dd/MMM/yyyy") & "') AND (iss1.iss_dt<='" & Format(todt.Value, "dd/MMM/yyyy") & "')  " & conditn & " ORDER BY " & orderby & ",iss1.iss_no")
            End If
            If ds.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = ds.Tables(0)
                hddr = GroupBox3.Text
            Else
                lblmsg.Visible = True
            End If
        End If


        'If ds.Tables(0).Rows.Count <> 0 Then
        '    dv.DataSource = ds.Tables(0)
        '    hddr = GroupBox3.Text
        'Else
        '    lblmsg.Visible = True
        'End If


        Close1()
    End Sub

    Private Sub chkparty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkstud.CheckedChanged
        If chkstud.Checked = True Then
            cmbstud.Text = "<<< All Party >>>"
            cmbstud.Enabled = False
            txtstudcd.Text = 0
            txtstafcd.Text = 0
        Else
            cmbstud.Text = ""
            cmbstud.Enabled = True
            cmbstud.Focus()
        End If
    End Sub

    Private Sub chkprod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkprod.CheckedChanged
        If chkprod.Checked = True Then
            cmbprodct.Text = "<<< All Products >>>"
            cmbprodct.Enabled = False
            txtprocd.Text = 0
        Else
            cmbprodct.Text = ""
            cmbprodct.Enabled = True
            cmbprodct.Focus()
        End If
    End Sub

End Class
