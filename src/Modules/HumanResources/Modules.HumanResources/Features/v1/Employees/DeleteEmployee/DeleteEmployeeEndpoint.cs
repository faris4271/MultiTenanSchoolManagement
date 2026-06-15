using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.HumanResources.Contracts.v1.Employees.DeleteEmployee;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.HumanResources.Features.v1.Employees.DeleteEmployee;

public static class DeleteEmployeeEndpoint
{
    internal static RouteHandlerBuilder MapDeleteEmployeeEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapDelete("/employees/{id:guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(new DeleteEmployeeCommand(id), cancellationToken);
            return TypedResults.NoContent();
        })
        .WithName(nameof(DeleteEmployeeCommand))
        .WithSummary("Delete an employee")
        .RequirePermission(HumanResourcesPermissionConstants.Employees.Delete);
    }
}
