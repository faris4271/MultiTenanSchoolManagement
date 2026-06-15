using FSH.Framework.Persistence;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.Administration.Contracts.v1.Departments;
using FSH.Modules.Administration.Contracts.v1.Departments.GetDepartments;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Departments.GetDepartments;

public sealed class GetDepartmentsQueryHandler : IQueryHandler<GetDepartmentsQuery, PagedResponse<DepartmentResponse>>
{
    private readonly AdministrationDbContext _dbContext;

    public GetDepartmentsQueryHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<PagedResponse<DepartmentResponse>> Handle(GetDepartmentsQuery query, CancellationToken cancellationToken)
    {
        var departments = _dbContext.Departments.AsNoTracking();

        if (query.SchoolId.HasValue)
        {
            departments = departments.Where(d => d.SchoolId == query.SchoolId.Value);
        }

        var projected = departments.Select(d => new DepartmentResponse
        {
            Id = d.Id,
            Name = d.Name,
            Description = d.Description,
            SchoolId = d.SchoolId
        });

        return await projected.ToPagedResponseAsync(query, cancellationToken);
    }
}
