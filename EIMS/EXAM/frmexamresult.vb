Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class frmexamresult
    Dim comd As String = "E"
    Dim con_img As New SqlConnection(connectionstrng)
    Dim cmd_img As SqlCommand

    Private Sub frmexamresult_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnubkscrl.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmexamresult_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmexamresult_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black
        End If
    End Sub

    Private Sub frmexamresult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnubkscrl.Enabled = False
        Me.clr()
    End Sub

    Private Sub clr()
        txtregdno.Text = ""
        txtseson.Text = ""
        txtstudnm.Text = ""
        txttrde.Text = ""
        cmbexmnm.Text = ""
        cmbacyr.Text = ""
        txtmark1.Text = "0.00"
        txtmark2.Text = "0.00"
        txtmark3.Text = "0.00"
        cmbpresnt.SelectedIndex = 0
        dv.Rows.Clear()
        pict1.BackgroundImage = My.Resources.photo
        If comd = "E" Then
            Me.Text = "Exam Results Entry Screen . . ."
            Dim ds As DataSet = get_dataset("SELECT max(coll_no) as 'Max' FROM collrec1")
            txtresltno.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtresltno.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
            btnsave.Text = "Save"
        ElseIf comd = "M" Then
            Me.Text = "Exam Results Modification Screen . . ."
            txtresltno.Text = ""
            btnsave.Text = "Modify"
        Else
            Me.Text = "Exam Results Deletion Screen . . ."
            txtresltno.Text = ""
            btnsave.Text = "Delete"
        End If
        txtregdno.Focus()
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        comd = "E"
        Me.clr()
        'Me.dv_disp()
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        prtnm = InputBox("Enter The Regd. No.", "Search Box...", Nothing)
        If (prtnm Is Nothing OrElse prtnm = "") Then
            'User hit cancel
        Else
            Dim dssear As DataSet = get_dataset("SELECT collrec1.coll_no AS 'Coll. No.',  CONVERT(VARCHAR,collrec1.coll_dt,103) AS 'Date', stud_hstry.reg_no AS 'Regd. No.',stud.stud_nm AS 'Stud. Name', sesion1.sesn_nm AS 'Session',trad.trad_nm AS 'Branch', (CASE WHEN collrec1.pay_mod='1' THEN 'Cash' WHEN collrec1.pay_mod='2' THEN 'DD/Cheque' END) AS 'Pay Mode' ,STR(collrec1.tot_amt,10,2) AS 'Amount' FROM stud RIGHT OUTER JOIN stud_hstry ON stud.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd RIGHT OUTER JOIN collrec1 ON stud_hstry.stud_sl = collrec1.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.reg_no LIKE'" & prtnm & "%') ORDER BY stud_hstry.reg_no")
            dv.Columns.Clear()
            If dssear.Tables(0).Rows.Count <> 0 Then
                dv.DataSource = dssear.Tables(0)
                dv.Columns(7).CellTemplate.Style.Alignment = DataGridViewContentAlignment.BottomRight
            End If
            dv.Visible = True
            dv.Dock = DockStyle.Fill
        End If
    End Sub

#Region "Enter/Leave"
    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmark1.Enter, txtmark2.Enter, txtregdno.Enter, cmbacyr.Enter, cmbexmnm.Enter, cmbpresnt.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmark1.Leave, txtmark2.Leave, txtregdno.Leave, cmbacyr.Leave, cmbexmnm.Leave, cmbpresnt.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub
#End Region

#Region "Mouse Enter/Leave"
    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter, btnview.MouseEnter, btnswap.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave, btnview.MouseLeave, btnswap.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "Key Press"
    Private Sub txtregdno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtregdno.KeyPress
        key(dtexam, e)
        SPKey(e)
    End Sub

    Private Sub dtexam_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtexam.KeyPress
        key(cmbacyr, e)
    End Sub

    Private Sub cmbacyr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbacyr.KeyPress
        key(cmbpresnt, e)
        SPKey(e)
    End Sub

    Private Sub cmbpresnt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbpresnt.KeyPress
        key(cmbexmnm, e)
        SPKey(e)
    End Sub

    Private Sub cmbexmnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbexmnm.KeyPress
        key(dv, e)
        SPKey(e)
    End Sub
#End Region

    Private Sub cmbacyr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacyr.GotFocus
        populate(cmbacyr, "SELECT sem_nm FROM semester WHERE rec_lock='N' ORDER BY sem_pos")
    End Sub

    Private Sub cmbacyr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacyr.LostFocus
        cmbacyr.Height = 21
    End Sub

    Private Sub cmbacyr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbacyr.Validated
        vdated(txtacmcd, "SELECT sem_cd FROM semester WHERE sem_nm='" & Trim(cmbacyr.Text) & "'")
    End Sub

    Private Sub cmbacyr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbacyr.Validating
        vdating(cmbacyr, "SELECT sem_nm FROM semester WHERE sem_nm='" & Trim(cmbacyr.Text) & "' AND rec_lock='N'", "Please Select A Valid Sem/Ac.Year Name.")
    End Sub

    Private Sub txtregdno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtregdno.Validating
        vdating(txtregdno, "SELECT schd1.* FROM schd1 LEFT OUTER JOIN stud ON schd1.stud_sl = stud.stud_sl where stud.reg_no='" & Trim(txtregdno.Text) & "'", "Please Make Payment Schedule For This Student.")
    End Sub

    Private Sub txtredg_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtregdno.Validated
        If Trim(txtregdno.Text) <> "" Then
            Start1()
            Dim ds As DataSet = get_dataset("SELECT stud_hstry.stud_sl, stud_hstry.sesn_cd,stud_hstry.sem_cd, stud.stud_nm, DATALENGTH(stud.stud_image) AS stud_img, trad.trad_nm, sesion1.sesn_nm, sesion1.sesn_dt1, sesion1.sesn_dt2, semester.sem_nm FROM stud_hstry LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.reg_no = '" & Trim(txtregdno.Text) & "')")
            If ds.Tables(0).Rows.Count <> 0 Then
                txtstudnm.Text = ds.Tables(0).Rows(0).Item("stud_nm")
                txtseson.Text = ds.Tables(0).Rows(0).Item("sesn_nm")
                txttrde.Text = ds.Tables(0).Rows(0).Item("trad_nm")
                cmbacyr.Text = ds.Tables(0).Rows(0).Item("sem_nm")
                txtstudsl.Text = ds.Tables(0).Rows(0).Item("stud_sl")
                txtsesncd.Text = ds.Tables(0).Rows(0).Item("sesn_cd")
                txtacmcd.Text = ds.Tables(0).Rows(0).Item("sem_cd")
                img_length = ds.Tables(0).Rows(0).Item("stud_img")
                If Val(img_length) <> 0 Then
                    Me.show_image()
                End If
            Else
                MessageBox.Show("Please Enter A Valid Regd. No", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtregdno.Focus()
            End If
            Close1()
        End If
    End Sub

    Private Sub show_image()
        Dim cmd_img As New SqlCommand("SELECT stud_image FROM stud WHERE stud_sl=" & Val(txtstudsl.Text) & " ", con_img)
        cmd_img.Parameters.AddWithValue("stud_image", 3)
        Try
            con_img.Open()
            pict1.SizeMode = PictureBoxSizeMode.StretchImage
            pict1.BackgroundImage = Image.FromStream(New IO.MemoryStream(CType(cmd_img.ExecuteScalar, Byte())))
            ' or you can save in a file 
            IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\stud.jpg", CType(cmd_img.ExecuteScalar, Byte()))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con_img.Close()
        End Try
    End Sub

    Private Sub pict1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pict1.MouseEnter
        pict1.Size = New Size(150, 160)
    End Sub

    Private Sub pict1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pict1.MouseLeave
        pict1.Size = New Size(40, 40)
    End Sub


    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        comd = "E"
        Me.clr()

    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        'If Val(txtcollno.Text) = 0 Then
        '    MessageBox.Show("Sorry The Collection No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtcollno.Focus()
        '    Exit Sub
        'End If
        If Trim(txtregdno.Text) = "" Then
            MessageBox.Show("Sorry The Regd. No. Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtregdno.Focus()
            Exit Sub
        End If
        'If cmbmode.SelectedIndex = 1 Then
        '    If Trim(txtbanknm.Text) = "" Then
        '        MessageBox.Show("Sorry The Bank Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        bank_panel.Visible = True
        '        txtbanknm.Focus()
        '        Exit Sub
        '    End If
        '    If Trim(txtchqno.Text) = "" Then
        '        MessageBox.Show("Sorry The Cheque No. Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        bank_panel.Visible = True
        '        txtchqno.Focus()
        '        Exit Sub
        '    End If
        '    If Trim(cmbpname.Text) = "" Or Val(txtprtcd.Text) = 0 Then
        '        MessageBox.Show("Sorry The Bankers Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        cmbpname.Focus()
        '        Exit Sub
        '    End If
        'End If
        'If Val(txttotamt.Text) = 0 Then
        '    MessageBox.Show("Sorry The Collection Amount Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    dvcoll.Focus()
        '    Exit Sub
        'End If
        'If Val(txtfinlamt.Text) < Val(txtpaidamt.Text) + Val(txttotamt.Text) + Val(txttotdisc.Text) + Val(txtdisc.Text) Then
        '    MessageBox.Show("Sorry You Can't Collect More Than Final Amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        'Me.pay_save()

    End Sub


    '    Private Sub dv1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '        For i As Integer = 0 To dv1.Rows.Count - 1
    '            If Trim(dv1.Rows(i).Cells(1).Value) <> "" Then
    '                scroll_nm = Trim(dv1.Rows(i).Cells(1).Value)
    '                Dim ds As DataSet = get_dataset("SELECT book1.book_nm FROM book1 LEFT OUTER JOIN book2 ON book1.book_cd = book2.book_cd WHERE (book2.scroll_nm = '" & scroll_nm & "')")
    '                If ds.Tables(0).Rows.Count <> 0 Then
    '                    book_nm = ds.Tables(0).Rows(0).Item(0)
    '                    MessageBox.Show("Sorry The Scroll No. :- " & scroll_nm & " is Already Assigned to The Book - " & book_nm, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    dv1.Rows(i).DefaultCellStyle.BackColor = Color.LightPink
    '                    dv1.Rows(i).Cells(1).Value = ""
    '                    dv1.Focus()
    '                Else
    '                    dv1.Rows(i).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
    '                End If
    '            End If
    '        Next
    '    End Sub


End Class
