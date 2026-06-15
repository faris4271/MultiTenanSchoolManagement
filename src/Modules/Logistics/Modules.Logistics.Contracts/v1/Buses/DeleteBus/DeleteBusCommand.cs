using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Buses.DeleteBus;

public sealed record DeleteBusCommand(Guid Id) : ICommand<Unit>;
