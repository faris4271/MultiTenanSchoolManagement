using FSH.Modules.Administration.Contracts.v1.Auditoriums.CreateAuditorium;
using FSH.Modules.Administration.Data;
using FSH.Modules.Administration.Domain;
using Mediator;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.CreateAuditorium;

public sealed class CreateAuditoriumCommandHandler : ICommandHandler<CreateAuditoriumCommand, Guid>
{
    private readonly AdministrationDbContext _dbContext;

    public CreateAuditoriumCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(CreateAuditoriumCommand command, CancellationToken cancellationToken)
    {
        var auditorium = Auditorium.Create(command.Name, command.TotalSeats, command.SchoolId);

        await _dbContext.Auditoriums.AddAsync(auditorium, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return auditorium.Id;
    }
}
