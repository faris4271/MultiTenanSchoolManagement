using FSH.Framework.Shared.Persistence;
using Mediator;

namespace FSH.Modules.Academics.Contracts.v1.Classrooms.GetClassrooms;

public sealed class GetClassroomsQuery : IPagedQuery, IQuery<PagedResponse<ClassroomResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? Sort { get; set; }
    public Guid? SchoolId { get; set; }
}
