using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.NoticeBoards.DeleteNoticeBoard;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.DeleteNoticeBoard;

public static class DeleteNoticeBoardEndpoint
{
    internal static RouteHandlerBuilder MapDeleteNoticeBoardEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapDelete("/notice-boards/{id:guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(new DeleteNoticeBoardCommand(id), cancellationToken);
            return TypedResults.NoContent();
        })
        .WithName("DeleteNoticeBoard")
        .WithSummary("Delete notice board")
        .RequirePermission(AdministrationPermissionConstants.NoticeBoards.Delete);
    }
}
