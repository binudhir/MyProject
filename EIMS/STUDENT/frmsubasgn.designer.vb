<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsubasgn
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dv = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtsubcd = New System.Windows.Forms.TextBox
        Me.txtstrmcd = New System.Windows.Forms.TextBox
        Me.txtacdncd = New System.Windows.Forms.TextBox
        Me.txtsesncd = New System.Windows.Forms.TextBox
        Me.cmbsessn = New System.Windows.Forms.ComboBox
        Me.cmbacdmyr = New System.Windows.Forms.ComboBox
        Me.cmbstrm = New System.Windows.Forms.ComboBox
        Me.cmbsubnm = New System.Windows.Forms.ComboBox
        Me.dv1 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuclr = New System.Windows.Forms.ToolStripMenuItem
        Me.txtstdsl = New System.Windows.Forms.TextBox
        Me.btnshow = New System.Windows.Forms.Button
        Me.rddall = New System.Windows.Forms.RadioButton
        Me.txtslno = New System.Windows.Forms.TextBox
        Me.rdall = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkcnfr = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnnext = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.cmbtype = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnswap = New System.Windows.Forms.Button
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenuview = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenusearch = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuexpert = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1.SuspendLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenu1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.dv)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(921, 488)
        Me.Panel1.TabIndex = 0
        '
        'dv
        '
        Me.dv.AllowUserToAddRows = False
        Me.dv.AllowUserToDeleteRows = False
        Me.dv.AllowUserToResizeColumns = False
        Me.dv.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.dv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dv.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column10, Me.Column2, Me.Column3, Me.Column4, Me.Column7, Me.Column5})
        Me.dv.GridColor = System.Drawing.Color.Black
        Me.dv.Location = New System.Drawing.Point(2, 3)
        Me.dv.Name = "dv"
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Azure
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(527, 425)
        Me.dv.TabIndex = 36
        '
        'Column1
        '
        Me.Column1.FalseValue = "0"
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column1.TrueValue = "1"
        Me.Column1.Width = 44
        '
        'Column10
        '
        Me.Column10.HeaderText = "Sl."
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 45
        '
        'Column2
        '
        Me.Column2.HeaderText = "Regd No."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 89
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Student Name"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Academic Year"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 130
        '
        'Column7
        '
        Me.Column7.HeaderText = "Column7"
        Me.Column7.Name = "Column7"
        Me.Column7.Visible = False
        Me.Column7.Width = 88
        '
        'Column5
        '
        Me.Column5.HeaderText = "Column5"
        Me.Column5.Name = "Column5"
        Me.Column5.Visible = False
        Me.Column5.Width = 88
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtsubcd)
        Me.GroupBox2.Controls.Add(Me.txtstrmcd)
        Me.GroupBox2.Controls.Add(Me.txtacdncd)
        Me.GroupBox2.Controls.Add(Me.txtsesncd)
        Me.GroupBox2.Controls.Add(Me.cmbsessn)
        Me.GroupBox2.Controls.Add(Me.cmbacdmyr)
        Me.GroupBox2.Controls.Add(Me.cmbstrm)
        Me.GroupBox2.Controls.Add(Me.cmbsubnm)
        Me.GroupBox2.Controls.Add(Me.dv1)
        Me.GroupBox2.Controls.Add(Me.txtstdsl)
        Me.GroupBox2.Controls.Add(Me.btnshow)
        Me.GroupBox2.Controls.Add(Me.rddall)
        Me.GroupBox2.Controls.Add(Me.txtslno)
        Me.GroupBox2.Controls.Add(Me.rdall)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.chkcnfr)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnnext)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.cmbtype)
        Me.GroupBox2.Location = New System.Drawing.Point(532, -1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(379, 429)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        '
        'txtsubcd
        '
        Me.txtsubcd.Location = New System.Drawing.Point(136, 90)
        Me.txtsubcd.Name = "txtsubcd"
        Me.txtsubcd.Size = New System.Drawing.Size(22, 21)
        Me.txtsubcd.TabIndex = 40
        Me.txtsubcd.Visible = False
        '
        'txtstrmcd
        '
        Me.txtstrmcd.Location = New System.Drawing.Point(239, 90)
        Me.txtstrmcd.Name = "txtstrmcd"
        Me.txtstrmcd.Size = New System.Drawing.Size(22, 21)
        Me.txtstrmcd.TabIndex = 39
        Me.txtstrmcd.Visible = False
        '
        'txtacdncd
        '
        Me.txtacdncd.Location = New System.Drawing.Point(214, 90)
        Me.txtacdncd.Name = "txtacdncd"
        Me.txtacdncd.Size = New System.Drawing.Size(22, 21)
        Me.txtacdncd.TabIndex = 38
        Me.txtacdncd.Visible = False
        '
        'txtsesncd
        '
        Me.txtsesncd.Location = New System.Drawing.Point(188, 90)
        Me.txtsesncd.Name = "txtsesncd"
        Me.txtsesncd.Size = New System.Drawing.Size(22, 21)
        Me.txtsesncd.TabIndex = 37
        Me.txtsesncd.Visible = False
        '
        'cmbsessn
        '
        Me.cmbsessn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbsessn.FormattingEnabled = True
        Me.cmbsessn.Location = New System.Drawing.Point(135, 16)
        Me.cmbsessn.Name = "cmbsessn"
        Me.cmbsessn.Size = New System.Drawing.Size(238, 20)
        Me.cmbsessn.TabIndex = 0
        '
        'cmbacdmyr
        '
        Me.cmbacdmyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbacdmyr.FormattingEnabled = True
        Me.cmbacdmyr.Location = New System.Drawing.Point(135, 41)
        Me.cmbacdmyr.Name = "cmbacdmyr"
        Me.cmbacdmyr.Size = New System.Drawing.Size(238, 20)
        Me.cmbacdmyr.TabIndex = 1
        '
        'cmbstrm
        '
        Me.cmbstrm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbstrm.FormattingEnabled = True
        Me.cmbstrm.Location = New System.Drawing.Point(135, 66)
        Me.cmbstrm.Name = "cmbstrm"
        Me.cmbstrm.Size = New System.Drawing.Size(238, 20)
        Me.cmbstrm.TabIndex = 2
        '
        'cmbsubnm
        '
        Me.cmbsubnm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbsubnm.FormattingEnabled = True
        Me.cmbsubnm.Location = New System.Drawing.Point(171, 135)
        Me.cmbsubnm.Name = "cmbsubnm"
        Me.cmbsubnm.Size = New System.Drawing.Size(151, 20)
        Me.cmbsubnm.TabIndex = 5
        '
        'dv1
        '
        Me.dv1.AllowUserToAddRows = False
        Me.dv1.AllowUserToDeleteRows = False
        Me.dv1.AllowUserToResizeColumns = False
        Me.dv1.AllowUserToResizeRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightCyan
        Me.dv1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dv1.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv1.ColumnHeadersVisible = False
        Me.dv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Column8, Me.Column9, Me.Column11, Me.Column6})
        Me.dv1.ContextMenuStrip = Me.cmenu1
        Me.dv1.GridColor = System.Drawing.Color.Black
        Me.dv1.Location = New System.Drawing.Point(4, 158)
        Me.dv1.Name = "dv1"
        Me.dv1.ReadOnly = True
        Me.dv1.RowHeadersVisible = False
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightCyan
        Me.dv1.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dv1.RowTemplate.Height = 20
        Me.dv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv1.Size = New System.Drawing.Size(372, 216)
        Me.dv1.TabIndex = 36
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Sl"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 36
        '
        'Column8
        '
        Me.Column8.HeaderText = "Type"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 129
        '
        'Column9
        '
        Me.Column9.HeaderText = "Subject"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 151
        '
        'Column11
        '
        Me.Column11.HeaderText = "Column11"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "Column6"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'cmenu1
        '
        Me.cmenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnudel, Me.cmnuclr})
        Me.cmenu1.Name = "ContextMenuStrip1"
        Me.cmenu1.Size = New System.Drawing.Size(108, 48)
        '
        'cmnudel
        '
        Me.cmnudel.Name = "cmnudel"
        Me.cmnudel.Size = New System.Drawing.Size(107, 22)
        Me.cmnudel.Text = "Delete"
        '
        'cmnuclr
        '
        Me.cmnuclr.Name = "cmnuclr"
        Me.cmnuclr.Size = New System.Drawing.Size(107, 22)
        Me.cmnuclr.Text = "Clear"
        '
        'txtstdsl
        '
        Me.txtstdsl.Location = New System.Drawing.Point(164, 90)
        Me.txtstdsl.Name = "txtstdsl"
        Me.txtstdsl.Size = New System.Drawing.Size(22, 21)
        Me.txtstdsl.TabIndex = 18
        Me.txtstdsl.Visible = False
        '
        'btnshow
        '
        Me.btnshow.Location = New System.Drawing.Point(264, 88)
        Me.btnshow.Name = "btnshow"
        Me.btnshow.Size = New System.Drawing.Size(109, 23)
        Me.btnshow.TabIndex = 35
        Me.btnshow.Text = "&Show List"
        Me.btnshow.UseVisualStyleBackColor = True
        '
        'rddall
        '
        Me.rddall.AutoSize = True
        Me.rddall.Location = New System.Drawing.Point(217, 402)
        Me.rddall.Name = "rddall"
        Me.rddall.Size = New System.Drawing.Size(156, 17)
        Me.rddall.TabIndex = 34
        Me.rddall.Text = "Deselect All Student"
        Me.rddall.UseVisualStyleBackColor = True
        '
        'txtslno
        '
        Me.txtslno.Enabled = False
        Me.txtslno.Location = New System.Drawing.Point(4, 135)
        Me.txtslno.Name = "txtslno"
        Me.txtslno.Size = New System.Drawing.Size(36, 21)
        Me.txtslno.TabIndex = 3
        '
        'rdall
        '
        Me.rdall.AutoSize = True
        Me.rdall.Checked = True
        Me.rdall.Location = New System.Drawing.Point(10, 402)
        Me.rdall.Name = "rdall"
        Me.rdall.Size = New System.Drawing.Size(140, 17)
        Me.rdall.TabIndex = 33
        Me.rdall.TabStop = True
        Me.rdall.Text = "Select All Student"
        Me.rdall.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(65, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Sassion :"
        '
        'chkcnfr
        '
        Me.chkcnfr.AutoSize = True
        Me.chkcnfr.ForeColor = System.Drawing.Color.Red
        Me.chkcnfr.Location = New System.Drawing.Point(10, 380)
        Me.chkcnfr.Name = "chkcnfr"
        Me.chkcnfr.Size = New System.Drawing.Size(199, 17)
        Me.chkcnfr.TabIndex = 32
        Me.chkcnfr.Text = "Confirm Massage Required"
        Me.chkcnfr.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(81, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Class :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(68, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Branch :"
        '
        'btnnext
        '
        Me.btnnext.Location = New System.Drawing.Point(321, 134)
        Me.btnnext.Name = "btnnext"
        Me.btnnext.Size = New System.Drawing.Size(56, 23)
        Me.btnnext.TabIndex = 30
        Me.btnnext.Text = "&Next"
        Me.btnnext.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.NavajoWhite
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(6, 113)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(370, 21)
        Me.TextBox1.TabIndex = 26
        Me.TextBox1.Text = "   Sl             Type                    Subject Name"
        '
        'cmbtype
        '
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"1.Compulsory", "2.Optional", "3.Elective", "4.Others"})
        Me.cmbtype.Location = New System.Drawing.Point(41, 135)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(129, 21)
        Me.cmbtype.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnswap)
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(4, 433)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(911, 49)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'btnswap
        '
        Me.btnswap.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnswap.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnswap.Location = New System.Drawing.Point(267, 20)
        Me.btnswap.Name = "btnswap"
        Me.btnswap.Size = New System.Drawing.Size(111, 23)
        Me.btnswap.TabIndex = 3
        Me.btnswap.Text = "&Swap"
        Me.btnswap.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(528, 20)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(111, 23)
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
        Me.btnexit.Size = New System.Drawing.Size(111, 23)
        Me.btnexit.TabIndex = 1
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(789, 20)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(111, 23)
        Me.btnsave.TabIndex = 0
        Me.btnsave.Text = "&Assign"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuadd, Me.cmnuedit, Me.cmenudel, Me.cmenuview, Me.cmnurefresh, Me.cmenusearch, Me.mnuexpert})
        Me.cmenu.Name = "ContextMenuStrip1"
        Me.cmenu.Size = New System.Drawing.Size(153, 180)
        '
        'cmnuadd
        '
        Me.cmnuadd.Name = "cmnuadd"
        Me.cmnuadd.Size = New System.Drawing.Size(152, 22)
        Me.cmnuadd.Text = "Add."
        '
        'cmnuedit
        '
        Me.cmnuedit.Name = "cmnuedit"
        Me.cmnuedit.Size = New System.Drawing.Size(152, 22)
        Me.cmnuedit.Text = "Edit."
        '
        'cmenudel
        '
        Me.cmenudel.Name = "cmenudel"
        Me.cmenudel.Size = New System.Drawing.Size(152, 22)
        Me.cmenudel.Text = "Delete."
        '
        'cmnurefresh
        '
        Me.cmnurefresh.Name = "cmnurefresh"
        Me.cmnurefresh.Size = New System.Drawing.Size(152, 22)
        Me.cmnurefresh.Text = "Refresh."
        '
        'cmenuview
        '
        Me.cmenuview.Name = "cmenuview"
        Me.cmenuview.Size = New System.Drawing.Size(152, 22)
        Me.cmenuview.Text = "View."
        '
        'cmenusearch
        '
        Me.cmenusearch.Name = "cmenusearch"
        Me.cmenusearch.Size = New System.Drawing.Size(152, 22)
        Me.cmenusearch.Text = "Search."
        '
        'mnuexpert
        '
        Me.mnuexpert.Name = "mnuexpert"
        Me.mnuexpert.Size = New System.Drawing.Size(152, 22)
        Me.mnuexpert.Text = "Expert."
        '
        'frmsubasgn
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(926, 493)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmsubasgn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Student Subject Assignment.(Entry Screen)"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.cmenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents txtstdsl As System.Windows.Forms.TextBox
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnswap As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmbstrm As System.Windows.Forms.ComboBox
    Friend WithEvents cmbacdmyr As System.Windows.Forms.ComboBox
    Friend WithEvents cmbsessn As System.Windows.Forms.ComboBox
    Friend WithEvents cmbsubnm As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents btnnext As System.Windows.Forms.Button
    Friend WithEvents rddall As System.Windows.Forms.RadioButton
    Friend WithEvents rdall As System.Windows.Forms.RadioButton
    Friend WithEvents chkcnfr As System.Windows.Forms.CheckBox
    Friend WithEvents txtslno As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnshow As System.Windows.Forms.Button
    Friend WithEvents dv1 As System.Windows.Forms.DataGridView
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents txtstrmcd As System.Windows.Forms.TextBox
    Friend WithEvents txtacdncd As System.Windows.Forms.TextBox
    Friend WithEvents txtsesncd As System.Windows.Forms.TextBox
    Friend WithEvents txtsubcd As System.Windows.Forms.TextBox
    Friend WithEvents cmenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuclr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmenuview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenusearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuexpert As System.Windows.Forms.ToolStripMenuItem

End Class
