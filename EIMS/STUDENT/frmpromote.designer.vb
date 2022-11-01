<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpromote
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
        Me.txttype = New System.Windows.Forms.TextBox
        Me.lblcause = New System.Windows.Forms.Label
        Me.cmbsession = New System.Windows.Forms.ComboBox
        Me.cmbcurr = New System.Windows.Forms.ComboBox
        Me.cmbtrad = New System.Windows.Forms.ComboBox
        Me.cmbnew = New System.Windows.Forms.ComboBox
        Me.chkall = New System.Windows.Forms.CheckBox
        Me.txttradcd = New System.Windows.Forms.TextBox
        Me.chkpay = New System.Windows.Forms.CheckBox
        Me.chklibrary = New System.Windows.Forms.CheckBox
        Me.chkpenalty = New System.Windows.Forms.CheckBox
        Me.txtcause = New System.Windows.Forms.TextBox
        Me.dttr = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.chksel = New System.Windows.Forms.CheckBox
        Me.txtnewcd = New System.Windows.Forms.TextBox
        Me.txtsempos = New System.Windows.Forms.TextBox
        Me.txtsemcd = New System.Windows.Forms.TextBox
        Me.btnshow = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.chkcnfr = New System.Windows.Forms.CheckBox
        Me.lblnew = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dv = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtsesncd = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.txttype)
        Me.Panel1.Controls.Add(Me.lblcause)
        Me.Panel1.Controls.Add(Me.cmbsession)
        Me.Panel1.Controls.Add(Me.cmbcurr)
        Me.Panel1.Controls.Add(Me.cmbtrad)
        Me.Panel1.Controls.Add(Me.cmbnew)
        Me.Panel1.Controls.Add(Me.chkall)
        Me.Panel1.Controls.Add(Me.txttradcd)
        Me.Panel1.Controls.Add(Me.chkpay)
        Me.Panel1.Controls.Add(Me.chklibrary)
        Me.Panel1.Controls.Add(Me.chkpenalty)
        Me.Panel1.Controls.Add(Me.txtcause)
        Me.Panel1.Controls.Add(Me.dttr)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.chksel)
        Me.Panel1.Controls.Add(Me.txtnewcd)
        Me.Panel1.Controls.Add(Me.txtsempos)
        Me.Panel1.Controls.Add(Me.txtsemcd)
        Me.Panel1.Controls.Add(Me.btnshow)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.chkcnfr)
        Me.Panel1.Controls.Add(Me.lblnew)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dv)
        Me.Panel1.Controls.Add(Me.txtsesncd)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(731, 459)
        Me.Panel1.TabIndex = 234
        '
        'txttype
        '
        Me.txttype.Location = New System.Drawing.Point(389, 34)
        Me.txttype.Name = "txttype"
        Me.txttype.Size = New System.Drawing.Size(22, 21)
        Me.txttype.TabIndex = 71
        Me.txttype.Visible = False
        '
        'lblcause
        '
        Me.lblcause.AutoSize = True
        Me.lblcause.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcause.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblcause.Location = New System.Drawing.Point(2, 150)
        Me.lblcause.Name = "lblcause"
        Me.lblcause.Size = New System.Drawing.Size(115, 13)
        Me.lblcause.TabIndex = 70
        Me.lblcause.Text = "Cause Of Leave :"
        '
        'cmbsession
        '
        Me.cmbsession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbsession.FormattingEnabled = True
        Me.cmbsession.Location = New System.Drawing.Point(120, 34)
        Me.cmbsession.Name = "cmbsession"
        Me.cmbsession.Size = New System.Drawing.Size(189, 21)
        Me.cmbsession.TabIndex = 1
        '
        'cmbcurr
        '
        Me.cmbcurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbcurr.FormattingEnabled = True
        Me.cmbcurr.Location = New System.Drawing.Point(120, 57)
        Me.cmbcurr.Name = "cmbcurr"
        Me.cmbcurr.Size = New System.Drawing.Size(189, 21)
        Me.cmbcurr.TabIndex = 2
        '
        'cmbtrad
        '
        Me.cmbtrad.BackColor = System.Drawing.Color.White
        Me.cmbtrad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbtrad.FormattingEnabled = True
        Me.cmbtrad.Location = New System.Drawing.Point(120, 80)
        Me.cmbtrad.Name = "cmbtrad"
        Me.cmbtrad.Size = New System.Drawing.Size(135, 21)
        Me.cmbtrad.TabIndex = 3
        '
        'cmbnew
        '
        Me.cmbnew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbnew.FormattingEnabled = True
        Me.cmbnew.Location = New System.Drawing.Point(120, 137)
        Me.cmbnew.Name = "cmbnew"
        Me.cmbnew.Size = New System.Drawing.Size(189, 21)
        Me.cmbnew.TabIndex = 5
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.Checked = True
        Me.chkall.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkall.ForeColor = System.Drawing.Color.Red
        Me.chkall.Location = New System.Drawing.Point(263, 83)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(43, 17)
        Me.chkall.TabIndex = 3
        Me.chkall.Text = "All"
        Me.chkall.UseVisualStyleBackColor = True
        '
        'txttradcd
        '
        Me.txttradcd.Location = New System.Drawing.Point(4, 101)
        Me.txttradcd.Name = "txttradcd"
        Me.txttradcd.Size = New System.Drawing.Size(22, 21)
        Me.txttradcd.TabIndex = 68
        Me.txttradcd.Visible = False
        '
        'chkpay
        '
        Me.chkpay.AutoSize = True
        Me.chkpay.ForeColor = System.Drawing.Color.Red
        Me.chkpay.Location = New System.Drawing.Point(553, 10)
        Me.chkpay.Name = "chkpay"
        Me.chkpay.Size = New System.Drawing.Size(137, 17)
        Me.chkpay.TabIndex = 6
        Me.chkpay.Text = "Payment Cleared"
        Me.chkpay.UseVisualStyleBackColor = True
        '
        'chklibrary
        '
        Me.chklibrary.AutoSize = True
        Me.chklibrary.ForeColor = System.Drawing.Color.Red
        Me.chklibrary.Location = New System.Drawing.Point(553, 39)
        Me.chklibrary.Name = "chklibrary"
        Me.chklibrary.Size = New System.Drawing.Size(179, 17)
        Me.chklibrary.TabIndex = 7
        Me.chklibrary.Text = "Library Books Returned"
        Me.chklibrary.UseVisualStyleBackColor = True
        '
        'chkpenalty
        '
        Me.chkpenalty.AutoSize = True
        Me.chkpenalty.ForeColor = System.Drawing.Color.Red
        Me.chkpenalty.Location = New System.Drawing.Point(553, 68)
        Me.chkpenalty.Name = "chkpenalty"
        Me.chkpenalty.Size = New System.Drawing.Size(129, 17)
        Me.chkpenalty.TabIndex = 8
        Me.chkpenalty.Text = "Penalty Cleared"
        Me.chkpenalty.UseVisualStyleBackColor = True
        '
        'txtcause
        '
        Me.txtcause.BackColor = System.Drawing.Color.White
        Me.txtcause.Location = New System.Drawing.Point(334, 56)
        Me.txtcause.Multiline = True
        Me.txtcause.Name = "txtcause"
        Me.txtcause.Size = New System.Drawing.Size(189, 40)
        Me.txtcause.TabIndex = 6
        '
        'dttr
        '
        Me.dttr.CustomFormat = "dd/MM/yyyy"
        Me.dttr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttr.Location = New System.Drawing.Point(120, 10)
        Me.dttr.Name = "dttr"
        Me.dttr.Size = New System.Drawing.Size(118, 21)
        Me.dttr.TabIndex = 62
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(77, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Date :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(16, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Branch Name :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'chksel
        '
        Me.chksel.AutoSize = True
        Me.chksel.ForeColor = System.Drawing.Color.Red
        Me.chksel.Location = New System.Drawing.Point(553, 110)
        Me.chksel.Name = "chksel"
        Me.chksel.Size = New System.Drawing.Size(141, 17)
        Me.chksel.TabIndex = 10
        Me.chksel.Text = "Select All Student"
        Me.chksel.UseVisualStyleBackColor = True
        '
        'txtnewcd
        '
        Me.txtnewcd.Location = New System.Drawing.Point(2, 45)
        Me.txtnewcd.Name = "txtnewcd"
        Me.txtnewcd.Size = New System.Drawing.Size(22, 21)
        Me.txtnewcd.TabIndex = 53
        Me.txtnewcd.Visible = False
        '
        'txtsempos
        '
        Me.txtsempos.Location = New System.Drawing.Point(2, 25)
        Me.txtsempos.Name = "txtsempos"
        Me.txtsempos.Size = New System.Drawing.Size(22, 21)
        Me.txtsempos.TabIndex = 52
        Me.txtsempos.Visible = False
        '
        'txtsemcd
        '
        Me.txtsemcd.Location = New System.Drawing.Point(25, 3)
        Me.txtsemcd.Name = "txtsemcd"
        Me.txtsemcd.Size = New System.Drawing.Size(22, 21)
        Me.txtsemcd.TabIndex = 51
        Me.txtsemcd.Visible = False
        '
        'btnshow
        '
        Me.btnshow.Location = New System.Drawing.Point(120, 106)
        Me.btnshow.Name = "btnshow"
        Me.btnshow.Size = New System.Drawing.Size(189, 23)
        Me.btnshow.TabIndex = 4
        Me.btnshow.Text = "&Show List"
        Me.btnshow.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(318, 130)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 45)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(167, 15)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 12
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(6, 15)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(75, 23)
        Me.btnexit.TabIndex = 13
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(327, 15)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 11
        Me.btnsave.Text = "&Promote"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'chkcnfr
        '
        Me.chkcnfr.AutoSize = True
        Me.chkcnfr.ForeColor = System.Drawing.Color.Red
        Me.chkcnfr.Location = New System.Drawing.Point(324, 111)
        Me.chkcnfr.Name = "chkcnfr"
        Me.chkcnfr.Size = New System.Drawing.Size(199, 17)
        Me.chkcnfr.TabIndex = 9
        Me.chkcnfr.Text = "Confirm Message Required"
        Me.chkcnfr.UseVisualStyleBackColor = True
        '
        'lblnew
        '
        Me.lblnew.AutoSize = True
        Me.lblnew.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnew.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblnew.Location = New System.Drawing.Point(37, 137)
        Me.lblnew.Name = "lblnew"
        Me.lblnew.Size = New System.Drawing.Size(80, 13)
        Me.lblnew.TabIndex = 43
        Me.lblnew.Text = "New Class :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(32, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Curr. Class :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(52, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Session :"
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
        Me.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column7})
        Me.dv.GridColor = System.Drawing.Color.Black
        Me.dv.Location = New System.Drawing.Point(2, 181)
        Me.dv.Name = "dv"
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Azure
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(725, 274)
        Me.dv.TabIndex = 37
        '
        'Column1
        '
        Me.Column1.FalseValue = "0"
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column1.TrueValue = "1"
        Me.Column1.Width = 44
        '
        'Column2
        '
        Me.Column2.HeaderText = "Regd No."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 89
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Student Name"
        Me.Column3.Name = "Column3"
        '
        'Column7
        '
        Me.Column7.HeaderText = "studsl"
        Me.Column7.Name = "Column7"
        Me.Column7.Visible = False
        Me.Column7.Width = 88
        '
        'txtsesncd
        '
        Me.txtsesncd.Location = New System.Drawing.Point(2, 3)
        Me.txtsesncd.Name = "txtsesncd"
        Me.txtsesncd.Size = New System.Drawing.Size(22, 21)
        Me.txtsesncd.TabIndex = 50
        Me.txtsesncd.Visible = False
        '
        'frmpromote
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(736, 465)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmpromote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmpromo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents cmbnew As System.Windows.Forms.ComboBox
    Friend WithEvents cmbcurr As System.Windows.Forms.ComboBox
    Friend WithEvents cmbsession As System.Windows.Forms.ComboBox
    Friend WithEvents lblnew As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkcnfr As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnshow As System.Windows.Forms.Button
    Friend WithEvents txtnewcd As System.Windows.Forms.TextBox
    Friend WithEvents txtsempos As System.Windows.Forms.TextBox
    Friend WithEvents txtsemcd As System.Windows.Forms.TextBox
    Friend WithEvents txtsesncd As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chksel As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbtrad As System.Windows.Forms.ComboBox
    Friend WithEvents dttr As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcause As System.Windows.Forms.TextBox
    Friend WithEvents chkpay As System.Windows.Forms.CheckBox
    Friend WithEvents chklibrary As System.Windows.Forms.CheckBox
    Friend WithEvents chkpenalty As System.Windows.Forms.CheckBox
    Friend WithEvents txttradcd As System.Windows.Forms.TextBox
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents lblcause As System.Windows.Forms.Label
    Friend WithEvents txttype As System.Windows.Forms.TextBox

End Class
