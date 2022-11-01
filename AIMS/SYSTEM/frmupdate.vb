Imports vb = Microsoft.VisualBasic


Public Class frmupdate

    Private Sub frmupdate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmupdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clr()
    End Sub

    Private Sub frmupdate_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        If Me.WindowState = FormWindowState.Maximized Then
            Me.BackColor = Color.LightCyan
        Else
            Me.BackColor = Color.Black

        End If
    End Sub

    Private Sub clr()
        txtpass.Text = ""
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnup.Click
        If Trim(txtpass.Text) <> "" Then
            Dim ds As DataSet = get_dataset("SELECT usr_pwd FROM usr WHERE usr_sl=" & usr_sl & "")
            If ds.Tables(0).Rows.Count <> 0 Then
                pass = ds.Tables(0).Rows(0).Item(0)
                If Trim(txtpass.Text) = pass Then
                    If txttype.Text = "S" Then
                        Me.Stock_update()
                        Me.Batch_update()
                    ElseIf txttype.Text = "B" Then
                        Me.Balance_update()
                    End If
                Else
                    MessageBox.Show("Please Enter A Valid Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtpass.Focus()
                    Exit Sub
                End If
            End If
        Else
            MessageBox.Show("Please Provide A Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtpass.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub Stock_update()
        Start1()
        Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9 As DataSet
        SQLInsert("UPDATE item SET rec_stk=0,iss_stk=0,cl_stk=0,dop_stk=0,drec_stk=0,dcl_stk=0,diss_stk=0 ")
        ds = get_dataset("SELECT it_cd FROM item ORDER  BY it_cd")
        Call pbstart()
        If ds.Tables(0).Rows.Count <> 0 Then
            MDI.pb.Maximum = ds.Tables(0).Rows.Count
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                itcd = ds.Tables(0).Rows(i).Item(0)
                opstk = 0
                recstk = 0
                isstk = 0
                clstk = 0
                'From opgodown
                ds1 = get_dataset("SELECT SUM(op_stkp) AS itqty FROM opgodown WHERE it_cd=" & itcd & "")
                If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                    opstk = opstk + Val(ds1.Tables(0).Rows(0).Item(0))
                End If
                'From Purchase(Purch2)
                ds2 = get_dataset("SELECT SUM((pur_qty * mul_rt) + (free_qty  * mul_rt))  AS itqty FROM purch2 WHERE it_cd=" & itcd & " AND tr_tp='1'")
                If Not IsDBNull(ds2.Tables(0).Rows(0).Item(0)) Then
                    recstk = recstk + Val(ds2.Tables(0).Rows(0).Item(0))
                End If
                ds3 = get_dataset("SELECT SUM((pur_qty * mul_rt) + (free_qty  * mul_rt)) AS itqty FROM purch2 WHERE it_cd=" & itcd & " AND tr_tp='2'")
                If Not IsDBNull(ds3.Tables(0).Rows(0).Item(0)) Then
                    isstk = isstk + (Val(ds3.Tables(0).Rows(0).Item(0)) * (-1))
                End If
                'From Sales
                ds4 = get_dataset("SELECT SUM((sale_qty * mul_rt) + (free_qty  * mul_rt)) AS itqty FROM csale2 WHERE it_cd=" & itcd & " AND tr_tp='1'")
                If Not IsDBNull(ds4.Tables(0).Rows(0).Item(0)) Then
                    isstk = isstk + Val(ds4.Tables(0).Rows(0).Item(0))
                End If
                ds5 = get_dataset("SELECT SUM((sale_qty * mul_rt) + (free_qty  * mul_rt)) AS itqty FROM csale2 WHERE it_cd=" & itcd & " AND tr_tp='2'")
                If Not IsDBNull(ds5.Tables(0).Rows(0).Item(0)) Then
                    recstk = recstk + (Val(ds5.Tables(0).Rows(0).Item(0)) * (-1))
                End If
                'From Purchase Return(Pret2)
                ds6 = get_dataset("SELECT SUM((pret_qty * mul_rt) + (free_qty  * mul_rt)) AS itqty FROM pret2 WHERE it_cd=" & itcd & " AND tr_tp='2'")
                If Not IsDBNull(ds6.Tables(0).Rows(0).Item(0)) Then
                    isstk = isstk + Val(ds6.Tables(0).Rows(0).Item(0))
                End If
                'From Sales Return
                ds7 = get_dataset("SELECT SUM((sret_qty * mul_rt) + (free_qty  * mul_rt)) AS itqty FROM sret2 WHERE it_cd=" & itcd & " AND tr_tp='2'")
                If Not IsDBNull(ds6.Tables(0).Rows(0).Item(0)) Then
                    recstk = recstk + Val(ds6.Tables(0).Rows(0).Item(0))
                End If


                'ds4 = get_dataset("SELECT SUM(pur_qty + free_qty) AS itqty FROM purch2 WHERE it_cd=" & itcd & " AND pur_tp='2'")
                'If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                '    isstk = isstk + Val(ds1.Tables(0).Rows(0).Item(0))
                'End If

                ''From Others In
                'ds5 = get_dataset("SELECT SUM(pur_qty + free_qty) AS itqty FROM purch2 WHERE it_cd=" & itcd & " AND pur_tp='1'")
                'If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                '    recstk = recstk + Val(ds1.Tables(0).Rows(0).Item(0))
                'End If
                ''From Others Out
                'ds6 = get_dataset("SELECT SUM(pur_qty + free_qty) AS itqty FROM purch2 WHERE it_cd=" & itcd & " AND pur_tp='2'")
                'If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                '    isstk = isstk + Val(ds1.Tables(0).Rows(0).Item(0))
                'End If

                'From Issue
                ds7 = get_dataset("SELECT SUM(qty) AS itqty FROM iss2 WHERE it_cd=" & itcd & " AND refund='N'")
                If Not IsDBNull(ds7.Tables(0).Rows(0).Item(0)) Then
                    isstk = isstk + Val(ds7.Tables(0).Rows(0).Item(0))
                End If

                'From Refund
                ds8 = get_dataset("SELECT SUM(qty) AS itqty FROM iss2 WHERE it_cd=" & itcd & " AND refund='Y'")
                If Not IsDBNull(ds8.Tables(0).Rows(0).Item(0)) Then
                    recstk = recstk + Val(ds8.Tables(0).Rows(0).Item(0))
                End If
                clstk = (opstk + recstk) - isstk
                SQLInsert("UPDATE item SET op_stk=" & Val(opstk) & ",rec_stk=" & Val(recstk) & ",iss_stk=" & Val(isstk) & ",cl_stk=" & Val(clstk) & " WHERE it_cd=" & itcd & "")
                If Val(clstk) = 0 Then
                    SQLInsert("UPDATE mast_slno SET io_pos='O' WHERE it_cd=" & itcd & "")
                End If
                ds9 = get_dataset("SELECT it_cd FROM mast_slno WHERE it_cd=" & itcd & "")
                If ds9.Tables(0).Rows.Count <> 0 Then
                    SQLInsert("UPDATE item SET bat_cnf='S' WHERE it_cd=" & itcd & "")
                End If
                Call pbincr()
            Next
            'Delete duplicate Serial No
            SQLInsert("DELETE FROM mast_slno WHERE sl_slno NOT IN (Select MAX(sl_slno) FROM mast_slno GROUP BY slno)")
            



            MessageBox.Show("Stock Update Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call pbclose()
            Me.Close()
        End If



    End Sub

    Private Sub Balance_update()
        Start1()
        Dim ds, ds1, ds2, ds3, ds4, ds7, ds8, ds9, ds10, ds11, ds12, ds13, ds14, ds15 As DataSet
        SQLInsert("UPDATE party SET cr_amt=0,dr_amt=0,cl_amt=0")
        SQLInsert("UPDATE party SET op_bal=op_bal*(-1) WHERE op_bal > 0 AND bal_cd='D'")
        ds = get_dataset("SELECT prt_code,op_bal FROM party ORDER BY prt_code")
        Call pbstart()
        If ds.Tables(0).Rows.Count <> 0 Then
            MDI.pb.Maximum = ds.Tables(0).Rows.Count
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                prtcd = ds.Tables(0).Rows(i).Item(0)
                opbal = ds.Tables(0).Rows(i).Item(1)
                cramt = 0
                dramt = 0
                clamt = 0
                'From Purchase(Purch2)
                ds1 = get_dataset("SELECT SUM(pur_amt) AS amt FROM purch1 WHERE prt_code=" & prtcd & " AND pur_type='2'")
                If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                    cramt = cramt + Val(ds1.Tables(0).Rows(0).Item(0))
                End If
                'From Sales
                ds2 = get_dataset("SELECT SUM(sale_amt) AS amt FROM csale1 WHERE prt_code=" & prtcd & " AND bill_tp<>'1'")
                If Not IsDBNull(ds2.Tables(0).Rows(0).Item(0)) Then
                    dramt = dramt + Val(ds2.Tables(0).Rows(0).Item(0))
                End If
                'From Service
                ds15 = get_dataset("SELECT SUM(srv_amt) AS amt FROM serv1 WHERE prt_code=" & prtcd & " AND bill_tp<>'1'")
                If Not IsDBNull(ds15.Tables(0).Rows(0).Item(0)) Then
                    dramt = dramt + Val(ds15.Tables(0).Rows(0).Item(0))
                End If
                'From Purchase Return(Pret2)
                ds3 = get_dataset("SELECT SUM(pret_amt) AS amt FROM pret1 WHERE prt_code=" & prtcd & " AND pret_type='2'")
                If Not IsDBNull(ds3.Tables(0).Rows(0).Item(0)) Then
                    dramt = dramt + Val(ds3.Tables(0).Rows(0).Item(0))
                End If
                'From Sales Return
                ds4 = get_dataset("SELECT SUM(sret_amt) AS amt FROM sret1 WHERE prt_code=" & prtcd & " AND sret_type='2'")
                If Not IsDBNull(ds4.Tables(0).Rows(0).Item(0)) Then
                    cramt = cramt + Val(ds4.Tables(0).Rows(0).Item(0))
                End If
                ''From Others In
                'ds5 = get_dataset("SELECT SUM(pur_qty + free_qty) AS itqty FROM purch2 WHERE it_cd=" & prtcd & " AND pur_tp='1'")
                'If Not IsDBNull(ds5.Tables(0).Rows(0).Item(0)) Then
                '    cramt = cramt + Val(ds5.Tables(0).Rows(0).Item(0))
                'End If
                ''From Others Out
                'ds6 = get_dataset("SELECT SUM(pur_qty + free_qty) AS itqty FROM purch2 WHERE it_cd=" & prtcd & " AND pur_tp='2'")
                'If Not IsDBNull(ds6.Tables(0).Rows(0).Item(0)) Then
                '    dramt = dramt + Val(ds6.Tables(0).Rows(0).Item(0))
                'End If
                'From Mr
                ds7 = get_dataset("SELECT SUM(amt) AS amt FROM mr WHERE prt_code=" & prtcd & "")
                If Not IsDBNull(ds7.Tables(0).Rows(0).Item(0)) Then
                    cramt = cramt + Val(ds7.Tables(0).Rows(0).Item(0))
                End If
                ds8 = get_dataset("SELECT SUM(amt) AS amt FROM mr WHERE by_code=" & prtcd & "")
                If Not IsDBNull(ds8.Tables(0).Rows(0).Item(0)) Then
                    dramt = dramt + Val(ds8.Tables(0).Rows(0).Item(0))
                End If
                'From Rec Vouc
                ds9 = get_dataset("SELECT SUM(amt) AS amt FROM vouc WHERE prt_code=" & prtcd & "")
                If Not IsDBNull(ds9.Tables(0).Rows(0).Item(0)) Then
                    cramt = cramt + Val(ds9.Tables(0).Rows(0).Item(0))
                End If
                ds10 = get_dataset("SELECT SUM(amt) AS amt FROM vouc WHERE by_code=" & prtcd & "")
                If Not IsDBNull(ds10.Tables(0).Rows(0).Item(0)) Then
                    dramt = dramt + Val(ds10.Tables(0).Rows(0).Item(0))
                End If
                'From Payvouc
                ds11 = get_dataset("SELECT SUM(amt) AS amt FROM voucp WHERE prt_code=" & prtcd & "")
                If Not IsDBNull(ds11.Tables(0).Rows(0).Item(0)) Then
                    dramt = dramt + Val(ds11.Tables(0).Rows(0).Item(0))
                End If
                ds12 = get_dataset("SELECT SUM(amt) AS amt FROM voucp WHERE by_code=" & prtcd & "")
                If Not IsDBNull(ds12.Tables(0).Rows(0).Item(0)) Then
                    cramt = cramt + Val(ds12.Tables(0).Rows(0).Item(0))
                End If
                'From Journal
                ds13 = get_dataset("SELECT SUM(amt) AS amt FROM jrn2 WHERE prt_code=" & prtcd & " AND jr_type='D'")
                If Not IsDBNull(ds13.Tables(0).Rows(0).Item(0)) Then
                    dramt = dramt + Val(ds13.Tables(0).Rows(0).Item(0))
                End If
                ds14 = get_dataset("SELECT SUM(amt) AS amt FROM jrn2 WHERE prt_code=" & prtcd & " AND jr_type='C'")
                If Not IsDBNull(ds14.Tables(0).Rows(0).Item(0)) Then
                    cramt = cramt + Val(ds14.Tables(0).Rows(0).Item(0))
                End If
                clamt = (opbal + cramt) - dramt
                SQLInsert("UPDATE party SET cr_amt=" & Val(cramt) & ",dr_amt=" & Val(dramt) & ",cl_amt=" & Val(clamt) & " WHERE prt_code=" & prtcd & "")
                Call pbincr()
            Next
            MessageBox.Show("Balance Update Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call pbclose()
            Me.Close()
        End If
    End Sub

    Private Sub Batch_update()
        Start1()
        Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
        SQLInsert("UPDATE batno SET rec_stk=0,iss_stk=0,cl_stk=0,dop_stk=0,drec_stk=0,dcl_stk=0,diss_stk=0 ")
        ds = get_dataset("SELECT bat_cd,op_stk FROM batno ORDER BY it_cd")
        Call pbstart()
        If ds.Tables(0).Rows.Count <> 0 Then
            MDI.pb.Maximum = ds.Tables(0).Rows.Count
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                btcd = ds.Tables(0).Rows(i).Item(0)
                opstk = ds.Tables(0).Rows(i).Item(1)
                recstk = 0
                isstk = 0
                clstk = 0
                'From opgodown
                'ds1 = get_dataset("SELECT SUM(op_stkp) AS itqty FROM opgodown WHERE bat_cd=" & btcd & "")
                'If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                '    opstk = opstk + Val(ds1.Tables(0).Rows(0).Item(0))
                'End If
                'From Purchase(Purch2)
                ds2 = get_dataset("SELECT SUM((pur_qty * mul_rt) + (free_qty  * mul_rt))  AS itqty FROM purch2 WHERE bat_cd=" & btcd & " AND tr_tp='1'")
                If Not IsDBNull(ds2.Tables(0).Rows(0).Item(0)) Then
                    recstk = recstk + Val(ds2.Tables(0).Rows(0).Item(0))
                End If
                ds3 = get_dataset("SELECT SUM((pur_qty * mul_rt) + (free_qty  * mul_rt)) AS itqty FROM purch2 WHERE bat_cd=" & btcd & " AND tr_tp='2'")
                If Not IsDBNull(ds3.Tables(0).Rows(0).Item(0)) Then
                    isstk = isstk + (Val(ds3.Tables(0).Rows(0).Item(0)) * (-1))
                End If
                'From Sales
                ds4 = get_dataset("SELECT SUM((sale_qty * mul_rt) + (free_qty  * mul_rt)) AS itqty FROM csale2 WHERE bat_cd=" & btcd & " AND tr_tp='1'")
                If Not IsDBNull(ds4.Tables(0).Rows(0).Item(0)) Then
                    isstk = isstk + Val(ds4.Tables(0).Rows(0).Item(0))
                End If
                ds5 = get_dataset("SELECT SUM((sale_qty * mul_rt) + (free_qty  * mul_rt)) AS itqty FROM csale2 WHERE bat_cd=" & btcd & " AND tr_tp='2'")
                If Not IsDBNull(ds5.Tables(0).Rows(0).Item(0)) Then
                    recstk = recstk + (Val(ds5.Tables(0).Rows(0).Item(0)) * (-1))
                End If
                'From Purchase Return(Pret2)
                ds6 = get_dataset("SELECT SUM((pret_qty * mul_rt) + (free_qty  * mul_rt)) AS itqty FROM pret2 WHERE bat_cd=" & btcd & " AND tr_tp='2'")
                If Not IsDBNull(ds6.Tables(0).Rows(0).Item(0)) Then
                    isstk = isstk + Val(ds6.Tables(0).Rows(0).Item(0))
                End If
                'From Sales Return
                ds7 = get_dataset("SELECT SUM((sret_qty * mul_rt) + (free_qty  * mul_rt)) AS itqty FROM sret2 WHERE bat_cd=" & btcd & " AND tr_tp='2'")
                If Not IsDBNull(ds6.Tables(0).Rows(0).Item(0)) Then
                    recstk = recstk + Val(ds6.Tables(0).Rows(0).Item(0))
                End If


                'ds4 = get_dataset("SELECT SUM(pur_qty + free_qty) AS itqty FROM purch2 WHERE bat_cd=" & btcd & " AND pur_tp='2'")
                'If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                '    isstk = isstk + Val(ds1.Tables(0).Rows(0).Item(0))
                'End If

                ''From Others In
                'ds5 = get_dataset("SELECT SUM(pur_qty + free_qty) AS itqty FROM purch2 WHERE bat_cd=" & btcd & " AND pur_tp='1'")
                'If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                '    recstk = recstk + Val(ds1.Tables(0).Rows(0).Item(0))
                'End If
                ''From Others Out
                'ds6 = get_dataset("SELECT SUM(pur_qty + free_qty) AS itqty FROM purch2 WHERE bat_cd=" & btcd & " AND pur_tp='2'")
                'If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                '    isstk = isstk + Val(ds1.Tables(0).Rows(0).Item(0))
                'End If

                ''From Issue
                'ds7 = get_dataset("SELECT SUM(pur_qty + free_qty) AS itqty FROM purch2 WHERE bat_cd=" & btcd & " AND pur_tp='2'")
                'If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                '    isstk = isstk + Val(ds1.Tables(0).Rows(0).Item(0))
                'End If

                ''From Refund
                'ds8 = get_dataset("SELECT SUM(pur_qty + free_qty) AS itqty FROM purch2 WHERE bat_cd=" & btcd & " AND pur_tp='2'")
                'If Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                '    isstk = isstk + Val(ds1.Tables(0).Rows(0).Item(0))
                'End If
                clstk = (opstk + recstk) - isstk
                SQLInsert("UPDATE batno SET op_stk=" & Val(opstk) & ",rec_stk=" & Val(recstk) & ",iss_stk=" & Val(isstk) & ",cl_stk=" & Val(clstk) & " WHERE bat_cd=" & btcd & "")
                Call pbincr()
            Next
            MessageBox.Show("Batch Update Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
        Call pbclose()


    End Sub

    Private Sub btnup_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnup.MouseEnter, btnexit.MouseEnter
        sender.forecolor = Color.Violet
    End Sub

    Private Sub btnup_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnup.MouseLeave, btnexit.MouseLeave
        sender.forecolor = Color.Red
    End Sub

    Private Sub txtpass_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.Leave
        sender.forecolor = Color.Black
        sender.backcolor = Color.White
    End Sub

    Private Sub txtpass_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.Enter
        sender.forecolor = Color.Blue
        sender.backcolor = Color.LavenderBlush
    End Sub

    Private Sub txtpass_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpass.KeyPress
        key(btnup, e)
        SPKey(e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Start1()
        ds = get_dataset("SELECT it_cd,cl_stk,dcl_stk FROM item ORDER BY it_cd")
        Call pbstart()
        If ds.Tables(0).Rows.Count <> 0 Then
            MDI.pb.Maximum = ds.Tables(0).Rows.Count
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
                Call pbincr()
            Next
            MessageBox.Show("Stock Update Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call pbclose()
            Me.Close()
        End If
    End Sub
End Class