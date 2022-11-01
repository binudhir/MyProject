Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module ordprint
    Dim ord_no As Integer

    Public Sub order_print(ByVal slno As Integer)
        ord_no = slno
        Call datastore()
        Select Case printpo
            Case Is = 1
                Call ordprint1()  ' Windows Print Order Default Half Page
            Case Else
                Call ordprint1()
        End Select
        For i As Integer = 0 To copypo
            Call print_repo()
        Next
    End Sub

    Private Sub datastore()
        SQLInsert("DELETE FROM print_order WHERE usr_sl=" & usr_sl & "")
        Dim ds1 As DataSet = get_dataset("SELECT porder1.po_no, porder1.po_dt, porder1.deliver_dt, porder1.nb1, party.pname, party.add1, party.cont1, item.it_name,manf.manf_nm, porder2.po_qty, porder2.po_mrp, porder2.po_unit, porder1.gr_tot, porder2.po_rate, porder2.po_amt FROM item RIGHT OUTER JOIN porder2 ON item.it_cd = porder2.it_cd RIGHT OUTER JOIN manf ON manf.manf_cd = porder2.manf_cd RIGHT OUTER JOIN porder1 ON porder2.po_no = porder1.po_no LEFT OUTER JOIN party ON porder1.prt_code = party.prt_code WHERE porder1.po_no=" & Val(ord_no) & "")
        If ds1.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                itnm = ds1.Tables(0).Rows(i).Item("it_name")
                manfnm = ds1.Tables(0).Rows(i).Item("manf_nm")
                suplnm = ds1.Tables(0).Rows(i).Item("pname")
                add1 = ds1.Tables(0).Rows(i).Item("add1")
                cont = ds1.Tables(0).Rows(i).Item("cont1")
                pono = ds1.Tables(0).Rows(i).Item("po_no")
                orddt = ds1.Tables(0).Rows(i).Item("po_dt")
                deldt = ds1.Tables(0).Rows(i).Item("deliver_dt")
                qty = ds1.Tables(0).Rows(i).Item("po_qty")
                nb = ds1.Tables(0).Rows(0).Item("nb1") & "."
                If conb <> "" Then
                    nb = nb & conb
                End If
                unt = ds1.Tables(0).Rows(i).Item("po_unit")
                mrp = ds1.Tables(0).Rows(i).Item("po_mrp")
                purt = ds1.Tables(0).Rows(i).Item("po_rate")
                amt = ds1.Tables(0).Rows(i).Item("po_amt")
                tot = Val(ds1.Tables(0).Rows(i).Item("gr_tot"))
                inword = RupeesToWord(tot)
                Dim ds As DataSet = get_dataset("SELECT MAX(prnt_no) AS 'Max' FROM print_order")
                mxno = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO print_order(prnt_no,supl_nm,add1,cont1,po_no,ordr_dt,delv_dt,manf_nm,prod_nm,po_qty,nb,unt,mrp,po_rate,po_amt,gr_tot,inword," & _
                          "usr_sl) VALUES (" & mxno & ",'" & _
                          suplnm & "','" & add1 & "','" & cont & "'," & pono & ",'" & orddt & "','" & deldt & "','" & manfnm & "','" & _
                         itnm & "'," & qty & ",'" & nb & "','" & unt & "','" & mrp & "','" & purt & "','" & amt & "','" & tot & "','" & inword & "'," & usr_sl & ")")
            Next
        End If
    End Sub

    Private Sub ordprint1()
        reportnm = "porder.rpt"
    End Sub
End Module
