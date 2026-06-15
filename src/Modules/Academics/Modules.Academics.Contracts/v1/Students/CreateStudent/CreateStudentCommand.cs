using Mediator;

namespace FSH.Modules.Academics.Contracts.v1.Students.CreateStudent;

public sealed record CreateStudentCommand(
    string FirstName,
    string LastName,
    string Email,
    string StudentType,
    int? GradeLevel,
    string? Section,
    string? Stream,
    string? ElectiveSubject,
    Guid ClassroomId) : ICommand<Guid>;
