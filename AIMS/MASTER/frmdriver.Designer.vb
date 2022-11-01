<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmdriver
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
        Me.cmbvehno = New System.Windows.Forms.ComboBox
        Me.txtdrvcd = New System.Windows.Forms.TextBox
        Me.txtage = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.doj = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.dob = New System.Windows.Forms.DateTimePicker
        Me.txtshrtnm = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtmobno = New System.Windows.Forms.TextBox
        Me.txtaddress = New System.Windows.Forms.TextBox
        Me.txtdrvnm = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtvehcd = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnview = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.cmblock = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dv = New System.Windows.Forms.DataGridView
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenuexpert = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.cmbvehno)
        Me.Panel1.Controls.Add(Me.txtdrvcd)
        Me.Panel1.Controls.Add(Me.txtage)
        Me.Panel1.Controls.Add(Me.Label44)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.doj)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.dob)
        Me.Panel1.Controls.Add(Me.txtshrtnm)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtmobno)
        Me.Panel1.Controls.Add(Me.txtaddress)
        Me.Panel1.Controls.Add(Me.txtdrvnm)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtvehcd)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.cmblock)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(554, 406)
        Me.Panel1.TabIndex = 0
        '
        'cmbvehno
        '
        Me.cmbvehno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbvehno.FormattingEnabled = True
        Me.cmbvehno.Location = New System.Drawing.Point(192, 259)
        Me.cmbvehno.Name = "cmbvehno"
        Me.cmbvehno.Size = New System.Drawing.Size(137, 21)
        Me.cmbvehno.TabIndex = 6
        '
        'txtdrvcd
        '
        Me.txtdrvcd.Location = New System.Drawing.Point(52, 307)
        Me.txtdrvcd.Name = "txtdrvcd"
        Me.txtdrvcd.Size = New System.Drawing.Size(36, 21)
        Me.txtdrvcd.TabIndex = 114
        Me.txtdrvcd.Visible = False
        '
        'txtage
        '
        Me.txtage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtage.Location = New System.Drawing.Point(396, 137)
        Me.txtage.Name = "txtage"
        Me.txtage.Size = New System.Drawing.Size(72, 21)
        Me.txtage.TabIndex = 112
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(353, 140)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(40, 13)
        Me.Label44.TabIndex = 113
        Me.Label44.Text = "Age :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(99, 262)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 13)
        Me.Label16.TabIndex = 85
        Me.Label16.Text = "*Vehicle No :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(115, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "Join Date :"
        '
        'doj
        '
        Me.doj.CalendarForeColor = System.Drawing.Color.Black
        Me.doj.CustomFormat = "dd/MM/yyyy"
        Me.doj.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.doj.Location = New System.Drawing.Point(192, 156)
        Me.doj.Name = "doj"
        Me.doj.Size = New System.Drawing.Size(132, 21)
        Me.doj.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(93, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 13)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Date of Birth :"
        '
        'dob
        '
        Me.dob.CalendarForeColor = System.Drawing.Color.Black
        Me.dob.CustomFormat = "dd/MM/yyyy"
        Me.dob.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dob.Location = New System.Drawing.Point(192, 131)
        Me.dob.Name = "dob"
        Me.dob.Size = New System.Drawing.Size(132, 21)
        Me.dob.TabIndex = 2
        '
        'txtshrtnm
        '
        Me.txtshrtnm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtshrtnm.Location = New System.Drawing.Point(192, 108)
        Me.txtshrtnm.Name = "txtshrtnm"
        Me.txtshrtnm.Size = New System.Drawing.Size(132, 21)
        Me.txtshrtnm.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(91, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "*Short Name :"
        '
        'txtmobno
        '
        Me.txtmobno.Location = New System.Drawing.Point(192, 235)
        Me.txtmobno.Name = "txtmobno"
        Me.txtmobno.Size = New System.Drawing.Size(276, 21)
        Me.txtmobno.TabIndex = 5
        '
        'txtaddress
        '
        Me.txtaddress.Location = New System.Drawing.Point(192, 180)
        Me.txtaddress.Multiline = True
        Me.txtaddress.Name = "txtaddress"
        Me.txtaddress.Size = New System.Drawing.Size(276, 53)
        Me.txtaddress.TabIndex = 4
        '
        'txtdrvnm
        '
        Me.txtdrvnm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdrvnm.Location = New System.Drawing.Point(192, 84)
        Me.txtdrvnm.Name = "txtdrvnm"
        Me.txtdrvnm.Size = New System.Drawing.Size(276, 21)
        Me.txtdrvnm.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(120, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "*Mob No :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(122, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Address :"
        '
        'txtvehcd
        '
        Me.txtvehcd.Location = New System.Drawing.Point(10, 307)
        Me.txtvehcd.Name = "txtvehcd"
        Me.txtvehcd.Size = New System.Drawing.Size(36, 21)
        Me.txtvehcd.TabIndex = 18
        Me.txtvehcd.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnview)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(3, 353)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(547, 49)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controls"
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(312, 20)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 5
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'btnview
        '
        Me.btnview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnview.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnview.Location = New System.Drawing.Point(159, 20)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(75, 23)
        Me.btnview.TabIndex = 6
        Me.btnview.Text = "&View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(6, 20)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(75, 23)
        Me.btnexit.TabIndex = 7
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(465, 20)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 4
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'cmblock
        '
        Me.cmblock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmblock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmblock.FormattingEnabled = True
        Me.cmblock.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmblock.Location = New System.Drawing.Point(396, 259)
        Me.cmblock.Name = "cmblock"
        Me.cmblock.Size = New System.Drawing.Size(72, 21)
        Me.cmblock.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(333, 262)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Locked :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(85, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "*Driver Name :"
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
        Me.dv.Location = New System.Drawing.Point(495, 9)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(33, 35)
        Me.dv.TabIndex = 77
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
        Me.cmenuexpert.Text = "Expert."
        '
        'frmdriver
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(557, 409)
        Me.Controls.Add(Me.dv)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmdriver"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmdriver"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmblock As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents txtvehcd As System.Windows.Forms.TextBox
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtdrvnm As System.Windows.Forms.TextBox
    Friend WithEvents txtmobno As System.Windows.Forms.TextBox
    Friend WithEvents txtaddress As System.Windows.Forms.TextBox
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents cmenuexpert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtshrtnm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents doj As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dob As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbvehno As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtdrvcd As System.Windows.Forms.TextBox
    Friend WithEvents txtage As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label

End Class
