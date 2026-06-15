using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Playgrounds.UpdatePlayground;

public sealed record UpdatePlaygroundCommand(
    Guid Id,
    string Name) : ICommand<Guid>;
