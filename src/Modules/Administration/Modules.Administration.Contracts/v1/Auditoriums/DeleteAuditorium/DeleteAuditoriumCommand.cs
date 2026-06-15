using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Auditoriums.DeleteAuditorium;

public sealed record DeleteAuditoriumCommand(Guid Id) : ICommand<Unit>;
