using FSH.Framework.Core.Domain;

namespace FSH.Modules.Logistics.Domain;

public  class LabEquipment : Equipment
{
    public Guid LabId { get; private set; }
    public virtual Lab? Lab { get; private set; }

    private LabEquipment() { }

    public static LabEquipment Create(string name, decimal cost, Guid labId, Guid schoolId)
    {
        return new LabEquipment
        {
            Id = Guid.NewGuid(),
            Name = name,
            Cost = cost,
            LabId = labId,
            SchoolId = schoolId,
            IsUnderRepair = false
        };
    }
}
