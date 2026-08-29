using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Repositorios.EntityFramework.config
{
    public class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {
            builder.HasKey(prestamo => prestamo.Id);

            builder.HasOne(prestamo => prestamo.Usuario)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(prestamo => prestamo.Telescopio)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(prestamo => prestamo.Montura)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(prestamo => prestamo.Camara)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(prestamo => prestamo.Ocular)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(prestamo => prestamo.FechaInicio);

            builder.Property(prestamo => prestamo.FechaFin);

            builder.Property(prestamo => prestamo.Estado);
        }
    }
}