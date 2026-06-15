using FluentValidation;
using FSH.Modules.Academics.Contracts.v1.Students.DeleteStudent;

namespace FSH.Modules.Academics.Features.v1.Students.DeleteStudent;

public sealed class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
{
    public DeleteStudentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Student ID is required.");
    }
}
