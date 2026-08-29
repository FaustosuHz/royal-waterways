namespace LogicaAplicacion.Dtos.Observacion
{
    public record ObservacionAltaDto(
        int usuarioId,
        int prestamoId,
        int objetoCelesteId,
        DateTime fechaObservacion,
        string? resultado,
        string? detalle
    );
}