using Mediator;

namespace FSH.Modules.Academics.Contracts.v1.Classrooms.CreateClassroom;

public sealed record CreateClassroomCommand(
    string Name,
    int MaxCapacity,
    Guid SchoolId,
    Guid? TeacherId,
    Guid? EquipmentId) : ICommand<Guid>;
