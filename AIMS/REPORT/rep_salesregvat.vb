﻿Imports vb = Microsoft.VisualBasic
Public Class rep_salesregvat
    Dim comd As String

    Private Sub rep_salesregvat_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub rep_salesregvat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub rep_salesregvat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        Me.clr()
        fromdt.Value = sys_date.AddDays(-sys_date.Day + 1)
        todt.Value = fromdt.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub clr()
        Me.Text = "Sales Register For V.A.T . . ."
        txtpartycd.Text = ""
        txttaxcd.Text = ""
        cmbtax.Focus()
        hddr = Me.Text
        dv.DataSource = Nothing
        lblmsg.Visible = False
        'chksales.Checked = True
        If chkparty.Checked = False Then
            cmbparty.Text = ""
        End If
        If chktax.Checked = False Then
            cmbtax.Text = ""
        End If
    End Sub

#Region "Enter/Leave"
    Private Sub cmbparty_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbparty.Enter, cmbtax.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub cmbparty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbparty.Leave, cmbtax.Leave

        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub btnview_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnrfresh.MouseEnter, btnexport.MouseEnter, btnexit.MouseEnter, btncalc.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnview_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnrfresh.MouseLeave, btnexport.MouseLeave, btnexit.MouseLeave, btncalc.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "combobox"
    Private Sub cmbparty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.LostFocus
        cmbparty.Height = 21
    End Sub

    Private Sub cmbparty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbparty.GotFocus
        txtpartycd.Text = 0
        populate(cmbparty, "SELECT pname FROM party WHERE prt_type='B' AND rec_lock='N' ORDER BY pname")
    End Sub

    Private Sub cmbparty_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbparty.Validated
        Dim ds As DataSet = get_dataset("SELECT prt_code,add1 FROM party WHERE pname='" & Trim(cmbparty.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtpartycd.Text = ds.Tables(0).Rows(0).Item("prt_code")
        End If
    End Sub

    Private Sub cmbparty_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbparty.Validating
        vdating(cmbparty, "SELECT pname FROM party WHERE prt_type='B' AND rec_lock='N' AND pname='" & Trim(cmbparty.Text) & "'", "Please Select A Valid Party Head Of A/c Name.")
    End Sub

    Private Sub cmbtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.GotFocus
        txttaxcd.Text = 0
        populate(cmbtax, "SELECT taxnm FROM taxper WHERE (rec_lock = 'N') ORDER BY taxnm")
    End Sub

    Private Sub cmbtax_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.LostFocus
        cmbtax.Height = 21
    End Sub

    Private Sub cmbtax_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.Validated
        vdating(cmbtax, "SELECT taxnm FROM taxper WHERE (taxnm = '" & Trim(cmbtax.Text) & "')", "Please Select a Valid Tax Name.")
    End Sub

    Private Sub cmbtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtax.Validating
        vdated(txttaxcd, "SELECT taxcd FROM taxper WHERE (taxnm = '" & Trim(cmbtax.Text) & "')")
    End Sub

#End Region

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btncalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncalc.Click
        System.Diagnostics.Process.Start("calc.exe")
    End Sub

    Private Sub btnrfresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrfresh.Click
        Me.clr()
    End Sub

    Private Sub btnexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexport.Click
        Call excel_view(dv)
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        lblmsg.Visible = False
        dv.DataSource = Nothing
        Start1()
        Dim ds As DataSet
        conditn = ""
        If chkparty.Checked = False Then
            conditn = conditn & "AND (party.prt_code=" & Val(txtpartycd.Text) & ")"
        End If
        If chktax.Checked = False Then
            conditn = conditn & "AND (taxper.taxcd=" & Val(txttaxcd.Text) & ")"
        End If
        orderby = "csale2.bill_no"

        If (chksales.Checked = True) Then
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY " & orderby & ") AS 'Sl.', csale2.bill_no AS 'Bill No.', CONVERT(varchar,csale2.bill_dt,103) AS 'Bill Dt.', party.pname AS 'Party Name', party.add1 AS 'Party Address', party.lst_no AS 'T.I.N/S.R.I.N', STR(csale2.tto_amt,10,2) AS 'TTO Amt.', STR(csale2.stax,10,2) AS 'VAT Amt.', STR(csale2.oth_amt,10,2) AS 'Other Amt.', STR(csale2.it_tot,10,2) AS 'Total Amt.', taxper.taxnm AS 'VAT Category' FROM csale2 LEFT OUTER JOIN taxper ON csale2.tax_cd = taxper.taxcd LEFT OUTER JOIN party ON csale2.prt_code = party.prt_code" & conditn & " ORDER BY " & orderby & "")
        Else
            ds = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY taxnm) AS 'Sl.', taxper.taxnm AS 'VAT category', STR(csale2.tto_amt,10,2) AS 'TTO Amt.', STR(csale2.stax,10,2) AS 'VAT Amt.', STR(csale2.disc_amt,10,2) AS 'Discount Amt.', STR(csale2.oth_amt,10,2) AS 'Other Amt.', STR(csale2.it_tot,10,2) AS 'Total Amt.' FROM csale2 LEFT OUTER JOIN taxper ON csale2.tax_cd = taxper.taxcd" & conditn & " ORDER BY taxper.taxnm ")
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = ds.Tables(0)
            'slno = 0
            'For i As Integer = 0 To dv.Rows.Count - 1
            '    If ds.Tables(0).Rows(i).Item("Purchase type") = "1" Then
            '        ds.Tables(0).Rows(i).Item("Purchase type") = "Purchase"
            '    End If
            '    If ds.Tables(0).Rows(i).Item("Purchase type") = "1" Then
            '        ds.Tables(0).Rows(i).Item("Purchase type") = "Return"
            '    End If
            '    If slno = Val(dv.Rows(i).Cells(1).Value) Then
            '        dv.Rows(i).Cells(1).Value = ""
            '        dv.Rows(i).Cells(2).Value = ""
            '        dv.Rows(i).Cells(3).Value = ""
            '        dv.Rows(i).Cells(4).Value = ""
            '        dv.Rows(i).Cells(6).Value = ""
            '    Else
            '        slno = Val(dv.Rows(i).Cells(1).Value)
            '    End If

            'Next
            GroupBox3.Text = "Purchase Register From " & fromdt.Value & " To " & todt.Value
            hddr = GroupBox3.Text
        Else
            lblmsg.Visible = True
        End If
        Close1()
    End Sub


    Private Sub chkdetail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksales.CheckedChanged
        If (chksales.Checked = True) Then
            chkabstract.Checked = False
        Else
            chkabstract.Checked = True
        End If
    End Sub

    Private Sub chkabstract_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkabstract.CheckedChanged
        If (chkabstract.Checked = True) Then
            chksales.Checked = False
        Else
            chksales.Checked = True
        End If
    End Sub


    Private Sub chkparty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkparty.CheckedChanged
        If chkparty.Checked = True Then
            cmbparty.Text = "<<< All Party >>>"
            cmbparty.Enabled = False
            txtpartycd.Text = 0
        Else
            cmbparty.Text = ""
            cmbparty.Enabled = True
            cmbparty.Focus()
        End If
    End Sub

    Private Sub chktax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktax.CheckedChanged
        If chktax.Checked = True Then
            cmbtax.Text = "<<< All Tax >>>"
            cmbtax.Enabled = False
            txttaxcd.Text = 0
        Else
            cmbtax.Text = ""
            cmbtax.Enabled = True
            cmbtax.Focus()
        End If
    End Sub

#Region "keypress"

    Private Sub startdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fromdt.KeyPress
        key(todt, e)
    End Sub

    Private Sub enddt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles todt.KeyPress
        key(cmbparty, e)
    End Sub

    Private Sub cmbparty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbparty.KeyPress
        key(cmbtax, e)
        SPKey(e)
    End Sub

    Private Sub cmbtax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtax.KeyPress
        key(chksales, e)
        SPKey(e)
    End Sub

    Private Sub chkpurch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chksales.KeyPress
        key(chkabstract, e)
    End Sub

    Private Sub chkabstract_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkabstract.KeyPress
        key(btnview, e)
    End Sub
#End Region


End Class
