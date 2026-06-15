using FluentValidation;
using FSH.Modules.Academics.Contracts.v1.Classrooms.CreateClassroom;

namespace FSH.Modules.Academics.Features.v1.Classrooms.CreateClassroom;

public sealed class CreateClassroomCommandValidator : AbstractValidator<CreateClassroomCommand>
{
    public CreateClassroomCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(300).WithMessage("Name must not exceed 300 characters.");

        RuleFor(x => x.MaxCapacity)
            .GreaterThan(0).WithMessage("Max capacity must be greater than 0.");

        RuleFor(x => x.SchoolId)
            .NotEmpty().WithMessage("School ID is required.");
    }
}
