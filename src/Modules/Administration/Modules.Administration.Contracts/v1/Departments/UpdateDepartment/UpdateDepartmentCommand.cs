using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Departments.UpdateDepartment;

public sealed record UpdateDepartmentCommand(
    Guid Id,
    string Name,
    string? Description) : ICommand<Guid>;
