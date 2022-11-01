<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpayvouc
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblamt = New System.Windows.Forms.Label
        Me.cmbpname = New System.Windows.Forms.ComboBox
        Me.cmbcollby = New System.Windows.Forms.ComboBox
        Me.cmbrecfrm = New System.Windows.Forms.ComboBox
        Me.lbldipobal = New System.Windows.Forms.Label
        Me.lblprtbal = New System.Windows.Forms.Label
        Me.txtcollcd = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbdesc1 = New System.Windows.Forms.ComboBox
        Me.cmbdesc2 = New System.Windows.Forms.ComboBox
        Me.cmbdesc3 = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.lbladdress1 = New System.Windows.Forms.Label
        Me.txtbycd = New System.Windows.Forms.TextBox
        Me.txtprtcd = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btns3 = New System.Windows.Forms.Button
        Me.btns2 = New System.Windows.Forms.Button
        Me.vdt = New System.Windows.Forms.DateTimePicker
        Me.btns1 = New System.Windows.Forms.Button
        Me.chckclrdata = New System.Windows.Forms.CheckBox
        Me.cmbrcmode = New System.Windows.Forms.ComboBox
        Me.txtcshinhand = New System.Windows.Forms.TextBox
        Me.txtamt = New System.Windows.Forms.TextBox
        Me.txtvno = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbladdress = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdview = New System.Windows.Forms.Button
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dv = New System.Windows.Forms.DataGridView
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenuview = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenusearch = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuprint = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenuexpert = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightCyan
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblamt)
        Me.Panel1.Controls.Add(Me.cmbpname)
        Me.Panel1.Controls.Add(Me.cmbcollby)
        Me.Panel1.Controls.Add(Me.cmbrecfrm)
        Me.Panel1.Controls.Add(Me.lbldipobal)
        Me.Panel1.Controls.Add(Me.lblprtbal)
        Me.Panel1.Controls.Add(Me.txtcollcd)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cmbdesc1)
        Me.Panel1.Controls.Add(Me.cmbdesc2)
        Me.Panel1.Controls.Add(Me.cmbdesc3)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.lbladdress1)
        Me.Panel1.Controls.Add(Me.txtbycd)
        Me.Panel1.Controls.Add(Me.txtprtcd)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btns3)
        Me.Panel1.Controls.Add(Me.btns2)
        Me.Panel1.Controls.Add(Me.vdt)
        Me.Panel1.Controls.Add(Me.btns1)
        Me.Panel1.Controls.Add(Me.chckclrdata)
        Me.Panel1.Controls.Add(Me.cmbrcmode)
        Me.Panel1.Controls.Add(Me.txtcshinhand)
        Me.Panel1.Controls.Add(Me.txtamt)
        Me.Panel1.Controls.Add(Me.txtvno)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lbladdress)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(549, 450)
        Me.Panel1.TabIndex = 0
        '
        'lblamt
        '
        Me.lblamt.AutoSize = True
        Me.lblamt.Location = New System.Drawing.Point(38, 354)
        Me.lblamt.Name = "lblamt"
        Me.lblamt.Size = New System.Drawing.Size(35, 13)
        Me.lblamt.TabIndex = 369
        Me.lblamt.Text = "0.00"
        Me.lblamt.Visible = False
        '
        'cmbpname
        '
        Me.cmbpname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbpname.FormattingEnabled = True
        Me.cmbpname.Location = New System.Drawing.Point(164, 78)
        Me.cmbpname.Name = "cmbpname"
        Me.cmbpname.Size = New System.Drawing.Size(317, 21)
        Me.cmbpname.TabIndex = 2
        '
        'cmbcollby
        '
        Me.cmbcollby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbcollby.FormattingEnabled = True
        Me.cmbcollby.Location = New System.Drawing.Point(165, 145)
        Me.cmbcollby.Name = "cmbcollby"
        Me.cmbcollby.Size = New System.Drawing.Size(317, 21)
        Me.cmbcollby.TabIndex = 3
        '
        'cmbrecfrm
        '
        Me.cmbrecfrm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbrecfrm.FormattingEnabled = True
        Me.cmbrecfrm.Location = New System.Drawing.Point(164, 220)
        Me.cmbrecfrm.Name = "cmbrecfrm"
        Me.cmbrecfrm.Size = New System.Drawing.Size(317, 21)
        Me.cmbrecfrm.TabIndex = 7
        '
        'lbldipobal
        '
        Me.lbldipobal.AutoSize = True
        Me.lbldipobal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldipobal.ForeColor = System.Drawing.Color.Red
        Me.lbldipobal.Location = New System.Drawing.Point(377, 245)
        Me.lbldipobal.Name = "lbldipobal"
        Me.lbldipobal.Size = New System.Drawing.Size(46, 14)
        Me.lbldipobal.TabIndex = 368
        Me.lbldipobal.Text = "0.00 Cr."
        Me.lbldipobal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblprtbal
        '
        Me.lblprtbal.AutoSize = True
        Me.lblprtbal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprtbal.ForeColor = System.Drawing.Color.Red
        Me.lblprtbal.Location = New System.Drawing.Point(377, 101)
        Me.lblprtbal.Name = "lblprtbal"
        Me.lblprtbal.Size = New System.Drawing.Size(46, 14)
        Me.lblprtbal.TabIndex = 367
        Me.lblprtbal.Text = "0.00 Cr."
        Me.lblprtbal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtcollcd
        '
        Me.txtcollcd.Location = New System.Drawing.Point(487, 145)
        Me.txtcollcd.Name = "txtcollcd"
        Me.txtcollcd.Size = New System.Drawing.Size(36, 21)
        Me.txtcollcd.TabIndex = 54
        Me.txtcollcd.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(97, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "Paid By :"
        '
        'cmbdesc1
        '
        Me.cmbdesc1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbdesc1.FormattingEnabled = True
        Me.cmbdesc1.Location = New System.Drawing.Point(165, 298)
        Me.cmbdesc1.Name = "cmbdesc1"
        Me.cmbdesc1.Size = New System.Drawing.Size(281, 21)
        Me.cmbdesc1.TabIndex = 8
        '
        'cmbdesc2
        '
        Me.cmbdesc2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbdesc2.FormattingEnabled = True
        Me.cmbdesc2.Location = New System.Drawing.Point(165, 322)
        Me.cmbdesc2.Name = "cmbdesc2"
        Me.cmbdesc2.Size = New System.Drawing.Size(281, 19)
        Me.cmbdesc2.TabIndex = 9
        '
        'cmbdesc3
        '
        Me.cmbdesc3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbdesc3.FormattingEnabled = True
        Me.cmbdesc3.Location = New System.Drawing.Point(165, 345)
        Me.cmbdesc3.Name = "cmbdesc3"
        Me.cmbdesc3.Size = New System.Drawing.Size(281, 19)
        Me.cmbdesc3.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(92, 245)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Address :"
        '
        'lbladdress1
        '
        Me.lbladdress1.AutoSize = True
        Me.lbladdress1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbladdress1.ForeColor = System.Drawing.Color.Red
        Me.lbladdress1.Location = New System.Drawing.Point(161, 245)
        Me.lbladdress1.Name = "lbladdress1"
        Me.lbladdress1.Size = New System.Drawing.Size(61, 14)
        Me.lbladdress1.TabIndex = 44
        Me.lbladdress1.Text = "Address :"
        '
        'txtbycd
        '
        Me.txtbycd.Location = New System.Drawing.Point(487, 220)
        Me.txtbycd.Name = "txtbycd"
        Me.txtbycd.Size = New System.Drawing.Size(36, 21)
        Me.txtbycd.TabIndex = 43
        Me.txtbycd.Visible = False
        '
        'txtprtcd
        '
        Me.txtprtcd.Location = New System.Drawing.Point(487, 78)
        Me.txtprtcd.Name = "txtprtcd"
        Me.txtprtcd.Size = New System.Drawing.Size(36, 21)
        Me.txtprtcd.TabIndex = 42
        Me.txtprtcd.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(93, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Address :"
        '
        'btns3
        '
        Me.btns3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btns3.ForeColor = System.Drawing.Color.Red
        Me.btns3.Location = New System.Drawing.Point(448, 346)
        Me.btns3.Name = "btns3"
        Me.btns3.Size = New System.Drawing.Size(35, 21)
        Me.btns3.TabIndex = 40
        Me.btns3.Text = "S"
        Me.btns3.UseVisualStyleBackColor = True
        '
        'btns2
        '
        Me.btns2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btns2.ForeColor = System.Drawing.Color.Red
        Me.btns2.Location = New System.Drawing.Point(448, 322)
        Me.btns2.Name = "btns2"
        Me.btns2.Size = New System.Drawing.Size(35, 21)
        Me.btns2.TabIndex = 39
        Me.btns2.Text = "S"
        Me.btns2.UseVisualStyleBackColor = True
        '
        'vdt
        '
        Me.vdt.CalendarForeColor = System.Drawing.Color.Black
        Me.vdt.CustomFormat = "dd/MM/yyyy"
        Me.vdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.vdt.Location = New System.Drawing.Point(371, 55)
        Me.vdt.Name = "vdt"
        Me.vdt.Size = New System.Drawing.Size(111, 21)
        Me.vdt.TabIndex = 1
        '
        'btns1
        '
        Me.btns1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btns1.ForeColor = System.Drawing.Color.Red
        Me.btns1.Location = New System.Drawing.Point(448, 298)
        Me.btns1.Name = "btns1"
        Me.btns1.Size = New System.Drawing.Size(35, 21)
        Me.btns1.TabIndex = 38
        Me.btns1.Text = "S"
        Me.btns1.UseVisualStyleBackColor = True
        '
        'chckclrdata
        '
        Me.chckclrdata.AutoSize = True
        Me.chckclrdata.Location = New System.Drawing.Point(389, 373)
        Me.chckclrdata.Name = "chckclrdata"
        Me.chckclrdata.Size = New System.Drawing.Size(94, 17)
        Me.chckclrdata.TabIndex = 12
        Me.chckclrdata.Text = "Clear Data"
        Me.chckclrdata.UseVisualStyleBackColor = True
        '
        'cmbrcmode
        '
        Me.cmbrcmode.AutoCompleteCustomSource.AddRange(New String() {"Cash"})
        Me.cmbrcmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbrcmode.FormattingEnabled = True
        Me.cmbrcmode.Items.AddRange(New Object() {"1.Cash", "2.DD/Cheque"})
        Me.cmbrcmode.Location = New System.Drawing.Point(164, 168)
        Me.cmbrcmode.Name = "cmbrcmode"
        Me.cmbrcmode.Size = New System.Drawing.Size(134, 21)
        Me.cmbrcmode.TabIndex = 4
        '
        'txtcshinhand
        '
        Me.txtcshinhand.Enabled = False
        Me.txtcshinhand.Location = New System.Drawing.Point(371, 191)
        Me.txtcshinhand.Name = "txtcshinhand"
        Me.txtcshinhand.Size = New System.Drawing.Size(111, 21)
        Me.txtcshinhand.TabIndex = 6
        Me.txtcshinhand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtcshinhand.Visible = False
        '
        'txtamt
        '
        Me.txtamt.Location = New System.Drawing.Point(371, 168)
        Me.txtamt.Name = "txtamt"
        Me.txtamt.Size = New System.Drawing.Size(111, 21)
        Me.txtamt.TabIndex = 5
        Me.txtamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtvno
        '
        Me.txtvno.AutoCompleteCustomSource.AddRange(New String() {"1"})
        Me.txtvno.Location = New System.Drawing.Point(164, 55)
        Me.txtvno.Name = "txtvno"
        Me.txtvno.Size = New System.Drawing.Size(134, 21)
        Me.txtvno.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(45, 301)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Voucher Details :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(49, 223)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Recieved From :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(269, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Case In Hand :"
        Me.Label8.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(305, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Amount :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(84, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Pay Mode :"
        '
        'lbladdress
        '
        Me.lbladdress.AutoSize = True
        Me.lbladdress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbladdress.ForeColor = System.Drawing.Color.Red
        Me.lbladdress.Location = New System.Drawing.Point(162, 102)
        Me.lbladdress.Name = "lbladdress"
        Me.lbladdress.Size = New System.Drawing.Size(61, 14)
        Me.lbladdress.TabIndex = 22
        Me.lbladdress.Text = "Address :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Patry / Head Of A/C :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(325, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Date :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdview)
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(7, 391)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(529, 49)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'cmdview
        '
        Me.cmdview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdview.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdview.Location = New System.Drawing.Point(153, 20)
        Me.cmdview.Name = "cmdview"
        Me.cmdview.Size = New System.Drawing.Size(75, 23)
        Me.cmdview.TabIndex = 14
        Me.cmdview.Text = "&View"
        Me.cmdview.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(300, 20)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 15
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(6, 20)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(75, 23)
        Me.btnexit.TabIndex = 13
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(447, 20)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 16
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(38, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Voucher Number :"
        '
        'dv
        '
        Me.dv.AllowUserToAddRows = False
        Me.dv.AllowUserToDeleteRows = False
        Me.dv.AllowUserToResizeColumns = False
        Me.dv.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent
        Me.dv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dv.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv.ContextMenuStrip = Me.cmenu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dv.GridColor = System.Drawing.Color.Black
        Me.dv.Location = New System.Drawing.Point(68, 12)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(33, 35)
        Me.dv.TabIndex = 370
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuadd, Me.cmnuedit, Me.cmenudel, Me.cmenuview, Me.cmnurefresh, Me.cmenusearch, Me.cmnuprint, Me.cmenuexpert})
        Me.cmenu.Name = "ContextMenuStrip1"
        Me.cmenu.Size = New System.Drawing.Size(153, 202)
        '
        'cmnuadd
        '
        Me.cmnuadd.Name = "cmnuadd"
        Me.cmnuadd.Size = New System.Drawing.Size(152, 22)
        Me.cmnuadd.Text = "Add"
        '
        'cmnuedit
        '
        Me.cmnuedit.Name = "cmnuedit"
        Me.cmnuedit.Size = New System.Drawing.Size(152, 22)
        Me.cmnuedit.Text = "Edit"
        '
        'cmenudel
        '
        Me.cmenudel.Name = "cmenudel"
        Me.cmenudel.Size = New System.Drawing.Size(152, 22)
        Me.cmenudel.Text = "Delete"
        '
        'cmenuview
        '
        Me.cmenuview.Name = "cmenuview"
        Me.cmenuview.Size = New System.Drawing.Size(152, 22)
        Me.cmenuview.Text = "View"
        '
        'cmnurefresh
        '
        Me.cmnurefresh.Name = "cmnurefresh"
        Me.cmnurefresh.Size = New System.Drawing.Size(152, 22)
        Me.cmnurefresh.Text = "Refresh."
        '
        'cmenusearch
        '
        Me.cmenusearch.Name = "cmenusearch"
        Me.cmenusearch.Size = New System.Drawing.Size(152, 22)
        Me.cmenusearch.Text = "Search"
        '
        'cmnuprint
        '
        Me.cmnuprint.Name = "cmnuprint"
        Me.cmnuprint.Size = New System.Drawing.Size(152, 22)
        Me.cmnuprint.Text = "Print."
        '
        'cmenuexpert
        '
        Me.cmenuexpert.Name = "cmenuexpert"
        Me.cmenuexpert.Size = New System.Drawing.Size(152, 22)
        Me.cmenuexpert.Text = "Expert"
        '
        'frmpayvouc
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(554, 455)
        Me.Controls.Add(Me.dv)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmpayvouc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmpayvouc"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdview As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbladdress As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btns1 As System.Windows.Forms.Button
    Friend WithEvents chckclrdata As System.Windows.Forms.CheckBox
    Friend WithEvents cmbdesc3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbdesc2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbdesc1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbrecfrm As System.Windows.Forms.ComboBox
    Friend WithEvents cmbrcmode As System.Windows.Forms.ComboBox
    Friend WithEvents cmbpname As System.Windows.Forms.ComboBox
    Friend WithEvents txtcshinhand As System.Windows.Forms.TextBox
    Friend WithEvents txtamt As System.Windows.Forms.TextBox
    Friend WithEvents txtvno As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents vdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents btns3 As System.Windows.Forms.Button
    Friend WithEvents btns2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtbycd As System.Windows.Forms.TextBox
    Friend WithEvents txtprtcd As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbladdress1 As System.Windows.Forms.Label
    Friend WithEvents cmbcollby As System.Windows.Forms.ComboBox
    Friend WithEvents txtcollcd As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbldipobal As System.Windows.Forms.Label
    Friend WithEvents lblprtbal As System.Windows.Forms.Label
    Friend WithEvents lblamt As System.Windows.Forms.Label
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents cmenuexpert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenuview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenusearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuprint As System.Windows.Forms.ToolStripMenuItem

End Class
