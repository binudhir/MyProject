<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpartymanf
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dv = New System.Windows.Forms.DataGridView
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.cmbparty = New System.Windows.Forms.ComboBox
        Me.cmbcompany = New System.Windows.Forms.ComboBox
        Me.txtcompcd = New System.Windows.Forms.TextBox
        Me.txtpartycd = New System.Windows.Forms.TextBox
        Me.btnclear = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtsl = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnview = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnref = New System.Windows.Forms.Button
        Me.txtcomp = New System.Windows.Forms.TextBox
        Me.txtcontperson = New System.Windows.Forms.TextBox
        Me.txttrade = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dv1 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtaddres = New System.Windows.Forms.TextBox
        Me.btnnext = New System.Windows.Forms.Button
        Me.txtbiling = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenu.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.cmbparty)
        Me.Panel1.Controls.Add(Me.cmbcompany)
        Me.Panel1.Controls.Add(Me.txtcompcd)
        Me.Panel1.Controls.Add(Me.txtpartycd)
        Me.Panel1.Controls.Add(Me.btnclear)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtsl)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.txtcomp)
        Me.Panel1.Controls.Add(Me.txtcontperson)
        Me.Panel1.Controls.Add(Me.txttrade)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.dv1)
        Me.Panel1.Controls.Add(Me.txtaddres)
        Me.Panel1.Controls.Add(Me.btnnext)
        Me.Panel1.Controls.Add(Me.txtbiling)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(555, 414)
        Me.Panel1.TabIndex = 0
        '
        'dv
        '
        Me.dv.AllowUserToAddRows = False
        Me.dv.AllowUserToDeleteRows = False
        Me.dv.AllowUserToResizeColumns = False
        Me.dv.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Transparent
        Me.dv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dv.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv.ContextMenuStrip = Me.cmenu
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dv.DefaultCellStyle = DataGridViewCellStyle7
        Me.dv.GridColor = System.Drawing.Color.Black
        Me.dv.Location = New System.Drawing.Point(3, 82)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(47, 26)
        Me.dv.TabIndex = 135
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
        'cmbparty
        '
        Me.cmbparty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbparty.FormattingEnabled = True
        Me.cmbparty.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmbparty.Location = New System.Drawing.Point(179, 8)
        Me.cmbparty.Name = "cmbparty"
        Me.cmbparty.Size = New System.Drawing.Size(290, 21)
        Me.cmbparty.TabIndex = 0
        '
        'cmbcompany
        '
        Me.cmbcompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbcompany.FormattingEnabled = True
        Me.cmbcompany.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmbcompany.Location = New System.Drawing.Point(106, 186)
        Me.cmbcompany.Name = "cmbcompany"
        Me.cmbcompany.Size = New System.Drawing.Size(182, 21)
        Me.cmbcompany.TabIndex = 5
        '
        'txtcompcd
        '
        Me.txtcompcd.Location = New System.Drawing.Point(475, 35)
        Me.txtcompcd.Name = "txtcompcd"
        Me.txtcompcd.Size = New System.Drawing.Size(33, 21)
        Me.txtcompcd.TabIndex = 138
        Me.txtcompcd.Visible = False
        '
        'txtpartycd
        '
        Me.txtpartycd.Location = New System.Drawing.Point(475, 8)
        Me.txtpartycd.Name = "txtpartycd"
        Me.txtpartycd.Size = New System.Drawing.Size(33, 21)
        Me.txtpartycd.TabIndex = 137
        Me.txtpartycd.Visible = False
        '
        'btnclear
        '
        Me.btnclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclear.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnclear.Location = New System.Drawing.Point(409, 337)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(60, 23)
        Me.btnclear.TabIndex = 136
        Me.btnclear.Text = "&CLEAR"
        Me.btnclear.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Red
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(-1, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(555, 2)
        Me.Label10.TabIndex = 130
        Me.Label10.Text = "Address :"
        '
        'txtsl
        '
        Me.txtsl.BackColor = System.Drawing.Color.White
        Me.txtsl.Enabled = False
        Me.txtsl.Location = New System.Drawing.Point(70, 186)
        Me.txtsl.Name = "txtsl"
        Me.txtsl.Size = New System.Drawing.Size(36, 21)
        Me.txtsl.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnview)
        Me.GroupBox3.Controls.Add(Me.btnsave)
        Me.GroupBox3.Controls.Add(Me.btnexit)
        Me.GroupBox3.Controls.Add(Me.btnref)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Red
        Me.GroupBox3.Location = New System.Drawing.Point(3, 363)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(537, 46)
        Me.GroupBox3.TabIndex = 131
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Controls . . ."
        '
        'btnview
        '
        Me.btnview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnview.Location = New System.Drawing.Point(157, 17)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(73, 23)
        Me.btnview.TabIndex = 14
        Me.btnview.Text = "&View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.ForeColor = System.Drawing.Color.Red
        Me.btnsave.Location = New System.Drawing.Point(453, 17)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(73, 23)
        Me.btnsave.TabIndex = 10
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.ForeColor = System.Drawing.Color.Red
        Me.btnexit.Location = New System.Drawing.Point(9, 17)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(73, 23)
        Me.btnexit.TabIndex = 15
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnref
        '
        Me.btnref.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnref.ForeColor = System.Drawing.Color.Red
        Me.btnref.Location = New System.Drawing.Point(305, 17)
        Me.btnref.Name = "btnref"
        Me.btnref.Size = New System.Drawing.Size(73, 23)
        Me.btnref.TabIndex = 12
        Me.btnref.Text = "&Refresh"
        Me.btnref.UseVisualStyleBackColor = True
        '
        'txtcomp
        '
        Me.txtcomp.Location = New System.Drawing.Point(288, 186)
        Me.txtcomp.Name = "txtcomp"
        Me.txtcomp.Size = New System.Drawing.Size(61, 21)
        Me.txtcomp.TabIndex = 6
        '
        'txtcontperson
        '
        Me.txtcontperson.BackColor = System.Drawing.Color.White
        Me.txtcontperson.Enabled = False
        Me.txtcontperson.Location = New System.Drawing.Point(179, 55)
        Me.txtcontperson.Name = "txtcontperson"
        Me.txtcontperson.Size = New System.Drawing.Size(290, 21)
        Me.txtcontperson.TabIndex = 2
        '
        'txttrade
        '
        Me.txttrade.Location = New System.Drawing.Point(349, 186)
        Me.txttrade.Name = "txttrade"
        Me.txttrade.Size = New System.Drawing.Size(61, 21)
        Me.txttrade.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(86, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Party Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(81, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Billing Name :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(64, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Contact Person :"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(70, 140)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(399, 45)
        Me.Panel2.TabIndex = 45
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(284, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Trade."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(222, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Comp."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(63, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(135, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Manufacturer Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(6, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Sl."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(235, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Discount(%)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(109, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Address :"
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
        Me.dv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Column8, Me.Column9, Me.Column11, Me.Column6})
        Me.dv1.GridColor = System.Drawing.Color.Black
        Me.dv1.Location = New System.Drawing.Point(70, 208)
        Me.dv1.Name = "dv1"
        Me.dv1.ReadOnly = True
        Me.dv1.RowHeadersVisible = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan
        Me.dv1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dv1.RowTemplate.Height = 20
        Me.dv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv1.Size = New System.Drawing.Size(399, 129)
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
        Me.Column8.HeaderText = "Manufacturer"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 182
        '
        'Column9
        '
        Me.Column9.HeaderText = "comp"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 61
        '
        'Column11
        '
        Me.Column11.HeaderText = "trade"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 61
        '
        'Column6
        '
        Me.Column6.HeaderText = "manfcd"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'txtaddres
        '
        Me.txtaddres.BackColor = System.Drawing.Color.White
        Me.txtaddres.Enabled = False
        Me.txtaddres.Location = New System.Drawing.Point(179, 79)
        Me.txtaddres.Multiline = True
        Me.txtaddres.Name = "txtaddres"
        Me.txtaddres.Size = New System.Drawing.Size(290, 52)
        Me.txtaddres.TabIndex = 3
        '
        'btnnext
        '
        Me.btnnext.ForeColor = System.Drawing.Color.Red
        Me.btnnext.Location = New System.Drawing.Point(409, 185)
        Me.btnnext.Name = "btnnext"
        Me.btnnext.Size = New System.Drawing.Size(60, 23)
        Me.btnnext.TabIndex = 8
        Me.btnnext.Text = "&Next"
        Me.btnnext.UseVisualStyleBackColor = True
        '
        'txtbiling
        '
        Me.txtbiling.BackColor = System.Drawing.Color.White
        Me.txtbiling.Enabled = False
        Me.txtbiling.Location = New System.Drawing.Point(179, 31)
        Me.txtbiling.Name = "txtbiling"
        Me.txtbiling.Size = New System.Drawing.Size(290, 21)
        Me.txtbiling.TabIndex = 1
        '
        'frmpartymanf
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(557, 416)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmpartymanf"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Company Wise Discount Master. . . . (E N T R Y  M O D E)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnref As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtcomp As System.Windows.Forms.TextBox
    Friend WithEvents txttrade As System.Windows.Forms.TextBox
    Friend WithEvents cmbcompany As System.Windows.Forms.ComboBox
    Friend WithEvents txtsl As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dv1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnnext As System.Windows.Forms.Button
    Friend WithEvents txtcontperson As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtaddres As System.Windows.Forms.TextBox
    Friend WithEvents txtbiling As System.Windows.Forms.TextBox
    Friend WithEvents cmbparty As System.Windows.Forms.ComboBox
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents btnclear As System.Windows.Forms.Button
    Friend WithEvents txtcompcd As System.Windows.Forms.TextBox
    Friend WithEvents txtpartycd As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
