using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Auditoriums.GetAuditorium;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.GetAuditorium;

public static class GetAuditoriumEndpoint
{
    internal static RouteHandlerBuilder MapGetAuditoriumEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/auditoriums/{id:guid}", (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(new GetAuditoriumQuery(id), cancellationToken))
        .WithName("GetAuditorium")
        .WithSummary("Get auditorium")
        .RequirePermission(AdministrationPermissionConstants.Auditoriums.View);
    }
}
