using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Playgrounds.DeletePlayground;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.DeletePlayground;

public static class DeletePlaygroundEndpoint
{
    internal static RouteHandlerBuilder MapDeletePlaygroundEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapDelete("/playgrounds/{id:guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(new DeletePlaygroundCommand(id), cancellationToken);
            return TypedResults.NoContent();
        })
        .WithName("DeletePlayground")
        .WithSummary("Delete playground")
        .RequirePermission(AdministrationPermissionConstants.Playgrounds.Delete);
    }
}
