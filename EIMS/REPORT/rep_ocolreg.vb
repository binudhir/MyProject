Imports vb = Microsoft.VisualBasic
Public Class rep_ocolreg
    Dim comd As String

    Private Sub rep_ocolreg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_ocolreg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_ocolreg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        startdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        enddt.Value = startdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        Me.Text = "Collection Register (Non Scheduled). . ."
        hddr = Me.Text
        txtsesncd.Text = 0
        txtstrmcd.Text = 0
        txtacdncd.Text = 0
        cmborder.SelectedIndex = 0
        cmbsessn.Focus()
        dv.DataSource = Nothing
        lblmsg.Visible = False
        dv.Visible = False
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
        key(cmborder, e)
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
        vdated(txtstudsl, "SELECT stud_sl FROM stud WHERE stud_nm='" & Trim(cmbstud.Text) & "'")
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
        Else
            cmbstud.Text = ""
            cmbstud.Enabled = True
            cmbstud.Focus()
        End If
    End Sub


    Private Sub chksesn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksesn.CheckedChanged
        If chksesn.Checked = True Then
            cmbsessn.Text = "<<< All Session >>>"
            cmbsessn.Enabled = False
            txtsesncd.Text = 0
        Else
            cmbsessn.Text = ""
            cmbsessn.Enabled = True
            cmbsessn.Focus()
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
        dv.Visible = True
        dv.Columns.Clear()
        dv.DataSource = Nothing
        'my code'
        dv.ColumnCount = 11
        dv.ColumnHeadersVisible = True
        dv.Columns(0).Name = "Sl."
        dv.Columns(1).Name = "Coll. No."
        dv.Columns(2).Name = "Coll. Date"
        dv.Columns(3).Name = "Regd. No."
        dv.Columns(4).Name = "Student Name"
        dv.Columns(5).Name = "Session"
        dv.Columns(6).Name = "Stream"
        dv.Columns(7).Name = "Class"
        dv.Columns(8).Name = "Account Type"
        dv.Columns(9).Name = "Amount"
        dv.Columns(10).Name = "Remark"
        Dim rw As Integer = 0
        Dim tot_coll As Integer = 0
        'end'
        Start1()
        Dim ds As DataSet
        conditn = ""
        If chksesn.Checked = False Then
            conditn = "AND (stud_hstry.sesn_cd=" & Val(txtsesncd.Text) & ")"
        End If
        If chkstrm.Checked = False Then
            conditn = conditn & "AND (stud_hstry.trad_cd=" & Val(txtstrmcd.Text) & ")"
        End If
        If chkclass.Checked = False Then
            conditn = conditn & " AND (stud_hstry.sem_cd=" & Val(txtacdncd.Text) & ")"
        End If
        If chkstud.Checked = False Then
            conditn = conditn & " AND (stud_hstry.stud_sl=" & Val(txtstudsl.Text) & ")"
        End If
        orderby = " stud.stud_nm"
        If cmborder.SelectedIndex = 1 Then
            orderby = " stud_hstry.reg_no"
        End If
        Call pbstart()
        'ds = get_dataset("SELECT  ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', collrec1.coll_no As 'Coll. No',CONVERT(VARCHAR,collrec1.coll_dt,103) As 'Coll.Date', stud_hstry.reg_no As 'Regd.No',stud.stud_nm As 'Student Name',sesion1.sesn_nm As 'Session',trad.trad_nm As 'Stream',semester. sem_nm As 'Class',(CASE WHEN collrec1.pay_mod='1' THEN 'Cash' WHEN collrec1.pay_mod='2' THEN 'DD/Cheque' END) As 'Account Type',STR(collrec1.tot_amt,10,2) As 'Amount',(CASE  WHEN collrec1.pay_mod='2' THEN collrec1.nb + collrec1.bank_nm WHEN collrec1.pay_mod='1' THEN collrec1.nb END) As 'Remark' FROM stud RIGHT OUTER JOIN stud_hstry ON stud.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd RIGHT OUTER JOIN collrec1 ON stud_hstry.stud_sl = collrec1.stud_sl WHERE (stud_hstry.active = 'Y') AND (collrec1.coll_dt>='" & Format(startdt.Value, "dd/MMM/yyyy") & "') AND (collrec1.coll_dt<='" & Format(enddt.Value, "dd/MMM/yyyy") & "') " & conditn & " ORDER BY " & orderby & "")
        ds = get_dataset("SELECT   ocollrec1.coll_no ,ocollrec1.coll_dt, stud_hstry.reg_no ,stud.stud_nm ,sesion1.sesn_nm ,trad.trad_nm ,semester. sem_nm ,ocollrec1.pay_mod,ocollrec1.tot_amt,ocollrec1.bank_nm,ocollrec1.nb  FROM stud RIGHT OUTER JOIN stud_hstry ON stud.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd RIGHT OUTER JOIN ocollrec1 ON stud_hstry.stud_sl = ocollrec1.stud_sl WHERE (stud_hstry.active = 'Y') AND (ocollrec1.coll_dt>='" & Format(startdt.Value, "dd/MMM/yyyy") & "') AND (ocollrec1.coll_dt<='" & Format(enddt.Value, "dd/MMM/yyyy") & "') " & conditn & " ORDER BY " & orderby & "")
        If ds.Tables(0).Rows.Count <> 0 Then
            MDI.pb.Maximum = ds.Tables(0).Rows.Count + 1
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv.Rows.Add()
                dv.Rows(rw).Cells(0).Value = rw + 1
                dv.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("coll_no")
                dv.Rows(rw).Cells(2).Value = Format(ds.Tables(0).Rows(i).Item("coll_dt"), "dd/MM/yyyy")
                dv.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("reg_no")
                dv.Rows(rw).Cells(4).Value = ds.Tables(0).Rows(i).Item("stud_nm")
                dv.Rows(rw).Cells(5).Value = ds.Tables(0).Rows(i).Item("sesn_nm")
                dv.Rows(rw).Cells(6).Value = ds.Tables(0).Rows(i).Item("trad_nm")
                dv.Rows(rw).Cells(7).Value = ds.Tables(0).Rows(i).Item("sem_nm")

                If ds.Tables(0).Rows(i).Item("pay_mod") = 1 Then
                    dv.Rows(rw).Cells(8).Value = "Cash"
                    dv.Rows(rw).Cells(10).Value = ds.Tables(0).Rows(i).Item("nb")
                Else
                    dv.Rows(rw).Cells(8).Value = "DD/Cheque"
                    dv.Rows(rw).Cells(10).Value = ds.Tables(0).Rows(i).Item("bank_nm") & "," & ds.Tables(0).Rows(i).Item("nb")
                End If
                dv.Rows(rw).Cells(9).Value = Format(ds.Tables(0).Rows(i).Item("tot_amt"), "#########.00")
                tot_coll = tot_coll + Val(ds.Tables(0).Rows(i).Item("tot_amt"))
                rw = rw + 1
                Call pbincr()
            Next
            If Val(tot_coll) <> 0 Then
                dv.Rows.Add()
                dv.Rows(rw).Cells(0).Value = ""
                dv.Rows(rw).Cells(1).Value = ""
                dv.Rows(rw).Cells(2).Value = ""
                dv.Rows(rw).Cells(3).Value = ""
                dv.Rows(rw).Cells(4).Value = ""
                dv.Rows(rw).Cells(5).Value = ""
                dv.Rows(rw).Cells(6).Value = ""
                dv.Rows(rw).Cells(7).Value = ""
                dv.Rows(rw).Cells(8).Value = "GRAND TOTAL"
                dv.Rows(rw).Cells(9).Value = Format(Val(tot_coll), "########0.00")
                dv.Rows(rw).Cells(10).Value = ""
                dv.Rows(rw).DefaultCellStyle.BackColor = Color.Pink
                dv.Rows(rw).DefaultCellStyle.ForeColor = Color.Black
                rw = rw + 1
            End If
            GroupBox3.Text = "Student Collection Register From (Non Scheduled)" & startdt.Value & " To " & enddt.Value
            hddr = GroupBox3.Text

        Else
            lblmsg.Visible = True
            dv.Visible = False
        End If
        Close1()
        Call pbstart()
    End Sub

End Class
