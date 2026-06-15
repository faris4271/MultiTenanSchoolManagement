using FluentValidation;
using FSH.Modules.Academics.Contracts.v1.Classrooms.DeleteClassroom;

namespace FSH.Modules.Academics.Features.v1.Classrooms.DeleteClassroom;

public sealed class DeleteClassroomCommandValidator : AbstractValidator<DeleteClassroomCommand>
{
    public DeleteClassroomCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Classroom ID is required.");
    }
}
