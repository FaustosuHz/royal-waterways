using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Repositorios.EntityFramework.config
{
    public class EquipoTelescopioConfiguration : IEntityTypeConfiguration<EquipoTelescopio>
    {
        public void Configure(EntityTypeBuilder<EquipoTelescopio> builder)
        {
            builder.OwnsOne(e => e.AperturaMM, VOAperturaMM =>
            {
                VOAperturaMM.Property(v => v.Value);
            });

            builder.OwnsOne(e => e.RelacionFocal, VORelacionFocal =>
            {
                VORelacionFocal.Property(v => v.Value);
            });

            builder.OwnsOne(e => e.DistanciaFocalMM, VODistanciaFocalMM =>
            {
                VODistanciaFocalMM.Property(v => v.Value);
            });

            builder.OwnsOne(e => e.PesoKg, VOPesoKg =>
            {
                VOPesoKg.Property(v => v.Value);
            });
        }
    }
}