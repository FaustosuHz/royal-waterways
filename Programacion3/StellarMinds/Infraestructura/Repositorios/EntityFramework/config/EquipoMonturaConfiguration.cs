using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Repositorios.EntityFramework.config
{
    public class EquipoMonturaConfiguration : IEntityTypeConfiguration<EquipoMontura>
    {
        public void Configure(EntityTypeBuilder<EquipoMontura> builder)
        {
            builder.Property(e => e.TipoMontura);
            builder.Property(e => e.EsGoTo);

            builder.OwnsOne(e => e.CargaUtilKg, VOCargaUtilKg =>
            {
                VOCargaUtilKg.Property(v => v.Value);
            });
        }
    }
}