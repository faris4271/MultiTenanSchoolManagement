using FSH.Modules.Administration.Contracts.v1.Schools.CreateSchool;
using FSH.Modules.Administration.Data;
using FSH.Modules.Administration.Domain;
using FSH.Modules.Administration.Domain.ValueObjects;
using Mediator;

namespace FSH.Modules.Administration.Features.v1.Schools.CreateSchool;

public sealed class CreateSchoolCommandHandler : ICommandHandler<CreateSchoolCommand, Guid>
{
    private readonly AdministrationDbContext _dbContext;

    public CreateSchoolCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(CreateSchoolCommand command, CancellationToken cancellationToken)
    {
        var address = new Address
        {
            Street = command.Street,
            City = command.City,
            State = command.State,
            ZipCode = command.ZipCode,
            Country = command.Country
        };

        var school = SchoolManagement.Create(command.Name, command.MediumOfStudy, address);

        await _dbContext.Schools.AddAsync(school, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return school.Id;
    }
}
