Imports vb = Microsoft.VisualBasic
Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class frmdbset
    Dim con_str As String

    Private Sub frmdbset_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 144 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmdbset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
    End Sub

    Private Sub frmdbset_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black
        End If
    End Sub

    Private Sub clr()
        cmblogtp.SelectedIndex = 1
        cmbsrvnm.Text = ""
        txtuserid.Text = "sa"
        txtpswd.Text = ""
        btnsearch.Visible = False
        chkall.Visible = False
    End Sub

    Private Sub txtmembr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpswd.Enter, txtuserid.Enter, cmblogtp.Enter, cmbsrvnm.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub txtmembr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpswd.Leave, txtuserid.Leave, cmblogtp.Leave, cmbsrvnm.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

    End Sub

    Private Sub btnexit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter, btnconnect.MouseEnter, btnget.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnexit_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave, btnconnect.MouseLeave, btnget.MouseLeave, btnget.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Me.clr()


    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        chk = 0
        For i As Integer = 0 To dv.Rows.Count - 1
            If dv.Rows(i).Cells(0).Value = 1 Then
                chk = 1
            End If
        Next
        If chk = 0 Then
            MessageBox.Show("Please Select At Least One Database To Change The Settings.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Me.link_write()
        End
    End Sub

    Private Sub btnget_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnget.Click
        Try
            Dim Server As String = String.Empty
            Dim instance As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
            Dim table As System.Data.DataTable = instance.GetDataSources()

            For Each row As System.Data.DataRow In table.Rows
                Server = String.Empty
                Server = row("ServerName")
                If row("InstanceName").ToString.Length > 0 Then
                    Server = Server & "\" & row("InstanceName")
                End If
                cmbsrvnm.Items.Add(Server)
            Next
            cmbsrvnm.SelectedIndex = cmbsrvnm.FindStringExact(Environment.MachineName)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmbsrvnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbsrvnm.KeyPress
        key(cmblogtp, e)
        SPKey(e)
    End Sub

    Private Sub cmblogtp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblogtp.KeyPress
        If txtpswd.Text = Enabled Then
            key(txtpswd, e)
        Else
            key(btnconnect, e)
        End If
    End Sub

    Private Sub txtuserid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuserid.KeyPress
        key(txtpswd, e)
        SPKey(e)
    End Sub

    Private Sub txtpswd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpswd.KeyPress
        key(btnconnect, e)
        SPKey(e)
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        chkall.Visible = False
        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        cn = New SqlConnection(con_str)
        Dim rw As Integer = 0
        dv.Rows.Clear()
        Try
            cn.Open()
            cmd = New SqlCommand("Select name From sys.databases Where database_id > 4 ORDER BY name", cn)
            da = New SqlDataAdapter(cmd)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dv.Rows.Add()
                    'dv.Rows(i).Cells(0).Value = i + 1
                    dv.Rows(i).Cells(1).Value = ds.Tables(0).Rows(rw).Item(0)
                    rw = rw + 1
                Next
                chkall.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            cn.Close()
            da.Dispose()
        End Try
        ''ds = get_dataset("Select name From sys.databases Where database_id > 4 ORDER BY name")
        'Dim rw As Integer = 0
        'If ds.Tables(0).Rows.Count <> 0 Then
        '    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
        '        dv.Rows.Add()
        '        'dv.Rows(i).Cells(0).Value = i + 1
        '        dv.Rows(i).Cells(1).Value = ds.Tables(0).Rows(rw).Item(0)
        '        rw = rw + 1
        '    Next
        'End If
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        If chkall.Checked = True Then
            For i As Integer = 0 To dv.Rows.Count - 1
                dv.Rows(i).Cells(0).Value = 1
            Next
        Else
            For i As Integer = 0 To dv.Rows.Count - 1
                dv.Rows(i).Cells(0).Value = 0
            Next
        End If
    End Sub

    Private Sub btnconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnconnect.Click
        cmblogtp.Enabled = True
        cmbsrvnm.Enabled = True
        btnget.Enabled = True
        If cmblogtp.SelectedIndex = 1 Then
            If Trim(txtuserid.Text) = "" Then
                MessageBox.Show("The User ID Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtuserid.Focus()
                Exit Sub
            End If
            If Trim(txtpswd.Text) = "" Then
                MessageBox.Show("The Password Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtpswd.Focus()
                Exit Sub
            End If
        End If
        If cmblogtp.SelectedIndex = 0 Then
            con_str = "Data Source=" & Trim(cmbsrvnm.Text) & ";Initial Catalog=master;Integrated Security=True"
        Else
            con_str = "Data Source=" & Trim(cmbsrvnm.Text) & ";Initial Catalog=master;Integrated Security=False;User ID=" & Trim(txtuserid.Text) & ";Password=" & Trim(txtpswd.Text) & ""
        End If

        If btnconnect.Text = "&Connect" Then
            Try
                Dim cn As SqlConnection
                cn = New SqlConnection(con_str)
                cn.Open()
                If cn.State = ConnectionState.Open Then
                    MessageBox.Show("Database Connection Established Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnconnect.Text = "&Disconnect"
                    btnsearch.Visible = True
                    cmblogtp.Enabled = False
                    cmbsrvnm.Enabled = False
                    btnget.Enabled = False
                    cn.Close()
                Else
                    MessageBox.Show("Database Connection Not Established Due To Some Problem.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnconnect.Text = "&Connect"
                    btnsearch.Visible = False
                End If

            Catch ex As Exception
                MessageBox.Show("Database Connection Not Established Due To Some Problem.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnconnect.Text = "&Connect"
                btnsearch.Visible = False
            End Try
        Else
            Dim cn As SqlConnection
            cn = New SqlConnection(con_str)
            cn.Dispose()
            MessageBox.Show("Database Disconnected Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnconnect.Text = "&Connect"
            btnsearch.Visible = False
            con_str = ""
            dv.Rows.Clear()
            chkall.Visible = False
        End If
    End Sub

    Private Sub cmblogtp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmblogtp.SelectedIndexChanged
        If cmblogtp.SelectedIndex = 0 Then
            txtpswd.Enabled = False
            txtuserid.Enabled = False
            txtpswd.Text = ""
            txtuserid.Text = "sa"
        Else
            txtpswd.Enabled = True
            txtuserid.Enabled = True
        End If
    End Sub

    Private Sub link_write()
        chk = 0
        Dim objWriter As New System.IO.StreamWriter(lnk_path)
        objWriter.Write("")
        For i As Integer = 0 To dv.Rows.Count - 1
            If dv.Rows(i).Cells(0).Value = 1 Then
                dbname = dv.Rows(i).Cells(1).Value
                objWriter.WriteLine(dbname & " ," & cmbsrvnm.Text & "," & txtuserid.Text & "," & txtpswd.Text & "," & vb.Left(cmblogtp.Text, 1))
                chk = 1
            End If
        Next
        objWriter.Close()
        MessageBox.Show("The Data Link Setting Update Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
