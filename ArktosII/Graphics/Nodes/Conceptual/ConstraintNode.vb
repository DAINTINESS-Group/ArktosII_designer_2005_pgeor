Namespace Graphics.Nodes.Conceptual

    Public Class ConstraintNode
        Inherits ArktosII.Graphics.Nodes.Hexagon

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            LoadPreferences(Designer.Preferences.ETLConstraint)
        End Sub

#End Region

    End Class

End Namespace