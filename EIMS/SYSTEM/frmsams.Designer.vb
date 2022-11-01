<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsams
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmsams))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblinstruct = New System.Windows.Forms.Label
        Me.dv = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbsessn = New System.Windows.Forms.ComboBox
        Me.cmbacdmyr = New System.Windows.Forms.ComboBox
        Me.cmbstrm = New System.Windows.Forms.ComboBox
        Me.cmbunversity = New System.Windows.Forms.ComboBox
        Me.txtunvcd = New System.Windows.Forms.TextBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.txtstrmcd = New System.Windows.Forms.TextBox
        Me.txtacdncd = New System.Windows.Forms.TextBox
        Me.txtsesncd = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnsave = New System.Windows.Forms.Button
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnimport = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(710, 424)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lblinstruct)
        Me.GroupBox2.Controls.Add(Me.dv)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Red
        Me.GroupBox2.Location = New System.Drawing.Point(165, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(540, 415)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data"
        '
        'lblinstruct
        '
        Me.lblinstruct.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinstruct.ForeColor = System.Drawing.Color.Blue
        Me.lblinstruct.Location = New System.Drawing.Point(6, 22)
        Me.lblinstruct.Name = "lblinstruct"
        Me.lblinstruct.Size = New System.Drawing.Size(114, 13)
        Me.lblinstruct.TabIndex = 35
        Me.lblinstruct.Text = resources.GetString("lblinstruct.Text")
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
        Me.dv.Size = New System.Drawing.Size(534, 395)
        Me.dv.TabIndex = 19
        Me.dv.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmbsessn)
        Me.GroupBox1.Controls.Add(Me.cmbacdmyr)
        Me.GroupBox1.Controls.Add(Me.cmbstrm)
        Me.GroupBox1.Controls.Add(Me.cmbunversity)
        Me.GroupBox1.Controls.Add(Me.txtunvcd)
        Me.GroupBox1.Controls.Add(Me.Label47)
        Me.GroupBox1.Controls.Add(Me.txtstrmcd)
        Me.GroupBox1.Controls.Add(Me.txtacdncd)
        Me.GroupBox1.Controls.Add(Me.txtsesncd)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnimport)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(157, 414)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'cmbsessn
        '
        Me.cmbsessn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbsessn.FormattingEnabled = True
        Me.cmbsessn.Location = New System.Drawing.Point(6, 93)
        Me.cmbsessn.Name = "cmbsessn"
        Me.cmbsessn.Size = New System.Drawing.Size(146, 21)
        Me.cmbsessn.TabIndex = 3
        '
        'cmbacdmyr
        '
        Me.cmbacdmyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbacdmyr.FormattingEnabled = True
        Me.cmbacdmyr.Location = New System.Drawing.Point(6, 133)
        Me.cmbacdmyr.Name = "cmbacdmyr"
        Me.cmbacdmyr.Size = New System.Drawing.Size(146, 21)
        Me.cmbacdmyr.TabIndex = 4
        '
        'cmbstrm
        '
        Me.cmbstrm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbstrm.FormattingEnabled = True
        Me.cmbstrm.Location = New System.Drawing.Point(6, 173)
        Me.cmbstrm.Name = "cmbstrm"
        Me.cmbstrm.Size = New System.Drawing.Size(146, 21)
        Me.cmbstrm.TabIndex = 5
        '
        'cmbunversity
        '
        Me.cmbunversity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbunversity.FormattingEnabled = True
        Me.cmbunversity.Location = New System.Drawing.Point(6, 214)
        Me.cmbunversity.Name = "cmbunversity"
        Me.cmbunversity.Size = New System.Drawing.Size(145, 21)
        Me.cmbunversity.TabIndex = 6
        '
        'txtunvcd
        '
        Me.txtunvcd.Location = New System.Drawing.Point(128, 194)
        Me.txtunvcd.Name = "txtunvcd"
        Me.txtunvcd.Size = New System.Drawing.Size(20, 21)
        Me.txtunvcd.TabIndex = 75
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label47.Location = New System.Drawing.Point(8, 197)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(131, 13)
        Me.Label47.TabIndex = 73
        Me.Label47.Text = "*University Name :"
        '
        'txtstrmcd
        '
        Me.txtstrmcd.Location = New System.Drawing.Point(128, 154)
        Me.txtstrmcd.Name = "txtstrmcd"
        Me.txtstrmcd.Size = New System.Drawing.Size(20, 21)
        Me.txtstrmcd.TabIndex = 41
        '
        'txtacdncd
        '
        Me.txtacdncd.Location = New System.Drawing.Point(128, 114)
        Me.txtacdncd.Name = "txtacdncd"
        Me.txtacdncd.Size = New System.Drawing.Size(20, 21)
        Me.txtacdncd.TabIndex = 40
        '
        'txtsesncd
        '
        Me.txtsesncd.Location = New System.Drawing.Point(128, 71)
        Me.txtsesncd.Name = "txtsesncd"
        Me.txtsesncd.Size = New System.Drawing.Size(20, 21)
        Me.txtsesncd.TabIndex = 39
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(8, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "*Branch Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(8, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "*Class Name :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(8, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "*Session Name :"
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(6, 239)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(146, 23)
        Me.btnsave.TabIndex = 3
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(6, 45)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(146, 23)
        Me.btnrefresh.TabIndex = 2
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(6, 264)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(146, 23)
        Me.btnexit.TabIndex = 1
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnimport
        '
        Me.btnimport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnimport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnimport.Location = New System.Drawing.Point(6, 20)
        Me.btnimport.Name = "btnimport"
        Me.btnimport.Size = New System.Drawing.Size(146, 23)
        Me.btnimport.TabIndex = 0
        Me.btnimport.Text = "&Import From Excel"
        Me.btnimport.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmsams
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(719, 432)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmsams"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmdept"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnimport As System.Windows.Forms.Button
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbsessn As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbacdmyr As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbstrm As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtstrmcd As System.Windows.Forms.TextBox
    Friend WithEvents txtacdncd As System.Windows.Forms.TextBox
    Friend WithEvents txtsesncd As System.Windows.Forms.TextBox
    Friend WithEvents lblinstruct As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents cmbunversity As System.Windows.Forms.ComboBox
    Friend WithEvents txtunvcd As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
