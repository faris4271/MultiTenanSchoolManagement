using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.NoticeBoards.GetNoticeBoard;

public sealed record GetNoticeBoardQuery(Guid Id) : IQuery<NoticeBoardResponse>;
