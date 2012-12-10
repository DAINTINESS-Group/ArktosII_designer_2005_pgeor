Imports ArktosII.Graphics.Classes

Namespace Graphics.Interfaces

    ''' -----------------------------------------------------------------------------
    ''' Project	 : ArktosII
    ''' Interface	 : Graphics.IDrawable
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     Interface to be implemented by all classes that need to be drawn on 
    '''     screen.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Finik]	23/1/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Interface IDrawable

#Region " Colors "

        Property ForeColor() As Color
        Event ForeColorChanged(ByVal sender As IDrawable, ByVal ge As GraphicsEventArgs)
        Sub OnForeColorChanged(ByVal ge As GraphicsEventArgs)

        Property BackColor() As Color
        Event BackColorChanged(ByVal sender As IDrawable, ByVal ge As GraphicsEventArgs)
        Sub OnBackColorChanged(ByVal ge As GraphicsEventArgs)

#End Region

#Region " Drawing "

        Property PenSize() As Integer
        Event PenSizeChanged(ByVal sender As IDrawable, ByVal ge As GraphicsEventArgs)
        Sub OnPenSizeChanged(ByVal ge As GraphicsEventArgs)

#End Region

#Region " Size "
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Property to get/set the size of the object.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	23/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Property Size() As System.Drawing.SizeF
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Event to be raised when the size of this object has changed
        ''' </summary>
        ''' <param name="sender">The object that raises the event</param>
        ''' <param name="ge">Arguments for the raised event</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	23/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Event SizeChanged(ByVal sender As IDrawable, ByVal ge As GraphicsEventArgs)
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     This function should be used for raising the SizeChanged event.
        ''' </summary>
        ''' <param name="ge">Arguments to be used while raising the event</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	23/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Sub OnSizeChanged(ByVal ge As GraphicsEventArgs)
#End Region

#Region " Location "
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Property to get/set the location of the object on the host object.  As
        '''     location we use the lower left point of the object.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	23/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Property Location() As System.Drawing.PointF
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Event to be raised when the location of the object has changed
        ''' </summary>
        ''' <param name="sender">The object that raises the event</param>
        ''' <param name="ge">Arguments for the raised event</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	23/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Event LocationChanged(ByVal sender As IDrawable, ByVal ge As GraphicsEventArgs)
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     This function should be used for raising the LocationChanged event.
        ''' </summary>
        ''' <param name="ge">Arguments to be used while raising the event</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	23/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Sub OnLocationChanged(ByVal ge As GraphicsEventArgs)
#End Region

#Region " Text "

        Property Text() As String
        Event TextChanged(ByVal sender As IDrawable, ByVal ge As GraphicsEventArgs)
        Sub OnTextChanged(ByVal ge As GraphicsEventArgs)

        Property Font() As Font
        Event FontChanged(ByVal sender As IDrawable, ByVal ge As GraphicsEventArgs)
        Sub OnFontChanged(ByVal ge As GraphicsEventArgs)

#End Region

#Region " Misc Properties & Functions "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     The basic function used to draw the object
        ''' </summary>
        ''' <param name="g">The graphics object to be used for the drawing of the
        '''     object</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	23/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Function Draw(ByVal g As System.Drawing.Graphics, ByVal scale As Single) As Integer
        Function IsAt(ByVal x As Integer, ByVal y As Integer) As Boolean
        Function GetBounds() As Rectangle
        Property IsVisible() As Boolean

#End Region

    End Interface

End Namespace