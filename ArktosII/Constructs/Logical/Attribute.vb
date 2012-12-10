Namespace Constructs.Logical

    Public Class Attribute
        Inherits ArktosII.Graphics.Nodes.Logical.AttributeNode

        Public Enum AttributeRoles
            ActivityInput = 1
            ActivityOutput = 2
            ActivityParameter = 4
            RecordsetAttribute = 8
        End Enum


#Region " Constructor "
        Public Sub New()
            MyBase.New()
        End Sub
#End Region

#Region " Implementation Members "
        Private myDescription As String
        Private myDataType As ArktosII.Constructs.Types.ReposDataType
        'Private myAttributeRole As AttributeRoles  'Specifies Whether it is an Act_IN, Act_Out,... . 
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

        Public ReadOnly Property AttributeRole() As AttributeRoles
            Get

            End Get
        End Property

#End Region

    End Class

End Namespace
