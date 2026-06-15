using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Equipments.CreateEquipment;

public sealed record CreateEquipmentCommand(
    string Name,
    decimal Cost,
    string EquipmentType,
    Guid? LabId,
    Guid? ClassroomId,
    Guid SchoolId) : ICommand<Guid>;
