using FSH.Framework.Core.Exceptions;
using FSH.Modules.HumanResources.Contracts.v1.Employees;
using FSH.Modules.HumanResources.Contracts.v1.Employees.GetEmployee;
using FSH.Modules.HumanResources.Data;
using FSH.Modules.HumanResources.Domain;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.HumanResources.Features.v1.Employees.GetEmployee;

public sealed class GetEmployeeQueryHandler : IQueryHandler<GetEmployeeQuery, EmployeeResponse>
{
    private readonly HumanResourcesDbContext _dbContext;

    public GetEmployeeQueryHandler(HumanResourcesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<EmployeeResponse> Handle(GetEmployeeQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        var employee = await _dbContext.Employees.AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == query.Id, cancellationToken)
            ?? throw new NotFoundException($"Employee with ID '{query.Id}' not found.");

        return new EmployeeResponse
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
        };
    }
}
