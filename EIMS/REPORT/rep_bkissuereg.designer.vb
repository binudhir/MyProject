<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rep_bkissuereg
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblmsg = New System.Windows.Forms.Label
        Me.dv = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btncalc = New System.Windows.Forms.Button
        Me.btnexport = New System.Windows.Forms.Button
        Me.btnrfresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnview = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbiss = New System.Windows.Forms.ComboBox
        Me.cmbstud = New System.Windows.Forms.ComboBox
        Me.cmbbook = New System.Windows.Forms.ComboBox
        Me.cmborder = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkbook = New System.Windows.Forms.CheckBox
        Me.chkstud = New System.Windows.Forms.CheckBox
        Me.chkabstract = New System.Windows.Forms.CheckBox
        Me.chkdetail = New System.Windows.Forms.CheckBox
        Me.fromdt = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.todt = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtbkcd = New System.Windows.Forms.TextBox
        Me.txtstudcd = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblstud = New System.Windows.Forms.Label
        Me.cmbref = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightCyan
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1033, 513)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblmsg)
        Me.GroupBox3.Controls.Add(Me.dv)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Red
        Me.GroupBox3.Location = New System.Drawing.Point(260, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(758, 505)
        Me.GroupBox3.TabIndex = 54
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Book Purchase Register. . . . ."
        '
        'lblmsg
        '
        Me.lblmsg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblmsg.AutoSize = True
        Me.lblmsg.Font = New System.Drawing.Font("Modern No. 20", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmsg.ForeColor = System.Drawing.Color.Red
        Me.lblmsg.Location = New System.Drawing.Point(275, 221)
        Me.lblmsg.Name = "lblmsg"
        Me.lblmsg.Size = New System.Drawing.Size(236, 24)
        Me.lblmsg.TabIndex = 20
        Me.lblmsg.Text = "Sorry No Data To View."
        Me.lblmsg.Visible = False
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dv.GridColor = System.Drawing.Color.Black
        Me.dv.Location = New System.Drawing.Point(3, 17)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(752, 485)
        Me.dv.TabIndex = 19
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btncalc)
        Me.GroupBox2.Controls.Add(Me.btnexport)
        Me.GroupBox2.Controls.Add(Me.btnrfresh)
        Me.GroupBox2.Controls.Add(Me.btnexit)
        Me.GroupBox2.Controls.Add(Me.btnview)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Red
        Me.GroupBox2.Location = New System.Drawing.Point(7, 342)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(250, 167)
        Me.GroupBox2.TabIndex = 53
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Controlls . . ."
        '
        'btncalc
        '
        Me.btncalc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncalc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncalc.Location = New System.Drawing.Point(81, 106)
        Me.btncalc.Name = "btncalc"
        Me.btncalc.Size = New System.Drawing.Size(85, 23)
        Me.btncalc.TabIndex = 12
        Me.btncalc.Text = "&Calculator"
        Me.btncalc.UseVisualStyleBackColor = True
        '
        'btnexport
        '
        Me.btnexport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexport.Location = New System.Drawing.Point(81, 49)
        Me.btnexport.Name = "btnexport"
        Me.btnexport.Size = New System.Drawing.Size(85, 23)
        Me.btnexport.TabIndex = 10
        Me.btnexport.Text = "&Export"
        Me.btnexport.UseVisualStyleBackColor = True
        '
        'btnrfresh
        '
        Me.btnrfresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrfresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrfresh.Location = New System.Drawing.Point(81, 77)
        Me.btnrfresh.Name = "btnrfresh"
        Me.btnrfresh.Size = New System.Drawing.Size(85, 23)
        Me.btnrfresh.TabIndex = 11
        Me.btnrfresh.Text = "&Refresh"
        Me.btnrfresh.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(81, 134)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(85, 23)
        Me.btnexit.TabIndex = 13
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnview
        '
        Me.btnview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnview.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnview.Location = New System.Drawing.Point(81, 20)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(85, 23)
        Me.btnview.TabIndex = 9
        Me.btnview.Text = "&View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbref)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbiss)
        Me.GroupBox1.Controls.Add(Me.cmbstud)
        Me.GroupBox1.Controls.Add(Me.cmbbook)
        Me.GroupBox1.Controls.Add(Me.cmborder)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.chkbook)
        Me.GroupBox1.Controls.Add(Me.chkstud)
        Me.GroupBox1.Controls.Add(Me.chkabstract)
        Me.GroupBox1.Controls.Add(Me.chkdetail)
        Me.GroupBox1.Controls.Add(Me.fromdt)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.todt)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtbkcd)
        Me.GroupBox1.Controls.Add(Me.txtstudcd)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblstud)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 333)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filters . . ."
        '
        'cmbiss
        '
        Me.cmbiss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbiss.FormattingEnabled = True
        Me.cmbiss.Items.AddRange(New Object() {"1.Student", "2.Staff"})
        Me.cmbiss.Location = New System.Drawing.Point(7, 128)
        Me.cmbiss.Name = "cmbiss"
        Me.cmbiss.Size = New System.Drawing.Size(150, 21)
        Me.cmbiss.TabIndex = 2
        '
        'cmbstud
        '
        Me.cmbstud.BackColor = System.Drawing.Color.White
        Me.cmbstud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbstud.FormattingEnabled = True
        Me.cmbstud.Location = New System.Drawing.Point(6, 176)
        Me.cmbstud.Name = "cmbstud"
        Me.cmbstud.Size = New System.Drawing.Size(195, 21)
        Me.cmbstud.TabIndex = 3
        '
        'cmbbook
        '
        Me.cmbbook.BackColor = System.Drawing.Color.White
        Me.cmbbook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbbook.FormattingEnabled = True
        Me.cmbbook.Location = New System.Drawing.Point(6, 220)
        Me.cmbbook.Name = "cmbbook"
        Me.cmbbook.Size = New System.Drawing.Size(195, 21)
        Me.cmbbook.TabIndex = 5
        '
        'cmborder
        '
        Me.cmborder.FormattingEnabled = True
        Me.cmborder.Items.AddRange(New Object() {"1.Date wise", "2.Book Wise"})
        Me.cmborder.Location = New System.Drawing.Point(7, 267)
        Me.cmborder.Name = "cmborder"
        Me.cmborder.Size = New System.Drawing.Size(150, 21)
        Me.cmborder.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 251)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Order By :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(12, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Issue To :"
        '
        'chkbook
        '
        Me.chkbook.AutoSize = True
        Me.chkbook.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkbook.ForeColor = System.Drawing.Color.Blue
        Me.chkbook.Location = New System.Drawing.Point(203, 222)
        Me.chkbook.Name = "chkbook"
        Me.chkbook.Size = New System.Drawing.Size(43, 17)
        Me.chkbook.TabIndex = 6
        Me.chkbook.Text = "All"
        Me.chkbook.UseVisualStyleBackColor = True
        '
        'chkstud
        '
        Me.chkstud.AutoSize = True
        Me.chkstud.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkstud.ForeColor = System.Drawing.Color.Blue
        Me.chkstud.Location = New System.Drawing.Point(203, 178)
        Me.chkstud.Name = "chkstud"
        Me.chkstud.Size = New System.Drawing.Size(43, 17)
        Me.chkstud.TabIndex = 4
        Me.chkstud.Text = "All"
        Me.chkstud.UseVisualStyleBackColor = True
        '
        'chkabstract
        '
        Me.chkabstract.AutoSize = True
        Me.chkabstract.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkabstract.Location = New System.Drawing.Point(107, 306)
        Me.chkabstract.Name = "chkabstract"
        Me.chkabstract.Size = New System.Drawing.Size(92, 17)
        Me.chkabstract.TabIndex = 8
        Me.chkabstract.Text = "ABSTRACT"
        Me.chkabstract.UseVisualStyleBackColor = True
        '
        'chkdetail
        '
        Me.chkdetail.AutoSize = True
        Me.chkdetail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkdetail.Location = New System.Drawing.Point(7, 306)
        Me.chkdetail.Name = "chkdetail"
        Me.chkdetail.Size = New System.Drawing.Size(73, 17)
        Me.chkdetail.TabIndex = 7
        Me.chkdetail.Text = "DETAIL"
        Me.chkdetail.UseVisualStyleBackColor = True
        '
        'fromdt
        '
        Me.fromdt.CalendarForeColor = System.Drawing.Color.Black
        Me.fromdt.CustomFormat = "dd/MM/yyyy"
        Me.fromdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fromdt.Location = New System.Drawing.Point(6, 33)
        Me.fromdt.Name = "fromdt"
        Me.fromdt.Size = New System.Drawing.Size(151, 21)
        Me.fromdt.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(12, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "To Date :"
        '
        'todt
        '
        Me.todt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.todt.CalendarForeColor = System.Drawing.Color.Black
        Me.todt.CustomFormat = "dd/MM/yyyy"
        Me.todt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.todt.Location = New System.Drawing.Point(6, 73)
        Me.todt.Name = "todt"
        Me.todt.Size = New System.Drawing.Size(151, 21)
        Me.todt.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "From Date :"
        '
        'txtbkcd
        '
        Me.txtbkcd.Location = New System.Drawing.Point(191, 17)
        Me.txtbkcd.Name = "txtbkcd"
        Me.txtbkcd.Size = New System.Drawing.Size(25, 21)
        Me.txtbkcd.TabIndex = 20
        Me.txtbkcd.Visible = False
        '
        'txtstudcd
        '
        Me.txtstudcd.Location = New System.Drawing.Point(191, 39)
        Me.txtstudcd.Name = "txtstudcd"
        Me.txtstudcd.Size = New System.Drawing.Size(25, 21)
        Me.txtstudcd.TabIndex = 19
        Me.txtstudcd.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Book Name :"
        '
        'lblstud
        '
        Me.lblstud.AutoSize = True
        Me.lblstud.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblstud.Location = New System.Drawing.Point(12, 156)
        Me.lblstud.Name = "lblstud"
        Me.lblstud.Size = New System.Drawing.Size(106, 13)
        Me.lblstud.TabIndex = 4
        Me.lblstud.Text = "Student Name :"
        '
        'cmbref
        '
        Me.cmbref.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbref.FormattingEnabled = True
        Me.cmbref.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmbref.Location = New System.Drawing.Point(160, 111)
        Me.cmbref.Name = "cmbref"
        Me.cmbref.Size = New System.Drawing.Size(75, 21)
        Me.cmbref.TabIndex = 34
        Me.cmbref.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(165, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Refund :"
        Me.Label2.Visible = False
        '
        'rep_bkissuereg
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 519)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "rep_bkissuereg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Book Issue Register. . . . ."
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btncalc As System.Windows.Forms.Button
    Friend WithEvents btnexport As System.Windows.Forms.Button
    Friend WithEvents btnrfresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblstud As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtbkcd As System.Windows.Forms.TextBox
    Friend WithEvents txtstudcd As System.Windows.Forms.TextBox
    Friend WithEvents lblmsg As System.Windows.Forms.Label
    Friend WithEvents todt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents fromdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbstud As System.Windows.Forms.ComboBox
    Friend WithEvents cmbbook As System.Windows.Forms.ComboBox
    Friend WithEvents chkabstract As System.Windows.Forms.CheckBox
    Friend WithEvents chkdetail As System.Windows.Forms.CheckBox
    Friend WithEvents chkbook As System.Windows.Forms.CheckBox
    Friend WithEvents chkstud As System.Windows.Forms.CheckBox
    Friend WithEvents cmbiss As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmborder As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbref As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
