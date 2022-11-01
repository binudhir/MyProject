Imports vb = Microsoft.VisualBasic
Public Class frmstudsearch
    Dim comd As String

    Private Sub frmstudsearch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmstudsearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmstudsearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
    End Sub

    Private Sub clr()
        txtsearch.Text = ""
        cmbstudserch.SelectedIndex = 0
        Me.Text = "Find a Student at a Glance . . . "
    End Sub
#Region "Enter/Leave"
    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstudserch.Enter, txtsearch.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstudserch.Leave, txtsearch.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrfresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrfresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrfresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrfresh.Click
        Me.clr()
    End Sub

    Private Sub cmbstudserch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstudserch.KeyPress
        key(txtsearch, e)
        SPKey(e)
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        Me.search()
    End Sub

    Private Sub search()
        Dim dssearch As DataSet
        dv.Columns.Clear()
        If txtsearch.Text <> "" Then
            If chkexact.Checked = True Then
                If cmbstudserch.SelectedIndex = 0 Then
                    dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud.stud_nm) AS 'Sl.',stud.reg_no AS 'Regd No.', stud.stud_nm AS 'Student Name', stud.council_reg AS 'Council Regd.', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch', sesion1.sesn_nm AS 'Session', stud.fathr_nm AS 'Father Name', stud.per_ph1 AS 'Contact No.', stud.per_add1 AS 'Address' FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.stud_nm LIKE '" & Trim(txtsearch.Text) & "%') ORDER BY stud.stud_nm")
                ElseIf cmbstudserch.SelectedIndex = 1 Then
                    dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud.reg_no) AS 'Sl.',stud.reg_no AS 'Regd No.', stud.stud_nm AS 'Student Name', stud.council_reg AS 'Council Regd.', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch', sesion1.sesn_nm AS 'Session', stud.fathr_nm AS 'Father Name', stud.per_ph1 AS 'Contact No.', stud.per_add1 AS 'Address' FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.reg_no LIKE '" & Trim(txtsearch.Text) & "%') ORDER BY stud.reg_no")
                ElseIf cmbstudserch.SelectedIndex = 2 Then
                    dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud.council_reg) AS 'Sl.',stud.reg_no AS 'Regd No.', stud.stud_nm AS 'Student Name', stud.council_reg AS 'Council Regd.', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch', sesion1.sesn_nm AS 'Session', stud.fathr_nm AS 'Father Name', stud.per_ph1 AS 'Contact No.', stud.per_add1 AS 'Address' FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.council_reg LIKE '" & Trim(txtsearch.Text) & "%') ORDER BY stud.council_reg")
                ElseIf cmbstudserch.SelectedIndex = 3 Then
                    dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud.fathr_nm) AS 'Sl.',stud.reg_no AS 'Regd No.', stud.stud_nm AS 'Student Name', stud.council_reg AS 'Council Regd.', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch', sesion1.sesn_nm AS 'Session', stud.fathr_nm AS 'Father Name', stud.per_ph1 AS 'Contact No.', stud.per_add1 AS 'Address' FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.fathr_nm LIKE '" & Trim(txtsearch.Text) & "%') ORDER BY stud.fathr_nm")
                ElseIf cmbstudserch.SelectedIndex = 4 Then
                    dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud.per_ph1) AS 'Sl.',stud.reg_no AS 'Regd No.', stud.stud_nm AS 'Student Name', stud.council_reg AS 'Council Regd.', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch', sesion1.sesn_nm AS 'Session', stud.fathr_nm AS 'Father Name', stud.per_ph1 AS 'Contact No.', stud.per_add1 AS 'Address' FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.per_ph1 LIKE '" & Trim(txtsearch.Text) & "%') ORDER BY stud.per_ph1")
                Else
                    dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud.per_add1) AS 'Sl.',stud.reg_no AS 'Regd No.', stud.stud_nm AS 'Student Name', stud.council_reg AS 'Council Regd.', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch', sesion1.sesn_nm AS 'Session', stud.fathr_nm AS 'Father Name', stud.per_ph1 AS 'Contact No.', stud.per_add1 AS 'Address' FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.per_add1 LIKE '" & Trim(txtsearch.Text) & "%') ORDER BY stud.per_add1")
                End If
            Else
                If cmbstudserch.SelectedIndex = 0 Then
                    dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud.stud_nm) AS 'Sl.',stud.reg_no AS 'Regd No.', stud.stud_nm AS 'Student Name', stud.council_reg AS 'Council Regd.', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch', sesion1.sesn_nm AS 'Session', stud.fathr_nm AS 'Father Name', stud.per_ph1 AS 'Contact No.', stud.per_add1 AS 'Address' FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.stud_nm LIKE '%" & Trim(txtsearch.Text) & "%') ORDER BY stud.stud_nm")
                ElseIf cmbstudserch.SelectedIndex = 1 Then
                    dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud.reg_no) AS 'Sl.',stud.reg_no AS 'Regd No.', stud.stud_nm AS 'Student Name', stud.council_reg AS 'Council Regd.', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch', sesion1.sesn_nm AS 'Session', stud.fathr_nm AS 'Father Name', stud.per_ph1 AS 'Contact No.', stud.per_add1 AS 'Address' FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.reg_no LIKE '%" & Trim(txtsearch.Text) & "%') ORDER BY stud.reg_no")
                ElseIf cmbstudserch.SelectedIndex = 2 Then
                    dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud.council_reg) AS 'Sl.',stud.reg_no AS 'Regd No.', stud.stud_nm AS 'Student Name', stud.council_reg AS 'Council Regd.', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch', sesion1.sesn_nm AS 'Session', stud.fathr_nm AS 'Father Name', stud.per_ph1 AS 'Contact No.', stud.per_add1 AS 'Address' FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.council_reg LIKE '%" & Trim(txtsearch.Text) & "%') ORDER BY stud.council_reg")
                ElseIf cmbstudserch.SelectedIndex = 3 Then
                    dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud.fathr_nm) AS 'Sl.',stud.reg_no AS 'Regd No.', stud.stud_nm AS 'Student Name', stud.council_reg AS 'Council Regd.', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch', sesion1.sesn_nm AS 'Session', stud.fathr_nm AS 'Father Name', stud.per_ph1 AS 'Contact No.', stud.per_add1 AS 'Address' FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.fathr_nm LIKE '%" & Trim(txtsearch.Text) & "%') ORDER BY stud.fathr_nm")
                ElseIf cmbstudserch.SelectedIndex = 4 Then
                    dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud.per_ph1) AS 'Sl.',stud.reg_no AS 'Regd No.', stud.stud_nm AS 'Student Name', stud.council_reg AS 'Council Regd.', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch', sesion1.sesn_nm AS 'Session', stud.fathr_nm AS 'Father Name', stud.per_ph1 AS 'Contact No.', stud.per_add1 AS 'Address' FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.per_ph1 LIKE '%" & Trim(txtsearch.Text) & "%') ORDER BY stud.per_ph1")
                Else
                    dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY stud.per_add1) AS 'Sl.',stud.reg_no AS 'Regd No.', stud.stud_nm AS 'Student Name', stud.council_reg AS 'Council Regd.', semester.sem_nm AS 'Class', trad.trad_nm AS 'Branch', sesion1.sesn_nm AS 'Session', stud.fathr_nm AS 'Father Name', stud.per_ph1 AS 'Contact No.', stud.per_add1 AS 'Address' FROM trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud.per_add1 LIKE '%" & Trim(txtsearch.Text) & "%') ORDER BY stud.per_add1")
                End If
            End If
            If dssearch.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dssearch.Tables(0)
                'dv.Columns(1).ReadOnly = True
            Else
                MessageBox.Show("Sorry No Data Found. Please Search In Different Catagories. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        
    End Sub

    Private Sub chkexact_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkexact.CheckedChanged
        Me.search()
    End Sub
End Class