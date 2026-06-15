using FSH.Modules.Academics.Contracts.v1.Classrooms.CreateClassroom;
using FSH.Modules.Academics.Data;
using FSH.Modules.Academics.Domain;
using Mediator;

namespace FSH.Modules.Academics.Features.v1.Classrooms.CreateClassroom;

public sealed class CreateClassroomCommandHandler : ICommandHandler<CreateClassroomCommand, Guid>
{
    private readonly AcademicsDbContext _dbContext;

    public CreateClassroomCommandHandler(AcademicsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(CreateClassroomCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var classroom = Classroom.Create(
            command.Name,
            command.MaxCapacity,
            command.SchoolId,
            command.TeacherId,
            command.EquipmentId);

        _dbContext.Classrooms.Add(classroom);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return classroom.Id;
    }
}
