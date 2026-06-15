using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.NoticeBoards.DeleteNoticeBoard;

public sealed record DeleteNoticeBoardCommand(Guid Id) : ICommand<Unit>;
