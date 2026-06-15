using FSH.Modules.Administration.Contracts.v1.Auditoriums.DeleteAuditorium;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.DeleteAuditorium;

public sealed class DeleteAuditoriumCommandHandler : ICommandHandler<DeleteAuditoriumCommand, Unit>
{
    private readonly AdministrationDbContext _dbContext;

    public DeleteAuditoriumCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Unit> Handle(DeleteAuditoriumCommand command, CancellationToken cancellationToken)
    {
        var auditorium = await _dbContext.Auditoriums
            .FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Auditorium with ID '{command.Id}' not found.");

        _dbContext.Auditoriums.Remove(auditorium);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
