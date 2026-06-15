using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.HumanResources.Contracts.v1.Employees.CreateEmployee;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.HumanResources.Features.v1.Employees.CreateEmployee;

public static class CreateEmployeeEndpoint
{
    internal static RouteHandlerBuilder MapCreateEmployeeEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/employees", (CreateEmployeeCommand command, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(command, cancellationToken))
        .WithName(nameof(CreateEmployeeCommand))
        .WithSummary("Create a new employee")
        .RequirePermission(HumanResourcesPermissionConstants.Employees.Create);
    }
}
