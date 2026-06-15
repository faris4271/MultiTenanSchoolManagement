using FSH.Framework.Core.Exceptions;
using FSH.Modules.Academics.Contracts.v1.Classrooms.UpdateClassroom;
using FSH.Modules.Academics.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Academics.Features.v1.Classrooms.UpdateClassroom;

public sealed class UpdateClassroomCommandHandler : ICommandHandler<UpdateClassroomCommand, Guid>
{
    private readonly AcademicsDbContext _dbContext;

    public UpdateClassroomCommandHandler(AcademicsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(UpdateClassroomCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var classroom = await _dbContext.Classrooms
            .FirstOrDefaultAsync(c => c.Id == command.Id, cancellationToken)
            ?? throw new NotFoundException($"Classroom with ID '{command.Id}' not found.");

        classroom.Update(command.Name, command.MaxCapacity, command.TeacherId, command.EquipmentId);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return classroom.Id;
    }
}
