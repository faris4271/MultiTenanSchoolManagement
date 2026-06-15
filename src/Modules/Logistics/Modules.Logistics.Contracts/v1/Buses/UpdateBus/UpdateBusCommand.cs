using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Buses.UpdateBus;

public sealed record UpdateBusCommand(
    Guid Id,
    string LicensePlate,
    Guid DriverId,
    int Capacity,
    List<string>? AreaList) : ICommand<Guid>;
