Imports Infrastructure.Infrastructure.Utilities.ApiResponses

Public Interface ILeaveBs
    Function ManageLeave(leaveId As Long?, startDate As DateTime, endDate As DateTime, status As String, employeeId As Long, leaveTypeId As Long, operation As String) As Task(Of ApiResponse(Of String))
End Interface
