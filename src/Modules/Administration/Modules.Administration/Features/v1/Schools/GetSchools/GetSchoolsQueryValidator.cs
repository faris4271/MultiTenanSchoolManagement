using FluentValidation;
using FSH.Framework.Web.Validation;
using FSH.Modules.Administration.Contracts.v1.Schools.GetSchools;

namespace FSH.Modules.Administration.Features.v1.Schools.GetSchools;

public sealed class GetSchoolsQueryValidator : AbstractValidator<GetSchoolsQuery>
{
    public GetSchoolsQueryValidator()
    {
        Include(new PagedQueryValidator<GetSchoolsQuery>());
    }
}
