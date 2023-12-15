Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.AspNetCore.Rewrite
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Module Program
    Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(args)

        ' Add services to the container.

        builder.Services.AddControllers()
        ' Learn more about configuring Swagger/OpenAPI at https://aka.ms/
        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddSwaggerGen()

        Dim app = builder.Build()

        app.UseRewriter(New RewriteOptions().AddRedirect("^$", "swagger"))

        '  Configure the HTTP request pipeline.
        If app.Environment.IsDevelopment() Then
            app.UseSwagger()
            app.UseSwaggerUI()
        End If

        app.UseHttpsRedirection()

        app.UseAuthorization()

        app.MapControllers()

        app.Run()
    End Sub
End Module