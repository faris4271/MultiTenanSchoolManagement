using Finbuckle.MultiTenant.Abstractions;
using Finbuckle.MultiTenant.EntityFrameworkCore.Extensions;
using FSH.Framework.Persistence.Context;
using FSH.Framework.Shared.Multitenancy;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.Logistics.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace FSH.Modules.Logistics.Data;

public sealed class LogisticsDbContext : BaseDbContext
{
    public LogisticsDbContext(
        IMultiTenantContextAccessor<AppTenantInfo> multiTenantContextAccessor,
        DbContextOptions<LogisticsDbContext> options,
        IOptions<DatabaseOptions> settings,
        IHostEnvironment environment) : base(multiTenantContextAccessor, options, settings, environment) { }

    public DbSet<Bus> Buses => Set<Bus>();
    public DbSet<Lab> Labs => Set<Lab>();
    public DbSet<Equipment> Equipments => Set<Equipment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.Entity<Bus>(b =>
        {
            b.ToTable("Buses", LogisticsModuleConstants.SchemaName);
            b.IsMultiTenant();
            b.HasKey(x => x.Id);
            b.Property(x => x.LicensePlate).IsRequired().HasMaxLength(50);
            b.Property(x => x.AreaList).HasColumnType("jsonb");
            b.OwnsMany(x => x.AreaList, a =>
            {
                a.ToTable("BusAreas", LogisticsModuleConstants.SchemaName);
            });
        });

        modelBuilder.Entity<Lab>(b =>
        {
            b.ToTable("Labs", LogisticsModuleConstants.SchemaName);
            b.IsMultiTenant();
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).IsRequired().HasMaxLength(300);
        });

        modelBuilder.Entity<Equipment>(b =>
        {
            b.ToTable("Equipments", LogisticsModuleConstants.SchemaName);
            b.IsMultiTenant();
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).IsRequired().HasMaxLength(300);
            b.Property(x => x.Cost).HasColumnType("decimal(18,2)");
            b.HasDiscriminator<string>("EquipmentType")
                .HasValue<LabEquipment>("Lab")
                .HasValue<ClassEquipment>("Class");
            b.Property("EquipmentType").HasMaxLength(50);
        });

        modelBuilder.Entity<LabEquipment>(b =>
        {
            b.HasOne(l => l.Lab)
                .WithMany()
                .HasForeignKey(l => l.LabId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        base.OnModelCreating(modelBuilder);
    }
}
