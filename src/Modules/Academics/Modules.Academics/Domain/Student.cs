using FSH.Framework.Core.Domain;
using FSH.Modules.Academics.Domain.Events;

namespace FSH.Modules.Academics.Domain;

public abstract class Student : AggregateRoot<Guid>, IAuditableEntity, ISoftDeletable, IHasTenant
{
    public string FirstName { get; protected set; } = default!;
    public string LastName { get; protected set; } = default!;
    public string Email { get; protected set; } = default!;
    public DateTime EnrollmentDate { get; protected set; }
    public Guid ClassroomId { get; protected set; }
    public virtual Classroom? Classroom { get; protected set; }
    public bool FeesPaid { get; protected set; }

    public DateTimeOffset CreatedOnUtc { get; }
    public string? CreatedBy { get; }
    public DateTimeOffset? LastModifiedOnUtc { get; }
    public string? LastModifiedBy { get; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedOnUtc { get; set; }
    public string? DeletedBy { get; }
    public string TenantId { get; set; } = default!;

    protected Student() { }

    public void PayFees()
    {
        if (FeesPaid)
            throw new InvalidOperationException("Fees already paid.");
        FeesPaid = true;
        AddDomainEvent(FeePaidDomainEvent.Create(Id, TenantId));
    }

    public void Update(string firstName, string lastName, string email, Guid classroomId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        ClassroomId = classroomId;
    }

    public void AssignClassroom(Guid classroomId)
    {
        ClassroomId = classroomId;
    }
}
