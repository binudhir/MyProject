<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rep_stockreg
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btncalc = New System.Windows.Forms.Button
        Me.btnexport = New System.Windows.Forms.Button
        Me.btnrfresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnview = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbprod = New System.Windows.Forms.ComboBox
        Me.cmbunit = New System.Windows.Forms.ComboBox
        Me.chkzero = New System.Windows.Forms.CheckBox
        Me.rdbabstra = New System.Windows.Forms.RadioButton
        Me.rdbdetail = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.startdt = New System.Windows.Forms.DateTimePicker
        Me.txtunitcd = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkprod = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.enddt = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtprodcd = New System.Windows.Forms.TextBox
        Me.txtgodncd = New System.Windows.Forms.TextBox
        Me.txtcompcd = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblmsg = New System.Windows.Forms.Label
        Me.dv = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightCyan
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1016, 523)
        Me.Panel1.TabIndex = 0
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
        Me.GroupBox2.Location = New System.Drawing.Point(4, 351)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(268, 167)
        Me.GroupBox2.TabIndex = 53
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Controlls . . ."
        '
        'btncalc
        '
        Me.btncalc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncalc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncalc.Location = New System.Drawing.Point(92, 106)
        Me.btncalc.Name = "btncalc"
        Me.btncalc.Size = New System.Drawing.Size(85, 23)
        Me.btncalc.TabIndex = 15
        Me.btncalc.Text = "&Calculator"
        Me.btncalc.UseVisualStyleBackColor = True
        '
        'btnexport
        '
        Me.btnexport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexport.Location = New System.Drawing.Point(92, 49)
        Me.btnexport.Name = "btnexport"
        Me.btnexport.Size = New System.Drawing.Size(85, 23)
        Me.btnexport.TabIndex = 13
        Me.btnexport.Text = "&Export"
        Me.btnexport.UseVisualStyleBackColor = True
        '
        'btnrfresh
        '
        Me.btnrfresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrfresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrfresh.Location = New System.Drawing.Point(92, 77)
        Me.btnrfresh.Name = "btnrfresh"
        Me.btnrfresh.Size = New System.Drawing.Size(85, 23)
        Me.btnrfresh.TabIndex = 14
        Me.btnrfresh.Text = "&Refresh"
        Me.btnrfresh.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(92, 134)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(85, 23)
        Me.btnexit.TabIndex = 16
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnview
        '
        Me.btnview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnview.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnview.Location = New System.Drawing.Point(92, 20)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(85, 23)
        Me.btnview.TabIndex = 12
        Me.btnview.Text = "&View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbprod)
        Me.GroupBox1.Controls.Add(Me.cmbunit)
        Me.GroupBox1.Controls.Add(Me.chkzero)
        Me.GroupBox1.Controls.Add(Me.rdbabstra)
        Me.GroupBox1.Controls.Add(Me.rdbdetail)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.startdt)
        Me.GroupBox1.Controls.Add(Me.txtunitcd)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkprod)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.enddt)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtprodcd)
        Me.GroupBox1.Controls.Add(Me.txtgodncd)
        Me.GroupBox1.Controls.Add(Me.txtcompcd)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(269, 333)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filters . . ."
        '
        'cmbprod
        '
        Me.cmbprod.BackColor = System.Drawing.Color.White
        Me.cmbprod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbprod.FormattingEnabled = True
        Me.cmbprod.Location = New System.Drawing.Point(7, 149)
        Me.cmbprod.Name = "cmbprod"
        Me.cmbprod.Size = New System.Drawing.Size(208, 21)
        Me.cmbprod.TabIndex = 4
        '
        'cmbunit
        '
        Me.cmbunit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbunit.FormattingEnabled = True
        Me.cmbunit.Items.AddRange(New Object() {"Unit 1", "Unit 2", "Unit 3", "Unit 4"})
        Me.cmbunit.Location = New System.Drawing.Point(7, 204)
        Me.cmbunit.Name = "cmbunit"
        Me.cmbunit.Size = New System.Drawing.Size(152, 21)
        Me.cmbunit.TabIndex = 8
        '
        'chkzero
        '
        Me.chkzero.AutoSize = True
        Me.chkzero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkzero.Location = New System.Drawing.Point(7, 307)
        Me.chkzero.Name = "chkzero"
        Me.chkzero.Size = New System.Drawing.Size(138, 17)
        Me.chkzero.TabIndex = 11
        Me.chkzero.Text = "Print Zero Stocks"
        Me.chkzero.UseVisualStyleBackColor = True
        '
        'rdbabstra
        '
        Me.rdbabstra.AutoSize = True
        Me.rdbabstra.Checked = True
        Me.rdbabstra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdbabstra.Location = New System.Drawing.Point(163, 254)
        Me.rdbabstra.Name = "rdbabstra"
        Me.rdbabstra.Size = New System.Drawing.Size(91, 17)
        Me.rdbabstra.TabIndex = 10
        Me.rdbabstra.TabStop = True
        Me.rdbabstra.Text = "ABSTRACT"
        Me.rdbabstra.UseVisualStyleBackColor = True
        Me.rdbabstra.Visible = False
        '
        'rdbdetail
        '
        Me.rdbdetail.AutoSize = True
        Me.rdbdetail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdbdetail.Location = New System.Drawing.Point(7, 254)
        Me.rdbdetail.Name = "rdbdetail"
        Me.rdbdetail.Size = New System.Drawing.Size(72, 17)
        Me.rdbdetail.TabIndex = 9
        Me.rdbdetail.Text = "DETAIL"
        Me.rdbdetail.UseVisualStyleBackColor = True
        Me.rdbdetail.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Select Unit :"
        '
        'startdt
        '
        Me.startdt.CalendarForeColor = System.Drawing.Color.Black
        Me.startdt.CustomFormat = "dd/MM/yyyy"
        Me.startdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.startdt.Location = New System.Drawing.Point(7, 41)
        Me.startdt.Name = "startdt"
        Me.startdt.Size = New System.Drawing.Size(140, 21)
        Me.startdt.TabIndex = 0
        '
        'txtunitcd
        '
        Me.txtunitcd.Location = New System.Drawing.Point(206, 86)
        Me.txtunitcd.Name = "txtunitcd"
        Me.txtunitcd.Size = New System.Drawing.Size(25, 21)
        Me.txtunitcd.TabIndex = 30
        Me.txtunitcd.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(13, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Product Name :"
        '
        'chkprod
        '
        Me.chkprod.AutoSize = True
        Me.chkprod.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkprod.ForeColor = System.Drawing.Color.Blue
        Me.chkprod.Location = New System.Drawing.Point(221, 152)
        Me.chkprod.Name = "chkprod"
        Me.chkprod.Size = New System.Drawing.Size(43, 17)
        Me.chkprod.TabIndex = 5
        Me.chkprod.Text = "All"
        Me.chkprod.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(13, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Ending Date :"
        '
        'enddt
        '
        Me.enddt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.enddt.CalendarForeColor = System.Drawing.Color.Black
        Me.enddt.CustomFormat = "dd/MM/yyyy"
        Me.enddt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.enddt.Location = New System.Drawing.Point(7, 87)
        Me.enddt.Name = "enddt"
        Me.enddt.Size = New System.Drawing.Size(140, 21)
        Me.enddt.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Starting Date :"
        '
        'txtprodcd
        '
        Me.txtprodcd.Location = New System.Drawing.Point(206, 40)
        Me.txtprodcd.Name = "txtprodcd"
        Me.txtprodcd.Size = New System.Drawing.Size(25, 21)
        Me.txtprodcd.TabIndex = 20
        Me.txtprodcd.Visible = False
        '
        'txtgodncd
        '
        Me.txtgodncd.Location = New System.Drawing.Point(206, 62)
        Me.txtgodncd.Name = "txtgodncd"
        Me.txtgodncd.Size = New System.Drawing.Size(25, 21)
        Me.txtgodncd.TabIndex = 19
        Me.txtgodncd.Visible = False
        '
        'txtcompcd
        '
        Me.txtcompcd.Location = New System.Drawing.Point(206, 17)
        Me.txtcompcd.Name = "txtcompcd"
        Me.txtcompcd.Size = New System.Drawing.Size(25, 21)
        Me.txtcompcd.TabIndex = 18
        Me.txtcompcd.Visible = False
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
        Me.GroupBox3.Location = New System.Drawing.Point(278, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(733, 515)
        Me.GroupBox3.TabIndex = 54
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Stock Register . . . "
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
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Transparent
        Me.dv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dv.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dv.DefaultCellStyle = DataGridViewCellStyle11
        Me.dv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dv.GridColor = System.Drawing.Color.Black
        Me.dv.Location = New System.Drawing.Point(3, 17)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(727, 495)
        Me.dv.TabIndex = 19
        '
        'rep_stockreg
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 529)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "rep_stockreg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "rep_stockreg"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtcompcd As System.Windows.Forms.TextBox
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btncalc As System.Windows.Forms.Button
    Friend WithEvents btnexport As System.Windows.Forms.Button
    Friend WithEvents btnrfresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtprodcd As System.Windows.Forms.TextBox
    Friend WithEvents txtgodncd As System.Windows.Forms.TextBox
    Friend WithEvents lblmsg As System.Windows.Forms.Label
    Friend WithEvents enddt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtunitcd As System.Windows.Forms.TextBox
    Friend WithEvents startdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbprod As System.Windows.Forms.ComboBox
    Friend WithEvents chkprod As System.Windows.Forms.CheckBox
    Friend WithEvents cmbunit As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdbabstra As System.Windows.Forms.RadioButton
    Friend WithEvents rdbdetail As System.Windows.Forms.RadioButton
    Friend WithEvents chkzero As System.Windows.Forms.CheckBox

End Class
