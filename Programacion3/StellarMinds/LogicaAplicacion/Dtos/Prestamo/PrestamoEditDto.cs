namespace LogicaAplicacion.Dtos.Prestamo
{
    public record PrestamoEditDto(
        int usuarioId,
        int telescopioId,
        int monturaId,
        int? camaraId,
        int? ocularId,
        DateTime fechaInicio,
        DateTime fechaFin
    );
}