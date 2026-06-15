using Mediator;

namespace FSH.Modules.Academics.Contracts.v1.Classrooms.UpdateClassroom;

public sealed record UpdateClassroomCommand(
    Guid Id,
    string Name,
    int MaxCapacity,
    Guid? TeacherId,
    Guid? EquipmentId) : ICommand<Guid>;
