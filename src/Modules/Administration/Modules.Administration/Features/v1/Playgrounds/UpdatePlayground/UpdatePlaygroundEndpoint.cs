using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Playgrounds.UpdatePlayground;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.UpdatePlayground;

public static class UpdatePlaygroundEndpoint
{
    internal static RouteHandlerBuilder MapUpdatePlaygroundEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/playgrounds/{id:guid}", (Guid id, UpdatePlaygroundCommand command, IMediator mediator, CancellationToken cancellationToken) =>
        {
            command = command with { Id = id };
            return mediator.Send(command, cancellationToken);
        })
        .WithName("UpdatePlayground")
        .WithSummary("Update playground")
        .RequirePermission(AdministrationPermissionConstants.Playgrounds.Update);
    }
}
