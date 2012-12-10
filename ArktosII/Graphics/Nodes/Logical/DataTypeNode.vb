Namespace Graphics.Nodes.Logical

    Public Class DataTypeNode
        Inherits ArktosII.Graphics.Nodes.Ellipse

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            LoadPreferences(Designer.Preferences.DataType)
        End Sub

#End Region

    End Class

End Namespace