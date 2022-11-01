<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmbook
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmbbooknm = New System.Windows.Forms.ComboBox
        Me.cmbauthnm = New System.Windows.Forms.ComboBox
        Me.cmbpublication = New System.Windows.Forms.ComboBox
        Me.cmbsub = New System.Windows.Forms.ComboBox
        Me.cmbshelf = New System.Windows.Forms.ComboBox
        Me.cmbcond = New System.Windows.Forms.ComboBox
        Me.cmblock = New System.Windows.Forms.ComboBox
        Me.txttotval = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txttotqty = New System.Windows.Forms.TextBox
        Me.btnclr = New System.Windows.Forms.Button
        Me.dv1 = New System.Windows.Forms.DataGridView
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnu1del = New System.Windows.Forms.ToolStripMenuItem
        Me.txtshelfcd = New System.Windows.Forms.TextBox
        Me.txtpubcd = New System.Windows.Forms.TextBox
        Me.txtsubcd = New System.Windows.Forms.TextBox
        Me.txtauthcd = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtedition = New System.Windows.Forms.TextBox
        Me.btnnxt = New System.Windows.Forms.Button
        Me.txtcost = New System.Windows.Forms.TextBox
        Me.txtpage = New System.Windows.Forms.TextBox
        Me.txtyear = New System.Windows.Forms.TextBox
        Me.txtaccessno = New System.Windows.Forms.TextBox
        Me.txtsl = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtbarcd = New System.Windows.Forms.TextBox
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
        Me.txtnewnm = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtscrl = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnview = New System.Windows.Forms.Button
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dv = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenuview = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenusearch = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuexport = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1.SuspendLayout()
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenu1.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.cmbbooknm)
        Me.Panel1.Controls.Add(Me.cmbauthnm)
        Me.Panel1.Controls.Add(Me.cmbpublication)
        Me.Panel1.Controls.Add(Me.cmbsub)
        Me.Panel1.Controls.Add(Me.cmbshelf)
        Me.Panel1.Controls.Add(Me.cmbcond)
        Me.Panel1.Controls.Add(Me.cmblock)
        Me.Panel1.Controls.Add(Me.txttotval)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.txttotqty)
        Me.Panel1.Controls.Add(Me.btnclr)
        Me.Panel1.Controls.Add(Me.dv1)
        Me.Panel1.Controls.Add(Me.txtshelfcd)
        Me.Panel1.Controls.Add(Me.txtpubcd)
        Me.Panel1.Controls.Add(Me.txtsubcd)
        Me.Panel1.Controls.Add(Me.txtauthcd)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtedition)
        Me.Panel1.Controls.Add(Me.btnnxt)
        Me.Panel1.Controls.Add(Me.txtcost)
        Me.Panel1.Controls.Add(Me.txtpage)
        Me.Panel1.Controls.Add(Me.txtyear)
        Me.Panel1.Controls.Add(Me.txtaccessno)
        Me.Panel1.Controls.Add(Me.txtsl)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtbarcd)
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
        Me.Panel1.Controls.Add(Me.txtnewnm)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtscrl)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(715, 486)
        Me.Panel1.TabIndex = 0
        '
        'cmbbooknm
        '
        Me.cmbbooknm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbbooknm.FormattingEnabled = True
        Me.cmbbooknm.ItemHeight = 13
        Me.cmbbooknm.Location = New System.Drawing.Point(157, 29)
        Me.cmbbooknm.Name = "cmbbooknm"
        Me.cmbbooknm.Size = New System.Drawing.Size(478, 21)
        Me.cmbbooknm.TabIndex = 0
        '
        'cmbauthnm
        '
        Me.cmbauthnm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbauthnm.FormattingEnabled = True
        Me.cmbauthnm.Location = New System.Drawing.Point(157, 95)
        Me.cmbauthnm.Name = "cmbauthnm"
        Me.cmbauthnm.Size = New System.Drawing.Size(478, 21)
        Me.cmbauthnm.TabIndex = 4
        '
        'cmbpublication
        '
        Me.cmbpublication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbpublication.FormattingEnabled = True
        Me.cmbpublication.Location = New System.Drawing.Point(157, 139)
        Me.cmbpublication.Name = "cmbpublication"
        Me.cmbpublication.Size = New System.Drawing.Size(478, 21)
        Me.cmbpublication.TabIndex = 6
        '
        'cmbsub
        '
        Me.cmbsub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbsub.FormattingEnabled = True
        Me.cmbsub.Location = New System.Drawing.Point(157, 161)
        Me.cmbsub.Name = "cmbsub"
        Me.cmbsub.Size = New System.Drawing.Size(175, 21)
        Me.cmbsub.TabIndex = 7
        '
        'cmbshelf
        '
        Me.cmbshelf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbshelf.FormattingEnabled = True
        Me.cmbshelf.Location = New System.Drawing.Point(460, 161)
        Me.cmbshelf.Name = "cmbshelf"
        Me.cmbshelf.Size = New System.Drawing.Size(175, 21)
        Me.cmbshelf.TabIndex = 8
        '
        'cmbcond
        '
        Me.cmbcond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcond.FormattingEnabled = True
        Me.cmbcond.Items.AddRange(New Object() {"1. Sound", "2.Semi Damage", "3. Damage"})
        Me.cmbcond.Location = New System.Drawing.Point(293, 231)
        Me.cmbcond.Name = "cmbcond"
        Me.cmbcond.Size = New System.Drawing.Size(85, 21)
        Me.cmbcond.TabIndex = 12
        '
        'cmblock
        '
        Me.cmblock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmblock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmblock.FormattingEnabled = True
        Me.cmblock.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmblock.Location = New System.Drawing.Point(557, 393)
        Me.cmblock.Name = "cmblock"
        Me.cmblock.Size = New System.Drawing.Size(72, 21)
        Me.cmblock.TabIndex = 19
        '
        'txttotval
        '
        Me.txttotval.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txttotval.Enabled = False
        Me.txttotval.Location = New System.Drawing.Point(338, 393)
        Me.txttotval.Name = "txttotval"
        Me.txttotval.Size = New System.Drawing.Size(71, 21)
        Me.txttotval.TabIndex = 1238
        Me.txttotval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(256, 396)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 13)
        Me.Label22.TabIndex = 1239
        Me.Label22.Text = "Total Cost :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(89, 396)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(91, 13)
        Me.Label20.TabIndex = 65
        Me.Label20.Text = "Total Books :"
        '
        'txttotqty
        '
        Me.txttotqty.BackColor = System.Drawing.Color.White
        Me.txttotqty.Enabled = False
        Me.txttotqty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotqty.Location = New System.Drawing.Point(180, 393)
        Me.txttotqty.MaxLength = 10
        Me.txttotqty.Name = "txttotqty"
        Me.txttotqty.Size = New System.Drawing.Size(71, 21)
        Me.txttotqty.TabIndex = 15
        Me.txttotqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnclr
        '
        Me.btnclr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclr.ForeColor = System.Drawing.Color.Red
        Me.btnclr.Location = New System.Drawing.Point(633, 254)
        Me.btnclr.Name = "btnclr"
        Me.btnclr.Size = New System.Drawing.Size(49, 21)
        Me.btnclr.TabIndex = 18
        Me.btnclr.Text = "&Clear"
        Me.btnclr.UseVisualStyleBackColor = True
        '
        'dv1
        '
        Me.dv1.AllowUserToAddRows = False
        Me.dv1.AllowUserToDeleteRows = False
        Me.dv1.AllowUserToResizeColumns = False
        Me.dv1.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.dv1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dv1.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dv1.ColumnHeadersVisible = False
        Me.dv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13})
        Me.dv1.ContextMenuStrip = Me.cmenu1
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dv1.DefaultCellStyle = DataGridViewCellStyle8
        Me.dv1.GridColor = System.Drawing.Color.Black
        Me.dv1.Location = New System.Drawing.Point(92, 254)
        Me.dv1.Name = "dv1"
        Me.dv1.ReadOnly = True
        Me.dv1.RowHeadersVisible = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Azure
        Me.dv1.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dv1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv1.RowTemplate.Height = 20
        Me.dv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv1.Size = New System.Drawing.Size(537, 136)
        Me.dv1.TabIndex = 64
        '
        'Column6
        '
        Me.Column6.HeaderText = "Sl"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 30
        '
        'Column7
        '
        Me.Column7.HeaderText = "book code"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 170
        '
        'Column8
        '
        Me.Column8.HeaderText = "conndition"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 85
        '
        'Column9
        '
        Me.Column9.HeaderText = "Edition"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 53
        '
        'Column10
        '
        Me.Column10.HeaderText = "year"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 53
        '
        'Column11
        '
        Me.Column11.HeaderText = "page"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 53
        '
        'Column12
        '
        Me.Column12.HeaderText = "cost"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 75
        '
        'Column13
        '
        Me.Column13.HeaderText = "qty"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Visible = False
        '
        'cmenu1
        '
        Me.cmenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnu1del})
        Me.cmenu1.Name = "ContextMenuStrip1"
        Me.cmenu1.Size = New System.Drawing.Size(108, 26)
        '
        'cmnu1del
        '
        Me.cmnu1del.Name = "cmnu1del"
        Me.cmnu1del.Size = New System.Drawing.Size(107, 22)
        Me.cmnu1del.Text = "Delete"
        '
        'txtshelfcd
        '
        Me.txtshelfcd.Location = New System.Drawing.Point(641, 166)
        Me.txtshelfcd.Name = "txtshelfcd"
        Me.txtshelfcd.Size = New System.Drawing.Size(23, 21)
        Me.txtshelfcd.TabIndex = 62
        Me.txtshelfcd.Visible = False
        '
        'txtpubcd
        '
        Me.txtpubcd.Location = New System.Drawing.Point(641, 139)
        Me.txtpubcd.Name = "txtpubcd"
        Me.txtpubcd.Size = New System.Drawing.Size(23, 21)
        Me.txtpubcd.TabIndex = 61
        Me.txtpubcd.Visible = False
        '
        'txtsubcd
        '
        Me.txtsubcd.Location = New System.Drawing.Point(336, 166)
        Me.txtsubcd.Name = "txtsubcd"
        Me.txtsubcd.Size = New System.Drawing.Size(23, 21)
        Me.txtsubcd.TabIndex = 60
        Me.txtsubcd.Visible = False
        '
        'txtauthcd
        '
        Me.txtauthcd.Location = New System.Drawing.Point(641, 98)
        Me.txtauthcd.Name = "txtauthcd"
        Me.txtauthcd.Size = New System.Drawing.Size(23, 21)
        Me.txtauthcd.TabIndex = 59
        Me.txtauthcd.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(565, 215)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 13)
        Me.Label19.TabIndex = 56
        Me.Label19.Text = "Cost"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(441, 215)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 13)
        Me.Label18.TabIndex = 55
        Me.Label18.Text = "Year"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(302, 215)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 13)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "Condition"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(494, 215)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 53
        Me.Label16.Text = "Page"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(174, 215)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 13)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "Book Code"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(380, 215)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "Edition"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(95, 215)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(23, 13)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "Sl."
        '
        'txtedition
        '
        Me.txtedition.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtedition.Location = New System.Drawing.Point(380, 232)
        Me.txtedition.MaxLength = 20
        Me.txtedition.Name = "txtedition"
        Me.txtedition.Size = New System.Drawing.Size(53, 21)
        Me.txtedition.TabIndex = 13
        '
        'btnnxt
        '
        Me.btnnxt.ForeColor = System.Drawing.Color.Red
        Me.btnnxt.Location = New System.Drawing.Point(633, 232)
        Me.btnnxt.Name = "btnnxt"
        Me.btnnxt.Size = New System.Drawing.Size(49, 21)
        Me.btnnxt.TabIndex = 17
        Me.btnnxt.Text = "Next"
        Me.btnnxt.UseVisualStyleBackColor = True
        '
        'txtcost
        '
        Me.txtcost.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcost.Location = New System.Drawing.Point(539, 232)
        Me.txtcost.MaxLength = 8
        Me.txtcost.Name = "txtcost"
        Me.txtcost.Size = New System.Drawing.Size(90, 21)
        Me.txtcost.TabIndex = 16
        Me.txtcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpage
        '
        Me.txtpage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpage.Location = New System.Drawing.Point(486, 232)
        Me.txtpage.Name = "txtpage"
        Me.txtpage.Size = New System.Drawing.Size(53, 21)
        Me.txtpage.TabIndex = 15
        '
        'txtyear
        '
        Me.txtyear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtyear.Location = New System.Drawing.Point(433, 232)
        Me.txtyear.MaxLength = 10
        Me.txtyear.Name = "txtyear"
        Me.txtyear.Size = New System.Drawing.Size(53, 21)
        Me.txtyear.TabIndex = 14
        Me.txtyear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtaccessno
        '
        Me.txtaccessno.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaccessno.Location = New System.Drawing.Point(122, 231)
        Me.txtaccessno.MaxLength = 20
        Me.txtaccessno.Name = "txtaccessno"
        Me.txtaccessno.Size = New System.Drawing.Size(170, 21)
        Me.txtaccessno.TabIndex = 11
        '
        'txtsl
        '
        Me.txtsl.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtsl.Enabled = False
        Me.txtsl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsl.Location = New System.Drawing.Point(92, 231)
        Me.txtsl.Name = "txtsl"
        Me.txtsl.ReadOnly = True
        Me.txtsl.Size = New System.Drawing.Size(29, 21)
        Me.txtsl.TabIndex = 42
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Red
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(-3, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(716, 2)
        Me.Label12.TabIndex = 41
        '
        'txtbarcd
        '
        Me.txtbarcd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbarcd.Location = New System.Drawing.Point(460, 183)
        Me.txtbarcd.MaxLength = 25
        Me.txtbarcd.Name = "txtbarcd"
        Me.txtbarcd.Size = New System.Drawing.Size(175, 21)
        Me.txtbarcd.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(386, 186)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Barcode :"
        '
        'txtisbn
        '
        Me.txtisbn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtisbn.Location = New System.Drawing.Point(157, 183)
        Me.txtisbn.MaxLength = 25
        Me.txtisbn.Name = "txtisbn"
        Me.txtisbn.Size = New System.Drawing.Size(175, 21)
        Me.txtisbn.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(84, 186)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "ISBN No :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(87, 164)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Subject :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(365, 164)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Shelf Name :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(64, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Publication :"
        '
        'txtothauth
        '
        Me.txtothauth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtothauth.Location = New System.Drawing.Point(157, 117)
        Me.txtothauth.MaxLength = 50
        Me.txtothauth.Name = "txtothauth"
        Me.txtothauth.Size = New System.Drawing.Size(478, 21)
        Me.txtothauth.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(52, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Other Author :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(51, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Author Name :"
        '
        'txtdetailnm
        '
        Me.txtdetailnm.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdetailnm.Location = New System.Drawing.Point(157, 73)
        Me.txtdetailnm.MaxLength = 200
        Me.txtdetailnm.Name = "txtdetailnm"
        Me.txtdetailnm.Size = New System.Drawing.Size(478, 21)
        Me.txtdetailnm.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(57, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Detail Name :"
        '
        'txtnewnm
        '
        Me.txtnewnm.BackColor = System.Drawing.Color.White
        Me.txtnewnm.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnewnm.Location = New System.Drawing.Point(157, 51)
        Me.txtnewnm.MaxLength = 50
        Me.txtnewnm.Name = "txtnewnm"
        Me.txtnewnm.ReadOnly = True
        Me.txtnewnm.Size = New System.Drawing.Size(478, 21)
        Me.txtnewnm.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(68, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "New Name :"
        '
        'txtscrl
        '
        Me.txtscrl.Location = New System.Drawing.Point(144, 5)
        Me.txtscrl.Name = "txtscrl"
        Me.txtscrl.Size = New System.Drawing.Size(36, 21)
        Me.txtscrl.TabIndex = 18
        Me.txtscrl.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnview)
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(4, 429)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(703, 50)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'btnview
        '
        Me.btnview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnview.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnview.Location = New System.Drawing.Point(197, 19)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(123, 23)
        Me.btnview.TabIndex = 2
        Me.btnview.Text = "&View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(382, 19)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(123, 23)
        Me.btnrefresh.TabIndex = 1
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(12, 19)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(123, 23)
        Me.btnexit.TabIndex = 3
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(567, 19)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(123, 23)
        Me.btnsave.TabIndex = 0
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(490, 396)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Locked :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(63, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Book Name :"
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
        Me.dv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
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
        Me.dv.Location = New System.Drawing.Point(12, 12)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(48, 35)
        Me.dv.TabIndex = 19
        '
        'Column1
        '
        Me.Column1.HeaderText = "Sl"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 44
        '
        'Column2
        '
        Me.Column2.HeaderText = "Book Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 97
        '
        'Column3
        '
        Me.Column3.HeaderText = "Author Name"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 107
        '
        'Column4
        '
        Me.Column4.HeaderText = "Publication Name"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 133
        '
        'Column5
        '
        Me.Column5.HeaderText = "book code"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        Me.Column5.Width = 91
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuadd, Me.cmnuedit, Me.cmenudel, Me.cmenuview, Me.cmnurefresh, Me.cmenusearch, Me.mnuexport})
        Me.cmenu.Name = "ContextMenuStrip1"
        Me.cmenu.Size = New System.Drawing.Size(117, 158)
        '
        'cmnuadd
        '
        Me.cmnuadd.Name = "cmnuadd"
        Me.cmnuadd.Size = New System.Drawing.Size(116, 22)
        Me.cmnuadd.Text = "Add."
        '
        'cmnuedit
        '
        Me.cmnuedit.Name = "cmnuedit"
        Me.cmnuedit.Size = New System.Drawing.Size(116, 22)
        Me.cmnuedit.Text = "Edit."
        '
        'cmenudel
        '
        Me.cmenudel.Name = "cmenudel"
        Me.cmenudel.Size = New System.Drawing.Size(116, 22)
        Me.cmenudel.Text = "Delete."
        '
        'cmenuview
        '
        Me.cmenuview.Name = "cmenuview"
        Me.cmenuview.Size = New System.Drawing.Size(116, 22)
        Me.cmenuview.Text = "View."
        '
        'cmnurefresh
        '
        Me.cmnurefresh.Name = "cmnurefresh"
        Me.cmnurefresh.Size = New System.Drawing.Size(116, 22)
        Me.cmnurefresh.Text = "Refresh."
        '
        'cmenusearch
        '
        Me.cmenusearch.Name = "cmenusearch"
        Me.cmenusearch.Size = New System.Drawing.Size(116, 22)
        Me.cmenusearch.Text = "Search."
        '
        'mnuexport
        '
        Me.mnuexport.Name = "mnuexport"
        Me.mnuexport.Size = New System.Drawing.Size(116, 22)
        Me.mnuexport.Text = "Export."
        '
        'frmbook
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(719, 491)
        Me.Controls.Add(Me.dv)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmbook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmbook"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu1.ResumeLayout(False)
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
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents txtscrl As System.Windows.Forms.TextBox
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtothauth As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtdetailnm As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnewnm As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtbarcd As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtisbn As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbsub As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbshelf As System.Windows.Forms.ComboBox
    Friend WithEvents txtaccessno As System.Windows.Forms.TextBox
    Friend WithEvents txtsl As System.Windows.Forms.TextBox
    Friend WithEvents txtedition As System.Windows.Forms.TextBox
    Friend WithEvents btnnxt As System.Windows.Forms.Button
    Friend WithEvents cmbcond As System.Windows.Forms.ComboBox
    Friend WithEvents txtcost As System.Windows.Forms.TextBox
    Friend WithEvents txtpage As System.Windows.Forms.TextBox
    Friend WithEvents txtyear As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbpublication As System.Windows.Forms.ComboBox
    Friend WithEvents cmbauthnm As System.Windows.Forms.ComboBox
    Friend WithEvents cmbbooknm As System.Windows.Forms.ComboBox
    Friend WithEvents txtshelfcd As System.Windows.Forms.TextBox
    Friend WithEvents txtpubcd As System.Windows.Forms.TextBox
    Friend WithEvents txtsubcd As System.Windows.Forms.TextBox
    Friend WithEvents txtauthcd As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnclr As System.Windows.Forms.Button
    Friend WithEvents dv1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txttotqty As System.Windows.Forms.TextBox
    Friend WithEvents txttotval As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmnu1del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenuview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuexport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenusearch As System.Windows.Forms.ToolStripMenuItem

End Class
