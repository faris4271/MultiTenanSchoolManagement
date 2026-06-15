using FSH.Framework.Shared.Persistence;
using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Buses.GetBuses;

public sealed class GetBusesQuery : IPagedQuery, IQuery<PagedResponse<BusResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? Sort { get; set; }
}
