Imports HRMS.Model.Models
Imports Infrastructure

Public Class DepartmentRepository : Inherits BaseRepository(Of Department, Long, HRMSContext) : Implements IDepartmentRepository
    Public Sub New(context As HRMSContext)
        MyBase.New(context)
    End Sub
End Class
