Imports ArktosII.Graphics.Classes

Namespace Graphics.Interfaces

    ''' -----------------------------------------------------------------------------
    ''' Project	 : ArktosII
    ''' Interface	 : Graphics.Interfaces.IMovable
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     Interface to be implemented by all classes that need to be moved.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Finik]	25/1/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Interface IMovable

        Sub OnMouseMoved(ByVal sender As Object, ByVal e As MouseEventArgs)

    End Interface

End Namespace