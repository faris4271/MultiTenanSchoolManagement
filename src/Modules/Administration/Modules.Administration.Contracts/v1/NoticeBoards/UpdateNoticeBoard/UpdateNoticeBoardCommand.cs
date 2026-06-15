using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.NoticeBoards.UpdateNoticeBoard;

public sealed record UpdateNoticeBoardCommand(
    Guid Id,
    string Title,
    string Content,
    DateTime? ExpiresAtUtc) : ICommand<Guid>;
