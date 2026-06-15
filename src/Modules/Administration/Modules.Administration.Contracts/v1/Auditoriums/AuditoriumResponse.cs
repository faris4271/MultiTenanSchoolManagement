namespace FSH.Modules.Administration.Contracts.v1.Auditoriums;

public record AuditoriumResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public int TotalSeats { get; init; }
    public int SeatsOccupied { get; init; }
    public int SeatsAvailable => TotalSeats - SeatsOccupied;
    public Guid SchoolId { get; init; }
}
