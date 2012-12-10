Imports TD.SandDock

Namespace Designer.Forms.Base

    Public Class frmProjectSDI
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents vsProvider As Skybound.VisualStyles.VisualStyleProvider
        Friend WithEvents dcContainer As TD.SandDock.DocumentContainer
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.vsProvider = New Skybound.VisualStyles.VisualStyleProvider
            Me.dcContainer = New TD.SandDock.DocumentContainer
            Me.SuspendLayout()
            '
            'dcContainer
            '
            Me.dcContainer.Guid = New System.Guid("a17215b1-f21d-4b62-a2e4-e7f8b92f04a8")
            Me.dcContainer.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400)
            Me.dcContainer.Location = New System.Drawing.Point(0, 0)
            Me.dcContainer.Manager = Nothing
            Me.dcContainer.Name = "dcContainer"
            Me.dcContainer.Size = New System.Drawing.Size(600, 422)
            Me.dcContainer.TabIndex = 0
            '
            'frmProjectSDI
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(600, 422)
            Me.Controls.Add(Me.dcContainer)
            Me.Name = "frmProjectSDI"
            Me.Text = "frmProjectSDI"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " Public Functions "

        Public Function ActiveDocument() As DockControl
            Return dcContainer.ActiveDocument
        End Function

        Public Sub AddScenario(ByVal type As ArktosII.Designer.Controls.DrawingSurface.DrawingTypes)
            Dim dc As New TD.SandDock.DockControl
            Dim ds As Designer.Controls.DrawingSurface
            Select Case type
                Case Designer.Controls.DrawingSurface.DrawingTypes.Conceptual
                    dc.Text = "Conceptual"
                    ds = New Designer.Controls.DrawingSurface(Designer.Controls.DrawingSurface.DrawingTypes.Conceptual)
                Case Designer.Controls.DrawingSurface.DrawingTypes.Detail
                    dc.Text = "Detail"
                    ds = New Designer.Controls.DrawingSurface(Designer.Controls.DrawingSurface.DrawingTypes.Detail)
                Case Designer.Controls.DrawingSurface.DrawingTypes.Logical
                    dc.Text = "Logical"
                    ds = New Designer.Controls.DrawingSurface(Designer.Controls.DrawingSurface.DrawingTypes.Logical)
            End Select
            ds.Dock = DockStyle.Fill
            dc.Controls.Add(ds)
            Me.dcContainer.AddDocument(dc)
        End Sub

#End Region

    End Class

End Namespace