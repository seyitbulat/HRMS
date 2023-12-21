﻿Imports AutoMapper
Imports HRMS.Model
Imports HRMS.Model.Models
Imports HRMS.Repository
Imports Infrastructure
Imports Infrastructure.Infrastructure.Utilities.ApiResponses

Public Class PositionBs : Implements IPositionBs

    Private ReadOnly _repo As IPositionRepository
    Private ReadOnly _mapper As IMapper

    Public Sub New(repo As IPositionRepository, mapper As IMapper)
        _repo = repo
        _mapper = mapper
    End Sub

    Public Async Function GetById(id As Long) As Task(Of ApiResponse(Of PositionGetDto)) Implements IPositionBs.GetById
        Dim position = Await _repo.GetByIdAsync(id)
        If position Is Nothing Then
            Return ApiResponse(Of PositionGetDto).Fail(404, "Item not found")
        End If
        Dim mappedPosition = _mapper.Map(Of PositionGetDto)(position)

        Return ApiResponse(Of PositionGetDto).Success(200, mappedPosition)
    End Function

    Public Async Function Add(dto As PositionPostDto) As Task(Of ApiResponse(Of PositionGetDto)) Implements IPositionBs.Add
        Dim newPosition = _mapper.Map(Of Position)(dto)
        Dim added = Await _repo.AddAsync(newPosition)
        Dim newDto = _mapper.Map(Of PositionGetDto)(added)

        Return ApiResponse(Of PositionGetDto).Success(201, newDto)
    End Function

    Public Async Function GetAll() As Task(Of ApiResponse(Of IEnumerable(Of PositionGetDto))) Implements IPositionBs.GetAll
        Dim repoResponse = Await _repo.GetAllAsync()
        Dim dtoList = _mapper.Map(Of IEnumerable(Of PositionGetDto))(repoResponse)

        Return ApiResponse(Of IEnumerable(Of PositionGetDto)).Success(200, dtoList)
    End Function

    Public Async Function Delete(id As Long) As Task(Of ApiResponse(Of NoData)) Implements IPositionBs.Delete
        Dim result = Await _repo.DeleteAsync(id)
        If result Then
            Return ApiResponse(Of NoData).Success(200)
        Else
            Return ApiResponse(Of NoData).Fail(404, "Item not found")
        End If
    End Function

    Public Async Function Update(id As Long, dto As PositionPutDto) As Task(Of ApiResponse(Of PositionGetDto)) Implements IPositionBs.Update
        Dim existingItem = Await _repo.GetByIdAsync(id)
        If existingItem Is Nothing Then
            Return ApiResponse(Of PositionGetDto).Fail(404, "Item not found")
        End If

        _mapper.Map(dto, existingItem)
        Await _repo.UpdateAsync(existingItem)

        Dim updatedDto = _mapper.Map(Of PositionGetDto)(existingItem)

        Return ApiResponse(Of PositionGetDto).Success(200, updatedDto)
    End Function

    Public Async Function ManagePosition(positionId As Long?, positionTitle As String, description As String, salaryGrade As Long, operation As String) As Task(Of ApiResponse(Of String)) Implements IPositionBs.ManagePosition
        Dim result = Await _repo.ManagePosition(positionId, positionTitle, description, salaryGrade, operation)

        If Not String.IsNullOrWhiteSpace(result) Then
            Return ApiResponse(Of String).Success(200, result)
        Else
            Return ApiResponse(Of String).Fail(500, "An error occurred during the position management operation.")
        End If
    End Function
End Class
