using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Academics.Contracts.v1.Students.GetStudent;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Academics.Features.v1.Students.GetStudent;

public static class GetStudentEndpoint
{
    internal static RouteHandlerBuilder MapGetStudentEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/students/{id:guid}", (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(new GetStudentQuery(id), cancellationToken))
        .WithName(nameof(GetStudentQuery))
        .WithSummary("Get student by ID")
        .RequirePermission(AcademicsPermissionConstants.Students.View);
    }
}
