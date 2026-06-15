using FSH.Framework.Core.Exceptions;
using FSH.Modules.Academics.Contracts.v1.Students;
using FSH.Modules.Academics.Contracts.v1.Students.GetStudent;
using FSH.Modules.Academics.Data;
using FSH.Modules.Academics.Domain;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Academics.Features.v1.Students.GetStudent;

public sealed class GetStudentQueryHandler : IQueryHandler<GetStudentQuery, StudentResponse>
{
    private readonly AcademicsDbContext _dbContext;

    public GetStudentQueryHandler(AcademicsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<StudentResponse> Handle(GetStudentQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        var student = await _dbContext.Students.AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == query.Id, cancellationToken)
            ?? throw new NotFoundException($"Student with ID '{query.Id}' not found.");

        return new StudentResponse
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            StudentType = student switch
            {
                PrimaryStudent => "Primary",
                HigherSecondaryStudent => "HigherSecondary",
                _ => "Unknown"
            },
            EnrollmentDate = student.EnrollmentDate,
            ClassroomId = student.ClassroomId,
            FeesPaid = student.FeesPaid,
            GradeLevel = student is PrimaryStudent p ? p.GradeLevel : null,
            Section = student is PrimaryStudent ps ? ps.Section : null,
            Stream = student is HigherSecondaryStudent hs ? hs.Stream : null,
            ElectiveSubject = student is HigherSecondaryStudent hse ? hse.ElectiveSubject : null,
        };
    }
}
