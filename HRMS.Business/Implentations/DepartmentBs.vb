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

    Public Async Function GetAll() As Task(Of ApiResponse(Of IEnumerable(Of DepartmentGetDto))) Implements IDepartmentBs.GetAll
        Dim includeList As New List(Of String)

        includeList.Add("Manager")
        Dim repoResponse = Await _repo.GetListAsync(includeList:=includeList)
        Dim dtoList = _mapper.Map(Of IEnumerable(Of DepartmentGetDto))(repoResponse)

        Return ApiResponse(Of IEnumerable(Of DepartmentGetDto)).Success(200, dtoList)
    End Function



    Public Async Function ManageDepartment(departmentId As Long?, departmentName As String, managerId As Long?, operation As String) As Task(Of ApiResponse(Of String)) Implements IDepartmentBs.ManageDepartment
        Dim result = Await _repo.ManageDepartment(departmentId, departmentName, managerId, operation)

        If Not String.IsNullOrWhiteSpace(result) Then
            Return ApiResponse(Of String).Success(200, result)
        Else
            Return ApiResponse(Of String).Fail(500, "An error occurred during the department management operation.")
        End If
    End Function

    Public Async Function GetByNameAsync(departmentName As String) As Task(Of ApiResponse(Of IEnumerable(Of DepartmentGetDto))) Implements IDepartmentBs.GetByNameAsync
        Dim includeList As New List(Of String)

        includeList.Add("Manager")
        Dim repoResponse = Await _repo.GetListAsync(includeList:=includeList, predicate:=Function(p) p.Departmentname.Contains(departmentName))
        Dim dtoList = _mapper.Map(Of IEnumerable(Of DepartmentGetDto))(repoResponse)

        Return ApiResponse(Of IEnumerable(Of DepartmentGetDto)).Success(200, dtoList)
    End Function
End Class
