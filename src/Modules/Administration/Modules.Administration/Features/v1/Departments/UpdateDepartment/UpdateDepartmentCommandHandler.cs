using FSH.Modules.Administration.Contracts.v1.Departments.UpdateDepartment;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Departments.UpdateDepartment;

public sealed class UpdateDepartmentCommandHandler : ICommandHandler<UpdateDepartmentCommand, Guid>
{
    private readonly AdministrationDbContext _dbContext;

    public UpdateDepartmentCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var department = await _dbContext.Departments
            .FirstOrDefaultAsync(d => d.Id == command.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Department with ID '{command.Id}' not found.");

        department.Update(command.Name, command.Description);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return department.Id;
    }
}
