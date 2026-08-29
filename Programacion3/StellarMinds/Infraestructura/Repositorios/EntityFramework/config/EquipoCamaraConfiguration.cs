using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Repositorios.EntityFramework.config
{
    public class EquipoCamaraConfiguration : IEntityTypeConfiguration<EquipoCamara>
    {
        public void Configure(EntityTypeBuilder<EquipoCamara> builder)
        {
            builder.Property(e => e.TipoSensor);

            builder.OwnsOne(e => e.Resolucion, VOResolucion =>
            {
                VOResolucion.Property(v => v.Value);
            });

            builder.OwnsOne(e => e.TamanioPixelMicras, VOTamanioPixelMicras =>
            {
                VOTamanioPixelMicras.Property(v => v.Value);
            });
        }
    }
}