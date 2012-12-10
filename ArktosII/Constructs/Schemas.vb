Namespace Constructs

	Public Class Schemas
        Implements IDictionary, ICloneable, ICollection, IEnumerable

#Region " Constructor "

        Public Sub New()
            myList = New ArrayList
            myHash = New Hashtable
        End Sub

#End Region

#Region " Implementation Members "

        Protected myList As ArrayList
        Protected myHash As Hashtable

#End Region

#Region " Interfaces "
        Public Sub CopyTo(ByVal array As System.Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo
            myList.CopyTo(array, index)
        End Sub

        Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
            Get
                Count = myHash.Count
            End Get
        End Property

        Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
            Get
                IsSynchronized = myHash.IsSynchronized
            End Get
        End Property

        Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
            Get
                SyncRoot = myHash.SyncRoot()
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements System.Collections.ICollection.GetEnumerator
            Return Me.myList.GetEnumerator
        End Function

        Public Sub Clear() Implements System.Collections.IDictionary.Clear
            myHash.Clear()
            myList.Clear()
        End Sub

        Public Function GetHashEnumerator() As System.Collections.IDictionaryEnumerator Implements System.Collections.IDictionary.GetEnumerator
            Return myHash.GetEnumerator
        End Function

        Public ReadOnly Property IsFixedSize() As Boolean Implements System.Collections.IDictionary.IsFixedSize
            Get
                IsFixedSize = myHash.IsFixedSize
            End Get
        End Property

        Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.IDictionary.IsReadOnly
            Get
                IsReadOnly = myHash.IsReadOnly
            End Get
        End Property

        Public ReadOnly Property Keys() As System.Collections.ICollection Implements System.Collections.IDictionary.Keys
            Get
                Keys = myHash.Keys
            End Get
        End Property

        Public ReadOnly Property Values() As System.Collections.ICollection Implements System.Collections.IDictionary.Values
            Get
                Values = myHash.Values
            End Get
        End Property

        Private Sub myRemove(ByVal key As Object) Implements System.Collections.IDictionary.Remove
            'DUMMY
            'myList.Remove(myHash.Item(key))
            'myHash.Remove(key)
        End Sub

        Private Property myItem(ByVal key As Object) As Object Implements System.Collections.IDictionary.Item
            Get
                'DUMMY
                'myItem = myHash.Item(key)
            End Get
            Set(ByVal Value As Object)
                'DUMMY
                'myHash.Item(key) = Value
            End Set
        End Property

        Private Function myContains(ByVal key As Object) As Boolean Implements System.Collections.IDictionary.Contains
            'Dummy
            'Return myHash.Contains(key)
        End Function

        Private Sub myAdd(ByVal key As Object, ByVal value As Object) Implements System.Collections.IDictionary.Add
            'Dummy
            'myHash.Add(key, value)
            'myList.Add(value)
        End Sub

        Private Function myClone() As Object Implements System.ICloneable.Clone
            'DUMMY
            'Return myHash.Clone()
        End Function

#End Region

#Region " Custom Public Methods "

        Public Sub Remove(ByVal ID As Guid)
            myList.Remove(myHash.Item(ID))
            myHash.Remove(ID)
        End Sub

        Public Sub Remove(ByVal value As Constructs.Schema)
            myHash.Remove(value.ID)
            myList.Remove(value)
        End Sub

        Default Public Property Item(ByVal ID As Guid) As Constructs.Schema
            Get
                Item = CType(myHash.Item(ID), Constructs.Schema)
            End Get
            Set(ByVal Value As Constructs.Schema)
                myHash.Item(ID) = Value
            End Set
        End Property

        Public Function ContainsKey(ByVal ID As Guid) As Boolean
            Return myHash.Contains(ID)
        End Function

        Public Function ContainsValue(ByVal value As Constructs.Schema) As Boolean
            Return myHash.ContainsValue(value)
        End Function

        Public Sub Add(ByVal value As Constructs.Schema)
            myHash.Add(value.ID, value)
            myList.Add(value)
        End Sub

        Public Function Clone() As Schemas
            Dim Cloned As New Schemas
            Dim tListItem As Constructs.Schema
            For Each tListItem In myList
                Cloned.Add(tListItem)
            Next
            Clone = Cloned
            Cloned = Nothing
            tListItem = Nothing
        End Function

#End Region

#Region " From IList "

        Public Function IndexOf(ByVal value As Constructs.Schema) As Integer
            Return myList.IndexOf(value)
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As Constructs.Schema)
            myList.Insert(index, value)
            myHash.Add(value.ID, value)
        End Sub

        Default Public Property Item(ByVal index As Integer) As Constructs.Schema
            Get
                Item = CType(myHash(myList(index)), Constructs.Schema)
            End Get
            Set(ByVal Value As Constructs.Schema)
                myHash(myList(index)) = Value
            End Set
        End Property

        Public Sub RemoveAt(ByVal index As Integer)
            myHash.Remove(CType(myList(index), Constructs.Schema).ID)
            myList.RemoveAt(index)
        End Sub

#End Region

    End Class

End Namespace