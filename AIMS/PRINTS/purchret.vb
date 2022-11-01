Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module purchret
    Dim ret_no As Integer

    Public Sub pret_print(ByVal slno As Integer)
        ret_no = slno
        Call datastore()
        Select Case printpret
            Case Is = 1
                Call purchret1()  ' Windows Print Order Default Half Page
            Case Else
                Call purchret1()
        End Select
        For i As Integer = 0 To copypret
            Call print_repo()
        Next
    End Sub

    Private Sub datastore()
        SQLInsert("DELETE FROM print_purch WHERE usr_sl=" & usr_sl & "")
        Dim ds1 As DataSet = get_dataset("SELECT pret1.pret_no, party.cont1,party.cl_amt, pret1.pret_dt, pret1.ref_no, pret1.ref_dt, pret1.dis_amt, pret1.adj_amt, pret1.pret_amt, pret1.nb, pret1.chr_amt, pret1.pret_type, pret2.prt_code, party.pname, party.add1,  item.it_name, pret2.unt, pret2.pret_qty, pret2.free_qty, pret2.mul_rt, pret2.mrp, pret2.pur_rt, pret2.it_amt, taxper.taxnm, pret2.stax, pret2.disc_amt, pret2.mrp_amt, pret2.to_amt, pret2.ex_mrp, party.lst_no FROM pret1 INNER JOIN pret2 ON pret1.pret_no = pret2.pret_no LEFT OUTER JOIN taxper ON pret2.tax_cd = taxper.taxcd LEFT OUTER JOIN item ON pret2.it_cd = item.it_cd LEFT OUTER JOIN party ON pret2.prt_code = party.prt_code  WHERE pret1.pret_no=" & Val(ret_no) & "")
        If ds1.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                prtbal = ""
                If ds1.Tables(0).Rows(0).Item("prt_code") <> 0 Then
                    clamt = Val(ds1.Tables(0).Rows(0).Item("cl_amt"))
                    If clamt < 0 Then
                        prtbal = "Cur.Bal. : " & Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
                    Else
                        prtbal = "Cur.Bal. : " & Format(clamt, "#######0.00") & " " & "Cr."
                    End If
                End If
                retno = ds1.Tables(0).Rows(i).Item("pret_no")
                retdt = ds1.Tables(0).Rows(i).Item("pret_dt")
                refno = ds1.Tables(0).Rows(i).Item("ref_no")
                refdt = ds1.Tables(0).Rows(i).Item("ref_dt")
                disamt = ds1.Tables(0).Rows(i).Item("dis_amt")
                adjamt = ds1.Tables(0).Rows(i).Item("adj_amt")
                retamt = Val(ds1.Tables(0).Rows(i).Item("pret_amt"))
                nb = prtbal & " " & ds1.Tables(0).Rows(0).Item("nb") & "."
                If conb <> "" Then
                    nb = nb & conb
                End If
                charges = ds1.Tables(0).Rows(i).Item("chr_amt")
                rettype = ds1.Tables(0).Rows(i).Item("pret_type")
                prtcd = ds1.Tables(0).Rows(i).Item("po_mrp")
                prtnm = ds1.Tables(0).Rows(i).Item("pname")
                add = ds1.Tables(0).Rows(i).Item("add1")
                cont = ds1.Tables(0).Rows(i).Item("cont1")
                itnm = ds1.Tables(0).Rows(i).Item("it_name")
                unt = ds1.Tables(0).Rows(i).Item("unt")
                retqty = ds1.Tables(0).Rows(i).Item("pret_qty")
                freeqty = ds1.Tables(0).Rows(i).Item("free_qty")
                mulrt = ds1.Tables(0).Rows(i).Item("mul_rt")
                mrp = ds1.Tables(0).Rows(i).Item("mrp")
                purrt = ds1.Tables(0).Rows(i).Item("pur_rt")
                itamt = ds1.Tables(0).Rows(i).Item("it_amt")
                taxnm = ds1.Tables(0).Rows(i).Item("taxnm")
                stax = ds1.Tables(0).Rows(i).Item("stax")
                discamt = ds1.Tables(0).Rows(i).Item("disc_amt")
                mrpamt = ds1.Tables(0).Rows(i).Item("mrp_amt")
                toamt = ds1.Tables(0).Rows(i).Item("to_amt")
                exmrp = ds1.Tables(0).Rows(i).Item("ex_mrp")
                tin = ds1.Tables(0).Rows(i).Item("lst_no")
                inword = RupeesToWord(retamt)
                Dim ds As DataSet = get_dataset("SELECT MAX(slno) AS 'Max' FROM print_purch")
                mxno = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO print_purch(slno,scrl_no,pret_dt,po_no,ref_no,ref_dt,prt_nm,add1,prt_tin,cont1,it_name,unt," & _
                         "it_qty,it_free,mul_rt,it_mrp,it_rate,it_amt,taxcat,it_tax,it_disc,tot_mrp,tot_vat,tot_amt,chrg_amt," & _
                         "disc_amt,adj_amt,gr_tot,nb,prt_code,inv_tp,excl_mrp,inword,cur_bal,usr_sl) VALUES (" & mxno & "," & _
                          retno & ",'" & retdt & "',0," & refno & ",'" & refdt & "','" & prtnm & "','" & add & "','" & _
                        tin & "'," & cont & ",'" & itnm & "','" & unt & "'," & retqty & "," & freeqty & "," & mulrt & "," & mrp & _
                        "," & purrt & "," & itamt & "," & taxnm & "," & stax & "," & discamt & "," & mrpamt & ",0," & toamt & _
                        "," & charges & "," & disamt & "," & adjamt & "," & retamt & ",'" & nb & "'," & prtcd & ",1," & exmrp & ",'" & inword & "'," & usr_sl & " )")
            Next
        End If
    End Sub

    Private Sub purchret1()
        reportnm = "purchret.rpt"
    End Sub
End Module
