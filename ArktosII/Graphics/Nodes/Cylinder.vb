Imports ArktosII.Graphics.Classes

Namespace Graphics.Nodes

    Public Class Cylinder
        Inherits ArktosII.Graphics.Nodes.Node

#Region " Constructor "

        Public Sub New()
            MyBase.New()
        End Sub

#End Region

        Public Overrides Function Draw(ByVal g As System.Drawing.Graphics, ByVal scale As Single) As Integer
            Dim w As Single = mySize.Width
            Dim h As Single = mySize.Height

            Dim gp As New System.Drawing.Drawing2D.GraphicsPath
            gp.AddArc(mylocation.X, mylocation.Y, w, h / 3, 0, -180)
            gp.AddLine(mylocation.X, mylocation.Y + h / 6, mylocation.X, mylocation.Y + 5 * h / 6)
            gp.AddArc(mylocation.X, mylocation.Y + 2 * h / 3, w, h / 3, 180, -180)
            gp.AddLine(mylocation.X + w, mylocation.Y + 5 * h / 6, mylocation.X + w, mylocation.Y + h / 6)

            myRegion = New Region(gp)

            Dim brBack As New System.Drawing.Drawing2D.LinearGradientBrush( _
                myRegion.GetBounds(g), _
                DirectCast(IIf(Designer.Preferences.DrawGradient, Graphics.Classes.Tools.DarkenColor(myBackcolor), myBackColor), Color), _
                mybackcolor, _
                Drawing2D.LinearGradientMode.Vertical)
            g.FillRegion(brBack, myRegion)
            brBack.Dispose()

            Dim penFrame As New Pen(myForecolor, myPenSize)
            g.DrawPath(penFrame, gp)
            g.DrawArc(penFrame, mylocation.X, mylocation.Y, w, h / 3, 0, 180)
            penFrame.Dispose()

            Dim brText As New SolidBrush(myForecolor)
            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
            g.DrawString(myText, myFont, brText, myRegion.GetBounds(g), sf)
            brText.Dispose()
        End Function

    End Class

End Namespace

