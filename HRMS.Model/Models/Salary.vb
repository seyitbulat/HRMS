Imports System
Imports System.Collections.Generic

Namespace Models
    Partial Public Class Salary
        Public Property Id As Long

        Public Property Basesalary As Decimal

        Public Property Bonus As Decimal?

        Public Property Deductions As Decimal?

        Public Property Effectivedate As Date

        Public Property Employeeid As Long?

        Public Property Isactive As Boolean

        Public Overridable Property Employee As Employee
    End Class
End Namespace
