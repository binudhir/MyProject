Imports vb = Microsoft.VisualBasic
Public Class frmiss
    Dim comd As String = "V"

    Private Sub frmiss_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnfr = MessageBox.Show("Are You Sure To Close The Screen", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If cnfr = vbYes Then
            e.Cancel = False
            MDI.mnuissue.Enabled = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmiss_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmiss_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MDI.mnuissue.Enabled = False
        usrprmsn("mnuissue", cmnuadd, cmnuedit, cmenudel, cmenuview)
        comd = swapprmsn("mnuissue", comd)
        Me.clr()
    End Sub

    Private Sub frmiss_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        txtscroll.Focus()
        txtregd.Text = ""
        txtname.Text = ""
        txtref.Text = ""
        txttrade.Text = ""
        txtsl.Text = "1"
        txtitcd.Text = ""
        txtgodsal.Text = ""
        txtisscd.Text = ""
        txtquantity.Text = "0"
        txtunit.Text = ""
        txtrate.Text = "0.00"
        txtamount.Text = "0.00"
        txtnb.Text = ""
        'lblstock = ""
        lblgrtot.Text = "0.00"
        dtissue.Value = sys_date
        cmbissue.SelectedIndex = 0
        cmbstorege.Text = ""
        cmbproduct.Text = ""
        dv1.Rows.Clear()
        If comd = "E" Then
            cmbissue.Enabled = True
            btnsave.Text = "Save"
            Me.Text = "Product Issue Entry Screen...."
            Dim ds As DataSet = get_dataset("SELECT MAX(iss_no) AS 'MAX' FROM iss1")
            txtscroll.Text = 1
            If ds.Tables(0).Rows.Count <> 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                End If
            End If
        ElseIf comd = "M" Then
            cmbissue.Enabled = False
            btnsave.Text = "Modify"
            Me.Text = "Product Issue Modification Screen . . ."
            txtscroll.Text = ""
        ElseIf comd = "D" Then
            btnsave.Text = "Delete"
            cmbissue.Enabled = False
            Me.Text = "Product Issue Deletion Screen . . ."
            txtscroll.Text = ""
        Else
            btnsave.Text = "View"
            cmbissue.Enabled = False
            Me.Text = "Product Issue View Screen . . ."
            txtscroll.Text = ""
        End If
        Me.clr1()
    End Sub

    Private Sub clr1()
        txtquantity.Text = "0"
        txtunit.Text = ""
        txtrate.Text = "0.00"
        txtamount.Text = "0.00"

    End Sub

    Private Sub cmbissue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbissue.SelectedIndexChanged
        If cmbissue.SelectedIndex = 0 Then
            lblreg.Text = "Regd No.:"
            lbltrade.Text = "Trade :"
        End If
        If cmbissue.SelectedIndex = 1 Then
            lblreg.Text = "Emp No.:"
            lbltrade.Text = "Dept.:"
        End If
    End Sub

#Region "Enter/Leave"
    Private Sub sender_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtscroll.Enter, cmbissue.Enter, txtunit.Enter, txttrade.Enter, txtsl.Enter, txtregd.Enter, txtref.Enter, txtrate.Enter, txtquantity.Enter, txtname.Enter, txtamount.Enter, cmbstorege.Enter, cmbproduct.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush

    End Sub

    Private Sub sender_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtunit.Leave, txttrade.Leave, txtsl.Leave, txtscroll.Leave, txtregd.Leave, txtref.Leave, txtrate.Leave, txtquantity.Leave, txtname.Leave, txtamount.Leave, cmbstorege.Leave, cmbproduct.Leave, cmbissue.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White

    End Sub
    Private Sub sender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.MouseEnter, btnexit.MouseEnter, btnview.MouseEnter, btnprint.MouseEnter, btnref.MouseEnter, btninter.MouseEnter, btnset.MouseEnter, btnsave.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub sender_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.MouseLeave, btnexit.MouseLeave, btnview.MouseLeave, btnprint.MouseLeave, btnref.MouseLeave, btninter.MouseLeave, btnset.MouseLeave, btnsave.MouseLeave
        sender.forecolor = Color.Red
    End Sub
#End Region

#Region "Key Press"

    Private Sub txtscroll_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtscroll.KeyPress
        key(dtissue, e)
        NUM(e)
    End Sub

    Private Sub dtissue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtissue.KeyPress
        key(cmbissue, e)
    End Sub

    Private Sub cmbissue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbissue.KeyPress
        key(txtregd, e)
        NUM(e)
    End Sub

    Private Sub txtregd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtregd.KeyPress
        key(txtref, e)
        SPKey(e)
    End Sub

    Private Sub txtref_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtref.KeyPress
        key(cmbstorege, e)
        SPKey(e)
    End Sub

    Private Sub cmbstorege_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbstorege.KeyPress
        key(cmbproduct, e)
        SPKey(e)
    End Sub

    Private Sub cmbproduct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbproduct.KeyPress
        If Trim(cmbproduct.Text) <> "" Then
            key(txtquantity, e)
        Else
            key(txtnb, e)
        End If
        SPKey(e)
    End Sub

    Private Sub txtquantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtquantity.KeyPress
        key(btnnxt, e)
        NUM1(e)
    End Sub

    Private Sub txtnb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnb.KeyPress
        key(btnsave, e)
        SPKey(e)
    End Sub
#End Region

#Region "GotFocus/LostFocus"

    Private Sub txtquantity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquantity.GotFocus
        If Val(txtquantity.Text) = 0 Then
            txtquantity.Text = ""
        End If
    End Sub

    Private Sub txtrate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.LostFocus
        txtrate.Text = Format(Val(txtrate.Text), "#########0.00")
    End Sub

    Private Sub txtamount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamount.LostFocus
        txtamount.Text = Format(Val(txtamount.Text), "########0.00")
    End Sub

    Private Sub cmbstorege_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstorege.GotFocus
        cmbstorege.Height = 100
        txtgodsal.Text = 0
        populate(cmbstorege, "SELECT godnm FROM godown WHERE rec_lock='N' ORDER BY godnm")
    End Sub

    Private Sub cmbstorege_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstorege.LostFocus
        cmbstorege.Height = 21
    End Sub

    Private Sub cmbproduct_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.GotFocus
        cmbproduct.Height = 100
        txtitcd.Text = 0
        Me.clr1()
        populate(cmbproduct, "SELECT it_name FROM item WHERE (rec_lock = 'N') AND godsl=" & Val(txtgodsal.Text) & " ORDER BY it_name")
    End Sub

    Private Sub cmbproduct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.LostFocus
        cmbproduct.Height = 21
    End Sub
#End Region

#Region "Validating/Validated"

    Private Sub txtscroll_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtscroll.Validating
        If comd <> "E" Then
            vdating(txtregd, "SELECT iss_no FROM iss1 WHERE (iss_no =" & Val(txtscroll.Text) & ")", "Please Enter A Valid Issue No.")
        End If

    End Sub

    Private Sub txtregd_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtregd.Validating
        If cmbissue.SelectedIndex = 0 Then
            vdating(txtregd, "SELECT reg_no FROM stud WHERE (reg_no ='" & Trim(txtregd.Text) & "') AND rec_lock='N'", "Please Enter A Valid Regd. No.")
        Else
            vdating(txtregd, "SELECT staf_id FROM staf WHERE (staf_id = '" & Trim(txtregd.Text) & "')", "Please Enter A Valid Employee No.")
        End If
    End Sub

    Private Sub txtregd_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtregd.Validated
        If cmbissue.SelectedIndex = 0 Then
            Dim ds As DataSet = get_dataset("SELECT stud_hstry.stud_sl, stud.stud_nm, trad.trad_nm FROM stud_hstry INNER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl WHERE stud.reg_no='" & Trim(txtregd.Text) & "' AND (stud_hstry.active = 'Y')")
            If ds.Tables(0).Rows.Count <> 0 Then
                txtname.Text = Trim(ds.Tables(0).Rows(0).Item("stud_nm"))
                txttrade.Text = Trim(ds.Tables(0).Rows(0).Item("trad_nm"))
                txtcd.Text = Format(ds.Tables(0).Rows(0).Item("stud_sl"))
            End If
        Else
            Dim ds As DataSet = get_dataset("SELECT staf.staf_sl, staf.staf_nm,dept.dept_nm FROM staf LEFT OUTER JOIN dept ON staf.dept_cd = dept.dept_cd WHERE (staf.staf_id = '" & Trim(txtregd.Text) & "' AND staf.rec_lock='N')")
            If ds.Tables(0).Rows.Count <> 0 Then
                txtname.Text = Trim(ds.Tables(0).Rows(0).Item("staf_nm"))
                txttrade.Text = Trim(ds.Tables(0).Rows(0).Item("dept_nm"))
                txtcd.Text = Format(ds.Tables(0).Rows(0).Item("staf_sl"))
            End If
        End If
    End Sub

    Private Sub cmbstorege_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstorege.Validating
        vdating(cmbstorege, "SELECT godnm FROM godown WHERE (godnm = '" & Trim(cmbstorege.Text) & "')", "Please Enter A Valid Storage Name.")
    End Sub

    Private Sub cmbstorege_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstorege.Validated
        vdated(txtgodsal, "SELECT godsl FROM godown WHERE (godnm = '" & Trim(cmbstorege.Text) & "')")
    End Sub

    Private Sub cmbproduct_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbproduct.Validated

        Dim ds As DataSet = get_dataset("SELECT cl_stk, it_cd, unt1, mrp FROM item WHERE it_name = '" & Trim(cmbproduct.Text) & "'")
        If ds.Tables(0).Rows.Count <> 0 Then
            txtitcd.Text = ds.Tables(0).Rows(0).Item("it_cd")
            txtunit.Text = Trim(ds.Tables(0).Rows(0).Item("unt1"))
            txtrate.Text = Format(ds.Tables(0).Rows(0).Item("mrp"), "#######0.00")
            lblstock.Text = ds.Tables(0).Rows(0).Item("cl_stk")
        End If
    End Sub

    Private Sub txtref_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtref.Validated
        If txtref.Text = "" Then
            txtref.Text = "X"
        End If
    End Sub

    Private Sub cmbproduct_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbproduct.Validating
        vdating(cmbproduct, "SELECT it_name FROM item WHERE (it_name = '" & Trim(cmbproduct.Text) & "') AND godsl=" & Val(txtgodsal.Text) & "", "Please Select a Valid Product Name.")
    End Sub

#End Region

#Region "Botton"

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click, cmnurefresh.Click
        Me.dv_disp()
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnref.Click
        Me.clr()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Val(txtscroll.Text) = 0 Then
            MessageBox.Show("Sorry The Order No. Should Not Be Zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtscroll.Focus()
            Exit Sub
        End If
        If cmbissue.SelectedIndex = 0 Then
            If Trim(txtregd.Text) = "" Then
                MessageBox.Show("Sorry The Regd. No. Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtregd.Focus()
                Exit Sub
            End If
        Else
            If Trim(txtregd.Text) = "" Then
                MessageBox.Show("Sorry The Employee No. Should Not Be Blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtregd.Focus()
                Exit Sub
            End If
        End If

        If Trim(cmbstorege.Text) = "" Or Val(txtgodsal.Text) = 0 Then
            MessageBox.Show("Please Enter A Valid Storage Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbstorege.Focus()
            Exit Sub
        End If
        If dv1.Rows.Count = 0 Then
            MessageBox.Show("Please Issue Atleast One Item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If
        Me.iss_save()
    End Sub

    Private Sub btnnxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnxt.Click
        If cmbproduct.Text = "" Then
            MessageBox.Show("Please Enter A Valid Product Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If

        If Trim(txtitcd.Text) = "" Then
            MessageBox.Show("Please Provide A Product Name Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbproduct.Focus()
            Exit Sub
        End If

        If Trim(txtquantity.Text) = "" Or Trim(txtquantity.Text) = 0 Then
            MessageBox.Show("Please Enter A Quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtquantity.Focus()
            Exit Sub
        End If
        sl1 = Val(txtsl.Text)
        dv1.Rows.Add()
        dv1.Rows(sl1 - 1).Cells(0).Value = sl1
        dv1.Rows(sl1 - 1).Cells(1).Value = cmbproduct.Text
        dv1.Rows(sl1 - 1).Cells(2).Value = txtquantity.Text
        dv1.Rows(sl1 - 1).Cells(3).Value = txtunit.Text
        dv1.Rows(sl1 - 1).Cells(4).Value = txtrate.Text
        dv1.Rows(sl1 - 1).Cells(5).Value = txtamount.Text
        dv1.Rows(sl1 - 1).Cells(6).Value = txtitcd.Text
        sl1 += 1
        txtsl.Text = sl1
        cmbproduct.Focus()
        Me.grandamt(dv1)
        Me.clr1()
    End Sub
#End Region

    Private Sub txtquantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquantity.TextChanged
        txtamount.Text = Format((Val(txtquantity.Text) * Val(txtrate.Text)), "#######0.00")
    End Sub

    Private Sub grandamt(ByVal dgv As DataGridView)
        gtamt = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            amt = dgv.Rows(i).Cells(5).Value
            gtamt = gtamt + Val(amt)
        Next
        lblgrtot.Text = Format(gtamt, "#######0.00")
    End Sub

    Private Sub iss_save()
        staf_sl = 0
        stud_sl = 0
        If cmbissue.SelectedIndex = 0 Then
            stud_sl = Val(txtcd.Text)
        Else
            staf_sl = Val(txtcd.Text)
        End If
        Start1()
        If comd = "E" Then
            cnfr = MessageBox.Show("Are You Sure To Save The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT MAX(iss_no) AS 'MAX' FROM iss1")
                txtscroll.Text = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        txtscroll.Text = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO iss1 (iss_no,iss_dt,iss_to,ref_no,stud_sl,staf_sl,godsl,tot_val,nb,usr_ent,ent_date,usr_mod,mod_date,rec_lock,used_by) VALUES (" & Val(txtscroll.Text) & _
                      ",'" & Format(dtissue.Value, "dd/MMM/yyyy") & "','" & _
                      vb.Left(cmbissue.Text, 1) & "','" & Trim(txtref.Text) & "'," & Val(stud_sl) & "," & Val(staf_sl) & "," & _
                      Val(txtgodsal.Text) & "," & Val(lblgrtot.Text) & ",'" & Trim(txtnb.Text) & "'," & _
                      Val(usr_sl) & ",'" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "'," & Val(usr_sl) & ",'" & _
                      Format(Now, "dd/MMM/yyyy HH:mm:ss") & "','N','N')")

                Me.dv_save()
                MessageBox.Show("Record Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'cnfr = MessageBox.Show("Are You Sure The Printer is Ready To Print The Bill.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If cnfr = vbYes Then
                '    Call colrec_print(Val(txtordno.Text))
                'End If
                Me.clr()
            End If
        ElseIf comd = "M" Then
            'If usr_tp = "O" Then
            '    MessageBox.Show("You Are Not Authorised to Modify The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            cnfr = MessageBox.Show("Are You Sure To Modify The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If cnfr = vbYes Then
                Dim ds As DataSet = get_dataset("SELECT iss_no FROM iss1 WHERE iss_no=" & Val(txtscroll.Text) & "")
                If ds.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE iss1 SET iss_dt='" & Format(dtissue.Value, "dd/MMM/yyyy") & "',iss_to='" & _
                         vb.Left(cmbissue.Text, 1) & "',ref_no='" & Trim(txtref.Text) & "',stud_sl=" & _
                         Val(stud_sl) & ",staf_sl=" & Val(staf_sl) & ",godsl=" & Val(txtgodsal.Text) & ",tot_val=" & Val(lblgrtot.Text) & _
                         ", nb='" & Trim(txtnb.Text) & "',usr_mod=" & _
                         Val(usr_sl) & ",mod_date='" & Format(Now, "dd/MMM/yyyy HH:mm:ss") & "' WHERE iss_no =" & Val(txtscroll.Text) & "")
                    Me.dv_save()
                    MessageBox.Show("Record Modified Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.clr()
                End If
            ElseIf comd = "D" Then
                'If usr_tp <> "A" Or usr_tp <> "D" Then
                '    MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Exit Sub
                'End If
                cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Start1()
                If cnfr = vbYes Then
                    Call del1(txtscroll.Text)
                    Call del2(txtscroll.Text)
                    txtscroll.Focus()
                End If
                End If

        End If
        Close1()
    End Sub

    Private Sub dv_save()
        If dv1.RowCount <> 0 Then
            If comd = "M" Then
                Call del2(txtscroll.Text)
            End If
            staf_sl = 0
            stud_sl = 0
            If cmbissue.SelectedIndex = 0 Then
                stud_sl = Val(txtcd.Text)
            Else
                staf_sl = Val(txtcd.Text)
            End If
            For i As Integer = 0 To dv1.RowCount - 1
                qty = Val(dv1.Rows(i).Cells(2).Value)
                unt = dv1.Rows(i).Cells(3).Value
                mrp = Val(dv1.Rows(i).Cells(4).Value)
                amt = Val(dv1.Rows(i).Cells(5).Value)
                itcd = Val(dv1.Rows(i).Cells(6).Value)
                Dim ds1 As DataSet = get_dataset("SELECT max(iss_sl) as 'Max' FROM iss2")
                mxno = 1
                If ds1.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds1.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO iss2(iss_sl,iss_no,iss_dt,iss_to,stud_sl,staf_sl,it_cd,qty,unt,rate,amt,refund,ret_dt) VALUES (" & _
                          Val(mxno) & "," & Val(txtscroll.Text) & ",'" & Format(dtissue.Value, "dd/MMM/yyyy") & "','" & _
                          vb.Left(cmbissue.Text, 1) & "'," & stud_sl & "," & staf_sl & "," & itcd & "," & qty & ",'" & unt & "'," & mrp & _
                          "," & amt & ",'N','" & Format(dtissue.Value, "dd/MMM/yyyy") & "')")
            Next
        End If
    End Sub

    Private Sub dv_disp()
        Dim dsedit As DataSet = get_dataset("SELECT iss1.*, godown.godnm, stud_hstry.reg_no, stud.stud_nm, trad.trad_nm, stud_hstry.active, staf.staf_nm, staf.staf_id, dept.dept_nm FROM staf LEFT OUTER JOIN dept ON staf.dept_cd = dept.dept_cd RIGHT OUTER JOIN iss1 ON staf.staf_sl = iss1.staf_sl LEFT OUTER JOIN trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl ON iss1.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN godown ON iss1.godsl = godown.godsl ORDER BY iss1.iss_no")
        dv.Rows.Clear()
        If dsedit.Tables(0).Rows.Count <> 0 Then
            Dim rw As Integer = 0
            For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                dv.Rows.Add()
                dv.Rows(rw).Cells(0).Value = dsedit.Tables(0).Rows(i).Item("iss_no")
                dv.Rows(rw).Cells(1).Value = Format(dsedit.Tables(0).Rows(i).Item("iss_dt"), "dd/MM/yyyy")
                If Val(dsedit.Tables(0).Rows(i).Item("iss_to")) = 1 Then
                    dv.Rows(rw).Cells(2).Value = dsedit.Tables(0).Rows(i).Item("stud_nm") & "(" & dsedit.Tables(0).Rows(i).Item("reg_no") & ")," & dsedit.Tables(0).Rows(i).Item("trad_nm")
                Else
                    dv.Rows(rw).Cells(2).Value = dsedit.Tables(0).Rows(i).Item("staf_nm") & "(" & dsedit.Tables(0).Rows(i).Item("staf_id") & ")," & dsedit.Tables(0).Rows(i).Item("dept_nm")
                End If
                dv.Rows(rw).Cells(3).Value = dsedit.Tables(0).Rows(i).Item("godnm")
                dv.Rows(rw).Cells(4).Value = Format(dsedit.Tables(0).Rows(i).Item("tot_val"), "########0.00")
                rw = rw + 1
            Next
        End If
        dv.Visible = True
        dv.Dock = DockStyle.Fill
    End Sub

    Private Sub dv_edit(ByVal slno As Integer)
        Start1()
        Dim dsedit As DataSet = get_dataset("SELECT iss1.*, godown.godnm, stud_hstry.reg_no, stud.stud_nm, trad.trad_nm, stud_hstry.active, staf.staf_nm, staf.staf_id, dept.dept_nm FROM staf LEFT OUTER JOIN dept ON staf.dept_cd = dept.dept_cd RIGHT OUTER JOIN iss1 ON staf.staf_sl = iss1.staf_sl LEFT OUTER JOIN trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl ON iss1.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN godown ON iss1.godsl = godown.godsl WHERE (iss1.iss_no = " & Val(slno) & ")")
        If dsedit.Tables(0).Rows.Count <> 0 Then
            txtscroll.Text = slno
            dtissue.Value = dsedit.Tables(0).Rows(0).Item("iss_dt")
            txtref.Text = dsedit.Tables(0).Rows(0).Item("ref_no")
            cmbissue.SelectedIndex = Val(dsedit.Tables(0).Rows(0).Item("iss_to")) - 1
            txtgodsal.Text = dsedit.Tables(0).Rows(0).Item("godsl")
            cmbstorege.Text = dsedit.Tables(0).Rows(0).Item("godnm")
            txtnb.Text = dsedit.Tables(0).Rows(0).Item("nb")
            If cmbissue.SelectedIndex = 0 Then
                txtregd.Text = dsedit.Tables(0).Rows(0).Item("reg_no")
                txtname.Text = dsedit.Tables(0).Rows(0).Item("stud_nm")
                txttrade.Text = dsedit.Tables(0).Rows(0).Item("trad_nm")
                txtcd.Text = dsedit.Tables(0).Rows(0).Item("stud_sl")
            Else
                txtregd.Text = dsedit.Tables(0).Rows(0).Item("staf_id")
                txtname.Text = dsedit.Tables(0).Rows(0).Item("staf_nm")
                txttrade.Text = dsedit.Tables(0).Rows(0).Item("dept_nm")
                txtcd.Text = dsedit.Tables(0).Rows(0).Item("staf_sl")
            End If
            Me.dv_view()
        End If
        Close1()
    End Sub

    Private Sub dv_view()
        Dim ds As DataSet = get_dataset("SELECT iss2.it_cd,iss2.qty, iss2.unt, iss2.rate, iss2.amt, item.it_name, iss2.iss_no FROM iss2 LEFT OUTER JOIN item ON iss2.it_cd = item.it_cd WHERE (iss2.iss_no = '" & Val(txtscroll.Text) & "' AND refund='N')")
        rw = 0
        dv1.Rows.Clear()
        If ds.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dv1.Rows.Add()
                dv1.Rows(rw).Cells(0).Value = i + 1
                dv1.Rows(rw).Cells(1).Value = ds.Tables(0).Rows(i).Item("it_name")
                dv1.Rows(rw).Cells(2).Value = Format(ds.Tables(0).Rows(i).Item("qty"), "######0")
                dv1.Rows(rw).Cells(3).Value = ds.Tables(0).Rows(i).Item("unt")
                dv1.Rows(rw).Cells(4).Value = Format(ds.Tables(0).Rows(i).Item("rate"), "#######0.00")
                dv1.Rows(rw).Cells(5).Value = Format(ds.Tables(0).Rows(i).Item("amt"), "######0.00")
                dv1.Rows(rw).Cells(6).Value = ds.Tables(0).Rows(i).Item("it_cd")
                rw += 1
            Next
            Me.grandamt(dv1)
            txtsl.Text = rw + 1
        Else
            MessageBox.Show("Products Issued To This Person Are Already Returned", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtregd.Focus()
            Me.clr()
        End If

    End Sub

    Private Sub btninter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninter.Click
        'If comd = "E" Then
        '    comd = "M"
        'ElseIf comd = "M" Then
        '    comd = "D"
        'Else
        '    comd = "E"
        'End If
        comd = swapprmsn("mnuissue", comd)
        Me.clr()
    End Sub

    Private Sub cmnuadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuadd.Click
        comd = "E"
        Me.clr()
        dv.Visible = False
    End Sub

    Private Sub cmnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuedit.Click
        If dv.RowCount <> 0 Then
            comd = "M"
            btnsave.Text = "Modify"
            Me.Text = "Product Issue Modification Screen. . . "
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
        End If
    End Sub

    Private Sub cmenuview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenuview.Click
        If dv.RowCount <> 0 Then
            comd = "V"
            btnsave.Text = "View"
            Me.Text = "Product Issue View Screen. . . "
            slno = dv.SelectedRows(0).Cells(0).Value
            Me.dv_edit(slno)
            dv.Visible = False
        End If
    End Sub

    Private Sub cmenudel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenudel.Click
        fnd = 0
        If dv.RowCount <> 0 Then
            'If usr_tp = "A" Or usr_tp = "D" Then
            slno = dv.SelectedRows(0).Cells(0).Value
            cnfr = MessageBox.Show("Are You Sure To Delete The Record.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Start1()
            If cnfr = vbYes Then
                Call del1(slno)
                Call del2(slno)
                MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dv_disp()
            End If
            Close1()
            'Else
            '    MessageBox.Show("You Are Not Authorised to Delete The Record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        End If
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
        txtsl.Text = sl
    End Sub

    Private Sub txtscroll_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtscroll.Validated
        If comd <> "E" Then
            If Val(txtscroll.Text) <> 0 Then
                Dim ds As DataSet = get_dataset("SELECT iss_no FROM iss1 WHERE (iss_no = '" & Trim(txtscroll.Text) & "')")
                If ds.Tables(0).Rows.Count <> 0 Then
                    Me.dv_edit(txtscroll.Text)
                Else
                    MessageBox.Show("Please Select a Valid Scroll No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtscroll.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtscroll_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtscroll.GotFocus
        If comd <> "E" Then
            Me.clr()
        End If
    End Sub

    'Delete data from Table1/Primary Table
    Private Sub del1(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT iss_no FROM iss1 WHERE iss_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            SQLInsert("DELETE FROM iss1 WHERE iss_no=" & Val(code) & "")
        End If
    End Sub

    'Delete data from Table2/Secondary Table
    Private Sub del2(ByVal code As Integer)
        Dim dsdel As DataSet = get_dataset("SELECT iss_sl FROM iss2 WHERE iss_no=" & Val(code) & "")
        If dsdel.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To dsdel.Tables(0).Rows.Count - 1
                posl = dsdel.Tables(0).Rows(i).Item(0)
                SQLInsert("DELETE FROM iss2 WHERE iss_sl=" & Val(posl) & "")
            Next
        End If
    End Sub

    Private Sub mnuexpert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuexpert.Click
        Call excel_view(dv)
    End Sub

    Private Sub cmenusearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmenusearch.Click
        prtnm = InputBox("Enter The Regd. No.", "Search Box...", Nothing)
        If (prtnm Is Nothing OrElse prtnm = "") Then
            'User hit cancel
        Else
            'Dim dssear As DataSet = get_dataset("SELECT collrec1.coll_no AS 'Coll. No.', collrec1.coll_dt AS 'Date', stud_hstry.reg_no AS 'Regd. No.',stud.stud_nm AS 'Stud. Name', sesion1.sesn_nm AS 'Session',trad.trad_nm AS 'Stream', (CASE WHEN collrec1.pay_mod='1' THEN 'Cash' WHEN collrec1.pay_mod='2' THEN 'DD/Cheque' END) AS 'Pay Mode' ,STR(collrec1.tot_amt,10,2) AS 'Amount' FROM stud RIGHT OUTER JOIN stud_hstry ON stud.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd LEFT OUTER JOIN trad ON stud_hstry.trad_cd = trad.trad_cd RIGHT OUTER JOIN collrec1 ON stud_hstry.stud_sl = collrec1.stud_sl WHERE (stud_hstry.active = 'Y') AND (stud_hstry.reg_no LIKE'" & prtnm & "%') ORDER BY stud_hstry.reg_no")
            Dim dsedit As DataSet = get_dataset("SELECT iss1.*, godown.godnm, stud_hstry.reg_no, stud.stud_nm, trad.trad_nm, stud_hstry.active, staf.staf_nm, staf.staf_id, dept.dept_nm FROM staf LEFT OUTER JOIN dept ON staf.dept_cd = dept.dept_cd RIGHT OUTER JOIN iss1 ON staf.staf_sl = iss1.staf_sl LEFT OUTER JOIN trad RIGHT OUTER JOIN stud_hstry ON trad.trad_cd = stud_hstry.trad_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl ON iss1.stud_sl = stud_hstry.stud_sl LEFT OUTER JOIN godown ON iss1.godsl = godown.godsl WHERE (stud_hstry.reg_no LIKE'" & prtnm & "%') ORDER BY iss1.iss_no")
            dv.Rows.Clear()
            If dsedit.Tables(0).Rows.Count <> 0 Then
                Dim rw As Integer = 0
                For i As Integer = 0 To dsedit.Tables(0).Rows.Count - 1
                    dv.Rows.Add()
                    dv.Rows(rw).Cells(0).Value = dsedit.Tables(0).Rows(i).Item("iss_no")
                    dv.Rows(rw).Cells(1).Value = Format(dsedit.Tables(0).Rows(i).Item("iss_dt"), "dd/MM/yyyy")
                    If Val(dsedit.Tables(0).Rows(i).Item("iss_to")) = 1 Then
                        dv.Rows(rw).Cells(2).Value = dsedit.Tables(0).Rows(i).Item("stud_nm") & "(" & dsedit.Tables(0).Rows(i).Item("reg_no") & ")," & dsedit.Tables(0).Rows(i).Item("trad_nm")
                    Else
                        dv.Rows(rw).Cells(2).Value = dsedit.Tables(0).Rows(i).Item("staf_nm") & "(" & dsedit.Tables(0).Rows(i).Item("staf_id") & ")," & dsedit.Tables(0).Rows(i).Item("dept_nm")
                    End If
                    dv.Rows(rw).Cells(3).Value = dsedit.Tables(0).Rows(i).Item("godnm")
                    dv.Rows(rw).Cells(4).Value = Format(dsedit.Tables(0).Rows(i).Item("tot_val"), "########0.00")
                    rw = rw + 1
                Next
            End If
            dv.Visible = True
            dv.Dock = DockStyle.Fill
        End If
    End Sub
   
End Class
