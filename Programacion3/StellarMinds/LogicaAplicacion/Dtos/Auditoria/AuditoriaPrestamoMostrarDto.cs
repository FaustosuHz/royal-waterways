using LogicaAplicacion.Dtos.Prestamo;
using LogicaAplicacion.Dtos.Usuario;

namespace LogicaAplicacion.Dtos.AuditoriaPrestamo
{
    public record AuditoriaPrestamoMostrarDto(
        int id,
        PrestamoDetalleDto prestamo,
        UsuarioListadoDto coordinador,
        int accion
    );
}