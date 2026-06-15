using FSH.Modules.Administration.Contracts.v1.NoticeBoards.DeleteNoticeBoard;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.DeleteNoticeBoard;

public sealed class DeleteNoticeBoardCommandHandler : ICommandHandler<DeleteNoticeBoardCommand, Unit>
{
    private readonly AdministrationDbContext _dbContext;

    public DeleteNoticeBoardCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Unit> Handle(DeleteNoticeBoardCommand command, CancellationToken cancellationToken)
    {
        var noticeBoard = await _dbContext.NoticeBoards
            .FirstOrDefaultAsync(n => n.Id == command.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Notice board with ID '{command.Id}' not found.");

        _dbContext.NoticeBoards.Remove(noticeBoard);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
