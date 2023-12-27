Imports System
Imports System.Collections.Generic
Imports Infrastructure

Namespace Models
    Partial Public Class Candidate : Inherits BaseEntity(Of Long)

        Public Property Firstname As String

        Public Property Lastname As String

        Public Property Applicationdate As Date

        Public Property Resumelink As String

        Public Property Appliedpositionid As Long
        Public Property ImageId As Long


        Public Overridable Property Appliedposition As Position

        Public Overridable ReadOnly Property Interviews As ICollection(Of Interview) = New List(Of Interview)()
        Public Overridable ReadOnly Property Images As ICollection(Of Image) = New List(Of Image)()
    End Class
End Namespace
