Namespace Graphics.Nodes.Logical

    Public Class FunctionNode
        Inherits ArktosII.Graphics.Nodes.Rectangle

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            LoadPreferences(Designer.Preferences.LogicalFunction)
        End Sub

#End Region

    End Class

End Namespace