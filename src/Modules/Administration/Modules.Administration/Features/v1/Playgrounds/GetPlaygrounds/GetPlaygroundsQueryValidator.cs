using FluentValidation;
using FSH.Framework.Web.Validation;
using FSH.Modules.Administration.Contracts.v1.Playgrounds.GetPlaygrounds;

namespace FSH.Modules.Administration.Features.v1.Playgrounds.GetPlaygrounds;

public sealed class GetPlaygroundsQueryValidator : AbstractValidator<GetPlaygroundsQuery>
{
    public GetPlaygroundsQueryValidator()
    {
        Include(new PagedQueryValidator<GetPlaygroundsQuery>());
    }
}
