Imports ArktosII.Graphics.Interfaces

Namespace Designer.Controls

    ''' -----------------------------------------------------------------------------
    ''' Project	 : ArktosII
    ''' Class	 : Designer.Classes.Paper
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     A class representing paper for use in drawing surface and printing
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Finik]	30/1/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------

    Public Class Paper
        Inherits System.Windows.Forms.Panel

#Region " Constructor "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Constructor for Paper Class
        ''' </summary>
        ''' <param name="paperSize"></param>
        ''' <param name="orientation"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	30/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub New(ByVal paperSize As Sizes, ByVal orientation As Orientations)
            ' Enable double buffering for GDI+
            SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            SetStyle(ControlStyles.DoubleBuffer, True)
            SetStyle(ControlStyles.UserPaint, True)

            ' Force redrawing when resizing
            SetStyle(ControlStyles.ResizeRedraw, True)

            Select Case orientation
                Case Orientations.Portrait
                    Select Case paperSize
                        Case Sizes.A3
                            myWidth = 297
                            myHeight = 420
                        Case Sizes.A4
                            myWidth = 210
                            myHeight = 297
                        Case Sizes.A5
                            myWidth = 148
                            myHeight = 210
                        Case Sizes.Executive
                            myWidth = 184.1
                            myHeight = 266.7
                        Case Sizes.Legal
                            myWidth = 215.9
                            myHeight = 355.6
                        Case Sizes.Letter
                            myWidth = 215.9
                            myHeight = 279.4
                    End Select
                Case Orientations.Landscape
                    Select Case paperSize
                        Case Sizes.A3
                            myHeight = 297
                            myWidth = 420
                        Case Sizes.A4
                            myHeight = 210
                            myWidth = 297
                        Case Sizes.A5
                            myHeight = 148
                            myWidth = 210
                        Case Sizes.Executive
                            myHeight = 184.1
                            myWidth = 266.7
                        Case Sizes.Legal
                            myHeight = 215.9
                            myWidth = 355.6
                        Case Sizes.Letter
                            myHeight = 215.9
                            myWidth = 279.4
                    End Select

                    Designer.Preferences.Init()
                    myScenario = New Constructs.Scenario
            End Select
        End Sub

        Public Sub New()
            Me.New(Sizes.A4, Orientations.Landscape)
        End Sub

#End Region

#Region " Enums "

        Public Enum Orientations
            Portrait = 0
            Landscape
        End Enum

        Public Enum Sizes
            A3
            A4
            A5
            Letter
            Legal
            Executive
        End Enum

#End Region

#Region " Event Handlers "

        Protected Sub Node_SelectionStateChanged(ByVal sender As ISelectable, ByVal e As Graphics.Classes.GraphicsEventArgs)
            Dim arrList As New ArrayList
            For Each nd As Graphics.Nodes.Node In myScenario.Nodes
                If nd.IsSelected Then arrList.Add(nd)
            Next

            ApplicationForm.myProperties.SelectedObjects = arrList.ToArray()
        End Sub

#End Region

#Region " Implementation Members "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     The Width of the paper in mm
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	30/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private myWidth As Single
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     The Height of the paper in mm
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	30/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private myHeight As Single
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Multiplier to convert the mm to pixels
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	30/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Const ToPixel As Single = 960 / 254
        Protected myScenario As ArktosII.Constructs.Scenario
        Protected myScale As Single = 1.0
        Protected selectionRectangle As Rectangle

        Private clickPoint As Point
        Private prevPoint As Point
        Private isMoving As Boolean = False
        Private isDragging As Boolean = False

        Protected currentPoint As Point
        Protected currentRectangle As Rectangle
        Protected clickedNode As ArktosII.Graphics.Nodes.Node

        Private isMouseDown As Boolean = False
        Private XDown, YDown As Integer
        Private OldX, OldY As Integer
        Private isMouseMoving As Boolean = False

#End Region

#Region " Overrides "

        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)

            If e.Button = MouseButtons.Left Then
                Dim node As Graphics.Nodes.Node

                clickPoint = New Point(e.X, e.Y)
                prevPoint = New Point(e.X, e.Y)

                Select Case ParentDrawingSurface.DrawingType
                    Case DrawingSurface.DrawingTypes.Conceptual
                        Select Case ApplicationForm.ActiveConceptualTool
                            Case frmMain.ConceptualTools.Pointer
                                ' Find the top-most node at the point
                                For Each nd As Graphics.Nodes.Node In myScenario.Nodes
                                    If nd.IsAt(e.X, e.Y) Then
                                        node = nd
                                    End If
                                Next

                                If Not node Is Nothing Then
                                    If ApplicationForm.ActiveFlags = frmMain.Flags.None Then
                                        If SelectedNodes.ContainsValue(node) Then
                                            ' Do Nothing
                                        Else
                                            ClearSelection()
                                            AddToSelection(node)

                                            Invalidate() : Update()
                                        End If
                                    End If
                                    If ApplicationForm.ActiveFlags And frmMain.Flags.Ctrl Then
                                        AddToSelection(node)
                                    ElseIf ApplicationForm.ActiveFlags And frmMain.Flags.Shift Then
                                        RemoveFromSelection(node)
                                    End If

                                    ' Create the rectangle based on the selected items
                                    selectionRectangle = HighlightSelection(Me.CreateGraphics)
                                    currentRectangle = selectionRectangle

                                    ' Store the clicked node to retrieve it later
                                    clickedNode = node

                                    ' Store the coordinates of the click
                                    XDown = e.X
                                    YDown = e.Y

                                    ' Store the coordinates of the click as old coordinates
                                    OldX = e.X
                                    OldY = e.Y
                                Else
                                    ClearSelection()
                                    isDragging = True
                                    isMouseDown = True
                                    XDown = e.X
                                    YDown = e.Y
                                    isMouseMoving = False
                                End If
                            Case frmMain.ConceptualTools.Attribute
                                MessageBox.Show("Attribute Window")
                                node = New Constructs.Conceptual.Attribute
                                AddNewNode(node, e.X, e.Y)
                            Case frmMain.ConceptualTools.Concept
                                MessageBox.Show("Concept Window")
                                node = New Constructs.Conceptual.Concept
                                AddNewNode(node, e.X, e.Y)
                            Case frmMain.ConceptualTools.ETLConstraint
                                MessageBox.Show("ETL Constraint Window")
                                node = New Constructs.Conceptual.Constraint
                                AddNewNode(node, e.X, e.Y)
                            Case frmMain.ConceptualTools.Note
                                MessageBox.Show("Note Window")
                                node = New Constructs.Conceptual.Note
                                AddNewNode(node, e.X, e.Y)
                            Case frmMain.ConceptualTools.Provider
                                MessageBox.Show("Provider Window")
                            Case frmMain.ConceptualTools.Transformation
                                MessageBox.Show("Transformation Window")
                                node = New Constructs.Conceptual.Transformation
                                AddNewNode(node, e.X, e.Y)
                        End Select

                        ApplicationForm.ResetConceptualTool()
                    Case DrawingSurface.DrawingTypes.Detail

                    Case DrawingSurface.DrawingTypes.Logical
                        Select Case ApplicationForm.ActiveLogicalTool
                            Case frmMain.LogicalTools.Pointer
                                ' Find the top-most node at the point
                                For Each nd As Graphics.Nodes.Node In myScenario.Nodes
                                    If nd.IsAt(e.X, e.Y) Then
                                        node = nd
                                    End If
                                Next

                                ' Find the top-most node at the point
                                For Each nd As Graphics.Nodes.Node In myScenario.Nodes
                                    If nd.IsAt(e.X, e.Y) Then
                                        node = nd
                                    End If
                                Next

                                If Not node Is Nothing Then
                                    If ApplicationForm.ActiveFlags = frmMain.Flags.None Then
                                        ClearSelection()
                                        AddToSelection(node)
                                    End If
                                    If ApplicationForm.ActiveFlags And frmMain.Flags.Ctrl Then
                                        AddToSelection(node)
                                    ElseIf ApplicationForm.ActiveFlags And frmMain.Flags.Shift Then
                                        RemoveFromSelection(node)
                                    End If
                                    isMoving = True
                                Else
                                    ClearSelection()
                                    ' Drawing the selection frame
                                    isDragging = True
                                    Dim rect As New Rectangle( _
                                        New Point(Math.Min(prevPoint.X, clickPoint.X), Math.Min(prevPoint.Y, clickPoint.Y)), _
                                        New Size(Math.Abs(prevPoint.X - clickPoint.X), Math.Abs(prevPoint.Y - clickPoint.Y)))
                                    ControlPaint.DrawReversibleFrame(RectangleToScreen(rect), Color.Yellow, FrameStyle.Dashed)
                                End If

                            Case frmMain.LogicalTools.Activity
                                MessageBox.Show("Activity Window")
                                node = New Constructs.Logical.Activity
                                AddNewNode(node, e.X, e.Y)
                            Case frmMain.LogicalTools.Attribute
                                MessageBox.Show("Attribute Window")
                                node = New Constructs.Logical.Attribute
                                AddNewNode(node, e.X, e.Y)
                            Case frmMain.LogicalTools.Constant
                                MessageBox.Show("Constant Window")
                                node = New Constructs.Logical.Constant
                                AddNewNode(node, e.X, e.Y)
                            Case frmMain.LogicalTools.DataType
                                MessageBox.Show("DataType Window")
                                node = New Constructs.Logical.DataType
                                AddNewNode(node, e.X, e.Y)
                            Case frmMain.LogicalTools.FunctionType
                                MessageBox.Show("FunctionType Window")
                                node = New Constructs.Logical.FunctionType
                                AddNewNode(node, e.X, e.Y)
                            Case frmMain.LogicalTools.LogicalFunction
                                MessageBox.Show("Logical Function Window")
                                node = New Constructs.Logical.Functions
                                AddNewNode(node, e.X, e.Y)
                            Case frmMain.LogicalTools.Note
                                MessageBox.Show("Note Window")
                                node = New Constructs.Logical.Note
                                AddNewNode(node, e.X, e.Y)
                            Case frmMain.LogicalTools.Parameter
                                MessageBox.Show("Parameter Window")
                                node = New Constructs.Logical.Parameter
                                AddNewNode(node, e.X, e.Y)
                            Case frmMain.LogicalTools.RecordSet
                                MessageBox.Show("RecordSet Window")
                                node = New Constructs.Logical.RecordSet
                                AddNewNode(node, e.X, e.Y)
                        End Select

                        ApplicationForm.ResetLogicalTool()
                End Select
            ElseIf e.Button = MouseButtons.Right Then

                ' ------------------------------- T E S T -------------------------------

                Dim ln As New ArktosII.Graphics.Lines.Line(myScenario.Nodes(0), myScenario.Nodes(1), Graphics.Lines.Line.LineTypes.SquareAngle)
                myScenario.Lines.Add(ln)
                Invalidate() : Update()

                ' --------------------------- E N D   T E S T ---------------------------

                ' TODO: ContextMenu
            End If
            Invalidate()
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(e)

            If e.Button = MouseButtons.Left Then
                If isDragging Then

                    isMouseDown = False
                    If isMouseMoving Then
                        RubberRectangle(XDown, YDown, OldX, OldY)
                    End If
                    isMouseMoving = False

                    Dim rect As New Rectangle( _
                        New Point(Math.Min(OldX, XDown), Math.Min(OldY, YDown)), _
                        New Size(Math.Abs(OldX - XDown), Math.Abs(OldY - YDown)))

                    For Each nd As Graphics.Nodes.Node In myScenario.Nodes
                        If rect.IntersectsWith(nd.Rectangle) Then
                            nd.IsSelected = True
                        End If
                    Next

                    HighlightSelection(Me.CreateGraphics)
                    Invalidate() : Update()

                    isDragging = False
                ElseIf isMoving Then
                    isMouseDown = False
                    If isMouseMoving Then
                        RubberRectangle(currentRectangle)
                    End If
                    isMouseMoving = False

                    ' Calculate the offset
                    Dim offset As New PointF(e.X - clickPoint.X, e.Y - clickPoint.Y)

                    ' Move the selected nodes
                    For Each nd As ArktosII.Graphics.Nodes.Node In SelectedNodes()
                        nd.Location = New PointF(nd.Location.X + offset.X, nd.Location.Y + offset.Y)
                    Next

                    ' Redraw the scenario
                    Invalidate() : Update()

                    isMoving = False
                Else
                    If ApplicationForm.ActiveFlags = frmMain.Flags.None Then
                        ClearSelection()
                        AddToSelection(clickedNode)

                        Invalidate() : Update()
                    End If
                End If
            End If
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            ' MyBase.OnMouseMove(e)

            If e.Button = MouseButtons.Left Then
                If isDragging Then
                    If isMouseMoving Then
                        RubberRectangle(XDown, YDown, OldX, OldY)
                    End If
                    RubberRectangle(XDown, YDown, e.X, e.Y)
                    isMouseMoving = True
                    OldX = e.X
                    OldY = e.Y
                Else
                    isMoving = True

                    ' Erase the previous rectangle in case this is not the first time drawing it
                    If isMouseMoving Then
                        RubberRectangle(currentRectangle)
                    End If
                    currentRectangle = New Rectangle( _
                        currentRectangle.X + (e.X - OldX), _
                        currentRectangle.Y + (e.Y - OldY), _
                        currentRectangle.Width, _
                        currentRectangle.Height)
                    RubberRectangle(currentRectangle)
                    isMouseMoving = True
                    OldX = e.X
                    OldY = e.Y
                End If
            End If
        End Sub

        Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(pe)

            pe.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            pe.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias

            ' Draw Lines
            For Each ln As Graphics.Lines.Line In myScenario.Lines
                ln.Draw(pe.Graphics, myScale)
            Next

            ' Draw Nodes
            For Each nd As Graphics.Nodes.Node In myScenario.Nodes
                nd.Draw(pe.Graphics, myScale)
            Next

            HighlightSelection(pe.Graphics)
        End Sub

#End Region

#Region " Private Functions "

        Private Sub ClearSelection()
            For Each nd As Graphics.Nodes.Node In myScenario.Nodes
                nd.IsSelected = False
            Next
            HighlightSelection(Me.CreateGraphics)
        End Sub

        Private Sub AddToSelection(ByVal node As ArktosII.Graphics.Nodes.Node)
            node.IsSelected = True
            HighlightSelection(Me.CreateGraphics)
        End Sub

        Private Sub RemoveFromSelection(ByVal node As ArktosII.Graphics.Nodes.Node)
            node.IsSelected = False
            HighlightSelection(Me.CreateGraphics)
        End Sub

        Private Sub AddNewNode(ByVal nd As Graphics.Nodes.Node, ByVal x As Single, ByVal y As Single)
            nd.Location = New PointF(x - nd.Size.Width / 2, y - nd.Size.Height / 2)
            nd.Font = Me.Font

            ' Add it to the Scenario
            myScenario.Nodes.Add(nd)

            ' Clear the selection and add the new node in a selection by itself
            ClearSelection()
            AddHandler nd.SelectionStateChanged, AddressOf Node_SelectionStateChanged
            AddToSelection(nd)
        End Sub

        Private Sub RubberRectangle(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
            Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromHwnd(Me.Handle)

            Dim rect As New Graphics.Classes.RubberBandRectangle(Graphics.Classes.PenStyles.PS_DOT, Color.Blue, 1)

            rect.DrawXORRectangle(g, x1, y1, x2, y2)
        End Sub

        Private Sub RubberRectangle(ByVal r As Rectangle)
            Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromHwnd(Me.Handle)

            Dim rect As New Graphics.Classes.RubberBandRectangle(Graphics.Classes.PenStyles.PS_SOLID, Color.Black, 2)

            rect.DrawXORRectangle(g, r.X, r.Y, r.X + r.Width, r.Y + r.Height)
        End Sub


#End Region

#Region " Properties "

            ''' -----------------------------------------------------------------------------
            ''' <summary>
            '''     The size of the paper in inches
            ''' </summary>
            ''' <value></value>
            ''' <remarks>
            ''' </remarks>
            ''' <history>
            ''' 	[Finik]	30/1/2005	Created
            ''' </history>
            ''' -----------------------------------------------------------------------------
        Public ReadOnly Property ToInches() As SizeF
            Get
                Return New SizeF(myWidth / 25.4, myHeight / 25.4)
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     The size of the paper in pixels
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	30/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public ReadOnly Property ToPixels() As Size
            Get
                Return New Size(CInt(myWidth * ToPixel), CInt(myHeight * ToPixel))
            End Get
        End Property

        Public ReadOnly Property ApplicationForm() As frmMain
            Get
                Return Me.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent
            End Get
        End Property

        Public ReadOnly Property ParentDrawingSurface() As DrawingSurface
            Get
                Return Me.Parent.Parent.Parent
            End Get
        End Property

#End Region

#Region " Public Functions "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Add's a new node to the paper
        ''' </summary>
        ''' <param name="node">The node to be added</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	31/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub Add(ByVal node As IDrawable)
            If Not node Is Nothing Then
                myScenario.Nodes.Add(node)
            End If
        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Removes a node from the paper
        ''' </summary>
        ''' <param name="node">The node to be removed</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	31/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub Remove(ByVal node As IDrawable)
            If Not node Is Nothing Then
                myScenario.Nodes.Remove(node)
            End If
        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Brings a node to front
        ''' </summary>
        ''' <param name="node">The node to be brought to front</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	31/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Overloads Sub BringToFront(ByVal node As IDrawable)
            If Not node Is Nothing Then
                myScenario.Nodes.Remove(node)
                myScenario.Nodes.Add(node)
            End If
        End Sub
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Sends a node to back
        ''' </summary>
        ''' <param name="node">The node to be sent to back</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	31/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Overloads Sub SendToBack(ByVal node As IDrawable)
            If Not node Is Nothing Then
                myScenario.Nodes.Remove(node)
                myScenario.Nodes.Insert(0, node)
            End If
        End Sub

        Public Function HighlightSelection(ByVal g As System.Drawing.Graphics) As Rectangle
            Dim rect As New Rectangle(5000, 5000, 0, 0)

            ' Find the rectangle around all the selected Nodes
            For Each nd As Graphics.Nodes.Node In myScenario.Nodes
                If nd.IsSelected Then
                    rect.X = Math.Min(rect.X, nd.Location.X)
                    rect.Y = Math.Min(rect.Y, nd.Location.Y)
                End If
            Next

            For Each nd As Graphics.Nodes.Node In myScenario.Nodes
                If nd.IsSelected Then
                    rect.Width = Math.Max(rect.X + rect.Width, nd.Location.X + nd.Size.Width) - rect.X
                    rect.Height = Math.Max(rect.Y + rect.Height, nd.Location.Y + nd.Size.Height) - rect.Y
                End If
            Next

            ' Set the desired offset
            rect.X -= Designer.Preferences.HandleOffset
            rect.Y -= Designer.Preferences.HandleOffset
            rect.Width += 2 * Designer.Preferences.HandleOffset
            rect.Height += 2 * Designer.Preferences.HandleOffset

            Graphics.Classes.Tools.DrawSelectionRectangle(g, rect)

            Return rect
        End Function

        Public Function SelectedNodes() As ArktosII.Constructs.NodeCollection
            Dim nc As New ArktosII.Constructs.NodeCollection

            For Each nd As ArktosII.Graphics.Nodes.Node In myScenario.Nodes
                If nd.IsSelected Then nc.Add(nd)
            Next

            Return nc
        End Function

#End Region

    End Class

End Namespace