using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Academics.Contracts.v1.Students.UpdateStudent;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Academics.Features.v1.Students.UpdateStudent;

public static class UpdateStudentEndpoint
{
    internal static RouteHandlerBuilder MapUpdateStudentEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/students/{id:guid}", (Guid id, UpdateStudentCommand command, IMediator mediator, CancellationToken cancellationToken) =>
        {
            command = command with { Id = id };
            return mediator.Send(command, cancellationToken);
        })
        .WithName(nameof(UpdateStudentCommand))
        .WithSummary("Update a student")
        .RequirePermission(AcademicsPermissionConstants.Students.Update);
    }
}
