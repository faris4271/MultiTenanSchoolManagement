using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.Auditoriums.CreateAuditorium;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.CreateAuditorium;

public sealed class CreateAuditoriumCommandValidator : AbstractValidator<CreateAuditoriumCommand>
{
    public CreateAuditoriumCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(300);
        RuleFor(x => x.TotalSeats).GreaterThan(0);
        RuleFor(x => x.SchoolId).NotEmpty();
    }
}
