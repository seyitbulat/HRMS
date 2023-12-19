Imports HRMS.Model.Models
Imports Infrastructure

Public Class InterviewRepository : Inherits BaseRepository(Of Interview, Long, HRMSContext) : Implements IInterviewRepository
    Public Sub New(context As HRMSContext)
        MyBase.New(context)
    End Sub
End Class
