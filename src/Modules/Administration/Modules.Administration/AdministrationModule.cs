using Asp.Versioning;
using FSH.Framework.Persistence;
using FSH.Framework.Web.Modules;
using FSH.Modules.Administration.Data;
using FSH.Modules.Administration.Features.v1.Auditoriums.BookAuditorium;
using FSH.Modules.Administration.Features.v1.Auditoriums.CreateAuditorium;
using FSH.Modules.Administration.Features.v1.Auditoriums.DeleteAuditorium;
using FSH.Modules.Administration.Features.v1.Auditoriums.GetAuditorium;
using FSH.Modules.Administration.Features.v1.Auditoriums.GetAuditoriums;
using FSH.Modules.Administration.Features.v1.Auditoriums.UpdateAuditorium;
using FSH.Modules.Administration.Features.v1.Departments.CreateDepartment;
using FSH.Modules.Administration.Features.v1.Departments.DeleteDepartment;
using FSH.Modules.Administration.Features.v1.Departments.GetDepartment;
using FSH.Modules.Administration.Features.v1.Departments.GetDepartments;
using FSH.Modules.Administration.Features.v1.Departments.UpdateDepartment;
using FSH.Modules.Administration.Features.v1.NoticeBoards.CreateNoticeBoard;
using FSH.Modules.Administration.Features.v1.NoticeBoards.DeleteNoticeBoard;
using FSH.Modules.Administration.Features.v1.NoticeBoards.GetNoticeBoard;
using FSH.Modules.Administration.Features.v1.NoticeBoards.GetNoticeBoards;
using FSH.Modules.Administration.Features.v1.NoticeBoards.UpdateNoticeBoard;
using FSH.Modules.Administration.Features.v1.Playgrounds.CreatePlayground;
using FSH.Modules.Administration.Features.v1.Playgrounds.DeletePlayground;
using FSH.Modules.Administration.Features.v1.Playgrounds.GetPlayground;
using FSH.Modules.Administration.Features.v1.Playgrounds.GetPlaygrounds;
using FSH.Modules.Administration.Features.v1.Playgrounds.UpdatePlayground;
using FSH.Modules.Administration.Features.v1.Schools.CreateSchool;
using FSH.Modules.Administration.Features.v1.Schools.DeleteSchool;
using FSH.Modules.Administration.Features.v1.Schools.GetSchool;
using FSH.Modules.Administration.Features.v1.Schools.GetSchools;
using FSH.Modules.Administration.Features.v1.Schools.UpdateSchool;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace FSH.Modules.Administration;

public class AdministrationModule : IModule
{
    public void ConfigureServices(IHostApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Services.AddHeroDbContext<AdministrationDbContext>();
        builder.Services.AddScoped<IDbInitializer, AdministrationDbInitializer>();
        builder.Services.AddHealthChecks()
            .AddDbContextCheck<AdministrationDbContext>(
                name: "db:administration",
                failureStatus: HealthStatus.Unhealthy);
    }

    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var apiVersionSet = endpoints.NewApiVersionSet()
            .HasApiVersion(new Asp.Versioning.ApiVersion(1))
            .ReportApiVersions()
            .Build();

        var group = endpoints
            .MapGroup("api/v{version:apiVersion}/administration")
            .WithTags("Administration")
            .WithApiVersionSet(apiVersionSet);

        // schools
        group.MapCreateSchoolEndpoint();
        group.MapGetSchoolEndpoint();
        group.MapGetSchoolsEndpoint();
        group.MapUpdateSchoolEndpoint();
        group.MapDeleteSchoolEndpoint();

        // departments
        group.MapCreateDepartmentEndpoint();
        group.MapGetDepartmentEndpoint();
        group.MapGetDepartmentsEndpoint();
        group.MapUpdateDepartmentEndpoint();
        group.MapDeleteDepartmentEndpoint();

        // auditoriums
        group.MapCreateAuditoriumEndpoint();
        group.MapGetAuditoriumEndpoint();
        group.MapGetAuditoriumsEndpoint();
        group.MapUpdateAuditoriumEndpoint();
        group.MapDeleteAuditoriumEndpoint();
        group.MapBookAuditoriumEndpoint();

        // playgrounds
        group.MapCreatePlaygroundEndpoint();
        group.MapGetPlaygroundEndpoint();
        group.MapGetPlaygroundsEndpoint();
        group.MapUpdatePlaygroundEndpoint();
        group.MapDeletePlaygroundEndpoint();

        // notice boards
        group.MapCreateNoticeBoardEndpoint();
        group.MapGetNoticeBoardEndpoint();
        group.MapGetNoticeBoardsEndpoint();
        group.MapUpdateNoticeBoardEndpoint();
        group.MapDeleteNoticeBoardEndpoint();
    }
}
