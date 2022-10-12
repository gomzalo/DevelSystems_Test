using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Back.Models.DB
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
                entity.ToTable("encuesta");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Preguntum>(entity =>
            {
                entity.ToTable("pregunta");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdEncuesta).HasColumnName("ID_Encuesta");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

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

                entity.HasOne(d => d.IdEncuestaNavigation)
                    .WithMany(p => p.Pregunta)
                    .HasForeignKey(d => d.IdEncuesta)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__pregunta__ID_Enc__01142BA1");
            });

            modelBuilder.Entity<Respuestum>(entity =>
            {
                entity.ToTable("respuesta");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdEncuesta).HasColumnName("ID_Encuesta");

                entity.Property(e => e.IdPregunta).HasColumnName("ID_Pregunta");

                entity.Property(e => e.Respuesta)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEncuestaNavigation)
                    .WithMany(p => p.Respuesta)
                    .HasForeignKey(d => d.IdEncuesta)
                    .HasConstraintName("FK__respuesta__ID_En__04E4BC85");

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.Respuesta)
                    .HasForeignKey(d => d.IdPregunta)
                    .HasConstraintName("FK__respuesta__ID_Pr__03F0984C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
