using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.Auditoriums.UpdateAuditorium;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.UpdateAuditorium;

public sealed class UpdateAuditoriumCommandValidator : AbstractValidator<UpdateAuditoriumCommand>
{
    public UpdateAuditoriumCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(300);
        RuleFor(x => x.TotalSeats).GreaterThan(0);
    }
}
