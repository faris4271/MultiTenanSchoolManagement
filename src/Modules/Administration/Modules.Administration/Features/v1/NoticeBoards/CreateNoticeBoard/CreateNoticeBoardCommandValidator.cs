using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.NoticeBoards.CreateNoticeBoard;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.CreateNoticeBoard;

public sealed class CreateNoticeBoardCommandValidator : AbstractValidator<CreateNoticeBoardCommand>
{
    public CreateNoticeBoardCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Content).NotEmpty().MaximumLength(5000);
        RuleFor(x => x.SchoolId).NotEmpty();
    }
}
