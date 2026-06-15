using FSH.Modules.HumanResources.Contracts.v1.Employees.CreateEmployee;
using FSH.Modules.HumanResources.Data;
using FSH.Modules.HumanResources.Domain;
using Mediator;

namespace FSH.Modules.HumanResources.Features.v1.Employees.CreateEmployee;

public sealed class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, Guid>
{
    private readonly HumanResourcesDbContext _dbContext;

    public CreateEmployeeCommandHandler(HumanResourcesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        Employee employee = command.EmployeeType switch
        {
            "Teacher" => Teacher.Create(
                command.FirstName,
                command.LastName,
                command.Email,
                command.Salary,
                command.DepartmentId,
                command.Subject!,
                command.Qualification),
            "SupportStaff" => SupportStaff.Create(
                command.FirstName,
                command.LastName,
                command.Email,
                command.Salary,
                command.DepartmentId,
                command.Role!,
                command.AssignedArea),
            _ => throw new ArgumentException($"Unknown employee type: {command.EmployeeType}")
        };

        _dbContext.Employees.Add(employee);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}
