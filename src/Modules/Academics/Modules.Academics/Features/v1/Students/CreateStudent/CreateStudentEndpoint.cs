using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Academics.Contracts.v1.Students.CreateStudent;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Academics.Features.v1.Students.CreateStudent;

public static class CreateStudentEndpoint
{
    internal static RouteHandlerBuilder MapCreateStudentEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/students", (CreateStudentCommand command, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(command, cancellationToken))
        .WithName(nameof(CreateStudentCommand))
        .WithSummary("Create a new student")
        .RequirePermission(AcademicsPermissionConstants.Students.Create);
    }
}
