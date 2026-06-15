using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Academics.Contracts.v1.Students.PayFees;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Academics.Features.v1.Students.PayFees;

public static class PayFeesEndpoint
{
    internal static RouteHandlerBuilder MapPayFeesEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/students/{id:guid}/pay-fees", (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(new PayFeesCommand(id), cancellationToken))
        .WithName(nameof(PayFeesCommand))
        .WithSummary("Pay student fees")
        .RequirePermission(AcademicsPermissionConstants.Students.PayFees);
    }
}
