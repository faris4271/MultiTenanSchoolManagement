using Finbuckle.MultiTenant.Abstractions;
using Finbuckle.MultiTenant.EntityFrameworkCore.Extensions;
using FSH.Framework.Persistence.Context;
using FSH.Framework.Shared.Multitenancy;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.HumanResources.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace FSH.Modules.HumanResources.Data;

public sealed class HumanResourcesDbContext : BaseDbContext
{
    public HumanResourcesDbContext(
        IMultiTenantContextAccessor<AppTenantInfo> multiTenantContextAccessor,
        DbContextOptions<HumanResourcesDbContext> options,
        IOptions<DatabaseOptions> settings,
        IHostEnvironment environment) : base(multiTenantContextAccessor, options, settings, environment) { }

    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.Entity<Employee>(b =>
        {
            b.ToTable("Employees", HumanResourcesModuleConstants.SchemaName);
            b.IsMultiTenant();
            b.HasKey(e => e.Id);
            b.Property(e => e.FirstName).IsRequired().HasMaxLength(200);
            b.Property(e => e.LastName).IsRequired().HasMaxLength(200);
            b.Property(e => e.Email).IsRequired().HasMaxLength(300);
            b.Property(e => e.Salary).HasColumnType("decimal(18,2)");
            b.HasDiscriminator<string>("EmployeeType")
                .HasValue<Teacher>("Teacher")
                .HasValue<SupportStaff>("SupportStaff");
            b.Property("EmployeeType").HasMaxLength(50);
        });

        modelBuilder.Entity<Teacher>(b =>
        {
            b.Property(t => t.Subject).IsRequired().HasMaxLength(200);
            b.Property(t => t.Qualification).HasMaxLength(200);
        });

        modelBuilder.Entity<SupportStaff>(b =>
        {
            b.Property(s => s.Role).IsRequired().HasMaxLength(200);
            b.Property(s => s.AssignedArea).HasMaxLength(300);
        });

        base.OnModelCreating(modelBuilder);
    }
}
