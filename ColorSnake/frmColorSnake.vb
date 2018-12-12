Public Class frmColorSnake
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnHighScore.Click

        My.Computer.Audio.Play(My.Resources.Beep2, AudioPlayMode.Background)
        My.Computer.Audio.Play(My.Resources.DJ_Sona_Ethereal_Nosaj_Thing_x_Pretty_Lights_, AudioPlayMode.BackgroundLoop)
        Me.Hide()
        frmHighScores.Show()
    End Sub


    Private Sub btnClassic_Click(sender As Object, e As EventArgs) Handles btnClassic.Click
        Me.Hide()
        frmClassic.btnNewGame.Enabled = True
        frmClassic.Show()
        My.Computer.Audio.Play(My.Resources.Beep2, AudioPlayMode.Background)
    End Sub

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        Me.Hide()
        SColor.btnNewGame.Enabled = True
        SColor.Show()
        My.Computer.Audio.Play(My.Resources.Beep2, AudioPlayMode.Background)
    End Sub
End Class
