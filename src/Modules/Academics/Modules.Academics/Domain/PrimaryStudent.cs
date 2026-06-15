using FSH.Framework.Core.Domain;

namespace FSH.Modules.Academics.Domain;

public sealed class PrimaryStudent : Student
{
    public int GradeLevel { get; private set; }
    public string? Section { get; private set; }

    private PrimaryStudent() { }

    public static PrimaryStudent Create(
        string firstName,
        string lastName,
        string email,
        int gradeLevel,
        Guid classroomId,
        string? section = null)
    {
        return new PrimaryStudent
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            GradeLevel = gradeLevel,
            ClassroomId = classroomId,
            Section = section,
            EnrollmentDate = DateTime.UtcNow,
            FeesPaid = false
        };
    }
}
