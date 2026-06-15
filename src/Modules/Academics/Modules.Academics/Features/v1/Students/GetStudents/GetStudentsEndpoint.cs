using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Academics.Contracts.v1.Students.GetStudents;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Academics.Features.v1.Students.GetStudents;

public static class GetStudentsEndpoint
{
    internal static RouteHandlerBuilder MapGetStudentsEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/students", ([AsParameters] GetStudentsQuery query, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(query, cancellationToken))
        .WithName(nameof(GetStudentsQuery))
        .WithSummary("Get students list")
        .RequirePermission(AcademicsPermissionConstants.Students.View);
    }
}
