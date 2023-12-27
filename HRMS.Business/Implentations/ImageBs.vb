Imports AutoMapper
Imports HRMS.Model
Imports HRMS.Model.Models
Imports HRMS.Repository
Imports Infrastructure
Imports Infrastructure.Infrastructure.Utilities.ApiResponses

Public Class ImageBs
    Implements IImageBs

    Private ReadOnly _repo As IImageRepository
    Private ReadOnly _mapper As IMapper

    Public Sub New(repo As IImageRepository, mapper As IMapper)
        _repo = repo
        _mapper = mapper
    End Sub

    Public Async Function GetById(id As Long) As Task(Of ApiResponse(Of ImageGetDto)) Implements IImageBs.GetById
        Dim image = Await _repo.GetByIdAsync(id)
        Dim mappedImage = _mapper.Map(Of ImageGetDto)(image)

        Return ApiResponse(Of ImageGetDto).Success(200, mappedImage)
    End Function

    Public Async Function Add(dto As ImagePostDto) As Task(Of ApiResponse(Of ImageGetDto)) Implements IImageBs.Add
        Dim newItem = _mapper.Map(Of Image)(dto)
        Dim added = Await _repo.AddAsync(newItem)

        Dim newDto = _mapper.Map(Of ImageGetDto)(added)

        Return ApiResponse(Of ImageGetDto).Success(201, newDto)
    End Function

    Public Async Function GetAll() As Task(Of ApiResponse(Of IEnumerable(Of ImageGetDto))) Implements IImageBs.GetAll
        Dim repoResponse = Await _repo.GetAllAsync()
        Dim dtoList = _mapper.Map(Of IEnumerable(Of ImageGetDto))(repoResponse)

        Return ApiResponse(Of IEnumerable(Of ImageGetDto)).Success(200, dtoList)
    End Function

    Public Async Function Delete(id As Long) As Task(Of ApiResponse(Of NoData)) Implements IImageBs.Delete
        Dim result = Await _repo.DeleteAsync(id)
        If result Then
            Return ApiResponse(Of NoData).Success(200)
        Else
            Return ApiResponse(Of NoData).Fail(404, "Item not found")
        End If
    End Function

    Public Async Function Update(id As Long, dto As ImagePutDto) As Task(Of ApiResponse(Of ImageGetDto)) Implements IImageBs.Update
        Dim existingItem = Await _repo.GetByIdAsync(id)
        If existingItem Is Nothing Then
            Return ApiResponse(Of ImageGetDto).Fail(404, "Item not found")
        End If

        _mapper.Map(dto, existingItem)
        Await _repo.UpdateAsync(existingItem)

        Dim updatedDto = _mapper.Map(Of ImageGetDto)(existingItem)

        Return ApiResponse(Of ImageGetDto).Success(200, updatedDto)
    End Function
End Class
