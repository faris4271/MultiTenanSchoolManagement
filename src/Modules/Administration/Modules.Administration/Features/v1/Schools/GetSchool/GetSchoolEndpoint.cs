using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Schools.GetSchool;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Schools.GetSchool;

public static class GetSchoolEndpoint
{
    internal static RouteHandlerBuilder MapGetSchoolEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/schools/{id:guid}", (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(new GetSchoolQuery(id), cancellationToken))
        .WithName("GetSchool")
        .WithSummary("Get school")
        .RequirePermission(AdministrationPermissionConstants.Schools.View);
    }
}
