Imports System.Data
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


    Public Async Function SearchByBirthdateAndLastnameProcedure(birthdate As Date, lastname As String) As Task(Of IEnumerable(Of Employee)) Implements IEmployeeRepository.SearchByBirthdateAndLastnameProcedure

        Return Await _context.Employees.FromSqlRaw("EXEC dbo.GetEmployeeByLastNameAndBirthDate @birthdate, @lastname", New SqlParameter("@birthdate", birthdate), New SqlParameter("@lastname", lastname)).ToListAsync()
    End Function

    Public Async Function GetEmployeeReport(departmentId As Long?, startDate As Date?, endDate As Date?) As Task(Of IEnumerable(Of Employee)) Implements IEmployeeRepository.GetEmployeeReport
        Return Await Task.Run(Function()
                                  Using conn As New SqlConnection(_context.Database.GetDbConnection().ConnectionString)
                                      Using cmd As New SqlCommand("sp_EmployeeReport", conn)
                                          cmd.CommandType = CommandType.StoredProcedure
                                          cmd.Parameters.Add(New SqlParameter("@DepartmentID", If(departmentId.HasValue, departmentId.Value, DBNull.Value)))
                                          cmd.Parameters.Add(New SqlParameter("@StartDate", If(startDate.HasValue, startDate.Value, DBNull.Value)))
                                          cmd.Parameters.Add(New SqlParameter("@EndDate", If(endDate.HasValue, endDate.Value, DBNull.Value)))

                                          conn.Open()
                                          Dim reader As SqlDataReader = cmd.ExecuteReader()
                                          Dim employees As New List(Of Employee)()

                                          While reader.Read()
                                              ' Assuming Employee is a class that matches your database schema
                                              Dim employee As New Employee()
                                              ' Map reader fields to employee properties here
                                              employees.Add(employee)
                                          End While

                                          conn.Close()
                                          Return employees
                                      End Using
                                  End Using
                              End Function)
    End Function
End Class