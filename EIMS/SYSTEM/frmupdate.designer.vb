<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmupdate
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
        Me.txttype = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnup = New System.Windows.Forms.Button
        Me.txtpass = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightCyan
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txttype)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnexit)
        Me.Panel1.Controls.Add(Me.btnup)
        Me.Panel1.Controls.Add(Me.txtpass)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(282, 107)
        Me.Panel1.TabIndex = 0
        '
        'txttype
        '
        Me.txttype.Location = New System.Drawing.Point(256, 1)
        Me.txttype.Name = "txttype"
        Me.txttype.Size = New System.Drawing.Size(21, 20)
        Me.txttype.TabIndex = 7
        Me.txttype.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(3, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "*Enter Password :"
        '
        'btnexit
        '
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.ForeColor = System.Drawing.Color.Red
        Me.btnexit.Location = New System.Drawing.Point(6, 72)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(81, 23)
        Me.btnexit.TabIndex = 5
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'btnup
        '
        Me.btnup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnup.ForeColor = System.Drawing.Color.Red
        Me.btnup.Location = New System.Drawing.Point(198, 72)
        Me.btnup.Name = "btnup"
        Me.btnup.Size = New System.Drawing.Size(75, 23)
        Me.btnup.TabIndex = 4
        Me.btnup.Text = "&Update"
        Me.btnup.UseVisualStyleBackColor = True
        '
        'txtpass
        '
        Me.txtpass.Location = New System.Drawing.Point(131, 27)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpass.Size = New System.Drawing.Size(142, 20)
        Me.txtpass.TabIndex = 2
        '
        'frmupdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(284, 109)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmupdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update Panel . . . "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnup As System.Windows.Forms.Button
    Friend WithEvents txtpass As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txttype As System.Windows.Forms.TextBox
End Class
