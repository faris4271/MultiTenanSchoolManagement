using FSH.Modules.Administration.Contracts.v1.Departments.DeleteDepartment;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Departments.DeleteDepartment;

public sealed class DeleteDepartmentCommandHandler : ICommandHandler<DeleteDepartmentCommand, Unit>
{
    private readonly AdministrationDbContext _dbContext;

    public DeleteDepartmentCommandHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Unit> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
    {
        var department = await _dbContext.Departments
            .FirstOrDefaultAsync(d => d.Id == command.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Department with ID '{command.Id}' not found.");

        _dbContext.Departments.Remove(department);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
