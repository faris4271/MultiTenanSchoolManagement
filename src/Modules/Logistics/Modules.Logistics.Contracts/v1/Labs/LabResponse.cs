namespace FSH.Modules.Logistics.Contracts.v1.Labs;

public record LabResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public Guid InchargeId { get; init; }
    public bool IsCurrentlyOccupied { get; init; }
    public Guid SchoolId { get; init; }
}
