using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Equipments.DeleteEquipment;

public sealed record DeleteEquipmentCommand(Guid Id) : ICommand<Unit>;
