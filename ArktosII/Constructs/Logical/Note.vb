Namespace Constructs.Logical

    Public Class Note
        Inherits ArktosII.Graphics.Nodes.Logical.NoteNode

#Region " Constructor "
        Public Sub New()
            MyBase.New()
        End Sub
#End Region

#Region " Implementation Members "
        Private myDescription As String
        Private myNote As String
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

        Public Property Note() As String
            Get
                Note = myNote
            End Get
            Set(ByVal Value As String)
                myNote = Value
            End Set
        End Property

#End Region


    End Class

End Namespace