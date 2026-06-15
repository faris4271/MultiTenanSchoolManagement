using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Buses.GetBus;

public sealed record GetBusQuery(Guid Id) : IQuery<BusResponse>;
