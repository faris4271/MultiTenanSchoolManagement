using FSH.Framework.Persistence;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.Administration.Contracts.v1.Schools;
using FSH.Modules.Administration.Contracts.v1.Schools.GetSchools;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Schools.GetSchools;

public sealed class GetSchoolsQueryHandler : IQueryHandler<GetSchoolsQuery, PagedResponse<SchoolResponse>>
{
    private readonly AdministrationDbContext _dbContext;

    public GetSchoolsQueryHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<PagedResponse<SchoolResponse>> Handle(GetSchoolsQuery query, CancellationToken cancellationToken)
    {
        var schools = _dbContext.Schools.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            schools = schools.Where(s => s.Name.Contains(query.Search));
        }

        var projected = schools.Select(s => new SchoolResponse
        {
            Id = s.Id,
            Name = s.Name,
            MediumOfStudy = s.MediumOfStudy,
            Street = s.Address.Street,
            City = s.Address.City,
            State = s.Address.State,
            ZipCode = s.Address.ZipCode,
            Country = s.Address.Country
        });

        return await projected.ToPagedResponseAsync(query, cancellationToken);
    }
}
