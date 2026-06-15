using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.Departments.CreateDepartment;

namespace FSH.Modules.Administration.Features.v1.Departments.CreateDepartment;

public sealed class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(300);
        RuleFor(x => x.Description).MaximumLength(2000);
        RuleFor(x => x.SchoolId).NotEmpty();
    }
}
