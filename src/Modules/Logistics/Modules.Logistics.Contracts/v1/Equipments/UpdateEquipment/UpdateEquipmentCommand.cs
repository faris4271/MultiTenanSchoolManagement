using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Equipments.UpdateEquipment;

public sealed record UpdateEquipmentCommand(
    Guid Id,
    string Name,
    decimal Cost) : ICommand<Guid>;
