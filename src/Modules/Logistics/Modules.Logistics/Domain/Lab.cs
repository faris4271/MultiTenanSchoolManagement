using FSH.Framework.Core.Domain;

namespace FSH.Modules.Logistics.Domain;

public class Lab : AggregateRoot<Guid>, IAuditableEntity, ISoftDeletable, IHasTenant
{
    public string Name { get; private set; } = default!;
    public Guid InchargeId { get; private set; }
    public bool IsCurrentlyOccupied { get; private set; }
    public Guid SchoolId { get; private set; }

    public DateTimeOffset CreatedOnUtc { get; }
    public string? CreatedBy { get; }
    public DateTimeOffset? LastModifiedOnUtc { get; }
    public string? LastModifiedBy { get; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedOnUtc { get; set; }
    public string? DeletedBy { get; }
    public string TenantId { get; set; } = default!;

    private Lab() { }

    public static Lab Create(string name, Guid inchargeId, Guid schoolId)
    {
        return new Lab
        {
            Id = Guid.NewGuid(),
            Name = name,
            InchargeId = inchargeId,
            IsCurrentlyOccupied = false,
            SchoolId = schoolId
        };
    }

    public void Update(string name, Guid inchargeId)
    {
        Name = name;
        InchargeId = inchargeId;
    }

    public bool IsOccupied() => IsCurrentlyOccupied;

    public void Occupy()
    {
        if (IsCurrentlyOccupied)
            throw new InvalidOperationException("Lab is currently occupied.");
        IsCurrentlyOccupied = true;
    }

    public void Release()
    {
        IsCurrentlyOccupied = false;
    }
}
