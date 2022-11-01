<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmstrmchang
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtsemister = New System.Windows.Forms.TextBox
        Me.txtsession = New System.Windows.Forms.TextBox
        Me.txttrade = New System.Windows.Forms.TextBox
        Me.btnserch = New System.Windows.Forms.Button
        Me.cmbnew = New System.Windows.Forms.ComboBox
        Me.txtnew = New System.Windows.Forms.TextBox
        Me.txtstudname = New System.Windows.Forms.TextBox
        Me.txtstudregd = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnrefresh = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.txtstudcd = New System.Windows.Forms.TextBox
        Me.txttradcd = New System.Windows.Forms.TextBox
        Me.txtoldtrad = New System.Windows.Forms.TextBox
        Me.txtslno = New System.Windows.Forms.TextBox
        Me.txtsescd = New System.Windows.Forms.TextBox
        Me.txtsemcd = New System.Windows.Forms.TextBox
        Me.txthstcd = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.txthstcd)
        Me.Panel1.Controls.Add(Me.txtsemcd)
        Me.Panel1.Controls.Add(Me.txtsescd)
        Me.Panel1.Controls.Add(Me.txtslno)
        Me.Panel1.Controls.Add(Me.txtoldtrad)
        Me.Panel1.Controls.Add(Me.txttradcd)
        Me.Panel1.Controls.Add(Me.txtstudcd)
        Me.Panel1.Controls.Add(Me.txtsemister)
        Me.Panel1.Controls.Add(Me.txtsession)
        Me.Panel1.Controls.Add(Me.txttrade)
        Me.Panel1.Controls.Add(Me.btnserch)
        Me.Panel1.Controls.Add(Me.cmbnew)
        Me.Panel1.Controls.Add(Me.txtnew)
        Me.Panel1.Controls.Add(Me.txtstudname)
        Me.Panel1.Controls.Add(Me.txtstudregd)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(516, 276)
        Me.Panel1.TabIndex = 0
        '
        'txtsemister
        '
        Me.txtsemister.BackColor = System.Drawing.Color.White
        Me.txtsemister.Enabled = False
        Me.txtsemister.Location = New System.Drawing.Point(181, 130)
        Me.txtsemister.Name = "txtsemister"
        Me.txtsemister.Size = New System.Drawing.Size(249, 21)
        Me.txtsemister.TabIndex = 28
        '
        'txtsession
        '
        Me.txtsession.BackColor = System.Drawing.Color.White
        Me.txtsession.Enabled = False
        Me.txtsession.Location = New System.Drawing.Point(181, 106)
        Me.txtsession.Name = "txtsession"
        Me.txtsession.Size = New System.Drawing.Size(249, 21)
        Me.txtsession.TabIndex = 26
        '
        'txttrade
        '
        Me.txttrade.BackColor = System.Drawing.Color.White
        Me.txttrade.Enabled = False
        Me.txttrade.Location = New System.Drawing.Point(181, 82)
        Me.txttrade.Name = "txttrade"
        Me.txttrade.Size = New System.Drawing.Size(249, 21)
        Me.txttrade.TabIndex = 23
        '
        'btnserch
        '
        Me.btnserch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnserch.ForeColor = System.Drawing.Color.Red
        Me.btnserch.Location = New System.Drawing.Point(351, 33)
        Me.btnserch.Name = "btnserch"
        Me.btnserch.Size = New System.Drawing.Size(79, 22)
        Me.btnserch.TabIndex = 121
        Me.btnserch.Text = "Search"
        Me.btnserch.UseVisualStyleBackColor = True
        '
        'cmbnew
        '
        Me.cmbnew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbnew.FormattingEnabled = True
        Me.cmbnew.Location = New System.Drawing.Point(181, 178)
        Me.cmbnew.Name = "cmbnew"
        Me.cmbnew.Size = New System.Drawing.Size(249, 20)
        Me.cmbnew.TabIndex = 3
        '
        'txtnew
        '
        Me.txtnew.Location = New System.Drawing.Point(181, 154)
        Me.txtnew.Name = "txtnew"
        Me.txtnew.Size = New System.Drawing.Size(249, 21)
        Me.txtnew.TabIndex = 2
        '
        'txtstudname
        '
        Me.txtstudname.BackColor = System.Drawing.Color.White
        Me.txtstudname.Enabled = False
        Me.txtstudname.Location = New System.Drawing.Point(181, 58)
        Me.txtstudname.Name = "txtstudname"
        Me.txtstudname.Size = New System.Drawing.Size(249, 21)
        Me.txtstudname.TabIndex = 21
        '
        'txtstudregd
        '
        Me.txtstudregd.Location = New System.Drawing.Point(181, 34)
        Me.txtstudregd.Name = "txtstudregd"
        Me.txtstudregd.Size = New System.Drawing.Size(168, 21)
        Me.txtstudregd.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(31, 181)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "New Trade / Stream :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(79, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "New Regd.No :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(129, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Class :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(113, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Session :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(58, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Trade / Stream  :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(72, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Student Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Student's Old Regd.No :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnrefresh)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(7, 226)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(501, 42)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controlls"
        '
        'btnrefresh
        '
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.Location = New System.Drawing.Point(213, 13)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnrefresh.TabIndex = 5
        Me.btnrefresh.Text = "&Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.Location = New System.Drawing.Point(6, 13)
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
        Me.btnsave.Location = New System.Drawing.Point(420, 13)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 4
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'txtstudcd
        '
        Me.txtstudcd.BackColor = System.Drawing.Color.White
        Me.txtstudcd.Enabled = False
        Me.txtstudcd.Location = New System.Drawing.Point(436, 34)
        Me.txtstudcd.Name = "txtstudcd"
        Me.txtstudcd.Size = New System.Drawing.Size(22, 21)
        Me.txtstudcd.TabIndex = 32
        Me.txtstudcd.Visible = False
        '
        'txttradcd
        '
        Me.txttradcd.BackColor = System.Drawing.Color.White
        Me.txttradcd.Enabled = False
        Me.txttradcd.Location = New System.Drawing.Point(436, 179)
        Me.txttradcd.Name = "txttradcd"
        Me.txttradcd.Size = New System.Drawing.Size(22, 21)
        Me.txttradcd.TabIndex = 122
        Me.txttradcd.Visible = False
        '
        'txtoldtrad
        '
        Me.txtoldtrad.BackColor = System.Drawing.Color.White
        Me.txtoldtrad.Enabled = False
        Me.txtoldtrad.Location = New System.Drawing.Point(436, 85)
        Me.txtoldtrad.Name = "txtoldtrad"
        Me.txtoldtrad.Size = New System.Drawing.Size(22, 21)
        Me.txtoldtrad.TabIndex = 123
        Me.txtoldtrad.Visible = False
        '
        'txtslno
        '
        Me.txtslno.BackColor = System.Drawing.Color.White
        Me.txtslno.Enabled = False
        Me.txtslno.Location = New System.Drawing.Point(436, 7)
        Me.txtslno.Name = "txtslno"
        Me.txtslno.Size = New System.Drawing.Size(22, 21)
        Me.txtslno.TabIndex = 124
        Me.txtslno.Visible = False
        '
        'txtsescd
        '
        Me.txtsescd.BackColor = System.Drawing.Color.White
        Me.txtsescd.Enabled = False
        Me.txtsescd.Location = New System.Drawing.Point(436, 109)
        Me.txtsescd.Name = "txtsescd"
        Me.txtsescd.Size = New System.Drawing.Size(22, 21)
        Me.txtsescd.TabIndex = 125
        Me.txtsescd.Visible = False
        '
        'txtsemcd
        '
        Me.txtsemcd.BackColor = System.Drawing.Color.White
        Me.txtsemcd.Enabled = False
        Me.txtsemcd.Location = New System.Drawing.Point(436, 133)
        Me.txtsemcd.Name = "txtsemcd"
        Me.txtsemcd.Size = New System.Drawing.Size(22, 21)
        Me.txtsemcd.TabIndex = 126
        Me.txtsemcd.Visible = False
        '
        'txthstcd
        '
        Me.txthstcd.BackColor = System.Drawing.Color.White
        Me.txthstcd.Enabled = False
        Me.txthstcd.Location = New System.Drawing.Point(464, 6)
        Me.txthstcd.Name = "txthstcd"
        Me.txthstcd.Size = New System.Drawing.Size(22, 21)
        Me.txthstcd.TabIndex = 127
        Me.txthstcd.Visible = False
        '
        'frmstrmchang
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(525, 286)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmstrmchang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmstrmchang"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents txtsemister As System.Windows.Forms.TextBox
    Friend WithEvents txtsession As System.Windows.Forms.TextBox
    Friend WithEvents txttrade As System.Windows.Forms.TextBox
    Friend WithEvents btnserch As System.Windows.Forms.Button
    Friend WithEvents cmbnew As System.Windows.Forms.ComboBox
    Friend WithEvents txtnew As System.Windows.Forms.TextBox
    Friend WithEvents txtstudname As System.Windows.Forms.TextBox
    Friend WithEvents txtstudregd As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtstudcd As System.Windows.Forms.TextBox
    Friend WithEvents txttradcd As System.Windows.Forms.TextBox
    Friend WithEvents txtoldtrad As System.Windows.Forms.TextBox
    Friend WithEvents txtslno As System.Windows.Forms.TextBox
    Friend WithEvents txtsemcd As System.Windows.Forms.TextBox
    Friend WithEvents txtsescd As System.Windows.Forms.TextBox
    Friend WithEvents txthstcd As System.Windows.Forms.TextBox

End Class
