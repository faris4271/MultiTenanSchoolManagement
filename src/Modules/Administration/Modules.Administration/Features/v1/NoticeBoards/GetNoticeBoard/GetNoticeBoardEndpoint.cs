using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.NoticeBoards.GetNoticeBoard;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.GetNoticeBoard;

public static class GetNoticeBoardEndpoint
{
    internal static RouteHandlerBuilder MapGetNoticeBoardEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/notice-boards/{id:guid}", (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(new GetNoticeBoardQuery(id), cancellationToken))
        .WithName("GetNoticeBoard")
        .WithSummary("Get notice board")
        .RequirePermission(AdministrationPermissionConstants.NoticeBoards.View);
    }
}
