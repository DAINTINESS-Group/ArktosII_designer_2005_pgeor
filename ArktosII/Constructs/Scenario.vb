Imports ArktosII.Constructs

Namespace Constructs

    Public Class Scenario

#Region " Constructor "

        Public Sub New()
            MyBase.New()

            myNodes = New NodeCollection
            myLines = New LineCollection
        End Sub

#End Region

#Region " Implementation Members "

        Protected myNodes As NodeCollection
        Protected myLines As LineCollection

#End Region

#Region " Properties "

        Public ReadOnly Property Nodes() As NodeCollection
            Get
                Return myNodes
            End Get
        End Property

        Public ReadOnly Property Lines() As LineCollection
            Get
                Return myLines
            End Get
        End Property

#End Region

    End Class

End Namespace