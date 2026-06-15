using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Academics.Contracts.v1.Classrooms.GetClassroom;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Academics.Features.v1.Classrooms.GetClassroom;

public static class GetClassroomEndpoint
{
    internal static RouteHandlerBuilder MapGetClassroomEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/classrooms/{id:guid}", (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(new GetClassroomQuery(id), cancellationToken))
        .WithName(nameof(GetClassroomQuery))
        .WithSummary("Get classroom by ID")
        .RequirePermission(AcademicsPermissionConstants.Classrooms.View);
    }
}
