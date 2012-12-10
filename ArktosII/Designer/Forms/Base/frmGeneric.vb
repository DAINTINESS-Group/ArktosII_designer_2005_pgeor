Namespace Designer.Forms.Base

    ''' -----------------------------------------------------------------------------
    ''' Project	 : ArktosII
    ''' Class	 : Designer.Forms.Base.frmGeneric
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     The base form for all the dialog boxes of the application.  Changing this
    '''     should commit the changes all over the application.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Finik]	28/1/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class frmGeneric
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
        Friend WithEvents pButtons As System.Windows.Forms.Panel
        Friend WithEvents vsProvider As Skybound.VisualStyles.VisualStyleProvider
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents pSeparator As System.Windows.Forms.Panel
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents grbSeparator As System.Windows.Forms.GroupBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGeneric))
            Me.pButtons = New System.Windows.Forms.Panel
            Me.btnCancel = New System.Windows.Forms.Button
            Me.vsProvider = New Skybound.VisualStyles.VisualStyleProvider
            Me.pSeparator = New System.Windows.Forms.Panel
            Me.btnOK = New System.Windows.Forms.Button
            Me.grbSeparator = New System.Windows.Forms.GroupBox
            Me.pButtons.SuspendLayout()
            Me.SuspendLayout()
            '
            'pButtons
            '
            Me.pButtons.Controls.Add(Me.btnOK)
            Me.pButtons.Controls.Add(Me.pSeparator)
            Me.pButtons.Controls.Add(Me.btnCancel)
            Me.pButtons.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pButtons.DockPadding.Top = 8
            Me.pButtons.Location = New System.Drawing.Point(8, 236)
            Me.pButtons.Name = "pButtons"
            Me.pButtons.Size = New System.Drawing.Size(458, 36)
            Me.pButtons.TabIndex = 0
            Me.vsProvider.SetVisualStyleSupport(Me.pButtons, True)
            '
            'btnCancel
            '
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
            Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
            Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnCancel.Location = New System.Drawing.Point(378, 8)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(80, 28)
            Me.btnCancel.TabIndex = 0
            Me.btnCancel.Text = "&Cancel"
            Me.vsProvider.SetVisualStyleSupport(Me.btnCancel, True)
            '
            'pSeparator
            '
            Me.pSeparator.Dock = System.Windows.Forms.DockStyle.Right
            Me.pSeparator.Location = New System.Drawing.Point(370, 8)
            Me.pSeparator.Name = "pSeparator"
            Me.pSeparator.Size = New System.Drawing.Size(8, 28)
            Me.pSeparator.TabIndex = 1
            Me.vsProvider.SetVisualStyleSupport(Me.pSeparator, True)
            '
            'btnOK
            '
            Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
            Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
            Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnOK.Location = New System.Drawing.Point(290, 8)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(80, 28)
            Me.btnOK.TabIndex = 2
            Me.btnOK.Text = "&OK"
            Me.vsProvider.SetVisualStyleSupport(Me.btnOK, True)
            '
            'grbSeparator
            '
            Me.grbSeparator.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.grbSeparator.Location = New System.Drawing.Point(8, 228)
            Me.grbSeparator.Name = "grbSeparator"
            Me.grbSeparator.Size = New System.Drawing.Size(458, 8)
            Me.grbSeparator.TabIndex = 1
            Me.grbSeparator.TabStop = False
            Me.vsProvider.SetVisualStyleSupport(Me.grbSeparator, False)
            '
            'frmGeneric
            '
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(474, 280)
            Me.ControlBox = False
            Me.Controls.Add(Me.grbSeparator)
            Me.Controls.Add(Me.pButtons)
            Me.DockPadding.All = 8
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmGeneric"
            Me.ShowInTaskbar = False
            Me.Text = "frmGeneric"
            Me.pButtons.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

    End Class

End Namespace