using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Labs.CreateLab;

public sealed record CreateLabCommand(
    string Name,
    Guid InchargeId,
    Guid SchoolId) : ICommand<Guid>;
