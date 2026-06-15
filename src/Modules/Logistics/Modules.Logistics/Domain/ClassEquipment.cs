using FSH.Framework.Core.Domain;

namespace FSH.Modules.Logistics.Domain;

public sealed class ClassEquipment : Equipment
{
    public Guid ClassroomId { get; private set; }

    private ClassEquipment() { }

    public static ClassEquipment Create(string name, decimal cost, Guid classroomId, Guid schoolId)
    {
        return new ClassEquipment
        {
            Id = Guid.NewGuid(),
            Name = name,
            Cost = cost,
            ClassroomId = classroomId,
            SchoolId = schoolId,
            IsUnderRepair = false
        };
    }
}
