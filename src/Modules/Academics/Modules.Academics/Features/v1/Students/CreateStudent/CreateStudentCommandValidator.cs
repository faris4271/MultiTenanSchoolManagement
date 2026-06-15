using FluentValidation;
using FSH.Modules.Academics.Contracts.v1.Students.CreateStudent;

namespace FSH.Modules.Academics.Features.v1.Students.CreateStudent;

public sealed class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(200).WithMessage("First name must not exceed 200 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(200).WithMessage("Last name must not exceed 200 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.")
            .MaximumLength(300).WithMessage("Email must not exceed 300 characters.");

        RuleFor(x => x.StudentType)
            .NotEmpty().WithMessage("Student type is required.")
            .Must(x => x is "Primary" or "HigherSecondary")
            .WithMessage("Student type must be 'Primary' or 'HigherSecondary'.");

        RuleFor(x => x.ClassroomId)
            .NotEmpty().WithMessage("Classroom ID is required.");

        RuleFor(x => x.GradeLevel)
            .NotNull().WithMessage("Grade level is required when student type is 'Primary'.")
            .When(x => x.StudentType == "Primary");

        RuleFor(x => x.Stream)
            .NotEmpty().WithMessage("Stream is required when student type is 'HigherSecondary'.")
            .When(x => x.StudentType == "HigherSecondary");
    }
}
