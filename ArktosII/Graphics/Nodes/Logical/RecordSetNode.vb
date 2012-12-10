Namespace Graphics.Nodes.Logical

    Public Class RecordSetNode
        Inherits ArktosII.Graphics.Nodes.Cylinder

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            LoadPreferences(Designer.Preferences.RecordSet)
        End Sub

#End Region

    End Class

End Namespace