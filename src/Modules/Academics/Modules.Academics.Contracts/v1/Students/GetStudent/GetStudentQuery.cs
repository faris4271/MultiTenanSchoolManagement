using Mediator;

namespace FSH.Modules.Academics.Contracts.v1.Students.GetStudent;

public sealed record GetStudentQuery(Guid Id) : IQuery<StudentResponse>;
