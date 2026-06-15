using FluentValidation;
using FSH.Modules.HumanResources.Contracts.v1.Employees.UpdateEmployee;

namespace FSH.Modules.HumanResources.Features.v1.Employees.UpdateEmployee;

public sealed class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Employee ID is required.");

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
    }
}
