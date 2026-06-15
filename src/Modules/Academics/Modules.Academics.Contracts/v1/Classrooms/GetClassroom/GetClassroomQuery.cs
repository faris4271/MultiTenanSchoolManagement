using Mediator;

namespace FSH.Modules.Academics.Contracts.v1.Classrooms.GetClassroom;

public sealed record GetClassroomQuery(Guid Id) : IQuery<ClassroomResponse>;
