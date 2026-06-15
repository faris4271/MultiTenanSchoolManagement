namespace FSH.Modules.Academics.Contracts.v1.Classrooms;

public record ClassroomResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public int MaxCapacity { get; init; }
    public int StudentCount { get; init; }
    public Guid? TeacherId { get; init; }
    public Guid? EquipmentId { get; init; }
    public Guid SchoolId { get; init; }
}
