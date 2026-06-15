using FSH.Framework.Core.Domain;
using FSH.Modules.Administration.Domain.ValueObjects;

namespace FSH.Modules.Administration.Domain;

public class SchoolManagement : AggregateRoot<Guid>, IAuditableEntity, ISoftDeletable, IHasTenant
{
    public string Name { get; private set; } = default!;
    public string MediumOfStudy { get; private set; } = default!;
    public Address Address { get; private set; } = default!;

    public DateTimeOffset CreatedOnUtc { get; }
    public string? CreatedBy { get; }
    public DateTimeOffset? LastModifiedOnUtc { get; }
    public string? LastModifiedBy { get; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedOnUtc { get; set; }
    public string? DeletedBy { get; }
    public string TenantId { get; set; } = default!;

    private SchoolManagement() { }

    public static SchoolManagement Create(string name, string mediumOfStudy, Address address)
    {
        return new SchoolManagement
        {
            Id = Guid.NewGuid(),
            Name = name,
            MediumOfStudy = mediumOfStudy,
            Address = address
        };
    }

    public void Update(string name, string mediumOfStudy, Address address)
    {
        Name = name;
        MediumOfStudy = mediumOfStudy;
        Address = address;
    }
}
