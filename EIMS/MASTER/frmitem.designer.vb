<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmitem
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
        Me.cmbvat = New System.Windows.Forms.ComboBox
        Me.cmbunt2 = New System.Windows.Forms.ComboBox
        Me.txtclstk = New System.Windows.Forms.TextBox
        Me.cmbgrp = New System.Windows.Forms.ComboBox
        Me.cmbunt1 = New System.Windows.Forms.ComboBox
        Me.cmbgodwn = New System.Windows.Forms.ComboBox
        Me.txtvatcd = New System.Windows.Forms.TextBox
        Me.txtuntcd1 = New System.Windows.Forms.TextBox
        Me.txtuntcd2 = New System.Windows.Forms.TextBox
        Me.txtgdncd = New System.Windows.Forms.TextBox
        Me.txtgrpcd = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnview = New System.Windows.Forms.Button
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmblock = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtopstk = New System.Windows.Forms.TextBox
        Me.txtpurrt = New System.Windows.Forms.TextBox
        Me.txtmrp = New System.Windows.Forms.TextBox
        Me.txtmulti = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtdescri = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtscrl = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtitemnm = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dv = New System.Windows.Forms.DataGridView
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenuview = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuexport = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenusearch = New System.Windows.Forms.ToolStripMenuItem
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
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
        Me.Panel1.Controls.Add(Me.cmbvat)
        Me.Panel1.Controls.Add(Me.cmbunt2)
        Me.Panel1.Controls.Add(Me.txtclstk)
        Me.Panel1.Controls.Add(Me.cmbgrp)
        Me.Panel1.Controls.Add(Me.cmbunt1)
        Me.Panel1.Controls.Add(Me.cmbgodwn)
        Me.Panel1.Controls.Add(Me.txtvatcd)
        Me.Panel1.Controls.Add(Me.txtuntcd1)
        Me.Panel1.Controls.Add(Me.txtuntcd2)
        Me.Panel1.Controls.Add(Me.txtgdncd)
        Me.Panel1.Controls.Add(Me.txtgrpcd)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.cmblock)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtopstk)
        Me.Panel1.Controls.Add(Me.txtpurrt)
        Me.Panel1.Controls.Add(Me.txtmrp)
        Me.Panel1.Controls.Add(Me.txtmulti)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtdescri)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtscrl)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtitemnm)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel1.Size = New System.Drawing.Size(598, 427)
        Me.Panel1.TabIndex = 0
        '
        'cmbvat
        '
        Me.cmbvat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbvat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbvat.FormattingEnabled = True
        Me.cmbvat.Location = New System.Drawing.Point(433, 146)
        Me.cmbvat.Name = "cmbvat"
        Me.cmbvat.Size = New System.Drawing.Size(133, 21)
        Me.cmbvat.TabIndex = 3
        '
        'cmbunt2
        '
        Me.cmbunt2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbunt2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbunt2.FormattingEnabled = True
        Me.cmbunt2.Location = New System.Drawing.Point(477, 169)
        Me.cmbunt2.Name = "cmbunt2"
        Me.cmbunt2.Size = New System.Drawing.Size(90, 21)
        Me.cmbunt2.TabIndex = 6
        '
        'txtclstk
        '
        Me.txtclstk.Enabled = False
        Me.txtclstk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclstk.Location = New System.Drawing.Point(496, 215)
        Me.txtclstk.MaxLength = 9
        Me.txtclstk.Name = "txtclstk"
        Me.txtclstk.Size = New System.Drawing.Size(70, 21)
        Me.txtclstk.TabIndex = 73
        '
        'cmbgrp
        '
        Me.cmbgrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbgrp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbgrp.FormattingEnabled = True
        Me.cmbgrp.Location = New System.Drawing.Point(151, 146)
        Me.cmbgrp.Name = "cmbgrp"
        Me.cmbgrp.Size = New System.Drawing.Size(144, 21)
        Me.cmbgrp.TabIndex = 2
        '
        'cmbunt1
        '
        Me.cmbunt1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbunt1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbunt1.FormattingEnabled = True
        Me.cmbunt1.Location = New System.Drawing.Point(151, 169)
        Me.cmbunt1.Name = "cmbunt1"
        Me.cmbunt1.Size = New System.Drawing.Size(90, 21)
        Me.cmbunt1.TabIndex = 4
        '
        'cmbgodwn
        '
        Me.cmbgodwn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbgodwn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbgodwn.FormattingEnabled = True
        Me.cmbgodwn.Location = New System.Drawing.Point(150, 215)
        Me.cmbgodwn.Name = "cmbgodwn"
        Me.cmbgodwn.Size = New System.Drawing.Size(144, 21)
        Me.cmbgodwn.TabIndex = 9
        '
        'txtvatcd
        '
        Me.txtvatcd.Location = New System.Drawing.Point(66, 302)
        Me.txtvatcd.Name = "txtvatcd"
        Me.txtvatcd.Size = New System.Drawing.Size(23, 21)
        Me.txtvatcd.TabIndex = 72
        Me.txtvatcd.Visible = False
        '
        'txtuntcd1
        '
        Me.txtuntcd1.Location = New System.Drawing.Point(95, 302)
        Me.txtuntcd1.Name = "txtuntcd1"
        Me.txtuntcd1.Size = New System.Drawing.Size(23, 21)
        Me.txtuntcd1.TabIndex = 71
        Me.txtuntcd1.Visible = False
        '
        'txtuntcd2
        '
        Me.txtuntcd2.Location = New System.Drawing.Point(124, 302)
        Me.txtuntcd2.Name = "txtuntcd2"
        Me.txtuntcd2.Size = New System.Drawing.Size(23, 21)
        Me.txtuntcd2.TabIndex = 70
        Me.txtuntcd2.Visible = False
        '
        'txtgdncd
        '
        Me.txtgdncd.Location = New System.Drawing.Point(153, 302)
        Me.txtgdncd.Name = "txtgdncd"
        Me.txtgdncd.Size = New System.Drawing.Size(23, 21)
        Me.txtgdncd.TabIndex = 69
        Me.txtgdncd.Visible = False
        '
        'txtgrpcd
        '
        Me.txtgrpcd.Location = New System.Drawing.Point(37, 302)
        Me.txtgrpcd.Name = "txtgrpcd"
        Me.txtgrpcd.Size = New System.Drawing.Size(23, 21)
        Me.txtgrpcd.TabIndex = 68
        Me.txtgrpcd.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnview)
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(4, 369)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(589, 49)
        Me.GroupBox1.TabIndex = 64
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'btnview
        '
        Me.btnview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnview.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnview.Location = New System.Drawing.Point(173, 16)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(75, 23)
        Me.btnview.TabIndex = 3
        Me.btnview.Text = "&View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(340, 16)
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
        Me.btnexit.Location = New System.Drawing.Point(6, 16)
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
        Me.btnsave.Location = New System.Drawing.Point(507, 16)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 0
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(174, 343)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(250, 13)
        Me.Label19.TabIndex = 63
        Me.Label19.Text = "Star(*) Marked Field Are Compulsory"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(568, 149)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(15, 13)
        Me.Label17.TabIndex = 61
        Me.Label17.Text = "*"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(297, 150)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 13)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = "*"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(567, 98)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 13)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "*"
        '
        'cmblock
        '
        Me.cmblock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmblock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmblock.FormattingEnabled = True
        Me.cmblock.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmblock.Location = New System.Drawing.Point(150, 239)
        Me.cmblock.Name = "cmblock"
        Me.cmblock.Size = New System.Drawing.Size(75, 21)
        Me.cmblock.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(87, 242)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Locked :"
        '
        'txtopstk
        '
        Me.txtopstk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopstk.Location = New System.Drawing.Point(420, 215)
        Me.txtopstk.MaxLength = 9
        Me.txtopstk.Name = "txtopstk"
        Me.txtopstk.Size = New System.Drawing.Size(75, 21)
        Me.txtopstk.TabIndex = 10
        '
        'txtpurrt
        '
        Me.txtpurrt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpurrt.Location = New System.Drawing.Point(420, 192)
        Me.txtpurrt.MaxLength = 8
        Me.txtpurrt.Name = "txtpurrt"
        Me.txtpurrt.Size = New System.Drawing.Size(146, 21)
        Me.txtpurrt.TabIndex = 8
        '
        'txtmrp
        '
        Me.txtmrp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmrp.Location = New System.Drawing.Point(150, 192)
        Me.txtmrp.MaxLength = 8
        Me.txtmrp.Name = "txtmrp"
        Me.txtmrp.Size = New System.Drawing.Size(144, 21)
        Me.txtmrp.TabIndex = 7
        '
        'txtmulti
        '
        Me.txtmulti.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmulti.Location = New System.Drawing.Point(314, 169)
        Me.txtmulti.Name = "txtmulti"
        Me.txtmulti.Size = New System.Drawing.Size(48, 21)
        Me.txtmulti.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(308, 217)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Opening Stock :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(45, 217)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 13)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Storage Point :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(308, 196)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Purchase Rate :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(99, 194)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "M.R.P :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(362, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Secondary Unit :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(245, 173)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Multiple :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(52, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Primary Unit :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(333, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Vat Category :"
        '
        'txtdescri
        '
        Me.txtdescri.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescri.Location = New System.Drawing.Point(151, 123)
        Me.txtdescri.MaxLength = 50
        Me.txtdescri.Name = "txtdescri"
        Me.txtdescri.Size = New System.Drawing.Size(416, 21)
        Me.txtdescri.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Product Description :"
        '
        'txtscrl
        '
        Me.txtscrl.Location = New System.Drawing.Point(151, 20)
        Me.txtscrl.Name = "txtscrl"
        Me.txtscrl.Size = New System.Drawing.Size(36, 21)
        Me.txtscrl.TabIndex = 18
        Me.txtscrl.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(95, 150)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Group :"
        '
        'txtitemnm
        '
        Me.txtitemnm.BackColor = System.Drawing.Color.White
        Me.txtitemnm.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtitemnm.Location = New System.Drawing.Point(151, 100)
        Me.txtitemnm.MaxLength = 30
        Me.txtitemnm.Name = "txtitemnm"
        Me.txtitemnm.Size = New System.Drawing.Size(415, 21)
        Me.txtitemnm.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(43, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Product Name :"
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
        Me.dv.Location = New System.Drawing.Point(266, 7)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(33, 35)
        Me.dv.TabIndex = 74
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuadd, Me.cmnuedit, Me.cmenudel, Me.cmenuview, Me.cmnurefresh, Me.cmenusearch, Me.mnuexport})
        Me.cmenu.Name = "ContextMenuStrip1"
        Me.cmenu.Size = New System.Drawing.Size(153, 180)
        '
        'cmnuadd
        '
        Me.cmnuadd.Name = "cmnuadd"
        Me.cmnuadd.Size = New System.Drawing.Size(152, 22)
        Me.cmnuadd.Text = "Add."
        '
        'cmnuedit
        '
        Me.cmnuedit.Name = "cmnuedit"
        Me.cmnuedit.Size = New System.Drawing.Size(152, 22)
        Me.cmnuedit.Text = "Edit."
        '
        'cmenudel
        '
        Me.cmenudel.Name = "cmenudel"
        Me.cmenudel.Size = New System.Drawing.Size(152, 22)
        Me.cmenudel.Text = "Delete."
        '
        'cmnurefresh
        '
        Me.cmnurefresh.Name = "cmnurefresh"
        Me.cmnurefresh.Size = New System.Drawing.Size(152, 22)
        Me.cmnurefresh.Text = "Refresh."
        '
        'cmenuview
        '
        Me.cmenuview.Name = "cmenuview"
        Me.cmenuview.Size = New System.Drawing.Size(152, 22)
        Me.cmenuview.Text = "View."
        '
        'mnuexport
        '
        Me.mnuexport.Name = "mnuexport"
        Me.mnuexport.Size = New System.Drawing.Size(152, 22)
        Me.mnuexport.Text = "Export."
        '
        'cmenusearch
        '
        Me.cmenusearch.Name = "cmenusearch"
        Me.cmenusearch.Size = New System.Drawing.Size(152, 22)
        Me.cmenusearch.Text = "Search."
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'frmitem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(604, 433)
        Me.Controls.Add(Me.dv)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmitem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmitem"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtitemnm As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtscrl As System.Windows.Forms.TextBox
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtdescri As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtpurrt As System.Windows.Forms.TextBox
    Friend WithEvents txtmrp As System.Windows.Forms.TextBox
    Friend WithEvents txtmulti As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmblock As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtopstk As System.Windows.Forms.TextBox
    Friend WithEvents cmbvat As System.Windows.Forms.ComboBox
    Friend WithEvents cmbgrp As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents cmbgodwn As System.Windows.Forms.ComboBox
    Friend WithEvents cmbunt2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbunt1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtvatcd As System.Windows.Forms.TextBox
    Friend WithEvents txtuntcd1 As System.Windows.Forms.TextBox
    Friend WithEvents txtuntcd2 As System.Windows.Forms.TextBox
    Friend WithEvents txtgdncd As System.Windows.Forms.TextBox
    Friend WithEvents txtgrpcd As System.Windows.Forms.TextBox
    Friend WithEvents txtclstk As System.Windows.Forms.TextBox
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents cmenuview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuexport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenusearch As System.Windows.Forms.ToolStripMenuItem

End Class
