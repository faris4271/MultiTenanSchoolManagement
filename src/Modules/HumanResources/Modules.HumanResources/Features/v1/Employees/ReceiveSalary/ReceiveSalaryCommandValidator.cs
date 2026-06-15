using FluentValidation;
using FSH.Modules.HumanResources.Contracts.v1.Employees.ReceiveSalary;

namespace FSH.Modules.HumanResources.Features.v1.Employees.ReceiveSalary;

public sealed class ReceiveSalaryCommandValidator : AbstractValidator<ReceiveSalaryCommand>
{
    public ReceiveSalaryCommandValidator()
    {
        RuleFor(x => x.EmployeeId)
            .NotEmpty().WithMessage("Employee ID is required.");
    }
}
