Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO
Public Class rep_studledg
    Dim comd As String
    Dim con_img As New SqlConnection(connectionstrng)
    Dim cmd_img As SqlCommand

    Private Sub rep_studledg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_studledg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_studledg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        'Me.clr()
    End Sub

    Private Sub clr()
        txtregdno.Text = ""
        txtstudnm.Text = ""
        If chkclass.Checked = False Then
            cmbacdmyr.Text = ""
        End If
        dv.Columns.Clear()
        lblmsg.Visible = False
    End Sub

    Private Sub cmborder_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregdno.Enter, cmbacdmyr.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub cmborder_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregdno.Leave, cmbacdmyr.Leave
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
        comd = "E"
        Me.clr()
        If dv.Visible = True Then
        End If
    End Sub

    Private Sub btnexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexport.Click
        Call excel_view(dv)
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

    Private Sub txtregdno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtregdno.KeyPress
        If cmbacdmyr.Enabled = True Then
            key(cmbacdmyr, e)
        Else
            key(btnview, e)
        End If
        SPKey(e)
    End Sub

    Private Sub cmbacdmyr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbacdmyr.KeyPress
        key(btnview, e)
        SPKey(e)
    End Sub

    Private Sub txtregdno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregdno.Validated
        If Trim(txtregdno.Text) <> "" Then
            Dim ds As DataSet = get_dataset("SELECT stud_hstry.stud_sl, stud.stud_nm, trad.trad_nm, sesion1.sesn_nm, DATALENGTH(stud.stud_image) AS stud_img, semester.sem_nm FROM stud_hstry LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.reg_no = '" & Trim(txtregdno.Text) & "')")
            If ds.Tables(0).Rows.Count <> 0 Then
                txtstudnm.Text = "Name : " & ds.Tables(0).Rows(0).Item("stud_nm") & vbCrLf & "Session : " & ds.Tables(0).Rows(0).Item("sesn_nm") & vbCrLf & "Stream : " & ds.Tables(0).Rows(0).Item("trad_nm") & vbCrLf & "Class : " & ds.Tables(0).Rows(0).Item("sem_nm")
                stud_sl = ds.Tables(0).Rows(0).Item("stud_sl")
                img_length = ds.Tables(0).Rows(0).Item("stud_img")
                GroupBox3.Text = "Name : " & ds.Tables(0).Rows(0).Item("stud_nm") & " Session : " & ds.Tables(0).Rows(0).Item("sesn_nm") & " Stream : " & ds.Tables(0).Rows(0).Item("trad_nm") & " Class : " & ds.Tables(0).Rows(0).Item("sem_nm")
                hddr = GroupBox3.Text
                If Val(img_length) <> 0 Then
                    Me.show_image(stud_sl)
                End If
            Else
                MessageBox.Show("Please Enter A Valid Regd. No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtregdno.Focus()
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

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        dv.Columns.Clear()
        lblmsg.Visible = False
        dv.Visible = True
        dv.DataSource = Nothing
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
        Dim ds2 As DataSet
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
                ds = get_dataset("SELECT semester.sem_nm ,schd2.schd_no,schd2.due_dt,schd2.grace,coll.coll_nm,schd2.due_amt FROM coll RIGHT OUTER JOIN schd2 ON coll.coll_cd = schd2.coll_cd LEFT OUTER JOIN semester ON schd2.sem_cd = semester.sem_cd RIGHT OUTER JOIN stud ON schd2.stud_sl = stud.stud_sl WHERE(stud.reg_no = '" & Trim(txtregdno.Text) & "') AND semester.sem_cd=" & Val(semcd) & " ORDER BY schd2.due_dt,schd2.schd_no")
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
                        dv.Rows(rw).Cells(8).Style.BackColor = Color.YellowGreen
                        'dv.Rows(rw).Cells(8).Value = Format(ds.Tables(0).Rows(i).Item("due_amt"), "########0.00")
                        due_amt = bal_tot + Val(ds.Tables(0).Rows(i).Item("due_amt"))
                        due_tot = due_tot + Val(ds.Tables(0).Rows(i).Item("due_amt"))
                        rw = rw + 1
                    Next
                    If due_amt <> 0 Then
                        dv.Rows(rw - 1).Cells(8).Style.BackColor = Color.YellowGreen
                        dv.Rows(rw - 1).Cells(8).Style.ForeColor = Color.White
                        dv.Rows(rw - 1).Cells(8).Value = Format(due_amt, "########0.00")
                    End If
                End If

                'SELECT semester.sem_nm, collrec2.coll_no, collrec2.coll_dt, coll.coll_nm, collrec2.coll_amt FROM coll RIGHT OUTER JOIN collrec2 ON coll.coll_cd = collrec2.coll_cd LEFT OUTER JOIN semester ON collrec2.sem_cd = semester.sem_cd RIGHT OUTER JOIN stud ON collrec2.stud_sl = stud.stud_sl WHERE(stud.reg_no = '" & Trim(txtregdno.Text) & "') AND semester.sem_cd=" & Val(semcd) & " ORDER BY collrec2.coll_dt,collrec2.coll_no
                ds1 = get_dataset("SELECT collrec2.coll_no, collrec2.coll_dt, collrec2.coll_amt,coll.coll_nm, semester.sem_nm FROM collrec2 LEFT OUTER JOIN stud ON collrec2.stud_sl = stud.stud_sl LEFT OUTER JOIN semester ON collrec2.sem_cd = semester.sem_cd LEFT OUTER JOIN coll ON collrec2.coll_cd = coll.coll_cd WHERE(stud.reg_no = '" & Trim(txtregdno.Text) & "') AND semester.sem_cd=" & Val(semcd) & " ORDER BY collrec2.coll_dt,collrec2.coll_no")
                If ds1.Tables(0).Rows.Count <> 0 Then
                    fnd = 1
                    ds2 = get_dataset("SELECT SUM(schd2.due_amt) AS 'due_amt' FROM schd2 LEFT OUTER JOIN stud ON schd2.stud_sl = stud.stud_sl WHERE (stud.reg_no = '" & Trim(txtregdno.Text) & "') AND sem_cd=" & Val(semcd) & "")
                    If Not IsDBNull(ds2.Tables(0).Rows(0).Item("due_amt")) Then
                        due_amt = bal_tot + ds2.Tables(0).Rows(0).Item("due_amt")
                    End If
                    For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                        dv.Rows.Add()
                        dv.Rows(rw).Cells(0).Value = rw + 1
                        dv.Rows(rw).Cells(1).Value = ds1.Tables(0).Rows(i).Item("sem_nm")
                        dv.Rows(rw).Cells(2).Value = "Col-" & ds1.Tables(0).Rows(i).Item("coll_no")
                        dv.Rows(rw).Cells(3).Value = Format(ds1.Tables(0).Rows(i).Item("coll_dt"), "dd/MM/yyyy")
                        dv.Rows(rw).Cells(4).Value = ds1.Tables(0).Rows(i).Item("coll_nm")
                        dv.Rows(rw).Cells(7).Value = Format(ds1.Tables(0).Rows(i).Item("coll_amt"), "########0.00")
                        due_amt = Format(Val(due_amt) - ds1.Tables(0).Rows(i).Item("coll_amt"), "########0.00")
                        dv.Rows(rw).Cells(8).Value = due_amt
                        coll_amt = coll_amt + Val(ds1.Tables(0).Rows(i).Item("coll_amt"))
                        coll_tot = coll_tot + Val(ds1.Tables(0).Rows(i).Item("coll_amt"))
                        rw = rw + 1
                    Next
                End If

                ds2 = get_dataset("SELECT SUM(collrec1.disc_amt) AS 'disc_amt' FROM collrec2 RIGHT OUTER JOIN collrec1 ON collrec2.coll_no = collrec1.coll_no LEFT OUTER JOIN stud ON collrec2.stud_sl = stud.stud_sl WHERE(stud.reg_no = '" & Trim(txtregdno.Text) & "') AND collrec2.sem_cd=" & Val(semcd) & "")
                If Not IsDBNull(ds2.Tables(0).Rows(0).Item("disc_amt")) Then
                    disc_amt = ds2.Tables(0).Rows(0).Item("disc_amt")
                    dv.Rows.Add()
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
                    bal_tot = bal_tot + (Val(due_amt) - Val(disc_amt))
                    rw = rw + 1
                    'Else
                    '    due_amt = 0
                End If






                If Val(due_amt) <> 0 Or Val(coll_amt) <> 0 Then
                    ds2 = get_dataset("SELECT SUM(schd2.due_amt) AS 'due_amt' FROM schd2 LEFT OUTER JOIN stud ON schd2.stud_sl = stud.stud_sl WHERE (stud.reg_no = '" & Trim(txtregdno.Text) & "') AND sem_cd=" & Val(semcd) & "")
                    If Not IsDBNull(ds2.Tables(0).Rows(0).Item("due_amt")) Then
                        due_amt = ds2.Tables(0).Rows(0).Item("due_amt")
                    Else
                        due_amt = 0
                    End If
                    dv.Rows.Add()
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
                    bal_tot = bal_tot + (Val(due_amt) - Val(coll_amt))
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
            dv.Visible = False
            lblmsg.Visible = True
        End If

    End Sub

    Private Sub chkparty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkclass.CheckedChanged
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

    Private Sub txtregdno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtregdno.GotFocus
        Me.clr()
    End Sub

End Class
