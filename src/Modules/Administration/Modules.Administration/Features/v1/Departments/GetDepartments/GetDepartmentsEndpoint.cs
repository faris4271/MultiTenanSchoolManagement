using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Departments.GetDepartments;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Departments.GetDepartments;

public static class GetDepartmentsEndpoint
{
    internal static RouteHandlerBuilder MapGetDepartmentsEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/departments", ([AsParameters] GetDepartmentsQuery query, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(query, cancellationToken))
        .WithName("GetDepartments")
        .WithSummary("Get departments")
        .RequirePermission(AdministrationPermissionConstants.Departments.View);
    }
}
