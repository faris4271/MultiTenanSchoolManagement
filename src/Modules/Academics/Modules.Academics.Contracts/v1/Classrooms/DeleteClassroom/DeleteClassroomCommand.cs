using Mediator;

namespace FSH.Modules.Academics.Contracts.v1.Classrooms.DeleteClassroom;

public sealed record DeleteClassroomCommand(Guid Id) : ICommand<Unit>;
