Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module saleprint
    Dim blno As Integer
    Dim ds2, ds1 As DataSet

    Public Sub sale_print(ByVal slno As Integer)
        blno = slno
        Call datastore()
        Select Case printbill
            Case Is = 1
                Call Salebill1()  ' Windows Print Sale Bill Default Half Page
            Case Is = 2
                Call Salebill2()  ' Windows Print  Sale Bill Default Full Page
            Case Is = 3
                Call Salebill3()  ' Windows Print  Sale Bill Default Half Page & Full Page When Item No More Then 10
            Case Is = 4
                Call Salebill4()  ' Windows Print  Sale Bill Full Page for S.K Engineering
            Case Is = 5
                Call Salebill5()  ' Windows Print  Sale Bill Half Page With Logo Print
            Case Is = 6
                Call Salebill6()  ' Windows Print  Sale Bill Full Page for GST Double Page
            Case Else
                Call Salebill1()
        End Select
        For i As Integer = 0 To copybill
            Call print_repo()
        Next
    End Sub

    Private Sub datastore()
        SQLInsert("DELETE FROM print_salebill WHERE usr_sl=" & usr_sl & "")
        ds1 = get_dataset("SELECT staf.short_nm,drvmst.drv_snm,drvmst.mob_no, party.lst_no,party.cl_amt, csale1.* FROM csale1 LEFT OUTER JOIN drvmst ON csale1.drv_cd = drvmst.drv_cd LEFT OUTER JOIN party ON csale1.prt_code = party.prt_code LEFT OUTER JOIN staf ON csale1.staf_sl = staf.staf_sl WHERE (csale1.bill_no = " & Val(blno) & ")")
        If ds1.Tables(0).Rows.Count <> 0 Then

            bill_tp = "Cash"
            invtp = "Retail Invoice"
            inv_no = ds1.Tables(0).Rows(0).Item("rin_bno")
            If ds1.Tables(0).Rows(0).Item("bill_tp") = "2" Then
                bill_tp = "Credit"
            End If
            If ds1.Tables(0).Rows(0).Item("inv_tp") = "T" Then
                invtp = "Tax Invoice"
                inv_no = ds1.Tables(0).Rows(0).Item("tin_bno")
            End If
            prtbal = ""
            If ds1.Tables(0).Rows(0).Item("prt_code") <> 0 Then
                clamt = Val(ds1.Tables(0).Rows(0).Item("cl_amt"))
                If clamt < 0 Then
                    prtbal = "Cur.Bal. : " & Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
                Else
                    prtbal = "Cur.Bal. : " & Format(clamt, "#######0.00") & " " & "Cr."
                End If
            End If
            inv_tp = invtp & "( " & bill_tp & " )"

            bill_no = blno
            bill_dt = ds1.Tables(0).Rows(0).Item("bill_dt")
            ref_dt = ds1.Tables(0).Rows(0).Item("pay_dt")
            ch_no = ds1.Tables(0).Rows(0).Item("ch_no")
            ch_dt = ds1.Tables(0).Rows(0).Item("ch_dt")
            order_no = ds1.Tables(0).Rows(0).Item("order_no")
            order_dt = ds1.Tables(0).Rows(0).Item("order_dt")
            ref_no = ds1.Tables(0).Rows(0).Item("ref_no")
            bl_name = ds1.Tables(0).Rows(0).Item("bl_name")
            add1 = ds1.Tables(0).Rows(0).Item("add1")
            mobno = ds1.Tables(0).Rows(0).Item("mobno")
            regd_no = ds1.Tables(0).Rows(0).Item("lst_no")
            sold_by = ds1.Tables(0).Rows(0).Item("short_nm")
            tot_tto = ds1.Tables(0).Rows(0).Item("tot_tto")
            tot_vat = ds1.Tables(0).Rows(0).Item("tot_vat")
            sale_amt = Val(ds1.Tables(0).Rows(0).Item("sale_amt"))
            dis_amt = ds1.Tables(0).Rows(0).Item("dis_amt")
            chr_amt = ds1.Tables(0).Rows(0).Item("chr_amt")
            dv_tot = ds1.Tables(0).Rows(0).Item("dv_tot")
            adj_amt = ds1.Tables(0).Rows(0).Item("adj_amt")
            cgsttot = ds1.Tables(0).Rows(0).Item("cgsttot")
            sgsttot = ds1.Tables(0).Rows(0).Item("sgsttot")
            igsttot = ds1.Tables(0).Rows(0).Item("igsttot")
            nb = prtbal & " " & ds1.Tables(0).Rows(0).Item("nb")
            'If Val(order_no) <> 0 Then
            '    nb = nb & " Ord No: " & order_no & ",Dt :" & Format(order_dt, "dd/MM/yy") & " ."
            'End If
            If conb <> "" Then
                nb = nb & conb
            End If
            splnb = ds1.Tables(0).Rows(0).Item("splnb")
            way_bno = ds1.Tables(0).Rows(0).Item("way_bno")
            drv_nm = ds1.Tables(0).Rows(0).Item("drv_snm")
            drv_mob = ds1.Tables(0).Rows(0).Item("mob_no")
            inwords = RupeesToWord(sale_amt)
            ds2 = get_dataset("SELECT batno.bat_no, item.it_name,item.hsn_code, taxper.txname, manf.manf_snm, csale2.* FROM manf RIGHT OUTER JOIN item ON manf.manf_cd = item.manf_cd RIGHT OUTER JOIN csale2 LEFT OUTER JOIN taxper ON csale2.tax_cd = taxper.taxcd LEFT OUTER JOIN batno ON csale2.bat_cd = batno.bat_cd ON item.it_cd = csale2.it_cd WHERE (csale2.bill_no = " & Val(blno) & ")")
            If ds2.Tables(0).Rows.Count <> 0 Then
                For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                    it_cd = ds2.Tables(0).Rows(i).Item("it_cd")
                    it_name = ds2.Tables(0).Rows(i).Item("it_name")
                    hsn_code = ds2.Tables(0).Rows(i).Item("hsn_code")
                    manf_nm = ""
                    If ds2.Tables(0).Rows(i).Item("bat_cd") <> 0 Then
                        manf_nm = "(" & ds2.Tables(0).Rows(i).Item("manf_snm") & ")"
                    End If
                    bat_no = ""
                    If ds2.Tables(0).Rows(i).Item("bat_cd") <> 0 Then
                        bat_no = "(B.No:- " & ds2.Tables(0).Rows(i).Item("bat_no") & ")"
                    End If
                    srl_no = "" 'ds2.Tables(0).Rows(i).Item("srl_no")
                    sale_qty = ds2.Tables(0).Rows(i).Item("sale_qty")
                    free_qty = ds2.Tables(0).Rows(i).Item("free_qty")
                    mrp = ds2.Tables(0).Rows(i).Item("mrp")
                    sale_rt = ds2.Tables(0).Rows(i).Item("sale_rt")
                    it_tot = ds2.Tables(0).Rows(i).Item("it_tot")
                    disc_rt1 = ds2.Tables(0).Rows(i).Item("disc_rt1")
                    disc_rt2 = ds2.Tables(0).Rows(i).Item("disc_rt2")
                    disc_amt1 = ds2.Tables(0).Rows(i).Item("disc_amt1")
                    disc_amt2 = ds2.Tables(0).Rows(i).Item("disc_amt2")
                    oth_amt = ds2.Tables(0).Rows(i).Item("oth_amt")
                    disc_amt = ds2.Tables(0).Rows(i).Item("disc_amt")
                    unt = ds2.Tables(0).Rows(i).Item("unt")
                    mul_rt = ds2.Tables(0).Rows(i).Item("mul_rt")
                    it_amt = ds2.Tables(0).Rows(i).Item("it_amt")
                    tto_amt = ds2.Tables(0).Rows(i).Item("tto_amt")
                    tax_nm = ds2.Tables(0).Rows(i).Item("txname")
                    stax = ds2.Tables(0).Rows(i).Item("stax")
                    'New Section
                    cgstper = ds2.Tables(0).Rows(i).Item("cgstper")
                    cgstamt = ds2.Tables(0).Rows(i).Item("cgstamt")
                    sgstper = ds2.Tables(0).Rows(i).Item("sgstper")
                    sgstamt = ds2.Tables(0).Rows(i).Item("sgstamt")
                    igstper = ds2.Tables(0).Rows(i).Item("igstper")
                    igstamt = ds2.Tables(0).Rows(i).Item("igstamt")
                    mrp_amt = ds2.Tables(0).Rows(i).Item("mrp_amt")
                    Dim dssl As DataSet = get_dataset("SELECT MAX(mast_slno.slno) AS slno FROM sale_slno LEFT OUTER JOIN mast_slno ON sale_slno.sl_slno = mast_slno.sl_slno WHERE (sale_slno.bill_no = " & Val(blno) & ") AND (sale_slno.it_cd = " & Val(it_cd) & ") GROUP BY sale_slno.sl_slno")
                    If dssl.Tables(0).Rows.Count <> 0 Then
                        For sl As Integer = 0 To dssl.Tables(0).Rows.Count - 1
                            If srl_no = "" Then
                                srl_no = dssl.Tables(0).Rows(sl).Item(0)
                            Else
                                srl_no = srl_no & ", " & dssl.Tables(0).Rows(sl).Item(0)
                            End If
                        Next
                        srl_no = "SN.:" & srl_no & ""
                    End If

                    Dim ds As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM print_salebill")
                    mxno = 1
                    If ds.Tables(0).Rows.Count <> 0 Then
                        If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                            mxno = ds.Tables(0).Rows(0).Item(0) + 1
                        End If
                    End If
                    SQLInsert("INSERT INTO print_salebill(slno,bill_no,bill_dt,inv_no,inv_tp,ch_no,ch_dt,order_no,order_dt,ref_no,ref_dt,bl_name,add1," & _
                              "mobno,regd_no,sold_by,it_nm,hsn_code,bat_no,srl_no,sale_qty,free_qty,mrp,sale_rt,it_tot,disc_rt1,disc_rt2,disc_amt1,disc_amt2," & _
                              "oth_amt,disc_amt,unt,mul_rt,it_amt,tto_amt,tax_nm,stax,mrp_amt,tot_tto,tot_vat,sale_amt,dis_amt,chr_amt,dv_tot,adj_amt," & _
                              "nb,splnb,way_bno,inwords,usr_sl,usr_id,manf_nm,drv_nm,drv_mob,cgstper ,cgstamt ,sgstper ,sgstamt ,igstper ,igstamt ,cgsttot ,sgsttot ,igsttot) VALUES (" & mxno & " , " & Val(bill_no) & " , '" & Format(bill_dt, "dd/MMM/yyyy") & "'   , '" & _
                                inv_no & "'  , '" & (inv_tp) & "'  , " & Val(ch_no) & "  , '" & Format(ch_dt, "dd/MMM/yyyy") & "'  , '" & Trim(order_no) & "'  , '" & _
                                Format(order_dt, "dd/MMM/yyyy") & "'  , '" & ref_no & "','" & Format(ref_dt, "dd/MMM/yyyy") & "'  , '" & bl_name & "'  , '" & add1 & "'  , '" & mobno & "'  , '" & regd_no & "'  , '" & _
                                sold_by & "'  , '" & it_name & "' ,'" & hsn_code & "' , '" & bat_no & "'  , '" & srl_no & "'  , " & Val(sale_qty) & "  , " & _
                                Val(free_qty) & "  , " & Val(mrp) & "  , " & Val(sale_rt) & "  , " & Val(it_tot) & "  , " & Val(disc_rt1) & "  , " & _
                                Val(disc_rt2) & "  , " & Val(disc_amt1) & "  , " & Val(disc_amt2) & "  , " & Val(oth_amt) & "  , " & Val(disc_amt) & "  , '" & _
                                unt & "'  , " & Val(mul_rt) & "  , " & Val(it_amt) & "  , " & Val(tto_amt) & "  , '" & tax_nm & "'  , " & Val(stax) & "  , " & _
                                Val(mrp_amt) & "  , " & Val(tot_tto) & "  , " & Val(tot_vat) & "  , " & Val(sale_amt) & "  , " & Val(dis_amt) & "  , " & _
                                Val(chr_amt) & "  , " & Val(dv_tot) & "  , " & Val(adj_amt) & "  , '" & Left(nb, 70) & "'  , '" & Left(splnb, 70) & "'  , '" & way_bno & "'  , '" & _
                                inwords & "'  , " & Val(usr_sl) & "  , '" & usr_nm & "', '" & manf_nm & "','" & drv_nm & "','" & drv_mob & "'," & cgstper & "," & cgstamt & "," & sgstper & "," & sgstamt & "," & igstper & "," & igstamt & "," & cgsttot & "," & sgsttot & "," & igsttot & ")")


                Next
            End If
        End If
    End Sub

    Private Sub Salebill1()
        reportnm = "salebillHF.rpt"
    End Sub

    Private Sub Salebill2()
        reportnm = "salebillFL.rpt"
    End Sub

    Private Sub Salebill3()
        Dim ds As DataSet = get_dataset("SELECT COUNT(slno) as 'Cntno' FROM print_salebill")
        If Val(ds.Tables(0).Rows(0).Item(0)) < 10 Then
            reportnm = "salebillHF.rpt"
        Else
            reportnm = "salebillFL.rpt"
        End If
    End Sub

    Private Sub Salebill4()
        reportnm = "SKE_bill.rpt"
    End Sub

    Private Sub Salebill5()
        reportnm = "salelogoHF.rpt"
    End Sub

    Private Sub Salebill6()
        reportnm = "GST_Invoice.rpt"
    End Sub
End Module
