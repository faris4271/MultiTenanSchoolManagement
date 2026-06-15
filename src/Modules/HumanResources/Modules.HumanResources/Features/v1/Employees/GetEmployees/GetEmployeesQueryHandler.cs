using FSH.Framework.Persistence;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.HumanResources.Contracts.v1.Employees;
using FSH.Modules.HumanResources.Contracts.v1.Employees.GetEmployees;
using FSH.Modules.HumanResources.Data;
using FSH.Modules.HumanResources.Domain;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.HumanResources.Features.v1.Employees.GetEmployees;

public sealed class GetEmployeesQueryHandler : IQueryHandler<GetEmployeesQuery, PagedResponse<EmployeeResponse>>
{
    private readonly HumanResourcesDbContext _dbContext;

    public GetEmployeesQueryHandler(HumanResourcesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<PagedResponse<EmployeeResponse>> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        IQueryable<Employee> employees = _dbContext.Employees.AsNoTracking();

        if (query.DepartmentId.HasValue)
        {
            employees = employees.Where(e => e.DepartmentId == query.DepartmentId.Value);
        }

        if (!string.IsNullOrWhiteSpace(query.EmployeeType))
        {
            employees = query.EmployeeType switch
            {
                "Teacher" => employees.OfType<Teacher>(),
                "SupportStaff" => employees.OfType<SupportStaff>(),
                _ => employees
            };
        }

        var paged = await employees.ToPagedResponseAsync(query, cancellationToken);

        var responses = paged.Items.Select(employee => new EmployeeResponse
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Salary = employee.Salary,
            DepartmentId = employee.DepartmentId,
            IsCheckedIn = employee.IsCheckedIn,
            LastCheckInUtc = employee.LastCheckInUtc,
            EmployeeType = employee switch { Teacher => "Teacher", SupportStaff => "SupportStaff", _ => "Unknown" },
            Subject = employee is Teacher t ? t.Subject : null,
            Qualification = employee is Teacher tq ? tq.Qualification : null,
            Role = employee is SupportStaff s ? s.Role : null,
            AssignedArea = employee is SupportStaff sa ? sa.AssignedArea : null,
        }).ToList();

        return new PagedResponse<EmployeeResponse>
        {
            Items = responses,
            PageNumber = paged.PageNumber,
            PageSize = paged.PageSize,
            TotalCount = paged.TotalCount,
            TotalPages = paged.TotalPages
        };
    }
}
