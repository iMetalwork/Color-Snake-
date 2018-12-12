Public Class frmHighScores

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
            My.Computer.Audio.Play(My.Resources.Beep2, AudioPlayMode.Background)
            Me.Hide()
            frmColorSnake.Show()
            My.Computer.Audio.Stop()
        End Sub

        Private Sub frmHighScores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            lstClassicScore.Items.AddRange(System.IO.File.ReadAllLines("classicScore.txt"))
            lstColorScore.Items.AddRange(System.IO.File.ReadAllLines("sColorScore.txt"))
        End Sub
    End Class
