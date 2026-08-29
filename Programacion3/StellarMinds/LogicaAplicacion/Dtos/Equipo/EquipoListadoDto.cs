namespace LogicaAplicacion.Dtos.Equipo
{
    public record EquipoListadoDto(
        int Id,
        string Marca,
        string Modelo,
        int CantidadDisponible,
        string TipoEquipo,

        // camara
        string? TipoSensor,
        string? Resolucion,
        decimal? TamanioPixelMicras,

        // montura
        string? TipoMontura,
        decimal? CargaUtilKg,
        bool? EsGoTo,

        // ocular
        decimal? DiametroMM,
        decimal? AnguloVisionGrados,

        // telescopio
        decimal? AperturaMM,
        string? RelacionFocal,
        decimal? DistanciaFocalMM,
        decimal? PesoKg
    );
}