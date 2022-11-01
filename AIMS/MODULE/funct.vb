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
        cmb.Height = 100
        'cmb.Text = ""
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

    'Function words(ByVal fig, Optional ByVal point = "Point") As String
    '    words = ""
    '    Dim digit(14) As Integer
    '    alpha = Array("", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety")
    '    figi = Trim(StrReverse(Str(Int(Abs(fig)))))
    '    For i = 1 To Len(figi)
    '        digit(i) = Mid(figi, i, 1)
    '    Next
    '    For i = 2 To Len(figi) Step 3
    '        If digit(i) = 1 Then
    '            digit(i) = digit(i - 1) + 10 : digit(i - 1) = 0
    '        Else : If digit(i) > 1 Then digit(i) = digit(i) + 18
    '        End If
    '    Next
    '    For i = 1 To Len(figi)
    '        If (i Mod 3) = 0 And digit(i) > 0 Then words = "hundred " & words
    '        If (i Mod 3) = 1 And digit(i) + digit(i + 1) + digit(i + 2) > 0 Then _
    '        words = Choose(i / 3, "thousand ", "million ", "billion ") & words
    '        words = Trim(alpha(digit(i)) & " " & words)
    '    Next
    '    If fig <> Int(fig) Then
    '        figc = StrReverse(figi)
    '        If figc = 0 Then figc = ""
    '        figd = Trim(WorksheetFunction.Substitute(Str(Abs(fig)), figc & ".", ""))
    '        words = Trim(words & " " & point)
    '        For i = 1 To Len(figd)
    '            If Val(Mid(figd, i, 1)) > 0 Then
    '                words = words & " " & alpha(Mid(figd, i, 1))
    '            Else : words = words & " Zero"
    '            End If
    '        Next
    '    End If
    '    If fig < 0 Then words = "Negative " & words
    'End Function

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


    'Private allowCoolMove As Boolean = False
    'Private myCoolPoint As New Point

    'Public Sub pnl_MouseDown(ByVal pnl As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    allowCoolMove = True
    '    myCoolPoint = New Point(e.X, e.Y)
    '    pnl.Cursor = Cursors.SizeAll
    'End Sub

    'Public Sub pnl_MouseMove(ByVal pnl As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If allowCoolMove = True Then
    '        pnl.Location = New Point(pnl.Location.X + e.X - myCoolPoint.X, pnl.Location.Y + e.Y - myCoolPoint.Y)
    '    End If
    'End Sub

    'Private Sub pnl_MouseUp(ByVal pnl As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    allowCoolMove = False
    '    pnl.Cursor = Cursors.Default
    'End Sub
End Module
