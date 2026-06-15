using FluentValidation;
using FSH.Modules.HumanResources.Contracts.v1.Employees.CheckIn;

namespace FSH.Modules.HumanResources.Features.v1.Employees.CheckIn;

public sealed class CheckInCommandValidator : AbstractValidator<CheckInCommand>
{
    public CheckInCommandValidator()
    {
        RuleFor(x => x.EmployeeId)
            .NotEmpty().WithMessage("Employee ID is required.");
    }
}
