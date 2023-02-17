using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UnitConversion.Models;

public partial class UnitConversionContext : DbContext
{
    public UnitConversionContext()
    {
    }

    public UnitConversionContext(DbContextOptions<UnitConversionContext> options)
        : base(options)
    {
    }

    

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("Server=LAPTOP-VNQ97EDO;Database=Unit_Conversion;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Units__3214EC270C9AF85E");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ImperialFormula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Imperial_formula");
            entity.Property(e => e.ImperialName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Imperial_Name");
            entity.Property(e => e.MetricFormula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Metric_Formula");
            entity.Property(e => e.MetricName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Metric_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
