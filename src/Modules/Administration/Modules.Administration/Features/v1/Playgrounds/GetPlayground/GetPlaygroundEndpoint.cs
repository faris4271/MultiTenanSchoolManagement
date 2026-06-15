using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Playgrounds.GetPlayground;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.GetPlayground;

public static class GetPlaygroundEndpoint
{
    internal static RouteHandlerBuilder MapGetPlaygroundEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/playgrounds/{id:guid}", (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(new GetPlaygroundQuery(id), cancellationToken))
        .WithName("GetPlayground")
        .WithSummary("Get playground")
        .RequirePermission(AdministrationPermissionConstants.Playgrounds.View);
    }
}
