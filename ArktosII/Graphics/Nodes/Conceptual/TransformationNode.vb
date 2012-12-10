Namespace Graphics.Nodes.Conceptual

    Public Class TransformationNode
        Inherits ArktosII.Graphics.Nodes.Hexagon

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            LoadPreferences(Designer.Preferences.Transformation)
        End Sub

#End Region

    End Class

End Namespace