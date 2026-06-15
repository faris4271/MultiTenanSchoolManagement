using Mediator;

namespace FSH.Modules.HumanResources.Contracts.v1.Employees.UpdateEmployee;

public sealed record UpdateEmployeeCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    decimal Salary,
    Guid DepartmentId) : ICommand<Guid>;
