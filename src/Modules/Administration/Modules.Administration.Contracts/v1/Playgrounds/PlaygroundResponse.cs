namespace FSH.Modules.Administration.Contracts.v1.Playgrounds;

public record PlaygroundResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public bool IsAvailable { get; init; }
    public Guid SchoolId { get; init; }
}
