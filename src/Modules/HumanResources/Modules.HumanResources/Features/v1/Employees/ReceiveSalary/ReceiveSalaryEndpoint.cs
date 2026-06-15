using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.HumanResources.Contracts.v1.Employees.ReceiveSalary;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.HumanResources.Features.v1.Employees.ReceiveSalary;

public static class ReceiveSalaryEndpoint
{
    internal static RouteHandlerBuilder MapReceiveSalaryEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/employees/{id:guid}/receive-salary", (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(new ReceiveSalaryCommand(id), cancellationToken))
        .WithName(nameof(ReceiveSalaryCommand))
        .WithSummary("Receive employee salary")
        .RequirePermission(HumanResourcesPermissionConstants.Employees.ReceiveSalary);
    }
}
