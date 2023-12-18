﻿Imports HRMS.Model
Imports Infrastructure
Imports Infrastructure.Infrastructure.Utilities.ApiResponses

Public Interface IEmployeeBs
    Function GetById(id As Long) As Task(Of ApiResponse(Of EmployeeGetDto))
    Function Add(dto As EmployeePostDto) As Task(Of ApiResponse(Of EmployeeGetDto))
    Function GetAll() As Task(Of ApiResponse(Of IEnumerable(Of EmployeeGetDto)))
    Function Delete(id As Long) As Task(Of ApiResponse(Of NoData))
    Function Update(id As Long, dto As EmployeePutDto) As Task(Of ApiResponse(Of EmployeeGetDto))
End Interface
