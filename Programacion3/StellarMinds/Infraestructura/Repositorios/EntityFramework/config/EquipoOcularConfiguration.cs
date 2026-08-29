using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Repositorios.EntityFramework.config
{
    public class EquipoOcularConfiguration : IEntityTypeConfiguration<EquipoOcular>
    {
        public void Configure(EntityTypeBuilder<EquipoOcular> builder)
        {
            builder.OwnsOne(e => e.DiametroMM, VODiametroMM =>
            {
                VODiametroMM.Property(v => v.Value);
            });

            builder.OwnsOne(e => e.AnguloVisionGrados, VOAnguloVisionGrados =>
            {
                VOAnguloVisionGrados.Property(v => v.Value);
            });
        }
    }
}