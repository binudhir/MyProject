<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class frmlogin
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
    Friend WithEvents txtunm As System.Windows.Forms.TextBox
    Friend WithEvents txtpswd As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.txtunm = New System.Windows.Forms.TextBox
        Me.txtpswd = New System.Windows.Forms.TextBox
        Me.btnlogin = New System.Windows.Forms.Button
        Me.btncncl = New System.Windows.Forms.Button
        Me.lblset = New System.Windows.Forms.Label
        Me.lblint = New System.Windows.Forms.Label
        Me.lblhelp = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'txtunm
        '
        Me.txtunm.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtunm.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunm.Location = New System.Drawing.Point(186, 126)
        Me.txtunm.Name = "txtunm"
        Me.txtunm.Size = New System.Drawing.Size(197, 17)
        Me.txtunm.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtunm, "User Name")
        '
        'txtpswd
        '
        Me.txtpswd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtpswd.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpswd.Location = New System.Drawing.Point(186, 155)
        Me.txtpswd.Name = "txtpswd"
        Me.txtpswd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpswd.Size = New System.Drawing.Size(197, 16)
        Me.txtpswd.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtpswd, "Password")
        '
        'btnlogin
        '
        Me.btnlogin.BackColor = System.Drawing.Color.Transparent
        Me.btnlogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnlogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnlogin.FlatAppearance.BorderSize = 2
        Me.btnlogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnlogin.Location = New System.Drawing.Point(399, 259)
        Me.btnlogin.Name = "btnlogin"
        Me.btnlogin.Size = New System.Drawing.Size(77, 26)
        Me.btnlogin.TabIndex = 2
        Me.btnlogin.Text = "Login"
        Me.ToolTip1.SetToolTip(Me.btnlogin, "Login")
        Me.btnlogin.UseVisualStyleBackColor = False
        '
        'btncncl
        '
        Me.btncncl.BackColor = System.Drawing.Color.Transparent
        Me.btncncl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncncl.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btncncl.FlatAppearance.BorderSize = 2
        Me.btncncl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btncncl.Location = New System.Drawing.Point(288, 259)
        Me.btncncl.Name = "btncncl"
        Me.btncncl.Size = New System.Drawing.Size(81, 26)
        Me.btncncl.TabIndex = 3
        Me.btncncl.Text = "Cancel"
        Me.ToolTip1.SetToolTip(Me.btncncl, "Cancel")
        Me.btncncl.UseVisualStyleBackColor = False
        '
        'lblset
        '
        Me.lblset.BackColor = System.Drawing.Color.Transparent
        Me.lblset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblset.Location = New System.Drawing.Point(13, 259)
        Me.lblset.Name = "lblset"
        Me.lblset.Size = New System.Drawing.Size(23, 22)
        Me.lblset.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.lblset, "Database Connection Setting.")
        '
        'lblint
        '
        Me.lblint.BackColor = System.Drawing.Color.Transparent
        Me.lblint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblint.Location = New System.Drawing.Point(45, 259)
        Me.lblint.Name = "lblint"
        Me.lblint.Size = New System.Drawing.Size(23, 22)
        Me.lblint.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.lblint, "Feel Free To Write Us.")
        '
        'lblhelp
        '
        Me.lblhelp.BackColor = System.Drawing.Color.Transparent
        Me.lblhelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblhelp.Location = New System.Drawing.Point(77, 259)
        Me.lblhelp.Name = "lblhelp"
        Me.lblhelp.Size = New System.Drawing.Size(23, 22)
        Me.lblhelp.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.lblhelp, "Help")
        '
        'frmlogin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.AIMS.My.Resources.Resources._4
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(516, 300)
        Me.Controls.Add(Me.lblhelp)
        Me.Controls.Add(Me.lblint)
        Me.Controls.Add(Me.lblset)
        Me.Controls.Add(Me.btncncl)
        Me.Controls.Add(Me.btnlogin)
        Me.Controls.Add(Me.txtpswd)
        Me.Controls.Add(Me.txtunm)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmlogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login Info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnlogin As System.Windows.Forms.Button
    Friend WithEvents btncncl As System.Windows.Forms.Button
    Friend WithEvents lblset As System.Windows.Forms.Label
    Friend WithEvents lblint As System.Windows.Forms.Label
    Friend WithEvents lblhelp As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
