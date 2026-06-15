using FSH.Framework.Core.Domain;

namespace FSH.Modules.Academics.Domain;

public class Classroom : AggregateRoot<Guid>, IAuditableEntity, ISoftDeletable, IHasTenant
{
    public string Name { get; private set; } = default!;
    public int MaxCapacity { get; private set; }
    public int StudentCount { get; private set; }
    public Guid? TeacherId { get; private set; }
    public Guid? EquipmentId { get; private set; }
    public Guid SchoolId { get; private set; }

    public DateTimeOffset CreatedOnUtc { get; }
    public string? CreatedBy { get; }
    public DateTimeOffset? LastModifiedOnUtc { get; }
    public string? LastModifiedBy { get; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedOnUtc { get; set; }
    public string? DeletedBy { get; }
    public string TenantId { get; set; } = default!;

    private Classroom() { }

    public static Classroom Create(string name, int maxCapacity, Guid schoolId, Guid? teacherId = null, Guid? equipmentId = null)
    {
        return new Classroom
        {
            Id = Guid.NewGuid(),
            Name = name,
            MaxCapacity = maxCapacity,
            StudentCount = 0,
            SchoolId = schoolId,
            TeacherId = teacherId,
            EquipmentId = equipmentId
        };
    }

    public void Update(string name, int maxCapacity, Guid? teacherId, Guid? equipmentId)
    {
        Name = name;
        MaxCapacity = maxCapacity;
        TeacherId = teacherId;
        EquipmentId = equipmentId;
    }

    public bool CanEnroll() => StudentCount < MaxCapacity;

    public void EnrollStudent()
    {
        if (!CanEnroll())
            throw new InvalidOperationException("Classroom is at full capacity.");
        StudentCount++;
    }

    public void RemoveStudent()
    {
        StudentCount = Math.Max(0, StudentCount - 1);
    }
}
