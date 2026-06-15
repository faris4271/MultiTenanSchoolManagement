using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Departments.CreateDepartment;

public sealed record CreateDepartmentCommand(
    string Name,
    Guid SchoolId,
    string? Description) : ICommand<Guid>;
