Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO

Public Class frmstuddoc
    Dim comd As String
    Dim rootpath As String = ""
    Dim imgnm As String = ""
    Dim con_img As New SqlConnection(connectionstrng)
    Dim cmd_img As SqlCommand

#Region "Start Up"

    Private Sub frmstuddoc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuupload.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmstuddoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmstuddoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuupload.Enabled = False
        grppreview.Dock = DockStyle.Fill
        Me.clr()
    End Sub

    Private Sub frmstuddoc_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        comd = "E"
        txtstudsl.Text = 0
        txtstudsl1.Text = 0
        txtdoccd.Text = 0
        cmbtype.SelectedIndex = 0
        txtdoc.Text = ""
        txtregdno1.Text = ""
        txtregdno.Text = ""
        txtstudnm.Text = ""
        txtstudnm1.Text = ""
        txtphoto.Text = "N"
        dvupld.Rows.Clear()
        dvdnld.Rows.Clear()
        pictupld.BackgroundImage = Nothing
        studimg.BackgroundImage = Nothing
        pictdnld.BackgroundImage = Nothing
        studimg1.BackgroundImage = Nothing
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdoc.Enter, txtregdno1.Enter, txtregdno.Enter, txtstudnm.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdoc.Leave, txtregdno1.Leave, txtregdno.Leave, txtstudnm.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.MouseEnter, btnexit.MouseEnter, btnupload.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.MouseLeave, btnexit.MouseLeave, btnupload.MouseLeave
        sender.forecolor = Color.Red
    End Sub

#End Region

#Region "Buttonns"

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
    End Sub

    Private Sub btnupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupload.Click
        If TabControl1.SelectedIndex = 0 Then
            If Trim(txtdoc.Text) = "" Then
                MessageBox.Show("The Doccument Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtdoc.Focus()
                Exit Sub
            End If
            If comd = "E" Then
                If dvupld.Rows.Count <> 0 Then
                    For i As Integer = 0 To dvupld.RowCount - 1
                        x = dvupld.Rows(i).Cells(1).Value
                        If Trim(txtdoc.Text) = x Then
                            MessageBox.Show("Sorry The Data Should Not Be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtdoc.Focus()
                            Exit Sub
                        End If
                    Next
                End If
            End If
            Me.docu_save()
        Else
            If dvdnld.RowCount <> 0 Then
                If rootpath = "" Then
                    If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        imgpath = FolderBrowserDialog1.SelectedPath
                    Else
                        Exit Sub
                    End If
                End If
                trk = 0
                For i As Integer = 0 To dvdnld.Rows.Count - 1
                    slno = dvdnld.Rows(i).Cells(4).Value
                    img = dvdnld.Rows(i).Cells(3).Value
                    imgnm = dvdnld.Rows(i).Cells(1).Value & "(" & Trim(txtregdno1.Text) & ")"
                    imgpth = rootpath & "\" & imgnm & ".Jpeg"
                    If img = "Yes" Then
                        trk = 1
                        Me.show_docimage(slno)
                        grppreview.Dock = DockStyle.Fill
                        Call image_download(imgpth, MDI.Picdnld, 1112, 774)
                    End If
                Next
                If trk = 1 Then
                    MessageBox.Show("Download Completed.The Images Are Downloaded At " & rootpath, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No Image File Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub


#End Region

#Region "Retrieve Section"
    Private Sub txtregdno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregdno.Validated
        Me.stud_details(txtregdno, txtstudnm, txtstudsl)
    End Sub

    Private Sub txtregdno1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregdno1.Validated
        Me.stud_details(txtregdno1, txtstudnm1, txtstudsl1)
    End Sub

    Private Sub stud_details(ByVal regdno As TextBox, ByVal studnm As TextBox, ByVal studsl As TextBox)
        If Trim(regdno.Text) <> "" Then
            Dim ds As DataSet = get_dataset("SELECT stud_hstry.stud_sl, stud.stud_nm, trad.trad_nm, sesion1.sesn_nm, DATALENGTH(stud.stud_image) AS stud_img, semester.sem_nm FROM stud_hstry LEFT OUTER JOIN semester ON stud_hstry.sem_cd = semester.sem_cd LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.reg_no = '" & Trim(regdno.Text) & "')")
            If ds.Tables(0).Rows.Count <> 0 Then
                studnm.Text = "Name : " & ds.Tables(0).Rows(0).Item("stud_nm") & vbCrLf & "Session : " & ds.Tables(0).Rows(0).Item("sesn_nm") & vbCrLf & "Stream : " & ds.Tables(0).Rows(0).Item("trad_nm") & vbCrLf & "Class : " & ds.Tables(0).Rows(0).Item("sem_nm")
                studsl.Text = ds.Tables(0).Rows(0).Item("stud_sl")
                img_length = ds.Tables(0).Rows(0).Item("stud_img")
                If Val(img_length) <> 0 Then
                    Me.show_image(studsl.Text)
                End If
                If TabControl1.SelectedIndex = 0 Then
                    Me.docu_view(dvupld, studsl.Text)
                Else
                    Me.docu_view(dvdnld, studsl.Text)
                End If
            Else
                MessageBox.Show("Please Enter A Valid Regd. No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                regdno.Focus()
            End If
        End If
    End Sub

    Private Sub docu_view(ByVal dgv As DataGridView, ByVal studsl As Integer)
        Dim ds As DataSet = get_dataset("SELECT docu_desc,docu_tp,docu_cd,DATALENGTH(docu_img) AS docu_img FROM stud_docu WHERE stud_sl=" & Val(studsl) & "")
        rw = 0
        dgv.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dgv.Rows.Add()
                dgv.Rows(rw).Cells(0).Value = i + 1
                dgv.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("docu_desc")
                If ds.Tables(0).Rows(i).Item("docu_tp") = "1" Then
                    dgv.Rows(rw).Cells(2).Value = "1.Photocopy"
                Else
                    dgv.Rows(rw).Cells(2).Value = "2.Original"
                End If
                img_length = ds.Tables(0).Rows(i).Item("docu_img")
                If Val(img_length) <> 0 Then
                    dgv.Rows(rw).Cells(3).Value = "Yes"
                Else
                    dgv.Rows(rw).Cells(3).Value = "No"
                End If
                dgv.Rows(rw).Cells(4).Value = ds.Tables(0).Rows(i).Item("docu_cd")
                rw += 1
            Next
        End If
    End Sub

#End Region

#Region "Image Section"

    Private Sub pict1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictupld.MouseEnter
        pictupld.Dock = DockStyle.Fill
    End Sub

    Private Sub pict1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pictupld.MouseLeave
        pictupld.Dock = DockStyle.None
        pictupld.Size = New Size(260, 160)
    End Sub

    Private Sub studimg_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles studimg.MouseLeave, studimg1.MouseLeave
        sender.Size = New Size(62, 67)
    End Sub

    Private Sub studimg_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles studimg.MouseEnter, studimg1.MouseEnter
        sender.Size = New Size(120, 120)
    End Sub


    Private Sub show_docimage(ByVal slno As Integer)
        Dim cmd_img As New SqlCommand("SELECT docu_img FROM stud_docu WHERE docu_cd=" & Val(slno) & " ", con_img)
        cmd_img.Parameters.AddWithValue("docu_img", 3)
        Try
            con_img.Open()
            If TabControl1.SelectedIndex = 0 Then
                pictupld.SizeMode = PictureBoxSizeMode.StretchImage
                pictupld.BackgroundImage = Image.FromStream(New IO.MemoryStream(CType(cmd_img.ExecuteScalar, Byte())))
            Else
                pictdnld.SizeMode = PictureBoxSizeMode.StretchImage
                pictdnld.BackgroundImage = Image.FromStream(New IO.MemoryStream(CType(cmd_img.ExecuteScalar, Byte())))
                MDI.Picdnld.SizeMode = PictureBoxSizeMode.StretchImage
                MDI.Picdnld.BackgroundImage = Image.FromStream(New IO.MemoryStream(CType(cmd_img.ExecuteScalar, Byte())))
            End If
            ' or you can save in a file 
            'IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\stud.jpg", CType(cmd_img.ExecuteScalar, Byte()))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con_img.Close()
        End Try
    End Sub

    Private Sub show_image(ByVal slno As Integer)
        Dim cmd_img As New SqlCommand("SELECT stud_image FROM stud WHERE stud_sl=" & Val(slno) & " ", con_img)
        cmd_img.Parameters.AddWithValue("stud_image", 3)
        Try
            con_img.Open()
            If TabControl1.SelectedIndex = 0 Then
                studimg.SizeMode = PictureBoxSizeMode.StretchImage
                studimg.BackgroundImage = Image.FromStream(New IO.MemoryStream(CType(cmd_img.ExecuteScalar, Byte())))
            Else
                studimg1.SizeMode = PictureBoxSizeMode.StretchImage
                studimg1.BackgroundImage = Image.FromStream(New IO.MemoryStream(CType(cmd_img.ExecuteScalar, Byte())))
            End If
            ' or you can save in a file 
            'IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\stud.jpg", CType(cmd_img.ExecuteScalar, Byte()))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con_img.Close()
        End Try
    End Sub

    Private Sub save_image(ByVal slno As Integer)
        Try
            Dim cmd_img As New SqlCommand("UPDATE stud_docu SET docu_img=@docu_img WHERE docu_cd=" & Val(slno) & "", con_img)
            Dim ms As New MemoryStream()
            pictupld.BackgroundImage.Save(ms, pictupld.BackgroundImage.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@docu_img", SqlDbType.Image)
            p.Value = data
            cmd_img.Parameters.Add(p)
            con_img.Open()
            cmd_img.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con_img.Close()
        End Try
    End Sub
#End Region



    Private Sub txtregdno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtregdno.KeyPress
        key(txtdoc, e)
        SPKey(e)
    End Sub

    Private Sub txtdoc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdoc.KeyPress
        key(cmbtype, e)
        SPKey(e)
    End Sub

    Private Sub cmbtype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtype.KeyPress
        key(btnupload, e)
        SPKey(e)
    End Sub

#Region "Link Label & Cmenu"

    Private Sub lnkadd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkadd.LinkClicked
        pictupld.Image = Nothing
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Set filter options and filter index.
            OpenFileDialog1.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg"
            OpenFileDialog1.FilterIndex = 1
            pictupld.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
            txtphoto.Text = "Y"
        End If
    End Sub

    Private Sub lnkclr_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkclr.LinkClicked
        pictupld.BackgroundImage = Nothing
        txtphoto.Text = "N"
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        comd = "E"
        txtdoc.Focus()
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dvupld.RowCount <> 0 Then
            comd = "M"
            slno = dvupld.SelectedRows(0).Cells(4).Value
            Dim ds As DataSet = get_dataset("SELECT docu_desc,docu_tp,docu_cd,DATALENGTH(docu_img) AS docu_img FROM stud_docu WHERE docu_cd=" & Val(slno) & "")
            If ds.Tables(0).Rows.Count <> 0 Then
                txtdoc.Text = ds.Tables(0).Rows(0).Item("docu_desc")
                cmbtype.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("docu_tp")) - 1
                txtdoccd.Text = slno
                img_length = ds.Tables(0).Rows(0).Item("docu_img")
                If Val(img_length) <> 0 Then
                    Me.show_docimage(txtdoccd.Text)
                    txtphoto.Text = "Y"
                Else
                    pictupld.BackgroundImage = Nothing
                    txtphoto.Text = "N"
                End If
            End If
            txtdoc.Focus()
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        If dvupld.RowCount <> 0 Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                slno = dvupld.SelectedRows(0).Cells(4).Value
                SQLInsert("DELETE FROM stud_docu WHERE docu_cd=" & Val(slno) & "")
            End If
            Me.docu_view(dvupld, txtstudsl.Text)
            txtdoc.Focus()
        End If
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click
        Me.docu_view(dvupld, txtstudsl.Text)
    End Sub

    Private Sub cmnuprvw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuprvw.Click
        If dvdnld.RowCount <> 0 Then
            slno = dvdnld.SelectedRows(0).Cells(4).Value
            img = dvdnld.SelectedRows(0).Cells(3).Value
            imgnm = dvdnld.SelectedRows(0).Cells(1).Value & "(" & Trim(txtregdno1.Text) & ")"
            If img = "Yes" Then
                Me.show_docimage(slno)
                grppreview.Dock = DockStyle.Fill
                grppreview.Visible = True
            Else
                MessageBox.Show("Nothing To View.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub cmnudnld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnudnld.Click
        If dvdnld.RowCount <> 0 Then
            slno = dvdnld.SelectedRows(0).Cells(4).Value
            img = dvdnld.SelectedRows(0).Cells(3).Value
            imgnm = dvdnld.SelectedRows(0).Cells(1).Value & "(" & Trim(txtregdno1.Text) & ")"
            If img = "Yes" Then
                Me.show_docimage(slno)
                If rootpath = "" Then
                    If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        rootpath = FolderBrowserDialog1.SelectedPath
                    Else
                        Exit Sub
                    End If
                End If
                imgpath = rootpath & "\" & imgnm & ".Jpeg"
                'Call image_download(imgpath, pictdnld, 470, 250)
                Call image_download(imgpath, MDI.Picdnld, 1112, 774)
                MessageBox.Show("Download Completed.The Images Are Downloaded At " & rootpath, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Nothing To Download.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub cmnurefresh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh1.Click
        Me.docu_view(dvdnld, txtstudsl1.Text)
    End Sub

    Private Sub lnkdownload_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkdownload.LinkClicked
        If rootpath = "" Then
            If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                rootpath = FolderBrowserDialog1.SelectedPath
            Else
                Exit Sub
            End If
        End If
        imgpath = rootpath & "\" & imgnm & ".Jpeg"
        Call image_download(imgpath, MDI.Picdnld, 1112, 774)
        MessageBox.Show("Download Completed.The Images Are Downloaded At " & rootpath, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        grppreview.Visible = False
    End Sub

    Private Sub lnkabort_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkabort.LinkClicked
        grppreview.Visible = False
    End Sub

    Private Sub studimg1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles studimg1.DoubleClick
        If rootpath = "" Then
            If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                rootpath = FolderBrowserDialog1.SelectedPath
            Else
                Exit Sub
            End If
        End If
        imgpath = rootpath & "\" & Trim(txtregdno1.Text) & ".Jpeg"
        Call image_download(imgpath, studimg1, 300, 360)
        MessageBox.Show("Download Completed.The Images Is Downloaded At " & rootpath, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        grppreview.Visible = False
    End Sub
#End Region

    Private Sub docu_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Add The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds1 As DataSet = get_dataset("SELECT max(docu_cd) as 'Max' FROM stud_docu")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO stud_docu(docu_cd,stud_sl,docu_desc,docu_tp,docu_img) VALUES (" & Val(mxno) & "," & _
                          Val(txtstudsl.Text) & ",'" & Trim(txtdoc.Text) & "','" & vb.Left(cmbtype.Text, 1) & "','')")
                If txtphoto.Text = "Y" Then
                    Me.save_image(mxno)
                End If
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtdoc.Text = ""
                pictupld.BackgroundImage = Nothing
                txtphoto.Text = "N"
                Me.docu_view(dvupld, txtstudsl.Text)
                Close1()
            End If
        Else
            'If usr_tp = "O" Then
            '    MessageBox.Show("You Are Not Authorised to Modify The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                'Dim ds As DataSet = get_dataset("SELECT unt_cd FROM unt WHERE unt_cd=" & Val(txtscrl.Text) & "")
                'If ds.Tables(0).Rows.Count <> 0 Then
                SQLInsert("UPDATE stud_docu SET docu_desc='" & Trim(txtdoc.Text) & "',docu_tp='" & _
                          vb.Left(cmbtype.Text, 1) & "' WHERE docu_cd =" & Val(txtdoccd.Text) & "")
                If txtphoto.Text = "Y" Then
                    Me.save_image(txtdoccd.Text)
                End If
                MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                comd = "E"
                txtdoc.Text = ""
                pictupld.BackgroundImage = Nothing
                txtphoto.Text = "N"
                Me.docu_view(dvupld, txtstudsl.Text)
                'End If
                Close1()
            End If
        End If
    End Sub

    

    Private Sub dvdocu_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvupld.CellClick
        If dvupld.RowCount <> 0 And comd = "M" Then
            slno = dvupld.SelectedRows(0).Cells(4).Value
            Dim ds As DataSet = get_dataset("SELECT docu_desc,docu_tp,docu_cd,DATALENGTH(docu_img) AS docu_img FROM stud_docu WHERE docu_cd=" & Val(slno) & "")
            If ds.Tables(0).Rows.Count <> 0 Then
                txtdoc.Text = ds.Tables(0).Rows(0).Item("docu_desc")
                cmbtype.SelectedIndex = Val(ds.Tables(0).Rows(0).Item("docu_tp")) - 1
                txtdoccd.Text = slno
                img_length = ds.Tables(0).Rows(0).Item("docu_img")
                If Val(img_length) <> 0 Then
                    Me.show_docimage(txtdoccd.Text)
                    txtphoto.Text = "Y"
                Else
                    pictupld.BackgroundImage = Nothing
                    txtphoto.Text = "N"
                End If
            End If
            txtdoc.Focus()
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Me.clr()
        If TabControl1.SelectedIndex = 0 Then
            btnupload.Text = "Upload"
            txtregdno.Focus()
        Else
            btnupload.Text = "Download"
            txtregdno1.Focus()
        End If
    End Sub

    Private Sub txtregdno1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtregdno1.KeyPress
        key(dvdnld, e)
        SPKey(e)
    End Sub

 

    

    

End Class
