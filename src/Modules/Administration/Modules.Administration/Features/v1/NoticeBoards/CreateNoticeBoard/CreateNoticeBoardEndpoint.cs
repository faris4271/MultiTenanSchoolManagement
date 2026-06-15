using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.NoticeBoards.CreateNoticeBoard;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.CreateNoticeBoard;

public static class CreateNoticeBoardEndpoint
{
    internal static RouteHandlerBuilder MapCreateNoticeBoardEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/notice-boards", async (CreateNoticeBoardCommand command, IMediator mediator, CancellationToken cancellationToken) =>
            await mediator.Send(command, cancellationToken))
        .WithName("CreateNoticeBoard")
        .WithSummary("Create notice board")
        .RequirePermission(AdministrationPermissionConstants.NoticeBoards.Create);
    }
}
