using Mediator;

namespace FSH.Modules.Academics.Contracts.v1.Students.DeleteStudent;

public sealed record DeleteStudentCommand(Guid Id) : ICommand<Unit>;
