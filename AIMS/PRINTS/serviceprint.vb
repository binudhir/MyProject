Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module serviceprint
    Dim blno As Integer
    Dim ds2, ds1 As DataSet

    Public Sub service_print(ByVal slno As Integer)
        blno = slno
        Call datastore()
        Select Case printsrvbl
            Case Is = 1
                Call servbill1()  ' Windows Print Service Bill Default Half Page
            Case Is = 2
                Call servbill2()  ' Windows Print  Service Bill Default Full Page
            Case Is = 3
                Call servbill3()  ' Windows Print  Service Bill Default Half Page & Full Page When Item No More Then 10
            Case Is = 4
                '        Call servbill4()  ' Windows Print  Service Bill Full Page for S.K Engineering
                '    Case Is = 5
                '        Call servbill5()  ' Windows Print  Service Bill Half Page With Logo Print
            Case Else
                Call Servbill1()
        End Select
        For i As Integer = 0 To copysrvbl
            Call print_repo()
        Next
    End Sub

    Private Sub datastore()
        SQLInsert("DELETE FROM print_servbill WHERE usr_sl=" & usr_sl & "")
        ds1 = get_dataset("SELECT staf.short_nm,drvmst.drv_snm,drvmst.mob_no, party.lst_no,party.cl_amt, serv1.* FROM serv1 LEFT OUTER JOIN drvmst ON serv1.drv_cd = drvmst.drv_cd LEFT OUTER JOIN party ON serv1.prt_code = party.prt_code LEFT OUTER JOIN staf ON serv1.staf_sl = staf.staf_sl WHERE (serv1.srv_no = " & Val(blno) & ")")
        If ds1.Tables(0).Rows.Count <> 0 Then
            bill_tp = "Cash"
            invtp = "Service Invoice"
            inv_no = ds1.Tables(0).Rows(0).Item("srv_pfx") & "-" & ds1.Tables(0).Rows(0).Item("inv_bno")
            If ds1.Tables(0).Rows(0).Item("bill_tp") = "2" Then
                bill_tp = "Credit"
            End If
            'If ds1.Tables(0).Rows(0).Item("inv_tp") = "T" Then
            '    invtp = "Tax Invoice"
            'End If
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
            bill_dt = ds1.Tables(0).Rows(0).Item("srv_dt")
            ref_dt = ds1.Tables(0).Rows(0).Item("pay_dt")
            order_no = ds1.Tables(0).Rows(0).Item("order_no")
            order_dt = ds1.Tables(0).Rows(0).Item("order_dt")
            ref_no = ds1.Tables(0).Rows(0).Item("ref_no")
            bl_name = ds1.Tables(0).Rows(0).Item("bl_name")
            add1 = ds1.Tables(0).Rows(0).Item("add1")
            mobno = ds1.Tables(0).Rows(0).Item("mobno")
            regd_no = ds1.Tables(0).Rows(0).Item("lst_no")
            sold_by = ds1.Tables(0).Rows(0).Item("short_nm")
            tot_tto = 0 'ds1.Tables(0).Rows(0).Item("tot_tto")
            tot_vat = ds1.Tables(0).Rows(0).Item("tot_vat")
            srv_amt = Val(ds1.Tables(0).Rows(0).Item("srv_amt"))
            dis_amt = ds1.Tables(0).Rows(0).Item("dis_amt")
            chr_amt = ds1.Tables(0).Rows(0).Item("chr_amt")
            dv_tot = ds1.Tables(0).Rows(0).Item("dv_tot")
            adj_amt = ds1.Tables(0).Rows(0).Item("adj_amt")
            cgsttot = ds1.Tables(0).Rows(0).Item("cgsttot")
            sgsttot = ds1.Tables(0).Rows(0).Item("sgsttot")
            igsttot = ds1.Tables(0).Rows(0).Item("igsttot")
            nb = prtbal & " " & ds1.Tables(0).Rows(0).Item("nb")
            If order_no <> "" Then
                nb = nb & " Order No: " & order_no & " Date :" & Format(order_dt, "dd/MMM/yyyy") & " ."
            End If
            If conb <> "" Then
                nb = nb & conb
            End If
            splnb = ds1.Tables(0).Rows(0).Item("splnb")
            way_bno = ds1.Tables(0).Rows(0).Item("way_bno")
            drv_nm = ds1.Tables(0).Rows(0).Item("drv_snm")
            drv_mob = ds1.Tables(0).Rows(0).Item("mob_no")
            inwords = RupeesToWord(srv_amt)
            ds2 = get_dataset("SELECT item.it_name, item.hsn_code, taxper.txname, manf.manf_snm, serv2.* FROM manf RIGHT OUTER JOIN item ON manf.manf_cd = item.manf_cd RIGHT OUTER JOIN serv2 LEFT OUTER JOIN taxper ON serv2.tax_cd = taxper.taxcd ON item.it_cd = serv2.it_cd WHERE (serv2.srv_no = " & Val(blno) & ")")
            If ds2.Tables(0).Rows.Count <> 0 Then
                For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                    it_cd = ds2.Tables(0).Rows(i).Item("it_cd")
                    it_name = ds2.Tables(0).Rows(i).Item("it_name")
                    hsn_code = ds2.Tables(0).Rows(i).Item("hsn_code")
                    manf_nm = ""
                    srv_qty = ds2.Tables(0).Rows(i).Item("srv_qty")
                    srv_rt = ds2.Tables(0).Rows(i).Item("srv_rt")
                    it_tot = ds2.Tables(0).Rows(i).Item("it_tot")
                    oth_amt = ds2.Tables(0).Rows(i).Item("chrg_amt")
                    disc_amt = ds2.Tables(0).Rows(i).Item("disc_amt")
                    unt = ds2.Tables(0).Rows(i).Item("unt")
                    mul_rt = ds2.Tables(0).Rows(i).Item("mul_rt")
                    it_amt = ds2.Tables(0).Rows(i).Item("it_amt")
                    tto_amt = 0 ' ds2.Tables(0).Rows(i).Item("tto_amt")
                    tax_nm = ds2.Tables(0).Rows(i).Item("txname")
                    stax = ds2.Tables(0).Rows(i).Item("stax")
                    'New Section
                    cgstper = ds2.Tables(0).Rows(i).Item("cgstper")
                    cgstamt = ds2.Tables(0).Rows(i).Item("cgstamt")
                    sgstper = ds2.Tables(0).Rows(i).Item("sgstper")
                    sgstamt = ds2.Tables(0).Rows(i).Item("sgstamt")
                    igstper = ds2.Tables(0).Rows(i).Item("igstper")
                    igstamt = ds2.Tables(0).Rows(i).Item("igstamt")
                    mrp_amt = 0 'ds2.Tables(0).Rows(i).Item("mrp_amt")

                    Dim ds As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM print_servbill")
                    mxno = 1
                    If ds.Tables(0).Rows.Count <> 0 Then
                        If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                            mxno = ds.Tables(0).Rows(0).Item(0) + 1
                        End If
                    End If
                    SQLInsert("INSERT INTO print_servbill(slno,srv_no,srv_dt,inv_no,inv_tp,order_no,order_dt,ref_no,ref_dt,bl_name,add1," & _
                              "mobno,regd_no,sold_by,it_nm,hsn_code,srv_qty,srv_rt,it_tot,oth_amt,disc_amt,unt,mul_rt,it_amt,tto_amt," & _
                              "tax_nm,stax,mrp_amt,tot_tto,tot_vat,srv_amt,dis_amt,chr_amt,dv_tot,adj_amt," & _
                              "nb,splnb,way_bno,inwords,usr_sl,usr_id,manf_nm,drv_nm,drv_mob,cgstper ,cgstamt ,sgstper ,sgstamt ,igstper ,igstamt ," & _
                              "cgsttot ,sgsttot ,igsttot,mrp) VALUES (" & mxno & " , " & Val(bill_no) & " , '" & Format(bill_dt, "dd/MMM/yyyy") & "'   , '" & _
                                inv_no & "'  , '" & (inv_tp) & "'  ,  '" & Trim(order_no) & "'  , '" & Format(order_dt, "dd/MMM/yyyy") & "'  , '" & _
                                ref_no & "','" & Format(ref_dt, "dd/MMM/yyyy") & "'  , '" & bl_name & "'  , '" & add1 & "'  , '" & mobno & "'  , '" & regd_no & "'  , '" & _
                                sold_by & "'  , '" & it_name & "' ,'" & hsn_code & "' ,  " & Val(srv_qty) & "  , " & _
                                 Val(srv_rt) & "  , " & Val(it_tot) & "  ,  " & Val(oth_amt) & "  , " & Val(disc_amt) & "  , '" & _
                                unt & "'  , " & Val(mul_rt) & "  , " & Val(it_amt) & "  , " & Val(tto_amt) & "  , '" & tax_nm & "'  , " & Val(stax) & "  , " & _
                                Val(mrp_amt) & "  , " & Val(tot_tto) & "  , " & Val(tot_vat) & "  , " & Val(srv_amt) & "  , " & Val(dis_amt) & "  , " & _
                                Val(chr_amt) & "  , " & Val(dv_tot) & "  , " & Val(adj_amt) & "  , '" & nb & "'  , '" & splnb & "'  , '" & way_bno & "'  , '" & _
                                inwords & "'  , " & Val(usr_sl) & "  , '" & usr_nm & "', '" & manf_nm & "','" & drv_nm & "','" & drv_mob & "'," & _
                                cgstper & "," & cgstamt & "," & sgstper & "," & sgstamt & "," & igstper & "," & igstamt & "," & cgsttot & "," & sgsttot & "," & igsttot & ",0)")


                Next
            End If
        End If
    End Sub

    Private Sub servbill1()
        reportnm = "Service_bill1.rpt"
    End Sub

    Private Sub servbill2()
        reportnm = "Service_bill.rpt"
    End Sub

    Private Sub servbill3()
        Dim ds As DataSet = get_dataset("SELECT COUNT(slno) as 'Cntno' FROM print_servbill")
        If Val(ds.Tables(0).Rows(0).Item(0)) < 10 Then
            reportnm = "Service_bill1.rpt"
        Else
            reportnm = "Service_bill.rpt"
        End If
    End Sub
End Module
