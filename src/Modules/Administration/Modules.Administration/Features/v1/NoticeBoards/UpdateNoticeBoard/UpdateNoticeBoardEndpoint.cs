using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.NoticeBoards.UpdateNoticeBoard;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.UpdateNoticeBoard;

public static class UpdateNoticeBoardEndpoint
{
    internal static RouteHandlerBuilder MapUpdateNoticeBoardEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPut("/notice-boards/{id:guid}", (Guid id, UpdateNoticeBoardCommand command, IMediator mediator, CancellationToken cancellationToken) =>
        {
            command = command with { Id = id };
            return mediator.Send(command, cancellationToken);
        })
        .WithName("UpdateNoticeBoard")
        .WithSummary("Update notice board")
        .RequirePermission(AdministrationPermissionConstants.NoticeBoards.Update);
    }
}
