Imports HRMS.Model.Models
Imports Infrastructure

Public Class PositionRepository : Inherits BaseRepository(Of Position, Long, HRMSContext) : Implements IPositionRepository

    Public Sub New(context As HRMSContext)
        MyBase.New(context)
    End Sub
End Class
