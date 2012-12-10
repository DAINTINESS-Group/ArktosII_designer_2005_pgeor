Imports ArktosII.Graphics.Classes

Namespace Graphics.Nodes

    Public Class Hexagon
        Inherits ArktosII.Graphics.Nodes.Node

#Region " Constructor "

        Public Sub New()
            MyBase.New()
        End Sub

#End Region

        Public Overrides Function Draw(ByVal g As System.Drawing.Graphics, ByVal scale As Single) As Integer
            Dim w As Single = mySize.Width
            Dim h As Single = mySize.Height
            Dim r As Single = w / 2

            Dim gp As New System.Drawing.Drawing2D.GraphicsPath
            Dim points() As PointF = New PointF() { _
                New PointF(Location.X, Location.Y + h / 2), _
                New PointF(Location.X + w / 4, Location.Y + h / 2 - r * Math.Sin(Math.PI / 3)), _
                New PointF(Location.X + 3 * w / 4, Location.Y + h / 2 - r * Math.Sin(Math.PI / 3)), _
                New PointF(Location.X + w, Location.Y + h / 2), _
                New PointF(Location.X + 3 * w / 4, Location.Y + h / 2 + r * Math.Sin(Math.PI / 3)), _
                New PointF(Location.X + w / 4, Location.Y + h / 2 + r * Math.Sin(Math.PI / 3)) _
            }
            gp.AddPolygon(points)

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