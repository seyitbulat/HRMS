Imports HRMS.Model.Models
Imports Infrastructure
Imports Microsoft.Data.SqlClient
Imports Microsoft.EntityFrameworkCore

Public Class EmployeeRepository : Inherits BaseRepository(Of Employee, Long, HRMSContext) : Implements IEmployeeRepository
    Public Property _context As HRMSContext
    Public Sub New(context As HRMSContext)
        MyBase.New(context)
        _context = context
    End Sub
    Public Async Function SearchByBirthdateAndLastname(birthdate As Date, lastname As String) As Task(Of IEnumerable(Of Employee)) Implements IEmployeeRepository.SearchByBirthdateAndLastname

        Return Await _context.Employees.Where(Function(e) e.Birthdate = birthdate AndAlso e.Lastname.Trim() = lastname.Trim()).ToListAsync()
    End Function

    Public Async Function SearchByBirthdateAndLastnameProcedure(birthdate As Date, lastname As String) As Task(Of IEnumerable(Of Employee)) Implements IEmployeeRepository.SearchByBirthdateAndLastnameProcedure
        Return Await _context.Employees.FromSqlRaw("EXEC dbo.SearchEmployeesByBirthdateAndLastname @birthdate, @lastname", New SqlParameter("@birthdate", birthdate), New SqlParameter("@lastname", lastname)).ToListAsync()
    End Function
End Class