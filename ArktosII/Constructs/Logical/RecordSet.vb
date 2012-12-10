Namespace Constructs.Logical

    Public Class RecordSet
        Inherits ArktosII.Graphics.Nodes.Logical.RecordSetNode

#Region " Implementation Members "
        Private myDescription As String
        Private myAttributes As Schema
        Private myDataSource As String
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

        Public Property DataSource() As String
            Get
                DataSource = myDataSource
            End Get
            Set(ByVal Value As String)
                myDataSource = Value
            End Set
        End Property

        Public ReadOnly Property Attributes() As Schema
            Get
                Attributes = myAttributes
            End Get
        End Property

#End Region

#Region " Schema Alterations "

        Public Function AddAttribute(ByVal Name As String, ByVal DataType As Constructs.Types.ReposDataType) As Attribute
            Throw New InvalidRecordSetAttributeException
        End Function

        Public Sub RemoveAttribute(ByVal Id As Guid)
            Throw New ArktosII.Constructs.InvalidSchemaNodeException
        End Sub

#End Region


    End Class

End Namespace
