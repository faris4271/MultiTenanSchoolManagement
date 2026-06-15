using FSH.Framework.Core.Exceptions;
using FSH.Modules.HumanResources.Contracts.v1.Employees.UpdateEmployee;
using FSH.Modules.HumanResources.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.HumanResources.Features.v1.Employees.UpdateEmployee;

public sealed class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand, Guid>
{
    private readonly HumanResourcesDbContext _dbContext;

    public UpdateEmployeeCommandHandler(HumanResourcesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var employee = await _dbContext.Employees
            .FirstOrDefaultAsync(e => e.Id == command.Id, cancellationToken)
            ?? throw new NotFoundException($"Employee with ID '{command.Id}' not found.");

        employee.UpdateBasicInfo(command.FirstName, command.LastName, command.Email, command.Salary, command.DepartmentId);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}
