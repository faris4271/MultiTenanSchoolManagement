using Mediator;

namespace FSH.Modules.HumanResources.Contracts.v1.Employees.CreateEmployee;

public sealed record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    string Email,
    decimal Salary,
    Guid DepartmentId,
    string EmployeeType,
    string? Subject,
    string? Qualification,
    string? Role,
    string? AssignedArea) : ICommand<Guid>;
