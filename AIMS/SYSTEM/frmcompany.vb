Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Data

Public Class frmcompany
    
    Dim con_img As New SqlConnection(connectionstrng)
    Dim cmd_img As SqlCommand

    Private Sub frmcompany_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmcompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
    End Sub

    Private Sub frmcompany_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Company Information Screen . . ."
        data_retrieve(1)
    End Sub

    Private Sub txtmembr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtzip.Enter, txtcompany.Enter, txtcont2.Enter, txtcont1.Enter, txtaddress.Enter, txtmailid.Enter, txtdescri.Enter, txtwebsite.Enter, txtpernb.Enter, txtjuris.Enter, txtregdno.Enter, txtpfx.Enter, txtsfx.Enter, txtbankdet.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub txtmembr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtzip.Leave, txtcompany.Leave, txtcont2.Leave, txtcont1.Leave, txtaddress.Leave, txtmailid.Leave, txtdescri.Leave, txtwebsite.Leave, txtpernb.Leave, txtjuris.Leave, txtregdno.Leave, txtpfx.Leave, txtsfx.Leave, txtbankdet.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub btnbrowse_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowse.MouseEnter, btnremove.MouseEnter
        sender.forecolor = Color.Blue
    End Sub

    Private Sub btnbrowse_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowse.MouseLeave, btnremove.MouseLeave
        sender.forecolor = Color.Black
    End Sub

    Private Sub txtcont1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont1.KeyPress
        key(txtcont2, e)
        NUM(e)
    End Sub

    Private Sub txtzip_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzip.KeyPress
        key(txtcont1, e)
        NUM(e)
    End Sub

    Private Sub txtcont2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcont2.KeyPress
        key(txtmailid, e)
        NUM(e)
    End Sub

    Private Sub txtmailid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmailid.KeyPress
        key(txtwebsite, e)
        SPKey(e)
    End Sub

    Private Sub txtdescri_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescri.KeyPress
        key(txtaddress, e)
        SPKey(e)
    End Sub

    Private Sub txtwebsite_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtwebsite.KeyPress
        key(txtregdno, e)
        SPKey(e)
    End Sub

    Private Sub txtregdno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtregdno.KeyPress
        key(regdt, e)
        SPKey(e)
    End Sub

    Private Sub regdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles regdt.KeyPress
        key(start_date, e)
    End Sub

    Private Sub start_date_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles start_date.KeyPress
        key(end_date, e)
    End Sub

    Private Sub End_date_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles end_date.KeyPress
        key(txtjuris, e)
    End Sub

    Private Sub txtjuris_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtjuris.KeyPress
        key(txtpfx, e)
        SPKey(e)
    End Sub

    Private Sub txtpfx_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpfx.KeyPress
        key(txtsfx, e)
        SPKey(e)
    End Sub

    Private Sub txtsufix_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsfx.KeyPress
        key(txtbankdet, e)
        SPKey(e)
    End Sub

    Private Sub txtbankdet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbankdet.KeyPress
        key(txtpernb, e)
        SPKey(e)
    End Sub

    Private Sub txtmailid_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmailid.Validating
        If Trim(txtmailid.Text) <> "" Then
            If txtmailid.Text.IndexOf("@") = -1 OrElse txtmailid.Text.IndexOf(".") = -1 Then
                e.Cancel = True
                MessageBox.Show("You Have Enter An Invalid Mail ID.Please Enter A Valid Email ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtmailid.Focus()
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub txtwebsite_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtwebsite.Validating
        If Trim(txtwebsite.Text) <> "" Then
            website = LCase(Trim(txtwebsite.Text))
            If LCase(website.IndexOf("www")) = -1 OrElse txtwebsite.Text.IndexOf(".") = -1 Then
                e.Cancel = True
                MessageBox.Show("You Have Enter An Invalid Web Site.Please Enter A Valid Web Site." & vbCrLf & "Ex. www.shradhatechnologies.com", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtwebsite.Focus()
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        comd = "E"
        btnsave.Text = "Modify"
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        'If Trim(txtcity.Text) = "" Then
        '    MessageBox.Show("Sorry The New Password Field Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtcity.Focus()
        '    Exit Sub
        'End If
        'If Trim(txtdescri.Text) = Trim(txtcity.Text) Then
        '    MessageBox.Show("Sorry The Old Password Should Not Be Equal To The New Password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtcity.Focus()
        '    Exit Sub
        'End If
        'If Trim(txtaddress.Text) = "" Then
        '    MessageBox.Show("Please Provide The Address.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtaddress.Focus()
        '    Exit Sub
        'End If
        'If Trim(txtcont1.Text) = "" Then
        '    MessageBox.Show("Please Provide A Contact Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtcont1.Focus()
        '    Exit Sub
        'End If
        Me.user_save()
    End Sub

    Private Sub user_save()
        cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Start1()
        If cnfr = vbYes Then
            Dim ds As DataSet = get_dataset("SELECT co_sl FROM company WHERE co_sl=" & Val(txtscrl.Text) & "")
            If ds.Tables(0).Rows.Count <> 0 Then
                SQLInsert("UPDATE company SET descri='" & Trim(txtdescri.Text) & "',co_add1 ='" & _
                          Trim(txtaddress.Text) & "', zip_cd = '" & Trim(txtzip.Text) & "', co_ph1  = '" & _
                          Trim(txtcont1.Text) & "', co_ph2    ='" & Trim(txtcont2.Text) & "', web      =  '" & _
                          Trim(txtwebsite.Text) & "', co_mail= '" & Trim(txtmailid.Text) & "',juri= '" & _
                          Trim(txtjuris.Text) & "',co_pfx='" & Trim(txtpfx.Text) & "',co_sfx='" & _
                          Trim(txtsfx.Text) & "' ,bank='" & Trim(txtbankdet.Text) & "' ,regd_no= '" & _
                          Trim(txtregdno.Text) & "', per_nb= '" & Trim(txtpernb.Text) & "', st_date='" & _
                          Format(start_date.Value, "dd/MMM/yyyy") & "', ed_date   ='" & _
                          Format(end_date.Value, "dd/MMM/yyyy") & "',regd_dt   ='" & _
                          Format(regdt.Value, "dd/MMM/yyyy") & "',co_img='' WHERE co_sl =" & Val(txtscrl.Text) & "")
                coph1 = Trim(txtcont1.Text)
                coph2 = Trim(txtcont2.Text)
                coadd = Trim(txtaddress.Text)
                coemail = Trim(txtmailid.Text)
                coweb = Trim(txtwebsite.Text)
                conb = Trim(txtpernb.Text)
                codscr = Trim(txtdescri.Text)
                cojuris = Trim(txtjuris.Text)
                stdt = start_date.Value
                endt = end_date.Value
                If Not Pict1.BackgroundImage Is Nothing Then
                    Me.save_image()
                End If
                MessageBox.Show("Record Modified Successfully.The Change Will Be Affect Your Next Login.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()

            End If
            Close1()
            Me.Close()
        End If
    End Sub

    Private Sub data_retrieve(ByVal slno As Integer)
        Dim dsedit As DataSet = get_dataset("SELECT DATALENGTH(co_img) AS co_img, company.* FROM company WHERE co_sl=" & Val(slno) & "")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtcompany.Text = dsedit.Tables(0).Rows(0).Item("co_nm")
            txtdescri.Text = dsedit.Tables(0).Rows(0).Item("descri")
            txtaddress.Text = dsedit.Tables(0).Rows(0).Item("co_add1")
            txtzip.Text = dsedit.Tables(0).Rows(0).Item("zip_cd")
            txtcont1.Text = dsedit.Tables(0).Rows(0).Item("co_ph1")
            txtcont2.Text = dsedit.Tables(0).Rows(0).Item("co_ph2")
            txtwebsite.Text = dsedit.Tables(0).Rows(0).Item("web")
            txtmailid.Text = dsedit.Tables(0).Rows(0).Item("co_mail")
            txtjuris.Text = dsedit.Tables(0).Rows(0).Item("juri")
            txtpfx.Text = dsedit.Tables(0).Rows(0).Item("co_pfx")
            txtsfx.Text = dsedit.Tables(0).Rows(0).Item("co_sfx")
            txtbankdet.Text = dsedit.Tables(0).Rows(0).Item("bank")
            txtpernb.Text = dsedit.Tables(0).Rows(0).Item("per_nb")
            txtregdno.Text = dsedit.Tables(0).Rows(0).Item("regd_no")
            start_date.Value = dsedit.Tables(0).Rows(0).Item("st_date")
            end_date.Value = dsedit.Tables(0).Rows(0).Item("ed_date")
            regdt.Value = dsedit.Tables(0).Rows(0).Item("regd_dt")
            img_length = dsedit.Tables(0).Rows(0).Item("co_img")
            If Val(img_length) <> 0 Then
                Me.show_image()
            End If
        End If
    End Sub

    Private Sub start_date_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles start_date.Validated
        end_date.Value = start_date.Value.AddYears(1)
    End Sub

    Private Sub btnbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowse.Click
        Pict1.Image = Nothing
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Set filter options and filter index.
            OpenFileDialog1.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg"
            OpenFileDialog1.FilterIndex = 1
            Pict1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnremove.Click
        Pict1.BackgroundImage = Nothing
    End Sub

    Private Sub save_image()
        Try
            Dim cmd_img As New SqlCommand("UPDATE company SET co_img=@co_img WHERE co_sl=1", con_img)
            Dim ms As New MemoryStream()
            Pict1.BackgroundImage.Save(ms, Pict1.BackgroundImage.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@co_img", SqlDbType.Image)
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

    Private Sub show_image()
        Dim cmd_img As New SqlCommand("SELECT co_img,DataLength(co_img) as db_len FROM company WHERE co_sl=1 ", con_img)
        cmd_img.Parameters.AddWithValue("co_img", 3)
        Try
            con_img.Open()
            Pict1.SizeMode = PictureBoxSizeMode.StretchImage
            Pict1.BackgroundImage = Image.FromStream(New IO.MemoryStream(CType(cmd_img.ExecuteScalar, Byte())))
            ' or you can save in a file 
            IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\complogo.jpg", CType(cmd_img.ExecuteScalar, Byte()))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con_img.Close()
        End Try
       

    End Sub

End Class
