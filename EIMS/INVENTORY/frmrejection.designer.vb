<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrejection
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.dv1 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtscroll = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtissue = New System.Windows.Forms.DateTimePicker
        Me.txtref = New System.Windows.Forms.TextBox
        Me.txtslno = New System.Windows.Forms.TextBox
        Me.txtquantity = New System.Windows.Forms.TextBox
        Me.txtunit = New System.Windows.Forms.TextBox
        Me.txtrate = New System.Windows.Forms.TextBox
        Me.txtamount = New System.Windows.Forms.TextBox
        Me.btnnext = New System.Windows.Forms.Button
        Me.cmbproduct = New System.Windows.Forms.ComboBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblstk = New System.Windows.Forms.Label
        Me.lbltotal = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtnb = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnsave = New System.Windows.Forms.Button
        Me.btnswap = New System.Windows.Forms.Button
        Me.btnview = New System.Windows.Forms.Button
        Me.btnref = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.cmbgodown = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbreject = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtgodcd = New System.Windows.Forms.TextBox
        Me.txtrejcd = New System.Windows.Forms.TextBox
        Me.txtitcd = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dv = New System.Windows.Forms.DataGridView
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.mnuexpert = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenu.SuspendLayout()
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuadd, Me.cmnuedit, Me.cmenudel, Me.cmnurefresh, Me.mnuexpert})
        Me.cmenu.Name = "ContextMenuStrip1"
        Me.cmenu.Size = New System.Drawing.Size(153, 136)
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
        'cmnurefresh
        '
        Me.cmnurefresh.Name = "cmnurefresh"
        Me.cmnurefresh.Size = New System.Drawing.Size(152, 22)
        Me.cmnurefresh.Text = "Refresh."
        '
        'dv1
        '
        Me.dv1.AllowUserToAddRows = False
        Me.dv1.AllowUserToDeleteRows = False
        Me.dv1.AllowUserToResizeColumns = False
        Me.dv1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dv1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dv1.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv1.ContextMenuStrip = Me.cmenu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dv1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dv1.GridColor = System.Drawing.Color.Black
        Me.dv1.Location = New System.Drawing.Point(3, 101)
        Me.dv1.Name = "dv1"
        Me.dv1.ReadOnly = True
        Me.dv1.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Azure
        Me.dv1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dv1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv1.RowTemplate.Height = 20
        Me.dv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv1.Size = New System.Drawing.Size(635, 124)
        Me.dv1.TabIndex = 106
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(15, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Scroll :"
        '
        'txtscroll
        '
        Me.txtscroll.Location = New System.Drawing.Point(69, 5)
        Me.txtscroll.Multiline = True
        Me.txtscroll.Name = "txtscroll"
        Me.txtscroll.Size = New System.Drawing.Size(80, 20)
        Me.txtscroll.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(443, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 13)
        Me.Label5.TabIndex = 111
        Me.Label5.Text = "Return Date :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(10, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "Ref.No :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(431, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 113
        Me.Label7.Text = "Godown From :"
        '
        'dtissue
        '
        Me.dtissue.CalendarForeColor = System.Drawing.Color.Black
        Me.dtissue.CustomFormat = "dd/MM/yyyy"
        Me.dtissue.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtissue.Location = New System.Drawing.Point(537, 5)
        Me.dtissue.Name = "dtissue"
        Me.dtissue.Size = New System.Drawing.Size(101, 21)
        Me.dtissue.TabIndex = 1
        '
        'txtref
        '
        Me.txtref.Location = New System.Drawing.Point(69, 31)
        Me.txtref.Multiline = True
        Me.txtref.Name = "txtref"
        Me.txtref.Size = New System.Drawing.Size(80, 21)
        Me.txtref.TabIndex = 2
        '
        'txtslno
        '
        Me.txtslno.Location = New System.Drawing.Point(3, 78)
        Me.txtslno.Multiline = True
        Me.txtslno.Name = "txtslno"
        Me.txtslno.Size = New System.Drawing.Size(42, 20)
        Me.txtslno.TabIndex = 98
        '
        'txtquantity
        '
        Me.txtquantity.Location = New System.Drawing.Point(288, 79)
        Me.txtquantity.Multiline = True
        Me.txtquantity.Name = "txtquantity"
        Me.txtquantity.Size = New System.Drawing.Size(70, 20)
        Me.txtquantity.TabIndex = 6
        '
        'txtunit
        '
        Me.txtunit.BackColor = System.Drawing.SystemColors.Window
        Me.txtunit.Enabled = False
        Me.txtunit.Location = New System.Drawing.Point(358, 79)
        Me.txtunit.Multiline = True
        Me.txtunit.Name = "txtunit"
        Me.txtunit.Size = New System.Drawing.Size(50, 20)
        Me.txtunit.TabIndex = 101
        '
        'txtrate
        '
        Me.txtrate.Location = New System.Drawing.Point(408, 79)
        Me.txtrate.Multiline = True
        Me.txtrate.Name = "txtrate"
        Me.txtrate.Size = New System.Drawing.Size(80, 20)
        Me.txtrate.TabIndex = 7
        '
        'txtamount
        '
        Me.txtamount.BackColor = System.Drawing.SystemColors.Window
        Me.txtamount.Enabled = False
        Me.txtamount.Location = New System.Drawing.Point(488, 79)
        Me.txtamount.Multiline = True
        Me.txtamount.Name = "txtamount"
        Me.txtamount.Size = New System.Drawing.Size(100, 20)
        Me.txtamount.TabIndex = 103
        '
        'btnnext
        '
        Me.btnnext.ForeColor = System.Drawing.Color.Red
        Me.btnnext.Location = New System.Drawing.Point(586, 78)
        Me.btnnext.Name = "btnnext"
        Me.btnnext.Size = New System.Drawing.Size(52, 23)
        Me.btnnext.TabIndex = 8
        Me.btnnext.Text = "Next"
        Me.btnnext.UseVisualStyleBackColor = True
        '
        'cmbproduct
        '
        Me.cmbproduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbproduct.FormattingEnabled = True
        Me.cmbproduct.Items.AddRange(New Object() {"Ball", "Bat", "Plastic chair", "Glass"})
        Me.cmbproduct.Location = New System.Drawing.Point(44, 78)
        Me.cmbproduct.Name = "cmbproduct"
        Me.cmbproduct.Size = New System.Drawing.Size(244, 20)
        Me.cmbproduct.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblstk)
        Me.Panel3.Controls.Add(Me.lbltotal)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Location = New System.Drawing.Point(2, 227)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(636, 24)
        Me.Panel3.TabIndex = 116
        '
        'lblstk
        '
        Me.lblstk.AutoSize = True
        Me.lblstk.ForeColor = System.Drawing.Color.Red
        Me.lblstk.Location = New System.Drawing.Point(126, 5)
        Me.lblstk.Name = "lblstk"
        Me.lblstk.Size = New System.Drawing.Size(0, 13)
        Me.lblstk.TabIndex = 91
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.ForeColor = System.Drawing.Color.Red
        Me.lbltotal.Location = New System.Drawing.Point(599, 5)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(0, 13)
        Me.lbltotal.TabIndex = 90
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(398, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 13)
        Me.Label16.TabIndex = 87
        Me.Label16.Text = "Grand Total :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(69, 5)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Stock :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(4, 256)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 13)
        Me.Label17.TabIndex = 117
        Me.Label17.Text = "N.B :"
        '
        'txtnb
        '
        Me.txtnb.Location = New System.Drawing.Point(44, 253)
        Me.txtnb.Multiline = True
        Me.txtnb.Name = "txtnb"
        Me.txtnb.Size = New System.Drawing.Size(594, 20)
        Me.txtnb.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Controls.Add(Me.btnswap)
        Me.GroupBox1.Controls.Add(Me.btnview)
        Me.GroupBox1.Controls.Add(Me.btnref)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(4, 273)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(634, 46)
        Me.GroupBox1.TabIndex = 118
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls . . ."
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(536, 17)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(79, 23)
        Me.btnsave.TabIndex = 10
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnswap
        '
        Me.btnswap.Location = New System.Drawing.Point(407, 17)
        Me.btnswap.Name = "btnswap"
        Me.btnswap.Size = New System.Drawing.Size(79, 23)
        Me.btnswap.TabIndex = 11
        Me.btnswap.Text = "S&wap"
        Me.btnswap.UseVisualStyleBackColor = True
        '
        'btnview
        '
        Me.btnview.Location = New System.Drawing.Point(278, 17)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(79, 23)
        Me.btnview.TabIndex = 12
        Me.btnview.Text = "&ViewLast"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'btnref
        '
        Me.btnref.Location = New System.Drawing.Point(149, 17)
        Me.btnref.Name = "btnref"
        Me.btnref.Size = New System.Drawing.Size(79, 23)
        Me.btnref.TabIndex = 13
        Me.btnref.Text = "&Refresh"
        Me.btnref.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Location = New System.Drawing.Point(20, 17)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(79, 23)
        Me.btnexit.TabIndex = 14
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'cmbgodown
        '
        Me.cmbgodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbgodown.FormattingEnabled = True
        Me.cmbgodown.Items.AddRange(New Object() {"GODOWN1"})
        Me.cmbgodown.Location = New System.Drawing.Point(537, 31)
        Me.cmbgodown.Name = "cmbgodown"
        Me.cmbgodown.Size = New System.Drawing.Size(101, 21)
        Me.cmbgodown.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(159, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "Rejected By :"
        '
        'cmbreject
        '
        Me.cmbreject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbreject.FormattingEnabled = True
        Me.cmbreject.Items.AddRange(New Object() {"Manas"})
        Me.cmbreject.Location = New System.Drawing.Point(253, 31)
        Me.cmbreject.Name = "cmbreject"
        Me.cmbreject.Size = New System.Drawing.Size(164, 20)
        Me.cmbreject.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightCyan
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtgodcd)
        Me.Panel1.Controls.Add(Me.txtrejcd)
        Me.Panel1.Controls.Add(Me.cmbgodown)
        Me.Panel1.Controls.Add(Me.cmbreject)
        Me.Panel1.Controls.Add(Me.cmbproduct)
        Me.Panel1.Controls.Add(Me.txtitcd)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtnb)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.btnnext)
        Me.Panel1.Controls.Add(Me.txtamount)
        Me.Panel1.Controls.Add(Me.txtrate)
        Me.Panel1.Controls.Add(Me.txtunit)
        Me.Panel1.Controls.Add(Me.txtquantity)
        Me.Panel1.Controls.Add(Me.txtslno)
        Me.Panel1.Controls.Add(Me.txtref)
        Me.Panel1.Controls.Add(Me.dtissue)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtscroll)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dv1)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(643, 323)
        Me.Panel1.TabIndex = 0
        '
        'txtgodcd
        '
        Me.txtgodcd.Location = New System.Drawing.Point(234, 4)
        Me.txtgodcd.Name = "txtgodcd"
        Me.txtgodcd.Size = New System.Drawing.Size(19, 21)
        Me.txtgodcd.TabIndex = 130
        Me.txtgodcd.Visible = False
        '
        'txtrejcd
        '
        Me.txtrejcd.Location = New System.Drawing.Point(209, 3)
        Me.txtrejcd.Name = "txtrejcd"
        Me.txtrejcd.Size = New System.Drawing.Size(19, 21)
        Me.txtrejcd.TabIndex = 129
        Me.txtrejcd.Visible = False
        '
        'txtitcd
        '
        Me.txtitcd.Location = New System.Drawing.Point(184, 3)
        Me.txtitcd.Name = "txtitcd"
        Me.txtitcd.Size = New System.Drawing.Size(19, 21)
        Me.txtitcd.TabIndex = 128
        Me.txtitcd.Visible = False
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Red
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(-1, 58)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(643, 2)
        Me.Label26.TabIndex = 127
        Me.Label26.Text = "Address :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(512, 63)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 123
        Me.Label14.Text = "Amount"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(430, 63)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 13)
        Me.Label13.TabIndex = 124
        Me.Label13.Text = "Rate"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(367, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "Unit"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(292, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 126
        Me.Label12.Text = "Quantity"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(84, 63)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 13)
        Me.Label10.TabIndex = 122
        Me.Label10.Text = "Name Of The Product"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(4, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 121
        Me.Label9.Text = "Sl No."
        '
        'dv
        '
        Me.dv.AllowUserToAddRows = False
        Me.dv.AllowUserToDeleteRows = False
        Me.dv.AllowUserToResizeColumns = False
        Me.dv.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Transparent
        Me.dv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dv.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.dv.ContextMenuStrip = Me.cmenu
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dv.DefaultCellStyle = DataGridViewCellStyle5
        Me.dv.GridColor = System.Drawing.Color.Black
        Me.dv.Location = New System.Drawing.Point(316, 5)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(40, 25)
        Me.dv.TabIndex = 131
        Me.dv.Visible = False
        '
        'Column8
        '
        Me.Column8.HeaderText = "Sl.No."
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 50
        '
        'Column1
        '
        Me.Column1.HeaderText = "Scroll"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'Column2
        '
        Me.Column2.HeaderText = "    Date"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = " Godown Name"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 130
        '
        'Column4
        '
        Me.Column4.HeaderText = "   Item Name"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 170
        '
        'Column5
        '
        Me.Column5.HeaderText = " Quantity"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 80
        '
        'Column6
        '
        Me.Column6.HeaderText = " Unit"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 50
        '
        'mnuexpert
        '
        Me.mnuexpert.Name = "mnuexpert"
        Me.mnuexpert.Size = New System.Drawing.Size(152, 22)
        Me.mnuexpert.Text = "Expert"
        '
        'frmrejection
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(645, 326)
        Me.Controls.Add(Me.dv)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmrejection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rejection Entry"
        Me.cmenu.ResumeLayout(False)
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtscroll As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtissue As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtref As System.Windows.Forms.TextBox
    Friend WithEvents txtslno As System.Windows.Forms.TextBox
    Friend WithEvents txtquantity As System.Windows.Forms.TextBox
    Friend WithEvents txtunit As System.Windows.Forms.TextBox
    Friend WithEvents txtrate As System.Windows.Forms.TextBox
    Friend WithEvents txtamount As System.Windows.Forms.TextBox
    Friend WithEvents btnnext As System.Windows.Forms.Button
    Friend WithEvents cmbproduct As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtnb As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnswap As System.Windows.Forms.Button
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents btnref As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents cmbgodown As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbreject As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtitcd As System.Windows.Forms.TextBox
    Friend WithEvents lblstk As System.Windows.Forms.Label
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents txtgodcd As System.Windows.Forms.TextBox
    Friend WithEvents txtrejcd As System.Windows.Forms.TextBox
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuexpert As System.Windows.Forms.ToolStripMenuItem

End Class
