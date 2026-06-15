using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Labs.UpdateLab;

public sealed record UpdateLabCommand(
    Guid Id,
    string Name,
    Guid InchargeId) : ICommand<Guid>;
