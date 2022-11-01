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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtrefsl = New System.Windows.Forms.TextBox
        Me.rdbdis = New System.Windows.Forms.RadioButton
        Me.rdbsel = New System.Windows.Forms.RadioButton
        Me.dv1 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtissue = New System.Windows.Forms.DateTimePicker
        Me.cmbissue = New System.Windows.Forms.ComboBox
        Me.txtcd = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnrefund = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnref = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.txttrade = New System.Windows.Forms.TextBox
        Me.lbltrade = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtname = New System.Windows.Forms.TextBox
        Me.txtregd = New System.Windows.Forms.TextBox
        Me.lblname = New System.Windows.Forms.Label
        Me.lblreg = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
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
        Me.Panel1.Controls.Add(Me.txtrefsl)
        Me.Panel1.Controls.Add(Me.rdbdis)
        Me.Panel1.Controls.Add(Me.rdbsel)
        Me.Panel1.Controls.Add(Me.dv1)
        Me.Panel1.Controls.Add(Me.dtissue)
        Me.Panel1.Controls.Add(Me.cmbissue)
        Me.Panel1.Controls.Add(Me.txtcd)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.txttrade)
        Me.Panel1.Controls.Add(Me.lbltrade)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtname)
        Me.Panel1.Controls.Add(Me.txtregd)
        Me.Panel1.Controls.Add(Me.lblname)
        Me.Panel1.Controls.Add(Me.lblreg)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(680, 368)
        Me.Panel1.TabIndex = 0
        '
        'txtrefsl
        '
        Me.txtrefsl.Location = New System.Drawing.Point(256, 6)
        Me.txtrefsl.Name = "txtrefsl"
        Me.txtrefsl.Size = New System.Drawing.Size(19, 21)
        Me.txtrefsl.TabIndex = 859
        Me.txtrefsl.Visible = False
        '
        'rdbdis
        '
        Me.rdbdis.AutoSize = True
        Me.rdbdis.Location = New System.Drawing.Point(502, 296)
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
        Me.dv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column5, Me.Column3, Me.Column4, Me.Column6, Me.Column7, Me.Column9, Me.Column8})
        Me.dv1.GridColor = System.Drawing.Color.Black
        Me.dv1.Location = New System.Drawing.Point(2, 64)
        Me.dv1.Name = "dv1"
        Me.dv1.RowHeadersVisible = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Azure
        Me.dv1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv1.Size = New System.Drawing.Size(674, 221)
        Me.dv1.TabIndex = 856
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
        'Column5
        '
        Me.Column5.HeaderText = "Product Name"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 320
        '
        'Column3
        '
        Me.Column3.HeaderText = "Quantity"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 70
        '
        'Column4
        '
        Me.Column4.HeaderText = "Unit"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 50
        '
        'Column6
        '
        Me.Column6.HeaderText = "M.R.P"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 70
        '
        'Column7
        '
        Me.Column7.HeaderText = "Amount"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 70
        '
        'Column9
        '
        Me.Column9.HeaderText = "isssl"
        Me.Column9.Name = "Column9"
        Me.Column9.Visible = False
        '
        'Column8
        '
        Me.Column8.HeaderText = "issno"
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        '
        'dtissue
        '
        Me.dtissue.CalendarForeColor = System.Drawing.Color.Black
        Me.dtissue.CustomFormat = "dd/MM/yyyy"
        Me.dtissue.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtissue.Location = New System.Drawing.Point(555, 6)
        Me.dtissue.Name = "dtissue"
        Me.dtissue.Size = New System.Drawing.Size(121, 21)
        Me.dtissue.TabIndex = 3
        '
        'cmbissue
        '
        Me.cmbissue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbissue.FormattingEnabled = True
        Me.cmbissue.Items.AddRange(New Object() {"1.Student", "2.Staff"})
        Me.cmbissue.Location = New System.Drawing.Point(75, 6)
        Me.cmbissue.Name = "cmbissue"
        Me.cmbissue.Size = New System.Drawing.Size(105, 21)
        Me.cmbissue.TabIndex = 1
        '
        'txtcd
        '
        Me.txtcd.Location = New System.Drawing.Point(188, 7)
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
        Me.GroupBox3.Location = New System.Drawing.Point(2, 319)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(674, 46)
        Me.GroupBox3.TabIndex = 130
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Controls . . ."
        '
        'btnrefund
        '
        Me.btnrefund.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefund.ForeColor = System.Drawing.Color.Red
        Me.btnrefund.Location = New System.Drawing.Point(589, 16)
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
        Me.btnref.Location = New System.Drawing.Point(301, 16)
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
        Me.Label26.Size = New System.Drawing.Size(681, 2)
        Me.Label26.TabIndex = 128
        Me.Label26.Text = "Address :"
        '
        'txttrade
        '
        Me.txttrade.BackColor = System.Drawing.Color.White
        Me.txttrade.Enabled = False
        Me.txttrade.Location = New System.Drawing.Point(555, 34)
        Me.txttrade.Name = "txttrade"
        Me.txttrade.Size = New System.Drawing.Size(121, 21)
        Me.txttrade.TabIndex = 234
        '
        'lbltrade
        '
        Me.lbltrade.AutoSize = True
        Me.lbltrade.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbltrade.Location = New System.Drawing.Point(500, 37)
        Me.lbltrade.Name = "lbltrade"
        Me.lbltrade.Size = New System.Drawing.Size(53, 13)
        Me.lbltrade.TabIndex = 31
        Me.lbltrade.Text = "Trade :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(459, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Refund Date :"
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.Color.White
        Me.txtname.Enabled = False
        Me.txtname.Location = New System.Drawing.Point(241, 34)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(252, 21)
        Me.txtname.TabIndex = 321
        '
        'txtregd
        '
        Me.txtregd.Location = New System.Drawing.Point(75, 34)
        Me.txtregd.Name = "txtregd"
        Me.txtregd.Size = New System.Drawing.Size(105, 21)
        Me.txtregd.TabIndex = 2
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblname.Location = New System.Drawing.Point(185, 37)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(52, 13)
        Me.lblname.TabIndex = 23
        Me.lblname.Text = "Name :"
        '
        'lblreg
        '
        Me.lblreg.AutoSize = True
        Me.lblreg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblreg.Location = New System.Drawing.Point(2, 37)
        Me.lblreg.Name = "lblreg"
        Me.lblreg.Size = New System.Drawing.Size(72, 13)
        Me.lblreg.TabIndex = 22
        Me.lblreg.Text = "Regd No. :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Tr. With :"
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
        'frmrefund
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(685, 374)
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
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents lblreg As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbissue As System.Windows.Forms.ComboBox
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents txtregd As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbltrade As System.Windows.Forms.Label
    Friend WithEvents dtissue As System.Windows.Forms.DateTimePicker
    Friend WithEvents txttrade As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents txtcd As System.Windows.Forms.TextBox
    Friend WithEvents btnref As System.Windows.Forms.Button
    Friend WithEvents btnrefund As System.Windows.Forms.Button
    Friend WithEvents dv1 As System.Windows.Forms.DataGridView
    Friend WithEvents rdbdis As System.Windows.Forms.RadioButton
    Friend WithEvents rdbsel As System.Windows.Forms.RadioButton
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtrefsl As System.Windows.Forms.TextBox

End Class
