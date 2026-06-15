using Mediator;

namespace FSH.Modules.HumanResources.Contracts.v1.Employees.GetEmployee;

public sealed record GetEmployeeQuery(Guid Id) : IQuery<EmployeeResponse>;
