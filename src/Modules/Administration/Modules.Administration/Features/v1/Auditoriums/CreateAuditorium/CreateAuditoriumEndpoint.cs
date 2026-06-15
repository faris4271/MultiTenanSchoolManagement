using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Auditoriums.CreateAuditorium;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.CreateAuditorium;

public static class CreateAuditoriumEndpoint
{
    internal static RouteHandlerBuilder MapCreateAuditoriumEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/auditoriums", async (CreateAuditoriumCommand command, IMediator mediator, CancellationToken cancellationToken) =>
            await mediator.Send(command, cancellationToken))
        .WithName("CreateAuditorium")
        .WithSummary("Create auditorium")
        .RequirePermission(AdministrationPermissionConstants.Auditoriums.Create);
    }
}
