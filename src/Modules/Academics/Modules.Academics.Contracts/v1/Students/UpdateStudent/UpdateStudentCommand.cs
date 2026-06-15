using Mediator;

namespace FSH.Modules.Academics.Contracts.v1.Students.UpdateStudent;

public sealed record UpdateStudentCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    Guid ClassroomId) : ICommand<Guid>;
