Namespace Graphics.Nodes.Logical

    Public Class NoteNode
        Inherits ArktosII.Graphics.Nodes.Note

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            LoadPreferences(Designer.Preferences.LogicalNote)
        End Sub

#End Region

    End Class

End Namespace