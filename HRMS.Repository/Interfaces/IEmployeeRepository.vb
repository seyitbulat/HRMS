Imports HRMS.Model.Models
Imports Infrastructure

Public Interface IEmployeeRepository : Inherits IBaseRepository(Of Employee, Long)
    Function SearchByBirthdateAndLastname(birthdate As Date, lastname As String) As Task(Of IEnumerable(Of Employee))
    Function SearchByBirthdateAndLastnameProcedure(birthdate As Date, lastname As String) As Task(Of IEnumerable(Of Employee))
    Function GetEmployeeReport(departmentId As Long?, startDate As Date?, endDate As Date?) As Task(Of IEnumerable(Of Employee))

End Interface
