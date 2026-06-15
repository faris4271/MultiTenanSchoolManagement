using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Schools.GetSchools;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Schools.GetSchools;

public static class GetSchoolsEndpoint
{
    internal static RouteHandlerBuilder MapGetSchoolsEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/schools", ([AsParameters] GetSchoolsQuery query, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(query, cancellationToken))
        .WithName("GetSchools")
        .WithSummary("Get schools")
        .RequirePermission(AdministrationPermissionConstants.Schools.View);
    }
}
