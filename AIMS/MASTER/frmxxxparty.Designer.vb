<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxxparty
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
        Me.dv = New System.Windows.Forms.DataGridView
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.cmbactp = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtcstno = New System.Windows.Forms.TextBox
        Me.cmbinout = New System.Windows.Forms.ComboBox
        Me.cmbbltp = New System.Windows.Forms.ComboBox
        Me.cmbtrans = New System.Windows.Forms.ComboBox
        Me.cmbcustom = New System.Windows.Forms.ComboBox
        Me.cmbmarket = New System.Windows.Forms.ComboBox
        Me.cmblock = New System.Windows.Forms.ComboBox
        Me.txtparty = New System.Windows.Forms.TextBox
        Me.txtmarkcd = New System.Windows.Forms.TextBox
        Me.chkautosm = New System.Windows.Forms.CheckBox
        Me.chkautoem = New System.Windows.Forms.CheckBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtlimit = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txttrans = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtbill = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtmailid = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtactp = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtperson = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtscrl = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnview = New System.Windows.Forms.Button
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtregno = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtcont2 = New System.Windows.Forms.TextBox
        Me.txtopbl = New System.Windows.Forms.TextBox
        Me.txtcont1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtadd1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightCyan
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dv)
        Me.Panel1.Controls.Add(Me.cmbactp)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtcstno)
        Me.Panel1.Controls.Add(Me.cmbinout)
        Me.Panel1.Controls.Add(Me.cmbbltp)
        Me.Panel1.Controls.Add(Me.cmbtrans)
        Me.Panel1.Controls.Add(Me.cmbcustom)
        Me.Panel1.Controls.Add(Me.cmbmarket)
        Me.Panel1.Controls.Add(Me.cmblock)
        Me.Panel1.Controls.Add(Me.txtparty)
        Me.Panel1.Controls.Add(Me.txtmarkcd)
        Me.Panel1.Controls.Add(Me.chkautosm)
        Me.Panel1.Controls.Add(Me.chkautoem)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtlimit)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txttrans)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtbill)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtmailid)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtactp)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtperson)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtscrl)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtregno)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtcont2)
        Me.Panel1.Controls.Add(Me.txtopbl)
        Me.Panel1.Controls.Add(Me.txtcont1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtadd1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(555, 407)
        Me.Panel1.TabIndex = 0
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
        Me.dv.Location = New System.Drawing.Point(187, 7)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(33, 22)
        Me.dv.TabIndex = 78
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuadd, Me.cmnuedit, Me.cmenudel, Me.cmnurefresh})
        Me.cmenu.Name = "ContextMenuStrip1"
        Me.cmenu.Size = New System.Drawing.Size(117, 92)
        '
        'cmnuadd
        '
        Me.cmnuadd.Name = "cmnuadd"
        Me.cmnuadd.Size = New System.Drawing.Size(116, 22)
        Me.cmnuadd.Text = "Add"
        '
        'cmnuedit
        '
        Me.cmnuedit.Name = "cmnuedit"
        Me.cmnuedit.Size = New System.Drawing.Size(116, 22)
        Me.cmnuedit.Text = "Edit"
        '
        'cmenudel
        '
        Me.cmenudel.Name = "cmenudel"
        Me.cmenudel.Size = New System.Drawing.Size(116, 22)
        Me.cmenudel.Text = "Delete"
        '
        'cmnurefresh
        '
        Me.cmnurefresh.Name = "cmnurefresh"
        Me.cmnurefresh.Size = New System.Drawing.Size(116, 22)
        Me.cmnurefresh.Text = "Refresh."
        '
        'cmbactp
        '
        Me.cmbactp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbactp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbactp.FormattingEnabled = True
        Me.cmbactp.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmbactp.Location = New System.Drawing.Point(157, 203)
        Me.cmbactp.Name = "cmbactp"
        Me.cmbactp.Size = New System.Drawing.Size(175, 21)
        Me.cmbactp.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(208, 247)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "T.I.N/S.R.I.N"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(385, 247)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "C.S.T No."
        '
        'txtcstno
        '
        Me.txtcstno.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcstno.Location = New System.Drawing.Point(334, 263)
        Me.txtcstno.MaxLength = 30
        Me.txtcstno.Name = "txtcstno"
        Me.txtcstno.Size = New System.Drawing.Size(163, 21)
        Me.txtcstno.TabIndex = 12
        '
        'cmbinout
        '
        Me.cmbinout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbinout.FormattingEnabled = True
        Me.cmbinout.Items.AddRange(New Object() {"1.Inside State", "2.Outside State"})
        Me.cmbinout.Location = New System.Drawing.Point(333, 203)
        Me.cmbinout.Name = "cmbinout"
        Me.cmbinout.Size = New System.Drawing.Size(164, 21)
        Me.cmbinout.TabIndex = 8
        '
        'cmbbltp
        '
        Me.cmbbltp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbltp.FormattingEnabled = True
        Me.cmbbltp.Items.AddRange(New Object() {"Cr.", "Dr."})
        Me.cmbbltp.Location = New System.Drawing.Point(334, 226)
        Me.cmbbltp.Name = "cmbbltp"
        Me.cmbbltp.Size = New System.Drawing.Size(43, 21)
        Me.cmbbltp.TabIndex = 10
        '
        'cmbtrans
        '
        Me.cmbtrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtrans.FormattingEnabled = True
        Me.cmbtrans.Items.AddRange(New Object() {"Cr.", "Dr."})
        Me.cmbtrans.Location = New System.Drawing.Point(251, 287)
        Me.cmbtrans.Name = "cmbtrans"
        Me.cmbtrans.Size = New System.Drawing.Size(42, 21)
        Me.cmbtrans.TabIndex = 14
        '
        'cmbcustom
        '
        Me.cmbcustom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcustom.FormattingEnabled = True
        Me.cmbcustom.Items.AddRange(New Object() {"1.Cat. One", "2.Cat. Two", "3.Cat. Three", "4.Cat. Four"})
        Me.cmbcustom.Location = New System.Drawing.Point(157, 310)
        Me.cmbcustom.Name = "cmbcustom"
        Me.cmbcustom.Size = New System.Drawing.Size(116, 21)
        Me.cmbcustom.TabIndex = 16
        '
        'cmbmarket
        '
        Me.cmbmarket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbmarket.FormattingEnabled = True
        Me.cmbmarket.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmbmarket.Location = New System.Drawing.Point(383, 310)
        Me.cmbmarket.Name = "cmbmarket"
        Me.cmbmarket.Size = New System.Drawing.Size(114, 21)
        Me.cmbmarket.TabIndex = 17
        '
        'cmblock
        '
        Me.cmblock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmblock.FormattingEnabled = True
        Me.cmblock.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmblock.Location = New System.Drawing.Point(437, 333)
        Me.cmblock.Name = "cmblock"
        Me.cmblock.Size = New System.Drawing.Size(60, 21)
        Me.cmblock.TabIndex = 19
        '
        'txtparty
        '
        Me.txtparty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtparty.Location = New System.Drawing.Point(157, 34)
        Me.txtparty.MaxLength = 50
        Me.txtparty.Name = "txtparty"
        Me.txtparty.Size = New System.Drawing.Size(340, 21)
        Me.txtparty.TabIndex = 0
        '
        'txtmarkcd
        '
        Me.txtmarkcd.Location = New System.Drawing.Point(503, 309)
        Me.txtmarkcd.Name = "txtmarkcd"
        Me.txtmarkcd.Size = New System.Drawing.Size(24, 21)
        Me.txtmarkcd.TabIndex = 47
        Me.txtmarkcd.Visible = False
        '
        'chkautosm
        '
        Me.chkautosm.AutoSize = True
        Me.chkautosm.ForeColor = System.Drawing.Color.Red
        Me.chkautosm.Location = New System.Drawing.Point(259, 336)
        Me.chkautosm.Name = "chkautosm"
        Me.chkautosm.Size = New System.Drawing.Size(86, 17)
        Me.chkautosm.TabIndex = 18
        Me.chkautosm.Text = "Auto SMS"
        Me.chkautosm.UseVisualStyleBackColor = True
        '
        'chkautoem
        '
        Me.chkautoem.AutoSize = True
        Me.chkautoem.ForeColor = System.Drawing.Color.Red
        Me.chkautoem.Location = New System.Drawing.Point(157, 336)
        Me.chkautoem.Name = "chkautoem"
        Me.chkautoem.Size = New System.Drawing.Size(96, 17)
        Me.chkautoem.TabIndex = 17
        Me.chkautoem.Text = "Auto Email"
        Me.chkautoem.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(6, 313)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(148, 13)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "Customer Categorey :"
        '
        'txtlimit
        '
        Me.txtlimit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlimit.Location = New System.Drawing.Point(383, 287)
        Me.txtlimit.MaxLength = 4
        Me.txtlimit.Name = "txtlimit"
        Me.txtlimit.Size = New System.Drawing.Size(114, 21)
        Me.txtlimit.TabIndex = 15
        Me.txtlimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(297, 290)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 13)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Limit Days :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(22, 289)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(132, 13)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "Transaction Limit  :"
        '
        'txttrans
        '
        Me.txttrans.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttrans.Location = New System.Drawing.Point(157, 286)
        Me.txttrans.MaxLength = 11
        Me.txttrans.Name = "txttrans"
        Me.txttrans.Size = New System.Drawing.Size(91, 21)
        Me.txttrans.TabIndex = 13
        Me.txttrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(279, 313)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Market Name :"
        '
        'txtbill
        '
        Me.txtbill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbill.Location = New System.Drawing.Point(157, 57)
        Me.txtbill.MaxLength = 50
        Me.txtbill.Name = "txtbill"
        Me.txtbill.Size = New System.Drawing.Size(340, 21)
        Me.txtbill.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(58, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Billing Name :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(31, 230)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 13)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Opening Balance :"
        '
        'txtmailid
        '
        Me.txtmailid.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmailid.Location = New System.Drawing.Point(157, 180)
        Me.txtmailid.MaxLength = 70
        Me.txtmailid.Name = "txtmailid"
        Me.txtmailid.Size = New System.Drawing.Size(340, 21)
        Me.txtmailid.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(84, 183)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Email ID :"
        '
        'txtactp
        '
        Me.txtactp.Location = New System.Drawing.Point(503, 203)
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
        Me.Label9.Location = New System.Drawing.Point(39, 206)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "* Account Type :"
        '
        'txtperson
        '
        Me.txtperson.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtperson.Location = New System.Drawing.Point(157, 80)
        Me.txtperson.MaxLength = 50
        Me.txtperson.Name = "txtperson"
        Me.txtperson.Size = New System.Drawing.Size(340, 21)
        Me.txtperson.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(37, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Concern Person :"
        '
        'txtscrl
        '
        Me.txtscrl.Location = New System.Drawing.Point(157, 7)
        Me.txtscrl.Name = "txtscrl"
        Me.txtscrl.Size = New System.Drawing.Size(24, 21)
        Me.txtscrl.TabIndex = 18
        Me.txtscrl.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnview)
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(2, 354)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(548, 49)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'btnview
        '
        Me.btnview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnview.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnview.Location = New System.Drawing.Point(168, 16)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(75, 23)
        Me.btnview.TabIndex = 22
        Me.btnview.Text = "&View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(306, 16)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 21
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(30, 16)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(75, 23)
        Me.btnexit.TabIndex = 23
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(444, 16)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 20
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(367, 336)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Locked :"
        '
        'txtregno
        '
        Me.txtregno.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtregno.Location = New System.Drawing.Point(157, 263)
        Me.txtregno.MaxLength = 12
        Me.txtregno.Name = "txtregno"
        Me.txtregno.Size = New System.Drawing.Size(175, 21)
        Me.txtregno.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(82, 265)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Regd. No :"
        '
        'txtcont2
        '
        Me.txtcont2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcont2.Location = New System.Drawing.Point(333, 157)
        Me.txtcont2.MaxLength = 15
        Me.txtcont2.Name = "txtcont2"
        Me.txtcont2.Size = New System.Drawing.Size(164, 21)
        Me.txtcont2.TabIndex = 5
        '
        'txtopbl
        '
        Me.txtopbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopbl.Location = New System.Drawing.Point(157, 226)
        Me.txtopbl.MaxLength = 11
        Me.txtopbl.Name = "txtopbl"
        Me.txtopbl.Size = New System.Drawing.Size(175, 21)
        Me.txtopbl.TabIndex = 9
        Me.txtopbl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcont1
        '
        Me.txtcont1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcont1.Location = New System.Drawing.Point(157, 157)
        Me.txtcont1.MaxLength = 15
        Me.txtcont1.Name = "txtcont1"
        Me.txtcont1.Size = New System.Drawing.Size(175, 21)
        Me.txtcont1.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(83, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Contacts :"
        '
        'txtadd1
        '
        Me.txtadd1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd1.Location = New System.Drawing.Point(157, 103)
        Me.txtadd1.MaxLength = 100
        Me.txtadd1.Multiline = True
        Me.txtadd1.Name = "txtadd1"
        Me.txtadd1.Size = New System.Drawing.Size(340, 52)
        Me.txtadd1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(86, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Address :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(51, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "* Party Name :"
        '
        'frmparty
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(557, 409)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmparty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Party Master . . ."
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtcont1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtadd1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
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
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents txtperson As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbactp As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtactp As System.Windows.Forms.TextBox
    Friend WithEvents txtmailid As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbbltp As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtbill As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbmarket As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbtrans As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txttrans As System.Windows.Forms.TextBox
    Friend WithEvents txtlimit As System.Windows.Forms.TextBox
    Friend WithEvents cmbcustom As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkautosm As System.Windows.Forms.CheckBox
    Friend WithEvents chkautoem As System.Windows.Forms.CheckBox
    Friend WithEvents txtmarkcd As System.Windows.Forms.TextBox
    Friend WithEvents txtparty As System.Windows.Forms.TextBox
    Friend WithEvents cmbinout As System.Windows.Forms.ComboBox
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents txtcstno As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
