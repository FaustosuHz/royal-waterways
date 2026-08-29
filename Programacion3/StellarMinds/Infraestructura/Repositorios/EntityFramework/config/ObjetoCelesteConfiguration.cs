using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Repositorios.EntityFramework.config
{
    public class ObjetoCelesteConfiguration : IEntityTypeConfiguration<ObjetoCeleste>
    {
        public void Configure(EntityTypeBuilder<ObjetoCeleste> builder)
        {
            builder.HasKey(objetoCeleste => objetoCeleste.Id);

            builder.Property(objetoCeleste => objetoCeleste.Tipo);

            builder.OwnsOne(objetoCeleste => objetoCeleste.Nombre, VONombre =>
            {
                VONombre.Property(valueObject => valueObject.Value);
            });

            builder.OwnsOne(objetoCeleste => objetoCeleste.MagnitudAparente, VOMagnitudAparente =>
            {
                VOMagnitudAparente.Property(valueObject => valueObject.Value);
            });
        }
    }
}