using FSH.Modules.Administration.Contracts.v1.Playgrounds.UpdatePlayground;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.UpdatePlayground;

public sealed class UpdatePlaygroundCommandHandler : ICommandHandler<UpdatePlaygroundCommand, Guid>
{
    private readonly AdministrationDbContext _dbContext;

    public UpdatePlaygroundCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(UpdatePlaygroundCommand command, CancellationToken cancellationToken)
    {
        var playground = await _dbContext.Playgrounds
            .FirstOrDefaultAsync(p => p.Id == command.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Playground with ID '{command.Id}' not found.");

        playground.Update(command.Name);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return playground.Id;
    }
}
