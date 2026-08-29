namespace LogicaAplicacion.Dtos.Prestamo
{
    public record PrestamoAltaDto(
        int usuarioId,
        int telescopioId,
        int monturaId,
        int? camaraId,
        int? ocularId,
        DateTime fechaInicio,
        DateTime fechaFin
    );
}