
Public Class GenericException
    Inherits System.Exception

    Private Const GenericMessage = "ARKTOSII" & vbCrLf & "Unspecified Exception"

    Public Sub New()
        MyBase.New(GenericMessage)
    End Sub

    Public Sub New(ByVal auxMessage As String)
        MyBase.New(GenericMessage + " - " + auxMessage)
    End Sub

    Public Sub New(ByVal auxMessage As String, ByVal inner As Exception)
        MyBase.New(GenericMessage + " - " + auxMessage, inner)
    End Sub

End Class

