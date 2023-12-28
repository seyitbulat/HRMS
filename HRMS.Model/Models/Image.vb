Imports System
Imports System.Collections.Generic
Imports Infrastructure

Namespace Models
    Partial Public Class Image : Inherits BaseEntity(Of Long)
        Public Property ImageId As Long

        Public Property ImagePath As String

        Public Property ImageName As String

        Public Property CreatedDate As Date

        Public Overridable ReadOnly Property Candidates As ICollection(Of Candidate) = New List(Of Candidate)()

        Public Overridable ReadOnly Property Employees As ICollection(Of Employee) = New List(Of Employee)()
    End Class
End Namespace
