Imports AutoMapper
Imports HRMS.Model
Imports HRMS.Model.Models
Imports HRMS.Repository
Imports Infrastructure
Imports Infrastructure.Infrastructure.Utilities.ApiResponses

Public Class EmployeeBs : Implements IEmployeeBs

    Private ReadOnly _repo As IEmployeeRepository
    Private ReadOnly _mapper As IMapper

    Public Sub New(repo As IEmployeeRepository, mapper As IMapper)
        _repo = repo
        _mapper = mapper
    End Sub

    Public Async Function GetById(id As Long) As Task(Of ApiResponse(Of EmployeeGetDto)) Implements IEmployeeBs.GetById
        Dim employee = Await _repo.GetByIdAsync(id)
        Dim mappedEmployee = _mapper.Map(Of EmployeeGetDto)(employee)

        Return ApiResponse(Of EmployeeGetDto).Success(200, mappedEmployee)
    End Function

    Public Async Function Add(dto As EmployeePostDto) As Task(Of ApiResponse(Of EmployeeGetDto)) Implements IEmployeeBs.Add
        Dim newItem = _mapper.Map(Of Employee)(dto)
        Dim added = Await _repo.AddAsync(newItem)

        Dim newDto = _mapper.Map(Of EmployeeGetDto)(added)

        Return ApiResponse(Of EmployeeGetDto).Success(201, newDto)
    End Function

    Public Async Function GetAll() As Task(Of ApiResponse(Of IEnumerable(Of EmployeeGetDto))) Implements IEmployeeBs.GetAll
        Dim repoResponse = Await _repo.GetAllAsync()
        Dim dtoList = _mapper.Map(Of IEnumerable(Of EmployeeGetDto))(repoResponse)

        Return ApiResponse(Of IEnumerable(Of EmployeeGetDto)).Success(200, dtoList)
    End Function

    Public Async Function Delete(id As Long) As Task(Of ApiResponse(Of NoData)) Implements IEmployeeBs.Delete
        Dim result = Await _repo.DeleteAsync(id)
        If result Then
            Return ApiResponse(Of NoData).Success(200)
        Else
            Return ApiResponse(Of NoData).Fail(404, "Item not found")
        End If
    End Function

    Public Async Function Update(id As Long, dto As EmployeePutDto) As Task(Of ApiResponse(Of EmployeeGetDto)) Implements IEmployeeBs.Update
        Dim existingItem = Await _repo.GetByIdAsync(id)
        If existingItem Is Nothing Then
            Return ApiResponse(Of EmployeeGetDto).Fail(404, "Item not found")
        End If

        _mapper.Map(dto, existingItem)
        Await _repo.UpdateAsync(existingItem)

        Dim updatedDto = _mapper.Map(Of EmployeeGetDto)(existingItem)

        Return ApiResponse(Of EmployeeGetDto).Success(200, updatedDto)
    End Function
End Class
