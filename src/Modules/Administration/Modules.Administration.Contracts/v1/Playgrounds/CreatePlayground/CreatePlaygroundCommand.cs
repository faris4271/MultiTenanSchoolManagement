using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Playgrounds.CreatePlayground;

public sealed record CreatePlaygroundCommand(
    string Name,
    Guid SchoolId) : ICommand<Guid>;
