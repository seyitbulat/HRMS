Imports Microsoft.AspNetCore.Mvc
Imports HRMS.Model
Imports Infrastructure.Infrastructure.Utilities.ApiResponses
Imports HRMS.Business
Imports Infrastructure
Imports HRMS.Api.HRMS.Api.Controllers

<Route("api/[controller]")>
<ApiController>
Public Class ImageController
    Inherits BaseController

    Private ReadOnly _imageService As IImageBs

    Public Sub New(imageService As IImageBs)
        _imageService = imageService
    End Sub
    <HttpGet("{id}")>
    Public Async Function GetById(id As Long) As Task(Of ActionResult(Of ApiResponse(Of ImageGetDto)))
        Dim response = Await _imageService.GetById(id)
        Return SendResponse(response)
    End Function

    <HttpGet>
    Public Async Function GetAll() As Task(Of ActionResult(Of ApiResponse(Of IEnumerable(Of ImageGetDto))))
        Dim response = Await _imageService.GetAll()
        Return SendResponse(response)
    End Function

    <HttpPost>
    Public Async Function Add(<FromBody> dto As ImagePostDto) As Task(Of ActionResult(Of ApiResponse(Of ImageGetDto)))
        Dim response = Await _imageService.Add(dto)
        Return SendResponse(response)
    End Function

    <HttpPut("{id}")>
    Public Async Function Update(id As Long, <FromBody> dto As ImagePutDto) As Task(Of ActionResult(Of ApiResponse(Of ImageGetDto)))
        Dim response = Await _imageService.Update(id, dto)
        Return SendResponse(response)
    End Function

    <HttpDelete("{id}")>
    Public Async Function Delete(id As Long) As Task(Of ActionResult(Of ApiResponse(Of NoData)))
        Dim response = Await _imageService.Delete(id)
        Return SendResponse(response)
    End Function


End Class
