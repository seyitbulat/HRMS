﻿Imports HRMS.Model
Imports Infrastructure
Imports Infrastructure.Infrastructure.Utilities.ApiResponses

Public Interface IDepartmentBs
    Function GetById(id As Long) As Task(Of ApiResponse(Of DepartmentGetDto))
    Function Add(dto As DepartmentPostDto) As Task(Of ApiResponse(Of DepartmentGetDto))
    Function GetAll() As Task(Of ApiResponse(Of IEnumerable(Of DepartmentGetDto)))
    Function Delete(id As Long) As Task(Of ApiResponse(Of NoData))
    Function Update(id As Long, dto As DepartmentPutDto) As Task(Of ApiResponse(Of DepartmentGetDto))
    Function ManageDepartment(departmentId As Long?, departmentName As String, managerId As Long?, operation As String) As Task(Of ApiResponse(Of String))

End Interface
