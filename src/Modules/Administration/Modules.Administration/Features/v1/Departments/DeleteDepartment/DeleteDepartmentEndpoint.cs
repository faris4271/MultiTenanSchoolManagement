using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Departments.DeleteDepartment;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Departments.DeleteDepartment;

public static class DeleteDepartmentEndpoint
{
    internal static RouteHandlerBuilder MapDeleteDepartmentEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapDelete("/departments/{id:guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(new DeleteDepartmentCommand(id), cancellationToken);
            return TypedResults.NoContent();
        })
        .WithName("DeleteDepartment")
        .WithSummary("Delete department")
        .RequirePermission(AdministrationPermissionConstants.Departments.Delete);
    }
}
