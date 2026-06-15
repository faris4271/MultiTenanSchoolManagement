using FSH.Framework.Core.Domain;

namespace FSH.Modules.Academics.Domain.Events;

public sealed record FeePaidDomainEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    string? CorrelationId,
    string? TenantId,
    Guid StudentId) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static FeePaidDomainEvent Create(Guid studentId, string? tenantId = null)
    {
        return DomainEvent.Create<FeePaidDomainEvent>((id, occurred) =>
            new FeePaidDomainEvent(id, occurred, null, tenantId, studentId));
    }
}
