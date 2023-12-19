Imports AutoMapper
Imports HRMS.Model
Imports HRMS.Model.Models

Public Class AutoMapperProfiles : Inherits Profile

    Public Sub New()
        CreateMap(Of LeavesType, LeavesTypeGetDto)()
        CreateMap(Of LeavesTypePostDto, LeavesType)()
        CreateMap(Of LeavesTypePutDto, LeavesType)()

        CreateMap(Of Department, DepartmentGetDto)()
        CreateMap(Of DepartmentPostDto, Department)()
        CreateMap(Of DepartmentPutDto, Department)()

        CreateMap(Of Position, PositionGetDto)()
        CreateMap(Of PositionPostDto, Position)()
        CreateMap(Of PositionPutDto, Position)()

    End Sub
End Class
