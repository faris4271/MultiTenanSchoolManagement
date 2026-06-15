using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Schools.DeleteSchool;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Schools.DeleteSchool;

public static class DeleteSchoolEndpoint
{
    internal static RouteHandlerBuilder MapDeleteSchoolEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapDelete("/schools/{id:guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(new DeleteSchoolCommand(id), cancellationToken);
            return TypedResults.NoContent();
        })
        .WithName("DeleteSchool")
        .WithSummary("Delete school")
        .RequirePermission(AdministrationPermissionConstants.Schools.Delete);
    }
}
