using FSH.Framework.Core.Domain;

namespace FSH.Modules.Logistics.Domain;

public class Bus : AggregateRoot<Guid>, IAuditableEntity, ISoftDeletable, IHasTenant
{
    public string LicensePlate { get; private set; } = default!;
    public Guid DriverId { get; private set; }
    public int Capacity { get; private set; }
    public int SeatsOccupied { get; private set; }
    public List<string> AreaList { get; private set; } = [];

    public DateTimeOffset CreatedOnUtc { get; }
    public string? CreatedBy { get; }
    public DateTimeOffset? LastModifiedOnUtc { get; }
    public string? LastModifiedBy { get; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedOnUtc { get; set; }
    public string? DeletedBy { get; }
    public string TenantId { get; set; } = default!;

    private Bus() { }

    public static Bus Create(string licensePlate, Guid driverId, int capacity, List<string>? areaList = null)
    {
        return new Bus
        {
            Id = Guid.NewGuid(),
            LicensePlate = licensePlate,
            DriverId = driverId,
            Capacity = capacity,
            SeatsOccupied = 0,
            AreaList = areaList ?? []
        };
    }

    public void Update(string licensePlate, Guid driverId, int capacity, List<string>? areaList)
    {
        LicensePlate = licensePlate;
        DriverId = driverId;
        Capacity = capacity;
        if (areaList is not null) AreaList = areaList;
    }

    public int ShowSeats() => Capacity - SeatsOccupied;

    public bool CanAllocate(int seats) => SeatsOccupied + seats <= Capacity;

    public void AllocateSeats(int seats)
    {
        if (!CanAllocate(seats))
            throw new InvalidOperationException($"Cannot allocate {seats} seats. Only {ShowSeats()} available.");
        SeatsOccupied += seats;
    }

    public void ReleaseSeats(int seats)
    {
        SeatsOccupied = Math.Max(0, SeatsOccupied - seats);
    }
}
