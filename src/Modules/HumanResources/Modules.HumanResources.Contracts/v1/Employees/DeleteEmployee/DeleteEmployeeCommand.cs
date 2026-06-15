using Mediator;

namespace FSH.Modules.HumanResources.Contracts.v1.Employees.DeleteEmployee;

public sealed record DeleteEmployeeCommand(Guid Id) : ICommand<Unit>;
