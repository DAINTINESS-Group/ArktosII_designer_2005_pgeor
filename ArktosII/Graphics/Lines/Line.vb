Imports ArktosII.Graphics.Classes
Imports ArktosII.Graphics.Interfaces
Imports System.ComponentModel

Namespace Graphics.Lines

    Public Class Line
        Implements ArktosII.Graphics.Interfaces.IDrawable

#Region " Constructor "

        Public Sub New()
            myGuid = Guid.NewGuid
        End Sub

        Public Sub New(ByVal startNode As ArktosII.Graphics.Nodes.Node, ByVal endNode As ArktosII.Graphics.Nodes.Node, ByVal linetype As LineTypes)
            Me.New()
            myStartPoint = New PointF(startNode.Location.X + startNode.Size.Width / 2, startNode.Location.Y + startNode.Size.Height / 2)
            myEndPoint = New PointF(endNode.Location.X + endNode.Size.Width / 2, endNode.Location.Y + endNode.Size.Height / 2)
            myLineType = linetype
        End Sub

#End Region

#Region " Event & Handlers "

        Public Event LineTypeChanged(ByVal sender As Line, ByVal ge As GraphicsEventArgs)

        Protected Sub OnLineTypeChanged(ByVal ge As GraphicsEventArgs)
            RaiseEvent LineTypeChanged(Me, ge)
        End Sub

#End Region

#Region " Implementation Members "

        Protected myGuid As Guid

        Public Enum LineTypes
            Direct = 0
            SquareAngle
        End Enum

        Protected myStartPoint As PointF
        Protected myEndPoint As PointF
        Protected myLineType As LineTypes

#End Region

#Region " Properties "

        Public ReadOnly Property ID() As String
            Get
                Return myGuid.ToString()
            End Get
        End Property

        Public Property LineType() As LineTypes
            Get
                Return myLineType
            End Get
            Set(ByVal Value As LineTypes)
                If Value <> myLineType Then
                    myLineType = Value
                    OnLineTypeChanged(New GraphicsEventArgs)
                End If
            End Set
        End Property

#End Region

#Region " IDrawable "

#Region " Events & Handlers "

        Public Event BackColorChanged(ByVal sender As Interfaces.IDrawable, ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.BackColorChanged

        Public Event FontChanged(ByVal sender As Interfaces.IDrawable, ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.FontChanged

        Public Event ForeColorChanged(ByVal sender As Interfaces.IDrawable, ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.ForeColorChanged

        Public Event LocationChanged(ByVal sender As Interfaces.IDrawable, ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.LocationChanged

        Public Event SizeChanged(ByVal sender As Interfaces.IDrawable, ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.SizeChanged

        Public Event PenSizeChanged(ByVal sender As Interfaces.IDrawable, ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.PenSizeChanged

        Public Event TextChanged(ByVal sender As Interfaces.IDrawable, ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.TextChanged

        Protected Sub OnBackColorChanged(ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.OnBackColorChanged
            RaiseEvent BackColorChanged(Me, ge)
        End Sub

        Protected Sub OnFontChanged(ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.OnFontChanged
            RaiseEvent FontChanged(Me, ge)
        End Sub

        Protected Sub OnForeColorChanged(ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.OnForeColorChanged
            RaiseEvent ForeColorChanged(Me, ge)
        End Sub

        Protected Sub OnLocationChanged(ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.OnLocationChanged
            RaiseEvent LocationChanged(Me, ge)
        End Sub

        Protected Sub OnPenSizeChanged(ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.OnPenSizeChanged
            RaiseEvent PenSizeChanged(Me, ge)
        End Sub

        Protected Sub OnSizeChanged(ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.OnSizeChanged
            RaiseEvent SizeChanged(Me, ge)
        End Sub

        Protected Sub OnTextChanged(ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.OnTextChanged
            RaiseEvent TextChanged(Me, ge)
        End Sub

#End Region

#Region " Properties "

#Region " Implementation Members "

        Protected myBackColor As Color
        Protected myFont As Font
        Protected meIsVisible As Boolean
        Protected myLocation As PointF
        Protected myForeColor As Color
        Protected myPenSize As Integer
        Protected mySize As SizeF
        Protected myText As String

#End Region

        Public Property BackColor() As System.Drawing.Color Implements Interfaces.IDrawable.BackColor
            Get
                Return myBackColor
            End Get
            Set(ByVal Value As System.Drawing.Color)
                If Not myBackColor.Equals(Value) Then
                    myBackColor = Value
                    OnBackColorChanged(New ArktosII.Graphics.Classes.GraphicsEventArgs)
                End If
            End Set
        End Property

        Public Property Font() As System.Drawing.Font Implements Interfaces.IDrawable.Font
            Get
                Return myFont
            End Get
            Set(ByVal Value As System.Drawing.Font)
                If Not myFont.Equals(Value) Then
                    myFont = Value
                    OnFontChanged(New ArktosII.Graphics.Classes.GraphicsEventArgs)
                End If
            End Set
        End Property

        <Browsable(False)> _
        Public Property IsVisible() As Boolean Implements Interfaces.IDrawable.IsVisible
            Get
                Return meIsVisible
            End Get
            Set(ByVal Value As Boolean)
                meIsVisible = Value
            End Set
        End Property

        Public Property Location() As System.Drawing.PointF Implements Interfaces.IDrawable.Location
            Get
                Return myLocation
            End Get
            Set(ByVal Value As System.Drawing.PointF)
                If Not myLocation.Equals(myLocation) Then
                    myLocation = Value
                    OnLocationChanged(New ArktosII.Graphics.Classes.GraphicsEventArgs)
                End If
            End Set
        End Property

        Public Property ForeColor() As System.Drawing.Color Implements Interfaces.IDrawable.ForeColor
            Get
                Return myForeColor
            End Get
            Set(ByVal Value As System.Drawing.Color)
                If Not myForeColor.Equals(Value) Then
                    myForeColor = Value
                    OnForeColorChanged(New ArktosII.Graphics.Classes.GraphicsEventArgs)
                End If
            End Set
        End Property

        Public Property PenSize() As Integer Implements Interfaces.IDrawable.PenSize
            Get
                Return myPenSize
            End Get
            Set(ByVal Value As Integer)
                If myPenSize <> Value Then
                    myPenSize = Value
                    OnPenSizeChanged(New ArktosII.Graphics.Classes.GraphicsEventArgs)
                End If
            End Set
        End Property

        Public Property Size() As System.Drawing.SizeF Implements Interfaces.IDrawable.Size
            Get
                Return mySize
            End Get
            Set(ByVal Value As System.Drawing.SizeF)
                If Not mySize.Equals(Value) Then
                    mySize = Value
                    OnSizeChanged(New ArktosII.Graphics.Classes.GraphicsEventArgs)
                End If
            End Set
        End Property

        Public Property Text() As String Implements Interfaces.IDrawable.Text
            Get
                Return myText
            End Get
            Set(ByVal Value As String)
                If Not myText.Equals(Value) Then
                    myText = Value
                    OnTextChanged(New ArktosII.Graphics.Classes.GraphicsEventArgs)
                End If
            End Set
        End Property

#End Region

#Region " Functions "

        Public Function Draw(ByVal g As System.Drawing.Graphics, ByVal scale As Single) As Integer Implements Interfaces.IDrawable.Draw
            Dim points() As PointF

            Select Case myLineType
                Case LineTypes.Direct
                    points = New PointF() {myStartPoint, myEndPoint}
                Case LineTypes.SquareAngle
                    points = New PointF() {myStartPoint, New PointF(myEndPoint.X, myStartPoint.Y), myEndPoint}
            End Select

            Dim p As New Pen(Color.Black, 2)
            g.DrawLines(p, points)
            p.Dispose()
        End Function

        Public Function GetBounds() As System.Drawing.Rectangle Implements Interfaces.IDrawable.GetBounds

        End Function

        Public Function IsAt(ByVal x As Integer, ByVal y As Integer) As Boolean Implements Interfaces.IDrawable.IsAt

        End Function


#End Region

#End Region

    End Class

End Namespace