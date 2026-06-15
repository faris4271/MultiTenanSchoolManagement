using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.Schools.DeleteSchool;

namespace FSH.Modules.Administration.Features.v1.Schools.DeleteSchool;

public sealed class DeleteSchoolCommandValidator : AbstractValidator<DeleteSchoolCommand>
{
    public DeleteSchoolCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
