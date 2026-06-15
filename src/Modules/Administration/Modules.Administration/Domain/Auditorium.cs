using FSH.Framework.Core.Domain;

namespace FSH.Modules.Administration.Domain;

public class Auditorium : AggregateRoot<Guid>, IAuditableEntity, ISoftDeletable, IHasTenant
{
    public string Name { get; private set; } = default!;
    public int TotalSeats { get; private set; }
    public int SeatsOccupied { get; private set; }
    public Guid SchoolId { get; private set; }
    public virtual SchoolManagement? School { get; private set; }

    public DateTimeOffset CreatedOnUtc { get; }
    public string? CreatedBy { get; }
    public DateTimeOffset? LastModifiedOnUtc { get; }
    public string? LastModifiedBy { get; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedOnUtc { get; set; }
    public string? DeletedBy { get; }
    public string TenantId { get; set; } = default!;

    private Auditorium() { }

    public static Auditorium Create(string name, int totalSeats, Guid schoolId)
    {
        return new Auditorium
        {
            Id = Guid.NewGuid(),
            Name = name,
            TotalSeats = totalSeats,
            SeatsOccupied = 0,
            SchoolId = schoolId
        };
    }

    public void Update(string name, int totalSeats)
    {
        Name = name;
        TotalSeats = totalSeats;
    }

    public bool CanBook(int seats)
    {
        return SeatsOccupied + seats <= TotalSeats;
    }

    public void Book(int seats)
    {
        if (!CanBook(seats))
            throw new InvalidOperationException($"Cannot book {seats} seats. Only {TotalSeats - SeatsOccupied} available.");
        SeatsOccupied += seats;
    }

    public void Release(int seats)
    {
        SeatsOccupied = Math.Max(0, SeatsOccupied - seats);
    }
}
