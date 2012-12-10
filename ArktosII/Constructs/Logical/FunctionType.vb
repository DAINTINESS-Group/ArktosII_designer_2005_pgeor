Namespace Constructs.Logical

    Public Class FunctionType
        Inherits ArktosII.Graphics.Nodes.Logical.FunctionTypeNode

#Region " Constructor "
        Public Sub New()
            MyBase.New()
        End Sub
#End Region

#Region " Implementation Members "
        Private myDescription As String
        Private myFunctionType As ArktosII.Constructs.Types.ReposFunctionType
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

        Public Property DataType() As ArktosII.Constructs.Types.ReposFunctionType
            Get
                DataType = myFunctionType
            End Get
            Set(ByVal Value As ArktosII.Constructs.Types.ReposFunctionType)
                myFunctionType = Value
            End Set
        End Property

#End Region


    End Class

End Namespace
