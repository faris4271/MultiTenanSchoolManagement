using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Academics.Contracts.v1.Classrooms.GetClassrooms;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Academics.Features.v1.Classrooms.GetClassrooms;

public static class GetClassroomsEndpoint
{
    internal static RouteHandlerBuilder MapGetClassroomsEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/classrooms", ([AsParameters] GetClassroomsQuery query, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(query, cancellationToken))
        .WithName(nameof(GetClassroomsQuery))
        .WithSummary("Get classrooms list")
        .RequirePermission(AcademicsPermissionConstants.Classrooms.View);
    }
}
