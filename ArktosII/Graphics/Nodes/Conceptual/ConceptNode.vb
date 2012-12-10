Namespace Graphics.Nodes.Conceptual

    Public Class ConceptNode
        Inherits ArktosII.Graphics.Nodes.Rectangle

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            LoadPreferences(Designer.Preferences.Concept)
        End Sub

#End Region

    End Class

End Namespace