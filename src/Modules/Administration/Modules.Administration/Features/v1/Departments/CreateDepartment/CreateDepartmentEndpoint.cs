using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Departments.CreateDepartment;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Departments.CreateDepartment;

public static class CreateDepartmentEndpoint
{
    internal static RouteHandlerBuilder MapCreateDepartmentEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/departments", async (CreateDepartmentCommand command, IMediator mediator, CancellationToken cancellationToken) =>
            await mediator.Send(command, cancellationToken))
        .WithName("CreateDepartment")
        .WithSummary("Create department")
        .RequirePermission(AdministrationPermissionConstants.Departments.Create);
    }
}
