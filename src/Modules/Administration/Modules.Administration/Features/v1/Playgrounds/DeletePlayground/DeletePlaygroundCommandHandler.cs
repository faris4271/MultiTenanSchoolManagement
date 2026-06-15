using FSH.Modules.Administration.Contracts.v1.Playgrounds.DeletePlayground;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.DeletePlayground;

public sealed class DeletePlaygroundCommandHandler : ICommandHandler<DeletePlaygroundCommand, Unit>
{
    private readonly AdministrationDbContext _dbContext;

    public DeletePlaygroundCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Unit> Handle(DeletePlaygroundCommand command, CancellationToken cancellationToken)
    {
        var playground = await _dbContext.Playgrounds
            .FirstOrDefaultAsync(p => p.Id == command.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Playground with ID '{command.Id}' not found.");

        _dbContext.Playgrounds.Remove(playground);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
