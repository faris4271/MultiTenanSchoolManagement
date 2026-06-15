using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.HumanResources.Contracts.v1.Employees.UpdateEmployee;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.HumanResources.Features.v1.Employees.UpdateEmployee;

public static class UpdateEmployeeEndpoint
{
    internal static RouteHandlerBuilder MapUpdateEmployeeEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/employees/{id:guid}", (Guid id, UpdateEmployeeCommand command, IMediator mediator, CancellationToken cancellationToken) =>
        {
            command = command with { Id = id };
            return mediator.Send(command, cancellationToken);
        })
        .WithName(nameof(UpdateEmployeeCommand))
        .WithSummary("Update an employee")
        .RequirePermission(HumanResourcesPermissionConstants.Employees.Update);
    }
}
