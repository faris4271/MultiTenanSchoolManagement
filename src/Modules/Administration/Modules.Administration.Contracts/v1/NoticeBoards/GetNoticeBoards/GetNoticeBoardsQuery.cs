using FSH.Framework.Shared.Persistence;
using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.NoticeBoards.GetNoticeBoards;

public sealed class GetNoticeBoardsQuery : IPagedQuery, IQuery<PagedResponse<NoticeBoardResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? Sort { get; set; }
    public Guid? SchoolId { get; set; }
    public bool? IsActive { get; set; }
}
