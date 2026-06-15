using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.Playgrounds.CreatePlayground;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.CreatePlayground;

public sealed class CreatePlaygroundCommandValidator : AbstractValidator<CreatePlaygroundCommand>
{
    public CreatePlaygroundCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(300);
        RuleFor(x => x.SchoolId).NotEmpty();
    }
}
