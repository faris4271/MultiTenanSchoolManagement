using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.NoticeBoards.UpdateNoticeBoard;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.UpdateNoticeBoard;

public sealed class UpdateNoticeBoardCommandValidator : AbstractValidator<UpdateNoticeBoardCommand>
{
    public UpdateNoticeBoardCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Content).NotEmpty().MaximumLength(5000);
    }
}
