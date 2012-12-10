Namespace Graphics.Nodes.Conceptual

    Public Class NoteNode
        Inherits ArktosII.Graphics.Nodes.Note

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            LoadPreferences(Designer.Preferences.Note)
        End Sub

#End Region

    End Class

End Namespace