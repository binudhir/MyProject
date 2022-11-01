Imports vb = Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class frmsams
    Dim scrlno As Integer
    Dim regdt As Date
    Dim regdno As String

    Dim excel07 As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR={1}'"
    Dim excel03 As String = "provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'"

    Private Sub frmsams_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmsams_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmsams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
    End Sub

    Private Sub frmsams_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        'Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        Me.Text = "Student Data Import From SAMS Report Wizard . . ."
        lblinstruct.Dock = DockStyle.Fill
        dv.Columns.Clear()
    End Sub
#Region "Combobox"
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

    Private Sub cmbunversity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunversity.GotFocus
        populate(cmbunversity, "SELECT uni_pfx FROM universe WHERE rec_lock='N' ORDER BY uni_pfx")
    End Sub

    Private Sub cmbunversity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunversity.LostFocus
        cmbunversity.Height = 21
    End Sub

    Private Sub cmbunversity_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunversity.Validated
        vdated(txtunvcd, "SELECT uni_cd FROM universe WHERE uni_pfx='" & Trim(cmbunversity.Text) & "'")
    End Sub

    Private Sub cmbunversity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunversity.Validating
        vdating(cmbunversity, "SELECT uni_pfx FROM universe WHERE uni_pfx='" & Trim(cmbunversity.Text) & "' AND rec_lock='N'", "Please Select A Valid University Name.")
    End Sub
#End Region

    Private Sub cmbsessn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbsessn.KeyPress
        key(cmbacdmyr, e)
        SPKey(e)
    End Sub

    Private Sub cmbacdmyr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbacdmyr.KeyPress
        key(cmbstrm, e)
        SPKey(e)
    End Sub

    Private Sub cmbstrm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstrm.KeyPress
        key(cmbunversity, e)
        SPKey(e)
    End Sub

    Private Sub cmbunversity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunversity.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsessn.Enter, cmbacdmyr.Enter, cmbstrm.Enter, cmbunversity.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsessn.Leave, cmbacdmyr.Leave, cmbstrm.Leave, cmbunversity.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
        sender.text = UCase(sender.text)
    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseEnter, btnimport.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseLeave, btnimport.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()
        cmbsessn.Text = ""
        cmbacdmyr.Text = ""
        cmbstrm.Text = ""
        cmbunversity.Text = ""
        txtsesncd.Text = 0
        txtacdncd.Text = 0
        txtstrmcd.Text = 0
        txtunvcd.Text = 0
        dv.Visible = False
        lblinstruct.Visible = True
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimport.Click
        OpenFileDialog1.ShowDialog()
        dv.Visible = True
        lblinstruct.Visible = False
        'Try
        '    Dim conn As OleDbConnection
        '    Dim dtr As OleDbDataReader
        '    Dim dta As OleDbDataAdapter
        '    Dim cmd As OleDbCommand
        '    Dim dts As DataSet
        '    Dim excel As String
        '    Dim OpenFileDialog As New OpenFileDialog

        '    OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        '    OpenFileDialog.Filter = "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls"

        '    If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then

        '        Dim fi As New FileInfo(OpenFileDialog.FileName)
        '        Dim FileName As String = OpenFileDialog.FileName

        '        excel = fi.FullName
        '        conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")
        '        dta = New OleDbDataAdapter("Select * From [Sheet1$]", conn)
        '        dts = New DataSet
        '        dta.Fill(dts, "[Sheet1$]")
        '        dv.DataSource = dts
        '        dv.DataMember = "[Sheet1$]"
        '        dv.Visible = True
        '        dv.Dock = DockStyle.Fill
        '        conn.Close()
        '    End If
        'Dim MyConnection As System.Data.OleDb.OleDbConnection
        'Dim DtSet As System.Data.DataSet
        'Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        'MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='E:\Junior Admission Register_27-Mar-2017.xls';Extended Properties=Excel 8.0;")
        'MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
        'MyCommand.TableMappings.Add("Table", "Net-informations.com")
        'DtSet = New System.Data.DataSet
        'MyCommand.Fill(DtSet)
        'dv.DataSource = DtSet.Tables(0)
        'dv.Visible = True
        'dv.Dock = DockStyle.Fill
        'MyConnection.Close()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
    End Sub


    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(cmbsessn.Text) = "" Or Val(txtsesncd.Text) = 0 Then
            MessageBox.Show("The Session Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbsessn.Focus()
            Exit Sub
        End If
        If Trim(cmbacdmyr.Text) = "" Or Val(txtacdncd.Text) = 0 Then
            MessageBox.Show("The Class Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbacdmyr.Focus()
            Exit Sub
        End If
        If Trim(cmbstrm.Text) = "" Or Val(txtstrmcd.Text) = 0 Then
            MessageBox.Show("The Branch Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbstrm.Focus()
            Exit Sub
        End If
        If dv.Rows.Count <> 0 Then
            Me.stud_save()
        Else
            MessageBox.Show("Please Import The Excel Data To The Grid View First.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub

    Private Sub stud_save()
        Try
            x = dv.Columns.Count
            If dv.Columns.Count = 13 Then
                Dim dob As Date
                cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Start1()
                If cnfr = vbYes Then
                    For i As Integer = 0 To dv.Rows.Count - 1
                        caste = 0
                        quota = 0
                        bldgrp = "9"
                        frstnm = ""
                        surnm = ""
                        mdlnm = ""
                        mobno = ""
                        secmrk = 0
                        mrkper = 0
                        regdno = dv.Rows(i).Cells(0).Value
                        studnm = dv.Rows(i).Cells(1).Value

                        Dim strarr As String() = studnm.Split(" ")
                        For count As Integer = 0 To strarr.Length - 1
                            If count = 0 Then
                                frstnm = strarr(count)
                            ElseIf count = 1 Then
                                mdlnm = strarr(count)
                            ElseIf count = 2 Then
                                surnm = strarr(count)
                            End If
                        Next
                        If surnm = "" Then
                            surnm = mdlnm
                            mdlnm = ""
                        End If
                        strm = dv.Rows(i).Cells(2).Value
                        fathnm = dv.Rows(i).Cells(3).Value
                        board = dv.Rows(i).Cells(4).Value
                        gndr = dv.Rows(i).Cells(5).Value
                        dob = dv.Rows(i).Cells(6).Value
                        bldgrp = dv.Rows(i).Cells(7).Value
                        address = dv.Rows(i).Cells(8).Value
                        caste = dv.Rows(i).Cells(9).Value
                        If Not IsDBNull(dv.Rows(i).Cells(10).Value) Then
                            mobno = dv.Rows(i).Cells(10).Value
                        End If




                        If Trim(caste) = "OBC" Then
                            caste = 4
                        ElseIf Trim(caste) = "ST" Then
                            caste = 2
                        ElseIf Trim(caste) = "SC" Then
                            caste = 3
                        Else
                            caste = 1
                        End If
                        quota = 1
                        If Not IsDBNull(dv.Rows(i).Cells(7).Value) Then
                            If Trim(bldgrp) = "O+" Then
                                bldgrp = "1"
                            ElseIf Trim(bldgrp) = "A+" Then
                                bldgrp = "2"
                            ElseIf Trim(bldgrp) = "B+" Then
                                bldgrp = "3"
                            ElseIf Trim(bldgrp) = "AB+" Then
                                bldgrp = "4"
                            ElseIf Trim(bldgrp) = "O-" Then
                                bldgrp = "5"
                            ElseIf Trim(bldgrp) = "A-" Then
                                bldgrp = "6"
                            ElseIf Trim(bldgrp) = "B-+" Then
                                bldgrp = "7"
                            ElseIf Trim(bldgrp) = "AB-" Then
                                bldgrp = "8"
                            Else
                                bldgrp = "9"
                            End If
                        Else
                            bldgrp = "9"
                        End If
                        'Mark Section For Qualification Entry
                        mark = dv.Rows(i).Cells(11).Value
                        Dim mrkarr As String() = mark.Split("(")
                        For cnt As Integer = 0 To mrkarr.Length - 1
                            If cnt = 0 Then
                                secmrk = mrkarr(cnt)
                            ElseIf cnt = 1 Then
                                x = mrkarr(cnt)
                                mrkper = vb.Left(x, Len(x) - 2)
                            End If
                        Next
                        x = (Val(secmrk) * 100) / Val(mrkper)
                        totmrk = Math.Round(x)

                        regdt = dv.Rows(i).Cells(12).Value
                        Dim ds As DataSet = get_dataset("SELECT max(stud_sl) as 'Max' FROM stud")
                        scrlno = 1
                        If ds.Tables(0).Rows.Count <> 0 Then
                            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                                scrlno = ds.Tables(0).Rows(0).Item(0) + 1
                            End If
                        End If
                        SQLInsert("INSERT INTO stud (stud_sl,stud_nm,reg_no,device_code,doj,leaved,cause_leave,hostel_req,dol,pre_add1,pre_add2," & _
                                  "pre_zip,pre_ph1,pre_ph2,per_add1,per_add2,per_zip,per_ph1,per_ph2,dob,gndr,married,nation,religion,height,weight," & _
                                  "chest,vision,fathr_nm,occu,income,rec_lock,stud_image,council_reg,ocu_cd,pre_ps,per_ps,lg_nm,lg_phno1,uni_cd,stud_usl," & _
                                  "mthr_nm,prt_code,join_tp,email,frm_no,pre_dist_cd,per_dist_cd,lg_phno2,stud_caste,stud_quota,fst_nm,mdl_nm,sur_nm," & _
                                  "conync_req,cantn_req,sms_req,mail_req,bld_grp,frm_enq,enq_no,reltn) VALUES (" & Val(scrlno) & ",'" & Trim(studnm) & "','" & _
                                  Trim(regdno) & "',0,'" & Format(regdt, "dd/MMM/yyyy") & "','N','','N','" & Format(regdt.AddYears(3), "dd/MMM/yyyy") & "','" & _
                                  Trim(address) & "','','','" & Trim(mobno) & "','','" & Trim(address) & "','" & _
                                  Trim(address) & "','','" & Trim(mobno) & "','','" & Format(dob, "dd/MMM/yyyy") & "','" & vb.Left(gndr, 1) & "','N','INDIAN','HINDU','','','','','" & _
                                  Trim(fathnm) & "','','1','N','','" & Trim(regdno) & "',0,'','','" & Trim(fathnm) & "','" & Trim(mobno) & "'," & Val(txtunvcd.Text) & "," & _
                                  Val(scrlno) & ",'',0,'1','','',1,1,'" & Trim(mobno) & "'," & Val(caste) & "," & Val(quota) & ",'" & _
                                  Trim(frstnm) & "','" & Trim(mdlnm) & "','" & Trim(surnm) & "','N','N','N','N','" & bldgrp & "','N',0,'FATHER')")
                        'stud histry Save
                        Me.hstry_save()
                        Me.quali_save(board, secmrk, totmrk, mrkper)
                        'sending sms
                        'Me.sms_send()
                    Next
                    MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                    Close1()
                End If
            Else
                MessageBox.Show("Sorry the Excel Data is not in Given Format.Please Read The Instruction Carefully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dv.Visible = False
                lblinstruct.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub hstry_save()
        SQLInsert("DELETE FROM stud_hstry WHERE active='Y'AND stud_sl=" & Val(scrlno) & "")
        Dim ds1 As DataSet = get_dataset("SELECT max(stud_hstry_sl) as 'Max' FROM stud_hstry")
        mxno = 1
        If ds1.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                mxno = ds1.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        SQLInsert("INSERT INTO stud_hstry(stud_hstry_sl,stud_sl,sesn_cd,sem_cd,trad_cd,reg_no,trans_dt,active,trans_tp,usr_ent,subj_asgn) VALUES (" & Val(mxno) & "," & _
                  Val(scrlno) & "," & Val(txtsesncd.Text) & "," & Val(txtacdncd.Text) & "," & Val(txtstrmcd.Text) & ",'" & Trim(regdno) & "','" & _
                  Format(regdt, "dd/MMM/yyyy") & "','Y','A'," & Val(usr_sl) & ",'N')")
    End Sub

    Private Sub quali_save(ByVal insnm As String, ByVal secmrk As Decimal, ByVal totmrk As Decimal, ByVal permrk As Decimal)
        SQLInsert("DELETE FROM stud_quali WHERE stud_sl=" & Val(scrlno) & "")
        Dim ds1 As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM stud_quali")
        mxno = 1
        If ds1.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                mxno = ds1.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        SQLInsert("INSERT INTO stud_quali(slno, stud_sl, ins_nm, edu_cd, yr, tot_mark, sec_mark, per_mark, cgpa, grade) VALUES (" & Val(mxno) & "," & _
                  Val(scrlno) & ",'" & insnm & "',1,'" & Format(regdt, "yyyy") & "'," & Val(totmrk) & "," & Val(secmrk) & "," & Val(permrk) & ",0,'A1')")
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Try
            Dim filepath As String = OpenFileDialog1.FileName
            Dim extensn As String = Path.GetExtension(filepath)
            Dim hdr As String = "YES"
            Dim constr As String, sheetname As String
            constr = String.Empty
            Select Case extensn
                Case ".xls" 'For Excel 2003
                    constr = String.Format(excel03, filepath, hdr)
                    Exit Select
                Case ".xlsx"  'For Excel 2003
                    constr = String.Format(excel07, filepath, hdr)
                    Exit Select
            End Select
            'Get The Name of First Sheet
            Using con As New OleDbConnection(constr)
                Using cmd As New OleDbCommand()
                    cmd.Connection = con
                    con.Open()
                    Dim dtexcel As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                    sheetname = dtexcel.Rows(0)("TABLE_NAME").ToString()
                    con.Close()
                End Using
            End Using
            'Read the Data From Excel File
            Using con As New OleDbConnection(constr)
                Using cmd As New OleDbCommand()
                    Using oda As New OleDbDataAdapter()
                        Dim dt As New DataTable()
                        cmd.CommandText = (Convert.ToString("Select * From [") & sheetname) + "]"
                        cmd.Connection = con
                        con.Open()
                        oda.SelectCommand = cmd
                        oda.Fill(dt)
                        con.Close()

                        'Populating in Datagridview
                        dv.DataSource = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
