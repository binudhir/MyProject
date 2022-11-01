﻿Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module payprint
    Dim vno As Integer

    Public Sub pvouc_print(ByVal slno As Integer)
        vno = slno
        Call datastore()
        Select Case printpvouc
            Case Is = 1
                Call payvouc1()  ' Windows Print Voucher Default Half Page
            Case Else
                Call payvouc1()
        End Select
        For i As Integer = 0 To copypvouc
            Call print_repo()
        Next
    End Sub

    Private Sub datastore()
        SQLInsert("DELETE FROM mrprint WHERE usr_sl=" & usr_sl & "")
        Dim ds1 As DataSet = get_dataset("SELECT voucp.*, staf.staf_nm, party.pname,party.add1,party.cl_amt, (SELECT pname FROM party WHERE party.prt_code=voucp.by_code) AS bank_nm,(SELECT add1 FROM party WHERE party.prt_code=voucp.by_code) AS bank_add FROM voucp LEFT OUTER JOIN party ON voucp.prt_code = party.prt_code LEFT OUTER JOIN staf ON voucp.staf_sl = staf.staf_sl WHERE voucp.v_no=" & Val(vno) & "")
        If ds1.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                prtbal = ""
                If ds1.Tables(0).Rows(0).Item("prt_code") <> 0 Then
                    clamt = Val(ds1.Tables(0).Rows(0).Item("cl_amt"))
                    If clamt < 0 Then
                        prtbal = "Cur.Bal.: " & Format(Val(clamt) * (-1), "#######0.00") & " " & "Dr."
                    Else
                        prtbal = "Cur.Bal. : " & Format(clamt, "#######0.00") & " " & "Cr."
                    End If
                End If
                mrno = ds1.Tables(0).Rows(i).Item("v_no")
                mrdt = ds1.Tables(0).Rows(i).Item("v_dt")
                amt = Val(ds1.Tables(0).Rows(i).Item("amt"))
                pname = ds1.Tables(0).Rows(i).Item("pname")
                add1 = ds1.Tables(0).Rows(i).Item("add1")
                desc1 = ds1.Tables(0).Rows(i).Item("desc1")
                desc2 = prtbal & " " & ds1.Tables(0).Rows(i).Item("desc2")
                desc3 = ds1.Tables(0).Rows(i).Item("desc3")
                If conb <> "" Then
                    desc3 = desc3 & "N.B. :" & conb
                End If
                stafnm = ds1.Tables(0).Rows(i).Item("staf_nm")
                banknm = ds1.Tables(0).Rows(i).Item("bank_nm")
                bankadd = ds1.Tables(0).Rows(i).Item("bank_add")

                paymode = "Cash"
                If ds1.Tables(0).Rows(i).Item("pay_mode") = "2" Then
                    paymode = "DD/Cheque"
                End If
                inwords = RupeesToWord(amt)

                Dim ds As DataSet = get_dataset("SELECT max(slno) as 'Max' FROM mrprint")
                mxno = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO mrprint(slno,mr_no,mr_dt,in_word,mr_amt,disc_amt,pname,add1,pay_mode,desc1,desc2,desc3,staf_nm,dipo_at,usr_sl) VALUES (" & mxno & "," & _
                          mrno & ",'" & mrdt & "','" & inwords & "','" & amt & "',0,'" & pname & "','" & _
                          add1 & "','" & paymode & "','" & desc1 & "','" & desc2 & "','" & desc3 & "','" & stafnm & "','" & banknm & "'," & Val(usr_sl) & ")")
            Next
        End If
    End Sub

    Private Sub payvouc1()
        reportnm = "payvouc.rpt"
    End Sub
End Module
