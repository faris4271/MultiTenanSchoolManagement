using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Auditoriums.DeleteAuditorium;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.DeleteAuditorium;

public static class DeleteAuditoriumEndpoint
{
    internal static RouteHandlerBuilder MapDeleteAuditoriumEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapDelete("/auditoriums/{id:guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(new DeleteAuditoriumCommand(id), cancellationToken);
            return TypedResults.NoContent();
        })
        .WithName("DeleteAuditorium")
        .WithSummary("Delete auditorium")
        .RequirePermission(AdministrationPermissionConstants.Auditoriums.Delete);
    }
}
