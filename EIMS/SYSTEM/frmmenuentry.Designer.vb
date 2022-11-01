<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmmenuentry
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnview = New System.Windows.Forms.Button
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsend = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btngen = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtgenerate = New System.Windows.Forms.TextBox
        Me.cmbmnutp = New System.Windows.Forms.ComboBox
        Me.cmbtablvl = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkmnutp = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtmnusl = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtmnutext = New System.Windows.Forms.TextBox
        Me.txtmenunm = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnview)
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsend)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(7, 299)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(501, 49)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'btnview
        '
        Me.btnview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnview.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnview.ForeColor = System.Drawing.Color.Black
        Me.btnview.Location = New System.Drawing.Point(144, 18)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(75, 23)
        Me.btnview.TabIndex = 4
        Me.btnview.Text = "&View"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.ForeColor = System.Drawing.Color.Black
        Me.btnrefresh.Location = New System.Drawing.Point(282, 18)
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
        Me.btnexit.ForeColor = System.Drawing.Color.Black
        Me.btnexit.Location = New System.Drawing.Point(6, 18)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(75, 23)
        Me.btnexit.TabIndex = 1
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnsend
        '
        Me.btnsend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsend.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsend.ForeColor = System.Drawing.Color.Black
        Me.btnsend.Location = New System.Drawing.Point(420, 18)
        Me.btnsend.Name = "btnsend"
        Me.btnsend.Size = New System.Drawing.Size(75, 23)
        Me.btnsend.TabIndex = 0
        Me.btnsend.Text = "&Send"
        Me.btnsend.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightCyan
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btngen)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtgenerate)
        Me.Panel1.Controls.Add(Me.cmbmnutp)
        Me.Panel1.Controls.Add(Me.cmbtablvl)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.chkmnutp)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtmnusl)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtmnutext)
        Me.Panel1.Controls.Add(Me.txtmenunm)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(516, 356)
        Me.Panel1.TabIndex = 0
        '
        'btngen
        '
        Me.btngen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btngen.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btngen.ForeColor = System.Drawing.Color.Black
        Me.btngen.Location = New System.Drawing.Point(270, 91)
        Me.btngen.Name = "btngen"
        Me.btngen.Size = New System.Drawing.Size(81, 23)
        Me.btngen.TabIndex = 5
        Me.btngen.Text = "&Generate"
        Me.btngen.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Genarated Query :"
        '
        'txtgenerate
        '
        Me.txtgenerate.Location = New System.Drawing.Point(142, 117)
        Me.txtgenerate.Multiline = True
        Me.txtgenerate.Name = "txtgenerate"
        Me.txtgenerate.Size = New System.Drawing.Size(366, 115)
        Me.txtgenerate.TabIndex = 28
        '
        'cmbmnutp
        '
        Me.cmbmnutp.FormattingEnabled = True
        Me.cmbmnutp.Items.AddRange(New Object() {"Config", "Xsecurity", "Master", "Student", "Accounts", "Inventory", "Examination", "Library", "Reports", "Utilities"})
        Me.cmbmnutp.Location = New System.Drawing.Point(190, 21)
        Me.cmbmnutp.Name = "cmbmnutp"
        Me.cmbmnutp.Size = New System.Drawing.Size(161, 21)
        Me.cmbmnutp.TabIndex = 27
        '
        'cmbtablvl
        '
        Me.cmbtablvl.FormattingEnabled = True
        Me.cmbtablvl.Items.AddRange(New Object() {"01.Config", "02.Security", "03.Master", "04.Student", "05.Accounts", "06.Inventory", "07.Examination", "08.Library", "09.Reports", "10.Utilities"})
        Me.cmbtablvl.Location = New System.Drawing.Point(142, 93)
        Me.cmbtablvl.Name = "cmbtablvl"
        Me.cmbtablvl.Size = New System.Drawing.Size(122, 21)
        Me.cmbtablvl.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(61, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Tab Lavel :"
        '
        'chkmnutp
        '
        Me.chkmnutp.AutoSize = True
        Me.chkmnutp.Location = New System.Drawing.Point(357, 74)
        Me.chkmnutp.Name = "chkmnutp"
        Me.chkmnutp.Size = New System.Drawing.Size(88, 17)
        Me.chkmnutp.TabIndex = 24
        Me.chkmnutp.Text = "Sub Menu"
        Me.chkmnutp.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(71, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Menu Sl :"
        '
        'txtmnusl
        '
        Me.txtmnusl.Location = New System.Drawing.Point(142, 21)
        Me.txtmnusl.Name = "txtmnusl"
        Me.txtmnusl.Size = New System.Drawing.Size(46, 21)
        Me.txtmnusl.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Menu Text :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Menu Name :"
        '
        'txtmnutext
        '
        Me.txtmnutext.Location = New System.Drawing.Point(142, 69)
        Me.txtmnutext.Name = "txtmnutext"
        Me.txtmnutext.Size = New System.Drawing.Size(209, 21)
        Me.txtmnutext.TabIndex = 19
        '
        'txtmenunm
        '
        Me.txtmenunm.Location = New System.Drawing.Point(142, 45)
        Me.txtmenunm.Name = "txtmenunm"
        Me.txtmenunm.Size = New System.Drawing.Size(209, 21)
        Me.txtmenunm.TabIndex = 18
        '
        'frmmenuentry
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(525, 366)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmmenuentry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Query Generator . . . . "
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnsend As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbmnutp As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtablvl As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkmnutp As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtmnusl As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtmnutext As System.Windows.Forms.TextBox
    Friend WithEvents txtmenunm As System.Windows.Forms.TextBox
    Friend WithEvents btngen As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtgenerate As System.Windows.Forms.TextBox

End Class
