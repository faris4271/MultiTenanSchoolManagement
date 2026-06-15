using FSH.Framework.Core.Exceptions;
using FSH.Modules.Academics.Contracts.v1.Students.PayFees;
using FSH.Modules.Academics.Data;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace FSH.Modules.Academics.Features.v1.Students.PayFees;

public sealed class PayFeesCommandHandler : ICommandHandler<PayFeesCommand, Guid>
{
    private readonly AcademicsDbContext _dbContext;

    public PayFeesCommandHandler(AcademicsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Guid> Handle(PayFeesCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var student = await _dbContext.Students
            .FirstOrDefaultAsync(s => s.Id == command.StudentId, cancellationToken)
            ?? throw new NotFoundException($"Student with ID '{command.StudentId}' not found.");

        student.PayFees();
        await _dbContext.SaveChangesAsync(cancellationToken);

        return student.Id;
    }
}
