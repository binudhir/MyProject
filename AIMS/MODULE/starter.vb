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
    Public printbill As Integer                    'Printing Sales Bill Style
    Public printschal As Integer                   'Printing Sales Challan Style
    Public printsret As Integer                    'Printing Sales Return Style
    Public printpo As Integer                      'Printing Purchase Order Style
    Public printpret As Integer                    'Printing Purchase Return Style
    Public printpvouc As Integer                   'Printing Payment Voucher Style
    Public printrvouc As Integer                   'Printing Reciept Voucher Style
    Public printmr As Integer                      'Printing Money Reciept Style
    Public printcntbl As Integer                   'Printing Counter Bill Style
    Public printsrvbl As Integer                   'Printing Service Bill Style
    Public copybill As Integer                     'No Of Copies Sales Bill
    Public copyschal As Integer                    'No Of Copies Sales Challan
    Public copysret As Integer                     'No Of Copies sales Return
    Public copypo As Integer                       'No Of Copies Purchase Order
    Public copypret As Integer                     'No Of Copies Purchase Return
    Public copypvouc As Integer                    'No Of Copies Payment Voucher
    Public copyrvouc As Integer                    'No Of Copies Reciept Voucher
    Public copymr As Integer                       'No Of Copies Money Reciept
    Public copycntrbl As Integer                   'No Of Copies Counter Bill
    Public copysrvbl As Integer                     'No Of Copies Service Bill

    Public exp_alrt As String                       'Required Expiry Alert
    Public exp_days As Integer                      'Expiry Alert How many Days
    Public strt_backup As String                    'Auto Backup When Program Start
    Public backup_days As Integer                   'Backup files for How many days
    Public backup_pth As String                     'Backup Directory Path
    Public pf_per As Decimal                        'PF percentage
    Public esic_per As Decimal                      'ESIC percentage
    Public oth_deduct As Decimal                    'Other Deduction
    Public backup_rem As Integer                    'Want Backup Reminder
    Public bday_rem As Integer                      'Want Birthday Reminder
    Public anvr_rem As Integer                      'Want Aniversery Reminder
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
    Public bill_sms As Integer                      'Want To SMS Party After Sales Invoice
    Public due_sms As Integer                       'Want To SMS Party After Due
    Public pay_sms As Integer                      'Want To SMS Party About sales return
    Public rec_sms As Integer                        'Want To SMS Party About MR


    Public lnk_path As String

    Public Sub main()
        If System.IO.File.Exists(My.Application.Info.DirectoryPath & "\dblnk.dll") = False Then
            File.Create(My.Application.Info.DirectoryPath & "\dblnk.dll").Dispose()
        End If
        If (Not System.IO.Directory.Exists(My.Application.Info.DirectoryPath & "\Backup")) Then
            System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Backup")
        End If
        'If (Not System.IO.Directory.Exists(My.Application.Info.DirectoryPath & "\DATABASE")) Then
        '    System.IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\DATABASE")
        'End If
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
            '.Panel3.Visible = False
            '.Panel4.Visible = False
            '.picnxt.Visible = True
            '.picpre.Visible = True
            .Pnldur.Visible = True
            .Pnldur.Left = .Width - 400
            .mnusecurity.Enabled = True
            .mnumaster.Enabled = True
            .mnuaccounts.Enabled = True
            .mnureports.Enabled = True
            .mnucompinfo.Enabled = True
            .mnucompset.Enabled = True
            .mnu_logout.Enabled = True
            .mnu_login.Enabled = False
            .mnuinventory.Enabled = True
            If sys_date.Month = 4 Then
                .mnufy.Visible = True
            End If
            If usr_tp = "A" Then
                .mnucompinfo.Visible = True
                ' .mnucompset.Visible = True
                .mnunewuser.Visible = True
                '.mnuuserpermission.Visible = True
                '.mnureports.Visible = True
                .mnusms.Visible = True
            ElseIf usr_tp = "D" Then
                .mnucompinfo.Visible = True
                '.mnucompset.Visible = True
                .mnunewuser.Visible = True
                '.mnuuserpermission.Visible = True
                '.mnureports.Visible = True
                .mnusms.Visible = True
            ElseIf usr_tp = "M" Then
                .mnucompinfo.Visible = False
                .mnucompset.Visible = False
                .mnunewuser.Visible = False
                .mnuuserpermission.Visible = False
                '.mnureports.Visible = True
                .mnusms.Visible = False
            Else
                .mnucompinfo.Visible = False
                .mnucompset.Visible = False
                .mnunewuser.Visible = False
                .mnuuserpermission.Visible = False
                .mnureports.Visible = False
                .mnusms.Visible = False
            End If
        End With
    End Sub

    Public Sub menu_disable()
        With MDI
            '.Panel3.Visible = False
            '.Panel4.Visible = False
            '.picnxt.Visible = False
            '.picpre.Visible = False
            .lblconm.Text = ""
            .lblwarning.Visible = False
            .lblwarning.Text = ""
            .mnusecurity.Enabled = False
            .mnumaster.Enabled = False
            .mnuaccounts.Enabled = False
            .mnureports.Enabled = False
            .Pnldur.Visible = False
            .mnucompinfo.Enabled = False
            .mnucompset.Enabled = False
            .mnu_login.Enabled = True
            .mnu_logout.Enabled = False
            .mnuinventory.Enabled = False
        End With
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
                MsgBox("Backup Succeed!", MsgBoxStyle.Information)
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
                MsgBox("Data Restored Successfully.", MsgBoxStyle.Information)
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
        If cocd = "ST0000BIN0000AIMS0000" Then
            conm = "M/s. Shradha Technologies."         'VIP Colony,Balasore
            installation_dt = #4/1/2016# 'Date Format MM/DD/YYYY
            expiry_dt = installation_dt.AddYears(3)
        ElseIf cocd = "ST0001BIN0001AIMS0001" Then
            conm = "M/s. Tirupati Marbles."                 'Near Station,Soro,Balasore
            installation_dt = #4/2/2015# 'Date Format MM/DD/YYYY
            expiry_dt = installation_dt.AddYears(1)
        ElseIf cocd = "ST0002BIN0002AIMS0002" Then
            conm = "M/s. Newtech Computer."             'KMBM ROAD,Baripada
            installation_dt = #11/9/2014# 'Date Format MM/DD/YYYY
            expiry_dt = installation_dt.AddDays(60)
        ElseIf cocd = "ST0004BIN0003AIMS0003" Then
            conm = "M/s. Thomson Enterprises."          'Betnoti,Mayurbhanj
            installation_dt = #11/23/2014# 'Date Format MM/DD/YYYY
            expiry_dt = installation_dt.AddYears(2)
        ElseIf cocd = "ST0004BIN0004AIMS0004" Then
            conm = "M/s. S.K. Engineering."          'Nilgiri,Balasore
            installation_dt = #11/14/2016# 'Date Format MM/DD/YYYY
            expiry_dt = installation_dt.AddYears(3)
        ElseIf cocd = "ST0005BIN0005AIMS0005" Then
            conm = "M/s. Devi Electronics."          'Nilgiri,Balasore
            installation_dt = #9/21/2017# 'Date Format MM/DD/YYYY
            expiry_dt = installation_dt.AddDays(30)
        Else
            MessageBox.Show("Invalid Company Liscence Please Contact Your Service Provider.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End
        End If
        MDI.lblconm.Text = conm
        MDI.Text = "Accounts And Inventory Management System (AIMS) . . . " & ver_no & " For (" & conm & ") Dt" & sys_date & " [" & sys_date.Day & "] F.Y. " & stdt.Year & "-" & endt.Year
        Start1()
        SQLInsert("UPDATE company SET co_nm='" & conm & "' ")
        Close1()
        x = DateDiff(DateInterval.Day, sys_date, expiry_dt)
        If x <= 30 Then
            MDI.lblwarning.Text = "The Software Liscence Will Be Expires After " & x & " Days."
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
                    Call pbincr()
                Next
                .Columns.AutoFit()
            End With
            'Protect Workbook  
            'xlWorkSheet.Protect("")
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
            printbill = ds.Tables(0).Rows(0).Item("print_bill")
            printschal = ds.Tables(0).Rows(0).Item("print_schal")
            printsret = ds.Tables(0).Rows(0).Item("print_sret")
            printpo = ds.Tables(0).Rows(0).Item("print_po")
            printpret = ds.Tables(0).Rows(0).Item("print_pret")
            printpvouc = ds.Tables(0).Rows(0).Item("print_pvouc")
            printrvouc = ds.Tables(0).Rows(0).Item("print_rvouc")
            printmr = ds.Tables(0).Rows(0).Item("print_mr")
            printcntbl = ds.Tables(0).Rows(0).Item("print_cntbl")
            printsrvbl = ds.Tables(0).Rows(0).Item("print_srvbl")
            copybill = Val(ds.Tables(0).Rows(0).Item("copy_bill")) - 1
            copyschal = Val(ds.Tables(0).Rows(0).Item("copy_schal")) - 1
            copysret = Val(ds.Tables(0).Rows(0).Item("copy_sret")) - 1
            copypo = Val(ds.Tables(0).Rows(0).Item("copy_po")) - 1
            copypret = Val(ds.Tables(0).Rows(0).Item("copy_pret")) - 1
            copypvouc = Val(ds.Tables(0).Rows(0).Item("copy_pvouc")) - 1
            copyrvouc = Val(ds.Tables(0).Rows(0).Item("copy_rvouc")) - 1
            copymr = Val(ds.Tables(0).Rows(0).Item("copy_mr")) - 1
            copycntrbl = Val(ds.Tables(0).Rows(0).Item("copy_cntbl")) - 1
            copysrvbl = Val(ds.Tables(0).Rows(0).Item("copy_srvbl")) - 1
            exp_alrt = ds.Tables(0).Rows(0).Item("exp_alrt")
            exp_days = ds.Tables(0).Rows(0).Item("exp_days")
            strt_backup = ds.Tables(0).Rows(0).Item("start_backup")
            backup_days = ds.Tables(0).Rows(0).Item("backup_days")
            backup_pth = ds.Tables(0).Rows(0).Item("backup_path")
            pf_per = ds.Tables(0).Rows(0).Item("pf_per")
            esic_per = ds.Tables(0).Rows(0).Item("esic_per")
            oth_deduct = ds.Tables(0).Rows(0).Item("oth_deduct")
            backup_rem = ds.Tables(0).Rows(0).Item("backup_rem")
            bday_rem = ds.Tables(0).Rows(0).Item("bday_rem")
            anvr_rem = ds.Tables(0).Rows(0).Item("anvr_rem")
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
            bill_sms = ds.Tables(0).Rows(0).Item("bill_sms")
            due_sms = ds.Tables(0).Rows(0).Item("due_sms")
            pay_sms = ds.Tables(0).Rows(0).Item("pay_sms")
            rec_sms = ds.Tables(0).Rows(0).Item("rec_sms")
        End If
    End Sub

    Public Sub stock_OUT(ByVal itqt As Decimal, ByVal itcd As Integer, ByVal batcd As Integer, ByVal prdtp As Integer, ByVal trtp As Integer)
        If Val(trtp) = 1 Then
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET iss_stk = iss_stk + (" & (itqt) & "),cl_stk = cl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET iss_stk = iss_stk + (" & (itqt) & "),cl_stk = cl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            Else
                SQLInsert("UPDATE item SET diss_stk = diss_stk + (" & (itqt) & "),dcl_stk = dcl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET diss_stk = diss_stk + (" & (itqt) & "),dcl_stk = dcl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            End If
        Else
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET rec_stk = rec_stk - (" & (itqt) & "),cl_stk = cl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET rec_stk = rec_stk - (" & (itqt) & "),cl_stk = cl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            Else
                SQLInsert("UPDATE item SET drec_stk = drec_stk - (" & (itqt) & "),dcl_stk = dcl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET drec_stk = drec_stk - (" & (itqt) & "),dcl_stk = dcl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            End If
        End If
    End Sub

    Public Sub stock_IN(ByVal itqt As Decimal, ByVal itcd As Integer, ByVal batcd As Integer, ByVal prdtp As Integer, ByVal trtp As Integer)
        If Val(trtp) = 1 Then
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET rec_stk = rec_stk + (" & (itqt) & "),cl_stk = cl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET rec_stk = rec_stk + (" & (itqt) & "),cl_stk = cl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            Else
                SQLInsert("UPDATE item SET drec_stk = drec_stk + (" & (itqt) & "),dcl_stk = dcl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET drec_stk = drec_stk + (" & (itqt) & "),dcl_stk = dcl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            End If
        Else
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET iss_stk = iss_stk + (" & (itqt) & "),cl_stk = cl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET iss_stk = iss_stk + (" & (itqt) & "),cl_stk = cl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            Else
                SQLInsert("UPDATE item SET diss_stk = diss_stk + (" & (itqt) & "),dcl_stk = dcl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET diss_stk = diss_stk + (" & (itqt) & "),dcl_stk = dcl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            End If
        End If
    End Sub

    Public Sub stock_OUTDEL(ByVal itqt As Decimal, ByVal itcd As Integer, ByVal batcd As Integer, ByVal prdtp As Integer, ByVal trtp As Integer)
        If Val(trtp) = 1 Then
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET iss_stk = iss_stk - (" & (itqt) & "),cl_stk = cl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET iss_stk = iss_stk - (" & (itqt) & "),cl_stk = cl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            Else
                SQLInsert("UPDATE item SET diss_stk = diss_stk - (" & (itqt) & "),dcl_stk = dcl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET diss_stk = diss_stk - (" & (itqt) & "),dcl_stk = dcl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            End If
        Else
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET rec_stk = rec_stk + (" & (itqt) & "),cl_stk = cl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET rec_stk = rec_stk + (" & (itqt) & "),cl_stk = cl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            Else
                SQLInsert("UPDATE item SET drec_stk = drec_stk + (" & (itqt) & "),dcl_stk = dcl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET drec_stk = drec_stk + (" & (itqt) & "),dcl_stk = dcl_stk + (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            End If
        End If
    End Sub

    Public Sub stock_INDEL(ByVal itqt As Decimal, ByVal itcd As Integer, ByVal batcd As Integer, ByVal prdtp As Integer, ByVal trtp As Integer)
        If Val(trtp) = 1 Then
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET rec_stk = rec_stk - (" & (itqt) & "),cl_stk = cl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET rec_stk = rec_stk - (" & (itqt) & "),cl_stk = cl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            Else
                SQLInsert("UPDATE item SET drec_stk = drec_stk - (" & (itqt) & "),dcl_stk = dcl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET drec_stk = drec_stk - (" & (itqt) & "),dcl_stk = dcl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            End If
        Else
            If Val(prdtp = 1) Then
                SQLInsert("UPDATE item SET iss_stk = iss_stk - (" & (itqt) & "),cl_stk = cl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET iss_stk = iss_stk - (" & (itqt) & "),cl_stk = cl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            Else
                SQLInsert("UPDATE item SET diss_stk = diss_stk - (" & (itqt) & "),dcl_stk = dcl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & "")
                SQLInsert("UPDATE batno SET diss_stk = diss_stk - (" & (itqt) & "),dcl_stk = dcl_stk - (" & (itqt) & ") WHERE it_cd=" & Val(itcd) & " AND bat_cd=" & Val(batcd) & "")
            End If
        End If
    End Sub

    Public Sub print_Details(ByVal txt As TextBox, ByVal lbl As Label, ByVal stlno As Integer)
       Select stlno
            Case Is = 1
                If Val(txt.Text) = 1 Then
                    lbl.Text = "Windows Print Default Half Page"
                ElseIf Val(txt.Text) = 2 Then
                    lbl.Text = "Windows Print Default Full Page"
                ElseIf Val(txt.Text) = 3 Then
                    lbl.Text = "Windows Print Default Half Page When Item Exceed 10 Then Full Page"
                ElseIf Val(txt.Text) = 4 Then
                    lbl.Text = "Windows Print Sale Bill Full Page For S.K Engineering"
                ElseIf Val(txt.Text) = 5 Then
                    lbl.Text = "Windows Print Sale Bill Half Page With Logo Print"
                ElseIf Val(txt.Text) = 6 Then
                    lbl.Text = "Windows Print  Sale Bill Full Page for GST Double Page"
                Else
                    lbl.Text = "Invalid Printing Format.The Printer May Not Support This Type Of Format."
                End If
            Case Is = 2
                If Val(txt.Text) = 1 Then
                    lbl.Text = "Windows Print Default Half Page"
                ElseIf Val(txt.Text) = 2 Then
                    lbl.Text = "Windows Print Default Full Page"
                ElseIf Val(txt.Text) = 3 Then
                    lbl.Text = "Windows Print Default Half Page When Item Exceed 10 Then Full Page"
                Else
                    lbl.Text = "Invalid Printing Format.The Printer May Not Support This Type Of Format."
                End If
            Case Is = 3
                If Val(txt.Text) = 1 Then
                    lbl.Text = "Windows Print Default Half Page"
                ElseIf Val(txt.Text) = 2 Then
                    lbl.Text = "Windows Print Default Full Page"
                ElseIf Val(txt.Text) = 3 Then
                    lbl.Text = "Windows Print Default Half Page When Item Exceed 10 Then Full Page"
                Else
                    lbl.Text = "Invalid Printing Format.The Printer May Not Support This Type Of Format."
                End If
            Case Is = 4
                If Val(txt.Text) = 1 Then
                    lbl.Text = "Windows Print Default Half Page"
                ElseIf Val(txt.Text) = 2 Then
                    lbl.Text = "Windows Print Default Full Page"
                ElseIf Val(txt.Text) = 3 Then
                    lbl.Text = "Windows Print Default Half Page When Item Exceed 10 Then Full Page"
                Else
                    lbl.Text = "Invalid Printing Format.The Printer May Not Support This Type Of Format."
                End If
            Case Is = 5
                If Val(txt.Text) = 1 Then
                    lbl.Text = "Windows Print Default Half Page"
                ElseIf Val(txt.Text) = 2 Then
                    lbl.Text = "Windows Print Default Full Page"
                ElseIf Val(txt.Text) = 3 Then
                    lbl.Text = "Windows Print Default Half Page When Item Exceed 10 Then Full Page"
                Else
                    lbl.Text = "Invalid Printing Format.The Printer May Not Support This Type Of Format."
                End If
            Case Is = 6
                If Val(txt.Text) = 1 Then
                    lbl.Text = "Windows Print Default Half Page"
                Else
                    lbl.Text = "Invalid Printing Format.The Printer May Not Support This Type Of Format."
                End If
            Case Is = 7
                If Val(txt.Text) = 1 Then
                    lbl.Text = "Windows Print Default Half Page"
                Else
                    lbl.Text = "Invalid Printing Format.The Printer May Not Support This Type Of Format."
                End If
            Case Is = 8
                If Val(txt.Text) = 1 Then
                    lbl.Text = "Windows Print Default Half Page"
                Else
                    lbl.Text = "Invalid Printing Format.The Printer May Not Support This Type Of Format."
                End If
            Case Is = 9
                If Val(txt.Text) = 1 Then
                    lbl.Text = "Windows Print Default Half Page"
                ElseIf Val(txt.Text) = 2 Then
                    lbl.Text = "Windows Print Default Full Page"
                ElseIf Val(txt.Text) = 3 Then
                    lbl.Text = "Windows Print Default Half Page When Item Exceed 10 Then Full Page"
                Else
                    lbl.Text = "Invalid Printing Format.The Printer May Not Support This Type Of Format."
                End If
            Case Is = 10
                If Val(txt.Text) = 1 Then
                    lbl.Text = "Windows Print Default Half Page"
                ElseIf Val(txt.Text) = 2 Then
                    lbl.Text = "Windows Print Default Full Page"
                ElseIf Val(txt.Text) = 3 Then
                    lbl.Text = "Windows Print Default Half Page When Item Exceed 10 Then Full Page"
                Else
                    lbl.Text = "Invalid Printing Format.The Printer May Not Support This Type Of Format."
                End If

        End Select
    End Sub

    Public Sub finance_year()
        Dim cn As SqlConnection
        fydbnm = dbnm
        fydbnm = InputBox("Please Provide a Database Name(Ex:SKE001,SKE17_18).", "Database Name", fydbnm)
        dbpath = My.Application.Info.DirectoryPath & "\DATABASE\"
        'creating and initializing the connection string
        Dim myConnectionString As SqlConnection = New SqlConnection("Data Source=" & Trim(srvnm) & ";Initial Catalog=" & dbnm & ";Integrated Security=True;Pooling=False")
        'since we need to create a new database set the Initial Catalog as Master
        'Which means we are creating database under master DB
        Dim myCommand As String 'to store the sql command to be executed
        'myCommand = "CREATE database " & fydbnm & "" 'the command that creates new database

        'the command that creates new database")
        myCommand = "CREATE DATABASE " & fydbnm & " ON " & _
                    "( NAME = " & fydbnm & ",FILENAME = '" & dbpath & "\" & fydbnm & ".mdf ',SIZE = 10,MAXSIZE = 50,FILEGROWTH = 5 )" & _
                    "LOG ON" & _
                    "( NAME = '" & fydbnm & "_log',FILENAME = '" & dbpath & "\" & fydbnm & "_log.ldf',SIZE = 5MB,MAXSIZE = 25MB,FILEGROWTH = 5MB )"



        Dim cmd As SqlCommand = New SqlCommand(myCommand, myConnectionString) ' creating command for execution
        Try
            cmd.Connection.Open() 'open a connection with cmd
            cmd.ExecuteNonQuery() 'Execute the query
            cmd.Connection.Close() 'Close the connection
            MessageBox.Show("Database Created Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            msg = ex.Message
            Exit Sub
        End Try
        'Creating table to the dynamicaly created database
        Try
            If Val(dbmode) = 1 Then
                cn = New SqlConnection("Data Source=" & Trim(srvnm) & ";Initial Catalog=" & Trim(fydbnm) & ";Integrated Security=True")
            Else
                cn = New SqlConnection("Data Source=" & Trim(srvnm) & ";Initial Catalog=" & Trim(fydbnm) & ";Integrated Security=False;User ID=" & Trim(dbid) & ";Password=" & Trim(dbpwd) & "")
            End If
            'here the connection string is initialized with Initial Catalog as my_db
            Dim sql As String 'sql query string
            Dim ds As DataSet = get_dataset("SELECT name From Sysobjects WHERE type='u' ORDER by Name")
            If ds.Tables(0).Rows.Count <> 0 Then
                pbstart()
                MDI.pb.Maximum = ds.Tables(0).Rows.Count
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    tblnm = ds.Tables(0).Rows(i).Item(0)
                    sql = "SELECT * INTO " & fydbnm & ".dbo." & tblnm & " from " & dbnm & ".dbo." & tblnm & ""
                    cmd = New SqlCommand(sql, cn) ' create command with connection and query string 
                    cmd.Connection.Open()
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    pbincr()
                Next
            End If
            pbclose()
            'New Connection String

            If Val(dbmode) = 1 Then
                connectionstrng = "Data Source=" & Trim(srvnm) & ";Initial Catalog=" & Trim(fydbnm) & ";Integrated Security=True"
            Else
                connectionstrng = "Data Source=" & Trim(srvnm) & ";Initial Catalog=" & Trim(fydbnm) & ";Integrated Security=False;User ID=" & Trim(dbid) & ";Password=" & Trim(dbpwd) & ""
            End If
            'Delete Transaction
            Dim str As String
            Dim strArr() As String
            Dim count As Integer
            str = "crnote,csale1,csale2,frmveh1,frmveh2,ig1,ig2,isale,isale1,iss1,iss2,jrn1," & _
            "jrn2,mr,othtr1,othtr2,pchal1,pchal2,porder1,porder2,pret1,pret2,print_cashbook,print_order," & _
            "print_prtledg,print_salebill,print_servbill,purch1,purch2,rinbill,schal1,schal2,sending_sms," & _
            "serv1,serv2,sret1,sret2,tinbill,toveh1,toveh2,vouc,voucp,pchal_slno,pret_slno,pur_slno," & _
            "sale_slno,schal_slno,sret_slno,opgodown"
            strArr = str.Split(",")
            For count = 0 To strArr.Length - 1
                tablnm = strArr(count)
                Start1()
                SQLInsert("DELETE FROM " & tablnm & "")
                Close1()
            Next

            'Transfer Closing balance to Opening in Party and Update Serial No
            Start1()
            SQLInsert("DELETE FROM mast_slno WHERE io_pos='O'")
            SQLInsert("UPDATE mast_slno SET trans='N' WHERE io_pos='I'")
            SQLInsert("UPDATE party SET op_bal=cl_amt, cr_amt=0,dr_amt=0")
            SQLInsert("UPDATE batno SET op_stk=cl_stk,dop_stk=dcl_stk,rec_stk=0,iss_stk=0,drec_stk=0,diss_stk=0 ")
            Close1()

            'Transfer Closing Stock to Opening in Item
            ds = get_dataset("SELECT it_cd,cl_stk,dcl_stk FROM item ORDER BY it_cd")
            Call pbstart()
            If ds.Tables(0).Rows.Count <> 0 Then
                MDI.pb.Maximum = ds.Tables(0).Rows.Count
                Start1()
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    itcd = ds.Tables(0).Rows(i).Item(0)
                    sqty = ds.Tables(0).Rows(i).Item(1)
                    dqty = ds.Tables(0).Rows(i).Item(2)
                    Dim ds1 As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM opgodown")
                    mxno = 1
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                            mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                        End If
                    End If
                    SQLInsert("INSERT INTO opgodown(slno, it_cd, op_stkp,op_stks, godsl) VALUES (" & Val(mxno) & "," & _
                          Val(itcd) & "," & Val(sqty) & "," & Val(dqty) & ",1)")
                    SQLInsert("UPDATE item SET op_stk=cl_stk,dop_stk=dcl_stk,rec_stk=0,iss_stk=0,drec_stk=0,diss_stk=0 WHERE it_cd=" & itcd & "")
                    pbincr()
                Next
                Close1()
            End If
            pbclose()
            MessageBox.Show("Financial Year Closing Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Path Writting
            'Dim TextLine As String
            'Dim objReader As New System.IO.StreamReader(lnk_path)
            'rw = ""
            'Do While objReader.Peek() <> -1
            '    TextLine = objReader.ReadLine() & vbNewLine
            '    'asd = TextLine.Split(",")
            '    rw = rw & TextLine
            'Loop
            'objReader.Close()
            'rw = rw & vbNewLine & dbnm & " ," & srvnm & "," & dbid & "," & dbpwd & "," & dbmode





            'Dim objWriter As New System.IO.StreamWriter(lnk_path)
            ''objWriter.Write("")
            'objWriter.WriteLine(rw)
            'objWriter.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            msg = ex.Message
        End Try

    End Sub
End Module
