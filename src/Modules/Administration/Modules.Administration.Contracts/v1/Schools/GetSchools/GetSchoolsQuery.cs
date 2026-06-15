using FSH.Framework.Shared.Persistence;
using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Schools.GetSchools;

public sealed class GetSchoolsQuery : IPagedQuery, IQuery<PagedResponse<SchoolResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? Sort { get; set; }
    public string? Search { get; set; }
}
