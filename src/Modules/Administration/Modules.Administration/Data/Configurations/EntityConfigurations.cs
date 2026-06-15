using Finbuckle.MultiTenant.EntityFrameworkCore.Extensions;
using FSH.Modules.Administration.Domain;
using FSH.Modules.Administration.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Modules.Administration.Data.Configurations;

public class SchoolManagementConfiguration : IEntityTypeConfiguration<SchoolManagement>
{
    public void Configure(EntityTypeBuilder<SchoolManagement> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("Schools", AdministrationModuleConstants.SchemaName)
            .IsMultiTenant();

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(s => s.MediumOfStudy)
            .IsRequired()
            .HasMaxLength(100);

        builder.OwnsOne(s => s.Address, a =>
        {
            a.Property(p => p.Street).HasMaxLength(500).IsRequired();
            a.Property(p => p.City).HasMaxLength(200).IsRequired();
            a.Property(p => p.State).HasMaxLength(200).IsRequired();
            a.Property(p => p.ZipCode).HasMaxLength(20).IsRequired();
            a.Property(p => p.Country).HasMaxLength(200).IsRequired();
        });
    }
}

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("Departments", AdministrationModuleConstants.SchemaName)
            .IsMultiTenant();

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(d => d.Description)
            .HasMaxLength(2000);

        builder.HasOne(d => d.School)
            .WithMany()
            .HasForeignKey(d => d.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class AuditoriumConfiguration : IEntityTypeConfiguration<Auditorium>
{
    public void Configure(EntityTypeBuilder<Auditorium> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("Auditoriums", AdministrationModuleConstants.SchemaName)
            .IsMultiTenant();

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(300);

        builder.HasOne(a => a.School)
            .WithMany()
            .HasForeignKey(a => a.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class PlaygroundConfiguration : IEntityTypeConfiguration<Playground>
{
    public void Configure(EntityTypeBuilder<Playground> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("Playgrounds", AdministrationModuleConstants.SchemaName)
            .IsMultiTenant();

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(300);

        builder.HasOne(p => p.School)
            .WithMany()
            .HasForeignKey(p => p.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class NoticeBoardConfiguration : IEntityTypeConfiguration<NoticeBoard>
{
    public void Configure(EntityTypeBuilder<NoticeBoard> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("NoticeBoards", AdministrationModuleConstants.SchemaName)
            .IsMultiTenant();

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Title)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(n => n.Content)
            .IsRequired()
            .HasMaxLength(5000);

        builder.HasOne(n => n.School)
            .WithMany()
            .HasForeignKey(n => n.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
