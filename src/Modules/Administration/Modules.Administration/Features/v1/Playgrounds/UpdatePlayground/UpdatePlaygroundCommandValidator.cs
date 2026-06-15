using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.Playgrounds.UpdatePlayground;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.UpdatePlayground;

public sealed class UpdatePlaygroundCommandValidator : AbstractValidator<UpdatePlaygroundCommand>
{
    public UpdatePlaygroundCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(300);
    }
}
