using Finbuckle.MultiTenant.Abstractions;
using Finbuckle.MultiTenant.EntityFrameworkCore.Extensions;
using FSH.Framework.Persistence.Context;
using FSH.Framework.Shared.Multitenancy;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.Academics.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace FSH.Modules.Academics.Data;

public sealed class AcademicsDbContext : BaseDbContext
{
    public AcademicsDbContext(
        IMultiTenantContextAccessor<AppTenantInfo> multiTenantContextAccessor,
        DbContextOptions<AcademicsDbContext> options,
        IOptions<DatabaseOptions> settings,
        IHostEnvironment environment) : base(multiTenantContextAccessor, options, settings, environment) { }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Classroom> Classrooms => Set<Classroom>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.Entity<Student>(b =>
        {
            b.ToTable("Students", AcademicsModuleConstants.SchemaName);
            b.IsMultiTenant();
            b.HasKey(s => s.Id);
            b.Property(s => s.FirstName).IsRequired().HasMaxLength(200);
            b.Property(s => s.LastName).IsRequired().HasMaxLength(200);
            b.Property(s => s.Email).IsRequired().HasMaxLength(300);
            b.HasDiscriminator<string>("StudentType")
                .HasValue<PrimaryStudent>("Primary")
                .HasValue<HigherSecondaryStudent>("HigherSecondary");
            b.Property("StudentType").HasMaxLength(50);
            b.HasOne(s => s.Classroom)
                .WithMany()
                .HasForeignKey(s => s.ClassroomId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PrimaryStudent>(b =>
        {
            b.Property(p => p.GradeLevel);
            b.Property(p => p.Section).HasMaxLength(50);
        });

        modelBuilder.Entity<HigherSecondaryStudent>(b =>
        {
            b.Property(h => h.Stream).IsRequired().HasMaxLength(200);
            b.Property(h => h.ElectiveSubject).HasMaxLength(200);
        });

        modelBuilder.Entity<Classroom>(b =>
        {
            b.ToTable("Classrooms", AcademicsModuleConstants.SchemaName);
            b.IsMultiTenant();
            b.HasKey(c => c.Id);
            b.Property(c => c.Name).IsRequired().HasMaxLength(300);
        });

        base.OnModelCreating(modelBuilder);
    }
}
