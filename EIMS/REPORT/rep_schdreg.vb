Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO
Public Class rep_schdreg
    Dim comd As String
    Dim con_img As New SqlConnection(connectionstrng)
    Dim cmd_img As SqlCommand

    Private Sub rep_schdreg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_schdreg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_schdreg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
    End Sub

    Private Sub clr()
        txtregdno.Text = ""
        txtstudnm.Text = ""
        startdt.Value = stdt
        enddt.Value = endt
        lblmsg.Visible = False
    End Sub

    Private Sub cmborder_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregdno.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmborder_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregdno.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

    End Sub

    Private Sub btncalc_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnrfresh.MouseEnter, btnexport.MouseEnter, btnexit.MouseEnter, btncalc.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btncalc_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnrfresh.MouseLeave, btnexport.MouseLeave, btnexit.MouseLeave, btncalc.MouseLeave
        sender.forecolor = Color.Red
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

    Private Sub txtregdno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtregdno.KeyPress
        key(startdt, e)
        SPKey(e)
    End Sub

    Private Sub txtregdno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregdno.Validated
        Dim ds As DataSet = get_dataset("SELECT stud_hstry.stud_sl, stud.stud_nm, trad.trad_nm, sesion1.sesn_nm, DATALENGTH(stud.stud_image) AS stud_img, semester.sem_nm FROM stud_hstry LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.reg_no = '" & Trim(txtregdno.Text) & "')")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtstudnm.Text = "Name : " & ds.Tables(0).Rows(0).Item("stud_nm") & vbCrLf & "Session : " & ds.Tables(0).Rows(0).Item("sesn_nm") & vbCrLf & "Branch : " & ds.Tables(0).Rows(0).Item("trad_nm") & vbCrLf & "Class : " & ds.Tables(0).Rows(0).Item("sem_nm")
            stud_sl = ds.Tables(0).Rows(0).Item("stud_sl")
            img_length = ds.Tables(0).Rows(0).Item("stud_img")
            If Val(img_length) <> 0 Then
                Me.show_image(stud_sl)
            End If
        End If
    End Sub

    Private Sub show_image(ByVal slno As Integer)
        Dim cmd_img As New SqlCommand("SELECT stud_image FROM stud WHERE stud_sl=" & Val(slno) & " ", con_img)
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
        pict1.Size = New Size(90, 90)
    End Sub

    Private Sub pict1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pict1.MouseLeave
        pict1.Size = New Size(60, 64)
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregdno.Enter, txtstudnm.Enter, txtregdno.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregdno.Leave, txtstudnm.Leave, txtregdno.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

    End Sub

    Private Sub startdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startdt.KeyPress
        key(enddt, e)
    End Sub

    Private Sub enddt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles enddt.KeyPress
        key(btnview, e)
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        dv.DataSource = Nothing
        lblmsg.Visible = False
        Start1()
        Dim ds As DataSet
        ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY schd2.due_dt) AS 'Sl.',stud.stud_nm AS 'Student Name', stud_hstry.reg_no AS 'Regd.No', semester.sem_nm AS 'Class',coll.coll_nm AS 'Collection Name',STR(schd2.due_amt,10,2) AS 'Due Amount', CONVERT(VARCHAR,schd2.due_dt,103) AS 'Due Date', schd2.grace AS 'Grace' FROM schd1 LEFT OUTER JOIN semester RIGHT OUTER JOIN stud_hstry ON semester.sem_cd = stud_hstry.sem_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl ON schd1.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN coll RIGHT OUTER JOIN schd2 ON coll.coll_cd = schd2.coll_cd ON schd1.schd_no = schd2.schd_no WHERE (stud_hstry.active = 'Y') AND (stud_hstry.reg_no = '" & Trim(txtregdno.Text) & "') AND (schd2.due_dt>='" & Format(startdt.Value, "dd/MMM/yyyy") & "') AND (schd2.due_dt<='" & Format(enddt.Value, "dd/MMM/yyyy") & "') ORDER BY schd2.due_dt")
        If ds.Tables(0).Rows.Count <> 0 Then
            GroupBox3.Text = "Student Payment Schedule Of Regd. No :-" & txtregdno.Text & " From " & startdt.Value & " To " & enddt.Value
            hddr = GroupBox3.Text
            dv.DataSource = ds.Tables(0)
        Else
            lblmsg.Visible = True
        End If
        Close1()
    End Sub
End Class
