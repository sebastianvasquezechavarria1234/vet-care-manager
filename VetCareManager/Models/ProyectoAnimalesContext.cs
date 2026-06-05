using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VetCareManager.Models;

public partial class VetCareManagerContext : DbContext
{
    public VetCareManagerContext()
    {
    }

    public VetCareManagerContext(DbContextOptions<VetCareManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animale> Animales { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Propietario> Propietarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-OSQK0RQ;Initial Catalog=proyecto_animales;integrated security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animale>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PK__Animales__A21A73279D58D19A");

            entity.Property(e => e.AnimalId).HasColumnName("AnimalID");
            entity.Property(e => e.Especie).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.PropietarioId).HasColumnName("PropietarioID");

            entity.HasOne(d => d.Propietario).WithMany(p => p.Animales)
                .HasForeignKey(d => d.PropietarioId)
                .HasConstraintName("FK__Animales__Propie__398D8EEE");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Citas__3214EC07813DAD03");

            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
        });

        modelBuilder.Entity<Propietario>(entity =>
        {
            entity.HasKey(e => e.PropietarioId).HasName("PK__Propieta__BDE3FD650C325636");

            entity.Property(e => e.PropietarioId).HasColumnName("PropietarioID");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
