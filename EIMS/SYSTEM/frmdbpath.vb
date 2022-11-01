﻿Imports vb = Microsoft.VisualBasic
Public Class frmdbpath
    Dim comd As String

    Private Sub frmdbpath_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 144 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmdbpath_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.read_text()
    End Sub

    Private Sub read_text()
        'Dim reader As New System.IO.StreamReader(lnk_path)
        'Dim FirstName, LastName As String
        'FirstName = reader.ReadLine()
        'LastName = reader.ReadLine()
        'reader.Close()
        'txtFirstName.Text = FirstName
        'txtLastName.Text = LastName

        Dim TextLine As String
        Dim objReader As New System.IO.StreamReader(lnk_path)
        rw = 0
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine() & vbNewLine
            asd = TextLine.Split(",")
            dv.Rows.Add()
            dv.Rows(rw).Cells(0).Value = rw + 1
            dv.Rows(rw).Cells(1).Value = asd(0)
            dv.Rows(rw).Cells(2).Value = asd(1)
            dv.Rows(rw).Cells(3).Value = asd(2)
            dv.Rows(rw).Cells(4).Value = asd(3)
            dv.Rows(rw).Cells(5).Value = asd(4)
            rw = rw + 1
        Loop
    End Sub

    Private Sub dv_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dv.DoubleClick
        Me.path_select()
    End Sub

    Private Sub dv_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dv.KeyDown
        If (e.KeyCode) = Keys.Enter Then
            Me.path_select()
        End If
    End Sub

    Private Sub path_select()
        For i As Integer = 0 To dv.SelectedRows.Count - 1
            dbnm = dv.SelectedRows(i).Cells(1).Value                        'DATA BASE NAME
            srvnm = dv.SelectedRows(i).Cells(2).Value                        'DATA SERVER NAME
            dbid = dv.SelectedRows(i).Cells(3).Value                          'DATABASE USER NAME
            dbpwd = dv.SelectedRows(i).Cells(4).Value                          'DATA BASE PASSWORD
            dbmode = Val(dv.SelectedRows(i).Cells(5).Value)
        Next
        If Val(dbmode) = 1 Then
            connectionstrng = "Data Source=" & Trim(srvnm) & ";Initial Catalog=" & Trim(dbnm) & ";Integrated Security=True"
        Else
            connectionstrng = "Data Source=" & Trim(srvnm) & ";Initial Catalog=" & Trim(dbnm) & ";Integrated Security=False;User ID=" & Trim(dbid) & ";Password=" & Trim(dbpwd) & ""
        End If
        frmlogin.MdiParent = MDI
        frmlogin.Show()
        Me.Close()
    End Sub
End Class
