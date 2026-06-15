using FSH.Framework.Core.Domain;

namespace FSH.Modules.Academics.Domain;

public sealed class HigherSecondaryStudent : Student
{
    public string Stream { get; private set; } = default!;
    public string? ElectiveSubject { get; private set; }

    private HigherSecondaryStudent() { }

    public static HigherSecondaryStudent Create(
        string firstName,
        string lastName,
        string email,
        string stream,
        Guid classroomId,
        string? electiveSubject = null)
    {
        return new HigherSecondaryStudent
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Stream = stream,
            ClassroomId = classroomId,
            ElectiveSubject = electiveSubject,
            EnrollmentDate = DateTime.UtcNow,
            FeesPaid = false
        };
    }
}
