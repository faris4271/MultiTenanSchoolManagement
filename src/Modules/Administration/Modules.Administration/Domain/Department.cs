using FSH.Framework.Core.Domain;

namespace FSH.Modules.Administration.Domain;

public class Department : AggregateRoot<Guid>, IAuditableEntity, ISoftDeletable, IHasTenant
{
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
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

    private Department() { }

    public static Department Create(string name, Guid schoolId, string? description = null)
    {
        return new Department
        {
            Id = Guid.NewGuid(),
            Name = name,
            SchoolId = schoolId,
            Description = description
        };
    }

    public void Update(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}
