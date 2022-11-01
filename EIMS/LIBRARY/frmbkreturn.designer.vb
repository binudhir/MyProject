<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmbkreturn
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dv = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bookcd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.txtstafcd = New System.Windows.Forms.TextBox
        Me.txtstucd = New System.Windows.Forms.TextBox
        Me.lbltrade = New System.Windows.Forms.Label
        Me.txttrade = New System.Windows.Forms.TextBox
        Me.txtsession = New System.Windows.Forms.TextBox
        Me.txtroll = New System.Windows.Forms.TextBox
        Me.lblroll = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.cmbtrtype = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblsession = New System.Windows.Forms.Label
        Me.dttr = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtsem = New System.Windows.Forms.TextBox
        Me.lblsem = New System.Windows.Forms.Label
        Me.txtnm = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.txtstafcd)
        Me.Panel1.Controls.Add(Me.txtstucd)
        Me.Panel1.Controls.Add(Me.lbltrade)
        Me.Panel1.Controls.Add(Me.txttrade)
        Me.Panel1.Controls.Add(Me.txtsession)
        Me.Panel1.Controls.Add(Me.txtroll)
        Me.Panel1.Controls.Add(Me.lblroll)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.cmbtrtype)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.lblsession)
        Me.Panel1.Controls.Add(Me.dttr)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtsem)
        Me.Panel1.Controls.Add(Me.lblsem)
        Me.Panel1.Controls.Add(Me.txtnm)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(851, 418)
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
        Me.dv.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column8, Me.Column9, Me.Column14, Me.bookcd, Me.Column15})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dv.DefaultCellStyle = DataGridViewCellStyle8
        Me.dv.GridColor = System.Drawing.Color.Black
        Me.dv.Location = New System.Drawing.Point(1, 55)
        Me.dv.Name = "dv"
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Azure
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(847, 308)
        Me.dv.TabIndex = 1240
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn1.HeaderText = "Sl."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 29
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn2.HeaderText = " Book Code"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 90
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Name Of The Book"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 165
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Publication"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn5.HeaderText = "MRP"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 60
        '
        'Column10
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column10.HeaderText = "Iss. Dt."
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 90
        '
        'Column11
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column11.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column11.HeaderText = "Ret. Dt."
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 90
        '
        'Column12
        '
        Me.Column12.HeaderText = "Condition"
        Me.Column12.Items.AddRange(New Object() {"1. Good", "2. Semi Damage", "3. Damage"})
        Me.Column12.MaxDropDownItems = 3
        Me.Column12.Name = "Column12"
        Me.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column13
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column13.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column13.HeaderText = "Penalty"
        Me.Column13.Name = "Column13"
        Me.Column13.Width = 60
        '
        'Column8
        '
        Me.Column8.HeaderText = "bookcd"
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "issno"
        Me.Column9.Name = "Column9"
        Me.Column9.Visible = False
        '
        'Column14
        '
        Me.Column14.HeaderText = "iss_sl"
        Me.Column14.Name = "Column14"
        Me.Column14.Visible = False
        '
        'bookcd
        '
        Me.bookcd.HeaderText = "bookcd"
        Me.bookcd.Name = "bookcd"
        Me.bookcd.Visible = False
        '
        'Column15
        '
        Me.Column15.HeaderText = "Refund"
        Me.Column15.Name = "Column15"
        Me.Column15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column15.Text = "Refund"
        Me.Column15.Width = 60
        '
        'txtstafcd
        '
        Me.txtstafcd.BackColor = System.Drawing.SystemColors.Info
        Me.txtstafcd.Enabled = False
        Me.txtstafcd.Location = New System.Drawing.Point(378, 28)
        Me.txtstafcd.Multiline = True
        Me.txtstafcd.Name = "txtstafcd"
        Me.txtstafcd.Size = New System.Drawing.Size(29, 20)
        Me.txtstafcd.TabIndex = 1239
        Me.txtstafcd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtstafcd.Visible = False
        '
        'txtstucd
        '
        Me.txtstucd.BackColor = System.Drawing.SystemColors.Info
        Me.txtstucd.Enabled = False
        Me.txtstucd.Location = New System.Drawing.Point(335, 28)
        Me.txtstucd.Multiline = True
        Me.txtstucd.Name = "txtstucd"
        Me.txtstucd.Size = New System.Drawing.Size(29, 20)
        Me.txtstucd.TabIndex = 1238
        Me.txtstucd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtstucd.Visible = False
        '
        'lbltrade
        '
        Me.lbltrade.AutoSize = True
        Me.lbltrade.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbltrade.Location = New System.Drawing.Point(172, 30)
        Me.lbltrade.Name = "lbltrade"
        Me.lbltrade.Size = New System.Drawing.Size(60, 13)
        Me.lbltrade.TabIndex = 130
        Me.lbltrade.Text = "Branch :"
        '
        'txttrade
        '
        Me.txttrade.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txttrade.Enabled = False
        Me.txttrade.Location = New System.Drawing.Point(233, 27)
        Me.txttrade.Multiline = True
        Me.txttrade.Name = "txttrade"
        Me.txttrade.Size = New System.Drawing.Size(96, 20)
        Me.txttrade.TabIndex = 129
        Me.txttrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtsession
        '
        Me.txtsession.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtsession.Enabled = False
        Me.txtsession.Location = New System.Drawing.Point(78, 28)
        Me.txtsession.Multiline = True
        Me.txtsession.Name = "txtsession"
        Me.txtsession.Size = New System.Drawing.Size(91, 20)
        Me.txtsession.TabIndex = 102
        Me.txtsession.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtroll
        '
        Me.txtroll.Location = New System.Drawing.Point(233, 5)
        Me.txtroll.Name = "txtroll"
        Me.txtroll.Size = New System.Drawing.Size(96, 21)
        Me.txtroll.TabIndex = 1
        Me.txtroll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblroll
        '
        Me.lblroll.AutoSize = True
        Me.lblroll.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblroll.Location = New System.Drawing.Point(172, 8)
        Me.lblroll.Name = "lblroll"
        Me.lblroll.Size = New System.Drawing.Size(60, 13)
        Me.lblroll.TabIndex = 127
        Me.lblroll.Text = "Roll No :"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Red
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Red
        Me.Label29.Location = New System.Drawing.Point(-1, 366)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(851, 1)
        Me.Label29.TabIndex = 125
        Me.Label29.Text = "Address :"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Red
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(-1, 51)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(851, 1)
        Me.Label26.TabIndex = 105
        Me.Label26.Text = "Address :"
        '
        'cmbtrtype
        '
        Me.cmbtrtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtrtype.FormattingEnabled = True
        Me.cmbtrtype.Items.AddRange(New Object() {"1. Student", "2. Staff"})
        Me.cmbtrtype.Location = New System.Drawing.Point(78, 5)
        Me.cmbtrtype.Name = "cmbtrtype"
        Me.cmbtrtype.Size = New System.Drawing.Size(91, 21)
        Me.cmbtrtype.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(2, 369)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(844, 46)
        Me.GroupBox1.TabIndex = 100
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls . . ."
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.ForeColor = System.Drawing.Color.Red
        Me.btnexit.Location = New System.Drawing.Point(104, 15)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(91, 23)
        Me.btnexit.TabIndex = 9
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.ForeColor = System.Drawing.Color.Red
        Me.btnrefresh.Location = New System.Drawing.Point(653, 15)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(91, 23)
        Me.btnrefresh.TabIndex = 8
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(9, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Tr. With :"
        '
        'lblsession
        '
        Me.lblsession.AutoSize = True
        Me.lblsession.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblsession.Location = New System.Drawing.Point(10, 30)
        Me.lblsession.Name = "lblsession"
        Me.lblsession.Size = New System.Drawing.Size(65, 13)
        Me.lblsession.TabIndex = 27
        Me.lblsession.Text = "Session :"
        '
        'dttr
        '
        Me.dttr.CalendarForeColor = System.Drawing.Color.Black
        Me.dttr.CustomFormat = "dd/MM/yyyy"
        Me.dttr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttr.Location = New System.Drawing.Point(724, 4)
        Me.dttr.Name = "dttr"
        Me.dttr.Size = New System.Drawing.Size(121, 21)
        Me.dttr.TabIndex = 101
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(652, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Tr. Date :"
        '
        'txtsem
        '
        Me.txtsem.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtsem.Enabled = False
        Me.txtsem.Location = New System.Drawing.Point(724, 27)
        Me.txtsem.Multiline = True
        Me.txtsem.Name = "txtsem"
        Me.txtsem.Size = New System.Drawing.Size(121, 20)
        Me.txtsem.TabIndex = 123
        '
        'lblsem
        '
        Me.lblsem.AutoSize = True
        Me.lblsem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblsem.Location = New System.Drawing.Point(670, 30)
        Me.lblsem.Name = "lblsem"
        Me.lblsem.Size = New System.Drawing.Size(49, 13)
        Me.lblsem.TabIndex = 23
        Me.lblsem.Text = "Class :"
        '
        'txtnm
        '
        Me.txtnm.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtnm.Enabled = False
        Me.txtnm.Location = New System.Drawing.Point(385, 5)
        Me.txtnm.Multiline = True
        Me.txtnm.Name = "txtnm"
        Me.txtnm.Size = New System.Drawing.Size(260, 20)
        Me.txtnm.TabIndex = 100
        Me.txtnm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(330, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Name :"
        '
        'frmbkreturn
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(855, 422)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmbkreturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Book Return Screen...."
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblsem As System.Windows.Forms.Label
    Friend WithEvents txtnm As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtsem As System.Windows.Forms.TextBox
    Friend WithEvents dttr As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblsession As System.Windows.Forms.Label
    Friend WithEvents cmbtrtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lbltrade As System.Windows.Forms.Label
    Friend WithEvents txttrade As System.Windows.Forms.TextBox
    Friend WithEvents txtsession As System.Windows.Forms.TextBox
    Friend WithEvents txtroll As System.Windows.Forms.TextBox
    Friend WithEvents lblroll As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents txtstucd As System.Windows.Forms.TextBox
    Friend WithEvents txtstafcd As System.Windows.Forms.TextBox
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bookcd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewButtonColumn

End Class
