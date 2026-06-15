using FSH.Framework.Core.Exceptions;
using FSH.Modules.Academics.Contracts.v1.Students.DeleteStudent;
using FSH.Modules.Academics.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Academics.Features.v1.Students.DeleteStudent;

public sealed class DeleteStudentCommandHandler : ICommandHandler<DeleteStudentCommand, Unit>
{
    private readonly AcademicsDbContext _dbContext;

    public DeleteStudentCommandHandler(AcademicsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Unit> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var student = await _dbContext.Students
            .FirstOrDefaultAsync(s => s.Id == command.Id, cancellationToken)
            ?? throw new NotFoundException($"Student with ID '{command.Id}' not found.");

        _dbContext.Students.Remove(student);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
