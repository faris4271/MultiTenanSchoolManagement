using FSH.Framework.Shared.Persistence;
using Mediator;

namespace FSH.Modules.Academics.Contracts.v1.Students.GetStudents;

public sealed class GetStudentsQuery : IPagedQuery, IQuery<PagedResponse<StudentResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? Sort { get; set; }
    public Guid? ClassroomId { get; set; }
    public string? StudentType { get; set; }
}
