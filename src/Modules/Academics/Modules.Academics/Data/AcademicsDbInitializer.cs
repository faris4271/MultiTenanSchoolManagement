using FSH.Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FSH.Modules.Academics.Data;

internal sealed class AcademicsDbInitializer(
    ILogger<AcademicsDbInitializer> logger,
    AcademicsDbContext context) : IDbInitializer
{
    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        if ((await context.Database.GetPendingMigrationsAsync(cancellationToken).ConfigureAwait(false)).Any())
        {
            await context.Database.MigrateAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] applied database migrations for academics module", context.TenantInfo?.Identifier);
        }
    }

    public Task SeedAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
