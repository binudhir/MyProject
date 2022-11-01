Option Explicit Off
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Module funct
    Public Function ULCASE(ByVal str As String)
        Dim s2 As String = StrConv(Trim(str), VbStrConv.ProperCase)
        ULCASE = s2
    End Function

    Public Sub populate(ByVal cmb As ComboBox, ByVal str As String)
        cmb.Height = 120
        cmb.Text = ""
        cmb.Items.Clear()
        Start1()
        Dim dspop As DataSet = get_dataset(str)
        If dspop.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dspop.Tables(0).Rows.Count - 1
                cmb.Items.Add(dspop.Tables(0).Rows(i).Item(0))
            Next
        End If

        dspop.Clear()
        Close1()
    End Sub

    Public Sub vdated(ByVal txt As Control, ByVal str As String)
        Start1()
        Dim ds As DataSet = get_dataset(str)
        If ds.Tables(0).Rows.Count <> 0 Then
            txt.Text = ds.Tables(0).Rows(0).Item(0)
        End If
        Close1()
    End Sub

    Public Sub vdating(ByVal cmb As Control, ByVal str As String, ByVal msg As String)
        If cmb.Text <> "" Then
            Start1()
            Dim ds As DataSet = get_dataset(str)
            If ds.Tables(0).Rows.Count = 0 Then
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmb.Focus()
            End If
            Close1()
        End If
    End Sub

    Public Sub NUM(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Public Sub key(ByVal txt As Control, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            txt.Focus()
        End If
    End Sub

    Public Sub SPKey(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 34 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        End If
    End Sub

    Public Sub NUM1(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
        If e.KeyChar = "." Then
            e.Handled = False
        End If
    End Sub

    Private Function Abs(ByVal fig As Object) As Object
        Throw New NotImplementedException
    End Function

    Private Function WorksheetFunction() As Object
        Throw New NotImplementedException
    End Function

    Private Function Array(ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, ByVal p4 As String, ByVal p5 As String, ByVal p6 As String, ByVal p7 As String, ByVal p8 As String, ByVal p9 As String, ByVal p10 As String, ByVal p11 As String, ByVal p12 As String, ByVal p13 As String, ByVal p14 As String, ByVal p15 As String, ByVal p16 As String, ByVal p17 As String, ByVal p18 As String, ByVal p19 As String, ByVal p20 As String, ByVal p21 As String, ByVal p22 As String, ByVal p23 As String, ByVal p24 As String, ByVal p25 As String, ByVal p26 As String, ByVal p27 As String, ByVal p28 As String) As Object
        Throw New NotImplementedException
    End Function

    Public Function CheckConnection() As Boolean
        'Checking Of Internet Connection Avalable Or Not
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

    Function words(ByVal fig) As String
        word = Left(fig, 2)
        If word = "11" And word = "12" And word = "13" Then
            word = word & "th"
        Else
            x = Right(word, 1)
            If x = "1" Then
                word = fig & "st"
            ElseIf x = "2" Then
                word = fig & "nd"
            ElseIf x = "3" Then
                word = fig & "rd"
            Else
                word = fig & "th"
            End If
        End If
        Return word
    End Function

    Public Function Encrypt(ByVal clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

    Public Function Decrypt(ByVal cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function

    Public Function sms_balance() As Integer
        If sms_id <> "" And sms_pwd <> "" Then
            Try
                Dim url As New Uri("http://bulksms.shradhatechnologies.com/api/checkBalance.asp?username=" & sms_id & "&password=" & sms_pwd & "")
                'Creating a variable for WebRequest'
                Dim req As WebRequest
                req = WebRequest.Create(url)
                'Creating a variable for WebResponse'
                Dim resp As WebResponse
                'Try and catch clause, to catch if there is error'
                resp = req.GetResponse()
                Dim reader As StreamReader
                reader = New StreamReader(resp.GetResponseStream())
                Dim balance_str As String = Trim(reader.ReadToEnd.Trim())
                resp.Close()
                'Getting user balance into a label'
                sms_balance = balance_str
                Return sms_balance
                req = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Function
    'For for that have not Swap Option
    Public Sub usrprmsn(ByVal mnunm As String, ByVal cmnuadd As ToolStripMenuItem, ByVal cmnuedit As ToolStripMenuItem, ByVal cmenudel As ToolStripMenuItem, ByVal cmenuview As ToolStripMenuItem)
        Start1()
        Dim dspop As DataSet = get_dataset("SELECT user_assign.add_prm, user_assign.edit_prm, user_assign.delete_prm, user_assign.view_prm, user_assign.menu_sl FROM user_assign LEFT OUTER JOIN menumst ON user_assign.menu_sl = menumst.menu_sl WHERE (user_assign.user_sl = " & usr_sl & ") AND (menumst.menu_id = '" & mnunm & "')")
        If dspop.Tables(0).Rows.Count <> 0 Then
            addprmsn = dspop.Tables(0).Rows(0).Item("add_prm")
            editprmsn = dspop.Tables(0).Rows(0).Item("edit_prm")
            delprmsn = dspop.Tables(0).Rows(0).Item("delete_prm")
            viewprmsn = dspop.Tables(0).Rows(0).Item("view_prm")
            If viewprmsn = 0 Then
                cmenuview.Enabled = False
            Else
                cmenuview.Enabled = True
            End If
            If addprmsn = 0 Then
                cmnuadd.Enabled = False
            Else
                cmnuadd.Enabled = True
            End If
            If editprmsn = 0 Then
                cmnuedit.Enabled = False
            Else
                cmnuedit.Enabled = True
            End If
            If delprmsn = 0 Then
                cmenudel.Enabled = False
            Else
                cmenudel.Enabled = True
            End If
        End If
        dspop.Clear()
        Close1()
    End Sub
    'For for that have Swap Option
    Public Function swapprmsn(ByVal mnunm As String, ByVal comd As String) As String
        Dim cmd As String
        Start1()
        Dim dspop As DataSet = get_dataset("SELECT user_assign.add_prm, user_assign.edit_prm, user_assign.delete_prm, user_assign.view_prm, user_assign.menu_sl FROM user_assign LEFT OUTER JOIN menumst ON user_assign.menu_sl = menumst.menu_sl WHERE (user_assign.user_sl = " & usr_sl & ") AND (menumst.menu_id = '" & mnunm & "')")
        If dspop.Tables(0).Rows.Count <> 0 Then
            addprmsn = dspop.Tables(0).Rows(0).Item("add_prm")
            editprmsn = dspop.Tables(0).Rows(0).Item("edit_prm")
            delprmsn = dspop.Tables(0).Rows(0).Item("delete_prm")
            viewprmsn = dspop.Tables(0).Rows(0).Item("view_prm")
            cmd = comd
            'If cmd = "E" Then
            '    If editprmsn = 1 Then
            '        cmd = "M"
            '    End If
            '    If delprmsn = 1 Then
            '        cmd = "D"
            '    End If
            '    If viewprmsn = 1 Then
            '        cmd = "V"
            '    End If
            'Else
            If cmd = "M" Then
                If delprmsn = 1 Then
                    cmd = "D"
                ElseIf viewprmsn = 1 Then
                    cmd = "V"
                ElseIf addprmsn = 1 Then
                    cmd = "E"
                End If
            ElseIf cmd = "D" Then
                If viewprmsn = 1 Then
                    cmd = "V"
                ElseIf addprmsn = 1 Then
                    cmd = "E"
                ElseIf editprmsn = 1 Then
                    cmd = "M"
                End If
            ElseIf cmd = "V" Then
                If addprmsn = 1 Then
                    cmd = "E"
                ElseIf editprmsn = 1 Then
                    cmd = "M"
                ElseIf delprmsn = 1 Then
                    cmd = "D"
                End If
            Else
                If editprmsn = 1 Then
                    cmd = "M"
                ElseIf addprmsn = 1 Then
                    cmd = "E"
                ElseIf delprmsn = 1 Then
                    cmd = "D"
                ElseIf viewprmsn = 1 Then
                    cmd = "V"
                End If
            End If
                comd = cmd
        End If
        dspop.Clear()
        Close1()
        Return comd
    End Function

    Public Function sidebutton(ByVal mnunm As String) As Boolean
        'Checking Of Permission Avalable Or Not for this menu
        Dim ds As DataSet = get_dataset("SELECT user_assign.*,menumst.menu_id,menumst.menu_nm FROM user_assign LEFT OUTER JOIN menumst ON user_assign.menu_sl = menumst.menu_sl WHERE (user_assign.user_sl = " & usr_sl & ") AND (menumst.menu_id='" & mnunm & "') AND (menumst.menu_lvl<>0)")
        If ds.Tables(0).Rows.Count <> 0 Then
            menuid = ds.Tables(0).Rows(0).Item("menu_id")
            menunm = ds.Tables(0).Rows(0).Item("menu_nm")
            addprm = ds.Tables(0).Rows(0).Item("add_prm")
            editprm = ds.Tables(0).Rows(0).Item("edit_prm")
            delprm = ds.Tables(0).Rows(0).Item("delete_prm")
            viewprm = ds.Tables(0).Rows(0).Item("view_prm")
            If addprm = 0 And editprm = 0 And delprm = 0 And viewprm = 0 Then
                Return False
            Else
                Return True
            End If
        End If
    End Function



End Module
