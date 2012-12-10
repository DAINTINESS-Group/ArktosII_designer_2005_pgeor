Namespace Constructs.Logical

    Public Class Parameter
        Inherits ArktosII.Graphics.Nodes.Logical.ParameterNode

        Public Enum ParameterRoles
            ActivityParameter = 1
            FunctionInput = 2
            FunctionOutput = 4
        End Enum


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

        Public ReadOnly Property ParameterRole() As ParameterRoles
            Get

            End Get
        End Property

#End Region


    End Class

End Namespace
