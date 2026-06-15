using FSH.Framework.Core.Exceptions;
using FSH.Modules.HumanResources.Contracts.v1.Employees.DeleteEmployee;
using FSH.Modules.HumanResources.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.HumanResources.Features.v1.Employees.DeleteEmployee;

public sealed class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand, Unit>
{
    private readonly HumanResourcesDbContext _dbContext;

    public DeleteEmployeeCommandHandler(HumanResourcesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Unit> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var employee = await _dbContext.Employees
            .FirstOrDefaultAsync(e => e.Id == command.Id, cancellationToken)
            ?? throw new NotFoundException($"Employee with ID '{command.Id}' not found.");

        _dbContext.Employees.Remove(employee);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
