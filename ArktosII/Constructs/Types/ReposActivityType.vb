Namespace Constructs.Types

	Public Class ReposActivityType


#Region " Implementation Members "
		Private myGuid As Guid		 'Not Certain how will specify them
		Private myName As String
		Private myDescription As String
		Private myInputSchemasNo As Integer
		Private mySQL As String		 'May not be used
		Private myLDL As String		 'May not be used
		Private myParameters As Schema
		Private myFunctions As Schema
		Private myOutputs As Schema
#End Region

#Region " Constructor "

		Public Sub New()
			myGuid = Guid.NewGuid()
			myParameters = New Schema
			myFunctions = New Schema
			myOutputs = New Schema
		End Sub

#End Region

#Region " Properties "

		Public ReadOnly Property ID() As Guid
			Get
				ID = myGuid
			End Get
		End Property

		Public Property Name() As String
			Get
				Name = myName
			End Get
			Set(ByVal Value As String)
				myName = Value
			End Set
		End Property

		Public Property Description() As String
			Get
				Description = myDescription
			End Get
			Set(ByVal Value As String)
				myDescription = Value
			End Set
		End Property

		Public Property InputSchemasNo() As Integer
			Get
				InputSchemasNo = myInputSchemasNo
			End Get
			Set(ByVal Value As Integer)
				myInputSchemasNo = Value
			End Set
		End Property

		Public Property SQL() As String
			Get
				SQL = mySQL
			End Get
			Set(ByVal Value As String)
				mySQL = Value
			End Set
		End Property

		Public Property LDL() As String
			Get
				LDL = myLDL
			End Get
			Set(ByVal Value As String)
				myLDL = Value
			End Set
		End Property

		Public ReadOnly Property Parameters() As Schema
			Get
				Parameters = myParameters
			End Get
		End Property

		Public ReadOnly Property Functions() As Schema
			Get
				Functions = myFunctions
			End Get
		End Property

		Public ReadOnly Property Outputs() As Schema
			Get
				Outputs = myOutputs
			End Get
		End Property

#End Region

	End Class

End Namespace
