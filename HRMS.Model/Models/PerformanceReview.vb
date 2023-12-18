Imports System
Imports System.Collections.Generic

Namespace Models
    Partial Public Class PerformanceReview
        Public Property Id As Long

        Public Property Reviewdate As Date

        Public Property Score As Long

        Public Property Comments As String

        Public Property Employeeid As Long

        Public Property Reviewerid As Long

        Public Property Isactive As Boolean

        Public Overridable Property Employee As Employee

        Public Overridable Property Reviewer As Employee
    End Class
End Namespace
