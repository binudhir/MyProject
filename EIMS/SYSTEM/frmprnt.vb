Imports vb = Microsoft.VisualBasic
Public Class frmprnt
    Dim slno As Integer = 0

    Private Sub frmprnt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmprnt_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black
        End If
    End Sub

    Private Sub frmprnt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
    End Sub

    Private Sub clr()
        txtstrtno.Text = ""
        txtendno.Text = ""
        chkcnfr.Checked = False
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtstrtno.Enter, txtendno.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LightGoldenrodYellow
        sender.Font = New System.Drawing.Font("Verdana", 10, FontStyle.Bold)
    End Sub

    Private Sub sender_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstrtno.Leave, txtendno.Leave
        sender.BackColor = Color.White
        sender.ForeColor = Color.Black
        sender.Font = New System.Drawing.Font("Verdana", 10, FontStyle.Regular)
    End Sub

    Private Sub lblcncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblexit.Click
        Me.Close()
    End Sub

    Private Sub lbllogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblprint.Click
        If Val(txtstrtno.Text) = 0 And Val(txtendno.Text) = 0 Then
            MessageBox.Show("The Value Of The Field Should Not Be Zero.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtstrtno.Focus()
            Exit Sub
        End If
        If Val(txtendno.Text) < Val(txtstrtno.Text) Then
            MessageBox.Show("The Starting No Should Not Be Greater Then The Ending No.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtendno.Text = txtstrtno.Text
            Exit Sub
        End If
        For i As Integer = Val(txtstrtno.Text) To Val(txtendno.Text)
            slno = i
            If chkcnfr.Checked = True Then
                cnfr = MessageBox.Show("Are You Sure The Printer is Ready To Print The Bill No:- " & slno, "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If cnfr = vbYes Then
                    Me.prints()
                End If
            Else
                Me.prints()
            End If
        Next
        Me.Close()
    End Sub

    Private Sub txtstrtno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstrtno.KeyPress
        key(txtendno, e)
        NUM(e)
    End Sub

    Private Sub txtendno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtendno.KeyPress
        key(lblprint, e)
        NUM(e)
    End Sub

    Private Sub prints()
        Start1()
        If frmno = 1 Then 'For Collection Reciepts
            Dim ds As DataSet = get_dataset("SELECT coll_no FROM collrec1 WHERE coll_no=" & slno & "")
            If ds.Tables(0).Rows.Count <> 0 Then
                Call colrec_print(slno)
            End If
        ElseIf frmno = 2 Then 'For Purchase Order
            Dim ds As DataSet = get_dataset("SELECT po_no FROM porder1 WHERE po_no=" & slno & "")
            If ds.Tables(0).Rows.Count <> 0 Then
                Call order_print(slno)
            End If


        End If
        Close1()
    End Sub
End Class
