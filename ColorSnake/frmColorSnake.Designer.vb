<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColorSnake
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmColorSnake))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClassic = New System.Windows.Forms.Button()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.btnHighScore = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("AR HERMANN", 36.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(301, 61)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Color Snake"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClassic
        '
        Me.btnClassic.Font = New System.Drawing.Font("AR ESSENCE", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClassic.Location = New System.Drawing.Point(123, 136)
        Me.btnClassic.Name = "btnClassic"
        Me.btnClassic.Size = New System.Drawing.Size(93, 50)
        Me.btnClassic.TabIndex = 1
        Me.btnClassic.Text = "Classic Snake "
        Me.btnClassic.UseVisualStyleBackColor = True
        '
        'btnColor
        '
        Me.btnColor.Font = New System.Drawing.Font("AR ESSENCE", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnColor.Location = New System.Drawing.Point(123, 197)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(93, 50)
        Me.btnColor.TabIndex = 2
        Me.btnColor.Text = "Color Snake "
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'btnHighScore
        '
        Me.btnHighScore.Font = New System.Drawing.Font("AR ESSENCE", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHighScore.Location = New System.Drawing.Point(123, 258)
        Me.btnHighScore.Name = "btnHighScore"
        Me.btnHighScore.Size = New System.Drawing.Size(93, 50)
        Me.btnHighScore.TabIndex = 3
        Me.btnHighScore.Text = "High Score"
        Me.btnHighScore.UseVisualStyleBackColor = True
        '
        'frmColorSnake
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 344)
        Me.Controls.Add(Me.btnHighScore)
        Me.Controls.Add(Me.btnColor)
        Me.Controls.Add(Me.btnClassic)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmColorSnake"
        Me.Text = "Color Snake"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnClassic As Button
    Friend WithEvents btnColor As Button
    Friend WithEvents btnHighScore As Button
End Class
