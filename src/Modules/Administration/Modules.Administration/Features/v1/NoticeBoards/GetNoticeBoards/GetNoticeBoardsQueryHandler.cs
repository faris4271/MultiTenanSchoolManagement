using FSH.Framework.Persistence;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.Administration.Contracts.v1.NoticeBoards;
using FSH.Modules.Administration.Contracts.v1.NoticeBoards.GetNoticeBoards;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.GetNoticeBoards;

public sealed class GetNoticeBoardsQueryHandler : IQueryHandler<GetNoticeBoardsQuery, PagedResponse<NoticeBoardResponse>>
{
    private readonly AdministrationDbContext _dbContext;

    public GetNoticeBoardsQueryHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<PagedResponse<NoticeBoardResponse>> Handle(GetNoticeBoardsQuery query, CancellationToken cancellationToken)
    {
        var noticeBoards = _dbContext.NoticeBoards.AsNoTracking();

        if (query.SchoolId.HasValue)
        {
            noticeBoards = noticeBoards.Where(n => n.SchoolId == query.SchoolId.Value);
        }

        if (query.IsActive.HasValue)
        {
            noticeBoards = noticeBoards.Where(n => n.IsActive == query.IsActive.Value);
        }

        var projected = noticeBoards.Select(n => new NoticeBoardResponse
        {
            Id = n.Id,
            Title = n.Title,
            Content = n.Content,
            IsActive = n.IsActive,
            ExpiresAtUtc = n.ExpiresAtUtc,
            SchoolId = n.SchoolId
        });

        return await projected.ToPagedResponseAsync(query, cancellationToken);
    }
}
