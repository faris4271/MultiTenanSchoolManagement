using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.Playgrounds.DeletePlayground;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.DeletePlayground;

public sealed class DeletePlaygroundCommandValidator : AbstractValidator<DeletePlaygroundCommand>
{
    public DeletePlaygroundCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
