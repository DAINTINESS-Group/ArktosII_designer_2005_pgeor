Namespace Designer.Forms

    Public Class frmPreferences
        Inherits Designer.Forms.Base.frmGeneric

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
        Friend WithEvents ListView1 As System.Windows.Forms.ListView
        Friend WithEvents cIcon As System.Windows.Forms.ColumnHeader
        Friend WithEvents cName As System.Windows.Forms.ColumnHeader
        Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "Colors"}, 0)
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPreferences))
            Me.ListView1 = New System.Windows.Forms.ListView
            Me.cIcon = New System.Windows.Forms.ColumnHeader
            Me.cName = New System.Windows.Forms.ColumnHeader
            Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
            Me.SuspendLayout()
            '
            'ListView1
            '
            Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cIcon, Me.cName})
            Me.ListView1.Cursor = System.Windows.Forms.Cursors.Hand
            Me.ListView1.Dock = System.Windows.Forms.DockStyle.Left
            Me.ListView1.FullRowSelect = True
            Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            Me.ListView1.HideSelection = False
            Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
            Me.ListView1.LargeImageList = Me.ImageList1
            Me.ListView1.Location = New System.Drawing.Point(8, 8)
            Me.ListView1.Name = "ListView1"
            Me.ListView1.Size = New System.Drawing.Size(144, 292)
            Me.ListView1.SmallImageList = Me.ImageList1
            Me.ListView1.TabIndex = 2
            Me.ListView1.View = System.Windows.Forms.View.Details
            '
            'cIcon
            '
            Me.cIcon.Text = ""
            Me.cIcon.Width = 40
            '
            'cName
            '
            Me.cName.Text = ""
            Me.cName.Width = 100
            '
            'ImageList1
            '
            Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
            Me.ImageList1.ImageSize = New System.Drawing.Size(32, 32)
            Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
            '
            'frmPreferences
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(562, 352)
            Me.Controls.Add(Me.ListView1)
            Me.DockPadding.All = 8
            Me.Name = "frmPreferences"
            Me.Controls.SetChildIndex(Me.ListView1, 0)
            Me.ResumeLayout(False)

        End Sub

#End Region

    End Class

End Namespace