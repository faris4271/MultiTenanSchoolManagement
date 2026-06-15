using FSH.Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FSH.Modules.HumanResources.Data;

internal sealed class HumanResourcesDbInitializer(
    ILogger<HumanResourcesDbInitializer> logger,
    HumanResourcesDbContext context) : IDbInitializer
{
    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        if ((await context.Database.GetPendingMigrationsAsync(cancellationToken).ConfigureAwait(false)).Any())
        {
            await context.Database.MigrateAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] applied database migrations for human resources module", context.TenantInfo?.Identifier);
        }
    }

    public Task SeedAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
