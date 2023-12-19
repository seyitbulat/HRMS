Imports HRMS.Model
Imports Infrastructure
Imports Infrastructure.Infrastructure.Utilities.ApiResponses

Public Interface IPositionBs
    Function GetById(id As Long) As Task(Of ApiResponse(Of PositionGetDto))
    Function Add(dto As PositionPostDto) As Task(Of ApiResponse(Of PositionGetDto))
    Function GetAll() As Task(Of ApiResponse(Of IEnumerable(Of PositionGetDto)))
    Function Delete(id As Long) As Task(Of ApiResponse(Of NoData))
    Function Update(id As Long, dto As PositionPutDto) As Task(Of ApiResponse(Of PositionGetDto))
End Interface
