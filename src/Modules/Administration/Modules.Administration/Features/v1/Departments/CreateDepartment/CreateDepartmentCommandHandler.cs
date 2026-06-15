using FSH.Modules.Administration.Contracts.v1.Departments.CreateDepartment;
using FSH.Modules.Administration.Data;
using FSH.Modules.Administration.Domain;
using Mediator;

namespace FSH.Modules.Administration.Features.v1.Departments.CreateDepartment;

public sealed class CreateDepartmentCommandHandler : ICommandHandler<CreateDepartmentCommand, Guid>
{
    private readonly AdministrationDbContext _dbContext;

    public CreateDepartmentCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var department = Department.Create(command.Name, command.SchoolId, command.Description);

        await _dbContext.Departments.AddAsync(department, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return department.Id;
    }
}
