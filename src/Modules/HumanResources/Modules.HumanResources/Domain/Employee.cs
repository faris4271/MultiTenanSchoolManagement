using FSH.Framework.Core.Domain;
using FSH.Modules.HumanResources.Domain.Events;

namespace FSH.Modules.HumanResources.Domain;

public abstract class Employee : AggregateRoot<Guid>, IAuditableEntity, ISoftDeletable, IHasTenant
{
    public string FirstName { get; protected set; } = default!;
    public string LastName { get; protected set; } = default!;
    public string Email { get; protected set; } = default!;
    public decimal Salary { get; protected set; }
    public Guid DepartmentId { get; protected set; }
    public bool IsCheckedIn { get; protected set; }
    public DateTime? LastCheckInUtc { get; protected set; }

    public DateTimeOffset CreatedOnUtc { get; }
    public string? CreatedBy { get; }
    public DateTimeOffset? LastModifiedOnUtc { get; }
    public string? LastModifiedBy { get; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedOnUtc { get; set; }
    public string? DeletedBy { get; }
    public string TenantId { get; set; } = default!;

    protected Employee() { }

    public void ReceiveSalary()
    {
        AddDomainEvent(SalaryPaidDomainEvent.Create(Id, Salary, TenantId));
    }

    public void CheckIn()
    {
        if (IsCheckedIn)
            throw new InvalidOperationException("Employee is already checked in.");
        IsCheckedIn = true;
        LastCheckInUtc = DateTime.UtcNow;
    }

    public void CheckOut()
    {
        if (!IsCheckedIn)
            throw new InvalidOperationException("Employee is not checked in.");
        IsCheckedIn = false;
    }

    public void UpdateBasicInfo(string firstName, string lastName, string email, decimal salary, Guid departmentId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Salary = salary;
        DepartmentId = departmentId;
    }
}
