using FluentValidation;
using FSH.Modules.HumanResources.Contracts.v1.Employees.DeleteEmployee;

namespace FSH.Modules.HumanResources.Features.v1.Employees.DeleteEmployee;

public sealed class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Employee ID is required.");
    }
}
