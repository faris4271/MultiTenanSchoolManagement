using Finbuckle.MultiTenant.Abstractions;
using FSH.Framework.Persistence.Context;
using FSH.Framework.Shared.Multitenancy;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.Administration.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace FSH.Modules.Administration.Data;

public sealed class AdministrationDbContext : BaseDbContext
{
    public AdministrationDbContext(
        IMultiTenantContextAccessor<AppTenantInfo> multiTenantContextAccessor,
        DbContextOptions<AdministrationDbContext> options,
        IOptions<DatabaseOptions> settings,
        IHostEnvironment environment) : base(multiTenantContextAccessor, options, settings, environment) { }

    public DbSet<SchoolManagement> Schools => Set<SchoolManagement>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Auditorium> Auditoriums => Set<Auditorium>();
    public DbSet<Playground> Playgrounds => Set<Playground>();
    public DbSet<NoticeBoard> NoticeBoards => Set<NoticeBoard>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdministrationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
