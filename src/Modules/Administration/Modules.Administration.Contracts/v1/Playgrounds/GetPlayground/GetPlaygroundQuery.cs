using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Playgrounds.GetPlayground;

public sealed record GetPlaygroundQuery(Guid Id) : IQuery<PlaygroundResponse>;
