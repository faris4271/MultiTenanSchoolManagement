using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Departments.UpdateDepartment;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Departments.UpdateDepartment;

public static class UpdateDepartmentEndpoint
{
    internal static RouteHandlerBuilder MapUpdateDepartmentEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/departments/{id:guid}", (Guid id, UpdateDepartmentCommand command, IMediator mediator, CancellationToken cancellationToken) =>
        {
            command = command with { Id = id };
            return mediator.Send(command, cancellationToken);
        })
        .WithName("UpdateDepartment")
        .WithSummary("Update department")
        .RequirePermission(AdministrationPermissionConstants.Departments.Update);
    }
}
