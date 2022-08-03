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
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Materia> Materias { get; set; } = null!;
        public virtual DbSet<Cuatrimestre> Cuatrimestres { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-43DVFJ7\\SQLEXPRESS;Database=Estudiante;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificacione>(entity =>
            {
                entity.HasKey(e => e.IdCal)
                    .HasName("PK__Califica__0FA7805667936916");

                entity.Property(e => e.IdCal).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Calificacion).HasColumnType("numeric(20, 0)");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdMathNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdMath)
                    .HasConstraintName("FK_IdMath");
            });

            modelBuilder.Entity<Cuatrimestre>(entity =>
            {
                entity.HasKey(e => e.IdCuatrimestre)
                    .HasName("PK__Cuatrimestre");

                entity.Property(e => e.IdCuatrimestre).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdStudent)
                    .HasName("PK__Estudian__61B35104A5E46612");

                entity.Property(e => e.IdStudent).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Carrera)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.IdMath)
                    .HasName("PK__Materias__4E66499D56BE1FF2");

                entity.Property(e => e.IdMath).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

             
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
