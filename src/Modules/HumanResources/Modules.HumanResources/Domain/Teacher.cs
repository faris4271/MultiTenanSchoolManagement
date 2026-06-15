using FSH.Framework.Core.Domain;

namespace FSH.Modules.HumanResources.Domain;

public sealed class Teacher : Employee
{
    public string Subject { get; private set; } = default!;
    public string? Qualification { get; private set; }

    private Teacher() { }

    public static Teacher Create(
        string firstName,
        string lastName,
        string email,
        decimal salary,
        Guid departmentId,
        string subject,
        string? qualification = null)
    {
        return new Teacher
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Salary = salary,
            DepartmentId = departmentId,
            Subject = subject,
            Qualification = qualification
        };
    }
}
