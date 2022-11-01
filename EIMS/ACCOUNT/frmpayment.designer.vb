<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpayment
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
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.btnconti = New System.Windows.Forms.Button
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtgrand = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtnb = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtgrace = New System.Windows.Forms.TextBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.txtdue = New System.Windows.Forms.TextBox
        Me.cmbcoll = New System.Windows.Forms.ComboBox
        Me.cmbsemi = New System.Windows.Forms.ComboBox
        Me.txtsl = New System.Windows.Forms.TextBox
        Me.btnnext = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtending = New System.Windows.Forms.DateTimePicker
        Me.txtfinal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtstart = New System.Windows.Forms.DateTimePicker
        Me.cmbsession = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuexpert = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Location = New System.Drawing.Point(4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1006, 469)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel5.Controls.Add(Me.btnconti)
        Me.Panel5.Controls.Add(Me.btnrefresh)
        Me.Panel5.Controls.Add(Me.btnexit)
        Me.Panel5.Location = New System.Drawing.Point(366, 423)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(631, 39)
        Me.Panel5.TabIndex = 22
        '
        'btnconti
        '
        Me.btnconti.Location = New System.Drawing.Point(532, 7)
        Me.btnconti.Name = "btnconti"
        Me.btnconti.Size = New System.Drawing.Size(75, 23)
        Me.btnconti.TabIndex = 2
        Me.btnconti.Text = "Continue"
        Me.btnconti.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Location = New System.Drawing.Point(286, 7)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 1
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Location = New System.Drawing.Point(25, 7)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(75, 23)
        Me.btnexit.TabIndex = 0
        Me.btnexit.Text = "Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel4.Controls.Add(Me.RadioButton2)
        Me.Panel4.Controls.Add(Me.RadioButton1)
        Me.Panel4.Location = New System.Drawing.Point(3, 423)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(356, 39)
        Me.Panel4.TabIndex = 21
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(261, 10)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(80, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "SelrctAll"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(15, 10)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(99, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "DeSelectAll"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtgrand)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txtnb)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtgrace)
        Me.Panel2.Controls.Add(Me.DateTimePicker1)
        Me.Panel2.Controls.Add(Me.txtdue)
        Me.Panel2.Controls.Add(Me.cmbcoll)
        Me.Panel2.Controls.Add(Me.cmbsemi)
        Me.Panel2.Controls.Add(Me.txtsl)
        Me.Panel2.Controls.Add(Me.btnnext)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.dtending)
        Me.Panel2.Controls.Add(Me.txtfinal)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.dtstart)
        Me.Panel2.Controls.Add(Me.cmbsession)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(362, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(634, 414)
        Me.Panel2.TabIndex = 20
        '
        'txtgrand
        '
        Me.txtgrand.Location = New System.Drawing.Point(427, 391)
        Me.txtgrand.Name = "txtgrand"
        Me.txtgrand.Size = New System.Drawing.Size(184, 21)
        Me.txtgrand.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Fuchsia
        Me.Label12.Location = New System.Drawing.Point(330, 394)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Grand Total :"
        '
        'txtnb
        '
        Me.txtnb.Location = New System.Drawing.Point(42, 391)
        Me.txtnb.Name = "txtnb"
        Me.txtnb.Size = New System.Drawing.Size(259, 21)
        Me.txtnb.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Fuchsia
        Me.Label9.Location = New System.Drawing.Point(3, 394)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "N.B :"
        '
        'txtgrace
        '
        Me.txtgrace.Location = New System.Drawing.Point(507, 105)
        Me.txtgrace.Name = "txtgrace"
        Me.txtgrace.Size = New System.Drawing.Size(73, 21)
        Me.txtgrace.TabIndex = 9
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/mm/yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(415, 106)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(98, 21)
        Me.DateTimePicker1.TabIndex = 8
        '
        'txtdue
        '
        Me.txtdue.Location = New System.Drawing.Point(347, 106)
        Me.txtdue.Name = "txtdue"
        Me.txtdue.Size = New System.Drawing.Size(72, 21)
        Me.txtdue.TabIndex = 7
        '
        'cmbcoll
        '
        Me.cmbcoll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbcoll.FormattingEnabled = True
        Me.cmbcoll.Items.AddRange(New Object() {"ADMISSION FEE", "LODGING FEE", "TUTION FEE"})
        Me.cmbcoll.Location = New System.Drawing.Point(158, 106)
        Me.cmbcoll.Name = "cmbcoll"
        Me.cmbcoll.Size = New System.Drawing.Size(192, 20)
        Me.cmbcoll.TabIndex = 6
        '
        'cmbsemi
        '
        Me.cmbsemi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbsemi.FormattingEnabled = True
        Me.cmbsemi.Location = New System.Drawing.Point(42, 106)
        Me.cmbsemi.Name = "cmbsemi"
        Me.cmbsemi.Size = New System.Drawing.Size(121, 20)
        Me.cmbsemi.TabIndex = 5
        '
        'txtsl
        '
        Me.txtsl.Location = New System.Drawing.Point(1, 106)
        Me.txtsl.Name = "txtsl"
        Me.txtsl.Size = New System.Drawing.Size(44, 21)
        Me.txtsl.TabIndex = 4
        '
        'btnnext
        '
        Me.btnnext.Location = New System.Drawing.Point(580, 105)
        Me.btnnext.Name = "btnnext"
        Me.btnnext.Size = New System.Drawing.Size(54, 23)
        Me.btnnext.TabIndex = 10
        Me.btnnext.Text = "Next"
        Me.btnnext.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(0, 71)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(634, 32)
        Me.Panel3.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(489, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Grace Period"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(432, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Due Dt"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(361, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Due Amt"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(160, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(194, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Collection Head of A/c Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(45, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Semister Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Sl."
        '
        'dtending
        '
        Me.dtending.CustomFormat = "dd/mm/yyyy"
        Me.dtending.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtending.Location = New System.Drawing.Point(403, 37)
        Me.dtending.Name = "dtending"
        Me.dtending.Size = New System.Drawing.Size(125, 21)
        Me.dtending.TabIndex = 3
        '
        'txtfinal
        '
        Me.txtfinal.Location = New System.Drawing.Point(403, 11)
        Me.txtfinal.Name = "txtfinal"
        Me.txtfinal.Size = New System.Drawing.Size(125, 21)
        Me.txtfinal.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.ForeColor = System.Drawing.Color.Fuchsia
        Me.Label4.Location = New System.Drawing.Point(304, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Ending Date :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.ForeColor = System.Drawing.Color.Fuchsia
        Me.Label3.Location = New System.Drawing.Point(296, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Final Amount :"
        '
        'dtstart
        '
        Me.dtstart.CustomFormat = "dd/mm/yyyy"
        Me.dtstart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtstart.Location = New System.Drawing.Point(110, 37)
        Me.dtstart.Name = "dtstart"
        Me.dtstart.Size = New System.Drawing.Size(121, 21)
        Me.dtstart.TabIndex = 1
        '
        'cmbsession
        '
        Me.cmbsession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbsession.FormattingEnabled = True
        Me.cmbsession.Items.AddRange(New Object() {"2014-15", "2013-15"})
        Me.cmbsession.Location = New System.Drawing.Point(110, 11)
        Me.cmbsession.Name = "cmbsession"
        Me.cmbsession.Size = New System.Drawing.Size(121, 20)
        Me.cmbsession.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Fuchsia
        Me.Label2.Location = New System.Drawing.Point(3, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Starting Date :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Fuchsia
        Me.Label1.Location = New System.Drawing.Point(39, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Session :"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.LightCyan
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4, Me.Column6})
        Me.DataGridView1.ContextMenuStrip = Me.cmenu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.GridColor = System.Drawing.Color.Black
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.DataGridView1.RowTemplate.Height = 20
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(356, 414)
        Me.DataGridView1.TabIndex = 20
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column3.HeaderText = "Regd No."
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column4.HeaderText = "Student Name"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 260
        '
        'Column6
        '
        Me.Column6.HeaderText = "Column6"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        Me.Column6.Width = 88
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
        'mnuexpert
        '
        Me.mnuexpert.Name = "mnuexpert"
        Me.mnuexpert.Size = New System.Drawing.Size(152, 22)
        Me.mnuexpert.Text = "Expert"
        '
        'frmpayment
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1005, 479)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmpayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmpayment"
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dtstart As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbsession As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtending As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtfinal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnnext As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtsl As System.Windows.Forms.TextBox
    Friend WithEvents txtdue As System.Windows.Forms.TextBox
    Friend WithEvents cmbcoll As System.Windows.Forms.ComboBox
    Friend WithEvents cmbsemi As System.Windows.Forms.ComboBox
    Friend WithEvents txtgrace As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtgrand As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtnb As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnconti As System.Windows.Forms.Button
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuexpert As System.Windows.Forms.ToolStripMenuItem

End Class
