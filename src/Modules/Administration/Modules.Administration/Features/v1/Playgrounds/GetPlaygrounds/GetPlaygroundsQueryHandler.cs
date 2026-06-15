using FSH.Framework.Persistence;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.Administration.Contracts.v1.Playgrounds;
using FSH.Modules.Administration.Contracts.v1.Playgrounds.GetPlaygrounds;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.GetPlaygrounds;

public sealed class GetPlaygroundsQueryHandler : IQueryHandler<GetPlaygroundsQuery, PagedResponse<PlaygroundResponse>>
{
    private readonly AdministrationDbContext _dbContext;

    public GetPlaygroundsQueryHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<PagedResponse<PlaygroundResponse>> Handle(GetPlaygroundsQuery query, CancellationToken cancellationToken)
    {
        var playgrounds = _dbContext.Playgrounds.AsNoTracking();

        if (query.SchoolId.HasValue)
        {
            playgrounds = playgrounds.Where(p => p.SchoolId == query.SchoolId.Value);
        }

        var projected = playgrounds.Select(p => new PlaygroundResponse
        {
            Id = p.Id,
            Name = p.Name,
            IsAvailable = p.IsAvailable,
            SchoolId = p.SchoolId
        });

        return await projected.ToPagedResponseAsync(query, cancellationToken);
    }
}
