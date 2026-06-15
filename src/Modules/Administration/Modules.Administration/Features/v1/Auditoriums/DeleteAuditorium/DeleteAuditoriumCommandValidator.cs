using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.Auditoriums.DeleteAuditorium;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.DeleteAuditorium;

public sealed class DeleteAuditoriumCommandValidator : AbstractValidator<DeleteAuditoriumCommand>
{
    public DeleteAuditoriumCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
