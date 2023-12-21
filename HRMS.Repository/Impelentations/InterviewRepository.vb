Imports System.Data
Imports HRMS.Model.Models
Imports Infrastructure
Imports Microsoft.Data.SqlClient
Imports Microsoft.EntityFrameworkCore

Public Class InterviewRepository : Inherits BaseRepository(Of Interview, Long, HRMSContext) : Implements IInterviewRepository
    Public Sub New(context As HRMSContext)
        MyBase.New(context)
        _context = context
    End Sub

    Private ReadOnly _context As HRMSContext

    Public Async Function ScheduleInterview(interviewDate As Date, candidateId As Long, interviewerId As Long, Optional interviewNotes As String = Nothing, Optional interviewOutcome As String = Nothing) As Task(Of String) Implements IInterviewRepository.ScheduleInterview
        Return Await Task.Run(Function()
                                  Using conn As New SqlConnection(_context.Database.GetDbConnection().ConnectionString)
                                      Using cmd As New SqlCommand("dbo.sp_ScheduleInterview", conn)
                                          cmd.CommandType = CommandType.StoredProcedure
                                          cmd.Parameters.Add(New SqlParameter("@InterviewDate", interviewDate))
                                          cmd.Parameters.Add(New SqlParameter("@CandidateID", candidateId))
                                          cmd.Parameters.Add(New SqlParameter("@InterviewerID", interviewerId))
                                          cmd.Parameters.Add(New SqlParameter("@InterviewNotes", If(interviewNotes, DBNull.Value)))
                                          cmd.Parameters.Add(New SqlParameter("@InterviewOutcome", If(interviewOutcome, DBNull.Value)))

                                          conn.Open()
                                          Dim result As Object = cmd.ExecuteScalar()
                                          conn.Close()

                                          Return If(result IsNot Nothing, result.ToString(), "Error: No result returned from stored procedure.")
                                      End Using
                                  End Using
                              End Function)
    End Function
End Class
