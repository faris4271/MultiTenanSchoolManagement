using FSH.Modules.Administration.Contracts.v1.Departments;
using FSH.Modules.Administration.Contracts.v1.Departments.GetDepartment;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Departments.GetDepartment;

public sealed class GetDepartmentQueryHandler : IQueryHandler<GetDepartmentQuery, DepartmentResponse>
{
    private readonly AdministrationDbContext _dbContext;

    public GetDepartmentQueryHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<DepartmentResponse> Handle(GetDepartmentQuery query, CancellationToken cancellationToken)
    {
        var department = await _dbContext.Departments
            .Where(d => d.Id == query.Id)
            .Select(d => new DepartmentResponse
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                SchoolId = d.SchoolId
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"Department with ID '{query.Id}' not found.");

        return department;
    }
}
