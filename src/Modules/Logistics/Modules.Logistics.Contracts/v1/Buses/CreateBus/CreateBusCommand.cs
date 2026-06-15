using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Buses.CreateBus;

public sealed record CreateBusCommand(
    string LicensePlate,
    Guid DriverId,
    int Capacity,
    List<string>? AreaList) : ICommand<Guid>;
