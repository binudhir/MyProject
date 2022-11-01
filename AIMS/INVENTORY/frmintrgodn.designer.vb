<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmintrgodn
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmbgodto = New System.Windows.Forms.ComboBox
        Me.txtuntcd = New System.Windows.Forms.TextBox
        Me.cmbgodfrom = New System.Windows.Forms.ComboBox
        Me.txtgodto = New System.Windows.Forms.TextBox
        Me.txtgodfrom = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.dtref = New System.Windows.Forms.DateTimePicker
        Me.dttrans = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtref = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtscroll = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtitcd = New System.Windows.Forms.TextBox
        Me.cmbunit = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtquantity = New System.Windows.Forms.TextBox
        Me.cmbproduct = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnnext = New System.Windows.Forms.Button
        Me.txtsl = New System.Windows.Forms.TextBox
        Me.dv1 = New System.Windows.Forms.DataGridView
        Me.cmenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnu1del = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btninter = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.btnview = New System.Windows.Forms.Button
        Me.btnref = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.dv = New System.Windows.Forms.DataGridView
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuprint = New System.Windows.Forms.ToolStripMenuItem
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.untcd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenu1.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.cmbgodto)
        Me.Panel1.Controls.Add(Me.txtuntcd)
        Me.Panel1.Controls.Add(Me.cmbgodfrom)
        Me.Panel1.Controls.Add(Me.txtgodto)
        Me.Panel1.Controls.Add(Me.txtgodfrom)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.dtref)
        Me.Panel1.Controls.Add(Me.dttrans)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtref)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtscroll)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtitcd)
        Me.Panel1.Controls.Add(Me.cmbunit)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtquantity)
        Me.Panel1.Controls.Add(Me.cmbproduct)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btnnext)
        Me.Panel1.Controls.Add(Me.txtsl)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.dv1)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(604, 343)
        Me.Panel1.TabIndex = 0
        '
        'cmbgodto
        '
        Me.cmbgodto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbgodto.FormattingEnabled = True
        Me.cmbgodto.Items.AddRange(New Object() {"Godown1"})
        Me.cmbgodto.Location = New System.Drawing.Point(476, 50)
        Me.cmbgodto.Name = "cmbgodto"
        Me.cmbgodto.Size = New System.Drawing.Size(121, 20)
        Me.cmbgodto.TabIndex = 5
        '
        'txtuntcd
        '
        Me.txtuntcd.Location = New System.Drawing.Point(291, 50)
        Me.txtuntcd.Name = "txtuntcd"
        Me.txtuntcd.Size = New System.Drawing.Size(19, 21)
        Me.txtuntcd.TabIndex = 864
        Me.txtuntcd.Visible = False
        '
        'cmbgodfrom
        '
        Me.cmbgodfrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbgodfrom.FormattingEnabled = True
        Me.cmbgodfrom.Items.AddRange(New Object() {"Godown1"})
        Me.cmbgodfrom.Location = New System.Drawing.Point(106, 50)
        Me.cmbgodfrom.Name = "cmbgodfrom"
        Me.cmbgodfrom.Size = New System.Drawing.Size(121, 20)
        Me.cmbgodfrom.TabIndex = 4
        '
        'txtgodto
        '
        Me.txtgodto.Location = New System.Drawing.Point(264, 52)
        Me.txtgodto.Name = "txtgodto"
        Me.txtgodto.Size = New System.Drawing.Size(19, 21)
        Me.txtgodto.TabIndex = 132
        Me.txtgodto.Visible = False
        '
        'txtgodfrom
        '
        Me.txtgodfrom.Location = New System.Drawing.Point(234, 52)
        Me.txtgodfrom.Name = "txtgodfrom"
        Me.txtgodfrom.Size = New System.Drawing.Size(19, 21)
        Me.txtgodfrom.TabIndex = 131
        Me.txtgodfrom.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(384, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 125
        Me.Label6.Text = "Godown To :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(-1, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 13)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "Godown From :"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Red
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(-1, 78)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(604, 2)
        Me.Label26.TabIndex = 121
        Me.Label26.Text = "Address :"
        '
        'dtref
        '
        Me.dtref.CalendarForeColor = System.Drawing.Color.Black
        Me.dtref.CustomFormat = "dd/MM/yyyy"
        Me.dtref.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtref.Location = New System.Drawing.Point(476, 28)
        Me.dtref.Name = "dtref"
        Me.dtref.Size = New System.Drawing.Size(121, 21)
        Me.dtref.TabIndex = 3
        '
        'dttrans
        '
        Me.dttrans.CalendarForeColor = System.Drawing.Color.Black
        Me.dttrans.CustomFormat = "dd/MM/yyyy"
        Me.dttrans.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttrans.Location = New System.Drawing.Point(476, 5)
        Me.dttrans.Name = "dttrans"
        Me.dttrans.Size = New System.Drawing.Size(121, 21)
        Me.dttrans.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(355, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Reference Date :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(365, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Transfer Date :"
        '
        'txtref
        '
        Me.txtref.Location = New System.Drawing.Point(106, 28)
        Me.txtref.Name = "txtref"
        Me.txtref.Size = New System.Drawing.Size(121, 21)
        Me.txtref.TabIndex = 2
        Me.txtref.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(0, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Reference No :"
        '
        'txtscroll
        '
        Me.txtscroll.Location = New System.Drawing.Point(106, 6)
        Me.txtscroll.Name = "txtscroll"
        Me.txtscroll.Size = New System.Drawing.Size(121, 21)
        Me.txtscroll.TabIndex = 0
        Me.txtscroll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(50, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Scroll :"
        '
        'txtitcd
        '
        Me.txtitcd.Location = New System.Drawing.Point(316, 48)
        Me.txtitcd.Name = "txtitcd"
        Me.txtitcd.Size = New System.Drawing.Size(19, 21)
        Me.txtitcd.TabIndex = 133
        Me.txtitcd.Visible = False
        '
        'cmbunit
        '
        Me.cmbunit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbunit.FormattingEnabled = True
        Me.cmbunit.Location = New System.Drawing.Point(451, 99)
        Me.cmbunit.Name = "cmbunit"
        Me.cmbunit.Size = New System.Drawing.Size(96, 20)
        Me.cmbunit.TabIndex = 862
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(485, 83)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 863
        Me.Label11.Text = "Unit"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(346, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 861
        Me.Label12.Text = "Quantity"
        '
        'txtquantity
        '
        Me.txtquantity.Location = New System.Drawing.Point(325, 99)
        Me.txtquantity.Name = "txtquantity"
        Me.txtquantity.Size = New System.Drawing.Size(125, 21)
        Me.txtquantity.TabIndex = 860
        '
        'cmbproduct
        '
        Me.cmbproduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbproduct.FormattingEnabled = True
        Me.cmbproduct.Items.AddRange(New Object() {"Ball", "Bat", "Plastic chair", "Glass"})
        Me.cmbproduct.Location = New System.Drawing.Point(54, 99)
        Me.cmbproduct.Name = "cmbproduct"
        Me.cmbproduct.Size = New System.Drawing.Size(270, 20)
        Me.cmbproduct.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(118, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 13)
        Me.Label8.TabIndex = 127
        Me.Label8.Text = "Name Of The Item"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(7, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 126
        Me.Label7.Text = "Sl.No."
        '
        'btnnext
        '
        Me.btnnext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnnext.ForeColor = System.Drawing.Color.Red
        Me.btnnext.Location = New System.Drawing.Point(547, 99)
        Me.btnnext.Name = "btnnext"
        Me.btnnext.Size = New System.Drawing.Size(52, 21)
        Me.btnnext.TabIndex = 8
        Me.btnnext.Text = "Next"
        Me.btnnext.UseVisualStyleBackColor = True
        '
        'txtsl
        '
        Me.txtsl.BackColor = System.Drawing.Color.White
        Me.txtsl.Enabled = False
        Me.txtsl.Location = New System.Drawing.Point(4, 99)
        Me.txtsl.Name = "txtsl"
        Me.txtsl.Size = New System.Drawing.Size(48, 21)
        Me.txtsl.TabIndex = 6
        Me.txtsl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dv1
        '
        Me.dv1.AllowUserToAddRows = False
        Me.dv1.AllowUserToDeleteRows = False
        Me.dv1.AllowUserToResizeColumns = False
        Me.dv1.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.dv1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dv1.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv1.ColumnHeadersVisible = False
        Me.dv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column4, Me.Column5, Me.Column3, Me.untcd})
        Me.dv1.ContextMenuStrip = Me.cmenu1
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dv1.DefaultCellStyle = DataGridViewCellStyle8
        Me.dv1.GridColor = System.Drawing.Color.Black
        Me.dv1.Location = New System.Drawing.Point(3, 122)
        Me.dv1.Name = "dv1"
        Me.dv1.ReadOnly = True
        Me.dv1.RowHeadersVisible = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Azure
        Me.dv1.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dv1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv1.RowTemplate.Height = 20
        Me.dv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv1.Size = New System.Drawing.Size(596, 164)
        Me.dv1.TabIndex = 19
        '
        'cmenu1
        '
        Me.cmenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnu1del})
        Me.cmenu1.Name = "ContextMenuStrip1"
        Me.cmenu1.Size = New System.Drawing.Size(108, 26)
        '
        'cmnu1del
        '
        Me.cmnu1del.Name = "cmnu1del"
        Me.cmnu1del.Size = New System.Drawing.Size(107, 22)
        Me.cmnu1del.Text = "Delete"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btninter)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Controls.Add(Me.btnview)
        Me.GroupBox1.Controls.Add(Me.btnref)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(3, 291)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(596, 46)
        Me.GroupBox1.TabIndex = 90
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls . . ."
        '
        'btninter
        '
        Me.btninter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btninter.Location = New System.Drawing.Point(376, 17)
        Me.btninter.Name = "btninter"
        Me.btninter.Size = New System.Drawing.Size(91, 23)
        Me.btninter.TabIndex = 14
        Me.btninter.Text = "&Swap"
        Me.btninter.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Location = New System.Drawing.Point(495, 17)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(96, 23)
        Me.btnsave.TabIndex = 9
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnview
        '
        Me.btnview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnview.Location = New System.Drawing.Point(128, 17)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(96, 23)
        Me.btnview.TabIndex = 11
        Me.btnview.Text = "&View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'btnref
        '
        Me.btnref.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnref.Location = New System.Drawing.Point(252, 17)
        Me.btnref.Name = "btnref"
        Me.btnref.Size = New System.Drawing.Size(96, 23)
        Me.btnref.TabIndex = 12
        Me.btnref.Text = "&Refresh"
        Me.btnref.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Location = New System.Drawing.Point(4, 17)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(96, 23)
        Me.btnexit.TabIndex = 13
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
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
        Me.dv.Location = New System.Drawing.Point(267, 21)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(46, 25)
        Me.dv.TabIndex = 134
        Me.dv.Visible = False
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuadd, Me.cmnuedit, Me.cmenudel, Me.cmnurefresh, Me.cmnuprint})
        Me.cmenu.Name = "ContextMenuStrip1"
        Me.cmenu.Size = New System.Drawing.Size(117, 114)
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
        'cmnuprint
        '
        Me.cmnuprint.Name = "cmnuprint"
        Me.cmnuprint.Size = New System.Drawing.Size(116, 22)
        Me.cmnuprint.Text = "Print."
        '
        'Column1
        '
        Me.Column1.HeaderText = "sl"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 46
        '
        'Column2
        '
        Me.Column2.HeaderText = "It Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 270
        '
        'Column4
        '
        Me.Column4.HeaderText = "Quantity"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 125
        '
        'Column5
        '
        Me.Column5.HeaderText = "Unit"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 96
        '
        'Column3
        '
        Me.Column3.HeaderText = "itcd"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        Me.Column3.Width = 56
        '
        'untcd
        '
        Me.untcd.HeaderText = "untcd"
        Me.untcd.Name = "untcd"
        Me.untcd.ReadOnly = True
        Me.untcd.Visible = False
        '
        'frmintrgodn
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(608, 348)
        Me.Controls.Add(Me.dv)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmintrgodn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inter Godown Transfer . . ."
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dv1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtscroll As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtref As System.Windows.Forms.TextBox
    Friend WithEvents dtref As System.Windows.Forms.DateTimePicker
    Friend WithEvents dttrans As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtsl As System.Windows.Forms.TextBox
    Friend WithEvents cmbproduct As System.Windows.Forms.ComboBox
    Friend WithEvents btnnext As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents btnref As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbgodto As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbgodfrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtgodto As System.Windows.Forms.TextBox
    Friend WithEvents txtgodfrom As System.Windows.Forms.TextBox
    Friend WithEvents txtitcd As System.Windows.Forms.TextBox
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuprint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnu1del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btninter As System.Windows.Forms.Button
    Friend WithEvents cmbunit As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtquantity As System.Windows.Forms.TextBox
    Friend WithEvents txtuntcd As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents untcd As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
