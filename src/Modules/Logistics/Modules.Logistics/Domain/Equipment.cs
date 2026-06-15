using FSH.Framework.Core.Domain;

namespace FSH.Modules.Logistics.Domain;

public abstract class Equipment : AggregateRoot<Guid>, IAuditableEntity, ISoftDeletable, IHasTenant
{
    public string Name { get; protected set; } = default!;
    public decimal Cost { get; protected set; }
    public bool IsUnderRepair { get; protected set; }
    public Guid SchoolId { get; protected set; }

    public DateTimeOffset CreatedOnUtc { get; }
    public string? CreatedBy { get; }
    public DateTimeOffset? LastModifiedOnUtc { get; }
    public string? LastModifiedBy { get; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedOnUtc { get; set; }
    public string? DeletedBy { get; }
    public string TenantId { get; set; } = default!;

    protected Equipment() { }

    public void MarkForRepair()
    {
        if (IsUnderRepair)
            throw new InvalidOperationException("Equipment is already under repair.");
        IsUnderRepair = true;
    }

    public void CompleteRepair()
    {
        if (!IsUnderRepair)
            throw new InvalidOperationException("Equipment is not under repair.");
        IsUnderRepair = false;
    }

    public void Update(string name, decimal cost)
    {
        Name = name;
        Cost = cost;
    }
}
