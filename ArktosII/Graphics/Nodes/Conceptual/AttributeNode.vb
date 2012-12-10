Namespace Graphics.Nodes.Conceptual

    Public Class AttributeNode
        Inherits ArktosII.Graphics.Nodes.Ellipse

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            LoadPreferences(Designer.Preferences.Attribute)
        End Sub

#End Region

    End Class

End Namespace