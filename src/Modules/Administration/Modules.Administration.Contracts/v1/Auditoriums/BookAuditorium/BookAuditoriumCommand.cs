using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Auditoriums.BookAuditorium;

public sealed record BookAuditoriumCommand(
    Guid AuditoriumId,
    int Seats) : ICommand<Guid>;
