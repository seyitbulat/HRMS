Imports HRMS.Model
Imports Infrastructure.Infrastructure.Utilities.ApiResponses

Public Interface ILeavesTypeBs
    Function GetById(id As Long) As Task(Of ApiResponse(Of LeavesTypeGetDto))
    Function Add(dto As LeavesTypePostDto) As Task(Of ApiResponse(Of LeavesTypeGetDto))
    Function GetAll() As Task(Of ApiResponse(Of IEnumerable(Of LeavesTypeGetDto)))
End Interface
