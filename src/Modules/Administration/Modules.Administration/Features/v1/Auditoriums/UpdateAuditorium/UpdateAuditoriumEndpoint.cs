using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Auditoriums.UpdateAuditorium;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.UpdateAuditorium;

public static class UpdateAuditoriumEndpoint
{
    internal static RouteHandlerBuilder MapUpdateAuditoriumEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/auditoriums/{id:guid}", (Guid id, UpdateAuditoriumCommand command, IMediator mediator, CancellationToken cancellationToken) =>
        {
            command = command with { Id = id };
            return mediator.Send(command, cancellationToken);
        })
        .WithName("UpdateAuditorium")
        .WithSummary("Update auditorium")
        .RequirePermission(AdministrationPermissionConstants.Auditoriums.Update);
    }
}
