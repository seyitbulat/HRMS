Imports HRMS.Api.Controllers
Imports HRMS.Api.HRMS.Api.Controllers
Imports HRMS.Business
Imports HRMS.Model
Imports Infrastructure.Infrastructure.Utilities.ApiResponses
Imports Microsoft.AspNetCore.Mvc

Public Class LeaveController
    Inherits BaseController

    Private ReadOnly _service As ILeaveBs

    Public Sub New(service As ILeaveBs)
        _service = service
    End Sub

    ' ... other actions ...

    <HttpPost("ManageLeave")>
    Public Async Function ManageLeave(<FromBody> dto As LeafPutDto) As Task(Of IActionResult)
        Dim response = Await _service.ManageLeave(dto.Id, dto.Startdate, dto.Enddate, dto.Status, dto.Employeeid, dto.Leavetypeid, dto.Operation)
        Return SendResponse(response)
    End Function


    <HttpPost("subtractAnnualLeave/{id}")>
    Public Async Function SubtractAnnualLeave(id As Long, <FromBody> dto As LeafPutDto) As Task(Of IActionResult)

        Dim result As ApiResponse(Of LeafPutDto) = Await _service.SubtractAnnualLeave(id, dto)
        Return Ok(result.Data)

    End Function
End Class
