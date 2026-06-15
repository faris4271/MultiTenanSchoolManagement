using FluentValidation;
using FSH.Modules.Academics.Contracts.v1.Students.UpdateStudent;

namespace FSH.Modules.Academics.Features.v1.Students.UpdateStudent;

public sealed class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Student ID is required.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(200).WithMessage("First name must not exceed 200 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(200).WithMessage("Last name must not exceed 200 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(300).WithMessage("Email must not exceed 300 characters.");

        RuleFor(x => x.ClassroomId)
            .NotEmpty().WithMessage("Classroom ID is required.");
    }
}
