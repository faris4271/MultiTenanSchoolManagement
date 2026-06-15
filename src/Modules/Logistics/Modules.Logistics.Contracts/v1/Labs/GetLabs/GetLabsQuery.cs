using FSH.Framework.Shared.Persistence;
using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Labs.GetLabs;

public sealed class GetLabsQuery : IPagedQuery, IQuery<PagedResponse<LabResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? Sort { get; set; }
    public Guid? SchoolId { get; set; }
}
