Imports ArktosII.Graphics.Classes

Namespace Graphics.Nodes

    Public Class Triangle
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
            Dim points() As PointF = New PointF() { _
                New PointF(myLocation.X, myLocation.Y), _
                New PointF(mylocation.X + w, myLocation.Y + h / 2), _
                New PointF(mylocation.X, mylocation.Y + h), _
                New PointF(myLocation.X, myLocation.Y) _
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