using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Academics.Contracts.v1.Students.DeleteStudent;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Academics.Features.v1.Students.DeleteStudent;

public static class DeleteStudentEndpoint
{
    internal static RouteHandlerBuilder MapDeleteStudentEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapDelete("/students/{id:guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(new DeleteStudentCommand(id), cancellationToken);
            return TypedResults.NoContent();
        })
        .WithName(nameof(DeleteStudentCommand))
        .WithSummary("Delete a student")
        .RequirePermission(AcademicsPermissionConstants.Students.Delete);
    }
}
