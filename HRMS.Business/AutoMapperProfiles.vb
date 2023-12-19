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

        CreateMap(Of Candidate, CandidateGetDto)()
        CreateMap(Of CandidatePostDto, Candidate)()
        CreateMap(Of CandidatePutDto, Candidate)()

        CreateMap(Of Employee, EmployeeGetDto)()
        CreateMap(Of EmployeePostDto, Employee)()
        CreateMap(Of EmployeePutDto, Employee)()

        CreateMap(Of Interview, InterviewGetDto)()
        CreateMap(Of InterviewPostDto, Interview)()
        CreateMap(Of InterviewPutDto, Interview)()
    End Sub
End Class
