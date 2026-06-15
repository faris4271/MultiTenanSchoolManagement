using FluentValidation;
using FSH.Framework.Web.Validation;
using FSH.Modules.Academics.Contracts.v1.Students.GetStudents;

namespace FSH.Modules.Academics.Features.v1.Students.GetStudents;

public sealed class GetStudentsQueryValidator : AbstractValidator<GetStudentsQuery>
{
    public GetStudentsQueryValidator()
    {
        Include(new PagedQueryValidator<GetStudentsQuery>());
    }
}
