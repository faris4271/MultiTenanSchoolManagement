using FSH.Modules.Administration.Contracts.v1.Schools;
using FSH.Modules.Administration.Contracts.v1.Schools.GetSchool;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Schools.GetSchool;

public sealed class GetSchoolQueryHandler : IQueryHandler<GetSchoolQuery, SchoolResponse>
{
    private readonly AdministrationDbContext _dbContext;

    public GetSchoolQueryHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<SchoolResponse> Handle(GetSchoolQuery query, CancellationToken cancellationToken)
    {
        var school = await _dbContext.Schools
            .Where(s => s.Id == query.Id)
            .Select(s => new SchoolResponse
            {
                Id = s.Id,
                Name = s.Name,
                MediumOfStudy = s.MediumOfStudy,
                Street = s.Address.Street,
                City = s.Address.City,
                State = s.Address.State,
                ZipCode = s.Address.ZipCode,
                Country = s.Address.Country
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"School with ID '{query.Id}' not found.");

        return school;
    }
}
