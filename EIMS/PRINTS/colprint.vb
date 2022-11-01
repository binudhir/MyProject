Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module colprint
    Dim recno As Integer

    Public Sub colrec_print(ByVal slno As Integer)
        recno = slno
        Call datastore()
        Select Case print_coll
            Case Is = 1
                Call collrec1()  ' Windows Print Collrec Default Half Page
            Case Else
                Call collrec1()
        End Select
        For i As Integer = 0 To copy_coll - 1
            Call print_repo()
        Next
    End Sub

    Private Sub datastore()
        SQLInsert("DELETE FROM print_collrecpt WHERE usr_sl=" & usr_sl & "")
        Dim ds1 As DataSet = get_dataset("SELECT trad.trad_nm, sesion1.sesn_nm, stud.stud_nm, stud.per_add1, stud_hstry.reg_no, collrec2.coll_amt, coll.coll_nm, collrec1.*, semester.sem_nm FROM trad RIGHT OUTER JOIN semester RIGHT OUTER JOIN stud_hstry ON semester.sem_cd = stud_hstry.sem_cd LEFT OUTER JOIN stud ON stud_hstry.stud_sl = stud.stud_sl LEFT OUTER JOIN sesion1 ON stud_hstry.sesn_cd = sesion1.sesn_cd ON trad.trad_cd = stud_hstry.trad_cd RIGHT OUTER JOIN collrec2 LEFT OUTER JOIN coll ON collrec2.coll_cd = coll.coll_cd RIGHT OUTER JOIN collrec1 ON collrec2.coll_no = collrec1.coll_no ON stud_hstry.stud_sl = collrec1.stud_sl WHERE (stud_hstry.active = 'Y') AND (collrec1.coll_no = " & Val(recno) & ") ORDER BY coll.coll_nm")
        If ds1.Tables(0).Rows.Count <> 0 Then
            For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                recno = ds1.Tables(0).Rows(i).Item("coll_no")
                recdt = ds1.Tables(0).Rows(i).Item("coll_dt")
                regno = ds1.Tables(0).Rows(i).Item("reg_no")
                studnm = ds1.Tables(0).Rows(i).Item("stud_nm")
                add1 = ds1.Tables(0).Rows(i).Item("per_add1")
                stream = ds1.Tables(0).Rows(i).Item("trad_nm")
                session = ds1.Tables(0).Rows(i).Item("sesn_nm")
                acyr = ds1.Tables(0).Rows(i).Item("sesn_nm")
                sem_nm = ds1.Tables(0).Rows(i).Item("sem_nm")
                totamt = ds1.Tables(0).Rows(i).Item("tot_amt")
                paymode = "Cash"
                If ds1.Tables(0).Rows(i).Item("pay_mod") = "2" Then
                    paymode = "DD/Cheque"
                End If
                inwords = RupeesToWord(totamt)
                chqno = ds1.Tables(0).Rows(i).Item("chq_no")
                banknm = ds1.Tables(0).Rows(i).Item("bank_nm")
                'use = ds1.Tables(0).Rows(i).Item("coll_no")
                colnm = ds1.Tables(0).Rows(i).Item("coll_nm")
                colamt = ds1.Tables(0).Rows(i).Item("coll_amt")
                nb = ds1.Tables(0).Rows(i).Item("nb")


                Dim ds As DataSet = get_dataset("SELECT max(sl) as 'Max' FROM print_collrecpt")
                mxno = 1
                If ds.Tables(0).Rows.Count <> 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                        mxno = ds.Tables(0).Rows(0).Item(0) + 1
                    End If
                End If
                SQLInsert("INSERT INTO print_collrecpt(sl,comp_nm,add1,add2,cont1,cont2,rcpt_no,rcpt_dt,reg_no,trad_nm,stud_nm,acdm_yr," & _
                          "sem_nm,pay_mod,tot_amt,amt_word,chq_no,chq_dt,bank_nm,coll_sl,coll_nm,nb,coll_amt,usr_sl) VALUES (" & mxno & ",'" & _
                          conm & "','" & coadd & "','" & coadd & "','" & coph1 & "','" & coph2 & "'," & recno & ",'" & recdt & "','" & _
                          regno & "','" & stream & "','" & studnm & "','" & acyr & "','" & sem_nm & "','" & paymode & "'," & totamt & ",'" & _
                          inwords & "','" & chqno & "','" & recdt & "','" & banknm & "'," & i + 1 & ",'" & colnm & "','" & nb & "'," & colamt & "," & _
                          usr_sl & ")")


            Next
        End If
    End Sub

    Private Sub collrec1()
        reportnm = "collrec.rpt"
        'Call print_repo()
        ' Call print_repo()
        'Call prints()
    End Sub
End Module
