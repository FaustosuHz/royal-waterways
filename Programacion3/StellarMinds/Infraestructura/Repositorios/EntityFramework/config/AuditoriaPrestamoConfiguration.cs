using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Repositorios.EntityFramework.config
{
    public class AuditoriaPrestamoConfiguration
        : IEntityTypeConfiguration<AuditoriaPrestamo>
    {
        public void Configure(
            EntityTypeBuilder<AuditoriaPrestamo> builder
        )
        {
            builder.HasKey(auditoria => auditoria.Id);

            builder.HasOne(auditoria => auditoria.Prestamo)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(auditoria => auditoria.Coordinador)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(auditoria => auditoria.Fecha);

            builder.Property(auditoria => auditoria.Accion);
        }
    }
}