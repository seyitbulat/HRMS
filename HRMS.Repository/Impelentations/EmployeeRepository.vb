Imports HRMS.Model.Models
Imports Infrastructure

Public Class EmployeeRepository : Inherits BaseRepository(Of Employee, Long, HRMSContext) : Implements IEmployeeRepository
    Public Sub New(context As HRMSContext)
        MyBase.New(context)
    End Sub
End Class
