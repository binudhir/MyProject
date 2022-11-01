Imports vb = Microsoft.VisualBasic
Public Class rep_studleg
    Dim comd As String

    Private Sub rep_colreg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_colreg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_colreg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
    End Sub

    Private Sub clr()
        Me.Text = "Student Ledger . . ."
        hddr = Me.Text
        txtsesncd.Text = 0
        txtstrmcd.Text = 0
        txtacdncd.Text = 0
        cmbsessn.Text = ""
        cmborder.SelectedIndex = 0
        cmbsessn.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False
        If chkclass.Checked = False Then
            cmbacdmyr.Text = ""
        End If
        If chkstrm.Checked = False Then
            cmbstrm.Text = ""
        End If
        If chkstud.Checked = False Then
            cmbstud.Text = ""
        End If
    End Sub

    Private Sub cmborder_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstrm.Enter, cmbsessn.Enter, cmborder.Enter, cmbacdmyr.Enter, cmbstud.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmborder_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstrm.Leave, cmbsessn.Leave, cmborder.Leave, cmbacdmyr.Leave, cmbstud.Leave

        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btncalc_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnrfresh.MouseEnter, btnexport.MouseEnter, btnexit.MouseEnter, btncalc.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btncalc_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnrfresh.MouseLeave, btnexport.MouseLeave, btnexit.MouseLeave, btncalc.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub cmbsession_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbsessn.KeyPress
        key(cmbstrm, e)
        SPKey(e)
    End Sub

    Private Sub cmbstream_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstrm.KeyPress
        key(cmbacdmyr, e)
        SPKey(e)
    End Sub

    Private Sub cmbclass_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbacdmyr.KeyPress
        key(cmbstud, e)
        SPKey(e)
    End Sub

    Private Sub cmbstud_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstud.KeyPress
        If cmborder.Visible = True Then
            key(cmborder, e)
        Else
            key(btnview, e)
        End If
        SPKey(e)
    End Sub

    Private Sub cmborder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmborder.KeyPress
        key(btnview, e)
        SPKey(e)
    End Sub

    Private Sub cmbsessn_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsessn.Validated
        vdated(txtsesncd, "SELECT sesn_cd FROM sesion1 WHERE sesn_nm='" & Trim(cmbsessn.Text) & "'")
    End Sub

    Private Sub cmbsessn_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbsessn.Validating
        vdating(cmbsessn, "SELECT sesn_nm FROM sesion1 WHERE sesn_nm='" & Trim(cmbsessn.Text) & "' AND rec_lock='N'", "Please Select A Valid Session Name.")
    End Sub

    Private Sub cmbsessn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsessn.GotFocus
        populate(cmbsessn, "SELECT sesn_nm FROM sesion1 WHERE rec_lock='N' ORDER BY sesn_dt1 DESC")
    End Sub

    Private Sub cmbsessn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsessn.LostFocus
        cmbsessn.Height = 21
    End Sub

    Private Sub cmbacdmyr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacdmyr.GotFocus
        populate(cmbacdmyr, "SELECT sem_nm FROM semester WHERE rec_lock='N' ORDER BY sem_pos")
    End Sub

    Private Sub cmbacdmyr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacdmyr.LostFocus
        cmbacdmyr.Height = 21
    End Sub

    Private Sub cmbacdmyr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacdmyr.Validated
        vdated(txtacdncd, "SELECT sem_cd FROM semester WHERE sem_nm='" & Trim(cmbacdmyr.Text) & "'")
    End Sub

    Private Sub cmbacdmyr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbacdmyr.Validating
        vdating(cmbacdmyr, "SELECT sem_nm FROM semester WHERE sem_nm='" & Trim(cmbacdmyr.Text) & "' AND rec_lock='N'", "Please Select A Valid Sem/Ac.Year Name.")
    End Sub

    Private Sub cmbstrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstrm.GotFocus
        populate(cmbstrm, "SELECT trad_nm FROM trad WHERE rec_lock='N' ORDER BY trad_nm")
    End Sub

    Private Sub cmbstrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstrm.LostFocus
        cmbstrm.Height = 21
    End Sub

    Private Sub cmbstrm_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstrm.Validated
        vdated(txtstrmcd, "SELECT trad_cd FROM trad WHERE trad_nm='" & Trim(cmbstrm.Text) & "'")
    End Sub

    Private Sub cmbstrm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstrm.Validating
        vdating(cmbstrm, "SELECT trad_nm FROM trad WHERE trad_nm='" & Trim(cmbstrm.Text) & "' AND rec_lock='N'", "Please Select A Valid Stream/Trade Name.")
    End Sub

    Private Sub cmbstud_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstud.GotFocus
        cmbstud.Text = ""
        txtstudsl.Text = 0
        conditn = ""
        If chkstrm.Checked = False Then
            conditn = "AND (stud_hstry.trad_cd=" & Val(txtstrmcd.Text) & ")"
        End If
        If chkclass.Checked = False Then
            conditn = conditn & " AND (stud_hstry.sem_cd=" & Val(txtacdncd.Text) & ")"
        End If
        populate(cmbstud, "SELECT stud.stud_nm FROM stud RIGHT OUTER JOIN stud_hstry ON stud.stud_sl = stud_hstry.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.sesn_cd = " & Val(txtsesncd.Text) & ")" & conditn & " ORDER BY stud.stud_nm")
    End Sub

    Private Sub cmbstud_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstud.LostFocus
        cmbstud.Height = 21
    End Sub

    Private Sub cmbstud_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstud.Validated
        'vdated(txtstudsl, "SELECT stud_sl FROM stud WHERE stud_nm='" & Trim(cmbstud.Text) & "'")
        Dim ds As DataSet = get_dataset("SELECT stud_hstry.stud_sl, stud.stud_nm, trad.trad_nm, sesion1.sesn_nm,semester.sem_nm FROM stud_hstry LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.stud_nm = '" & Trim(cmbstud.Text) & "')")
        If ds.Tables(0).Rows.Count <> 0 Then
            'txtstudnm.Text = "Name : " & ds.Tables(0).Rows(0).Item("stud_nm") & vbCrLf & "Session : " & ds.Tables(0).Rows(0).Item("sesn_nm") & vbCrLf & "Stream : " & ds.Tables(0).Rows(0).Item("trad_nm") & vbCrLf & "Class : " & ds.Tables(0).Rows(0).Item("sem_nm")
            txtstudsl.Text = ds.Tables(0).Rows(0).Item("stud_sl")
            GroupBox3.Text = "Name : " & ds.Tables(0).Rows(0).Item("stud_nm") & " Session : " & ds.Tables(0).Rows(0).Item("sesn_nm") & " Stream : " & ds.Tables(0).Rows(0).Item("trad_nm") & " Class : " & ds.Tables(0).Rows(0).Item("sem_nm")
            hddr = GroupBox3.Text
        End If
    End Sub

    Private Sub cmbstud_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstud.Validating
        conditn = ""
        If chkstrm.Checked = False Then
            conditn = "AND (stud_hstry.trad_cd=" & Val(txtstrmcd.Text) & ")"
        End If
        If chkclass.Checked = False Then
            conditn = conditn & " AND (stud_hstry.sem_cd=" & Val(txtacdncd.Text) & ")"
        End If
        vdating(cmbstud, "SELECT stud.stud_nm FROM stud RIGHT OUTER JOIN stud_hstry ON stud.stud_sl = stud_hstry.stud_sl WHERE (stud.stud_nm='" & Trim(cmbstud.Text) & "') AND (stud_hstry.active = 'Y') AND (stud_hstry.sesn_cd = " & Val(txtsesncd.Text) & ")" & conditn & "", "Please Select A Valid Student Name.")
    End Sub

    Private Sub chkstrm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkstrm.CheckedChanged
        If chkstrm.Checked = True Then
            cmbstrm.Text = "<<< All Stream >>>"
            cmbstrm.Enabled = False
            txtstrmcd.Text = 0
        Else
            cmbstrm.Text = ""
            cmbstrm.Enabled = True
            cmbstrm.Focus()
        End If
    End Sub

    Private Sub chkclass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkclass.CheckedChanged
        If chkclass.Checked = True Then
            cmbacdmyr.Text = "<<< All Class >>>"
            cmbacdmyr.Enabled = False
            txtacdncd.Text = 0
        Else
            cmbacdmyr.Text = ""
            cmbacdmyr.Enabled = True
            cmbacdmyr.Focus()
        End If
    End Sub

    Private Sub chkstud_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkstud.CheckedChanged
        If chkstud.Checked = True Then
            cmbstud.Text = "<<< All Student >>>"
            cmbstud.Enabled = False
            txtstudsl.Text = 0
            cmborder.Visible = True
            Label7.Visible = True
        Else
            cmbstud.Text = ""
            cmbstud.Enabled = True
            cmbstud.Focus()
            cmborder.Visible = False
            Label7.Visible = False
        End If
    End Sub


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
        dv.Columns.Clear()
        lblmsg.Visible = False
        dv.DataSource = Nothing
        If cmbsessn.Text = "" Then
            MessageBox.Show("Please Select A Session", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dv.DataSource = Nothing
            Exit Sub
        End If
        Start1()
        Dim ds As DataSet
        Dim ds1 As DataSet
        conditn = ""
        If chkstrm.Checked = False Then
            conditn = "AND (stud_hstry.trad_cd=" & Val(txtstrmcd.Text) & ")"
        End If
        If chkclass.Checked = False Then
            conditn = conditn & " AND (stud_hstry.sem_cd=" & Val(txtacdncd.Text) & ")"
        End If
        If chkstud.Checked = False Then
            'conditn = conditn & " AND (stud_hstry.stud_sl=" & Val(txtstudsl.Text) & ")"
            Me.stud_ledg()
            Exit Sub
        End If
        orderby = " stud.stud_nm"
        If cmborder.SelectedIndex = 1 Then
            orderby = " stud_hstry.reg_no"
        End If
        ds = get_dataset("SELECT  ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', stud_hstry.reg_no As 'Regd.No',stud.stud_nm As 'Student Name',sesion1.sesn_nm As 'Session',trad.trad_nm As 'Stream',semester. sem_nm As 'Class',STR(schd1.final_amt,10,2) As 'Final Amount',STR(schd1.final_amt,10,2) As 'Paid Amount',STR(schd1.final_amt,10,2) As 'Due Amount' FROM stud RIGHT OUTER JOIN stud_hstry ON stud.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd RIGHT OUTER JOIN schd1 ON stud_hstry.stud_sl = schd1.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.sesn_cd = " & Val(txtsesncd.Text) & ") " & conditn & " ORDER BY " & orderby & "")
        If ds.Tables(0).Rows.Count <> 0 Then
            Call pbstart()
            dv.DataSource = ds.Tables(0)
            MDI.pb.Maximum = dv.Rows.Count
            For i As Integer = 0 To dv.Rows.Count - 1
                regno = dv.Rows(i).Cells(1).Value
                fnlamt = Val(dv.Rows(i).Cells(6).Value)
                ds1 = get_dataset("SELECT (SUM(collrec1.tot_amt) + SUM(collrec1.disc_amt)) AS tot_amt FROM collrec1 LEFT OUTER JOIN stud ON collrec1.stud_sl = stud.stud_sl GROUP BY stud.reg_no HAVING (stud.reg_no = '" & regno & "')")
                paidamt = 0
                If ds1.Tables(0).Rows.Count <> 0 Then
                    paidamt = Val(ds1.Tables(0).Rows(0).Item(0))
                    dv.Rows(i).Cells(7).Value = Format(paidamt, "########0.00")
                Else
                    dv.Rows(i).Cells(7).Value = "0.00"
                End If
                dueamt = fnlamt - paidamt
                dv.Rows(i).Cells(8).Value = Format(Val(dueamt), "########0.00")
                Call pbincr()
            Next
            GroupBox3.Text = "Student Ledger Abstract"
            hddr = GroupBox3.Text
        Else
            lblmsg.Visible = True
        End If
        Close1()
        Call pbclose()
    End Sub


    Private Sub stud_ledg()
        ' Create an unbound DataGridView by declaring a column count.
        dv.ColumnCount = 9
        dv.ColumnHeadersVisible = True

        '' Set the column header style. 
        'Dim columnHeaderStyle As New DataGridViewCellStyle()

        'columnHeaderStyle.BackColor = Color.Beige
        'columnHeaderStyle.Font = New Font("Verdana", 10, FontStyle.Bold)
        'dv.ColumnHeadersDefaultCellStyle = columnHeaderStyle

        ' Set the column header names.
        dv.Columns(0).Name = "Sl."
        dv.Columns(1).Name = "Class"
        dv.Columns(2).Name = "Scrl No"
        dv.Columns(3).Name = "Date"
        dv.Columns(4).Name = "Transaction Details"
        dv.Columns(5).Name = "Finalized Amount"
        dv.Columns(6).Name = "Grace"
        dv.Columns(7).Name = "Paid Amount"
        dv.Columns(8).Name = "Due Amount"
        dv.Columns("Finalized Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dv.Columns("Grace").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dv.Columns("Paid Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dv.Columns("Due Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Dim rw As Integer = 0
        Start1()
        Dim ds As DataSet
        Dim ds1 As DataSet
        fnd = 0
        conditn = ""
        due_tot = 0
        coll_tot = 0
        bal_tot = 0
        If chkclass.Checked = False Then
            conditn = "WHERE (sem_cd=" & Val(txtacdncd.Text) & ")"
        End If
        Dim dssem As DataSet = get_dataset("SELECT sem_cd FROM semester " & conditn & " ORDER by sem_pos")
        If dssem.Tables(0).Rows.Count <> 0 Then
            For sem As Integer = 0 To dssem.Tables(0).Rows.Count - 1
                semcd = dssem.Tables(0).Rows(sem).Item(0)
                due_amt = 0
                coll_amt = 0
                If Val(bal_tot) <> 0 Then
                    dv.Rows.Add()
                    dv.Rows(rw).Cells(0).Value = rw + 1
                    dv.Rows(rw).Cells(1).Value = ""
                    dv.Rows(rw).Cells(2).Value = ""
                    dv.Rows(rw).Cells(3).Value = ""
                    dv.Rows(rw).Cells(4).Value = "Previous Due"
                    dv.Rows(rw).Cells(8).Value = Format(bal_tot, "########0.00")
                    due_amt = Format(bal_tot, "########0.00")
                    'dv.Rows(rw).Cells(8).Style.BackColor = Color.YellowGreen
                    dv.Rows(rw).Cells(8).Style.BackColor = Color.Red
                    dv.Rows(rw).Cells(8).Style.ForeColor = Color.White
                    rw = rw + 1
                End If
                ds = get_dataset("SELECT semester.sem_nm ,schd2.schd_no,schd2.due_dt,schd2.grace,coll.coll_nm,schd2.due_amt FROM coll RIGHT OUTER JOIN schd2 ON coll.coll_cd = schd2.coll_cd LEFT OUTER JOIN semester ON schd2.sem_cd = semester.sem_cd RIGHT OUTER JOIN stud ON schd2.stud_sl = stud.stud_sl WHERE(stud.stud_sl = " & Val(txtstudsl.Text) & ") AND semester.sem_cd=" & Val(semcd) & " ORDER BY schd2.due_dt,schd2.schd_no")
                If ds.Tables(0).Rows.Count <> 0 Then
                    fnd = 1
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        dv.Rows.Add()
                        dv.Rows(rw).Cells(0).Value = rw + 1
                        dv.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("sem_nm")
                        dv.Rows(rw).Cells(2).Value = "Sch-" & ds.Tables(0).Rows(i).Item("schd_no")
                        dv.Rows(rw).Cells(3).Value = Format(ds.Tables(0).Rows(i).Item("due_dt"), "dd/MM/yyyy")
                        dv.Rows(rw).Cells(4).Value = ds.Tables(0).Rows(i).Item("coll_nm")
                        dv.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(i).Item("due_amt"), "########0.00")
                        dv.Rows(rw).Cells(6).Value = ds.Tables(0).Rows(i).Item("grace")
                        'dv.Rows(rw).Cells(8).Value = Format(ds.Tables(0).Rows(i).Item("due_amt"), "########0.00")
                        due_amt = bal_tot + Val(ds.Tables(0).Rows(i).Item("due_amt"))
                        dv.Rows(rw).Cells(8).Value = due_amt
                        due_tot = due_tot + Val(ds.Tables(0).Rows(i).Item("due_amt"))
                        rw = rw + 1
                    Next
                    If due_amt <> 0 Then
                        dv.Rows(rw - 1).Cells(8).Style.BackColor = Color.YellowGreen
                        dv.Rows(rw - 1).Cells(8).Style.ForeColor = Color.White
                        dv.Rows(rw - 1).Cells(8).Value = Format(due_amt, "########0.00")
                    End If
                End If
                ds1 = get_dataset("SELECT semester.sem_nm, collrec2.coll_no, collrec2.coll_dt, coll.coll_nm, collrec2.coll_amt FROM coll RIGHT OUTER JOIN collrec2 ON coll.coll_cd = collrec2.coll_cd LEFT OUTER JOIN semester ON collrec2.sem_cd = semester.sem_cd RIGHT OUTER JOIN stud ON collrec2.stud_sl = stud.stud_sl WHERE(stud.stud_sl = " & Val(txtstudsl.Text) & ") AND semester.sem_cd=" & Val(semcd) & " ORDER BY collrec2.coll_dt,collrec2.coll_no")
                If ds1.Tables(0).Rows.Count <> 0 Then
                    fnd = 1
                    For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                        dv.Rows.Add()
                        dv.Rows(rw).Cells(0).Value = rw + 1
                        dv.Rows(rw).Cells(1).Value = ds1.Tables(0).Rows(i).Item("sem_nm")
                        dv.Rows(rw).Cells(2).Value = "Col-" & ds1.Tables(0).Rows(i).Item("coll_no")
                        dv.Rows(rw).Cells(3).Value = Format(ds1.Tables(0).Rows(i).Item("coll_dt"), "dd/MM/yyyy")
                        dv.Rows(rw).Cells(4).Value = ds1.Tables(0).Rows(i).Item("coll_nm")
                        dv.Rows(rw).Cells(7).Value = Format(ds1.Tables(0).Rows(i).Item("coll_amt"), "########0.00")
                        'dv.Rows(rw).Cells(8).Value = Format(ds1.Tables(0).Rows(i).Item("coll_amt"), "########0.00")

                        due_amt = Format(Val(due_amt) - Val(ds1.Tables(0).Rows(i).Item("coll_amt")), "########0.00")
                        dv.Rows(rw).Cells(8).Value = due_amt

                        coll_amt = coll_amt + Val(ds1.Tables(0).Rows(i).Item("coll_amt"))
                        coll_tot = coll_tot + Val(ds1.Tables(0).Rows(i).Item("coll_amt"))
                        rw = rw + 1
                    Next
                End If
                ds2 = get_dataset("SELECT SUM(collrec1.disc_amt) AS 'disc_amt' FROM collrec2 RIGHT OUTER JOIN collrec1 ON collrec2.coll_no = collrec1.coll_no LEFT OUTER JOIN stud ON collrec2.stud_sl = stud.stud_sl WHERE(stud.stud_sl = '" & Trim(txtstudsl.Text) & "') AND collrec2.sem_cd=" & Val(semcd) & "")
                If Not IsDBNull(ds2.Tables(0).Rows(0).Item("disc_amt")) Then
                    disc_amt = ds2.Tables(0).Rows(0).Item("disc_amt")
                    dv.Rows.Add()
                    dv.Rows(rw).Cells(0).Value = rw
                    dv.Rows(rw).Cells(0).Value = ""
                    dv.Rows(rw).Cells(1).Value = ""
                    dv.Rows(rw).Cells(2).Value = ""
                    dv.Rows(rw).Cells(3).Value = ""
                    dv.Rows(rw).Cells(4).Value = "Discount"

                    'dv.Rows(rw).Cells(5).Value = Format(due_amt, "########0.00")
                    dv.Rows(rw).Cells(7).Value = Format(disc_amt, "########0.00")
                    dv.Rows(rw).Cells(8).Value = Format(Val(due_amt) - Val(disc_amt), "########0.00")
                    'dv.Rows(rw).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Blue
                    coll_amt = coll_amt + Val(disc_amt)
                    coll_tot = coll_tot + Val(disc_amt)
                    bal_tot = bal_tot + (Val(due_amt) - Val(disc_amt))
                    rw = rw + 1
                    'Else
                    '    due_amt = 0
                End If
                If Val(due_amt) <> 0 Or Val(coll_amt) <> 0 Then
                    ds2 = get_dataset("SELECT SUM(schd2.due_amt) AS 'due_amt' FROM schd2 LEFT OUTER JOIN stud ON schd2.stud_sl = stud.stud_sl WHERE (stud.stud_sl = '" & Trim(txtstudsl.Text) & "') AND sem_cd=" & Val(semcd) & "")
                    If Not IsDBNull(ds2.Tables(0).Rows(0).Item("due_amt")) Then
                        due_amt = ds2.Tables(0).Rows(0).Item("due_amt")
                    Else
                        due_amt = 0
                    End If
                    dv.Rows.Add()
                    dv.Rows(rw).Cells(0).Value = rw
                    dv.Rows(rw).Cells(0).Value = ""
                    dv.Rows(rw).Cells(1).Value = ""
                    dv.Rows(rw).Cells(2).Value = ""
                    dv.Rows(rw).Cells(3).Value = ""
                    dv.Rows(rw).Cells(4).Value = "TOTAL"
                    dv.Rows(rw).Cells(5).Value = Format(due_amt, "########0.00")
                    dv.Rows(rw).Cells(7).Value = Format(coll_amt, "########0.00")
                    dv.Rows(rw).Cells(8).Value = Format(Val(due_amt) - Val(coll_amt), "########0.00")
                    dv.Rows(rw).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Blue
                    'bal_tot = bal_tot + (Val(due_amt) - Val(coll_amt))
                    rw = rw + 1
                End If
            Next
            If Val(due_tot) <> 0 Or Val(coll_tot) <> 0 Then
                dv.Rows.Add()
                dv.Rows(rw).Cells(0).Value = ""
                dv.Rows(rw).Cells(1).Value = ""
                dv.Rows(rw).Cells(2).Value = ""
                dv.Rows(rw).Cells(3).Value = ""
                dv.Rows(rw).Cells(4).Value = "GRAND TOTAL"
                dv.Rows(rw).Cells(5).Value = Format(due_tot, "########0.00")
                dv.Rows(rw).Cells(7).Value = Format(coll_tot, "########0.00")
                dv.Rows(rw).Cells(8).Value = Format(Val(due_tot - coll_tot), "########0.00")
                dv.Rows(rw).DefaultCellStyle.BackColor = Color.Pink
                dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Black
                rw = rw + 1
            End If
        End If
        Close1()
        If fnd = 0 Then
            dv.Columns.Clear()
            lblmsg.Visible = True
        End If
    End Sub

End Class
