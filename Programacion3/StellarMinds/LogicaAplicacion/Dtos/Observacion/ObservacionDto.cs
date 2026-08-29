namespace LogicaAplicacion.Dtos.Observacion
{
    public record ObservacionDto(
        int id,
        int usuarioId,
        int prestamoId,
        int objetoCelesteId,
        DateTime fechaObservacion,
        string? resultado,
        string? detalle
    );
}