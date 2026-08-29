using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Repositorios.EntityFramework.config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasDiscriminator<string>("TipoRol")
            .HasValue<Socio>("Socio")
            .HasValue<Administrador>("Administrador")
            .HasValue<Coordinador>("Coordinador");

            builder.OwnsOne(u => u.Nombre, VONombre =>
            {
                VONombre.Property(v => v.Value);
            });

            builder.OwnsOne(u => u.Apellido, VOApellido =>
            {
                VOApellido.Property(v => v.Value);
            });

            builder.OwnsOne(u => u.Direccion, VODireccion =>
            {
                VODireccion.Property(v => v.Value);
            });

            builder.OwnsOne(u => u.Telefono, VOTelefono =>
            {
                VOTelefono.Property(v => v.Value);
            });

            builder.OwnsOne(u => u.Email, VOEmail =>
            {
                VOEmail.Property(v => v.Value);
            });

            builder.OwnsOne(u => u.NombreUsuario, VONombreUsuario =>
            {
                VONombreUsuario.Property(v => v.Value);
            });

            builder.OwnsOne(u => u.Contrasenia, VOContrasenia =>
            {
                VOContrasenia.Property(v => v.Value);
            });
        }
    }
}
