using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Equipments.GetEquipment;

public sealed record GetEquipmentQuery(Guid Id) : IQuery<EquipmentResponse>;
