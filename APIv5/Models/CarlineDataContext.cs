using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIv5.Models;

public partial class CarlineDataContext : DbContext
{
    public CarlineDataContext()
    {
    }

    public CarlineDataContext(DbContextOptions<CarlineDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=AZURE_SQL_CONNECTIONSTRING");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImagePath).HasColumnName("Image Path");
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(50)
                .HasColumnName("License Plate");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
