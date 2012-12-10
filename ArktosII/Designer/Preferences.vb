Imports System.ComponentModel
Imports System.Xml.Serialization

Namespace Designer

    <Serializable()> _
    Public Module Preferences

        Public Sub Init()
            ' Concept
            With Concept
                .BackColor = Color.FromArgb(192, 255, 192)
                .ForeColor = Color.Black
                .Width = 96
                .Height = 40
            End With

            ' Attribute
            With Attribute
                .BackColor = Color.FromArgb(255, 224, 192)
                .ForeColor = Color.Black
                .Width = 96
                .Height = 40
            End With

            ' Transformation
            With Transformation
                .BackColor = Color.FromArgb(255, 255, 192)
                .ForeColor = Color.Black
                .Width = 48
                .Height = 40
            End With

            ' Node
            With Note
                .BackColor = Color.FromArgb(192, 255, 255)
                .ForeColor = Color.Black
                .Width = 96
                .Height = 40
            End With

            ' ETL Constraint
            With ETLConstraint
                .BackColor = Color.FromArgb(255, 255, 192)
                .ForeColor = Color.Black
                .Width = 48
                .Height = 40
            End With

            ' Activity
            With Activity
                .BackColor = Color.White
                .ForeColor = Color.Black
                .Width = 96
                .Height = 64
            End With

            ' Logical Attribute
            With LogicalAttribute
                .BackColor = Color.White
                .ForeColor = Color.Black
                .Width = 96
                .Height = 40
            End With

            ' Constant
            With Constant
                .BackColor = Color.Black
                .ForeColor = Color.White
                .Width = 48
                .Height = 48
            End With

            ' Data Type
            With DataType
                .BackColor = Color.White
                .ForeColor = Color.Black
                .Width = 96
                .Height = 40
            End With

            ' Function
            With LogicalFunction
                .BackColor = Color.LightSkyBlue
                .ForeColor = Color.Black
                .Width = 96
                .Height = 40
            End With

            ' Function Type
            With FunctionType
                .BackColor = Color.Black
                .ForeColor = Color.White
                .Width = 96
                .Height = 40
            End With

            ' Logical Note
            With LogicalNote
                .BackColor = Color.LemonChiffon
                .ForeColor = Color.Black
                .Width = 96
                .Height = 40
            End With

            ' Parameter
            With Parameter
                .BackColor = Color.White
                .ForeColor = Color.Black
                .Width = 96
                .Height = 40
            End With

            ' RecordSet
            With RecordSet
                .BackColor = Color.FromArgb(192, 255, 192)
                .ForeColor = Color.Black
                .Width = 96
                .Height = 48
            End With
        End Sub

#Region " Selection Handles "

        Public HandleWidth As Integer = 7
        Public HandleBackColor As Color = Color.Black
        Public HandleForeColor As Color = Color.Black
        Public HandleOffset As Integer = 8

#End Region

#Region " Node Preferences "

        ' Conceptual
        <XmlElement()> Public ReadOnly Concept As New NodePreferences
        <XmlElement()> Public ReadOnly Attribute As New NodePreferences
        <XmlElement()> Public ReadOnly ETLConstraint As New NodePreferences
        <XmlElement()> Public ReadOnly Note As New NodePreferences
        <XmlElement()> Public ReadOnly Transformation As New NodePreferences

        ' Logical
        <XmlElement()> Public ReadOnly Activity As New NodePreferences
        <XmlElement()> Public ReadOnly LogicalAttribute As New NodePreferences
        <XmlElement()> Public ReadOnly Constant As New NodePreferences
        <XmlElement()> Public ReadOnly DataType As New NodePreferences
        <XmlElement()> Public ReadOnly LogicalFunction As New NodePreferences
        <XmlElement()> Public ReadOnly FunctionType As New NodePreferences
        <XmlElement()> Public ReadOnly LogicalNote As New NodePreferences
        <XmlElement()> Public ReadOnly Parameter As New NodePreferences
        <XmlElement()> Public ReadOnly RecordSet As New NodePreferences

#End Region

#Region " Graphics "

        <XmlAttributeAttribute()> _
        Public DrawGradient As Boolean = True

#End Region

#Region " Public Class NodePreferences "

        Public Class NodePreferences
            <XmlElement(DataType:="Color")> Public BackColor As Color
            <XmlElement(DataType:="Color")> Public ForeColor As Color
            <XmlAttributeAttribute()> Public Width As Single
            <XmlAttributeAttribute()> Public Height As Single
        End Class

#End Region

    End Module

End Namespace