using FSH.Framework.Shared.Identity.Authorization;
using FSH.Modules.Administration.Contracts.v1.NoticeBoards.GetNoticeBoards;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.GetNoticeBoards;

public static class GetNoticeBoardsEndpoint
{
    internal static RouteHandlerBuilder MapGetNoticeBoardsEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/notice-boards", ([AsParameters] GetNoticeBoardsQuery query, IMediator mediator, CancellationToken cancellationToken) =>
            mediator.Send(query, cancellationToken))
        .WithName("GetNoticeBoards")
        .WithSummary("Get notice boards")
        .RequirePermission(AdministrationPermissionConstants.NoticeBoards.View);
    }
}
