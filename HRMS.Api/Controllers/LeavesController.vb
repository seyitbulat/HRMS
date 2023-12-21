Imports System
Imports HRMS.Business
Imports HRMS.Model
Imports Infrastructure.Infrastructure.Utilities.ApiResponses
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.Extensions.Logging

Namespace HRMS.Api.Controllers
    Public Class LeavesController
        Inherits BaseController

        Private ReadOnly _service As ILeavesBs

        Public Sub New(service As ILeavesBs)
            _service = service
        End Sub


        <HttpPost("subtractAnnualLeave/{id}")>
        Public Async Function SubtractAnnualLeave(id As Long, <FromBody> dto As LeafPutDto) As Task(Of IActionResult)

            Dim result As ApiResponse(Of LeafPutDto) = Await _service.SubtractAnnualLeave(id, dto)
            Return Ok(result.Data)

        End Function



    End Class
End Namespace
