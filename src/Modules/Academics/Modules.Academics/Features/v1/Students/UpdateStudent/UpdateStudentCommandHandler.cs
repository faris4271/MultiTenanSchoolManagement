using FSH.Framework.Core.Exceptions;
using FSH.Modules.Academics.Contracts.v1.Students.UpdateStudent;
using FSH.Modules.Academics.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Academics.Features.v1.Students.UpdateStudent;

public sealed class UpdateStudentCommandHandler : ICommandHandler<UpdateStudentCommand, Guid>
{
    private readonly AcademicsDbContext _dbContext;

    public UpdateStudentCommandHandler(AcademicsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var student = await _dbContext.Students
            .FirstOrDefaultAsync(s => s.Id == command.Id, cancellationToken)
            ?? throw new NotFoundException($"Student with ID '{command.Id}' not found.");

        student.Update(command.FirstName, command.LastName, command.Email, command.ClassroomId);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return student.Id;
    }
}
