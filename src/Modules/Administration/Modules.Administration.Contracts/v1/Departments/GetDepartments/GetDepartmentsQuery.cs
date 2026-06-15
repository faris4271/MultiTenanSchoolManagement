using FSH.Framework.Shared.Persistence;
using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Departments.GetDepartments;

public sealed class GetDepartmentsQuery : IPagedQuery, IQuery<PagedResponse<DepartmentResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? Sort { get; set; }
    public Guid? SchoolId { get; set; }
}
