Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Threading
Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Net.Mail
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Office.Interop

Public Module Starter
    Dim Mail As New MailMessage
    Dim client As New WebClient()
    'Dim connectionstrng As String = "Data Source=DIAMOND-PC\SQLEXPRESS1; Initial Catalog=EIMS001; User ID=sa; Password=diamond"
    Public connectionstrng As String
    Public con1 As SqlConnection
    Public con2 As SqlConnection
    Public con3 As SqlConnection
    Public con4 As SqlConnection
    Public con5 As SqlConnection
    'Dim con1, con2 As SqlConnection
    'Public dr1 As SqlDataReader
    'Public dr2 As SqlDataReader
    'Public dr3 As SqlDataReader
    'Public dr4 As SqlDataReader

    Dim dr, dr2 As SqlDataReader
    Dim da As SqlDataAdapter

    Public cmd As SqlCommand
    Public cmd1 As SqlCommand
    Public cmd2 As SqlCommand
    Public cmd3 As SqlCommand
    Public cmd4 As SqlCommand
    Public cmd5 As SqlCommand
    'Dim cmd, cmd1 As New SqlCommand

    Public srvnm As String                           'DATA SERVER NAME
    Public dbnm As String                            'DATA BASE NAME
    Public dbid As String                            'DATABASE USER NAME
    Public dbpwd As String                           'DATA BASE PASSWORD
    Public dbmode As Integer

    Public cosl As String                            'COMPANY SL
    Public cocd As String                            'COMPANY CODE
    Public conm As String                            'COMPANY NAME
    Public cosnm As String                           'COMPANY SHORTNAME
    Public coph1 As String                           'COMPANY CONTACT1
    Public coph2 As String                           'COMPANY CONTACT2
    Public coadd As String                           'COMPANY ADDRESS
    Public coemail As String                         'COMPANY EMAIL ID  
    Public coweb As String                           'COMPANY WEBSITE
    Public conb As String                            'COMPANY N.B
    Public codscr As String                          'COMPANY DESCRIPTION
    Public cojuris As String                         'COMPANY JURISDICTION
    Public stdt As Date                              'START DATE
    Public endt As Date                              'END DATE 
    Public expiry_dt As Date                         'Application Expiry DATE
    Public installation_dt As Date                   'Application Installation DATE
    Public hddr As String                            'Header Print

    Public logn As String = "N"                      'Whether login or not
    Public usr_nm As String                          'username
    Public usr_sl As String                          'usersl
    Public usr_tp As String                          'User Level(A,D,M,O)
    Public ver_no As String                          'version No

    Public comdcrse As String                        'for course master
    Public comdbatch As String                       'for Batch master

    Public comdreg As String                         'For registration
    Public comdbatchallocate As String               'For Branch Allocation
    Public sys_date As Date = Today
    Public comdmr As String                          ' For Money receipt

    'PRINT SECTION
    Public frmno As Integer                          'Printing Form Number
    Public reportnm As String                        'Crystal Report Name

    'GLOBAL SETTINGS
    Public print_schd As Integer                    'Printing Schedule Style
    Public print_coll As Integer                    'Printing Collection Reciept Style
    Public print_ocoll As Integer                   'Printing Other Collection Style
    Public print_payv As Integer                    'Printing Payment Voucher Style
    Public print_recv As Integer                    'Printing Reciept Voucher Style
    Public print_po As Integer                      'Printing Purchase Order Style
    Public stud_icard As Integer                    'Printing Student Icard Style
    Public staff_icard As Integer                   'Printing Staff Icard Style
    Public trst_coll As Integer                     'Printing Trust Collection Style
    Public trst_ocoll As Integer                    'Printing Trust Other Collection Style
    Public due_alrt As String                       'Required Due Alert
    Public due_days As Integer                      'Due Alert How many Days
    Public strt_backup As String                    'Auto Backup When Program Start
    Public backup_days As Integer                   'Backup files for How many days
    Public backup_pth As String                     'Backup Directory Path
    Public stud_bk As Integer                       'No of books issued to a student
    Public stud_bkday As Integer                    'How many days allows to a student to keeb the book
    Public staf_bk As Integer                       'No of books issued to a student
    Public staf_bkday As Integer                    'How many days allows to a staff to keeb the book
    Public pf_per As Decimal                        'PF percentage
    Public esic_per As Decimal                      'ESIC percentage
    Public oth_deduct As Decimal                    'Other Deduction
    Public backup_rem As Integer                    'Want Backup Reminder
    Public bday_rem As Integer                      'Want Birthday Reminder
    Public anvr_rem As Integer                      'Want Aniversery Reminder
    Public enq_rem As Integer                       'Want Enquiry Followup Reminder
    Public due_rem As Integer                       'Want Due Amount Reminder
    Public srvr_gsm As Integer                      'SMS server or GSM Modem
    Public sms_srvr As String                       'Server String
    Public sms_id As String                         'SMS id
    Public sms_pwd As String                        'SMS password
    Public sender_id As String                      'SMS sender ID
    Public port_no As Integer                       'EMAIL port no
    Public smtp_srvr As String                      'SMTP server
    Public mail_id As String                        'Email ID
    Public mail_pwd As String                       'Email Password
    Public stud_sms As Integer                      'Want To SMS Student
    Public fath_sms As Integer                      'Want To SMS Students Father
    Public moth_sms As Integer                      'Want To SMS Student Mother
    Public grdn_sms As Integer                      'Want To SMS Students Guardian
    Public regd_sms As Integer                      'Want To SMS Student After Registration
    Public due_sms As Integer                       'Want To SMS Student After Due
    Public coll_sms As Integer                      'Want To SMS Student About Collection
    Public reslt_sms As Integer                     'Want To SMS Student About Result

    Public copy_schd As Integer                     'Printing Number of Copies
    Public copy_coll As Integer                     'Printing Number of Copies
    Public copy_ocoll As Integer                    'Printing Number of Copies
    Public copy_payv As Integer                     'Printing Number of Copies
    Public copy_recv As Integer                     'Printing Number of Copies
    Public copy_po As Integer                       'Printing Number of Copies
    Public copy_tcoll As Integer                    'Printing Number of Copies
    Public copy_tocoll As Integer                   'Printing Number of Copies

    Public inventory As String = "Y"                'Inventory module permission to a Organisation
    Public library As String = "Y"                  'Library module permission to a Organisation
    Public exam As String = "Y"                     'Examination module permission to a Organisation
    Public attandnc As String = "Y"                 'Attendance module permission to a Organisation

    Public studbk As Integer                        'Max. number of book s issued to student
    Public stafbk As Integer                        'Max. number of book s issued to staff

    Public lnk_path As String

    Public Sub main()
        If System.IO.File.Exists(My.Application.Info.DirectoryPath & "\dblnk.dll") = False Then
            File.Create(My.Application.Info.DirectoryPath & "\dblnk.dll").Dispose()
        End If
        If (Not System.IO.Directory.Exists(My.Application.Info.DirectoryPath & "\Backup")) Then
            System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Backup")
        End If
        lnk_path = My.Application.Info.DirectoryPath & "\dblnk.dll"
    End Sub

    Public Sub SqlCon1()
        Dim str1 As String
        con1 = New SqlConnection
        str1 = connectionstrng
        con1.ConnectionString = str1
    End Sub

    Public Sub Start1()
        Call SqlCon1()
        If con1.State = 1 Then
            con1.Close()
        End If
        con1.Open()
    End Sub

    Public Sub Close1()
        If con1.State = 1 Then
            con1.Close()
        End If
    End Sub

    Public Sub SQLSelect(ByVal qry As String)
        Dim cmd1 As SqlCommand
        cmd1 = New SqlCommand(qry, con1)
        cmd1.CommandType = CommandType.Text
        dr = cmd1.ExecuteReader
    End Sub

    Public Sub SQLInsert(ByVal qry As String)
        Dim cmd1 As SqlCommand
        cmd1 = New SqlCommand(qry, con1)
        cmd1.CommandType = CommandType.Text
        cmd1.ExecuteNonQuery()
    End Sub

    Public Function get_dataset(ByVal qry As String) As DataSet
        Dim strweb As String
        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        strweb = connectionstrng
        cn = New SqlConnection(strweb)
        Try
            cn.Open()
            cmd = New SqlCommand(qry, cn)
            da = New SqlDataAdapter(cmd)
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            da.Dispose()
        End Try
    End Function

    Public Sub Sending_email(ByVal subject As String, ByVal mailid As String, ByVal mailbody As String, Optional ByVal Attachments() As String = Nothing)
        msg = ""
        sent = "N"
        attach = "N"
        connected = CheckConnection() 'Checking Of Internet Connection Avalable Or Not
        If connected = True Then
            Try
                Mail.Subject = subject
                Mail.To.Add(mailid)
                Mail.From = New MailAddress(mailid)
                Mail.Body = mailbody

                'If FileExists(AttachmentFile) Then Mail.Attachments.Add(AttachmentFile)

                'Dim attachment As New Mail.Attachment(Server.MapPath("test.txt")) 'create the attachment
                'Mail.Attachments.Add(Attachment) 'add the attachment
                'SmtpMail.SmtpServer = "localhost" 'your real server goes here
                If (Attachments IsNot Nothing) Then

                    For Each FileName In Attachments
                        Mail.Attachments.Remove(New System.Net.Mail.Attachment(FileName))
                        Mail.Attachments.Add( _
                        New System.Net.Mail.Attachment(FileName))
                    Next
                    attach = "Y"
                End If
                Dim SMTP As New SmtpClient("smtp.gmail.com")
                SMTP.EnableSsl = True
                SMTP.Credentials = New System.Net.NetworkCredential("shradhatechbls@gmail.com", "shradha@321")
                SMTP.Port = 587
                SMTP.Send(Mail)
                Mail.Attachments.Clear()
                MessageBox.Show("Email Sent successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                msg = "Email Sent successfully."
                sent = "Y"
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                msg = ex.Message
            End Try
        Else
            MessageBox.Show("There is No Internet Connection.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            msg = "There is No Internet Connection."
        End If
        'Mail Saving
        Start1()
        Dim ds As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM complain")
        slno = 1
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                slno = ds.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        SQLInsert("INSERT INTO complain (slno,subj,body,attach,send,nb,send_dt,usr_sl) VALUES (" & Val(slno) & ",'" & _
                  Trim(subject) & "','" & Trim(mailbody) & "','" & attach & "','" & sent & "','" & _
                  msg & "','" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & usr_sl & ")")
        Close1()
    End Sub

    Public Sub Sending_sms(ByVal mobno As String, ByVal msg As String)
        Try
            api = "http://bulksms.shradhatechnologies.com/api/swsend.asp?username=" & sms_id & "&password=" & sms_pwd & "&sender=" & sender_id & "&sendto=" & mobno & "&message=" & msg & ""
            client.OpenRead(api)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub saving_sms(ByVal mxno As Integer, ByVal sms_for As String, ByVal mob_no As String, ByVal sms As String)
        Try
            SQLInsert("INSERT INTO sending_sms(sms_sl,sms_for,sms_no,sms_text,sms_dt,sms_snd,sms_sdt,evnt) VALUES (" & Val(mxno) & ",'" & _
                      sms_for & "','" & mob_no & "','" & sms & "','" & Format(Now, "dd/MMM/yyyy hh:mm:ss") & "','N','" & _
                      Format(Now, "dd/MMM/yyyy hh:mm:ss") & "','" & Left(sms_for, 1) & "')")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub menu_enable()
        With MDI
            .Panel3.Visible = False
            .Panel4.Visible = False
            .picnxt.Visible = True
            .picpre.Visible = True
            .mnusecurity.Enabled = True
            .mnumaster.Enabled = True
            .mnu_student.Enabled = True
            .mnuaccounts.Enabled = True
            .mnureports.Enabled = True
            .pictwifi.Visible = True
            .Pnldur.Visible = True
            .Pnldur.Left = .Width - 400
            .pictwifi.Left = .Pnldur.Left - 50
            .mnucompinfo.Enabled = True
            .mnucompset.Enabled = True
            .mnu_logout.Enabled = True
            .mnu_login.Enabled = False
            .mnuinventory.Enabled = True
            .mnuexamination.Enabled = True
            .mnulibrary.Enabled = True
            If usr_tp = "A" Then
                .mnucompinfo.Visible = True
                ' .mnucompset.Visible = True
                .mnunewuser.Visible = True
                .mnuuserpermission.Visible = True
                .mnureports.Visible = True
                .mnusms.Visible = True
            ElseIf usr_tp = "D" Then
                .mnucompinfo.Visible = True
                '.mnucompset.Visible = True
                .mnunewuser.Visible = True
                .mnuuserpermission.Visible = True
                .mnureports.Visible = True
                .mnusms.Visible = True
            ElseIf usr_tp = "M" Then
                .mnucompinfo.Visible = False
                .mnucompset.Visible = False
                .mnunewuser.Visible = False
                .mnuuserpermission.Visible = False
                .mnureports.Visible = True
                .mnusms.Visible = False
            Else
                .mnucompinfo.Visible = False
                .mnucompset.Visible = False
                .mnunewuser.Visible = False
                .mnuuserpermission.Visible = False
                .mnureports.Visible = False
                .mnusms.Visible = False
            End If
            connected = CheckConnection() 'Checking Of Internet Connection Avalable Or Not
            If connected = True Then
                .pictwifi.BackgroundImage = My.Resources.network2
            Else
                .pictwifi.BackgroundImage = My.Resources.network1
            End If
        End With
    End Sub

    Public Sub menu_disable()
        With MDI
            .Panel3.Visible = False
            .Panel4.Visible = False
            .picnxt.Visible = False
            .picpre.Visible = False
            .lblconm.Text = ""
            .lblwarning.Visible = False
            .lblwarning.Text = ""
            .mnusecurity.Enabled = False
            .mnumaster.Enabled = False
            .mnu_student.Enabled = False
            .mnuaccounts.Enabled = False
            .mnureports.Enabled = False
            .Pnldur.Visible = False
            .pictwifi.Visible = False
            .mnucompinfo.Enabled = False
            .mnucompset.Enabled = False
            .mnu_login.Enabled = True
            .mnu_logout.Enabled = False
            .mnuinventory.Enabled = False
            .mnuexamination.Enabled = False
            .mnulibrary.Enabled = False
            .lblduration.Text = "00:00:00"
        End With
    End Sub

    'Public Sub prmsn_mngmnt(ByVal menunm As String, ByVal frmnm As Form)
    '    Dim ds As DataSet = get_dataset("SELECT user_assign.add_prm, user_assign.edit_prm, user_assign.delete_prm, user_assign.view_prm, user_assign.menu_sl FROM user_assign LEFT OUTER JOIN menumst ON user_assign.menu_sl = menumst.menu_sl WHERE (user_assign.user_sl = " & usr_sl & ") AND (menumst.menu_id = '" & menunm & "')")
    '    If ds.Tables(0).Rows.Count <> 0 Then
    '        addprmsn = ds.Tables(0).Rows(0).Item("add_prm")
    '        editprmsn = ds.Tables(0).Rows(0).Item("edit_prm")
    '        delprmsn = ds.Tables(0).Rows(0).Item("delete_prm")
    '        viewprmsn = ds.Tables(0).Rows(0).Item("view_prm")
    '        If addprmsn = 0 Then
    '            frmcntr.cmnuadd.Enabled = False
    '        Else
    '            cmnuadd.Enabled = True
    '        End If
    '        If editprmsn = 0 Then
    '            cmnuedit.Enabled = False
    '        Else
    '            cmnuedit.Enabled = True
    '        End If
    '        If delprmsn = 0 Then
    '            cmenudel.Enabled = False
    '        Else
    '            cmenudel.Enabled = True
    '        End If
    '        If viewprmsn = 1 Then
    '            btnsave.Enabled = False
    '        Else
    '            btnsave.Enabled = True
    '        End If
    '    End If
    'End Sub


    Public Sub uprmenu_visible()
        ' Dim ds As DataSet = get_dataset("SELECT menumst.menu_id FROM user_assign LEFT OUTER JOIN menumst ON user_assign.menu_sl = menumst.menu_sl WHERE (user_assign.user_sl = " & usr_sl & ") AND (user_assign.add_prm = 0) AND (user_assign.edit_prm = 0) AND (user_assign.delete_prm = 0) AND (user_assign.view_prm = 0)")
        Dim ds As DataSet = get_dataset("SELECT user_assign.*,menumst.menu_id, menumst.tab_lvl FROM user_assign LEFT OUTER JOIN menumst ON user_assign.menu_sl = menumst.menu_sl WHERE (user_assign.user_sl = " & usr_sl & ")  AND (menumst.menu_lvl=0) ORDER BY menumst.tab_lvl")
        If ds.Tables(0).Rows.Count <> 0 Then
            'Dim mnunm As ToolStripMenuItem
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                tablvl = ds.Tables(0).Rows(i).Item("tab_lvl")
                addprm = ds.Tables(0).Rows(i).Item("add_prm")
                editprm = ds.Tables(0).Rows(i).Item("edit_prm")
                delprm = ds.Tables(0).Rows(i).Item("delete_prm")
                viewprm = ds.Tables(0).Rows(i).Item("view_prm")
                MDI.MenuStrip1.Items(tablvl - 1).Visible = True
                If addprm = 0 And editprm = 0 And delprm = 0 And viewprm = 0 Then
                    MDI.MenuStrip1.Items(tablvl - 1).Visible = False
                End If
                mnunm = MDI.MenuStrip1.Items(tablvl - 1).Name
                Call lwrmenu_visible(mnunm, tablvl)
            Next
        End If
        'MDI.mnuExamGroup.Visible = False
        'MDI.mnuExam.Visible = False
        'MDI.mnuPeriodGroup.Visible = False
        'MDI.mnuPeriod.Visible = False
        'MDI.mnuPlanner.Visible = False
        'MDI.mnuImport_stud.Visible = False
        MDI.mnuPenalty.Visible = False
        'MDI.mnubkissreg.Visible = False
        MDI.mnubkretreg.Visible = False
    End Sub

    Private Sub lwrmenu_visible(ByVal mnunm As String, ByVal tablvl As Integer)
        'For Each item As ToolStripMenuItem In MDI.MenuStrip1.Items
        '    If item.Name = mnunm Then
        Dim ds As DataSet = get_dataset("SELECT user_assign.*,menumst.menu_id,menumst.menu_nm, menumst.tab_lvl FROM user_assign LEFT OUTER JOIN menumst ON user_assign.menu_sl = menumst.menu_sl WHERE (user_assign.user_sl = " & usr_sl & ") AND (menumst.tab_lvl=" & tablvl & ") AND (menumst.menu_lvl<>0) ORDER BY user_assign.asgn_no")
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                tablvl = ds.Tables(0).Rows(i).Item("tab_lvl")
                menuid = ds.Tables(0).Rows(i).Item("menu_id")
                menunm = ds.Tables(0).Rows(i).Item("menu_nm")
                addprm = ds.Tables(0).Rows(i).Item("add_prm")
                editprm = ds.Tables(0).Rows(i).Item("edit_prm")
                delprm = ds.Tables(0).Rows(i).Item("delete_prm")
                viewprm = ds.Tables(0).Rows(i).Item("view_prm")
                Select Case tablvl
                    Case Is = 1
                        MDI.mnuconfig.DropDownItems(i + 1).Visible = True
                        If addprm = 0 And editprm = 0 And delprm = 0 And viewprm = 0 Then
                            MDI.mnuconfig.DropDownItems(i + 1).Visible = False
                        End If
                    Case Is = 2
                        MDI.mnusecurity.DropDownItems(i).Visible = True
                        If addprm = 0 And editprm = 0 And delprm = 0 And viewprm = 0 Then
                            MDI.mnusecurity.DropDownItems(i).Visible = False
                        End If
                    Case Is = 3
                        MDI.mnumaster.DropDownItems(i).Visible = True
                        If addprm = 0 And editprm = 0 And delprm = 0 And viewprm = 0 Then
                            MDI.mnumaster.DropDownItems(i).Visible = False
                        End If
                    Case Is = 4
                        MDI.mnu_student.DropDownItems(i).Visible = True
                        If addprm = 0 And editprm = 0 And delprm = 0 And viewprm = 0 Then
                            MDI.mnu_student.DropDownItems(i).Visible = False
                        End If
                    Case Is = 5
                        MDI.mnuaccounts.DropDownItems(i).Visible = True
                        If addprm = 0 And editprm = 0 And delprm = 0 And viewprm = 0 Then
                            MDI.mnuaccounts.DropDownItems(i).Visible = False
                        End If
                    Case Is = 6
                        MDI.mnuinventory.DropDownItems(i).Visible = True
                        If addprm = 0 And editprm = 0 And delprm = 0 And viewprm = 0 Then
                            MDI.mnuinventory.DropDownItems(i).Visible = False
                        End If
                    Case Is = 7
                        MDI.mnuexamination.DropDownItems(i).Visible = True
                        If addprm = 0 And editprm = 0 And delprm = 0 And viewprm = 0 Then
                            MDI.mnuexamination.DropDownItems(i).Visible = False
                        End If
                    Case Is = 8
                        MDI.mnulibrary.DropDownItems(i).Visible = True
                        If addprm = 0 And editprm = 0 And delprm = 0 And viewprm = 0 Then
                            MDI.mnulibrary.DropDownItems(i).Visible = False
                        End If
                    Case Is = 9
                        MDI.mnureports.DropDownItems(i).Visible = True
                        If addprm = 0 And editprm = 0 And delprm = 0 And viewprm = 0 Then
                            MDI.mnureports.DropDownItems(i).Visible = False
                        End If
                    Case Is = 10
                        MDI.mnuutilities.DropDownItems(i).Visible = True
                        If addprm = 0 And editprm = 0 And delprm = 0 And viewprm = 0 Then
                            MDI.mnuutilities.DropDownItems(i).Visible = False
                        End If
                End Select
            Next
            'MDI.MenuStrip1.Items.Add("x")
            'MDI.mnu_student.Items.Add(new MenuItem(dr["Title"].ToString(),  dr["URL"].ToString(), dr["ID"].ToString()))
        End If
        '    End If
        'Next
    End Sub

    Public Sub menu_update()
        Start1()
        SQLInsert("DELETE FROM menumst")
        'COMPANY MENU
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (1,'Configuration','mnuconfig',0,0,1,'C',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (2,'Company Info','mnuconfig',1,1,1,'C',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (3,'Settings','mnucompset',1,1,1,'C',0,0,0,0,'N','Y')")
        'SECURITY MENU
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (4,'Security','mnusecurity',0,0,2,'X',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (5,'Create New User','mnunewuser',1,4,2,'X',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (6,'Assign User Permission','mnuuserpermission',1,4,2,'X',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (7,'Password Change','mnuchngpswd',1,4,2,'X',0,0,0,0,'N','Y')")
        'MASTER MENU
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (8,'Master','mnumaster',0,0,3,'MM',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (9,'University Master','mnuunv',1,8,3,'MS',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (10,'Session Master','mnuSession',1,8,3,'MS',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (11,'Class Master','mnuclasss',1,8,3,'MS',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (12,'Branch Master','mnubranch',1,8,3,'MA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (13,'Collection A/c Master','mnuCollection',1,8,3,'MA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (14,'Party Head Of A/c Master','mnuParty',1,8,3,'MA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (15,'Unit Master','mnuUnit',1,8,3,'MI',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (16,'Tax Master','mnuTax',1,8,3,'MI',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (17,'Storage Point Master','mnuStorage',1,8,3,'MI',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (18,'Product Group','mnuProductgrp',1,8,3,'MI',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (19,'Product Master','mnuProduct',1,8,3,'MI',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (20,'Subject Master','mnuSubject',1,8,3,'M',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (21,'Exam Group','mnuExamGroup',1,8,3,'ME',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (22,'Exam Master','mnuExam',1,8,3,'ME',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (23,'Period Group','mnuPeriodGroup',1,8,3,'M',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (24,'Period Master','mnuPeriod',1,8,3,'M',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (25,'Department Master','mnuDepartment',1,8,3,'M',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (26,'Designation Master','mnuDesignation',1,8,3,'M',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (27,'Employee Master','mnuEmployee',1,8,3,'M',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (28,'Country Master','mnuCountry',1,8,3,'M',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (29,'State Master','mnuState',1,8,3,'M',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (30,'District Master','mnuDistrict',1,8,3,'M',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (31,'Qualification Master','mnuQualification',1,8,3,'M',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (32,'Occupation Master','mnuOccupation',1,8,3,'M',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (33,'Book Master','mnubookmst',1,8,3,'ML',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (34,'Author Master','mnuauthr',1,8,3,'ML',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (35,'Publication Master','mnupublictn',1,8,3,'ML',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (36,'Shelf Master','mnushelf',1,8,3,'ML',0,0,0,0,'N','Y')")

        'STUDENTS MENU
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (37,'Student','mnu_student',0,0,4,'S',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (38,'Student Enquiry.','mnustudenq',1,36,4,'S',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (39,'Student Registration.','mnustudreg',1,36,4,'S',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (40,'Subject Assignment.','mnusubassign',1,36,4,'S',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (41,'Student Promotion.','mnuStudPromot',1,36,4,'S',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (42,'Student Leave.','mnustudlv',1,36,4,'S',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (43,'Student Passed Out.','mnustudout',1,36,4,'S',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (44,'Branch Change','mnuTradeChange',1,36,4,'S',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (45,'Upload / Download.','mnuupload',1,36,4,'S',0,0,0,0,'N','Y')")
        'ACCOUNTS MENU
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (46,'Accounts','mnuaccounts',0,0,5,'A',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (47,'Payment Schedule.','mnuPaySchedule',1,45,5,'A',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (48,'Scheduled Fees Collection.','mnuFeeColl_SC',1,45,5,'A',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (49,'Non-Scheduled Fees Collection.','mnuFeeColl_NSC',1,45,5,'A',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (50,'Penalty Impose.','mnuPenalty',1,45,5,'A',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (51,'Reciept Voucher.','mnuRec_Vouc',1,45,5,'A',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (52,'Payment Voucher.','mnuPayVouc',1,45,5,'A',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (53,'Journal Voucher.','mnuJrn_Vouc',1,45,5,'A',0,0,0,0,'N','Y')")
        'INVENTORY MENU
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (54,'Inventory','mnuinventory',0,0,6,'I',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (55,'Purchase Order.','mnuporder',1,53,6,'I',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (56,'Purchase Invoice.','mnupurinv',1,53,6,'I',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (57,'Purchase Return.','mnupret',1,53,6,'I',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (58,'Issue Of Products.','mnuissue',1,53,6,'I',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (59,'Refund Of Products.','mnurefund',1,53,6,'I',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (60,'Inter Godown Transfer.','mnuintrgdn',1,53,6,'I',0,0,0,0,'N','Y')")
        'EXAMINATION MENU
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (61,'Examination','mnuexamination',0,0,7,'E',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (62,'Student Exam Results.','mnuexamresult',1,60,7,'E',0,0,0,0,'N','Y')")
        'LIBRARY MENU
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (63,'Library','mnulibrary',0,0,8,'L',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (64,'Purchase of Books.','mnubkpur',1,62,8,'L',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (65,'Scrolling Of Books.','mnubkscrl',1,62,8,'L',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (66,'Issue Of Books.','mnubkiss',1,62,8,'L',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (67,'Return Of Books.','mnubkret',1,62,8,'L',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (68,'Rejection OF Books.','mnubkrej',1,62,8,'L',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (69,'Book Search.','mnubksearch',1,62,8,'L',0,0,0,0,'N','Y')")
        'REPORTS MENU
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (70,'Reports','mnureports',0,0,9,'RR',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (71,'Student Admission Register.','rep_studreg',1,68,9,'RM',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (72,'Employee Register.','mnuemplyee',1,68,9,'RM',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (73,'Payment Schedule Register(All).','mnupaschdall',1,68,9,'RA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (74,'Payment Schedule Register(Individual).','mnupayschd',1,68,9,'RA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (75,'Scheduled Collection Register(All).','mnuschdcolreg',1,68,9,'RA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (76,'Scheduled Collection Register(Individual).','mnuschdcolregindvdl',1,68,9,'RA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (77,'Non-Scheduled Collection Register(All).','mnuNschdcolreg',1,68,9,'RA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (78,'Non-Scheduled Collection Register(Individual).','mnuNschdcolregindvdl',1,68,9,'RA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (79,'Student Ledger.','mnustudledg',1,68,9,'RA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (80,'Student Ledger(Student Wise).','mnustudledger',1,68,9,'RA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (81,'Cashbook / Daybook.','repcashbook',1,68,9,'RA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (82,'Party Ledger.','mnuprtledger',1,68,9,'RA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (83,'Reciept Ledger.','mnurecledg',1,68,9,'RA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (84,'Payment Ledger.','mnupayledg',1,68,9,'RA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (85,'Journal Ledger.','mnujrnledg',1,68,9,'RA',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (86,'Purchase Order Register.','mnuorderreg',1,68,9,'RI',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (87,'Purchase Register.','mnupurchreg',1,68,9,'RI',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (88,'Purche Return Register.','mnupurchretreg',1,68,9,'RI',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (89,'Issue Register.','mnuissureg',1,68,9,'RI',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (90,'Refund Register.','mnurefreg',1,68,9,'RI',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (91,'Book Stock Register.','mnubkstkreg',1,68,9,'RL',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (92,'Book Purchase Register.','mnubkpurreg',1,68,9,'RL',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (93,'Book Issue Register.','mnubkissreg',1,68,9,'RL',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (94,'Book Return Register.','mnubkretreg',1,68,9,'RL',0,0,0,0,'N','Y')")
        'UTILITIES MENU
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (95,'Utilities','mnuutilities',0,0,10,'U',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (96,'Database Settings.','mnudbsetting',1,92,10,'U',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (97,'Data Restore.','mnudbrestore',1,92,10,'U',0,0,0,0,'N','Y')")
        SQLInsert("INSERT INTO menumst(menu_sl,menu_nm,menu_id,menu_lvl,upr_lvl,tab_lvl,menu_tp,add_prmsn,edit_prmsn,delete_prmsn,view_prmsn,menu_lock,menu_prmsn) VALUES (98,'SMS Gateway.','mnusms',1,92,10,'U',0,0,0,0,'N','Y')")
        If attandnc = "N" Then
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_tp='I'")
            SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnuPeriodGroup'")
            SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnuPeriod'")
        End If
        If exam = "N" Then
            SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE RIGHT(menu_tp,1)='E'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnuExamGroup'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnuExam'")
        End If
        If library = "N" Then
            SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE RIGHT(menu_tp,1)='L'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnubookmst'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnuauthr'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnupublictn'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnushelf'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnubkstkreg'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnubkpurreg'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnubkissreg'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnubkretreg'")
        End If
        If inventory = "N" Then
            SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE RIGHT(menu_tp,1)='I'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnuUnit'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnuTax'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnuStorage'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnuProductgrp'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnuProductgrp'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnuorderreg'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnupurchreg'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnupurchretreg'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnuissureg'")
            'SQLInsert("UPDATE menumst SET menu_prmsn='N' WHERE menu_id='mnurefreg'")
        End If


        Close1()
    End Sub

    Public Sub data_backup()
        If dbmode = 1 Then
            con_str = "Data Source=" & srvnm & ";Initial Catalog=master;Integrated Security=True"
        Else
            con_str = "Data Source=" & srvnm & ";Initial Catalog=master;Integrated Security=False;User ID=" & dbid & ";Password=" & dbpwd & ""
        End If
        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.InitialDirectory = backup_pth
        SaveFileDialog1.Filter = "Backup Files (*.bak)|*.bak"
        SaveFileDialog1.RestoreDirectory = True
        SaveFileDialog1.Title = "Create Database Backup."
        SaveFileDialog1.FileName = dbnm & "@" + Now.ToString("dd-MM-yyyy_hh.mm.ss")
        If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            'getting backup file path.
            Dim path As String
            path = System.IO.Path.GetFullPath(SaveFileDialog1.FileName)
            Dim cn As SqlConnection
            cn = New SqlConnection(con_str)
            'Code to backup database.
            Try
                'Backup In progress...
                cmd = New SqlCommand("USE master; BACKUP DATABASE " & dbnm & " TO DISK = '" & path.ToString & "'", cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Backup Succeed!", MsgBoxStyle.Information, "Information")
                cn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                cn.Close()
            End Try
        End If
    End Sub

    Public Sub data_restore()
        If dbmode = 1 Then
            con_str = "Data Source=" & srvnm & ";Initial Catalog=master;Integrated Security=True"
        Else
            con_str = "Data Source=" & srvnm & ";Initial Catalog=master;Integrated Security=False;User ID=" & dbid & ";Password=" & dbpwd & ""
        End If
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.InitialDirectory = backup_pth
        OpenFileDialog1.Filter = "Backup Files (*.bak)|*.bak"
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.Title = "Open backup file."
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            'getting restore file path.
            Dim path As String
            path = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
            Dim cn As SqlConnection
            cn = New SqlConnection(con_str)
            'Code to restore database.
            Try
                cmd = New SqlCommand("USE master ALTER DATABASE " & dbnm & "  SET SINGLE_USER WITH ROLLBACK IMMEDIATE  RESTORE DATABASE " & dbnm & " FROM DISK = '" & path & "' ALTER DATABASE " & dbnm & " SET MULTI_USER ;", cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Data Restored Successfully.", MsgBoxStyle.Information, "Information")
                cn.Close()
                End
            Catch ex As Exception
                MsgBox(ex.Message)
                cn.Close()
            End Try
        End If
    End Sub

    'Enum Action
    '    BackUp
    '    Restore
    'End Enum

    'Private Sub Execute(ByVal strAction As Action)
    '    Dim Filename As String
    '    'ServerName1 = cmbServerName1.Text.Trim()
    '    'UserID1 = txtUserName1.Text.Trim()
    '    'Password1 = txtPassword1.Text.Trim()
    '    'database = cmbDataBase1.Text

    '    'If cmbAuthe1.SelectedIndex = 0 Then
    '    '    strConn = "Data Source=" & ServerName1 & ";Initial Catalog="  & cmbDataBase1.Text &'";Integrated Security=True"
    '    'Else
    '    '    strConn = "Data Source=" & srvnm & "; Initial Catalog=" & dbnm & ";user id=" & UserID1 & ";password=" ' & Password1 & '";Integrated Security=false"
    '    'End If

    '    If Val(dbmode) = 1 Then
    '        connectionstrng = "Data Source=" & Trim(srvnm) & ";Initial Catalog=" & Trim(dbnm) & ";Integrated Security=True"
    '    Else
    '        connectionstrng = "Data Source=" & Trim(srvnm) & ";Initial Catalog=" & Trim(dbnm) & ";Integrated Security=False;User ID=" & Trim(dbid) & ";Password=" & Trim(dbpwd) & ""
    '    End If


    '    con = New SqlConnection(strConn)
    '    con.Open()
    '    Dim strQuery As String
    '    If strAction = Action.BackUp Then
    '        Dim objdlg As New SaveFileDialog
    '        objdlg.FileName = database
    '        objdlg.ShowDialog()
    '        Filename = objdlg.FileName
    '        strQuery = "backup database " & database & " to disk='" & Filename & "'"
    '    Else
    '        Dim objdlg As New OpenFileDialog
    '        objdlg.FileName = database
    '        objdlg.ShowDialog()
    '        Filename = objdlg.FileName
    '        strQuery = "RESTORE DATABASE " ' & database & '" FROM disk='" & Filename & "'"
    '    End If

    '    Dim cmd As SqlCommand
    '    cmd = New SqlCommand(strQuery, con)
    '    cmd.ExecuteNonQuery()
    'End Sub

    Public Sub comp_check()
        Dim ds As DataSet = get_dataset("SELECT * FROM company WHERE co_sl=1")
        If ds.Tables(0).Rows.Count <> 0 Then
            cocd = ds.Tables(0).Rows(0).Item("co_cd")
            cosnm = ds.Tables(0).Rows(0).Item("co_snm")
            coph1 = ds.Tables(0).Rows(0).Item("co_ph1")
            coph2 = ds.Tables(0).Rows(0).Item("co_ph2")
            coadd = ds.Tables(0).Rows(0).Item("co_add1")
            coemail = ds.Tables(0).Rows(0).Item("co_mail")
            coweb = ds.Tables(0).Rows(0).Item("web")
            conb = ds.Tables(0).Rows(0).Item("per_nb")
            codscr = ds.Tables(0).Rows(0).Item("descri")
            cojuris = ds.Tables(0).Rows(0).Item("juri")
            stdt = ds.Tables(0).Rows(0).Item("st_date")
            endt = ds.Tables(0).Rows(0).Item("ed_date")
        End If
        If cocd = "ST0000BIN0000EIMS0000" Then
            conm = "Shradha Technologies(Demo Copy)."
            installation_dt = #5/8/2014# 'Date Format MM/DD/YYYY
            expiry_dt = installation_dt.AddYears(8)
        ElseIf cocd = "ST0001BIN0001EIMS0001" Then
            library = "N"
            attandnc = "N"
            exam = "N"
            conm = "Sai +2 Science Residential College." 'Takatpur,Baripada,Mayurbhanj
            installation_dt = #6/1/2014# 'Date Format MM/DD/YYYY
            expiry_dt = installation_dt.AddYears(8)
        ElseIf cocd = "ST0001BIN0001EIMS0002" Then
            attandnc = "N"
            exam = "N"
            conm = "Raja Kishor Chandra Academy Of Technology." 'Nilgiri,Balasore
            installation_dt = #9/1/2014# 'Date Format MM/DD/YYYY
            expiry_dt = installation_dt.AddYears(10)
        ElseIf cocd = "ST0003BIN0003EIMS0003" Then
            attandnc = "N"
            exam = "N"
            inventory = "N"
            'conm = "Radhanath +2 Science Residential College." 'Soro,Balasore
            conm = "Chitrada College." 'Chitrada,Mayurbhanj
            installation_dt = #12/22/2015# 'Date Format MM/DD/YYYY
            expiry_dt = installation_dt.AddDays(60)
        ElseIf cocd = "ST0004BIN0004EIMS0004" Then
            attandnc = "N"
            exam = "N"
            inventory = "N"
            conm = "Laxmikanta College." 'Bangriposi,Mayurbhanj
            installation_dt = #3/27/2017# 'Date Format MM/DD/YYYY
            expiry_dt = installation_dt.AddDays(60)
        ElseIf cocd = "ST0005BIN0005EIMS0005" Then
            attandnc = "N"
            exam = "N"
            'inventory = "N"
            conm = "Zisaji Presidency College." 'Nagaland
            installation_dt = #3/7/2019# 'Date Format MM/DD/YYYY
            expiry_dt = installation_dt.AddDays(60)
        Else
            MessageBox.Show("Invalid Company Liscence Please Contact Your Service Provider.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End
        End If
        MDI.lblconm.Text = conm
        MDI.Text = "Educational Institute Management System(EIMS) . . . " & ver_no & " For (" & conm & ") Dt" & sys_date & " [" & sys_date.Day & "] F.Y. " & stdt.Year & "-" & endt.Year
        Start1()
        SQLInsert("UPDATE company SET co_nm='" & conm & "' ")
        Close1()
        x = DateDiff(DateInterval.Day, sys_date, expiry_dt)
        If x <= 30 Then
            If Val(x) < 0 Then
                MDI.lblwarning.Text = "The Software Liscence Have Already Expired."
            Else
                MDI.lblwarning.Text = "The Software Liscence Will Be Expires After " & x & " Days."
            End If
            MDI.lblwarning.Visible = True
        Else
            MDI.lblwarning.Text = ""
        End If
        If sys_date >= expiry_dt Then
            MessageBox.Show("The Software Liscence is Expired.Please Renew The Liscence.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End
        End If
    End Sub

    'Public Sub prints()
    '    Dim cryRpt As New ReportDocument
    '    ' CrystalDecisions.CrystalReports.Engine.ReportDocument(report = New CrystalDecisions.CrystalReports.Engine.ReportDocument())
    '    cryRpt.Load(My.Application.Info.DirectoryPath & "\REPORTS\" & reportnm)
    '    'report.Load("Your report path")
    '    'If no printer name is given, report will be printed to default printer
    '    cryRpt.PrintOptions.PrinterName = ""
    '    cryRpt.PrintToPrinter(1, True, 0, 0)
    'End Sub

    Public Sub print_repo()
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table
        cryRpt.Load(My.Application.Info.DirectoryPath & "\REPORTS\" & reportnm)
        If dbmode = 2 Then
            With crConnectionInfo
                .ServerName = srvnm
                .DatabaseName = dbnm
                .UserID = dbid
                .Password = dbpwd
            End With
            CrTables = cryRpt.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next
        End If
        cryRpt.PrintOptions.PrinterName = ""
        cryRpt.PrintToPrinter(1, True, 0, 0)
    End Sub

    Public Sub disp_repo()
        If reportnm <> "" Then
            Dim cryRpt As New ReportDocument
            cryRpt.Load(My.Application.Info.DirectoryPath & "\REPORTS\" & reportnm)
            If dbmode = 2 Then
                Dim crtableLogoninfos As New TableLogOnInfos
                Dim crtableLogoninfo As New TableLogOnInfo
                Dim crConnectionInfo As New ConnectionInfo
                Dim CrTables As Tables
                Dim CrTable As Table
                With crConnectionInfo
                    .ServerName = srvnm
                    .DatabaseName = dbnm
                    .UserID = dbid
                    .Password = dbpwd
                End With
                CrTables = cryRpt.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
            End If
            frmviewer1.CrystalReportViewer1.ReportSource = cryRpt
            frmviewer1.CrystalReportViewer1.Refresh()
            frmviewer1.MdiParent = MDI
            frmviewer1.Show()
        End If
    End Sub

    Public Sub excel_view(ByVal dv As DataGridView)
        If dv.Rows.Count <> 0 Then
            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            xlApp = New Excel.ApplicationClass
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")
            xlWorkSheet.PageSetup.TopMargin = 100
            ph = coph1
            If coph2 <> "" Then
                ph = coph1 & "," & coph2
            End If
            Call pbstart()
            xlWorkSheet.PageSetup.CenterHeader = conm & vbCr & coadd & vbCr & "Ph :-" & ph & vbCr & hddr
            xlWorkSheet.PageSetup.LeftFooter = Format(Now, "dd/MMM/yyyy hh:mm:ss ttt")
            xlWorkSheet.PageSetup.RightFooter = usr_nm
            xlWorkSheet.PageSetup.Orientation = 2
            With xlWorkSheet
                'MDI.pb.Maximum = dv.ColumnCount + 1
                For Each col As DataGridViewColumn In dv.Columns
                    If col.Visible = True Then
                        'noms des colonnes
                        .Cells(1, col.Index + 1) = col.HeaderText
                        .Cells(1, col.Index + 1).Interior.Color = RGB(255, 255, 200) 'System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                        .Cells(1, col.Index + 1).Font.Color = RGB(250, 0, 0)
                        .Cells(1, col.Index + 1).Font.Bold = True
                        .Cells(1, col.Index + 1).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        MDI.pb.Maximum = dv.RowCount + 1
                        For Each rowa As DataGridViewRow In dv.Rows
                            .Cells(rowa.Index + 2, col.Index + 1) = rowa.Cells(col.Index).Value
                            .Cells(rowa.Index + 2, col.Index + 1).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDash
                        Next
                    End If
                    Call pbincr()
                Next
                .Columns.AutoFit()
            End With
            'Protect Workbook  
            'xlWorkSheet.Protect("binod")
            xlApp.Visible = True
            Call pbclose()
        Else
            MessageBox.Show("Sorry There is No Data To Export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub pbstart()
        MDI.pb.Visible = True
        MDI.pb.Value = 0
        MDI.pb.Width = MDI.Width - 105
    End Sub

    Public Sub pbincr()
        If MDI.pb.Value < MDI.pb.Maximum Then
            MDI.pb.Value += 1
        End If
    End Sub

    Public Sub pbclose()
        MDI.pb.Visible = False
        MDI.pb.Width = 100
    End Sub

    Public Sub global_settings()
        Dim ds As DataSet = get_dataset("SELECT * FROM gen_setting WHERE slno=1")
        If ds.Tables(0).Rows.Count <> 0 Then
            print_schd = ds.Tables(0).Rows(0).Item("print_schd")
            print_coll = ds.Tables(0).Rows(0).Item("print_coll")
            print_ocoll = ds.Tables(0).Rows(0).Item("print_ocoll")
            print_payv = ds.Tables(0).Rows(0).Item("print_payv")
            print_recv = ds.Tables(0).Rows(0).Item("print_recv")
            print_po = ds.Tables(0).Rows(0).Item("print_po")
            stud_icard = ds.Tables(0).Rows(0).Item("stud_icard")
            staff_icard = ds.Tables(0).Rows(0).Item("staff_icard")
            trst_coll = ds.Tables(0).Rows(0).Item("trst_coll")
            trst_ocoll = ds.Tables(0).Rows(0).Item("trst_ocoll")
            due_alrt = ds.Tables(0).Rows(0).Item("due_alrt")
            due_days = ds.Tables(0).Rows(0).Item("due_days")
            strt_backup = ds.Tables(0).Rows(0).Item("strt_backup")
            backup_days = ds.Tables(0).Rows(0).Item("backup_days")
            backup_pth = ds.Tables(0).Rows(0).Item("backup_pth")
            stud_bk = ds.Tables(0).Rows(0).Item("stud_bk")
            stud_bkday = ds.Tables(0).Rows(0).Item("stud_bkday")
            staf_bk = ds.Tables(0).Rows(0).Item("staf_bk")
            staf_bkday = ds.Tables(0).Rows(0).Item("staf_bkday")
            pf_per = ds.Tables(0).Rows(0).Item("pf_per")
            esic_per = ds.Tables(0).Rows(0).Item("esic_per")
            oth_deduct = ds.Tables(0).Rows(0).Item("oth_deduct")
            backup_rem = ds.Tables(0).Rows(0).Item("backup_rem")
            bday_rem = ds.Tables(0).Rows(0).Item("bday_rem")
            anvr_rem = ds.Tables(0).Rows(0).Item("anvr_rem")
            enq_rem = ds.Tables(0).Rows(0).Item("enq_rem")
            due_rem = ds.Tables(0).Rows(0).Item("due_rem")
            srvr_gsm = ds.Tables(0).Rows(0).Item("srvr_gsm")
            sms_srvr = ds.Tables(0).Rows(0).Item("sms_srvr")
            sms_id = ds.Tables(0).Rows(0).Item("sms_id")
            sms_pwd = Decrypt(Trim(ds.Tables(0).Rows(0).Item("sms_pwd")))
            sender_id = ds.Tables(0).Rows(0).Item("sender_id")
            port_no = ds.Tables(0).Rows(0).Item("port_no")
            smtp_srvr = ds.Tables(0).Rows(0).Item("smtp_srvr")
            mail_id = ds.Tables(0).Rows(0).Item("mail_id")
            mail_pwd = Decrypt(Trim(ds.Tables(0).Rows(0).Item("mail_pwd")))
            stud_sms = ds.Tables(0).Rows(0).Item("stud_sms")
            fath_sms = ds.Tables(0).Rows(0).Item("fath_sms")
            moth_sms = ds.Tables(0).Rows(0).Item("moth_sms")
            grdn_sms = ds.Tables(0).Rows(0).Item("grdn_sms")
            regd_sms = ds.Tables(0).Rows(0).Item("regd_sms")
            due_sms = ds.Tables(0).Rows(0).Item("due_sms")
            coll_sms = ds.Tables(0).Rows(0).Item("coll_sms")
            reslt_sms = ds.Tables(0).Rows(0).Item("reslt_sms")

            copy_schd = ds.Tables(0).Rows(0).Item("copy_schd")
            copy_coll = ds.Tables(0).Rows(0).Item("copy_coll")
            copy_ocoll = ds.Tables(0).Rows(0).Item("copy_ocoll")
            copy_payv = ds.Tables(0).Rows(0).Item("copy_payv")
            copy_recv = ds.Tables(0).Rows(0).Item("copy_recv")
            copy_po = ds.Tables(0).Rows(0).Item("copy_po")
            copy_tcoll = ds.Tables(0).Rows(0).Item("copy_tcoll")
            copy_tocoll = ds.Tables(0).Rows(0).Item("copy_tocoll")

            studbk = ds.Tables(0).Rows(0).Item("stud_bk")
            stafbk = ds.Tables(0).Rows(0).Item("staf_bk")
        End If
    End Sub


    Public Sub stock_OUT(ByVal itqt As Decimal, ByVal itcd As Integer, ByVal prdtp As Integer, ByVal trtp As Integer)
        If Val(trtp) = 1 Then
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET iss_stk = iss_stk + (" & (itqt) & "),cl_stk = cl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            Else
                SQLInsert("UPDATE item SET diss_stk = diss_stk + (" & (itqt) & "),dcl_stk = dcl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            End If
        Else
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET rec_stk = rec_stk - (" & (itqt) & "),cl_stk = cl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            Else
                SQLInsert("UPDATE item SET drec_stk = drec_stk - (" & (itqt) & "),dcl_stk = dcl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            End If
        End If
    End Sub

    Public Sub stock_IN(ByVal itqt As Decimal, ByVal itcd As Integer, ByVal prdtp As Integer, ByVal trtp As Integer)
        If Val(trtp) = 1 Then
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET rec_stk = rec_stk + (" & (itqt) & "),cl_stk = cl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            Else
                SQLInsert("UPDATE item SET drec_stk = drec_stk + (" & (itqt) & "),dcl_stk = dcl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            End If
        Else
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET iss_stk = iss_stk + (" & (itqt) & "),cl_stk = cl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            Else
                SQLInsert("UPDATE item SET diss_stk = diss_stk + (" & (itqt) & "),dcl_stk = dcl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            End If
        End If
    End Sub

    Public Sub stock_OUTDEL(ByVal itqt As Decimal, ByVal itcd As Integer, ByVal prdtp As Integer, ByVal trtp As Integer)
        If Val(trtp) = 1 Then
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET iss_stk = iss_stk - (" & (itqt) & "),cl_stk = cl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            Else
                SQLInsert("UPDATE item SET diss_stk = diss_stk - (" & (itqt) & "),dcl_stk = dcl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            End If
        Else
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET rec_stk = rec_stk + (" & (itqt) & "),cl_stk = cl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            Else
                SQLInsert("UPDATE item SET drec_stk = drec_stk + (" & (itqt) & "),dcl_stk = dcl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            End If
        End If
    End Sub

    Public Sub stock_INDEL(ByVal itqt As Decimal, ByVal itcd As Integer, ByVal prdtp As Integer, ByVal trtp As Integer)
        If Val(trtp) = 1 Then
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET rec_stk = rec_stk - (" & (itqt) & "),cl_stk = cl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            Else
                SQLInsert("UPDATE item SET drec_stk = drec_stk - (" & (itqt) & "),dcl_stk = dcl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            End If
        Else
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET iss_stk = iss_stk - (" & (itqt) & "),cl_stk = cl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            Else
                SQLInsert("UPDATE item SET diss_stk = diss_stk - (" & (itqt) & "),dcl_stk = dcl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
            End If
        End If
    End Sub

    Public Sub image_download(ByVal imgpth As String, ByVal pict As PictureBox, ByVal width As Integer, ByVal height As Integer)
        pict.Size = New Size(width, height)
        Dim bmp As New Drawing.Bitmap(pict.Width, pict.Height)
        pict.DrawToBitmap(bmp, pict.ClientRectangle)
        bmp.Save(imgpth, System.Drawing.Imaging.ImageFormat.Jpeg)
    End Sub

End Module
