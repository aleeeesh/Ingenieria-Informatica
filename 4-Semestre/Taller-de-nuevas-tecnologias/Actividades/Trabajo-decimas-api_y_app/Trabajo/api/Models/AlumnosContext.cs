using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_NOTAS.Models;

public partial class AlumnosContext : DbContext
{
    public AlumnosContext()
    {
    }

    public AlumnosContext(DbContextOptions<AlumnosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Nota> Notas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ALUMNOS;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.CodAlumno);

            entity.ToTable("ALUMNO");

            entity.Property(e => e.CodAlumno)
                .ValueGeneratedNever()
                .HasColumnName("COD_ALUMNO");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
        });

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.IdAsignatura);

            entity.ToTable("ASIGNATURA");

            entity.Property(e => e.IdAsignatura).HasColumnName("ID_ASIGNATURA");
            entity.Property(e => e.NomAsignatura)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_ASIGNATURA");
        });

        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.IdNota);

            entity.ToTable("NOTAS");

            entity.Property(e => e.IdNota).HasColumnName("ID_NOTA");
            entity.Property(e => e.CodAlumno).HasColumnName("COD_ALUMNO");
            entity.Property(e => e.IdAsignatura).HasColumnName("ID_ASIGNATURA");
            entity.Property(e => e.NNota).HasColumnName("N_NOTA");
            entity.Property(e => e.Nota1)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("NOTA");

            entity.HasOne(d => d.CodAlumnoNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.CodAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NOTAS_ALUMNO1");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NOTAS_ASIGNATURA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
