Imports ArktosII.Graphics.Interfaces
Imports ArktosII.Graphics.Classes
Imports System.ComponentModel

Namespace Graphics.Nodes

    ''' -----------------------------------------------------------------------------
    ''' Project	 : ArktosII
    ''' Class	 : Base.Node
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     The MustInherit class that every Node must inherit in order to get the
    '''     appropriate functionality.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Finik]	25/1/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public MustInherit Class Node
        Implements IDrawable, IMovable, ISelectable

#Region " Constructor "

        Public Sub New()
            myGUID = Guid.NewGuid
        End Sub

#End Region

#Region " Implementation Members "

        Protected myGUID As Guid
        Protected myForeColor As Color = Color.Black
        Protected myBackColor As Color = Color.White
        Protected myFont As Font
        Protected myText As String
        Protected myPenSize As Integer = 2
        Protected meIsSelected As Boolean = False
        Protected meIsVisible As Boolean = True
        Protected myRegion As Region

        Protected Friend myOffset As Point

#End Region

#Region " Interfaces "

#Region " IDrawable "

#Region " Events & Handlers "

        Public Event LocationChanged(ByVal sender As Graphics.Interfaces.IDrawable, ByVal ge As Graphics.Classes.GraphicsEventArgs) Implements Graphics.Interfaces.IDrawable.LocationChanged

        Public Event SizeChanged(ByVal sender As Graphics.Interfaces.IDrawable, ByVal ge As Graphics.Classes.GraphicsEventArgs) Implements Graphics.Interfaces.IDrawable.SizeChanged

        Public Event BackColorChanged(ByVal sender As Interfaces.IDrawable, ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.BackColorChanged

        Public Event ForeColorChanged(ByVal sender As Interfaces.IDrawable, ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.ForeColorChanged

        Public Event TextChanged(ByVal sender As Interfaces.IDrawable, ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.TextChanged

        Public Event FontChanged(ByVal sender As Interfaces.IDrawable, ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.FontChanged

        Public Event PenSizeChanged(ByVal sender As Interfaces.IDrawable, ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.PenSizeChanged

        Protected Sub OnPenSizeChanged(ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.OnPenSizeChanged
            RaiseEvent PenSizeChanged(Me, ge)
        End Sub


        Protected Sub OnLocationChanged(ByVal ge As Graphics.Classes.GraphicsEventArgs) Implements Graphics.Interfaces.IDrawable.OnLocationChanged
            RaiseEvent LocationChanged(Me, ge)
        End Sub

        Protected Sub OnSizeChanged(ByVal ge As Graphics.Classes.GraphicsEventArgs) Implements Graphics.Interfaces.IDrawable.OnSizeChanged
            RaiseEvent SizeChanged(Me, ge)
        End Sub

        Protected Sub OnBackColorChanged(ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.OnBackColorChanged
            RaiseEvent BackColorChanged(Me, ge)
        End Sub

        Protected Sub OnForeColorChanged(ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.OnForeColorChanged
            RaiseEvent ForeColorChanged(Me, ge)
        End Sub

        Protected Sub OnFontChanged(ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.OnFontChanged
            RaiseEvent FontChanged(Me, ge)
        End Sub

        Protected Sub OnTextChanged(ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.IDrawable.OnTextChanged
            RaiseEvent TextChanged(Me, ge)
        End Sub

#End Region

#Region " Properties "

        Protected mySize As SizeF
        Protected myLocation As PointF

        <Category("Layout"), Description("The position of the top-left corner of the node with respect to the containing paper")> _
                Public Property Location() As System.Drawing.PointF Implements Graphics.Interfaces.IDrawable.Location
            Get
                Return myLocation
            End Get
            Set(ByVal Value As System.Drawing.PointF)
                If Not Value.Equals(myLocation) Then
                    myLocation = Value
                    OnLocationChanged(New Graphics.Classes.GraphicsEventArgs)
                End If
            End Set
        End Property

        <Category("Layout"), Description("The size of the node in pixels")> _
        Public Property Size() As System.Drawing.SizeF Implements Graphics.Interfaces.IDrawable.Size
            Get
                Return mySize
            End Get
            Set(ByVal Value As System.Drawing.SizeF)
                If Not Value.Equals(mySize) Then
                    mySize = Value
                    OnSizeChanged(New Graphics.Classes.GraphicsEventArgs)
                End If
            End Set
        End Property

        <Category("Appearance"), Description("The foreground color for this node")> _
        Public Property ForeColor() As System.Drawing.Color Implements Interfaces.IDrawable.BackColor
            Get
                Return myForeColor
            End Get
            Set(ByVal Value As System.Drawing.Color)
                myForeColor = Value
                OnForeColorChanged(New Graphics.Classes.GraphicsEventArgs)
            End Set
        End Property

        <Category("Appearance"), Description("The background color for this node")> _
        Public Property BackColor() As System.Drawing.Color Implements Interfaces.IDrawable.ForeColor
            Get
                Return myBackColor
            End Get
            Set(ByVal Value As System.Drawing.Color)
                myBackColor = Value
                OnBackColorChanged(New Graphics.Classes.GraphicsEventArgs)
            End Set
        End Property

        <Category("Appearance"), Description("The font used for the text drawn on this node")> _
        Public Property Font() As System.Drawing.Font Implements Interfaces.IDrawable.Font
            Get
                Return myFont
            End Get
            Set(ByVal Value As System.Drawing.Font)
                myFont = Value
                OnFontChanged(New GraphicsEventArgs)
            End Set
        End Property

        <Category("Appearance"), Description("The text to be drawn on the node")> _
        Public Property Text() As String Implements Interfaces.IDrawable.Text
            Get
                Return myText
            End Get
            Set(ByVal Value As String)
                myText = Value
                OnTextChanged(New GraphicsEventArgs)
            End Set
        End Property

        <Browsable(False), DefaultValue(GetType(Integer), "2")> _
Public Property PenSize() As Integer Implements Interfaces.IDrawable.PenSize
            Get
                Return myPenSize
            End Get
            Set(ByVal Value As Integer)
                myPenSize = Value
                OnPenSizeChanged(New GraphicsEventArgs)
            End Set
        End Property

#End Region

#Region " Functions "

        Public MustOverride Function Draw(ByVal g As System.Drawing.Graphics, ByVal scale As Single) As Integer Implements Graphics.Interfaces.IDrawable.Draw

        Public Function GetBounds() As System.Drawing.Rectangle Implements Interfaces.IDrawable.GetBounds
            Return New System.Drawing.Rectangle(myLocation.X, myLocation.Y, mySize.Width, mySize.Height)
        End Function

        Public Function IsAt(ByVal x As Integer, ByVal y As Integer) As Boolean Implements Interfaces.IDrawable.IsAt
            Return myRegion.IsVisible(x, y)
        End Function

        Public Property IsVisible() As Boolean Implements Interfaces.IDrawable.IsVisible
            Get
                Return meIsVisible
            End Get
            Set(ByVal Value As Boolean)
                meIsVisible = Value
            End Set
        End Property

#End Region

#End Region

#Region " IMovable "

#Region " Events & Handlers "

        Protected Friend Sub OnMouseMoved(ByVal sender As Object, ByVal e As MouseEventArgs) Implements Graphics.Interfaces.IMovable.OnMouseMoved
            If e.Button = MouseButtons.Left Then
                Dim endPoint As New Point(e.X, e.Y)
                myLocation.X = endPoint.X - myOffset.X
                myLocation.Y = endPoint.Y - myOffset.Y
            End If
        End Sub

#End Region

#End Region

#Region " ISelectable "

#Region " Events & Handlers "

        Public Event SelectionStateChanged(ByVal sender As Interfaces.ISelectable, ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.ISelectable.SelectionStateChanged

        Public Sub OnSelectionStateChanged(ByVal ge As Classes.GraphicsEventArgs) Implements Interfaces.ISelectable.OnSelectionStateChanged
            RaiseEvent SelectionStateChanged(Me, ge)
        End Sub

#End Region

#Region " Properties "

        Public Property IsSelected() As Boolean Implements Interfaces.ISelectable.IsSelected
            Get
                Return meIsSelected
            End Get
            Set(ByVal Value As Boolean)
                If meIsSelected <> Value Then
                    meIsSelected = Value
                    OnSelectionStateChanged(New GraphicsEventArgs)
                End If
            End Set
        End Property

#End Region

#End Region

#End Region

#Region " Properties "

        Public ReadOnly Property ID() As String
            Get
                Return myGUID.ToString
            End Get
        End Property

        <Browsable(False)> _
Public ReadOnly Property Rectangle() As System.Drawing.Rectangle
            Get
                Return New System.Drawing.Rectangle(myLocation.X, myLocation.Y, mySize.Width, mySize.Height)
            End Get
        End Property

#End Region

#Region " Public Functions "

        Public Sub LoadPreferences(ByVal prefs As Designer.NodePreferences)
            myBackColor = prefs.BackColor
            myForeColor = prefs.ForeColor
            mySize.Height = prefs.Height
            mySize.Width = prefs.Width
        End Sub

#End Region

    End Class

End Namespace