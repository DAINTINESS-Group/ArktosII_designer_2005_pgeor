Namespace Graphics.Classes

    Public Class PrintProperties

        Public Sub New()

        End Sub

        Public Enum PageSizes
            A0 = 0
            A1
            A2
            A3
            A4
            A5
            Letter
            Legal
        End Enum

        Public Enum PageOrientation
            Portrait = 0
            Landscape
        End Enum

        Public Shared Empty As PrintProperties

    End Class

End Namespace