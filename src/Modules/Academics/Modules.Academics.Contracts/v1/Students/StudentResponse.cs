namespace FSH.Modules.Academics.Contracts.v1.Students;

public record StudentResponse
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string StudentType { get; init; } = default!;
    public DateTime EnrollmentDate { get; init; }
    public Guid ClassroomId { get; init; }
    public bool FeesPaid { get; init; }
    public int? GradeLevel { get; init; }
    public string? Section { get; init; }
    public string? Stream { get; init; }
    public string? ElectiveSubject { get; init; }
}
