<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmscroll
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dv1 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtbookcd = New System.Windows.Forms.TextBox
        Me.cmbbooknm = New System.Windows.Forms.ComboBox
        Me.txtmrp = New System.Windows.Forms.TextBox
        Me.txtsub = New System.Windows.Forms.TextBox
        Me.txtauth = New System.Windows.Forms.TextBox
        Me.txtpub = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtstock = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtisbn = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtothauth = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtdetailnm = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.dv1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtbookcd)
        Me.Panel1.Controls.Add(Me.cmbbooknm)
        Me.Panel1.Controls.Add(Me.txtmrp)
        Me.Panel1.Controls.Add(Me.txtsub)
        Me.Panel1.Controls.Add(Me.txtauth)
        Me.Panel1.Controls.Add(Me.txtpub)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtstock)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtisbn)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtothauth)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtdetailnm)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(656, 412)
        Me.Panel1.TabIndex = 0
        '
        'dv1
        '
        Me.dv1.AllowUserToAddRows = False
        Me.dv1.AllowUserToDeleteRows = False
        Me.dv1.AllowUserToResizeColumns = False
        Me.dv1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dv1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dv1.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn14, Me.Column4, Me.Column1, Me.Column5, Me.DataGridViewTextBoxColumn15, Me.Column11, Me.Column12, Me.DataGridViewTextBoxColumn20})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dv1.DefaultCellStyle = DataGridViewCellStyle3
        Me.dv1.GridColor = System.Drawing.Color.LightPink
        Me.dv1.Location = New System.Drawing.Point(5, 143)
        Me.dv1.Name = "dv1"
        Me.dv1.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightCyan
        Me.dv1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dv1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv1.RowTemplate.Height = 20
        Me.dv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dv1.Size = New System.Drawing.Size(644, 210)
        Me.dv1.TabIndex = 124
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Sl"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 30
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Book Code"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Edition"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 80
        '
        'Column1
        '
        Me.Column1.HeaderText = "Yr Of Pub."
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 81
        '
        'Column5
        '
        Me.Column5.HeaderText = "Pages"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 70
        '
        'DataGridViewTextBoxColumn15
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn15.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn15.HeaderText = "M.R.P"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Width = 80
        '
        'Column11
        '
        Me.Column11.HeaderText = "Condition"
        Me.Column11.Items.AddRange(New Object() {"1. Good", "2. Semi Damage", "3. Damage"})
        Me.Column11.Name = "Column11"
        Me.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column12
        '
        Me.Column12.HeaderText = "Pur.Date"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "Column14"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(203, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 14)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "List Of Books Which Are Not Scrolled"
        '
        'txtbookcd
        '
        Me.txtbookcd.Location = New System.Drawing.Point(605, 6)
        Me.txtbookcd.Name = "txtbookcd"
        Me.txtbookcd.Size = New System.Drawing.Size(29, 21)
        Me.txtbookcd.TabIndex = 122
        Me.txtbookcd.Visible = False
        '
        'cmbbooknm
        '
        Me.cmbbooknm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbbooknm.FormattingEnabled = True
        Me.cmbbooknm.ItemHeight = 13
        Me.cmbbooknm.Location = New System.Drawing.Point(126, 6)
        Me.cmbbooknm.Name = "cmbbooknm"
        Me.cmbbooknm.Size = New System.Drawing.Size(478, 21)
        Me.cmbbooknm.TabIndex = 0
        '
        'txtmrp
        '
        Me.txtmrp.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtmrp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmrp.Location = New System.Drawing.Point(420, 94)
        Me.txtmrp.Name = "txtmrp"
        Me.txtmrp.ReadOnly = True
        Me.txtmrp.Size = New System.Drawing.Size(58, 21)
        Me.txtmrp.TabIndex = 7
        '
        'txtsub
        '
        Me.txtsub.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtsub.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsub.Location = New System.Drawing.Point(126, 94)
        Me.txtsub.Name = "txtsub"
        Me.txtsub.ReadOnly = True
        Me.txtsub.Size = New System.Drawing.Size(185, 21)
        Me.txtsub.TabIndex = 6
        '
        'txtauth
        '
        Me.txtauth.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtauth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtauth.Location = New System.Drawing.Point(126, 72)
        Me.txtauth.Name = "txtauth"
        Me.txtauth.ReadOnly = True
        Me.txtauth.Size = New System.Drawing.Size(185, 21)
        Me.txtauth.TabIndex = 4
        '
        'txtpub
        '
        Me.txtpub.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtpub.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpub.Location = New System.Drawing.Point(419, 50)
        Me.txtpub.Name = "txtpub"
        Me.txtpub.ReadOnly = True
        Me.txtpub.Size = New System.Drawing.Size(185, 21)
        Me.txtpub.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Red
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(-3, 118)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(660, 2)
        Me.Label12.TabIndex = 41
        '
        'txtstock
        '
        Me.txtstock.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtstock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtstock.Location = New System.Drawing.Point(546, 94)
        Me.txtstock.Name = "txtstock"
        Me.txtstock.ReadOnly = True
        Me.txtstock.Size = New System.Drawing.Size(58, 21)
        Me.txtstock.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(489, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Stock :"
        '
        'txtisbn
        '
        Me.txtisbn.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtisbn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtisbn.Location = New System.Drawing.Point(126, 50)
        Me.txtisbn.MaxLength = 25
        Me.txtisbn.Name = "txtisbn"
        Me.txtisbn.ReadOnly = True
        Me.txtisbn.Size = New System.Drawing.Size(185, 21)
        Me.txtisbn.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(53, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "ISBN No :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(56, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Subject :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(372, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "MRP :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(326, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Publication :"
        '
        'txtothauth
        '
        Me.txtothauth.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtothauth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtothauth.Location = New System.Drawing.Point(419, 72)
        Me.txtothauth.Name = "txtothauth"
        Me.txtothauth.ReadOnly = True
        Me.txtothauth.Size = New System.Drawing.Size(185, 21)
        Me.txtothauth.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(314, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Other Author :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(20, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Author Name :"
        '
        'txtdetailnm
        '
        Me.txtdetailnm.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdetailnm.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdetailnm.Location = New System.Drawing.Point(126, 28)
        Me.txtdetailnm.Name = "txtdetailnm"
        Me.txtdetailnm.ReadOnly = True
        Me.txtdetailnm.Size = New System.Drawing.Size(478, 21)
        Me.txtdetailnm.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(26, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Detail Name :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(5, 355)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(644, 50)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(259, 18)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(123, 23)
        Me.btnrefresh.TabIndex = 10
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(12, 18)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(123, 23)
        Me.btnexit.TabIndex = 12
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(506, 18)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(123, 23)
        Me.btnsave.TabIndex = 9
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(32, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Book Name :"
        '
        'frmscroll
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(660, 417)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmscroll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scrolling of Books"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtothauth As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtdetailnm As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtstock As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtisbn As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbbooknm As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtauth As System.Windows.Forms.TextBox
    Friend WithEvents txtpub As System.Windows.Forms.TextBox
    Friend WithEvents txtmrp As System.Windows.Forms.TextBox
    Friend WithEvents txtsub As System.Windows.Forms.TextBox
    Friend WithEvents txtbookcd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dv1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
