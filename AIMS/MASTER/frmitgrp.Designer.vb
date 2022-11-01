<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmitgrp
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
        Me.dv = New System.Windows.Forms.DataGridView
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnview = New System.Windows.Forms.Button
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.cmblock = New System.Windows.Forms.ComboBox
        Me.txtgrplong = New System.Windows.Forms.TextBox
        Me.txtgrpshort = New System.Windows.Forms.TextBox
        Me.txtscrl = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmenuexpert = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1.SuspendLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenu.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.cmblock)
        Me.Panel1.Controls.Add(Me.txtgrplong)
        Me.Panel1.Controls.Add(Me.txtgrpshort)
        Me.Panel1.Controls.Add(Me.txtscrl)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(555, 407)
        Me.Panel1.TabIndex = 0
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
        Me.dv.Location = New System.Drawing.Point(393, 28)
        Me.dv.Name = "dv"
        Me.dv.ReadOnly = True
        Me.dv.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan
        Me.dv.RowTemplate.Height = 20
        Me.dv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dv.Size = New System.Drawing.Size(33, 35)
        Me.dv.TabIndex = 78
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuadd, Me.cmnuedit, Me.cmenudel, Me.cmnurefresh, Me.cmenuexpert})
        Me.cmenu.Name = "ContextMenuStrip1"
        Me.cmenu.Size = New System.Drawing.Size(117, 114)
        '
        'cmnuadd
        '
        Me.cmnuadd.Name = "cmnuadd"
        Me.cmnuadd.Size = New System.Drawing.Size(116, 22)
        Me.cmnuadd.Text = "Add"
        '
        'cmnuedit
        '
        Me.cmnuedit.Name = "cmnuedit"
        Me.cmnuedit.Size = New System.Drawing.Size(116, 22)
        Me.cmnuedit.Text = "Edit"
        '
        'cmenudel
        '
        Me.cmenudel.Name = "cmenudel"
        Me.cmenudel.Size = New System.Drawing.Size(116, 22)
        Me.cmenudel.Text = "Delete"
        '
        'cmnurefresh
        '
        Me.cmnurefresh.Name = "cmnurefresh"
        Me.cmnurefresh.Size = New System.Drawing.Size(116, 22)
        Me.cmnurefresh.Text = "Refresh."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(60, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Group Name(Long) :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(329, 225)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Locked :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(44, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "* Group Name(Short) :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnview)
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(3, 353)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(547, 49)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'btnview
        '
        Me.btnview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnview.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnview.Location = New System.Drawing.Point(159, 20)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(75, 23)
        Me.btnview.TabIndex = 5
        Me.btnview.Text = "&View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(312, 20)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 4
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(6, 20)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(75, 23)
        Me.btnexit.TabIndex = 6
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(465, 20)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 3
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'cmblock
        '
        Me.cmblock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmblock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmblock.FormattingEnabled = True
        Me.cmblock.Items.AddRange(New Object() {"No", "Yes"})
        Me.cmblock.Location = New System.Drawing.Point(391, 222)
        Me.cmblock.Name = "cmblock"
        Me.cmblock.Size = New System.Drawing.Size(72, 21)
        Me.cmblock.TabIndex = 2
        '
        'txtgrplong
        '
        Me.txtgrplong.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgrplong.Location = New System.Drawing.Point(198, 199)
        Me.txtgrplong.MaxLength = 50
        Me.txtgrplong.Name = "txtgrplong"
        Me.txtgrplong.Size = New System.Drawing.Size(265, 21)
        Me.txtgrplong.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtgrplong, "hggghhvh")
        '
        'txtgrpshort
        '
        Me.txtgrpshort.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgrpshort.Location = New System.Drawing.Point(198, 176)
        Me.txtgrpshort.MaxLength = 50
        Me.txtgrpshort.Name = "txtgrpshort"
        Me.txtgrpshort.Size = New System.Drawing.Size(265, 21)
        Me.txtgrpshort.TabIndex = 0
        Me.txtgrpshort.Tag = ""
        '
        'txtscrl
        '
        Me.txtscrl.Location = New System.Drawing.Point(279, 50)
        Me.txtscrl.Name = "txtscrl"
        Me.txtscrl.Size = New System.Drawing.Size(36, 21)
        Me.txtscrl.TabIndex = 18
        Me.txtscrl.Visible = False
        '
        'cmenuexpert
        '
        Me.cmenuexpert.Name = "cmenuexpert"
        Me.cmenuexpert.Size = New System.Drawing.Size(116, 22)
        Me.cmenuexpert.Text = "Expert"
        '
        'frmitgrp
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(557, 409)
        Me.Controls.Add(Me.dv)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmitgrp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmitgrp"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtgrpshort As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmblock As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents txtscrl As System.Windows.Forms.TextBox
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents txtgrplong As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dv As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmenuexpert As System.Windows.Forms.ToolStripMenuItem

End Class
