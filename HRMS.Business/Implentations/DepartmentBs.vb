Imports AutoMapper
Imports HRMS.Model
Imports HRMS.Model.Models
Imports HRMS.Repository
Imports Infrastructure
Imports Infrastructure.Infrastructure.Utilities.ApiResponses

Public Class DepartmentBs : Implements IDepartmentBs

    Private ReadOnly _repo As IDepartmentRepository
    Private ReadOnly _mapper As IMapper

    Public Sub New(repo As IDepartmentRepository, mapper As IMapper)
        _repo = repo
        _mapper = mapper
    End Sub

    Public Async Function GetById(id As Long) As Task(Of ApiResponse(Of DepartmentGetDto)) Implements IDepartmentBs.GetById
        Dim department = Await _repo.GetByIdAsync(id)
        Dim mappedDepartment = _mapper.Map(Of DepartmentGetDto)(department)

        Return ApiResponse(Of DepartmentGetDto).Success(200, mappedDepartment)
    End Function

    Public Async Function Add(dto As DepartmentPostDto) As Task(Of ApiResponse(Of DepartmentGetDto)) Implements IDepartmentBs.Add
        Dim newItem = _mapper.Map(Of Department)(dto)
        Dim added = Await _repo.AddAsync(newItem)

        Dim newDto = _mapper.Map(Of DepartmentGetDto)(added)

        Return ApiResponse(Of DepartmentGetDto).Success(201, newDto)
    End Function

    Public Async Function GetAll() As Task(Of ApiResponse(Of IEnumerable(Of DepartmentGetDto))) Implements IDepartmentBs.GetAll
        Dim repoResponse = Await _repo.GetAllAsync()
        Dim dtoList = _mapper.Map(Of IEnumerable(Of DepartmentGetDto))(repoResponse)

        Return ApiResponse(Of IEnumerable(Of DepartmentGetDto)).Success(200, dtoList)
    End Function

    Public Async Function Delete(id As Long) As Task(Of ApiResponse(Of NoData)) Implements IDepartmentBs.Delete
        Dim result = Await _repo.DeleteAsync(id)
        If result Then
            Return ApiResponse(Of NoData).Success(200)
        Else
            Return ApiResponse(Of NoData).Fail(404, "Item not found")
        End If
    End Function

    Public Async Function Update(id As Long, dto As DepartmentPutDto) As Task(Of ApiResponse(Of DepartmentGetDto)) Implements IDepartmentBs.Update
        Dim existingItem = Await _repo.GetByIdAsync(id)
        If existingItem Is Nothing Then
            Return ApiResponse(Of DepartmentGetDto).Fail(404, "Item not found")
        End If

        _mapper.Map(dto, existingItem)
        Await _repo.UpdateAsync(existingItem)

        Dim updatedDto = _mapper.Map(Of DepartmentGetDto)(existingItem)

        Return ApiResponse(Of DepartmentGetDto).Success(200, updatedDto)
    End Function

    Public Async Function ManageDepartment(departmentId As Long?, departmentName As String, managerId As Long?, operation As String) As Task(Of ApiResponse(Of String)) Implements IDepartmentBs.ManageDepartment
        Dim result = Await _repo.ManageDepartment(departmentId, departmentName, managerId, operation)

        If Not String.IsNullOrWhiteSpace(result) Then
            Return ApiResponse(Of String).Success(200, result)
        Else
            Return ApiResponse(Of String).Fail(500, "An error occurred during the department management operation.")
        End If
    End Function
End Class
