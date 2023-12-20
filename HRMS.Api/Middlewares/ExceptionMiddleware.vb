Imports System.Linq.Expressions
Imports System.Runtime.CompilerServices
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Http
Imports Microsoft.AspNetCore.Diagnostics
Imports Infrastructure
Imports Infrastructure.Infrastructure.Utilities.ApiResponses
Imports System.Text.Json

Public Module ExceptionMiddleware

    <Extension()>
    Public Sub UseCustomException(app As IApplicationBuilder)
        app.UseExceptionHandler(Sub(config)
                                    config.Run(Async Function(context)
                                                   context.Response.ContentType = "application/json"
                                                   Dim exceptionFeature = context.Features.Get(Of IExceptionHandlerFeature)()
                                                   Dim statusCode = StatusCodes.Status500InternalServerError
                                                   If TypeOf exceptionFeature.Error Is BadRequestException Then
                                                       statusCode = StatusCodes.Status400BadRequest
                                                   ElseIf TypeOf exceptionFeature.Error Is NotFoundException Then
                                                       statusCode = StatusCodes.Status404NotFound
                                                   End If

                                                   context.Response.StatusCode = statusCode
                                                   Dim response = ApiResponse(Of NoData).Fail(statusCode, exceptionFeature.Error.Message)
                                                   Await context.Response.WriteAsync(JsonSerializer.Serialize(response))
                                               End Function)
                                End Sub)
    End Sub
End Module
