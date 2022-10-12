using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Back.Models
{
    public partial class ENCUESTAS_DSContext : DbContext
    {
        public ENCUESTAS_DSContext()
        {
        }

        public ENCUESTAS_DSContext(DbContextOptions<ENCUESTAS_DSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Encuestum> Encuesta { get; set; } = null!;
        public virtual DbSet<Preguntum> Pregunta { get; set; } = null!;
        public virtual DbSet<Respuestum> Respuesta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=G10;Database=ENCUESTAS_DS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Encuestum>(entity =>
            {
                entity.HasKey(e => e.Nombre)
                    .HasName("PK__encuesta__75E3EFCEDD4D10C7");

                entity.ToTable("encuesta");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Preguntum>(entity =>
            {
                entity.HasKey(e => new { e.Nombre, e.NombreEncuesta })
                    .HasName("PK__pregunta__C7BBD066DA12B3A2");

                entity.ToTable("pregunta");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEncuesta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Encuesta");

                entity.Property(e => e.Requerido)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Tipo)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.NombreEncuestaNavigation)
                    .WithMany(p => p.Pregunta)
                    .HasForeignKey(d => d.NombreEncuesta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pregunta__Nombre__38996AB5");
            });

            modelBuilder.Entity<Respuestum>(entity =>
            {
                entity.HasKey(e => new { e.NombrePregunta, e.NombreEncuesta })
                    .HasName("PK__respuest__A422B16F175619D9");

                entity.ToTable("respuesta");

                entity.Property(e => e.NombrePregunta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Pregunta");

                entity.Property(e => e.NombreEncuesta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Encuesta");

                entity.Property(e => e.Respuesta)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Nombre)
                    .WithOne(p => p.Respuestum)
                    .HasForeignKey<Respuestum>(d => new { d.NombrePregunta, d.NombreEncuesta })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__respuesta__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
