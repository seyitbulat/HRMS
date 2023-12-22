Imports HRMS.Api.HRMS.Api.Controllers
Imports HRMS.Business
Imports HRMS.Model
Imports Microsoft.AspNetCore.Mvc

Public Class DepartmentController
    Inherits BaseController
    Private ReadOnly _service As IDepartmentBs

    Public Sub New(service As IDepartmentBs)
        _service = service
    End Sub

    <HttpGet("GetById/{id}")>
    Async Function GetById(<FromRoute> id As Long) As Task(Of IActionResult)
        Dim response = Await _service.GetById(id)
        Return SendResponse(response)
    End Function


    <HttpGet("GetAll")>
    Async Function GetAll() As Task(Of IActionResult)
        Dim response = Await _service.GetAll()
        Return SendResponse(response)
    End Function

    <HttpPost("ManageDepartment")>
    Public Async Function ManageDepartment(<FromBody> dto As DepartmentPutDto) As Task(Of IActionResult)
        Dim response = Await _service.ManageDepartment(dto.Id, dto.Departmentname, dto.Managerid, dto.Operation)
        Return SendResponse(response)
    End Function
End Class
