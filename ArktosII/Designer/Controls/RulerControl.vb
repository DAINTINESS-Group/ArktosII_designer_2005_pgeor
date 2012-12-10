Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Namespace Designer.Controls

    Public Class RulerControl
        Inherits System.Windows.Forms.Control
        Implements IMessageFilter

#Region " Constructor "

        Public Sub New()
            MyBase.New()
            MyBase.BackColor = System.Drawing.Color.White
            MyBase.ForeColor = System.Drawing.Color.Black

            ' This call is required by the Windows.Forms Form Designer
            InitializeComponent()

            SetStyle(ControlStyles.ResizeRedraw, True)
        End Sub

#End Region

#Region " Component Designer generated code "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Required methot for designer support - do not modify the contents of 
        '''     this method with the code editor.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	28/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub InitializeComponent()
            '
            ' RulerControl
            ' 
            Me.Name = "RulerControl"
        End Sub

#End Region

#Region " Event Handlers "

        Protected Overridable Sub OnHooverValue(ByVal e As HooverValueEventArgs)
            RaiseEvent HooverValue(Me, e)
        End Sub

        Protected Overridable Sub OnScaleModeChanged(ByVal e As ScaleModeChangedEventArgs)
            RaiseEvent ScaleModeChanged(Me, e)
        End Sub

        Protected Overrides Sub OnEnter(ByVal e As EventArgs)
            MyBase.OnEnter(e)
            Me.meDrawLine = False
            Invalidate()
        End Sub

        Protected Overrides Sub OnLeave(ByVal e As EventArgs)
            MyBase.OnLeave(e)
            Invalidate()
        End Sub

#End Region

#Region " Implementation Members "

#Region " Delegates "

        Public Delegate Sub ScaleModeChangedEventHandler(ByVal sender As Object, ByVal e As ScaleModeChangedEventArgs)
        Public Delegate Sub HooverValueEventHandler(ByVal sender As Object, ByVal e As HooverValueEventArgs)

#End Region

#Region " Enumerations "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     An enumeration for the orientation of the ruler.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	28/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Enum Orientations
            Horizontal = 0
            Vertical = 1
        End Enum
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     The scale of the ruler.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	28/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Enum ScaleModes
            Points = 0
            Pixels = 1
            Centimetres = 2
            Inches = 3
        End Enum

        Public Enum RulerAlingments
            TopOrLeft = 0
            Middle = 1
            BottomOrRight = 2
        End Enum

        Friend Enum Msg
            WM_MOUSEMOVE = 512
            WM_MOUSELEAVE = 675
            WM_NCMOUSELEAVE = 674
        End Enum

#End Region

#Region " Events "

        Public Event ScaleModeChanged As ScaleModeChangedEventHandler
        Public Event HooverValue As HooverValueEventHandler

#End Region

        Private myScale As Integer
        Private myScaleStartValue As Integer
        Private meDrawLine As Boolean = False
        Private meInControl As Boolean = False
        Private myMousePosition As Integer = 1
        Private myOldMousePosition As Integer = -1
        Private myBitmap As Bitmap = Nothing

        Private myOrientation As Orientations
        Private myScaleMode As ScaleModes
        Private myRulerAlingment As RulerAlingments = RulerAlingments.BottomOrRight
        Private myBorderStyle3D As Border3DStyle = Border3DStyle.Etched

        Private myMajorInterval As Integer = 100
        Private myNumberOfDivisions As Integer = 10
        Private myDivisionMarkFactor As Integer = 5
        Private myMiddleMarkFactor As Integer = 2
        Private myZoomFactor As Double = 1
        Private myStartValue As Double = 0
        Private meIsMouseTrackingOn As Boolean = False
        Private meIsVerticalNumbers As Boolean = True

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Required designer variable
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	28/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private components As System.ComponentModel.Container = Nothing

#End Region

#Region " IMessageFilter "

        Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage
            If Not Me.meIsMouseTrackingOn Then Return False

            If m.Msg = CInt(Msg.WM_MOUSEMOVE) Then
                Dim X As Integer = 0
                Dim Y As Integer = 0

                ' The mouse coordinate are measured in screen coordinates because thats what Control.MousePosition
                ' returns.  The Message.LParam value is not used because it returns the mouse position relative
                ' to the control the mouse is over.
                Dim ptScreen As Point = Control.MousePosition

                ' Get the origin of this control in screen coordinates so that later we can compare it against
                ' the mouse point to determine if we've hit this control.

                Dim ptClientOrigin As Point = New Point(X, Y)
                ptClientOrigin = PointToScreen(ptClientOrigin)

                meDrawLine = False
                meInControl = False

                Dim eHoover As HooverValueEventArgs = Nothing

                ' Work out whether the mouse is within the Y-axis bounds of a vertical ruler or within the 
                ' X-axis bounds of a horizontal ruler.
                If myOrientation = Orientations.Horizontal Then
                    meDrawLine = (ptScreen.X >= ptClientOrigin.X) And (ptScreen.X <= ptClientOrigin.X + Me.Width)
                Else
                    meDrawLine = (ptScreen.Y >= ptClientOrigin.Y) And (ptScreen.Y <= ptClientOrigin.Y + Me.Height)
                End If

                ' If the mouse is in a valid position ...
                If meDrawLine Then
                    ' ... workout the position of the mouse relative to the 
                    X = ptScreen.X - ptClientOrigin.X
                    Y = ptScreen.Y - ptClientOrigin.Y

                    ' Determine whether the mouse is within the bounds of the control itself
                    meInControl = Me.ClientRectangle.Contains(New Point(X, Y))

                    ' Make the relative mouse position available in pixel relative to this control's origin
                    ChangeMousePosition(IIf(myOrientation = Orientations.Horizontal, X, Y))
                    eHoover = New HooverValueEventArgs(CalculateValue(myMousePosition))
                Else
                    ChangeMousePosition(-1)
                    eHoover = New HooverValueEventArgs(myMousePosition)
                End If

                ' Paint directly by calling the OnPaint() method.  This way the background is not hosed
                ' by the call to Invalidate() so painting occurs without the hint of a flicker
                Dim e As PaintEventArgs = Nothing
                Try
                    e = New PaintEventArgs(Me.CreateGraphics(), Me.ClientRectangle)
                    OnPaint(e)
                Finally
                    e.Graphics.Dispose()
                End Try

                OnHooverValue(eHoover)
            End If

            If (m.Msg = CInt(Msg.WM_MOUSELEAVE) Or m.Msg = CInt(Msg.WM_NCMOUSELEAVE)) Then
                meDrawLine = False
                Dim paintArgs As PaintEventArgs = Nothing
                Try
                    paintArgs = New PaintEventArgs(Me.CreateGraphics, Me.ClientRectangle)
                    Me.OnPaint(paintArgs)
                Finally
                    paintArgs.Graphics.Dispose()
                End Try
            End If

            Return False ' Wheter or not the message is filtered
        End Function

#End Region

#Region " Private Functions "

        Private Function CalculateValue(ByVal offset As Integer) As Double
            If offset < 0 Then offset = 0

            Dim nValue As Double = CDbl(offset - Start()) / CDbl(myScale) * CDbl(myMajorInterval)
            Return nValue + Me.myStartValue
        End Function

        <Description("May not return zero even when a -ve scale number is given as the returned value needs to allow for the border thickness.")> _
        Private Function CalculagePixel(ByVal nScaleValue As Double) As Integer
            Dim nValue As Double = nScaleValue - Me.myStartValue
            If nValue < -0 Then Return Start() ' Start is the offset to the actual display area to allow for the border (if any)

            Dim iOffset As Integer = Convert.ToInt32(nValue / CDbl(myMajorInterval) * CDbl(myScale))

            Return iOffset + Start()
        End Function

        Private Sub ChangeMousePosition(ByVal iNewPosition As Integer)
            myOldMousePosition = myMousePosition
            myMousePosition = iNewPosition
        End Sub

        Private Function DefaultMajorInterval(ByVal iScaleMode As ScaleModes) As Integer
            Dim iInterval As Integer = 10

            Select Case iScaleMode
                Case ScaleModes.Points
                    iInterval = 72
                Case ScaleModes.Pixels
                    iInterval = 100
                Case ScaleModes.Centimetres
                    iInterval = 1
                Case ScaleModes.Inches
                    iInterval = 1
            End Select

            Return iInterval
        End Function

        Private Function DefaultScale(ByVal iScaleMode As ScaleModes) As Integer
            Dim iScale As Integer = 100

            Select Case iScaleMode
                Case ScaleModes.Points
                    iScale = 96
                Case ScaleModes.Pixels
                    iScale = 100
                Case ScaleModes.Centimetres
                    iScale = 38
                Case ScaleModes.Inches
                    iScale = 96
            End Select

            Return Convert.ToInt32(CDbl(iScale) * myZoomFactor)
        End Function

        Private Sub DivisionMark(ByVal g As System.Drawing.Graphics, ByVal position As Integer, ByVal proportion As Integer)
            ' This function is affected by the RulerAlingment setting
            Dim iMarkStart As Integer = 0
            Dim iMarkEnd As Integer = 0

            If myOrientation = Orientations.Horizontal Then
                Select Case myRulerAlingment
                    Case RulerAlingments.BottomOrRight
                        iMarkStart = Height - Height / proportion
                        iMarkEnd = Height
                    Case RulerAlingments.Middle
                        iMarkStart = (Height - Height / proportion) / 2 - 1
                        iMarkEnd = iMarkStart + Height / proportion
                    Case RulerAlingments.TopOrLeft
                        iMarkStart = 0
                        iMarkEnd = Height / proportion
                End Select

                Line(g, position, iMarkStart, position, iMarkEnd)
            Else
                Select Case myRulerAlingment
                    Case RulerAlingments.BottomOrRight
                        iMarkStart = Width - Width / proportion
                        iMarkEnd = Width
                    Case RulerAlingments.Middle
                        iMarkStart = (Width - Width / proportion) / 2 - 1
                        iMarkEnd = iMarkStart + Width / proportion
                    Case RulerAlingments.TopOrLeft
                        iMarkStart = 0
                        iMarkEnd = Width / proportion
                End Select

                Line(g, iMarkStart, position, iMarkEnd, position)
            End If
        End Sub

        Private Sub DrawControl(ByVal graphics As System.Drawing.Graphics)
            Dim g As System.drawing.Graphics

            ' If myBitmap Is Nothing Then
            ' Create a bitmap
            myBitmap = New Bitmap(Me.Width, Me.Height)

            g = graphics.FromImage(myBitmap)

            Try
                ' Wash the background with BackColor
                g.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, myBitmap.Width, myBitmap.Height)

                ' Paint the lines on the image
                Dim iScale As Integer = myScale

                Dim iStart As Integer = Start()
                Dim iEnd As Integer = IIf(myOrientation = Orientations.Horizontal, Width, Height)

                For j As Integer = iStart To iEnd Step iScale
                    Dim iLeft As Integer = myScale  ' Make an assumption that we're starting at zero or on a major increment
                    Dim jOffset As Integer = j + myScaleStartValue

                    iScale = (jOffset - iStart) Mod myScale ' Get the Mod value to see if this is "big line" opportunity

                    ' If it is, draw big line
                    If iScale = 0 Then
                        If myRulerAlingment <> RulerAlingments.Middle Then
                            If myOrientation = Orientations.Horizontal Then
                                Line(g, j, 0, j, Height)
                            Else
                                Line(g, 0, j, Width, j)
                            End If

                            iLeft = myScale             ' Set the for loop increment
                        Else
                            iLeft = myScale - iScale    ' Set the for loop increment
                        End If
                    End If

                    iScale = iLeft

                    Dim iValue As Integer = (((jOffset - iStart) / myScale) + 1) * myMajorInterval
                    DrawValue(g, iValue, j - iStart, iScale)

                    Dim iUsed As Integer = 0

                    ' Draw small lines
                    For i As Integer = 0 To myNumberOfDivisions - 1
                        ' Use a spreading algorithm rather than using expensive floating point numbers
                        Dim dblTemp As Double = CDbl(myScale - iUsed) / CDbl(myNumberOfDivisions - i)
                        Dim iX As Integer = Convert.ToInt32(Math.Round(dblTemp, 0))
                        iUsed += iX

                        If iUsed >= (myScale - iLeft) Then
                            iX = iUsed + j - (myScale - iLeft)

                            ' Is it an even number and, if so, is it the middle value?
                            Dim bMiddleMark As Boolean = ((myNumberOfDivisions And 1) = 0) And (i + 1 = myNumberOfDivisions / 2)
                            Dim bShowMiddleMark As Boolean = bMiddleMark
                            Dim bLastDivisionMark As Boolean = ((i + 1) = myNumberOfDivisions)
                            Dim bLastAlignMiddleDivisionMark As Boolean = bLastDivisionMark And (myRulerAlingment = RulerAlingments.Middle)
                            Dim bShowDivisionMark As Boolean = Not bMiddleMark And Not bLastDivisionMark

                            If bShowMiddleMark Then
                                DivisionMark(g, iX, myMiddleMarkFactor)     ' Height or Width will be 1/3
                            ElseIf bShowDivisionMark Then
                                DivisionMark(g, iX, myDivisionMarkFactor)   ' Height or Width will be 1/5
                            End If
                        End If
                    Next
                Next

                If myBorderStyle3D <> Border3DStyle.Flat Then
                    ControlPaint.DrawBorder3D(g, Me.ClientRectangle, myBorderStyle3D)
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine(ex.Message)
            Finally
                g.Dispose()
            End Try

            g = graphics

            Try
                ' Always draw the bitmap
                g.DrawImage(myBitmap, Me.ClientRectangle)
                RenderTrackLine(g)
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine(ex.Message)
            Finally
                GC.Collect()
            End Try
            'End If
        End Sub

        Private Sub DrawValue(ByVal g As System.Drawing.Graphics, ByVal iValue As Integer, ByVal iPosition As Integer, ByVal iSpaceAvailable As Integer)
            ' The sizing operation is common to all options
            Dim format As New StringFormat(StringFormatFlags.MeasureTrailingSpaces)
            If meIsVerticalNumbers Then format.FormatFlags = format.FormatFlags Or StringFormatFlags.DirectionVertical

            Dim szF As SizeF = g.MeasureString(iValue.ToString, Me.Font, iSpaceAvailable, format)
            Dim drawPoint As PointF
            Dim iX As Integer = 0
            Dim iY As Integer = 0

            If myOrientation = Orientations.Horizontal Then
                Select Case myRulerAlingment
                    Case RulerAlingments.BottomOrRight
                        iX = iPosition + iSpaceAvailable - CInt(szF.Width) - 2
                        iY = 2
                    Case RulerAlingments.Middle
                        iX = iPosition + iSpaceAvailable - CInt(szF.Width) / 2
                        iY = Height - CInt(szF.Height) / 2 - 2
                    Case RulerAlingments.TopOrLeft
                        iX = iPosition + iSpaceAvailable - CInt(szF.Width) - 2
                        iY = Height - 2 - CInt(szF.Height)
                End Select

                drawPoint = New PointF(iX, iY)
            Else
                Select Case myRulerAlingment
                    Case RulerAlingments.BottomOrRight
                        iX = 2
                        iY = iPosition + iSpaceAvailable - CInt(szF.Height) - 2
                    Case RulerAlingments.Middle
                        iX = (Width - CInt(szF.Width)) / 2 - 1
                        iY = iPosition + iSpaceAvailable - CInt(szF.Height) / 2
                    Case RulerAlingments.TopOrLeft
                        iX = Width - 2 - CInt(szF.Width)
                        iY = iPosition + iSpaceAvailable - CInt(szF.Height) - 2
                End Select

                drawPoint = New PointF(iX, iY)
            End If

            ' The drawstring function is common to all operations

            g.DrawString(iValue.ToString(), Me.Font, New SolidBrush(Me.ForeColor), drawPoint, format)
        End Sub

        Private Sub Line(ByVal g As System.Drawing.Graphics, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
            g.DrawLine(New Pen(New SolidBrush(Me.ForeColor)), x1, y1, x2, y2)
        End Sub

        Private Function Offset() As Integer
            Dim iOffset As Integer = 0

            Select Case myBorderStyle3D
                Case Border3DStyle.Flat
                    iOffset = 0
                Case Border3DStyle.Adjust
                    iOffset = 0
                Case Border3DStyle.Sunken
                    iOffset = 2
                Case Border3DStyle.Bump
                    iOffset = 2
                Case Border3DStyle.Etched
                    iOffset = 2
                Case Border3DStyle.Raised
                    iOffset = 2
                Case Border3DStyle.RaisedInner
                    iOffset = 1
                Case Border3DStyle.RaisedOuter
                    iOffset = 1
                Case Border3DStyle.SunkenInner
                    iOffset = 1
                Case Border3DStyle.SunkenOuter
                    iOffset = 1
            End Select

            Return iOffset
        End Function

        Private Function Start() As Integer
            Dim iStart As Integer = 0

            Select Case myBorderStyle3D
                Case Border3DStyle.Flat
                    iStart = 0
                Case Border3DStyle.Adjust
                    iStart = 0
                Case Border3DStyle.Sunken
                    iStart = 1
                Case Border3DStyle.Bump
                    iStart = 1
                Case Border3DStyle.Etched
                    iStart = 1
                Case Border3DStyle.Raised
                    iStart = 1
                Case Border3DStyle.RaisedInner
                    iStart = 0
                Case Border3DStyle.RaisedOuter
                    iStart = 0
                Case Border3DStyle.SunkenInner
                    iStart = 0
                Case Border3DStyle.SunkenOuter
                    iStart = 0
                Case Else
                    iStart = 0
            End Select

            Return iStart
        End Function

        Public Sub RenderTrackLine(ByVal g As Drawing.Graphics)
            If meIsMouseTrackingOn And meDrawLine Then
                Dim ioffset As Integer = Offset()

                ' Optionally render Mouse tracking line
                Select Case myOrientation
                    Case Orientations.Horizontal
                        Line(g, myMousePosition, ioffset, myMousePosition, Height - ioffset)
                    Case Orientations.Vertical
                        Line(g, ioffset, myMousePosition, Width - ioffset, myMousePosition)
                End Select
            End If
        End Sub

#End Region

#Region " Properties "

        <DefaultValue(GetType(Border3DStyle), "Etched"), Description("The border style used to draw the ruler"), Category("Ruler")> _
        Public Property BorderStyle() As Border3DStyle
            Get
                Return myBorderStyle3D
            End Get
            Set(ByVal Value As Border3DStyle)
                myBorderStyle3D = Value
                myBitmap = Nothing
                Invalidate()
            End Set
        End Property

        <Description("Horizontal or Vertical layout"), Category("Ruler")> _
        Public Property Orientation() As Orientations
            Get
                Return myOrientation
            End Get
            Set(ByVal Value As Orientations)
                myOrientation = Value
                myBitmap = Nothing
                Invalidate()
            End Set
        End Property

        <Description("A value from which the ruler marking should be shown.  Default is zero"), Category("Ruler")> _
        Public Property StartValue() As Double
            Get
                Return myStartValue
            End Get
            Set(ByVal Value As Double)
                myStartValue = Value

                ' Convert the value to pixels
                myScaleStartValue = Convert.ToInt32(Value * myScale / myMajorInterval)
                myBitmap = Nothing
                Invalidate()

            End Set
        End Property

        <Description("The scale to use"), Category("Ruler")> _
        Public Property ScaleMode() As ScaleModes
            Get
                Return myScaleMode
            End Get
            Set(ByVal Value As ScaleModes)
                Dim myOldScaleMode As ScaleModes = myScaleMode
                myScaleMode = Value

                If myMajorInterval = DefaultMajorInterval(myOldScaleMode) Then
                    ' Set the default Scale and MajorInterval value
                    myScale = DefaultScale(myScaleMode)
                    myMajorInterval = DefaultMajorInterval(myScaleMode)
                Else
                    MajorInterval = myMajorInterval
                End If

                ' Use the current start value (if there is one)
                Me.StartValue = myStartValue

                Dim e As New ScaleModeChangedEventArgs(Value)
                Me.OnScaleModeChanged(e)
            End Set
        End Property

        <Description("The value of the major interval. When displaying inches, 1 is a typical value. When displaying " & _
            "Points, 36 or 72 might be good values."), Category("Ruler")> _
        Public Property MajorInterval() As Integer
            Get
                Return myMajorInterval
            End Get
            Set(ByVal Value As Integer)
                If Value <= 0 Then Throw New Exception("The major interval cannot be less than one")
                myMajorInterval = Value
                myScale = DefaultScale(myScaleMode) * myMajorInterval / DefaultMajorInterval(myScaleMode)
                myBitmap = Nothing
                Invalidate()
            End Set
        End Property

        <Description("How many divisions should be shown between each major interval."), Category("Ruler")> _
        Public Property Divisions() As Integer
            Get
                Return myNumberOfDivisions
            End Get
            Set(ByVal Value As Integer)
                If Value <= 0 Then Throw New Exception("The number of divisions cannot be less than one.")
                myNumberOfDivisions = Value
                myBitmap = Nothing
                Invalidate()
            End Set
        End Property

        <Description("The height or width of this control multiplied by the reciprocal of this number will be used to compute the height of the non-middle division marks."), Category("Ruler")> _
        Public Property DivisionMarkFactor() As Integer
            Get
                Return myDivisionMarkFactor
            End Get
            Set(ByVal Value As Integer)
                If Value <= 0 Then Throw New Exception("The Division Mark Factor cannot be less than one.")
                myDivisionMarkFactor = Value
                myBitmap = Nothing
                Invalidate()
            End Set
        End Property

        <Description("The height or width of this control multiplied by the reciprocal of this number will be used to compute the height of the middle division mark."), Category("Ruler")> _
        Public Property MiddleMarkFactor() As Integer
            Get
                Return myMiddleMarkFactor
            End Get
            Set(ByVal Value As Integer)
                If Value <= 0 Then Throw New Exception("The Middle Mark Factor cannot be less than one.")
                myMiddleMarkFactor = Value
                myBitmap = Nothing
                Invalidate()
            End Set
        End Property

        <Description("The value of the current mouse position expressed in unit of the scale set (centimetres, inches, etc."), Category("Ruler")> _
        Public ReadOnly Property ScaleValue() As Double
            Get
                Return CalculateValue(myMousePosition)
            End Get
        End Property

        <Description("TRUE if a line is displayed to track the current position of the mouse and events are generated as the mouse moves."), Category("Ruler")> _
        Public Property MouseTrackingOn() As Boolean
            Get
                Return meIsMouseTrackingOn
            End Get
            Set(ByVal Value As Boolean)
                If Value = meIsMouseTrackingOn Then Return

                If Value Then
                    ' Tracking is being enabled so add the message filter hook
                    Application.AddMessageFilter(Me)
                Else
                    ' Tracking is being disabled so remove the message filter hook
                    Application.RemoveMessageFilter(Me)
                    ChangeMousePosition(-1)
                End If

                meIsMouseTrackingOn = Value
                myBitmap = Nothing
                Invalidate()
            End Set
        End Property

        <Description("The font used to display the division number")> _
        Public Overrides Property Font() As Font
            Get
                Return MyBase.Font
            End Get
            Set(ByVal Value As Font)
                MyBase.Font = Value
                myBitmap = Nothing
                Invalidate()
            End Set
        End Property

        <Description("Return the mouse position as number of pixels from the top or left of the control. -1 means that the mouse is positioned before or after the control."), Category("Ruler")> _
        Public ReadOnly Property MouseLocation() As Integer
            Get
                Return myMousePosition
            End Get
        End Property

        '<DefaultValue(GetType(Color), "ControlDarkDark"), Description("The color used to lines and number on the ruler.")> _
        'Public Overrides Property ForeColor() As Color
        '    Get
        '        Return MyBase.ForeColor
        '    End Get
        '    Set(ByVal Value As Color)
        '        MyBase.ForeColor = Value
        '        myBitmap = Nothing
        '        Invalidate()
        '    End Set
        'End Property

        '<DefaultValue(GetType(Color), "White"), Description("The color used to paint the background of the ruler.")> _
        'Public Overrides Property BackColor() As Color
        '    Get
        '        Return MyBase.BackColor
        '    End Get
        '    Set(ByVal Value As Color)
        '        MyBase.BackColor = Value
        '        myBitmap = Nothing
        '        Invalidate()
        '    End Set
        'End Property

        <Description(""), Category("Ruler")> _
        Public Property VerticalNumbers() As Boolean
            Get
                Return meIsVerticalNumbers
            End Get
            Set(ByVal Value As Boolean)
                meIsVerticalNumbers = Value
                myBitmap = Nothing
                Invalidate()
            End Set
        End Property

        <Description("A factor between 0.5 and 2 by which the displayed scale will be zoomed"), Category("Ruler")> _
        Public Property ZoomFactor() As Double
            Get
                Return myZoomFactor
            End Get
            Set(ByVal Value As Double)
                If (Value < 0.5) Or (Value > 2) Then Throw New Exception("Zoom factor can be between 50% and 200%")

                If myZoomFactor = Value Then Return

                myZoomFactor = Value
                Me.ScaleMode = myScaleMode
                myBitmap = Nothing
                Invalidate()
            End Set
        End Property

        <Description("Determines how the ruler markings are displayed"), Category("Ruler")> _
        Public Property RulerAlingment() As RulerAlingments
            Get
                Return myRulerAlingment
            End Get
            Set(ByVal Value As RulerAlingments)
                If myRulerAlingment = Value Then Return

                myRulerAlingment = Value
                myBitmap = Nothing
                Invalidate()
            End Set
        End Property

#End Region

#Region " Overrides "

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not components Is Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnResize(ByVal e As EventArgs)
            MyBase.OnResize(e)

            ' Take private resize actions here
            myBitmap = Nothing
            Invalidate()
        End Sub

        Public Overrides Sub Refresh()
            MyBase.Refresh()
            Invalidate()
        End Sub

        <Description("Draws the ruler marks in the scale requested.")> _
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            DrawControl(e.Graphics)
        End Sub

        Protected Overrides Sub OnHandleDestroyed(ByVal e As EventArgs)
            MyBase.OnHandleDestroyed(e)
            Try
                If meIsMouseTrackingOn Then
                    Application.RemoveMessageFilter(Me)
                End If
            Catch ex As Exception
                ' Do Nothing 
            End Try
        End Sub

#End Region




#Region " Public Class ScaleModeChangedEventArgs "

        Public Class ScaleModeChangedEventArgs
            Inherits System.EventArgs

#Region " Constructor "

            Public Sub New(ByVal mode As ScaleModes)
                MyBase.New()

                myMode = mode
            End Sub

#End Region

#Region " Implementation Members "

            Private myMode As ScaleModes

#End Region

#Region " Properties "

            Public ReadOnly Property Mode() As ScaleModes
                Get
                    Return myMode
                End Get
            End Property

#End Region


        End Class

#End Region

#Region " Public Class HooverValueEventArgs "

        Public Class HooverValueEventArgs
            Inherits System.EventArgs

#Region " Constructor "

            Public Sub New(ByVal value As Double)

            End Sub

#End Region

#Region " Implementation Members "

            Private myValue As Double

#End Region

#Region " Properties "

            Public ReadOnly Property Value() As Double
                Get
                    Return myValue
                End Get
            End Property

#End Region

        End Class

#End Region

    End Class

End Namespace