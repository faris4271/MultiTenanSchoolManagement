using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Auditoriums.GetAuditorium;

public sealed record GetAuditoriumQuery(Guid Id) : IQuery<AuditoriumResponse>;
