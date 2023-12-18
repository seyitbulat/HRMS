Imports System
Imports System.Collections.Generic

Namespace Models
    Partial Public Class Position
        Public Property Id As Long

        Public Property Positiontitle As String

        Public Property Description As String

        Public Property Salarygrade As Long

        Public Property Isactive As Boolean

        Public Overridable ReadOnly Property Candidates As ICollection(Of Candidate) = New List(Of Candidate)()

        Public Overridable ReadOnly Property Employees As ICollection(Of Employee) = New List(Of Employee)()
    End Class
End Namespace
