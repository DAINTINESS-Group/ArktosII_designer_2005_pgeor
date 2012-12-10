Namespace Constructs.Types

	Public Class ReposFunctionType

#Region " Implementation Members "
		Private myGuid As Guid		 'Not Certain how will specify them
		Private myName As String
		Private myDescription As String
		Private myInputs As Schema
		Private myOutputs As Schema
#End Region

#Region " Constructor "

		Public Sub New()
			myGuid = Guid.NewGuid()
			myInputs = New Schema
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

		Public ReadOnly Property Inputs() As Schema
			Get
				Inputs = myInputs
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