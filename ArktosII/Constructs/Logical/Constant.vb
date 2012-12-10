Namespace Constructs.Logical

    Public Class Constant
        Inherits ArktosII.Graphics.Nodes.Logical.ConstantNode

#Region " Implementation Members "
        Private myDescription As String
#End Region

#Region " Constructor "
        Public Sub New()
            MyBase.New()
        End Sub
#End Region

#Region " Properties "

        Public Property Description() As String
            Get
                Description = myDescription
            End Get
            Set(ByVal Value As String)
                myDescription = Value
            End Set
        End Property

#End Region

    End Class

End Namespace
