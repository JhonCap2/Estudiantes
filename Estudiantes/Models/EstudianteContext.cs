using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Estudiantes.Models
{
    public partial class EstudianteContext : DbContext
    {
        public EstudianteContext()
        {
        }

        public EstudianteContext(DbContextOptions<EstudianteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacione> Calificaciones { get; set; } = null!;
        public virtual DbSet<Cuatrimestre> Cuatrimestres { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Materia> Materias { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-T3S73U1\\SQLEXPRESS;Database=Estudiante;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificacione>(entity =>
            {
                entity.HasKey(e => e.IdCalificaciones)
                    .HasName("PK__Califica__D130F10584E875B1");

                entity.Property(e => e.IdCalificaciones).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Calificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdMathNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdMath)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Materia");
            });

            modelBuilder.Entity<Cuatrimestre>(entity =>
            {
                entity.HasKey(e => e.IdCuatrimestre)
                    .HasName("PK__Cuatrime__B414E683B5CD38F6");

                entity.Property(e => e.IdCuatrimestre).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Numero).HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Cuatrimestres)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdStudent)
                    .HasName("PK__Estudian__61B351048CBB11EC");

                entity.Property(e => e.IdStudent).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Carrera)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.IdMath)
                    .HasName("PK__Materias__4E66499D520BEB35");

                entity.Property(e => e.IdMath).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Materia1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Materia");

                entity.HasOne(d => d.IdCuatrimestreNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.IdCuatrimestre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuatrimestre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
