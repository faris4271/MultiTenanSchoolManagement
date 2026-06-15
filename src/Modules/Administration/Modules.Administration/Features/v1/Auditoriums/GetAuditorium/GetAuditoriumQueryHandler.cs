using FSH.Modules.Administration.Contracts.v1.Auditoriums;
using FSH.Modules.Administration.Contracts.v1.Auditoriums.GetAuditorium;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.GetAuditorium;

public sealed class GetAuditoriumQueryHandler : IQueryHandler<GetAuditoriumQuery, AuditoriumResponse>
{
    private readonly AdministrationDbContext _dbContext;

    public GetAuditoriumQueryHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<AuditoriumResponse> Handle(GetAuditoriumQuery query, CancellationToken cancellationToken)
    {
        var auditorium = await _dbContext.Auditoriums
            .Where(a => a.Id == query.Id)
            .Select(a => new AuditoriumResponse
            {
                Id = a.Id,
                Name = a.Name,
                TotalSeats = a.TotalSeats,
                SeatsOccupied = a.SeatsOccupied,
                SchoolId = a.SchoolId
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"Auditorium with ID '{query.Id}' not found.");

        return auditorium;
    }
}
