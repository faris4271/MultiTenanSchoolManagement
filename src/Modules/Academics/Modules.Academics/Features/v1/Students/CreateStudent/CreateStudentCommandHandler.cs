using FSH.Modules.Academics.Contracts.v1.Students.CreateStudent;
using FSH.Modules.Academics.Data;
using FSH.Modules.Academics.Domain;
using Mediator;

namespace FSH.Modules.Academics.Features.v1.Students.CreateStudent;

public sealed class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand, Guid>
{
    private readonly AcademicsDbContext _dbContext;

    public CreateStudentCommandHandler(AcademicsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        Student student = command.StudentType switch
        {
            "Primary" => PrimaryStudent.Create(
                command.FirstName,
                command.LastName,
                command.Email,
                command.GradeLevel!.Value,
                command.ClassroomId,
                command.Section),
            "HigherSecondary" => HigherSecondaryStudent.Create(
                command.FirstName,
                command.LastName,
                command.Email,
                command.Stream!,
                command.ClassroomId,
                command.ElectiveSubject),
            _ => throw new ArgumentException($"Unknown student type: {command.StudentType}")
        };

        _dbContext.Students.Add(student);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return student.Id;
    }
}
