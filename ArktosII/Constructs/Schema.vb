Namespace Constructs

    Public Class Schema
        Inherits NodeCollection

#Region " Constructor "

        Public Sub New()
            myGuid = Guid.NewGuid
        End Sub

#End Region

#Region " Implementation Members "

        Protected myGuid As Guid

#End Region

#Region " Properties "

        Public ReadOnly Property ID() As String
            Get
                Return myGuid.ToString()
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub Expand(ByVal pos As System.Drawing.Point)
            'Expand Everything In myNodes at Position pos
        End Sub

#End Region

#Region " Schema Alterations "
        ' Edw mpainoun vasikoi elegxoi (unique name)
        Public Overloads Sub Add(ByVal node As ArktosII.Graphics.Nodes.Node)
            Throw New InvalidSchemaNodeException
            MyBase.Add(node)
        End Sub

        Public Overloads Sub Remove(ByVal ID As Guid)
            MyBase.Remove(ID)
        End Sub

        Public Overloads Sub Remove(ByVal value As Graphics.Nodes.Node)
            MyBase.Remove(value)
        End Sub
#End Region

    End Class

End Namespace