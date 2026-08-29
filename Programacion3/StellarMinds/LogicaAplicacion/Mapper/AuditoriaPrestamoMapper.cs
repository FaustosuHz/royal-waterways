using Dominio.Entidades;
using LogicaAplicacion.Dtos.AuditoriaPrestamo;
using LogicaAplicacion.Dtos.Prestamo;
using LogicaAplicacion.Dtos.Usuario;

namespace LogicaAplicacion.Mapper
{
    public class AuditoriaPrestamoMapper
    {
        public static AuditoriaPrestamo FromDto(
            AuditoriaPrestamoDto dto,
            Prestamo prestamo,
            Usuario coordinador)
        {
            return new AuditoriaPrestamo(
                prestamo,
                coordinador,
                (TipoAccionAuditoria)dto.accion
            );
        }

        public static AuditoriaPrestamoDto ToDto(AuditoriaPrestamo auditoria)
        {
            return new AuditoriaPrestamoDto(
                auditoria.Id,
                auditoria.Prestamo.Id,
                auditoria.Coordinador.Id,
                (int)auditoria.Accion
            );
        }

        public static AuditoriaPrestamoMostrarDto ToMostrarDto(
            AuditoriaPrestamo auditoria,
            PrestamoDetalleDto prestamo,
            UsuarioListadoDto coordinador)
        {
            return new AuditoriaPrestamoMostrarDto(
                auditoria.Id,
                prestamo,
                coordinador,
                (int)auditoria.Accion
            );
        }
    }
}