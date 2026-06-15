using FluentValidation;
using FSH.Framework.Web.Validation;
using FSH.Modules.HumanResources.Contracts.v1.Employees.GetEmployees;

namespace FSH.Modules.HumanResources.Features.v1.Employees.GetEmployees;

public sealed class GetEmployeesQueryValidator : AbstractValidator<GetEmployeesQuery>
{
    public GetEmployeesQueryValidator()
    {
        Include(new PagedQueryValidator<GetEmployeesQuery>());
    }
}
