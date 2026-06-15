using FSH.Modules.Administration.Contracts.v1.Auditoriums.UpdateAuditorium;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.UpdateAuditorium;

public sealed class UpdateAuditoriumCommandHandler : ICommandHandler<UpdateAuditoriumCommand, Guid>
{
    private readonly AdministrationDbContext _dbContext;

    public UpdateAuditoriumCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(UpdateAuditoriumCommand command, CancellationToken cancellationToken)
    {
        var auditorium = await _dbContext.Auditoriums
            .FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Auditorium with ID '{command.Id}' not found.");

        auditorium.Update(command.Name, command.TotalSeats);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return auditorium.Id;
    }
}
