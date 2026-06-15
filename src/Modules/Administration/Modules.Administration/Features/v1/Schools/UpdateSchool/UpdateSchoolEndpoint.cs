using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Schools.UpdateSchool;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Schools.UpdateSchool;

public static class UpdateSchoolEndpoint
{
    internal static RouteHandlerBuilder MapUpdateSchoolEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/schools/{id:guid}", (Guid id, UpdateSchoolCommand command, IMediator mediator, CancellationToken cancellationToken) =>
        {
            command = command with { Id = id };
            return mediator.Send(command, cancellationToken);
        })
        .WithName("UpdateSchool")
        .WithSummary("Update school")
        .RequirePermission(AdministrationPermissionConstants.Schools.Update);
    }
}
