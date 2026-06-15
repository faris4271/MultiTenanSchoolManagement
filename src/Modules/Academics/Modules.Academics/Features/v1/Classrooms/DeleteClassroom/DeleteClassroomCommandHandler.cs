using FSH.Framework.Core.Exceptions;
using FSH.Modules.Academics.Contracts.v1.Classrooms.DeleteClassroom;
using FSH.Modules.Academics.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Academics.Features.v1.Classrooms.DeleteClassroom;

public sealed class DeleteClassroomCommandHandler : ICommandHandler<DeleteClassroomCommand, Unit>
{
    private readonly AcademicsDbContext _dbContext;

    public DeleteClassroomCommandHandler(AcademicsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Unit> Handle(DeleteClassroomCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var classroom = await _dbContext.Classrooms
            .FirstOrDefaultAsync(c => c.Id == command.Id, cancellationToken)
            ?? throw new NotFoundException($"Classroom with ID '{command.Id}' not found.");

        _dbContext.Classrooms.Remove(classroom);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
