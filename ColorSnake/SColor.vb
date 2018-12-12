Public Class SColor
    Protected Friend mGs As GamingConditions = GamingConditions.Player
    Private WithEvents PlayingGame As ColorSnakeGame
    Private WithEvents PlayerGame As ColorSnakeGame
    Public Event GameOver()
    Public Shared cPattern As New ArrayList
    Dim playerName As String = ""
    Dim highScore As Integer = 0
    Dim score As Integer = 0








    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If PlayingGame.GameCondition = GameState.Playing Then
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
        If PlayingGame.GameCondition = GameCondition.Playing Then
            PlayingGame.Move()
        End If
    End Sub

    Public Sub HandleGameOver()
        Dim FileNum As Integer
        Me.btnNewGame.Enabled = True
        Me.btnPause.Visible = False
        Me.lblPause.Visible = False


        score = txtScore.Text
        If score > highScore Then
            highScore = score
            playerName = InputBox("Enter player name:", "High score!")
            FileNum = FreeFile()
            FileOpen(FileNum, "sColorScore.txt", OpenMode.Output)
            PrintLine(FileNum, playerName, highScore)
            FileClose(FileNum)
        End If

    End Sub

    Private Sub btnNewGame_Click(sender As Object, e As EventArgs) Handles btnNewGame.Click

        Dim holder As String
        Dim blank As Integer
        Dim srnd As New Random
        cPattern.Clear()

        For i = 0 To 3
            blank = srnd.Next(0, 3)
            Select Case blank
                Case 0
                    cPattern.Insert(i, "Red")
                Case 1
                    cPattern.Insert(i, "Blue")
                Case 2
                    cPattern.Insert(i, "Green")
                Case 3
                    cPattern.Insert(i, "Yellow")
            End Select
        Next
        For i = 0 To 3
            holder = holder + " " + cPattern.Item(i)
        Next
        lblPattern.Text = holder
        txtScore.Text = 0
            btnNewGame.Enabled = False
        btnPause.Visible = True
        lblPause.Visible = True
        My.Computer.Audio.Play(My.Resources.Bit_Rush, AudioPlayMode.BackgroundLoop)
        PlayerGame = New ColorSnakeGame
        ColorSnakeGame.cBodylength = 3
        AddHandler PlayerGame.GameOver, AddressOf HandleGameOver
        AddHandler PlayerGame.Updated, AddressOf HandleGameUpdate
        PlayingGame = PlayerGame
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        PlayingGame = PlayerGame
        If PlayerGame.GameCondition = GameCondition.Paused Then
            PlayingGame = PlayerGame
            PlayingGame.Pause()
        Else
            PlayingGame.Pause()

        End If
    End Sub



    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        PlayingGame = PlayerGame
        PlayingGame.EndGame()
        frmColorSnake.Show()
        Me.Hide()
        My.Computer.Audio.Stop()
    End Sub

    Private Sub SColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
Public Enum GameCondition As Integer
    GameOver = 0
    Playing = 1
    Paused = 2
End Enum

Public Enum GamingConditions As Integer
    Demo = 0
    Player = 1
End Enum

Public Enum MovePlaces As Integer
    North = 0
    East = 1
    South = 2
    West = 3
End Enum
Public Class ColorSnakePart
    Protected Friend cColor As Color
    Protected Friend cRect As Rectangle
    Public Property Color() As Color
        Get
            Return cColor
        End Get
        Set(ByVal value As Color)
            cColor = value
        End Set
    End Property
    Public Sub New()
        cColor = Drawing.Color.Yellow
        cRect = New Rectangle(0, 0, 10, 10)
    End Sub
    Public Sub New(ByVal c As Color, ByVal x As Integer, ByVal y As Integer)
        cColor = c
        cRect = New Rectangle(x, y, 10, 10)
    End Sub
End Class

Public Class ColorSnake
    Public Event IsDead()
    Public Event EatenFood(ByRef f As ColorFood)
    Protected Friend cHeading As MovePlaces = MovePlaces.East
    Protected Friend cHead As Color = Color.Yellow
    Protected Friend cBody As Color = Color.Green
    Protected Friend cParts As New Queue(Of ColorSnakePart)


    Protected Friend cLand As ColorSnakeGame

    Public Sub New(ByRef onLand As ColorSnakeGame)
        cLand = onLand

        For i = 0 To 30 Step 10
            cParts.Enqueue(New ColorSnakePart(Color.Green, i, 50))
        Next
        cParts.Last.Color = Color.Yellow
    End Sub

    Public Property Heading() As MovePlaces
        Get
            Return cHeading
        End Get
        Set(value As MovePlaces)
            If [Enum].IsDefined(GetType(MovePlaces), value) Then cHeading = value
        End Set
    End Property

    Public Sub Move(ByVal cd As MovePlaces, Optional ByVal Lengthen As Boolean = False)
        If [Enum].IsDefined(GetType(MovePlaces), cd) = False Then Throw New ArgumentException(String.Format("{0} is not a valid value.", cd))
        cHeading = cd
        If cParts.Count > 0 Then
            cParts.Last.Color = cBody 'Get Color function goes here
            Dim cp As ColorSnakePart = Nothing
            Select Case cd
                Case MovePlaces.North
                    cp = New ColorSnakePart(Color.Yellow, cParts.Last.cRect.X, cParts.Last.cRect.Y - cLand.cSize)
                'Get Color Function Goes Here
                Case MovePlaces.East
                    cp = New ColorSnakePart(Color.Yellow, cParts.Last.cRect.X + cLand.cSize, cParts.Last.cRect.Y)

                Case MovePlaces.South
                    cp = New ColorSnakePart(Color.Yellow, cParts.Last.cRect.X, cParts.Last.cRect.Y + cLand.cSize)

                Case MovePlaces.West
                    cp = New ColorSnakePart(Color.Yellow, cParts.Last.cRect.X - cLand.cSize, cParts.Last.cRect.Y)
            End Select
            Dim ft As IEnumerable(Of ColorFood) = cLand.cFood.Where(Function(fp As ColorFood) fp.Rect.IntersectsWith(cp.cRect))
            If ft.Any Then
                If ft.Last.Color.Equals(ColorFood.GetNextColor(ColorSnakeGame.cBodylength + 1, SColor.cPattern)) Then
                    Lengthen = True
                    RaiseEvent EatenFood(ft(0))
                Else

                    RaiseEvent IsDead()

                End If

            End If
            If Not Lengthen Then cParts.Dequeue()
            Dim MoveIntoSelf = cParts.Any(Function(dd As ColorSnakePart) dd.cRect.IntersectsWith(cp.cRect))
            'Check to see if the snake is dead
            If MoveIntoSelf Then RaiseEvent IsDead()
            If cp.cRect.X < cLand.cBounds.Left Then RaiseEvent IsDead()
            If cp.cRect.X > cLand.cBounds.Right Then RaiseEvent IsDead()
            If cp.cRect.Y < cLand.cBounds.Top Then RaiseEvent IsDead()
            If cp.cRect.Y > cLand.cBounds.Bottom Then RaiseEvent IsDead()
            cParts.Enqueue(cp)
        End If
    End Sub

    Public Sub DrawSnake(ByRef g As Graphics)
        For Each cp As ColorSnakePart In cParts
            Using b As New Pen(cp.Color) 'Get Color Function Goes Here
                g.FillRectangle(b.Brush, cp.cRect)
                g.DrawRectangle(Pens.Black, cp.cRect)
            End Using
        Next
    End Sub


End Class
Public Class ColorSnakeGame
    Protected Friend cBounds As New Rectangle(10, 25, 467, 300)
    Protected Friend cBorder As New Rectangle(0, 330, 497, 10)
    Protected Friend cSize As Integer = 10
    Protected Friend cRnd As New Random
    Protected Friend WithEvents cSnake As ColorSnake
    Protected Friend cFood As New List(Of ColorFood)
    Protected Friend cGameCondition As GameCondition
    Protected Friend cInitialFood As Integer = 4
    Protected Friend cPoints As Integer = 0

    Public Shared cBodylength As Integer = 3

    Protected Friend cTick As New System.Windows.Forms.Timer With {.Interval = 500, .Enabled = True}

    Public Event GameOver()
    Public Event Updated()



    Public ReadOnly Property Points As Integer
        Get
            Return cPoints
        End Get
    End Property
    Public ReadOnly Property GameCondition
        Get
            Return cGameCondition
        End Get
    End Property

    Private Sub Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If GameCondition = GameCondition.Playing Then Move()
    End Sub


    Public Sub New()

        cSnake = New ColorSnake(Me)

        For i = 1 To cInitialFood
            AddNewPieceOfFood()
        Next
        AddHandler cSnake.IsDead, AddressOf HandleDeadSnake
        AddHandler cSnake.EatenFood, AddressOf HasEatenFood
        cGameCondition = GameCondition.Playing
        AddHandler cTick.Tick, AddressOf Tick
    End Sub


    Public Sub Pause()
        If cGameCondition = GameCondition.Playing Then
            cGameCondition = GameCondition.Paused
        ElseIf cGameCondition = GameCondition.Paused Then
            cGameCondition = GameCondition.Playing
        End If
    End Sub

    Public Sub EndGame()

        If cGameCondition = GameCondition.Playing Then
            cGameCondition = GameCondition.GameOver
        ElseIf cGameCondition = GameCondition.Paused Then
            cGameCondition = GameCondition.GetHashCode
            RaiseEvent GameOver()
        End If
    End Sub

    Public Sub PlayGame()
        cGameCondition = GameCondition.Playing
    End Sub
    Private Sub HasEatenFood(ByRef f As ColorFood)
        cFood.Remove(f)
        cPoints += 1
        cBodylength += 1
        If cFood.Any - False Then AddNewPieceOfFood()

    End Sub

    Private Sub HandleDeadSnake() Handles cSnake.IsDead
        cGameCondition = GameCondition.GameOver
        RaiseEvent GameOver()
    End Sub

    Public Sub Move()
        Move(cSnake.Heading)
    End Sub

    Public Sub Move(ByVal cd As MovePlaces)
        cSnake.Move(cd)
        If cRnd.NextDouble <= 0.2 Then AddNewPieceOfFood()
        RaiseEvent Updated()
    End Sub

    Private Sub AddNewPieceOfFood()
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim fr As ColorFood = Nothing
        Dim OverFood As Boolean = True
        Dim OverSnake As Boolean = True

        Do
            x = cRnd.Next(0, 40)
            y = cRnd.Next(0, 20)
            fr = New ColorFood(Me, ColorFood.GetRndColor(SColor.cPattern), x * cSize, y * cSize) 'Get Color Function Goes Here
            OverFood = cFood.Any(Function(f As ColorFood) f.Rect.IntersectsWith(fr.Rect))
            OverSnake = cSnake.cParts.Any(Function(s As ColorSnakePart) s.cRect.IntersectsWith(fr.Rect))

        Loop Until Not (OverFood OrElse OverSnake)
        cFood.Add(New ColorFood(Me, fr.Color, fr.Rect.X, fr.Rect.Y))
    End Sub

    Public Sub Draw(ByRef g As Graphics)
        For Each fp As ColorFood In cFood
            fp.Draw(g)
        Next
        cSnake.DrawSnake(g)
        Using b As New Pen(Drawing.Color.Black)
            g.FillRectangle(b.Brush, cBorder)
            g.DrawRectangle(Pens.Black, cBorder)
        End Using
    End Sub


End Class

Public Class ColorFood
    Protected Friend cColor As Color
    Protected Friend cRect As Rectangle

    Protected Friend brnd As New Random





    Public ReadOnly Property Color() As Color
        Get
            Return cColor
        End Get
    End Property
    Public ReadOnly Property Rect As Rectangle
        Get
            Return cRect
        End Get
    End Property

    Public Shared Function GetNextColor(ByRef a As Integer, ByRef q As ArrayList)

        Dim pigmen As String = q.Item(a Mod 4)
        Select Case pigmen
            Case "Red"
                Return Color.Red
            Case "Blue"
                Return Color.Blue
            Case "Green"
                Return Color.Green
            Case "Yellow"
                Return Color.Yellow
        End Select
    End Function

    Public Shared Function GetRndColor(ByRef q As ArrayList)
        Dim vrnd As New Random
        Dim chair As Integer

        chair = vrnd.Next(0, 20)
        Dim pigment As String = q.Item(chair Mod 4)
        Select Case pigment
            Case "Red"
                Return Color.Red
            Case "Blue"
                Return Color.Blue
            Case "Green"
                Return Color.Green
            Case "Yellow"
                Return Color.Yellow
        End Select

    End Function


    Public Sub New(ByRef land As ColorSnakeGame, ByVal c As Color, ByVal x As Integer, ByVal y As Integer)
        cColor = c
        cRect = New Rectangle(x + land.cBounds.Left, y + land.cBounds.Top, land.cSize, land.cSize)
    End Sub
    Public Sub Draw(ByRef g As Graphics)
        Using b As New Pen(cColor)
            g.FillEllipse(b.Brush, cRect)
            g.DrawEllipse(Pens.Black, cRect)
        End Using
    End Sub
End Class