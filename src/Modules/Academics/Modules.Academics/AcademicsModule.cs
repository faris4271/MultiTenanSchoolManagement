using Asp.Versioning;
using FSH.Framework.Persistence;
using FSH.Framework.Web.Modules;
using FSH.Modules.Academics.Data;
using FSH.Modules.Academics.Features.v1.Classrooms.CreateClassroom;
using FSH.Modules.Academics.Features.v1.Classrooms.DeleteClassroom;
using FSH.Modules.Academics.Features.v1.Classrooms.GetClassroom;
using FSH.Modules.Academics.Features.v1.Classrooms.GetClassrooms;
using FSH.Modules.Academics.Features.v1.Classrooms.UpdateClassroom;
using FSH.Modules.Academics.Features.v1.Students.CreateStudent;
using FSH.Modules.Academics.Features.v1.Students.DeleteStudent;
using FSH.Modules.Academics.Features.v1.Students.GetStudent;
using FSH.Modules.Academics.Features.v1.Students.GetStudents;
using FSH.Modules.Academics.Features.v1.Students.PayFees;
using FSH.Modules.Academics.Features.v1.Students.UpdateStudent;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace FSH.Modules.Academics;

public class AcademicsModule : IModule
{
    public void ConfigureServices(IHostApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Services.AddHeroDbContext<AcademicsDbContext>();
        builder.Services.AddScoped<IDbInitializer, AcademicsDbInitializer>();
        builder.Services.AddHealthChecks()
            .AddDbContextCheck<AcademicsDbContext>(
                name: "db:academics",
                failureStatus: HealthStatus.Unhealthy);
    }

    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var apiVersionSet = endpoints.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .ReportApiVersions()
            .Build();

        var group = endpoints
            .MapGroup("api/v{version:apiVersion}/academics")
            .WithTags("Academics")
            .WithApiVersionSet(apiVersionSet);

        // students
        group.MapCreateStudentEndpoint();
        group.MapGetStudentEndpoint();
        group.MapGetStudentsEndpoint();
        group.MapUpdateStudentEndpoint();
        group.MapDeleteStudentEndpoint();
        group.MapPayFeesEndpoint();

        // classrooms
        group.MapCreateClassroomEndpoint();
        group.MapGetClassroomEndpoint();
        group.MapGetClassroomsEndpoint();
        group.MapUpdateClassroomEndpoint();
        group.MapDeleteClassroomEndpoint();
    }
}
