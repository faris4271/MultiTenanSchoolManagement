namespace FSH.Modules.Logistics.Contracts.v1.Buses;

public record BusResponse
{
    public Guid Id { get; init; }
    public string LicensePlate { get; init; } = default!;
    public Guid DriverId { get; init; }
    public int Capacity { get; init; }
    public int SeatsOccupied { get; init; }
    public int SeatsAvailable { get; init; }
    public List<string> AreaList { get; init; } = [];
}
