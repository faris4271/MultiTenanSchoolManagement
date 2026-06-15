using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Playgrounds.CreatePlayground;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.CreatePlayground;

public static class CreatePlaygroundEndpoint
{
    internal static RouteHandlerBuilder MapCreatePlaygroundEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/playgrounds", async (CreatePlaygroundCommand command, IMediator mediator, CancellationToken cancellationToken) =>
            await mediator.Send(command, cancellationToken))
        .WithName("CreatePlayground")
        .WithSummary("Create playground")
        .RequirePermission(AdministrationPermissionConstants.Playgrounds.Create);
    }
}
