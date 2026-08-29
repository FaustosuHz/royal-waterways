namespace LogicaAplicacion.Dtos.AuditoriaPrestamo
{
    public record AuditoriaPrestamoDto(
        int id,
        int prestamoId,
        int coordinadorId,
        int accion
    );
}