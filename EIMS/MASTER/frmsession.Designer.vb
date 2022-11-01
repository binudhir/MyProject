<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsession
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtacdur = New System.Windows.Forms.TextBox
        Me.txtacdmcd = New System.Windows.Forms.TextBox
        Me.btnnext = New System.Windows.Forms.Button
        Me.aendt = New System.Windows.Forms.DateTimePicker
        Me.astdt = New System.Windows.Forms.DateTimePicker
        Me.cmbacyr = New System.Windows.Forms.ComboBox
        Me.txtsl = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dv1 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnu1del = New System.Windows.Forms.ToolStripMenuItem
        Me.Label12 = New System.Windows.Forms.Label
        Me.enddt = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.startdt = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtscrl = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnview = New System.Windows.Forms.Button
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.cmblock = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtduration = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtsession = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dv = New System.Windows.Forms.DataGridView
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenuview = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuexport = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenusearch = New System.Windows.Forms.ToolStripMenuItem
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
        Me.Panel1.Controls.Add(Me.txtacdur)
        Me.Panel1.Controls.Add(Me.txtacdmcd)
        Me.Panel1.Controls.Add(Me.btnnext)
        Me.Panel1.Controls.Add(Me.aendt)
        Me.Panel1.Controls.Add(Me.astdt)
        Me.Panel1.Controls.Add(Me.cmbacyr)
        Me.Panel1.Controls.Add(Me.txtsl)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dv1)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.enddt)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.startdt)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtscrl)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.cmblock)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtduration)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtsession)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(516, 356)
        Me.Panel1.TabIndex = 0
        '
        'txtacdur
        '
        Me.txtacdur.Location = New System.Drawing.Point(373, 276)
        Me.txtacdur.Name = "txtacdur"
        Me.txtacdur.Size = New System.Drawing.Size(36, 21)
        Me.txtacdur.TabIndex = 33
        Me.txtacdur.Visible = False
        '
        'txtacdmcd
        '
        Me.txtacdmcd.Location = New System.Drawing.Point(415, 276)
        Me.txtacdmcd.Name = "txtacdmcd"
        Me.txtacdmcd.Size = New System.Drawing.Size(36, 21)
        Me.txtacdmcd.TabIndex = 32
        Me.txtacdmcd.Visible = False
        '
        'btnnext
        '
        Me.btnnext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnnext.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnext.Location = New System.Drawing.Point(428, 128)
        Me.btnnext.Name = "btnnext"
        Me.btnnext.Size = New System.Drawing.Size(53, 21)
        Me.btnnext.TabIndex = 7
        Me.btnnext.Text = "&Next"
        Me.btnnext.UseVisualStyleBackColor = True
        '
        'aendt
        '
        Me.aendt.CalendarForeColor = System.Drawing.Color.Black
        Me.aendt.CustomFormat = "dd/MM/yyyy"
        Me.aendt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.aendt.Location = New System.Drawing.Point(323, 129)
        Me.aendt.Name = "aendt"
        Me.aendt.Size = New System.Drawing.Size(105, 21)
        Me.aendt.TabIndex = 6
        '
        'astdt
        '
        Me.astdt.CalendarForeColor = System.Drawing.Color.Black
        Me.astdt.CustomFormat = "dd/MM/yyyy"
        Me.astdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.astdt.Location = New System.Drawing.Point(217, 129)
        Me.astdt.Name = "astdt"
        Me.astdt.Size = New System.Drawing.Size(105, 21)
        Me.astdt.TabIndex = 5
        '
        'cmbacyr
        '
        Me.cmbacyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbacyr.FormattingEnabled = True
        Me.cmbacyr.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmbacyr.Location = New System.Drawing.Point(62, 129)
        Me.cmbacyr.Name = "cmbacyr"
        Me.cmbacyr.Size = New System.Drawing.Size(154, 21)
        Me.cmbacyr.TabIndex = 4
        '
        'txtsl
        '
        Me.txtsl.Enabled = False
        Me.txtsl.Location = New System.Drawing.Point(30, 129)
        Me.txtsl.Name = "txtsl"
        Me.txtsl.Size = New System.Drawing.Size(31, 21)
        Me.txtsl.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Lavender
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(30, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(451, 15)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "   Sl        Academic Year         Starting Date     Ending Date"
        '
        'dv1
        '
        Me.dv1.AllowUserToAddRows = False
        Me.dv1.AllowUserToDeleteRows = False
        Me.dv1.AllowUserToResizeColumns = False
        Me.dv1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan
        Me.dv1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dv1.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv1.ColumnHeadersVisible = False
        Me.dv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Column8, Me.Column9, Me.Column10, Me.DataGridViewTextBoxColumn7, Me.Column6, Me.Column11})
        Me.dv1.ContextMenuStrip = Me.cmenu1
        Me.dv1.GridColor = System.Drawing.Color.Black
        Me.dv1.Location = New System.Drawing.Point(30, 151)
        Me.dv1.Name = "dv1"
        Me.dv1.ReadOnly = True
        Me.dv1.RowHeadersVisible = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan
        Me.dv1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dv1.RowTemplate.Height = 20
        Me.dv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv1.Size = New System.Drawing.Size(451, 119)
        Me.dv1.TabIndex = 29
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Sl"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 43
        '
        'Column8
        '
        Me.Column8.HeaderText = "Academic Year"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 150
        '
        'Column9
        '
        Me.Column9.HeaderText = "Start Date"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 105
        '
        'Column10
        '
        Me.Column10.HeaderText = "End Date"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 105
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Column5"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 83
        '
        'Column6
        '
        Me.Column6.HeaderText = "Column6"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'Column11
        '
        Me.Column11.HeaderText = "Column11"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Visible = False
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
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(304, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "End Date :"
        '
        'enddt
        '
        Me.enddt.CalendarForeColor = System.Drawing.Color.Black
        Me.enddt.CustomFormat = "dd/MM/yyyy"
        Me.enddt.Enabled = False
        Me.enddt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.enddt.Location = New System.Drawing.Point(379, 86)
        Me.enddt.Name = "enddt"
        Me.enddt.Size = New System.Drawing.Size(102, 21)
        Me.enddt.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(31, 91)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Start Date :"
        '
        'startdt
        '
        Me.startdt.CalendarForeColor = System.Drawing.Color.Black
        Me.startdt.CustomFormat = "dd/MM/yyyy"
        Me.startdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.startdt.Location = New System.Drawing.Point(114, 88)
        Me.startdt.Name = "startdt"
        Me.startdt.Size = New System.Drawing.Size(110, 21)
        Me.startdt.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(426, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "(In Months)"
        '
        'txtscrl
        '
        Me.txtscrl.Location = New System.Drawing.Point(466, 275)
        Me.txtscrl.Name = "txtscrl"
        Me.txtscrl.Size = New System.Drawing.Size(36, 21)
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
        Me.GroupBox1.Location = New System.Drawing.Point(7, 299)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(501, 49)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'btnview
        '
        Me.btnview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnview.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnview.Location = New System.Drawing.Point(144, 20)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(75, 23)
        Me.btnview.TabIndex = 11
        Me.btnview.Text = "&View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(282, 20)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 10
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
        Me.btnexit.TabIndex = 12
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
        Me.btnsave.TabIndex = 9
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'cmblock
        '
        Me.cmblock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmblock.FormattingEnabled = True
        Me.cmblock.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmblock.Location = New System.Drawing.Point(114, 272)
        Me.cmblock.Name = "cmblock"
        Me.cmblock.Size = New System.Drawing.Size(60, 21)
        Me.cmblock.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(51, 275)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Locked :"
        '
        'txtduration
        '
        Me.txtduration.Location = New System.Drawing.Point(379, 63)
        Me.txtduration.MaxLength = 4
        Me.txtduration.Name = "txtduration"
        Me.txtduration.Size = New System.Drawing.Size(41, 21)
        Me.txtduration.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(307, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Duration :"
        '
        'txtsession
        '
        Me.txtsession.Location = New System.Drawing.Point(114, 65)
        Me.txtsession.MaxLength = 25
        Me.txtsession.Name = "txtsession"
        Me.txtsession.Size = New System.Drawing.Size(110, 21)
        Me.txtsession.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Session Name :"
        '
        'dv
        '
        Me.dv.AllowUserToAddRows = False
        Me.dv.AllowUserToDeleteRows = False
        Me.dv.AllowUserToResizeColumns = False
        Me.dv.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent
        Me.dv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dv.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv.ContextMenuStrip = Me.cmenu
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dv.DefaultCellStyle = DataGridViewCellStyle4
        Me.dv.GridColor = System.Drawing.Color.Black
        Me.dv.Location = New System.Drawing.Point(361, 7)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(33, 35)
        Me.dv.TabIndex = 76
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuadd, Me.cmnuedit, Me.cmenudel, Me.cmenuview, Me.RefreshToolStripMenuItem, Me.cmenusearch, Me.mnuexport})
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
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh."
        '
        'cmenuview
        '
        Me.cmenuview.Name = "cmenuview"
        Me.cmenuview.Size = New System.Drawing.Size(152, 22)
        Me.cmenuview.Text = "View."
        '
        'mnuexport
        '
        Me.mnuexport.Name = "mnuexport"
        Me.mnuexport.Size = New System.Drawing.Size(152, 22)
        Me.mnuexport.Text = "Export."
        '
        'cmenusearch
        '
        Me.cmenusearch.Name = "cmenusearch"
        Me.cmenusearch.Size = New System.Drawing.Size(152, 22)
        Me.cmenusearch.Text = "Search."
        '
        'frmsession
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
        Me.Name = "frmsession"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmsession"
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
    Friend WithEvents txtsession As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtduration As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmblock As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents txtscrl As System.Windows.Forms.TextBox
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents enddt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents startdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dv1 As System.Windows.Forms.DataGridView
    Friend WithEvents aendt As System.Windows.Forms.DateTimePicker
    Friend WithEvents astdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbacyr As System.Windows.Forms.ComboBox
    Friend WithEvents txtsl As System.Windows.Forms.TextBox
    Friend WithEvents btnnext As System.Windows.Forms.Button
    Friend WithEvents txtacdmcd As System.Windows.Forms.TextBox
    Friend WithEvents txtacdur As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnu1del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents cmenuview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuexport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenusearch As System.Windows.Forms.ToolStripMenuItem

End Class
