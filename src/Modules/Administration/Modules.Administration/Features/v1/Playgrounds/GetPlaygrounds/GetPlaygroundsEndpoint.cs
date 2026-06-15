using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Playgrounds.GetPlaygrounds;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.GetPlaygrounds;

public static class GetPlaygroundsEndpoint
{
    internal static RouteHandlerBuilder MapGetPlaygroundsEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/playgrounds", ([AsParameters] GetPlaygroundsQuery query, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(query, cancellationToken))
        .WithName("GetPlaygrounds")
        .WithSummary("Get playgrounds")
        .RequirePermission(AdministrationPermissionConstants.Playgrounds.View);
    }
}
