Imports HRMS.Business
Imports HRMS.Repository
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

        builder.Services.AddDbContext(Of HRMSContext)
        builder.Services.AddAutoMapper(GetType(AutoMapperProfiles))

        builder.Services.AddScoped(Of ILeavesTypeRepository, LeavesTypeRepository)
        builder.Services.AddScoped(Of ILeavesTypeBs, LeavesTypeBs)

        builder.Services.AddScoped(Of ICandidateRepository, CandidateRepository)
        builder.Services.AddScoped(Of ICandidateBs, CandidateBs)

        builder.Services.AddScoped(Of IEmployeeRepository, EmployeeRepository)
        builder.Services.AddScoped(Of IEmployeeBs, EmployeeBs)

        builder.Services.AddScoped(Of IDepartmentRepository, DepartmentRepository)
        builder.Services.AddScoped(Of IDepartmentBs, DepartmentBs)

        builder.Services.AddScoped(Of IPositionRepository, PositionRepository)
        builder.Services.AddScoped(Of IPositionBs, PositionBs)
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