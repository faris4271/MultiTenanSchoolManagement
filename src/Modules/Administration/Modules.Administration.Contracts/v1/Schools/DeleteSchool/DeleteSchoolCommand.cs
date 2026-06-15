using Mediator;

namespace FSH.Modules.Administration.Contracts.v1.Schools.DeleteSchool;

public sealed record DeleteSchoolCommand(Guid Id) : ICommand<Unit>;
