using FSH.Framework.Core.Exceptions;
using FSH.Modules.HumanResources.Contracts.v1.Employees.CheckIn;
using FSH.Modules.HumanResources.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.HumanResources.Features.v1.Employees.CheckIn;

public sealed class CheckInCommandHandler : ICommandHandler<CheckInCommand, Guid>
{
    private readonly HumanResourcesDbContext _dbContext;

    public CheckInCommandHandler(HumanResourcesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(CheckInCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var employee = await _dbContext.Employees
            .FirstOrDefaultAsync(e => e.Id == command.EmployeeId, cancellationToken)
            ?? throw new NotFoundException($"Employee with ID '{command.EmployeeId}' not found.");

        employee.CheckIn();
        await _dbContext.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}
