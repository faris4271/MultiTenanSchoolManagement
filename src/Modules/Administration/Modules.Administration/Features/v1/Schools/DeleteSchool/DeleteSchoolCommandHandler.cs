using FSH.Modules.Administration.Contracts.v1.Schools.DeleteSchool;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Schools.DeleteSchool;

public sealed class DeleteSchoolCommandHandler : ICommandHandler<DeleteSchoolCommand, Unit>
{
    private readonly AdministrationDbContext _dbContext;

    public DeleteSchoolCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Unit> Handle(DeleteSchoolCommand command, CancellationToken cancellationToken)
    {
        var school = await _dbContext.Schools
            .FirstOrDefaultAsync(s => s.Id == command.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"School with ID '{command.Id}' not found.");

        _dbContext.Schools.Remove(school);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
