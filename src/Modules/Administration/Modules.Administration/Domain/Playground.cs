using FSH.Framework.Core.Domain;

namespace FSH.Modules.Administration.Domain;

public class Playground : AggregateRoot<Guid>, IAuditableEntity, ISoftDeletable, IHasTenant
{
    public string Name { get; private set; } = default!;
    public bool IsAvailable { get; private set; }
    public Guid SchoolId { get; private set; }
    public virtual SchoolManagement? School { get; private set; }

    public DateTimeOffset CreatedOnUtc { get; }
    public string? CreatedBy { get; }
    public DateTimeOffset? LastModifiedOnUtc { get; }
    public string? LastModifiedBy { get; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedOnUtc { get; set; }
    public string? DeletedBy { get; }
    public string TenantId { get; set; } = default!;

    private Playground() { }

    public static Playground Create(string name, Guid schoolId)
    {
        return new Playground
        {
            Id = Guid.NewGuid(),
            Name = name,
            IsAvailable = true,
            SchoolId = schoolId
        };
    }

    public void Update(string name)
    {
        Name = name;
    }

    public bool IsOccupied() => !IsAvailable;

    public void Occupy()
    {
        if (!IsAvailable)
            throw new InvalidOperationException("Playground is already occupied.");
        IsAvailable = false;
    }

    public void Release()
    {
        IsAvailable = true;
    }
}
