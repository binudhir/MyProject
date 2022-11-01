<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmprnt
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblprint = New System.Windows.Forms.Label
        Me.lblexit = New System.Windows.Forms.Label
        Me.chkcnfr = New System.Windows.Forms.CheckBox
        Me.txtendno = New System.Windows.Forms.TextBox
        Me.txtstrtno = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuadd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuedit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenudel = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnurefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1.SuspendLayout()
        Me.cmenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.EIMS.My.Resources.Resources.Print
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblprint)
        Me.Panel1.Controls.Add(Me.lblexit)
        Me.Panel1.Controls.Add(Me.chkcnfr)
        Me.Panel1.Controls.Add(Me.txtendno)
        Me.Panel1.Controls.Add(Me.txtstrtno)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(351, 195)
        Me.Panel1.TabIndex = 0
        '
        'lblprint
        '
        Me.lblprint.BackColor = System.Drawing.Color.Transparent
        Me.lblprint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblprint.Location = New System.Drawing.Point(248, 151)
        Me.lblprint.Name = "lblprint"
        Me.lblprint.Size = New System.Drawing.Size(67, 20)
        Me.lblprint.TabIndex = 2
        '
        'lblexit
        '
        Me.lblexit.BackColor = System.Drawing.Color.Transparent
        Me.lblexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblexit.Location = New System.Drawing.Point(46, 153)
        Me.lblexit.Name = "lblexit"
        Me.lblexit.Size = New System.Drawing.Size(64, 18)
        Me.lblexit.TabIndex = 3
        '
        'chkcnfr
        '
        Me.chkcnfr.AutoSize = True
        Me.chkcnfr.Checked = True
        Me.chkcnfr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkcnfr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkcnfr.Location = New System.Drawing.Point(47, 105)
        Me.chkcnfr.Name = "chkcnfr"
        Me.chkcnfr.Size = New System.Drawing.Size(219, 17)
        Me.chkcnfr.TabIndex = 4
        Me.chkcnfr.Text = "Ask For Printing Confirmation"
        Me.chkcnfr.UseVisualStyleBackColor = True
        '
        'txtendno
        '
        Me.txtendno.Location = New System.Drawing.Point(254, 53)
        Me.txtendno.Name = "txtendno"
        Me.txtendno.Size = New System.Drawing.Size(73, 21)
        Me.txtendno.TabIndex = 1
        Me.txtendno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtstrtno
        '
        Me.txtstrtno.Location = New System.Drawing.Point(254, 28)
        Me.txtstrtno.Name = "txtstrtno"
        Me.txtstrtno.Size = New System.Drawing.Size(73, 21)
        Me.txtstrtno.TabIndex = 0
        Me.txtstrtno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(132, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Ending Number :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(124, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Starting Number :"
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuadd, Me.cmnuedit, Me.cmenudel, Me.cmnurefresh})
        Me.cmenu.Name = "ContextMenuStrip1"
        Me.cmenu.Size = New System.Drawing.Size(117, 92)
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
        'frmprnt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(354, 197)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmprnt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Printing Wizaed . . ."
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.cmenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenudel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnurefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkcnfr As System.Windows.Forms.CheckBox
    Friend WithEvents txtendno As System.Windows.Forms.TextBox
    Friend WithEvents txtstrtno As System.Windows.Forms.TextBox
    Friend WithEvents lblprint As System.Windows.Forms.Label
    Friend WithEvents lblexit As System.Windows.Forms.Label

End Class
