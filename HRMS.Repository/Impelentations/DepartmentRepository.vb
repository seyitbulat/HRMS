Imports System.Data
Imports HRMS.Model.Models
Imports Infrastructure
Imports Microsoft.Data.SqlClient
Imports Microsoft.EntityFrameworkCore

Public Class DepartmentRepository : Inherits BaseRepository(Of Department, Long, HRMSContext) : Implements IDepartmentRepository
    Public Sub New(context As HRMSContext)
        MyBase.New(context)
        _context = context
    End Sub

    Private ReadOnly _context As HRMSContext

    Public Async Function ManageDepartment(departmentId As Long?, departmentName As String, managerId As Long?, operation As String) As Task(Of String) Implements IDepartmentRepository.ManageDepartment
        Return Await Task.Run(Function()
                                  Using conn As New SqlConnection(_context.Database.GetDbConnection().ConnectionString)
                                      Using cmd As New SqlCommand("dbo.sp_ManageDepartment", conn)
                                          cmd.CommandType = CommandType.StoredProcedure
                                          cmd.Parameters.Add(New SqlParameter("@DepartmentID", If(departmentId.HasValue, departmentId.Value, DBNull.Value)))
                                          cmd.Parameters.Add(New SqlParameter("@DepartmentName", departmentName))
                                          cmd.Parameters.Add(New SqlParameter("@ManagerID", If(managerId.HasValue, managerId.Value, DBNull.Value)))
                                          cmd.Parameters.Add(New SqlParameter("@Operation", operation))

                                          conn.Open()
                                          Dim result As Object = cmd.ExecuteScalar()
                                          conn.Close()

                                          Return If(result IsNot Nothing, result.ToString(), "Error: No result returned from stored procedure.")
                                      End Using
                                  End Using
                              End Function)
    End Function
End Class
