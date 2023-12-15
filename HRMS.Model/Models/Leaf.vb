Imports System
Imports System.Collections.Generic

Namespace Models
    Partial Public Class Leaf
        Public Property Id As Long

        Public Property Startdate As Date?

        Public Property Enddate As Date?

        Public Property Status As String

        Public Property Employeeid As Long?

        Public Property Leavetypeid As Long?

        Public Overridable Property Employee As Employee

        Public Overridable Property Leavetype As LeavesType
    End Class
End Namespace
