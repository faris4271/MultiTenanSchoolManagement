using Mediator;

namespace FSH.Modules.HumanResources.Contracts.v1.Employees.CheckIn;

public sealed record CheckInCommand(Guid EmployeeId) : ICommand<Guid>;
