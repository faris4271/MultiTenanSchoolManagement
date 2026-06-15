using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Playgrounds.DeletePlayground;

public sealed record DeletePlaygroundCommand(Guid Id) : ICommand<Unit>;
