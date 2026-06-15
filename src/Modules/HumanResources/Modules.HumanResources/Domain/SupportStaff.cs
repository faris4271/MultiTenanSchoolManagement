using FSH.Framework.Core.Domain;

namespace FSH.Modules.HumanResources.Domain;

public sealed class SupportStaff : Employee
{
    public string Role { get; private set; } = default!;
    public string? AssignedArea { get; private set; }

    private SupportStaff() { }

    public static SupportStaff Create(
        string firstName,
        string lastName,
        string email,
        decimal salary,
        Guid departmentId,
        string role,
        string? assignedArea = null)
    {
        return new SupportStaff
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Salary = salary,
            DepartmentId = departmentId,
            Role = role,
            AssignedArea = assignedArea
        };
    }
}
