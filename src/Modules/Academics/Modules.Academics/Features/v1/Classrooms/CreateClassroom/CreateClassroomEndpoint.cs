using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Academics.Contracts.v1.Classrooms.CreateClassroom;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Academics.Features.v1.Classrooms.CreateClassroom;

public static class CreateClassroomEndpoint
{
    internal static RouteHandlerBuilder MapCreateClassroomEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/classrooms", (CreateClassroomCommand command, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(command, cancellationToken))
        .WithName(nameof(CreateClassroomCommand))
        .WithSummary("Create a new classroom")
        .RequirePermission(AcademicsPermissionConstants.Classrooms.Create);
    }
}
