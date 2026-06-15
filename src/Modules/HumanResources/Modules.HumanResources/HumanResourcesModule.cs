using Asp.Versioning;
using FSH.Framework.Persistence;
using FSH.Framework.Web.Modules;
using FSH.Modules.HumanResources.Data;
using FSH.Modules.HumanResources.Features.v1.Employees.CheckIn;
using FSH.Modules.HumanResources.Features.v1.Employees.CreateEmployee;
using FSH.Modules.HumanResources.Features.v1.Employees.DeleteEmployee;
using FSH.Modules.HumanResources.Features.v1.Employees.GetEmployee;
using FSH.Modules.HumanResources.Features.v1.Employees.GetEmployees;
using FSH.Modules.HumanResources.Features.v1.Employees.ReceiveSalary;
using FSH.Modules.HumanResources.Features.v1.Employees.UpdateEmployee;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace FSH.Modules.HumanResources;

public class HumanResourcesModule : IModule
{
    public void ConfigureServices(IHostApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Services.AddHeroDbContext<HumanResourcesDbContext>();
        builder.Services.AddScoped<IDbInitializer, HumanResourcesDbInitializer>();
        builder.Services.AddHealthChecks()
            .AddDbContextCheck<HumanResourcesDbContext>(
                name: "db:hr",
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
            .MapGroup("api/v{version:apiVersion}/hr")
            .WithTags("HumanResources")
            .WithApiVersionSet(apiVersionSet);

        // employees
        group.MapCreateEmployeeEndpoint();
        group.MapGetEmployeeEndpoint();
        group.MapGetEmployeesEndpoint();
        group.MapUpdateEmployeeEndpoint();
        group.MapDeleteEmployeeEndpoint();
        group.MapReceiveSalaryEndpoint();
        group.MapCheckInEndpoint();
    }
}
