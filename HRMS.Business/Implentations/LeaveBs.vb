Imports HRMS.Repository
Imports Infrastructure.Infrastructure.Utilities.ApiResponses

Public Class LeaveBs
    Implements ILeaveBs

    Private ReadOnly _repo As ILeaveRepository

    Public Sub New(repo As ILeaveRepository)
        _repo = repo
    End Sub

    Public Async Function ManageLeave(leaveId As Long?, startDate As DateTime, endDate As DateTime, status As String, employeeId As Long, leaveTypeId As Long, operation As String) As Task(Of ApiResponse(Of String)) Implements ILeaveBs.ManageLeave
        Dim result = Await _repo.ManageLeave(leaveId, startDate, endDate, status, employeeId, leaveTypeId, operation)

        If Not String.IsNullOrWhiteSpace(result) Then
            Return ApiResponse(Of String).Success(200, result)
        Else
            Return ApiResponse(Of String).Fail(500, "An error occurred during the leave management operation.")
        End If
    End Function
End Class
