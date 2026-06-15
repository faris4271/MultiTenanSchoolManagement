using FluentValidation;
using FSH.Framework.Web.Validation;
using FSH.Modules.Administration.Contracts.v1.Departments.GetDepartments;

namespace FSH.Modules.Administration.Features.v1.Departments.GetDepartments;

public sealed class GetDepartmentsQueryValidator : AbstractValidator<GetDepartmentsQuery>
{
    public GetDepartmentsQueryValidator()
    {
        Include(new PagedQueryValidator<GetDepartmentsQuery>());
    }
}
