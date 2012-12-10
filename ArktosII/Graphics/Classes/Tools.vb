Namespace Graphics.Classes

    Module Tools

#Region " Private "

        Private Sub DrawSelectionHandle(ByVal g As System.Drawing.Graphics, ByVal x As Integer, ByVal y As Integer)
            Dim br As New SolidBrush(Designer.Preferences.HandleBackColor)
            Dim HandleHalfWidth As Integer = (Designer.Preferences.HandleWidth - 1) / 2
            g.FillRectangle(br, x - HandleHalfWidth, y - HandleHalfWidth, Designer.Preferences.HandleWidth, Designer.Preferences.HandleWidth)
            br.Dispose()

            Dim p As New Pen(Designer.Preferences.HandleForeColor)
            g.DrawRectangle(p, x - HandleHalfWidth, y - HandleHalfWidth, Designer.Preferences.HandleWidth, Designer.Preferences.HandleWidth)
            p.Dispose()
        End Sub

#End Region

#Region " Public "

        Public Sub DrawSelectionRectangle(ByVal g As System.Drawing.Graphics, ByVal rect As Rectangle)
            DrawSelectionHandle(g, rect.X, rect.Y)
            DrawSelectionHandle(g, rect.X + rect.Width / 2, rect.Y)
            DrawSelectionHandle(g, rect.X + rect.Width, rect.Y)

            DrawSelectionHandle(g, rect.X, rect.Y + rect.Height / 2)
            DrawSelectionHandle(g, rect.X + rect.Width, rect.Y + rect.Height / 2)

            DrawSelectionHandle(g, rect.X, rect.Y + rect.Height)
            DrawSelectionHandle(g, rect.X + rect.Width / 2, rect.Y + rect.Height)
            DrawSelectionHandle(g, rect.X + rect.Width, rect.Y + rect.Height)
        End Sub

        Public Function DarkenColor(ByVal clr As Color) As Color
            Dim factor As Integer = 32

            Dim cl As Color
            cl = Color.FromArgb(Math.Max(clr.R - factor, 0), Math.Max(clr.G - factor, 0), Math.Max(clr.B - factor, 0))

            Return cl
        End Function

#End Region

    End Module

End Namespace