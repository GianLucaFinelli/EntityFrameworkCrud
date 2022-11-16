using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EntityFrameworkCrud.Models
{
    public partial class EFCrudContext : DbContext
    {
        public EFCrudContext()
        {
        }

        public EFCrudContext(DbContextOptions<EFCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Colegio> Colegio { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AMFF9M4\\SQLEXPRESS;Database=EFCrud;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Alumno_Curso");
            });

            modelBuilder.Entity<Colegio>(entity =>
            {
                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.IdColegioNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdColegio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Curso_Colegio");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
