Imports HRMS.Model.Models
Imports Infrastructure
Public Class CandidateRepository : Inherits BaseRepository(Of Candidate, Long, HRMSContext) : Implements ICandidateRepository
    Public Sub New(context As HRMSContext)
        MyBase.New(context)
    End Sub
End Class
