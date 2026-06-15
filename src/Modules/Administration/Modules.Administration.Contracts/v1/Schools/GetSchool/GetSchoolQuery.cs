using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Schools.GetSchool;

public sealed record GetSchoolQuery(Guid Id) : IQuery<SchoolResponse>;
