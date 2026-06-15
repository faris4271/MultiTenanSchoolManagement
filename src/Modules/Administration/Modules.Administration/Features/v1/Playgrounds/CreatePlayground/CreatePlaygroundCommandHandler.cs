using FSH.Modules.Administration.Contracts.v1.Playgrounds.CreatePlayground;
using FSH.Modules.Administration.Data;
using FSH.Modules.Administration.Domain;
using Mediator;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.CreatePlayground;

public sealed class CreatePlaygroundCommandHandler : ICommandHandler<CreatePlaygroundCommand, Guid>
{
    private readonly AdministrationDbContext _dbContext;

    public CreatePlaygroundCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(CreatePlaygroundCommand command, CancellationToken cancellationToken)
    {
        var playground = Playground.Create(command.Name, command.SchoolId);

        await _dbContext.Playgrounds.AddAsync(playground, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return playground.Id;
    }
}
