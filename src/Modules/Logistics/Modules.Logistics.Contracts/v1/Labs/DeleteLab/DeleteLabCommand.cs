using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Labs.DeleteLab;

public sealed record DeleteLabCommand(Guid Id) : ICommand<Unit>;
