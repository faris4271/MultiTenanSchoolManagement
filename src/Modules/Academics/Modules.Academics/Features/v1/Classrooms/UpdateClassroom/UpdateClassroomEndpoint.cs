using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Academics.Contracts.v1.Classrooms.UpdateClassroom;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Academics.Features.v1.Classrooms.UpdateClassroom;

public static class UpdateClassroomEndpoint
{
    internal static RouteHandlerBuilder MapUpdateClassroomEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/classrooms/{id:guid}", (Guid id, UpdateClassroomCommand command, IMediator mediator, CancellationToken cancellationToken) =>
        {
            command = command with { Id = id };
            return mediator.Send(command, cancellationToken);
        })
        .WithName(nameof(UpdateClassroomCommand))
        .WithSummary("Update a classroom")
        .RequirePermission(AcademicsPermissionConstants.Classrooms.Update);
    }
}
