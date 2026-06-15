using FluentValidation;
using FSH.Modules.HumanResources.Contracts.v1.Employees.CreateEmployee;

namespace FSH.Modules.HumanResources.Features.v1.Employees.CreateEmployee;

public sealed class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(200).WithMessage("First name must not exceed 200 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(200).WithMessage("Last name must not exceed 200 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.")
            .MaximumLength(300).WithMessage("Email must not exceed 300 characters.");

        RuleFor(x => x.Salary)
            .GreaterThan(0).WithMessage("Salary must be greater than 0.");

        RuleFor(x => x.DepartmentId)
            .NotEmpty().WithMessage("Department ID is required.");

        RuleFor(x => x.EmployeeType)
            .NotEmpty().WithMessage("Employee type is required.")
            .Must(x => x is "Teacher" or "SupportStaff")
            .WithMessage("Employee type must be 'Teacher' or 'SupportStaff'.");

        RuleFor(x => x.Subject)
            .NotEmpty().WithMessage("Subject is required when employee type is 'Teacher'.")
            .When(x => x.EmployeeType == "Teacher");

        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("Role is required when employee type is 'SupportStaff'.")
            .When(x => x.EmployeeType == "SupportStaff");
    }
}
