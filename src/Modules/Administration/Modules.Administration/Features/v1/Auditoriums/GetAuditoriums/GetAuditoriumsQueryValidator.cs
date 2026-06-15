using FluentValidation;
using FSH.Framework.Web.Validation;
using FSH.Modules.Administration.Contracts.v1.Auditoriums.GetAuditoriums;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.GetAuditoriums;

public sealed class GetAuditoriumsQueryValidator : AbstractValidator<GetAuditoriumsQuery>
{
    public GetAuditoriumsQueryValidator()
    {
        Include(new PagedQueryValidator<GetAuditoriumsQuery>());
    }
}
