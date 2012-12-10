Imports System.Drawing
Imports System.Runtime.InteropServices

Namespace Graphics.Classes

    Public Enum PenStyles
        PS_SOLID = 0
        PS_DASH = 1
        PS_DOT = 2
        PS_DASHDOT = 3
        PS_DASHDOTDOT = 4
    End Enum

    Public Class RubberBandRectangle

#Region " Constructor "

        Public Sub New()
            Me.New(PenStyles.PS_SOLID, Color.Black, 1)
        End Sub

        Public Sub New(ByVal style As PenStyles, ByVal clr As Color, ByVal size As Integer)
            myPenStyle = style
            myPenColor = clr
            myPenSize = size
        End Sub

#End Region

#Region " Implementation Members "

        Private NULL_BRUSH As Integer = 5
        Private R2_XORPEN As Integer = 7

        Private myPenStyle As PenStyles
        Private myPenColor As Color
        Private myPenSize As Integer

        Private Const TRANSPARENT As Integer = 1
        Private Const OPAQUE As Integer = 2

#End Region

#Region " Properties "

        Public Property PenStyle() As PenStyles
            Get
                Return myPenStyle
            End Get
            Set(ByVal Value As PenStyles)
                myPenStyle = Value
            End Set
        End Property

        Public Property PenColor() As Color
            Get
                Return myPenColor
            End Get
            Set(ByVal Value As Color)
                myPenColor = Value
            End Set
        End Property

        Public Property PenSize() As Integer
            Get
                Return myPenSize
            End Get
            Set(ByVal Value As Integer)
                myPenSize = Value
            End Set
        End Property

#End Region

#Region " Public Functions "

        Public Sub DrawXORRectangle(ByVal g As System.Drawing.Graphics, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
            ' Extract the Win32 HDC from the Graphics object supplied.
            Dim hdc As IntPtr = g.GetHdc()

            ' Create a pen to draw the border of the rectangle.
            Dim gdiPen As IntPtr = CreatePen(myPenStyle, myPenSize, RGB(myPenColor.R, myPenColor.G, myPenColor.B))

            ' Set the ROP cdrawint mode to XOR.
            SetROP2(hdc, R2_XORPEN)

            SetBkMode(hdc, TRANSPARENT)

            ' Select the pen into the device context.
            Dim oldPen As IntPtr = SelectObject(hdc, gdiPen)

            ' Create a stock NULL_BRUSH brush and select it into the device context so
            ' that the rectangle isn't filled.
            Dim oldBrush As IntPtr = SelectObject(hdc, GetStockObject(NULL_BRUSH))

            ' Now XOR the hollow rectangle on the Graphics object with an outline of myPenStyle
            Rectangle(hdc, x1, y1, x2, y2)

            ' Put the old stuff back where it was 
            SelectObject(hdc, oldBrush) ' No need to delete a stock object
            SelectObject(hdc, oldPen)
            DeleteObject(gdiPen)

            ' Return the device context to windows.
            g.ReleaseHdc(hdc)
        End Sub

#End Region

#Region " Private Functions "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="hdc">Handle to a Win32 device context</param>
        ''' <param name="enDrawMode">Drawing mode</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[finik]	6/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <DllImport("gdi32.dll")> _
        Private Shared Function SetROP2(ByVal hdc As IntPtr, ByVal enDrawMode As Integer) As Integer
            ' Leave Empty - DllImport attribute forwards calls to gdi32.dll
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     
        ''' </summary>
        ''' <param name="enPenStyle">Pen style from enum PenStyles</param>
        ''' <param name="nWidth">Width of pen</param>
        ''' <param name="crColor">Color of pen</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[finik]	6/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <DllImport("gdi32.dll")> _
        Private Shared Function CreatePen(ByVal enPenStyle As PenStyles, ByVal nWidth As Integer, ByVal crColor As Integer) As IntPtr
            ' Leave Empty - DllImport attribute forwards calls to gdi32.dll
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     
        ''' </summary>
        ''' <param name="hObject">Win32 GDI handle to object to delete</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[finik]	6/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <DllImport("gdi32.dll")> _
        Private Shared Function DeleteObject(ByVal hObject As IntPtr) As Boolean
            ' Leave Empty - DllImport attribute forwards calls to gdi32.dll
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="hdc">Win32 GDI device context</param>
        ''' <param name="hObject">Win32 GDI handle to object to select</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[finik]	6/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <DllImport("gdi32.dll")> _
        Private Shared Function SelectObject(ByVal hdc As IntPtr, ByVal hObject As IntPtr) As IntPtr
            ' Leave Empty - DllImport attribute forwards calls to gdi32.dll
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="hdc">Handle to Win32 device context</param>
        ''' <param name="x1">x-coordinate of the top left corner</param>
        ''' <param name="y1">y-coordinate of the top left corner</param>
        ''' <param name="x2">x-coordinate of the bottom right corner</param>
        ''' <param name="y2">y-coordinate to the bottom right corner</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[finik]	6/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <DllImport("gdi32.dll")> _
        Private Shared Sub Rectangle(ByVal hdc As IntPtr, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
            ' Leave Empty - DllImport attribute forwards calls to gdi32.dll
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="brStyle">Selected from the WinGDI.h BrushStyles enum</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[finik]	6/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <DllImport("gdi32.dll")> _
        Private Shared Function GetStockObject(ByVal brStyle As Integer) As IntPtr
            ' Leave Empty - DllImport attribute forwards calls to gdi32.dll
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="hdc"></param>
        ''' <param name="iBkMode"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[finik]	6/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <DllImport("gdi32.dll")> _
        Private Shared Function SetBkMode(ByVal hdc As IntPtr, ByVal iBkMode As Integer) As Integer
            ' Leave Empty - DllImport attribute forwards calls to gdi32.dll
        End Function

        Private Shared Function RGB(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Integer
            Return ((255 Xor R) Or ((255 Xor G) << 8) Or ((255 Xor B) << 16))
        End Function

#End Region

    End Class

End Namespace