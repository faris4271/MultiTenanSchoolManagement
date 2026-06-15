using Mediator;

namespace FSH.Modules.Academics.Contracts.v1.Students.PayFees;

public sealed record PayFeesCommand(Guid StudentId) : ICommand<Guid>;
