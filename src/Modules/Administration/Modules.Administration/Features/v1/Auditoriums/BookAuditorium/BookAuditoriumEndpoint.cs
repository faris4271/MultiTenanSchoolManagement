using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.Auditoriums.BookAuditorium;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.BookAuditorium;

public static class BookAuditoriumEndpoint
{
    internal static RouteHandlerBuilder MapBookAuditoriumEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/auditoriums/{id:guid}/book", (Guid id, BookAuditoriumCommand command, IMediator mediator, CancellationToken cancellationToken) =>
        {
            command = command with { AuditoriumId = id };
            return mediator.Send(command, cancellationToken);
        })
        .WithName("BookAuditorium")
        .WithSummary("Book auditorium")
        .RequirePermission(AdministrationPermissionConstants.Auditoriums.Book);
    }
}
