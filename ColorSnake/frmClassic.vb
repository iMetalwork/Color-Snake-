'Program:       Classic Snake
'Date:          April 9, 2016


Public Class frmClassic
    Protected Friend mGs As GamingStates = GamingStates.Player
    Private WithEvents PlayingGame As SnakeGame
    Private WithEvents PlayerGame As SnakeGame
    Public Event GameOver()
    Dim playerName As String = ""
    Dim highScore As Integer = 0
    Dim score As Integer = 0

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If PlayingGame.GameState = GameState.Playing Then
            Select Case e.KeyCode
                Case Keys.Up
                    PlayingGame.Move(MoveDirections.North)
                Case Keys.Right
                    PlayingGame.Move(MoveDirections.East)
                Case Keys.Down
                    PlayingGame.Move(MoveDirections.South)
                Case Keys.Left
                    PlayingGame.Move(MoveDirections.West)
            End Select
        End If
    End Sub


    Public Sub HandleGameUpdate()
        Me.txtScore.Text = PlayingGame.Points
        Me.Invalidate()
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If PlayingGame IsNot Nothing Then
            PlayingGame.Draw(e.Graphics)
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If PlayingGame.GameState = GameState.Playing Then
            PlayingGame.Move()
        End If
    End Sub

    Public Sub HandleGameOver()
        Me.btnNewGame.Enabled = True
        Me.btnPause.Visible = False
        Me.lblPause.Visible = False
        score = txtScore.Text
        Dim FileNum As Integer
        If score > highScore Then
            highScore = score
            playerName = InputBox("Enter player name:", "High Score!")
            FileNum = FreeFile()
            FileOpen(FileNum, "classicScore.txt", OpenMode.Output)
            PrintLine(FileNum, playerName, highScore)
            FileClose(FileNum)
        End If
    End Sub

    Private Sub btnNewGame_Click(sender As Object, e As EventArgs) Handles btnNewGame.Click
        txtScore.Text = 0
        btnNewGame.Enabled = False
        btnPause.Visible = True
        lblPause.Visible = True
        My.Computer.Audio.Play(My.Resources.Bit_Rush, AudioPlayMode.BackgroundLoop)
        PlayerGame = New SnakeGame
        AddHandler PlayerGame.GameOver, AddressOf HandleGameOver
        AddHandler PlayerGame.Updated, AddressOf HandleGameUpdate
        PlayingGame = PlayerGame
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        PlayingGame = PlayerGame
        If PlayerGame.GameState = GameState.Paused Then
            PlayingGame = PlayerGame
            PlayingGame.Pause()
        Else
            PlayingGame.Pause()

        End If
    End Sub

    Private Sub frmClassic_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        PlayingGame = PlayerGame
        PlayingGame.EndGame()
        frmColorSnake.Show()
        Me.Hide()
        My.Computer.Audio.Stop()
    End Sub
End Class

Public Enum GameState As Integer
    GameOver = 0
    Playing = 1
    Paused = 2
End Enum

Public Enum GamingStates As Integer
    Demo = 0
    Player = 1
End Enum

Public Enum MoveDirections As Integer
    North = 0
    East = 1
    South = 2
    West = 3
End Enum
Public Class SnakePart
    Protected Friend mColor As Color
    Protected Friend mRect As Rectangle
    Public Property Color() As Color
        Get
            Return mColor
        End Get
        Set(ByVal value As Color)
            mColor = value
        End Set
    End Property
    Public Sub New()
        mColor = Drawing.Color.Yellow
        mRect = New Rectangle(0, 0, 10, 10)
    End Sub
    Public Sub New(ByVal c As Color, ByVal x As Integer, ByVal y As Integer)
        mColor = c
        mRect = New Rectangle(x, y, 10, 10)
    End Sub
End Class

Public Class Snake
    Public Event IsDead()
    Public Event EatenFood(ByRef f As Food)
    Protected Friend mHeading As MoveDirections = MoveDirections.East
    Protected Friend mHead As System.Drawing.Color = System.Drawing.Color.Yellow
    Protected Friend mBody As Color = Color.Green
    Protected Friend mParts As New Queue(Of SnakePart)

    Protected Friend mLand As SnakeGame

    Public Sub New(ByRef onLand As SnakeGame)
        mLand = onLand
        For i = 0 To 30 Step 10
            mParts.Enqueue(New SnakePart(Color.Green, i, 50))
        Next
        mParts.Last.Color = Color.Yellow
    End Sub

    Public Property Heading() As MoveDirections
        Get
            Return mHeading
        End Get
        Set(value As MoveDirections)
            If [Enum].IsDefined(GetType(MoveDirections), value) Then mHeading = value
        End Set
    End Property

    Public Sub Move(ByVal md As MoveDirections, Optional ByVal Lengthen As Boolean = False)
        If [Enum].IsDefined(GetType(MoveDirections), md) = False Then Throw New ArgumentException(String.Format("{0} is not a valid value.", md))
        mHeading = md
        If mParts.Count > 0 Then
            mParts.Last.Color = mBody
            Dim sp As SnakePart = Nothing
            Select Case md
                Case MoveDirections.North
                    sp = New SnakePart(Color.Yellow, mParts.Last.mRect.X, mParts.Last.mRect.Y - mLand.mSize)

                Case MoveDirections.East
                    sp = New SnakePart(Color.Yellow, mParts.Last.mRect.X + mLand.mSize, mParts.Last.mRect.Y)

                Case MoveDirections.South
                    sp = New SnakePart(Color.Yellow, mParts.Last.mRect.X, mParts.Last.mRect.Y + mLand.mSize)

                Case MoveDirections.West
                    sp = New SnakePart(Color.Yellow, mParts.Last.mRect.X - mLand.mSize, mParts.Last.mRect.Y)
            End Select
            Dim ft As IEnumerable(Of Food) = mLand.mFood.Where(Function(fp As Food) fp.Rect.IntersectsWith(sp.mRect))
            If ft.Any Then

                Lengthen = True
                    RaiseEvent EatenFood(ft(0))
                End If
                If Not Lengthen Then mParts.Dequeue()
            Dim MoveIntoSelf = mParts.Any(Function(dd As SnakePart) dd.mRect.IntersectsWith(sp.mRect))
            'Check to see if the snake is dead
            If MoveIntoSelf Then RaiseEvent IsDead()
            If sp.mRect.X < mLand.mBounds.Left Then RaiseEvent IsDead()
            If sp.mRect.X > mLand.mBounds.Right Then RaiseEvent IsDead()
            If sp.mRect.Y < mLand.mBounds.Top Then RaiseEvent IsDead()
            If sp.mRect.Y > mLand.mBounds.Bottom Then RaiseEvent IsDead()
            mParts.Enqueue(sp)
        End If
    End Sub

    Public Sub DrawSnake(ByRef g As Graphics)
        For Each sp As SnakePart In mParts
            Using b As New Pen(sp.Color)
                g.FillRectangle(b.Brush, sp.mRect)
                g.DrawRectangle(Pens.Black, sp.mRect)
            End Using
        Next
    End Sub
End Class
Public Class SnakeGame
    Protected Friend mBounds As New Rectangle(10, 25, 467, 300)
    Protected Friend mBorder As New Rectangle(0, 330, 497, 10)
    Protected Friend mSize As Integer = 10
    Protected Friend mRnd As New Random
    Protected Friend WithEvents mSnake As Snake
    Protected Friend mFood As New List(Of Food)
    Protected Friend mGameState As GameState
    Protected Friend mInitialFood As Integer = 4
    Protected Friend mPoints As Integer = 0

    Protected Friend mTick As New System.Windows.Forms.Timer With {.Interval = 500, .Enabled = True}

    Public Event GameOver()
    Public Event Updated()

    Public ReadOnly Property Points As Integer
        Get
            Return mPoints
        End Get
    End Property
    Public ReadOnly Property GameState
        Get
            Return mGameState
        End Get
    End Property

    Private Sub Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If GameState = GameState.Playing Then Move()
    End Sub

    Public Sub New()

        mSnake = New Snake(Me)

        For i = 1 To mInitialFood
            AddNewPieceOfFood()
        Next
        AddHandler mSnake.IsDead, AddressOf HandleDeadSnake
        AddHandler mSnake.EatenFood, AddressOf HasEatenFood
        mGameState = GameState.Playing
        AddHandler mTick.Tick, AddressOf Tick
    End Sub

    Public Sub Pause()
        If mGameState = GameState.Playing Then
            mGameState = GameState.Paused
        ElseIf mGameState = GameState.Paused Then
            mGameState = GameState.Playing
        End If
    End Sub

    Public Sub EndGame()

        If mGameState = GameState.Playing Then
            mGameState = GameState.GameOver
        ElseIf mGameState = GameState.Paused Then
            mGameState = GameState.GetHashCode
            RaiseEvent GameOver()
        End If
    End Sub

    Public Sub PlayGame()
        mGameState = GameState.Playing
    End Sub
    Private Sub HasEatenFood(ByRef f As Food)
        mFood.Remove(f)
        mPoints += 1
        If mFood.Any - False Then AddNewPieceOfFood()
    End Sub

    Private Sub HandleDeadSnake() Handles mSnake.IsDead
        mGameState = GameState.GameOver
        RaiseEvent GameOver()
    End Sub

    Public Sub Move()
        Move(mSnake.Heading)
    End Sub

    Public Sub Move(ByVal md As MoveDirections)
        mSnake.Move(md)
        If mRnd.NextDouble <= 0.2 Then AddNewPieceOfFood()
        RaiseEvent Updated()
    End Sub

    Private Sub AddNewPieceOfFood()
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim fr As Food = Nothing
        Dim OverFood As Boolean = True
        Dim OverSnake As Boolean = True

        Do
            x = mRnd.Next(0, 40)
            y = mRnd.Next(0, 20)
            fr = New Food(Me, Color.Green, x * mSize, y * mSize)
            OverFood = mFood.Any(Function(f As Food) f.Rect.IntersectsWith(fr.Rect))
            OverSnake = mSnake.mParts.Any(Function(s As SnakePart) s.mRect.IntersectsWith(fr.Rect))

        Loop Until Not (OverFood OrElse OverSnake)
        mFood.Add(New Food(Me, fr.Color, fr.Rect.X, fr.Rect.Y))
    End Sub

    Public Sub Draw(ByRef g As Graphics)
        For Each fp As Food In mFood
            fp.Draw(g)
        Next
        mSnake.DrawSnake(g)
        Using b As New Pen(Color.Black)
            g.FillRectangle(b.Brush, mBorder)
            g.DrawRectangle(Pens.Black, mBorder)
        End Using
    End Sub


End Class

Public Class Food
    Protected Friend mColor As Color
    Protected Friend mRect As Rectangle
    Public ReadOnly Property Color() As Color
        Get
            Return mColor
        End Get
    End Property
    Public ReadOnly Property Rect As Rectangle
        Get
            Return mRect
        End Get
    End Property

    Public Sub New(ByRef land As SnakeGame, ByVal c As Color, ByVal x As Integer, ByVal y As Integer)
        mColor = c
        mRect = New Rectangle(x + land.mBounds.Left, y + land.mBounds.Top, land.mSize, land.mSize)
    End Sub
    Public Sub Draw(ByRef g As Graphics)
        Using b As New Pen(mColor)
            g.FillEllipse(b.Brush, mRect)
            g.DrawEllipse(Pens.Black, mRect)
        End Using
    End Sub
End Class
