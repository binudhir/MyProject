<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrefund
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmbname = New System.Windows.Forms.ComboBox
        Me.lblname = New System.Windows.Forms.Label
        Me.txtrefsl = New System.Windows.Forms.TextBox
        Me.rdbdis = New System.Windows.Forms.RadioButton
        Me.rdbsel = New System.Windows.Forms.RadioButton
        Me.dv1 = New System.Windows.Forms.DataGridView
        Me.dtissue = New System.Windows.Forms.DateTimePicker
        Me.cmbissue = New System.Windows.Forms.ComboBox
        Me.txtcd = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnrefund = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnref = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.cmbname)
        Me.Panel1.Controls.Add(Me.lblname)
        Me.Panel1.Controls.Add(Me.txtrefsl)
        Me.Panel1.Controls.Add(Me.rdbdis)
        Me.Panel1.Controls.Add(Me.rdbsel)
        Me.Panel1.Controls.Add(Me.dv1)
        Me.Panel1.Controls.Add(Me.dtissue)
        Me.Panel1.Controls.Add(Me.cmbissue)
        Me.Panel1.Controls.Add(Me.txtcd)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 368)
        Me.Panel1.TabIndex = 0
        '
        'cmbname
        '
        Me.cmbname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Items.AddRange(New Object() {"Ball", "Bat", "Plastic chair", "Glass"})
        Me.cmbname.Location = New System.Drawing.Point(85, 33)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(275, 20)
        Me.cmbname.TabIndex = 860
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblname.Location = New System.Drawing.Point(30, 36)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(52, 13)
        Me.lblname.TabIndex = 861
        Me.lblname.Text = "Name :"
        '
        'txtrefsl
        '
        Me.txtrefsl.Location = New System.Drawing.Point(337, 3)
        Me.txtrefsl.Name = "txtrefsl"
        Me.txtrefsl.Size = New System.Drawing.Size(19, 21)
        Me.txtrefsl.TabIndex = 859
        Me.txtrefsl.Visible = False
        '
        'rdbdis
        '
        Me.rdbdis.AutoSize = True
        Me.rdbdis.Location = New System.Drawing.Point(599, 296)
        Me.rdbdis.Name = "rdbdis"
        Me.rdbdis.Size = New System.Drawing.Size(156, 17)
        Me.rdbdis.TabIndex = 858
        Me.rdbdis.TabStop = True
        Me.rdbdis.Text = "Deselect All Product"
        Me.rdbdis.UseVisualStyleBackColor = True
        '
        'rdbsel
        '
        Me.rdbsel.AutoSize = True
        Me.rdbsel.Location = New System.Drawing.Point(20, 295)
        Me.rdbsel.Name = "rdbsel"
        Me.rdbsel.Size = New System.Drawing.Size(140, 17)
        Me.rdbsel.TabIndex = 857
        Me.rdbsel.TabStop = True
        Me.rdbsel.Text = "Select All Product"
        Me.rdbsel.UseVisualStyleBackColor = True
        '
        'dv1
        '
        Me.dv1.AllowUserToAddRows = False
        Me.dv1.AllowUserToDeleteRows = False
        Me.dv1.AllowUserToResizeColumns = False
        Me.dv1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dv1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dv1.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column10, Me.Column5, Me.Column4, Me.Column3, Me.Column6, Me.Column7, Me.Column9, Me.Column8, Me.Column11})
        Me.dv1.GridColor = System.Drawing.Color.Black
        Me.dv1.Location = New System.Drawing.Point(1, 68)
        Me.dv1.Name = "dv1"
        Me.dv1.RowHeadersVisible = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Azure
        Me.dv1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv1.Size = New System.Drawing.Size(771, 221)
        Me.dv1.TabIndex = 856
        '
        'dtissue
        '
        Me.dtissue.CalendarForeColor = System.Drawing.Color.Black
        Me.dtissue.CustomFormat = "dd/MM/yyyy"
        Me.dtissue.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtissue.Location = New System.Drawing.Point(645, 6)
        Me.dtissue.Name = "dtissue"
        Me.dtissue.Size = New System.Drawing.Size(121, 21)
        Me.dtissue.TabIndex = 3
        '
        'cmbissue
        '
        Me.cmbissue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbissue.FormattingEnabled = True
        Me.cmbissue.Items.AddRange(New Object() {"1.Staff", "2.Vehicle"})
        Me.cmbissue.Location = New System.Drawing.Point(85, 6)
        Me.cmbissue.Name = "cmbissue"
        Me.cmbissue.Size = New System.Drawing.Size(154, 21)
        Me.cmbissue.TabIndex = 1
        '
        'txtcd
        '
        Me.txtcd.Location = New System.Drawing.Point(308, 3)
        Me.txtcd.Name = "txtcd"
        Me.txtcd.Size = New System.Drawing.Size(19, 21)
        Me.txtcd.TabIndex = 855
        Me.txtcd.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnrefund)
        Me.GroupBox3.Controls.Add(Me.btnexit)
        Me.GroupBox3.Controls.Add(Me.btnref)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Red
        Me.GroupBox3.Location = New System.Drawing.Point(2, 316)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(769, 46)
        Me.GroupBox3.TabIndex = 130
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Controls . . ."
        '
        'btnrefund
        '
        Me.btnrefund.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefund.ForeColor = System.Drawing.Color.Red
        Me.btnrefund.Location = New System.Drawing.Point(679, 16)
        Me.btnrefund.Name = "btnrefund"
        Me.btnrefund.Size = New System.Drawing.Size(73, 23)
        Me.btnrefund.TabIndex = 17
        Me.btnrefund.Text = "Re&fund"
        Me.btnrefund.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.ForeColor = System.Drawing.Color.Red
        Me.btnexit.Location = New System.Drawing.Point(13, 16)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(73, 23)
        Me.btnexit.TabIndex = 16
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnref
        '
        Me.btnref.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnref.ForeColor = System.Drawing.Color.Red
        Me.btnref.Location = New System.Drawing.Point(346, 16)
        Me.btnref.Name = "btnref"
        Me.btnref.Size = New System.Drawing.Size(73, 23)
        Me.btnref.TabIndex = 13
        Me.btnref.Text = "&Refresh"
        Me.btnref.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Red
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(-1, 60)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(775, 2)
        Me.Label26.TabIndex = 128
        Me.Label26.Text = "Address :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(549, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Refund Date :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Ref.From :"
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
        'Column1
        '
        Me.Column1.FalseValue = "0"
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column1.TrueValue = "1"
        Me.Column1.Width = 45
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column2.HeaderText = "Sl."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 45
        '
        'Column10
        '
        Me.Column10.HeaderText = "Manf Name"
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 150
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.HeaderText = "Product Name"
        Me.Column5.Name = "Column5"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Unit"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 50
        '
        'Column3
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column3.HeaderText = "Quantity"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 70
        '
        'Column6
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column6.HeaderText = "M.R.P"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 70
        '
        'Column7
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column7.HeaderText = "Amount"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 90
        '
        'Column9
        '
        Me.Column9.HeaderText = "isssl"
        Me.Column9.Name = "Column9"
        Me.Column9.Visible = False
        '
        'Column8
        '
        Me.Column8.HeaderText = "itcd"
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        '
        'Column11
        '
        Me.Column11.HeaderText = "mulrt"
        Me.Column11.Name = "Column11"
        Me.Column11.Visible = False
        '
        'frmrefund
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(781, 374)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmrefund"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Return of Product Entry Screen...."
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.cmenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbissue As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtissue As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents txtcd As System.Windows.Forms.TextBox
    Friend WithEvents btnref As System.Windows.Forms.Button
    Friend WithEvents btnrefund As System.Windows.Forms.Button
    Friend WithEvents dv1 As System.Windows.Forms.DataGridView
    Friend WithEvents rdbdis As System.Windows.Forms.RadioButton
    Friend WithEvents rdbsel As System.Windows.Forms.RadioButton
    Friend WithEvents txtrefsl As System.Windows.Forms.TextBox
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
