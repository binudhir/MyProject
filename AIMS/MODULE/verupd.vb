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
                Call updt16()
            Case Is = "1.1.6"
                Call updt17()
            Case Is = "1.1.7"
            Case Else
                MessageBox.Show("Your Software Might Not Be Updated.Please Contact The Software Provider.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End
        End Select
    End Sub

    Private Sub updt1()
        ver_no = "1.0.1"
        Start1()
        SQLInsert("ALTER TABLE party ADD cst_no VARCHAR(30)")
        SQLInsert("UPDATE party SET cst_no =''")
       
        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt2()
    End Sub

    Private Sub updt2()
        ver_no = "1.0.2"
        Start1()
        SQLInsert("ALTER TABLE party ALTER COLUMN mail VARCHAR(70)")
        SQLInsert("UPDATE party SET mail =''")
        SQLInsert(" ALTER TABLE party ALTER COLUMN add1 VARCHAR(100)")
        SQLInsert("ALTER TABLE party ALTER COLUMN cont1 VARCHAR(100)")
        SQLInsert("ALTER TABLE party ALTER COLUMN cont2 VARCHAR(100)")
        SQLInsert("ALTER TABLE party ALTER COLUMN pname VARCHAR(50)")
        SQLInsert("ALTER TABLE party ALTER COLUMN bname VARCHAR(50)")
        SQLInsert("ALTER TABLE party ALTER COLUMN per_cont VARCHAR(50)")


        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt3()
    End Sub

    Private Sub updt3()
        ver_no = "1.0.3"
        Start1()
        SQLInsert("ALTER TABLE purch1 ADD godsl INT")
        SQLInsert("UPDATE purch1 SET godsl = 1")
        SQLInsert("ALTER TABLE purch2 ALTER COLUMN unt VARCHAR(6)")
        SQLInsert("ALTER TABLE untlnk ADD unt_cd INT")
        SQLInsert("ALTER TABLE party ADD cl_amt MONEY")
        SQLInsert("UPDATE party SET cl_amt = op_bal")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'setting_purch' AND type = 'U') BEGIN " & _
     "CREATE TABLE dbo.setting_purch(" & _
        "slno INT NOT NULL," & _
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


        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt4()
    End Sub
    
    Private Sub updt4()
        ver_no = "1.0.4"
        Start1()
        SQLInsert("EXEC sp_rename 'purch1.msf_tot', 'dv_tot', 'COLUMN'")
        SQLInsert("EXEC sp_rename 'purch1.to_amt', 'pur_amt', 'COLUMN'")
        SQLInsert("EXEC sp_rename 'purch2.pur_amt', 'it_tot', 'COLUMN'")
        SQLInsert("ALTER TABLE purch2 DROP COLUMN entax")
        SQLInsert("ALTER TABLE purch2 DROP COLUMN pfx")
        SQLInsert("ALTER TABLE purch1 DROP COLUMN pfx")

        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'msale' AND type = 'U')" & _
            "DROP TABLE msale")
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'msale1' AND type = 'U')" & _
           "DROP TABLE msale1")

        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'csale' AND type = 'U')" & _
          "DROP TABLE csale")
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'csale1' AND type = 'U')" & _
           "DROP TABLE csale1")

        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'schal1' AND type = 'U')" & _
          "DROP TABLE schal1")
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'schal2' AND type = 'U')" & _
           "DROP TABLE schal2")
        'Create csale1 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'csale1' AND type = 'U') BEGIN " & _
        "CREATE TABLE dbo.csale1(" & _
                        "bill_no INT NOT NULL PRIMARY KEY," & _
                        "bill_dt DATETIME NULL," & _
                        "bill_tp VARCHAR(1) NULL," & _
                        "bill_pfx VARCHAR(2) NULL," & _
                        "tin_bno BIGINT NULL," & _
                        "rin_bno BIGINT NULL," & _
                        "inv_tp VARCHAR(1) NULL," & _
                        "prt_code INT NULL," & _
                        "staf_sl INT NULL," & _
                        "godsl INT NULL," & _
                        "ch_no INT NULL," & _
                        "ch_dt DATETIME NULL," & _
                        "order_no INT NULL," & _
                        "order_dt DATETIME NULL," & _
                        "ref_no VARCHAR(10) NULL," & _
                        "trk_no VARCHAR(15) NULL," & _
                        "way_bno INT NULL," & _
                        "way_pfx VARCHAR(2) NULL," & _
                        "lr_no VARCHAR(15) NULL," & _
                        "lr_dt DATETIME NULL," & _
                        "sale_amt MONEY NULL," & _
                        "dis_amt MONEY NULL," & _
                        "chr_amt MONEY NULL," & _
                        "dv_tot MONEY NULL," & _
                        "adj_amt MONEY NULL," & _
                        "bl_name VARCHAR(70) NULL," & _
                        "add1 VARCHAR(50) NULL," & _
                        "mobno VARCHAR(15) NULL," & _
                        "tot_tto MONEY NULL," & _
                        "tot_vat MONEY NULL," & _
                        "used_by VARCHAR(1) NULL," & _
                        "rec_lock VARCHAR(1) NULL," & _
                        "nb VARCHAR(70) NULL," & _
                        "splnb VARCHAR(250) NULL," & _
                        "usr_ent INT NULL," & _
                        "ent_date DATETIME NULL," & _
                        "usr_mod INT NULL," & _
                        "mod_date DATETIME NULL" & _
        ") END")
        'Create csale2 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'csale2' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.csale2(" & _
                        "bill_sl INT NOT NULL PRIMARY KEY," & _
                        "bill_no INT NULL," & _
                        "bill_dt DATETIME NULL," & _
                        "bill_tp VARCHAR(1) NULL," & _
                        "tin_bno BIGINT NULL," & _
                        "rin_bno BIGINT NULL," & _
                        "prt_code INT NULL," & _
                        "ch_no INT NULL," & _
                        "ch_sl INT NULL," & _
                        "it_cd INT NULL," & _
                        "bat_cd INT NULL," & _
                        "godsl INT NULL," & _
                        "prd_tp VARCHAR(1) NULL," & _
                        "tr_tp VARCHAR(1) NULL," & _
                        "sale_qty MONEY NULL," & _
                        "free_qty MONEY NULL," & _
                        "mrp MONEY NULL," & _
                        "sale_rt MONEY NULL," & _
                        "it_tot MONEY NULL," & _
                        "disc_rt1 MONEY NULL," & _
                        "disc_rt2 MONEY NULL," & _
                        "disc_amt1 MONEY NULL," & _
                        "disc_amt2 MONEY NULL," & _
                        "oth_amt MONEY NULL," & _
                        "disc_amt MONEY NULL," & _
                        "ex_mrp MONEY NULL," & _
                        "bill_pfx VARCHAR(2) NULL," & _
                        "unt VARCHAR(6) NULL," & _
                        "mul_rt MONEY NULL," & _
                        "it_amt MONEY NULL," & _
                        "tto_amt MONEY NULL," & _
                        "tax_cd INT NULL," & _
                        "stax MONEY NULL," & _
                        "mrp_amt MONEY NULL," & _
                        "bit_type VARCHAR(1) NULL" & _
               ") END")

        'Create schal1 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'schal1' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.schal1(" & _
                       "sch_no INT NOT NULL PRIMARY KEY," & _
                       "sch_dt DATETIME NULL," & _
                       "prt_code INT NULL," & _
                       "ref_no VARCHAR(15) NULL," & _
                       "ref_dt DATETIME NULL," & _
                       "way_bno INT NULL," & _
                       "way_chr VARCHAR(3) NULL," & _
                       "trk_no VARCHAR(15) NULL," & _
                       "lr_no VARCHAR(15) NULL," & _
                       "lr_dt DATETIME NULL," & _
                       "sch_amt MONEY NULL," & _
                       "billed VARCHAR(1) NULL," & _
                       "usedby VARCHAR(1) NULL," & _
                       "pfx VARCHAR(2) NULL," & _
                       "rec_lock VARCHAR(1) NULL," & _
                       "nb VARCHAR(250) NULL," & _
                       "ord_no VARCHAR(25) NULL," & _
                       "ord_dt DATETIME NULL," & _
                       "god_sl INT NULL," & _
                       "usr_ent INT NULL," & _
                       "ent_date DATETIME NULL," & _
                       "usr_mod INT NULL," & _
                       "mod_date DATETIME NULL" & _
       ") END")
        'Create schal2 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'schal2' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.schal2(" & _
                        "sch_sl INT NOT NULL PRIMARY KEY," & _
                        "sch_no INT NULL," & _
                        "sch_dt DATETIME NULL," & _
                        "sch_tp VARCHAR(1) NULL," & _
                        "prd_tp VARCHAR(1) NULL," & _
                        "prt_code INT NULL," & _
                        "it_cd INT NULL," & _
                        "bat_cd INT NULL," & _
                        "sale_rt MONEY NULL," & _
                        "sch_qty MONEY NULL," & _
                        "free_qty MONEY NULL," & _
                        "bsch_qty MONEY NULL," & _
                        "bfree_qty MONEY NULL," & _
                        "unt VARCHAR(6) NULL," & _
                        "billed VARCHAR(1) NULL," & _
                        "mrp MONEY NULL," & _
                        "excl_mrp MONEY NULL," & _
                        "it_amt MONEY NULL," & _
                        "mul_rt MONEY NULL," & _
                        "rep_qty MONEY NULL," & _
                        "brep_qty MONEY NULL" & _
               ") END")
        'Create setting_sales Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'setting_sales' AND type = 'U') BEGIN " & _
            "CREATE TABLE dbo.setting_sales(" & _
                "slno INT NOT NULL," & _
                "req_mrp INT NOT NULL," & _
                "req_rate INT NOT NULL," & _
                "req_disc INT NOT NULL," & _
                "req_codis INT NOT NULL," & _
                "req_vat INT NOT NULL," & _
                "bill_rnd INT NOT NULL," & _
                "req_prnt INT NOT NULL," & _
                "req_chal INT NOT NULL," & _
                "rate_calc INT NOT NULL" & _
            ") END")
        SQLInsert("INSERT INTO setting_sales(slno,req_mrp,req_rate,req_disc,req_codis,req_vat,bill_rnd,req_prnt,req_chal,rate_calc) VALUES (1,0,0,0,0,0,0,0,0,0)")

        'Create setting_sales Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'print_salebill' AND type = 'U') BEGIN " & _
            "CREATE TABLE dbo.print_salebill(" & _
                  "slno INT NOT NULL," & _
                  "bill_no INT NULL," & _
                  "bill_dt DATETIME NULL," & _
                  "inv_no VARCHAR(70) NULL," & _
                  "inv_tp VARCHAR(70) NULL," & _
                  "ch_no INT NULL," & _
                  "ch_dt DATETIME NULL," & _
                  "order_no INT NULL," & _
                  "order_dt DATETIME NULL," & _
                  "ref_no VARCHAR(70) NULL," & _
                  "bl_name VARCHAR(70) NULL," & _
                  "add1 VARCHAR(70) NULL," & _
                  "mobno VARCHAR(70) NULL," & _
                  "regd_no VARCHAR(70) NULL," & _
                  "sold_by VARCHAR(70) NULL," & _
                  "it_nm VARCHAR(70) NULL," & _
                  "bat_no VARCHAR(70) NULL," & _
                  "srl_no VARCHAR(70) NULL," & _
                  "sale_qty MONEY NULL," & _
                  "free_qty MONEY NULL," & _
                  "mrp MONEY NULL," & _
                  "sale_rt MONEY NULL," & _
                  "it_tot MONEY NULL," & _
                  "disc_rt1 MONEY NULL," & _
                  "disc_rt2 MONEY NULL," & _
                  "disc_amt1 MONEY NULL," & _
                  "disc_amt2 MONEY NULL," & _
                  "oth_amt MONEY NULL," & _
                  "disc_amt MONEY NULL," & _
                  "unt VARCHAR(10) NULL," & _
                  "mul_rt MONEY NULL," & _
                  "it_amt MONEY NULL," & _
                  "tto_amt MONEY NULL," & _
                  "tax_nm VARCHAR(70) NULL," & _
                  "stax MONEY NULL," & _
                  "mrp_amt MONEY NULL," & _
                  "tot_tto MONEY NULL," & _
                  "tot_vat MONEY NULL," & _
                  "sale_amt MONEY NULL," & _
                  "dis_amt MONEY NULL," & _
                  "chr_amt MONEY NULL," & _
                  "dv_tot MONEY NULL," & _
                  "adj_amt MONEY NULL," & _
                  "nb VARCHAR(70) NULL," & _
                  "splnb VARCHAR(70) NULL," & _
                  "way_bno VARCHAR(70) NULL," & _
                  "inwords VARCHAR(70) NULL," & _
                  "usr_sl INT NULL," & _
                  "usr_id VARCHAR(70) NULL," & _
            ") END")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt5()
    End Sub

    Private Sub updt5()
        ver_no = "1.0.5"
        Start1()
        SQLInsert("ALTER TABLE print_salebill ALTER COLUMN inwords VARCHAR(200)")
        SQLInsert("ALTER TABLE print_salebill ADD manf_nm VARCHAR(70)")
        SQLInsert("ALTER TABLE manf ADD manf_snm VARCHAR(6)")
        SQLInsert("UPDATE manf SET manf_snm =LEFT(manf_nm,6)")
        SQLInsert("ALTER TABLE jrn1 DROP COLUMN ch_no")
        SQLInsert("ALTER TABLE jrn1 DROP COLUMN mr_no")
        SQLInsert("ALTER TABLE jrn2 DROP COLUMN mr_no")
        SQLInsert("ALTER TABLE company ADD regd_no VARCHAR(50),regd_dt DATETIME")
        SQLInsert("UPDATE company SET regd_no ='',regd_dt = '" & sys_date & "'")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt6()
    End Sub

    Private Sub updt6()
        ver_no = "1.0.6"
        Start1()
        'Create porder1 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'porder1' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.porder1(" & _
                        "po_no INT NOT NULL PRIMARY KEY," & _
                        "po_dt DATETIME NULL," & _
                        "priority VARCHAR(1) NULL," & _
                        "ref_no VARCHAR(20) NULL," & _
                        "prt_code INT NULL," & _
                        "deliver_dt DATETIME NULL," & _
                        "gr_tot MONEY NULL," & _
                        "nb1 VARCHAR(70) NULL," & _
                        "nb2 VARCHAR(70) NULL," & _
                        "usr_ent INT NULL," & _
                        "ent_date DATETIME NULL," & _
                        "usr_mod INT NULL," & _
                        "mod_date DATETIME NULL," & _
                        "rec_lock VARCHAR(1) NULL," & _
                        "used_by VARCHAR(1) NULL" & _
               ") END")

        'Create porder2 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'porder2' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.porder2(" & _
                        "po_sl INT NOT NULL PRIMARY KEY," & _
                        "po_no INT NULL," & _
                        "po_dt DATETIME NULL," & _
                        "prt_code INT NULL," & _
                        "manf_cd INT NULL," & _
                        "it_cd INT NULL," & _
                        "po_qty MONEY NULL," & _
                        "bpo_qty MONEY NULL," & _
                        "po_free MONEY NULL," & _
                        "bpo_free MONEY NULL," & _
                        "po_rate MONEY NULL," & _
                        "po_mrp MONEY NULL," & _
                        "po_amt MONEY NULL," & _
                        "po_unit VARCHAR(4) NULL," & _
                        "mul_rt MONEY NULL," & _
                        "billed VARCHAR(1) NULL" & _
               ") END")

        'Create print_order Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'print_order' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.print_order(" & _
                        "prnt_no INT NULL," & _
                        "supl_nm VARCHAR(40) NULL," & _
                        "add1 VARCHAR(100) NULL," & _
                        "cont1 VARCHAR(12) NULL," & _
                        "po_no INT NULL," & _
                        "ordr_dt DATETIME NULL," & _
                        "delv_dt DATETIME NULL," & _
                        "manf_nm VARCHAR(40) NULL," & _
                        "prod_nm VARCHAR(40) NULL," & _
                        "po_qty MONEY NULL," & _
                        "nb VARCHAR(50) NULL," & _
                        "usr_sl INT NULL," & _
                        "gr_tot MONEY NULL," & _
                        "po_rate MONEY NULL," & _
                        "po_amt MONEY NULL," & _
                        "unt VARCHAR(6) NULL," & _
                        "mrp MONEY NULL," & _
                        "inword VARCHAR(70) NULL" & _
               ") END")


        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt7()
    End Sub


    Private Sub updt7()
        ver_no = "1.0.7"
        Start1()
        'Create pchal_slno
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'pchal_slno' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.pchal_slno(" & _
                        "sl_slno int NULL," & _
                        "it_cd int NULL," & _
                        "pch_no int NULL," & _
                        "pch_sl int NULL," & _
                        "billed VARCHAR(1) NULL," & _
                        "pur_no INT," & _
                        "pur_sl INT" & _
               ") END")
        'Create schal_slno
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'schal_slno' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.schal_slno(" & _
                        "sl_slno int NULL," & _
                        "it_cd int NULL," & _
                        "sch_no int NULL," & _
                        "sch_sl int NULL," & _
                        "billed VARCHAR(1) NULL," & _
                        "bill_no INT," & _
                        "bill_sl INT" & _
               ") END")

        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'pchal1' AND type = 'U')" & _
        "DROP TABLE pchal1")
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'pchal2' AND type = 'U')" & _
           "DROP TABLE pchal2")

        'Create pchal1 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'pchal1' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.pchal1(" & _
                       "pch_no INT NOT NULL PRIMARY KEY," & _
                       "pch_dt DATETIME NULL," & _
                       "prt_code INT NULL," & _
                       "ref_no VARCHAR(15) NULL," & _
                       "ref_dt DATETIME NULL," & _
                       "way_bno INT NULL," & _
                       "way_chr VARCHAR(3) NULL," & _
                       "trk_no VARCHAR(15) NULL," & _
                       "lr_no VARCHAR(15) NULL," & _
                       "lr_dt DATETIME NULL," & _
                       "pch_amt MONEY NULL," & _
                       "billed VARCHAR(1) NULL," & _
                       "usedby VARCHAR(1) NULL," & _
                       "rec_lock VARCHAR(1) NULL," & _
                       "nb VARCHAR(250) NULL," & _
                       "ord_no VARCHAR(25) NULL," & _
                       "ord_dt DATETIME NULL," & _
                       "god_sl INT NULL," & _
                       "usr_ent INT NULL," & _
                       "ent_date DATETIME NULL," & _
                       "usr_mod INT NULL," & _
                       "mod_date DATETIME NULL" & _
       ") END")
        'Create pchal2 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'pchal2' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.pchal2(" & _
                        "pch_sl INT NOT NULL PRIMARY KEY," & _
                        "pch_no INT NULL," & _
                        "pch_dt DATETIME NULL," & _
                        "pch_tp VARCHAR(1) NULL," & _
                        "prd_tp VARCHAR(1) NULL," & _
                        "prt_code INT NULL," & _
                        "it_cd INT NULL," & _
                        "bat_cd INT NULL," & _
                        "pur_rt MONEY NULL," & _
                        "pch_qty MONEY NULL," & _
                        "free_qty MONEY NULL," & _
                        "bpch_qty MONEY NULL," & _
                        "bfree_qty MONEY NULL," & _
                        "unt VARCHAR(6) NULL," & _
                        "billed VARCHAR(1) NULL," & _
                        "mrp MONEY NULL," & _
                        "excl_mrp MONEY NULL," & _
                        "it_amt MONEY NULL," & _
                        "mul_rt MONEY NULL," & _
                        "rep_qty MONEY NULL," & _
                        "brep_qty MONEY NULL" & _
               ") END")

        'Create setting_pchal Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'setting_pchal' AND type = 'U') BEGIN " & _
            "CREATE TABLE dbo.setting_pchal(" & _
                "slno INT NOT NULL," & _
                "req_mrp INT NOT NULL," & _
                "req_rate INT NOT NULL," & _
                "req_mrprt INT NOT NULL," & _
                "rate_calc INT NOT NULL" & _
            ") END")
        SQLInsert("INSERT INTO setting_pchal(slno,req_mrp,req_rate,req_mrprt,rate_calc) VALUES (1,0,0,0,0)")

        'Create setting_schal Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'setting_schal' AND type = 'U') BEGIN " & _
            "CREATE TABLE dbo.setting_schal(" & _
                "slno INT NOT NULL," & _
                "req_mrp INT NOT NULL," & _
                "req_rate INT NOT NULL," & _
                "req_mrprt INT NOT NULL," & _
                "rate_calc INT NOT NULL" & _
            ") END")
        SQLInsert("INSERT INTO setting_schal(slno,req_mrp,req_rate,req_mrprt,rate_calc) VALUES (1,0,0,0,0)")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt8()
    End Sub

    Private Sub updt8()
        ver_no = "1.0.8"
        Start1()
        SQLInsert("ALTER TABLE purch1 ALTER COLUMN inv_no VARCHAR(25)")
        SQLInsert("ALTER TABLE pret1 ALTER COLUMN ref_no VARCHAR(25)")
        SQLInsert("EXEC sp_rename 'pret_slno.r_no', 'pret_no', 'COLUMN'")
        SQLInsert("EXEC sp_rename 'pret_slno.r_sl', 'pret_sl', 'COLUMN'")
        SQLInsert("EXEC sp_rename 'sret_slno.r_no', 'sret_no', 'COLUMN'")
        SQLInsert("EXEC sp_rename 'sret_slno.r_sl', 'sret_sl', 'COLUMN'")
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'rejin1' AND type = 'U')" & _
                "DROP TABLE rejin1")
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'rejin2' AND type = 'U')" & _
           "DROP TABLE rejin2")
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'rejout1' AND type = 'U')" & _
               "DROP TABLE rejout1")
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'rejout2' AND type = 'U')" & _
           "DROP TABLE rejout2")
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'pret1' AND type = 'U')" & _
          "DROP TABLE pret1")
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'pret2' AND type = 'U')" & _
           "DROP TABLE pret2")

        'Create pret1 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'pret1' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.pret1(" & _
                       "pret_no INT NOT NULL PRIMARY KEY," & _
                       "pret_dt DATETIME NULL," & _
                       "prt_code INT NULL," & _
                       "pret_type VARCHAR(1) NULL," & _
                       "chal_no VARCHAR(10) NULL," & _
                       "chal_dt DATETIME NULL," & _
                       "ref_no VARCHAR(25) NULL," & _
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
        'Create pret2 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'pret2' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.pret2(" & _
                       "pret_sl INT NOT NULL PRIMARY KEY," & _
                       "pret_no INT NULL," & _
                       "pret_dt DATETIME NULL," & _
                       "prt_code INT NULL," & _
                       "it_cd INT NULL," & _
                       "bat_cd INT NULL," & _
                       "pur_rt MONEY NULL," & _
                       "pret_qty MONEY NULL," & _
                       "free_qty MONEY NULL," & _
                       "it_amt MONEY NULL," & _
                       "tto_amt MONEY NULL," & _
                       "tax_cd MONEY NULL," & _
                       "oth_amt MONEY NULL," & _
                       "disc_amt MONEY NULL," & _
                       "it_tot MONEY NULL," & _
                       "stax MONEY NULL," & _
                       "entax MONEY NULL," & _
                       "mrp MONEY NULL," & _
                       "ex_mrp MONEY NULL," & _
                       "prd_tp VARCHAR(1) NULL," & _
                       "tr_tp VARCHAR(1) NULL," & _
                       "unt VARCHAR(4) NULL," & _
                       "mul_rt MONEY NULL," & _
                       "disc_rt1 MONEY NULL," & _
                       "disc_rt2 MONEY NULL," & _
                       "disc_amt1 MONEY NULL," & _
                       "disc_amt2 MONEY NULL," & _
                       "mrp_amt MONEY NULL," & _
                       "bit_type VARCHAR(1) NULL" & _
       ") END")
        'Create sret1 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'sret1' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.sret1(" & _
                       "sret_no INT NOT NULL PRIMARY KEY," & _
                       "sret_dt DATETIME NULL," & _
                       "prt_code INT NULL," & _
                       "sret_type VARCHAR(1) NULL," & _
                       "chal_no VARCHAR(10) NULL," & _
                       "chal_dt DATETIME NULL," & _
                       "ref_no VARCHAR(25) NULL," & _
                       "ref_dt DATETIME NULL," & _
                       "way_bno INT NULL," & _
                       "trk_no VARCHAR(15) NULL," & _
                       "sret_amt MONEY NULL," & _
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
        'Create sret2 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'sret2' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.sret2(" & _
                       "sret_sl INT NOT NULL PRIMARY KEY," & _
                       "sret_no INT NULL," & _
                       "sret_dt DATETIME NULL," & _
                       "prt_code INT NULL," & _
                       "it_cd INT NULL," & _
                       "bat_cd INT NULL," & _
                       "sale_rt MONEY NULL," & _
                       "sret_qty MONEY NULL," & _
                       "free_qty MONEY NULL," & _
                       "it_amt MONEY NULL," & _
                       "tto_amt MONEY NULL," & _
                       "tax_cd MONEY NULL," & _
                       "oth_amt MONEY NULL," & _
                       "disc_amt MONEY NULL," & _
                       "it_tot MONEY NULL," & _
                       "stax MONEY NULL," & _
                       "mrp MONEY NULL," & _
                       "ex_mrp MONEY NULL," & _
                       "prd_tp VARCHAR(1) NULL," & _
                       "tr_tp VARCHAR(1) NULL," & _
                       "unt VARCHAR(4) NULL," & _
                       "mul_rt MONEY NULL," & _
                       "disc_rt1 MONEY NULL," & _
                       "disc_rt2 MONEY NULL," & _
                       "disc_amt1 MONEY NULL," & _
                       "disc_amt2 MONEY NULL," & _
                       "mrp_amt MONEY NULL," & _
                       "bit_type VARCHAR(1) NULL" & _
       ") END")

        'Create setting_pret Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'setting_pret' AND type = 'U') BEGIN " & _
     "CREATE TABLE dbo.setting_pret(" & _
        "slno INT NOT NULL," & _
        "req_mrp INT NOT NULL," & _
        "req_rate INT NOT NULL," & _
        "req_disc INT NOT NULL," & _
        "req_codis INT NOT NULL," & _
        "req_vat INT NOT NULL," & _
        "bill_rnd INT NOT NULL," & _
        "req_prnt INT NOT NULL," & _
        "rate_calc INT NOT NULL" & _
     ") END")

        SQLInsert("INSERT INTO setting_pret(slno,req_mrp,req_rate,req_disc,req_codis,req_vat,bill_rnd,req_prnt,rate_calc) VALUES (1,0,0,0,0,0,0,0,0)")

        'Create setting_sret Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'setting_sret' AND type = 'U') BEGIN " & _
     "CREATE TABLE dbo.setting_sret(" & _
        "slno INT NOT NULL," & _
        "req_mrp INT NOT NULL," & _
        "req_rate INT NOT NULL," & _
        "req_disc INT NOT NULL," & _
        "req_codis INT NOT NULL," & _
        "req_vat INT NOT NULL," & _
        "bill_rnd INT NOT NULL," & _
        "req_prnt INT NOT NULL," & _
        "rate_calc INT NOT NULL" & _
     ") END")

        SQLInsert("INSERT INTO setting_sret(slno,req_mrp,req_rate,req_disc,req_codis,req_vat,bill_rnd,req_prnt,rate_calc) VALUES (1,0,0,0,0,0,0,0,0)")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt9()
    End Sub

    Private Sub updt9()
        ver_no = "1.0.9"
        Start1()
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'ig1' AND type = 'U')" & _
              "DROP TABLE ig1")
        SQLInsert("IF EXISTS (SELECT * FROM sys.tables WHERE name = 'ig2' AND type = 'U')" & _
           "DROP TABLE ig2")
        'Create gen_setting Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'gen_setting' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.gen_setting(" & _
                       "slno INT NOT NULL PRIMARY KEY," & _
                       "print_bill INT NULL," & _
                       "print_schal INT NULL," & _
                       "print_sret INT NULL," & _
                       "print_PO INT NULL," & _
                       "print_pret INT NULL," & _
                       "print_mr INT NULL," & _
                       "print_pvouc INT NULL," & _
                       "print_rvouc INT NULL," & _
                       "print_cntbl INT NULL," & _
                       "copy_bill INT NULL," & _
                       "copy_schal INT NULL," & _
                       "copy_sret INT NULL," & _
                       "copy_PO INT NULL," & _
                       "copy_pret INT NULL," & _
                       "copy_mr INT NULL," & _
                       "copy_pvouc INT NULL," & _
                       "copy_rvouc INT NULL," & _
                       "copy_cntbl INT NULL," & _
                       "exp_alrt VARCHAR(1) NULL," & _
                       "exp_days INT NULL," & _
                       "start_backup VARCHAR(1) NULL," & _
                       "backup_days INT NULL," & _
                       "backup_path VARCHAR(150) NULL," & _
                       "pf_per MONEY NULL," & _
                       "esic_per MONEY NULL," & _
                       "oth_deduct MONEY NULL," & _
                       "backup_rem INT NULL," & _
                       "bday_rem INT NULL," & _
                       "anvr_rem INT NULL," & _
                       "due_rem INT NULL," & _
                       "srvr_gsm INT NULL," & _
                       "sms_srvr VARCHAR(100) NULL," & _
                       "sms_id VARCHAR(50) NULL," & _
                       "sms_pwd VARCHAR(50) NULL," & _
                       "sender_id VARCHAR(50) NULL," & _
                       "port_no INT NULL," & _
                       "smtp_srvr VARCHAR(100) NULL," & _
                       "mail_id VARCHAR(50) NULL," & _
                       "mail_pwd VARCHAR(50) NULL," & _
                       "bill_sms INT NULL," & _
                       "due_sms INT NULL," & _
                       "pay_sms INT NULL," & _
                       "rec_sms INT NULL," & _
       ") END")
        'Create ig1 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ig1' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.ig1(" & _
                       "ig_no INT NOT NULL PRIMARY KEY," & _
                       "ig_dt DATETIME NULL," & _
                       "ig_ref VARCHAR(10) NULL," & _
                       "gdsl_frm INT NULL," & _
                       "gdsl_to INT NULL," & _
                       "usr_ent INT NULL," & _
                       "ent_date DATETIME NULL," & _
                       "usr_mod INT NULL," & _
                       "mod_date DATETIME NULL," & _
                       "usedby VARCHAR(1) NULL," & _
                       "pfx VARCHAR(2) NULL," & _
                       "rec_lock VARCHAR(1) NULL," & _
                       "ref_dt DATETIME NULL," & _
       ") END")
        'Create ig2 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ig2' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.ig2(" & _
                      "ig_sl INT NOT NULL PRIMARY KEY," & _
                       "ig_no INT NULL," & _
                       "ig_dt DATETIME NULL," & _
                       "gdsl_frm INT NULL," & _
                       "gdsl_to INT NULL," & _
                       "it_cd INT NULL," & _
                       "it_qty MONEY NULL," & _
                       "unt VARCHAR(4) NULL," & _
                       "mul_rt MONEY NULL," & _
                       "pfx VARCHAR(2) NULL," & _
       ") END")
        'Create iss1 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'iss1' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.iss1(" & _
                       "iss_no INT NOT NULL PRIMARY KEY," & _
                       "iss_dt DATETIME NULL," & _
                       "iss_to VARCHAR(1) NULL," & _
                       "ref_no VARCHAR(15) NULL," & _
                       "staf_sl INT NULL," & _
                       "godsl INT NULL," & _
                       "tot_val MONEY NULL," & _
                       "nb VARCHAR(70) NULL," & _
                       "usr_ent INT NULL," & _
                       "ent_date DATETIME NULL," & _
                       "usr_mod INT NULL," & _
                       "mod_date DATETIME NULL," & _
                       "rec_lock VARCHAR(1) NULL," & _
                       "used_by VARCHAR(1) NULL," & _
                       "veh_cd INT NULL" & _
       ") END")

        'Create iss2 Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'iss2' AND type = 'U') BEGIN " & _
     "CREATE TABLE dbo.iss2(" & _
       "iss_sl INT NOT NULL PRIMARY KEY," & _
                       "iss_no INT NULL," & _
                       "iss_dt DATETIME NULL," & _
                       "iss_to VARCHAR(1) NULL," & _
                       "staf_sl INT NULL," & _
                       "it_cd INT NULL," & _
                       "qty MONEY NULL," & _
                       "unt VARCHAR(4) NULL," & _
                       "rate MONEY NULL," & _
                       "amt MONEY NULL," & _
                       "refund VARCHAR(1) NULL," & _
                       "ret_dt DATETIME NULL," & _
                       "veh_cd INT NULL," & _
                       "manf_cd INT NULL," & _
                       "mul_rt MONEY NULL" & _
     ") END")
        SQLInsert("INSERT INTO gen_setting(slno,print_bill,print_schal,print_sret,print_PO,print_pret,print_mr,print_pvouc,print_rvouc,print_cntbl,copy_bill,copy_schal,copy_sret,copy_PO,copy_pret,copy_mr,copy_pvouc,copy_rvouc,copy_cntbl,exp_alrt,exp_days,start_backup,backup_days,backup_path,pf_per,esic_per,oth_deduct,backup_rem,bday_rem,anvr_rem,due_rem,srvr_gsm,sms_srvr,sms_id,sms_pwd,sender_id,port_no,smtp_srvr,mail_id,mail_pwd,bill_sms,due_sms,pay_sms,rec_sms) VALUES (1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,'N',0,'N',0,'" & My.Application.Info.DirectoryPath & "\Backup" & "',0,0,0,0,0,0,0,0,'','','','',587,'smtp.gmail.com','','',0,0,0,0)")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt10()
    End Sub

    Private Sub updt10()
        ver_no = "1.1.0"
        Start1()
        'Create drvmst Table
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'drvmst' AND type = 'U') BEGIN " & _
       "CREATE TABLE dbo.drvmst(" & _
                        "drv_cd INT NOT NULL PRIMARY KEY," & _
                        "drv_nm VARCHAR(50) NULL," & _
                        "drv_snm VARCHAR(10) NULL," & _
                        "doj DATETIME NULL," & _
                        "dob DATETIME NULL," & _
                        "veh_cd INT NULL," & _
                        "add1 VARCHAR(100) NULL," & _
                        "mob_no VARCHAR(15) NULL," & _
                        "rec_lock VARCHAR(1) NULL" & _
       ") END")
        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt11()
    End Sub

    Private Sub updt11()
        ver_no = "1.1.1"
        Start1()

        SQLInsert("ALTER TABLE csale1 ADD drv_cd INT")
        SQLInsert("UPDATE csale1 SET drv_cd = 0")
        SQLInsert("ALTER TABLE print_salebill ADD drv_nm VARCHAR(50),drv_mob VARCHAR(15)")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt12()
    End Sub

    Private Sub updt12()
        ver_no = "1.1.2"
        Start1()

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



        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt13()
    End Sub

    Private Sub updt13()
        ver_no = "1.1.3"
        Start1()

        SQLInsert("ALTER TABLE print_salebill ALTER COLUMN srl_no VARCHAR(500)")
       

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt14()
    End Sub

    Private Sub updt14()
        ver_no = "1.1.4"
        Start1()
        SQLInsert("ALTER TABLE company ADD co_pfx VARCHAR(20),co_sfx VARCHAR(20)")
        SQLInsert("UPDATE company SET co_pfx = '',co_sfx = ''")

        SQLInsert("ALTER TABLE item ADD hsn_code VARCHAR(15)")
        SQLInsert("UPDATE item SET hsn_code = ''")

        SQLInsert("ALTER TABLE purch1 ADD cgsttot MONEY,sgsttot MONEY,igsttot MONEY")
        SQLInsert("UPDATE purch1 SET cgsttot =0,sgsttot = 0,igsttot =0 ")
        SQLInsert("ALTER TABLE purch2 ADD cgstper MONEY,cgstamt MONEY,sgstper MONEY,sgstamt MONEY,igstper MONEY,igstamt MONEY")
        SQLInsert("UPDATE purch2 SET cgstamt = stax,sgstamt =0,igstamt = 0,cgstper = 0,sgstper = 0,igstper = 0")

        SQLInsert("ALTER TABLE csale1 ADD cgsttot MONEY,sgsttot MONEY,igsttot MONEY")
        SQLInsert("UPDATE csale1 SET cgsttot =tot_vat,sgsttot = 0,igsttot =0 ")
        SQLInsert("ALTER TABLE csale2 ADD cgstper MONEY,cgstamt MONEY,sgstper MONEY,sgstamt MONEY,igstper MONEY,igstamt MONEY")
        SQLInsert("UPDATE csale2 SET cgstamt = stax,sgstamt =0,igstamt = 0,cgstper = 0,sgstper = 0,igstper = 0")


        SQLInsert("ALTER TABLE print_salebill ADD hsn_code VARCHAR(20),cgstper MONEY,cgstamt MONEY,sgstper MONEY,sgstamt MONEY,igstper MONEY,igstamt MONEY,cgsttot MONEY,sgsttot MONEY,igsttot MONEY")


        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt15()
    End Sub

    Private Sub updt15()
        ver_no = "1.1.5"
        Start1()
        SQLInsert("ALTER TABLE csale1 ADD pay_dt DATETIME")
        SQLInsert("UPDATE csale1 SET pay_dt = bill_dt")
        SQLInsert("ALTER TABLE csale1 ALTER COLUMN order_no VARCHAR(15)")
        SQLInsert("ALTER TABLE csale2 ADD item_tp VARCHAR(1)")
        SQLInsert("UPDATE csale2 SET item_tp = '1'")

        SQLInsert("ALTER TABLE print_salebill ADD ref_dt DATETIME")
        SQLInsert("ALTER TABLE print_salebill ALTER COLUMN order_no VARCHAR(15)")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt16()
    End Sub

    Private Sub updt16()
        ver_no = "1.1.6"
        Start1()
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'setting_service' AND type = 'U') BEGIN " & _
             "CREATE TABLE dbo.setting_service(" & _
                     "slno INT NOT NULL PRIMARY KEY," & _
                     "req_rate int NOT NULL," & _
                     "req_disc int NOT NULL," & _
                     "req_vat int NOT NULL," & _
                     "bill_rnd int NOT NULL," & _
                     "req_prnt int NOT NULL" & _
              ") END")
        SQLInsert("INSERT INTO setting_service(slno,req_rate,req_disc,req_vat,bill_rnd,req_prnt) VALUES (1,0,0,0,1,1)")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'serv1' AND type = 'U') BEGIN " & _
            "CREATE TABLE dbo.serv1(" & _
                    "srv_no INT NOT NULL PRIMARY KEY," & _
                    "srv_dt DATETIME," & _
                    "bill_tp VARCHAR(1)," & _
                    "srv_pfx VARCHAR(3)," & _
                    "inv_bno BIGINT," & _
                    "inv_tp VARCHAR(1)," & _
                    "prt_code INT," & _
                    "staf_sl INT," & _
                    "order_no VARCHAR(15)," & _
                    "order_dt DATETIME," & _
                    "ref_no VARCHAR(10)," & _
                    "trk_no VARCHAR(15)," & _
                    "way_bno INT," & _
                    "way_pfx VARCHAR(4)," & _
                    "lr_no VARCHAR(15)," & _
                    "lr_dt DATETIME," & _
                    "srv_amt MONEY," & _
                    "dis_amt MONEY," & _
                    "chr_amt MONEY," & _
                    "dv_tot MONEY," & _
                    "adj_amt MONEY," & _
                    "cgsttot MONEY," & _
                    "sgsttot MONEY," & _
                    "igsttot MONEY," & _
                    "bl_name VARCHAR(70)," & _
                    "add1 VARCHAR(50)," & _
                    "mobno VARCHAR(15)," & _
                    "tot_tto MONEY," & _
                    "tot_vat MONEY," & _
                    "used_by VARCHAR(1)," & _
                    "nb VARCHAR(70)," & _
                    "splnb VARCHAR(250)," & _
                    "drv_cd INT," & _
                    "pay_dt DATETIME," & _
                    "usr_ent INT," & _
                    "ent_date DATETIME," & _
                    "usr_mod INT," & _
                    "mod_date DATETIME," & _
                    "rec_lock VARCHAR(1)" & _
             ") END")

        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'serv2' AND type = 'U') BEGIN " & _
           "CREATE TABLE dbo.serv2(" & _
                   "srv_sl INT NOT NULL PRIMARY KEY," & _
                   "srv_no INT NOT NULL," & _
                   "srv_dt DATETIME," & _
                   "bill_tp VARCHAR(1)," & _
                   "srv_pfx VARCHAR(3)," & _
                   "inv_bno BIGINT," & _
                   "prt_code INT," & _
                   "it_cd INT," & _
                   "srv_qty MONEY," & _
                   "srv_rt MONEY, " & _
                   "it_tot MONEY," & _
                   "disc_amt MONEY," & _
                   "chrg_amt MONEY," & _
                   "unt VARCHAR(6), " & _
                   "mul_rt MONEY," & _
                   "it_amt MONEY," & _
                   "tax_cd INT," & _
                   "stax MONEY," & _
                   "cgstper	MONEY," & _
                   "cgstamt	MONEY," & _
                   "sgstper	MONEY," & _
                   "sgstamt	MONEY," & _
                   "igstper MONEY, " & _
                   "igstamt MONEY " & _
              ") END")
        SQLInsert("IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'print_servbill' AND type = 'U') BEGIN " & _
           "CREATE TABLE dbo.print_servbill(" & _
                   "slno INT NOT NULL," & _
                   "srv_no INT NULL," & _
                   "srv_dt DATETIME NULL," & _
                   "inv_no VARCHAR(70) NULL," & _
                   "inv_tp VARCHAR(70) NULL," & _
                   "order_no VARCHAR(15) NULL," & _
                   "order_dt DATETIME NULL," & _
                   "ref_no VARCHAR(70) NULL," & _
                   "ref_dt DATETIME NULL," & _
                   "bl_name VARCHAR(70) NULL," & _
                   "add1 VARCHAR(70) NULL," & _
                   "mobno VARCHAR(70) NULL," & _
                   "regd_no VARCHAR(70) NULL," & _
                   "sold_by VARCHAR(70) NULL," & _
                   "it_nm VARCHAR(70) NULL," & _
                   "srv_qty MONEY NULL," & _
                   "mrp MONEY NULL," & _
                   "srv_rt MONEY NULL," & _
                   "it_tot MONEY NULL," & _
                   "oth_amt MONEY NULL," & _
                   "disc_amt MONEY NULL," & _
                   "unt VARCHAR(10) NULL," & _
                   "mul_rt MONEY NULL," & _
                   "it_amt MONEY NULL," & _
                   "tto_amt MONEY NULL," & _
                   "tax_nm VARCHAR(70) NULL," & _
                   "stax MONEY NULL," & _
                   "mrp_amt MONEY NULL," & _
                   "tot_tto MONEY NULL," & _
                   "tot_vat MONEY NULL," & _
                   "srv_amt MONEY NULL," & _
                   "dis_amt MONEY NULL," & _
                   "chr_amt MONEY NULL," & _
                   "dv_tot MONEY NULL," & _
                   "adj_amt MONEY NULL," & _
                   "nb VARCHAR(70) NULL," & _
                   "splnb VARCHAR(70) NULL," & _
                   "way_bno VARCHAR(70) NULL," & _
                   "inwords VARCHAR(200) NULL," & _
                   "usr_sl INT NULL," & _
                   "usr_id VARCHAR(70) NULL," & _
                   "manf_nm VARCHAR(70) NULL," & _
                   "drv_nm VARCHAR(50) NULL," & _
                   "drv_mob VARCHAR(15) NULL," & _
                   "hsn_code VARCHAR(20) NULL," & _
                   "cgstper MONEY NULL," & _
                   "cgstamt MONEY NULL," & _
                   "sgstper MONEY NULL," & _
                   "sgstamt MONEY NULL," & _
                   "igstper MONEY NULL," & _
                   "igstamt MONEY NULL," & _
                   "cgsttot MONEY NULL," & _
                   "sgsttot MONEY NULL," & _
                   "igsttot MONEY NULL" & _
              ") END")

        SQLInsert("ALTER TABLE gen_setting ADD print_srvbl INT,copy_srvbl INT")
        SQLInsert("UPDATE gen_setting SET print_srvbl = 1,copy_srvbl = 1")

        SQLInsert("UPDATE company SET ver_no='" & ver_no & "'")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call updt17()
    End Sub

    Private Sub updt17()
        ver_no = "1.1.7"
        Start1()

        SQLInsert("ALTER TABLE company ADD bank VARCHAR(100)")

       
        SQLInsert("UPDATE company SET ver_no='" & ver_no & "',bank=''")
        Close1()
        MessageBox.Show("Software Version Updated To " & ver_no & "." & _
                  vbCrLf & "Please Close The Software To Activate The Update Version.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End
    End Sub
End Module
