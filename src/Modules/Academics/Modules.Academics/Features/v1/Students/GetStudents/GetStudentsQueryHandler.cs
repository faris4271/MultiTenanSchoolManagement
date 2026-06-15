using FSH.Framework.Persistence;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.Academics.Contracts.v1.Students;
using FSH.Modules.Academics.Contracts.v1.Students.GetStudents;
using FSH.Modules.Academics.Data;
using FSH.Modules.Academics.Domain;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Academics.Features.v1.Students.GetStudents;

public sealed class GetStudentsQueryHandler : IQueryHandler<GetStudentsQuery, PagedResponse<StudentResponse>>
{
    private readonly AcademicsDbContext _dbContext;

    public GetStudentsQueryHandler(AcademicsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<PagedResponse<StudentResponse>> Handle(GetStudentsQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        IQueryable<Student> students = _dbContext.Students.AsNoTracking();

        if (query.ClassroomId.HasValue)
        {
            students = students.Where(s => s.ClassroomId == query.ClassroomId.Value);
        }

        if (!string.IsNullOrWhiteSpace(query.StudentType))
        {
            students = query.StudentType switch
            {
                "Primary" => students.OfType<PrimaryStudent>(),
                "HigherSecondary" => students.OfType<HigherSecondaryStudent>(),
                _ => students
            };
        }

        var totalCount = await students.LongCountAsync(cancellationToken);
        var pageNumber = query.PageNumber is null or <= 0 ? 1 : query.PageNumber.Value;
        var pageSize = query.PageSize is null or <= 0 ? 20 : Math.Min(query.PageSize.Value, 100);
        var totalPages = totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)pageSize);

        if (pageNumber > totalPages && totalPages > 0)
        {
            pageNumber = totalPages;
        }

        var items = await students
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var responses = items.Select(s => new StudentResponse
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,
            StudentType = s switch
            {
                PrimaryStudent => "Primary",
                HigherSecondaryStudent => "HigherSecondary",
                _ => "Unknown"
            },
            EnrollmentDate = s.EnrollmentDate,
            ClassroomId = s.ClassroomId,
            FeesPaid = s.FeesPaid,
            GradeLevel = s is PrimaryStudent p ? p.GradeLevel : null,
            Section = s is PrimaryStudent ps ? ps.Section : null,
            Stream = s is HigherSecondaryStudent hs ? hs.Stream : null,
            ElectiveSubject = s is HigherSecondaryStudent hse ? hse.ElectiveSubject : null,
        }).ToList();

        return new PagedResponse<StudentResponse>
        {
            Items = responses,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = totalPages
        };
    }
}
