Imports HRMS.Api.Controllers
Imports HRMS.Api.HRMS.Api.Controllers
Imports HRMS.Business
Imports HRMS.Model
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
End Class
