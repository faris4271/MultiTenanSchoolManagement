using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Departments.GetDepartment;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Departments.GetDepartment;

public static class GetDepartmentEndpoint
{
    internal static RouteHandlerBuilder MapGetDepartmentEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/departments/{id:guid}", (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(new GetDepartmentQuery(id), cancellationToken))
        .WithName("GetDepartment")
        .WithSummary("Get department")
        .RequirePermission(AdministrationPermissionConstants.Departments.View);
    }
}
