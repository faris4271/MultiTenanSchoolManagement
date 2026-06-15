using FSH.Framework.Core.Domain;

namespace FSH.Modules.HumanResources.Domain.Events;

public sealed record SalaryPaidDomainEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    string? CorrelationId,
    string? TenantId,
    Guid EmployeeId,
    decimal Amount) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static SalaryPaidDomainEvent Create(Guid employeeId, decimal amount, string? tenantId = null)
    {
        return DomainEvent.Create<SalaryPaidDomainEvent>((id, occurred) =>
            new SalaryPaidDomainEvent(id, occurred, null, tenantId, employeeId, amount));
    }
}
