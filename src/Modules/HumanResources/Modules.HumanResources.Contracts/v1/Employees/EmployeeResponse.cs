namespace FSH.Modules.HumanResources.Contracts.v1.Employees;

public record EmployeeResponse
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public decimal Salary { get; init; }
    public Guid DepartmentId { get; init; }
    public bool IsCheckedIn { get; init; }
    public DateTime? LastCheckInUtc { get; init; }
    public string EmployeeType { get; init; } = default!;
    public string? Subject { get; init; }
    public string? Qualification { get; init; }
    public string? Role { get; init; }
    public string? AssignedArea { get; init; }
}
