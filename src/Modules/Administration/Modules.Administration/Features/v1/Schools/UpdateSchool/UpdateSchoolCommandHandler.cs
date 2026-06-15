using FSH.Modules.Administration.Contracts.v1.Schools.UpdateSchool;
using FSH.Modules.Administration.Data;
using FSH.Modules.Administration.Domain.ValueObjects;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Schools.UpdateSchool;

public sealed class UpdateSchoolCommandHandler : ICommandHandler<UpdateSchoolCommand, Guid>
{
    private readonly AdministrationDbContext _dbContext;

    public UpdateSchoolCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(UpdateSchoolCommand command, CancellationToken cancellationToken)
    {
        var school = await _dbContext.Schools
            .FirstOrDefaultAsync(s => s.Id == command.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"School with ID '{command.Id}' not found.");

        var address = new Address
        {
            Street = command.Street,
            City = command.City,
            State = command.State,
            ZipCode = command.ZipCode,
            Country = command.Country
        };

        school.Update(command.Name, command.MediumOfStudy, address);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return school.Id;
    }
}
