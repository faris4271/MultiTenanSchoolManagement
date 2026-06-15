using FSH.Modules.Administration.Contracts.v1.NoticeBoards.UpdateNoticeBoard;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.UpdateNoticeBoard;

public sealed class UpdateNoticeBoardCommandHandler : ICommandHandler<UpdateNoticeBoardCommand, Guid>
{
    private readonly AdministrationDbContext _dbContext;

    public UpdateNoticeBoardCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(UpdateNoticeBoardCommand command, CancellationToken cancellationToken)
    {
        var noticeBoard = await _dbContext.NoticeBoards
            .FirstOrDefaultAsync(n => n.Id == command.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Notice board with ID '{command.Id}' not found.");

        noticeBoard.Update(command.Title, command.Content, command.ExpiresAtUtc);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return noticeBoard.Id;
    }
}
