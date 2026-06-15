using FluentValidation;
using FSH.Framework.Web.Validation;
using FSH.Modules.Administration.Contracts.v1.NoticeBoards.GetNoticeBoards;

namespace FSH.Modules.Administration.Features.v1.NoticeBoards.GetNoticeBoards;

public sealed class GetNoticeBoardsQueryValidator : AbstractValidator<GetNoticeBoardsQuery>
{
    public GetNoticeBoardsQueryValidator()
    {
        Include(new PagedQueryValidator<GetNoticeBoardsQuery>());
    }
}
