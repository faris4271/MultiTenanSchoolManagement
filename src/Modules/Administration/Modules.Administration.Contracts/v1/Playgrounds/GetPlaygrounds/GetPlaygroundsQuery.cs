using FSH.Framework.Shared.Persistence;
using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Playgrounds.GetPlaygrounds;

public sealed class GetPlaygroundsQuery : IPagedQuery, IQuery<PagedResponse<PlaygroundResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? Sort { get; set; }
    public Guid? SchoolId { get; set; }
}
