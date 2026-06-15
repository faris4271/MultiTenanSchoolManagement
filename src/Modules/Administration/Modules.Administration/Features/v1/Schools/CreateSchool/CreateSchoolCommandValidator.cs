using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.Schools.CreateSchool;

namespace FSH.Modules.Administration.Features.v1.Schools.CreateSchool;

public sealed class CreateSchoolCommandValidator : AbstractValidator<CreateSchoolCommand>
{
    public CreateSchoolCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(500);
        RuleFor(x => x.MediumOfStudy).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Street).NotEmpty();
        RuleFor(x => x.City).NotEmpty();
        RuleFor(x => x.State).NotEmpty();
        RuleFor(x => x.Country).NotEmpty();
        RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(20);
    }
}
