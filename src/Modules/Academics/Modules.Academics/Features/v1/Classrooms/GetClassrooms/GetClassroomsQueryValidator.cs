using FluentValidation;
using FSH.Framework.Web.Validation;
using FSH.Modules.Academics.Contracts.v1.Classrooms.GetClassrooms;

namespace FSH.Modules.Academics.Features.v1.Classrooms.GetClassrooms;

public sealed class GetClassroomsQueryValidator : AbstractValidator<GetClassroomsQuery>
{
    public GetClassroomsQueryValidator()
    {
        Include(new PagedQueryValidator<GetClassroomsQuery>());
    }
}
