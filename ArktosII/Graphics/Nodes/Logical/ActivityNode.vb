Namespace Graphics.Nodes.Logical

    Public Class ActivityNode
        Inherits ArktosII.Graphics.Nodes.Triangle

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            LoadPreferences(Designer.Preferences.Activity)
        End Sub

#End Region

    End Class

End Namespace