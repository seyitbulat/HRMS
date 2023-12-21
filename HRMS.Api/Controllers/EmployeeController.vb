Imports HRMS.Api.HRMS.Api.Controllers
Imports HRMS.Business
Imports HRMS.Model
Imports Microsoft.AspNetCore.Mvc

Public Class EmployeeController
    Inherits BaseController

    Private ReadOnly _service As IEmployeeBs

    Public Sub New(service As IEmployeeBs)
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

    <HttpPost>
    Async Function AddEmployee(<FromBody> dto As EmployeePostDto) As Task(Of IActionResult)
        Dim response = Await _service.Add(dto)
        Return SendResponse(response)
    End Function

    <HttpDelete("{id}")>
    Async Function DeleteEmployee(<FromRoute> id As Long) As Task(Of IActionResult)
        Dim response = Await _service.Delete(id)
        Return SendResponse(response)
    End Function

    <HttpGet("Search")>
    Async Function SearchByBirthdateAndLastname(<FromQuery> birthdate As Date, <FromQuery> lastname As String) As Task(Of IActionResult)
        Dim response = Await _service.SearchByBirthdateAndLastname(birthdate, lastname)
        Return SendResponse(response)
    End Function
End Class
