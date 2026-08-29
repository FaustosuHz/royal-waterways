using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Repositorios.EntityFramework.config
{
    public class ObservacionConfiguration : IEntityTypeConfiguration<Observacion>
    {
        public void Configure(EntityTypeBuilder<Observacion> builder)
        {
            builder.ToTable("Observaciones");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.FechaObservacion)
                .IsRequired();

            // Usuario (1 a muchos)
            builder.HasOne(o => o.Usuario)
                .WithMany()
                .IsRequired();

            // Prestamo (1 a muchos)
            builder.HasOne(o => o.Prestamo)
                .WithMany()
                .IsRequired();

            // ObjetoCeleste (1 a muchos o many-to-one)
            builder.HasOne(o => o.ObjetoCeleste)
                .WithMany()
                .IsRequired();

            // Resultado (nullable)
            builder.Property(o => o.Resultado)
                .HasConversion<int>()
                .IsRequired(false);

            // VO Detalle (nullable)
            builder.OwnsOne(o => o.Detalle, d =>
            {
                d.Property(x => x.Value)
                    .HasColumnName("Detalle")
                    .HasMaxLength(300);
            });
        }
    }
}