using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.HumanResources.Contracts.v1.Employees.GetEmployee;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.HumanResources.Features.v1.Employees.GetEmployee;

public static class GetEmployeeEndpoint
{
    internal static RouteHandlerBuilder MapGetEmployeeEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/employees/{id:guid}", (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(new GetEmployeeQuery(id), cancellationToken))
        .WithName(nameof(GetEmployeeQuery))
        .WithSummary("Get employee by ID")
        .RequirePermission(HumanResourcesPermissionConstants.Employees.View);
    }
}
