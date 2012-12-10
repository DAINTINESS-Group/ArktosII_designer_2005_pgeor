Imports ArktosII.Graphics.Classes

Namespace Graphics.Nodes

    Public Class Rectangle
        Inherits ArktosII.Graphics.Nodes.Node

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides Function Draw(ByVal g As System.Drawing.Graphics, ByVal scale As Single) As Integer
            Dim myRect As New Drawing.RectangleF(mylocation.X, mylocation.Y, mysize.Width, mysize.Height)
            Dim w As Single = mySize.Width
            Dim h As Single = mySize.Height

            Dim gp As New System.Drawing.Drawing2D.GraphicsPath
            gp.AddRectangle(myRect)
            myRegion = New Region(gp)

            Dim brBack As New System.Drawing.Drawing2D.LinearGradientBrush( _
                myRect, _
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
            g.DrawString(myText, myFont, brText, myRect, sf)
            brText.Dispose()
        End Function

    End Class

End Namespace