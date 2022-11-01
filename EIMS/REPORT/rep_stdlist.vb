Imports vb = Microsoft.VisualBasic
Public Class rep_stdlist
    Dim comd As String

    Private Sub rep_stdlist_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_stdlist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_stdlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
    End Sub

    Private Sub clr()
        Me.Text = "Student List. . ."
        hddr = Me.Text
        txtsesncd.Text = 0
        txtstrmcd.Text = 0
        txtacdncd.Text = 0
        cmbsessn.Text = ""
        cmbgndr.SelectedIndex = 0
        cmbhostel.SelectedIndex = 0
        cmbcaste.SelectedIndex = 0
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
    End Sub

    Private Sub cmborder_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstrm.Enter, cmbsessn.Enter, cmborder.Enter, cmbhostel.Enter, cmbgndr.Enter, cmbacdmyr.Enter, cmbcaste.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmborder_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstrm.Leave, cmbsessn.Leave, cmborder.Leave, cmbhostel.Leave, cmbgndr.Leave, cmbacdmyr.Leave, cmbcaste.Leave

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
        key(cmbgndr, e)
        SPKey(e)
    End Sub

    Private Sub cmbgndr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgndr.KeyPress
        key(cmbhostel, e)
        SPKey(e)
    End Sub

    Private Sub cmbhostel_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbhostel.KeyPress
        key(cmbcaste, e)
        SPKey(e)
    End Sub

    Private Sub cmbcaste_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcaste.KeyPress
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
        vdating(cmbstrm, "SELECT trad_nm FROM trad WHERE trad_nm='" & Trim(cmbstrm.Text) & "' AND rec_lock='N'", "Please Select A Valid Branch Name.")
    End Sub

    Private Sub chkstrm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkstrm.CheckedChanged
        If chkstrm.Checked = True Then
            cmbstrm.Text = "<<< All Branch >>>"
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
        conditn = ""
        If chkstrm.Checked = False Then
            conditn = "AND (stud_hstry.trad_cd=" & Val(txtstrmcd.Text) & ")"
        End If
        If chkclass.Checked = False Then
            conditn = conditn & " AND (stud_hstry.sem_cd=" & Val(txtacdncd.Text) & ")"
        End If
        If cmbgndr.SelectedIndex <> 0 Then
            conditn = conditn & " AND (stud.gndr='" & vb.Left(cmbgndr.Text, 1) & "')"
        End If
        If cmbhostel.SelectedIndex <> 0 Then
            conditn = conditn & " AND (stud.hostel_req='" & vb.Left(cmbhostel.Text, 1) & "')"
        End If
        If cmbcaste.SelectedIndex <> 0 Then
            conditn = conditn & " AND (stud.stud_caste='" & vb.Left(cmbcaste.Text, 1) & "')"
        End If
        orderby = " stud.stud_nm"
        If cmborder.SelectedIndex = 1 Then
            orderby = " stud_hstry.reg_no"
        End If
        If chkabst.Checked = False Then
            ds = get_dataset("SELECT  ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.',  stud.reg_no As 'Regd.No', stud.stud_nm AS 'Student Name',trad.trad_nm AS 'Stream', semester.sem_nm AS 'Class', stud.council_reg As 'Council No', CONVERT(VARCHAR,stud.dob,103) As 'Date Of Birth',stud.fathr_nm As 'Father Name',stud.pre_add1 As 'Address', dist.dist_nm As 'District',stat.stat_nm As 'State', stud.pre_ph1 As 'Stud Mob', stud.per_ph1 As 'Father Mob',stud.email As 'Email',stud.gndr As 'M/F',(CASE  WHEN stud_caste=1 THEN 'Gen' WHEN stud_caste=2 THEN 'ST' WHEN stud_caste=3 THEN 'SC' WHEN stud_caste=4 THEN 'OBC' END) As 'Caste',(CASE WHEN stud.hostel_req='N' Then 'No' WHEN stud.hostel_req='Y' Then 'Yes' END) As 'Hostel'  FROM semester RIGHT OUTER JOIN stud_hstry ON semester.sem_cd = stud_hstry.sem_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN dist LEFT OUTER JOIN stat ON dist.stat_cd = stat.stat_cd RIGHT OUTER JOIN stud ON dist.dist_cd = stud.pre_dist_cd ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.sesn_cd = " & Val(txtsesncd.Text) & ")" & conditn & " ORDER BY " & orderby & "")
        Else
            ds = get_dataset("SELECT  ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.',  stud.reg_no As 'Regd.No', stud.stud_nm AS 'Student Name',trad.trad_nm AS 'Stream', semester.sem_nm AS 'Class',stud.pre_add1 As 'Address', dist.dist_nm As 'District',stat.stat_nm As 'State', stud.pre_ph1 As 'Stud Mob', stud.email As 'Email',stud.gndr As 'M/F' FROM semester RIGHT OUTER JOIN stud_hstry ON semester.sem_cd = stud_hstry.sem_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN dist LEFT OUTER JOIN stat ON dist.stat_cd = stat.stat_cd RIGHT OUTER JOIN stud ON dist.dist_cd = stud.pre_dist_cd ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.sesn_cd = " & Val(txtsesncd.Text) & ")" & conditn & " ORDER BY " & orderby & "")
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
        Else
            lblmsg.Visible = True
        End If
        Close1()
    End Sub


End Class
