using FSH.Modules.Administration.Contracts.v1.NoticeBoards;
using FSH.Modules.Administration.Contracts.v1.NoticeBoards.GetNoticeBoard;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.GetNoticeBoard;

public sealed class GetNoticeBoardQueryHandler : IQueryHandler<GetNoticeBoardQuery, NoticeBoardResponse>
{
    private readonly AdministrationDbContext _dbContext;

    public GetNoticeBoardQueryHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<NoticeBoardResponse> Handle(GetNoticeBoardQuery query, CancellationToken cancellationToken)
    {
        var noticeBoard = await _dbContext.NoticeBoards
            .Where(n => n.Id == query.Id)
            .Select(n => new NoticeBoardResponse
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                IsActive = n.IsActive,
                ExpiresAtUtc = n.ExpiresAtUtc,
                SchoolId = n.SchoolId
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"Notice board with ID '{query.Id}' not found.");

        return noticeBoard;
    }
}
