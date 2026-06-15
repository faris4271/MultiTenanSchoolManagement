using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.HumanResources.Contracts.v1.Employees.CheckIn;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.HumanResources.Features.v1.Employees.CheckIn;

public static class CheckInEndpoint
{
    internal static RouteHandlerBuilder MapCheckInEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/employees/{id:guid}/check-in", (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(new CheckInCommand(id), cancellationToken))
        .WithName(nameof(CheckInCommand))
        .WithSummary("Check in employee")
        .RequirePermission(HumanResourcesPermissionConstants.Employees.CheckIn);
    }
}
