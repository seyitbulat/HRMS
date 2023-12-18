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

    <HttpGet("GetById")>
    Async Function GetById(<FromRoute> id As Long) As Task(Of IActionResult)
        Dim response = Await _service.GetById(id)
        Return SendResponse(response)
    End Function


    <HttpGet("GetAll")>
    Async Function GetAll() As Task(Of IActionResult)
        Dim response = Await _service.GetAll()
        Return SendResponse(response)
    End Function

    <HttpPost>
    Async Function AddDepartment(<FromBody> dto As DepartmentPostDto) As Task(Of IActionResult)
        Dim response = Await _service.Add(dto)
        Return SendResponse(response)
    End Function

    <HttpDelete("{id}")>
    Async Function DeleteDepartment(<FromRoute> id As Long) As Task(Of IActionResult)
        Dim response = Await _service.Delete(id)
        Return SendResponse(response)
    End Function
End Class
