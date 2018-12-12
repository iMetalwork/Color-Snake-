<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SColor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SColor))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblNewGame = New System.Windows.Forms.ToolStripLabel()
        Me.btnNewGame = New System.Windows.Forms.ToolStripButton()
        Me.lblPause = New System.Windows.Forms.ToolStripLabel()
        Me.btnPause = New System.Windows.Forms.ToolStripButton()
        Me.lblReturn = New System.Windows.Forms.ToolStripLabel()
        Me.btnReturn = New System.Windows.Forms.ToolStripButton()
        Me.lblScore = New System.Windows.Forms.ToolStripLabel()
        Me.txtScore = New System.Windows.Forms.ToolStripTextBox()
        Me.lblPatternTitle = New System.Windows.Forms.Label()
        Me.lblPattern = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblNewGame, Me.btnNewGame, Me.lblPause, Me.btnPause, Me.lblReturn, Me.btnReturn, Me.lblScore, Me.txtScore})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(481, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblNewGame
        '
        Me.lblNewGame.Name = "lblNewGame"
        Me.lblNewGame.Size = New System.Drawing.Size(65, 22)
        Me.lblNewGame.Text = "New Game"
        '
        'btnNewGame
        '
        Me.btnNewGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNewGame.Image = CType(resources.GetObject("btnNewGame.Image"), System.Drawing.Image)
        Me.btnNewGame.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNewGame.Name = "btnNewGame"
        Me.btnNewGame.Size = New System.Drawing.Size(23, 22)
        Me.btnNewGame.Text = "ToolStripButton1"
        '
        'lblPause
        '
        Me.lblPause.Name = "lblPause"
        Me.lblPause.Size = New System.Drawing.Size(38, 22)
        Me.lblPause.Text = "Pause"
        Me.lblPause.Visible = False
        '
        'btnPause
        '
        Me.btnPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPause.Image = CType(resources.GetObject("btnPause.Image"), System.Drawing.Image)
        Me.btnPause.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(23, 22)
        Me.btnPause.Text = "ToolStripButton2"
        Me.btnPause.Visible = False
        '
        'lblReturn
        '
        Me.lblReturn.Name = "lblReturn"
        Me.lblReturn.Size = New System.Drawing.Size(122, 22)
        Me.lblReturn.Text = "Return To Main Menu"
        '
        'btnReturn
        '
        Me.btnReturn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnReturn.Image = CType(resources.GetObject("btnReturn.Image"), System.Drawing.Image)
        Me.btnReturn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(23, 22)
        Me.btnReturn.Text = "ToolStripButton3"
        '
        'lblScore
        '
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(36, 22)
        Me.lblScore.Text = "Score"
        '
        'txtScore
        '
        Me.txtScore.Enabled = False
        Me.txtScore.Name = "txtScore"
        Me.txtScore.Size = New System.Drawing.Size(100, 25)
        '
        'lblPatternTitle
        '
        Me.lblPatternTitle.AutoSize = True
        Me.lblPatternTitle.Font = New System.Drawing.Font("Forte", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatternTitle.Location = New System.Drawing.Point(27, 378)
        Me.lblPatternTitle.Name = "lblPatternTitle"
        Me.lblPatternTitle.Size = New System.Drawing.Size(113, 30)
        Me.lblPatternTitle.TabIndex = 1
        Me.lblPatternTitle.Text = "Pattern:"
        '
        'lblPattern
        '
        Me.lblPattern.AutoSize = True
        Me.lblPattern.Font = New System.Drawing.Font("Forte", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPattern.Location = New System.Drawing.Point(146, 378)
        Me.lblPattern.Name = "lblPattern"
        Me.lblPattern.Size = New System.Drawing.Size(0, 30)
        Me.lblPattern.TabIndex = 2
        '
        'SColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 458)
        Me.Controls.Add(Me.lblPattern)
        Me.Controls.Add(Me.lblPatternTitle)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "SColor"
        Me.Text = "Color"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents lblNewGame As ToolStripLabel
    Friend WithEvents btnNewGame As ToolStripButton
    Friend WithEvents lblPause As ToolStripLabel
    Friend WithEvents btnPause As ToolStripButton
    Friend WithEvents lblReturn As ToolStripLabel
    Friend WithEvents btnReturn As ToolStripButton
    Friend WithEvents lblScore As ToolStripLabel
    Friend WithEvents txtScore As ToolStripTextBox
    Friend WithEvents lblPatternTitle As Label
    Friend WithEvents lblPattern As Label
End Class
