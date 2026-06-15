using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Schools.CreateSchool;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Schools.CreateSchool;

public static class CreateSchoolEndpoint
{
    internal static RouteHandlerBuilder MapCreateSchoolEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/schools", async (CreateSchoolCommand command, IMediator mediator, CancellationToken cancellationToken) =>
            await mediator.Send(command, cancellationToken))
        .WithName("CreateSchool")
        .WithSummary("Create school")
        .RequirePermission(AdministrationPermissionConstants.Schools.Create);
    }
}
