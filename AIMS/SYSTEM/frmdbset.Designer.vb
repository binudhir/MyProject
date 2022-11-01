<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmdbset
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dv = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkall = New System.Windows.Forms.CheckBox
        Me.btnsearch = New System.Windows.Forms.Button
        Me.cmbsrvnm = New System.Windows.Forms.ComboBox
        Me.btnconnect = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnget = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtpswd = New System.Windows.Forms.TextBox
        Me.cmblogtp = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtuserid = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rdbcreatedb = New System.Windows.Forms.RadioButton
        Me.rdblinkdb = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdbnetwrk = New System.Windows.Forms.RadioButton
        Me.rdblocal = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.dv)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(457, 412)
        Me.Panel1.TabIndex = 0
        '
        'dv
        '
        Me.dv.AllowUserToAddRows = False
        Me.dv.AllowUserToDeleteRows = False
        Me.dv.AllowUserToResizeColumns = False
        Me.dv.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dv.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column5})
        Me.dv.GridColor = System.Drawing.Color.Black
        Me.dv.Location = New System.Drawing.Point(3, 220)
        Me.dv.Name = "dv"
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Azure
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(449, 137)
        Me.dv.TabIndex = 33
        '
        'Column1
        '
        Me.Column1.FalseValue = "0"
        Me.Column1.HeaderText = "Sl"
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column1.TrueValue = "1"
        Me.Column1.Width = 44
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Database Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Column5"
        Me.Column5.Name = "Column5"
        Me.Column5.Visible = False
        Me.Column5.Width = 88
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkall)
        Me.GroupBox4.Controls.Add(Me.btnsearch)
        Me.GroupBox4.Controls.Add(Me.cmbsrvnm)
        Me.GroupBox4.Controls.Add(Me.btnconnect)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.btnget)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txtpswd)
        Me.GroupBox4.Controls.Add(Me.cmblogtp)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.txtuserid)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Red
        Me.GroupBox4.Location = New System.Drawing.Point(10, 95)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(442, 119)
        Me.GroupBox4.TabIndex = 31
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Action . . . "
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.Location = New System.Drawing.Point(342, 91)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(87, 17)
        Me.chkall.TabIndex = 34
        Me.chkall.Text = "Select All"
        Me.chkall.UseVisualStyleBackColor = True
        '
        'btnsearch
        '
        Me.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearch.Location = New System.Drawing.Point(338, 64)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(100, 23)
        Me.btnsearch.TabIndex = 39
        Me.btnsearch.Text = "&Search"
        Me.btnsearch.UseVisualStyleBackColor = True
        '
        'cmbsrvnm
        '
        Me.cmbsrvnm.FormattingEnabled = True
        Me.cmbsrvnm.Location = New System.Drawing.Point(109, 17)
        Me.cmbsrvnm.Name = "cmbsrvnm"
        Me.cmbsrvnm.Size = New System.Drawing.Size(227, 21)
        Me.cmbsrvnm.TabIndex = 2
        '
        'btnconnect
        '
        Me.btnconnect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnconnect.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnconnect.Location = New System.Drawing.Point(338, 40)
        Me.btnconnect.Name = "btnconnect"
        Me.btnconnect.Size = New System.Drawing.Size(100, 23)
        Me.btnconnect.TabIndex = 38
        Me.btnconnect.Text = "&Connect"
        Me.btnconnect.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(6, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Server Name :"
        '
        'btnget
        '
        Me.btnget.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnget.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnget.Location = New System.Drawing.Point(338, 17)
        Me.btnget.Name = "btnget"
        Me.btnget.Size = New System.Drawing.Size(100, 23)
        Me.btnget.TabIndex = 37
        Me.btnget.Text = "&Get Instance"
        Me.btnget.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(20, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Login Type :"
        '
        'txtpswd
        '
        Me.txtpswd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpswd.Location = New System.Drawing.Point(109, 88)
        Me.txtpswd.Name = "txtpswd"
        Me.txtpswd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpswd.Size = New System.Drawing.Size(227, 21)
        Me.txtpswd.TabIndex = 36
        '
        'cmblogtp
        '
        Me.cmblogtp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmblogtp.FormattingEnabled = True
        Me.cmblogtp.Items.AddRange(New Object() {"1.Windows Authentication", "2.SQL Server Authentication"})
        Me.cmblogtp.Location = New System.Drawing.Point(109, 40)
        Me.cmblogtp.Name = "cmblogtp"
        Me.cmblogtp.Size = New System.Drawing.Size(227, 21)
        Me.cmblogtp.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(29, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Password :"
        '
        'txtuserid
        '
        Me.txtuserid.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuserid.Location = New System.Drawing.Point(109, 64)
        Me.txtuserid.Name = "txtuserid"
        Me.txtuserid.Size = New System.Drawing.Size(227, 21)
        Me.txtuserid.TabIndex = 34
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(42, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "User ID :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdbcreatedb)
        Me.GroupBox3.Controls.Add(Me.rdblinkdb)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Red
        Me.GroupBox3.Location = New System.Drawing.Point(232, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(212, 68)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Action . . . "
        '
        'rdbcreatedb
        '
        Me.rdbcreatedb.AutoSize = True
        Me.rdbcreatedb.Location = New System.Drawing.Point(20, 43)
        Me.rdbcreatedb.Name = "rdbcreatedb"
        Me.rdbcreatedb.Size = New System.Drawing.Size(133, 17)
        Me.rdbcreatedb.TabIndex = 1
        Me.rdbcreatedb.Text = "Create Database"
        Me.rdbcreatedb.UseVisualStyleBackColor = True
        '
        'rdblinkdb
        '
        Me.rdblinkdb.AutoSize = True
        Me.rdblinkdb.Checked = True
        Me.rdblinkdb.Location = New System.Drawing.Point(20, 20)
        Me.rdblinkdb.Name = "rdblinkdb"
        Me.rdblinkdb.Size = New System.Drawing.Size(117, 17)
        Me.rdblinkdb.TabIndex = 0
        Me.rdblinkdb.TabStop = True
        Me.rdblinkdb.Text = "Link Database"
        Me.rdblinkdb.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdbnetwrk)
        Me.GroupBox2.Controls.Add(Me.rdblocal)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Red
        Me.GroupBox2.Location = New System.Drawing.Point(6, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(212, 68)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Location . . . "
        '
        'rdbnetwrk
        '
        Me.rdbnetwrk.AutoSize = True
        Me.rdbnetwrk.Location = New System.Drawing.Point(20, 43)
        Me.rdbnetwrk.Name = "rdbnetwrk"
        Me.rdbnetwrk.Size = New System.Drawing.Size(79, 17)
        Me.rdbnetwrk.TabIndex = 1
        Me.rdbnetwrk.Text = "Network"
        Me.rdbnetwrk.UseVisualStyleBackColor = True
        '
        'rdblocal
        '
        Me.rdblocal.AutoSize = True
        Me.rdblocal.Checked = True
        Me.rdblocal.Location = New System.Drawing.Point(20, 20)
        Me.rdblocal.Name = "rdblocal"
        Me.rdblocal.Size = New System.Drawing.Size(59, 17)
        Me.rdblocal.TabIndex = 0
        Me.rdblocal.TabStop = True
        Me.rdblocal.Text = "Local"
        Me.rdblocal.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(3, 359)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(445, 49)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(185, 18)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 2
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(6, 18)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(75, 23)
        Me.btnexit.TabIndex = 1
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(364, 18)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 0
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(7, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(337, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Welcome To Database Installation Wizard . . ."
        '
        'frmdbset
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(466, 422)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmdbset"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Installation Wizard . . ."
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbcreatedb As System.Windows.Forms.RadioButton
    Friend WithEvents rdblinkdb As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbnetwrk As System.Windows.Forms.RadioButton
    Friend WithEvents rdblocal As System.Windows.Forms.RadioButton
    Friend WithEvents cmblogtp As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbsrvnm As System.Windows.Forms.ComboBox
    Friend WithEvents btnget As System.Windows.Forms.Button
    Friend WithEvents txtpswd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtuserid As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnconnect As System.Windows.Forms.Button
    Friend WithEvents btnsearch As System.Windows.Forms.Button
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
