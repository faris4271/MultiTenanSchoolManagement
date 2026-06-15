using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Auditoriums.CreateAuditorium;

public sealed record CreateAuditoriumCommand(
    string Name,
    int TotalSeats,
    Guid SchoolId) : ICommand<Guid>;
