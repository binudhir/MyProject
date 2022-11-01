Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO

Public Class frmitem
    Dim comd As String = "E"
    Dim con_img As New SqlConnection(connectionstrng)
    Dim cmd_img As SqlCommand

#Region "START UP"
    Private Sub frmitem_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuProduct.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmitem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmitem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Dock = DockStyle.Fill
        cmbbatch.SelectedIndex = 0
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Remove(TabPage3)
        MDI.mnuProduct.Enabled = False
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub frmitem_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        txtbatsl.Text = "1"
        txtsl.Text = "1"
        txtstksl.Text = "1"
        TabControl1.SelectedIndex = 0
        txtphoto.Text = "N"
        txtserregd.Text = ""
        txtsername.Text = ""
        dv1.Rows.Clear()
        lblsnd.Text = "00"
        lbdmg.Text = "00"
        lblsrlstk.Text = "00"
        lblsrlqty.Text = "00"
        lblbat_sndstk.Text = "00"
        lblbat_sndqty.Text = "00"
        lblbat_dmgstk.Text = "00"
        lblbat_dmgqty.Text = "00"
        dvsrl.Rows.Clear()
        dv.Columns.Clear()
        dvbat.Rows.Clear()
        txtmanfcd.Text = 0
        txtgrpcd.Text = 0
        txtonsalcd.Text = 0
        txtscrl.Text = 0
        txtonpurcd.Text = 0
        txtgodncd.Text = 0
        txtbatonpurcd.Text = 0
        txtbatonsalcd.Text = 0
        txtsl.Text = 1
        txttrdisper1.Text = "0.00"
        txttrdisper.Text = "0.00"
        txttrdisamt1.Text = "0.00"
        txttrdisamt.Text = "0.00"
        txtstock.Text = "0.00"
        txtstkval.Text = "0.00"
        txtopstkrt.Text = "0.00"
        txtsound.Text = ""
        txtopsalrt.Text = "0.00"
        txtpurrt.Text = "0.00"
        txtoppurrt.Text = "0.00"
        txtmulti3.Text = "1"
        txtmulti2.Text = "1"
        txtmulti1.Text = "1"
        txtmrp.Text = "0.00"
        txtitnm.Text = ""
        txtsrtcode.Text = ""
        txthsncode.Text = ""
        txtdmgd.Text = ""
        txtdescri.Text = ""
        txtcodisper1.Text = "0.00"
        txtcodisper.Text = "0.00"
        txtcodisamt1.Text = "0.00"
        txtcodisamt.Text = "0.00"
        txtcat4.Text = "0.00"
        txtcat2.Text = "0.00"
        txtcat3.Text = "0.00"
        txtcat1.Text = "0.00"
        cmbunt4.Text = ""
        cmbunt3.Text = ""
        cmbunt2.Text = ""
        cmbunit1.Text = ""
        cmbtype.SelectedIndex = 0
        cmbtaxtp.SelectedIndex = 0
        cmbonsale.Text = ""
        cmbonpurch.Text = ""
        cmbmanf.Text = ""
        cmblock.SelectedIndex = 0
        cmbgrp.Text = ""
        cmbgodwn.Text = ""
        txtsound.Text = "0.00"
        txtdmgd.Text = "0.00"
        pict1.BackgroundImage = Nothing
        If comd = "E" Then
            Me.Text = "Product Master Entry Screen . . ."
            Dim ds As DataSet = get_dataset("SELECT max(it_cd) as 'Max' FROM item")
            txtscrl.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
        End If
        txtitnm.Focus()
        Me.clr1()
        Me.clr2()
        Me.last_regd()
    End Sub

    Private Sub clr1()
        txtsndopn.Text = "0.00"
        txtsndcl.Text = "0.00"
        txton.Text = "1"
        txtfree.Text = "0"
        txtmfgdt.Text = "12/2099"
        txtdmgopn.Text = "0.00"
        txtdmgcl.Text = "0.00"
        txtbatstrt.Text = txtstock.Text
        txtbatpurt.Text = txtpurrt.Text
        txtbatopstrt.Text = txtopstkrt.Text
        txtbatopstkval.Text = txtstkval.Text
        txtbatopsalrt.Text = txtopsalrt.Text
        txtbatoppurrat.Text = txtoppurrt.Text
        txtbatmrp.Text = txtmrp.Text
        txtbatch.Text = ""
        txtbatcat4.Text = txtcat4.Text
        txtbatcat3.Text = txtcat3.Text
        txtbatcat2.Text = txtcat2.Text
        txtbatcat1.Text = txtcat1.Text
        cmbbattaxtp.SelectedIndex = 0
        cmbbatonsal.Text = cmbonsale.Text
        cmbbatonpur.Text = cmbonpurch.Text
        txtbatonsalcd.Text = txtonsalcd.Text
        txtbatonpurcd.Text = txtonpurcd.Text
    End Sub

    Private Sub clr2()
        txtsrlno.Text = ""
    End Sub

    Private Sub cmnurefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnurefresh.Click, btnview.Click
        Me.clr()
        Me.dv_disp()
    End Sub

    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrdisper1.Enter, txttrdisper.Enter, txttrdisamt1.Enter, txttrdisamt.Enter, txtstock.Enter, txtstkval.Enter, txtopstkrt.Enter, txtopsalrt.Enter, txtpurrt.Enter, txtoppurrt.Enter, txtmulti3.Enter, txtmulti2.Enter, txtmulti1.Enter, txtmrp.Enter, txtitnm.Enter, txtsrtcode.Enter, txtdescri.Enter, txtcodisper1.Enter, txtcodisper.Enter, txtcodisamt1.Enter, txtcodisamt.Enter, txtcat4.Enter, txtcat2.Enter, txtcat3.Enter, txtcat1.Enter, cmbunt4.Enter, cmbunt3.Enter, cmbunt2.Enter, cmbunit1.Enter, cmbtype.Enter, cmbtaxtp.Enter, cmbonsale.Enter, cmbonpurch.Enter, cmbmanf.Enter, cmblock.Enter, cmbgrp.Enter, cmbbatch.Enter, txtsndopn.Enter, txtsndcl.Enter, txton.Enter, txtfree.Enter, txtmfgdt.Enter, txtdmgopn.Enter, txtdmgcl.Enter, txtbatstrt.Enter, txtbatpurt.Enter, txtbatopstrt.Enter, txtbatopstkval.Enter, txtbatopsalrt.Enter, txtbatoppurrat.Enter, txtbatmrp.Enter, txtbatch.Enter, txtbatcat4.Enter, txtbatcat3.Enter, txtbatcat2.Enter, txtbatcat1.Enter, cmbbattaxtp.Enter, cmbbatonsal.Enter, cmbbatonpur.Enter, txtsrlno.Enter, txtsl.Enter, txtsrlqty.Enter, txtexpdt.Enter, cmbgodwn.Enter, txtsound.Enter, txtdmgd.Enter, txthsncode.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrdisper1.Leave, txttrdisper.Leave, txttrdisamt1.Leave, txttrdisamt.Leave, txtstock.Leave, txtstkval.Leave, txtopstkrt.Leave, txtopsalrt.Leave, txtpurrt.Leave, txtoppurrt.Leave, txtmulti3.Leave, txtmulti2.Leave, txtmulti1.Leave, txtmrp.Leave, txtitnm.Leave, txtsrtcode.Leave, txtdescri.Leave, txtcodisper1.Leave, txtcodisper.Leave, txtcodisamt1.Leave, txtcodisamt.Leave, txtcat4.Leave, txtcat2.Leave, txtcat3.Leave, txtcat1.Leave, cmbunt4.Leave, cmbunt3.Leave, cmbunt2.Leave, cmbunit1.Leave, cmbtype.Leave, cmbtaxtp.Leave, cmbonsale.Leave, cmbonpurch.Leave, cmbmanf.Leave, cmblock.Leave, cmbgrp.Leave, cmbbatch.Leave, txtsndopn.Leave, txtsndcl.Leave, txton.Leave, txtfree.Leave, txtmfgdt.Leave, txtdmgopn.Leave, txtdmgcl.Leave, txtbatstrt.Leave, txtbatpurt.Leave, txtbatopstrt.Leave, txtbatopstkval.Leave, txtbatopsalrt.Leave, txtbatoppurrat.Leave, txtbatmrp.Leave, txtbatch.Leave, txtbatcat4.Leave, txtbatcat3.Leave, txtbatcat2.Leave, txtbatcat1.Leave, cmbbattaxtp.Leave, cmbbatonsal.Leave, cmbbatonpur.Leave, txtsrlno.Leave, txtsl.Leave, txtsrlqty.Leave, txtexpdt.Leave, cmbgodwn.Leave, txtsound.Leave, txtdmgd.Leave, txthsncode.Leave
        'sender.text = UCase(sender.text)
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub
#End Region

#Region "GOTFOCUS/LOSTFOCUS"
    Private Sub sender_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttrdisper1.GotFocus, txttrdisper.GotFocus, txttrdisamt1.GotFocus, txttrdisamt.GotFocus, txtstock.GotFocus, txtstkval.GotFocus, txtopstkrt.GotFocus, txtopsalrt.GotFocus, txtpurrt.GotFocus, txtoppurrt.GotFocus, txtmrp.GotFocus, txtcodisper1.GotFocus, txtcodisper.GotFocus, txtcodisamt1.GotFocus, txtcodisamt.GotFocus, txtcat4.GotFocus, txtcat2.GotFocus, txtcat3.GotFocus, txtcat1.GotFocus, txtsndopn.GotFocus, txtfree.GotFocus, txtdmgopn.GotFocus, txtbatstrt.GotFocus, txtbatpurt.GotFocus, txtbatopstrt.GotFocus, txtbatopstkval.GotFocus, txtbatopsalrt.GotFocus, txtbatoppurrat.GotFocus, txtbatmrp.GotFocus, txtbatcat4.GotFocus, txtbatcat3.GotFocus, txtbatcat2.GotFocus, txtbatcat1.GotFocus
        If Val(sender.text) = 0 Then
            sender.text = ""
        End If
    End Sub

    Private Sub sender_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttrdisper1.LostFocus, txttrdisper.LostFocus, txttrdisamt1.LostFocus, txttrdisamt.LostFocus, txtstock.LostFocus, txtstkval.LostFocus, txtopstkrt.LostFocus, txtopsalrt.LostFocus, txtpurrt.LostFocus, txtoppurrt.LostFocus, txtmrp.LostFocus, txtcodisper1.LostFocus, txtcodisper.LostFocus, txtcodisamt1.LostFocus, txtcodisamt.LostFocus, txtcat4.LostFocus, txtcat2.LostFocus, txtcat3.LostFocus, txtcat1.LostFocus, txtsndopn.LostFocus, txtfree.LostFocus, txtdmgopn.LostFocus, txtbatstrt.LostFocus, txtbatpurt.LostFocus, txtbatopstrt.LostFocus, txtbatopstkval.LostFocus, txtbatopsalrt.LostFocus, txtbatoppurrat.LostFocus, txtbatmrp.LostFocus, txtbatcat4.LostFocus, txtbatcat3.LostFocus, txtbatcat2.LostFocus, txtbatcat1.LostFocus
        sender.text = Format(Val(sender.text), "######0.00")
    End Sub

    Private Sub txtmulti1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmulti1.GotFocus, txtmulti2.GotFocus, txtmulti3.GotFocus
        If Val(sender.text) = 1 Then
            sender.text = ""
        End If
    End Sub

    Private Sub txtmulti1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmulti1.LostFocus, txtmulti2.LostFocus, txtmulti3.LostFocus
        If Val(sender.text) < 1 Then
            sender.text = "1"
        End If
    End Sub

    Private Sub txtexpiry_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmfgdt.GotFocus, txtexpdt.GotFocus
        If Trim(sender.Text) = "12/2099" Then
            sender.Text = ""
        End If
    End Sub

    Private Sub txtexpiry_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmfgdt.LostFocus, txtexpdt.LostFocus
        If Trim(sender.Text) = "" Then
            sender.Text = "12/2099"
        End If
    End Sub

    Private Sub txtitnm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtitnm.LostFocus
        If Trim(txtdescri.Text) = "" Then
            txtdescri.Text = Trim(txtitnm.Text)
        End If
    End Sub
#End Region

    Private Sub sender_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmfgdt.Validated, txtexpdt.Validated
        mnth = ""
        yr = ""
        If vb.Left(sender.Text, 3) <> "/" Then
            If Len(sender.Text) = 6 Then
                mnth = vb.Left(sender.Text, 2)
                yr = vb.Right(sender.Text, 4)
                sender.Text = mnth & "/" & vb.Right(sender.Text, 4)
            ElseIf Len(sender.Text) >= 4 And Len(sender.Text) < 6 Then
                mnth = vb.Left(sender.Text, 2)
                yr = vb.Right(sender.Text, Len(sender.Text) - Len(mnth))
                sender.Text = mnth & "/20" & vb.Right(sender.Text, 2)
            Else
                sender.Text = "12/2099"
            End If
        End If
    End Sub

    Private Sub txtexpdt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtexpdt.Validating, txtmfgdt.Validating
        If vb.Left(sender.Text, 3) <> "/" Then
            If Val(vb.Left(sender.text, 2)) > 12 Then
                MessageBox.Show("The Month Format Not Support.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                sender.Text = ""
                sender.Focus()
            End If
        End If
    End Sub

#Region "BUTTONS"
    Private Sub btndelete_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseEnter, btnsave.MouseEnter, btnrefresh.MouseEnter, btnexit.MouseEnter, btnedit.MouseEnter, btndelete.MouseEnter, btnadd.MouseEnter, btnbatnxt.MouseEnter, btnbatfresh.MouseEnter, btnbatclr.MouseEnter, btnsrlnxt.MouseEnter, btnsrlfresh.MouseEnter, btnsrlcrl.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btndelete_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.MouseLeave, btnsave.MouseLeave, btnrefresh.MouseLeave, btnexit.MouseLeave, btnedit.MouseLeave, btndelete.MouseLeave, btnadd.MouseLeave, btnbatnxt.MouseLeave, btnbatfresh.MouseLeave, btnbatclr.MouseLeave, btnsrlnxt.MouseLeave, btnsrlfresh.MouseLeave, btnsrlcrl.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click, cmnuadd.Click
        comd = "E"
        btnsave.Text = "Save."
        Me.Text = "Product Master Entry Screen . . ."
        Me.clr()
        For i As Integer = 0 To dv.Height = 10
            dv.Height = dv.Height - 1
        Next
        dv.Visible = False
        grpsearch.Visible = False
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click, cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Product Master Modification Screen . . ."
            slno = dv.SelectedRows(0).Cells(10).Value
            Me.dv_edit(slno)
            For i As Integer = 0 To dv.Width = 10
                dv.Width = dv.Width - 1
            Next
            dv.Visible = False
            grpsearch.Visible = False
            txtitnm.Focus()
        End If
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        comd = "E"
        Me.clr()
        If dv.Visible = True Then
            Me.dv_disp()
        End If
    End Sub

    Private Sub btnbatnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatnxt.Click
        If Trim(txtbatch.Text) = "" Then
            MessageBox.Show("The Batch Name Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtbatch.Focus()
            Exit Sub
        End If
        If Trim(cmbbatonsal.Text) = "" Or Val(txtbatonsalcd.Text) = 0 Then
            MessageBox.Show("The Sale Tax Category Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbbatonsal.Focus()
            Exit Sub
        End If
        If Trim(cmbbatonpur.Text) = "" Or Val(txtbatonpurcd.Text) = 0 Then
            MessageBox.Show("The Purchase Tax Category Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbbatonpur.Focus()
            Exit Sub
        End If
        If dvbat.Rows.Count <> 0 Then
            For i As Integer = 0 To dvbat.RowCount - 1
                x = dvbat.Rows(i).Cells(9).Value
                If Val(txtbatch.Text) = x Then
                    MessageBox.Show("Sorry The Data Should Not Be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtbatch.Focus()
                    Exit Sub
                End If
            Next
        End If
        If Val(lblbat_sndqty.Text) = Val(lblbat_sndstk.Text) Then
            MessageBox.Show("Sorry The Batch Quantity Should Not Be More Than Total Quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtsrlno.Text = ""
            btnsave.Focus()
            Exit Sub
        End If
        sl = Val(txtbatsl.Text)
        dvbat.Rows.Add()
        dvbat.Rows(sl - 1).Cells(0).Value = sl
        dvbat.Rows(sl - 1).Cells(1).Value = txtbatch.Text
        dvbat.Rows(sl - 1).Cells(2).Value = txtmfgdt.Text
        dvbat.Rows(sl - 1).Cells(3).Value = txtexpdt.Text
        dvbat.Rows(sl - 1).Cells(4).Value = cmbbattaxtp.Text
        dvbat.Rows(sl - 1).Cells(5).Value = cmbbatonsal.Text
        dvbat.Rows(sl - 1).Cells(6).Value = cmbbatonpur.Text
        dvbat.Rows(sl - 1).Cells(7).Value = txtfree.Text
        dvbat.Rows(sl - 1).Cells(8).Value = txton.Text
        dvbat.Rows(sl - 1).Cells(9).Value = txtsndopn.Text
        dvbat.Rows(sl - 1).Cells(10).Value = txtdmgopn.Text
        dvbat.Rows(sl - 1).Cells(11).Value = txtbatmrp.Text
        dvbat.Rows(sl - 1).Cells(12).Value = txtbatpurt.Text
        dvbat.Rows(sl - 1).Cells(13).Value = txtbatstrt.Text
        dvbat.Rows(sl - 1).Cells(14).Value = txtbatcat1.Text
        dvbat.Rows(sl - 1).Cells(15).Value = txtbatcat2.Text
        dvbat.Rows(sl - 1).Cells(16).Value = txtbatcat3.Text
        dvbat.Rows(sl - 1).Cells(17).Value = txtbatcat4.Text
        dvbat.Rows(sl - 1).Cells(18).Value = txtbatoppurrat.Text
        dvbat.Rows(sl - 1).Cells(19).Value = txtbatopsalrt.Text
        dvbat.Rows(sl - 1).Cells(20).Value = txtbatopstrt.Text
        dvbat.Rows(sl - 1).Cells(21).Value = txtbatopstkval.Text
        dvbat.Rows(sl - 1).Cells(22).Value = txtbatonsalcd.Text
        dvbat.Rows(sl - 1).Cells(23).Value = txtbatonpurcd.Text
        sl += 1
        txtbatsl.Text = sl
        Me.batstk()
        txtbatch.Focus()
        Me.clr1()
    End Sub

    Private Sub btnclr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatclr.Click
        dvbat.Rows.Clear()
        txtbatsl.Text = "1"
        Me.batstk()
        Me.clr1()
    End Sub

    Private Sub btnstknxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnstknxt.Click
        If Trim(cmbgodwn.Text) = "" Or Val(txtgodncd.Text) = 0 Then
            MessageBox.Show("Please Select A Valid Godown.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbgodwn.Focus()
            Exit Sub
        End If
        If Val(txtsound.Text + txtdmgd.Text) = 0 Then
            MessageBox.Show("The Quantity Should No Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtsound.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                x = dv1.Rows(i).Cells(1).Value
                If Trim(cmbgodwn.Text) = x Then
                    MessageBox.Show("Sorry The Data Should Not Be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmbgodwn.Focus()
                    Exit Sub
                End If
            Next
        End If
        sl1 = Val(txtstksl.Text)
        dv1.Rows.Add()
        dv1.Rows(sl1 - 1).Cells(0).Value = sl1
        dv1.Rows(sl1 - 1).Cells(1).Value = cmbgodwn.Text
        dv1.Rows(sl1 - 1).Cells(2).Value = txtsound.Text
        dv1.Rows(sl1 - 1).Cells(3).Value = txtdmgd.Text
        dv1.Rows(sl1 - 1).Cells(4).Value = txtgodncd.Text
        sl1 += 1
        txtstksl.Text = sl1
        Me.granstk()
        cmbgodwn.Text = ""
        txtgodncd.Text = 0
        txtsound.Text = ""
        txtdmgd.Text = ""
        cmbgodwn.Focus()
    End Sub

    Private Sub btnstkclr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnstkclr.Click
        dv1.Rows.Clear()
        txtstksl.Text = "1"
        cmbgodwn.Text = ""
        txtgodncd.Text = 0
        txtsound.Text = ""
        txtdmgd.Text = ""
        Me.granstk()
    End Sub

    Private Sub btnbatfresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatfresh.Click
        'txtbatsl.Text = "1"
        Me.clr1()
    End Sub

    Private Sub btnsrlnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsrlnxt.Click
        If Trim(txtsrlno.Text) = "" Then
            MessageBox.Show("The Serial Number Should Not Be Blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtsrlno.Focus()
            Exit Sub
        End If
        If dvsrl.Rows.Count <> 0 Then
            For i As Integer = 0 To dvsrl.RowCount - 1
                x = dvsrl.Rows(i).Cells(1).Value
                If Trim(txtsrlno.Text) = x Then
                    MessageBox.Show("Sorry The Data Should Not Be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtsrlno.Focus()
                    Exit Sub
                End If
            Next
        End If
        If dvsrl.Rows.Count = Val(lblsrlstk.Text) Then
            MessageBox.Show("Sorry The Serial No. Quantity Should Not Be More Than Total Quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtsrlno.Text = ""
            btnsave.Focus()
            Exit Sub
        End If

        sl1 = Val(txtsl.Text)
        dvsrl.Rows.Add()
        dvsrl.Rows(sl1 - 1).Cells(0).Value = sl1
        dvsrl.Rows(sl1 - 1).Cells(1).Value = txtsrlno.Text
        dvsrl.Rows(sl1 - 1).Cells(2).Value = txtsrlqty.Text
        dvsrl.Rows(sl1 - 1).Cells(3).Value = "N"
        sl1 += 1
        txtsl.Text = sl1
        Me.srlstk()
        txtsrlno.Text = ""
        txtsrlno.Focus()
    End Sub

    Private Sub btnsrlcrl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsrlcrl.Click
        dvsrl.Rows.Clear()
        txtsl.Text = "1"
        Me.srlstk()
        Me.clr2()
    End Sub

    Private Sub btnsrlfresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsrlfresh.Click
        txtsl.Text = "1"
        Me.clr2()
    End Sub

    Private Sub btnsrlview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsrlview.Click
        Dim ds As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY mast_slno.slno) AS 'Sl.',item.it_name AS 'Product Name', manf.manf_nm AS 'Manf. Name', itgrp.gp_nm AS 'Group', mast_slno.slno AS 'Serial No.', (CASE WHEN mast_slno.io_pos='I' Then 'In' WHEN mast_slno.io_pos='O' Then 'Out' END) AS 'In/Out' FROM itgrp RIGHT OUTER JOIN item ON itgrp.gp_cd = item.gp_cd LEFT OUTER JOIN manf ON item.manf_cd = manf.manf_cd RIGHT OUTER JOIN mast_slno ON item.it_cd = mast_slno.it_cd WHERE (item.bat_cnf = 'S') ORDER BY mast_slno.slno")
        'dvsrlview.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            dvsrlview.DataSource = ds.Tables(0)
        End If
        dvsrlview.Visible = True
        dvsrlview.Dock = DockStyle.Fill
    End Sub

    Private Sub btnbatview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatview.Click
        Dim ds As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name) AS 'Sl.',item.it_name AS 'Product Name', itgrp.gp_nm AS 'Group', manf.manf_nm AS 'Manuf. Name',batno.bat_no AS 'Batch No.',RIGHT(convert(varchar,batno.manf_dt,103),7) AS 'Manf.Dt.',  STR(batno.mrp, 10, 2) AS 'MRP', STR(batno.pur_rate, 10, 2) AS 'Pur.Rate', STR(batno.sale_rate1, 10, 2) AS 'Sale Rate', RIGHT(convert(varchar,batno.exp_dt,103),7) AS 'Exp.Dt.' FROM item LEFT OUTER JOIN batno ON item.it_cd = batno.it_cd LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN manf ON item.manf_cd = manf.manf_cd WHERE (item.bat_cnf = 'B') ORDER BY item.it_name")
        dvbatview.Columns.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            dvbatview.DataSource = ds.Tables(0)
        End If
        dvbatview.Visible = True
        dvbatview.Dock = DockStyle.Fill
    End Sub
#End Region

#Region "Keypress"

    Private Sub txtitnm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtitnm.KeyPress
        key(txthsncode, e)
        SPKey(e)
    End Sub

    Private Sub txthsncode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthsncode.KeyPress
        key(txtdescri, e)
        SPKey(e)
    End Sub

    Private Sub txtitemcd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsrtcode.KeyPress
        key(txtdescri, e)
        SPKey(e)
    End Sub

    Private Sub txtdescri_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescri.KeyPress
        key(cmbmanf, e)
        SPKey(e)
    End Sub

    Private Sub cmbmanfct_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbmanf.KeyPress
        key(cmbtype, e)
        SPKey(e)
    End Sub

    Private Sub cmbtype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtype.KeyPress
        key(cmbgrp, e)
        SPKey(e)
    End Sub

    Private Sub cmbgrp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgrp.KeyPress
        If TabControl1.SelectedIndex = 0 Then
            key(cmbtaxtp, e)
        ElseIf TabControl1.SelectedIndex = 1 Then
            key(txtbatch, e)
        Else
            key(txtsrlno, e)
        End If
        SPKey(e)
    End Sub

    Private Sub cmbtaxtp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtaxtp.KeyPress
        key(cmbonsale, e)
        SPKey(e)
    End Sub

    Private Sub cmbonsale_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbonsale.KeyPress
        key(cmbonpurch, e)
        SPKey(e)
    End Sub

    Private Sub cmbonpurch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbonpurch.KeyPress
        key(txtmrp, e)
        SPKey(e)
    End Sub

    Private Sub txtmrp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmrp.KeyPress
        key(txtpurrt, e)
        NUM1(e)
    End Sub

    Private Sub txtpurrt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpurrt.KeyPress
        key(txtstock, e)
        NUM1(e)
    End Sub

    Private Sub txtstock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstock.KeyPress
        key(txtcat1, e)
        NUM1(e)
    End Sub

    Private Sub txtcat1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcat1.KeyPress
        key(txtcat2, e)
        NUM1(e)
    End Sub

    Private Sub txtcat2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcat2.KeyPress
        key(txtcat3, e)
        NUM1(e)
    End Sub

    Private Sub txtcat3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcat3.KeyPress
        key(txtcat4, e)
        NUM1(e)
    End Sub

    Private Sub txtcat4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcat4.KeyPress
        key(txtoppurrt, e)
        NUM1(e)
    End Sub

    Private Sub txtpurrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtoppurrt.KeyPress
        key(txtopsalrt, e)
        NUM1(e)
    End Sub

    Private Sub txtsalrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtopsalrt.KeyPress
        key(txtopstkrt, e)
        NUM1(e)
    End Sub

    Private Sub txtstkrt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtopstkrt.KeyPress
        key(txtstkval, e)
        NUM1(e)
    End Sub

    Private Sub txtstkval_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstkval.KeyPress
        key(txtcodisper, e)
        NUM1(e)
    End Sub

    Private Sub cmbbatch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbatch.KeyPress
        key(cmblock, e)
    End Sub

    Private Sub cmblock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblock.KeyPress
        key(txtcodisper, e)
    End Sub

    Private Sub txtcodisper_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodisper.KeyPress
        key(txtcodisamt, e)
        NUM1(e)
    End Sub

    Private Sub txtcodisamt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodisamt.KeyPress
        key(txttrdisper, e)
        NUM1(e)
    End Sub

    Private Sub txttrdisper_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttrdisper.KeyPress
        key(txttrdisamt, e)
        NUM1(e)
    End Sub

    Private Sub txttrdisamt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttrdisamt.KeyPress
        key(txtcodisper1, e)
        NUM1(e)
    End Sub

    Private Sub txtcodisper1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodisper1.KeyPress
        key(txtcodisamt1, e)
        NUM1(e)
    End Sub

    Private Sub txtcodisamt1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodisamt1.KeyPress
        key(txttrdisper1, e)
        NUM1(e)
    End Sub

    Private Sub txttrdisper1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttrdisper1.KeyPress
        key(txttrdisamt1, e)
        NUM1(e)
    End Sub

    Private Sub txttrdisamt1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttrdisamt1.KeyPress
        key(cmbunit1, e)
        NUM1(e)
    End Sub

    Private Sub cmbunit1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunit1.KeyPress
        If txtmulti1.Enabled = True Then
            key(txtmulti1, e)
        Else
            key(cmbgodwn, e)
        End If
        SPKey(e)
    End Sub

    Private Sub cmbunit2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunt2.KeyPress
        If txtmulti2.Visible = True Then
            key(txtmulti2, e)
        Else
            key(cmbgodwn, e)
        End If
        SPKey(e)
    End Sub

    Private Sub txtmulti1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmulti1.KeyPress
        key(cmbunt2, e)
        NUM(e)
    End Sub

    Private Sub cmbunit3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunt3.KeyPress
        key(txtmulti3, e)
        SPKey(e)
    End Sub

    Private Sub txtmulti2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmulti2.KeyPress
        key(cmbunt3, e)
        NUM(e)
    End Sub

    Private Sub cmbunit4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbunt4.KeyPress
        key(cmbgodwn, e)
        SPKey(e)
    End Sub

    Private Sub txtmulti3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmulti3.KeyPress
        key(cmbunt4, e)
        NUM(e)
    End Sub

    Private Sub cmbgodwn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbgodwn.KeyPress
        If Trim(cmbgodwn.Text) = "" Then
            key(btnsave, e)
        Else
            key(txtsound, e)
        End If
        SPKey(e)
    End Sub

    Private Sub txtsound_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsound.KeyPress
        key(txtdmgd, e)
        NUM(e)
    End Sub

    Private Sub txtdmgd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdmgd.KeyPress
        key(btnstknxt, e)
        NUM(e)
    End Sub

    Private Sub txtbatch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbatch.KeyPress
        key(txtmfgdt, e)
        SPKey(e)
    End Sub

    Private Sub txtmfgdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmfgdt.KeyPress
        key(txtexpdt, e)
        NUM(e)
    End Sub

    Private Sub txtexpdt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtexpdt.KeyPress
        key(cmbbattaxtp, e)
        NUM(e)
    End Sub

    Private Sub cmbbattaxtp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbattaxtp.KeyPress
        key(cmbbatonsal, e)
        SPKey(e)
    End Sub

    Private Sub cmbbatonsal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbatonsal.KeyPress
        key(txtfree, e)
        SPKey(e)
    End Sub

    Private Sub cmbbatonpur_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbbatonpur.KeyPress
        key(txtfree, e)
        SPKey(e)
    End Sub

    Private Sub txtfree_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfree.KeyPress
        key(txton, e)
        NUM(e)
    End Sub

    Private Sub txton_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txton.KeyPress
        key(txtsndopn, e)
        NUM(e)
    End Sub

    Private Sub txtsndopn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsndopn.KeyPress
        key(txtdmgopn, e)
        NUM1(e)
    End Sub

    Private Sub txtdmgopn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdmgopn.KeyPress
        key(txtbatmrp, e)
        NUM1(e)
    End Sub

    Private Sub txtbatmrp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbatmrp.KeyPress
        key(txtbatpurt, e)
        NUM1(e)
    End Sub

    Private Sub txtbatpurt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbatpurt.KeyPress
        key(txtbatstrt, e)
        NUM1(e)
    End Sub

    Private Sub txtbatstrt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbatstrt.KeyPress
        key(txtbatcat1, e)
        NUM1(e)
    End Sub

    Private Sub txtbatcat1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbatcat1.KeyPress
        key(txtbatcat2, e)
        NUM1(e)
    End Sub

    Private Sub txtbatcat2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbatcat2.KeyPress
        key(txtbatcat3, e)
        NUM1(e)
    End Sub

    Private Sub txtbatcat3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbatcat3.KeyPress
        key(txtbatcat4, e)
        NUM1(e)
    End Sub

    Private Sub txtbatcat4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbatcat4.KeyPress
        key(txtbatoppurrat, e)
        NUM1(e)
    End Sub

    Private Sub txtbatoppurrat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbatoppurrat.KeyPress
        key(txtbatopsalrt, e)
        NUM1(e)
    End Sub

    Private Sub txtbatopsalrt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbatopsalrt.KeyPress
        key(txtbatopstrt, e)
        NUM1(e)
    End Sub

    Private Sub txtbatopstrt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbatopstrt.KeyPress
        key(txtbatopstkval, e)
        NUM1(e)
    End Sub

    Private Sub txtbatopstkval_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbatopstkval.KeyPress
        key(btnbatnxt, e)
        NUM1(e)
    End Sub

    Private Sub txtsrlno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsrlno.KeyPress
        key(btnsrlnxt, e)
        SPKey(e)
    End Sub
#End Region

#Region "Combo Box"

    Private Sub cmbmanf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmanf.GotFocus
        populate(cmbmanf, "SELECT manf_nm FROM manf WHERE rec_lock='N' ORDER BY manf_nm")
    End Sub

    Private Sub cmbmanf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmanf.LostFocus
        cmbmanf.Height = 21
    End Sub

    Private Sub cmbmanf_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmanf.Validated
        vdated(txtmanfcd, "SELECT manf_cd FROM manf WHERE manf_nm='" & Trim(cmbmanf.Text) & "'")
    End Sub

    Private Sub cmbmanf_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmanf.Validating
        vdating(cmbmanf, "SELECT manf_nm FROM manf WHERE manf_nm='" & Trim(cmbmanf.Text) & "' AND rec_lock='N'", "Please Select A Valid Manufacturer Name.")
    End Sub

    Private Sub cmbgrp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgrp.GotFocus
        populate(cmbgrp, "SELECT gp_nm FROM itgrp WHERE rec_lock='N' ORDER BY gp_nm")
    End Sub

    Private Sub cmbgrp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgrp.LostFocus
        cmbgrp.Height = 21
    End Sub

    Private Sub cmbgrp_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgrp.Validated
        vdated(txtgrpcd, "SELECT gp_cd FROM itgrp WHERE gp_nm='" & Trim(cmbgrp.Text) & "'")
    End Sub

    Private Sub cmbgrp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgrp.Validating
        vdating(cmbgrp, "SELECT gp_nm FROM itgrp WHERE gp_nm='" & Trim(cmbgrp.Text) & "' AND rec_lock='N'", "Please Select A Valid Group Name.")
    End Sub

    Private Sub cmbonsale_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbonsale.GotFocus
        populate(cmbonsale, "SELECT txname FROM taxper WHERE rec_lock='N' ORDER BY txname")
    End Sub

    Private Sub cmbonsale_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbonsale.LostFocus
        cmbonsale.Height = 21
    End Sub

    Private Sub cmbonsale_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbonsale.Validated
        Dim ds As DataSet = get_dataset("SELECT taxcd FROM taxper WHERE txname='" & Trim(cmbonsale.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtonsalcd.Text = ds.Tables(0).Rows(0).Item(0)
            If Val(txtonpurcd.Text) = 0 Then
                txtonpurcd.Text = Val(txtonsalcd.Text)
            End If
            If Trim(cmbonpurch.Text) = "" Then
                cmbonpurch.Text = Trim(cmbonsale.Text)
            End If
        End If
    End Sub

    Private Sub cmbonsale_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbonsale.Validating
        vdating(cmbonsale, "SELECT txname FROM taxper WHERE txname='" & Trim(cmbonsale.Text) & "' AND rec_lock='N'", "Please Select A Valid Tax Name.")
    End Sub

    Private Sub cmbonpurch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbonpurch.GotFocus
        populate(cmbonpurch, "SELECT txname FROM taxper WHERE rec_lock='N' ORDER BY txname")
    End Sub

    Private Sub cmbonpurch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbonpurch.LostFocus
        cmbonpurch.Height = 21
    End Sub

    Private Sub cmbonpurch_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbonpurch.Validated
        vdated(txtonpurcd, "SELECT taxcd FROM taxper WHERE txname='" & Trim(cmbonpurch.Text) & "'")
    End Sub

    Private Sub cmbonpurch_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbonpurch.Validating
        vdating(cmbonpurch, "SELECT txname FROM taxper WHERE txname='" & Trim(cmbonpurch.Text) & "' AND rec_lock='N'", "Please Select A Valid Tax Name.")
    End Sub

    Private Sub cmbbatonsal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatonsal.GotFocus
        populate(cmbbatonsal, "SELECT txname FROM taxper WHERE rec_lock='N' ORDER BY txname")
    End Sub

    Private Sub cmbbatonsal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatonsal.LostFocus
        cmbbatonsal.Height = 21
    End Sub

    Private Sub cmbbatonsal_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatonsal.Validated
        Dim ds As DataSet = get_dataset("SELECT taxcd FROM taxper WHERE txname='" & Trim(cmbbatonsal.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtbatonsalcd.Text = ds.Tables(0).Rows(0).Item(0)
            If Val(txtbatonpurcd.Text) = 0 Then
                txtbatonpurcd.Text = Val(txtbatonsalcd.Text)
            End If
            If Trim(cmbbatonpur.Text) = "" Then
                cmbbatonpur.Text = Trim(cmbbatonsal.Text)
            End If
        End If
    End Sub

    Private Sub cmbbatonsal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbbatonsal.Validating
        vdating(cmbbatonsal, "SELECT txname FROM taxper WHERE txname='" & Trim(cmbbatonsal.Text) & "' AND rec_lock='N'", "Please Select A Valid Tax Name.")
    End Sub

    Private Sub cmbbatonpur_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatonpur.GotFocus
        populate(cmbbatonpur, "SELECT txname FROM taxper WHERE rec_lock='N' ORDER BY txname")
    End Sub

    Private Sub cmbbatonpur_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatonpur.LostFocus
        cmbbatonpur.Height = 21
    End Sub

    Private Sub cmbbatonpur_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbatonpur.Validated
        vdated(txtbatonpurcd, "SELECT taxcd FROM taxper WHERE txname='" & Trim(cmbbatonpur.Text) & "'")
    End Sub

    Private Sub cmbbatonpur_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbbatonpur.Validating
        vdating(cmbbatonpur, "SELECT txname FROM taxper WHERE txname='" & Trim(cmbbatonpur.Text) & "' AND rec_lock='N'", "Please Select A Valid Tax Name.")
    End Sub

    Private Sub cmbgodwn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodwn.GotFocus
        populate(cmbgodwn, "SELECT godnm FROM godown WHERE rec_lock='N' ORDER BY godnm")
    End Sub

    Private Sub cmbgodwn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodwn.LostFocus
        cmbgodwn.Height = 21
    End Sub

    Private Sub cmbgodwn_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgodwn.Validated
        vdated(txtgodncd, "SELECT godsl FROM godown WHERE godnm='" & Trim(cmbgodwn.Text) & "'")
    End Sub

    Private Sub cmbgodwn_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgodwn.Validating
        vdating(cmbgodwn, "SELECT godnm FROM godown WHERE godnm='" & Trim(cmbgodwn.Text) & "' AND rec_lock='N'", "Please Select A Valid Godown Name.")
    End Sub

    Private Sub cmbunit1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit1.GotFocus
        populate(cmbunit1, "SELECT unt_nm FROM unt WHERE rec_lock='N' ORDER BY unt_nm")
    End Sub

    Private Sub cmbunit1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit1.LostFocus
        cmbunit1.Height = 21
    End Sub

    Private Sub cmbunit1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit1.Validated
        vdated(txtuntcd1, "SELECT unt_cd FROM unt WHERE unt_nm='" & Trim(cmbunit1.Text) & "'")
    End Sub

    Private Sub cmbunit1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit1.Validating
        vdating(cmbunit1, "SELECT unt_nm FROM unt WHERE unt_nm='" & Trim(cmbunit1.Text) & "' AND rec_lock='N'", "Please Select A Valid unit Name.")
    End Sub

    Private Sub cmbunt2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunt2.GotFocus
        populate(cmbunt2, "SELECT unt_nm FROM unt WHERE rec_lock='N' ORDER BY unt_nm")
    End Sub

    Private Sub cmbunt2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunt2.LostFocus
        cmbunt2.Height = 21
    End Sub

    Private Sub cmbunt2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunt2.Validated
        vdated(txtuntcd2, "SELECT unt_cd FROM unt WHERE unt_nm='" & Trim(cmbunt2.Text) & "'")
    End Sub

    Private Sub cmbunt2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunt2.Validating
        vdating(cmbunt2, "SELECT unt_nm FROM unt WHERE unt_nm='" & Trim(cmbunt2.Text) & "' AND rec_lock='N'", "Please Select A Valid unit Name.")
    End Sub

    Private Sub cmbunt3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunt3.GotFocus
        populate(cmbunt3, "SELECT unt_nm FROM unt WHERE rec_lock='N' ORDER BY unt_nm")
    End Sub

    Private Sub cmbunt3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunt3.LostFocus
        cmbunt3.Height = 21
    End Sub

    Private Sub cmbunt3_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunt3.Validated
        vdated(txtuntcd3, "SELECT unt_cd FROM unt WHERE unt_nm='" & Trim(cmbunt3.Text) & "'")
    End Sub

    Private Sub cmbunt3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunt3.Validating
        vdating(cmbunt3, "SELECT unt_nm FROM unt WHERE unt_nm='" & Trim(cmbunt3.Text) & "' AND rec_lock='N'", "Please Select A Valid unit Name.")
    End Sub

    Private Sub cmbunt4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunt4.GotFocus
        populate(cmbunt4, "SELECT unt_nm FROM unt WHERE rec_lock='N' ORDER BY unt_nm")
    End Sub

    Private Sub cmbunt4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunt4.LostFocus
        cmbunt4.Height = 21
    End Sub

    Private Sub cmbunt4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunt4.Validated
        vdated(txtuntcd4, "SELECT unt_cd FROM unt WHERE unt_nm='" & Trim(cmbunt4.Text) & "'")
    End Sub

    Private Sub cmbunt4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunt4.Validating
        vdating(cmbunt4, "SELECT unt_nm FROM unt WHERE unt_nm='" & Trim(cmbunt4.Text) & "' AND rec_lock='N'", "Please Select A Valid unit Name.")
    End Sub
#End Region

#Region "Display"
    Private Sub dv_disp()
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name) AS 'Sl.', item.it_name AS 'Product Name', item.hsn_code AS 'HSN Code', itgrp.gp_nm AS 'Group', manf.manf_nm AS 'Manuf. Name', STR(item.mrp, 10, 2) AS 'MRP', STR(item.pur_rate, 10, 2) AS 'Pur.Rate', STR(item.sale_rate1, 10, 2) AS 'Sale Rate',taxper.taxnm AS 'GST', STR(item.cl_stk, 10, 2) + item.unt1 AS 'Cl.Stk', item.it_cd, item.rec_lock, item.prd_tp FROM item LEFT OUTER JOIN taxper ON item.stx_cd = taxper.taxcd LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN manf ON item.manf_cd = manf.manf_cd ORDER BY item.it_name")
        dv.Columns.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dsedit.Tables(0)
            dv.Columns(10).Visible = False
            dv.Columns(11).Visible = False
            dv.Columns(12).Visible = False
            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(11).Value
                service = dv.Rows(i).Cells(12).Value
                If reclock = "Y" Or service <> "1" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
        End If
        Close1()
        dv.Visible = True
        grpsearch.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub txtsersearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtserregd.TextChanged
        Me.search()
    End Sub

    Private Sub search()
        Dim dssearch As DataSet
        If txtsername.Text <> "" And txtserregd.Text <> "" Then
            If chkexact.Checked = False And chkexact1.Checked = False Then
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name) AS 'Sl.', item.it_name AS 'Product Name', item.hsn_code AS 'HSN Code', itgrp.gp_nm AS 'Group', manf.manf_nm AS 'Manuf. Name', STR(item.mrp, 10, 2) AS 'MRP', STR(item.pur_rate, 10, 2) AS 'Pur.Rate', STR(item.sale_rate1, 10, 2) AS 'Sale Rate',taxper.taxnm AS 'GST', STR(item.cl_stk, 10, 2) + item.unt1 AS 'Cl.Stk', item.it_cd, item.rec_lock, item.prd_tp FROM item LEFT OUTER JOIN taxper ON item.stx_cd = taxper.taxcd LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN manf ON item.manf_cd = manf.manf_cd WHERE item.bar_code LIKE '%" & Trim(txtserregd.Text) & "%' AND item.it_name LIKE '%" & Trim(txtsername.Text) & "%' ORDER BY item.it_name")
            Else
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name) AS 'Sl.', item.it_name AS 'Product Name', item.hsn_code AS 'HSN Code', itgrp.gp_nm AS 'Group', manf.manf_nm AS 'Manuf. Name', STR(item.mrp, 10, 2) AS 'MRP', STR(item.pur_rate, 10, 2) AS 'Pur.Rate', STR(item.sale_rate1, 10, 2) AS 'Sale Rate',taxper.taxnm AS 'GST', STR(item.cl_stk, 10, 2) + item.unt1 AS 'Cl.Stk', item.it_cd, item.rec_lock, item.prd_tp FROM item LEFT OUTER JOIN taxper ON item.stx_cd = taxper.taxcd LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN manf ON item.manf_cd = manf.manf_cd WHERE item.bar_code LIKE '" & Trim(txtserregd.Text) & "%' AND item.it_name LIKE '" & Trim(txtsername.Text) & "%' ORDER BY item.it_name")
            End If
        ElseIf txtserregd.Text <> "" Then
            If chkexact.Checked = False Then
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name) AS 'Sl.', item.it_name AS 'Product Name', item.hsn_code AS 'HSN Code', itgrp.gp_nm AS 'Group', manf.manf_nm AS 'Manuf. Name', STR(item.mrp, 10, 2) AS 'MRP', STR(item.pur_rate, 10, 2) AS 'Pur.Rate', STR(item.sale_rate1, 10, 2) AS 'Sale Rate',taxper.taxnm AS 'GST', STR(item.cl_stk, 10, 2) + item.unt1 AS 'Cl.Stk', item.it_cd, item.rec_lock, item.prd_tp FROM item LEFT OUTER JOIN taxper ON item.stx_cd = taxper.taxcd LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN manf ON item.manf_cd = manf.manf_cd WHERE item.bar_code LIKE '%" & Trim(txtserregd.Text) & "%' ORDER BY item.it_name")
            Else
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name) AS 'Sl.', item.it_name AS 'Product Name', item.hsn_code AS 'HSN Code', itgrp.gp_nm AS 'Group', manf.manf_nm AS 'Manuf. Name', STR(item.mrp, 10, 2) AS 'MRP', STR(item.pur_rate, 10, 2) AS 'Pur.Rate', STR(item.sale_rate1, 10, 2) AS 'Sale Rate',taxper.taxnm AS 'GST', STR(item.cl_stk, 10, 2) + item.unt1 AS 'Cl.Stk', item.it_cd, item.rec_lock, item.prd_tp FROM item LEFT OUTER JOIN taxper ON item.stx_cd = taxper.taxcd LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN manf ON item.manf_cd = manf.manf_cd WHERE item.bar_code LIKE '" & Trim(txtserregd.Text) & "%' ORDER BY item.it_name")
            End If
        ElseIf txtsername.Text <> "" Then
            If chkexact1.Checked = False Then
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name) AS 'Sl.', item.it_name AS 'Product Name', item.hsn_code AS 'HSN Code', itgrp.gp_nm AS 'Group', manf.manf_nm AS 'Manuf. Name', STR(item.mrp, 10, 2) AS 'MRP', STR(item.pur_rate, 10, 2) AS 'Pur.Rate', STR(item.sale_rate1, 10, 2) AS 'Sale Rate',taxper.taxnm AS 'GST', STR(item.cl_stk, 10, 2) + item.unt1 AS 'Cl.Stk', item.it_cd, item.rec_lock, item.prd_tp FROM item LEFT OUTER JOIN taxper ON item.stx_cd = taxper.taxcd LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN manf ON item.manf_cd = manf.manf_cd WHERE item.it_name LIKE '%" & Trim(txtsername.Text) & "%' ORDER BY item.it_name")
            Else
                dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name) AS 'Sl.', item.it_name AS 'Product Name', item.hsn_code AS 'HSN Code', itgrp.gp_nm AS 'Group', manf.manf_nm AS 'Manuf. Name', STR(item.mrp, 10, 2) AS 'MRP', STR(item.pur_rate, 10, 2) AS 'Pur.Rate', STR(item.sale_rate1, 10, 2) AS 'Sale Rate',taxper.taxnm AS 'GST', STR(item.cl_stk, 10, 2) + item.unt1 AS 'Cl.Stk', item.it_cd, item.rec_lock, item.prd_tp FROM item LEFT OUTER JOIN taxper ON item.stx_cd = taxper.taxcd LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN manf ON item.manf_cd = manf.manf_cd WHERE item.it_name LIKE '" & Trim(txtsername.Text) & "%' ORDER BY item.it_name")
            End If
        Else
            dssearch = get_dataset("SELECT ROW_NUMBER() OVER(ORDER BY it_name) AS 'Sl.', item.it_name AS 'Product Name', item.hsn_code AS 'HSN Code', itgrp.gp_nm AS 'Group', manf.manf_nm AS 'Manuf. Name', STR(item.mrp, 10, 2) AS 'MRP', STR(item.pur_rate, 10, 2) AS 'Pur.Rate', STR(item.sale_rate1, 10, 2) AS 'Sale Rate',taxper.taxnm AS 'GST', STR(item.cl_stk, 10, 2) + item.unt1 AS 'Cl.Stk', item.it_cd, item.rec_lock, item.prd_tp FROM item LEFT OUTER JOIN taxper ON item.stx_cd = taxper.taxcd LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN manf ON item.manf_cd = manf.manf_cd ORDER BY item.it_name")
        End If
        dv.Columns.Clear()
        If dssearch.Tables(0).Rows.Count <> 0 Then
            dv.DataSource = dssearch.Tables(0)
            dv.Columns(10).Visible = False
            dv.Columns(11).Visible = False
            dv.Columns(12).Visible = False
            For i As Integer = 0 To dv.Rows.Count - 1
                reclock = dv.Rows(i).Cells(11).Value
                service = dv.Rows(i).Cells(12).Value
                If reclock = "Y" Or service <> "1" Then
                    dv.Rows(i).DefaultCellStyle.BackColor = Color.White
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                Else
                    dv.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            Next
        End If
    End Sub

    Private Sub txtsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsername.TextChanged
        Me.search()
    End Sub
#End Region

#Region "DATA SAVE"
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(txtitnm.Text) = "" Then
            MessageBox.Show("The Product Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtitnm.Focus()
            Exit Sub
        End If
        If Trim(cmbmanf.Text) = "" Or Val(txtmanfcd.Text) = 0 Then
            MessageBox.Show("The Manufacturer Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbmanf.Focus()
            Exit Sub
        End If
        If Trim(cmbgrp.Text) = "" Or Val(txtgrpcd.Text) = 0 Then
            MessageBox.Show("The Product Group Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbgrp.Focus()
            Exit Sub
        End If
        If Trim(cmbonsale.Text) = "" Or Val(txtonsalcd.Text) = 0 Then
            MessageBox.Show("The Sale Tax Category Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            cmbonsale.Focus()
            Exit Sub
        End If
        If Trim(cmbonpurch.Text) = "" Or Val(txtonpurcd.Text) = 0 Then
            MessageBox.Show("The Purchase Tax Category Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            cmbonpurch.Focus()
            Exit Sub
        End If
        If Trim(cmbunit1.Text) = "" Then
            MessageBox.Show("The Primary Unit Name Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            cmbunit1.Focus()
            Exit Sub
        End If
        If cmbbatch.SelectedIndex = 1 Then
            If Val(lblbat_sndstk.Text) <> Val(lblbat_sndqty.Text) Then
                MessageBox.Show("The Product Quantity And Batch Quantity Should Be Equal.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TabControl1.SelectedIndex = 2
                txtsrlno.Focus()
                Exit Sub
            End If
        End If
        If cmbbatch.SelectedIndex = 2 Then
            If Val(lblsrlstk.Text) <> Val(lblsrlqty.Text) Then
                MessageBox.Show("The Product Quantity And Serial Number Quantity Should Be Equal.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TabControl1.SelectedIndex = 2
                txtsrlno.Focus()
                Exit Sub
            End If
        End If

        Me.item_save()
    End Sub

    Private Sub item_save()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT max(it_cd) as 'Max' FROM item")
                txtscrl.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscrl.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO item(it_cd,it_name,prd_tp,descri,bar_code,hsn_code,manf_cd,gp_cd,tax_stl,stx_cd,ptx_cd,mrp,pur_rate,stk_rate," & _
                          "sale_rate1,sale_rate2,sale_rate3,sale_rate4,oppur_rate,opsal_rate,opstk_rate,opstk_val,sal_codisper,sal_codisamt," & _
                          "sal_trdisper,sal_trdisamt,pur_codisper,pur_codisamt,pur_trdisper,pur_trdisamt,unt1,unt2,unt3,unt4,multi1,multi2," & _
                          "multi3,op_stk,rec_stk,iss_stk,cl_stk,dop_stk,drec_stk,diss_stk,dcl_stk,stor_at,bat_cnf,stk_lock,rec_lock,item_image) VALUES (" & _
                          Val(txtscrl.Text) & ",'" & Trim(txtitnm.Text) & "','" & vb.Left(cmbtype.Text, 1) & "','" & Trim(txtdescri.Text) & "','" & _
                          Trim(txtsrtcode.Text) & "','" & Trim(txthsncode.Text) & "'," & Val(txtmanfcd.Text) & "," & Val(txtgrpcd.Text) & ",'" & vb.Left(cmbtaxtp.Text, 1) & _
                          "'," & Val(txtonsalcd.Text) & "," & Val(txtonpurcd.Text) & "," & Val(txtmrp.Text) & "," & Val(txtpurrt.Text) & "," & _
                          Val(txtstock.Text) & "," & Val(txtcat1.Text) & "," & Val(txtcat2.Text) & "," & Val(txtcat3.Text) & "," & Val(txtcat4.Text) & "," & _
                          Val(txtoppurrt.Text) & "," & Val(txtopsalrt.Text) & "," & Val(txtopstkrt.Text) & "," & Val(txtstkval.Text) & "," & _
                          Val(txtcodisper.Text) & "," & Val(txtcodisamt.Text) & "," & Val(txttrdisper.Text) & "," & Val(txttrdisamt.Text) & "," & _
                          Val(txtcodisper1.Text) & "," & Val(txtcodisamt1.Text) & "," & Val(txttrdisper1.Text) & "," & Val(txttrdisamt1.Text) & ",'" & _
                          Trim(cmbunit1.Text) & "','" & Trim(cmbunt2.Text) & "','" & Trim(cmbunt3.Text) & "','" & Trim(cmbunt4.Text) & "'," & _
                          Val(txtmulti1.Text) & "," & Val(txtmulti2.Text) & "," & Val(txtmulti3.Text) & ",0,0,0,0,0,0,0,0,'G','" & _
                          vb.Left(cmbbatch.Text, 1) & "','" & IIf(chklock.Checked, "Y", "N") & "','" & vb.Left(cmblock.Text, 1) & "','')")
                Me.godn_save()
                Me.unit_save()
                If cmbbatch.SelectedIndex = 1 Then
                    Me.batch_save()
                ElseIf cmbbatch.SelectedIndex = 2 Then
                    Me.srl_save()
                End If
                If txtphoto.Text = "Y" Then
                    Me.save_image()
                End If
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.clr()
                Close1()
            End If
        Else
            If usr_tp = "O" Then
                MessageBox.Show("You Are Not Authorised to Modify The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT it_cd FROM item WHERE it_cd=" & Val(txtscrl.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE item SET it_name='" & Trim(txtitnm.Text) & "',prd_tp='" & vb.Left(cmbtype.Text, 1) & "',descri='" & _
                              Trim(txtdescri.Text) & "',bar_code='" & Trim(txtsrtcode.Text) & "',hsn_code='" & Trim(txthsncode.Text) & "',manf_cd=" & Val(txtmanfcd.Text) & ",gp_cd=" & _
                              Val(txtgrpcd.Text) & ", tax_stl='" & vb.Left(cmbtaxtp.Text, 1) & "', stx_cd=" & Val(txtonsalcd.Text) & ", ptx_cd=" & _
                              Val(txtonpurcd.Text) & ", mrp=" & Val(txtmrp.Text) & ", pur_rate= " & Val(txtpurrt.Text) & ",stk_rate=" & _
                              Val(txtstock.Text) & ", sale_rate1=" & Val(txtcat1.Text) & ", sale_rate2=" & Val(txtcat2.Text) & ", sale_rate3=" & _
                              Val(txtcat3.Text) & ", sale_rate4=" & Val(txtcat4.Text) & ", oppur_rate=" & Val(txtoppurrt.Text) & ", opsal_rate=" & _
                              Val(txtopsalrt.Text) & ", opstk_rate=" & Val(txtopstkrt.Text) & ", opstk_val=" & Val(txtstkval.Text) & ", sal_codisper=" & _
                              Val(txtcodisper.Text) & ", sal_codisamt=" & Val(txtcodisamt.Text) & ", sal_trdisper=" & _
                              Val(txttrdisper.Text) & ", sal_trdisamt=" & Val(txttrdisamt.Text) & ", pur_codisper=" & _
                              Val(txtcodisper1.Text) & ", pur_codisamt=" & Val(txtcodisamt1.Text) & ", pur_trdisper=" & _
                              Val(txttrdisper1.Text) & ", pur_trdisamt=" & Val(txttrdisamt1.Text) & ", unt1='" & Trim(cmbunit1.Text) & "', unt2='" & _
                              Trim(cmbunt2.Text) & "', unt3='" & Trim(cmbunt3.Text) & "', unt4='" & Trim(cmbunt4.Text) & "', multi1=" & _
                              Val(txtmulti1.Text) & ", multi2=" & Val(txtmulti2.Text) & ", multi3=" & Val(txtmulti3.Text) & ", bat_cnf='" & _
                              vb.Left(cmbbatch.Text, 1) & "', stk_lock='" & IIf(chklock.Checked, "Y", "N") & "', rec_lock='" & _
                              vb.Left(cmblock.Text, 1) & "' WHERE it_cd =" & Val(txtscrl.Text) & "")
                    Me.godn_save()
                    Me.unit_save()
                    If cmbbatch.SelectedIndex = 1 Then
                        Me.batch_save()
                    ElseIf cmbbatch.SelectedIndex = 2 Then
                        Me.srl_save()
                    End If
                    If txtphoto.Text = "Y" Then
                        Me.save_image()
                    End If
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                    Me.dv_disp()
                End If
                Close1()
            End If
        End If
    End Sub

    Private Sub batch_save()
        If dvbat.RowCount <> 0 Then
            SQLInsert("DELETE FROM batno WHERE it_cd=" & Val(txtscrl.Text) & "")
            For i As Integer = 0 To dvbat.RowCount - 1
                batch = dvbat.Rows(i).Cells(1).Value
                mfgdt = dvbat.Rows(i).Cells(2).Value
                expdt = dvbat.Rows(i).Cells(3).Value
                battaxtp = vb.Left(dvbat.Rows(i).Cells(4).Value, 1)
                free = dvbat.Rows(i).Cells(7).Value
                fron = dvbat.Rows(i).Cells(8).Value
                sndopn = dvbat.Rows(i).Cells(9).Value
                dmgopn = dvbat.Rows(i).Cells(10).Value
                batmrp = dvbat.Rows(i).Cells(11).Value
                batpurt = dvbat.Rows(i).Cells(12).Value
                batstrt = dvbat.Rows(i).Cells(13).Value
                batcat1 = dvbat.Rows(i).Cells(14).Value
                batcat2 = dvbat.Rows(i).Cells(15).Value
                batcat3 = dvbat.Rows(i).Cells(16).Value
                batcat4 = dvbat.Rows(i).Cells(17).Value
                batoppurrat = dvbat.Rows(i).Cells(18).Value
                batopsalrt = dvbat.Rows(i).Cells(19).Value
                batopstrt = dvbat.Rows(i).Cells(20).Value
                batopstkval = dvbat.Rows(i).Cells(21).Value
                batonsalcd = dvbat.Rows(i).Cells(22).Value
                batonpurcd = dvbat.Rows(i).Cells(23).Value
                mm = vb.Left(mfgdt, 2)
                yy = vb.Right(mfgdt, 4)

                mm1 = vb.Left(expdt, 2)
                yy1 = vb.Right(expdt, 4)
                mfgdt1 = CDate(mm & "/" & "01/" & yy)
                expdt1 = CDate(mm1 & "/" & "01/" & yy1)

                Dim ds1 As DataSet = get_dataset("SELECT max(bat_cd) as 'Max' FROM batno")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO batno(bat_cd,bat_no,it_cd,exp_dt,tax_stl,stx_cd,ptx_cd,mrp,pur_rate,stk_rate,sale_rate1,sale_rate2," & _
                          "sale_rate3,sale_rate4,freeqty,freeon,oppur_rate,opsal_rate,opstk_rate,opstk_val,op_stk,rec_stk,iss_stk,cl_stk," & _
                          "dop_stk,drec_stk,diss_stk,dcl_stk,manf_dt,rec_lock,prt_code,pur_dt,inv_no,inv_dt) VALUES (" & Val(mxno) & ",'" & batch & "'," & _
                          Val(txtscrl.Text) & ",'" & Format(expdt1, "dd/MMM/yyyy") & "','" & battaxtp & "'," & Val(batonsalcd) & "," & Val(batonpurcd) & "," & _
                          Val(batmrp) & "," & Val(batpurt) & "," & Val(batstrt) & "," & Val(batcat1) & "," & Val(batcat2) & "," & _
                          Val(batcat3) & "," & Val(batcat4) & "," & Val(free) & "," & Val(fron) & "," & Val(batoppurrat) & "," & _
                          Val(batopsalrt) & "," & Val(batopstrt) & "," & Val(batopstkval) & "," & Val(sndopn) & ",0,0," & Val(sndopn) & "," & _
                          Val(dmgopn) & ",0,0," & Val(dmgopn) & ",'" & Format(mfgdt1, "dd/MMM/yyyy") & "','N',0,'" & sys_date & "','','" & sys_date & "')")
            Next
        End If
    End Sub

    Private Sub godn_save()
        Me.god_del(txtscrl.Text)
        If dv1.RowCount <> 0 Then
            For i As Integer = 0 To dv1.RowCount - 1
                sqty = dv1.Rows(i).Cells(2).Value
                dqty = dv1.Rows(i).Cells(3).Value
                gdn_cd = dv1.Rows(i).Cells(4).Value
                Dim ds1 As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM opgodown")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO opgodown(slno, it_cd, op_stkp,op_stks, godsl) VALUES (" & Val(mxno) & "," & _
                          Val(txtscrl.Text) & "," & Val(sqty) & "," & Val(dqty) & "," & Val(gdn_cd) & ")")
                Dim ds As DataSet = get_dataset("SELECT op_stk,cl_stk,dop_stk,dcl_stk FROM item WHERE it_cd=" & Val(txtscrl.Text) & "")
                opstk1 = 0
                dopstk1 = 0
                clstk1 = 0
                dclstk1 = 0
                If ds.Tables(0).Rows.Count <> 0 Then
                    opstk = Val(ds.Tables(0).Rows(0).Item(0))
                    clstk = Val(ds.Tables(0).Rows(0).Item(1))
                    dopstk = Val(ds.Tables(0).Rows(0).Item(2))
                    dclstk = Val(ds.Tables(0).Rows(0).Item(3))
                    opstk1 = opstk + Val(sqty)
                    dopstk1 = dopstk + Val(dqty)
                    'If clstk = 0 Then
                    clstk1 = clstk + Val(sqty)
                    'End If
                    'If dclstk = 0 Then
                    dclstk1 = dclstk + Val(dqty)
                    'End If
                End If
                SQLInsert("UPDATE item SET op_stk=" & opstk1 & ",cl_stk=" & clstk1 & ",dop_stk=" & dopstk1 & ",dcl_stk=" & dclstk1 & " WHERE it_cd=" & Val(txtscrl.Text) & "")
            Next

        End If
    End Sub

    Private Sub srl_save()
        SQLInsert("DELETE FROM mast_slno WHERE it_cd=" & Val(txtscrl.Text) & "")
        If dvsrl.RowCount <> 0 Then
            For i As Integer = 0 To dvsrl.RowCount - 1
                slno = dvsrl.Rows(i).Cells(1).Value
                trans = dvsrl.Rows(i).Cells(3).Value
                Dim ds1 As DataSet = get_dataset("SELECT max(sl_slno) as 'Max' FROM mast_slno")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO mast_slno(sl_slno, it_cd, slno,io_pos, trans) VALUES (" & Val(mxno) & "," & _
                          Val(txtscrl.Text) & ",'" & Trim(slno) & "','I','" & Trim(trans) & "')")
                SQLInsert("INSERT INTO prod_slno(sl_slno, it_cd) VALUES (" & Val(mxno) & "," & Val(txtscrl.Text) & ")")
            Next
        End If
    End Sub

    Private Sub unit_save()
        SQLInsert("DELETE FROM untlnk WHERE it_cd=" & Val(txtscrl.Text) & "")

        Dim ds1 As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM untlnk")
        mxno = 1
        If ds1.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                mxno = ds1.Tables(0).Rows(0).Item(0) + 1
            End If
        End If
        If Trim(cmbunit1.Text) <> "" Then
            SQLInsert("INSERT INTO untlnk(slno, it_cd,unt_pos, unt_nm,mul_rt,unt_cd) VALUES (" & Val(mxno) & "," & _
               Val(txtscrl.Text) & ",1,'" & Trim(cmbunit1.Text) & "',1," & Val(txtuntcd1.Text) & ")")
            mxno += 1
        End If
        If Trim(cmbunt2.Text) <> "" Then
            SQLInsert("INSERT INTO untlnk(slno, it_cd,unt_pos, unt_nm,mul_rt,unt_cd) VALUES (" & Val(mxno) & "," & _
               Val(txtscrl.Text) & ",2,'" & Trim(cmbunt2.Text) & "'," & Val(txtmulti1.Text) & "," & Val(txtuntcd2.Text) & ")")
            mxno += 1
        End If
        If Trim(cmbunt3.Text) <> "" Then
            SQLInsert("INSERT INTO untlnk(slno, it_cd,unt_pos, unt_nm,mul_rt,unt_cd) VALUES (" & Val(mxno) & "," & _
               Val(txtscrl.Text) & ",3,'" & Trim(cmbunt3.Text) & "'," & Val(txtmulti2.Text) * Val(txtmulti1.Text) & "," & Val(txtuntcd3.Text) & ")")
            mxno += 1
        End If
        If Trim(cmbunt4.Text) <> "" Then
            SQLInsert("INSERT INTO untlnk(slno, it_cd,unt_pos, unt_nm,mul_rt,unt_cd) VALUES (" & Val(mxno) & "," & _
               Val(txtscrl.Text) & ",4,'" & Trim(cmbunt4.Text) & "'," & Val(txtmulti3.Text) * Val(txtmulti2.Text) * Val(txtmulti1.Text) & "," & Val(txtuntcd4.Text) & ")")
            mxno += 1
        End If

    End Sub

    Private Sub save_image()
        Try
            Dim cmd_img As New SqlCommand("UPDATE item SET item_image=@item_image WHERE it_cd=" & Val(txtscrl.Text) & "", con_img)
            Dim ms As New MemoryStream()
            pict1.BackgroundImage.Save(ms, pict1.BackgroundImage.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@item_image", SqlDbType.Image)
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
        Dim cmd_img As New SqlCommand("SELECT item_image FROM item WHERE it_cd=" & Val(txtscrl.Text) & " ", con_img)
        cmd_img.Parameters.AddWithValue("item_image", 3)
        Try
            con_img.Open()
            pict1.SizeMode = PictureBoxSizeMode.StretchImage
            pict1.BackgroundImage = Image.FromStream(New IO.MemoryStream(CType(cmd_img.ExecuteScalar, Byte())))
            ' or you can save in a file 
            IO.File.WriteAllBytes(My.Application.Info.DirectoryPath & "\item.jpg", CType(cmd_img.ExecuteScalar, Byte()))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con_img.Close()
        End Try
    End Sub
#End Region

#Region "Retrieve"
    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT item.*, taxper.txname, manf.manf_nm, itgrp.gp_nm,(SELECT txname FROM taxper WHERE taxper.taxcd=item.ptx_cd) AS ptx_nm,DataLength(item.item_image) AS item_img FROM item LEFT OUTER JOIN itgrp ON item.gp_cd = itgrp.gp_cd LEFT OUTER JOIN manf ON item.manf_cd = manf.manf_cd LEFT OUTER JOIN taxper ON item.stx_cd = taxper.taxcd WHERE (item.it_cd = " & Val(slno) & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscrl.Text = slno
            txtitnm.Text = dsedit.Tables(0).Rows(0).Item("it_name")
            txtsrtcode.Text = dsedit.Tables(0).Rows(0).Item("bar_code")
            txthsncode.Text = dsedit.Tables(0).Rows(0).Item("hsn_code")
            txtdescri.Text = dsedit.Tables(0).Rows(0).Item("descri")
            cmbmanf.Text = dsedit.Tables(0).Rows(0).Item("manf_nm")
            txtmanfcd.Text = dsedit.Tables(0).Rows(0).Item("manf_cd")
            cmbgrp.Text = dsedit.Tables(0).Rows(0).Item("gp_nm")
            txtgrpcd.Text = dsedit.Tables(0).Rows(0).Item("gp_cd")
            cmbonsale.Text = dsedit.Tables(0).Rows(0).Item("txname")
            txtonsalcd.Text = dsedit.Tables(0).Rows(0).Item("stx_cd")
            cmbonpurch.Text = dsedit.Tables(0).Rows(0).Item("ptx_nm")
            txtonpurcd.Text = dsedit.Tables(0).Rows(0).Item("ptx_cd")
            txtmrp.Text = Format(dsedit.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            txtpurrt.Text = Format(dsedit.Tables(0).Rows(0).Item("pur_rate"), "#######0.00")
            txtstock.Text = Format(dsedit.Tables(0).Rows(0).Item("stk_rate"), "#######0.00")
            txtcat1.Text = Format(dsedit.Tables(0).Rows(0).Item("sale_rate1"), "#######0.00")
            txtcat2.Text = Format(dsedit.Tables(0).Rows(0).Item("sale_rate2"), "#######0.00")
            txtcat3.Text = Format(dsedit.Tables(0).Rows(0).Item("sale_rate3"), "#######0.00")
            txtcat4.Text = Format(dsedit.Tables(0).Rows(0).Item("sale_rate4"), "#######0.00")
            txtoppurrt.Text = Format(dsedit.Tables(0).Rows(0).Item("oppur_rate"), "#######0.00")
            txtopsalrt.Text = Format(dsedit.Tables(0).Rows(0).Item("opsal_rate"), "#######0.00")
            txtopstkrt.Text = Format(dsedit.Tables(0).Rows(0).Item("opstk_rate"), "#######0.00")
            txtstkval.Text = Format(dsedit.Tables(0).Rows(0).Item("opstk_val"), "#######0.00")
            txtcodisper.Text = Format(dsedit.Tables(0).Rows(0).Item("sal_codisper"), "#######0.00")
            txtcodisamt.Text = Format(dsedit.Tables(0).Rows(0).Item("sal_codisamt"), "#######0.00")
            txttrdisper.Text = Format(dsedit.Tables(0).Rows(0).Item("sal_trdisper"), "#######0.00")
            txttrdisamt.Text = Format(dsedit.Tables(0).Rows(0).Item("sal_trdisamt"), "#######0.00")
            txtcodisper1.Text = Format(dsedit.Tables(0).Rows(0).Item("pur_codisper"), "#######0.00")
            txtcodisamt1.Text = Format(dsedit.Tables(0).Rows(0).Item("pur_codisamt"), "#######0.00")
            txttrdisper1.Text = Format(dsedit.Tables(0).Rows(0).Item("pur_trdisper"), "#######0.00")
            txttrdisamt1.Text = Format(dsedit.Tables(0).Rows(0).Item("pur_trdisamt"), "#######0.00")
            'cmbunit1.Text = dsedit.Tables(0).Rows(0).Item("unt1")
            'cmbunt2.Text = dsedit.Tables(0).Rows(0).Item("unt2")
            'cmbunt3.Text = dsedit.Tables(0).Rows(0).Item("unt3")
            'cmbunt4.Text = dsedit.Tables(0).Rows(0).Item("unt4")
            'txtmulti1.Text = Format(dsedit.Tables(0).Rows(0).Item("multi1"), "##0")
            'txtmulti2.Text = Format(dsedit.Tables(0).Rows(0).Item("multi2"), "##0")
            'txtmulti3.Text = Format(dsedit.Tables(0).Rows(0).Item("multi3"), "##0")
            cmbtype.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("prd_tp")) - 1
            If dsedit.Tables(0).Rows(0).Item("tax_stl") = "I" Then
                cmbtaxtp.SelectedIndex = 0
            Else
                cmbtaxtp.SelectedIndex = 1
            End If
            If dsedit.Tables(0).Rows(0).Item("bat_cnf") = "N" Then
                cmbbatch.SelectedIndex = 0
            ElseIf dsedit.Tables(0).Rows(0).Item("bat_cnf") = "B" Then
                cmbbatch.SelectedIndex = 1
            Else
                cmbbatch.SelectedIndex = 2
            End If
            If dsedit.Tables(0).Rows(0).Item("rec_lock") = "N" Then
                cmblock.SelectedIndex = 0
            Else
                cmblock.SelectedIndex = 1
            End If

            If dsedit.Tables(0).Rows(0).Item("stk_lock") = "N" Then
                chklock.Checked = False
            Else
                chklock.Checked = True
            End If
            img_length = dsedit.Tables(0).Rows(0).Item("item_img")
            If Val(img_length) <> 0 Then
                txtphoto.Text = "Y"
                Me.show_image()
            End If
            Me.godn_view()
            Me.unit_view()

            Label20.Visible = True
            'Label26.Visible = True
            'Label21.Visible = True
            'Label13.Visible = True
            'Label11.Visible = True
            txtmulti1.Enabled = True
            'txtmulti2.Visible = True
            'txtmulti3.Visible = True
            cmbunt2.Visible = True
            'cmbunt3.Visible = True
            'cmbunt4.Visible = True
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
            If cmbbatch.SelectedIndex = 1 Then
                TabControl1.TabPages.Add(TabPage2)
                Me.batch_view()
            ElseIf cmbbatch.SelectedIndex = 2 Then
                TabControl1.TabPages.Add(TabPage3)
                Label20.Visible = False
                'Label26.Visible = False
                'Label21.Visible = False
                'Label13.Visible = False
                'Label11.Visible = False
                txtmulti1.Enabled = False
                'txtmulti2.Visible = False
                'txtmulti3.Visible = False
                cmbunt2.Visible = False
                'cmbunt3.Visible = False
                'cmbunt4.Visible = False
                Me.seral_view()
            End If
        End If
        Close1()
    End Sub

    Private Sub batch_view()
        Dim ds As DataSet = get_dataset("SELECT batno.*, taxper.txname,(SELECT txname FROM taxper WHERE taxper.taxcd=batno.ptx_cd) AS ptx_nm FROM batno LEFT OUTER JOIN taxper ON batno.stx_cd = taxper.taxcd WHERE (batno.it_cd = " & Val(txtscrl.Text) & ")")
        rw = 0
        dvbat.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dvbat.Rows.Add()
                dvbat.Rows(rw).Cells(0).Value = i + 1
                dvbat.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("bat_no")
                dvbat.Rows(rw).Cells(2).Value = Format(ds.Tables(0).Rows(i).Item("manf_dt"), "MM/yyyy")
                dvbat.Rows(rw).Cells(3).Value = Format(ds.Tables(0).Rows(i).Item("exp_dt"), "MM/yyyy")
                If ds.Tables(0).Rows(i).Item("tax_stl") = "I" Then
                    dvbat.Rows(rw).Cells(4).Value = "Inclusive"
                Else
                    dvbat.Rows(rw).Cells(4).Value = "Exclusive"
                End If
                dvbat.Rows(rw).Cells(5).Value = ds.Tables(0).Rows(i).Item("txname")
                dvbat.Rows(rw).Cells(6).Value = ds.Tables(0).Rows(i).Item("ptx_nm")
                dvbat.Rows(rw).Cells(7).Value = Format(ds.Tables(0).Rows(i).Item("freeqty"), "#######0.00")
                dvbat.Rows(rw).Cells(8).Value = Format(ds.Tables(0).Rows(i).Item("freeon"), "#######0")
                dvbat.Rows(rw).Cells(9).Value = Format(ds.Tables(0).Rows(i).Item("op_stk"), "#######0.00")
                dvbat.Rows(rw).Cells(10).Value = Format(ds.Tables(0).Rows(i).Item("dop_stk"), "#######0.00")
                dvbat.Rows(rw).Cells(11).Value = Format(ds.Tables(0).Rows(i).Item("mrp"), "#######0.00")
                dvbat.Rows(rw).Cells(12).Value = Format(ds.Tables(0).Rows(i).Item("pur_rate"), "#######0.00")
                dvbat.Rows(rw).Cells(13).Value = Format(ds.Tables(0).Rows(i).Item("stk_rate"), "#######0.00")
                dvbat.Rows(rw).Cells(14).Value = Format(ds.Tables(0).Rows(i).Item("sale_rate1"), "#######0.00")
                dvbat.Rows(rw).Cells(15).Value = Format(ds.Tables(0).Rows(i).Item("sale_rate2"), "#######0.00")
                dvbat.Rows(rw).Cells(16).Value = Format(ds.Tables(0).Rows(i).Item("sale_rate3"), "#######0.00")
                dvbat.Rows(rw).Cells(17).Value = Format(ds.Tables(0).Rows(i).Item("sale_rate4"), "#######0.00")
                dvbat.Rows(rw).Cells(18).Value = Format(ds.Tables(0).Rows(i).Item("oppur_rate"), "#######0.00")
                dvbat.Rows(rw).Cells(19).Value = Format(ds.Tables(0).Rows(i).Item("opsal_rate"), "#######0.00")
                dvbat.Rows(rw).Cells(20).Value = Format(ds.Tables(0).Rows(i).Item("opstk_rate"), "#######0.00")
                dvbat.Rows(rw).Cells(21).Value = Format(ds.Tables(0).Rows(i).Item("opstk_val"), "#######0.00")
                dvbat.Rows(rw).Cells(22).Value = ds.Tables(0).Rows(i).Item("stx_cd")
                dvbat.Rows(rw).Cells(23).Value = ds.Tables(0).Rows(i).Item("ptx_cd")
                rw += 1
            Next
            txtbatsl.Text = rw + 1
            Me.batstk()
        End If
    End Sub

    Private Sub godn_view()
        Dim ds As DataSet = get_dataset("SELECT opgodown.*, godown.godnm FROM opgodown LEFT OUTER JOIN godown ON opgodown.godsl = godown.godsl WHERE opgodown.it_cd=" & Val(txtscrl.Text) & "")
        rw = 0
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("godnm")
                dv1.Rows(rw).Cells(2).Value = Format(ds.Tables(0).Rows(i).Item("op_stkp"), "######0.00")
                dv1.Rows(rw).Cells(3).Value = Format(ds.Tables(0).Rows(i).Item("op_stks"), "######0.00")
                dv1.Rows(rw).Cells(4).Value = ds.Tables(0).Rows(i).Item("godsl")
                rw += 1
            Next
            txtstksl.Text = rw + 1
            Me.granstk()
        End If
    End Sub

    Private Sub seral_view()
        Dim ds As DataSet = get_dataset("SELECT slno,trans FROM mast_slno WHERE it_cd=" & Val(txtscrl.Text) & " AND io_pos='I'")
        rw = 0
        dvsrl.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dvsrl.Rows.Add()
                dvsrl.Rows(rw).Cells(0).Value = i + 1
                dvsrl.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("slno")
                dvsrl.Rows(rw).Cells(2).Value = "1"
                dvsrl.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("trans")
                rw += 1
            Next
            txtsl.Text = rw + 1
            Me.srlstk()
        End If
    End Sub

    Private Sub unit_view()

        Dim ds1 As DataSet = get_dataset("SELECT * FROM untlnk WHERE it_cd=" & Val(txtscrl.Text) & " ORDER BY unt_pos")
        If ds1.Tables(0).Rows.Count <> 0 Then
            txtmulti1.Text = 1
            For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                If ds1.Tables(0).Rows(i).Item("unt_pos") = 2 Then
                    cmbunt2.Text = ds1.Tables(0).Rows(i).Item("unt_nm")
                    txtuntcd2.Text = ds1.Tables(0).Rows(i).Item("unt_cd")
                    txtmulti1.Text = Val(ds1.Tables(0).Rows(i).Item("mul_rt"))
                ElseIf ds1.Tables(0).Rows(i).Item("unt_pos") = 3 Then
                    cmbunt3.Text = ds1.Tables(0).Rows(i).Item("unt_nm")
                    txtuntcd3.Text = ds1.Tables(0).Rows(i).Item("unt_cd")
                    txtmulti2.Text = Val(ds1.Tables(0).Rows(i).Item("mul_rt")) / Val(txtmulti1.Text)
                ElseIf ds1.Tables(0).Rows(i).Item("unt_pos") = 4 Then
                    cmbunt4.Text = ds1.Tables(0).Rows(i).Item("unt_nm")
                    txtuntcd4.Text = ds1.Tables(0).Rows(i).Item("unt_cd")
                    txtmulti3.Text = Val(ds1.Tables(0).Rows(i).Item("mul_rt")) / Val(txtmulti2.Text * txtmulti1.Text)
                Else
                    cmbunit1.Text = ds1.Tables(0).Rows(i).Item("unt_nm")
                    txtuntcd1.Text = ds1.Tables(0).Rows(i).Item("unt_cd")
                End If
            Next
        End If
    End Sub

    Private Sub last_regd()
        lv.GridLines = True
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT TOP(9) it_name  FROM item where rec_lock='N' Order By it_cd DESC")
        lv.Items.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                With lv
                    .Items.Add(dsedit.Tables(0).Rows(i).Item("it_name"))
                    With .Items(.Items.Count - 1).SubItems
                        .Add(dsedit.Tables(0).Rows(i).Item("it_name"))
                    End With
                End With
            Next
        End If
        Close1()
    End Sub
#End Region

    Private Sub lnkadd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkadd.LinkClicked
        pict1.Image = Nothing
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Set filter options and filter index.
            OpenFileDialog1.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg"
            OpenFileDialog1.FilterIndex = 1
            pict1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
            txtphoto.Text = "Y"
        End If
    End Sub

    Private Sub lnknext_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnknext.LinkClicked
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub lnkclr_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkclr.LinkClicked
        pict1.BackgroundImage = Nothing
        txtphoto.Text = "N"
    End Sub

    Private Sub pict1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pict1.DoubleClick
        If txtphoto.Text = "Y" Then
            Dim stfpath As String
            If Trim(txtsrtcode.Text) = "" Then
                stfpath = My.Application.Info.DirectoryPath & "\item.Jpeg"
            Else
                stfpath = My.Application.Info.DirectoryPath & "\" & Trim(txtsrtcode.Text) & ".Jpeg"
            End If
            pict1.Size = New Size(413, 531)
            Dim bmp As New Drawing.Bitmap(pict1.Width, pict1.Height)
            pict1.DrawToBitmap(bmp, pict1.ClientRectangle)
            bmp.Save(stfpath, System.Drawing.Imaging.ImageFormat.Jpeg)
            pict1.Size = New Size(150, 160)
        End If
    End Sub

    Private Sub txtsrtcode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtsrtcode.Validating
        'If Trim(txtitemcode.Text) <> "" Then
        '    Dim ds As DataSet = get_dataset("SELECT reg_no FROM item WHERE reg_no='" & Trim(txtitemcode.Text) & "'")
        '    If ds.Tables(0).Rows.Count <> 0 Then
        '        MessageBox.Show("Sorry The Registration No. Should Not be Duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        txtitemcode.Focus()
        '        e.Cancel = True
        '    Else
        '        e.Cancel = False
        '    End If
        'End If
    End Sub

    Private Sub chkexact_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkexact.CheckedChanged
        Me.search()
    End Sub

    Private Sub chkexact1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkexact1.CheckedChanged
        Me.search()
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click, btndelete.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            If usr_tp = "A" Or usr_tp = "D" Then
                slno = dv.SelectedRows(0).Cells(10).Value
                cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Start1()
                If cnfr = vbYes Then
                    Dim ds As DataSet = get_dataset("SELECT it_cd FROM item WHERE it_cd=" & Val(slno) & "")
                    If ds.Tables(0).Rows.Count <> 0 Then
                        Dim ds1 As DataSet = get_dataset("SELECT it_cd FROM purch2 WHERE it_cd=" & Val(slno) & "")
                        If ds1.Tables(0).Rows.Count <> 0 Then
                            fnd = 1
                        End If
                        If fnd = 0 Then
                            SQLInsert("DELETE FROM item WHERE it_cd =" & Val(slno) & "")
                            Me.god_del(slno)
                            SQLInsert("DELETE FROM batno WHERE it_cd =" & Val(slno) & "")
                            SQLInsert("DELETE FROM mast_slno WHERE it_cd =" & Val(slno) & "")
                            SQLInsert("DELETE FROM prod_slno WHERE it_cd =" & Val(slno) & "")
                            SQLInsert("DELETE FROM untlnk WHERE it_cd =" & Val(slno) & "")
                            MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.dv_disp()
                        Else
                            MessageBox.Show("Sorry You Can't Delete The Product It Has Been Already Used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If
                    Close1()
                End If
            Else
                MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    'Delete data from item
    Private Sub god_del(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT SUM(op_stkp) AS op_stkp,SUM(op_stks) AS op_stks from opgodown WHERE it_cd=" & Val(code) & "")
          If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                'slno = dsdel.Tables(0).Rows(i).Item(0)
                sqty = 0
                dqty = 0
                If Not IsDBNull(dsdel.Tables(0).Rows(i).Item(0)) Then
                    sqty = Val(dsdel.Tables(0).Rows(i).Item(0))
                End If
                If Not IsDBNull(dsdel.Tables(0).Rows(i).Item(1)) Then
                    dqty = Val(dsdel.Tables(0).Rows(i).Item(1))
                End If
                SQLInsert("UPDATE item SET op_stk=op_stk -" & Val(sqty) & ",dop_stk=drec_stk -" & Val(dqty) & " WHERE it_cd=" & Val(code) & "")
                SQLInsert("UPDATE item SET cl_stk=cl_stk -" & Val(sqty) & ",dcl_stk=dcl_stk -" & Val(dqty) & " WHERE it_cd=" & Val(code) & " AND (dcl_stk>0 OR cl_stk>0)")

                SQLInsert("DELETE FROM opgodown WHERE it_cd=" & Val(code) & "")
            Next
        End If
    End Sub

    Private Sub cmenu2del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenu2del.Click
        For Each row As DataGridViewRow In dvbat.SelectedRows
            dvbat.Rows.Remove(row)
        Next
        sl = 1
        For i As Integer = 0 To dvbat.Rows.Count - 1
            dvbat.Rows(i).Cells(0).Value = i + 1
            sl += 1
        Next
        txtbatsl.Text = sl
        Me.batstk()
    End Sub

    Private Sub cmnu1del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1del.Click
        For Each row As DataGridViewRow In dv1.SelectedRows
            dv1.Rows.Remove(row)
        Next
        sl = 1
        For i As Integer = 0 To dv1.Rows.Count - 1
            dv1.Rows(i).Cells(0).Value = i + 1
            sl += 1
        Next
        txtstksl.Text = sl
        Me.granstk()
    End Sub

    Private Sub granstk()
        Dim ds As DataSet = get_dataset("SELECT COUNT(it_cd) as cntno from mast_slno where it_cd=" & Val(txtscrl.Text) & " AND trans='Y' AND io_pos='I'")
        purqty = 0
        If ds.Tables(0).Rows.Count <> 0 Then
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                purqty = ds.Tables(0).Rows(0).Item(0)
            End If
        End If
        gamt = 0
        gamt1 = 0
        For i As Integer = 0 To dv1.Rows.Count - 1
            amt = dv1.Rows(i).Cells(2).Value
            amt1 = dv1.Rows(i).Cells(3).Value
            gamt = gamt + Val(amt)
            gamt1 = gamt1 + Val(amt1)
        Next
        lblsnd.Text = Format(gamt, "#######0")
        lbdmg.Text = Format(gamt1, "#######0")
        lblsrlstk.Text = Val(gamt) + Val(gamt1) + Val(purqty)
        lblbat_sndstk.Text = Val(gamt)
        lblbat_dmgstk.Text = Val(gamt1)
    End Sub

    Private Sub batstk()
        sqty1 = 0
        dqty1 = 0
        For i As Integer = 0 To dvbat.Rows.Count - 1
            sqty = dvbat.Rows(i).Cells(9).Value
            dqty = dvbat.Rows(i).Cells(10).Value
            sqty1 = sqty1 + Val(sqty)
            dqty1 = dqty1 + Val(dqty)
        Next
        lblbat_sndqty.Text = Format(sqty1, "#######0")
        lblbat_dmgqty.Text = Format(dqty1, "#######0")
    End Sub

    Private Sub srlstk()
        Dim ds As DataSet = get_dataset("SELECT cl_stk from item where it_cd=" & Val(txtscrl.Text) & "")
        purqty = 0
        If ds.Tables(0).Rows.Count <> 0 Then
            purqty = ds.Tables(0).Rows(0).Item(0)
        End If
        sqty = 0
        For i As Integer = 0 To dvsrl.Rows.Count - 1
            qty = dvsrl.Rows(i).Cells(2).Value
            sqty = sqty + Val(qty)
        Next
        lblsrlqty.Text = Format(sqty, "#######0")
        lblsrlstk.Text = Val(purqty)
    End Sub

    Private Sub cmenu3del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenu3del.Click
        For Each row As DataGridViewRow In dvsrl.SelectedRows
            dvsrl.Rows.Remove(row)
        Next
        sl = 1
        For i As Integer = 0 To dvsrl.Rows.Count - 1
            dvsrl.Rows(i).Cells(0).Value = i + 1
            sl += 1
        Next
        txtsl.Text = sl
        Me.srlstk()
    End Sub

    Private Sub cmbbatch_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbatch.Validated
        Label20.Visible = True
        'Label26.Visible = True
        'Label21.Visible = True
        'Label13.Visible = True
        'Label11.Visible = True
        txtmulti1.Enabled = True
        'txtmulti2.Visible = True
        'txtmulti3.Visible = True
        cmbunt2.Visible = True
        'cmbunt3.Visible = True
        'cmbunt4.Visible = True
        'TabControl1.TabPages.Remove(TabPage1)
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Remove(TabPage3)
        If cmbbatch.SelectedIndex = 1 Then
            TabControl1.TabPages.Add(TabPage2)
        ElseIf cmbbatch.SelectedIndex = 2 Then
            TabControl1.TabPages.Add(TabPage3)
            Label20.Visible = False
            'Label26.Visible = False
            'Label21.Visible = False
            'Label13.Visible = False
            'Label11.Visible = False
            txtmulti1.Enabled = False
            'txtmulti2.Visible = False
            'txtmulti3.Visible = False
            cmbunt2.Visible = False
            'cmbunt3.Visible = False
            'cmbunt4.Visible = False
            'Else
            '    TabControl1.TabPages.Add(TabPage1)
        End If
    End Sub

    Private Sub dvsrlview_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dvsrlview.DoubleClick, dvbatview.DoubleClick
        sender.Visible = False
    End Sub

    Private Sub txtsrlno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtsrlno.Validating

        If txtsrlno.Text <> "" Then
            Dim ds As DataSet = get_dataset("SELECT slno FROM mast_slno WHERE slno='" & Trim(txtsrlno.Text) & "' ")
            If ds.Tables(0).Rows.Count <> 0 Then
                MessageBox.Show("Sorry The Serial No. Is  Already Present in Your Database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtsrlno.Focus()
                txtsrlno.Text = ""
            End If
        End If

    End Sub

    Private Sub lblsrlqty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblsrlqty.Click

    End Sub

    Private Sub cmenuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuexpert.Click
        Call excel_view(dv)
    End Sub

End Class
