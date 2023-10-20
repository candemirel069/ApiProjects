using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Locataion.Data.Entities;

public partial class LocationDbContext : DbContext
{
    public LocationDbContext()
    {
    }

    public LocationDbContext(DbContextOptions<LocationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ilce> Ilce { get; set; }

    public virtual DbSet<Sehir> Sehir { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyLocationDB;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ilce>(entity =>
        {
            entity.Property(e => e.Adi).HasMaxLength(50);

            entity.HasOne(d => d.Sehir).WithMany(p => p.Ilce)
                .HasForeignKey(d => d.SehirId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ilce_Sehir");
        });

        modelBuilder.Entity<Sehir>(entity =>
        {
            entity.Property(e => e.Adi).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
