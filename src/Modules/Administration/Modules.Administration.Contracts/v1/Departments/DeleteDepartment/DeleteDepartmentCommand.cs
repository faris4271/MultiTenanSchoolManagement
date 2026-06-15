using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Departments.DeleteDepartment;

public sealed record DeleteDepartmentCommand(Guid Id) : ICommand<Unit>;
