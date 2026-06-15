using FluentValidation;
using FSH.Modules.Academics.Contracts.v1.Students.PayFees;

namespace FSH.Modules.Academics.Features.v1.Students.PayFees;

public sealed class PayFeesCommandValidator : AbstractValidator<PayFeesCommand>
{
    public PayFeesCommandValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("Student ID is required.");
    }
}
