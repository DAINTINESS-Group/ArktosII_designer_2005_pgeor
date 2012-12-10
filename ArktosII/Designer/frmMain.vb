Imports System.Drawing
Namespace Designer

    ''' -----------------------------------------------------------------------------
    ''' Project	 : ArktosII
    ''' Class	 : Designer.frmMain
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     The main form of the program (Designer)
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Finik]	25/1/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class frmMain
        Inherits System.Windows.Forms.Form

#Region " Public Shared Sub Main "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     This function creates a new instance of the designer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	25/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared Sub Main()
            Skybound.VisualStyles.VisualStyleProvider.EnableVisualStyles()
            Application.Run(New frmMain)
        End Sub

#End Region

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            cmbZoom.ComboBox.SelectedIndex = 3
            AddHandler cmbZoom.ComboBox.SelectedIndexChanged, AddressOf cmbZoom_SelectedIndexChanged
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
        Friend WithEvents DockingManager As TD.SandDock.SandDockManager
        Friend WithEvents leftSandDock As TD.SandDock.DockContainer
        Friend WithEvents rightSandDock As TD.SandDock.DockContainer
        Friend WithEvents bottomSandDock As TD.SandDock.DockContainer
        Friend WithEvents topSandDock As TD.SandDock.DockContainer
        Friend WithEvents ToolbarManager As TD.SandBar.SandBarManager
        Friend WithEvents leftSandBarDock As TD.SandBar.ToolBarContainer
        Friend WithEvents rightSandBarDock As TD.SandBar.ToolBarContainer
        Friend WithEvents bottomSandBarDock As TD.SandBar.ToolBarContainer
        Friend WithEvents topSandBarDock As TD.SandBar.ToolBarContainer
        Friend WithEvents MenuBarItem1 As TD.SandBar.MenuBarItem
        Friend WithEvents MenuBarItem2 As TD.SandBar.MenuBarItem
        Friend WithEvents MenuBarItem3 As TD.SandBar.MenuBarItem
        Friend WithEvents MenuBarItem4 As TD.SandBar.MenuBarItem
        Friend WithEvents MenuBarItem5 As TD.SandBar.MenuBarItem
        Friend WithEvents mbMenu As TD.SandBar.MenuBar
        Friend WithEvents tbStandard As TD.SandBar.ToolBar
        Friend WithEvents btnNewScenario As TD.SandBar.ButtonItem
        Friend WithEvents btnOpenScenario As TD.SandBar.ButtonItem
        Friend WithEvents btnPrint As TD.SandBar.ButtonItem
        Friend WithEvents btnSave As TD.SandBar.ButtonItem
        Friend WithEvents mnuFileNew As TD.SandBar.MenuButtonItem
        Friend WithEvents mnuFileOpen As TD.SandBar.MenuButtonItem
        Friend WithEvents mnuFileSave As TD.SandBar.MenuButtonItem
        Friend WithEvents mnuFileExit As TD.SandBar.MenuButtonItem
        Friend WithEvents mnuFileClose As TD.SandBar.MenuButtonItem
        Friend WithEvents mnuFileSaveAs As TD.SandBar.MenuButtonItem
        Friend WithEvents cmbZoom As TD.SandBar.ComboBoxItem
        Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
        Friend WithEvents myProperties As System.Windows.Forms.PropertyGrid
        Friend WithEvents NavigationBar1 As Divelements.Navisight.NavigationBar
        Friend WithEvents dcToolbox As TD.SandDock.DockControl
        Friend WithEvents ncConceptual As Divelements.Navisight.NavigationCategory
        Friend WithEvents ncLogical As Divelements.Navisight.NavigationCategory
        Friend WithEvents dcDatabaseExplorer As TD.SandDock.DockControl
        Friend WithEvents dcProperties As TD.SandDock.DockControl
        Friend WithEvents dcScenarioExplorer As TD.SandDock.DockControl
        Friend WithEvents bbConceptual As Divelements.Navisight.ButtonBar
        Friend WithEvents nbPointer As Divelements.Navisight.NavigationButton
        Friend WithEvents nbConcept As Divelements.Navisight.NavigationButton
        Friend WithEvents nbTransformation As Divelements.Navisight.NavigationButton
        Friend WithEvents nbETLConstraint As Divelements.Navisight.NavigationButton
        Friend WithEvents nbNote As Divelements.Navisight.NavigationButton
        Friend WithEvents nbProvider As Divelements.Navisight.NavigationButton
        Friend WithEvents nbLogicalPointer As Divelements.Navisight.NavigationButton
        Friend WithEvents nbActivity As Divelements.Navisight.NavigationButton
        Friend WithEvents nbLogicalAttribute As Divelements.Navisight.NavigationButton
        Friend WithEvents nbDataType As Divelements.Navisight.NavigationButton
        Friend WithEvents nbConstant As Divelements.Navisight.NavigationButton
        Friend WithEvents bbLogical As Divelements.Navisight.ButtonBar
        Friend WithEvents nbFunction As Divelements.Navisight.NavigationButton
        Friend WithEvents nbFunctionType As Divelements.Navisight.NavigationButton
        Friend WithEvents nbLogicalNote As Divelements.Navisight.NavigationButton
        Friend WithEvents nbParameter As Divelements.Navisight.NavigationButton
        Friend WithEvents nbRecordSet As Divelements.Navisight.NavigationButton
        Friend WithEvents nbAttribute As Divelements.Navisight.NavigationButton
        Friend WithEvents mnuAddConceptual As TD.SandBar.MenuButtonItem
        Friend WithEvents mnuAddLogical As TD.SandBar.MenuButtonItem
        Friend WithEvents MenuBarItem6 As TD.SandBar.MenuBarItem
        Friend WithEvents MenuButtonItem1 As TD.SandBar.MenuButtonItem
        Friend WithEvents MenuButtonItem2 As TD.SandBar.MenuButtonItem
        Friend WithEvents MenuButtonItem3 As TD.SandBar.MenuButtonItem
        Friend WithEvents sbStatus As TD.SandBar.StatusBar
        Friend WithEvents sbiStatus As TD.SandBar.StatusBarItem
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
            Me.vsProvider = New Skybound.VisualStyles.VisualStyleProvider
            Me.DockingManager = New TD.SandDock.SandDockManager
            Me.leftSandDock = New TD.SandDock.DockContainer
            Me.dcToolbox = New TD.SandDock.DockControl
            Me.NavigationBar1 = New Divelements.Navisight.NavigationBar
            Me.ncConceptual = New Divelements.Navisight.NavigationCategory
            Me.bbConceptual = New Divelements.Navisight.ButtonBar
            Me.nbPointer = New Divelements.Navisight.NavigationButton
            Me.nbConcept = New Divelements.Navisight.NavigationButton
            Me.nbAttribute = New Divelements.Navisight.NavigationButton
            Me.nbTransformation = New Divelements.Navisight.NavigationButton
            Me.nbNote = New Divelements.Navisight.NavigationButton
            Me.nbETLConstraint = New Divelements.Navisight.NavigationButton
            Me.nbProvider = New Divelements.Navisight.NavigationButton
            Me.ncLogical = New Divelements.Navisight.NavigationCategory
            Me.bbLogical = New Divelements.Navisight.ButtonBar
            Me.nbLogicalPointer = New Divelements.Navisight.NavigationButton
            Me.nbActivity = New Divelements.Navisight.NavigationButton
            Me.nbLogicalAttribute = New Divelements.Navisight.NavigationButton
            Me.nbConstant = New Divelements.Navisight.NavigationButton
            Me.nbDataType = New Divelements.Navisight.NavigationButton
            Me.nbFunction = New Divelements.Navisight.NavigationButton
            Me.nbFunctionType = New Divelements.Navisight.NavigationButton
            Me.nbLogicalNote = New Divelements.Navisight.NavigationButton
            Me.nbParameter = New Divelements.Navisight.NavigationButton
            Me.nbRecordSet = New Divelements.Navisight.NavigationButton
            Me.dcDatabaseExplorer = New TD.SandDock.DockControl
            Me.rightSandDock = New TD.SandDock.DockContainer
            Me.dcProperties = New TD.SandDock.DockControl
            Me.myProperties = New System.Windows.Forms.PropertyGrid
            Me.dcScenarioExplorer = New TD.SandDock.DockControl
            Me.bottomSandDock = New TD.SandDock.DockContainer
            Me.topSandDock = New TD.SandDock.DockContainer
            Me.ToolbarManager = New TD.SandBar.SandBarManager
            Me.leftSandBarDock = New TD.SandBar.ToolBarContainer
            Me.rightSandBarDock = New TD.SandBar.ToolBarContainer
            Me.bottomSandBarDock = New TD.SandBar.ToolBarContainer
            Me.topSandBarDock = New TD.SandBar.ToolBarContainer
            Me.mbMenu = New TD.SandBar.MenuBar
            Me.MenuBarItem1 = New TD.SandBar.MenuBarItem
            Me.mnuFileNew = New TD.SandBar.MenuButtonItem
            Me.mnuFileOpen = New TD.SandBar.MenuButtonItem
            Me.mnuFileSave = New TD.SandBar.MenuButtonItem
            Me.mnuFileSaveAs = New TD.SandBar.MenuButtonItem
            Me.mnuFileClose = New TD.SandBar.MenuButtonItem
            Me.mnuFileExit = New TD.SandBar.MenuButtonItem
            Me.MenuBarItem2 = New TD.SandBar.MenuBarItem
            Me.MenuBarItem3 = New TD.SandBar.MenuBarItem
            Me.MenuBarItem6 = New TD.SandBar.MenuBarItem
            Me.MenuButtonItem1 = New TD.SandBar.MenuButtonItem
            Me.mnuAddConceptual = New TD.SandBar.MenuButtonItem
            Me.MenuButtonItem2 = New TD.SandBar.MenuButtonItem
            Me.mnuAddLogical = New TD.SandBar.MenuButtonItem
            Me.MenuButtonItem3 = New TD.SandBar.MenuButtonItem
            Me.MenuBarItem4 = New TD.SandBar.MenuBarItem
            Me.MenuBarItem5 = New TD.SandBar.MenuBarItem
            Me.tbStandard = New TD.SandBar.ToolBar
            Me.btnNewScenario = New TD.SandBar.ButtonItem
            Me.btnOpenScenario = New TD.SandBar.ButtonItem
            Me.btnSave = New TD.SandBar.ButtonItem
            Me.btnPrint = New TD.SandBar.ButtonItem
            Me.cmbZoom = New TD.SandBar.ComboBoxItem
            Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
            Me.sbStatus = New TD.SandBar.StatusBar
            Me.sbiStatus = New TD.SandBar.StatusBarItem
            Me.leftSandDock.SuspendLayout()
            Me.dcToolbox.SuspendLayout()
            Me.NavigationBar1.SuspendLayout()
            Me.ncConceptual.SuspendLayout()
            Me.ncLogical.SuspendLayout()
            Me.rightSandDock.SuspendLayout()
            Me.dcProperties.SuspendLayout()
            Me.topSandBarDock.SuspendLayout()
            CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DockingManager
            '
            Me.DockingManager.OwnerForm = Me
            '
            'leftSandDock
            '
            Me.leftSandDock.Controls.Add(Me.dcToolbox)
            Me.leftSandDock.Controls.Add(Me.dcDatabaseExplorer)
            Me.leftSandDock.Dock = System.Windows.Forms.DockStyle.Left
            Me.leftSandDock.Guid = New System.Guid("63dd0b93-44f7-4ce7-931e-f949d39e1038")
            Me.leftSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400, System.Windows.Forms.Orientation.Horizontal, New TD.SandDock.LayoutSystemBase() {New TD.SandDock.ControlLayoutSystem(220, 498, New TD.SandDock.DockControl() {Me.dcToolbox, Me.dcDatabaseExplorer}, Me.dcToolbox)})
            Me.leftSandDock.Location = New System.Drawing.Point(0, 49)
            Me.leftSandDock.Manager = Me.DockingManager
            Me.leftSandDock.Name = "leftSandDock"
            Me.leftSandDock.Size = New System.Drawing.Size(224, 498)
            Me.leftSandDock.TabIndex = 1
            '
            'dcToolbox
            '
            Me.dcToolbox.Closable = False
            Me.dcToolbox.Controls.Add(Me.NavigationBar1)
            Me.dcToolbox.Guid = New System.Guid("f5fe36c7-def0-425a-8e3d-7581c6371295")
            Me.dcToolbox.Location = New System.Drawing.Point(0, 18)
            Me.dcToolbox.Name = "dcToolbox"
            Me.dcToolbox.Size = New System.Drawing.Size(220, 457)
            Me.dcToolbox.TabImage = CType(resources.GetObject("dcToolbox.TabImage"), System.Drawing.Image)
            Me.dcToolbox.TabIndex = 2
            Me.dcToolbox.Text = "Toolbox"
            '
            'NavigationBar1
            '
            Me.NavigationBar1.Controls.Add(Me.ncConceptual)
            Me.NavigationBar1.Controls.Add(Me.ncLogical)
            Me.NavigationBar1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.NavigationBar1.Location = New System.Drawing.Point(0, 0)
            Me.NavigationBar1.Name = "NavigationBar1"
            Me.NavigationBar1.SelectedCategory = Me.ncConceptual
            Me.NavigationBar1.Size = New System.Drawing.Size(220, 457)
            Me.NavigationBar1.TabIndex = 1
            Me.NavigationBar1.Text = "NavigationBar1"
            '
            'ncConceptual
            '
            Me.ncConceptual.Controls.Add(Me.bbConceptual)
            Me.ncConceptual.Location = New System.Drawing.Point(0, 20)
            Me.ncConceptual.MinimumHeaderSize = 20
            Me.ncConceptual.Name = "ncConceptual"
            Me.ncConceptual.Size = New System.Drawing.Size(220, 417)
            Me.ncConceptual.TabIndex = 0
            Me.ncConceptual.Text = "Conceptual"
            '
            'bbConceptual
            '
            Me.bbConceptual.AutoScrollMinSize = New System.Drawing.Size(0, 266)
            Me.bbConceptual.Buttons.AddRange(New Divelements.Navisight.NavigationButton() {Me.nbPointer, Me.nbConcept, Me.nbAttribute, Me.nbTransformation, Me.nbNote, Me.nbETLConstraint, Me.nbProvider})
            Me.bbConceptual.ButtonSpacing = 4
            Me.bbConceptual.Cursor = System.Windows.Forms.Cursors.Hand
            Me.bbConceptual.Dock = System.Windows.Forms.DockStyle.Fill
            Me.bbConceptual.Location = New System.Drawing.Point(0, 0)
            Me.bbConceptual.Name = "bbConceptual"
            Me.bbConceptual.Size = New System.Drawing.Size(220, 417)
            Me.bbConceptual.TabIndex = 0
            Me.bbConceptual.TextAlignment = Divelements.Navisight.ButtonTextAlignment.Side
            '
            'nbPointer
            '
            Me.nbPointer.Checked = True
            Me.nbPointer.Text = "Pointer"
            '
            'nbConcept
            '
            Me.nbConcept.Image = CType(resources.GetObject("nbConcept.Image"), System.Drawing.Image)
            Me.nbConcept.Text = "Concept"
            '
            'nbAttribute
            '
            Me.nbAttribute.Image = CType(resources.GetObject("nbAttribute.Image"), System.Drawing.Image)
            Me.nbAttribute.Text = "Attribute"
            '
            'nbTransformation
            '
            Me.nbTransformation.Image = CType(resources.GetObject("nbTransformation.Image"), System.Drawing.Image)
            Me.nbTransformation.Text = "Transformation"
            '
            'nbNote
            '
            Me.nbNote.Image = CType(resources.GetObject("nbNote.Image"), System.Drawing.Image)
            Me.nbNote.Text = "Note"
            '
            'nbETLConstraint
            '
            Me.nbETLConstraint.Image = CType(resources.GetObject("nbETLConstraint.Image"), System.Drawing.Image)
            Me.nbETLConstraint.Text = "ETL Constraint"
            '
            'nbProvider
            '
            Me.nbProvider.Image = CType(resources.GetObject("nbProvider.Image"), System.Drawing.Image)
            Me.nbProvider.Text = "Provider"
            '
            'ncLogical
            '
            Me.ncLogical.Controls.Add(Me.bbLogical)
            Me.ncLogical.Location = New System.Drawing.Point(0, 211)
            Me.ncLogical.MinimumHeaderSize = 20
            Me.ncLogical.Name = "ncLogical"
            Me.ncLogical.Size = New System.Drawing.Size(220, 244)
            Me.ncLogical.TabIndex = 1
            Me.ncLogical.Text = "Logical"
            '
            'bbLogical
            '
            Me.bbLogical.AutoScrollMinSize = New System.Drawing.Size(0, 237)
            Me.bbLogical.Buttons.AddRange(New Divelements.Navisight.NavigationButton() {Me.nbLogicalPointer, Me.nbActivity, Me.nbLogicalAttribute, Me.nbConstant, Me.nbDataType, Me.nbFunction, Me.nbFunctionType, Me.nbLogicalNote, Me.nbParameter, Me.nbRecordSet})
            Me.bbLogical.ButtonSpacing = 4
            Me.bbLogical.Cursor = System.Windows.Forms.Cursors.Hand
            Me.bbLogical.Dock = System.Windows.Forms.DockStyle.Fill
            Me.bbLogical.Location = New System.Drawing.Point(0, 0)
            Me.bbLogical.Name = "bbLogical"
            Me.bbLogical.Size = New System.Drawing.Size(220, 244)
            Me.bbLogical.TabIndex = 0
            Me.bbLogical.TextAlignment = Divelements.Navisight.ButtonTextAlignment.Side
            '
            'nbLogicalPointer
            '
            Me.nbLogicalPointer.Checked = True
            Me.nbLogicalPointer.Text = "Pointer"
            '
            'nbActivity
            '
            Me.nbActivity.Text = "Activity"
            '
            'nbLogicalAttribute
            '
            Me.nbLogicalAttribute.Text = "Attribute"
            '
            'nbConstant
            '
            Me.nbConstant.Text = "Constant"
            '
            'nbDataType
            '
            Me.nbDataType.Text = "Data Type"
            '
            'nbFunction
            '
            Me.nbFunction.Text = "Function"
            '
            'nbFunctionType
            '
            Me.nbFunctionType.Text = "Function Type"
            '
            'nbLogicalNote
            '
            Me.nbLogicalNote.Image = CType(resources.GetObject("nbLogicalNote.Image"), System.Drawing.Image)
            Me.nbLogicalNote.Text = "Note"
            '
            'nbParameter
            '
            Me.nbParameter.Text = "Parameter"
            '
            'nbRecordSet
            '
            Me.nbRecordSet.Text = "Record Set"
            '
            'dcDatabaseExplorer
            '
            Me.dcDatabaseExplorer.Closable = False
            Me.dcDatabaseExplorer.Guid = New System.Guid("2f59fc56-0a4d-4da2-bae0-a4919106d300")
            Me.dcDatabaseExplorer.Location = New System.Drawing.Point(0, 18)
            Me.dcDatabaseExplorer.Name = "dcDatabaseExplorer"
            Me.dcDatabaseExplorer.Size = New System.Drawing.Size(220, 457)
            Me.dcDatabaseExplorer.TabIndex = 3
            Me.dcDatabaseExplorer.Text = "Database Explorer"
            '
            'rightSandDock
            '
            Me.rightSandDock.Controls.Add(Me.dcProperties)
            Me.rightSandDock.Controls.Add(Me.dcScenarioExplorer)
            Me.rightSandDock.Dock = System.Windows.Forms.DockStyle.Right
            Me.rightSandDock.DockingManager = TD.SandDock.DockingManager.Whidbey
            Me.rightSandDock.Guid = New System.Guid("1101cceb-b74b-43d0-b3e6-3f68122868d1")
            Me.rightSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400, System.Windows.Forms.Orientation.Horizontal, New TD.SandDock.LayoutSystemBase() {New TD.SandDock.ControlLayoutSystem(220, 498, New TD.SandDock.DockControl() {Me.dcProperties, Me.dcScenarioExplorer}, Me.dcProperties)})
            Me.rightSandDock.Location = New System.Drawing.Point(568, 49)
            Me.rightSandDock.Manager = Me.DockingManager
            Me.rightSandDock.Name = "rightSandDock"
            Me.rightSandDock.Size = New System.Drawing.Size(224, 498)
            Me.rightSandDock.TabIndex = 2
            '
            'dcProperties
            '
            Me.dcProperties.Closable = False
            Me.dcProperties.Controls.Add(Me.myProperties)
            Me.dcProperties.Guid = New System.Guid("aa3f879b-8fb9-4c30-92aa-5d490bbd38ad")
            Me.dcProperties.Location = New System.Drawing.Point(4, 18)
            Me.dcProperties.Name = "dcProperties"
            Me.dcProperties.Size = New System.Drawing.Size(220, 457)
            Me.dcProperties.TabImage = CType(resources.GetObject("dcProperties.TabImage"), System.Drawing.Image)
            Me.dcProperties.TabIndex = 0
            Me.dcProperties.Text = "Properties"
            Me.dcProperties.Visible = False
            '
            'myProperties
            '
            Me.myProperties.CommandsVisibleIfAvailable = True
            Me.myProperties.Dock = System.Windows.Forms.DockStyle.Fill
            Me.myProperties.HelpVisible = False
            Me.myProperties.LargeButtons = False
            Me.myProperties.LineColor = System.Drawing.SystemColors.ScrollBar
            Me.myProperties.Location = New System.Drawing.Point(0, 0)
            Me.myProperties.Name = "myProperties"
            Me.myProperties.Size = New System.Drawing.Size(220, 457)
            Me.myProperties.TabIndex = 0
            Me.myProperties.Text = "PropertyGrid1"
            Me.myProperties.ToolbarVisible = False
            Me.myProperties.ViewBackColor = System.Drawing.SystemColors.Window
            Me.myProperties.ViewForeColor = System.Drawing.SystemColors.WindowText
            '
            'dcScenarioExplorer
            '
            Me.dcScenarioExplorer.Closable = False
            Me.dcScenarioExplorer.Guid = New System.Guid("792f30f8-19ba-4f92-a564-f161357c41fe")
            Me.dcScenarioExplorer.Location = New System.Drawing.Point(4, 18)
            Me.dcScenarioExplorer.Name = "dcScenarioExplorer"
            Me.dcScenarioExplorer.Size = New System.Drawing.Size(220, 457)
            Me.dcScenarioExplorer.TabImage = CType(resources.GetObject("dcScenarioExplorer.TabImage"), System.Drawing.Image)
            Me.dcScenarioExplorer.TabIndex = 1
            Me.dcScenarioExplorer.Text = "Scenario Explorer"
            '
            'bottomSandDock
            '
            Me.bottomSandDock.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.bottomSandDock.Guid = New System.Guid("1f2427cd-f291-4290-8b40-d0bfd5a598fd")
            Me.bottomSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400)
            Me.bottomSandDock.Location = New System.Drawing.Point(0, 547)
            Me.bottomSandDock.Manager = Me.DockingManager
            Me.bottomSandDock.Name = "bottomSandDock"
            Me.bottomSandDock.Size = New System.Drawing.Size(792, 0)
            Me.bottomSandDock.TabIndex = 3
            '
            'topSandDock
            '
            Me.topSandDock.Dock = System.Windows.Forms.DockStyle.Top
            Me.topSandDock.Guid = New System.Guid("07ec2af7-f3bf-43dd-8694-228dc07a306b")
            Me.topSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400)
            Me.topSandDock.Location = New System.Drawing.Point(0, 49)
            Me.topSandDock.Manager = Me.DockingManager
            Me.topSandDock.Name = "topSandDock"
            Me.topSandDock.Size = New System.Drawing.Size(792, 0)
            Me.topSandDock.TabIndex = 4
            '
            'ToolbarManager
            '
            Me.ToolbarManager.OwnerForm = Me
            '
            'leftSandBarDock
            '
            Me.leftSandBarDock.Dock = System.Windows.Forms.DockStyle.Left
            Me.leftSandBarDock.Guid = New System.Guid("36943405-6c53-45e5-aee9-816fe69c4826")
            Me.leftSandBarDock.Location = New System.Drawing.Point(0, 49)
            Me.leftSandBarDock.Manager = Me.ToolbarManager
            Me.leftSandBarDock.Name = "leftSandBarDock"
            Me.leftSandBarDock.Size = New System.Drawing.Size(0, 498)
            Me.leftSandBarDock.TabIndex = 5
            '
            'rightSandBarDock
            '
            Me.rightSandBarDock.Dock = System.Windows.Forms.DockStyle.Right
            Me.rightSandBarDock.Guid = New System.Guid("4bbb5dd4-9754-4bf3-b69f-ccf18f3ba2f9")
            Me.rightSandBarDock.Location = New System.Drawing.Point(792, 49)
            Me.rightSandBarDock.Manager = Me.ToolbarManager
            Me.rightSandBarDock.Name = "rightSandBarDock"
            Me.rightSandBarDock.Size = New System.Drawing.Size(0, 498)
            Me.rightSandBarDock.TabIndex = 6
            '
            'bottomSandBarDock
            '
            Me.bottomSandBarDock.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.bottomSandBarDock.Guid = New System.Guid("7d46812f-258d-4fe8-9589-ed7c01659510")
            Me.bottomSandBarDock.Location = New System.Drawing.Point(0, 547)
            Me.bottomSandBarDock.Manager = Me.ToolbarManager
            Me.bottomSandBarDock.Name = "bottomSandBarDock"
            Me.bottomSandBarDock.Size = New System.Drawing.Size(792, 0)
            Me.bottomSandBarDock.TabIndex = 7
            '
            'topSandBarDock
            '
            Me.topSandBarDock.Controls.Add(Me.mbMenu)
            Me.topSandBarDock.Controls.Add(Me.tbStandard)
            Me.topSandBarDock.Dock = System.Windows.Forms.DockStyle.Top
            Me.topSandBarDock.Guid = New System.Guid("14867062-acc9-4628-b0a5-82d0717fdd0b")
            Me.topSandBarDock.Location = New System.Drawing.Point(0, 0)
            Me.topSandBarDock.Manager = Me.ToolbarManager
            Me.topSandBarDock.Name = "topSandBarDock"
            Me.topSandBarDock.Size = New System.Drawing.Size(792, 49)
            Me.topSandBarDock.TabIndex = 8
            '
            'mbMenu
            '
            Me.mbMenu.Guid = New System.Guid("f5e79fd5-544d-41d5-9d61-1f252cb079b4")
            Me.mbMenu.Items.AddRange(New TD.SandBar.ToolbarItemBase() {Me.MenuBarItem1, Me.MenuBarItem2, Me.MenuBarItem3, Me.MenuBarItem6, Me.MenuBarItem4, Me.MenuBarItem5})
            Me.mbMenu.Location = New System.Drawing.Point(2, 0)
            Me.mbMenu.Name = "mbMenu"
            Me.mbMenu.OwnerForm = Me
            Me.mbMenu.Renderer = New TD.SandBar.WhidbeyRenderer
            Me.mbMenu.Size = New System.Drawing.Size(790, 23)
            Me.mbMenu.TabIndex = 0
            Me.mbMenu.Text = "MenuBar1"
            '
            'MenuBarItem1
            '
            Me.MenuBarItem1.Items.AddRange(New TD.SandBar.ToolbarItemBase() {Me.mnuFileNew, Me.mnuFileOpen, Me.mnuFileSave, Me.mnuFileSaveAs, Me.mnuFileClose, Me.mnuFileExit})
            Me.MenuBarItem1.Text = "&File"
            '
            'mnuFileNew
            '
            Me.mnuFileNew.Image = CType(resources.GetObject("mnuFileNew.Image"), System.Drawing.Image)
            Me.mnuFileNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN
            Me.mnuFileNew.Text = "New Scenario ..."
            '
            'mnuFileOpen
            '
            Me.mnuFileOpen.Image = CType(resources.GetObject("mnuFileOpen.Image"), System.Drawing.Image)
            Me.mnuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
            Me.mnuFileOpen.Text = "Open Scenario ..."
            '
            'mnuFileSave
            '
            Me.mnuFileSave.BeginGroup = True
            Me.mnuFileSave.Image = CType(resources.GetObject("mnuFileSave.Image"), System.Drawing.Image)
            Me.mnuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
            Me.mnuFileSave.Text = "Save"
            '
            'mnuFileSaveAs
            '
            Me.mnuFileSaveAs.Image = CType(resources.GetObject("mnuFileSaveAs.Image"), System.Drawing.Image)
            Me.mnuFileSaveAs.Text = "Save As ..."
            '
            'mnuFileClose
            '
            Me.mnuFileClose.BeginGroup = True
            Me.mnuFileClose.Image = CType(resources.GetObject("mnuFileClose.Image"), System.Drawing.Image)
            Me.mnuFileClose.Shortcut = System.Windows.Forms.Shortcut.CtrlF4
            Me.mnuFileClose.Text = "Close"
            '
            'mnuFileExit
            '
            Me.mnuFileExit.BeginGroup = True
            Me.mnuFileExit.Image = CType(resources.GetObject("mnuFileExit.Image"), System.Drawing.Image)
            Me.mnuFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4
            Me.mnuFileExit.Text = "Exit"
            '
            'MenuBarItem2
            '
            Me.MenuBarItem2.Text = "&Edit"
            '
            'MenuBarItem3
            '
            Me.MenuBarItem3.Text = "&View"
            '
            'MenuBarItem6
            '
            Me.MenuBarItem6.Items.AddRange(New TD.SandBar.ToolbarItemBase() {Me.MenuButtonItem1, Me.MenuButtonItem2, Me.MenuButtonItem3})
            Me.MenuBarItem6.Text = "&Project"
            '
            'MenuButtonItem1
            '
            Me.MenuButtonItem1.Items.AddRange(New TD.SandBar.ToolbarItemBase() {Me.mnuAddConceptual})
            Me.MenuButtonItem1.Text = "&Conceptual"
            '
            'mnuAddConceptual
            '
            Me.mnuAddConceptual.Text = "New ..."
            '
            'MenuButtonItem2
            '
            Me.MenuButtonItem2.Items.AddRange(New TD.SandBar.ToolbarItemBase() {Me.mnuAddLogical})
            Me.MenuButtonItem2.Text = "&Logical"
            '
            'mnuAddLogical
            '
            Me.mnuAddLogical.Text = "New ..."
            '
            'MenuButtonItem3
            '
            Me.MenuButtonItem3.BeginGroup = True
            Me.MenuButtonItem3.Text = "Project Properties"
            '
            'MenuBarItem4
            '
            Me.MenuBarItem4.MdiWindowList = True
            Me.MenuBarItem4.Text = "&Window"
            '
            'MenuBarItem5
            '
            Me.MenuBarItem5.Text = "&Help"
            '
            'tbStandard
            '
            Me.tbStandard.DockLine = 1
            Me.tbStandard.Guid = New System.Guid("5dbd11c8-f39a-4f8f-a2cc-227f5ed3815b")
            Me.tbStandard.Items.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnNewScenario, Me.btnOpenScenario, Me.btnSave, Me.btnPrint, Me.cmbZoom})
            Me.tbStandard.Location = New System.Drawing.Point(2, 23)
            Me.tbStandard.Name = "tbStandard"
            Me.tbStandard.Renderer = New TD.SandBar.WhidbeyRenderer
            Me.tbStandard.Size = New System.Drawing.Size(183, 26)
            Me.tbStandard.TabIndex = 1
            Me.tbStandard.Text = "ToolBar1"
            '
            'btnNewScenario
            '
            Me.btnNewScenario.Image = CType(resources.GetObject("btnNewScenario.Image"), System.Drawing.Image)
            '
            'btnOpenScenario
            '
            Me.btnOpenScenario.Image = CType(resources.GetObject("btnOpenScenario.Image"), System.Drawing.Image)
            '
            'btnSave
            '
            Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
            '
            'btnPrint
            '
            Me.btnPrint.BeginGroup = True
            Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
            '
            'cmbZoom
            '
            Me.cmbZoom.BeginGroup = True
            Me.cmbZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbZoom.Items.AddRange(New Object() {"200 %", "150 %", "100 %", "75 %", "50 %"})
            Me.cmbZoom.MinimumControlWidth = 50
            '
            'StatusBarPanel1
            '
            Me.StatusBarPanel1.Text = "StatusBarPanel1"
            '
            'sbStatus
            '
            Me.sbStatus.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.sbStatus.Guid = New System.Guid("6f980481-63e7-4529-ba5e-892d5da67df6")
            Me.sbStatus.Items.AddRange(New TD.SandBar.ToolbarItemBase() {Me.sbiStatus})
            Me.sbStatus.Location = New System.Drawing.Point(0, 547)
            Me.sbStatus.Name = "sbStatus"
            Me.sbStatus.OwnerForm = Me
            Me.sbStatus.Renderer = New TD.SandBar.WhidbeyRenderer
            Me.sbStatus.ShowGripper = False
            Me.sbStatus.Size = New System.Drawing.Size(792, 19)
            Me.sbStatus.StretchItem = Me.sbiStatus
            Me.sbStatus.TabIndex = 11
            Me.sbStatus.Tearable = False
            Me.sbStatus.Text = "StatusBar1"
            '
            'sbiStatus
            '
            Me.sbiStatus.Text = ""
            '
            'frmMain
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(792, 566)
            Me.Controls.Add(Me.leftSandDock)
            Me.Controls.Add(Me.rightSandDock)
            Me.Controls.Add(Me.bottomSandDock)
            Me.Controls.Add(Me.topSandDock)
            Me.Controls.Add(Me.leftSandBarDock)
            Me.Controls.Add(Me.rightSandBarDock)
            Me.Controls.Add(Me.bottomSandBarDock)
            Me.Controls.Add(Me.topSandBarDock)
            Me.Controls.Add(Me.sbStatus)
            Me.IsMdiContainer = True
            Me.KeyPreview = True
            Me.Name = "frmMain"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Arktos II v2.0"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.leftSandDock.ResumeLayout(False)
            Me.dcToolbox.ResumeLayout(False)
            Me.NavigationBar1.ResumeLayout(False)
            Me.ncConceptual.ResumeLayout(False)
            Me.ncLogical.ResumeLayout(False)
            Me.rightSandDock.ResumeLayout(False)
            Me.dcProperties.ResumeLayout(False)
            Me.topSandBarDock.ResumeLayout(False)
            CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " Implementation Members "

        Public Enum Flags
            None = 0
            Ctrl = 1
            Shift = 2
            Alt = 4
        End Enum

        Protected ActiveFlag As Flags = Flags.None

        Public Enum ConceptualTools
            Pointer = -1
            Concept
            Attribute
            Transformation
            ETLConstraint
            Note
            Provider
        End Enum

        Public Enum LogicalTools
            Pointer = -1
            Activity
            Attribute
            Constant
            DataType
            LogicalFunction
            FunctionType
            Note
            Parameter
            RecordSet
        End Enum

#End Region

#Region " Event Handlers "

#Region " Form "

        Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Set all the docked toolboxes to collapsed
            dcToolbox.LayoutSystem.Collapsed = True
            dcProperties.LayoutSystem.Collapsed = True
            dcScenarioExplorer.LayoutSystem.Collapsed = True
            dcDatabaseExplorer.LayoutSystem.Collapsed = True
        End Sub

#End Region

#Region " Toolbars "

#Region " Standard "

        Private Sub btnNewScenario_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewScenario.Activate
            NewProject()
        End Sub

        Private Sub cmbZoom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim doc As TD.SandDock.DockControl = DirectCast(Me.ActiveMdiChild, Forms.Base.frmProjectSDI).ActiveDocument
            If Not doc Is Nothing Then
                Dim zoom As Single
                Select Case cmbZoom.ComboBox.SelectedIndex
                    Case 0 ' 200%
                        zoom = 2.0
                    Case 1 ' 150%
                        zoom = 1.5
                    Case 2 ' 100%
                        zoom = 1.0
                    Case 3 ' 75%
                        zoom = 0.75
                    Case 4 ' 50%
                        zoom = 0.5
                End Select

                DirectCast(doc.Controls(0), Controls.DrawingSurface).SetZoomFactor(zoom)
            End If
        End Sub

#End Region

#End Region

#Region " Toolbox "

#Region " Conceptual "

        Private Sub nbConcept_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbConcept.Activate
            ResetConceptualTool(False)
            nbConcept.Checked = True
        End Sub

        Private Sub nbAttribute_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbAttribute.Activate
            ResetConceptualTool(False)
            nbAttribute.Checked = True
        End Sub

        Private Sub nbTransformation_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbTransformation.Activate
            ResetConceptualTool(False)
            nbTransformation.Checked = True
        End Sub

        Private Sub nbNote_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbNote.Activate
            ResetConceptualTool(False)
            nbNote.Checked = True
        End Sub

        Private Sub nbETLConstraint_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbETLConstraint.Activate
            ResetConceptualTool(False)
            nbETLConstraint.Checked = True
        End Sub

        Private Sub nbProvider_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbProvider.Activate
            ResetConceptualTool(False)
            nbProvider.Checked = True
        End Sub

        Private Sub nbPointer_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbPointer.Activate
            ResetConceptualTool(True)
        End Sub

#End Region

#Region " Logical "

        Private Sub nbActivity_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbActivity.Activate
            ResetLogicalTool(False)
            nbActivity.Checked = True
        End Sub

        Private Sub nbLogicalAttribute_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbLogicalAttribute.Activate
            ResetLogicalTool(False)
            nbLogicalAttribute.Checked = True
        End Sub

        Private Sub nbConstant_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbConstant.Activate
            ResetLogicalTool(False)
            nbConstant.Checked = True
        End Sub

        Private Sub nbDataType_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbDataType.Activate
            ResetLogicalTool(False)
            nbDataType.Checked = True
        End Sub

        Private Sub nbFunction_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbFunction.Activate
            ResetLogicalTool(False)
            nbFunction.Checked = True
        End Sub

        Private Sub nbFunctionType_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbFunctionType.Activate
            ResetLogicalTool(False)
            nbFunctionType.Checked = True
        End Sub

        Private Sub nbLogicalNote_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbLogicalNote.Activate
            ResetLogicalTool(False)
            nbLogicalNote.Checked = True
        End Sub

        Private Sub nbParameter_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbParameter.Activate
            ResetLogicalTool(False)
            nbParameter.Checked = True
        End Sub

        Private Sub nbRecordSet_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbRecordSet.Activate
            ResetLogicalTool(False)
            nbRecordSet.Checked = True
        End Sub

        Private Sub nbLogicalPointer_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbLogicalPointer.Activate
            ResetLogicalTool(True)
        End Sub

#End Region

#End Region

#Region " MenuBar "

#Region " File "

        Private Sub mnuFileNew_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNew.Activate
            NewProject()
        End Sub

        Private Sub mnuFileExit_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Activate
            ' TODO: Confirm exit based on saved status of the scenarios.
            Me.Close()
        End Sub

#End Region

#Region " Project "

#Region " Conceptual "

        Private Sub mnuAddConceptual_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddConceptual.Activate
            Dim activeMDI As forms.Base.frmProjectSDI = Me.ActiveMdiChild
            activeMDI.AddScenario(Designer.Controls.DrawingSurface.DrawingTypes.Conceptual)
            mnuAddConceptual.Enabled = False
        End Sub

#End Region

#Region " Logical "

        Private Sub mnuAddLogical_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddLogical.Activate
            Dim activeMDI As forms.Base.frmProjectSDI = Me.ActiveMdiChild
            activeMDI.AddScenario(Designer.Controls.DrawingSurface.DrawingTypes.Logical)
            mnuAddLogical.Enabled = False
        End Sub

#End Region

#End Region

#End Region

#End Region

#Region " Overrides "

        Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
            MyBase.OnKeyDown(e)

            If e.Control Then ActiveFlag = ActiveFlag Or Flags.Ctrl
            If e.Alt Then ActiveFlag = ActiveFlag Or Flags.Alt
            If e.Shift Then ActiveFlag = ActiveFlag Or Flags.Shift
        End Sub

        Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
            MyBase.OnKeyUp(e)

            If e.Control Then ActiveFlag = ActiveFlag Or Flags.Ctrl Else ActiveFlag = ActiveFlag And Not Flags.Ctrl
            If e.Alt Then ActiveFlag = ActiveFlag Or Flags.Alt Else ActiveFlag = ActiveFlag And Not Flags.Alt
            If e.Shift Then ActiveFlag = ActiveFlag Or Flags.Shift Else ActiveFlag = ActiveFlag And Not Flags.Shift
        End Sub

#End Region

#Region " Private Methods "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Creates a new SDI Form containing drawing surfaces for either a
        '''     Conceptual or a Logical or even both Scenarios.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Finik]	28/1/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub NewProject()
            Dim newProject As New Designer.Forms.Base.frmProjectSDI
            newProject.MdiParent = Me
            newProject.Show()
        End Sub

#End Region

#Region " Properties "

        Public ReadOnly Property ActiveFlags() As Flags
            Get
                Return ActiveFlag
            End Get
        End Property

        Public ReadOnly Property ActiveConceptualTool() As ConceptualTools
            Get
                If nbConcept.Checked Then Return ConceptualTools.Concept
                If nbAttribute.Checked Then Return ConceptualTools.Attribute
                If nbTransformation.Checked Then Return ConceptualTools.Transformation
                If nbETLConstraint.Checked Then Return ConceptualTools.ETLConstraint
                If nbNote.Checked Then Return ConceptualTools.Note
                If nbProvider.Checked Then Return ConceptualTools.Provider

                Return ConceptualTools.Pointer
            End Get
        End Property

        Public ReadOnly Property ActiveLogicalTool() As LogicalTools
            Get
                If nbActivity.Checked Then Return LogicalTools.Activity
                If nbLogicalAttribute.Checked Then Return LogicalTools.Attribute
                If nbConstant.Checked Then Return LogicalTools.Constant
                If nbDataType.Checked Then Return LogicalTools.DataType
                If nbFunction.Checked Then Return LogicalTools.LogicalFunction
                If nbFunctionType.Checked Then Return LogicalTools.FunctionType
                If nbLogicalNote.Checked Then Return LogicalTools.Note
                If nbParameter.Checked Then Return LogicalTools.Parameter
                If nbRecordSet.Checked Then Return LogicalTools.RecordSet

                Return LogicalTools.Pointer
            End Get
        End Property

#End Region

#Region " Public Functions "

        Public Sub ResetConceptualTool(Optional ByVal selectPointer As Boolean = True)
            nbPointer.Checked = selectPointer

            nbConcept.Checked = False
            nbAttribute.Checked = False
            nbTransformation.Checked = False
            nbETLConstraint.Checked = False
            nbNote.Checked = False
            nbProvider.Checked = False
        End Sub

        Public Sub ResetLogicalTool(Optional ByVal selectPointer As Boolean = True)
            nbLogicalPointer.Checked = selectPointer

            nbActivity.Checked = False
            nbLogicalAttribute.Checked = False
            nbConstant.Checked = False
            nbDataType.Checked = False
            nbFunction.Checked = False
            nbFunctionType.Checked = False
            nbLogicalNote.Checked = False
            nbParameter.Checked = False
            nbRecordSet.Checked = False
        End Sub

#End Region

    End Class

End Namespace