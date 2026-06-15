using FSH.Modules.Administration.Contracts.v1.NoticeBoards.CreateNoticeBoard;
using FSH.Modules.Administration.Data;
using FSH.Modules.Administration.Domain;
using Mediator;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.CreateNoticeBoard;

public sealed class CreateNoticeBoardCommandHandler : ICommandHandler<CreateNoticeBoardCommand, Guid>
{
    private readonly AdministrationDbContext _dbContext;

    public CreateNoticeBoardCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(CreateNoticeBoardCommand command, CancellationToken cancellationToken)
    {
        var noticeBoard = NoticeBoard.Create(command.Title, command.Content, command.SchoolId, command.ExpiresAtUtc);

        await _dbContext.NoticeBoards.AddAsync(noticeBoard, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return noticeBoard.Id;
    }
}
