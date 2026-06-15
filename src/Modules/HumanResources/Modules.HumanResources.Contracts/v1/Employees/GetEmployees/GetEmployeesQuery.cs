using FSH.Framework.Shared.Persistence;
using Mediator;

namespace FSH.Modules.HumanResources.Contracts.v1.Employees.GetEmployees;

public sealed class GetEmployeesQuery : IPagedQuery, IQuery<PagedResponse<EmployeeResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? Sort { get; set; }
    public Guid? DepartmentId { get; set; }
    public string? EmployeeType { get; set; }
}
