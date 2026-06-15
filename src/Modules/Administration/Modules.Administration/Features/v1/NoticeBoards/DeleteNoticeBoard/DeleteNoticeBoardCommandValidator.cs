using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.NoticeBoards.DeleteNoticeBoard;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.DeleteNoticeBoard;

public sealed class DeleteNoticeBoardCommandValidator : AbstractValidator<DeleteNoticeBoardCommand>
{
    public DeleteNoticeBoardCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
