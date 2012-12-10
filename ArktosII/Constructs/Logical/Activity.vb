Imports ArktosII.Constructs.Logical

Namespace Constructs.Logical

	Public Class Activity
		Inherits ArktosII.Graphics.Nodes.Logical.ActivityNode

#Region " Implementation Members "
		Private myDescription As String
		Private myLog As String		 ' file H class
		Private mySQL As String		 'May not be used
		Private myLDL As String		 'May not be used
		Private myType As Constructs.Types.ReposActivityType
		Private myInputs As Schemas
		Private myParameters As Schema
		Private myFunctions As Schema
		Private myOutputs As Schema
#End Region

#Region " Constructor "

		Public Sub New()
			MyBase.New()
		End Sub

#End Region

#Region " Properties "

		Public Property Description() As String
			Get
				Description = myDescription
			End Get
			Set(ByVal Value As String)
				myDescription = Value
			End Set
		End Property

		Public Property Log() As String
			Get
				Log = myLog
			End Get
			Set(ByVal Value As String)
				myLog = Value
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

		Public Property Type() As Constructs.Types.ReposActivityType
			Get
				Type = myType
			End Get
			Set(ByVal Value As Constructs.Types.ReposActivityType)
				myType = Value
			End Set
		End Property

		Public ReadOnly Property Inputs() As Schemas
			Get
				Inputs = myInputs
			End Get
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

#Region " Schema Alterations "

        'Edw tha mpoun Oti elegxoi xreiazontai sygkekrimena gia ton kathe "typo"

#Region " Inputs "

		'Create A New Input in an existing schema'
        Public Function AddInput(ByVal Name As String, ByVal DataType As Constructs.Types.ReposDataType, ByVal SchemaID As Guid) As Attribute
            Throw New InvalidActivityInputException
        End Function

        'Create A New Input Based, schema creation if needed will be handled in here'
        Public Function AddInput(ByVal Name As String, ByVal DataType As Constructs.Types.ReposDataType) As Attribute
            Throw New InvalidActivityInputException

        End Function

        'Create A New Input Based On An Existing Source (eg.Act.Out)'
        Public Function AddInput(ByVal Source As Attribute) As Attribute
            Throw New InvalidActivityInputException
        End Function

        Public Sub RemoveInput(ByVal Id As Guid)
            Throw New ArktosII.Constructs.InvalidSchemaNodeException
        End Sub

#End Region

#Region " Parameters "

		'Create A New Parameter
        Public Function AddParameter(ByVal Source As Attribute) As Parameter

        End Function

        'Create A New Parameter Based On An Existing source (eg Act.IN)
        Public Function AddParameter(ByVal Name As String, ByVal DataType As Constructs.Types.ReposDataType) As Parameter

        End Function

        Public Sub RemoveParameter(ByVal Id As Guid)

        End Sub

#End Region

#Region " Outputs "

        'Create A New Output Based On An Existing source (eg Act.IN)
        Public Function AddOutput(ByVal Source As Attribute) As Attribute

        End Function

        'Create A New OutPut
        Public Function AddOutput(ByVal Name As String, ByVal DataType As Constructs.Types.ReposDataType) As Attribute

        End Function

        Public Sub RemoveOutput(ByVal Id As Guid)

        End Sub

#End Region

#End Region

	End Class

End Namespace
