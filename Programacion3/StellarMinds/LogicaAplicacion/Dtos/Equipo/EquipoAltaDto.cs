namespace LogicaAplicacion.Dtos.Equipo
{
    public record EquipoAltaDto(
        string marca,
        string modelo,
        int cantidadDisponible,
        string tipoEquipo,

        string? tipoSensor,
        string? resolucion,
        decimal? tamanioPixelMicras,

        string? tipoMontura,
        decimal? cargaUtilKg,
        bool? esGoTo,

        decimal? diametroMM,
        decimal? anguloVisionGrados,

        decimal? aperturaMM,
        string? relacionFocal,
        decimal? distanciaFocalMM,
        decimal? pesoKg
    );
}