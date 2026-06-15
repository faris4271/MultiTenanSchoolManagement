using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Auditoriums.UpdateAuditorium;

public sealed record UpdateAuditoriumCommand(
    Guid Id,
    string Name,
    int TotalSeats) : ICommand<Guid>;
