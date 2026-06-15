using FSH.Modules.Administration.Contracts.v1.Playgrounds;
using FSH.Modules.Administration.Contracts.v1.Playgrounds.GetPlayground;
using FSH.Modules.Administration.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.GetPlayground;

public sealed class GetPlaygroundQueryHandler : IQueryHandler<GetPlaygroundQuery, PlaygroundResponse>
{
    private readonly AdministrationDbContext _dbContext;

    public GetPlaygroundQueryHandler(AdministrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<PlaygroundResponse> Handle(GetPlaygroundQuery query, CancellationToken cancellationToken)
    {
        var playground = await _dbContext.Playgrounds
            .Where(p => p.Id == query.Id)
            .Select(p => new PlaygroundResponse
            {
                Id = p.Id,
                Name = p.Name,
                IsAvailable = p.IsAvailable,
                SchoolId = p.SchoolId
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"Playground with ID '{query.Id}' not found.");

        return playground;
    }
}
