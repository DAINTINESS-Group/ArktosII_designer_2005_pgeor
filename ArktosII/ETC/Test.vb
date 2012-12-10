Public Class Test
    Sub New()
        Dim act As New ArktosII.Constructs.Logical.Activity
        Dim attr As New ArktosII.Constructs.Logical.Attribute
        act.AddInput(attr)

        Dim sr As System.IO.StreamReader = New System.IO.StreamReader("TestFile.txt")

    End Sub
End Class
