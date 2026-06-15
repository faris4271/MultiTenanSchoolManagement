using FSH.Framework.Persistence;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.Administration.Contracts.v1.Auditoriums;
using FSH.Modules.Administration.Contracts.v1.Auditoriums.GetAuditoriums;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.GetAuditoriums;

public sealed class GetAuditoriumsQueryHandler : IQueryHandler<GetAuditoriumsQuery, PagedResponse<AuditoriumResponse>>
{
    private readonly AdministrationDbContext _dbContext;

    public GetAuditoriumsQueryHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<PagedResponse<AuditoriumResponse>> Handle(GetAuditoriumsQuery query, CancellationToken cancellationToken)
    {
        var auditoriums = _dbContext.Auditoriums.AsNoTracking();

        if (query.SchoolId.HasValue)
        {
            auditoriums = auditoriums.Where(a => a.SchoolId == query.SchoolId.Value);
        }

        var projected = auditoriums.Select(a => new AuditoriumResponse
        {
            Id = a.Id,
            Name = a.Name,
            TotalSeats = a.TotalSeats,
            SeatsOccupied = a.SeatsOccupied,
            SchoolId = a.SchoolId
        });

        return await projected.ToPagedResponseAsync(query, cancellationToken);
    }
}
