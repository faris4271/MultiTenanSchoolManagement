using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.Departments.UpdateDepartment;

namespace FSH.Modules.Administration.Features.v1.Departments.UpdateDepartment;

public sealed class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(300);
    }
}
