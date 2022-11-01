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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.grpsearch = New System.Windows.Forms.GroupBox
        Me.chkexact1 = New System.Windows.Forms.CheckBox
        Me.chkexact = New System.Windows.Forms.CheckBox
        Me.Label68 = New System.Windows.Forms.Label
        Me.txtsername = New System.Windows.Forms.TextBox
        Me.Label67 = New System.Windows.Forms.Label
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.lv = New System.Windows.Forms.ListView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btndelete = New System.Windows.Forms.Button
        Me.btnadd = New System.Windows.Forms.Button
        Me.btnedit = New System.Windows.Forms.Button
        Me.btnview = New System.Windows.Forms.Button
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dv = New System.Windows.Forms.DataGridView
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenuexpert = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbactp = New System.Windows.Forms.ComboBox
        Me.cmbmarket = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtcstno = New System.Windows.Forms.TextBox
        Me.cmbinout = New System.Windows.Forms.ComboBox
        Me.cmbbltp = New System.Windows.Forms.ComboBox
        Me.cmbtrans = New System.Windows.Forms.ComboBox
        Me.cmbcustom = New System.Windows.Forms.ComboBox
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
        Me.cmenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnu1del = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenu2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmenu2del = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenu3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmenu3del = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Panel1.SuspendLayout()
        Me.grpsearch.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenu.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.cmenu1.SuspendLayout()
        Me.cmenu2.SuspendLayout()
        Me.cmenu3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightCyan
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.grpsearch)
        Me.Panel1.Controls.Add(Me.GroupBox11)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(831, 526)
        Me.Panel1.TabIndex = 0
        '
        'grpsearch
        '
        Me.grpsearch.Controls.Add(Me.chkexact1)
        Me.grpsearch.Controls.Add(Me.chkexact)
        Me.grpsearch.Controls.Add(Me.Label68)
        Me.grpsearch.Controls.Add(Me.txtsername)
        Me.grpsearch.Controls.Add(Me.Label67)
        Me.grpsearch.Controls.Add(Me.txtadd)
        Me.grpsearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpsearch.ForeColor = System.Drawing.Color.Red
        Me.grpsearch.Location = New System.Drawing.Point(666, 383)
        Me.grpsearch.Name = "grpsearch"
        Me.grpsearch.Size = New System.Drawing.Size(166, 139)
        Me.grpsearch.TabIndex = 57
        Me.grpsearch.TabStop = False
        Me.grpsearch.Text = "Search"
        '
        'chkexact1
        '
        Me.chkexact1.AutoSize = True
        Me.chkexact1.Location = New System.Drawing.Point(14, 117)
        Me.chkexact1.Name = "chkexact1"
        Me.chkexact1.Size = New System.Drawing.Size(62, 17)
        Me.chkexact1.TabIndex = 59
        Me.chkexact1.Text = "Exact"
        Me.chkexact1.UseVisualStyleBackColor = True
        '
        'chkexact
        '
        Me.chkexact.AutoSize = True
        Me.chkexact.Location = New System.Drawing.Point(14, 58)
        Me.chkexact.Name = "chkexact"
        Me.chkexact.Size = New System.Drawing.Size(62, 17)
        Me.chkexact.TabIndex = 58
        Me.chkexact.Text = "Exact"
        Me.chkexact.UseVisualStyleBackColor = True
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label68.Location = New System.Drawing.Point(5, 76)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(52, 13)
        Me.Label68.TabIndex = 45
        Me.Label68.Text = "Name :"
        '
        'txtsername
        '
        Me.txtsername.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsername.Location = New System.Drawing.Point(6, 93)
        Me.txtsername.Name = "txtsername"
        Me.txtsername.Size = New System.Drawing.Size(156, 21)
        Me.txtsername.TabIndex = 59
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label67.Location = New System.Drawing.Point(5, 17)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(68, 13)
        Me.Label67.TabIndex = 43
        Me.Label67.Text = "Address :"
        '
        'txtadd
        '
        Me.txtadd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.Location = New System.Drawing.Point(6, 34)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(156, 21)
        Me.txtadd.TabIndex = 57
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.lv)
        Me.GroupBox11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.ForeColor = System.Drawing.Color.Red
        Me.GroupBox11.Location = New System.Drawing.Point(666, 243)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(166, 137)
        Me.GroupBox11.TabIndex = 60
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Last Party"
        '
        'lv
        '
        Me.lv.BackColor = System.Drawing.Color.LightCyan
        Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lv.GridLines = True
        Me.lv.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lv.Location = New System.Drawing.Point(3, 17)
        Me.lv.Name = "lv"
        Me.lv.Size = New System.Drawing.Size(160, 117)
        Me.lv.TabIndex = 60
        Me.lv.UseCompatibleStateImageBehavior = False
        Me.lv.View = System.Windows.Forms.View.List
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btndelete)
        Me.GroupBox1.Controls.Add(Me.btnadd)
        Me.GroupBox1.Controls.Add(Me.btnedit)
        Me.GroupBox1.Controls.Add(Me.btnview)
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(666, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(162, 235)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'btndelete
        '
        Me.btndelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btndelete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndelete.Location = New System.Drawing.Point(32, 140)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(99, 23)
        Me.btndelete.TabIndex = 25
        Me.btndelete.Text = "&Delete"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'btnadd
        '
        Me.btnadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnadd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadd.Location = New System.Drawing.Point(32, 50)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(99, 23)
        Me.btnadd.TabIndex = 22
        Me.btnadd.Text = "&Add"
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'btnedit
        '
        Me.btnedit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnedit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnedit.Location = New System.Drawing.Point(32, 80)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(99, 23)
        Me.btnedit.TabIndex = 23
        Me.btnedit.Text = "&Edit"
        Me.btnedit.UseVisualStyleBackColor = True
        '
        'btnview
        '
        Me.btnview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnview.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnview.Location = New System.Drawing.Point(32, 170)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(99, 23)
        Me.btnview.TabIndex = 26
        Me.btnview.Text = "&View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(32, 110)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(99, 23)
        Me.btnrefresh.TabIndex = 24
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(32, 200)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(99, 23)
        Me.btnexit.TabIndex = 27
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(32, 20)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(99, 23)
        Me.btnsave.TabIndex = 21
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dv)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Location = New System.Drawing.Point(1, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(659, 519)
        Me.Panel2.TabIndex = 0
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
        Me.dv.Location = New System.Drawing.Point(550, 6)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(33, 22)
        Me.dv.TabIndex = 162
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuadd, Me.cmnuedit, Me.cmenudel, Me.cmnurefresh, Me.cmenuexpert})
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
        'cmenuexpert
        '
        Me.cmenuexpert.Name = "cmenuexpert"
        Me.cmenuexpert.Size = New System.Drawing.Size(116, 22)
        Me.cmenuexpert.Text = "Expert"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbactp)
        Me.GroupBox2.Controls.Add(Me.cmbmarket)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtcstno)
        Me.GroupBox2.Controls.Add(Me.cmbinout)
        Me.GroupBox2.Controls.Add(Me.cmbbltp)
        Me.GroupBox2.Controls.Add(Me.cmbtrans)
        Me.GroupBox2.Controls.Add(Me.cmbcustom)
        Me.GroupBox2.Controls.Add(Me.cmblock)
        Me.GroupBox2.Controls.Add(Me.txtparty)
        Me.GroupBox2.Controls.Add(Me.txtmarkcd)
        Me.GroupBox2.Controls.Add(Me.chkautosm)
        Me.GroupBox2.Controls.Add(Me.chkautoem)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtlimit)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txttrans)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtbill)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtmailid)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtactp)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtperson)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtscrl)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtregno)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtcont2)
        Me.GroupBox2.Controls.Add(Me.txtopbl)
        Me.GroupBox2.Controls.Add(Me.txtcont1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtadd1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Red
        Me.GroupBox2.Location = New System.Drawing.Point(35, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(586, 414)
        Me.GroupBox2.TabIndex = 124
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Party Entry . . . "
        '
        'cmbactp
        '
        Me.cmbactp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbactp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbactp.FormattingEnabled = True
        Me.cmbactp.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmbactp.Location = New System.Drawing.Point(158, 218)
        Me.cmbactp.Name = "cmbactp"
        Me.cmbactp.Size = New System.Drawing.Size(175, 21)
        Me.cmbactp.TabIndex = 7
        '
        'cmbmarket
        '
        Me.cmbmarket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbmarket.FormattingEnabled = True
        Me.cmbmarket.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmbmarket.Location = New System.Drawing.Point(405, 325)
        Me.cmbmarket.Name = "cmbmarket"
        Me.cmbmarket.Size = New System.Drawing.Size(114, 21)
        Me.cmbmarket.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(209, 262)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 13)
        Me.Label5.TabIndex = 164
        Me.Label5.Text = "GST T.I.N/S.R.I.N"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(405, 262)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 163
        Me.Label4.Text = "C.S.T No."
        '
        'txtcstno
        '
        Me.txtcstno.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcstno.Location = New System.Drawing.Point(335, 278)
        Me.txtcstno.MaxLength = 30
        Me.txtcstno.Name = "txtcstno"
        Me.txtcstno.Size = New System.Drawing.Size(184, 21)
        Me.txtcstno.TabIndex = 20
        '
        'cmbinout
        '
        Me.cmbinout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbinout.FormattingEnabled = True
        Me.cmbinout.Items.AddRange(New Object() {"1.Inside State", "2.Outside State"})
        Me.cmbinout.Location = New System.Drawing.Point(334, 218)
        Me.cmbinout.Name = "cmbinout"
        Me.cmbinout.Size = New System.Drawing.Size(185, 21)
        Me.cmbinout.TabIndex = 8
        '
        'cmbbltp
        '
        Me.cmbbltp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbltp.FormattingEnabled = True
        Me.cmbbltp.Items.AddRange(New Object() {"Cr.", "Dr."})
        Me.cmbbltp.Location = New System.Drawing.Point(335, 241)
        Me.cmbbltp.Name = "cmbbltp"
        Me.cmbbltp.Size = New System.Drawing.Size(43, 21)
        Me.cmbbltp.TabIndex = 10
        '
        'cmbtrans
        '
        Me.cmbtrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtrans.FormattingEnabled = True
        Me.cmbtrans.Items.AddRange(New Object() {"Cr.", "Dr."})
        Me.cmbtrans.Location = New System.Drawing.Point(252, 302)
        Me.cmbtrans.Name = "cmbtrans"
        Me.cmbtrans.Size = New System.Drawing.Size(42, 21)
        Me.cmbtrans.TabIndex = 14
        '
        'cmbcustom
        '
        Me.cmbcustom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcustom.FormattingEnabled = True
        Me.cmbcustom.Items.AddRange(New Object() {"1.Cat. One", "2.Cat. Two", "3.Cat. Three", "4.Cat. Four"})
        Me.cmbcustom.Location = New System.Drawing.Point(158, 325)
        Me.cmbcustom.Name = "cmbcustom"
        Me.cmbcustom.Size = New System.Drawing.Size(136, 21)
        Me.cmbcustom.TabIndex = 16
        '
        'cmblock
        '
        Me.cmblock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmblock.FormattingEnabled = True
        Me.cmblock.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmblock.Location = New System.Drawing.Point(459, 352)
        Me.cmblock.Name = "cmblock"
        Me.cmblock.Size = New System.Drawing.Size(60, 21)
        Me.cmblock.TabIndex = 20
        '
        'txtparty
        '
        Me.txtparty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtparty.Location = New System.Drawing.Point(158, 49)
        Me.txtparty.MaxLength = 50
        Me.txtparty.Name = "txtparty"
        Me.txtparty.Size = New System.Drawing.Size(361, 21)
        Me.txtparty.TabIndex = 0
        '
        'txtmarkcd
        '
        Me.txtmarkcd.Location = New System.Drawing.Point(524, 324)
        Me.txtmarkcd.Name = "txtmarkcd"
        Me.txtmarkcd.Size = New System.Drawing.Size(24, 21)
        Me.txtmarkcd.TabIndex = 161
        Me.txtmarkcd.Visible = False
        '
        'chkautosm
        '
        Me.chkautosm.AutoSize = True
        Me.chkautosm.ForeColor = System.Drawing.Color.Red
        Me.chkautosm.Location = New System.Drawing.Point(281, 356)
        Me.chkautosm.Name = "chkautosm"
        Me.chkautosm.Size = New System.Drawing.Size(86, 17)
        Me.chkautosm.TabIndex = 19
        Me.chkautosm.Text = "Auto SMS"
        Me.chkautosm.UseVisualStyleBackColor = True
        '
        'chkautoem
        '
        Me.chkautoem.AutoSize = True
        Me.chkautoem.ForeColor = System.Drawing.Color.Red
        Me.chkautoem.Location = New System.Drawing.Point(153, 354)
        Me.chkautoem.Name = "chkautoem"
        Me.chkautoem.Size = New System.Drawing.Size(96, 17)
        Me.chkautoem.TabIndex = 18
        Me.chkautoem.Text = "Auto Email"
        Me.chkautoem.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(7, 328)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(148, 13)
        Me.Label16.TabIndex = 160
        Me.Label16.Text = "Customer Categorey :"
        '
        'txtlimit
        '
        Me.txtlimit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlimit.Location = New System.Drawing.Point(405, 301)
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
        Me.Label15.Location = New System.Drawing.Point(319, 305)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 13)
        Me.Label15.TabIndex = 159
        Me.Label15.Text = "Limit Days :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(23, 304)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(132, 13)
        Me.Label14.TabIndex = 158
        Me.Label14.Text = "Transaction Limit  :"
        '
        'txttrans
        '
        Me.txttrans.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttrans.Location = New System.Drawing.Point(158, 301)
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
        Me.Label13.Location = New System.Drawing.Point(301, 328)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 13)
        Me.Label13.TabIndex = 157
        Me.Label13.Text = "Market Name :"
        '
        'txtbill
        '
        Me.txtbill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbill.Location = New System.Drawing.Point(158, 72)
        Me.txtbill.MaxLength = 50
        Me.txtbill.Name = "txtbill"
        Me.txtbill.Size = New System.Drawing.Size(361, 21)
        Me.txtbill.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(59, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 13)
        Me.Label12.TabIndex = 156
        Me.Label12.Text = "Billing Name :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(32, 245)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 13)
        Me.Label11.TabIndex = 155
        Me.Label11.Text = "Opening Balance :"
        '
        'txtmailid
        '
        Me.txtmailid.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmailid.Location = New System.Drawing.Point(158, 195)
        Me.txtmailid.MaxLength = 70
        Me.txtmailid.Name = "txtmailid"
        Me.txtmailid.Size = New System.Drawing.Size(361, 21)
        Me.txtmailid.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(85, 198)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 154
        Me.Label10.Text = "Email ID :"
        '
        'txtactp
        '
        Me.txtactp.Location = New System.Drawing.Point(524, 218)
        Me.txtactp.Name = "txtactp"
        Me.txtactp.Size = New System.Drawing.Size(24, 21)
        Me.txtactp.TabIndex = 153
        Me.txtactp.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(40, 221)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 13)
        Me.Label9.TabIndex = 152
        Me.Label9.Text = "* Account Type :"
        '
        'txtperson
        '
        Me.txtperson.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtperson.Location = New System.Drawing.Point(158, 95)
        Me.txtperson.MaxLength = 50
        Me.txtperson.Name = "txtperson"
        Me.txtperson.Size = New System.Drawing.Size(361, 21)
        Me.txtperson.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(38, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 13)
        Me.Label8.TabIndex = 151
        Me.Label8.Text = "Concern Person :"
        '
        'txtscrl
        '
        Me.txtscrl.Location = New System.Drawing.Point(158, 22)
        Me.txtscrl.Name = "txtscrl"
        Me.txtscrl.Size = New System.Drawing.Size(24, 21)
        Me.txtscrl.TabIndex = 148
        Me.txtscrl.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(389, 355)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = "Locked :"
        '
        'txtregno
        '
        Me.txtregno.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtregno.Location = New System.Drawing.Point(158, 278)
        Me.txtregno.MaxLength = 20
        Me.txtregno.Name = "txtregno"
        Me.txtregno.Size = New System.Drawing.Size(175, 21)
        Me.txtregno.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(83, 280)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 141
        Me.Label6.Text = "Regd. No :"
        '
        'txtcont2
        '
        Me.txtcont2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcont2.Location = New System.Drawing.Point(334, 172)
        Me.txtcont2.MaxLength = 15
        Me.txtcont2.Name = "txtcont2"
        Me.txtcont2.Size = New System.Drawing.Size(185, 21)
        Me.txtcont2.TabIndex = 5
        '
        'txtopbl
        '
        Me.txtopbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopbl.Location = New System.Drawing.Point(158, 241)
        Me.txtopbl.MaxLength = 11
        Me.txtopbl.Name = "txtopbl"
        Me.txtopbl.Size = New System.Drawing.Size(175, 21)
        Me.txtopbl.TabIndex = 9
        Me.txtopbl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcont1
        '
        Me.txtcont1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcont1.Location = New System.Drawing.Point(158, 172)
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
        Me.Label3.Location = New System.Drawing.Point(84, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Contacts :"
        '
        'txtadd1
        '
        Me.txtadd1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd1.Location = New System.Drawing.Point(158, 118)
        Me.txtadd1.MaxLength = 100
        Me.txtadd1.Multiline = True
        Me.txtadd1.Name = "txtadd1"
        Me.txtadd1.Size = New System.Drawing.Size(361, 52)
        Me.txtadd1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(87, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "Address :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(52, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 126
        Me.Label1.Text = "* Party Name :"
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
        'cmenu2
        '
        Me.cmenu2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmenu2del})
        Me.cmenu2.Name = "ContextMenuStrip1"
        Me.cmenu2.Size = New System.Drawing.Size(108, 26)
        '
        'cmenu2del
        '
        Me.cmenu2del.Name = "cmenu2del"
        Me.cmenu2del.Size = New System.Drawing.Size(107, 22)
        Me.cmenu2del.Text = "Delete"
        '
        'cmenu3
        '
        Me.cmenu3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmenu3del})
        Me.cmenu3.Name = "ContextMenuStrip1"
        Me.cmenu3.Size = New System.Drawing.Size(108, 26)
        '
        'cmenu3del
        '
        Me.cmenu3del.Name = "cmenu3del"
        Me.cmenu3del.Size = New System.Drawing.Size(107, 22)
        Me.cmenu3del.Text = "Delete"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmparty
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(835, 530)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmparty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmpartymst"
        Me.Panel1.ResumeLayout(False)
        Me.grpsearch.ResumeLayout(False)
        Me.grpsearch.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.cmenu1.ResumeLayout(False)
        Me.cmenu2.ResumeLayout(False)
        Me.cmenu3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grpsearch As System.Windows.Forms.GroupBox
    Friend WithEvents chkexact1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkexact As System.Windows.Forms.CheckBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents txtsername As System.Windows.Forms.TextBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents lv As System.Windows.Forms.ListView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnu1del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenu2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmenu2del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenu3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmenu3del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents cmbactp As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcstno As System.Windows.Forms.TextBox
    Friend WithEvents cmbinout As System.Windows.Forms.ComboBox
    Friend WithEvents cmbbltp As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtrans As System.Windows.Forms.ComboBox
    Friend WithEvents cmbcustom As System.Windows.Forms.ComboBox
    Friend WithEvents cmbmarket As System.Windows.Forms.ComboBox
    Friend WithEvents cmblock As System.Windows.Forms.ComboBox
    Friend WithEvents txtparty As System.Windows.Forms.TextBox
    Friend WithEvents txtmarkcd As System.Windows.Forms.TextBox
    Friend WithEvents chkautosm As System.Windows.Forms.CheckBox
    Friend WithEvents chkautoem As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtlimit As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txttrans As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtbill As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtmailid As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtactp As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtperson As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtscrl As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtregno As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcont2 As System.Windows.Forms.TextBox
    Friend WithEvents txtopbl As System.Windows.Forms.TextBox
    Friend WithEvents txtcont1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtadd1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmenuexpert As System.Windows.Forms.ToolStripMenuItem

End Class
