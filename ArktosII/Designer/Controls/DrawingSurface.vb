Imports ArktosII.Graphics

Namespace Designer.Controls

    ''' -----------------------------------------------------------------------------
    ''' Project	 : ArktosII
    ''' Class	 : Graphics.Classes.DrawingSurface
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     This class represents the surface that all the drawing take place.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Finik]	25/1/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class DrawingSurface
        Inherits System.Windows.Forms.UserControl

#Region " Constructor "

        Public Sub New(ByVal drawingType As DrawingTypes)
            MyBase.New()

            myDrawingType = drawingType

            InitializeComponent()

            SetPaperSize(Paper.Sizes.A4, Paper.Orientations.Landscape)
            SetZoomFactor(1.0)
        End Sub

        Public Sub New()
            MyBase.New()

            InitializeComponent()

            myDrawingType = DrawingTypes.Conceptual

            SetPaperSize(Paper.Sizes.A4, Paper.Orientations.Landscape)
            SetZoomFactor(1.0)
        End Sub
#End Region

#Region " Component Designer generated code "

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

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
        Friend WithEvents pTop As System.Windows.Forms.Panel
        Friend WithEvents pLeft As System.Windows.Forms.Panel
        Friend WithEvents pMain As System.Windows.Forms.Panel
        Friend WithEvents pShadow As System.Windows.Forms.Panel
        Friend WithEvents pbPaper As ArktosII.Designer.Controls.Paper
        Friend WithEvents rcHorizontal As ArktosII.Designer.Controls.RulerControl
        Friend WithEvents rcVertical As ArktosII.Designer.Controls.RulerControl
        Friend WithEvents pScroller As ArktosII.Designer.Controls.PanelScroll
        Private Sub InitializeComponent()
            Me.pTop = New System.Windows.Forms.Panel
            Me.rcHorizontal = New ArktosII.Designer.Controls.RulerControl
            Me.pLeft = New System.Windows.Forms.Panel
            Me.rcVertical = New ArktosII.Designer.Controls.RulerControl
            Me.pMain = New System.Windows.Forms.Panel
            Me.pbPaper = New ArktosII.Designer.Controls.Paper(Paper.Sizes.A4, Paper.Orientations.Landscape)
            Me.pShadow = New System.Windows.Forms.Panel
            Me.pScroller = New ArktosII.Designer.Controls.PanelScroll
            Me.pTop.SuspendLayout()
            Me.pLeft.SuspendLayout()
            Me.pMain.SuspendLayout()
            Me.pScroller.SuspendLayout()
            Me.SuspendLayout()
            '
            'pTop
            '
            Me.pTop.Controls.Add(Me.rcHorizontal)
            Me.pTop.DockPadding.Bottom = 4
            Me.pTop.DockPadding.Left = 64
            Me.pTop.DockPadding.Right = 40
            Me.pTop.DockPadding.Top = 4
            Me.pTop.Location = New System.Drawing.Point(32, 0)
            Me.pTop.Name = "pTop"
            Me.pTop.Size = New System.Drawing.Size(720, 32)
            Me.pTop.TabIndex = 0
            '
            'rcHorizontal
            '
            Me.rcHorizontal.BackColor = System.Drawing.Color.White
            Me.rcHorizontal.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
            Me.rcHorizontal.DivisionMarkFactor = 5
            Me.rcHorizontal.Divisions = 10
            Me.rcHorizontal.ForeColor = System.Drawing.Color.Black
            Me.rcHorizontal.Location = New System.Drawing.Point(40, 4)
            Me.rcHorizontal.MajorInterval = 1
            Me.rcHorizontal.MiddleMarkFactor = 2
            Me.rcHorizontal.MouseTrackingOn = True
            Me.rcHorizontal.Name = "rcHorizontal"
            Me.rcHorizontal.Orientation = ArktosII.Designer.Controls.RulerControl.Orientations.Horizontal
            Me.rcHorizontal.RulerAlingment = ArktosII.Designer.Controls.RulerControl.RulerAlingments.BottomOrRight
            Me.rcHorizontal.ScaleMode = ArktosII.Designer.Controls.RulerControl.ScaleModes.Centimetres
            Me.rcHorizontal.Size = New System.Drawing.Size(432, 24)
            Me.rcHorizontal.StartValue = 0
            Me.rcHorizontal.TabIndex = 0
            Me.rcHorizontal.Text = "RulerControl1"
            Me.rcHorizontal.VerticalNumbers = False
            Me.rcHorizontal.ZoomFactor = 1
            '
            'pLeft
            '
            Me.pLeft.Controls.Add(Me.rcVertical)
            Me.pLeft.DockPadding.Bottom = 40
            Me.pLeft.DockPadding.Left = 4
            Me.pLeft.DockPadding.Right = 4
            Me.pLeft.DockPadding.Top = 32
            Me.pLeft.Location = New System.Drawing.Point(0, 32)
            Me.pLeft.Name = "pLeft"
            Me.pLeft.Size = New System.Drawing.Size(32, 568)
            Me.pLeft.TabIndex = 1
            '
            'rcVertical
            '
            Me.rcVertical.BackColor = System.Drawing.Color.White
            Me.rcVertical.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
            Me.rcVertical.DivisionMarkFactor = 5
            Me.rcVertical.Divisions = 10
            Me.rcVertical.ForeColor = System.Drawing.Color.Black
            Me.rcVertical.Location = New System.Drawing.Point(4, 32)
            Me.rcVertical.MajorInterval = 1
            Me.rcVertical.MiddleMarkFactor = 2
            Me.rcVertical.MouseTrackingOn = True
            Me.rcVertical.Name = "rcVertical"
            Me.rcVertical.Orientation = ArktosII.Designer.Controls.RulerControl.Orientations.Vertical
            Me.rcVertical.RulerAlingment = ArktosII.Designer.Controls.RulerControl.RulerAlingments.BottomOrRight
            Me.rcVertical.ScaleMode = ArktosII.Designer.Controls.RulerControl.ScaleModes.Centimetres
            Me.rcVertical.Size = New System.Drawing.Size(24, 280)
            Me.rcVertical.StartValue = 0
            Me.rcVertical.TabIndex = 1
            Me.rcVertical.Text = "RulerControl2"
            Me.rcVertical.VerticalNumbers = False
            Me.rcVertical.ZoomFactor = 1
            '
            'pMain
            '
            Me.pMain.BackColor = System.Drawing.SystemColors.ControlDark
            Me.pMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pMain.Controls.Add(Me.pbPaper)
            Me.pMain.Controls.Add(Me.pShadow)
            Me.pMain.Location = New System.Drawing.Point(0, 0)
            Me.pMain.Name = "pMain"
            Me.pMain.Size = New System.Drawing.Size(3000, 3000)
            Me.pMain.TabIndex = 2
            '
            'pbPaper
            '
            Me.pbPaper.BackColor = System.Drawing.Color.White
            Me.pbPaper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pbPaper.Location = New System.Drawing.Point(32, 32)
            Me.pbPaper.Name = "pbPaper"
            Me.pbPaper.Size = New System.Drawing.Size(428, 276)
            Me.pbPaper.TabIndex = 0
            Me.pbPaper.TabStop = False
            '
            'pShadow
            '
            Me.pShadow.BackColor = System.Drawing.Color.Black
            Me.pShadow.Location = New System.Drawing.Point(40, 40)
            Me.pShadow.Name = "pShadow"
            Me.pShadow.Size = New System.Drawing.Size(428, 276)
            Me.pShadow.TabIndex = 1
            '
            'pScroller
            '
            Me.pScroller.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pScroller.AutoScroll = True
            Me.pScroller.Controls.Add(Me.pMain)
            Me.pScroller.Location = New System.Drawing.Point(32, 32)
            Me.pScroller.Name = "pScroller"
            Me.pScroller.Size = New System.Drawing.Size(744, 584)
            Me.pScroller.TabIndex = 3
            Me.pScroller.AutoScrollPosition = New System.Drawing.Point(-1500, -1500)
            '
            'DrawingSurface
            '
            Me.Controls.Add(Me.pScroller)
            Me.Controls.Add(Me.pLeft)
            Me.Controls.Add(Me.pTop)
            Me.Name = "DrawingSurface"
            Me.Size = New System.Drawing.Size(776, 616)
            Me.pTop.ResumeLayout(False)
            Me.pLeft.ResumeLayout(False)
            Me.pMain.ResumeLayout(False)
            Me.pScroller.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " Event Handlers "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Resize the ruler controls
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	30/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub pScroller_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pScroller.SizeChanged
            pTop.Width = pScroller.Width - SystemInformation.VerticalScrollBarWidth
            pLeft.Height = pScroller.Height - SystemInformation.HorizontalScrollBarHeight
        End Sub

        Private Sub pScroller_VScrollValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles pScroller.VScrollValueChanged
            rcVertical.Top = pbPaper.Top + pScroller.AutoScrollPosition.Y
        End Sub

        Private Sub pScroller_HScrollValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles pScroller.HScrollValueChanged
            rcHorizontal.Left = pbPaper.Left + pScroller.AutoScrollPosition.X
        End Sub

        Private Sub pbPaper_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbPaper.Paint
            'If meShowGrid Then
            '    Dim p As New System.Drawing.Pen(Color.Blue)

            '    For i As Single = (10 * Paper.ToPixel * myZoomFactor) To pbPaper.Width Step (10 * Paper.ToPixel * myZoomFactor)
            '        For j As Single = (10 * Paper.ToPixel * myZoomFactor) To pbPaper.Height Step (10 * Paper.ToPixel * myZoomFactor)
            '            e.Graphics.DrawLine(p, i, j, i + 1, j)
            '        Next
            '    Next

            '    p.Dispose()
            'End If
        End Sub

#End Region

#Region " Implementation Members "

        Public Enum DrawingTypes
            Conceptual
            Logical
            Detail
        End Enum

        Private myPaper As Designer.Controls.Paper
        Private myZoomFactor As Single = 1
        Private meShowGrid As Boolean = True
        Private myDrawingType As DrawingTypes

#End Region

#Region " Properties "

        Public Property ShowGrid() As Boolean
            Get
                Return meShowGrid
            End Get
            Set(ByVal Value As Boolean)
                meShowGrid = Value
                Invalidate()
            End Set
        End Property

        Public ReadOnly Property DrawingType() As DrawingTypes
            Get
                Return myDrawingType
            End Get
        End Property

#End Region

#Region " Public Functions "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Sets the size and the orientation of the paper.  Positions the paper
        '''     in the center of the screen and readjusts the rulers.
        ''' </summary>
        ''' <param name="size">The size of the paper</param>
        ''' <param name="orientation">The orientation of the paper</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	30/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub SetPaperSize(ByVal size As Paper.Sizes, ByVal orientation As Paper.Orientations)
            myPaper = New Paper(size, orientation)

            pbPaper.Size = myPaper.ToPixels
            pShadow.Size = myPaper.ToPixels

            SetZoomFactor(1.0)
        End Sub

        Public Sub SetZoomFactor(ByVal sZoom As Single)
            Dim szDisplay As Size = pScroller.DisplayRectangle.Size
            Dim szClient As Size = pScroller.ClientRectangle.Size

            pScroller.AutoScrollPosition = New Point( _
                (szDisplay.Width - szClient.Width) / 2, _
                (szDisplay.Height - szClient.Height) / 2)

            ' Resize the paper and the shadow behind the paper
            Dim zoom As Single = sZoom / myZoomFactor
            pbPaper.Scale(zoom)
            pShadow.Scale(zoom)

            CenterPaper()

            ' Adjust the vertical ruler
            rcVertical.ZoomFactor = sZoom
            rcVertical.Height = pbPaper.Height
            rcVertical.Top = pbPaper.Top + pScroller.AutoScrollPosition.Y

            ' Adjust the horizontal ruler
            rcHorizontal.ZoomFactor = sZoom
            rcHorizontal.Width = pbPaper.Width
            rcHorizontal.Left = pbPaper.Left + pScroller.AutoScrollPosition.X

            myZoomFactor = sZoom
        End Sub

        Public Sub CenterPaper()
            pbPaper.Left = (pMain.Width - pbPaper.Width) / 2 - 4
            pbPaper.Top = (pMain.Height - pbPaper.Height) / 2 - 4

            pShadow.Left = (pMain.Width - pbPaper.Width) / 2 + 4
            pShadow.Top = (pMain.Height - pbPaper.Height) / 2 + 4

            rcHorizontal.Width = pbPaper.Width
            rcHorizontal.Left = pbPaper.Left

            rcVertical.Height = pbPaper.Height
            rcVertical.Top = pbPaper.Top
        End Sub

#End Region

    End Class

End Namespace