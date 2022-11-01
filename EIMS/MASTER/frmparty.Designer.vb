<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmparty
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
        Me.cmbactp = New System.Windows.Forms.ComboBox
        Me.cmbbltp = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbsms = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbmail = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtmailid = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtactp = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtperson = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtscrl = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdview = New System.Windows.Forms.Button
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.cmblock = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtregno = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtcont2 = New System.Windows.Forms.TextBox
        Me.txtopbl = New System.Windows.Forms.TextBox
        Me.txtcont1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtadd1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtprtnm = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dv = New System.Windows.Forms.DataGridView
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenuview = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenusearch = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuexport = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightCyan
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmbactp)
        Me.Panel1.Controls.Add(Me.cmbbltp)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.cmbsms)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cmbmail)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtmailid)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtactp)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtperson)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtscrl)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.cmblock)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtregno)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtcont2)
        Me.Panel1.Controls.Add(Me.txtopbl)
        Me.Panel1.Controls.Add(Me.txtcont1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtadd1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtprtnm)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(520, 360)
        Me.Panel1.TabIndex = 0
        '
        'cmbactp
        '
        Me.cmbactp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbactp.FormattingEnabled = True
        Me.cmbactp.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmbactp.Location = New System.Drawing.Point(151, 227)
        Me.cmbactp.Name = "cmbactp"
        Me.cmbactp.Size = New System.Drawing.Size(294, 21)
        Me.cmbactp.TabIndex = 8
        '
        'cmbbltp
        '
        Me.cmbbltp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbltp.FormattingEnabled = True
        Me.cmbbltp.Items.AddRange(New Object() {"Cr.", "Dr."})
        Me.cmbbltp.Location = New System.Drawing.Point(296, 251)
        Me.cmbbltp.Name = "cmbbltp"
        Me.cmbbltp.Size = New System.Drawing.Size(45, 21)
        Me.cmbbltp.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(25, 254)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 13)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Opening Balance :"
        '
        'cmbsms
        '
        Me.cmbsms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsms.FormattingEnabled = True
        Me.cmbsms.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmbsms.Location = New System.Drawing.Point(385, 204)
        Me.cmbsms.Name = "cmbsms"
        Me.cmbsms.Size = New System.Drawing.Size(60, 21)
        Me.cmbsms.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(306, 207)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Auto SMS :"
        '
        'cmbmail
        '
        Me.cmbmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbmail.FormattingEnabled = True
        Me.cmbmail.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmbmail.Location = New System.Drawing.Point(151, 204)
        Me.cmbmail.Name = "cmbmail"
        Me.cmbmail.Size = New System.Drawing.Size(60, 21)
        Me.cmbmail.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(63, 207)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Auto Email :"
        '
        'txtmailid
        '
        Me.txtmailid.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmailid.Location = New System.Drawing.Point(151, 180)
        Me.txtmailid.MaxLength = 50
        Me.txtmailid.Name = "txtmailid"
        Me.txtmailid.Size = New System.Drawing.Size(294, 21)
        Me.txtmailid.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(78, 183)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Email ID :"
        '
        'txtactp
        '
        Me.txtactp.Location = New System.Drawing.Point(34, 207)
        Me.txtactp.Name = "txtactp"
        Me.txtactp.Size = New System.Drawing.Size(24, 21)
        Me.txtactp.TabIndex = 24
        Me.txtactp.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(45, 230)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Account Type :"
        '
        'txtperson
        '
        Me.txtperson.Location = New System.Drawing.Point(151, 80)
        Me.txtperson.MaxLength = 50
        Me.txtperson.Name = "txtperson"
        Me.txtperson.Size = New System.Drawing.Size(294, 21)
        Me.txtperson.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(31, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Concern Person :"
        '
        'txtscrl
        '
        Me.txtscrl.Location = New System.Drawing.Point(151, 20)
        Me.txtscrl.Name = "txtscrl"
        Me.txtscrl.Size = New System.Drawing.Size(36, 21)
        Me.txtscrl.TabIndex = 18
        Me.txtscrl.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdview)
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(7, 301)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(501, 49)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'cmdview
        '
        Me.cmdview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdview.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdview.Location = New System.Drawing.Point(144, 20)
        Me.cmdview.Name = "cmdview"
        Me.cmdview.Size = New System.Drawing.Size(75, 23)
        Me.cmdview.TabIndex = 3
        Me.cmdview.Text = "&View"
        Me.cmdview.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(282, 20)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 2
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
        Me.btnexit.TabIndex = 1
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(420, 20)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 0
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'cmblock
        '
        Me.cmblock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmblock.FormattingEnabled = True
        Me.cmblock.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmblock.Location = New System.Drawing.Point(385, 273)
        Me.cmblock.Name = "cmblock"
        Me.cmblock.Size = New System.Drawing.Size(60, 21)
        Me.cmblock.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(321, 279)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Locked :"
        '
        'txtregno
        '
        Me.txtregno.Location = New System.Drawing.Point(151, 275)
        Me.txtregno.Name = "txtregno"
        Me.txtregno.Size = New System.Drawing.Size(148, 21)
        Me.txtregno.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(80, 280)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Regd. No :"
        '
        'txtcont2
        '
        Me.txtcont2.Location = New System.Drawing.Point(301, 157)
        Me.txtcont2.MaxLength = 15
        Me.txtcont2.Name = "txtcont2"
        Me.txtcont2.Size = New System.Drawing.Size(144, 21)
        Me.txtcont2.TabIndex = 4
        '
        'txtopbl
        '
        Me.txtopbl.Location = New System.Drawing.Point(151, 251)
        Me.txtopbl.MaxLength = 8
        Me.txtopbl.Name = "txtopbl"
        Me.txtopbl.Size = New System.Drawing.Size(144, 21)
        Me.txtopbl.TabIndex = 9
        Me.txtopbl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcont1
        '
        Me.txtcont1.Location = New System.Drawing.Point(151, 157)
        Me.txtcont1.MaxLength = 15
        Me.txtcont1.Name = "txtcont1"
        Me.txtcont1.Size = New System.Drawing.Size(148, 21)
        Me.txtcont1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(77, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Contacts :"
        '
        'txtadd1
        '
        Me.txtadd1.Location = New System.Drawing.Point(151, 103)
        Me.txtadd1.MaxLength = 100
        Me.txtadd1.Multiline = True
        Me.txtadd1.Name = "txtadd1"
        Me.txtadd1.Size = New System.Drawing.Size(294, 52)
        Me.txtadd1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(80, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Address :"
        '
        'txtprtnm
        '
        Me.txtprtnm.Location = New System.Drawing.Point(151, 57)
        Me.txtprtnm.MaxLength = 50
        Me.txtprtnm.Name = "txtprtnm"
        Me.txtprtnm.Size = New System.Drawing.Size(294, 21)
        Me.txtprtnm.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(57, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Party Name :"
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
        Me.dv.Location = New System.Drawing.Point(235, 16)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(33, 35)
        Me.dv.TabIndex = 75
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuadd, Me.cmnuedit, Me.cmenudel, Me.cmenuview, Me.cmnurefresh, Me.cmenusearch, Me.mnuexport})
        Me.cmenu.Name = "ContextMenuStrip1"
        Me.cmenu.Size = New System.Drawing.Size(117, 158)
        '
        'cmnuadd
        '
        Me.cmnuadd.Name = "cmnuadd"
        Me.cmnuadd.Size = New System.Drawing.Size(116, 22)
        Me.cmnuadd.Text = "Add."
        '
        'cmnuedit
        '
        Me.cmnuedit.Name = "cmnuedit"
        Me.cmnuedit.Size = New System.Drawing.Size(116, 22)
        Me.cmnuedit.Text = "Edit."
        '
        'cmenudel
        '
        Me.cmenudel.Name = "cmenudel"
        Me.cmenudel.Size = New System.Drawing.Size(116, 22)
        Me.cmenudel.Text = "Delete."
        '
        'cmenuview
        '
        Me.cmenuview.Name = "cmenuview"
        Me.cmenuview.Size = New System.Drawing.Size(116, 22)
        Me.cmenuview.Text = "View."
        '
        'cmnurefresh
        '
        Me.cmnurefresh.Name = "cmnurefresh"
        Me.cmnurefresh.Size = New System.Drawing.Size(116, 22)
        Me.cmnurefresh.Text = "Refresh."
        '
        'cmenusearch
        '
        Me.cmenusearch.Name = "cmenusearch"
        Me.cmenusearch.Size = New System.Drawing.Size(116, 22)
        Me.cmenusearch.Text = "Search."
        '
        'mnuexport
        '
        Me.mnuexport.Name = "mnuexport"
        Me.mnuexport.Size = New System.Drawing.Size(116, 22)
        Me.mnuexport.Text = "Export."
        '
        'frmparty
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(525, 366)
        Me.Controls.Add(Me.dv)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmparty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmparty"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtcont1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtadd1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtprtnm As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcont2 As System.Windows.Forms.TextBox
    Friend WithEvents txtopbl As System.Windows.Forms.TextBox
    Friend WithEvents cmblock As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtregno As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents txtscrl As System.Windows.Forms.TextBox
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdview As System.Windows.Forms.Button
    Friend WithEvents txtperson As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbactp As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtactp As System.Windows.Forms.TextBox
    Friend WithEvents cmbsms As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbmail As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtmailid As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbbltp As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents cmenuview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuexport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenusearch As System.Windows.Forms.ToolStripMenuItem

End Class
