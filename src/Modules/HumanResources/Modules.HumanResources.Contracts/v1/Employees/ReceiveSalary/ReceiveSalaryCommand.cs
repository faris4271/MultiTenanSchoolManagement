using Mediator;

namespace FSH.Modules.HumanResources.Contracts.v1.Employees.ReceiveSalary;

public sealed record ReceiveSalaryCommand(Guid EmployeeId) : ICommand<Guid>;
