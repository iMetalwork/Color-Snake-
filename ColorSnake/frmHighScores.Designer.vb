<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHighScores
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
        Me.lblSnakeGameTitle = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnReturn = New System.Windows.Forms.Button()
        Me.lstClassicScore = New System.Windows.Forms.ListBox()
        Me.lstColorScore = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lblSnakeGameTitle
        '
        Me.lblSnakeGameTitle.AutoSize = True
        Me.lblSnakeGameTitle.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSnakeGameTitle.Location = New System.Drawing.Point(35, 31)
        Me.lblSnakeGameTitle.Name = "lblSnakeGameTitle"
        Me.lblSnakeGameTitle.Size = New System.Drawing.Size(174, 21)
        Me.lblSnakeGameTitle.TabIndex = 0
        Me.lblSnakeGameTitle.Text = "Snake Game HighScore"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(238, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(214, 21)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "ColorSnake Game HighScore"
        '
        'btnReturn
        '
        Me.btnReturn.Location = New System.Drawing.Point(176, 194)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(75, 23)
        Me.btnReturn.TabIndex = 6
        Me.btnReturn.Text = "Return"
        Me.btnReturn.UseVisualStyleBackColor = True
        '
        'lstClassicScore
        '
        Me.lstClassicScore.FormattingEnabled = True
        Me.lstClassicScore.Location = New System.Drawing.Point(48, 73)
        Me.lstClassicScore.Name = "lstClassicScore"
        Me.lstClassicScore.Size = New System.Drawing.Size(120, 95)
        Me.lstClassicScore.TabIndex = 7
        '
        'lstColorScore
        '
        Me.lstColorScore.FormattingEnabled = True
        Me.lstColorScore.Location = New System.Drawing.Point(280, 73)
        Me.lstColorScore.Name = "lstColorScore"
        Me.lstColorScore.Size = New System.Drawing.Size(120, 95)
        Me.lstColorScore.TabIndex = 8
        '
        'frmHighScores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 241)
        Me.Controls.Add(Me.lstColorScore)
        Me.Controls.Add(Me.lstClassicScore)
        Me.Controls.Add(Me.btnReturn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblSnakeGameTitle)
        Me.Name = "frmHighScores"
        Me.Text = "frmHighScores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblSnakeGameTitle As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnReturn As Button
    Friend WithEvents lstClassicScore As ListBox
    Friend WithEvents lstColorScore As ListBox
End Class
