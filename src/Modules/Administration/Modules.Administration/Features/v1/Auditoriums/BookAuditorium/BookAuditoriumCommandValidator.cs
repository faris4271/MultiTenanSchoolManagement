using FluentValidation;
using FSH.Modules.Administration.Contracts.v1.Auditoriums.BookAuditorium;

namespace FSH.Modules.Administration.Features.v1.Auditoriums.BookAuditorium;

public sealed class BookAuditoriumCommandValidator : AbstractValidator<BookAuditoriumCommand>
{
    public BookAuditoriumCommandValidator()
    {
        RuleFor(x => x.AuditoriumId).NotEmpty();
        RuleFor(x => x.Seats).GreaterThan(0);
    }
}
