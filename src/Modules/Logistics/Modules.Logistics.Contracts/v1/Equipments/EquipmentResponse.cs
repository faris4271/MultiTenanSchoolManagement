namespace FSH.Modules.Logistics.Contracts.v1.Equipments;

public record EquipmentResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public decimal Cost { get; init; }
    public bool IsUnderRepair { get; init; }
    public string EquipmentType { get; init; } = default!;
    public Guid? LabId { get; init; }
    public Guid? ClassroomId { get; init; }
    public Guid SchoolId { get; init; }
}
