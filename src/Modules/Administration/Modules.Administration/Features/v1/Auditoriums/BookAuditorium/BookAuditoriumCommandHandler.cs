using FSH.Modules.Administration.Contracts.v1.Auditoriums.BookAuditorium;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.BookAuditorium;

public sealed class BookAuditoriumCommandHandler : ICommandHandler<BookAuditoriumCommand, Guid>
{
    private readonly AdministrationDbContext _dbContext;

    public BookAuditoriumCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(BookAuditoriumCommand command, CancellationToken cancellationToken)
    {
        var auditorium = await _dbContext.Auditoriums
            .FirstOrDefaultAsync(a => a.Id == command.AuditoriumId, cancellationToken)
            ?? throw new KeyNotFoundException($"Auditorium with ID '{command.AuditoriumId}' not found.");

        auditorium.Book(command.Seats);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return auditorium.Id;
    }
}
