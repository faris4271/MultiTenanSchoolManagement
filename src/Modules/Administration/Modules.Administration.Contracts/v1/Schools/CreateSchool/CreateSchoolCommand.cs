using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Schools.CreateSchool;

public sealed record CreateSchoolCommand(
    string Name,
    string MediumOfStudy,
    string Street,
    string City,
    string State,
    string ZipCode,
    string Country) : ICommand<Guid>;
