using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Schools.UpdateSchool;

public sealed record UpdateSchoolCommand(
    Guid Id,
    string Name,
    string MediumOfStudy,
    string Street,
    string City,
    string State,
    string ZipCode,
    string Country) : ICommand<Guid>;
