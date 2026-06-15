using FSH.Framework.Core.Exceptions;
using FSH.Modules.Academics.Contracts.v1.Classrooms;
using FSH.Modules.Academics.Contracts.v1.Classrooms.GetClassroom;
using FSH.Modules.Academics.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Academics.Features.v1.Classrooms.GetClassroom;

public sealed class GetClassroomQueryHandler : IQueryHandler<GetClassroomQuery, ClassroomResponse>
{
    private readonly AcademicsDbContext _dbContext;

    public GetClassroomQueryHandler(AcademicsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<ClassroomResponse> Handle(GetClassroomQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        return await _dbContext.Classrooms.AsNoTracking()
            .Where(c => c.Id == query.Id)
            .Select(c => new ClassroomResponse
            {
                Id = c.Id,
                Name = c.Name,
                MaxCapacity = c.MaxCapacity,
                StudentCount = c.StudentCount,
                TeacherId = c.TeacherId,
                EquipmentId = c.EquipmentId,
                SchoolId = c.SchoolId,
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException($"Classroom with ID '{query.Id}' not found.");
    }
}
