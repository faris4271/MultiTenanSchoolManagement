using FSH.Framework.Shared.Persistence;
using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Equipments.GetEquipments;

public sealed class GetEquipmentsQuery : IPagedQuery, IQuery<PagedResponse<EquipmentResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? Sort { get; set; }
    public string? EquipmentType { get; set; }
    public Guid? SchoolId { get; set; }
    public bool? IsUnderRepair { get; set; }
}
