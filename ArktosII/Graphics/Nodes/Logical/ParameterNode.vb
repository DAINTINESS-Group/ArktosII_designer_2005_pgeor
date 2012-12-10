Namespace Graphics.Nodes.Logical

    Public Class ParameterNode
        Inherits ArktosII.Graphics.Nodes.Rectangle

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            LoadPreferences(Designer.Preferences.Parameter)
        End Sub

#End Region

    End Class

End Namespace