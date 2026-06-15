using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.Schools.UpdateSchool;

namespace FSH.Modules.Administration.Features.v1.Schools.UpdateSchool;

public sealed class UpdateSchoolCommandValidator : AbstractValidator<UpdateSchoolCommand>
{
    public UpdateSchoolCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(500);
        RuleFor(x => x.MediumOfStudy).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Street).NotEmpty();
        RuleFor(x => x.City).NotEmpty();
        RuleFor(x => x.State).NotEmpty();
        RuleFor(x => x.Country).NotEmpty();
        RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(20);
    }
}
