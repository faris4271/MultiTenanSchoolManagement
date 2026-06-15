using FSH.Framework.Shared.Persistence;
using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Auditoriums.GetAuditoriums;

public sealed class GetAuditoriumsQuery : IPagedQuery, IQuery<PagedResponse<AuditoriumResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? Sort { get; set; }
    public Guid? SchoolId { get; set; }
}
