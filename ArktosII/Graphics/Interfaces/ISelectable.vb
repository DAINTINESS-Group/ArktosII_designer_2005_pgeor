Namespace Graphics.Interfaces

    Public Interface ISelectable

        Property IsSelected() As Boolean
        Event SelectionStateChanged(ByVal sender As ISelectable, ByVal ge As Graphics.Classes.GraphicsEventArgs)
        Sub OnSelectionStateChanged(ByVal ge As Graphics.Classes.GraphicsEventArgs)

    End Interface

End Namespace