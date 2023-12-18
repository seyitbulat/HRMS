Imports Infrastructure.Utilities.Security.JWT
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Text.Json.Serialization
Imports System.Threading.Tasks

Namespace Infrastructure.Utilities.ApiResponses
    Public Class ApiResponse(Of T)
        Public Property Data As T
        Public Property ErrorMessages As List(Of String)
        Public Property StatusCode As Integer

        Public Shared Function Success(statusCode As Integer) As ApiResponse(Of T)
            Return New ApiResponse(Of T) With {.StatusCode = statusCode}
        End Function

        Public Shared Function Success(statusCode As Integer, data As T) As ApiResponse(Of T)
            Return New ApiResponse(Of T) With {.Data = data, .StatusCode = statusCode}
        End Function

        Public Shared Function Fail(statusCode As Integer, errorMessages As List(Of String)) As ApiResponse(Of T)
            Return New ApiResponse(Of T) With {.StatusCode = statusCode, .ErrorMessages = errorMessages}
        End Function

        Public Shared Function Fail(statusCode As Integer, errorMessage As String) As ApiResponse(Of T)
            Return New ApiResponse(Of T) With {.StatusCode = statusCode, .ErrorMessages = New List(Of String) From {errorMessage}}
        End Function
    End Class
End Namespace
