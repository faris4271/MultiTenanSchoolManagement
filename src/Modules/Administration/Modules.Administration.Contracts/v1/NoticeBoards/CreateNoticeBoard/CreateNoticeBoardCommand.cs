using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.NoticeBoards.CreateNoticeBoard;

public sealed record CreateNoticeBoardCommand(
    string Title,
    string Content,
    Guid SchoolId,
    DateTime? ExpiresAtUtc) : ICommand<Guid>;
