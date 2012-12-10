Namespace Graphics.Nodes.Logical

    Public Class AttributeNode
        Inherits ArktosII.Graphics.Nodes.Ellipse

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            LoadPreferences(Designer.Preferences.LogicalAttribute)
        End Sub

#End Region

    End Class

End Namespace