using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Departments.GetDepartment;

public sealed record GetDepartmentQuery(Guid Id) : IQuery<DepartmentResponse>;
