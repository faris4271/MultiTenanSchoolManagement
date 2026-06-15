namespace FSH.Modules.Administration.Contracts.v1.Departments;

public record DepartmentResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public Guid SchoolId { get; init; }
}
