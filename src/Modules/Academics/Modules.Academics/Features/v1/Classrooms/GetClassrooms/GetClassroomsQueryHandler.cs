using FSH.Framework.Persistence;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.Academics.Contracts.v1.Classrooms;
using FSH.Modules.Academics.Contracts.v1.Classrooms.GetClassrooms;
using FSH.Modules.Academics.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Academics.Features.v1.Classrooms.GetClassrooms;

public sealed class GetClassroomsQueryHandler : IQueryHandler<GetClassroomsQuery, PagedResponse<ClassroomResponse>>
{
    private readonly AcademicsDbContext _dbContext;

    public GetClassroomsQueryHandler(AcademicsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<PagedResponse<ClassroomResponse>> Handle(GetClassroomsQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        IQueryable<Domain.Classroom> classrooms = _dbContext.Classrooms.AsNoTracking();

        if (query.SchoolId.HasValue)
        {
            classrooms = classrooms.Where(c => c.SchoolId == query.SchoolId.Value);
        }

        var projected = classrooms.Select(c => new ClassroomResponse
        {
            Id = c.Id,
            Name = c.Name,
            MaxCapacity = c.MaxCapacity,
            StudentCount = c.StudentCount,
            TeacherId = c.TeacherId,
            EquipmentId = c.EquipmentId,
            SchoolId = c.SchoolId,
        });

        return await projected.ToPagedResponseAsync(query, cancellationToken);
    }
}
