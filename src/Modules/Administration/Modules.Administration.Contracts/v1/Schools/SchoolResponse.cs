namespace FSH.Modules.Administration.Contracts.v1.Schools;

public record SchoolResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string MediumOfStudy { get; init; } = default!;
    public string Street { get; init; } = default!;
    public string City { get; init; } = default!;
    public string State { get; init; } = default!;
    public string ZipCode { get; init; } = default!;
    public string Country { get; init; } = default!;
}
