using FSH.Framework.Core.Exceptions;
using FSH.Modules.HumanResources.Contracts.v1.Employees.ReceiveSalary;
using FSH.Modules.HumanResources.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.HumanResources.Features.v1.Employees.ReceiveSalary;

public sealed class ReceiveSalaryCommandHandler : ICommandHandler<ReceiveSalaryCommand, Guid>
{
    private readonly HumanResourcesDbContext _dbContext;

    public ReceiveSalaryCommandHandler(HumanResourcesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(ReceiveSalaryCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var employee = await _dbContext.Employees
            .FirstOrDefaultAsync(e => e.Id == command.EmployeeId, cancellationToken)
            ?? throw new NotFoundException($"Employee with ID '{command.EmployeeId}' not found.");

        employee.ReceiveSalary();
        await _dbContext.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}
