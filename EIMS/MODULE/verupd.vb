Imports Microsoft.VisualBasic
Module verupd
    Public Sub verupdt()
        Dim ds As DataSet = get_dataset("SELECT ver_no FROM company")
        If ds.Tables(0).Rows.Count <> 0 Then
            ver_no = ds.Tables(0).Rows(0).Item(0)
        End If

        Select Case ver_no
            Case Is = "1.0.0"
                Call updt1()
            Case Is = "1.0.1"
                Call updt2()
            Case Is = "1.0.2"
                Call updt3()
            Case Is = "1.0.3"
                Call updt4()
            Case Is = "1.0.4"
                Call updt5()
            Case Is = "1.0.5"
                Call updt6()
            Case Is = "1.0.6"
                Call updt7()
            Case Is = "1.0.7"
                Call updt8()
            Case Is = "1.0.8"
                Call updt9()
            Case Is = "1.0.9"
                Call updt10()
            Case Is = "1.1.0"
                Call updt11()
            Case Is = "1.1.1"
                Call updt12()
            Case Is = "1.1.2"
                Call updt13()
            Case Is = "1.1.3"
                Call updt14()
            Case Is = "1.1.4"
                Call updt15()
            Case Is = "1.1.5"

            Case Else
                MessageBox.Show("Your Software Might Not Be Updated.Please Contact The Software Provider.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End
        End Select
    End Sub

    Private Sub updt1()
        ver_no = "1.0.1"
        Start1()
        SQLInsert("ALTER TABLE book1 ADD barcode VARCHAR(25)")
        SQLInsert("ALTER TABLE book2 ADD blocked VARCHAR(1)")
        SQLInsert("UPDATE book1 SET barcode =''")
        SQLInsert("UPDATE book2 SET blocked ='N'")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt2()
    End Sub

    Private Sub updt2()
        ver_no = "1.0.2"
        Start1()
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'rejout1' AND type = 'U')" & _
                    "DROP TABLE rejout1")
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'rejout2' AND type = 'U')" & _
                     "DROP TABLE rejout2")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'rej1' AND type = 'U') BEGIN " & _
         "CREATE TABLE [dbo].[rej1](" & _
                  "scrl_no INT  NOT NULL PRIMARY KEY," & _
                  "scrl_dt DATETIME NULL," & _
                  "ref_no VARCHAR(15) NULL," & _
                  "ref_dt DATETIME NULL," & _
                  "staf_sl INT NULL," & _
                  "godsl INT NULL," & _
                  "gr_tot MONEY NULL," & _
                  "nb VARCHAR(70) NULL," & _
                  "rec_lock VARCHAR(1) NULL," & _
                  "usr_ent INT NULL," & _
                  "ent_date DATETIME NULL," & _
                  "usr_mod INT NULL," & _
                  "mod_date DATETIME NULL," & _
                  "usedby VARCHAR(1) NULL," & _
                  "shift_sl INT NULL" & _
       ") END")
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'rej2' AND type = 'U') BEGIN " & _
        "CREATE TABLE [dbo].[rej2](" & _
                 "scrl_sl INT  NOT NULL PRIMARY KEY," & _
                 "scrl_no INT FOREIGN KEY REFERENCES rej1(scrl_no) ," & _
                 "scrl_dt DATETIME NULL," & _
                 "it_cd INT NULL," & _
                 "godsl INT NULL," & _
                 "rej_qty INT NULL," & _
                 "unt VARCHAR (4) NULL," & _
                 "pur_rt MONEY NULL," & _
                 "tot_amt MONEY NULL" & _
        ") END")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt3()
    End Sub

    Private Sub updt3()
        ver_no = "1.0.3"
        Start1()

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'gen_setting' AND type = 'U') BEGIN " & _
         "CREATE TABLE [dbo].[gen_setting](" & _
                  "slno INT  NOT NULL PRIMARY KEY," & _
                  "print_schd INT ," & _
                  "print_coll INT ," & _
                  "print_ocoll INT ," & _
                  "print_payv INT ," & _
                  "print_recv INT ," & _
                  "print_po INT ," & _
                  "stud_icard  INT ," & _
                  "staff_icard INT ," & _
                  "trst_coll INT ," & _
                  "trst_ocoll INT ," & _
                  "due_alrt VARCHAR(1)," & _
                  "due_days INT ," & _
                  "strt_backup VARCHAR(1)," & _
                  "backup_days INT ," & _
                  "backup_pth VARCHAR(100)," & _
                  "stud_bk INT ," & _
                  "stud_bkday INT ," & _
                  "staf_bk INT ," & _
                  "staf_bkday INT ," & _
                  "pf_per MONEY," & _
                  "esic_per MONEY," & _
                  "oth_deduct MONEY," & _
                  "backup_rem INT," & _
                  "bday_rem INT," & _
                  "anvr_rem INT," & _
                  "enq_rem INT ," & _
                  "due_rem INT ," & _
                  "srvr_gsm INT ," & _
                  "sms_srvr VARCHAR(100)," & _
                  "sms_id VARCHAR(50)," & _
                  "sms_pwd	VARCHAR(50)," & _
                  "sender_id VARCHAR(50)," & _
                  "port_no INT ," & _
                  "smtp_srvr VARCHAR(100)," & _
                  "mail_id	VARCHAR(50)," & _
                  "mail_pwd VARCHAR(50)," & _
                  "stud_sms INT ," & _
                  "fath_sms INT ," & _
                  "moth_sms INT ," & _
                  "grdn_sms INT ," & _
                  "regd_sms INT ," & _
                  "due_sms INT ," & _
                  "coll_sms INT ," & _
                  "reslt_sms INT " & _
          ") END")

        SQLInsert("INSERT INTO gen_setting(slno,print_schd,print_coll,print_ocoll,print_payv,print_recv,print_po,stud_icard,staff_icard," & _
                  "trst_coll,trst_ocoll,due_alrt,due_days,strt_backup,backup_days,backup_pth,stud_bk,stud_bkday,staf_bk,staf_bkday,pf_per," & _
                  "esic_per,oth_deduct,backup_rem,bday_rem,anvr_rem,enq_rem,due_rem,srvr_gsm,sms_srvr,sms_id,sms_pwd,sender_id,port_no,smtp_srvr," & _
                  "mail_id,mail_pwd,stud_sms,fath_sms,moth_sms,grdn_sms,regd_sms,due_sms,coll_sms,reslt_sms) VALUES (1,1,1,1,1,1,1,1,1,1,1,'N',0,'Y',0,'" & _
                  My.Application.Info.DirectoryPath & "\Backup" & "',0,0,0,0,0,0,0,1,0,0,0,0,0,'','','','',587,'smtp.gmail.com','','',0,1,0,0,0,0,0,0)")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt4()
    End Sub

    Private Sub updt4()
        ver_no = "1.0.4"
        Start1()
        SQLInsert("ALTER TABLE iss2 ADD refund VARCHAR(1),ret_dt DATETIME")
        SQLInsert("UPDATE iss2 SET refund='N',ret_dt =" & sys_date & "")
        SQLInsert("ALTER TABLE purch1 ADD adj_amt MONEY")
        SQLInsert("UPDATE purch1 SET adj_amt=0")
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'print_order' AND type = 'U') BEGIN " & _
         "CREATE TABLE dbo.print_order(" & _
         "prnt_no INT NULL ," & _
         "supl_nm VARCHAR(40) NULL ," & _
         "add1 VARCHAR(100) NULL ," & _
         "cont1 VARCHAR(12) NULL ," & _
         "po_no INT NULL ," & _
         "ordr_dt DATETIME NULL ," & _
         "delv_dt DATETIME NULL ," & _
         "prod_nm VARCHAR(40) NULL ," & _
         "po_qty MONEY NULL ," & _
         "nb VARCHAR(50) NULL ," & _
         "usr_sl INT NULL ," & _
         "comp_nm VARCHAR(100) NULL ," & _
         "comp_add1 VARCHAR(50) NULL ," & _
         "comp_add2 VARCHAR(50) NULL ," & _
         "comp_cont1 VARCHAR(20) NULL ," & _
         "comp_email VARCHAR(40) NULL ," & _
         "comp_web VARCHAR(40) NULL" & _
         ") END")


        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt5()
    End Sub

    Private Sub updt5()
        ver_no = "1.0.5"
        Start1()
        SQLInsert("ALTER TABLE purch1 ADD godsl INT")
        SQLInsert("UPDATE purch1 SET godsl=0")
        SQLInsert("ALTER TABLE purch2 DROP COLUMN godsl")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt6()
    End Sub

    Private Sub updt6()
        ver_no = "1.0.6"
        Start1()
        SQLInsert("ALTER TABLE purch1 ALTER COLUMN way_bno INT")
        SQLInsert("ALTER TABLE purch1 ALTER COLUMN way_chr VARCHAR(5)")
        SQLInsert("ALTER TABLE print_order ADD gr_tot MONEY, po_rate MONEY, po_amt MONEY,unt VARCHAR(6),mrp MONEY,inword VARCHAR(70)")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'pret1' AND type = 'U') BEGIN " & _
        "CREATE TABLE dbo.pret1(" & _
                        "pret_no INT NOT NULL PRIMARY KEY," & _
                        "pret_dt DATETIME NULL," & _
                        "prt_code INT NULL," & _
                        "pret_type VARCHAR(1) NULL," & _
                        "chal_no VARCHAR(10) NULL," & _
                        "chal_dt DATETIME NULL," & _
                        "ref_no VARCHAR(15) NULL," & _
                        "ref_dt DATETIME NULL," & _
                        "way_bno INT NULL," & _
                        "trk_no VARCHAR(15) NULL," & _
                        "pret_amt MONEY NULL," & _
                        "adj_amt MONEY NULL," & _
                        "way_chr VARCHAR(5) NULL," & _
                        "dis_amt MONEY NULL," & _
                        "chr_amt MONEY NULL," & _
                        "nb VARCHAR(70) NULL," & _
                        "lr_no VARCHAR(15) NULL," & _
                        "lr_dt DATETIME NULL," & _
                        "usedby VARCHAR(1) NULL," & _
                        "godsl INT NULL," & _
                        "rec_lock VARCHAR(1) NULL," & _
                        "usr_ent INT NULL," & _
                        "ent_date DATETIME NULL," & _
                        "usr_mod INT NULL," & _
                        "mod_date DATETIME NULL" & _
        ") END")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'pret2' AND type = 'U') BEGIN " & _
        "CREATE TABLE dbo.pret2(" & _
                       "pret_sl INT NOT NULL PRIMARY KEY," & _
                       "pret_no INT FOREIGN KEY REFERENCES pret1(pret_no)," & _
                       "pret_dt DATETIME NULL," & _
                       "prt_code INT NULL," & _
                       "it_cd INT NULL," & _
                       "pur_rt MONEY NULL," & _
                       "pret_qty MONEY NULL," & _
                       "it_amt MONEY NULL," & _
                       "tto_amt MONEY NULL," & _
                       "tax_cd MONEY NULL," & _
                       "oth_amt MONEY NULL," & _
                       "disc_amt MONEY NULL," & _
                       "to_amt MONEY NULL," & _
                       "stax MONEY NULL," & _
                       "entax MONEY NULL," & _
                       "mrp MONEY NULL," & _
                       "ex_mrp MONEY NULL," & _
                       "prd_tp varchar(1) NULL," & _
                       "tr_tp varchar(1) NULL," & _
                       "unt varchar(4) NULL," & _
                       "free_qty MONEY NULL," & _
                       "mul_rt MONEY NULL," & _
                       "disc_rt1 MONEY NULL," & _
                       "disc_rt2 MONEY NULL," & _
                       "disc_amt1 MONEY NULL," & _
                       "disc_amt2 MONEY NULL," & _
                       "mrp_amt MONEY NULL," & _
                       "bit_type varchar(1) NULL" & _
                ") END")



        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt7()
    End Sub

    Private Sub updt7()
        ver_no = "1.0.7"
        Start1()
        SQLInsert("ALTER TABLE party ALTER column add1 VARCHAR(100)")
        SQLInsert("ALTER TABLE pubc ALTER column add1 VARCHAR(100)")
        SQLInsert("ALTER TABLE staf_quali ALTER column sch_nm VARCHAR(70)")
        SQLInsert("ALTER TABLE staf ALTER column per_add1 VARCHAR(100)")
        SQLInsert("ALTER TABLE staf ALTER column pre_add1 VARCHAR(100)")
        SQLInsert("ALTER TABLE universe ALTER column add1 VARCHAR(100)")
        SQLInsert("ALTER TABLE ig1 ALTER column ig_ref VARCHAR(20)")
        SQLInsert("ALTER TABLE coll ALTER column coll_nm VARCHAR(30)")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt8()
    End Sub

    Private Sub updt8()
        ver_no = "1.0.8"
        Start1()
        SQLInsert("ALTER TABLE staf ADD id_pfx VARCHAR(4),stafid_no INT")
        SQLInsert("UPDATE staf SET id_pfx='',stafid_no=staf_sl")
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'print_purch' AND type = 'U') BEGIN " & _
        "CREATE TABLE dbo.print_purch(" & _
            "slno INT NULL," & _
            "scrl_no INT NULL," & _
            "pret_dt DATETIME NULL," & _
            "po_no INT NULL," & _
            "ref_no VARCHAR(15) NULL," & _
            "ref_dt DATETIME NULL," & _
            "prt_nm VARCHAR(30) NULL," & _
            "add1 VARCHAR(30) NULL," & _
            "prt_tin VARCHAR(15) NULL," & _
            "cont1 VARCHAR(15) NULL," & _
            "it_name VARCHAR(30) NULL," & _
            "unt VARCHAR(6) NULL," & _
            "it_qty MONEY NULL," & _
            "it_free MONEY NULL," & _
            "mul_rt MONEY NULL," & _
            "it_mrp MONEY NULL," & _
            "it_rate MONEY NULL," & _
            "it_amt MONEY NULL," & _
            "taxcat VARCHAR(8) NULL," & _
            "it_tax MONEY NULL," & _
            "it_disc MONEY NULL," & _
            "tot_mrp MONEY NULL," & _
            "tot_vat MONEY NULL," & _
            "tot_amt MONEY NULL," & _
            "chrg_amt MONEY NULL," & _
            "disc_amt MONEY NULL," & _
            "adj_amt MONEY NULL," & _
            "gr_tot MONEY NULL," & _
            "nb VARCHAR(70) NULL," & _
            "prt_code INT NULL," & _
            "inv_tp VARCHAR(10) NULL," & _
            "excl_mrp MONEY NULL," & _
            "inword VARCHAR(70) NULL," & _
            "cur_bal VARCHAR(20) NULL," & _
            "usr_sl INT NULL," & _
        ") END")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt9()
    End Sub

    Private Sub updt9()
        ver_no = "1.0.9"
        Start1()
        SQLInsert("ALTER TABLE stud ALTER COLUMN cause_leave VARCHAR(50)")

        SQLInsert("ALTER TABLE stud DROP COLUMN income")
        SQLInsert("ALTER TABLE stud ADD income VARCHAR(1)")
        SQLInsert("UPDATE stud SET income = '1'")

        SQLInsert("ALTER TABLE universe ALTER COLUMN uni_pfx VARCHAR(6)")

        SQLInsert("ALTER TABLE book2 ADD pur_sl INT")
        SQLInsert("UPDATE book2 SET pur_sl = 0")

        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'sending_sms' AND type = 'U')" & _
            "DROP TABLE sending_sms")
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'sending_mail' AND type = 'U')" & _
                     "DROP TABLE sending_mail")

        SQLInsert("ALTER TABLE item ADD rop_stk DECIMAL,rrec_stk DECIMAL,riss_stk DECIMAL,rcl_stk DECIMAL")
        SQLInsert("UPDATE item SET rop_stk=0,rrec_stk=0,riss_stk=0,rcl_stk=0")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'contacts' AND type = 'U') BEGIN " & _
        "CREATE TABLE dbo.contacts(" & _
           "cont_sl int NOT NULL," & _
           "cont_nm varchar(100) NULL," & _
           "cont_no varchar(20) NULL," & _
           "grp_sl int NULL" & _
        ") END")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'phgroup' AND type = 'U') BEGIN " & _
            "CREATE TABLE dbo.phgroup(" & _
                "grp_sl int NOT NULL," & _
                "grp_nm varchar(100) NULL" & _
            ") END")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'sending_mail' AND type = 'U') BEGIN " & _
          "CREATE TABLE dbo.sending_mail(" & _
                "mail_sl int NOT NULL ," & _
                "to_nm varchar(50) NULL," & _
                "to_mail varchar(70) NULL," & _
                "subj varchar(100) NULL," & _
                "matr text NULL," & _
                "attch VARCHAR(200) NULL," & _
                "mail_dt datetime NULL," & _
                "mail_snd varchar(1) NULL," & _
                "mail_sdt datetime NULL," & _
                "evnt VARCHAR(15) NULL" & _
          ") END")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'sending_sms' AND type = 'U') BEGIN " & _
         "CREATE TABLE dbo.sending_sms(" & _
                "sms_sl int NOT NULL ," & _
                "sms_for varchar(20) NULL," & _
                "sms_no text NULL," & _
                "sms_text text NULL," & _
                "sms_dt datetime NULL," & _
                "sms_snd varchar(1) NULL," & _
                "sms_sdt datetime NULL," & _
                "evnt VARCHAR(15) NULL" & _
         ") END")


        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt10()
    End Sub

    Private Sub updt10()
        ver_no = "1.1.0"
        Start1()
        SQLInsert("ALTER TABLE print_collrecpt ADD nb VARCHAR(100)")

        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_sl01")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_nm01")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_amt01")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_sl02")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_nm02")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_amt02")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_sl03")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_nm03")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_amt03")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_sl04")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_nm04")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_amt04")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_sl05")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_nm05")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_amt05")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_sl06")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_nm06")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_amt06")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_sl07")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_nm07")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_amt07")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_sl08")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_nm08")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_amt08")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_sl09")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_nm09")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_amt09")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_sl10")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_nm10")
        SQLInsert("ALTER TABLE print_collrecpt DROP COLUMN coll_amt10")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt11()
    End Sub

    Private Sub updt11()
        ver_no = "1.1.1"
        Start1()

        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'setting_purch' AND type = 'U')" & _
                     "DROP TABLE setting_purch")
        SQLInsert("ALTER TABLE purch1 ADD dv_tot MONEY")
        SQLInsert("UPDATE purch1 SET dv_tot = 0")
        SQLInsert("EXEC sp_rename 'purch1.to_amt', 'pur_amt', 'COLUMN'")
        SQLInsert("EXEC sp_rename 'purch2.pur_amt', 'it_tot', 'COLUMN'")
        SQLInsert("ALTER TABLE party ADD cl_amt MONEY")
        SQLInsert("UPDATE party SET cl_amt = op_bal")
        SQLInsert("ALTER TABLE stud ALTER COLUMN per_add1 VARCHAR(100)")
        SQLInsert("ALTER TABLE stud ALTER COLUMN per_add2 VARCHAR(100)")
        SQLInsert("ALTER TABLE stud ALTER COLUMN pre_add1 VARCHAR(100)")
        SQLInsert("ALTER TABLE stud ALTER COLUMN pre_add2 VARCHAR(100)")
        SQLInsert("ALTER TABLE stud ALTER COLUMN email VARCHAR(100)")
        SQLInsert("ALTER TABLE stud ALTER COLUMN cause_leave VARCHAR(100)")
        SQLInsert("ALTER TABLE stud_quali ALTER COLUMN ins_nm VARCHAR(100)")
        SQLInsert("ALTER TABLE voucr_coll ADD staf_sl INT")
        SQLInsert("ALTER TABLE voucr_trst ADD staf_sl INT")
        SQLInsert("ALTER TABLE voucp_coll ADD staf_sl INT")
        SQLInsert("ALTER TABLE voucp_trst ADD staf_sl INT")
        SQLInsert("ALTER TABLE ocollrec1 ADD bank_nm VARCHAR(50),chq_no VARCHAR(50),chq_dt DATETIME")
        SQLInsert("UPDATE ocollrec1 SET bank_nm ='',chq_no = '',chq_dt = coll_dt")


        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'setting_purch' AND type = 'U') BEGIN " & _
                "CREATE TABLE dbo.setting_purch(" & _
                        "slno INT NOT NULL PRIMARY KEY," & _
                        "req_mrp INT NOT NULL," & _
                        "req_rate INT NOT NULL," & _
                        "req_disc INT NOT NULL," & _
                        "req_codis INT NOT NULL," & _
                        "req_vat INT NOT NULL," & _
                        "bill_rnd INT NOT NULL," & _
                        "req_prnt INT NOT NULL," & _
                        "rate_calc INT NOT NULL" & _
                ") END")

        SQLInsert("INSERT INTO setting_purch(slno,req_mrp,req_rate,req_disc,req_codis,req_vat,bill_rnd,req_prnt,rate_calc) VALUES (1,0,0,0,0,0,0,0,0)")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'untlnk' AND type = 'U') BEGIN " & _
                "CREATE TABLE dbo.untlnk(" & _
                        "slno INT NOT NULL PRIMARY KEY," & _
                        "it_cd int NULL," & _
                        "unt_pos int NULL," & _
                        "unt_nm varchar(4) NULL," & _
                        "mul_rt int NULL," & _
                        "unt_cd int NULL," & _
                ") END")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt12()
    End Sub

    Private Sub updt12()
        ver_no = "1.1.2"
        Start1()

        SQLInsert("ALTER TABLE gen_setting ADD copy_schd INT")
        SQLInsert("ALTER TABLE gen_setting ADD copy_coll INT")
        SQLInsert("ALTER TABLE gen_setting ADD copy_ocoll INT")
        SQLInsert("ALTER TABLE gen_setting ADD copy_payv INT")
        SQLInsert("ALTER TABLE gen_setting ADD copy_recv INT")
        SQLInsert("ALTER TABLE gen_setting ADD copy_po INT")
        SQLInsert("ALTER TABLE gen_setting ADD copy_tcoll INT")
        SQLInsert("ALTER TABLE gen_setting ADD copy_tocoll INT")
        SQLInsert("UPDATE gen_setting SET copy_schd=1, copy_coll=1,copy_ocoll=1,copy_payv=1,copy_recv=1,copy_po=1,copy_tcoll=1,copy_tocoll=1")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'course' AND type = 'U') BEGIN " & _
             "CREATE TABLE dbo.course(" & _
                     "course_cd INT NOT NULL PRIMARY KEY," & _
                     "course_nm varchar(50) NULL UNIQUE," & _
                     "rec_lock varchar(1) NULL" & _
             ") END")
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'print_cashbook' AND type = 'U') BEGIN " & _
             "CREATE TABLE dbo.print_cashbook(" & _
                     "slno INT NOT NULL PRIMARY KEY," & _
                     "scrl_dt DATETIME NULL," & _
                     "scrl_tp VARCHAR(15) NULL," & _
                     "scrl_no bigINT NULL," & _
                     "tr_details VARCHAR(100) NULL," & _
                     "dr_amt MONEY NULL," & _
                     "cr_amt MONEY NULL," & _
                     "desc1 VARCHAR(50) NULL," & _
                     "desc2 VARCHAR(50) NULL," & _
                     "desc3 VARCHAR(50) NULL," & _
                     "blnc_amt VARCHAR(30) NULL," & _
                     "usr_sl INT NULL" & _
              ") END")


        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt13()
    End Sub

    Private Sub updt13()
        ver_no = "1.1.3"
        Start1()

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'print_prtledg' AND type = 'U') BEGIN " & _
             "CREATE TABLE dbo.print_prtledg(" & _
                     "slno INT NOT NULL PRIMARY KEY," & _
                     "scrl_dt DATETIME NULL," & _
                     "scrl_tp VARCHAR(15) NULL," & _
                     "scrl_no bigINT NULL," & _
                     "prt_code INT NULL," & _
                     "prt_type VARCHAR(30) NULL," & _
                     "tr_details VARCHAR(100) NULL," & _
                     "dr_amt MONEY NULL," & _
                     "cr_amt MONEY NULL," & _
                     "desc1 VARCHAR(50) NULL," & _
                     "desc2 VARCHAR(50) NULL," & _
                     "desc3 VARCHAR(50) NULL," & _
                     "blnc_amt VARCHAR(30) NULL," & _
                     "usr_sl INT NULL" & _
              ") END")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'bk_pret1' AND type = 'U') BEGIN " & _
            "CREATE TABLE dbo.bk_pret1(" & _
                    "pret_no INT NOT NULL PRIMARY KEY," & _
                    "pret_dt DATETIME NULL," & _
                    "pret_tp VARCHAR(1) NULL," & _
                    "ref_no VARCHAR(10) NULL," & _
                    "ref_dt DATETIME NULL," & _
                    "prt_code INT NULL," & _
                    "tot_tax MONEY NULL," & _
                    "tot_itamt MONEY NULL," & _
                    "tot_oth MONEY NULL," & _
                    "tot_ittot MONEY NULL," & _
                    "chr_amt MONEY NULL," & _
                    "dis_amt MONEY NULL," & _
                    "adj_amt MONEY NULL," & _
                    "gr_tot MONEY NULL," & _
                    "nb VARCHAR(50) NULL," & _
                    "usr_ent INT NULL," & _
                    "ent_date DATETIME NULL," & _
                    "usr_mod INT NULL," & _
                    "mod_date DATETIME NULL," & _
                    "usedby VARCHAR(1) NULL," & _
                    "rec_lock VARCHAR(1) NULL" & _
             ") END")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'bk_pret2' AND type = 'U') BEGIN " & _
           "CREATE TABLE dbo.bk_pret2(" & _
                   "pret_sl INT NOT NULL PRIMARY KEY," & _
                   "pret_no INT NULL," & _
                   "pret_dt DATETIME NULL," & _
                   "prt_code INT NULL," & _
                   "pur_tp VARCHAR(1) NULL," & _
                   "book_cd INT NULL," & _
                   "it_qty INT NULL," & _
                   "it_rate MONEY NULL," & _
                   "it_amt MONEY NULL," & _
                   "tax_cd INT NULL," & _
                   "tax_amt MONEY NULL," & _
                   "oth_amt MONEY NULL," & _
                   "it_tot MONEY NULL" & _
            ") END")

        SQLInsert("ALTER TABLE collrec1 ADD disc_amt MONEY")
        SQLInsert("ALTER TABLE ocollrec1 ADD disc_amt MONEY")
        SQLInsert("UPDATE collrec1 SET disc_amt = 0")
        SQLInsert("UPDATE ocollrec1 SET disc_amt = 0")

        SQLInsert("ALTER TABLE company ADD co_snm VARCHAR(10)")
        SQLInsert("UPDATE company SET co_snm =''")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt14()
    End Sub

    Private Sub updt14()
        ver_no = "1.1.4"
        Start1()
        SQLInsert("ALTER TABLE menumst ADD menu_prmsn VARCHAR(1)")
        SQLInsert("ALTER TABLE menumst ALTER COLUMN menu_tp VARCHAR(2)")
        SQLInsert("UPDATE menumst SET menu_prmsn = 'Y'")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt15()
    End Sub

    Private Sub updt15()
        ver_no = "1.1.5"
        Start1()
        SQLInsert("ALTER TABLE book1 ALTER COLUMN isbn_no VARCHAr(25)")
       
        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & "." & _
                      vbCrLf & "Please Close The Software To Activate The Update Version.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End
    End Sub
End Module
