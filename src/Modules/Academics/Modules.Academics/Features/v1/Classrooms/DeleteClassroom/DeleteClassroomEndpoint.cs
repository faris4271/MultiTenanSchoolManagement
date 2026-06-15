using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Academics.Contracts.v1.Classrooms.DeleteClassroom;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Academics.Features.v1.Classrooms.DeleteClassroom;

public static class DeleteClassroomEndpoint
{
    internal static RouteHandlerBuilder MapDeleteClassroomEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapDelete("/classrooms/{id:guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(new DeleteClassroomCommand(id), cancellationToken);
            return TypedResults.NoContent();
        })
        .WithName(nameof(DeleteClassroomCommand))
        .WithSummary("Delete a classroom")
        .RequirePermission(AcademicsPermissionConstants.Classrooms.Delete);
    }
}
