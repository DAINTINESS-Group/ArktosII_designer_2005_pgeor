Namespace Constructs

    Public NotInheritable Class DataConnection
        Implements IDisposable

#Region " Constructors "

        Public Sub New(ByVal dr As DataRow)
            drDataConnection = dr
        End Sub

#End Region

#Region " IDisposable "

        Public Sub Dispose() Implements System.IDisposable.Dispose
            drDataConnection.Delete()
        End Sub

#End Region

#Region " Implementation Members "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     The available providers.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[finik]	22/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Enum Providers
            DB2 = 0
            MicrosoftAccess = 1
            MicrosoftSQLServer = 2
            Oracle = 3
            UserDefined = 4
        End Enum

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     The provider strings to be used to create the connection string to
        '''     the database.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[finik]	22/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Protected Shared ProviderStrings() As String = New String() { _
            "DB2OLEDB", _
            "Microsoft.Jet.OLEDB.4.0", _
            "sqloledb", _
            "MSDAORA", _
            "" _
        }

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     A simple description for the providers.  These descriptions should be
        '''     used in the forms where the user chooses the provider to avoid hard
        '''     coding them and changing them in many different locations.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[finik]	22/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Protected Shared ProviderNames() As String = New String() { _
            "DB2", _
            "Microsoft Access", _
            "Microsoft SQL Server", _
            "Oracle", _
            "User Defined" _
        }

        Protected drDataConnection As DataRow

#End Region

#Region " Properties "

        Public Shared ReadOnly Property ProviderString(ByVal type As Providers) As String
            Get
                Return ProviderStrings(type)
            End Get
        End Property

        Public Shared ReadOnly Property ProviderName(ByVal type As Providers) As String
            Get
                Return ProviderNames(type)
            End Get
        End Property

        Public Shared ReadOnly Property ConnectionString(ByVal provider As Providers, ByVal userid As String, ByVal password As String, ByVal datasource As String, ByVal initialCatalog As String, ByVal packageCollection As String, ByVal location As String, Optional ByVal integratedSecurity As Boolean = False) As String
            Get
                Dim str As String = "Provider=" & ProviderStrings(provider) & ";"

                Select Case provider
                    Case Providers.DB2
                        str = str & "Network Address=" & location & ";" _
                                  & "Network Transport Library=TCPIP;" _
                                  & "Package Collection=" & packageCollection & ";" _
                                  & "Initial Catalog=" & initialCatalog & ";" _
                                  & "User Id=" & userid & ";" _
                                  & "Password=" & password & ";"
                    Case Providers.MicrosoftAccess
                        str = str & "Data source=" & datasource & ";"
                    Case Providers.MicrosoftSQLServer
                        str = str & "Data source=" & datasource & ";" _
                                  & "Initial Catalog=" & initialCatalog & ";"
                        If integratedSecurity Then
                            str = str & "Integrated Security = SSPI;"
                        Else
                            str = str & "User id=" & userid & ";" _
                                      & "Password=" & password & ";"
                        End If
                    Case Providers.Oracle
                        str = str & "Data source=" & datasource & ";" _
                                  & "User id=" & userid & ";" _
                                  & "Password=" & password & ";"
                    Case Providers.UserDefined
                        str = str & "Data source=" & datasource & ";"
                End Select

                Return str
            End Get
        End Property

        Public Shared ReadOnly Property CountProviders() As Integer
            Get
                Return ProviderStrings.Length
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     The unique GUID of this data connection.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[finik]	22/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public ReadOnly Property ID() As String
            Get
                Return drDataConnection.Item("DATASOURCE_ID")
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     The alias used to describe this connection.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[finik]	22/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property DBAlias() As String
            Get
                Return drDataConnection.Item("NAME")
            End Get
            Set(ByVal Value As String)
                drDataConnection.Item("NAME") = Value
            End Set
        End Property

        Public Property Location() As String
            Get
                Return drDataConnection.Item("LOCATION")
            End Get
            Set(ByVal Value As String)
                drDataConnection.Item("LOCATION") = Value
            End Set
        End Property

        Public Property Provider() As Providers
            Get
                Return drDataConnection.Item("CS_PROVIDER")
            End Get
            Set(ByVal Value As Providers)
                drDataConnection.Item("CS_PROVIDER") = CInt(Value)
            End Set
        End Property

        Public Property Datasource() As String
            Get
                Return drDataConnection.Item("CS_DATASOURCE")
            End Get
            Set(ByVal Value As String)
                drDataConnection.Item("CS_DATASOURCE") = Value
            End Set
        End Property

        Public Property UserID() As String
            Get
                Return drDataConnection.Item("CS_USERID")
            End Get
            Set(ByVal Value As String)
                drDataConnection.Item("CS_USERID") = Value
            End Set
        End Property

        Public Property Password() As String
            Get
                Return drDataConnection.Item("CS_PASSWORD")
            End Get
            Set(ByVal Value As String)
                drDataConnection.Item("CS_PASSWORD") = Value
            End Set
        End Property

        Public Property InitialCatalog() As String
            Get
                Return drDataConnection.Item("CS_INITIAL_CATALOG")
            End Get
            Set(ByVal Value As String)
                drDataConnection.Item("CS_INITIAL_CATALOG") = Value
            End Set
        End Property

        Public Property PackageCollection() As String
            Get
                Return drDataConnection.Item("CS_PACKAGE_COLLECTION")
            End Get
            Set(ByVal Value As String)
                drDataConnection.Item("CS_PACKAGE_COLLECTION") = Value
            End Set
        End Property

        Public Property UseIntegratedSecurity() As Boolean
            Get
                Return drDataConnection.Item("CS_INTEGRATED_SECURITY")
            End Get
            Set(ByVal Value As Boolean)
                drDataConnection.Item("CS_INTEGRATED_SECURITY") = CBool(Value)
            End Set
        End Property

        Public ReadOnly Property DBName() As String
            Get
                Return drDataConnection.Item("DBName")
            End Get
        End Property

        Public ReadOnly Property ConnectionString() As String
            Get
                Return DataConnection.ConnectionString(Provider, UserID, Password, Datasource, InitialCatalog, PackageCollection, Location, UseIntegratedSecurity)
            End Get
        End Property

#End Region

#Region " Public Functions "

        Public Function GetDataRow() As System.Data.DataRow
            Return drDataConnection
        End Function

#End Region

    End Class

End Namespace