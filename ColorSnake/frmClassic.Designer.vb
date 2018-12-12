<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmClassic
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClassic))
        Me.tmrLoop = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblNewGame = New System.Windows.Forms.ToolStripLabel()
        Me.btnNewGame = New System.Windows.Forms.ToolStripButton()
        Me.lblPause = New System.Windows.Forms.ToolStripLabel()
        Me.btnPause = New System.Windows.Forms.ToolStripButton()
        Me.lblReturn = New System.Windows.Forms.ToolStripLabel()
        Me.btnReturn = New System.Windows.Forms.ToolStripButton()
        Me.lblSCore = New System.Windows.Forms.ToolStripLabel()
        Me.txtScore = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrLoop
        '
        Me.tmrLoop.Enabled = True
        Me.tmrLoop.Interval = 150
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblNewGame, Me.btnNewGame, Me.lblPause, Me.btnPause, Me.lblReturn, Me.btnReturn, Me.lblSCore, Me.txtScore})
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
        Me.btnNewGame.Text = "New Game"
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
        Me.btnPause.Text = "New Game"
        Me.btnPause.Visible = False
        '
        'lblReturn
        '
        Me.lblReturn.Name = "lblReturn"
        Me.lblReturn.Size = New System.Drawing.Size(120, 22)
        Me.lblReturn.Text = "Return to Main Menu"
        '
        'btnReturn
        '
        Me.btnReturn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnReturn.Image = CType(resources.GetObject("btnReturn.Image"), System.Drawing.Image)
        Me.btnReturn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(23, 22)
        '
        'lblSCore
        '
        Me.lblSCore.Name = "lblSCore"
        Me.lblSCore.Size = New System.Drawing.Size(36, 22)
        Me.lblSCore.Text = "Score"
        '
        'txtScore
        '
        Me.txtScore.Enabled = False
        Me.txtScore.Name = "txtScore"
        Me.txtScore.Size = New System.Drawing.Size(100, 25)
        '
        'frmClassic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 458)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmClassic"
        Me.Text = "Classic Snake"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrLoop As Timer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnNewGame As ToolStripButton
    Friend WithEvents btnPause As ToolStripButton
    Friend WithEvents lblNewGame As ToolStripLabel
    Friend WithEvents lblPause As ToolStripLabel
    Friend WithEvents lblSCore As ToolStripLabel
    Friend WithEvents txtScore As ToolStripTextBox
    Friend WithEvents lblReturn As ToolStripLabel
    Friend WithEvents btnReturn As ToolStripButton
End Class
