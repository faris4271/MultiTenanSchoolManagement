using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Auditoriums.GetAuditoriums;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.GetAuditoriums;

public static class GetAuditoriumsEndpoint
{
    internal static RouteHandlerBuilder MapGetAuditoriumsEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/auditoriums", ([AsParameters] GetAuditoriumsQuery query, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(query, cancellationToken))
        .WithName("GetAuditoriums")
        .WithSummary("Get auditoriums")
        .RequirePermission(AdministrationPermissionConstants.Auditoriums.View);
    }
}
