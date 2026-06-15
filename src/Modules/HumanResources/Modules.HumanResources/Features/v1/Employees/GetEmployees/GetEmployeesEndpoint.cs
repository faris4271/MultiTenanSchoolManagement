using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.HumanResources.Contracts.v1.Employees.GetEmployees;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.HumanResources.Features.v1.Employees.GetEmployees;

public static class GetEmployeesEndpoint
{
    internal static RouteHandlerBuilder MapGetEmployeesEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/employees", ([AsParameters] GetEmployeesQuery query, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(query, cancellationToken))
        .WithName(nameof(GetEmployeesQuery))
        .WithSummary("Get employees list")
        .RequirePermission(HumanResourcesPermissionConstants.Employees.View);
    }
}
