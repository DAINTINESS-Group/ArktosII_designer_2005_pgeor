Namespace Graphics.Nodes.Logical

    Public Class ConstantNode
        Inherits ArktosII.Graphics.Nodes.Cycle

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            LoadPreferences(Designer.Preferences.Constant)
        End Sub

#End Region

    End Class

End Namespace