Namespace Constructs.Logical

    Public Class DataType
        Inherits ArktosII.Graphics.Nodes.Logical.DataTypeNode

#Region " Constructor "
        Public Sub New()
            MyBase.New()
        End Sub
#End Region

#Region " Implementation Members "
        Private myDescription As String
        Private myDataType As ArktosII.Constructs.Types.ReposDataType
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

        Public Property DataType() As ArktosII.Constructs.Types.ReposDataType
            Get
                DataType = myDataType
            End Get
            Set(ByVal Value As ArktosII.Constructs.Types.ReposDataType)
                myDataType = Value
            End Set
        End Property

#End Region

    End Class

End Namespace
