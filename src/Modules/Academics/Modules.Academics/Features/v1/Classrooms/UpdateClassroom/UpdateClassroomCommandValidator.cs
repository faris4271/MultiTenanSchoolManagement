using FluentValidation;
using FSH.Modules.Academics.Contracts.v1.Classrooms.UpdateClassroom;

namespace FSH.Modules.Academics.Features.v1.Classrooms.UpdateClassroom;

public sealed class UpdateClassroomCommandValidator : AbstractValidator<UpdateClassroomCommand>
{
    public UpdateClassroomCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Classroom ID is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(300).WithMessage("Name must not exceed 300 characters.");

        RuleFor(x => x.MaxCapacity)
            .GreaterThan(0).WithMessage("Max capacity must be greater than 0.");
    }
}
