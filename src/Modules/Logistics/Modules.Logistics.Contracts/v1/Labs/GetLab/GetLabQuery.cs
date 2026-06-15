using Mediator;

namespace FSH.Modules.Logistics.Contracts.v1.Labs.GetLab;

public sealed record GetLabQuery(Guid Id) : IQuery<LabResponse>;
