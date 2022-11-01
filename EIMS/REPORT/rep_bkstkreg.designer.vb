<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rep_bkstkreg
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btncalc = New System.Windows.Forms.Button
        Me.btnexport = New System.Windows.Forms.Button
        Me.btnrfresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnview = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkabstract = New System.Windows.Forms.CheckBox
        Me.chkdetail = New System.Windows.Forms.CheckBox
        Me.cmborder = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbpub = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkpub = New System.Windows.Forms.CheckBox
        Me.cmbbook = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkbook = New System.Windows.Forms.CheckBox
        Me.cmbauth = New System.Windows.Forms.ComboBox
        Me.txtunitcd = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkauth = New System.Windows.Forms.CheckBox
        Me.txtauthcd = New System.Windows.Forms.TextBox
        Me.txtbkcd = New System.Windows.Forms.TextBox
        Me.txtpubcd = New System.Windows.Forms.TextBox
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
        Me.btncalc.TabIndex = 12
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
        Me.btnexport.TabIndex = 10
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
        Me.btnrfresh.TabIndex = 11
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
        Me.btnexit.TabIndex = 13
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
        Me.btnview.TabIndex = 9
        Me.btnview.Text = "&View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbpub)
        Me.GroupBox1.Controls.Add(Me.cmbauth)
        Me.GroupBox1.Controls.Add(Me.cmbbook)
        Me.GroupBox1.Controls.Add(Me.cmborder)
        Me.GroupBox1.Controls.Add(Me.chkabstract)
        Me.GroupBox1.Controls.Add(Me.chkdetail)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.chkpub)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkbook)
        Me.GroupBox1.Controls.Add(Me.txtunitcd)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkauth)
        Me.GroupBox1.Controls.Add(Me.txtauthcd)
        Me.GroupBox1.Controls.Add(Me.txtbkcd)
        Me.GroupBox1.Controls.Add(Me.txtpubcd)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(269, 333)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filters . . ."
        '
        'chkabstract
        '
        Me.chkabstract.AutoSize = True
        Me.chkabstract.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkabstract.Location = New System.Drawing.Point(148, 221)
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
        Me.chkdetail.Location = New System.Drawing.Point(8, 221)
        Me.chkdetail.Name = "chkdetail"
        Me.chkdetail.Size = New System.Drawing.Size(73, 17)
        Me.chkdetail.TabIndex = 7
        Me.chkdetail.Text = "DETAIL"
        Me.chkdetail.UseVisualStyleBackColor = True
        '
        'cmborder
        '
        Me.cmborder.FormattingEnabled = True
        Me.cmborder.Items.AddRange(New Object() {"1.Book Name", "2.Author Name", "3.Publication Name"})
        Me.cmborder.Location = New System.Drawing.Point(6, 175)
        Me.cmborder.Name = "cmborder"
        Me.cmborder.Size = New System.Drawing.Size(159, 21)
        Me.cmborder.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(12, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Order By :"
        '
        'cmbpub
        '
        Me.cmbpub.BackColor = System.Drawing.Color.White
        Me.cmbpub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbpub.FormattingEnabled = True
        Me.cmbpub.Location = New System.Drawing.Point(6, 40)
        Me.cmbpub.Name = "cmbpub"
        Me.cmbpub.Size = New System.Drawing.Size(208, 21)
        Me.cmbpub.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Publication Name :"
        '
        'chkpub
        '
        Me.chkpub.AutoSize = True
        Me.chkpub.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkpub.ForeColor = System.Drawing.Color.Blue
        Me.chkpub.Location = New System.Drawing.Point(220, 43)
        Me.chkpub.Name = "chkpub"
        Me.chkpub.Size = New System.Drawing.Size(43, 17)
        Me.chkpub.TabIndex = 1
        Me.chkpub.Text = "All"
        Me.chkpub.UseVisualStyleBackColor = True
        '
        'cmbbook
        '
        Me.cmbbook.BackColor = System.Drawing.Color.White
        Me.cmbbook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbbook.FormattingEnabled = True
        Me.cmbbook.Location = New System.Drawing.Point(6, 130)
        Me.cmbbook.Name = "cmbbook"
        Me.cmbbook.Size = New System.Drawing.Size(208, 21)
        Me.cmbbook.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Book Name :"
        '
        'chkbook
        '
        Me.chkbook.AutoSize = True
        Me.chkbook.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkbook.ForeColor = System.Drawing.Color.Blue
        Me.chkbook.Location = New System.Drawing.Point(220, 133)
        Me.chkbook.Name = "chkbook"
        Me.chkbook.Size = New System.Drawing.Size(43, 17)
        Me.chkbook.TabIndex = 5
        Me.chkbook.Text = "All"
        Me.chkbook.UseVisualStyleBackColor = True
        '
        'cmbauth
        '
        Me.cmbauth.BackColor = System.Drawing.Color.White
        Me.cmbauth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbauth.FormattingEnabled = True
        Me.cmbauth.Location = New System.Drawing.Point(6, 85)
        Me.cmbauth.Name = "cmbauth"
        Me.cmbauth.Size = New System.Drawing.Size(208, 21)
        Me.cmbauth.TabIndex = 2
        '
        'txtunitcd
        '
        Me.txtunitcd.Location = New System.Drawing.Point(99, 258)
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
        Me.Label3.Location = New System.Drawing.Point(12, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Author Name :"
        '
        'chkauth
        '
        Me.chkauth.AutoSize = True
        Me.chkauth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkauth.ForeColor = System.Drawing.Color.Blue
        Me.chkauth.Location = New System.Drawing.Point(220, 88)
        Me.chkauth.Name = "chkauth"
        Me.chkauth.Size = New System.Drawing.Size(43, 17)
        Me.chkauth.TabIndex = 3
        Me.chkauth.Text = "All"
        Me.chkauth.UseVisualStyleBackColor = True
        '
        'txtauthcd
        '
        Me.txtauthcd.Location = New System.Drawing.Point(37, 258)
        Me.txtauthcd.Name = "txtauthcd"
        Me.txtauthcd.Size = New System.Drawing.Size(25, 21)
        Me.txtauthcd.TabIndex = 20
        Me.txtauthcd.Visible = False
        '
        'txtbkcd
        '
        Me.txtbkcd.Location = New System.Drawing.Point(68, 258)
        Me.txtbkcd.Name = "txtbkcd"
        Me.txtbkcd.Size = New System.Drawing.Size(25, 21)
        Me.txtbkcd.TabIndex = 19
        Me.txtbkcd.Visible = False
        '
        'txtpubcd
        '
        Me.txtpubcd.Location = New System.Drawing.Point(6, 258)
        Me.txtpubcd.Name = "txtpubcd"
        Me.txtpubcd.Size = New System.Drawing.Size(25, 21)
        Me.txtpubcd.TabIndex = 18
        Me.txtpubcd.Visible = False
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
        Me.GroupBox3.Text = "Book Stock Register . . . "
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
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Transparent
        Me.dv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dv.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dv.DefaultCellStyle = DataGridViewCellStyle8
        Me.dv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dv.GridColor = System.Drawing.Color.Black
        Me.dv.Location = New System.Drawing.Point(3, 17)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(727, 495)
        Me.dv.TabIndex = 19
        '
        'rep_bkstkreg
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1020, 529)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "rep_bkstkreg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "rep_bkstkreg"
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
    Friend WithEvents txtpubcd As System.Windows.Forms.TextBox
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
    Friend WithEvents txtauthcd As System.Windows.Forms.TextBox
    Friend WithEvents txtbkcd As System.Windows.Forms.TextBox
    Friend WithEvents lblmsg As System.Windows.Forms.Label
    Friend WithEvents txtunitcd As System.Windows.Forms.TextBox
    Friend WithEvents cmbauth As System.Windows.Forms.ComboBox
    Friend WithEvents chkauth As System.Windows.Forms.CheckBox
    Friend WithEvents cmbpub As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkpub As System.Windows.Forms.CheckBox
    Friend WithEvents cmbbook As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkbook As System.Windows.Forms.CheckBox
    Friend WithEvents cmborder As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkabstract As System.Windows.Forms.CheckBox
    Friend WithEvents chkdetail As System.Windows.Forms.CheckBox

End Class
