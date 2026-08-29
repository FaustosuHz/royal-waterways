using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Repositorios.EntityFramework.config
{
    public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasDiscriminator<string>("TipoEquipo")
                .HasValue<EquipoCamara>("Camara")
                .HasValue<EquipoMontura>("Montura")
                .HasValue<EquipoOcular>("Ocular")
                .HasValue<EquipoTelescopio>("Telescopio");

            builder.OwnsOne(e => e.Marca, VOMarca =>
            {
                VOMarca.Property(v => v.Value);
            });

            builder.OwnsOne(e => e.Modelo, VOModelo =>
            {
                VOModelo.Property(v => v.Value);
            });

            builder.OwnsOne(e => e.CantidadDisponible, VOCantidadDisponible =>
            {
                VOCantidadDisponible.Property(v => v.Value);
            });
        }
    }
}